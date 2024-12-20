namespace ClrDebug.DbgEng
{
    public class SvcDebugSourceView : ComObject<ISvcDebugSourceView>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SvcDebugSourceView"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
        public SvcDebugSourceView(ISvcDebugSourceView raw) : base(raw)
        {
        }

        #region ISvcDebugSourceView
        #region ViewSource

        /// <summary>
        /// Gets the the source of this view.
        /// </summary>
        public DebugServiceManager ViewSource
        {
            get
            {
                DebugServiceManager viewSourceResult;
                TryGetViewSource(out viewSourceResult).ThrowDbgEngNotOK();

                return viewSourceResult;
            }
        }

        /// <summary>
        /// Gets the the source of this view.
        /// </summary>
        public HRESULT TryGetViewSource(out DebugServiceManager viewSourceResult)
        {
            /*HRESULT GetViewSource(
            [Out, MarshalAs(UnmanagedType.Interface)] out IDebugServiceManager viewSource);*/
            IDebugServiceManager viewSource;
            HRESULT hr = Raw.GetViewSource(out viewSource);

            if (hr == HRESULT.S_OK)
                viewSourceResult = viewSource == null ? null : new DebugServiceManager(viewSource);
            else
                viewSourceResult = default(DebugServiceManager);

            return hr;
        }

        #endregion
        #endregion
    }
}
