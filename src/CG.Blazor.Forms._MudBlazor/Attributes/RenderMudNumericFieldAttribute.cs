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
    /// This class is an attribute that, when applied to a numeric property, 
    /// causes the form generator to render the property as a <see cref="MudNumericField{T}"/> 
    /// component.
    /// </summary>
    /// <remarks>
    /// <para>
    /// This attribute is only valid when placed on a property of type: numeric,
    /// which means: byte, int, long, float, double, decimal.
    /// </para>
    /// </remarks>
    /// <example>
    /// Here is an example of decorating a model property to render a  <see cref="MudNumericField{T}"/>:
    /// <code>
    /// using CG.Blazor.Forms.Attributes;
    /// class MyModel
    /// {
    ///     [RenderMudNumeric]
    ///     public int MyProperty { get;set; }
    /// }
    /// </code>
    /// </example>
    [AttributeUsage(AttributeTargets.Property)]
    public class RenderMudNumericFieldAttribute : MudBlazorAttribute
    {
        // *******************************************************************
        // Properties.
        // *******************************************************************

        #region Properties

        /// <summary>
        /// This property indicates the Start or End Adornment if not set to None.
        /// </summary>
        public Adornment Adornment { get; set; }

        /// <summary>
        /// This property indicates the color of the adornment if used. It supports 
        /// the theme colors.
        /// </summary>
        public Color AdornmentColor { get; set; }

        /// <summary>
        /// This property indicates the icon that will be used if Adornment is set 
        /// to Start or End.
        /// </summary>
        public string AdornmentIcon { get; set; }

        /// <summary>
        /// This property indicates the text that will be used if Adornment is set
        /// to Start or End, the Text overrides Icon.
        /// </summary>
        public string AdornmentText { get; set; }

        /// <summary>
        /// This property, If true, will force the input focus automatically
        /// </summary>
        public bool AutoFocus { get; set; }

        /// <summary>
        /// This property indicates the interval to be awaited in milliseconds 
        /// before changing the Text value
        /// </summary>
        public int DebounceInterval { get; set; }

        /// <summary>
        /// This property, if true, the input element will be disabled.
        /// </summary>
        public bool Disabled { get; set; }

        /// <summary>
        /// This property, if true, the input will not have an underline.
        /// </summary>
        public bool DisableUnderLine { get; set; }

        /// <summary>
        /// This property contains a conversion format value for ToString(), 
        /// can be used for formatting primitive types, DateTimes and TimeSpans
        /// </summary>
        public string Format { get; set; }

        /// <summary>
        /// This property, if true, will force the input to take up the full width 
        /// of its container.
        /// </summary>
        public bool FullWidth { get; set; }

        /// <summary>
        /// This property, if true, hides the spin buttons, the user can still change 
        /// value with keyboard arrows and manual update.
        /// </summary>
        public bool HideSpinButtons { get; set; }

        /// <summary>
        /// This property contains the icon size.
        /// </summary>
        public Size IconSize { get; set; }

        /// <summary>
        /// This property, If true, the input will update the Value immediately on typing.
        /// If false, the Value is updated only on Enter.
        /// </summary>
        public bool Immediate { get; set; }

        /// <summary>
        /// This property hints at the type of data that might be entered by the user while
        /// editing the input. Defaults to numeric
        /// </summary>
        public InputMode InputMode { get; set; }

        /// <summary>
        /// This property contains the label for the text field.
        /// </summary>
        public string Label { get; set; }

        /// <summary>
        /// This property indicates the number of lines to display.
        /// </summary>
        public int Lines { get; set; }

        /// <summary>
        /// This property, if true, will adjust the vertical spacing.
        /// </summary>
        public Margin Margin { get; set; }

        /// <summary>
        /// This property indicates the maximum value for the input.
        /// </summary>
        public object Max { get; set; }

        /// <summary>
        /// This property indicates the minumum value for the input.
        /// </summary>
        public object Min { get; set; }

        /// <summary>
        /// This property, when specified, is a regular expression which the input's 
        /// value must match in order for the value to pass constraint validation. It 
        /// must be a valid JavaScript regular expression Defaults to[0 - 9,\.\-+]* 
        /// To get a numerical keyboard on safari, use the pattern.The default pattern 
        /// should achieve numerical keyboard.
        /// </summary>
        public string Pattern { get; set; }

        /// <summary>
        /// This property contains a short hint displayed in the input before the user 
        /// enters a value.
        /// </summary>
        public string Placeholder { get; set; }

        /// <summary>
        /// This property indicates whether the text field is read only, or not.
        /// </summary>
        public bool ReadOnly { get; set; }

        /// <summary>
        /// This property contains the increment added/subtracted by the spin buttons.
        /// </summary>
        public object Step { get; set; }

        /// <summary>
        /// This property contains the variant for the control.
        /// </summary>
        public Variant Variant { get; set; }

        #endregion

        // *******************************************************************
        // Constructors.
        // *******************************************************************

        #region Constructors

        /// <summary>
        /// This constructor creates a new instance of the <see cref="RenderMudNumericFieldAttribute"/>
        /// class.
        /// </summary>
        public RenderMudNumericFieldAttribute()
        {
            // Set default values.
            Adornment = Adornment.None;
            AdornmentColor = Color.Default;
            AdornmentIcon = string.Empty;
            AdornmentText = string.Empty;
            AutoFocus = false;
            DebounceInterval = 0;
            Disabled = false;
            DisableUnderLine = false;
            Format = string.Empty;
            FullWidth = false;
            HideSpinButtons = false;
            IconSize = Size.Medium;
            Immediate = false;
            InputMode = InputMode.numeric;
            Label = string.Empty;
            Lines = 1;
            Margin = Margin.None;
            Max = null;
            Min = null;
            Pattern = string.Empty;
            Placeholder = string.Empty;
            ReadOnly = false;
            Step = null;
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
            if (Adornment.None != Adornment)
            {
                // Add the property value.
                attr[nameof(Adornment)] = Adornment;
            }

            // Does this property have a non-default value?
            if (Color.Default != AdornmentColor)
            {
                // Add the property value.
                attr[nameof(AdornmentColor)] = AdornmentColor;
            }

            // Does this property have a non-default value?
            if (false == string.IsNullOrEmpty(AdornmentIcon))
            {
                // Add the property value.
                attr[nameof(AdornmentIcon)] = AdornmentIcon;
            }

            // Does this property have a non-default value?
            if (false == string.IsNullOrEmpty(AdornmentText))
            {
                // Add the property value.
                attr[nameof(AdornmentText)] = AdornmentText;
            }

            // Does this property have a non-default value?
            if (false != AutoFocus)
            {
                // Add the property value.
                attr[nameof(AutoFocus)] = AutoFocus;
            }

            // Does this property have a non-default value?
            if (0 != DebounceInterval)
            {
                // Add the property value.
                attr[nameof(DebounceInterval)] = DebounceInterval;
            }

            // Does this property have a non-default value?
            if (false != Disabled)
            {
                // Add the property value.
                attr[nameof(Disabled)] = Disabled;
            }

            // Does this property have a non-default value?
            if (false != DisableUnderLine)
            {
                // Add the property value.
                attr[nameof(DisableUnderLine)] = DisableUnderLine;
            }

            // Does this property have a non-default value?
            if (false == string.IsNullOrEmpty(Format))
            {
                // Add the property value.
                attr[nameof(Format)] = Format;
            }

            // Does this property have a non-default value?
            if (false != FullWidth)
            {
                // Add the property value.
                attr[nameof(FullWidth)] = FullWidth;
            }

            // Does this property have a non-default value?
            if (false != HideSpinButtons)
            {
                // Add the property value.
                attr[nameof(HideSpinButtons)] = HideSpinButtons;
            }

            // Does this property have a non-default value?
            if (Size.Medium != IconSize)
            {
                // Add the property value.
                attr[nameof(IconSize)] = IconSize;
            }

            // Does this property have a non-default value?
            if (false != Immediate)
            {
                // Add the property value.
                attr[nameof(Immediate)] = Immediate;
            }

            // Does this property have a non-default value?
            if (InputMode.numeric != InputMode)
            {
                // Add the property value.
                attr[nameof(InputMode)] = InputMode;
            }

            // Does this property have a non-default value?
            if (false == string.IsNullOrEmpty(Label))
            {
                // Add the property value.
                attr[nameof(Label)] = Label;
            }

            // Does this property have a non-default value?
            if (1 != Lines)
            {
                // Add the property value.
                attr[nameof(Lines)] = Lines;
            }

            // Does this property have a non-default value?
            if (Margin.None != Margin)
            {
                // Add the property value.
                attr[nameof(Margin)] = Margin;
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
            if (false == string.IsNullOrEmpty(Pattern))
            {
                // Add the property value.
                attr[nameof(Pattern)] = Pattern;
            }

            // Does this property have a non-default value?
            if (false == string.IsNullOrEmpty(Placeholder))
            {
                // Add the property value.
                attr[nameof(Placeholder)] = Placeholder;
            }

            // Does this property have a non-default value?
            if (false != ReadOnly)
            {
                // Add the property value.
                attr[nameof(ReadOnly)] = ReadOnly;
            }

            // Does this property have a non-default value?
            if (null != Step)
            {
                // Add the property value.
                attr[nameof(Step)] = Step;
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
                .ThrowIfNull(logger, nameof(logger));

            try
            {
                // If we get here then we are trying to render a MudNumericField component
                //   and bind it to the specified numeric property.

                // Should never happen, but, pffft, check it anyway.
                if (path.Count < 2)
                {
                    // Let the world know what we're doing.
                    logger.LogDebug(
                        "RenderMudNumericFieldAttribute::Generate called with a shallow path!"
                        );

                    // Return the index.
                    return index;
                }

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
                        propParent
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
                        propParent
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
                        propParent
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
                        propParent
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
                        propParent
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
                        propParent
                        );
                }

                // Otherwise, we don't know this type ...
                else
                {
                    // Let the world know what we're doing.
                    logger.LogDebug(
                        "Ignoring property: '{PropName}' on: '{ObjName}' " +
                        "because we only render mud numeric components on properties " +
                        "that are of type: numeric. That property is of type: '{PropType}'!",
                        prop.Name,
                        propParent.GetType().Name,
                        propertyType.Name
                        );
                }

                // Return the index.
                return index;
            }
            catch (Exception ex)
            {
                // Give the error better context.
                throw new FormGenerationException(
                    message: "Failed to render a mud numeric field! " +
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
        /// This method generates a MudNumericField control that is bound to 
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
        /// <returns>The index after rendering is complete.</returns>
        private int BindToByte(
            RenderTreeBuilder builder,
            int index,
            IHandleEvent eventTarget,
            PropertyInfo prop,
            ILogger<IFormGenerator> logger,
            Type propertyType,
            object model,
            object propParent
            )
        {
            // Let the world know what we're doing.
            logger.LogDebug(
                "Rendering property: '{PropName}' as a MudNumericField.",
                prop.Name
                );

            // Get any non-default attribute values (overrides).
            var attributes = ToAttributes();

            // Did we not override the label?
            if (false == attributes.ContainsKey("Label"))
            {
                // Ensure the Label property is set.
                attributes["Label"] = prop.Name;
            }

            // Is the NOT property nullable?
            if (propertyType == typeof(byte))
            {
                // Is there a value?
                if (null != model)
                {
                    // Ensure the Value property value is set.
                    attributes["Value"] = (byte)prop.GetValue(propParent);
                }

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

                // Ensure the For property value is set.
                attributes["For"] = Expression.Lambda<Func<byte>>(
                    MemberExpression.Property(
                        Expression.Constant(
                            propParent,
                            propParent.GetType()
                            ),
                        prop.Name
                        )
                    );

                // Render as a MudNumericField control.
                index = builder.RenderUIComponent<MudNumericField<byte>>(
                    index++,
                    attributes: attributes
                    );
            }

            // Otherwise, the property IS nullable.
            else
            {
                // Is there a value?
                if (null != model)
                {
                    // Ensure the Value property value is set.
                    attributes["Value"] = (byte?)prop.GetValue(propParent);
                }

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

                // Ensure the For property value is set.
                attributes["For"] = Expression.Lambda<Func<byte?>>(
                    MemberExpression.Property(
                        Expression.Constant(
                            propParent,
                            propParent.GetType()
                            ),
                        prop.Name
                        )
                    );

                // Render as a MudNumericField control.
                index = builder.RenderUIComponent<MudNumericField<byte?>>(
                    index++,
                    attributes: attributes
                    );
            }

            // Return the index.
            return index;
        }

        // *******************************************************************

        /// <summary>
        /// This method generates a MudNumericField control that is bound to 
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
        /// <returns>The index after rendering is complete.</returns>
        private int BindToInt(
            RenderTreeBuilder builder,
            int index,
            IHandleEvent eventTarget,
            PropertyInfo prop,
            ILogger<IFormGenerator> logger,
            Type propertyType,
            object model,
            object propParent
            )
        {
            // Let the world know what we're doing.
            logger.LogDebug(
                "Rendering property: '{PropName}' as a MudNumericField.",
                prop.Name
                );

            // Get any non-default attribute values (overrides).
            var attributes = ToAttributes();

            // Did we not override the label?
            if (false == attributes.ContainsKey("Label"))
            {
                // Ensure the Label property is set.
                attributes["Label"] = prop.Name;
            }

            // Is the NOT property nullable?
            if (propertyType == typeof(int))
            {
                // Is there a value?
                if (null != model)
                {
                    // Ensure the Value property value is set.
                    attributes["Value"] = (int)prop.GetValue(propParent);
                }

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

                // Ensure the For property value is set.
                attributes["For"] = Expression.Lambda<Func<int>>(
                    MemberExpression.Property(
                        Expression.Constant(
                            propParent,
                            propParent.GetType()
                            ),
                        prop.Name
                        )
                    );

                // Render as a MudNumericField control.
                index = builder.RenderUIComponent<MudNumericField<int>>(
                    index++,
                    attributes: attributes
                    );
            }

            // Otherwise, the property IS nullable.
            else
            {
                // Is there a value?
                if (null != model)
                {
                    // Ensure the Value property value is set.
                    attributes["Value"] = (int?)prop.GetValue(propParent);
                }

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

                // Render as a MudNumericField control.
                index = builder.RenderUIComponent<MudNumericField<int?>>(
                    index++,
                    attributes: attributes
                    );
            }

            // Return the index.
            return index;
        }

        // *******************************************************************

        /// <summary>
        /// This method generates a MudNumericField control that is bound to 
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
        /// <returns>The index after rendering is complete.</returns>
        private int BindToLong(
            RenderTreeBuilder builder,
            int index,
            IHandleEvent eventTarget,
            PropertyInfo prop,
            ILogger<IFormGenerator> logger,
            Type propertyType,
            object model,
            object propParent
            )
        {
            // Let the world know what we're doing.
            logger.LogDebug(
                "Rendering property: '{PropName}' as a MudNumericField.",
                prop.Name
                );

            // Get any non-default attribute values (overrides).
            var attributes = ToAttributes();

            // Did we not override the label?
            if (false == attributes.ContainsKey("Label"))
            {
                // Ensure the Label property is set.
                attributes["Label"] = prop.Name;
            }

            // Is the NOT property nullable?
            if (propertyType == typeof(long))
            {
                // Is there a value?
                if (null != model)
                {
                    // Ensure the Value property value is set.
                    attributes["Value"] = (long)prop.GetValue(propParent);
                }

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

                // Ensure the For property value is set.
                attributes["For"] = Expression.Lambda<Func<long>>(
                    MemberExpression.Property(
                        Expression.Constant(
                            propParent,
                            propParent.GetType()
                            ),
                        prop.Name
                        )
                    );

                // Render as a MudNumericField control.
                index = builder.RenderUIComponent<MudNumericField<long>>(
                    index++,
                    attributes: attributes
                    );
            }

            // Otherwise, the property IS nullable.
            else
            {
                // Is there a value?
                if (null != model)
                {
                    // Ensure the Value property value is set.
                    attributes["Value"] = (long?)prop.GetValue(propParent);
                }

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

                // Ensure the For property value is set.
                attributes["For"] = Expression.Lambda<Func<long?>>(
                    MemberExpression.Property(
                        Expression.Constant(
                            propParent,
                            propParent.GetType()
                            ),
                        prop.Name
                        )
                    );

                // Render as a MudNumericField control.
                index = builder.RenderUIComponent<MudNumericField<long?>>(
                    index++,
                    attributes: attributes
                    );
            }

            // Return the index.
            return index;
        }

        // *******************************************************************

        /// <summary>
        /// This method generates a MudNumericField control that is bound to 
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
        /// <returns>The index after rendering is complete.</returns>
        private int BindToFloat(
            RenderTreeBuilder builder,
            int index,
            IHandleEvent eventTarget,
            PropertyInfo prop,
            ILogger<IFormGenerator> logger,
            Type propertyType,
            object model,
            object propParent
            )
        {
            // Let the world know what we're doing.
            logger.LogDebug(
                "Rendering property: '{PropName}' as a MudNumericField.",
                prop.Name
                );

            // Get any non-default attribute values (overrides).
            var attributes = ToAttributes();

            // Did we not override the label?
            if (false == attributes.ContainsKey("Label"))
            {
                // Ensure the Label property is set.
                attributes["Label"] = prop.Name;
            }

            // Is the NOT property nullable?
            if (propertyType == typeof(float))
            {
                // Is there a value?
                if (null != model)
                {
                    // Ensure the Value property value is set.
                    attributes["Value"] = (float)prop.GetValue(propParent);
                }

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

                // Ensure the For property value is set.
                attributes["For"] = Expression.Lambda<Func<float>>(
                    MemberExpression.Property(
                        Expression.Constant(
                            propParent,
                            propParent.GetType()
                            ),
                        prop.Name
                        )
                    );

                // Render as a MudNumericField control.
                index = builder.RenderUIComponent<MudNumericField<float>>(
                    index++,
                    attributes: attributes
                    );
            }

            // Otherwise, the property IS nullable.
            else
            {
                // Is there a value?
                if (null != model)
                {
                    // Ensure the Value property value is set.
                    attributes["Value"] = (float?)prop.GetValue(propParent);
                }

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

                // Ensure the For property value is set.
                attributes["For"] = Expression.Lambda<Func<float?>>(
                    MemberExpression.Property(
                        Expression.Constant(
                            propParent,
                            propParent.GetType()
                            ),
                        prop.Name
                        )
                    );

                // Render as a MudNumericField control.
                index = builder.RenderUIComponent<MudNumericField<float?>>(
                    index++,
                    attributes: attributes
                    );
            }

            // Return the index.
            return index;
        }

        // *******************************************************************

        /// <summary>
        /// This method generates a MudNumericField control that is bound to 
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
        /// <returns>The index after rendering is complete.</returns>
        private int BindToDouble(
            RenderTreeBuilder builder,
            int index,
            IHandleEvent eventTarget,
            PropertyInfo prop,
            ILogger<IFormGenerator> logger,
            Type propertyType,
            object model,
            object propParent
            )
        {
            // Let the world know what we're doing.
            logger.LogDebug(
                "Rendering property: '{PropName}' as a MudNumericField.",
                prop.Name
                );

            // Get any non-default attribute values (overrides).
            var attributes = ToAttributes();

            // Did we not override the label?
            if (false == attributes.ContainsKey("Label"))
            {
                // Ensure the Label property is set.
                attributes["Label"] = prop.Name;
            }

            // Is the NOT property nullable?
            if (propertyType == typeof(double))
            {
                // Is there a value?
                if (null != model)
                {
                    // Ensure the Value property value is set.
                    attributes["Value"] = (double)prop.GetValue(propParent);
                }

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

                // Ensure the For property value is set.
                attributes["For"] = Expression.Lambda<Func<double>>(
                    MemberExpression.Property(
                        Expression.Constant(
                            propParent,
                            propParent.GetType()
                            ),
                        prop.Name
                        )
                    );

                // Render as a MudNumericField control.
                index = builder.RenderUIComponent<MudNumericField<double>>(
                    index++,
                    attributes: attributes
                    );
            }

            // Otherwise, the property IS nullable.
            else
            {
                // Is there a value?
                if (null != model)
                {
                    // Ensure the Value property value is set.
                    attributes["Value"] = (double?)prop.GetValue(propParent);
                }

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

                // Ensure the For property value is set.
                attributes["For"] = Expression.Lambda<Func<double?>>(
                    MemberExpression.Property(
                        Expression.Constant(
                            propParent,
                            propParent.GetType()
                            ),
                        prop.Name
                        )
                    );

                // Render as a MudNumericField control.
                index = builder.RenderUIComponent<MudNumericField<double?>>(
                    index++,
                    attributes: attributes
                    );
            }

            // Return the index.
            return index;
        }

        // *******************************************************************

        /// <summary>
        /// This method generates a MudNumericField control that is bound to 
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
        /// <returns>The index after rendering is complete.</returns>
        private int BindToDecimal(
            RenderTreeBuilder builder,
            int index,
            IHandleEvent eventTarget,
            PropertyInfo prop,
            ILogger<IFormGenerator> logger,
            Type propertyType,
            object model,
            object propParent
            )
        {
            // Let the world know what we're doing.
            logger.LogDebug(
                "Rendering property: '{PropName}' as a MudNumericField.",
                prop.Name
                );

            // Get any non-default attribute values (overrides).
            var attributes = ToAttributes();

            // Did we not override the label?
            if (false == attributes.ContainsKey("Label"))
            {
                // Ensure the Label property is set.
                attributes["Label"] = prop.Name;
            }

            // Is the NOT property nullable?
            if (propertyType == typeof(decimal))
            {
                // Is there a value?
                if (null != model)
                {
                    // Ensure the Value property value is set.
                    attributes["Value"] = (decimal)prop.GetValue(propParent);
                }

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

                // Ensure the For property value is set.
                attributes["For"] = Expression.Lambda<Func<decimal>>(
                    MemberExpression.Property(
                        Expression.Constant(
                            propParent,
                            propParent.GetType()
                            ),
                        prop.Name
                        )
                    );

                // Render as a MudNumericField control.
                index = builder.RenderUIComponent<MudNumericField<decimal>>(
                    index++,
                    attributes: attributes
                    );
            }

            // Otherwise, the property IS nullable.
            else
            {
                // Is there a value?
                if (null != model)
                {
                    // Ensure the Value property value is set.
                    attributes["Value"] = (decimal?)prop.GetValue(propParent);
                }

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

                // Ensure the For property value is set.
                attributes["For"] = Expression.Lambda<Func<decimal?>>(
                    MemberExpression.Property(
                        Expression.Constant(
                            propParent,
                            propParent.GetType()
                            ),
                        prop.Name
                        )
                    );

                // Render as a MudNumericField control.
                index = builder.RenderUIComponent<MudNumericField<decimal?>>(
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
