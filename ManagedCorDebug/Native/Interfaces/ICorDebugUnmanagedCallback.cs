using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    [Guid("5263E909-8CB5-11D3-BD2F-0000F80849BD")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [ComImport]
    public interface ICorDebugUnmanagedCallback
    {
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void DebugEvent([ComAliasName("cordebug.ULONG_PTR"), In]
            ulong pDebugEvent, [In] int fOutOfBand);
    }
}