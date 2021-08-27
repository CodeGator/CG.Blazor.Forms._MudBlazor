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
    /// This class is an attribute that, when applied to a <see cref="TimeSpan"/> 
    /// property, causes the form generator to render the property as a <see cref="MudTimePicker"/> 
    /// component.
    /// </summary>
    /// <remarks>
    /// <para>
    /// This attribute is only valid when placed on a property of type: <see cref="TimeSpan"/>.
    /// </para>
    /// </remarks>
    /// <example>
    /// Here is an example of decorating a model property to render a  <see cref="MudTimePicker"/>:
    /// <code>
    /// using CG.Blazor.Forms.Attributes;
    /// class MyModel
    /// {
    ///     [RenderMudTimePacker]
    ///     public TimeSpan MyProperty { get;set; }
    /// }
    /// </code>
    /// </example>
    [AttributeUsage(AttributeTargets.Property)]
    public class RenderMudTimePickerAttribute : MudBlazorAttribute
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
        /// This property indicates whether the control shows a 12 or 24 hour day.
        /// </summary>
        public bool AmPm { get; set; }

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
        /// This property indicates whether the control is disabled, or not.
        /// </summary>
        public bool Disabled { get; set; }

        /// <summary>
        /// This property indicates whether the toolbar is disabled, or not.
        /// </summary>
        public bool DisableToolbar { get; set; }

        /// <summary>
        /// This property indicates whether the control is editable, or not.
        /// </summary>
        public bool Editable { get; set; }

        /// <summary>
        /// This property contains the elevation to use for the control.
        /// </summary>
        public int Elevation { get; set; }

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
        /// This property indicates whether the control should show square corners, 
        /// or not.
        /// </summary>
        public bool Square { get; set; }

        /// <summary>
        /// This property contains the edition mode. By default, you can 
        /// edit hours and minutes.
        /// </summary>
        public TimeEditMode TimeEditMode { get; set; }  

        /// <summary>
        /// This property contains the string format for the selected time.
        /// </summary>
        public string TimeFormat {  get; set; }

        /// <summary>
        /// This property contains user class names for picker's ToolBar, 
        /// separated by space
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
        /// This constructor creates a new instance of the <see cref="RenderMudTimePickerAttribute"/>
        /// class.
        /// </summary>
        public RenderMudTimePickerAttribute()
        {
            // Set default values.
            Adornment = Adornment.End;
            AdornmentColor = Color.Default;
            AdornmentIcon = string.Empty;
            AllowKeyboardInput = false;
            AmPm = false;
            AutoClose = false;
            ClassActions = string.Empty;
            ClosingDelay = 100;
            Color = Color.Primary;
            Disabled = false;
            DisableToolbar = false;
            Editable = false;
            Elevation = 0;
            IconSize = Size.Medium;
            Label = string.Empty;
            Margin = Margin.None;
            OpenTo = OpenTo.Hours;
            Orientation = Orientation.Portrait;
            PickerVariant = PickerVariant.Inline;
            ReadOnly = false;
            Required = false;
            Rounded = false;
            Square = false;
            TimeEditMode = TimeEditMode.Normal;
            TimeFormat = string.Empty;
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
            if (false != AmPm)
            {
                // Add the property value.
                attr[nameof(AmPm)] = AmPm;
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
            if (false != Square)
            {
                // Add the property value.
                attr[nameof(Square)] = Square;
            }

            // Does this property have a non-default value?
            if (TimeEditMode.Normal != TimeEditMode)
            {
                // Add the property value.
                attr[nameof(TimeEditMode)] = TimeEditMode;
            }

            // Does this property have a non-default value?
            if (false == string.IsNullOrEmpty(TimeFormat))
            {
                // Add the property value.
                attr[nameof(TimeFormat)] = TimeFormat;
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
                // If we get here then we are trying to render a MudTimePicker component
                //   and bind it to the specified TimeSpan property.

                // Should never happen, but, pffft, check it anyway.
                if (path.Count < 2)
                {
                    // Let the world know what we're doing.
                    logger.LogDebug(
                        "RenderMudTimePickerAttribute::Generate called with a shallow path!"
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
                    model = default(TimeSpan);
                }
                
                // Get the property type.
                var propertyType = prop.PropertyType;

                // Get the property's parent.
                var propParent = path.Skip(1).First();

                // Should we bind to a TimeSpan?
                if (propertyType == typeof(TimeSpan))
                {
                    index = BindToTimeSpan(
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
                        "MudTimePicker components on properties of type: TimeSpan. " +
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
                    message: "Failed to render a mud time picker field! " +
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
        /// This method generates a MudTimePicker control that is bound to 
        /// a TimeSpan property.
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
        private int BindToTimeSpan(
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
            if (false == default(TimeSpan).Equals((TimeSpan?)model))
            {
                // Ensure the property value is set.
                attributes["Time"] = (TimeSpan?)prop.GetValue(propParent);
            }

            // Ensure the property is bound, both ways.
            attributes["TimeChanged"] = RuntimeHelpers.TypeCheck<EventCallback<TimeSpan?>>(
                EventCallback.Factory.Create<TimeSpan?>(
                    eventTarget,
                    EventCallback.Factory.CreateInferred<TimeSpan?>(
                        eventTarget,
                        x => prop.SetValue(propParent, x),
                        (TimeSpan?)prop.GetValue(propParent)
                        )
                    )
                );

            // Render as a MudTimePicker control.
            index = builder.RenderUIComponent<MudTimePicker>(
                index++,
                attributes: attributes
                );

            // Return the index.
            return index;
        }

        #endregion
    }
}
