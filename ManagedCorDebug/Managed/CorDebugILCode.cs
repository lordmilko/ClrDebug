using System;
using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    public class CorDebugILCode : ComObject<ICorDebugILCode>
    {
        public CorDebugILCode(ICorDebugILCode raw) : base(raw)
        {
        }

        #region ICorDebugILCode
        #region GetEHClauses

        public GetEHClausesResult GetEHClauses(uint cClauses)
        {
            HRESULT hr;
            GetEHClausesResult result;

            if ((hr = TryGetEHClauses(cClauses, out result)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return result;
        }

        public HRESULT TryGetEHClauses(uint cClauses, out GetEHClausesResult result)
        {
            /*HRESULT GetEHClauses([In] uint cClauses, out uint pcClauses, [MarshalAs(UnmanagedType.LPArray), Out]
            CorDebugEHClause[] clauses);*/
            uint pcClauses;
            CorDebugEHClause[] clauses = null;
            HRESULT hr = Raw.GetEHClauses(cClauses, out pcClauses, clauses);

            if (hr == HRESULT.S_OK)
                result = new GetEHClausesResult(pcClauses, clauses);
            else
                result = default(GetEHClausesResult);

            return hr;
        }

        #endregion
        #endregion
        #region ICorDebugILCode2

        public ICorDebugILCode2 Raw2 => (ICorDebugILCode2) Raw;

        #region GetLocalVarSigToken

        public mdSignature LocalVarSigToken
        {
            get
            {
                HRESULT hr;
                mdSignature pmdSig;

                if ((hr = TryGetLocalVarSigToken(out pmdSig)) != HRESULT.S_OK)
                    Marshal.ThrowExceptionForHR((int) hr);

                return pmdSig;
            }
        }

        public HRESULT TryGetLocalVarSigToken(out mdSignature pmdSig)
        {
            /*HRESULT GetLocalVarSigToken(out mdSignature pmdSig);*/
            return Raw2.GetLocalVarSigToken(out pmdSig);
        }

        #endregion
        #region GetInstrumentedILMap

        public GetInstrumentedILMapResult GetInstrumentedILMap(uint cMap)
        {
            HRESULT hr;
            GetInstrumentedILMapResult result;

            if ((hr = TryGetInstrumentedILMap(cMap, out result)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return result;
        }

        public HRESULT TryGetInstrumentedILMap(uint cMap, out GetInstrumentedILMapResult result)
        {
            /*HRESULT GetInstrumentedILMap([In] uint cMap, out uint pcMap, [MarshalAs(UnmanagedType.LPArray), Out] COR_IL_MAP[] map);*/
            uint pcMap;
            COR_IL_MAP[] map = null;
            HRESULT hr = Raw2.GetInstrumentedILMap(cMap, out pcMap, map);

            if (hr == HRESULT.S_OK)
                result = new GetInstrumentedILMapResult(pcMap, map);
            else
                result = default(GetInstrumentedILMapResult);

            return hr;
        }

        #endregion
        #endregion
    }
}