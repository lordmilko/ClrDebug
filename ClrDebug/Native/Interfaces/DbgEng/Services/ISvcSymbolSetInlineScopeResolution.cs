using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    /// <summary>
    /// Represents a way to discover scopes and their contents (variables and arguments) including that of inlined functions.<para/>
    /// Symbol sets which support inline frame resolution along with the enumeration of locals and arguments must support this interface.
    /// </summary>
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("4760A68C-DCAA-432E-A787-1063C9FA0D3D")]
    [ComImport]
    public interface ISvcSymbolSetInlineScopeResolution
    {
        /// <summary>
        /// Finds a scope by an offset within the image and the inline function symbol representing a certain level of inlining at that location.<para/>
        /// A caller which passes nullptr for the inlineSymbol or passes a function symbol which does not represent an inlined function instance will get the behavior of the ISvcSymbolSetScopeResolution variant of this method.
        /// </summary>
        [PreserveSig]
        HRESULT FindScopeByOffsetAndInlineSymbol(
            [In] long moduleOffset,
            [In, MarshalAs(UnmanagedType.Interface)] ISvcSymbol inlineSymbol,
            [Out, MarshalAs(UnmanagedType.Interface)] out ISvcSymbolSetScope scope);

        [PreserveSig]
        HRESULT FindScopeFrameForInlineSymbol(
            [In, MarshalAs(UnmanagedType.Interface)] ISvcProcess process,
            [In, MarshalAs(UnmanagedType.Interface)] ISvcRegisterContext frameContext,
            [In, MarshalAs(UnmanagedType.Interface)] ISvcSymbol inlineSymbol,
            [Out, MarshalAs(UnmanagedType.Interface)] out ISvcSymbolSetScopeFrame scopeFrame);
    }
}
