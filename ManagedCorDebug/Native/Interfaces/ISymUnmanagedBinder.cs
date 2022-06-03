using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    [Guid("AA544D42-28CB-11D3-BD22-0000F80849BD")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [ComImport]
    public interface ISymUnmanagedBinder
    {
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        [return: MarshalAs(UnmanagedType.Interface)]
        ISymUnmanagedReader GetReaderForFile(
            [MarshalAs(UnmanagedType.IUnknown), In]
            object importer,
            [In] ref ushort filename,
            [In] ref ushort searchPath);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        [return: MarshalAs(UnmanagedType.Interface)]
        ISymUnmanagedReader GetReaderFromStream([MarshalAs(UnmanagedType.IUnknown), In]
            object importer, [MarshalAs(UnmanagedType.Interface), In]
            IStream pstream);
    }
}