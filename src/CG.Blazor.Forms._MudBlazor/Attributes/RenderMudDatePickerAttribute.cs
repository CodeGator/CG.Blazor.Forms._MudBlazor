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
    /// This class is an attribute that, when applied to a <see cref="Nullable{DateTime}"/> property, 
    /// causes the form generator to render the property as a <see cref="MudDatePicker"/> 
    /// component.
    /// </summary>
    /// <remarks>
    /// <para>
    /// This attribute is only valid when placed on a property of type: <see cref="Nullable{DateTime}"/>.
    /// </para>
    /// </remarks>
    /// <example>
    /// Here is an example of decorating a model property to render a  <see cref="MudDatePicker"/>:
    /// <code>
    /// using CG.Blazor.Forms.Attributes;
    /// class MyModel
    /// {
    ///     [RenderMudDatePicker]
    ///     public DateTime? MyProperty { get;set; }
    /// }
    /// </code>
    /// </example>
    [AttributeUsage(AttributeTargets.Property)]
    public class RenderMudDatePickerAttribute : MudBlazorAttribute
    {
        // *******************************************************************
        // Properties.
        // *******************************************************************

        #region Properties

        /// <summary>
        /// This property indicates the position for the control.
        /// </summary>
        public Adornment Adornment { get; set; }

        /// <summary>
        /// This property indicates the color for the control.
        /// </summary>
        public Color AdornmentColor { get; set; }

        /// <summary>
        /// This property indicates the icon for the control.
        /// </summary>
        public string AdornmentIcon { get; set; }

        /// <summary>
        /// This property indicates whether the control accepts keyboard 
        /// input, or not.
        /// </summary>
        public bool AllowKeyboardInput { get; set; }

        /// <summary>
        /// This property indicates whether the control should close 
        /// automatically, or not.
        /// </summary>
        public bool AutoClose { get; set; }

        /// <summary>
        /// This property contains any CSS classes to use for the action buttons.
        /// </summary>
        public string ClassActions { get; set; }

        /// <summary>
        /// This property indicates the closing delay for the control.
        /// </summary>
        public int ClosingDelay { get; set; }

        /// <summary>
        /// This property contains the color to use for the control.
        /// </summary>
        public Color Color { get; set; }

        /// <summary>
        /// This property indicates the date format for the control.
        /// </summary>
        public string DateFormat { get; set; }

        /// <summary>
        /// This property indicates whether the control is disabled, or not.
        /// </summary>
        public bool Disabled { get; set; }

        /// <summary>
        /// This property indicates whether the toolbar is disabled, or not.
        /// </summary>
        public bool DisableToolbar { get; set; }

        /// <summary>
        /// This property indicates how many months to display in the control.
        /// </summary>
        public int DisplayMonths { get; set; }

        /// <summary>
        /// This property indicates whether the control is editable, or not.
        /// </summary>
        public bool Editable { get; set; }

        /// <summary>
        /// This property contains the elevation to use for the control.
        /// </summary>
        public int Elevation { get; set; }

        /// <summary>
        /// This property contains an optional day on which to start the week.
        /// </summary>
        public DayOfWeek? FirstDayOfWeek { get; set; }

        /// <summary>
        /// This property indicates the icon size to use with the control.
        /// </summary>
        public Size IconSize { get; set; }

        /// <summary>
        /// This property contains a label for the control.
        /// </summary>
        public string Label { get; set; }

        /// <summary>
        /// This property contains the margin for the control.
        /// </summary>
        public Margin Margin { get; set; }

        /// <summary>
        /// This property contains an optional maximum date for the control.
        /// </summary>
        public DateTime? MaxDate { get; set; }

        /// <summary>
        /// This property contains an optional maximum number of months to show
        /// in a singlee row, on the control.
        /// </summary>
        public int? MaxMonthColumns { get; set; }

        /// <summary>
        /// This property contains an optional minimum date for the control.
        /// </summary>
        public DateTime? MinDate { get; set; }

        /// <summary>
        /// This property contains the first view to show in the control.
        /// </summary>
        public OpenTo OpenTo { get; set; }

        /// <summary>
        /// This property contains the orientiation for the control.
        /// </summary>
        public Orientation Orientation { get; set; }

        /// <summary>
        /// This property contains the control container variant.
        /// </summary>
        public PickerVariant PickerVariant { get; set; }

        /// <summary>
        /// This property indicates whether the control is read only, or not.
        /// </summary>
        public bool ReadOnly { get; set; }

        /// <summary>
        /// This property indicates whether the control is required, or not.
        /// </summary>
        public bool Required { get; set; }

        /// <summary>
        /// This property indicates whether the control should have rounded corners, 
        /// or not.
        /// </summary>
        public bool Rounded { get; set; }

        /// <summary>
        /// This property indicates whether the control should show weekly numbers, 
        /// or not.
        /// </summary>
        public bool ShowWeekNumbers { get; set; }

        /// <summary>
        /// This property indicates whether the control should show square corners, 
        /// or not.
        /// </summary>
        public bool Square { get; set; }

        /// <summary>
        /// This property contains an optional starting month date for the control.
        /// </summary>
        public DateTime? StartMonth { get; set; }

        /// <summary>
        /// This property indicates the format to use for the selected date, in
        /// the title of the control.
        /// </summary>
        public string TitleDateFormat { get; set; }

        /// <summary>
        /// This property contains any CSS classes to use for the control's tool
        /// bar.
        /// </summary>
        public string ToolBarClass { get; set; }

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
        /// This constructor creates a new instance of the <see cref="RenderMudDatePickerAttribute"/>
        /// class.
        /// </summary>
        public RenderMudDatePickerAttribute()
        {
            // Set default values.
            Adornment = Adornment.End;
            AdornmentColor = Color.Default;
            AdornmentIcon = string.Empty;
            AllowKeyboardInput = false;
            AutoClose = false;
            ClassActions = string.Empty;
            ClosingDelay = 100;
            Color = Color.Primary;
            DateFormat = string.Empty;
            Disabled = false;
            DisableToolbar = false;
            DisplayMonths = 1;
            Editable = false;
            Elevation = 0;
            FirstDayOfWeek = null;
            IconSize = Size.Medium;
            Label = string.Empty;
            Margin = Margin.None;
            MaxDate = null;
            MaxMonthColumns = null;
            MinDate = null;
            OpenTo = OpenTo.Date;
            Orientation = Orientation.Portrait;
            PickerVariant = PickerVariant.Inline;
            ReadOnly = false;
            Required = false;
            Rounded = false;
            ShowWeekNumbers = false;
            Square = false;
            StartMonth = null;
            Tag = null;
            TitleDateFormat = string.Empty;
            ToolBarClass = string.Empty;
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
            if (false != AllowKeyboardInput)
            {
                // Add the property value.
                attr[nameof(AllowKeyboardInput)] = AllowKeyboardInput;
            }

            // Does this property have a non-default value?
            if (false != AutoClose)
            {
                // Add the property value.
                attr[nameof(AutoClose)] = AutoClose;
            }

            // Does this property have a non-default value?
            if (false == string.IsNullOrEmpty(ClassActions))
            {
                // Add the property value.
                attr[nameof(ClassActions)] = ClassActions;
            }

            // Does this property have a non-default value?
            if (100 != ClosingDelay)
            {
                // Add the property value.
                attr[nameof(ClosingDelay)] = ClosingDelay;
            }

            // Does this property have a non-default value?
            if (Color.Primary != Color)
            {
                // Add the property value.
                attr[nameof(Color)] = Color;
            }

            // Does this property have a non-default value?
            if (false == string.IsNullOrEmpty(DateFormat))
            {
                // Add the property value.
                attr[nameof(DateFormat)] = DateFormat;
            }

            // Does this property have a non-default value?
            if (false != Disabled)
            {
                // Add the property value.
                attr[nameof(Disabled)] = Disabled;
            }

            // Does this property have a non-default value?
            if (false != DisableToolbar)
            {
                // Add the property value.
                attr[nameof(DisableToolbar)] = DisableToolbar;
            }

            // Does this property have a non-default value?
            if (1 != DisplayMonths)
            {
                // Add the property value.
                attr[nameof(DisplayMonths)] = DisplayMonths;
            }

            // Does this property have a non-default value?
            if (false != Editable)
            {
                // Add the property value.
                attr[nameof(Editable)] = Editable;
            }

            // Does this property have a non-default value?
            if (0 != Elevation)
            {
                // Add the property value.
                attr[nameof(Elevation)] = Elevation;
            }

            // Does this property have a non-default value?
            if (null != FirstDayOfWeek)
            {
                // Add the property value.
                attr[nameof(FirstDayOfWeek)] = FirstDayOfWeek.Value;
            }

            // Does this property have a non-default value?
            if (Size.Medium != IconSize)
            {
                // Add the property value.
                attr[nameof(IconSize)] = IconSize;
            }

            // Does this property have a non-default value?
            if (false == string.IsNullOrEmpty(Label))
            {
                // Add the property value.
                attr[nameof(Label)] = Label;
            }

            // Does this property have a non-default value?
            if (Margin.None != Margin)
            {
                // Add the property value.
                attr[nameof(Margin)] = Margin;
            }

            // Does this property have a non-default value?
            if (null != MaxDate)
            {
                // Add the property value.
                attr[nameof(MaxDate)] = MaxDate;
            }

            // Does this property have a non-default value?
            if (null != MaxMonthColumns)
            {
                // Add the property value.
                attr[nameof(MaxMonthColumns)] = MaxMonthColumns;
            }

            // Does this property have a non-default value?
            if (null != MinDate)
            {
                // Add the property value.
                attr[nameof(MinDate)] = MinDate;
            }

            // Does this property have a non-default value?
            if (OpenTo.Date != OpenTo)
            {
                // Add the property value.
                attr[nameof(OpenTo)] = OpenTo;
            }

            // Does this property have a non-default value?
            if (Orientation.Portrait != Orientation)
            {
                // Add the property value.
                attr[nameof(Orientation)] = Orientation;
            }

            // Does this property have a non-default value?
            if (PickerVariant.Inline != PickerVariant)
            {
                // Add the property value.
                attr[nameof(PickerVariant)] = PickerVariant;
            }

            // Does this property have a non-default value?
            if (false != ReadOnly)
            {
                // Add the property value.
                attr[nameof(ReadOnly)] = ReadOnly;
            }

            // Does this property have a non-default value?
            if (false != Required)
            {
                // Add the property value.
                attr[nameof(Required)] = Required;
            }

            // Does this property have a non-default value?
            if (false != Rounded)
            {
                // Add the property value.
                attr[nameof(Rounded)] = Rounded;
            }

            // Does this property have a non-default value?
            if (false != ShowWeekNumbers)
            {
                // Add the property value.
                attr[nameof(ShowWeekNumbers)] = ShowWeekNumbers;
            }

            // Does this property have a non-default value?
            if (false != Square)
            {
                // Add the property value.
                attr[nameof(Square)] = Square;
            }

            // Does this property have a non-default value?
            if (null != StartMonth)
            {
                // Add the property value.
                attr[nameof(StartMonth)] = StartMonth;
            }

            // Does this property have a non-default value?
            if (false == string.IsNullOrEmpty(TitleDateFormat))
            {
                // Add the property value.
                attr[nameof(TitleDateFormat)] = TitleDateFormat;
            }

            // Does this property have a non-default value?
            if (false == string.IsNullOrEmpty(ToolBarClass))
            {
                // Add the property value.
                attr[nameof(ToolBarClass)] = ToolBarClass;
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
                // If we get here then we are trying to render a MudTextField component
                //   and bind it to the specified string property.

                // Should never happen, but, pffft, check it anyway.
                if (path.Count < 2)
                {
                    // Let the world know what we're doing.
                    logger.LogDebug(
                        "RenderMudDateTimeAttribute::Generate called with a shallow path!"
                        );

                    // Return the index.
                    return index;
                }

                // Create a complete property path, for logging.
                var propPath = $"{string.Join('.', path.Skip(1).Reverse().Select(x => x.GetType().Name))}.{prop.Name}";

                // Get the model reference.
                var model = path.Peek();

                // This is alright since the type is nullable.
                if (null == model)
                {
                    // Supply a dummy value, for now.
                    model = default(DateTime);
                }

                // Get the property type.
                var propertyType = prop.PropertyType;

                // Get the property's parent.
                var propParent = path.Skip(1).First();

                // Should we bind to a DateTime?
                if (propertyType == typeof(DateTime))
                {
                    index = BindToDateTime(
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

                else
                {
                    // Let the world know what we're doing.
                    logger.LogDebug(
                        "Not rendering property: '{PropPath}' since we only render " +
                        "MudDatePicker components on properties of type: DateTime. " +
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
                    message: "Failed to render a MudDatePicker component! " +
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
        /// This method generates a MudDatePicker control that is bound to 
        /// a DateTime property.
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
        private int BindToDateTime(
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
                "Rendering property: '{PropPath}' as a MudTimePicker. [idx: '{Index}']",
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

            // Is this NOT a dummy value?
            if (false == default(DateTime).Equals((DateTime?)model))
            {
                // Ensure the property value is set.
                attributes["Date"] = (DateTime?)prop.GetValue(propParent);
            }

            // Ensure the property is bound, both ways.
            attributes["DateChanged"] = RuntimeHelpers.TypeCheck<EventCallback<DateTime?>>(
                EventCallback.Factory.Create<DateTime?>(
                    eventTarget,
                    EventCallback.Factory.CreateInferred<DateTime?>(
                        eventTarget,
                        x => prop.SetValue(propParent, x),
                        (DateTime?)prop.GetValue(propParent)
                        )
                    )
                );

            // Render as a MudDatePicker control.
            index = builder.RenderUIComponent<MudDatePicker>(
                index++,
                attributes: attributes
                );

            // Return the index.
            return index;
        }

        #endregion
    }
}
