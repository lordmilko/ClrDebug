using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;

namespace ManagedCorDebug
{
    public class SymUnmanagedENCUpdate : ComObject<ISymUnmanagedENCUpdate>
    {
        public SymUnmanagedENCUpdate(ISymUnmanagedENCUpdate raw) : base(raw)
        {
        }

        #region ISymUnmanagedENCUpdate
        #region UpdateSymbolStore2

        public void UpdateSymbolStore2(IStream pIStream, SYMLINEDELTA pDeltaLines, uint cDeltaLines)
        {
            HRESULT hr;

            if ((hr = TryUpdateSymbolStore2(pIStream, pDeltaLines, cDeltaLines)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        public HRESULT TryUpdateSymbolStore2(IStream pIStream, SYMLINEDELTA pDeltaLines, uint cDeltaLines)
        {
            /*HRESULT UpdateSymbolStore2([MarshalAs(UnmanagedType.Interface), In]
            IStream pIStream, [In] ref SYMLINEDELTA pDeltaLines, [In] uint cDeltaLines);*/
            return Raw.UpdateSymbolStore2(pIStream, ref pDeltaLines, cDeltaLines);
        }

        #endregion
        #region GetLocalVariableCount

        public uint GetLocalVariableCount(uint mdMethodToken)
        {
            HRESULT hr;
            uint pcLocals;

            if ((hr = TryGetLocalVariableCount(mdMethodToken, out pcLocals)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return pcLocals;
        }

        public HRESULT TryGetLocalVariableCount(uint mdMethodToken, out uint pcLocals)
        {
            /*HRESULT GetLocalVariableCount([In] uint mdMethodToken, out uint pcLocals);*/
            return Raw.GetLocalVariableCount(mdMethodToken, out pcLocals);
        }

        #endregion
        #region GetLocalVariables

        public GetLocalVariablesResult GetLocalVariables(uint mdMethodToken, uint cLocals)
        {
            HRESULT hr;
            GetLocalVariablesResult result;

            if ((hr = TryGetLocalVariables(mdMethodToken, cLocals, out result)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return result;
        }

        public HRESULT TryGetLocalVariables(uint mdMethodToken, uint cLocals, out GetLocalVariablesResult result)
        {
            /*HRESULT GetLocalVariables(
            [In] uint mdMethodToken,
            [In] uint cLocals,
            [Out] IntPtr rgLocals, //ISymUnmanagedVariable
            out uint pceltFetched);*/
            IntPtr rgLocals = default(IntPtr);
            uint pceltFetched;
            HRESULT hr = Raw.GetLocalVariables(mdMethodToken, cLocals, rgLocals, out pceltFetched);

            if (hr == HRESULT.S_OK)
                result = new GetLocalVariablesResult(rgLocals, pceltFetched);
            else
                result = default(GetLocalVariablesResult);

            return hr;
        }

        #endregion
        #region InitializeForEnc

        public void InitializeForEnc()
        {
            HRESULT hr;

            if ((hr = TryInitializeForEnc()) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        public HRESULT TryInitializeForEnc()
        {
            /*HRESULT InitializeForEnc();*/
            return Raw.InitializeForEnc();
        }

        #endregion
        #region UpdateMethodLines

        public void UpdateMethodLines(uint mdMethodToken, int pDeltas, uint cDeltas)
        {
            HRESULT hr;

            if ((hr = TryUpdateMethodLines(mdMethodToken, pDeltas, cDeltas)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        public HRESULT TryUpdateMethodLines(uint mdMethodToken, int pDeltas, uint cDeltas)
        {
            /*HRESULT UpdateMethodLines([In] uint mdMethodToken, [In] ref int pDeltas, [In] uint cDeltas);*/
            return Raw.UpdateMethodLines(mdMethodToken, ref pDeltas, cDeltas);
        }

        #endregion
        #endregion
    }
}