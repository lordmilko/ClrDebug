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

        /// <summary>
        /// Represents an inline stack frame within a physical frame.
        /// </summary>
        public SvcStackProviderFrame UnderlyingFrame
        {
            get
            {
                SvcStackProviderFrame ppFrameResult;
                TryGetUnderlyingFrame(out ppFrameResult).ThrowDbgEngNotOK();

                return ppFrameResult;
            }
        }

        /// <summary>
        /// Represents an inline stack frame within a physical frame.
        /// </summary>
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

        /// <summary>
        /// Gets the inline depth of this particular stack frame.
        /// </summary>
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

        /// <summary>
        /// Gets the maximal inline depth of the stack at this particular inline frame's location. In other words, for a given @pc, if there are 3 nested inlne frames at this point, all three frames would return 3 for GetMaximalInlineDepth() and would return 3, 2, and 1 respectively (going through an unwind) for GetInlineDepth().
        /// </summary>
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
