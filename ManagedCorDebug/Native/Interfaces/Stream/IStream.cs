using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    [Guid("0000000C-0000-0000-C000-000000000046")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [ComImport]
    public interface IStream : ISequentialStream
    {
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        new HRESULT RemoteRead(out byte pv, [In] uint cb, out uint pcbRead);

        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        new HRESULT RemoteWrite([In] ref byte pv, [In] uint cb, out uint pcbWritten);

        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT RemoteSeek([In] LARGE_INTEGER dlibMove, [In] uint dwOrigin, out ULARGE_INTEGER plibNewPosition);

        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT SetSize([In] ULARGE_INTEGER libNewSize);

        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT RemoteCopyTo(
            [MarshalAs(UnmanagedType.Interface), In]
            IStream pstm,
            [In] ULARGE_INTEGER cb,
            out ULARGE_INTEGER pcbRead,
            out ULARGE_INTEGER pcbWritten);

        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT Commit([In] uint grfCommitFlags);

        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT Revert();

        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT LockRegion([In] ULARGE_INTEGER libOffset, [In] ULARGE_INTEGER cb, [In] uint dwLockType);

        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT UnlockRegion([In] ULARGE_INTEGER libOffset, [In] ULARGE_INTEGER cb, [In] uint dwLockType);

        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT Stat(out tagSTATSTG pstatstg, [In] uint grfStatFlag);

        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT Clone([MarshalAs(UnmanagedType.Interface)] out IStream ppstm);
    }
}