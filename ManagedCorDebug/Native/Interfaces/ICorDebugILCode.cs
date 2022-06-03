using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    [Guid("598D46C2-C877-42A7-89D2-3D0C7F1C1264")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [ComImport]
    public interface ICorDebugILCode
    {
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void GetEHClauses([In] uint cClauses, out uint pcClauses, [MarshalAs(UnmanagedType.Interface), Out]
            ICorDebugILCode clauses);
    }
}