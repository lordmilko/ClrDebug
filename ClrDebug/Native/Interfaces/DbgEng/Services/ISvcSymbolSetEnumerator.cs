using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("2D8214A6-A620-4452-93A0-DF5DAEB43DA1")]
    [ComImport]
    public interface ISvcSymbolSetEnumerator
    {
        [PreserveSig]
        HRESULT Reset();
        
        [PreserveSig]
        HRESULT GetNext(
            [Out, MarshalAs(UnmanagedType.Interface)] out ISvcSymbol symbol);
    }
}
