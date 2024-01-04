using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("73FE19F4-A110-4500-8ED9-3C28896F508C")]
    [ComImport]
    public interface IDataModelManager
    {
        [PreserveSig]
        HRESULT Close();
        
        [PreserveSig]
        HRESULT CreateNoValue(
            [Out, MarshalAs(UnmanagedType.Interface)] out IModelObject @object);
        
        [PreserveSig]
        HRESULT CreateErrorObject(
            [In] HRESULT hrError,
            [In, MarshalAs(UnmanagedType.LPWStr)] string pwszMessage,
            [Out, MarshalAs(UnmanagedType.Interface)] out IModelObject @object);
        
        [PreserveSig]
        HRESULT CreateTypedObject(
            [In, MarshalAs(UnmanagedType.Interface)] IDebugHostContext context,
            [In] Location objectLocation,
            [In, MarshalAs(UnmanagedType.Interface)] IDebugHostType objectType,
            [Out, MarshalAs(UnmanagedType.Interface)] out IModelObject @object);
        
        [PreserveSig]
        HRESULT CreateTypedObjectReference(
            [In, MarshalAs(UnmanagedType.Interface)] IDebugHostContext context,
            [In] Location objectLocation,
            [In, MarshalAs(UnmanagedType.Interface)] IDebugHostType objectType,
            [Out, MarshalAs(UnmanagedType.Interface)] out IModelObject @object);
        
        [PreserveSig]
        HRESULT CreateSyntheticObject(
            [In, MarshalAs(UnmanagedType.Interface)] IDebugHostContext context,
            [Out, MarshalAs(UnmanagedType.Interface)] out IModelObject @object);
        
        [PreserveSig]
        HRESULT CreateDataModelObject(
            [In, MarshalAs(UnmanagedType.Interface)] IDataModelConcept dataModel,
            [Out, MarshalAs(UnmanagedType.Interface)] out IModelObject @object);
        
        [PreserveSig]
        HRESULT CreateIntrinsicObject(
            [In] ModelObjectKind objectKind,
            [In, MarshalAs(UnmanagedType.Struct)] object intrinsicData,
            [Out, MarshalAs(UnmanagedType.Interface)] out IModelObject @object);
        
        [PreserveSig]
        HRESULT CreateTypedIntrinsicObject(
            [In, MarshalAs(UnmanagedType.Struct)] object intrinsicData,
            [In, MarshalAs(UnmanagedType.Interface)] IDebugHostType type,
            [Out, MarshalAs(UnmanagedType.Interface)] out IModelObject @object);
        
        [PreserveSig]
        HRESULT GetModelForTypeSignature(
            [In, MarshalAs(UnmanagedType.Interface)] IDebugHostTypeSignature typeSignature,
            [Out, MarshalAs(UnmanagedType.Interface)] out IModelObject dataModel);
        
        [PreserveSig]
        HRESULT GetModelForType(
            [In, MarshalAs(UnmanagedType.Interface)] IDebugHostType type,
            [Out, MarshalAs(UnmanagedType.Interface)] out IModelObject dataModel,
            [Out, MarshalAs(UnmanagedType.Interface)] out IDebugHostTypeSignature typeSignature,
            [Out, MarshalAs(UnmanagedType.Interface)] out IDebugHostSymbolEnumerator wildcardMatches);
        
        [PreserveSig]
        HRESULT RegisterModelForTypeSignature(
            [In, MarshalAs(UnmanagedType.Interface)] IDebugHostTypeSignature typeSignature,
            [In, MarshalAs(UnmanagedType.Interface)] IModelObject dataModel);
        
        [PreserveSig]
        HRESULT UnregisterModelForTypeSignature(
            [In, MarshalAs(UnmanagedType.Interface)] IModelObject dataModel,
            [In, MarshalAs(UnmanagedType.Interface)] IDebugHostTypeSignature typeSignature);
        
        [PreserveSig]
        HRESULT RegisterExtensionForTypeSignature(
            [In, MarshalAs(UnmanagedType.Interface)] IDebugHostTypeSignature typeSignature,
            [In, MarshalAs(UnmanagedType.Interface)] IModelObject dataModel);
        
        [PreserveSig]
        HRESULT UnregisterExtensionForTypeSignature(
            [In, MarshalAs(UnmanagedType.Interface)] IModelObject dataModel,
            [In, MarshalAs(UnmanagedType.Interface)] IDebugHostTypeSignature typeSignature);
        
        [PreserveSig]
        HRESULT CreateMetadataStore(
            [In, MarshalAs(UnmanagedType.Interface)] IKeyStore parentStore,
            [Out, MarshalAs(UnmanagedType.Interface)] out IKeyStore metadataStore);
        
        [PreserveSig]
        HRESULT GetRootNamespace(
            [Out, MarshalAs(UnmanagedType.Interface)] out IModelObject rootNamespace);
        
        [PreserveSig]
        HRESULT RegisterNamedModel(
            [In, MarshalAs(UnmanagedType.LPWStr)] string modelName,
            [In, MarshalAs(UnmanagedType.Interface)] IModelObject modeObject);
        
        [PreserveSig]
        HRESULT UnregisterNamedModel(
            [In, MarshalAs(UnmanagedType.LPWStr)] string modelName);
        
        [PreserveSig]
        HRESULT AcquireNamedModel(
            [In, MarshalAs(UnmanagedType.LPWStr)] string modelName,
            [Out, MarshalAs(UnmanagedType.Interface)] out IModelObject modelObject);
    }
}
