namespace ClrDebug.DbgEng
{
    public class FilteredNamespacePropertyToken : ComObject<IFilteredNamespacePropertyToken>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FilteredNamespacePropertyToken"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
        public FilteredNamespacePropertyToken(IFilteredNamespacePropertyToken raw) : base(raw)
        {
        }

        #region IFilteredNamespacePropertyToken
        #region Filter

        public ModelMethod Filter
        {
            get
            {
                ModelMethod ppFilterResult;
                TryGetFilter(out ppFilterResult).ThrowDbgEngNotOK();

                return ppFilterResult;
            }
        }

        public HRESULT TryGetFilter(out ModelMethod ppFilterResult)
        {
            /*HRESULT GetFilter(
            [Out, MarshalAs(UnmanagedType.Interface)] out IModelMethod ppFilter);*/
            IModelMethod ppFilter;
            HRESULT hr = Raw.GetFilter(out ppFilter);

            if (hr == HRESULT.S_OK)
                ppFilterResult = ppFilter == null ? null : new ModelMethod(ppFilter);
            else
                ppFilterResult = default(ModelMethod);

            return hr;
        }

        #endregion
        #region RemoveFilter

        public void RemoveFilter()
        {
            TryRemoveFilter().ThrowDbgEngNotOK();
        }

        public HRESULT TryRemoveFilter()
        {
            /*HRESULT RemoveFilter();*/
            return Raw.RemoveFilter();
        }

        #endregion
        #region TrySetFilter

        public void TrySetFilter(IModelMethod pFilter)
        {
            TryTrySetFilter(pFilter).ThrowDbgEngNotOK();
        }

        public HRESULT TryTrySetFilter(IModelMethod pFilter)
        {
            /*HRESULT TrySetFilter(
            [In, MarshalAs(UnmanagedType.Interface)] IModelMethod pFilter);*/
            return Raw.TrySetFilter(pFilter);
        }

        #endregion
        #endregion
    }
}
