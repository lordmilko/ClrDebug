using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    /// <summary>
    /// Any symbol which is typed, has type information, or more advanced location capability (other than a simple linear offset within the image) supports this interface.<para/>
    /// Simple symbol providers which only do basic address -&gt; name and name -&gt; address mapping need not implement this interface.
    /// </summary>
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("949A8DE4-BFF9-4F84-A3EF-79B2F154415A")]
    [ComImport]
    public interface ISvcSymbolInfo
    {
        /// <summary>
        /// Gets the type of the symbol.
        /// </summary>
        [PreserveSig]
        HRESULT GetType(
            [Out, MarshalAs(UnmanagedType.Interface)] out ISvcSymbol symbolType);

        /// <summary>
        /// Gets the location of the symbol.
        /// </summary>
        [PreserveSig]
        HRESULT GetLocation(
            [Out] out SvcSymbolLocation pLocation);

        /// <summary>
        /// Gets the value of a constant value symbol. GetLocation will return an indication that the symbol has a constant value.<para/>
        /// If this method is called on a symbol without a constant value, it will fail.
        /// </summary>
        [PreserveSig]
        HRESULT GetValue(
            [Out, MarshalAs(UnmanagedType.Struct)] out object pValue);

        /// <summary>
        /// Gets a simple attribute of the symbol. The type of a given attribute is defined by the attribute itself. If the symbol cannot logically provide a value for the attribute, E_NOT_SET should be returned.<para/>
        /// If the provider does not implement the attribute for any symbol, E_NOTIMPL should be returned.
        /// </summary>
        [PreserveSig]
        HRESULT GetAttribute(
            [In] SvcSymbolAttribute attr,
            [Out, MarshalAs(UnmanagedType.Struct)] out object pAttributeValue);
    }
}
