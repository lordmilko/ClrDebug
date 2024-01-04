using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("014D366A-1F23-4981-9219-B2DB8B402054")]
    [ComImport]
    public interface IDataModelScriptHostContext
    {
        [PreserveSig]
        HRESULT NotifyScriptChange(
            [In, MarshalAs(UnmanagedType.Interface)] IDataModelScript script,
            [In] ScriptChangeKind changeKind);
        
        [PreserveSig]
        HRESULT GetNamespaceObject(
            [Out, MarshalAs(UnmanagedType.Interface)] out IModelObject namespaceObject);
    }
}
