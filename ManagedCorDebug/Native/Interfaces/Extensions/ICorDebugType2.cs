using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("E6E91D79-693D-48BC-B417-8284B4F10FB5")]
    [ComImport]
    public interface ICorDebugType2
    {
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void GetTypeID(out COR_TYPEID id);
    }
}