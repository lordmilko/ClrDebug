using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace ManagedCorDebug
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
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT SetSource([In] uint sourceSize, [In] ref byte source);

        /// <summary>
        /// Sets checksum information.
        /// </summary>
        /// <param name="algorithmId">[in] The GUID that represents the algorithm identifier.</param>
        /// <param name="checkSumSize">[in] A ULONG32 that indicates the size, in bytes, of the checkSum buffer.</param>
        /// <param name="checkSum">[in] The buffer that stores the checksum information.</param>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT SetCheckSum([In] Guid algorithmId, [In] uint checkSumSize, [In] ref byte checkSum);
    }
}