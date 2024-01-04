using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("1303DEC4-FA3B-4F1B-9224-B953D16BABB5")]
    [ComImport]
    public interface IDataModelScriptTemplate
    {
        [PreserveSig]
        HRESULT GetName(
            [Out, MarshalAs(UnmanagedType.BStr)] out string templateName);
        
        [PreserveSig]
        HRESULT GetDescription(
            [Out, MarshalAs(UnmanagedType.BStr)] out string templateDescription);
        
        [PreserveSig]
        HRESULT GetContent(
            [Out, MarshalAs(UnmanagedType.Interface)] out IStream contentStream);
    }
}
