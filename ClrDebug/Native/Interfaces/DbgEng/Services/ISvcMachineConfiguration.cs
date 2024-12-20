using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    /// <summary>
    /// Provided By: DEBUG_SERVICE_MACHINE (always). The ISvcMachineConfiguration interface is provided by the machine service.
    /// </summary>
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("2F5A6E6F-23F1-47D9-9DCF-A359B51AAAB0")]
    [ComImport]
    public interface ISvcMachineConfiguration
    {
        /// <summary>
        /// Returns the archtiecture of the machine as an IMAGE_FILE_MACHINE_* constant.
        /// </summary>
        [PreserveSig]
        int GetArchitecture();
    }
}
