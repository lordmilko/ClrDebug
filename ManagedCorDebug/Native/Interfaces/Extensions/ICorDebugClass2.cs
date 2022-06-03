using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    [Guid("B008EA8D-7AB1-43F7-BB20-FBB5A04038AE")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [ComImport]
    public interface ICorDebugClass2
    {
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void GetParameterizedType(
            [In] uint elementType,
            [In] uint nTypeArgs,
            [MarshalAs(UnmanagedType.Interface), In]
            ref ICorDebugType ppTypeArgs,
            [MarshalAs(UnmanagedType.Interface)] out ICorDebugType ppType);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void SetJMCStatus([In] int bIsJustMyCode);
    }
}