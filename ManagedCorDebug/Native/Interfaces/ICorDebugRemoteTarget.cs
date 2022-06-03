using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    [Guid("C3ED8383-5A49-4CF5-B4B7-01864D9E582D")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [ComImport]
    public interface ICorDebugRemoteTarget
    {
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void GetHostName([In] uint cchHostName, out uint pcchHostName, [MarshalAs(UnmanagedType.Interface), Out]
            ICorDebugRemoteTarget szHostName);
    }
}