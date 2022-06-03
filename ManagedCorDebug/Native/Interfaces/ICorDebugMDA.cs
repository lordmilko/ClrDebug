using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;

namespace ManagedCorDebug
{
    [Guid("CC726F2F-1DB7-459B-B0EC-05F01D841B42")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [ComImport]
    public interface ICorDebugMDA
    {
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT GetName([In] uint cchName, out uint pcchName, [MarshalAs(UnmanagedType.Interface), Out]
            StringBuilder szName);

        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT GetDescription([In] uint cchName, out uint pcchName, [MarshalAs(UnmanagedType.Interface), Out]
            StringBuilder szName);

        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT GetXML([In] uint cchName, out uint pcchName, [MarshalAs(UnmanagedType.Interface), Out]
            StringBuilder szName);

        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT GetFlags([In] ref CorDebugMDAFlags pFlags);

        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT GetOSThreadId(out uint pOsTid);
    }
}