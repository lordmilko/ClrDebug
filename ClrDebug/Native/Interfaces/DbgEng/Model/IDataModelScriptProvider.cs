using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("513461E0-4FCA-48CE-8658-32F3E2056F3B")]
    [ComImport]
    public interface IDataModelScriptProvider
    {
        [PreserveSig]
        HRESULT GetName(
            [Out, MarshalAs(UnmanagedType.BStr)] out string name);
        
        [PreserveSig]
        HRESULT GetExtension(
            [Out, MarshalAs(UnmanagedType.BStr)] out string extension);
        
        [PreserveSig]
        HRESULT CreateScript(
            [Out, MarshalAs(UnmanagedType.Interface)] out IDataModelScript script);
        
        [PreserveSig]
        HRESULT GetDefaultTemplateContent(
            [Out, MarshalAs(UnmanagedType.Interface)] out IDataModelScriptTemplate templateContent);
        
        [PreserveSig]
        HRESULT EnumerateTemplates(
            [Out, MarshalAs(UnmanagedType.Interface)] out IDataModelScriptTemplateEnumerator enumerator);
    }
}
