using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("8983F680-8031-4BBC-9F67-BBB206058FAB")]
    [ComImport]
    public interface ISvcEventArgumentsSourceMappingsChanged
    {
        [PreserveSig]
        HRESULT GetModule(
            [Out, MarshalAs(UnmanagedType.Interface)] out ISvcModule module);
    }
}
