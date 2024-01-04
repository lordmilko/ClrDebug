using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("69CE6AE2-2268-4E6F-B062-20CE62BFE677")]
    [ComImport]
    public interface IDataModelScriptTemplateEnumerator
    {
        [PreserveSig]
        HRESULT Reset();
        
        [PreserveSig]
        HRESULT GetNext(
            [Out, MarshalAs(UnmanagedType.Interface)] out IDataModelScriptTemplate templateContent);
    }
}
