using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("B349ABE3-B56F-4689-BFCD-76BF39D888EA")]
    [ComImport]
    public interface ICLRProfiling
    {
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT AttachProfiler(
            [In] uint dwProfileeProcessID,
            [In] uint dwMillisecondsMax,
            [In] ref Guid pClsidProfiler,
            [MarshalAs(UnmanagedType.LPWStr), In] string wszProfilerPath,
            [In] IntPtr pvClientData,
            [In] uint cbClientData);
    }
}