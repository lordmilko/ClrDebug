using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    [Guid("5F69C5E5-3E12-42DF-B371-F9D761D6EE24")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [ComImport]
    public interface ICorDebugComObjectValue
    {
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void GetCachedInterfaceTypes([In] int bIInspectableOnly,
            [MarshalAs(UnmanagedType.Interface)] out ICorDebugTypeEnum ppInterfacesEnum);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void GetCachedInterfacePointers(
            [In] int bIInspectableOnly,
            [In] uint celt,
            out uint pceltFetched,
            out ulong ptrs);
    }
}