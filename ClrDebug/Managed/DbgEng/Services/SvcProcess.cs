namespace ClrDebug.DbgEng
{
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

        public long Key
        {
            get
            {
                long processKey;
                TryGetKey(out processKey).ThrowDbgEngNotOK();

                return processKey;
            }
        }

        public HRESULT TryGetKey(out long processKey)
        {
            /*HRESULT GetKey(
            [Out] out long processKey);*/
            return Raw.GetKey(out processKey);
        }

        #endregion
        #region Id

        public long Id
        {
            get
            {
                long processId;
                TryGetId(out processId).ThrowDbgEngNotOK();

                return processId;
            }
        }

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
