namespace ClrDebug.DbgEng
{
    /// <summary>
    /// When DebugExtensionInitialize is called, it creates a debug client and gets access to the data model. Such access is provided by a bridge interface between the legacy IDebug* interfaces of Debugging Tools for Windows and the data model.<para/>
    /// This bridge interface is IHostDataModelAccess.
    /// </summary>
    public class HostDataModelAccess : ComObject<IHostDataModelAccess>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="HostDataModelAccess"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
        public HostDataModelAccess(IHostDataModelAccess raw) : base(raw)
        {
        }

        #region IHostDataModelAccess
        #region DataModel

        /// <summary>
        /// The GetDataModel method is the method on the bridge interface which provides access to both sides of the data model: • The debug host (the lower edge of the debugger) is expressed by the returned <see cref="IDebugHost"/> interface • The data model's main component -- the data model manager is expressed by the returned <see cref="IDataModelManager"/> interface
        /// </summary>
        public GetDataModelResult DataModel
        {
            get
            {
                GetDataModelResult result;
                TryGetDataModel(out result).ThrowDbgEngNotOK();

                return result;
            }
        }

        /// <summary>
        /// The GetDataModel method is the method on the bridge interface which provides access to both sides of the data model: • The debug host (the lower edge of the debugger) is expressed by the returned <see cref="IDebugHost"/> interface • The data model's main component -- the data model manager is expressed by the returned <see cref="IDataModelManager"/> interface
        /// </summary>
        /// <param name="result">The values that were emitted from the COM method.</param>
        /// <returns>This method returns HRESULT that indicates success or failure.</returns>
        public HRESULT TryGetDataModel(out GetDataModelResult result)
        {
            /*HRESULT GetDataModel(
            [Out, MarshalAs(UnmanagedType.Interface)] out IDataModelManager manager,
            [Out, MarshalAs(UnmanagedType.Interface)] out IDebugHost host);*/
            IDataModelManager manager;
            IDebugHost host;
            HRESULT hr = Raw.GetDataModel(out manager, out host);

            if (hr == HRESULT.S_OK)
                result = new GetDataModelResult(manager == null ? null : new DataModelManager(manager), host == null ? null : new DebugHost(host));
            else
                result = default(GetDataModelResult);

            return hr;
        }

        #endregion
        #endregion
    }
}
