using CG.Blazor.Forms.Services;
using CG.Validations;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using Microsoft.Extensions.Logging;
using MudBlazor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace CG.Blazor.Forms.Attributes
{
    /// <summary>
    /// This class is an attribute that, when applied to a class causes the form 
    /// generator to render any instances of the class wrapped inside a <see cref="MudTabs"/>
    /// component.
    /// </summary>
    /// <remarks>
    /// <para>
    /// This attribute is only valid when placed on a class definition.
    /// </para>
    /// <para>
    /// This attribute looks for object properties decorated with the <see cref="RenderMudTabPanelAttribute"/>
    /// attribute. Any properties not properly decorated are ignored. Any properties
    /// that aren't of object type are ignored. 
    /// </para>
    /// <para>
    /// This attribute is only effective when applied to the top-level model's class
    /// definition. It is not intended to be used for generating tabs on ancestor
    /// models (child, grandchild great-grandchild, etc).
    /// </para>
    /// </remarks>
    /// <example>
    /// Here is an example of decorating a view-model to render content within a
    /// <see cref="MudTabs"/> component:
    /// <code>
    /// using CG.Blazor.Forms.Attributes;
    /// 
    /// [RenderMudTabs]
    /// class MyModel
    /// {
    ///     [RenderMudTabPanel(Text = "Panel A")]
    ///     public MyModel2 MyProperty { get; set; }
    /// }
    /// </code>
    /// </example>
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class RenderMudTabsAttribute : RenderObjectAttribute
    {
        // *******************************************************************
        // Public methods.
        // *******************************************************************

        #region Public methods
        
        /// <inheritdoc/>
        public override int Generate(
            RenderTreeBuilder builder, 
            int index, 
            IHandleEvent eventTarget, 
            Stack<object> path, 
            PropertyInfo prop, 
            ILogger<IFormGenerator> logger
            )
        {
            // Validate the parameters before attempting to use them.
            Guard.Instance().ThrowIfNull(builder, nameof(builder))
                .ThrowIfLessThanZero(index, nameof(index))
                .ThrowIfNull(path, nameof(path))
                .ThrowIfNull(logger, nameof(logger));

            try
            {
                // If we get here then we are trying to render MudTabs component with
                //   the specified property embedded as child content.

                // Should never happen, but, pffft, check it anyway.
                if (false == path.Any())
                {
                    // Let the world know what we're doing.
                    logger.LogDebug(
                        "RenderMudTabsAttribute::Generate called with an empty path!"
                        );

                    // Return the index.
                    return index;
                }

                // Let the world know what we're doing.
                logger.LogDebug(
                    "Rendering a MudTabs around the '{ObjType}' view-model. [idx: '{Index}']",
                    path.First().GetType().Name,
                    index
                    );

                // Get any non-default attribute values (overrides).
                var attributes = ToAttributes();

                // Render the MudTabs control.
                index = builder.RenderUIComponent<MudTabs>(
                    index,
                    attributes: attributes,
                    contentDelegate: tabsBuilder =>
                    {
                        // Render any properties decorated with MudTabPanel attributes.
                        RenderTabPanels(
                            tabsBuilder,
                            0,
                            eventTarget,
                            path,
                            prop,
                            logger
                            );
                    });

                // Return the index.
                return index;
            }
            catch (Exception ex)
            {
                // Give the error better context.
                throw new FormGenerationException(
                    message: "Failed to render a mud tab panel! " +
                        "See inner exception(s) for more detail.",
                    innerException: ex
                    );
            }
        }

        #endregion

        // *******************************************************************
        // Private methods.
        // *******************************************************************

        #region Private methods

        /// <summary>
        /// This method iterates through child any properties decorated with 
        /// MudTabPanel attributes, and renders them.
        /// </summary>
        /// <param name="builder">The builder to use for the operation.</param>
        /// <param name="index">The index to use for the operation.</param>
        /// <param name="eventTarget">The event target to use for the 
        /// operation.</param>
        /// <param name="path">The path to the current model.</param>
        /// <param name="prop">The reflection information for the property.</param>
        /// <param name="logger">The logger to use for the operation.</param>
        /// <returns>The index after rendering is complete.</returns>
        private int RenderTabPanels(
            RenderTreeBuilder builder,
            int index,
            IHandleEvent eventTarget,
            Stack<object> path,
            PropertyInfo prop,
            ILogger<IFormGenerator> logger
            )
        {
            // If we get here then we're trying to iterate through the 
            //   properties on the specified model, wrapping each one
            //   in a MudTabsPanel component before rendering it.

            // Get the model reference.
            var model = path.Peek();

            // Get the model's type.
            var modelType = model.GetType();

            // Get the child properties.
            var childProps = modelType.GetProperties()
                .Where(x => x.CanWrite && x.CanRead);

            // Loop through the child properties.
            foreach (var childProp in childProps)
            {
                // Create a complete property path, for logging.
                var propPath = $"{string.Join('.', path.Reverse().Select(x => x.GetType().Name))}.{childProp.Name}";

                // Is the property missing the attribute?
                var attr = childProp.GetCustomAttribute<RenderMudTabPanelAttribute>();
                if (null == attr)
                {
                    // Let the world know what we're doing.
                    logger.LogDebug(
                        "Not rendering property '{PropPath}'. [idx: '{Index}'] since " +
                        "it isn't decorated with a MudTabPanelAttribute attribute.",
                        propPath,
                        index
                        );

                    // Ignore this property.
                    continue;
                }

                // Get the value of the child property.
                var childValue = childProp.GetValue(model);

                // Is the value missing?
                if (null == childValue)
                {
                    // If we get here then we've encountered a NULL reference
                    //   in the specified property. That may not be an issue,
                    //   if the property is a string, or a nullable type, because
                    //   we can continue to render.
                    // On the other hand, if the property isn't a string or 
                    //   nullable type then we really do need to ignore the property.

                    // Is the property type a string?
                    if (typeof(string) == childProp.PropertyType)
                    {
                        // Assign a default value.
                        childValue = string.Empty;
                    }

                    else if (typeof(Nullable<>) == childProp.PropertyType)
                    {
                        // Nothing to do here, really.
                    }

                    // Otherwise, is this a NULL object ref?
                    else if (childProp.PropertyType.IsClass)
                    {
                        // Let the world know what we're doing.
                        logger.LogDebug(
                            "Not rendering property: '{PropPath}' [idx: '{Index}'] " +
                            "since it's value is null!",
                            propPath,
                            index
                            );

                        // Ignore this property.
                        continue;
                    }
                }

                // Push the property onto path.
                path.Push(childValue);

                // Render the property.
                index = attr.Generate(
                    builder,
                    index,
                    eventTarget,
                    path,
                    childProp,
                    logger
                    );
                
                // Pop property off the path.
                path.Pop();
            }

            // Return the index.
            return index;
        }

        #endregion
    }
}
