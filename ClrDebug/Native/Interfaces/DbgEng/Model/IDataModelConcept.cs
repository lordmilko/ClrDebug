using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("FCB98D1D-1114-4FBF-B24C-EFFCB5DEF0D3")]
    [ComImport]
    public interface IDataModelConcept
    {
        [PreserveSig]
        HRESULT InitializeObject(
            [In, MarshalAs(UnmanagedType.Interface)] IModelObject modelObject,
            [In, MarshalAs(UnmanagedType.Interface)] IDebugHostTypeSignature matchingTypeSignature,
            [In, MarshalAs(UnmanagedType.Interface)] IDebugHostSymbolEnumerator wildcardMatches);
        
        [PreserveSig]
        HRESULT GetName(
            [Out, MarshalAs(UnmanagedType.BStr)] out string modelName);
    }
}
