namespace ClrDebug.DbgEng
{
    /// <summary>
    /// It is expected that any implementation of ISvcThread will successfully QI for ISvcExecutionUnit in order to read thread context and provide other core attributes of something which can successfully "step".
    /// </summary>
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

        /// <summary>
        /// Gets the unique key of the process to which this thread belongs. This is the same key returned from the containing ISvcProcess's GetKey method.
        /// </summary>
        public long ContainingProcessKey
        {
            get
            {
                long containingProcessKey;
                TryGetContainingProcessKey(out containingProcessKey).ThrowDbgEngNotOK();

                return containingProcessKey;
            }
        }

        /// <summary>
        /// Gets the unique key of the process to which this thread belongs. This is the same key returned from the containing ISvcProcess's GetKey method.
        /// </summary>
        public HRESULT TryGetContainingProcessKey(out long containingProcessKey)
        {
            /*HRESULT GetContainingProcessKey(
            [Out] out long containingProcessKey);*/
            return Raw.GetContainingProcessKey(out containingProcessKey);
        }

        #endregion
        #region Key

        /// <summary>
        /// Gets the unique "per-process" thread key. The interpretation of this key is dependent upon the service which provides this interface.<para/>
        /// For Windows Kernel, this may be the address of an ETHREAD in the target. For Windows User, this may be the TID.
        /// </summary>
        public long Key
        {
            get
            {
                long threadKey;
                TryGetKey(out threadKey).ThrowDbgEngNotOK();

                return threadKey;
            }
        }

        /// <summary>
        /// Gets the unique "per-process" thread key. The interpretation of this key is dependent upon the service which provides this interface.<para/>
        /// For Windows Kernel, this may be the address of an ETHREAD in the target. For Windows User, this may be the TID.
        /// </summary>
        public HRESULT TryGetKey(out long threadKey)
        {
            /*HRESULT GetKey(
            [Out] out long threadKey);*/
            return Raw.GetKey(out threadKey);
        }

        #endregion
        #region Id

        /// <summary>
        /// Gets the thread's ID as defined by the underlying platform. This may or may not be the same value as returned from GetKey.
        /// </summary>
        public long Id
        {
            get
            {
                long threadId;
                TryGetId(out threadId).ThrowDbgEngNotOK();

                return threadId;
            }
        }

        /// <summary>
        /// Gets the thread's ID as defined by the underlying platform. This may or may not be the same value as returned from GetKey.
        /// </summary>
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
