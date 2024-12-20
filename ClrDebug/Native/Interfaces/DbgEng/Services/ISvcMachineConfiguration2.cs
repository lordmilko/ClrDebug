using System;
using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    /// <summary>
    /// Provided By: DEBUG_SERVICE_MACHINE. The ISvcMachineConfiguration interface is provided by the machine service.
    /// </summary>
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("D63778DF-FE4F-4AB8-904E-0E334E5A7CD3")]
    [ComImport]
    public interface ISvcMachineConfiguration2 : ISvcMachineConfiguration
    {
        /// <summary>
        /// Returns the archtiecture of the machine as an IMAGE_FILE_MACHINE_* constant.
        /// </summary>
        [PreserveSig]
        new int GetArchitecture();

        /// <summary>
        /// Returns the architecture of the machine as a DEBUG_ARCHDEF_* guid. This supports the notion of a custom architecture.<para/>
        /// If such is utilized, the returned GUID *MUST* also be the component aggregate for the architecture.
        /// </summary>
        [PreserveSig]
        HRESULT GetArchitectureGuid(
            [Out] out Guid architecture);
    }
}
