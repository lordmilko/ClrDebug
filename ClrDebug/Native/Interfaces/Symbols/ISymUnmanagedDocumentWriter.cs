using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
#if GENERATED_MARSHALLING
using System.Runtime.InteropServices.Marshalling;
#endif

namespace ClrDebug
{
    /// <summary>
    /// Provides methods for writing to a document referenced by a symbol store.
    /// </summary>
    [Guid("B01FAFEB-C450-3A4D-BEEC-B4CEEC01E006")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [ComImport]
    public interface ISymUnmanagedDocumentWriter
    {
        /// <summary>
        /// Sets embedded source for a document that is being written.
        /// </summary>
        /// <param name="sourceSize">[in] A ULONG32 that contains the size of the source buffer.</param>
        /// <param name="source">[in] The buffer that stores the embedded source.</param>
        /// <returns>S_OK if the method succeeds; otherwise, E_FAIL or some other error code.</returns>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT SetSource(
            [In] int sourceSize,
            [In] IntPtr source);

        /// <summary>
        /// Sets checksum information.
        /// </summary>
        /// <param name="algorithmId">[in] The GUID that represents the algorithm identifier.</param>
        /// <param name="checkSumSize">[in] A ULONG32 that indicates the size, in bytes, of the checkSum buffer.</param>
        /// <param name="checkSum">[in] The buffer that stores the checksum information.</param>
        /// <returns>S_OK if the method succeeds; otherwise, E_FAIL or some other error code.</returns>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT SetCheckSum(
#if !GENERATED_MARSHALLING
            [In, MarshalAs(UnmanagedType.LPStruct)]
#else
            [MarshalUsing(typeof(GuidMarshaller))] in
#endif
            Guid algorithmId,
            [In] int checkSumSize,
            [In] IntPtr checkSum);
    }
}
