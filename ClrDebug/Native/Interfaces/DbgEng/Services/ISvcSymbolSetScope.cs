using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("99D912AF-630F-473E-9B4D-A55829753070")]
    [ComImport]
    public interface ISvcSymbolSetScope
    {
        [PreserveSig]
        HRESULT EnumerateArguments(
            [Out, MarshalAs(UnmanagedType.Interface)] out ISvcSymbolSetEnumerator enumerator);
        
        [PreserveSig]
        HRESULT EnumerateLocals(
            [Out, MarshalAs(UnmanagedType.Interface)] out ISvcSymbolSetEnumerator enumerator);
    }
}
