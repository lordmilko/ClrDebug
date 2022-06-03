using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("D05E60C3-848C-4E7D-894E-623320FF6AFA")]
    [ComImport]
    public interface ICorDebugDataTarget3
    {
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void GetLoadedModules(
            [In] uint cRequestedModules,
            out uint pcFetchedModules,
            [MarshalAs(UnmanagedType.Interface), Out]
            ICorDebugDataTarget3 pLoadedModules);
    }
}