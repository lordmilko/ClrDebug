using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    [Guid("7FCC5FB5-49C0-41DE-9938-3B88B5B9ADD7")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [ComImport]
    public interface ICorDebugModule2
    {
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void SetJMCStatus([In] int bIsJustMyCode, [In] uint cTokens, [In] ref uint pTokens);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void ApplyChanges([In] uint cbMetadata, [In] ref byte pbMetadata, [In] uint cbIL, [In] ref byte pbIL);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void SetJITCompilerFlags([In] uint dwFlags);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void GetJITCompilerFlags(out uint pdwFlags);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void ResolveAssembly([In] uint tkAssemblyRef,
            [MarshalAs(UnmanagedType.Interface)] out ICorDebugAssembly ppAssembly);
    }
}