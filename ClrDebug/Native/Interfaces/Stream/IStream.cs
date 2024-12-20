using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
#if GENERATED_MARSHALLING
using System.Runtime.InteropServices.Marshalling;
#endif

namespace ClrDebug
{
    [Guid("0000000C-0000-0000-C000-000000000046")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
#if !GENERATED_MARSHALLING
    [ComImport]
#else
    [GeneratedComInterface]
#endif
    public partial interface IStream : ISequentialStream
    {
#if !GENERATED_MARSHALLING
        [PreserveSig]
        new HRESULT Read(
            [Out] IntPtr pv,
            [In] int cb,
            [Out] out int pcbRead);

        [PreserveSig]
        new HRESULT Write(
            [In] IntPtr pv,
            [In] int cb,
            [Out] out int pcbWritten);
#endif

        [PreserveSig]
        HRESULT Seek(
            [In] LARGE_INTEGER dlibMove,
            [In] STREAM_SEEK dwOrigin,
            [Out] out ULARGE_INTEGER plibNewPosition);

        [PreserveSig]
        HRESULT SetSize(
            [In] ULARGE_INTEGER libNewSize);

        [PreserveSig]
        HRESULT CopyTo(
            [MarshalAs(UnmanagedType.Interface), In] IStream pstm,
            [In] ULARGE_INTEGER cb,
            [Out] out ULARGE_INTEGER pcbRead,
            [Out] out ULARGE_INTEGER pcbWritten);

        [PreserveSig]
        HRESULT Commit(
            [In] STGC grfCommitFlags);

        [PreserveSig]
        HRESULT Revert();

        [PreserveSig]
        HRESULT LockRegion(
            [In] ULARGE_INTEGER libOffset,
            [In] ULARGE_INTEGER cb,
            [In] int dwLockType);

        [PreserveSig]
        HRESULT UnlockRegion(
            [In] ULARGE_INTEGER libOffset,
            [In] ULARGE_INTEGER cb,
            [In] int dwLockType);

        [PreserveSig]
        HRESULT Stat(
            [Out] out STATSTG pstatstg,
            [In] STATFLAG grfStatFlag);

        [PreserveSig]
        HRESULT Clone(
            [Out, MarshalAs(UnmanagedType.Interface)] out IStream ppstm);
    }
}
