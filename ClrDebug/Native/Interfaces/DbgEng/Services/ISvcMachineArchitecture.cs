using System;
using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("C9CD3D26-2A2D-4E14-99CD-2196F08C921A")]
    [ComImport]
    public interface ISvcMachineArchitecture
    {
        [PreserveSig]
        int GetArchitecture();
        
        [PreserveSig]
        HRESULT GetArchitectureGuid(
            [Out] out Guid architecture);
        
        [PreserveSig]
        long GetBitness();
        
        [PreserveSig]
        long GetPageSize();
        
        [PreserveSig]
        long GetPageShift();
        
        [PreserveSig]
        HRESULT EnumerateRegisters(
            [In] SvcContextFlags flags,
            [Out, MarshalAs(UnmanagedType.Interface)] out ISvcRegisterEnumerator registerEnumerator);
        
        [PreserveSig]
        HRESULT GetRegisterInformation(
            [In] int registerId,
            [Out, MarshalAs(UnmanagedType.Interface)] out ISvcRegisterInformation registerInformation);
        
        [PreserveSig]
        HRESULT GetIdForAbstractRegister(
            [In] SvcAbstractRegister abstractId,
            [Out] out int canonicalId);
        
        [PreserveSig]
        HRESULT CreateRegisterContext(
            [Out, MarshalAs(UnmanagedType.Interface)] out ISvcRegisterContext ppArchRegisterContext);
        
        [PreserveSig]
        long GetDirectoryBase(
            [In] DirectoryBaseKind dirKind,
            [In, MarshalAs(UnmanagedType.Interface)] ISvcRegisterContext pSpecialContext);
        
        [PreserveSig]
        int GetPagingLevels(
            [In, MarshalAs(UnmanagedType.Interface)] ISvcRegisterContext pSpecialContext);
    }
}
