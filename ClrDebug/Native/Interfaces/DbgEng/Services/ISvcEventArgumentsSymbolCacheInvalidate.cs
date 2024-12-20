using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("1F3A5177-9D20-490C-8EF7-7BB2EF6044F3")]
    [ComImport]
    public interface ISvcEventArgumentsSymbolCacheInvalidate
    {
        /// <summary>
        /// Gets information about the module and symbol set for which cache invalidation should occur.
        /// </summary>
        [PreserveSig]
        HRESULT GetSymbolsInformation(
            [Out, MarshalAs(UnmanagedType.Interface)] out ISvcModule module,
            [Out, MarshalAs(UnmanagedType.Interface)] out ISvcSymbolSet symbolSet);
    }
}
