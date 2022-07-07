using System.Runtime.InteropServices;
using System.Text;

namespace ClrDebug.DbgEng
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("6a7ccc5f-fb5e-4dcc-b41c-6c20307bccc7")]
    [ComImport]
    public interface IDebugSymbolGroup2 : IDebugSymbolGroup
    {
        #region IDebugSymbolGroup

        [PreserveSig]
        new HRESULT GetNumberSymbols(
            [Out] out uint Number);

        [PreserveSig]
        new HRESULT AddSymbol(
            [In, MarshalAs(UnmanagedType.LPStr)] string Name,
            [In, Out] ref uint Index);

        [PreserveSig]
        new HRESULT RemoveSymbolByName(
            [In, MarshalAs(UnmanagedType.LPStr)] string Name);

        [PreserveSig]
        new HRESULT RemoveSymbolsByIndex(
            [In] uint Index);

        [PreserveSig]
        new HRESULT GetSymbolName(
            [In] uint Index,
            [Out, MarshalAs(UnmanagedType.LPStr)] StringBuilder Buffer,
            [In] int BufferSize,
            [Out] out uint NameSize);

        [PreserveSig]
        new HRESULT GetSymbolParameters(
            [In] uint Start,
            [In] uint Count,
            [Out, MarshalAs(UnmanagedType.LPArray)] DEBUG_SYMBOL_PARAMETERS[] Params);

        [PreserveSig]
        new HRESULT ExpandSymbol(
            [In] uint Index,
            [In, MarshalAs(UnmanagedType.Bool)] bool Expand);

        [PreserveSig]
        new HRESULT OutputSymbols(
            [In] DEBUG_OUTCTL OutputControl,
            [In] DEBUG_OUTPUT_SYMBOLS Flags,
            [In] uint Start,
            [In] uint Count);

        [PreserveSig]
        new HRESULT WriteSymbol(
            [In] uint Index,
            [In, MarshalAs(UnmanagedType.LPStr)] string Value);

        [PreserveSig]
        new HRESULT OutputAsType(
            [In] uint Index,
            [In, MarshalAs(UnmanagedType.LPStr)] string Type);

        #endregion
        #region IDebugSymbolGroup2

        [PreserveSig]
        HRESULT AddSymbolWide(
            [In, MarshalAs(UnmanagedType.LPWStr)] string Name,
            [In, Out] ref uint Index);

        [PreserveSig]
        HRESULT RemoveSymbolByNameWide(
            [In, MarshalAs(UnmanagedType.LPWStr)] string Name);

        [PreserveSig]
        HRESULT GetSymbolNameWide(
            [In] uint Index,
            [Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder Buffer,
            [In] int BufferSize,
            [Out] out uint NameSize);

        [PreserveSig]
        HRESULT WriteSymbolWide(
            [In] uint Index,
            [In, MarshalAs(UnmanagedType.LPWStr)] string Value);

        [PreserveSig]
        HRESULT OutputAsTypeWide(
            [In] uint Index,
            [In, MarshalAs(UnmanagedType.LPWStr)] string Type);

        [PreserveSig]
        HRESULT GetSymbolTypeName(
            [In] uint Index,
            [Out, MarshalAs(UnmanagedType.LPStr)] StringBuilder Buffer,
            [In] int BufferSize,
            [Out] out uint NameSize);

        [PreserveSig]
        HRESULT GetSymbolTypeNameWide(
            [In] uint Index,
            [Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder Buffer,
            [In] int BufferSize,
            [Out] out uint NameSize);

        [PreserveSig]
        HRESULT GetSymbolSize(
            [In] uint Index,
            [Out] out uint Size);

        [PreserveSig]
        HRESULT GetSymbolOffset(
            [In] uint Index,
            [Out] out ulong Offset);

        [PreserveSig]
        HRESULT GetSymbolRegister(
            [In] uint Index,
            [Out] out uint Register);

        [PreserveSig]
        HRESULT GetSymbolValueText(
            [In] uint Index,
            [Out, MarshalAs(UnmanagedType.LPStr)] StringBuilder Buffer,
            [In] int BufferSize,
            [Out] out uint NameSize);

        [PreserveSig]
        HRESULT GetSymbolValueTextWide(
            [In] uint Index,
            [Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder Buffer,
            [In] int BufferSize,
            [Out] out uint NameSize);

        [PreserveSig]
        HRESULT GetSymbolEntryInformation(
            [In] uint Index,
            [Out] out DEBUG_SYMBOL_ENTRY Info);

        #endregion
    }
}
