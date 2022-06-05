using System;

namespace ManagedCorDebug
{
    /// <summary>
    /// Contains values that describe the relationship between a method and an associated property or event.
    /// </summary>
    [Flags]
    public enum CorMethodSemanticsAttr
    {
        /// <summary>
        /// Specifies that the method is a set accessor for a property.
        /// </summary>
        msSetter = 0x0001,     // Setter for property

        /// <summary>
        /// Specifies that the method is a get accessor for a property.
        /// </summary>
        msGetter = 0x0002,     // Getter for property

        /// <summary>
        /// Specifies that the method has a relationship to a property or an event other than those defined here.
        /// </summary>
        msOther = 0x0004,     // other method for property or event

        /// <summary>
        /// Specifies that the method adds handler methods for an event.
        /// </summary>
        msAddOn = 0x0008,     // AddOn method for event

        /// <summary>
        /// Specifies that the method removes handler methods for an event.
        /// </summary>
        msRemoveOn = 0x0010,     // RemoveOn method for event

        /// <summary>
        /// Specifies that the method raises an event.
        /// </summary>
        msFire = 0x0020,     // Fire method for event
    }
}