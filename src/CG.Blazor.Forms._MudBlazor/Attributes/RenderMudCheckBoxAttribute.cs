using CG.Blazor.Forms.Services;
using CG.Validations;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.CompilerServices;
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
    /// This class is an attribute that, when applied to a bool property, causes
    /// the form generator to render the property as a <see cref="MudCheckBox{T}"/> 
    /// component.
    /// </summary>
    /// <remarks>
    /// <para>
    /// This attribute is only valid when placed on a property of type: string.
    /// </para>
    /// </remarks>
    /// <example>
    /// Here is an example of decorating a model property to render a  <see cref="MudCheckBox{T}"/>:
    /// <code>
    /// using CG.Blazor.Forms.Attributes;
    /// class MyModel
    /// {
    ///     [RenderMudCheckBox]
    ///     public bool MyProperty { get;set; }
    /// }
    /// </code>
    /// </example>
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class RenderMudCheckBoxAttribute : MudBlazorAttribute
    {
        // *******************************************************************
        // Properties.
        // *******************************************************************

        #region Properties

        /// <summary>
        /// This property contains a custom checked icon, leave null for default.
        /// </summary>
        public string CheckedIcon { get; set;  }

        /// <summary>
        /// This property indicates the color of the component. It supports 
        /// the theme colors.
        /// </summary>
        public Color Color { get; set; }

        /// <summary>
        /// This proerty, if true, causes compact padding to be applied.
        /// </summary>
        public bool Dense { get; set; }

        /// <summary>
        /// This property, if true, the input will be disabled.
        /// </summary>
        public bool Disabled { get; set; }

        /// <summary>
        /// This property, if true, disables ripple effect.
        /// </summary>
        public bool DisableRipple { get; set; }

        /// <summary>
        /// This property contains a custom indeterminate icon, leave 
        /// null for default.
        /// </summary>
        public string IndeterminateIcon { get; set; }

        /// <summary>
        /// This property contains an optional label for the text field.
        /// </summary>
        public string Label { get; set; }

        /// <summary>
        /// This property, if true, the input will be read-only.
        /// </summary>
        public bool ReadOnly { get; set; }

        /// <summary>
        /// This property cotnains the size of the component.
        /// </summary>
        public Size Size { get; set; }

        /// <summary>
        /// This property indicates if the checkbox can cycle again through 
        /// indeterminate status.
        /// </summary>
        public bool TriState { get; set; }

        /// <summary>
        /// This property contains a custom unchecked icon, leave null for default.
        /// </summary>
        public string UncheckedIcon { get; set; }

        #endregion

        // *******************************************************************
        // Constructors.
        // *******************************************************************

        #region Constructors

        /// <summary>
        /// This constructor creates a new instance of the <see cref="RenderMudCheckBoxAttribute"/>
        /// class.
        /// </summary>
        public RenderMudCheckBoxAttribute()
        {
            // Set default values.
            CheckedIcon = string.Empty;
            Color = Color.Default;
            Dense = false;
            Disabled = false;
            DisableRipple = false;
            IndeterminateIcon = string.Empty;
            Label = string.Empty;
            ReadOnly = false;
            Size = Size.Medium;
            TriState = false;
            UncheckedIcon = string.Empty;
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
            if (false == string.IsNullOrEmpty(CheckedIcon))
            {
                // Add the property value.
                attr[nameof(CheckedIcon)] = CheckedIcon;
            }

            // Does this property have a non-default value?
            if (Color.Default != Color)
            {
                // Add the property value.
                attr[nameof(Color)] = Color;
            }

            // Does this property have a non-default value?
            if (false != Dense)
            {
                // Add the property value.
                attr[nameof(Dense)] = Dense;
            }

            // Does this property have a non-default value?
            if (false != Disabled)
            {
                // Add the property value.
                attr[nameof(Disabled)] = Disabled;
            }

            // Does this property have a non-default value?
            if (false != DisableRipple)
            {
                // Add the property value.
                attr[nameof(DisableRipple)] = DisableRipple;
            }

            // Does this property have a non-default value?
            if (false != string.IsNullOrEmpty(IndeterminateIcon))
            {
                // Add the property value.
                attr[nameof(IndeterminateIcon)] = IndeterminateIcon;
            }

            // Does this property have a non-default value?
            if (false == string.IsNullOrEmpty(Label))
            {
                // Add the property value.
                attr[nameof(Label)] = Label;
            }

            // Does this property have a non-default value?
            if (false != ReadOnly)
            {
                // Add the property value.
                attr[nameof(ReadOnly)] = ReadOnly;
            }

            // Does this property have a non-default value?
            if (Size.Medium != Size)
            {
                // Add the property value.
                attr[nameof(Size)] = Size;
            }

            // Does this property have a non-default value?
            if (false != TriState)
            {
                // Add the property value.
                attr[nameof(TriState)] = TriState;
            }

            // Does this property have a non-default value?
            if (false != string.IsNullOrEmpty(UncheckedIcon))
            {
                // Add the property value.
                attr[nameof(UncheckedIcon)] = UncheckedIcon;
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
                // If we get here then we are trying to render a MudCheckBox component
                //   and bind it to the specified bool property.

                // Should never happen, but, pffft, check it anyway.
                if (path.Count < 2)
                {
                    // Let the world know what we're doing.
                    logger.LogDebug(
                        "RenderMudCheckBoxAttribute::Generate called with a shallow path!"
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
                        "RenderMudCheckBoxAttribute::Generate called with a null model!"
                        );

                    // Return the index.
                    return index;
                }

                // Get the property type.
                var propertyType = prop.PropertyType;

                // Get the property's parent.
                var propParent = path.Skip(1).First();

                // We only render MudCheckBox controls against bools.
                if (propertyType == typeof(bool))
                {
                    // Let the world know what we're doing.
                    logger.LogDebug(
                        "Rendering property: '{PropPath}' as a MudCheckBox. [idx: '{Index}']",
                        propPath,
                        index
                        );

                    // Get any non-default attribute values (overrides).
                    var attributes = ToAttributes();

                    // Ensure the Label property is set.
                    if (false == attributes.ContainsKey("Label"))
                    {
                        // Ensure we have a label.
                        attributes["Label"] = prop.Name;
                    }

                    // Ensure the Checked property value is set.
                    attributes["Checked"] = (bool)prop.GetValue(propParent);

                    // Ensure the CheckedChanged property is bound, both ways.
                    attributes["CheckedChanged"] = RuntimeHelpers.TypeCheck<EventCallback<bool>>(
                        EventCallback.Factory.Create<bool>(
                            eventTarget,
                            EventCallback.Factory.CreateInferred<bool>(
                                eventTarget,
                                x => prop.SetValue(propParent, x),
                                (bool)prop.GetValue(propParent)
                                )
                            )
                        );

                    // Render the property as a MudCheckBox control.
                    index = builder.RenderUIComponent<MudCheckBox<bool>>(
                        index++,
                        attributes: attributes
                        );
                }
                else
                {
                    // Let the world know what we're doing.
                    logger.LogDebug(
                        "Not Rendering property: '{PropPath}' since we only render " +
                        "MudCheckBox components on properties of type: bool. " +
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
                    message: "Failed to render a MudCheckBox component! " +
                        "See inner exception(s) for more detail.",
                    innerException: ex
                    );
            }
        }

        #endregion
    }
}
