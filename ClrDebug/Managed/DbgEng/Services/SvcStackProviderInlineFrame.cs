namespace ClrDebug.DbgEng
{
    public class SvcStackProviderInlineFrame : ComObject<ISvcStackProviderInlineFrame>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SvcStackProviderInlineFrame"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
        public SvcStackProviderInlineFrame(ISvcStackProviderInlineFrame raw) : base(raw)
        {
        }

        #region ISvcStackProviderInlineFrame
        #region UnderlyingFrame

        public SvcStackProviderFrame UnderlyingFrame
        {
            get
            {
                SvcStackProviderFrame ppFrameResult;
                TryGetUnderlyingFrame(out ppFrameResult).ThrowDbgEngNotOK();

                return ppFrameResult;
            }
        }

        public HRESULT TryGetUnderlyingFrame(out SvcStackProviderFrame ppFrameResult)
        {
            /*HRESULT GetUnderlyingFrame(
            [Out, MarshalAs(UnmanagedType.Interface)] out ISvcStackProviderFrame ppFrame);*/
            ISvcStackProviderFrame ppFrame;
            HRESULT hr = Raw.GetUnderlyingFrame(out ppFrame);

            if (hr == HRESULT.S_OK)
                ppFrameResult = ppFrame == null ? null : new SvcStackProviderFrame(ppFrame);
            else
                ppFrameResult = default(SvcStackProviderFrame);

            return hr;
        }

        #endregion
        #region InlineDepth

        public long InlineDepth
        {
            get
            {
                /*long GetInlineDepth();*/
                return Raw.GetInlineDepth();
            }
        }

        #endregion
        #region MaximalInlineDepth

        public long MaximalInlineDepth
        {
            get
            {
                /*long GetMaximalInlineDepth();*/
                return Raw.GetMaximalInlineDepth();
            }
        }

        #endregion
        #endregion
    }
}
