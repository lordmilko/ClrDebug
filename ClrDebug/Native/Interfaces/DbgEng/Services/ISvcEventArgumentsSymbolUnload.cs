using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("2A5AFCDE-B2E7-443E-9D02-510E4F8E8040")]
    [ComImport]
    public interface ISvcEventArgumentsSymbolUnload
    {
        [PreserveSig]
        HRESULT GetModule(
            [Out, MarshalAs(UnmanagedType.Interface)] out ISvcModule module);
        
        [PreserveSig]
        HRESULT GetSymbols(
            [Out, MarshalAs(UnmanagedType.Interface)] out ISvcSymbolSet symbols);
    }
}
