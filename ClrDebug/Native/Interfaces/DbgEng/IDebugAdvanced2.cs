using System;
using System.Runtime.InteropServices;
using System.Text;

namespace ClrDebug.DbgEng
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("716d14c9-119b-4ba5-af1f-0890e672416a")]
    [ComImport]
    public interface IDebugAdvanced2 : IDebugAdvanced
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
        HRESULT Request(
            [In] DEBUG_REQUEST Request,
            [In] IntPtr InBuffer,
            [In] int InBufferSize,
            [Out] IntPtr OutBuffer,
            [In] int OutBufferSize,
            [Out] out int OutSize);

        [PreserveSig]
        HRESULT GetSourceFileInformation(
            [In] DEBUG_SRCFILE Which,
            [In, MarshalAs(UnmanagedType.LPStr)] string SourceFile,
            [In] ulong Arg64,
            [In] uint Arg32,
            [Out] IntPtr Buffer,
            [In] int BufferSize,
            [Out] out int InfoSize);

        [PreserveSig]
        HRESULT FindSourceFileAndToken(
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
        HRESULT GetSymbolInformation(
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
        HRESULT GetSystemObjectInformation(
            [In] DEBUG_SYSOBJINFO Which,
            [In] ulong Arg64,
            [In] uint Arg32,
            [Out] IntPtr Buffer,
            [In] int BufferSize,
            [Out] out int InfoSize);

        #endregion
    }
}
