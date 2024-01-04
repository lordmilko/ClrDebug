using System;
using System.Runtime.InteropServices;
using SRI = System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("FE6B3658-DA4B-44E3-8A58-6201322280E6")]
    [ComImport]
    public interface IDebugHostMemory4 : IDebugHostMemory3
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
        HRESULT GetPhysicalAddressLocation(
            [In] long physAddr,
            [Out] out Location pPhysicalAddressLocation);
        
        [return: MarshalAs(UnmanagedType.U1)]
        bool IsPhysicalAddressLocation(
            [In] ref Location pLocation);
    }
}
