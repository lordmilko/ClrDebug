using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    [Guid("68005D0F-B8E0-3B01-84D5-A11A94154942")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [ComImport]
    public interface ISymUnmanagedScope
    {
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        [return: MarshalAs(UnmanagedType.Interface)]
        ISymUnmanagedMethod GetMethod();

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        [return: MarshalAs(UnmanagedType.Interface)]
        ISymUnmanagedScope GetParent();

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void GetChildren([In] uint cChildren, out uint pcChildren, [MarshalAs(UnmanagedType.Interface), Out]
            ISymUnmanagedScope children);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        uint GetStartOffset();

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        uint GetEndOffset();

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        uint GetLocalCount();

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void GetLocals([In] uint cLocals, out uint pcLocals, [MarshalAs(UnmanagedType.Interface), Out]
            ISymUnmanagedScope locals);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void GetNamespaces([In] uint cNameSpaces, out uint pcNameSpaces, [MarshalAs(UnmanagedType.Interface), Out]
            ISymUnmanagedScope namespaces);
    }
}