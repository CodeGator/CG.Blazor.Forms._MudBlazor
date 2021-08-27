using CG.Blazor.Forms.Attributes;
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
    /// the form generator to render the property as a <see cref="MudSelect{T}"/> 
    /// component.
    /// </summary>
    /// <remarks>
    /// <para>
    /// This attribute is only valid when placed on a property of type: <see cref="string"/>.
    /// </para>
    /// </remarks>
    /// <example>
    /// Here is an example of decorating a model property to render a  <see cref="MudSelect{T}"/>:
    /// <code>
    /// using CG.Blazor.Forms.Attributes;
    /// class MyModel
    /// {
    ///     [RenderSelect(Options = "1 2 3 4")]
    ///     public string MyProperty { get;set; }
    /// }
    /// </code>
    /// </example>
    [AttributeUsage(AttributeTargets.Property)]
    public class RenderMudSelectAttribute : MudBlazorAttribute
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
        /// This property contains the close select icon.
        /// </summary>
        public string CloseIcon { get; set; }

        /// <summary>
        /// This property, if true, causes compact vertical padding to be 
        /// applied to all Select items.
        /// </summary>
        public bool Dense { get; set; }

        /// <summary>
        /// This property sets the direction the Select menu should open.
        /// </summary>
        public Direction Direction { get; set; }

        /// <summary>
        /// This property, if true, the input will be disabled.
        /// </summary>
        public bool Disabled { get; set; }

        /// <summary>
        /// This property, if true, disables the under line for the input.
        /// </summary>
        public bool DisableUnderLine { get; set; }

        /// <summary>
        /// This property contains the conversion format parameter for ToString(), 
        /// which can be used for formatting primitive types, DateTimes and TimeSpans
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
        public Size IconSize { get; set; }

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
        /// This property contains an optional label for the text field.
        /// </summary>
        public string Label { get; set; }

        /// <summary>
        /// This property contains the number of lines that the input will display.
        /// </summary>
        public int Lines { get; set; }

        /// <summary>
        /// This property indicates how much to change the vertical spacing. 
        /// </summary>
        public Margin Margin { get; set; }

        /// <summary>
        /// This property indicates the maximum height the select can have when open.
        /// </summary>
        public int MaxHeight { get; set; }

        /// <summary>
        /// This property, if true, multiple values can be selected via checkboxes which 
        /// are automatically shown in the dropdown
        /// </summary>
        public bool MultiSelection { get; set; }

        /// <summary>
        /// This property, if true, the Select menu will open either before or after the 
        /// input (left/right).
        /// </summary>
        public bool OffsetX { get; set; }

        /// <summary>
        /// This property, if true, the Select menu will open either before or after the 
        /// input (top/bottom).
        /// </summary>
        public bool OffsetY { get; set; }

        /// <summary>
        /// This property contains the open select icon.
        /// </summary>
        public string OpenIcon { get; set; }

        /// <summary>
        /// This property contains a comma separated list of options, for the dropdown.
        /// </summary>
        public string Options { get; set; }

        /// <summary>
        /// This property contains the pattern attribute, when specified, is a regular 
        /// expression which the input's value must match in order for the value to 
        /// pass constraint validation. It must be a valid JavaScript regular expression.
        /// Not Supported in multline input
        /// </summary>
        public string Pattern { get; set; }

        /// <summary>
        /// This property, if true, the input will be read-only.
        /// </summary>
        public bool ReadOnly { get; set; }

        /// <summary>
        /// This propert, ff true, the Select's input will not show any values that 
        /// are not defined in the dropdown. This can be useful if Value is bound 
        /// to a variable which is initialized to a value which is not in the list
        /// and you want the Select to show the label / placeholder instead.
        /// </summary>
        public bool Strict { get; set; }

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
        /// This constructor creates a new instance of the <see cref="RenderMudSelectAttribute"/>
        /// class.
        /// </summary>
        public RenderMudSelectAttribute()
        {
            // Set default values.
            Adornment = Adornment.End;
            AdornmentColor = Color.Default;
            AdornmentIcon = string.Empty;
            AdornmentText = string.Empty;
            AutoFocus = false;
            Clearable = false;
            CloseIcon = string.Empty;
            Dense = false;
            Direction = Direction.Bottom;
            Disabled = false;
            DisableUnderLine = false;
            Format = string.Empty;
            FullWidth = false;
            IconSize = Size.Medium;
            Immediate = false;
            InputMode = InputMode.text;
            Label = string.Empty;
            Lines = 1;
            Margin = Margin.None;
            MaxHeight = 300;
            MultiSelection = false;
            OffsetX = false;
            OffsetY = false;
            OpenIcon = string.Empty;
            Options = string.Empty;
            Pattern = string.Empty;
            ReadOnly = false;
            Strict = false;
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
            if (Adornment.End != Adornment)
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
            if (Direction.Bottom != Direction)
            {
                // Add the property value.
                attr[nameof(Direction)] = Direction;
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
            if (300 != MaxHeight)
            {
                // Add the property value.
                attr[nameof(MaxHeight)] = MaxHeight;
            }

            // Does this property have a non-default value?
            if (false != MultiSelection)
            {
                // Add the property value.
                attr[nameof(MultiSelection)] = MultiSelection;
            }

            // Does this property have a non-default value?
            if (false != OffsetX)
            {
                // Add the property value.
                attr[nameof(OffsetX)] = OffsetX;
            }

            // Does this property have a non-default value?
            if (false != OffsetY)
            {
                // Add the property value.
                attr[nameof(OffsetY)] = OffsetY;
            }

            // Does this property have a non-default value?
            if (false == string.IsNullOrEmpty(Pattern))
            {
                // Add the property value.
                attr[nameof(Pattern)] = Pattern;
            }

            // Does this property have a non-default value?
            if (false == string.IsNullOrEmpty(OpenIcon))
            {
                // Add the property value.
                attr[nameof(OpenIcon)] = OpenIcon;
            }

            // Does this property have a non-default value?
            if (false == string.IsNullOrEmpty(Pattern))
            {
                // Add the property value.
                attr[nameof(Pattern)] = Pattern;
            }

            // Does this property have a non-default value?
            if (false != ReadOnly)
            {
                // Add the property value.
                attr[nameof(ReadOnly)] = ReadOnly;
            }

            // Does this property have a non-default value?
            if (false != Strict)
            {
                // Add the property value.
                attr[nameof(Strict)] = Strict;
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
                // If we get here then we are trying to render a MudSelect component
                //   and bind it to the specified string property.

                // Should never happen, but, pffft, check it anyway.
                if (path.Count < 2)
                {
                    // Let the world know what we're doing.
                    logger.LogDebug(
                        "RenderMudSelectAttribute::Generate called with a shallow path!"
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
                        "RenderMudSelectAttribute::Generate called with a null model!"
                        );

                    // Return the index.
                    return index;
                }

                

                // Get the property's parent.
                var propParent = path.Skip(1).First();

                // We only render MudSelect controls against strings.
                if (prop.PropertyType == typeof(string))
                {
                    // Let the world know what we're doing.
                    logger.LogDebug(
                        "Rendering property: '{PropPath}' as a MudSelect. [idx: '{Index}']",
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

                    // Ensure the T attribute is set.
                    attributes["T"] = typeof(string).Name;

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

                    // Render the property as a MudSelect control.
                    index = builder.RenderUIComponent<MudSelect<string>>(
                        index++,
                        attributes: attributes,
                        contentDelegate: childBuilder =>
                        {
                            // Loop through the options
                            var options = Options.Split(',');
                            foreach (var option in options)
                            {
                                var index2 = index; // Reset the index.

                                // Create attributes for the item.
                                var selectItemAttributes = new Dictionary<string, object>()
                                {
                                    { "Value", option },
                                    { "T", attributes["T"] }
                                };

                                // Render the MudSelectItem control.
                                index2 = childBuilder.RenderUIComponent<MudSelectItem<string>>(
                                    index2++,
                                    attributes: selectItemAttributes
                                    );
                            }
                        });
                }
                else
                {
                    // Let the world know what we're doing.
                    logger.LogDebug(
                        "Not rendering property: '{PropPath}' since we only render " +
                        "MudSelect components on properties of type: string. " +
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
                    message: "Failed to render a MudSelect component! " +
                        "See inner exception(s) for more detail.",
                    innerException: ex
                    );
            }
        }

        #endregion
    }
}
