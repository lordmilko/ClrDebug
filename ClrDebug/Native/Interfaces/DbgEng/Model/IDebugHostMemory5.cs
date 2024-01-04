using System;
using System.Runtime.InteropServices;
using SRI = System.Runtime.InteropServices;
using ClrDebug.TypeLib;

namespace ClrDebug.DbgEng
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("DF033400-4912-46E9-BA62-6EF2EB4D87D4")]
    [ComImport]
    public interface IDebugHostMemory5 : IDebugHostMemory4
    {
        [PreserveSig]
        new HRESULT ReadBytes(
            [In, MarshalAs(UnmanagedType.Interface)] IDebugHostContext context,
            [In] Location location,
            [Out] IntPtr buffer,
            [In] long bufferSize,
            [Out] out long bytesRead);
        
        [PreserveSig]
        new HRESULT WriteBytes(
            [In, MarshalAs(UnmanagedType.Interface)] IDebugHostContext context,
            [In] Location location,
            [In] IntPtr buffer,
            [In] long bufferSize,
            [Out] out long bytesWritten);
        
        [PreserveSig]
        new HRESULT ReadPointers(
            [In, MarshalAs(UnmanagedType.Interface)] IDebugHostContext context,
            [In] Location location,
            [In] long count,
            [SRI.Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] long[] pointers);
        
        [PreserveSig]
        new HRESULT WritePointers(
            [In, MarshalAs(UnmanagedType.Interface)] IDebugHostContext context,
            [In] Location location,
            [In] long count,
            [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] long[] pointers);
        
        [PreserveSig]
        new HRESULT GetDisplayStringForLocation(
            [In, MarshalAs(UnmanagedType.Interface)] IDebugHostContext context,
            [In] Location location,
            [In, MarshalAs(UnmanagedType.U1)] bool verbose,
            [Out, MarshalAs(UnmanagedType.BStr)] out string locationName);
        
        [PreserveSig]
        new HRESULT LinearizeLocation(
            [In, MarshalAs(UnmanagedType.Interface)] IDebugHostContext context,
            [In] Location location,
            [Out] out Location pLinearizedLocation);
        
        [PreserveSig]
        new HRESULT CanonicalizeLocation(
            [In, MarshalAs(UnmanagedType.Interface)] IDebugHostContext context,
            [In] Location location,
            [Out] out Location pCanonicalizedLocation);
        
        [PreserveSig]
        new HRESULT GetPhysicalAddressLocation(
            [In] long physAddr,
            [Out] out Location pPhysicalAddressLocation);
        
        [return: MarshalAs(UnmanagedType.U1)]
        new bool IsPhysicalAddressLocation(
            [In] ref Location pLocation);
        
        [PreserveSig]
        HRESULT ReadIntrinsics(
            [In, MarshalAs(UnmanagedType.Interface)] IDebugHostContext context,
            [In] Location location,
            [In] VARENUM vt,
            [In] long count,
            [SRI.Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.Struct, SizeParamIndex = 3)] object[] vals,
            [Out] out long intrinsicsRead);
        
        [PreserveSig]
        HRESULT ReadOrdinalIntrinsics(
            [In, MarshalAs(UnmanagedType.Interface)] IDebugHostContext context,
            [In] Location location,
            [In] long ordinalSize,
            [In, MarshalAs(UnmanagedType.U1)] bool ordinalIsSigned,
            [In] long count,
            [SRI.Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.Struct, SizeParamIndex = 4)] object[] vals,
            [Out] out long intrinsicsRead);
    }
}
