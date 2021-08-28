using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using CG.Blazor.Forms.Components;
using CG.Blazor.Forms.Services;
using CG.Validations;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using Microsoft.Extensions.Logging;
using MudBlazor;

namespace CG.Blazor.Forms.Attributes
{
    /// <summary>
    /// This class is an attribute that, when applied to a property of type: object, 
    /// causes the form generator to render the property wrapped inside a <see cref="MuddyGroupBox"/>
    /// component.
    /// </summary>
    /// <remarks>
    /// <para>
    /// This attribute is only valid when placed on a property of type: object.
    /// </para>
    /// <para>
    /// This attribute only makes sense to apply to an object property when the 
    /// parent of that property has been decorated with a <see cref="RenderMuddyGroupBoxAttribute"/>
    /// attribute. 
    /// </para>
    /// </remarks>
    /// <example>
    /// Here is an example of decorating a view-model to render content within a
    /// <see cref="MuddyGroupBox"/> component:
    /// <code>
    /// using CG.Blazor.Forms.Attributes;
    /// 
    /// class MyModel
    /// {
    ///     [RenderMuddyGroupBox]
    ///     public MyModel2 MyProperty { get; set; }
    /// }
    /// </code>
    /// </example>
    [AttributeUsage(AttributeTargets.Property)]
    public class RenderMuddyGroupBoxAttribute : RenderObjectAttribute
    {
        // *******************************************************************
        // Properties.
        // *******************************************************************

        #region Properties

        /// <summary>
        /// This property contains any CSS classes to use for the control.
        /// </summary>
        public string Class { get; set; }

        /// <summary>
        /// This property contains the elevation to use for the control.
        /// </summary>
        public int Elevation { get; set; }

        /// <summary>
        /// This property contains the label for the component.
        /// </summary>
        public string Label { get; set; }

        /// <summary>
        /// This property contains the color for the label.
        /// </summary>
        public Color LabelColor { get; set; }

        /// <summary>
        /// This property contains the typography for the label.
        /// </summary>
        public Typo LabelTypo { get; set; }

        /// <summary>
        /// This property indicates whether the control should be outlined, 
        /// or not.
        /// </summary>
        public bool Outlined { get; set; }

        /// <summary>
        /// This property indicates the CSS styles to use for the control.
        /// </summary>
        public string Style { get; set; }

        /// <summary>
        /// This property indicates whether the control should show square corners, 
        /// or not.
        /// </summary>
        public bool Square { get; set; }

        /// <summary>
        /// This property contain a tag to attach any user data object to the component 
        /// for your convenience.
        /// </summary>
        public object Tag { get; set; }

        /// <summary>
        /// This property contains attributes you add to the component that don't match 
        /// any of its parameters. They will be splatted onto the underlying HTML tag.
        /// </summary>
        public IDictionary<string, object> UserAttributes { get; set; }

        #endregion

        // *******************************************************************
        // Constructors.
        // *******************************************************************

        #region Constructors

        /// <summary>
        /// This constructor creates a new instance of the <see cref="RenderMuddyGroupBoxAttribute"/>
        /// class.
        /// </summary>
        public RenderMuddyGroupBoxAttribute()
        {
            // Set default values.
            Class = string.Empty;
            Elevation = 1;
            Label = string.Empty;
            LabelColor = Color.Default;
            LabelTypo = Typo.h6;
            Outlined = false;
            Style = string.Empty;
            Square = false;
            Tag = null;
            UserAttributes = null;
        }

        #endregion

        // *******************************************************************
        // Public methods.
        // *******************************************************************

        #region Public methods

        /// <inheritdoc/>
        public override IDictionary<string, object> ToAttributes()
        {
            // Create a table to hold the attributes.
            var attr = new Dictionary<string, object>();

            // Does this property have a non-default value?
            if (false == string.IsNullOrEmpty(Class))
            {
                // Add the property value.
                attr[nameof(Class)] = Class;
            }

            // Does this property have a non-default value?
            if (1 != Elevation)
            {
                // Add the property value.
                attr[nameof(Elevation)] = Elevation;
            }

            // Does this property have a non-default value?
            if (false == string.IsNullOrEmpty(Label))
            {
                // Add the property value.
                attr[nameof(Label)] = Label;
            }

            // Does this property have a non-default value?
            if (Color.Default != LabelColor)
            {
                // Add the property value.
                attr[nameof(LabelColor)] = LabelColor;
            }

            // Does this property have a non-default value?
            if (Typo.h6 != LabelTypo)
            {
                // Add the property value.
                attr[nameof(LabelTypo)] = LabelTypo;
            }

            // Does this property have a non-default value?
            if (false != Outlined)
            {
                // Add the property value.
                attr[nameof(Outlined)] = Outlined;
            }

            // Does this property have a non-default value?
            if (false == string.IsNullOrEmpty(Style))
            {
                // Add the property value.
                attr[nameof(Style)] = Style;
            }

            // Does this property have a non-default value?
            if (false != Square)
            {
                // Add the property value.
                attr[nameof(Square)] = Square;
            }

            // Does this property have a non-default value?
            if (null != Tag)
            {
                // Add the property value.
                attr[nameof(Tag)] = Tag;
            }

            // Does this property have a non-default value?
            if (null != UserAttributes)
            {
                // Add the property value.
                attr[nameof(UserAttributes)] = UserAttributes;
            }

            // Return the attributes.
            return attr;
        }

        // *******************************************************************

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
                .ThrowIfNull(prop, nameof(prop))
                .ThrowIfNull(logger, nameof(logger));

            try
            {
                // Should never happen, but, pffft, check it anyway.
                if (path.Count < 2)
                {
                    // Let the world know what we're doing.
                    logger.LogDebug(
                        "RenderMuddyGroupBoxAttribute::Generate called with an shallow path!"
                        );

                    // Return the index.
                    return index;
                }

                // Create a complete property path, for logging.
                var propPath = $"{string.Join('.', path.Skip(1).Reverse().Select(x => x.GetType().Name))}.{prop.Name}";

                // Let the world know what we're doing.
                logger.LogDebug(
                    "Rendering a MuddyGroupBox around the property '{PropPath}'. [idx: '{Index}']",
                    propPath,
                    index
                    );

                // Get the model reference.
                var model = path.Peek();

                // Is the model value missing?
                if (null == model)
                {
                    // Let the world know what we're doing.
                    logger.LogDebug(
                        "Not rendering a MuddyGroupBox for property: '{PropPath}' [idx: '{Index}'] " +
                        "since it's value is null!",
                        propPath,
                        index
                        );

                    // Return the index.
                    return index;
                }

                // Get any non-default attribute values (overrides).
                var attributes = ToAttributes();

                // Did we not override the label?
                if (false == attributes.ContainsKey("Label"))
                {
                    // Ensure we have a label.
                    attributes["Label"] = prop.Name;
                }

                // Render the MudTabs control.
                index = builder.RenderUIComponent<MuddyGroupBox>(
                    index,
                    attributes: attributes,
                    contentDelegate: childBuilder =>
                    {
                        // Push the model onto path.
                        path.Push(model);

                        // Render any child properties inside the tab panel.
                        RenderProperties(
                            childBuilder,
                            0,
                            eventTarget,
                            path,
                            prop,
                            logger
                            );

                        // Pop model off the path.
                        path.Pop();
                    });

                // Return the index.
                return index;
            }
            catch (Exception ex)
            {
                // Give the error better context.
                throw new FormGenerationException(
                    message: "Failed to render a MudduyGroupBox! " +
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
        /// This method iterates through child any properties on the model and
        /// renders each one.
        /// </summary>
        /// <param name="builder">The builder to use for the operation.</param>
        /// <param name="index">The index to use for the operation.</param>
        /// <param name="eventTarget">The event target to use for the 
        /// operation.</param>
        /// <param name="path">The path to the current model.</param>
        /// <param name="prop">The reflection information for the property.</param>
        /// <param name="logger">The logger to use for the operation.</param>
        /// <returns>The index after rendering is complete.</returns>
        private int RenderProperties(
            RenderTreeBuilder builder,
            int index,
            IHandleEvent eventTarget,
            Stack<object> path,
            PropertyInfo prop,
            ILogger<IFormGenerator> logger
            )
        {
            // If we get here then we're trying to iterate through the 
            //   properties on the specified model, rendering each one.

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

                // Look for any form generation attributes on the view-model.
                var attrs = childProp.GetCustomAttributes<FormGeneratorAttribute>();

                // Loop through the attributes.
                foreach (var attr in attrs)
                {
                    // Render the property.
                    index = attr.Generate(
                        builder,
                        index,
                        eventTarget,
                        path,
                        childProp,
                        logger
                        );
                }

                // Did we ignore this property?
                if (false == attrs.Any())
                {
                    // Let the world know what we're doing.
                    logger.LogDebug(
                        "Not rendering property: '{PropPath}' [idx: '{Index}'] " +
                        "since it's not decorated with a FormGenerator attribute!",
                        propPath,
                        index
                        );
                }

                // Pop property off the path.
                path.Pop();
            }

            // Return the index.
            return index;
        }

        #endregion
    }
}
