using System;
using System.Runtime.InteropServices;
using SRI = System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("EEA033DE-38F6-416B-A251-1D3771001270")]
    [ComImport]
    public interface IDebugHostMemory2 : IDebugHostMemory
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
        HRESULT LinearizeLocation(
            [In, MarshalAs(UnmanagedType.Interface)] IDebugHostContext context,
            [In] Location location,
            [Out] out Location pLinearizedLocation);
    }
}
