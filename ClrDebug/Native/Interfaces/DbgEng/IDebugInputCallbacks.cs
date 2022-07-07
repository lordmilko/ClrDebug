using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("9f50e42c-f136-499e-9a97-73036c94ed2d")]
    [ComImport]
    public interface IDebugInputCallbacks
    {
        [PreserveSig]
        HRESULT StartInput(
            [In] int bufferSize);

        [PreserveSig]
        HRESULT EndInput();
    }
}
