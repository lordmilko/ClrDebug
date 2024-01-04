using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("C0D44DDA-6D7D-4B07-923C-68242BEB9E20")]
    [ComImport]
    public interface IComponentFileSourceInitializer
    {
        [PreserveSig]
        HRESULT Initialize(
            [In, MarshalAs(UnmanagedType.LPWStr)] string filePath);
    }
}
