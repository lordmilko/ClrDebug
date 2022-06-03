using System;

namespace ManagedCorDebug
{
    [Flags]
    public enum CorMethodImpl
    {
        // code impl mask
        miCodeTypeMask = 0x0003,   // Flags about code type.
        miIL = 0x0000,   // Method impl is IL.
        miNative = 0x0001,   // Method impl is native.
        miOPTIL = 0x0002,   // Method impl is OPTIL
        miRuntime = 0x0003,   // Method impl is provided by the runtime.
        // end code impl mask

        // managed mask
        miManagedMask = 0x0004,   // Flags specifying whether the code is managed or unmanaged.
        miUnmanaged = 0x0004,   // Method impl is unmanaged, otherwise managed.
        miManaged = 0x0000,   // Method impl is managed.
        // end managed mask

        // implementation info and interop
        miForwardRef = 0x0010,   // Indicates method is defined; used primarily in merge scenarios.
        miPreserveSig = 0x0080,   // Indicates method sig is not to be mangled to do HRESULT conversion.

        miInternalCall = 0x1000,   // Reserved for internal use.

        miSynchronized = 0x0020,   // Method is single threaded through the body.
        miNoInlining = 0x0008,   // Method may not be inlined.
        miAggressiveInlining = 0x0100,   // Method should be inlined if possible.
        miNoOptimization = 0x0040,   // Method may not be optimized.

        // These are the flags that are allowed in MethodImplAttribute's Value
        // property. This should include everything above except the code impl
        // flags (which are used for MethodImplAttribute's MethodCodeType field).
        miUserMask = miManagedMask | miForwardRef | miPreserveSig |
                     miInternalCall | miSynchronized |
                     miNoInlining | miAggressiveInlining |
                     miNoOptimization,

        miMaxMethodImplVal = 0xffff,   // Range check value
    }
}