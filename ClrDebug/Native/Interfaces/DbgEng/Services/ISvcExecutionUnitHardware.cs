using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("F272C72D-E794-498F-B169-2F74B38A2DAE")]
    [ComImport]
    public interface ISvcExecutionUnitHardware
    {
        [PreserveSig]
        HRESULT GetSpecialContext(
            [Out, MarshalAs(UnmanagedType.Interface)] out ISvcRegisterContext specialContext);

        /// <summary>
        /// Gets the processor number assigned to this execution unit. Calling ISvcMachineDebug::GetProcessor with this number should get back to the same execution unit.
        /// </summary>
        [PreserveSig]
        long GetProcessorNumber();
    }
}
