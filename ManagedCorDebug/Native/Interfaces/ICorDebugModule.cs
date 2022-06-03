using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;

namespace ManagedCorDebug
{
    [Guid("DBA2D8C1-E5C5-4069-8C13-10A7C6ABF43D")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [ComImport]
    public interface ICorDebugModule
    {
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT GetProcess([MarshalAs(UnmanagedType.Interface)] out ICorDebugProcess ppProcess);

        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT GetBaseAddress(out ulong pAddress);

        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT GetAssembly([MarshalAs(UnmanagedType.Interface)] out ICorDebugAssembly ppAssembly);

        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT GetName([In] uint cchName, out uint pcchName, [MarshalAs(UnmanagedType.LPWStr), Out] StringBuilder szName);

        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT EnableJITDebugging([In] int bTrackJITInfo, [In] int bAllowJitOpts);

        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT EnableClassLoadCallbacks([In] int bClassLoadCallbacks);

        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT GetFunctionFromToken([In] uint methodDef,
            [MarshalAs(UnmanagedType.Interface)] out ICorDebugFunction ppFunction);

        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT GetFunctionFromRVA([In] ulong rva, [MarshalAs(UnmanagedType.Interface)] out ICorDebugFunction ppFunction);

        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT GetClassFromToken([In] uint typeDef, [MarshalAs(UnmanagedType.Interface)] out ICorDebugClass ppClass);

        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT CreateBreakpoint([MarshalAs(UnmanagedType.Interface)] out ICorDebugModuleBreakpoint ppBreakpoint);

        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT GetEditAndContinueSnapshot(
            [MarshalAs(UnmanagedType.Interface)] out ICorDebugEditAndContinueSnapshot ppEditAndContinueSnapshot);

        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT GetMetaDataInterface([In] ref Guid riid, [MarshalAs(UnmanagedType.IUnknown)] out object ppObj);

        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT GetToken(out uint pToken);

        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT IsDynamic(out int pDynamic);

        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT GetGlobalVariableValue([In] uint fieldDef,
            [MarshalAs(UnmanagedType.Interface)] out ICorDebugValue ppValue);

        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT GetSize(out uint pcBytes);

        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT IsInMemory(out int pInMemory);
    }
}