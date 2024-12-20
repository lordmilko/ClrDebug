using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    /// <summary>
    /// Represents a way to discover scopes and their contents (variables and arguments). Symbol sets which support the enumeration of locals and arguments must support this interface.
    /// </summary>
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("E1EE646E-0480-4DB3-8982-7DE87ED5B174")]
    [ComImport]
    public interface ISvcSymbolSetScopeResolution
    {
        /// <summary>
        /// Returns a scope representing the global scope of the module the symbol set represents. This may be an aggregation of other symbols one could discover through fully enumerating the symbol set.
        /// </summary>
        [PreserveSig]
        HRESULT GetGlobalScope(
            [Out, MarshalAs(UnmanagedType.Interface)] out ISvcSymbolSetScope scope);

        /// <summary>
        /// Finds a scope by an offset within the image (which is assumed to be an offset within a function or other code area).
        /// </summary>
        [PreserveSig]
        HRESULT FindScopeByOffset(
            [In] long moduleOffset,
            [Out, MarshalAs(UnmanagedType.Interface)] out ISvcSymbolSetScope scope);

        /// <summary>
        /// Finds a scope by the unwound context record for a stack frame.
        /// </summary>
        [PreserveSig]
        HRESULT FindScopeFrame(
            [In, MarshalAs(UnmanagedType.Interface)] ISvcProcess process,
            [In, MarshalAs(UnmanagedType.Interface)] ISvcRegisterContext registerContext,
            [Out, MarshalAs(UnmanagedType.Interface)] out ISvcSymbolSetScopeFrame scopeFrame);
    }
}
