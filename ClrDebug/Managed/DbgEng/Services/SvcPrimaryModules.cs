namespace ClrDebug.DbgEng
{
    /// <summary>
    /// Provided By: [Optional] Module enumeration service. The ISvcPrimaryModules (and derivative) interface(s) may optionally be provided on the module enumeration service to indicate key modules of a process.<para/>
    /// Typically, this is used to determine the main executable image of a given process.
    /// </summary>
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

        /// <summary>
        /// Finds the main executable module for the given process. This is the executable image which started the given process.<para/>
        /// For a non-process context (e.g.: a kernel), this may be defined as the kernel image.
        /// </summary>
        public SvcModule FindExecutableModule(ISvcProcess process)
        {
            SvcModule executableModuleResult;
            TryFindExecutableModule(process, out executableModuleResult).ThrowDbgEngNotOK();

            return executableModuleResult;
        }

        /// <summary>
        /// Finds the main executable module for the given process. This is the executable image which started the given process.<para/>
        /// For a non-process context (e.g.: a kernel), this may be defined as the kernel image.
        /// </summary>
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
