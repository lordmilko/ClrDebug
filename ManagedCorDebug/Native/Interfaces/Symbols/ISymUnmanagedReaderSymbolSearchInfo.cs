using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("20D9645D-03CD-4E34-9C11-9848A5B084F1")]
    [ComImport]
    public interface ISymUnmanagedReaderSymbolSearchInfo
    {
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void GetSymbolSearchInfoCount(out uint pcSearchInfo);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void GetSymbolSearchInfo(
            [In] uint cSearchInfo,
            out uint pcSearchInfo,
            [MarshalAs(UnmanagedType.Interface)] out ISymUnmanagedSymbolSearchInfo rgpSearchInfo);
    }
}