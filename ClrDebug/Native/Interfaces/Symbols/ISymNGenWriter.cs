using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace ClrDebug
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("D682FD12-43DE-411C-811B-BE8404CEA126")]
    [ComImport]
    public interface ISymNGenWriter
    {
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT AddSymbol([MarshalAs(UnmanagedType.BStr), In] string pSymbol, [In] ushort iSection, [In] long rva);

        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT AddSection([In] ushort iSection, [In] ushort flags, [In] int offset, [In] int cb);
    }
}