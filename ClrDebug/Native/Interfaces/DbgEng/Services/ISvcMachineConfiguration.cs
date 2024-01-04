using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("2F5A6E6F-23F1-47D9-9DCF-A359B51AAAB0")]
    [ComImport]
    public interface ISvcMachineConfiguration
    {
        [PreserveSig]
        int GetArchitecture();
    }
}
