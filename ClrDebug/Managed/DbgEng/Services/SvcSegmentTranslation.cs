namespace ClrDebug.DbgEng
{
    public class SvcSegmentTranslation : ComObject<ISvcSegmentTranslation>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SvcSegmentTranslation"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
        public SvcSegmentTranslation(ISvcSegmentTranslation raw) : base(raw)
        {
        }

        #region ISvcSegmentTranslation
        #region TranslateSelector

        public void TranslateSelector(SvcSegmentSelectorSource segmentSelectorSource, long selector, ref SvcSegmentDescription pDescription)
        {
            TryTranslateSelector(segmentSelectorSource, selector, ref pDescription).ThrowDbgEngNotOK();
        }

        public HRESULT TryTranslateSelector(SvcSegmentSelectorSource segmentSelectorSource, long selector, ref SvcSegmentDescription pDescription)
        {
            /*HRESULT TranslateSelector(
            [In] SvcSegmentSelectorSource segmentSelectorSource,
            [In] long selector,
            [In, Out] ref SvcSegmentDescription pDescription);*/
            return Raw.TranslateSelector(segmentSelectorSource, selector, ref pDescription);
        }

        #endregion
        #endregion
    }
}
