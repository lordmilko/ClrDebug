using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;

namespace ManagedCorDebug
{
    [Guid("0DFF7289-54F8-11D3-BD28-0000F80849BD")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [ComImport]
    public interface ISymUnmanagedNamespace
    {
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT GetName([In] uint cchName, out uint pcchName, [MarshalAs(UnmanagedType.Interface), Out]
            StringBuilder szName);

        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT GetNamespaces([In] uint cNameSpaces, out uint pcNameSpaces, [MarshalAs(UnmanagedType.Interface), Out]
            ISymUnmanagedNamespace namespaces);

        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT GetVariables([In] uint cVars, out uint pcVars, [MarshalAs(UnmanagedType.Interface), Out]
            ISymUnmanagedNamespace pVars);
    }
}