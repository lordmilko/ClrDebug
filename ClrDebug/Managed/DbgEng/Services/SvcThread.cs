namespace ClrDebug.DbgEng
{
    public class SvcThread : ComObject<ISvcThread>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SvcThread"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
        public SvcThread(ISvcThread raw) : base(raw)
        {
        }

        #region ISvcThread
        #region ContainingProcessKey

        public long ContainingProcessKey
        {
            get
            {
                long containingProcessKey;
                TryGetContainingProcessKey(out containingProcessKey).ThrowDbgEngNotOK();

                return containingProcessKey;
            }
        }

        public HRESULT TryGetContainingProcessKey(out long containingProcessKey)
        {
            /*HRESULT GetContainingProcessKey(
            [Out] out long containingProcessKey);*/
            return Raw.GetContainingProcessKey(out containingProcessKey);
        }

        #endregion
        #region Key

        public long Key
        {
            get
            {
                long threadKey;
                TryGetKey(out threadKey).ThrowDbgEngNotOK();

                return threadKey;
            }
        }

        public HRESULT TryGetKey(out long threadKey)
        {
            /*HRESULT GetKey(
            [Out] out long threadKey);*/
            return Raw.GetKey(out threadKey);
        }

        #endregion
        #region Id

        public long Id
        {
            get
            {
                long threadId;
                TryGetId(out threadId).ThrowDbgEngNotOK();

                return threadId;
            }
        }

        public HRESULT TryGetId(out long threadId)
        {
            /*HRESULT GetId(
            [Out] out long threadId);*/
            return Raw.GetId(out threadId);
        }

        #endregion
        #endregion
    }
}
