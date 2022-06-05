using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;

namespace ManagedCorDebug
{
    /// <summary>
    /// ICorDebugEditAndContinueErrorInfo is obsolete. Do not use this interface.
    /// </summary>
    [Guid("8D600D41-F4F6-4CB3-B7EC-7BD164944036")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [ComImport]
    public interface ICorDebugEditAndContinueErrorInfo
    {
        /// <summary>
        /// GetModule is obsolete. Do not call this method.
        /// </summary>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT GetModule([MarshalAs(UnmanagedType.Interface)] out ICorDebugModule ppModule);

        /// <summary>
        /// GetToken is obsolete. Do not call this method.
        /// </summary>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT GetToken(out uint pToken);

        /// <summary>
        /// GetErrorCode is obsolete. Do not call this method.
        /// </summary>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT GetErrorCode([MarshalAs(UnmanagedType.Error)] out int pHr);

        /// <summary>
        /// GetString is obsolete. Do not call this method.
        /// </summary>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT GetString([In] uint cchString, out uint pcchString, [Out] StringBuilder szString);
    }
}