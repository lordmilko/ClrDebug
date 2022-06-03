using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("CC7BCAF5-8A68-11D2-983C-0000F808342D")]
    [ComImport]
    public interface ICorDebugClass
    {
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void GetModule([MarshalAs(UnmanagedType.Interface)] out ICorDebugModule pModule);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void GetToken(out uint pTypeDef);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void GetStaticFieldValue([In] uint fieldDef, [MarshalAs(UnmanagedType.Interface), In]
            ICorDebugFrame pFrame, [MarshalAs(UnmanagedType.Interface)] out ICorDebugValue ppValue);
    }
}