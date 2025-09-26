using System;
using System.Runtime.InteropServices;
#if GENERATED_MARSHALLING
using System.Runtime.InteropServices.Marshalling;
#endif

namespace ClrDebug.DbgEng
{
    /// <summary>
    /// Provided By: DEBUG_SERVICE_MACHINE. The ISvcMachineConfiguration interface is provided by the machine service.
    /// </summary>
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("D63778DF-FE4F-4AB8-904E-0E334E5A7CD3")]
#if !GENERATED_MARSHALLING
    [ComImport]
#else
    [GeneratedComInterface]
#endif
    public partial interface ISvcMachineConfiguration2 : ISvcMachineConfiguration
    {
#if !GENERATED_MARSHALLING
        /// <summary>
        /// Returns the archtiecture of the machine as an IMAGE_FILE_MACHINE_* constant.
        /// </summary>
        [PreserveSig]
        new int GetArchitecture();
#endif

        /// <summary>
        /// Returns the architecture of the machine as a DEBUG_ARCHDEF_* guid. This supports the notion of a custom architecture.<para/>
        /// If such is utilized, the returned GUID *MUST* also be the component aggregate for the architecture.
        /// </summary>
        [PreserveSig]
        HRESULT GetArchitectureGuid(
            [Out]
#if GENERATED_MARSHALLING
            [MarshalUsing(typeof(GuidMarshaller))]
#endif
            out Guid architecture);
    }
}
