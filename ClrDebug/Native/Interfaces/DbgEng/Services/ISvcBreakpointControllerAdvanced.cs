using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("F1A32D9A-922A-41B6-ADFF-AC363BB982D5")]
    [ComImport]
    public interface ISvcBreakpointControllerAdvanced
    {
        [return: MarshalAs(UnmanagedType.U1)]
        bool DoesBreakpointTrapAddressReflectHardware();
    }
}
