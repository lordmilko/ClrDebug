using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("D1B55D38-9B15-4287-BCF3-6032EC3480C2")]
    [ComImport]
    public interface ISvcSymbolParents
    {
        [PreserveSig]
        HRESULT GetLexicalParent(
            [Out, MarshalAs(UnmanagedType.Interface)] out ISvcSymbol lexicalParent);
    }
}
