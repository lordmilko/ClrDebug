using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
#if GENERATED_MARSHALLING
using System.Runtime.InteropServices.Marshalling;
#endif

namespace ClrDebug
{
    /// <summary>
    /// Extends the "ICorDebugObjectValue" interface to support inheritance and overrides.
    /// </summary>
    [Guid("49E4A320-4A9B-4ECA-B105-229FB7D5009F")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
#if !GENERATED_MARSHALLING
    [ComImport]
#else
    [GeneratedComInterface]
#endif
    public partial interface ICorDebugObjectValue2
    {
        /// <summary>
        /// This method is not yet implemented.
        /// </summary>
        /// <remarks>
        /// Gets interface pointers to the "ICorDebugFunction" and "ICorDebugType" instances that represent the most derived
        /// method and type for the specified member reference.
        /// </remarks>
        [PreserveSig]
        HRESULT GetVirtualMethodAndType(
            [In] mdMemberRef memberRef,
            [Out, MarshalAs(UnmanagedType.Interface)] out ICorDebugFunction ppFunction,
            [Out, MarshalAs(UnmanagedType.Interface)] out ICorDebugType ppType);
    }
}
