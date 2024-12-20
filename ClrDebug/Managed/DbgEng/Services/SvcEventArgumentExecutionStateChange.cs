namespace ClrDebug.DbgEng
{
    public class SvcEventArgumentExecutionStateChange : ComObject<ISvcEventArgumentExecutionStateChange>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SvcEventArgumentExecutionStateChange"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
        public SvcEventArgumentExecutionStateChange(ISvcEventArgumentExecutionStateChange raw) : base(raw)
        {
        }

        #region ISvcEventArgumentExecutionStateChange
        #region ChangeKind

        /// <summary>
        /// Gets the kind of execution state change which has occurred.
        /// </summary>
        public SvcExecutionStateChangeKind ChangeKind
        {
            get
            {
                /*SvcExecutionStateChangeKind GetChangeKind();*/
                return Raw.GetChangeKind();
            }
        }

        #endregion
        #region ChangeEffects

        /// <summary>
        /// Gets the process and/or execution unit which is affected by the state change. These may be null on output, indicating that the change affected every process/execution unit in the debug target.
        /// </summary>
        public GetChangeEffectsResult ChangeEffects
        {
            get
            {
                GetChangeEffectsResult result;
                TryGetChangeEffects(out result).ThrowDbgEngNotOK();

                return result;
            }
        }

        /// <summary>
        /// Gets the process and/or execution unit which is affected by the state change. These may be null on output, indicating that the change affected every process/execution unit in the debug target.
        /// </summary>
        public HRESULT TryGetChangeEffects(out GetChangeEffectsResult result)
        {
            /*HRESULT GetChangeEffects(
            [Out, MarshalAs(UnmanagedType.Interface)] out ISvcProcess process,
            [Out, MarshalAs(UnmanagedType.Interface)] out ISvcExecutionUnit executionUnit);*/
            ISvcProcess process;
            ISvcExecutionUnit executionUnit;
            HRESULT hr = Raw.GetChangeEffects(out process, out executionUnit);

            if (hr == HRESULT.S_OK)
                result = new GetChangeEffectsResult(process == null ? null : new SvcProcess(process), executionUnit == null ? null : new SvcExecutionUnit(executionUnit));
            else
                result = default(GetChangeEffectsResult);

            return hr;
        }

        #endregion
        #endregion
    }
}
