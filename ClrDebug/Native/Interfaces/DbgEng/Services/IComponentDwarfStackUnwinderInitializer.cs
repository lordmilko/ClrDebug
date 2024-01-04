using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("93ABD785-449B-4C64-931D-A2D5B2488205")]
    [ComImport]
    public interface IComponentDwarfStackUnwinderInitializer
    {
        [PreserveSig]
        HRESULT Initialize(
            [In, MarshalAs(UnmanagedType.Interface)] ISvcStackFrameUnwind pSecondaryUnwinder);
    }
}
