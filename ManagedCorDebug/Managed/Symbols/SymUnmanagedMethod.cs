using System;
using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    public class SymUnmanagedMethod : ComObject<ISymUnmanagedMethod>
    {
        public SymUnmanagedMethod(ISymUnmanagedMethod raw) : base(raw)
        {
        }

        #region ISymUnmanagedMethod
        #region GetToken

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

        public HRESULT TryGetToken(out mdMethodDef pToken)
        {
            /*HRESULT GetToken([Out] out mdMethodDef pToken);*/
            return Raw.GetToken(out pToken);
        }

        #endregion
        #region GetSequencePointCount

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

        public HRESULT TryGetSequencePointCount(out uint pRetVal)
        {
            /*HRESULT GetSequencePointCount([Out] out uint pRetVal);*/
            return Raw.GetSequencePointCount(out pRetVal);
        }

        #endregion
        #region GetRootScope

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

        public HRESULT TryGetRootScope(ref ISymUnmanagedScope pRetVal)
        {
            /*HRESULT GetRootScope([Out, MarshalAs(UnmanagedType.Interface)] ISymUnmanagedScope pRetVal);*/
            return Raw.GetRootScope(pRetVal);
        }

        #endregion
        #region GetNamespace

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

        public ISymUnmanagedScope GetScopeFromOffset(uint offset)
        {
            HRESULT hr;
            ISymUnmanagedScope pRetVal = default(ISymUnmanagedScope);

            if ((hr = TryGetScopeFromOffset(offset, ref pRetVal)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return pRetVal;
        }

        public HRESULT TryGetScopeFromOffset(uint offset, ref ISymUnmanagedScope pRetVal)
        {
            /*HRESULT GetScopeFromOffset([In] uint offset, [Out, MarshalAs(UnmanagedType.Interface)] ISymUnmanagedScope pRetVal);*/
            return Raw.GetScopeFromOffset(offset, pRetVal);
        }

        #endregion
        #region GetOffset

        public uint GetOffset(ISymUnmanagedDocument document, uint line, uint column)
        {
            HRESULT hr;
            uint pRetVal;

            if ((hr = TryGetOffset(document, line, column, out pRetVal)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return pRetVal;
        }

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

        public GetRangesResult GetRanges(ISymUnmanagedDocument document, uint line, uint column, uint cRanges)
        {
            HRESULT hr;
            GetRangesResult result;

            if ((hr = TryGetRanges(document, line, column, cRanges, out result)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return result;
        }

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

        public GetParametersResult GetParameters(uint cParams)
        {
            HRESULT hr;
            GetParametersResult result;

            if ((hr = TryGetParameters(cParams, out result)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return result;
        }

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

        public int GetSourceStartEnd(ISymUnmanagedDocument[] docs, uint[] lines, uint[] columns)
        {
            HRESULT hr;
            int pRetVal;

            if ((hr = TryGetSourceStartEnd(docs, lines, columns, out pRetVal)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return pRetVal;
        }

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

        public void GetSequencePoints(uint cPoints, uint offsets, ISymUnmanagedDocument documents, uint lines, uint columns, uint endLines, uint endColumns)
        {
            HRESULT hr;

            if ((hr = TryGetSequencePoints(cPoints, offsets, documents, lines, columns, endLines, endColumns)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

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