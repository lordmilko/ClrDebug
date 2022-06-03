using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    [Guid("8D600D41-F4F6-4CB3-B7EC-7BD164944036")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [ComImport]
    public interface ICorDebugEditAndContinueErrorInfo
    {
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void GetModule([MarshalAs(UnmanagedType.Interface)] out ICorDebugModule ppModule);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void GetToken(out uint pToken);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void GetErrorCode([MarshalAs(UnmanagedType.Error)] out int pHr);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void GetString([In] uint cchString, out uint pcchString, [MarshalAs(UnmanagedType.Interface), Out]
            ICorDebugEditAndContinueErrorInfo szString);
    }
}