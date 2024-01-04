namespace ClrDebug.DbgEng
{
    public class SvcEventArgumentsSearchPathsChanged : ComObject<ISvcEventArgumentsSearchPathsChanged>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SvcEventArgumentsSearchPathsChanged"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
        public SvcEventArgumentsSearchPathsChanged(ISvcEventArgumentsSearchPathsChanged raw) : base(raw)
        {
        }

        #region ISvcEventArgumentsSearchPathsChanged
        #region AllPaths

        public string AllPaths
        {
            get
            {
                string searchPaths;
                TryGetAllPaths(out searchPaths).ThrowDbgEngNotOK();

                return searchPaths;
            }
        }

        public HRESULT TryGetAllPaths(out string searchPaths)
        {
            /*HRESULT GetAllPaths(
            [Out, MarshalAs(UnmanagedType.BStr)] out string searchPaths);*/
            return Raw.GetAllPaths(out searchPaths);
        }

        #endregion
        #endregion
    }
}
