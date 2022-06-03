using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    [Guid("18AD3D6E-B7D2-11D2-BD04-0000F80849BD")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [ComImport]
    public interface ICorDebugObjectValue : ICorDebugValue
    {
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        new void GetType(out CorElementType pType);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        new void GetSize(out uint pSize);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        new void GetAddress(out ulong pAddress);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        new void CreateBreakpoint([MarshalAs(UnmanagedType.Interface)] out ICorDebugValueBreakpoint ppBreakpoint);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void GetClass([MarshalAs(UnmanagedType.Interface)] out ICorDebugClass ppClass);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void GetFieldValue([MarshalAs(UnmanagedType.Interface), In]
            ICorDebugClass pClass, [In] uint fieldDef, [MarshalAs(UnmanagedType.Interface)] out ICorDebugValue ppValue);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void GetVirtualMethod([In] uint memberRef,
            [MarshalAs(UnmanagedType.Interface)] out ICorDebugFunction ppFunction);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void GetContext([MarshalAs(UnmanagedType.Interface)] out ICorDebugContext ppContext);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void IsValueClass(out int pbIsValueClass);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void GetManagedCopy([MarshalAs(UnmanagedType.IUnknown)] out object ppObject);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void SetFromManagedCopy([MarshalAs(UnmanagedType.IUnknown), In]
            object pObject);
    }
}