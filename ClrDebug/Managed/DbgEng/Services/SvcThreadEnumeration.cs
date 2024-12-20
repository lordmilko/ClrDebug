namespace ClrDebug.DbgEng
{
    public class SvcThreadEnumeration : ComObject<ISvcThreadEnumeration>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SvcThreadEnumeration"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
        public SvcThreadEnumeration(ISvcThreadEnumeration raw) : base(raw)
        {
        }

        #region ISvcThreadEnumeration
        #region FindThread

        /// <summary>
        /// Finds a thread by a unique key. The interpretation and semantic meaning of the key is specific to the service which provides this.<para/>
        /// For Windows Kernel mode, this may be a service which returns o an ISvcThread from a target ETHREAD pointer. For user mode, it might be the thread ID.
        /// </summary>
        public SvcThread FindThread(ISvcProcess process, long threadKey)
        {
            SvcThread targetThreadResult;
            TryFindThread(process, threadKey, out targetThreadResult).ThrowDbgEngNotOK();

            return targetThreadResult;
        }

        /// <summary>
        /// Finds a thread by a unique key. The interpretation and semantic meaning of the key is specific to the service which provides this.<para/>
        /// For Windows Kernel mode, this may be a service which returns o an ISvcThread from a target ETHREAD pointer. For user mode, it might be the thread ID.
        /// </summary>
        public HRESULT TryFindThread(ISvcProcess process, long threadKey, out SvcThread targetThreadResult)
        {
            /*HRESULT FindThread(
            [In, MarshalAs(UnmanagedType.Interface)] ISvcProcess process,
            [In] long threadKey,
            [Out, MarshalAs(UnmanagedType.Interface)] out ISvcThread targetThread);*/
            ISvcThread targetThread;
            HRESULT hr = Raw.FindThread(process, threadKey, out targetThread);

            if (hr == HRESULT.S_OK)
                targetThreadResult = targetThread == null ? null : new SvcThread(targetThread);
            else
                targetThreadResult = default(SvcThread);

            return hr;
        }

        #endregion
        #region EnumerateThreads

        /// <summary>
        /// Returns an enumerator object which is capable of enumerating all processes on the target and creating an ISvcProcess for them.
        /// </summary>
        public SvcThreadEnumerator EnumerateThreads(ISvcProcess process)
        {
            SvcThreadEnumerator targetThreadEnumeratorResult;
            TryEnumerateThreads(process, out targetThreadEnumeratorResult).ThrowDbgEngNotOK();

            return targetThreadEnumeratorResult;
        }

        /// <summary>
        /// Returns an enumerator object which is capable of enumerating all processes on the target and creating an ISvcProcess for them.
        /// </summary>
        public HRESULT TryEnumerateThreads(ISvcProcess process, out SvcThreadEnumerator targetThreadEnumeratorResult)
        {
            /*HRESULT EnumerateThreads(
            [In, MarshalAs(UnmanagedType.Interface)] ISvcProcess process,
            [Out, MarshalAs(UnmanagedType.Interface)] out ISvcThreadEnumerator targetThreadEnumerator);*/
            ISvcThreadEnumerator targetThreadEnumerator;
            HRESULT hr = Raw.EnumerateThreads(process, out targetThreadEnumerator);

            if (hr == HRESULT.S_OK)
                targetThreadEnumeratorResult = targetThreadEnumerator == null ? null : new SvcThreadEnumerator(targetThreadEnumerator);
            else
                targetThreadEnumeratorResult = default(SvcThreadEnumerator);

            return hr;
        }

        #endregion
        #endregion
    }
}
