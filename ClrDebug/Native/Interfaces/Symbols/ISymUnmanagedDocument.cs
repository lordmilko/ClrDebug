using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
#if GENERATED_MARSHALLING
using System.Runtime.InteropServices.Marshalling;
#endif

namespace ClrDebug
{
    /// <summary>
    /// Represents a document referenced by a symbol store. A document is defined by a uniform resource locator (URL) and a document type GUID.<para/>
    /// You can locate the document regardless of how it is stored by using the URL and document type GUID. You can store the document source in the symbol store and retrieve it through this interface.
    /// </summary>
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("40DE4037-7C81-3E1E-B022-AE1ABFF2CA08")]
    [ComImport]
    public interface ISymUnmanagedDocument
    {
        /// <summary>
        /// Returns the uniform resource locator (URL) for this document.
        /// </summary>
        /// <param name="cchUrl">[in] The size, in characters, of the szURL buffer.</param>
        /// <param name="pcchUrl">[out] A pointer to a variable that receives the size of the URL, including the null termination.</param>
        /// <param name="szUrl">[out] The buffer containing the URL.</param>
        /// <returns>S_OK if the method succeeds; otherwise, an error code.</returns>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT GetURL(
            [In] int cchUrl,
            [Out] out int pcchUrl,
            [Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U2, SizeParamIndex = 0)] char[] szUrl);

        /// <summary>
        /// Gets the document type of this document.
        /// </summary>
        /// <param name="pRetVal">[out] Pointer to a variable that receives the document type.</param>
        /// <returns>S_OK if the method succeeds.</returns>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT GetDocumentType(
            [Out]
#if GENERATED_MARSHALLING
            [MarshalUsing(typeof(GuidMarshaller))]
#endif
            out Guid pRetVal);

        /// <summary>
        /// Gets the language identifier of this document
        /// </summary>
        /// <param name="pRetVal">[out] A pointer to a variable that receives the language identifier.</param>
        /// <returns>S_OK if the method succeeds.</returns>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT GetLanguage(
            [Out]
#if GENERATED_MARSHALLING
            [MarshalUsing(typeof(GuidMarshaller))]
#endif
            out Guid pRetVal);

        /// <summary>
        /// Gets the language vendor of this document.
        /// </summary>
        /// <param name="pRetVal">[out] A pointer to a variable that receives the language vendor.</param>
        /// <returns>S_OK if the method succeeds.</returns>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT GetLanguageVendor(
            [Out]
#if GENERATED_MARSHALLING
            [MarshalUsing(typeof(GuidMarshaller))]
#endif
            out Guid pRetVal);

        /// <summary>
        /// Gets the checksum algorithm identifier, or returns a GUID of all zeros if there is no checksum.
        /// </summary>
        /// <param name="pRetVal">[out] A pointer to a variable that receives the checksum algorithm identifier.</param>
        /// <returns>S_OK if the method succeeds.</returns>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT GetCheckSumAlgorithmId(
            [Out]
#if GENERATED_MARSHALLING
            [MarshalUsing(typeof(GuidMarshaller))]
#endif
            out Guid pRetVal);

        /// <summary>
        /// Gets the checksum.
        /// </summary>
        /// <param name="cData">[in] The length of the buffer provided by the data parameter</param>
        /// <param name="pcData">[out] The size and length of the checksum, in bytes.</param>
        /// <param name="data">[out] The buffer that receives the checksum.</param>
        /// <returns>S_OK if the method succeeds; otherwise, an error code.</returns>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT GetCheckSum(
            [In] int cData,
            [Out] out int pcData,
            [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0), Out] byte[] data);

        /// <summary>
        /// Returns the closest line that is a sequence point, given a line in this document that may or may not be a sequence point.
        /// </summary>
        /// <param name="line">[in] A line in this document.</param>
        /// <param name="pRetVal">[out] A pointer to a variable that receives the line.</param>
        /// <returns>S_OK if the method succeeds; otherwise, an error code.</returns>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT FindClosestLine(
            [In] int line,
            [Out] out int pRetVal);

        /// <summary>
        /// Returns true if the document has source embedded in the debugging symbols; otherwise, returns false.
        /// </summary>
        /// <param name="pRetVal">[out] A pointer to a variable that indicates whether the document has source embedded in the debugging symbols.</param>
        /// <returns>S_OK if the method succeeds.</returns>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT HasEmbeddedSource(
            [Out] out int pRetVal);

        /// <summary>
        /// Gets the length, in bytes, of the embedded source.
        /// </summary>
        /// <param name="pRetVal">[out] A pointer to a variable that indicates the length, in bytes, of the embedded source.</param>
        /// <returns>S_OK if the method succeeds.</returns>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT GetSourceLength(
            [Out] out int pRetVal);

        /// <summary>
        /// Returns the specified range of the embedded source into the given buffer. The buffer must be large enough to hold the source.
        /// </summary>
        /// <param name="startLine">[in] The starting line in the current document.</param>
        /// <param name="startColumn">[in] The starting column in the current document.</param>
        /// <param name="endLine">[in] The final line in the current document.</param>
        /// <param name="endColumn">[in] The final column in the current document.</param>
        /// <param name="cSourceBytes">[in] The size of the source, in bytes.</param>
        /// <param name="pcSourceBytes">[out] A pointer to a variable that receives the source size.</param>
        /// <param name="source">[out] The size and length of the specified range of the source document, in bytes.</param>
        /// <returns>S_OK if the method succeeds.</returns>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT GetSourceRange(
            [In] int startLine,
            [In] int startColumn,
            [In] int endLine,
            [In] int endColumn,
            [In] int cSourceBytes,
            [Out] out int pcSourceBytes,
            [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 4), Out] byte[] source);
    }
}
