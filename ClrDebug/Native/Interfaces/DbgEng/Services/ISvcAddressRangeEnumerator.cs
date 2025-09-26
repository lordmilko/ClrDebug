using System.Runtime.InteropServices;
#if GENERATED_MARSHALLING
using System.Runtime.InteropServices.Marshalling;
#endif

namespace ClrDebug.DbgEng
{
    /// <summary>
    /// Enumerates a set of one or more address ranges.
    /// </summary>
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("A7DF185B-CBBF-4B0D-BBA6-C58D6F9240C0")]
#if !GENERATED_MARSHALLING
    [ComImport]
#else
    [GeneratedComInterface]
#endif
    public partial interface ISvcAddressRangeEnumerator
    {
        /// <summary>
        /// Resets the enumerator.
        /// </summary>
        [PreserveSig]
        HRESULT Reset();

        /// <summary>
        /// Gets the next address range from the enumerator.
        /// </summary>
        [PreserveSig]
        HRESULT GetNext(
            [Out] out SvcAddressRange pAddressRange);
    }
}
