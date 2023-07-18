using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
#if GENERATED_MARSHALLING
using System.Runtime.InteropServices.Marshalling;
#endif

namespace ClrDebug
{
    /// <summary>
    /// [Supported in .NET 5 and later versions.] Provides a method that enumerates ranges of native memory that are used by the .NET runtime to store internal data structures that describe .NET types and methods.<para/>
    /// The returned information is the same information that would be shown by using the SOS eeheap -loader command.
    /// </summary>
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("344B37AA-F2C0-4D3B-9909-91CCF787DA8C")]
#if !GENERATED_MARSHALLING
    [ComImport]
#else
    [GeneratedComInterface]
#endif
    public partial interface ICorDebugProcess11
    {
        /// <summary>
        /// [Supported in .NET 5 and later versions.] Enumerates ranges of native memory that are used by the .NET runtime to store internal data structures that describe .NET types and methods.<para/>
        /// The information returned is the same information that would be shown by using the SOS eeheap-loader command.
        /// </summary>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT EnumerateLoaderHeapMemoryRegions(
            [Out, MarshalAs(UnmanagedType.Interface)] out ICorDebugMemoryRangeEnum ppRanges);
    }
}
