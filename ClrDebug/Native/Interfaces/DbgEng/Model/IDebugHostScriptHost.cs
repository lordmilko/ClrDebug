using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("B70334A4-B92C-4570-93A1-D3EB686649A0")]
    [ComImport]
    public interface IDebugHostScriptHost
    {
        [PreserveSig]
        HRESULT CreateContext(
            [In, MarshalAs(UnmanagedType.Interface)] IDataModelScript script,
            [Out, MarshalAs(UnmanagedType.Interface)] out IDataModelScriptHostContext scriptContext);
    }
}
