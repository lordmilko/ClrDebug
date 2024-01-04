using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("36A82767-6ED1-4E47-A7A7-D517A8691534")]
    [ComImport]
    public interface IComponentStackUnwindContextInitializer
    {
        [PreserveSig]
        HRESULT Initialize(
            [In, MarshalAs(UnmanagedType.Interface)] ISvcProcess unwindProcess,
            [In, MarshalAs(UnmanagedType.Interface)] ISvcThread unwindThread);
    }
}
