using System;
using System.Collections.Generic;

namespace CG.Blazor.Forms.Attributes
{
    /// <summary>
    /// This class is a base for all MudBlazor specific form generation attributes.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public abstract class MudBlazorAttribute : FormGeneratorAttribute
    {
        // *******************************************************************
        // Properties.
        // *******************************************************************

        #region Properties

        /// <summary>
        /// This property contains user class names, separated by space
        /// </summary>
        public string Class { get; set; }

        /// <summary>
        /// This property contains user styles, applied on top of the component's 
        /// own classes and styles
        /// </summary>
        public string Style { get; set; }

        /// <summary>
        /// This property contain a tag to attach any user data object to the component 
        /// for your convenience.
        /// </summary>
        public object Tag { get; set; }

        /// <summary>
        /// This property contains attributes you add to the component that don't match 
        /// any of its parameters. They will be splatted onto the underlying HTML tag.
        /// </summary>
        public IDictionary<string, object> UserAttributes { get; set; }

        #endregion

        // *******************************************************************
        // Constructors.
        // *******************************************************************

        #region Constructors

        /// <summary>
        /// This constructor creates a new instance of <see cref="MudBlazorAttribute"/>
        /// class.
        /// </summary>
        protected MudBlazorAttribute()
        {
            // Set default values.
            Class = string.Empty;
            Style = string.Empty;
            Tag = null;
            UserAttributes = null;
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
            var attr = base.ToAttributes();

            // Does this property have a non-default value?
            if (false == string.IsNullOrEmpty(Class))
            {
                // Add the property value.
                attr[nameof(Class)] = Class;
            }

            // Does this property have a non-default value?
            if (false == string.IsNullOrEmpty(Style))
            {
                // Add the property value.
                attr[nameof(Style)] = Style;
            }

            // Does this property have a non-default value?
            if (null != Tag)
            {
                // Add the property value.
                attr[nameof(Tag)] = Tag;
            }

            // Does this property have a non-default value?
            if (null != UserAttributes)
            {
                // Add the property value.
                attr[nameof(UserAttributes)] = UserAttributes;
            }

            // Return the attributes.
            return attr;
        }

        #endregion
    }
}
