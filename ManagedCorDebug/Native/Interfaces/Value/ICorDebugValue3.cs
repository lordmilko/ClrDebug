using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("565005FC-0F8A-4F3E-9EDB-83102B156595")]
    [ComImport]
    public interface ICorDebugValue3
    {
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void GetSize64(out ulong pSize);
    }
}