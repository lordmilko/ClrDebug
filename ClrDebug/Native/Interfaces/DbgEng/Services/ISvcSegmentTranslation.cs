using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("4C1BEC33-1B39-4708-AB0A-C8AE0E9DDB3E")]
    [ComImport]
    public interface ISvcSegmentTranslation
    {
        [PreserveSig]
        HRESULT TranslateSelector(
            [In] SvcSegmentSelectorSource segmentSelectorSource,
            [In] long selector,
            [In, Out] ref SvcSegmentDescription pDescription);
    }
}
