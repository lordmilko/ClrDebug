using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    [Guid("35389FF1-3684-4C55-A2EE-210F26C60E5E")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [ComImport]
    public interface ICorDebugNativeFrame2
    {
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void IsChild(out int pIsChild);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void IsMatchingParentFrame([MarshalAs(UnmanagedType.Interface), In]
            ICorDebugNativeFrame2 pPotentialParentFrame, out int pIsParent);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void GetStackParameterSize(out uint pSize);
    }
}