using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("F2BCE54E-4835-4F8A-836E-7981E29904D1")]
    [ComImport]
    public interface IHostDataModelAccess
    {
        [PreserveSig]
        HRESULT GetDataModel(
            [Out, MarshalAs(UnmanagedType.Interface)] out IDataModelManager manager,
            [Out, MarshalAs(UnmanagedType.Interface)] out IDebugHost host);
    }
}
