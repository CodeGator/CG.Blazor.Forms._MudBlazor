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
    /// This class is an attribute that, when applied to a string property, causes
    /// the form generator to render the property as a <see cref="MudAlert"/> component.
    /// </summary>
    /// <remarks>
    /// <para>
    /// This attribute is only valid when placed on a property of type: string.
    /// </para>
    /// </remarks>
    /// <example>
    /// Here is an example of decorating a model property to render a  <see cref="MudAlert"/>:
    /// <code>
    /// using CG.Blazor.Forms.Attributes;
    /// class MyModel
    /// {
    ///     [RenderMudAlert]
    ///     public string MyProperty { get;set; }
    /// }
    /// </code>
    /// </example>
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class RenderMudAlertAttribute : MudBlazorAttribute
    {
        // *******************************************************************
        // Properties.
        // *******************************************************************

        #region Properties

        /// <summary>
        /// This property sets the position of the text to the start (Left in 
        /// LTR and right in RTL).
        /// </summary>
        public AlertTextPosition AlertTextPosition { get; set; }

        /// <summary>
        /// This property defines the icon used for the close button.
        /// </summary>
        public string CloseIcon { get; set; }

        /// <summary>
        /// This property indicates, if true, compact padding will be used.
        /// </summary>
        public bool Dense { get; set; }

        /// <summary>
        /// This property indicates the elevation. The higher the number, 
        /// the heavier the drop-shadow. 0 for no shadow.
        /// </summary>
        public int Elevation { get; set; }

        /// <summary>
        /// This property indicates a custom icon, leave unset to use the 
        /// standard icon which depends on the Severity
        /// </summary>
        public string Icon { get; set; }

        /// <summary>
        /// This property indicates, if true, no alert icon will be used.
        /// </summary>
        public bool NoIcon { get; set; }

        /// <summary>
        /// This property indicates the severity of the alert. This defines 
        /// the color and icon used.
        /// </summary>
        public Severity Severity { get; set; }

        /// <summary>
        /// This property indicates if the alert shows a close icon.
        /// </summary>
        public bool ShowCloseIcon { get; set; }

        /// <summary>
        /// This property indicates, if true, rounded corners are disabled.
        /// </summary>
        public bool Square { get; set; }

        /// <summary>
        /// This property indicates the variant to use.
        /// </summary>
        public Variant Variant { get; set; }

        #endregion

        // *******************************************************************
        // Constructors.
        // *******************************************************************

        #region Constructors

        /// <summary>
        /// This constructor creates a new instance of the <see cref="RenderMudAlertAttribute"/>
        /// class.
        /// </summary>
        public RenderMudAlertAttribute()
        {
            // Set default values.
            AlertTextPosition = AlertTextPosition.Left;
            CloseIcon = string.Empty;
            Dense = false;
            Elevation = 0;
            Icon = string.Empty;
            NoIcon = false;
            Severity = Severity.Normal;
            ShowCloseIcon = false;
            Square = false;
            Variant = Variant.Text;
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
            if (AlertTextPosition.Left != AlertTextPosition)
            {
                // Add the property value.
                attr[nameof(AlertTextPosition)] = AlertTextPosition;
            }

            // Does this property have a non-default value?
            if (false == string.IsNullOrEmpty(CloseIcon))
            {
                // Add the property value.
                attr[nameof(CloseIcon)] = CloseIcon;
            }

            // Does this property have a non-default value?
            if (false != Dense)
            {
                // Add the property value.
                attr[nameof(Dense)] = Dense;
            }

            // Does this property have a non-default value?
            if (0 != Elevation)
            {
                // Add the property value.
                attr[nameof(Elevation)] = Elevation;
            }

            // Does this property have a non-default value?
            if (false == string.IsNullOrEmpty(Icon))
            {
                // Add the property value.
                attr[nameof(Icon)] = Icon;
            }

            // Does this property have a non-default value?
            if (false != NoIcon)
            {
                // Add the property value.
                attr[nameof(NoIcon)] = NoIcon;
            }

            // Does this property have a non-default value?
            if (Severity.Normal != Severity)
            {
                // Add the property value.
                attr[nameof(Severity)] = Severity;
            }

            // Does this property have a non-default value?
            if (false != ShowCloseIcon)
            {
                // Add the property value.
                attr[nameof(ShowCloseIcon)] = ShowCloseIcon;
            }

            // Does this property have a non-default value?
            if (false != Square)
            {
                // Add the property value.
                attr[nameof(Square)] = Square;
            }

            // Does this property have a non-default value?
            if (Variant.Text != Variant)
            {
                // Add the property value.
                attr[nameof(Variant)] = Variant;
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
                // If we get here then we are trying to render a MudAlert component
                //   and bind it to the specified string property.

                // Should never happen, but, pffft, check it anyway.
                if (path.Count < 2)
                {
                    // Let the world know what we're doing.
                    logger.LogDebug(
                        "RenderMudAlertAttribute::Generate called with a shallow path!"
                        );

                    // Return the index.
                    return index;
                }

                // Create a complete property path, for logging.
                var propPath = $"{string.Join('.', path.Skip(1).Reverse().Select(x => x.GetType().Name))}.{prop.Name}";

                // Get the model reference.
                var model = path.Peek();

                // Should never happen, but, pffft, check it anyway.
                if (null == model)
                {
                    // Let the world know what we're doing.
                    logger.LogDebug(
                        "RenderMudAlertAttribute::Generate called with a null model!"
                        );

                    // Return the index.
                    return index;
                }

                // Get the property type.
                var propertyType = prop.PropertyType;

                // Get the property's parent.
                var propParent = path.Skip(1).First();

                // We only render MudAlert controls against strings.
                if (propertyType == typeof(string))
                {
                    // Let the world know what we're doing.
                    logger.LogDebug(
                        "Rendering property: '{PropPath}' as a MudAlert. [idx: '{Index}']",
                        propPath,
                        index
                        );

                    // Get any non-default attribute values (overrides).
                    var attributes = ToAttributes();

                    // Render the property as a MudAlert control.
                    index = builder.RenderUIComponent<MudAlert>(
                        index++,
                        attributes: attributes,
                        contentDelegate: childBuilder =>
                        {
                            // Add the child content.
                            childBuilder.AddContent(
                                        index++,
                                        (string)prop.GetValue(propParent)
                                        );
                        });
                }
                else
                {
                    // Let the world know what we're doing.
                    logger.LogDebug(
                        "Not rendering property: '{PropPath}' since we only render " +
                        "MudAlert components on properties of type: string. " +
                        "That property is of type: '{PropType}'!",
                        propPath,
                        prop.PropertyType.Name
                        );
                }

                // Return the index.
                return index;
            }
            catch (Exception ex)
            {
                // Give the error better context.
                throw new FormGenerationException(
                    message: "Failed to render a MudAlert component! " +
                        "See inner exception(s) for more detail.",
                    innerException: ex
                    );
            }
        }

        #endregion
    }
}
