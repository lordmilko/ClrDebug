namespace ClrDebug.DbgEng
{
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

        public SvcStackProviderFrameSetEnumerator StartStackWalk(ISvcStackUnwindContext unwindContext)
        {
            SvcStackProviderFrameSetEnumerator frameEnumResult;
            TryStartStackWalk(unwindContext, out frameEnumResult).ThrowDbgEngNotOK();

            return frameEnumResult;
        }

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

        public SvcStackProviderFrameSetEnumerator StartStackWalkForAlternateContext(ISvcStackUnwindContext unwindContext, ISvcRegisterContext registerContext)
        {
            SvcStackProviderFrameSetEnumerator frameEnumResult;
            TryStartStackWalkForAlternateContext(unwindContext, registerContext, out frameEnumResult).ThrowDbgEngNotOK();

            return frameEnumResult;
        }

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
