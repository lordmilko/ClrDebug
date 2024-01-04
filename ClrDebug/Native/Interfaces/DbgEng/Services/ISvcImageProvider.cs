using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("76D4EDDF-282E-4381-8389-6FA9EEB067C2")]
    [ComImport]
    public interface ISvcImageProvider
    {
        [PreserveSig]
        HRESULT LocateImage(
            [In, MarshalAs(UnmanagedType.Interface)] ISvcModule image,
            [Out, MarshalAs(UnmanagedType.Interface)] out ISvcDebugSourceFile ppFile);
    }
}
