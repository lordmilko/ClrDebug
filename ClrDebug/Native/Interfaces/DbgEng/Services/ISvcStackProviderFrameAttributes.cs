using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("96CE81F7-C6B9-4665-B2E5-6EB229079091")]
    [ComImport]
    public interface ISvcStackProviderFrameAttributes
    {
        [PreserveSig]
        HRESULT GetFrameText(
            [Out, MarshalAs(UnmanagedType.BStr)] out string frameText);
        
        [PreserveSig]
        HRESULT GetSourceAssociation(
            [Out, MarshalAs(UnmanagedType.BStr)] out string sourceFile,
            [Out] out long sourceLine,
            [Out] out long sourceColumn);
    }
}
