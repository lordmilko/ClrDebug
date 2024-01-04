namespace ClrDebug.DbgEng
{
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
