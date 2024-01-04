namespace ClrDebug.DbgEng
{
    public class SvcModuleWithTimestampAndChecksum : SvcModule
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SvcModuleWithTimestampAndChecksum"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
        public SvcModuleWithTimestampAndChecksum(ISvcModuleWithTimestampAndChecksum raw) : base(raw)
        {
        }

        #region ISvcModuleWithTimestampAndChecksum

        public new ISvcModuleWithTimestampAndChecksum Raw => (ISvcModuleWithTimestampAndChecksum) base.Raw;

        #region TimeDateStamp

        public int TimeDateStamp
        {
            get
            {
                int moduleTimeDateStamp;
                TryGetTimeDateStamp(out moduleTimeDateStamp).ThrowDbgEngNotOK();

                return moduleTimeDateStamp;
            }
        }

        public HRESULT TryGetTimeDateStamp(out int moduleTimeDateStamp)
        {
            /*HRESULT GetTimeDateStamp(
            [Out] out int moduleTimeDateStamp);*/
            return Raw.GetTimeDateStamp(out moduleTimeDateStamp);
        }

        #endregion
        #region CheckSum

        public int CheckSum
        {
            get
            {
                int moduleCheckSum;
                TryGetCheckSum(out moduleCheckSum).ThrowDbgEngNotOK();

                return moduleCheckSum;
            }
        }

        public HRESULT TryGetCheckSum(out int moduleCheckSum)
        {
            /*HRESULT GetCheckSum(
            [Out] out int moduleCheckSum);*/
            return Raw.GetCheckSum(out moduleCheckSum);
        }

        #endregion
        #endregion
    }
}
