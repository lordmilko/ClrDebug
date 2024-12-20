namespace ClrDebug.DbgEng
{
    /// <summary>
    /// The ISvcSegmentationContext interface is (optionally) provided by execution contexts in order to translate segment selectors into flat addresses.
    /// </summary>
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

        /// <summary>
        /// Translates a selector into a given linear address description. The caller must fill in the size of the descriptor request in SizeOfDescription.<para/>
        /// The implementation must set the resulting descirption validity.
        /// </summary>
        public void TranslateSelector(SvcSegmentSelectorSource segmentSelectorSource, long selector, ref SvcSegmentDescription pDescription)
        {
            TryTranslateSelector(segmentSelectorSource, selector, ref pDescription).ThrowDbgEngNotOK();
        }

        /// <summary>
        /// Translates a selector into a given linear address description. The caller must fill in the size of the descriptor request in SizeOfDescription.<para/>
        /// The implementation must set the resulting descirption validity.
        /// </summary>
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
