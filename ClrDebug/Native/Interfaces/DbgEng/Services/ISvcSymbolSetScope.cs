using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    /// <summary>
    /// Represents a lexical scope within code. A scope can implement ISvcSymbolChildren to allow query of other children underneath the scope.
    /// </summary>
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("99D912AF-630F-473E-9B4D-A55829753070")]
    [ComImport]
    public interface ISvcSymbolSetScope
    {
        /// <summary>
        /// If the scope is a function scope (or is a lexical sub-scope of a function), this enumerates the arguments of the function.<para/>
        /// This will fail for a scope for which arguments are inappropriate.
        /// </summary>
        [PreserveSig]
        HRESULT EnumerateArguments(
            [Out, MarshalAs(UnmanagedType.Interface)] out ISvcSymbolSetEnumerator enumerator);

        /// <summary>
        /// Enumerates the locals within the scope.
        /// </summary>
        [PreserveSig]
        HRESULT EnumerateLocals(
            [Out, MarshalAs(UnmanagedType.Interface)] out ISvcSymbolSetEnumerator enumerator);
    }
}
