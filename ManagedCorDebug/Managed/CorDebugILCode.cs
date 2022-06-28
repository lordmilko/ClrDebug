using System.Diagnostics;

namespace ManagedCorDebug
{
    /// <summary>
    /// [Supported in the .NET Framework 4.5.2 and later versions] Represents a segment of intermediate language (IL) code.
    /// </summary>
    public class CorDebugILCode : ComObject<ICorDebugILCode>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CorDebugILCode"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
        public CorDebugILCode(ICorDebugILCode raw) : base(raw)
        {
        }

        #region ICorDebugILCode
        #region EHClauses

        /// <summary>
        /// [Supported in the .NET Framework 4.5.2 and later versions] Returns a pointer to a list of exception handling (EH) clauses that are defined for this intermediate language (IL).
        /// </summary>
        public CorDebugEHClause[] EHClauses
        {
            get
            {
                CorDebugEHClause[] clauses;
                TryGetEHClauses(out clauses).ThrowOnNotOK();

                return clauses;
            }
        }

        /// <summary>
        /// [Supported in the .NET Framework 4.5.2 and later versions] Returns a pointer to a list of exception handling (EH) clauses that are defined for this intermediate language (IL).
        /// </summary>
        /// <param name="clauses">[out] An array of <see cref="CorDebugEHClause"/> objects that contain information on exception handling clauses defined for this IL.</param>
        /// <remarks>
        /// If cClauses is 0 and pcClauses is non-null, pcClauses is set to the number of available exception handling clauses.
        /// If cClauses is non-zero, it represents the storage capacity of the clauses array. When the method returns, clauses
        /// contains a maximum of cClauses items, and pcClauses is set to the number of clauses actually written to the clauses
        /// array.
        /// </remarks>
        public HRESULT TryGetEHClauses(out CorDebugEHClause[] clauses)
        {
            /*HRESULT GetEHClauses([In] int cClauses, [Out] out int pcClauses, [MarshalAs(UnmanagedType.LPArray), Out]
            CorDebugEHClause[] clauses);*/
            int cClauses = 0;
            int pcClauses;
            clauses = null;
            HRESULT hr = Raw.GetEHClauses(cClauses, out pcClauses, clauses);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER && hr != HRESULT.S_OK)
                goto fail;

            cClauses = pcClauses;
            clauses = new CorDebugEHClause[pcClauses];
            hr = Raw.GetEHClauses(cClauses, out pcClauses, clauses);
            fail:
            return hr;
        }

        #endregion
        #endregion
        #region ICorDebugILCode2

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public ICorDebugILCode2 Raw2 => (ICorDebugILCode2) Raw;

        #region LocalVarSigToken

        /// <summary>
        /// [Supported in the .NET Framework 4.5.2 and later versions] Gets the metadata token for the local variable signature for the function that is represented by this instance.
        /// </summary>
        public mdSignature LocalVarSigToken
        {
            get
            {
                mdSignature pmdSig;
                TryGetLocalVarSigToken(out pmdSig).ThrowOnNotOK();

                return pmdSig;
            }
        }

        /// <summary>
        /// [Supported in the .NET Framework 4.5.2 and later versions] Gets the metadata token for the local variable signature for the function that is represented by this instance.
        /// </summary>
        /// <param name="pmdSig">[out] A pointer to the <see cref="mdSignature"/> token for the local variable signature for this function, or mdSignatureNil if there is no signature (that is, if the function doesn't have any local variables).</param>
        public HRESULT TryGetLocalVarSigToken(out mdSignature pmdSig)
        {
            /*HRESULT GetLocalVarSigToken([Out] out mdSignature pmdSig);*/
            return Raw2.GetLocalVarSigToken(out pmdSig);
        }

        #endregion
        #region InstrumentedILMap

        /// <summary>
        /// [Supported in the .NET Framework 4.5.2 and later versions] Returns a map from profiler-instrumented intermediate language (IL) offsets to original method IL offsets for this instance.
        /// </summary>
        public COR_IL_MAP[] InstrumentedILMap
        {
            get
            {
                COR_IL_MAP[] map;
                TryGetInstrumentedILMap(out map).ThrowOnNotOK();

                return map;
            }
        }

        /// <summary>
        /// [Supported in the .NET Framework 4.5.2 and later versions] Returns a map from profiler-instrumented intermediate language (IL) offsets to original method IL offsets for this instance.
        /// </summary>
        /// <param name="map">[out] An array of <see cref="COR_IL_MAP"/> values that provide information on mappings from profiler-instrumented IL to the IL of the original method.</param>
        /// <remarks>
        /// If the profiler sets the mapping by calling the ICorProfilerInfo.SetILInstrumentedCodeMap method, the debugger
        /// can call this method to retrieve the mapping and to use the mapping internally when calculating IL offsets for
        /// stack traces and variable lifetimes. If cMap is 0 and pcMap is non-null, pcMap is set to the number of available
        /// <see cref="COR_IL_MAP"/> values. If cMap is non-zero, it represents the storage capacity of the map array. When the method returns,
        /// map contains a maximum of cMap items, and pcMap is set to the number of <see cref="COR_IL_MAP"/> values actually written to the
        /// map array. If the IL hasn't been instrumented or the mapping wasn't provided by a profiler, this method returns
        /// S_OK and sets pcMap to 0.
        /// </remarks>
        public HRESULT TryGetInstrumentedILMap(out COR_IL_MAP[] map)
        {
            /*HRESULT GetInstrumentedILMap([In] int cMap, [Out] out int pcMap, [MarshalAs(UnmanagedType.LPArray), Out] COR_IL_MAP[] map);*/
            int cMap = 0;
            int pcMap;
            map = null;
            HRESULT hr = Raw2.GetInstrumentedILMap(cMap, out pcMap, map);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER && hr != HRESULT.S_OK)
                goto fail;

            cMap = pcMap;
            map = new COR_IL_MAP[pcMap];
            hr = Raw2.GetInstrumentedILMap(cMap, out pcMap, map);
            fail:
            return hr;
        }

        #endregion
        #endregion
    }
}