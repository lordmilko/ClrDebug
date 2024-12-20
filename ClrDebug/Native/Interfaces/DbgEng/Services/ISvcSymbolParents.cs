using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    /// <summary>
    /// Any symbol which supports finding its parent (lexical or otherwise) supports this interface. Simple symbol providers which only do basic address -&gt; name and name -&gt; address mapping need not implement this interface.<para/>
    /// This interface should be considered *OPTIONAL* -- even in the presence of ISvcSymbolChildren.
    /// </summary>
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("D1B55D38-9B15-4287-BCF3-6032EC3480C2")]
    [ComImport]
    public interface ISvcSymbolParents
    {
        /// <summary>
        /// Gets the lexical parent of the given symbol.
        /// </summary>
        [PreserveSig]
        HRESULT GetLexicalParent(
            [Out, MarshalAs(UnmanagedType.Interface)] out ISvcSymbol lexicalParent);
    }
}
