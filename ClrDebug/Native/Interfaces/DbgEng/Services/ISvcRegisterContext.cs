using System;
using System.Runtime.InteropServices;
using SRI = System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("CA1AFE05-244C-4FA3-BED4-A355418587EF")]
    [ComImport]
    public interface ISvcRegisterContext
    {
        [PreserveSig]
        HRESULT GetArchitectureGuid(
            [Out] out Guid architecture);
        
        [PreserveSig]
        HRESULT GetRegisterValue(
            [In] int registerId,
            [Out] IntPtr buffer,
            [In] int bufferSize,
            [Out] out int registerSize);
        
        [PreserveSig]
        HRESULT GetRegisterValue64(
            [In] int registerId,
            [Out] out long pRegisterValue);
        
        [PreserveSig]
        HRESULT GetAbstractRegisterValue64(
            [In] SvcAbstractRegister abstractId,
            [Out] out long pRegisterValue);
        
        [PreserveSig]
        HRESULT SetRegisterValue(
            [In] int registerId,
            [In] IntPtr buffer,
            [In] int bufferSize,
            [Out] out int registerSize);
        
        [PreserveSig]
        HRESULT SetRegisterValue64(
            [In] int registerId,
            [In] long registerValue);
        
        [PreserveSig]
        HRESULT SetAbstractRegisterValue64(
            [In] SvcAbstractRegister abstractId,
            [In] long registerValue);
        
        [PreserveSig]
        HRESULT GetRegisterValues(
            [In] int registerCount,
            [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] RegisterInformationQuery[] pRegisters,
            [In] int bufferSize,
            [Out] IntPtr buffer,
            [SRI.Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] int[] registerSizes);
        
        [PreserveSig]
        HRESULT SetRegisterValues(
            [In] int registerCount,
            [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] RegisterInformationQuery[] pRegisters,
            [In] int bufferSize,
            [In] IntPtr buffer,
            [SRI.Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] int[] registerSizes);
        
        [PreserveSig]
        HRESULT SetToContext(
            [In, MarshalAs(UnmanagedType.Interface)] ISvcRegisterContext registerContext);
        
        [PreserveSig]
        HRESULT Duplicate(
            [Out, MarshalAs(UnmanagedType.Interface)] out ISvcRegisterContext duplicateContext);
    }
}
