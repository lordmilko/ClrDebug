using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("2F2F8A27-B2FB-491A-B86F-5A4232F1EB23")]
    [ComImport]
    public interface ISvcBreakpointControllerAdvanced2 : ISvcBreakpointControllerAdvanced
    {
        [return: MarshalAs(UnmanagedType.U1)]
        new bool DoesBreakpointTrapAddressReflectHardware();
        
        [PreserveSig]
        HRESULT GetSoftwareBreakpointAddressDelta(
            [Out] out long pByteCountPastInstruction);
    }
}
