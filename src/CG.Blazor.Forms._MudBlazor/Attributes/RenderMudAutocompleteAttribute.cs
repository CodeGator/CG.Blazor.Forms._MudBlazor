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
using System.Threading.Tasks;

namespace CG.Blazor.Forms.Attributes
{
    /// <summary>
    /// This class is an attribute that, when applied to a string property, causes
    /// the form generator to render the property as a <see cref="MudAutocomplete{T}"/>
    /// component.
    /// </summary>
    /// <remarks>
    /// <para>
    /// This attribute is only valid when placed on a property of type: string.
    /// </para>
    /// <para>
    /// When configured to do so, this attribute causes the form generator to wire 
    /// up a search function for the auto-complete behavior. In order to configure 
    /// that behavior, the <see cref="RenderMudAutocompleteAttribute.SearchFunc"/> 
    /// parameter should be set to the name of a method on the model. Then, at form 
    /// generation time, the form generator will locate that method and wire up a 
    /// callback.
    /// </para>
    /// </remarks>
    /// <example>
    /// Here is an example of decorating a model property to render a <see cref="MudAutocomplete{T}"/>:
    /// <code>
    /// using CG.Blazor.Forms.Attributes;
    /// class MyModel
    /// {
    ///     [RenderMudAutocomplete(SearchFunc = "Search1")]
    ///     public string MyProperty { get;set; }
    ///     
    ///     public async Task<IEnumerable<string>> Search1(string value)
    ///     {
    ///        // TODO : write search code here.
    ///     }
    /// }
    /// </code>
    /// </example>
    [AttributeUsage(AttributeTargets.Property)]
    public class RenderMudAutocompleteAttribute : MudBlazorAttribute
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
        /// This property contains the Close Autocomplete Icon.
        /// </summary>
        public string CloseIcon { get; set; }

        /// <summary>
        /// This property appears on the drop-down close override Text with 
        /// selected Value. This makes it clear to the user which list value 
        /// is currently selected and disallows incomplete values in Text.
        /// </summary>
        public bool CoerceText { get; set; }

        /// <summary>
        /// This property indicates whether user input will be coerced, or not.
        /// </summary>
        public bool CoerceValue { get; set; }

        /// <summary>
        /// This property contains an interval to be awaited, in milliseconds, 
        /// before changing the Text value
        /// </summary>
        public double DebounceInterval { get; set; }

        /// <summary>
        /// This property indicates whether compact vertical padding will be 
        /// applied to all Autocomplete items, or not.
        /// </summary>
        public bool Dense { get; set; }

        /// <summary>
        /// This property indicates the direction the Autocomplete menu should 
        /// use, when opening.
        /// </summary>
        public Direction Direction { get; set; }

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
        /// This property contains the label text will be displayed in the input, 
        /// and scaled down at the top if the input has value.
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
        /// This property indicates how may items to display. 
        /// </summary>
        public int? MaxItems { get; set; }

        /// <summary>
        /// This property indicates the minimal number of character required to
        /// initiate a search.
        /// </summary>
        public int MinCharacters { get; set; }

        /// <summary>
        /// This property indicates whether the Autocomplete menu opens before 
        /// or after the input (left/right).
        /// </summary>
        public bool OffsetX { get; set; }

        /// <summary>
        /// This property indicates whether the Autocomplete menu opens before 
        /// or after the input (top/bottom).
        /// </summary>
        public bool OffsetY { get; set; }

        /// <summary>
        /// This property contains the open icon.
        /// </summary>
        public string OpenIcon { get; set; }

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
        /// This property indicates whether the control will reset Value if user 
        /// deletes the text
        /// </summary>
        public bool ResetValueOnEmptyText { get; set; }

        /// <summary>
        /// This property contains the name of an optional search function, on 
        /// the associated model.
        /// </summary>
        public string SearchFunc { get; set; }

        /// <summary>
        /// This property indicates whether the currently selected item from the
        /// drop-down (if it is open) will be selected on a tab, or not.
        /// </summary>
        public bool SelectValueOnTab { get; set; }

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
        /// This constructor creates a new instance of the <see cref="RenderMudAutocompleteAttribute"/>
        /// class.
        /// </summary>
        public RenderMudAutocompleteAttribute()
        {
            // Set default values.
            Adornment = Adornment.None;
            AdornmentColor = Color.Default;
            AdornmentIcon = string.Empty;
            AdornmentText = string.Empty;
            AutoFocus = false;
            Clearable = false;
            CloseIcon = string.Empty;
            CoerceText = true;
            CoerceValue = false;
            DebounceInterval = 100;
            Dense = false;
            Direction = Direction.Bottom;
            DisableUnderLine = false;
            Format = string.Empty;
            FullWidth = false;
            IconSize = Size.Medium;
            Immediate = false;
            InputMode = InputMode.text;
            Label = string.Empty;
            Lines = 1;
            Margin = Margin.None;
            MaxItems = null;
            MinCharacters = 0;
            OffsetX = false;
            OffsetY = true;
            OpenIcon = string.Empty;
            Pattern = string.Empty;
            Placeholder = string.Empty;
            ReadOnly = false;
            ResetValueOnEmptyText = false;
            SearchFunc = string.Empty;
            SelectValueOnTab = false;
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
            if (true != CoerceText)
            {
                // Add the property value.
                attr[nameof(CoerceText)] = CoerceText;
            }

            // Does this property have a non-default value?
            if (false != CoerceValue)
            {
                // Add the property value.
                attr[nameof(CoerceValue)] = CoerceValue;
            }

            // Does this property have a non-default value?
            if (100 != DebounceInterval)
            {
                // Add the property value.
                attr[nameof(DebounceInterval)] = DebounceInterval;
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
            if (null != MaxItems)
            {
                // Add the property value.
                attr[nameof(MaxItems)] = MaxItems.Value;
            }

            // Does this property have a non-default value?
            if (0 != MinCharacters)
            {
                // Add the property value.
                attr[nameof(MinCharacters)] = MinCharacters;
            }

            // Does this property have a non-default value?
            if (false != OffsetX)
            {
                // Add the property value.
                attr[nameof(OffsetX)] = OffsetX;
            }

            // Does this property have a non-default value?
            if (true != OffsetY)
            {
                // Add the property value.
                attr[nameof(OffsetY)] = OffsetY;
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
            if (false != ResetValueOnEmptyText)
            {
                // Add the property value.
                attr[nameof(ResetValueOnEmptyText)] = ResetValueOnEmptyText;
            }

            // Does this property have a non-default value?
            if (false == string.IsNullOrEmpty(SearchFunc))
            {
                // Add the property value.
                attr[nameof(SearchFunc)] = SearchFunc;
            }

            // Does this property have a non-default value?
            if (false != SelectValueOnTab)
            {
                // Add the property value.
                attr[nameof(SelectValueOnTab)] = SelectValueOnTab;
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
                // If we get here then we are trying to render a MudAutocomplete component
                //   and bind it to the specified string property.

                // Should never happen, but, pffft, check it anyway.
                if (path.Count < 2)
                {
                    // Let the world know what we're doing.
                    logger.LogDebug(
                        "RenderMudAutocompleteAttribute::Generate called with a shallow path!"
                        );

                    // Return the index.
                    return index;
                }

                // Get the model reference.
                var model = path.Peek();

                // Should never happen, but, pffft, check it anyway.
                if (null == model)
                {
                    // Let the world know what we're doing.
                    logger.LogDebug(
                        "RenderMudAutocompleteAttribute::Generate called with a null model!"
                        );

                    // Return the index.
                    return index;
                }

                // Get the model's type.
                var modelType = model.GetType();

                // Get the property's parent.
                var propParent = path.Skip(1).First();

                // We only render MudAutocomplete controls against strings.
                if (modelType == typeof(string))
                {
                    // Let the world know what we're doing.
                    logger.LogDebug(
                        "Rendering property: '{PropName}' as a MudAutocomplete.",
                        prop.Name
                        );

                    // Get any non-default attribute values (overrides).
                    var attributes = ToAttributes();

                    // Should we convert from the string?
                    if (attributes["SearchFunc"] is string methodName)
                    {
                        // If we get here then we need to go find a search method,
                        //   on either the model, or the view-model, that corresponds
                        //   with the method named in the attribute.

                        // Get the view-model.
                        var viewModel = path.Last();

                        // Should never happen, but, pffft, check it anyway.
                        if (null == viewModel)
                        {
                            // Let the world know what we're doing.
                            logger.LogDebug(
                                "RenderMudAutocompleteAttribute::Generate called with a null view model!"
                                );

                            // Return the index.
                            return index;
                        }

                        // Create possible targets for the search.
                        var targets = (viewModel == propParent)
                            ? new[] { viewModel }
                            : new[] { viewModel, propParent };

                        Func<string, Task<IEnumerable<string>>> @func = null;

                        // Loop and look for the search function.
                        foreach (var target in targets)
                        {
                            // Get the target type.
                            var targetType = target.GetType();

                            // Look for the named search method.
                            var methodInfo = targetType.GetMethod(
                                methodName,
                                BindingFlags.Public |
                                BindingFlags.NonPublic |
                                BindingFlags.Instance
                                );

                            // Did we succeed?
                            if (null != methodInfo)
                            {
                                // Create a viewModel reference expression.
                                var viewModelExp = Expression.Constant(
                                    target
                                    );

                                // Create a parameter expression.
                                var p1 = Expression.Parameter(
                                    typeof(string),
                                    "p1"
                                    );

                                // Create the method call expression.
                                var callExp = Expression.Call(
                                    viewModelExp,
                                    methodInfo,
                                    p1
                                    );

                                // Create a lambda expression.
                                var lambdaExp = Expression.Lambda<Func<string, Task<IEnumerable<string>>>>(
                                    callExp,
                                    callExp.Arguments.OfType<ParameterExpression>()
                                    );

                                // Compile the expression to a func.
                                @func = lambdaExp.Compile();

                                // We found the search function so stop looking for it.
                                break;
                            }
                        }

                        // Did we fail?
                        if (null == @func)
                        {
                            // Let the world know what we're doing.
                            logger.LogDebug(
                                "Ignoring property: '{PropName}' on: '{ObjName}' " +
                                "because we couldn't find the named search function: '{SearchFunc}' " +
                                "on either the model, or the view-model!",
                                prop.Name,
                                propParent.GetType().Name,
                                methodName
                                );

                            // Return the index.
                            return index;
                        }

                        // Replace the search method name with the func.
                        attributes["SearchFunc"] = func;

                        // Ensure the Value property value is set.
                        attributes["Value"] = (string)prop.GetValue(propParent);

                        // Ensure the ValueChanged property is bound, both ways.
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

                        // Render the MudAutocomplete control.
                        builder.RenderUIComponent<MudAutocomplete<string>>(
                            index++,
                            attributes: attributes
                            );
                    }
                    else
                    {
                        // Let the world know what we're doing.
                        logger.LogDebug(
                            "Ignoring property: '{PropName}' on: '{ObjName}' " +
                            "because we only render mud auto complete components on properties " +
                            "that are of type: string. That property is of type: '{PropType}'!",
                            prop.Name,
                            propParent.GetType().Name,
                            prop.PropertyType.Name
                            );
                    }
                }

                // Return the index.
                return index;
            }
            catch (Exception ex)
            {
                // Give the error better context.
                throw new FormGenerationException(
                    message: "Failed to render a mud auto complete field! " +
                        "See inner exception(s) for more detail.",
                    innerException: ex
                    );
            }
        }

        #endregion
    }
}
