using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    [Guid("21E9D9C0-FCB8-11DF-8CFF-0800200C9A66")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [ComImport]
    public interface ICorDebugProcess5
    {
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT GetGCHeapInformation(out COR_HEAPINFO pHeapInfo);

        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT EnumerateHeap([MarshalAs(UnmanagedType.Interface)] out ICorDebugHeapEnum ppObjects);

        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT EnumerateHeapRegions([MarshalAs(UnmanagedType.Interface)] out ICorDebugHeapSegmentEnum ppRegions);

        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT GetObject([In] ulong addr, [MarshalAs(UnmanagedType.Interface)] out ICorDebugObjectValue pObject);

        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT EnumerateGCReferences([In] int enumerateWeakReferences,
            [MarshalAs(UnmanagedType.Interface)] out ICorDebugGCReferenceEnum ppEnum);

        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT EnumerateHandles([In] CorGCReferenceType types,
            [MarshalAs(UnmanagedType.Interface)] out ICorDebugGCReferenceEnum ppEnum);

        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT GetTypeID([In] ulong obj, out COR_TYPEID pId);

        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT GetTypeForTypeID([In] COR_TYPEID id, [MarshalAs(UnmanagedType.Interface)] out ICorDebugType ppType);

        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT GetArrayLayout([In] COR_TYPEID id, out COR_ARRAY_LAYOUT pLayout);

        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT GetTypeLayout([In] COR_TYPEID id, out COR_TYPE_LAYOUT pLayout);

        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT GetTypeFields([In] COR_TYPEID id, uint celt, ref COR_FIELD fields, ref uint pceltNeeded);

        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT EnableNGENPolicy([In] CorDebugNGENPolicy ePolicy);
    }
}