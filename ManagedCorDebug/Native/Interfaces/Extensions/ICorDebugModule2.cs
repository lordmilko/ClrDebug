using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    [Guid("7FCC5FB5-49C0-41DE-9938-3B88B5B9ADD7")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [ComImport]
    public interface ICorDebugModule2
    {
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT SetJMCStatus([In] int bIsJustMyCode, [In] uint cTokens, [In] ref uint pTokens);

        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT ApplyChanges([In] uint cbMetadata, [In] ref byte pbMetadata, [In] uint cbIL, [In] ref byte pbIL);

        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT SetJITCompilerFlags([In] uint dwFlags);

        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT GetJITCompilerFlags(out uint pdwFlags);

        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT ResolveAssembly([In] uint tkAssemblyRef,
            [MarshalAs(UnmanagedType.Interface)] out ICorDebugAssembly ppAssembly);
    }
}