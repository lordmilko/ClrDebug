using System;
using System.Runtime.InteropServices;
using System.Text;

namespace ClrDebug.DbgEng
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("cba4abb4-84c4-444d-87ca-a04e13286739")]
    [ComImport]
    public interface IDebugAdvanced3 : IDebugAdvanced2
    {
        #region IDebugAdvanced

        [PreserveSig]
        new HRESULT GetThreadContext(
            [In] IntPtr Context,
            [In] uint ContextSize);

        [PreserveSig]
        new HRESULT SetThreadContext(
            [In] IntPtr Context,
            [In] uint ContextSize);

        #endregion
        #region IDebugAdvanced2

        [PreserveSig]
        new HRESULT Request(
            [In] DEBUG_REQUEST Request,
            [In] IntPtr InBuffer,
            [In] int InBufferSize,
            [Out] IntPtr OutBuffer,
            [In] int OutBufferSize,
            [Out] out int OutSize);

        [PreserveSig]
        new HRESULT GetSourceFileInformation(
            [In] DEBUG_SRCFILE Which,
            [In, MarshalAs(UnmanagedType.LPStr)] string SourceFile,
            [In] ulong Arg64,
            [In] uint Arg32,
            [Out] IntPtr Buffer,
            [In] int BufferSize,
            [Out] out int InfoSize);

        [PreserveSig]
        new HRESULT FindSourceFileAndToken(
            [In] uint StartElement,
            [In] ulong ModAddr,
            [In, MarshalAs(UnmanagedType.LPStr)] string File,
            [In] DEBUG_FIND_SOURCE Flags,
            [Out] IntPtr FileToken,
            [In] int FileTokenSize,
            [Out] out int FoundElement,
            [Out, MarshalAs(UnmanagedType.LPStr)] StringBuilder Buffer,
            [In] int BufferSize,
            [Out] out int FoundSize);

        [PreserveSig]
        new HRESULT GetSymbolInformation(
            [In] DEBUG_SYMINFO Which,
            [In] ulong Arg64,
            [In] uint Arg32,
            [Out] IntPtr Buffer,
            [In] int BufferSize,
            [Out] out int InfoSize,
            [Out, MarshalAs(UnmanagedType.LPStr)] StringBuilder StringBuffer,
            [In] int StringBufferSize,
            [Out] out int StringSize);

        [PreserveSig]
        new HRESULT GetSystemObjectInformation(
            [In] DEBUG_SYSOBJINFO Which,
            [In] ulong Arg64,
            [In] uint Arg32,
            [Out] IntPtr Buffer,
            [In] int BufferSize,
            [Out] out int InfoSize);

        #endregion
        #region IDebugAdvanced3

        [PreserveSig]
        HRESULT GetSourceFileInformationWide(
            [In] DEBUG_SRCFILE Which,
            [In, MarshalAs(UnmanagedType.LPWStr)] string SourceFile,
            [In] ulong Arg64,
            [In] uint Arg32,
            [Out] IntPtr Buffer,
            [In] int BufferSize,
            [Out] out int InfoSize);

        [PreserveSig]
        HRESULT FindSourceFileAndTokenWide(
            [In] uint StartElement,
            [In] ulong ModAddr,
            [In, MarshalAs(UnmanagedType.LPWStr)] string File,
            [In] DEBUG_FIND_SOURCE Flags,
            [Out] IntPtr FileToken,
            [In] int FileTokenSize,
            [Out] out int FoundElement,
            [Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder Buffer,
            [In] int BufferSize,
            [Out] out int FoundSize);

        [PreserveSig]
        HRESULT GetSymbolInformationWide(
            [In] DEBUG_SYMINFO Which,
            [In] ulong Arg64,
            [In] uint Arg32,
            [Out] IntPtr Buffer,
            [In] int BufferSize,
            [Out] out int InfoSize,
            [Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder StringBuffer,
            [In] int StringBufferSize,
            [Out] out int StringSize);

        #endregion
    }
}
