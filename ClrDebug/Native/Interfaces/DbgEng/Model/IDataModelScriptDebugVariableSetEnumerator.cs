using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("0F9FEED7-D045-4AC3-98A8-A98942CF6A35")]
    [ComImport]
    public interface IDataModelScriptDebugVariableSetEnumerator
    {
        [PreserveSig]
        HRESULT Reset();
        
        [PreserveSig]
        HRESULT GetNext(
            [Out, MarshalAs(UnmanagedType.BStr)] out string variableName,
            [Out, MarshalAs(UnmanagedType.Interface)] out IModelObject variableValue,
            [Out, MarshalAs(UnmanagedType.Interface)] out IKeyStore variableMetadata);
    }
}
