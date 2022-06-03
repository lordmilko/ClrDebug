using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("0C733A30-2A1C-11CE-ADE5-00AA0044773D")]
    [ComImport]
    public interface ISequentialStream
    {
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT RemoteRead(out byte pv, [In] uint cb, out uint pcbRead);

        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT RemoteWrite([In] ref byte pv, [In] uint cb, out uint pcbWritten);
    }
}