using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("1E020689-2351-432D-BDD2-C4DF5DB629E0")]
    [ComImport]
    public interface ISvcEventArgumentsSymbolLoad
    {
        /// <summary>
        /// Gets the module for which symbols were loaded.
        /// </summary>
        [PreserveSig]
        HRESULT GetModule(
            [Out, MarshalAs(UnmanagedType.Interface)] out ISvcModule module);

        /// <summary>
        /// Gets the symbols which were loaded for the module. The caller should check the output result for nullptr for symbol formats which are not (currently) expressable as a symbol set.
        /// </summary>
        [PreserveSig]
        HRESULT GetSymbols(
            [Out, MarshalAs(UnmanagedType.Interface)] out ISvcSymbolSet symbols);
    }
}
