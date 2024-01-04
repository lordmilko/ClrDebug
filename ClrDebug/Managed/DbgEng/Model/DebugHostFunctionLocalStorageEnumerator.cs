namespace ClrDebug.DbgEng
{
    public class DebugHostFunctionLocalStorageEnumerator : ComObject<IDebugHostFunctionLocalStorageEnumerator>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DebugHostFunctionLocalStorageEnumerator"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
        public DebugHostFunctionLocalStorageEnumerator(IDebugHostFunctionLocalStorageEnumerator raw) : base(raw)
        {
        }

        #region IDebugHostFunctionLocalStorageEnumerator
        #region Next

        public DebugHostFunctionLocalStorage Next
        {
            get
            {
                DebugHostFunctionLocalStorage storageResult;
                TryGetNext(out storageResult).ThrowDbgEngNotOK();

                return storageResult;
            }
        }

        public HRESULT TryGetNext(out DebugHostFunctionLocalStorage storageResult)
        {
            /*HRESULT GetNext(
            [Out, MarshalAs(UnmanagedType.Interface)] out IDebugHostFunctionLocalStorage storage);*/
            IDebugHostFunctionLocalStorage storage;
            HRESULT hr = Raw.GetNext(out storage);

            if (hr == HRESULT.S_OK)
                storageResult = storage == null ? null : new DebugHostFunctionLocalStorage(storage);
            else
                storageResult = default(DebugHostFunctionLocalStorage);

            return hr;
        }

        #endregion
        #region Reset

        public void Reset()
        {
            TryReset().ThrowDbgEngNotOK();
        }

        public HRESULT TryReset()
        {
            /*HRESULT Reset();*/
            return Raw.Reset();
        }

        #endregion
        #endregion
    }
}
