using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("2A5AFCDE-B2E7-443E-9D02-510E4F8E8040")]
    [ComImport]
    public interface ISvcEventArgumentsSymbolUnload
    {
        /// <summary>
        /// Gets the module for which symbols are being unloaded.
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
