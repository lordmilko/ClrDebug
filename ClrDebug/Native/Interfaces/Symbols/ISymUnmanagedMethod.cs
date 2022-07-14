using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace ClrDebug
{
    /// <summary>
    /// Represents a method within the symbol store. This interface provides access to only the symbol-related attributes of a method, instead of the type-related attributes.
    /// </summary>
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("B62B923C-B500-3158-A543-24F307A8B7E1")]
    [ComImport]
    public interface ISymUnmanagedMethod
    {
        /// <summary>
        /// Returns the metadata token for this method.
        /// </summary>
        /// <param name="pToken">[out] A pointer to a <see cref="mdMethodDef"/> that receives the size, in characters, of the buffer required to contain the metadata.</param>
        /// <returns>S_OK if the method succeeds; otherwise, E_FAIL or some other error code.</returns>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT GetToken([Out] out mdMethodDef pToken);

        /// <summary>
        /// Gets the count of sequence points within this method.
        /// </summary>
        /// <param name="pRetVal">[out] A pointer to a ULONG32 that receives the size of the buffer required to contain the sequence points.</param>
        /// <returns>S_OK if the method succeeds; otherwise, E_FAIL or some other error code.</returns>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT GetSequencePointCount([Out] out int pRetVal);

        /// <summary>
        /// Gets the root lexical scope within this method. This scope encloses the entire method.
        /// </summary>
        /// <param name="pRetVal">[out] A pointer that is set to the returned <see cref="ISymUnmanagedScope"/> interface.</param>
        /// <returns>S_OK if the method succeeds; otherwise, E_FAIL or some other error code.</returns>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT GetRootScope([Out, MarshalAs(UnmanagedType.Interface)] out ISymUnmanagedScope pRetVal);

        /// <summary>
        /// Gets the most enclosing lexical scope within this method that encloses the given offset. This can be used to start local variable searches.
        /// </summary>
        /// <param name="offset">[in] A ULONG that contains the offset.</param>
        /// <param name="pRetVal">[out] A pointer that is set to the returned <see cref="ISymUnmanagedScope"/> interface.</param>
        /// <returns>S_OK if the method succeeds; otherwise, E_FAIL or some other error code.</returns>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT GetScopeFromOffset([In] int offset, [Out, MarshalAs(UnmanagedType.Interface)] out ISymUnmanagedScope pRetVal);

        /// <summary>
        /// Returns the offset within this method that corresponds to a given position within a document.
        /// </summary>
        /// <param name="document">[in] A pointer to the document for which the offset is requested.</param>
        /// <param name="line">[in] The document line for which the offset is requested.</param>
        /// <param name="column">[in] The document column for which the offset is requested.</param>
        /// <param name="pRetVal">[out] A pointer to a ULONG32 that receives the offsets.</param>
        /// <returns>S_OK if the method succeeds; otherwise, E_FAIL or some other error code.</returns>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT GetOffset(
            [MarshalAs(UnmanagedType.Interface), In] ISymUnmanagedDocument document,
            [In] int line,
            [In] int column,
            [Out] out int pRetVal);

        /// <summary>
        /// Given a position in a document, returns an array of start and end offset pairs that correspond to the ranges of Microsoft intermediate language (MSIL) that the position covers within this method.<para/>
        /// The array is an array of integers and has the format [start, end, start, end]. The number of range pairs is the length of the array divided by 2.
        /// </summary>
        /// <param name="document">[in] The document for which the offset is requested.</param>
        /// <param name="line">[in] The document line corresponding to the ranges.</param>
        /// <param name="column">[in] The document column corresponding to the ranges.</param>
        /// <param name="cRanges">[in] The size of the ranges array.</param>
        /// <param name="pcRanges">[out] A pointer to a ULONG32 that receives the size of the buffer required to contain the ranges.</param>
        /// <param name="ranges">[out] A pointer to the buffer that receives the ranges.</param>
        /// <returns>S_OK if the method succeeds; otherwise, E_FAIL or some other error code.</returns>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT GetRanges(
            [MarshalAs(UnmanagedType.Interface), In]
            ISymUnmanagedDocument document,
            [In] int line,
            [In] int column,
            [In] int cRanges,
            [Out] out int pcRanges,
            [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 3), Out] int[] ranges);

        /// <summary>
        /// Gets the parameters for this method. The parameters are returned in the order in which they are defined within the method's signature.
        /// </summary>
        /// <param name="cParams">[in] The size of the params array.</param>
        /// <param name="pcParams">[in] A pointer to a ULONG32 that receives the size of the buffer that is required to contain the parameters.</param>
        /// <param name="params">[out] A pointer to the buffer that receives the parameters.</param>
        /// <returns>S_OK if the method succeeds; otherwise, E_FAIL or some other error code.</returns>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT GetParameters([In] int cParams, [Out] out int pcParams, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0), Out] ISymUnmanagedVariable[] @params);

        /// <summary>
        /// Gets the namespace within which this method is defined.
        /// </summary>
        /// <param name="pRetVal">[out] A pointer that is set to the returned <see cref="ISymUnmanagedNamespace"/> interface.</param>
        /// <returns>S_OK if the method succeeds; otherwise, E_FAIL or some other error code.</returns>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT GetNamespace([Out, MarshalAs(UnmanagedType.Interface)] out ISymUnmanagedNamespace pRetVal);

        /// <summary>
        /// Gets the start and end document positions for the source of this method. The first array position is the start, and the second array position is the end.
        /// </summary>
        /// <param name="docs">[in] The starting and ending source documents.</param>
        /// <param name="lines">[in] The starting and ending lines in the corresponding source documents.</param>
        /// <param name="columns">[in] The starting and ending columns in the corresponding source documents.</param>
        /// <param name="pRetVal">[out] true if positions were defined; otherwise, false.</param>
        /// <returns>S_OK if the method succeeds; otherwise, E_FAIL or some other error code.</returns>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT GetSourceStartEnd(
            [MarshalAs(UnmanagedType.LPArray, SizeConst = 2), In] ISymUnmanagedDocument[] docs,
            [MarshalAs(UnmanagedType.LPArray, SizeConst = 2), In] int[] lines,
            [MarshalAs(UnmanagedType.LPArray, SizeConst = 2), In] int[] columns,
            [Out] out int pRetVal);

        /// <summary>
        /// Gets all the sequence points within this method.
        /// </summary>
        /// <param name="cPoints">[in] A ULONG32 that receives the size of the offsets, documents, lines, columns, endLines, and endColumns arrays.</param>
        /// <param name="pcPoints">[out] A pointer to a ULONG32 that receives the length of the buffer required to contain the sequence points.</param>
        /// <param name="offsets">[in] An array in which to store the Microsoft intermediate language (MSIL) offsets from the beginning of the method for the sequence points.</param>
        /// <param name="documents">[in] An array in which to store the documents in which the sequence points are located.</param>
        /// <param name="lines">[in] An array in which to store the lines in the documents at which the sequence points are located.</param>
        /// <param name="columns">[in] An array in which to store the columns in the documents at which the sequence points are located.</param>
        /// <param name="endLines">[in] The array of lines in the documents at which the sequence points end.</param>
        /// <param name="endColumns">[in] The array of columns in the documents at which the sequence points end.</param>
        /// <returns>S_OK if the method succeeds; otherwise, E_FAIL or some other error code.</returns>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT GetSequencePoints(
            [In] int cPoints,
            [Out] out int pcPoints,
            [Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] int[] offsets,
            [Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] ISymUnmanagedDocument[] documents,
            [Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] int[] lines,
            [Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] int[] columns,
            [Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] int[] endLines,
            [Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] int[] endColumns);
    }
}
