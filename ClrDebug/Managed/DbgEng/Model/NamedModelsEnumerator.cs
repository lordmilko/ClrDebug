namespace ClrDebug.DbgEng
{
    public class NamedModelsEnumerator : ComObject<INamedModelsEnumerator>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NamedModelsEnumerator"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
        public NamedModelsEnumerator(INamedModelsEnumerator raw) : base(raw)
        {
        }

        #region INamedModelsEnumerator
        #region Next

        public NamedModelsEnumerator_GetNextResult Next
        {
            get
            {
                NamedModelsEnumerator_GetNextResult result;
                TryGetNext(out result).ThrowDbgEngNotOK();

                return result;
            }
        }

        public HRESULT TryGetNext(out NamedModelsEnumerator_GetNextResult result)
        {
            /*HRESULT GetNext(
            [Out, MarshalAs(UnmanagedType.BStr)] out string pModelName,
            [Out, MarshalAs(UnmanagedType.Interface)] out IModelObject ppModel);*/
            string pModelName;
            IModelObject ppModel;
            HRESULT hr = Raw.GetNext(out pModelName, out ppModel);

            if (hr == HRESULT.S_OK)
                result = new NamedModelsEnumerator_GetNextResult(pModelName, ppModel == null ? null : new ModelObject(ppModel));
            else
                result = default(NamedModelsEnumerator_GetNextResult);

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
