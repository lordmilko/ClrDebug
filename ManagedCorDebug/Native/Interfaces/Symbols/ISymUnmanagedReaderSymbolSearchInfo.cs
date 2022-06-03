using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("20D9645D-03CD-4E34-9C11-9848A5B084F1")]
    [ComImport]
    public interface ISymUnmanagedReaderSymbolSearchInfo
    {
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT GetSymbolSearchInfoCount(out uint pcSearchInfo);

        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT GetSymbolSearchInfo(
            [In] uint cSearchInfo,
            out uint pcSearchInfo,
            [MarshalAs(UnmanagedType.Interface)] out ISymUnmanagedSymbolSearchInfo rgpSearchInfo);
    }
}