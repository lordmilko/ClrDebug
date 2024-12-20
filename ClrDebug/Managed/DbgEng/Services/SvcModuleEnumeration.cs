namespace ClrDebug.DbgEng
{
    public class SvcModuleEnumeration : ComObject<ISvcModuleEnumeration>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SvcModuleEnumeration"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
        public SvcModuleEnumeration(ISvcModuleEnumeration raw) : base(raw)
        {
        }

        #region ISvcModuleEnumeration
        #region FindModule

        /// <summary>
        /// Finds a module by a unique key. The interpretation and semantic meaning of the key is specific to the service which provides this.<para/>
        /// This may be the base address of the module.
        /// </summary>
        public SvcModule FindModule(ISvcProcess process, long moduleKey)
        {
            SvcModule targetModuleResult;
            TryFindModule(process, moduleKey, out targetModuleResult).ThrowDbgEngNotOK();

            return targetModuleResult;
        }

        /// <summary>
        /// Finds a module by a unique key. The interpretation and semantic meaning of the key is specific to the service which provides this.<para/>
        /// This may be the base address of the module.
        /// </summary>
        public HRESULT TryFindModule(ISvcProcess process, long moduleKey, out SvcModule targetModuleResult)
        {
            /*HRESULT FindModule(
            [In, MarshalAs(UnmanagedType.Interface)] ISvcProcess process,
            [In] long moduleKey,
            [Out, MarshalAs(UnmanagedType.Interface)] out ISvcModule targetModule);*/
            ISvcModule targetModule;
            HRESULT hr = Raw.FindModule(process, moduleKey, out targetModule);

            if (hr == HRESULT.S_OK)
                targetModuleResult = SvcModule.New(targetModule);
            else
                targetModuleResult = default(SvcModule);

            return hr;
        }

        #endregion
        #region FindModuleAtAddress

        /// <summary>
        /// Finds a module by an address.
        /// </summary>
        public SvcModule FindModuleAtAddress(ISvcProcess process, long moduleAddress)
        {
            SvcModule targetModuleResult;
            TryFindModuleAtAddress(process, moduleAddress, out targetModuleResult).ThrowDbgEngNotOK();

            return targetModuleResult;
        }

        /// <summary>
        /// Finds a module by an address.
        /// </summary>
        public HRESULT TryFindModuleAtAddress(ISvcProcess process, long moduleAddress, out SvcModule targetModuleResult)
        {
            /*HRESULT FindModuleAtAddress(
            [In, MarshalAs(UnmanagedType.Interface)] ISvcProcess process,
            [In] long moduleAddress,
            [Out, MarshalAs(UnmanagedType.Interface)] out ISvcModule targetModule);*/
            ISvcModule targetModule;
            HRESULT hr = Raw.FindModuleAtAddress(process, moduleAddress, out targetModule);

            if (hr == HRESULT.S_OK)
                targetModuleResult = SvcModule.New(targetModule);
            else
                targetModuleResult = default(SvcModule);

            return hr;
        }

        #endregion
        #region EnumerateModules

        /// <summary>
        /// Returns an enumerator object which is capable of enumerating all modules in the given process and creating an ISvcModule for them.
        /// </summary>
        public SvcModuleEnumerator EnumerateModules(ISvcProcess process)
        {
            SvcModuleEnumerator targetModuleEnumeratorResult;
            TryEnumerateModules(process, out targetModuleEnumeratorResult).ThrowDbgEngNotOK();

            return targetModuleEnumeratorResult;
        }

        /// <summary>
        /// Returns an enumerator object which is capable of enumerating all modules in the given process and creating an ISvcModule for them.
        /// </summary>
        public HRESULT TryEnumerateModules(ISvcProcess process, out SvcModuleEnumerator targetModuleEnumeratorResult)
        {
            /*HRESULT EnumerateModules(
            [In, MarshalAs(UnmanagedType.Interface)] ISvcProcess process,
            [Out, MarshalAs(UnmanagedType.Interface)] out ISvcModuleEnumerator targetModuleEnumerator);*/
            ISvcModuleEnumerator targetModuleEnumerator;
            HRESULT hr = Raw.EnumerateModules(process, out targetModuleEnumerator);

            if (hr == HRESULT.S_OK)
                targetModuleEnumeratorResult = targetModuleEnumerator == null ? null : new SvcModuleEnumerator(targetModuleEnumerator);
            else
                targetModuleEnumeratorResult = default(SvcModuleEnumerator);

            return hr;
        }

        #endregion
        #endregion
    }
}
