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

        /// <summary>
        /// Provides a semicolon separated list of paths from which the provider will search for the appropriate images/symbols.<para/>
        /// Note that this will return symbol server syntax.
        /// </summary>
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

        /// <summary>
        /// Provides a semicolon separated list of paths from which the provider will search for the appropriate images/symbols.<para/>
        /// Note that this will return symbol server syntax.
        /// </summary>
        public HRESULT TryGetAllPaths(out string searchPaths)
        {
            /*HRESULT GetAllPaths(
            [Out, MarshalAs(UnmanagedType.BStr)] out string searchPaths);*/
            return Raw.GetAllPaths(out searchPaths);
        }

        /// <summary>
        /// Provides a semicolon separated list of paths to the provider in which to search for the appropriate images/symbols.<para/>
        /// Note that this accepts symbol server syntax.
        /// </summary>
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
