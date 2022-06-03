using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    [Guid("B029E51B-4C55-4FE2-B993-9F7BC1F10DB4")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [ComConversionLoss]
    [ComImport]
    public interface ISymNGenWriter2 : ISymNGenWriter
    {
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        new void AddSymbol([MarshalAs(UnmanagedType.BStr), In] string pSymbol, [In] ushort iSection, [In] ulong rva);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        new void AddSection([In] ushort iSection, [In] ushort flags, [In] int offset, [In] int cb);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void OpenModW([In] ref ushort wszModule, [In] ref ushort wszObjFile, [Out] IntPtr ppmod);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void CloseMod([In] ref byte pmod);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void ModAddSymbols([In] ref byte pmod, [In] ref byte pbSym, [In] int cb);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void ModAddSecContribEx(
            [In] ref byte pmod,
            [In] ushort isect,
            [In] int off,
            [In] int cb,
            [In] uint dwCharacteristics,
            [In] uint dwDataCrc,
            [In] uint dwRelocCrc);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void QueryPDBNameExW(out ushort wszPDB, [In] ulong cchMax);
    }
}