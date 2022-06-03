using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    [Guid("6DC3FA01-D7CB-11D2-8A95-0080C792E5D8")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [ComImport]
    public interface ICorDebugEditAndContinueSnapshot
    {
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT CopyMetaData([MarshalAs(UnmanagedType.Interface), In]
            IStream pIStream, out Guid pMvid);

        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT GetMvid(out Guid pMvid);

        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT GetRoDataRVA(out uint pRoDataRVA);

        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT GetRwDataRVA(out uint pRwDataRVA);

        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT SetPEBytes([MarshalAs(UnmanagedType.Interface), In]
            IStream pIStream);

        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT SetILMap([In] uint mdFunction, [In] uint cMapSize, [In] ref COR_IL_MAP map);

        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT SetPESymbolBytes([MarshalAs(UnmanagedType.Interface), In]
            IStream pIStream);
    }
}