using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    /// <summary>
    /// Extends the "ICorDebugObjectValue" interface to support inheritance and overrides.
    /// </summary>
    [Guid("49E4A320-4A9B-4ECA-B105-229FB7D5009F")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [ComImport]
    public interface ICorDebugObjectValue2
    {
        /// <summary>
        /// This method is not yet implemented.
        /// </summary>
        /// <remarks>
        /// Gets interface pointers to the "ICorDebugFunction" and "ICorDebugType" instances that represent the most derived
        /// method and type for the specified member reference.
        /// </remarks>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT GetVirtualMethodAndType(
            [In] uint memberRef,
            [MarshalAs(UnmanagedType.Interface)] out ICorDebugFunction ppFunction,
            [MarshalAs(UnmanagedType.Interface)] out ICorDebugType ppType);
    }
}