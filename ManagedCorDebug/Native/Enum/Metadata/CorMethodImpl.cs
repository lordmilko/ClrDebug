using System;

namespace ManagedCorDebug
{
    /// <summary>
    /// Contains values that describe method implementation features.
    /// </summary>
    [Flags]
    public enum CorMethodImpl
    {
        /// <summary>
        /// Flags that describe code type.
        /// </summary>
        miCodeTypeMask = 0x0003,   // Flags about code type.

        /// <summary>
        /// Specifies that the method implementation is Microsoft intermediate language (MSIL).
        /// </summary>
        miIL = 0x0000,   // Method impl is IL.

        /// <summary>
        /// Specifies that the method implementation is native.
        /// </summary>
        miNative = 0x0001,   // Method impl is native.

        /// <summary>
        /// Specifies that the method implementation is OPTIL.
        /// </summary>
        miOPTIL = 0x0002,   // Method impl is OPTIL

        /// <summary>
        /// Specifies that the method implementation is provided by the common language runtime.
        /// </summary>
        miRuntime = 0x0003,   // Method impl is provided by the runtime.

        /// <summary>
        /// Flags that indicate whether the code is managed or unmanaged.
        /// </summary>
        miManagedMask = 0x0004,   // Flags specifying whether the code is managed or unmanaged.

        /// <summary>
        /// Specifies that the method implementation is unmanaged.
        /// </summary>
        miUnmanaged = 0x0004,   // Method impl is unmanaged, otherwise managed.

        /// <summary>
        /// Specifies that the method implementation is managed.
        /// </summary>
        miManaged = 0x0000,   // Method impl is managed.

        /// <summary>
        /// Specifies that the method is defined. This flag is used primarily in merge scenarios.
        /// </summary>
        miForwardRef = 0x0010,   // Indicates method is defined; used primarily in merge scenarios.

        /// <summary>
        /// Specifies that the method signature cannot be mangled for an <see cref="HRESULT"/> conversion.
        /// </summary>
        miPreserveSig = 0x0080,   // Indicates method sig is not to be mangled to do HRESULT conversion.

        /// <summary>
        /// Reserved for internal use by the common language runtime.
        /// </summary>
        miInternalCall = 0x1000,   // Reserved for internal use.

        /// <summary>
        /// Specifies that the method is single-threaded through its body.
        /// </summary>
        miSynchronized = 0x0020,   // Method is single threaded through the body.

        /// <summary>
        /// Specifies that the method cannot be inlined.
        /// </summary>
        miNoInlining = 0x0008,   // Method may not be inlined.

        /// <summary>
        /// Specifies that the method should be inlined if possible.
        /// </summary>
        miAggressiveInlining = 0x0100,   // Method should be inlined if possible.

        /// <summary>
        /// Specifies that the method should not be optimized.
        /// </summary>
        miNoOptimization = 0x0040,   // Method may not be optimized.

        // These are the flags that are allowed in MethodImplAttribute's Value
        // property. This should include everything above except the code impl
        // flags (which are used for MethodImplAttribute's MethodCodeType field).
        miUserMask = miManagedMask | miForwardRef | miPreserveSig |
                     miInternalCall | miSynchronized |
                     miNoInlining | miAggressiveInlining |
                     miNoOptimization,

        /// <summary>
        /// The maximum valid value for a <see cref="CorMethodImpl"/>.
        /// </summary>
        miMaxMethodImplVal = 0xffff,   // Range check value
    }
}