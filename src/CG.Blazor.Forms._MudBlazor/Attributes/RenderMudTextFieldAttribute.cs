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
    /// This class is an attribute that, when applied to a string property, causes
    /// the form generator to render the property as a <see cref="MudTextField{T}"/> 
    /// component.
    /// </summary>
    /// <remarks>
    /// <para>
    /// This attribute is only valid when placed on a property of type: string.
    /// </para>
    /// </remarks>
    /// <example>
    /// Here is an example of decorating a model property to render a <see cref="MudTextField{T}"/> :
    /// <code>
    /// using CG.Blazor.Forms.Attributes;
    /// class MyModel
    /// {
    ///     [RenderMudTextField]
    ///     public string MyProperty { get;set; }
    /// }
    /// </code>
    /// </example>
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class RenderMudTextFieldAttribute : MudBlazorAttribute
    {
        // *******************************************************************
        // Properties.
        // *******************************************************************

        #region Properties

        /// <summary>
        /// This property contains the Start or End Adornment if not set to None.
        /// </summary>
        public Adornment Adornment { get; set; }

        /// <summary>
        /// This property contains the color of the adornment if used. It 
        /// supports the theme colors.
        /// </summary>
        public Color AdornmentColor { get; set; }

        /// <summary>
        /// This property contains the Icon that will be used if Adornment 
        /// is set to Start or End.
        /// </summary>
        public string AdornmentIcon { get; set; }

        /// <summary>
        /// This property contains text that will be used if Adornment is set 
        /// to Start or End, the Text overrides Icon.
        /// </summary>
        public string AdornmentText { get; set; }

        /// <summary>
        /// This property indicates the input will focus automatically, when true.
        /// </summary>
        public bool AutoFocus { get; set; }

        /// <summary>
        /// This property indicates whether to show the clear button, or not.
        /// </summary>
        public bool Clearable { get; set; }

        /// <summary>
        /// This property contains an interval to be awaited, in milliseconds, 
        /// before changing the Text value
        /// </summary>
        public double DebounceInterval { get; set; }

        /// <summary>
        /// This property indicates whether the inpur element is disabled, or not.
        /// </summary>
        public bool Disabled { get; set; }

        /// <summary>
        /// This property indicates whether the input will have an underline,
        /// or not.
        /// </summary>
        public bool DisableUnderLine { get; set; }

        /// <summary>
        /// This property contains the conversion format parameter for ToString(), 
        /// can be used for formatting primitive types, DateTimes and TimeSpans
        /// </summary>
        public string Format { get; set; }

        /// <summary>
        /// This property indicates whether the input will take up the full width 
        /// of its container, or not.
        /// </summary>
        public bool FullWidth { get; set; }

        /// <summary>
        /// This property indicates the icon size.
        /// </summary>
        public Size IconSize { get; set;  }

        /// <summary>
        /// This property indicates whether the the input will update the Value 
        /// immediately on typing. If false, the Value is updated only on Enter.
        /// </summary>
        public bool Immediate { get; set; }

        /// <summary>
        /// This property hints at the type of data that might be entered by the 
        /// user while editing the input
        /// </summary>
        public InputMode InputMode { get; set; }

        /// <summary>
        /// This property indicates the type of the input element. It should be 
        /// a valid HTML5 input type.
        /// </summary>
        public InputType InputType { get;set; }

        /// <summary>
        /// This property contains the label text will be displayed in the input, 
        /// and scaled down at the top if the input has value.
        /// </summary>
        public string Label { get; set;  }

        /// <summary>
        /// This property contains the number of lines that the input will display.
        /// </summary>
        public int Lines { get; set; }

        /// <summary>
        /// This property indicates how much to change the vertical spacing. 
        /// </summary>
        public Margin Margin { get;set; }

        /// <summary>
        /// This property contains a regular expression which the input's value 
        /// must match in order for the value to pass constraint validation. It 
        /// must be a valid JavaScript regular expression Not Supported in multline 
        /// input
        /// </summary>
        public string Pattern { get; set; }

        /// <summary>
        /// This property contains the short hint displayed in the input before
        /// the user enters a value.
        /// </summary>
        public string Placeholder { get; set; }

        /// <summary>
        /// This property indicates whether the input will be read-only, or not.
        /// </summary>
        public bool ReadOnly { get; set; }

        /// <summary>
        /// This property contains the variant to use with the control.
        /// </summary>
        public Variant Variant { get; set; }

        #endregion

        // *******************************************************************
        // Constructors.
        // *******************************************************************

        #region Constructors

        /// <summary>
        /// This constructor creates a new instance of the <see cref="RenderMudTextFieldAttribute"/>
        /// class.
        /// </summary>
        public RenderMudTextFieldAttribute()
        {
            // Set default values.
            Adornment = Adornment.None;
            AdornmentColor = Color.Default;
            AdornmentIcon = string.Empty;
            AdornmentText = string.Empty;
            AutoFocus = false;
            Clearable = false;
            DebounceInterval = 0;
            Disabled = false;
            DisableUnderLine = false;
            Format = string.Empty;
            FullWidth = false;
            IconSize = Size.Medium;
            Immediate = false;
            InputMode = InputMode.text;
            InputType = InputType.Text;
            Label = string.Empty;
            Lines = 1;
            Margin = Margin.None;
            Pattern = string.Empty;
            Placeholder = string.Empty;
            ReadOnly = false;
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
            // Give the base class a chance.
            var attr = base.ToAttributes();

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
            if (false != Clearable)
            {
                // Add the property value.
                attr[nameof(Clearable)] = Clearable;
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
            if (InputMode.text != InputMode)
            {
                // Add the property value.
                attr[nameof(InputMode)] = InputMode;
            }

            // Does this property have a non-default value?
            if (InputType.Text != InputType)
            {
                // Add the property value.
                attr[nameof(InputType)] = InputType;
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
            ILogger<IFormGenerator> logger)
        {
            // Validate the parameters before attempting to use them.
            Guard.Instance().ThrowIfNull(builder, nameof(builder))
                .ThrowIfLessThanZero(index, nameof(index))
                .ThrowIfNull(path, nameof(path))
                .ThrowIfNull(prop, nameof(prop))
                .ThrowIfNull(logger, nameof(logger));

            try
            {
                // If we get here then we are trying to render a MudTextField component
                //   and bind it to the specified string property.

                // Should never happen, but, pffft, check it anyway.
                if (path.Count < 2)
                {
                    // Let the world know what we're doing.
                    logger.LogDebug(
                        "RenderMudTextFieldAttribute::Generate called with a shallow path!"
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
                        "RenderMudTextFieldAttribute::Generate called with a null model!"
                        );

                    // Return the index.
                    return index;
                }

                // Get the property's parent.
                var propParent = path.Skip(1).First();

                // We only render MudTextField controls against strings.
                if (prop.PropertyType == typeof(string))
                {
                    // Let the world know what we're doing.
                    logger.LogDebug(
                        "Rendering property: '{PropPath}' as a MudTextField. [idx: '{Index}']",
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
                    attributes["Value"] = (string)prop.GetValue(propParent);

                    // Ensure the property is bound, both ways.
                    attributes["ValueChanged"] = RuntimeHelpers.TypeCheck<EventCallback<string>>(
                        EventCallback.Factory.Create<string>(
                            eventTarget,
                            EventCallback.Factory.CreateInferred<string>(
                                eventTarget,
                                x => prop.SetValue(propParent, x),
                                (string)prop.GetValue(propParent)
                                )
                            )
                        );

                    // Make the compiler happy.
                    if (null != propParent)
                    {
                        // Ensure the For property value is set.
                        attributes["For"] = Expression.Lambda<Func<string>>(
                            MemberExpression.Property(
                                Expression.Constant(
                                    propParent,
                                    propParent.GetType()),
                                prop.Name
                                )
                            );
                    }

                    // Render the property as a MudTextField control.
                    index = builder.RenderUIComponent<MudTextField<string>>(
                        index,
                        attributes: attributes
                        );
                }
                else
                {
                    // Let the world know what we're doing.
                    logger.LogDebug(
                        "Not rendering property: '{PropPath}' since we only render " +
                        "MudTextField components on properties of type: string. " +
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
                    message: "Failed to render a mud text field! " +
                        "See inner exception(s) for more detail.",
                    innerException: ex
                    );
            }
        }

        #endregion
    }
}
