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
using System.Linq.Expressions;
using System.Reflection;

namespace CG.Blazor.Forms.Attributes
{
    /// <summary>
    /// This class is an attribute that, when applied to a numeric property, causes
    /// the form generator to render the property as a <see cref="MudSlider{T}"/> 
    /// component.
    /// </summary>
    /// <remarks>
    /// <para>
    /// This attribute is only valid when placed on a property of type: numeric,
    /// which means: byte, short, int, long, float, double, decimal.
    /// </para>
    /// </remarks>
    /// <example>
    /// Here is an example of decorating a model property to render a  <see cref="MudSlider{T}"/>:
    /// <code>
    /// using CG.Blazor.Forms.Attributes;
    /// class MyModel
    /// {
    ///     [RenderMudSlider]
    ///     public float MyProperty { get;set; }
    /// }
    /// </code>
    /// </example>
    [AttributeUsage(AttributeTargets.Property)]
    public class RenderMudSliderAttribute : MudBlazorAttribute
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
        /// This property, if true, the dragging the slider will update the 
        /// Value immediately. If false, the Value is updated only on releasing 
        /// the handle.indicates whether to disable the ripple, or not.
        /// </summary>
        public bool Immediate { get; set; }

        /// <summary>
        /// This property contains an optional label for the text field.
        /// </summary>
        public string Label { get; set; }

        /// <summary>
        /// This property contains the maximum allowed value of the slider. 
        /// Should not be equal to min.
        /// </summary>
        public object Max { get; set; }

        /// <summary>
        /// This property contains the minimum allowed value of the slider. 
        /// Should not be equal to max.
        /// </summary>
        public object Min { get; set; }

        /// <summary>
        /// This property contains how many steps the slider should take 
        /// on each move.
        /// </summary>
        public object Step { get; set; }

        #endregion

        // *******************************************************************
        // Constructors.
        // *******************************************************************

        #region Constructors

        /// <summary>
        /// This constructor creates a new instance of the <see cref="RenderMudSliderAttribute"/>
        /// class.
        /// </summary>
        public RenderMudSliderAttribute()
        {
            // Set default values.
            Color = Color.Default;
            Disabled = false;
            Immediate = false;
            Label = string.Empty;
            Max = null;
            Min = null;
            Step = null;
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
            if (false != Immediate)
            {
                // Add the property value.
                attr[nameof(Immediate)] = Immediate;
            }

            // Does this property have a non-default value?
            if (false == string.IsNullOrEmpty(Label))
            {
                // Add the property value.
                attr[nameof(Label)] = Label;
            }

            // Does this property have a non-default value?
            if (null != Max)
            {
                // Add the property value.
                attr[nameof(Max)] = Max;
            }

            // Does this property have a non-default value?
            if (null != Min)
            {
                // Add the property value.
                attr[nameof(Min)] = Min;
            }

            // Does this property have a non-default value?
            if (null != Step)
            {
                // Add the property value.
                attr[nameof(Step)] = Step;
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
                // If we get here then we are trying to render a MudSlider component
                //   and bind it to the specified string property.

                // Should never happen, but, pffft, check it anyway.
                if (path.Count < 2)
                {
                    // Let the world know what we're doing.
                    logger.LogDebug(
                        "RenderMudSliderAttribute::Generate called with a shallow path!"
                        );

                    // Return the index.
                    return index;
                }

                // Create a complete property path, for logging.
                var propPath = $"{string.Join('.', path.Skip(1).Reverse().Select(x => x.GetType().Name))}.{prop.Name}";

                // Get the model reference.
                var model = path.Peek();

                // Get the property type.
                var propertyType = prop.PropertyType;

                // Get the property's parent.
                var propParent = path.Skip(1).First();

                // Should we bind to a byte?
                if (propertyType == typeof(byte) ||
                    propertyType == typeof(Nullable<byte>))
                {
                    index = BindToByte(
                        builder,
                        index,
                        eventTarget,
                        prop,
                        logger,
                        propertyType,
                        model,
                        propParent,
                        propPath
                        );
                }

                // Should we bind to a short?
                else if (propertyType == typeof(short) ||
                    propertyType == typeof(Nullable<short>))
                {
                    index = BindToShort(
                        builder,
                        index,
                        eventTarget,
                        prop,
                        logger,
                        propertyType,
                        model,
                        propParent,
                        propPath
                        );
                }

                // Should we bind to an int?
                else if (propertyType == typeof(int) ||
                    propertyType == typeof(Nullable<int>))
                {
                    index = BindToInt(
                        builder,
                        index,
                        eventTarget,
                        prop,
                        logger,
                        propertyType,
                        model,
                        propParent,
                        propPath
                        );
                }

                // Should we bind to a long?
                else if (propertyType == typeof(long) ||
                    propertyType == typeof(Nullable<long>))
                {
                    index = BindToLong(
                        builder,
                        index,
                        eventTarget,
                        prop,
                        logger,
                        propertyType,
                        model,
                        propParent,
                        propPath
                        );
                }

                // Should we bind to a float?
                else if (propertyType == typeof(float) ||
                    propertyType == typeof(Nullable<float>))
                {
                    index = BindToFloat(
                        builder,
                        index,
                        eventTarget,
                        prop,
                        logger,
                        propertyType,
                        model,
                        propParent,
                        propPath
                        );
                }

                // Should we bind to a double?
                else if (propertyType == typeof(double) ||
                    propertyType == typeof(Nullable<double>))
                {
                    index = BindToDouble(
                        builder,
                        index,
                        eventTarget,
                        prop,
                        logger,
                        propertyType,
                        model,
                        propParent,
                        propPath
                        );
                }

                // Should we bind to a decimal?
                else if (propertyType == typeof(decimal) ||
                    propertyType == typeof(Nullable<decimal>))
                {
                    index = BindToDecimal(
                        builder,
                        index,
                        eventTarget,
                        prop,
                        logger,
                        propertyType,
                        model,
                        propParent,
                        propPath
                        );
                }

                // Otherwise, we don't know this type ...
                else
                {
                    // Let the world know what we're doing.
                    logger.LogDebug(
                        "Not rendering property: '{PropPath}' since we only render " +
                        "MudSlider components on properties of type: numeric. " +
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
                    message: "Failed to render a MudSlider component! " +
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
        /// This method generates a MudSlider control that is bound to 
        /// a byte property.
        /// </summary>
        /// <param name="builder">The builder to use for the operation.</param>
        /// <param name="index">The index to use for the operation.</param>
        /// <param name="eventTarget">The event target to use for the 
        /// operation.</param>
        /// <param name="prop">The reflection information for the property.</param>
        /// <param name="logger">The logger to use for the operation.</param>
        /// <param name="propertyType">The type of property to use for the 
        /// operation.</param>
        /// <param name="model">The model to use for the operation.</param>
        /// <param name="propParent">The property parent to use for the 
        /// operation.</param>
        /// <param name="propPath">The complete path to the property.</param>
        /// <returns>The index after rendering is complete.</returns>
        private int BindToByte(
            RenderTreeBuilder builder,
            int index,
            IHandleEvent eventTarget,
            PropertyInfo prop,
            ILogger<IFormGenerator> logger,
            Type propertyType,
            object model,
            object propParent,
            string propPath
            )
        {
            // Let the world know what we're doing.
            logger.LogDebug(
                "Rendering property: '{PropPath}' as a MudSlider. [idx: '{Index}']",
                propPath,
                index
                );

            // Get any non-default attribute values (overrides).
            var attributes = ToAttributes();

            // Did we not override the label?
            if (false == attributes.ContainsKey("Label"))
            {
                // Ensure the Label property is set.
                attributes["Label"] = prop.Name;
            }

            // Is the property NOT nullable?
            if (propertyType == typeof(byte))
            {
                // Ensure the Value property value is set.
                attributes["Value"] = (byte)prop.GetValue(propParent);

                // Ensure the Value property is bound, both ways.
                attributes["ValueChanged"] = RuntimeHelpers.TypeCheck<EventCallback<byte>>(
                    EventCallback.Factory.Create<byte>(
                        eventTarget,
                        EventCallback.Factory.CreateInferred<byte>(
                            eventTarget,
                            x => prop.SetValue(propParent, x),
                            null != model ? (byte)prop.GetValue(propParent) : (byte)0
                            )
                        )
                    );

                // Render as a MudSlider control.
                index = builder.RenderUIComponent<MudSlider<byte>>(
                    index++,
                    attributes: attributes
                    );
            }

            // Otherwise, the property IS nullable.
            else
            {
                // Ensure the Value property value is set.
                attributes["Value"] = (byte?)prop.GetValue(propParent) ?? (byte)0;

                // Ensure the Value property is bound, both ways.
                attributes["ValueChanged"] = RuntimeHelpers.TypeCheck<EventCallback<byte?>>(
                    EventCallback.Factory.Create<byte?>(
                        eventTarget,
                        EventCallback.Factory.CreateInferred<byte?>(
                            eventTarget,
                            x => prop.SetValue(propParent, x),
                            null != model ? (byte?)prop.GetValue(propParent) : (byte?)0
                            )
                        )
                    );

                // Render as a MudSlider control.
                index = builder.RenderUIComponent<MudSlider<byte?>>(
                    index++,
                    attributes: attributes
                    );
            }

            // Return the index.
            return index;
        }

        // *******************************************************************

        /// <summary>
        /// This method generates a MudSlider control that is bound to 
        /// a short property.
        /// </summary>
        /// <param name="builder">The builder to use for the operation.</param>
        /// <param name="index">The index to use for the operation.</param>
        /// <param name="eventTarget">The event target to use for the 
        /// operation.</param>
        /// <param name="prop">The reflection information for the property.</param>
        /// <param name="logger">The logger to use for the operation.</param>
        /// <param name="propertyType">The type of property to use for the 
        /// operation.</param>
        /// <param name="model">The model to use for the operation.</param>
        /// <param name="propParent">The property parent to use for the 
        /// operation.</param>
        /// <param name="propPath">The complete path to the property.</param>
        /// <returns>The index after rendering is complete.</returns>
        private int BindToShort(
            RenderTreeBuilder builder,
            int index,
            IHandleEvent eventTarget,
            PropertyInfo prop,
            ILogger<IFormGenerator> logger,
            Type propertyType,
            object model,
            object propParent,
            string propPath
            )
        {
            // Let the world know what we're doing.
            logger.LogDebug(
                "Rendering property: '{PropName}' as a MudSlider.  [idx: '{Index}']",
                propPath,
                index
                );

            // Get any non-default attribute values (overrides).
            var attributes = ToAttributes();

            // Did we not override the label?
            if (false == attributes.ContainsKey("Label"))
            {
                // Ensure the Label property is set.
                attributes["Label"] = prop.Name;
            }

            // Is the property NOT nullable?
            if (propertyType == typeof(short))
            {
                // Ensure the Value property value is set.
                attributes["Value"] = (short)prop.GetValue(propParent);

                // Ensure the Value property is bound, both ways.
                attributes["ValueChanged"] = RuntimeHelpers.TypeCheck<EventCallback<short>>(
                    EventCallback.Factory.Create<short>(
                        eventTarget,
                        EventCallback.Factory.CreateInferred<short>(
                            eventTarget,
                            x => prop.SetValue(propParent, x),
                            null != model ? (short)prop.GetValue(propParent) : (short)0
                            )
                        )
                    );

                // Render as a MudSlider control.
                index = builder.RenderUIComponent<MudSlider<short>>(
                    index++,
                    attributes: attributes
                    );
            }

            // Otherwise, the property IS nullable.
            else
            {
                attributes["Value"] = (short?)prop.GetValue(propParent) ?? (short)0;

                // Ensure the Value property is bound, both ways.
                attributes["ValueChanged"] = RuntimeHelpers.TypeCheck<EventCallback<short?>>(
                    EventCallback.Factory.Create<short?>(
                        eventTarget,
                        EventCallback.Factory.CreateInferred<short?>(
                            eventTarget,
                            x => prop.SetValue(propParent, x),
                            null != model ? (short?)prop.GetValue(propParent) : (short?)0
                            )
                        )
                    );

                // Ensure the For property value is set.
                attributes["For"] = Expression.Lambda<Func<short?>>(
                    MemberExpression.Property(
                        Expression.Constant(
                            propParent,
                            propParent.GetType()
                            ),
                        prop.Name
                        )
                    );

                // Render as a MudSlider control.
                index = builder.RenderUIComponent<MudSlider<short?>>(
                    index++,
                    attributes: attributes
                    );
            }

            // Return the index.
            return index;
        }

        // *******************************************************************

        /// <summary>
        /// This method generates a MudSlider control that is bound to 
        /// an int property.
        /// </summary>
        /// <param name="builder">The builder to use for the operation.</param>
        /// <param name="index">The index to use for the operation.</param>
        /// <param name="eventTarget">The event target to use for the 
        /// operation.</param>
        /// <param name="prop">The reflection information for the property.</param>
        /// <param name="logger">The logger to use for the operation.</param>
        /// <param name="propertyType">The type of property to use for the 
        /// operation.</param>
        /// <param name="model">The model to use for the operation.</param>
        /// <param name="propParent">The property parent to use for the 
        /// operation.</param>
        /// <param name="propPath">The complete path to the property.</param>
        /// <returns>The index after rendering is complete.</returns>
        private int BindToInt(
            RenderTreeBuilder builder,
            int index,
            IHandleEvent eventTarget,
            PropertyInfo prop,
            ILogger<IFormGenerator> logger,
            Type propertyType,
            object model,
            object propParent,
            string propPath
            )
        {
            // Let the world know what we're doing.
            logger.LogDebug(
                "Rendering property: '{PropName}' as a MudSlider.  [idx: '{Index}']",
                propPath,
                index
                );

            // Get any non-default attribute values (overrides).
            var attributes = ToAttributes();

            // Did we not override the label?
            if (false == attributes.ContainsKey("Label"))
            {
                // Ensure the Label property is set.
                attributes["Label"] = prop.Name;
            }

            // Is the property NOT nullable?
            if (propertyType == typeof(int))
            {
                // Ensure the Value property value is set.
                attributes["Value"] = (int)prop.GetValue(propParent);

                // Ensure the Value property is bound, both ways.
                attributes["ValueChanged"] = RuntimeHelpers.TypeCheck<EventCallback<int>>(
                    EventCallback.Factory.Create<int>(
                        eventTarget,
                        EventCallback.Factory.CreateInferred<int>(
                            eventTarget,
                            x => prop.SetValue(propParent, x),
                            null != model ? (int)prop.GetValue(propParent) : (int)0
                            )
                        )
                    );

                // Render as a MudSlider control.
                index = builder.RenderUIComponent<MudSlider<int>>(
                    index++,
                    attributes: attributes
                    );
            }

            // Otherwise, the property IS nullable.
            else
            {
                // Ensure the Value property value is set.
                attributes["Value"] = (int?)prop.GetValue(propParent) ?? (int)0;

                // Ensure the Value property is bound, both ways.
                attributes["ValueChanged"] = RuntimeHelpers.TypeCheck<EventCallback<int?>>(
                    EventCallback.Factory.Create<int?>(
                        eventTarget,
                        EventCallback.Factory.CreateInferred<int?>(
                            eventTarget,
                            x => prop.SetValue(propParent, x),
                            null != model ? (int?)prop.GetValue(propParent) : (int?)0
                            )
                        )
                    );

                // Ensure the For property value is set.
                attributes["For"] = Expression.Lambda<Func<int?>>(
                    MemberExpression.Property(
                        Expression.Constant(
                            propParent,
                            propParent.GetType()
                            ),
                        prop.Name
                        )
                    );

                // Render as a MudSlider control.
                index = builder.RenderUIComponent<MudSlider<int?>>(
                    index++,
                    attributes: attributes
                    );
            }

            // Return the index.
            return index;
        }

        // *******************************************************************

        /// <summary>
        /// This method generates a MudSlider control that is bound to 
        /// a long property.
        /// </summary>
        /// <param name="builder">The builder to use for the operation.</param>
        /// <param name="index">The index to use for the operation.</param>
        /// <param name="eventTarget">The event target to use for the 
        /// operation.</param>
        /// <param name="prop">The reflection information for the property.</param>
        /// <param name="logger">The logger to use for the operation.</param>
        /// <param name="propertyType">The type of property to use for the 
        /// operation.</param>
        /// <param name="model">The model to use for the operation.</param>
        /// <param name="propParent">The property parent to use for the 
        /// operation.</param>
        /// <param name="propPath">The complete path to the property.</param>
        /// <returns>The index after rendering is complete.</returns>
        private int BindToLong(
            RenderTreeBuilder builder,
            int index,
            IHandleEvent eventTarget,
            PropertyInfo prop,
            ILogger<IFormGenerator> logger,
            Type propertyType,
            object model,
            object propParent,
            string propPath
            )
        {
            // Let the world know what we're doing.
            logger.LogDebug(
                "Rendering property: '{PropName}' as a MudSlider.  [idx: '{Index}']",
                propPath,
                index
                );

            // Get any non-default attribute values (overrides).
            var attributes = ToAttributes();

            // Did we not override the label?
            if (false == attributes.ContainsKey("Label"))
            {
                // Ensure the Label property is set.
                attributes["Label"] = prop.Name;
            }

            // Is the property NOT nullable?
            if (propertyType == typeof(long))
            {
                // Ensure the Value property value is set.
                attributes["Value"] = (long)prop.GetValue(propParent);

                // Ensure the Value property is bound, both ways.
                attributes["ValueChanged"] = RuntimeHelpers.TypeCheck<EventCallback<long>>(
                    EventCallback.Factory.Create<long>(
                        eventTarget,
                        EventCallback.Factory.CreateInferred<long>(
                            eventTarget,
                            x => prop.SetValue(propParent, x),
                            null != model ? (long)prop.GetValue(propParent) : (long)0
                            )
                        )
                    );

                // Render as a MudSlider control.
                index = builder.RenderUIComponent<MudSlider<long>>(
                    index++,
                    attributes: attributes
                    );
            }

            // Otherwise, the property IS nullable.
            else
            {
                // Ensure the Value property value is set.
                attributes["Value"] = (long?)prop.GetValue(propParent) ?? (long)0;

                // Ensure the Value property is bound, both ways.
                attributes["ValueChanged"] = RuntimeHelpers.TypeCheck<EventCallback<long?>>(
                    EventCallback.Factory.Create<long?>(
                        eventTarget,
                        EventCallback.Factory.CreateInferred<long?>(
                            eventTarget,
                            x => prop.SetValue(propParent, x),
                            null != model ? (long?)prop.GetValue(propParent) : (long?)0
                            )
                        )
                    );

                // Render as a MudSlider control.
                index = builder.RenderUIComponent<MudSlider<long?>>(
                    index++,
                    attributes: attributes
                    );
            }

            // Return the index.
            return index;
        }

        // *******************************************************************

        /// <summary>
        /// This method generates a MudSlider control that is bound to 
        /// a float property.
        /// </summary>
        /// <param name="builder">The builder to use for the operation.</param>
        /// <param name="index">The index to use for the operation.</param>
        /// <param name="eventTarget">The event target to use for the 
        /// operation.</param>
        /// <param name="prop">The reflection information for the property.</param>
        /// <param name="logger">The logger to use for the operation.</param>
        /// <param name="propertyType">The type of property to use for the 
        /// operation.</param>
        /// <param name="model">The model to use for the operation.</param>
        /// <param name="propParent">The property parent to use for the 
        /// operation.</param>
        /// <param name="propPath">The complete path to the property.</param>
        /// <returns>The index after rendering is complete.</returns>
        private int BindToFloat(
            RenderTreeBuilder builder,
            int index,
            IHandleEvent eventTarget,
            PropertyInfo prop,
            ILogger<IFormGenerator> logger,
            Type propertyType,
            object model,
            object propParent,
            string propPath
            )
        {
            // Let the world know what we're doing.
            logger.LogDebug(
                "Rendering property: '{PropName}' as a MudSlider.  [idx: '{Index}']",
                propPath,
                index
                );

            // Get any non-default attribute values (overrides).
            var attributes = ToAttributes();

            // Did we not override the label?
            if (false == attributes.ContainsKey("Label"))
            {
                // Ensure the Label property is set.
                attributes["Label"] = prop.Name;
            }

            // Is the property NOT nullable?
            if (propertyType == typeof(float))
            {
                // Ensure the Value property value is set.
                attributes["Value"] = (float)prop.GetValue(propParent);

                // Ensure the Value property is bound, both ways.
                attributes["ValueChanged"] = RuntimeHelpers.TypeCheck<EventCallback<float>>(
                    EventCallback.Factory.Create<float>(
                        eventTarget,
                        EventCallback.Factory.CreateInferred<float>(
                            eventTarget,
                            x => prop.SetValue(propParent, x),
                            null != model ? (float)prop.GetValue(propParent) : (float)0
                            )
                        )
                    );

                // Render as a MudSlider control.
                index = builder.RenderUIComponent<MudSlider<float>>(
                    index++,
                    attributes: attributes
                    );
            }

            // Otherwise, the property IS nullable.
            else
            {
                // Ensure the Value property value is set.
                attributes["Value"] = (float?)prop.GetValue(propParent) ?? (float)0;

                // Ensure the Value property is bound, both ways.
                attributes["ValueChanged"] = RuntimeHelpers.TypeCheck<EventCallback<float?>>(
                    EventCallback.Factory.Create<float?>(
                        eventTarget,
                        EventCallback.Factory.CreateInferred<float?>(
                            eventTarget,
                            x => prop.SetValue(propParent, x),
                            null != model ? (float?)prop.GetValue(propParent) : (float?)0
                            )
                        )
                    );

                // Render as a MudSlider control.
                index = builder.RenderUIComponent<MudSlider<float?>>(
                    index++,
                    attributes: attributes
                    );
            }

            // Return the index.
            return index;
        }

        // *******************************************************************

        /// <summary>
        /// This method generates a MudSlider control that is bound to 
        /// a double property.
        /// </summary>
        /// <param name="builder">The builder to use for the operation.</param>
        /// <param name="index">The index to use for the operation.</param>
        /// <param name="eventTarget">The event target to use for the 
        /// operation.</param>
        /// <param name="prop">The reflection information for the property.</param>
        /// <param name="logger">The logger to use for the operation.</param>
        /// <param name="propertyType">The type of property to use for the 
        /// operation.</param>
        /// <param name="model">The model to use for the operation.</param>
        /// <param name="propParent">The property parent to use for the 
        /// operation.</param>
        /// <param name="propPath">The complete path to the property.</param>
        /// <returns>The index after rendering is complete.</returns>
        private int BindToDouble(
            RenderTreeBuilder builder,
            int index,
            IHandleEvent eventTarget,
            PropertyInfo prop,
            ILogger<IFormGenerator> logger,
            Type propertyType,
            object model,
            object propParent,
            string propPath
            )
        {
            // Let the world know what we're doing.
            logger.LogDebug(
                "Rendering property: '{PropName}' as a MudSlider.  [idx: '{Index}']",
                propPath,
                index
                );

            // Get any non-default attribute values (overrides).
            var attributes = ToAttributes();

            // Did we not override the label?
            if (false == attributes.ContainsKey("Label"))
            {
                // Ensure the Label property is set.
                attributes["Label"] = prop.Name;
            }

            // Is the property NOT nullable?
            if (propertyType == typeof(double))
            {
                // Ensure the Value property value is set.
                attributes["Value"] = (double)prop.GetValue(propParent);

                // Ensure the Value property is bound, both ways.
                attributes["ValueChanged"] = RuntimeHelpers.TypeCheck<EventCallback<double>>(
                    EventCallback.Factory.Create<double>(
                        eventTarget,
                        EventCallback.Factory.CreateInferred<double>(
                            eventTarget,
                            x => prop.SetValue(propParent, x),
                            null != model ? (double)prop.GetValue(propParent) : (double)0
                            )
                        )
                    );

                // Render as a MudSlider control.
                index = builder.RenderUIComponent<MudSlider<double>>(
                    index++,
                    attributes: attributes
                    );
            }

            // Otherwise, the property IS nullable.
            else
            {
                // Ensure the Value property value is set.
                attributes["Value"] = (double?)prop.GetValue(propParent) ?? (double)0;

                // Ensure the Value property is bound, both ways.
                attributes["ValueChanged"] = RuntimeHelpers.TypeCheck<EventCallback<double?>>(
                    EventCallback.Factory.Create<double?>(
                        eventTarget,
                        EventCallback.Factory.CreateInferred<double?>(
                            eventTarget,
                            x => prop.SetValue(propParent, x),
                            null != model ? (double?)prop.GetValue(propParent) : (double?)0
                            )
                        )
                    );

                // Render as a MudSlider control.
                index = builder.RenderUIComponent<MudSlider<double?>>(
                    index++,
                    attributes: attributes
                    );
            }

            // Return the index.
            return index;
        }

        // *******************************************************************

        /// <summary>
        /// This method generates a MudSlider control that is bound to 
        /// a decimal property.
        /// </summary>
        /// <param name="builder">The builder to use for the operation.</param>
        /// <param name="index">The index to use for the operation.</param>
        /// <param name="eventTarget">The event target to use for the 
        /// operation.</param>
        /// <param name="prop">The reflection information for the property.</param>
        /// <param name="logger">The logger to use for the operation.</param>
        /// <param name="propertyType">The type of property to use for the 
        /// operation.</param>
        /// <param name="model">The model to use for the operation.</param>
        /// <param name="propParent">The property parent to use for the 
        /// operation.</param>
        /// <param name="propPath">The complete path to the property.</param>
        /// <returns>The index after rendering is complete.</returns>
        private int BindToDecimal(
            RenderTreeBuilder builder,
            int index,
            IHandleEvent eventTarget,
            PropertyInfo prop,
            ILogger<IFormGenerator> logger,
            Type propertyType,
            object model,
            object propParent,
            string propPath
            )
        {
            // Let the world know what we're doing.
            logger.LogDebug(
                "Rendering property: '{PropName}' as a MudSlider.  [idx: '{Index}']",
                propPath,
                index
                );

            // Get any non-default attribute values (overrides).
            var attributes = ToAttributes();

            // Did we not override the label?
            if (false == attributes.ContainsKey("Label"))
            {
                // Ensure the Label property is set.
                attributes["Label"] = prop.Name;
            }

            // Is the property NOT nullable?
            if (propertyType == typeof(decimal))
            {
                // Ensure the Value property value is set.
                attributes["Value"] = (decimal)prop.GetValue(propParent);

                // Ensure the Value property is bound, both ways.
                attributes["ValueChanged"] = RuntimeHelpers.TypeCheck<EventCallback<decimal>>(
                    EventCallback.Factory.Create<decimal>(
                        eventTarget,
                        EventCallback.Factory.CreateInferred<decimal>(
                            eventTarget,
                            x => prop.SetValue(propParent, x),
                            null != model ? (decimal)prop.GetValue(propParent) : (decimal)0
                            )
                        )
                    );

                // Render as a MudSlider control.
                index = builder.RenderUIComponent<MudSlider<decimal>>(
                    index++,
                    attributes: attributes
                    );
            }

            // Otherwise, the property IS nullable.
            else
            {
                // Ensure the Value property value is set.
                attributes["Value"] = (decimal?)prop.GetValue(propParent) ?? (decimal)0;

                // Ensure the Value property is bound, both ways.
                attributes["ValueChanged"] = RuntimeHelpers.TypeCheck<EventCallback<decimal?>>(
                    EventCallback.Factory.Create<decimal?>(
                        eventTarget,
                        EventCallback.Factory.CreateInferred<decimal?>(
                            eventTarget,
                            x => prop.SetValue(propParent, x),
                            null != model ? (decimal?)prop.GetValue(propParent) : (decimal?)0
                            )
                        )
                    );

                // Render as a MudSlider control.
                index = builder.RenderUIComponent<MudSlider<decimal?>>(
                    index++,
                    attributes: attributes
                    );
            }

            // Return the index.
            return index;
        }

        #endregion
    }
}
