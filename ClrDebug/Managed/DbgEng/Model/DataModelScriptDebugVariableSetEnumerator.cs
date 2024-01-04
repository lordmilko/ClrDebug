namespace ClrDebug.DbgEng
{
    /// <summary>
    /// Enumerates a set of variables (arguments, parameters, locals, etc...)
    /// </summary>
    public class DataModelScriptDebugVariableSetEnumerator : ComObject<IDataModelScriptDebugVariableSetEnumerator>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DataModelScriptDebugVariableSetEnumerator"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
        public DataModelScriptDebugVariableSetEnumerator(IDataModelScriptDebugVariableSetEnumerator raw) : base(raw)
        {
        }

        #region IDataModelScriptDebugVariableSetEnumerator
        #region Next

        /// <summary>
        /// The GetNext method moves the enumerator to the next variable in the set and returns the variable's name, value, and any metadata associated with it.<para/>
        /// If the enumerator has hit the end of the set, the error E_BOUNDS is returned. Once the E_BOUNDS marker has been returned from the GetNext method, it will continue to produce E_BOUNDS when called again unless an intervening Reset call is made.
        /// </summary>
        public DataModelScriptDebugVariableSetEnumerator_GetNextResult Next
        {
            get
            {
                DataModelScriptDebugVariableSetEnumerator_GetNextResult result;
                TryGetNext(out result).ThrowDbgEngNotOK();

                return result;
            }
        }

        /// <summary>
        /// The GetNext method moves the enumerator to the next variable in the set and returns the variable's name, value, and any metadata associated with it.<para/>
        /// If the enumerator has hit the end of the set, the error E_BOUNDS is returned. Once the E_BOUNDS marker has been returned from the GetNext method, it will continue to produce E_BOUNDS when called again unless an intervening Reset call is made.
        /// </summary>
        /// <param name="result">The values that were emitted from the COM method.</param>
        /// <returns>This method returns HRESULT which indicates success or failure.</returns>
        public HRESULT TryGetNext(out DataModelScriptDebugVariableSetEnumerator_GetNextResult result)
        {
            /*HRESULT GetNext(
            [Out, MarshalAs(UnmanagedType.BStr)] out string variableName,
            [Out, MarshalAs(UnmanagedType.Interface)] out IModelObject variableValue,
            [Out, MarshalAs(UnmanagedType.Interface)] out IKeyStore variableMetadata);*/
            string variableName;
            IModelObject variableValue;
            IKeyStore variableMetadata;
            HRESULT hr = Raw.GetNext(out variableName, out variableValue, out variableMetadata);

            if (hr == HRESULT.S_OK)
                result = new DataModelScriptDebugVariableSetEnumerator_GetNextResult(variableName, variableValue == null ? null : new ModelObject(variableValue), variableMetadata == null ? null : new KeyStore(variableMetadata));
            else
                result = default(DataModelScriptDebugVariableSetEnumerator_GetNextResult);

            return hr;
        }

        #endregion
        #region Reset

        /// <summary>
        /// The Reset method resets the position of the enumerator to where it was immediately after creation -- that is, before the first element of the set.
        /// </summary>
        public void Reset()
        {
            TryReset().ThrowDbgEngNotOK();
        }

        /// <summary>
        /// The Reset method resets the position of the enumerator to where it was immediately after creation -- that is, before the first element of the set.
        /// </summary>
        /// <returns>This method returns HRESULT which indicates success or failure.</returns>
        public HRESULT TryReset()
        {
            /*HRESULT Reset();*/
            return Raw.Reset();
        }

        #endregion
        #endregion
    }
}
