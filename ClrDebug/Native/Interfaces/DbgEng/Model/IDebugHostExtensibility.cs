using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("3C2B24E1-11D0-4F86-8AE5-4DF166F73253")]
    [ComImport]
    public interface IDebugHostExtensibility
    {
        [PreserveSig]
        HRESULT CreateFunctionAlias(
            [In, MarshalAs(UnmanagedType.LPWStr)] string aliasName,
            [In, MarshalAs(UnmanagedType.Interface)] IModelObject functionObject);
        
        [PreserveSig]
        HRESULT DestroyFunctionAlias(
            [In, MarshalAs(UnmanagedType.LPWStr)] string aliasName);
    }
}
