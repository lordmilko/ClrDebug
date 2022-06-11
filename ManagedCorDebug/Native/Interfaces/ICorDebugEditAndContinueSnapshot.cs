using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    /// <summary>
    /// <see cref="ICorDebugEditAndContinueSnapshot"/> is obsolete. Do not use this interface.
    /// </summary>
    [Guid("6DC3FA01-D7CB-11D2-8A95-0080C792E5D8")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [ComImport]
    public interface ICorDebugEditAndContinueSnapshot
    {
        /// <summary>
        /// CopyMetaData is obsolete. Do not call this method.
        /// </summary>
        [Obsolete]
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT CopyMetaData([MarshalAs(UnmanagedType.Interface), In]
            IStream pIStream, out Guid pMvid);

        /// <summary>
        /// GetMvid is obsolete. Do not call this method.
        /// </summary>
        [Obsolete]
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT GetMvid(out Guid pMvid);

        /// <summary>
        /// GetRoDataRVA is obsolete. Do not call this method.
        /// </summary>
        [Obsolete]
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT GetRoDataRVA(out uint pRoDataRVA);

        /// <summary>
        /// GetRwDataRVA is obsolete. Do not call this method.
        /// </summary>
        [Obsolete]
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT GetRwDataRVA(out uint pRwDataRVA);

        /// <summary>
        /// SetPEBytes is obsolete. Do not call this method.
        /// </summary>
        [Obsolete]
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT SetPEBytes([MarshalAs(UnmanagedType.Interface), In]
            IStream pIStream);

        /// <summary>
        /// SetILMap is obsolete. Do not call this method.
        /// </summary>
        [Obsolete]
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT SetILMap([In] uint mdFunction, [In] uint cMapSize, [In] ref COR_IL_MAP map);

        /// <summary>
        /// SetPESymbolBytes is obsolete. Do not call this method.
        /// </summary>
        [Obsolete]
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT SetPESymbolBytes([MarshalAs(UnmanagedType.Interface), In]
            IStream pIStream);
    }
}