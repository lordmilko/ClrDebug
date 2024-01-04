using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("D492514F-7CFE-4876-96AC-7FAB627895AB")]
    [ComImport]
    public interface ISvcEventArgumentsModuleDiscovery
    {
        [PreserveSig]
        HRESULT GetModule(
            [Out, MarshalAs(UnmanagedType.Interface)] out ISvcModule module);
    }
}
