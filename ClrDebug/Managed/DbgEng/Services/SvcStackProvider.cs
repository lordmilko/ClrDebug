namespace ClrDebug.DbgEng
{
    /// <summary>
    /// Describes an abstract stack provider. Semantically, this is a layer above a stack unwinder which returns physical frames on a stack and register contexts.<para/>
    /// Frames from a stack provider can be physical frames provided by a stack unwinder... or they can be inline frames on top of those physical frames...<para/>
    /// or they can be entirely synthetic constructs that represent some logical form of call chain.
    /// </summary>
    public class SvcStackProvider : ComObject<ISvcStackProvider>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SvcStackProvider"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
        public SvcStackProvider(ISvcStackProvider raw) : base(raw)
        {
        }

        #region ISvcStackProvider
        #region StartStackWalk

        /// <summary>
        /// Starts a stack walk for the execution unit given by the unwind context and returns a frame set enumerator representing the frames within that stack walk.
        /// </summary>
        public SvcStackProviderFrameSetEnumerator StartStackWalk(ISvcStackUnwindContext unwindContext)
        {
            SvcStackProviderFrameSetEnumerator frameEnumResult;
            TryStartStackWalk(unwindContext, out frameEnumResult).ThrowDbgEngNotOK();

            return frameEnumResult;
        }

        /// <summary>
        /// Starts a stack walk for the execution unit given by the unwind context and returns a frame set enumerator representing the frames within that stack walk.
        /// </summary>
        public HRESULT TryStartStackWalk(ISvcStackUnwindContext unwindContext, out SvcStackProviderFrameSetEnumerator frameEnumResult)
        {
            /*HRESULT StartStackWalk(
            [In, MarshalAs(UnmanagedType.Interface)] ISvcStackUnwindContext unwindContext,
            [Out, MarshalAs(UnmanagedType.Interface)] out ISvcStackProviderFrameSetEnumerator frameEnum);*/
            ISvcStackProviderFrameSetEnumerator frameEnum;
            HRESULT hr = Raw.StartStackWalk(unwindContext, out frameEnum);

            if (hr == HRESULT.S_OK)
                frameEnumResult = frameEnum == null ? null : new SvcStackProviderFrameSetEnumerator(frameEnum);
            else
                frameEnumResult = default(SvcStackProviderFrameSetEnumerator);

            return hr;
        }

        #endregion
        #region StartStackWalkForAlternateContext

        /// <summary>
        /// Starts a stack walk given an alternate starting register context. Other than assuming a different initial register context than StartStackWalk, the method operates identically.<para/>
        /// Stack providers which deal in physical frames *SHOULD* implement this method. Stack providers which do not may legally E_NOTIMPL this method.
        /// </summary>
        public SvcStackProviderFrameSetEnumerator StartStackWalkForAlternateContext(ISvcStackUnwindContext unwindContext, ISvcRegisterContext registerContext)
        {
            SvcStackProviderFrameSetEnumerator frameEnumResult;
            TryStartStackWalkForAlternateContext(unwindContext, registerContext, out frameEnumResult).ThrowDbgEngNotOK();

            return frameEnumResult;
        }

        /// <summary>
        /// Starts a stack walk given an alternate starting register context. Other than assuming a different initial register context than StartStackWalk, the method operates identically.<para/>
        /// Stack providers which deal in physical frames *SHOULD* implement this method. Stack providers which do not may legally E_NOTIMPL this method.
        /// </summary>
        public HRESULT TryStartStackWalkForAlternateContext(ISvcStackUnwindContext unwindContext, ISvcRegisterContext registerContext, out SvcStackProviderFrameSetEnumerator frameEnumResult)
        {
            /*HRESULT StartStackWalkForAlternateContext(
            [In, MarshalAs(UnmanagedType.Interface)] ISvcStackUnwindContext unwindContext,
            [In, MarshalAs(UnmanagedType.Interface)] ISvcRegisterContext registerContext,
            [Out, MarshalAs(UnmanagedType.Interface)] out ISvcStackProviderFrameSetEnumerator frameEnum);*/
            ISvcStackProviderFrameSetEnumerator frameEnum;
            HRESULT hr = Raw.StartStackWalkForAlternateContext(unwindContext, registerContext, out frameEnum);

            if (hr == HRESULT.S_OK)
                frameEnumResult = frameEnum == null ? null : new SvcStackProviderFrameSetEnumerator(frameEnum);
            else
                frameEnumResult = default(SvcStackProviderFrameSetEnumerator);

            return hr;
        }

        #endregion
        #endregion
    }
}
