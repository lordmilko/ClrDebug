using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;

namespace ManagedCorDebug
{
    [Guid("817F343A-6630-4578-96C5-D11BC0EC5EE2")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [ComImport]
    public interface ICorDebugLoadedModule
    {
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT GetBaseAddress(out ulong pAddress);

        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT GetName([In] uint cchName, out uint pcchName, [MarshalAs(UnmanagedType.Interface), Out]
            StringBuilder szName);

        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT GetSize(out uint pcBytes);
    }
}