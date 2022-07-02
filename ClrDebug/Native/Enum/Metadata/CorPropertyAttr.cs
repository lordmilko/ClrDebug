using System;

namespace ClrDebug
{
    /// <summary>
    /// Contains values that describe the metadata of a property.
    /// </summary>
    [Flags]
    public enum CorPropertyAttr
    {
        /// <summary>
        /// Specifies that the property is special, and that its name describes how.
        /// </summary>
        prSpecialName           =   0x0200,     // property is special.  Name describes how.

        /// <summary>
        /// Reserved for internal use by the common language runtime.
        /// </summary>
        prReservedMask          =   0xf400,

        /// <summary>
        /// Specifies that the common language runtime metadata internal APIs should check the encoding of the property name.
        /// </summary>
        prRTSpecialName         =   0x0400,     // Runtime(metadata internal APIs) should check name encoding.

        /// <summary>
        /// Specifies that the property has a default value.
        /// </summary>
        prHasDefault            =   0x1000,     // Property has default

        /// <summary>
        /// Unused.
        /// </summary>
        prUnused                =   0xe9ff,
    }
}