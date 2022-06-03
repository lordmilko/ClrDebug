using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;

namespace ManagedCorDebug
{
    public delegate void RuntimeLoadedCallback(
        [MarshalAs(UnmanagedType.Interface)] ICLRRuntimeInfo pRuntimeInfo,
        [MarshalAs(UnmanagedType.FunctionPtr)] CallbackThreadSet pfnCallbackThreadSet,
        [MarshalAs(UnmanagedType.FunctionPtr)] CallbackThreadUnset pfnCallbackThreadUnset
    );

    public delegate void CallbackThreadSet();

    public delegate void CallbackThreadUnset();

    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("D332DB9E-B9B3-4125-8207-A14884F53216")]
    [ComImport]
    public interface ICLRMetaHost
    {
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT GetRuntime([MarshalAs(UnmanagedType.LPWStr), In] string pwzVersion, [In] ref Guid riid, [Out] out object ppRuntime);

        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT GetVersionFromFile([MarshalAs(UnmanagedType.LPWStr), In] string pwzFilePath,
            [MarshalAs(UnmanagedType.LPWStr), Out]
            StringBuilder pwzBuffer, [In] [Out] ref uint pcchBuffer);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        [return: MarshalAs(UnmanagedType.Interface)]
        IEnumUnknown EnumerateInstalledRuntimes();

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        [return: MarshalAs(UnmanagedType.Interface)]
        IEnumUnknown EnumerateLoadedRuntimes([In] IntPtr hndProcess);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void RequestRuntimeLoadedNotification([MarshalAs(UnmanagedType.FunctionPtr), In]
            RuntimeLoadedCallback pCallbackFunction);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        IntPtr QueryLegacyV2RuntimeBinding([In] ref Guid riid);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void ExitProcess([In] int iExitCode);
    }
}