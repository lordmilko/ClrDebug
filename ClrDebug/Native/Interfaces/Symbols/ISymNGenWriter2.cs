using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;

namespace ClrDebug
{
    [Guid("B029E51B-4C55-4FE2-B993-9F7BC1F10DB4")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [ComConversionLoss]
    [ComImport]
    public interface ISymNGenWriter2 : ISymNGenWriter
    {
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        new HRESULT AddSymbol(
            [MarshalAs(UnmanagedType.BStr), In] string pSymbol,
            [In] ushort iSection,
            [In] long rva);

        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        new HRESULT AddSection(
            [In] ushort iSection,
            [In] ushort flags,
            [In] int offset,
            [In] int cb);

        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT OpenModW(
            [In, MarshalAs(UnmanagedType.LPWStr)] string wszModule,
            [In, MarshalAs(UnmanagedType.LPWStr)] string wszObjFile,
            [Out] out IntPtr ppmod);

        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT CloseMod(
            [In] IntPtr pmod);

        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT ModAddSymbols(
            [In] IntPtr pmod,
            [In] IntPtr pbSym,
            [In] int cb);

        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT ModAddSecContribEx(
            [In] IntPtr pmod,
            [In] ushort isect,
            [In] int off,
            [In] int cb,
            [In] int dwCharacteristics,
            [In] int dwDataCrc,
            [In] int dwRelocCrc);

        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT QueryPDBNameExW(
            [Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder wszPDB,
            [In] long cchMax);
    }
}
