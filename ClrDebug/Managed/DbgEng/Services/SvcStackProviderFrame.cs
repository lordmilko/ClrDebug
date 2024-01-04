namespace ClrDebug.DbgEng
{
    public class SvcStackProviderFrame : ComObject<ISvcStackProviderFrame>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SvcStackProviderFrame"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
        public SvcStackProviderFrame(ISvcStackProviderFrame raw) : base(raw)
        {
        }

        #region ISvcStackProviderFrame
        #region FrameKind

        public StackProviderFrameKind FrameKind
        {
            get
            {
                /*StackProviderFrameKind GetFrameKind();*/
                return Raw.GetFrameKind();
            }
        }

        #endregion
        #endregion
    }
}
