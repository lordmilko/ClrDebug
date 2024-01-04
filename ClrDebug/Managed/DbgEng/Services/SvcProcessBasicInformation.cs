namespace ClrDebug.DbgEng
{
    public class SvcProcessBasicInformation : ComObject<ISvcProcessBasicInformation>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SvcProcessBasicInformation"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
        public SvcProcessBasicInformation(ISvcProcessBasicInformation raw) : base(raw)
        {
        }

        #region ISvcProcessBasicInformation
        #region Name

        public string Name
        {
            get
            {
                string processName;
                TryGetName(out processName).ThrowDbgEngNotOK();

                return processName;
            }
        }

        public HRESULT TryGetName(out string processName)
        {
            /*HRESULT GetName(
            [Out, MarshalAs(UnmanagedType.BStr)] out string processName);*/
            return Raw.GetName(out processName);
        }

        #endregion
        #region Arguments

        public string Arguments
        {
            get
            {
                string processArguments;
                TryGetArguments(out processArguments).ThrowDbgEngNotOK();

                return processArguments;
            }
        }

        public HRESULT TryGetArguments(out string processArguments)
        {
            /*HRESULT GetArguments(
            [Out, MarshalAs(UnmanagedType.BStr)] out string processArguments);*/
            return Raw.GetArguments(out processArguments);
        }

        #endregion
        #region ParentId

        public long ParentId
        {
            get
            {
                long parentId;
                TryGetParentId(out parentId).ThrowDbgEngNotOK();

                return parentId;
            }
        }

        public HRESULT TryGetParentId(out long parentId)
        {
            /*HRESULT GetParentId(
            [Out] out long parentId);*/
            return Raw.GetParentId(out parentId);
        }

        #endregion
        #endregion

        /// <summary>
        /// Returns a string that represents the current object.
        /// </summary>
        /// <returns>A string that represents the current object.</returns>
        public override string ToString()
        {
            return Name;
        }
    }
}
