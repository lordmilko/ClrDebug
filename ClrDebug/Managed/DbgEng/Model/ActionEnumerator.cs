namespace ClrDebug.DbgEng
{
    public class ActionEnumerator : ComObject<IActionEnumerator>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ActionEnumerator"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
        public ActionEnumerator(IActionEnumerator raw) : base(raw)
        {
        }

        #region IActionEnumerator
        #region Next

        public ActionEnumerator_GetNextResult Next
        {
            get
            {
                ActionEnumerator_GetNextResult result;
                TryGetNext(out result).ThrowDbgEngNotOK();

                return result;
            }
        }

        public HRESULT TryGetNext(out ActionEnumerator_GetNextResult result)
        {
            /*HRESULT GetNext(
            [Out, MarshalAs(UnmanagedType.BStr)] out string keyName,
            [Out, MarshalAs(UnmanagedType.BStr)] out string actionName,
            [Out, MarshalAs(UnmanagedType.BStr)] out string actionDescription,
            [Out, MarshalAs(UnmanagedType.U1)] out bool actionIsDefault,
            [Out, MarshalAs(UnmanagedType.Interface)] out IModelObject actionMethod,
            [Out, MarshalAs(UnmanagedType.Interface)] out IKeyStore metadta);*/
            string keyName;
            string actionName;
            string actionDescription;
            bool actionIsDefault;
            IModelObject actionMethod;
            IKeyStore metadta;
            HRESULT hr = Raw.GetNext(out keyName, out actionName, out actionDescription, out actionIsDefault, out actionMethod, out metadta);

            if (hr == HRESULT.S_OK)
                result = new ActionEnumerator_GetNextResult(keyName, actionName, actionDescription, actionIsDefault, actionMethod == null ? null : new ModelObject(actionMethod), metadta == null ? null : new KeyStore(metadta));
            else
                result = default(ActionEnumerator_GetNextResult);

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
