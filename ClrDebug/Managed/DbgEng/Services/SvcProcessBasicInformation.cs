namespace ClrDebug.DbgEng
{
    /// <summary>
    /// Defines basic information about a particular process. This interface is optional to implement by any implementation of ISvcProcess.<para/>
    /// Not every provider implements this.
    /// </summary>
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

        /// <summary>
        /// Gets the name of the process. This may or may not be the same as the name of the main executable (or may be truncated) depending on the underlying platform.<para/>
        /// An implementation for a process which does not have a name will return E_NOT_SET.
        /// </summary>
        public string Name
        {
            get
            {
                string processName;
                TryGetName(out processName).ThrowDbgEngNotOK();

                return processName;
            }
        }

        /// <summary>
        /// Gets the name of the process. This may or may not be the same as the name of the main executable (or may be truncated) depending on the underlying platform.<para/>
        /// An implementation for a process which does not have a name will return E_NOT_SET.
        /// </summary>
        public HRESULT TryGetName(out string processName)
        {
            /*HRESULT GetName(
            [Out, MarshalAs(UnmanagedType.BStr)] out string processName);*/
            return Raw.GetName(out processName);
        }

        #endregion
        #region Arguments

        /// <summary>
        /// Gets the start arguments of the process. An implementation for a process which does not have available arguments will return E_NOT_SET.
        /// </summary>
        public string Arguments
        {
            get
            {
                string processArguments;
                TryGetArguments(out processArguments).ThrowDbgEngNotOK();

                return processArguments;
            }
        }

        /// <summary>
        /// Gets the start arguments of the process. An implementation for a process which does not have available arguments will return E_NOT_SET.
        /// </summary>
        public HRESULT TryGetArguments(out string processArguments)
        {
            /*HRESULT GetArguments(
            [Out, MarshalAs(UnmanagedType.BStr)] out string processArguments);*/
            return Raw.GetArguments(out processArguments);
        }

        #endregion
        #region ParentId

        /// <summary>
        /// Gets the PID of the parent process. An implementation for a process which does not have an available parent ID will return E_NOT_SET.
        /// </summary>
        public long ParentId
        {
            get
            {
                long parentId;
                TryGetParentId(out parentId).ThrowDbgEngNotOK();

                return parentId;
            }
        }

        /// <summary>
        /// Gets the PID of the parent process. An implementation for a process which does not have an available parent ID will return E_NOT_SET.
        /// </summary>
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
