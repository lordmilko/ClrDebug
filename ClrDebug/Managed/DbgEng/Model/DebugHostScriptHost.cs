namespace ClrDebug.DbgEng
{
    /// <summary>
    /// An interface which the underlying debugger host must implement in order to manage data model scripts. The interface which indicates the capability of the debug host to take part in the scripting environment.<para/>
    /// This interface allows for the creation of contexts which inform scripting engines of where to place objects.
    /// </summary>
    public class DebugHostScriptHost : ComObject<IDebugHostScriptHost>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DebugHostScriptHost"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
        public DebugHostScriptHost(IDebugHostScriptHost raw) : base(raw)
        {
        }

        #region IDebugHostScriptHost
        #region CreateContext

        /// <summary>
        /// The CreateContext method is called by a script provider to create a new context in which to place the contents of the script.<para/>
        /// Such context is represented by the <see cref="IDataModelScriptHostContext"/>.
        /// </summary>
        /// <param name="script">The script for which to create a new context.</param>
        /// <returns>The newly created script host context is returned here.</returns>
        public DataModelScriptHostContext CreateContext(IDataModelScript script)
        {
            DataModelScriptHostContext scriptContextResult;
            TryCreateContext(script, out scriptContextResult).ThrowDbgEngNotOK();

            return scriptContextResult;
        }

        /// <summary>
        /// The CreateContext method is called by a script provider to create a new context in which to place the contents of the script.<para/>
        /// Such context is represented by the <see cref="IDataModelScriptHostContext"/>.
        /// </summary>
        /// <param name="script">The script for which to create a new context.</param>
        /// <param name="scriptContextResult">The newly created script host context is returned here.</param>
        /// <returns>This method returns HRESULT which indicates success or failure.</returns>
        public HRESULT TryCreateContext(IDataModelScript script, out DataModelScriptHostContext scriptContextResult)
        {
            /*HRESULT CreateContext(
            [In, MarshalAs(UnmanagedType.Interface)] IDataModelScript script,
            [Out, MarshalAs(UnmanagedType.Interface)] out IDataModelScriptHostContext scriptContext);*/
            IDataModelScriptHostContext scriptContext;
            HRESULT hr = Raw.CreateContext(script, out scriptContext);

            if (hr == HRESULT.S_OK)
                scriptContextResult = scriptContext == null ? null : new DataModelScriptHostContext(scriptContext);
            else
                scriptContextResult = default(DataModelScriptHostContext);

            return hr;
        }

        #endregion
        #endregion
    }
}
