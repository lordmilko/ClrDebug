using System;
using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    /// <summary>
    /// Represents a method within the symbol store. This interface provides access to only the symbol-related attributes of a method, instead of the type-related attributes.
    /// </summary>
    public class SymUnmanagedMethod : ComObject<ISymUnmanagedMethod>
    {
        public SymUnmanagedMethod(ISymUnmanagedMethod raw) : base(raw)
        {
        }

        #region ISymUnmanagedMethod
        #region GetToken

        /// <summary>
        /// Returns the metadata token for this method.
        /// </summary>
        public mdMethodDef Token
        {
            get
            {
                HRESULT hr;
                mdMethodDef pToken;

                if ((hr = TryGetToken(out pToken)) != HRESULT.S_OK)
                    Marshal.ThrowExceptionForHR((int) hr);

                return pToken;
            }
        }

        /// <summary>
        /// Returns the metadata token for this method.
        /// </summary>
        /// <param name="pToken">[out] A pointer to a <see cref="mdMethodDef"/> that receives the size, in characters, of the buffer required to contain the metadata.</param>
        /// <returns>S_OK if the method succeeds; otherwise, E_FAIL or some other error code.</returns>
        public HRESULT TryGetToken(out mdMethodDef pToken)
        {
            /*HRESULT GetToken([Out] out mdMethodDef pToken);*/
            return Raw.GetToken(out pToken);
        }

        #endregion
        #region GetSequencePointCount

        /// <summary>
        /// Gets the count of sequence points within this method.
        /// </summary>
        public uint SequencePointCount
        {
            get
            {
                HRESULT hr;
                uint pRetVal;

                if ((hr = TryGetSequencePointCount(out pRetVal)) != HRESULT.S_OK)
                    Marshal.ThrowExceptionForHR((int) hr);

                return pRetVal;
            }
        }

        /// <summary>
        /// Gets the count of sequence points within this method.
        /// </summary>
        /// <param name="pRetVal">[out] A pointer to a ULONG32 that receives the size of the buffer required to contain the sequence points.</param>
        /// <returns>S_OK if the method succeeds; otherwise, E_FAIL or some other error code.</returns>
        public HRESULT TryGetSequencePointCount(out uint pRetVal)
        {
            /*HRESULT GetSequencePointCount([Out] out uint pRetVal);*/
            return Raw.GetSequencePointCount(out pRetVal);
        }

        #endregion
        #region GetRootScope

        /// <summary>
        /// Gets the root lexical scope within this method. This scope encloses the entire method.
        /// </summary>
        public ISymUnmanagedScope RootScope
        {
            get
            {
                HRESULT hr;
                ISymUnmanagedScope pRetVal = default(ISymUnmanagedScope);

                if ((hr = TryGetRootScope(ref pRetVal)) != HRESULT.S_OK)
                    Marshal.ThrowExceptionForHR((int) hr);

                return pRetVal;
            }
        }

        /// <summary>
        /// Gets the root lexical scope within this method. This scope encloses the entire method.
        /// </summary>
        /// <param name="pRetVal">[out] A pointer that is set to the returned <see cref="ISymUnmanagedScope"/> interface.</param>
        /// <returns>S_OK if the method succeeds; otherwise, E_FAIL or some other error code.</returns>
        public HRESULT TryGetRootScope(ref ISymUnmanagedScope pRetVal)
        {
            /*HRESULT GetRootScope([Out, MarshalAs(UnmanagedType.Interface)] ISymUnmanagedScope pRetVal);*/
            return Raw.GetRootScope(pRetVal);
        }

        #endregion
        #region GetNamespace

        /// <summary>
        /// Gets the namespace within which this method is defined.
        /// </summary>
        public SymUnmanagedNamespace Namespace
        {
            get
            {
                HRESULT hr;
                SymUnmanagedNamespace pRetValResult;

                if ((hr = TryGetNamespace(out pRetValResult)) != HRESULT.S_OK)
                    Marshal.ThrowExceptionForHR((int) hr);

                return pRetValResult;
            }
        }

        /// <summary>
        /// Gets the namespace within which this method is defined.
        /// </summary>
        /// <param name="pRetValResult">[out] A pointer that is set to the returned <see cref="ISymUnmanagedNamespace"/> interface.</param>
        /// <returns>S_OK if the method succeeds; otherwise, E_FAIL or some other error code.</returns>
        public HRESULT TryGetNamespace(out SymUnmanagedNamespace pRetValResult)
        {
            /*HRESULT GetNamespace([MarshalAs(UnmanagedType.Interface)] out ISymUnmanagedNamespace pRetVal);*/
            ISymUnmanagedNamespace pRetVal;
            HRESULT hr = Raw.GetNamespace(out pRetVal);

            if (hr == HRESULT.S_OK)
                pRetValResult = new SymUnmanagedNamespace(pRetVal);
            else
                pRetValResult = default(SymUnmanagedNamespace);

            return hr;
        }

        #endregion
        #region GetScopeFromOffset

        /// <summary>
        /// Gets the most enclosing lexical scope within this method that encloses the given offset. This can be used to start local variable searches.
        /// </summary>
        /// <param name="offset">[in] A ULONG that contains the offset.</param>
        /// <returns>[out] A pointer that is set to the returned <see cref="ISymUnmanagedScope"/> interface.</returns>
        public ISymUnmanagedScope GetScopeFromOffset(uint offset)
        {
            HRESULT hr;
            ISymUnmanagedScope pRetVal = default(ISymUnmanagedScope);

            if ((hr = TryGetScopeFromOffset(offset, ref pRetVal)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return pRetVal;
        }

        /// <summary>
        /// Gets the most enclosing lexical scope within this method that encloses the given offset. This can be used to start local variable searches.
        /// </summary>
        /// <param name="offset">[in] A ULONG that contains the offset.</param>
        /// <param name="pRetVal">[out] A pointer that is set to the returned <see cref="ISymUnmanagedScope"/> interface.</param>
        /// <returns>S_OK if the method succeeds; otherwise, E_FAIL or some other error code.</returns>
        public HRESULT TryGetScopeFromOffset(uint offset, ref ISymUnmanagedScope pRetVal)
        {
            /*HRESULT GetScopeFromOffset([In] uint offset, [Out, MarshalAs(UnmanagedType.Interface)] ISymUnmanagedScope pRetVal);*/
            return Raw.GetScopeFromOffset(offset, pRetVal);
        }

        #endregion
        #region GetOffset

        /// <summary>
        /// Returns the offset within this method that corresponds to a given position within a document.
        /// </summary>
        /// <param name="document">[in] A pointer to the document for which the offset is requested.</param>
        /// <param name="line">[in] The document line for which the offset is requested.</param>
        /// <param name="column">[in] The document column for which the offset is requested.</param>
        /// <returns>[out] A pointer to a ULONG32 that receives the offsets.</returns>
        public uint GetOffset(ISymUnmanagedDocument document, uint line, uint column)
        {
            HRESULT hr;
            uint pRetVal;

            if ((hr = TryGetOffset(document, line, column, out pRetVal)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return pRetVal;
        }

        /// <summary>
        /// Returns the offset within this method that corresponds to a given position within a document.
        /// </summary>
        /// <param name="document">[in] A pointer to the document for which the offset is requested.</param>
        /// <param name="line">[in] The document line for which the offset is requested.</param>
        /// <param name="column">[in] The document column for which the offset is requested.</param>
        /// <param name="pRetVal">[out] A pointer to a ULONG32 that receives the offsets.</param>
        /// <returns>S_OK if the method succeeds; otherwise, E_FAIL or some other error code.</returns>
        public HRESULT TryGetOffset(ISymUnmanagedDocument document, uint line, uint column, out uint pRetVal)
        {
            /*HRESULT GetOffset(
            [MarshalAs(UnmanagedType.Interface), In] ISymUnmanagedDocument document,
            [In] uint line,
            [In] uint column,
            [Out] out uint pRetVal);*/
            return Raw.GetOffset(document, line, column, out pRetVal);
        }

        #endregion
        #region GetRanges

        /// <summary>
        /// Given a position in a document, returns an array of start and end offset pairs that correspond to the ranges of Microsoft intermediate language (MSIL) that the position covers within this method.<para/>
        /// The array is an array of integers and has the format [start, end, start, end]. The number of range pairs is the length of the array divided by 2.
        /// </summary>
        /// <param name="document">[in] The document for which the offset is requested.</param>
        /// <param name="line">[in] The document line corresponding to the ranges.</param>
        /// <param name="column">[in] The document column corresponding to the ranges.</param>
        /// <param name="cRanges">[in] The size of the ranges array.</param>
        /// <returns>The values that were emitted from the COM method.</returns>
        public GetRangesResult GetRanges(ISymUnmanagedDocument document, uint line, uint column, uint cRanges)
        {
            HRESULT hr;
            GetRangesResult result;

            if ((hr = TryGetRanges(document, line, column, cRanges, out result)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return result;
        }

        /// <summary>
        /// Given a position in a document, returns an array of start and end offset pairs that correspond to the ranges of Microsoft intermediate language (MSIL) that the position covers within this method.<para/>
        /// The array is an array of integers and has the format [start, end, start, end]. The number of range pairs is the length of the array divided by 2.
        /// </summary>
        /// <param name="document">[in] The document for which the offset is requested.</param>
        /// <param name="line">[in] The document line corresponding to the ranges.</param>
        /// <param name="column">[in] The document column corresponding to the ranges.</param>
        /// <param name="cRanges">[in] The size of the ranges array.</param>
        /// <param name="result">The values that were emitted from the COM method.</param>
        /// <returns>S_OK if the method succeeds; otherwise, E_FAIL or some other error code.</returns>
        public HRESULT TryGetRanges(ISymUnmanagedDocument document, uint line, uint column, uint cRanges, out GetRangesResult result)
        {
            /*HRESULT GetRanges(
            [MarshalAs(UnmanagedType.Interface), In]
            ISymUnmanagedDocument document,
            [In] uint line,
            [In] uint column,
            [In] uint cRanges,
            out uint pcRanges,
            [MarshalAs(UnmanagedType.LPArray), Out] uint[] ranges);*/
            uint pcRanges;
            uint[] ranges = null;
            HRESULT hr = Raw.GetRanges(document, line, column, cRanges, out pcRanges, ranges);

            if (hr == HRESULT.S_OK)
                result = new GetRangesResult(pcRanges, ranges);
            else
                result = default(GetRangesResult);

            return hr;
        }

        #endregion
        #region GetParameters

        /// <summary>
        /// Gets the parameters for this method. The parameters are returned in the order in which they are defined within the method's signature.
        /// </summary>
        /// <param name="cParams">[in] The size of the params array.</param>
        /// <returns>The values that were emitted from the COM method.</returns>
        public GetParametersResult GetParameters(uint cParams)
        {
            HRESULT hr;
            GetParametersResult result;

            if ((hr = TryGetParameters(cParams, out result)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return result;
        }

        /// <summary>
        /// Gets the parameters for this method. The parameters are returned in the order in which they are defined within the method's signature.
        /// </summary>
        /// <param name="cParams">[in] The size of the params array.</param>
        /// <param name="result">The values that were emitted from the COM method.</param>
        /// <returns>S_OK if the method succeeds; otherwise, E_FAIL or some other error code.</returns>
        public HRESULT TryGetParameters(uint cParams, out GetParametersResult result)
        {
            /*HRESULT GetParameters([In] uint cParams, out uint pcParams, [MarshalAs(UnmanagedType.Interface), Out]
            IntPtr @params);*/
            uint pcParams;
            IntPtr @params = default(IntPtr);
            HRESULT hr = Raw.GetParameters(cParams, out pcParams, @params);

            if (hr == HRESULT.S_OK)
                result = new GetParametersResult(pcParams, @params);
            else
                result = default(GetParametersResult);

            return hr;
        }

        #endregion
        #region GetSourceStartEnd

        /// <summary>
        /// Gets the start and end document positions for the source of this method. The first array position is the start, and the second array position is the end.
        /// </summary>
        /// <param name="docs">[in] The starting and ending source documents.</param>
        /// <param name="lines">[in] The starting and ending lines in the corresponding source documents.</param>
        /// <param name="columns">[in] The starting and ending columns in the corresponding source documents.</param>
        /// <returns>[out] true if positions were defined; otherwise, false.</returns>
        public int GetSourceStartEnd(ISymUnmanagedDocument[] docs, uint[] lines, uint[] columns)
        {
            HRESULT hr;
            int pRetVal;

            if ((hr = TryGetSourceStartEnd(docs, lines, columns, out pRetVal)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return pRetVal;
        }

        /// <summary>
        /// Gets the start and end document positions for the source of this method. The first array position is the start, and the second array position is the end.
        /// </summary>
        /// <param name="docs">[in] The starting and ending source documents.</param>
        /// <param name="lines">[in] The starting and ending lines in the corresponding source documents.</param>
        /// <param name="columns">[in] The starting and ending columns in the corresponding source documents.</param>
        /// <param name="pRetVal">[out] true if positions were defined; otherwise, false.</param>
        /// <returns>S_OK if the method succeeds; otherwise, E_FAIL or some other error code.</returns>
        public HRESULT TryGetSourceStartEnd(ISymUnmanagedDocument[] docs, uint[] lines, uint[] columns, out int pRetVal)
        {
            /*HRESULT GetSourceStartEnd(
            [MarshalAs(UnmanagedType.LPArray, SizeConst = 2), In]
            ISymUnmanagedDocument[] docs,
            [MarshalAs(UnmanagedType.LPArray, SizeConst = 2), In]
            uint[] lines,
            [MarshalAs(UnmanagedType.LPArray, SizeConst = 2), In]
            uint[] columns,
            out int pRetVal);*/
            return Raw.GetSourceStartEnd(docs, lines, columns, out pRetVal);
        }

        #endregion
        #region GetSequencePoints

        /// <summary>
        /// Gets all the sequence points within this method.
        /// </summary>
        /// <param name="cPoints">[in] A ULONG32 that receives the size of the offsets, documents, lines, columns, endLines, and endColumns arrays.</param>
        /// <param name="offsets">[in] An array in which to store the Microsoft intermediate language (MSIL) offsets from the beginning of the method for the sequence points.</param>
        /// <param name="documents">[in] An array in which to store the documents in which the sequence points are located.</param>
        /// <param name="lines">[in] An array in which to store the lines in the documents at which the sequence points are located.</param>
        /// <param name="columns">[in] An array in which to store the columns in the documents at which the sequence points are located.</param>
        /// <param name="endLines">[in] The array of lines in the documents at which the sequence points end.</param>
        /// <param name="endColumns">[in] The array of columns in the documents at which the sequence points end.</param>
        public void GetSequencePoints(uint cPoints, uint offsets, ISymUnmanagedDocument documents, uint lines, uint columns, uint endLines, uint endColumns)
        {
            HRESULT hr;

            if ((hr = TryGetSequencePoints(cPoints, offsets, documents, lines, columns, endLines, endColumns)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        /// <summary>
        /// Gets all the sequence points within this method.
        /// </summary>
        /// <param name="cPoints">[in] A ULONG32 that receives the size of the offsets, documents, lines, columns, endLines, and endColumns arrays.</param>
        /// <param name="offsets">[in] An array in which to store the Microsoft intermediate language (MSIL) offsets from the beginning of the method for the sequence points.</param>
        /// <param name="documents">[in] An array in which to store the documents in which the sequence points are located.</param>
        /// <param name="lines">[in] An array in which to store the lines in the documents at which the sequence points are located.</param>
        /// <param name="columns">[in] An array in which to store the columns in the documents at which the sequence points are located.</param>
        /// <param name="endLines">[in] The array of lines in the documents at which the sequence points end.</param>
        /// <param name="endColumns">[in] The array of columns in the documents at which the sequence points end.</param>
        /// <returns>S_OK if the method succeeds; otherwise, E_FAIL or some other error code.</returns>
        public HRESULT TryGetSequencePoints(uint cPoints, uint offsets, ISymUnmanagedDocument documents, uint lines, uint columns, uint endLines, uint endColumns)
        {
            /*HRESULT GetSequencePoints(
            [In] uint cPoints,
            out uint pcPoints,
            [In] ref uint offsets,
            [MarshalAs(UnmanagedType.Interface), In]
            ref ISymUnmanagedDocument documents,
            [In] ref uint lines,
            [In] ref uint columns,
            [In] ref uint endLines,
            [In] ref uint endColumns);*/
            uint pcPoints;

            return Raw.GetSequencePoints(cPoints, out pcPoints, ref offsets, ref documents, ref lines, ref columns, ref endLines, ref endColumns);
        }

        #endregion
        #endregion
    }
}