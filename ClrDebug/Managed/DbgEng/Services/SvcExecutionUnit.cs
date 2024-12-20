namespace ClrDebug.DbgEng
{
    /// <summary>
    /// The ISvcExecutionUnit interface is provided by a debug primitive which is capable of execution of code. This may be a thread.<para/>
    /// It may be a processor core.
    /// </summary>
    public class SvcExecutionUnit : ComObject<ISvcExecutionUnit>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SvcExecutionUnit"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
        public SvcExecutionUnit(ISvcExecutionUnit raw) : base(raw)
        {
        }

        #region ISvcExecutionUnit
        #region GetContext

        /// <summary>
        /// Gets the register context of the execution unit. Which categories of registers are retrieved is dependent upon the flags passed in.<para/>
        /// If the method returns S_OK, all registers of the given categories were retrieved. If the method returns S_FALSE, some registers of the given categories were retrieved.<para/>
        /// S_FALSE may indicate that an entire category was not retrieved (e.g.: a dump or core contains no record of SSE/AVX registers) or it may indicate that some registers of a category were retrieved and some were not.
        /// </summary>
        public SvcRegisterContext GetContext(SvcContextFlags contextFlags)
        {
            SvcRegisterContext ppRegisterContextResult;
            TryGetContext(contextFlags, out ppRegisterContextResult).ThrowDbgEngNotOK();

            return ppRegisterContextResult;
        }

        /// <summary>
        /// Gets the register context of the execution unit. Which categories of registers are retrieved is dependent upon the flags passed in.<para/>
        /// If the method returns S_OK, all registers of the given categories were retrieved. If the method returns S_FALSE, some registers of the given categories were retrieved.<para/>
        /// S_FALSE may indicate that an entire category was not retrieved (e.g.: a dump or core contains no record of SSE/AVX registers) or it may indicate that some registers of a category were retrieved and some were not.
        /// </summary>
        public HRESULT TryGetContext(SvcContextFlags contextFlags, out SvcRegisterContext ppRegisterContextResult)
        {
            /*HRESULT GetContext(
            [In] SvcContextFlags contextFlags,
            [Out, MarshalAs(UnmanagedType.Interface)] out ISvcRegisterContext ppRegisterContext);*/
            ISvcRegisterContext ppRegisterContext;
            HRESULT hr = Raw.GetContext(contextFlags, out ppRegisterContext);

            if (hr == HRESULT.S_OK)
                ppRegisterContextResult = ppRegisterContext == null ? null : new SvcRegisterContext(ppRegisterContext);
            else
                ppRegisterContextResult = default(SvcRegisterContext);

            return hr;
        }

        #endregion
        #region SetContext

        /// <summary>
        /// Sets the register context of the execution unit. Which categories of registers are written is dependent upon the flags passed in.<para/>
        /// The S_OK/S_FALSE definitions mirror GetContextEx. Note that registers which are not contained in the register context will not be written regardless of what SvcContextFlags indicates.
        /// </summary>
        public void SetContext(SvcContextFlags contextFlags, ISvcRegisterContext pRegisterContext)
        {
            TrySetContext(contextFlags, pRegisterContext).ThrowDbgEngNotOK();
        }

        /// <summary>
        /// Sets the register context of the execution unit. Which categories of registers are written is dependent upon the flags passed in.<para/>
        /// The S_OK/S_FALSE definitions mirror GetContextEx. Note that registers which are not contained in the register context will not be written regardless of what SvcContextFlags indicates.
        /// </summary>
        public HRESULT TrySetContext(SvcContextFlags contextFlags, ISvcRegisterContext pRegisterContext)
        {
            /*HRESULT SetContext(
            [In] SvcContextFlags contextFlags,
            [In, MarshalAs(UnmanagedType.Interface)] ISvcRegisterContext pRegisterContext);*/
            return Raw.SetContext(contextFlags, pRegisterContext);
        }

        #endregion
        #endregion
    }
}
