using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;

namespace ManagedCorDebug
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("BD39D1D2-BA2F-486A-89B0-B4B0CB466891")]
    [ComImport]
    public interface ICLRRuntimeInfo
    {
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT GetVersionString([MarshalAs(UnmanagedType.LPWStr), Out]
            StringBuilder pwzBuffer, [In] [Out] ref uint pcchBuffer);

        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT GetRuntimeDirectory([MarshalAs(UnmanagedType.LPWStr), Out]
            StringBuilder pwzBuffer, [In] [Out] ref uint pcchBuffer);

        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT IsLoaded([In] IntPtr hndProcess);

        [PreserveSig]
        [LCIDConversion(3)]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT LoadErrorString([In] uint iResourceID, [MarshalAs(UnmanagedType.LPWStr), Out]
            StringBuilder pwzBuffer, [In] [Out] ref uint pcchBuffer);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        IntPtr LoadLibrary([MarshalAs(UnmanagedType.LPWStr), In] string pwzDllName);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        IntPtr GetProcAddress([MarshalAs(UnmanagedType.LPStr), In] string pszProcName);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        [return: MarshalAs(UnmanagedType.IUnknown)]
        object GetInterface([In] ref Guid rclsid, [In] ref Guid riid);

        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT IsLoadable();

        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT SetDefaultStartupFlags([In] uint dwStartupFlags,
            [MarshalAs(UnmanagedType.LPWStr), In] string pwzHostConfigFile);

        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT GetDefaultStartupFlags(
            out uint pdwStartupFlags,
            [MarshalAs(UnmanagedType.LPWStr), Out]
            StringBuilder pwzHostConfigFile,
            [In] [Out] ref uint pcchHostConfigFile);

        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT BindAsLegacyV2Runtime();

        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT IsStarted(out int pbStarted, out uint pdwStartupFlags);
    }
}