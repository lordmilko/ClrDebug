using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("E13613F9-3A3C-40B5-8F48-1E5EBFB9B21B")]
    [ComImport]
    public interface IRawEnumerator
    {
        [PreserveSig]
        HRESULT Reset();
        
        [PreserveSig]
        HRESULT GetNext(
            [Out, MarshalAs(UnmanagedType.BStr)] out string name,
            [Out] out SymbolKind kind,
            [Out, MarshalAs(UnmanagedType.Interface)] out IModelObject value);
    }
}
