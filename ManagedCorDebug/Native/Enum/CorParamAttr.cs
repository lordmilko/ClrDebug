using System;

namespace ManagedCorDebug
{
    [Flags]
    public enum CorParamAttr
    {
        pdIn                        =   0x0001,     // Param is [In]
        pdOut                       =   0x0002,     // Param is [out]
        pdOptional                  =   0x0010,     // Param is optional

        // Reserved flags for Runtime use only.
        pdReservedMask              =   0xf000,
        pdHasDefault                =   0x1000,     // Param has default value.
        pdHasFieldMarshal           =   0x2000,     // Param has FieldMarshal.

        pdUnused                    =   0xcfe0,
    }
}