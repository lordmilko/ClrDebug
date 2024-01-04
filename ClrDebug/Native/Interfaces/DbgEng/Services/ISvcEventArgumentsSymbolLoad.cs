using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("1E020689-2351-432D-BDD2-C4DF5DB629E0")]
    [ComImport]
    public interface ISvcEventArgumentsSymbolLoad
    {
        [PreserveSig]
        HRESULT GetModule(
            [Out, MarshalAs(UnmanagedType.Interface)] out ISvcModule module);
        
        [PreserveSig]
        HRESULT GetSymbols(
            [Out, MarshalAs(UnmanagedType.Interface)] out ISvcSymbolSet symbols);
    }
}
