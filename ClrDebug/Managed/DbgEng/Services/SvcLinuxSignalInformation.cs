namespace ClrDebug.DbgEng
{
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

        public long SourcePid
        {
            get
            {
                long sourcePid;
                TryGetSourcePid(out sourcePid).ThrowDbgEngNotOK();

                return sourcePid;
            }
        }

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
