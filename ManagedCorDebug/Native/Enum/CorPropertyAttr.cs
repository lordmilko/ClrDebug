using System;

namespace ManagedCorDebug
{
    [Flags]
    public enum CorPropertyAttr
    {
        prSpecialName           =   0x0200,     // property is special.  Name describes how.

        // Reserved flags for Runtime use only.
        prReservedMask          =   0xf400,
        prRTSpecialName         =   0x0400,     // Runtime(metadata internal APIs) should check name encoding.
        prHasDefault            =   0x1000,     // Property has default

        prUnused                =   0xe9ff,
    }
}