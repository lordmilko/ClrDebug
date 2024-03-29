﻿using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using SRI = System.Runtime.InteropServices;
#if GENERATED_MARSHALLING
using System.Runtime.InteropServices.Marshalling;
#endif

namespace ClrDebug
{
    /// <summary>
    /// Provides information for the Edit and Continue feature.
    /// </summary>
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("85E891DA-A631-4C76-ACA2-A44A39C46B8C")]
#if !GENERATED_MARSHALLING
    [ComImport]
#else
    [GeneratedComInterface]
#endif
    public partial interface ISymENCUnmanagedMethod
    {
        /// <summary>
        /// Gets the file name for the line associated with an offset.
        /// </summary>
        /// <param name="dwOffset">[in] A ULONG32 that contains the offset.</param>
        /// <param name="cchName">[in] A ULONG32 that indicates the size of the szName buffer.</param>
        /// <param name="pcchName">[out] A pointer to a ULONG32 that receives the size, in characters, of the buffer required to contain the file names.</param>
        /// <param name="szName">[out] The buffer that contains the file names.</param>
        /// <returns>S_OK if the method succeeds; otherwise, E_FAIL or some other error code.</returns>
        [PreserveSig]
        HRESULT GetFileNameFromOffset(
            [In] int dwOffset,
            [In] int cchName,
            [Out] out int pcchName,
            [SRI.Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U2, SizeParamIndex = 1)] char[] szName);

        /// <summary>
        /// Gets the line information associated with an offset. If the offset parameter (dwOffset) is not a sequence point, this method gets the line information associated with the previous offset.
        /// </summary>
        /// <param name="dwOffset">[in] A ULONG32 that contains the offset.</param>
        /// <param name="pline">[out] A pointer to a ULONG32 that receives the line.</param>
        /// <param name="pcolumn">[out] A pointer to a ULONG32 that receives the column.</param>
        /// <param name="pendLine">[out] A pointer to a ULONG32 that receives the end line.</param>
        /// <param name="pendColumn">[out] A pointer to a ULONG32 that receives the end column.</param>
        /// <param name="pdwStartOffset">[out] A pointer to a ULONG32 that receives the associated sequence point.</param>
        /// <returns>S_OK if the method succeeds; otherwise, E_FAIL or some other error code.</returns>
        [PreserveSig]
        HRESULT GetLineFromOffset(
            [In] int dwOffset,
            [Out] out int pline,
            [Out] out int pcolumn,
            [Out] out int pendLine,
            [Out] out int pendColumn,
            [Out] out int pdwStartOffset);

        /// <summary>
        /// Gets the number of documents that this method has lines in.
        /// </summary>
        /// <param name="pRetVal">[out] A pointer to a ULONG32 that receives the size of the buffer required to contain the documents.</param>
        /// <returns>S_OK if the method succeeds; otherwise, E_FAIL or some other error code.</returns>
        [PreserveSig]
        HRESULT GetDocumentsForMethodCount(
            [Out] out int pRetVal);

        /// <summary>
        /// Gets the documents that this method has lines in.
        /// </summary>
        /// <param name="cDocs">[in] The length of the buffer pointed to by pcDocs.</param>
        /// <param name="pcDocs">[out] A pointer to a ULONG32 that receives the size, in characters, of the buffer required to contain the documents.</param>
        /// <param name="documents">[in] The buffer that contains the documents.</param>
        /// <returns>S_OK if the method succeeds; otherwise, an error code.</returns>
        [PreserveSig]
        HRESULT GetDocumentsForMethod(
            [In] int cDocs,
            [Out] out int pcDocs,
            [SRI.Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] ISymUnmanagedDocument[] documents);

        /// <summary>
        /// Gets the smallest start line and largest end line for the method in a specific document.
        /// </summary>
        /// <param name="document">[in] A pointer to the document.</param>
        /// <param name="pstartLine">[out] A pointer to a ULONG32 that receives the start line.</param>
        /// <param name="pendLine">[out] A pointer to a ULONG32 that receives the end line.</param>
        /// <returns>S_OK if the method succeeds; otherwise, E_FAIL or some other error code.</returns>
        [PreserveSig]
        HRESULT GetSourceExtentInDocument(
            [MarshalAs(UnmanagedType.Interface), In] ISymUnmanagedDocument document,
            [Out] out int pstartLine,
            [Out] out int pendLine);
    }
}
