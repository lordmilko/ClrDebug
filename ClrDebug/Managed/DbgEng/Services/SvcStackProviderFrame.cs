namespace ClrDebug.DbgEng
{
    /// <summary>
    /// Represents a single frame from a stack provider. The base interface only provides detection of the frame kind. Other interfaces may be required depending on the frame type.<para/>
    /// Some interfaces are optional for any type of stack frame.
    /// </summary>
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

        /// <summary>
        /// Gets the kind of stack frame that this ISvcStackProviderFrame represents.
        /// </summary>
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
