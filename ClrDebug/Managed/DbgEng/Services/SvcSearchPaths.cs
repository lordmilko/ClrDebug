namespace ClrDebug.DbgEng
{
    public class SvcSearchPaths : ComObject<ISvcSearchPaths>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SvcSearchPaths"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
        public SvcSearchPaths(ISvcSearchPaths raw) : base(raw)
        {
        }

        #region ISvcSearchPaths
        #region AllPaths

        public string AllPaths
        {
            get
            {
                string searchPaths;
                TryGetAllPaths(out searchPaths).ThrowDbgEngNotOK();

                return searchPaths;
            }
            set
            {
                TrySetAllPaths(value).ThrowDbgEngNotOK();
            }
        }

        public HRESULT TryGetAllPaths(out string searchPaths)
        {
            /*HRESULT GetAllPaths(
            [Out, MarshalAs(UnmanagedType.BStr)] out string searchPaths);*/
            return Raw.GetAllPaths(out searchPaths);
        }

        public HRESULT TrySetAllPaths(string searchPaths)
        {
            /*HRESULT SetAllPaths(
            [In, MarshalAs(UnmanagedType.LPWStr)] string searchPaths);*/
            return Raw.SetAllPaths(searchPaths);
        }

        #endregion
        #endregion
    }
}
