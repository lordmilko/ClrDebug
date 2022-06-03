using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("D05E60C3-848C-4E7D-894E-623320FF6AFA")]
    [ComImport]
    public interface ICorDebugDataTarget3
    {
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT GetLoadedModules(
            [In] uint cRequestedModules,
            out uint pcFetchedModules,
            [Out] IntPtr pLoadedModules); //ICorDebugLoadedModule
    }
}