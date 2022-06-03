using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("D682FD12-43DE-411C-811B-BE8404CEA126")]
    [ComImport]
    public interface ISymNGenWriter
    {
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void AddSymbol([MarshalAs(UnmanagedType.BStr), In] string pSymbol, [In] ushort iSection, [In] ulong rva);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void AddSection([In] ushort iSection, [In] ushort flags, [In] int offset, [In] int cb);
    }
}