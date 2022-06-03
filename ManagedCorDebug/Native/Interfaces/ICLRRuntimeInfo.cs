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
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void GetVersionString([MarshalAs(UnmanagedType.LPWStr), Out]
            StringBuilder pwzBuffer, [In] [Out] ref uint pcchBuffer);

        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        int GetRuntimeDirectory([MarshalAs(UnmanagedType.LPWStr), Out]
            StringBuilder pwzBuffer, [In] [Out] ref uint pcchBuffer);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        int IsLoaded([In] IntPtr hndProcess);

        [LCIDConversion(3)]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void LoadErrorString([In] uint iResourceID, [MarshalAs(UnmanagedType.LPWStr), Out]
            StringBuilder pwzBuffer, [In] [Out] ref uint pcchBuffer);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        IntPtr LoadLibrary([MarshalAs(UnmanagedType.LPWStr), In] string pwzDllName);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        IntPtr GetProcAddress([MarshalAs(UnmanagedType.LPStr), In] string pszProcName);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        [return: MarshalAs(UnmanagedType.IUnknown)]
        object GetInterface([In] ref Guid rclsid, [In] ref Guid riid);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        int IsLoadable();

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void SetDefaultStartupFlags([In] uint dwStartupFlags,
            [MarshalAs(UnmanagedType.LPWStr), In] string pwzHostConfigFile);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void GetDefaultStartupFlags(
            out uint pdwStartupFlags,
            [MarshalAs(UnmanagedType.LPWStr), Out]
            StringBuilder pwzHostConfigFile,
            [In] [Out] ref uint pcchHostConfigFile);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void BindAsLegacyV2Runtime();

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void IsStarted(out int pbStarted, out uint pdwStartupFlags);
    }
}