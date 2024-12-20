namespace ClrDebug.DbgEng
{
    public class SvcEventArgumentsSourceMappingsChanged : ComObject<ISvcEventArgumentsSourceMappingsChanged>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SvcEventArgumentsSourceMappingsChanged"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
        public SvcEventArgumentsSourceMappingsChanged(ISvcEventArgumentsSourceMappingsChanged raw) : base(raw)
        {
        }

        #region ISvcEventArgumentsSourceMappingsChanged
        #region Module

        /// <summary>
        /// Gets the module for which source mappings are changing.
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
        /// Gets the module for which source mappings are changing.
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
