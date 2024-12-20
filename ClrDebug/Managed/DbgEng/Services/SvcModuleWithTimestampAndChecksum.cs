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

        /// <summary>
        /// Gets the time date stamp of the module.
        /// </summary>
        public int TimeDateStamp
        {
            get
            {
                int moduleTimeDateStamp;
                TryGetTimeDateStamp(out moduleTimeDateStamp).ThrowDbgEngNotOK();

                return moduleTimeDateStamp;
            }
        }

        /// <summary>
        /// Gets the time date stamp of the module.
        /// </summary>
        public HRESULT TryGetTimeDateStamp(out int moduleTimeDateStamp)
        {
            /*HRESULT GetTimeDateStamp(
            [Out] out int moduleTimeDateStamp);*/
            return Raw.GetTimeDateStamp(out moduleTimeDateStamp);
        }

        #endregion
        #region CheckSum

        /// <summary>
        /// Gets the check sum of the module.
        /// </summary>
        public int CheckSum
        {
            get
            {
                int moduleCheckSum;
                TryGetCheckSum(out moduleCheckSum).ThrowDbgEngNotOK();

                return moduleCheckSum;
            }
        }

        /// <summary>
        /// Gets the check sum of the module.
        /// </summary>
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
