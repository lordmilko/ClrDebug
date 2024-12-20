namespace ClrDebug.DbgEng
{
    /// <summary>
    /// Notes - All implementations of ISvcWindowsBugCheckInformation must also implement ISvcExceptionInformation.
    /// </summary>
    public class SvcWindowsBugCheckInformation : ComObject<ISvcWindowsBugCheckInformation>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SvcWindowsBugCheckInformation"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
        public SvcWindowsBugCheckInformation(ISvcWindowsBugCheckInformation raw) : base(raw)
        {
        }

        #region ISvcWindowsBugCheckInformation
        #region BugCheckCode

        /// <summary>
        /// Gets the bugcheck code.
        /// </summary>
        public int BugCheckCode
        {
            get
            {
                /*int GetBugCheckCode();*/
                return Raw.GetBugCheckCode();
            }
        }

        #endregion
        #region BugCheckData

        /// <summary>
        /// Gets the bugcheck data.
        /// </summary>
        public long BugCheckData
        {
            get
            {
                /*void GetBugCheckData(
            [Out] out long pBugCheckData);*/
                long pBugCheckData;
                Raw.GetBugCheckData(out pBugCheckData);

                return pBugCheckData;
            }
        }

        #endregion
        #endregion
    }
}
