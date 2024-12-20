namespace ClrDebug.DbgEng
{
    /// <summary>
    /// Provided By: DEBUG_SERVICE_EXECUTION_CONTEXT_TRANSLATION. Defines a means of translating from one context to another (e.g.: native to WoW, emulator to emulate, etc...).
    /// </summary>
    public class SvcContextTranslation : ComObject<ISvcContextTranslation>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SvcContextTranslation"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
        public SvcContextTranslation(ISvcContextTranslation raw) : base(raw)
        {
        }

        #region ISvcContextTranslation
        #region GetTranslatedContext

        /// <summary>
        /// Gets a translated context record for the given execution unit (thread or core).
        /// </summary>
        public SvcRegisterContext GetTranslatedContext(ISvcExecutionUnit execUnit, SvcContextFlags contextFlags)
        {
            SvcRegisterContext contextResult;
            TryGetTranslatedContext(execUnit, contextFlags, out contextResult).ThrowDbgEngNotOK();

            return contextResult;
        }

        /// <summary>
        /// Gets a translated context record for the given execution unit (thread or core).
        /// </summary>
        public HRESULT TryGetTranslatedContext(ISvcExecutionUnit execUnit, SvcContextFlags contextFlags, out SvcRegisterContext contextResult)
        {
            /*HRESULT GetTranslatedContext(
            [In, MarshalAs(UnmanagedType.Interface)] ISvcExecutionUnit execUnit,
            [In] SvcContextFlags contextFlags,
            [Out, MarshalAs(UnmanagedType.Interface)] out ISvcRegisterContext context);*/
            ISvcRegisterContext context;
            HRESULT hr = Raw.GetTranslatedContext(execUnit, contextFlags, out context);

            if (hr == HRESULT.S_OK)
                contextResult = context == null ? null : new SvcRegisterContext(context);
            else
                contextResult = default(SvcRegisterContext);

            return hr;
        }

        #endregion
        #region SetTranslatedContext

        /// <summary>
        /// Sets a translated context record to the given execution unit (thread or core).
        /// </summary>
        public void SetTranslatedContext(ISvcExecutionUnit execUnit, SvcContextFlags contextFlags, ISvcRegisterContext context)
        {
            TrySetTranslatedContext(execUnit, contextFlags, context).ThrowDbgEngNotOK();
        }

        /// <summary>
        /// Sets a translated context record to the given execution unit (thread or core).
        /// </summary>
        public HRESULT TrySetTranslatedContext(ISvcExecutionUnit execUnit, SvcContextFlags contextFlags, ISvcRegisterContext context)
        {
            /*HRESULT SetTranslatedContext(
            [In, MarshalAs(UnmanagedType.Interface)] ISvcExecutionUnit execUnit,
            [In] SvcContextFlags contextFlags,
            [In, MarshalAs(UnmanagedType.Interface)] ISvcRegisterContext context);*/
            return Raw.SetTranslatedContext(execUnit, contextFlags, context);
        }

        #endregion
        #endregion
    }
}
