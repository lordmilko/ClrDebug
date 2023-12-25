using System;
using System.Runtime.InteropServices;
#if GENERATED_MARSHALLING
using System.Runtime.InteropServices.Marshalling;
#endif

namespace ClrDebug
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("0000000B-0000-0000-C000-000000000046")]
#if !GENERATED_MARSHALLING
    [ComImport]
#else
    [GeneratedComInterface]
#endif
    public partial interface IStorage
    {
        [PreserveSig]
        HRESULT CreateStream(
            [MarshalAs(UnmanagedType.LPWStr), In] string pwcsName,
            [In] int grfMode,
            [In] int reserved1,
            [In] int reserved2,
            [Out, MarshalAs(UnmanagedType.Interface)] out IStream ppstm);

        [PreserveSig]
        HRESULT OpenStream(
            [MarshalAs(UnmanagedType.LPWStr), In] string pwcsName,
            [In] IntPtr reserved1,
            [In] int grfMode,
            [In] int reserved2,
            [Out, MarshalAs(UnmanagedType.Interface)] out IStream ppstm);

        [PreserveSig]
        HRESULT CreateStorage(
            [MarshalAs(UnmanagedType.LPWStr), In] string pwcsName,
            [In] int grfMode,
            [In] int reserved1,
            [In] int reserved2,
            [Out, MarshalAs(UnmanagedType.Interface)] out IStorage ppstg);

        [PreserveSig]
        HRESULT OpenStorage(
            [MarshalAs(UnmanagedType.LPWStr), In] string pwcsName,
            [MarshalAs(UnmanagedType.Interface), In] IStorage pstgPriority,
            [In] int grfMode,
            [In] IntPtr snbExclude, //Original type is SNB which is a LPOLESTR* (despite confusing spacing in objidl.h)
            [In] int reserved,
            [Out, MarshalAs(UnmanagedType.Interface)] out IStorage ppstg);

        [PreserveSig]
        HRESULT CopyTo(
            [In] int ciidExclude,
#if !GENERATED_MARSHALLING
            [In, MarshalAs(UnmanagedType.LPStruct)]
#else
            [MarshalUsing(typeof(GuidMarshaller))] in
#endif
            Guid rgiidExclude,
            [In] IntPtr snbExclude,
            [MarshalAs(UnmanagedType.Interface), In] IStorage pstgDest);

        [PreserveSig]
        HRESULT MoveElementTo(
            [MarshalAs(UnmanagedType.LPWStr), In] string pwcsName,
            [MarshalAs(UnmanagedType.Interface), In] IStorage pstgDest,
            [MarshalAs(UnmanagedType.LPWStr), In] string pwcsNewName,
            [In] int grfFlags);

        [PreserveSig]
        HRESULT Commit(
            [In] int grfCommitFlags);

        [PreserveSig]
        HRESULT Revert();

        [PreserveSig]
        HRESULT EnumElements(
            [In] int reserved1,
            [In] IntPtr reserved2,
            [In] int reserved3,
            [Out, MarshalAs(UnmanagedType.Interface)] out IEnumSTATSTG ppenum);

        [PreserveSig]
        HRESULT DestroyElement(
            [MarshalAs(UnmanagedType.LPWStr), In] string pwcsName);

        [PreserveSig]
        HRESULT RenameElement(
            [MarshalAs(UnmanagedType.LPWStr), In] string pwcsOldName,
            [MarshalAs(UnmanagedType.LPWStr), In] string pwcsNewName);

        [PreserveSig]
        HRESULT SetElementTimes(
            [MarshalAs(UnmanagedType.LPWStr), In] string pwcsName,
            [In] ref FILETIME pctime,
            [In] ref FILETIME patime,
            [In] ref FILETIME pmtime);

        [PreserveSig]
        HRESULT SetClass(
#if !GENERATED_MARSHALLING
            [In, MarshalAs(UnmanagedType.LPStruct)]
#else
            [MarshalUsing(typeof(GuidMarshaller))] in
#endif
            Guid clsid);

        [PreserveSig]
        HRESULT SetStateBits(
            [In] int grfStateBits,
            [In] int grfMask);

        [PreserveSig]
        HRESULT Stat(
            [Out] out STATSTG pstatstg,
            [In] int grfStatFlag);
    }
}
