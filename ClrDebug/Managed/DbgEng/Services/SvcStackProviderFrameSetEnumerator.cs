namespace ClrDebug.DbgEng
{
    public class SvcStackProviderFrameSetEnumerator : ComObject<ISvcStackProviderFrameSetEnumerator>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SvcStackProviderFrameSetEnumerator"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
        public SvcStackProviderFrameSetEnumerator(ISvcStackProviderFrameSetEnumerator raw) : base(raw)
        {
        }

        #region ISvcStackProviderFrameSetEnumerator
        #region UnwindContext

        public SvcStackUnwindContext UnwindContext
        {
            get
            {
                SvcStackUnwindContext unwindContextResult;
                TryGetUnwindContext(out unwindContextResult).ThrowDbgEngNotOK();

                return unwindContextResult;
            }
        }

        public HRESULT TryGetUnwindContext(out SvcStackUnwindContext unwindContextResult)
        {
            /*HRESULT GetUnwindContext(
            [Out, MarshalAs(UnmanagedType.Interface)] out ISvcStackUnwindContext unwindContext);*/
            ISvcStackUnwindContext unwindContext;
            HRESULT hr = Raw.GetUnwindContext(out unwindContext);

            if (hr == HRESULT.S_OK)
                unwindContextResult = unwindContext == null ? null : new SvcStackUnwindContext(unwindContext);
            else
                unwindContextResult = default(SvcStackUnwindContext);

            return hr;
        }

        #endregion
        #region CurrentFrame

        public SvcStackProviderFrame CurrentFrame
        {
            get
            {
                SvcStackProviderFrame currentFrameResult;
                TryGetCurrentFrame(out currentFrameResult).ThrowDbgEngNotOK();

                return currentFrameResult;
            }
        }

        public HRESULT TryGetCurrentFrame(out SvcStackProviderFrame currentFrameResult)
        {
            /*HRESULT GetCurrentFrame(
            [Out, MarshalAs(UnmanagedType.Interface)] out ISvcStackProviderFrame currentFrame);*/
            ISvcStackProviderFrame currentFrame;
            HRESULT hr = Raw.GetCurrentFrame(out currentFrame);

            if (hr == HRESULT.S_OK)
                currentFrameResult = currentFrame == null ? null : new SvcStackProviderFrame(currentFrame);
            else
                currentFrameResult = default(SvcStackProviderFrame);

            return hr;
        }

        #endregion
        #region Reset

        public void Reset()
        {
            TryReset().ThrowDbgEngNotOK();
        }

        public HRESULT TryReset()
        {
            /*HRESULT Reset();*/
            return Raw.Reset();
        }

        #endregion
        #region MoveNext

        public void MoveNext()
        {
            TryMoveNext().ThrowDbgEngNotOK();
        }

        public HRESULT TryMoveNext()
        {
            /*HRESULT MoveNext();*/
            return Raw.MoveNext();
        }

        #endregion
        #endregion
    }
}
