using System;

namespace ManagedCorDebug
{
    [Flags]
    public enum CorMethodSemanticsAttr
    {
        msSetter = 0x0001,     // Setter for property
        msGetter = 0x0002,     // Getter for property
        msOther = 0x0004,     // other method for property or event
        msAddOn = 0x0008,     // AddOn method for event
        msRemoveOn = 0x0010,     // RemoveOn method for event
        msFire = 0x0020,     // Fire method for event
    }
}