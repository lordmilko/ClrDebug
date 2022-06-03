using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;

namespace ManagedCorDebug
{
    [Guid("F8B3534A-A46B-4980-B520-BEC4ACEABA8F")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [ComImport]
    public interface ISymUnmanagedSymbolSearchInfo
    {
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT GetSearchPathLength(out uint pcchPath);

        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT GetSearchPath([In] uint cchPath, out uint pcchPath, [MarshalAs(UnmanagedType.Interface), Out]
            StringBuilder szPath);

        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT GetHRESULT([MarshalAs(UnmanagedType.Error)] out int phr);
    }
}