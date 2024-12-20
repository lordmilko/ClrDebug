using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    /// <summary>
    /// The ISvcSegmentationContext interface is (optionally) provided by execution contexts in order to translate segment selectors into flat addresses.
    /// </summary>
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("4C1BEC33-1B39-4708-AB0A-C8AE0E9DDB3E")]
    [ComImport]
    public interface ISvcSegmentTranslation
    {
        /// <summary>
        /// Translates a selector into a given linear address description. The caller must fill in the size of the descriptor request in SizeOfDescription.<para/>
        /// The implementation must set the resulting descirption validity.
        /// </summary>
        [PreserveSig]
        HRESULT TranslateSelector(
            [In] SvcSegmentSelectorSource segmentSelectorSource,
            [In] long selector,
            [In, Out] ref SvcSegmentDescription pDescription);
    }
}
