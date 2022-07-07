using System.Runtime.InteropServices;
using System.Text;

namespace ClrDebug.DbgEng
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("f2528316-0f1a-4431-aeed-11d096e1e2ab")]
    [ComImport]
    public interface IDebugSymbolGroup
    {
        [PreserveSig]
        HRESULT GetNumberSymbols(
            [Out] out uint Number);

        [PreserveSig]
        HRESULT AddSymbol(
            [In, MarshalAs(UnmanagedType.LPStr)] string Name,
            [In, Out] ref uint Index);

        [PreserveSig]
        HRESULT RemoveSymbolByName(
            [In, MarshalAs(UnmanagedType.LPStr)] string Name);

        [PreserveSig]
        HRESULT RemoveSymbolsByIndex(
            [In] uint Index);

        [PreserveSig]
        HRESULT GetSymbolName(
            [In] uint Index,
            [Out, MarshalAs(UnmanagedType.LPStr)] StringBuilder Buffer,
            [In] int BufferSize,
            [Out] out uint NameSize);

        [PreserveSig]
        HRESULT GetSymbolParameters(
            [In] uint Start,
            [In] uint Count,
            [Out, MarshalAs(UnmanagedType.LPArray)]
            DEBUG_SYMBOL_PARAMETERS[] Params);

        [PreserveSig]
        HRESULT ExpandSymbol(
            [In] uint Index,
            [In, MarshalAs(UnmanagedType.Bool)] bool Expand);

        [PreserveSig]
        HRESULT OutputSymbols(
            [In] DEBUG_OUTCTL OutputControl,
            [In] DEBUG_OUTPUT_SYMBOLS Flags,
            [In] uint Start,
            [In] uint Count);

        [PreserveSig]
        HRESULT WriteSymbol(
            [In] uint Index,
            [In, MarshalAs(UnmanagedType.LPStr)] string Value);

        [PreserveSig]
        HRESULT OutputAsType(
            [In] uint Index,
            [In, MarshalAs(UnmanagedType.LPStr)] string Type);
    }
}
