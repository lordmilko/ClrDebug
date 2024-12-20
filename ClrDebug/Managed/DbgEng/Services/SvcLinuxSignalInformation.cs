namespace ClrDebug.DbgEng
{
    /// <summary>
    /// Notes - All implementations of ISvcLinuxSignalInformation must also implement ISvcExceptionInformation.
    /// </summary>
    public class SvcLinuxSignalInformation : ComObject<ISvcLinuxSignalInformation>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SvcLinuxSignalInformation"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
        public SvcLinuxSignalInformation(ISvcLinuxSignalInformation raw) : base(raw)
        {
        }

        #region ISvcLinuxSignalInformation
        #region SignalNumber

        /// <summary>
        /// Gets the Linux signal number associated with the signal represented by this interface.
        /// </summary>
        public int SignalNumber
        {
            get
            {
                /*int GetSignalNumber();*/
                return Raw.GetSignalNumber();
            }
        }

        #endregion
        #region ErrorNumber

        /// <summary>
        /// Gets the errno associated with this signal (if applicable; otherwise 0).
        /// </summary>
        public int ErrorNumber
        {
            get
            {
                /*int GetErrorNumber();*/
                return Raw.GetErrorNumber();
            }
        }

        #endregion
        #region SignalCode

        /// <summary>
        /// Gets the signal code associated with this signal.
        /// </summary>
        public int SignalCode
        {
            get
            {
                /*int GetSignalCode();*/
                return Raw.GetSignalCode();
            }
        }

        #endregion
        #region SourcePid

        /// <summary>
        /// Gets the source PID for the origin of the signal if such information is included within the signal record. Otherwise, E_NOT_SET is returned.
        /// </summary>
        public long SourcePid
        {
            get
            {
                long sourcePid;
                TryGetSourcePid(out sourcePid).ThrowDbgEngNotOK();

                return sourcePid;
            }
        }

        /// <summary>
        /// Gets the source PID for the origin of the signal if such information is included within the signal record. Otherwise, E_NOT_SET is returned.
        /// </summary>
        public HRESULT TryGetSourcePid(out long sourcePid)
        {
            /*HRESULT GetSourcePid(
            [Out] out long sourcePid);*/
            return Raw.GetSourcePid(out sourcePid);
        }

        #endregion
        #endregion
    }
}
