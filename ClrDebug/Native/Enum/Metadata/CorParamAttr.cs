using System;

namespace ClrDebug
{
    /// <summary>
    /// Contains values that describe the metadata of a method parameter.
    /// </summary>
    [Flags]
    public enum CorParamAttr
    {
        /// <summary>
        /// Specifies that the parameter is passed into the method call.
        /// </summary>
        pdIn                        =   0x0001,     // Param is [In]

        /// <summary>
        /// Specifies that the parameter is passed from the method return.
        /// </summary>
        pdOut                       =   0x0002,     // Param is [out]

        /// <summary>
        /// Specifies that the parameter is optional.
        /// </summary>
        pdOptional                  =   0x0010,     // Param is optional

        /// <summary>
        /// Reserved for internal use by the common language runtime.
        /// </summary>
        pdReservedMask              =   0xf000,

        /// <summary>
        /// Specifies that the parameter has a default value.
        /// </summary>
        pdHasDefault                =   0x1000,     // Param has default value.

        /// <summary>
        /// Specifies that the parameter has marshalling information.
        /// </summary>
        pdHasFieldMarshal           =   0x2000,     // Param has FieldMarshal.

        /// <summary>
        /// Unused.
        /// </summary>
        pdUnused                    =   0xcfe0,
    }
}