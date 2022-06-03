using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    [Guid("F8B3534A-A46B-4980-B520-BEC4ACEABA8F")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [ComImport]
    public interface ISymUnmanagedSymbolSearchInfo
    {
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void GetSearchPathLength(out uint pcchPath);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void GetSearchPath([In] uint cchPath, out uint pcchPath, [MarshalAs(UnmanagedType.Interface), Out]
            ISymUnmanagedSymbolSearchInfo szPath);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void GetHRESULT([MarshalAs(UnmanagedType.Error)] out int phr);
    }
}