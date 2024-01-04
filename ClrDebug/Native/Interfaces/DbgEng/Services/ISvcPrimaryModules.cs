using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("04E3E600-9A10-48DF-A618-775B3E36A740")]
    [ComImport]
    public interface ISvcPrimaryModules
    {
        [PreserveSig]
        HRESULT FindExecutableModule(
            [In, MarshalAs(UnmanagedType.Interface)] ISvcProcess process,
            [Out, MarshalAs(UnmanagedType.Interface)] out ISvcModule executableModule);
    }
}
