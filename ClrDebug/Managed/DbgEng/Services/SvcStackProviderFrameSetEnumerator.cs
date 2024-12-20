namespace ClrDebug.DbgEng
{
    /// <summary>
    /// Defines a set of stack frames which can be linearly enumerated from a "top" to a "bottom" (typically retrieved from a stack walk).<para/>
    /// The set of frames can, however, represent some portion of a physical stack or a logical call chain which doesn't necessarily relate to a physical stack in memory.<para/>
    /// While a stack provider can return a stack walk as a single "frame set", it is entirely possible to have aggregate stack providers that compose an interleaved number of frame sets into a single frame set.
    /// </summary>
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

        /// <summary>
        /// Gets the unwinder context which is associated with this frame set.
        /// </summary>
        public SvcStackUnwindContext UnwindContext
        {
            get
            {
                SvcStackUnwindContext unwindContextResult;
                TryGetUnwindContext(out unwindContextResult).ThrowDbgEngNotOK();

                return unwindContextResult;
            }
        }

        /// <summary>
        /// Gets the unwinder context which is associated with this frame set.
        /// </summary>
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

        /// <summary>
        /// Returns the current frame of the set. If there is no current frame, this will return E_BOUNDS.
        /// </summary>
        public SvcStackProviderFrame CurrentFrame
        {
            get
            {
                SvcStackProviderFrame currentFrameResult;
                TryGetCurrentFrame(out currentFrameResult).ThrowDbgEngNotOK();

                return currentFrameResult;
            }
        }

        /// <summary>
        /// Returns the current frame of the set. If there is no current frame, this will return E_BOUNDS.
        /// </summary>
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

        /// <summary>
        /// ; Resets the enumerator back to the top of the set of frames which it represents.
        /// </summary>
        public void Reset()
        {
            TryReset().ThrowDbgEngNotOK();
        }

        /// <summary>
        /// ; Resets the enumerator back to the top of the set of frames which it represents.
        /// </summary>
        public HRESULT TryReset()
        {
            /*HRESULT Reset();*/
            return Raw.Reset();
        }

        #endregion
        #region MoveNext

        /// <summary>
        /// Moves the enumerator to the next frame. This will return E_BOUNDS at the end of enumeration.
        /// </summary>
        public void MoveNext()
        {
            TryMoveNext().ThrowDbgEngNotOK();
        }

        /// <summary>
        /// Moves the enumerator to the next frame. This will return E_BOUNDS at the end of enumeration.
        /// </summary>
        public HRESULT TryMoveNext()
        {
            /*HRESULT MoveNext();*/
            return Raw.MoveNext();
        }

        #endregion
        #endregion
    }
}
