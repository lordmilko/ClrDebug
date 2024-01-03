using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
#if GENERATED_MARSHALLING
using System.Runtime.InteropServices.Marshalling;
#endif

namespace ClrDebug
{
    /// <summary>
    /// <see cref="ICorDebugEditAndContinueSnapshot"/> is obsolete. Do not use this interface.
    /// </summary>
    [Guid("6DC3FA01-D7CB-11D2-8A95-0080C792E5D8")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
#if !GENERATED_MARSHALLING
    [ComImport]
#else
    [GeneratedComInterface]
#endif
    public partial interface ICorDebugEditAndContinueSnapshot
    {
        /// <summary>
        /// CopyMetaData is obsolete. Do not call this method.
        /// </summary>
        [Obsolete]
        [PreserveSig]
        HRESULT CopyMetaData(
            [MarshalAs(UnmanagedType.Interface), In] IStream pIStream,
            [Out]
#if GENERATED_MARSHALLING
            [MarshalUsing(typeof(GuidMarshaller))]
#endif
            out Guid pMvid);

        /// <summary>
        /// GetMvid is obsolete. Do not call this method.
        /// </summary>
        [Obsolete]
        [PreserveSig]
        HRESULT GetMvid(
            [Out]
#if GENERATED_MARSHALLING
            [MarshalUsing(typeof(GuidMarshaller))]
#endif
            out Guid pMvid);

        /// <summary>
        /// GetRoDataRVA is obsolete. Do not call this method.
        /// </summary>
        [Obsolete]
        [PreserveSig]
        HRESULT GetRoDataRVA(
            [Out] out int pRoDataRVA);

        /// <summary>
        /// GetRwDataRVA is obsolete. Do not call this method.
        /// </summary>
        [Obsolete]
        [PreserveSig]
        HRESULT GetRwDataRVA(
            [Out] out int pRwDataRVA);

        /// <summary>
        /// SetPEBytes is obsolete. Do not call this method.
        /// </summary>
        [Obsolete]
        [PreserveSig]
        HRESULT SetPEBytes(
            [MarshalAs(UnmanagedType.Interface), In] IStream pIStream);

        /// <summary>
        /// SetILMap is obsolete. Do not call this method.
        /// </summary>
        [Obsolete]
        [PreserveSig]
        HRESULT SetILMap(
            [In] mdToken mdFunction,
            [In] int cMapSize,
            [In] ref COR_IL_MAP map);

        /// <summary>
        /// SetPESymbolBytes is obsolete. Do not call this method.
        /// </summary>
        [Obsolete]
        [PreserveSig]
        HRESULT SetPESymbolBytes(
            [MarshalAs(UnmanagedType.Interface), In] IStream pIStream);
    }
}
