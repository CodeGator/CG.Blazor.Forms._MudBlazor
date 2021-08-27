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
    /// the form generator to render the property as a <see cref="MudSwitch{T}"/> component.
    /// </summary>
    /// <remarks>
    /// <para>
    /// This attribute is only valid when placed on a property of type: bool.
    /// </para>
    /// </remarks>
    /// <example>
    /// Here is an example of decorating a model property to render a  <see cref="MudSwitch{T}"/>:
    /// <code>
    /// using CG.Blazor.Forms.Attributes;
    /// class MyModel
    /// {
    ///     [RenderMudSwitch]
    ///     public bool MyProperty { get;set; }
    /// }
    /// </code>
    /// </example>
    [AttributeUsage(AttributeTargets.Property)]
    public class RenderMudSwitchAttribute : FormGeneratorAttribute
    {
        // *******************************************************************
        // Properties.
        // *******************************************************************

        #region Properties

        /// <summary>
        /// This property indicates what color to use for the switch.
        /// </summary>
        public Color Color { get; set; }

        /// <summary>
        /// This property indicates whether the switch is disabled, or not.
        /// </summary>
        public bool Disabled { get; set; }

        /// <summary>
        /// This property indicates whether to disable the ripple, or not.
        /// </summary>
        public bool DisableRipple { get; set; }

        /// <summary>
        /// This property contains the label for the switch.
        /// </summary>
        public string Label { get; set; }

        /// <summary>
        /// This property indicates whether the switch is read only, or not.
        /// </summary>
        public bool ReadOnly { get; set; }

        #endregion

        // *******************************************************************
        // Constructors.
        // *******************************************************************

        #region Constructors

        /// <summary>
        /// This constructor creates a new instance of the <see cref="RenderMudSwitchAttribute"/>
        /// class.
        /// </summary>
        public RenderMudSwitchAttribute()
        {
            // Set default values.
            Color = Color.Default;
            Disabled = false;
            DisableRipple = false;
            Label = string.Empty;
            ReadOnly = false;
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
            if (Color.Default != Color)
            {
                // Add the property value.
                attr[nameof(Color)] = Color;
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
                // If we get here then we are trying to render a MudSwitch component
                //   and bind it to the specified bool property.

                // Should never happen, but, pffft, check it anyway.
                if (path.Count < 2)
                {
                    // Let the world know what we're doing.
                    logger.LogDebug(
                        "RenderMudSwitchAttribute::Generate called with a shallow path!"
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
                        "RenderMudSwitchAttribute::Generate called with a null model!"
                        );

                    // Return the index.
                    return index;
                }

                // Get the property's parent.
                var propParent = path.Skip(1).First();

                // We only render MudSwitch controls against bools.
                if (prop.PropertyType == typeof(bool))
                {
                    // Let the world know what we're doing.
                    logger.LogDebug(
                        "Rendering property: '{PropPath}' as a MudSwitch. [idx: '{Index}']",
                        propPath,
                        index
                        );

                    // Get any non-default attribute values (overrides).
                    var attributes = ToAttributes();

                    // Did we not override the label?
                    if (false == attributes.ContainsKey("Label"))
                    {
                        // Ensure we have a label.
                        attributes["Label"] = prop.Name;
                    }

                    // Ensure the property value is set.
                    attributes["Checked"] = (bool)prop.GetValue(propParent);

                    // Ensure the property is bound, both ways.
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

                    // Render the property as a MudSwitch control.
                    index = builder.RenderUIComponent<MudSwitch<bool>>(
                        index++,
                        attributes: attributes
                        );
                }
                else
                {
                    // Let the world know what we're doing.
                    logger.LogDebug(
                        "Not rendering property: '{PropPath}' since we only render " +
                        "MudSwitch components on properties of type: bool. " +
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
                    message: "Failed to render a MudSwitch component! " +
                        "See inner exception(s) for more detail.",
                    innerException: ex
                    );
            }
        }

        #endregion
    }
}
