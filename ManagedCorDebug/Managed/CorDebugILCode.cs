using System;
using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    /// <summary>
    /// [Supported in the .NET Framework 4.5.2 and later versions] Represents a segment of intermediate language (IL) code.
    /// </summary>
    public class CorDebugILCode : ComObject<ICorDebugILCode>
    {
        public CorDebugILCode(ICorDebugILCode raw) : base(raw)
        {
        }

        #region ICorDebugILCode
        #region GetEHClauses

        /// <summary>
        /// [Supported in the .NET Framework 4.5.2 and later versions] Returns a pointer to a list of exception handling (EH) clauses that are defined for this intermediate language (IL).
        /// </summary>
        /// <param name="cClauses">[in] The storage capacity of the clauses array. See the Remarks section for more information.</param>
        /// <returns>The values that were emitted from the COM method.</returns>
        /// <remarks>
        /// If cClauses is 0 and pcClauses is non-null, pcClauses is set to the number of available exception handling clauses.
        /// If cClauses is non-zero, it represents the storage capacity of the clauses array. When the method returns, clauses
        /// contains a maximum of cClauses items, and pcClauses is set to the number of clauses actually written to the clauses
        /// array.
        /// </remarks>
        public GetEHClausesResult GetEHClauses(int cClauses)
        {
            HRESULT hr;
            GetEHClausesResult result;

            if ((hr = TryGetEHClauses(cClauses, out result)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return result;
        }

        /// <summary>
        /// [Supported in the .NET Framework 4.5.2 and later versions] Returns a pointer to a list of exception handling (EH) clauses that are defined for this intermediate language (IL).
        /// </summary>
        /// <param name="cClauses">[in] The storage capacity of the clauses array. See the Remarks section for more information.</param>
        /// <param name="result">The values that were emitted from the COM method.</param>
        /// <remarks>
        /// If cClauses is 0 and pcClauses is non-null, pcClauses is set to the number of available exception handling clauses.
        /// If cClauses is non-zero, it represents the storage capacity of the clauses array. When the method returns, clauses
        /// contains a maximum of cClauses items, and pcClauses is set to the number of clauses actually written to the clauses
        /// array.
        /// </remarks>
        public HRESULT TryGetEHClauses(int cClauses, out GetEHClausesResult result)
        {
            /*HRESULT GetEHClauses([In] int cClauses, out int pcClauses, [MarshalAs(UnmanagedType.LPArray), Out]
            CorDebugEHClause[] clauses);*/
            int pcClauses;
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

        /// <summary>
        /// [Supported in the .NET Framework 4.5.2 and later versions] Gets the metadata token for the local variable signature for the function that is represented by this instance.
        /// </summary>
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

        /// <summary>
        /// [Supported in the .NET Framework 4.5.2 and later versions] Gets the metadata token for the local variable signature for the function that is represented by this instance.
        /// </summary>
        /// <param name="pmdSig">[out] A pointer to the <see cref="mdSignature"/> token for the local variable signature for this function, or mdSignatureNil if there is no signature (that is, if the function doesn't have any local variables).</param>
        public HRESULT TryGetLocalVarSigToken(out mdSignature pmdSig)
        {
            /*HRESULT GetLocalVarSigToken(out mdSignature pmdSig);*/
            return Raw2.GetLocalVarSigToken(out pmdSig);
        }

        #endregion
        #region GetInstrumentedILMap

        /// <summary>
        /// [Supported in the .NET Framework 4.5.2 and later versions] Returns a map from profiler-instrumented intermediate language (IL) offsets to original method IL offsets for this instance.
        /// </summary>
        /// <param name="cMap">[in] The storage capacity of the map array. See the Remarks section for more information.</param>
        /// <returns>The values that were emitted from the COM method.</returns>
        /// <remarks>
        /// If the profiler sets the mapping by calling the ICorProfilerInfo.SetILInstrumentedCodeMap method, the debugger
        /// can call this method to retrieve the mapping and to use the mapping internally when calculating IL offsets for
        /// stack traces and variable lifetimes. If cMap is 0 and pcMap is non-null, pcMap is set to the number of available
        /// <see cref="COR_IL_MAP"/> values. If cMap is non-zero, it represents the storage capacity of the map array. When the method returns,
        /// map contains a maximum of cMap items, and pcMap is set to the number of <see cref="COR_IL_MAP"/> values actually written to the
        /// map array. If the IL hasn't been instrumented or the mapping wasn't provided by a profiler, this method returns
        /// S_OK and sets pcMap to 0.
        /// </remarks>
        public GetInstrumentedILMapResult GetInstrumentedILMap(int cMap)
        {
            HRESULT hr;
            GetInstrumentedILMapResult result;

            if ((hr = TryGetInstrumentedILMap(cMap, out result)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return result;
        }

        /// <summary>
        /// [Supported in the .NET Framework 4.5.2 and later versions] Returns a map from profiler-instrumented intermediate language (IL) offsets to original method IL offsets for this instance.
        /// </summary>
        /// <param name="cMap">[in] The storage capacity of the map array. See the Remarks section for more information.</param>
        /// <param name="result">The values that were emitted from the COM method.</param>
        /// <remarks>
        /// If the profiler sets the mapping by calling the ICorProfilerInfo.SetILInstrumentedCodeMap method, the debugger
        /// can call this method to retrieve the mapping and to use the mapping internally when calculating IL offsets for
        /// stack traces and variable lifetimes. If cMap is 0 and pcMap is non-null, pcMap is set to the number of available
        /// <see cref="COR_IL_MAP"/> values. If cMap is non-zero, it represents the storage capacity of the map array. When the method returns,
        /// map contains a maximum of cMap items, and pcMap is set to the number of <see cref="COR_IL_MAP"/> values actually written to the
        /// map array. If the IL hasn't been instrumented or the mapping wasn't provided by a profiler, this method returns
        /// S_OK and sets pcMap to 0.
        /// </remarks>
        public HRESULT TryGetInstrumentedILMap(int cMap, out GetInstrumentedILMapResult result)
        {
            /*HRESULT GetInstrumentedILMap([In] int cMap, out int pcMap, [MarshalAs(UnmanagedType.LPArray), Out] COR_IL_MAP[] map);*/
            int pcMap;
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