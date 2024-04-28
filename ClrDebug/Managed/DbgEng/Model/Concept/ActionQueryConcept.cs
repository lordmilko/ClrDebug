namespace ClrDebug.DbgEng
{
    public class ActionQueryConcept : ComObject<IActionQueryConcept>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ActionQueryConcept"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
        public ActionQueryConcept(IActionQueryConcept raw) : base(raw)
        {
        }

        #region IActionQueryConcept
        #region EnumerateActions

        public ActionEnumerator EnumerateActions(IModelObject contextObject)
        {
            ActionEnumerator actionEnumeratorResult;
            TryEnumerateActions(contextObject, out actionEnumeratorResult).ThrowDbgEngNotOK();

            return actionEnumeratorResult;
        }

        public HRESULT TryEnumerateActions(IModelObject contextObject, out ActionEnumerator actionEnumeratorResult)
        {
            /*HRESULT EnumerateActions(
            [In, MarshalAs(UnmanagedType.Interface)] IModelObject contextObject,
            [Out, MarshalAs(UnmanagedType.Interface)] out IActionEnumerator actionEnumerator);*/
            IActionEnumerator actionEnumerator;
            HRESULT hr = Raw.EnumerateActions(contextObject, out actionEnumerator);

            if (hr == HRESULT.S_OK)
                actionEnumeratorResult = actionEnumerator == null ? null : new ActionEnumerator(actionEnumerator);
            else
                actionEnumeratorResult = default(ActionEnumerator);

            return hr;
        }

        #endregion
        #endregion
    }
}
