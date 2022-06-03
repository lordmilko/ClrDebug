using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    [Guid("CC7BCB00-8A68-11D2-983C-0000F808342D")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [ComImport]
    public interface ICorDebugContext : ICorDebugObjectValue
    {
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        new void GetType(out uint pType);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        new void GetSize(out uint pSize);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        new void GetAddress(out ulong pAddress);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        new void CreateBreakpoint([MarshalAs(UnmanagedType.Interface)] out ICorDebugValueBreakpoint ppBreakpoint);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        new void GetClass([MarshalAs(UnmanagedType.Interface)] out ICorDebugClass ppClass);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        new void GetFieldValue([MarshalAs(UnmanagedType.Interface), In]
            ICorDebugClass pClass, [In] uint fieldDef, [MarshalAs(UnmanagedType.Interface)] out ICorDebugValue ppValue);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        new void GetVirtualMethod([In] uint memberRef,
            [MarshalAs(UnmanagedType.Interface)] out ICorDebugFunction ppFunction);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        new void GetContext([MarshalAs(UnmanagedType.Interface)] out ICorDebugContext ppContext);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        new void IsValueClass(out int pbIsValueClass);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        new void GetManagedCopy([MarshalAs(UnmanagedType.IUnknown)] out object ppObject);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        new void SetFromManagedCopy([MarshalAs(UnmanagedType.IUnknown), In]
            object pObject);
    }
}