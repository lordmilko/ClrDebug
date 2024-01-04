using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("5DBA6ACF-1E01-400D-B164-838034F71ACE")]
    [ComImport]
    public interface IDebugDataModelScripting
    {
        [PreserveSig]
        HRESULT GetProviders(
            [MarshalAs(UnmanagedType.Interface), In] IDebugOutputStream stream);

        [PreserveSig]
        HRESULT GetScriptTemplateContent(
            [MarshalAs(UnmanagedType.LPWStr), In] string scriptExtension,
            [MarshalAs(UnmanagedType.LPWStr), In] string templateName,
            [MarshalAs(UnmanagedType.Interface), In] IDebugOutputStream templateContent);

        [PreserveSig]
        HRESULT CreateScript(
            [MarshalAs(UnmanagedType.LPWStr), In] string scriptExtension,
            [MarshalAs(UnmanagedType.Interface), Out] out IDebugDataModelScriptReference scriptReference);
    }
}
