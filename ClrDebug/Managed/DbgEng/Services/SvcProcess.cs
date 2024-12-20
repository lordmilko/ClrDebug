namespace ClrDebug.DbgEng
{
    /// <summary>
    /// Defines a means of accessing or identifying aspects of a process. Note that this represents a process whether that is a user mode process or a kernel mode process.<para/>
    /// This interface is intended to be a minimal core of information about a process. Further ISvcProcess* interfaces can be added to provide further functionality.<para/>
    /// @NOTE: For now, this is likely to be very tied to ProcessInfo (user mode) or the implicit process data (kernel mode).
    /// </summary>
    public class SvcProcess : ComObject<ISvcProcess>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SvcProcess"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
        public SvcProcess(ISvcProcess raw) : base(raw)
        {
        }

        #region ISvcProcess
        #region Key

        /// <summary>
        /// Gets the unique "per-target" process key. The interpretation of this key is dependent upon the service which provides this interface.<para/>
        /// For Windows Kernel, this may be the address of an EPROCESS in the target. For Windows User, this may be the PID.
        /// </summary>
        public long Key
        {
            get
            {
                long processKey;
                TryGetKey(out processKey).ThrowDbgEngNotOK();

                return processKey;
            }
        }

        /// <summary>
        /// Gets the unique "per-target" process key. The interpretation of this key is dependent upon the service which provides this interface.<para/>
        /// For Windows Kernel, this may be the address of an EPROCESS in the target. For Windows User, this may be the PID.
        /// </summary>
        public HRESULT TryGetKey(out long processKey)
        {
            /*HRESULT GetKey(
            [Out] out long processKey);*/
            return Raw.GetKey(out processKey);
        }

        #endregion
        #region Id

        /// <summary>
        /// Gets the process' ID as defined by the underlying platform. This may or may not be the same value as returned from GetKey.
        /// </summary>
        public long Id
        {
            get
            {
                long processId;
                TryGetId(out processId).ThrowDbgEngNotOK();

                return processId;
            }
        }

        /// <summary>
        /// Gets the process' ID as defined by the underlying platform. This may or may not be the same value as returned from GetKey.
        /// </summary>
        public HRESULT TryGetId(out long processId)
        {
            /*HRESULT GetId(
            [Out] out long processId);*/
            return Raw.GetId(out processId);
        }

        #endregion
        #endregion
    }
}
