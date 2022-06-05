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
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        new HRESULT AddSymbol([MarshalAs(UnmanagedType.BStr), In] string pSymbol, [In] ushort iSection, [In] ulong rva);

        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        new HRESULT AddSection([In] ushort iSection, [In] ushort flags, [In] int offset, [In] int cb);

        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT OpenModW([In] string wszModule, [In] string wszObjFile, [Out] IntPtr ppmod);

        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT CloseMod([In] ref byte pmod);

        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT ModAddSymbols([In] ref byte pmod, [In] ref byte pbSym, [In] int cb);

        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT ModAddSecContribEx(
            [In] ref byte pmod,
            [In] ushort isect,
            [In] int off,
            [In] int cb,
            [In] uint dwCharacteristics,
            [In] uint dwDataCrc,
            [In] uint dwRelocCrc);

        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT QueryPDBNameExW(out ushort wszPDB, [In] ulong cchMax);
    }
}