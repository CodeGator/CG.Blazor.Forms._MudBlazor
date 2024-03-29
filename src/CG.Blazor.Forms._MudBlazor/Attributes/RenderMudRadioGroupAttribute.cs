﻿using CG.Blazor.Forms.Services;
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
    /// the form generator to render the property as a <see cref="MudRadioGroup{T}"/> 
    /// component.
    /// </summary>
    /// <remarks>
    /// <para>
    /// This attribute is only valid when placed on a property of type: string.
    /// </para>
    /// </remarks>
    /// <example>
    /// Here is an example of decorating a model property to render a <see cref="MudRadioGroup{T}"/>:
    /// <code>
    /// using CG.Blazor.Forms.Attributes;
    /// class MyModel
    /// {
    ///     [RenderRadioGroup(Options = "1 2 3")]
    ///     public string MyProperty { get;set; }
    /// }
    /// </code>
    /// </example>
    [AttributeUsage(AttributeTargets.Property)]
    public class RenderMudRadioGroupAttribute : MudBlazorAttribute
    {
        // *******************************************************************
        // Properties.
        // *******************************************************************

        #region Properties

        /// <summary>
        /// This property contains a comma separated list of options for the 
        /// radio buttons in the group.
        /// </summary>
        public string Options { get; set; }

        /// <summary>
        /// This property contains the name of an optional function, on either the 
        /// top-level view-model, or the the associated model. That returns a list
        /// of strings, for options. 
        /// </summary>
        /// <remarks>
        /// <para>
        /// The method should have this signature: IEnumerable{string} Func()
        /// </para>
        /// </remarks>
        public string OptionsFunc { get; set; }

        /// <summary>
        /// This property contains a comma separated list of colors for the 
        /// radio buttons in the group.
        /// </summary>
        public string Colors { get; set; }

        /// <summary>
        /// This property indicates whether the radio buttons in the group 
        /// should be dense, or not.
        /// </summary>
        public bool Dense { get; set; }

        /// <summary>
        /// This property contains a comma separated list of disabled flags
        /// for the radio buttons in the group.
        /// </summary>
        public string Disabled { get; set; }

        /// <summary>
        /// This property indicates whether the radio buttons in the group 
        /// should disable the ripple, or not.
        /// </summary>
        public bool DisableRipple { get; set; }

        /// <summary>
        /// This property indicates the placement for the radio buttons in the 
        /// group.
        /// </summary>
        public Placement Placement { get; set; }

        /// <summary>
        /// This property indicates the size for the radio buttons in the group.
        /// </summary>
        public Size Size { get; set; }

        #endregion

        // *******************************************************************
        // Constructors.
        // *******************************************************************

        #region Constructors

        /// <summary>
        /// This constructor creates a new instance of the <see cref="RenderMudRadioGroupAttribute"/>
        /// class.
        /// </summary>
        public RenderMudRadioGroupAttribute()
        {
            // Set default values.
            Colors = string.Empty;
            Dense = false;
            Disabled = string.Empty;
            DisableRipple = false;
            Options = string.Empty;
            OptionsFunc = string.Empty;
            Placement = Placement.End;
            Size = Size.Medium;
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
            if (false == string.IsNullOrEmpty(Options))
            {
                // Add the property value.
                attr[nameof(Options)] = Options;
            }

            // Does this property have a non-default value?
            if (false == string.IsNullOrEmpty(Colors))
            {
                // Add the property value.
                attr[nameof(Colors)] = Colors;
            }

            // Does this property have a non-default value?
            if (false != Dense)
            {
                // Add the property value.
                attr[nameof(Dense)] = Dense;
            }

            // Does this property have a non-default value?
            if (false == string.IsNullOrEmpty(Disabled))
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
            if (Placement.End != Placement)
            {
                // Add the property value.
                attr[nameof(Placement)] = Placement;
            }

            // Does this property have a non-default value?
            if (Size.Medium != Size)
            {
                // Add the property value.
                attr[nameof(Size)] = Size;
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
                // If we get here then we are trying to render a MudRadioGroup component
                //   and bind it to the specified string property.

                // Should never happen, but, pffft, check it anyway.
                if (path.Count < 2)
                {
                    // Let the world know what we're doing.
                    logger.LogDebug(
                        "RenderMudRadioGroupAttribute::Generate called with a shallow path!"
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
                        "RenderMudRadioGroupAttribute::Generate called with a null model!"
                        );

                    // Return the index.
                    return index;
                }

                // Get the model's type.
                var modelType = model.GetType();

                // Get the property's parent.
                var propParent = path.Skip(1).First();

                // We only render MudRadioGroup controls against strings.
                if (modelType == typeof(string))
                {
                    // Let the world know what we're doing.
                    logger.LogDebug(
                        "Rendering property: '{PropPath}' as a MudRadioGroup. [idx: '{Index}']",
                        propPath,
                        index
                        );

                    // Get any non-default attribute values (overrides).
                    var attributes = ToAttributes();

                    // Ensure the value is set.
                    attributes["SelectedOption"] = (string)prop.GetValue(propParent);

                    // Ensure the property is bound, both ways.
                    attributes["SelectedOptionChanged"] = RuntimeHelpers.TypeCheck<EventCallback<string>>(
                        EventCallback.Factory.Create<string>(
                            eventTarget,
                            EventCallback.Factory.CreateInferred<string>(
                                eventTarget,
                                x => prop.SetValue(propParent, x),
                                (string)prop.GetValue(propParent)
                                )
                            )
                        );

                    // Render the property as a MudRadioGroup control.
                    index = builder.RenderUIComponent<MudRadioGroup<string>>(
                        index++,
                        attributes: attributes,
                        contentDelegate: childBuilder =>
                        {
                            // Split the optional attributes.
                            var colors = Colors.Split(',').Select(x => x.Trim()).ToArray();
                            var disabled = Disabled.Split(',').Select(x => x.Trim()).ToArray();
                            var x = 0;

                            // How should we build the options?
                            IEnumerable<string> options;

                            // Get the view-model.
                            var viewModel = path.Last();

                            // Try to resolve the options func.
                            if (TryOptionsFunc(
                                viewModel,
                                propParent,
                                out var func
                                ))
                            {
                                // If we get here then we resolved the options 
                                //   func, so let's use it now to populate the
                                //   options.

                                // Invoke the function.
                                options = func.Invoke().Result
                                    .Select(x => x.Trim())
                                    .ToArray();
                            }
                            else
                            {
                                // If we get here then we failed to resolve the
                                //   options func, so, try to use the options
                                //   property instead.

                                // Split the options.
                                options = Options.Split(',')
                                    .Select(x => x.Trim())
                                    .ToArray();
                            }

                            // Loop through the options.
                            foreach (var option in options)
                            {
                                var index2 = index; // Reset the index.

                                // Create attributes for the radio button.
                                var buttonAttributes = new Dictionary<string, object>()
                                {
                                    { "Option", option }
                                };

                                // Should we copy the dense flag?
                                if (attributes.ContainsKey("Dense"))
                                {
                                    // Copy the attribute.
                                    buttonAttributes["Dense"] = attributes["Dense"];
                                }

                                // Should we copy the disable ripple flag?
                                if (attributes.ContainsKey("DisableRipple"))
                                {
                                    // Copy the attribute.
                                    buttonAttributes["DisableRipple"] = attributes["DisableRipple"];
                                }

                                // Should we copy the placement?
                                if (attributes.ContainsKey("Placement"))
                                {
                                    // Copy the attribute.
                                    buttonAttributes["Placement"] = attributes["Placement"];
                                }

                                // Should we copy the size?
                                if (attributes.ContainsKey("Size"))
                                {
                                    // Copy the attribute.
                                    buttonAttributes["Size"] = attributes["Size"];
                                }

                                // Should we copy the style?
                                if (attributes.ContainsKey("Style"))
                                {
                                    // Copy the attribute.
                                    buttonAttributes["Style"] = attributes["Style"];
                                }

                                // Should we copy the user attributes?
                                if (attributes.ContainsKey("UserAttributes"))
                                {
                                    // Copy the attribute.
                                    buttonAttributes["UserAttributes"] = attributes["UserAttributes"];
                                }

                                // Do we have a color for this radio button?
                                if (x < colors.Length - 1)
                                {
                                    if (Enum.TryParse<Color>(colors[x], out var colorValue))
                                    {
                                        // Set the color attribute.
                                        buttonAttributes["Color"] = colorValue;
                                    }
                                }

                                // Do we have a disabled flag for this radio button?
                                if (x < disabled.Length - 1)
                                {
                                    if (bool.TryParse(disabled[x], out var disabledValue))
                                    {
                                        // Set the disabled attribute.
                                        buttonAttributes["Disabled"] = disabledValue;
                                    }
                                }

                                // Render the mudradio control.
                                index2 = childBuilder.RenderUIComponent<MudRadio<string>>(
                                    index2++,
                                    attributes: buttonAttributes,
                                    contentDelegate: grandChildBuilder =>
                                    {
                                        // Render the radio button's content.
                                        grandChildBuilder.AddContent(
                                            index2++,
                                            option
                                            );
                                    });

                                // Track which button we're rendering.
                                x++;
                            }
                        });
                }
                else
                {
                    // Let the world know what we're doing.
                    logger.LogDebug(
                        "Not rendering property: '{PropPath}' since we only render " +
                        "MudRadioGroup components on properties of type: string. " +
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
                    message: "Failed to render a MudRadioGroup component! " +
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
        /// This method checks the <see cref="OptionsFunc"/> property and,
        /// if the property is populated, searches on the view-model and
        /// the model for a matching function. That functio is then called
        /// and the resilts are returned to <paramref name="func"/>.
        /// </summary>
        /// <param name="viewModel">The view-model to use for the operation.</param>
        /// <param name="propParent">The model to use for the operation.</param>
        /// <param name="func">The output parameter, which is assigned a 
        /// reference to a func, if one is found.</param>
        /// <returns>True if the <see cref="OptionsFunc"/> property contains 
        /// the name of a method on either the view-model, or the model; False
        /// if not.</returns>
        private bool TryOptionsFunc(
            object viewModel,
            object propParent,
            out Func<Task<IEnumerable<string>>> func
            )
        {
            func = null;

            // Is the property populated?
            if (false == string.IsNullOrEmpty(OptionsFunc))
            {
                // Create possible targets for the search.
                var targets = (viewModel == propParent)
                    ? new[] { viewModel }
                    : new[] { viewModel, propParent };

                // Loop and look for the function.
                foreach (var target in targets)
                {
                    // Get the target type.
                    var targetType = target.GetType();

                    // Look for the named method.
                    var methodInfo = targetType.GetMethod(
                        OptionsFunc,
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

                        // Create the method call expression.
                        var callExp = Expression.Call(
                            viewModelExp,
                            methodInfo
                            );

                        // Create a lambda expression.
                        var lambdaExp = Expression.Lambda<Func<Task<IEnumerable<string>>>>(
                            callExp,
                            callExp.Arguments.OfType<ParameterExpression>()
                            );

                        // Compile the expression to a func.
                        func = lambdaExp.Compile();

                        // We found the func.
                        return true;
                    }
                }
            }

            // We didn't find the func.
            return false;
        }

        #endregion
    }
}
