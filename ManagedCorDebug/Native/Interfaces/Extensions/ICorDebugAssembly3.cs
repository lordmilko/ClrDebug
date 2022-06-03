using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    [Guid("76361AB2-8C86-4FE9-96F2-F73D8843570A")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [ComImport]
    public interface ICorDebugAssembly3
    {
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT GetContainerAssembly([MarshalAs(UnmanagedType.Interface)] ref ICorDebugAssembly ppAssembly);

        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT EnumerateContainedAssemblies([MarshalAs(UnmanagedType.Interface)] ref ICorDebugAssemblyEnum ppAssemblies);
    }
}