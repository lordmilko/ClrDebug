namespace ClrDebug.DbgEng
{
    public class SvcPrimaryModules : ComObject<ISvcPrimaryModules>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SvcPrimaryModules"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
        public SvcPrimaryModules(ISvcPrimaryModules raw) : base(raw)
        {
        }

        #region ISvcPrimaryModules
        #region FindExecutableModule

        public SvcModule FindExecutableModule(ISvcProcess process)
        {
            SvcModule executableModuleResult;
            TryFindExecutableModule(process, out executableModuleResult).ThrowDbgEngNotOK();

            return executableModuleResult;
        }

        public HRESULT TryFindExecutableModule(ISvcProcess process, out SvcModule executableModuleResult)
        {
            /*HRESULT FindExecutableModule(
            [In, MarshalAs(UnmanagedType.Interface)] ISvcProcess process,
            [Out, MarshalAs(UnmanagedType.Interface)] out ISvcModule executableModule);*/
            ISvcModule executableModule;
            HRESULT hr = Raw.FindExecutableModule(process, out executableModule);

            if (hr == HRESULT.S_OK)
                executableModuleResult = SvcModule.New(executableModule);
            else
                executableModuleResult = default(SvcModule);

            return hr;
        }

        #endregion
        #endregion
    }
}
