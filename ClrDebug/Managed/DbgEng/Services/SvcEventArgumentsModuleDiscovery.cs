namespace ClrDebug.DbgEng
{
    public class SvcEventArgumentsModuleDiscovery : ComObject<ISvcEventArgumentsModuleDiscovery>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SvcEventArgumentsModuleDiscovery"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
        public SvcEventArgumentsModuleDiscovery(ISvcEventArgumentsModuleDiscovery raw) : base(raw)
        {
        }

        #region ISvcEventArgumentsModuleDiscovery
        #region Module

        /// <summary>
        /// Gets the module which is (dis)appearing. For a module arrival event, the returned module must already be in the enumerator as of the firing of this event and must be fully valid.<para/>
        /// For a module disappearance event, the interfaces on the returned module *MUST* continue to operate as if the module were loaded until the event notification has completed.<para/>
        /// This means fetching the name, base address, size, etc... must function during the event notification. After the event notification is complete, the module may be considered detached/orphaned for anyone continuing to hold the ISvcModule interface.
        /// </summary>
        public SvcModule Module
        {
            get
            {
                SvcModule moduleResult;
                TryGetModule(out moduleResult).ThrowDbgEngNotOK();

                return moduleResult;
            }
        }

        /// <summary>
        /// Gets the module which is (dis)appearing. For a module arrival event, the returned module must already be in the enumerator as of the firing of this event and must be fully valid.<para/>
        /// For a module disappearance event, the interfaces on the returned module *MUST* continue to operate as if the module were loaded until the event notification has completed.<para/>
        /// This means fetching the name, base address, size, etc... must function during the event notification. After the event notification is complete, the module may be considered detached/orphaned for anyone continuing to hold the ISvcModule interface.
        /// </summary>
        public HRESULT TryGetModule(out SvcModule moduleResult)
        {
            /*HRESULT GetModule(
            [Out, MarshalAs(UnmanagedType.Interface)] out ISvcModule module);*/
            ISvcModule module;
            HRESULT hr = Raw.GetModule(out module);

            if (hr == HRESULT.S_OK)
                moduleResult = SvcModule.New(module);
            else
                moduleResult = default(SvcModule);

            return hr;
        }

        #endregion
        #endregion
    }
}
