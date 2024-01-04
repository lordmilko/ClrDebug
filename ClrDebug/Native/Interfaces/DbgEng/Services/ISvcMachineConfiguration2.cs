using System;
using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("D63778DF-FE4F-4AB8-904E-0E334E5A7CD3")]
    [ComImport]
    public interface ISvcMachineConfiguration2 : ISvcMachineConfiguration
    {
        [PreserveSig]
        new int GetArchitecture();
        
        [PreserveSig]
        HRESULT GetArchitectureGuid(
            [Out] out Guid architecture);
    }
}
