using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("F412C5EA-2284-4622-A660-A697160D3312")]
    [ComImport]
    public interface IDataModelManager2 : IDataModelManager
    {
        [PreserveSig]
        new HRESULT Close();
        
        [PreserveSig]
        new HRESULT CreateNoValue(
            [Out, MarshalAs(UnmanagedType.Interface)] out IModelObject @object);
        
        [PreserveSig]
        new HRESULT CreateErrorObject(
            [In] HRESULT hrError,
            [In, MarshalAs(UnmanagedType.LPWStr)] string pwszMessage,
            [Out, MarshalAs(UnmanagedType.Interface)] out IModelObject @object);
        
        [PreserveSig]
        new HRESULT CreateTypedObject(
            [In, MarshalAs(UnmanagedType.Interface)] IDebugHostContext context,
            [In] Location objectLocation,
            [In, MarshalAs(UnmanagedType.Interface)] IDebugHostType objectType,
            [Out, MarshalAs(UnmanagedType.Interface)] out IModelObject @object);
        
        [PreserveSig]
        new HRESULT CreateTypedObjectReference(
            [In, MarshalAs(UnmanagedType.Interface)] IDebugHostContext context,
            [In] Location objectLocation,
            [In, MarshalAs(UnmanagedType.Interface)] IDebugHostType objectType,
            [Out, MarshalAs(UnmanagedType.Interface)] out IModelObject @object);
        
        [PreserveSig]
        new HRESULT CreateSyntheticObject(
            [In, MarshalAs(UnmanagedType.Interface)] IDebugHostContext context,
            [Out, MarshalAs(UnmanagedType.Interface)] out IModelObject @object);
        
        [PreserveSig]
        new HRESULT CreateDataModelObject(
            [In, MarshalAs(UnmanagedType.Interface)] IDataModelConcept dataModel,
            [Out, MarshalAs(UnmanagedType.Interface)] out IModelObject @object);
        
        [PreserveSig]
        new HRESULT CreateIntrinsicObject(
            [In] ModelObjectKind objectKind,
            [In, MarshalAs(UnmanagedType.Struct)] object intrinsicData,
            [Out, MarshalAs(UnmanagedType.Interface)] out IModelObject @object);
        
        [PreserveSig]
        new HRESULT CreateTypedIntrinsicObject(
            [In, MarshalAs(UnmanagedType.Struct)] object intrinsicData,
            [In, MarshalAs(UnmanagedType.Interface)] IDebugHostType type,
            [Out, MarshalAs(UnmanagedType.Interface)] out IModelObject @object);
        
        [PreserveSig]
        new HRESULT GetModelForTypeSignature(
            [In, MarshalAs(UnmanagedType.Interface)] IDebugHostTypeSignature typeSignature,
            [Out, MarshalAs(UnmanagedType.Interface)] out IModelObject dataModel);
        
        [PreserveSig]
        new HRESULT GetModelForType(
            [In, MarshalAs(UnmanagedType.Interface)] IDebugHostType type,
            [Out, MarshalAs(UnmanagedType.Interface)] out IModelObject dataModel,
            [Out, MarshalAs(UnmanagedType.Interface)] out IDebugHostTypeSignature typeSignature,
            [Out, MarshalAs(UnmanagedType.Interface)] out IDebugHostSymbolEnumerator wildcardMatches);
        
        [PreserveSig]
        new HRESULT RegisterModelForTypeSignature(
            [In, MarshalAs(UnmanagedType.Interface)] IDebugHostTypeSignature typeSignature,
            [In, MarshalAs(UnmanagedType.Interface)] IModelObject dataModel);
        
        [PreserveSig]
        new HRESULT UnregisterModelForTypeSignature(
            [In, MarshalAs(UnmanagedType.Interface)] IModelObject dataModel,
            [In, MarshalAs(UnmanagedType.Interface)] IDebugHostTypeSignature typeSignature);
        
        [PreserveSig]
        new HRESULT RegisterExtensionForTypeSignature(
            [In, MarshalAs(UnmanagedType.Interface)] IDebugHostTypeSignature typeSignature,
            [In, MarshalAs(UnmanagedType.Interface)] IModelObject dataModel);
        
        [PreserveSig]
        new HRESULT UnregisterExtensionForTypeSignature(
            [In, MarshalAs(UnmanagedType.Interface)] IModelObject dataModel,
            [In, MarshalAs(UnmanagedType.Interface)] IDebugHostTypeSignature typeSignature);
        
        [PreserveSig]
        new HRESULT CreateMetadataStore(
            [In, MarshalAs(UnmanagedType.Interface)] IKeyStore parentStore,
            [Out, MarshalAs(UnmanagedType.Interface)] out IKeyStore metadataStore);
        
        [PreserveSig]
        new HRESULT GetRootNamespace(
            [Out, MarshalAs(UnmanagedType.Interface)] out IModelObject rootNamespace);
        
        [PreserveSig]
        new HRESULT RegisterNamedModel(
            [In, MarshalAs(UnmanagedType.LPWStr)] string modelName,
            [In, MarshalAs(UnmanagedType.Interface)] IModelObject modeObject);
        
        [PreserveSig]
        new HRESULT UnregisterNamedModel(
            [In, MarshalAs(UnmanagedType.LPWStr)] string modelName);
        
        [PreserveSig]
        new HRESULT AcquireNamedModel(
            [In, MarshalAs(UnmanagedType.LPWStr)] string modelName,
            [Out, MarshalAs(UnmanagedType.Interface)] out IModelObject modelObject);
        
        [PreserveSig]
        HRESULT AcquireSubNamespace(
            [In, MarshalAs(UnmanagedType.LPWStr)] string modelName,
            [In, MarshalAs(UnmanagedType.LPWStr)] string subNamespaceModelName,
            [In, MarshalAs(UnmanagedType.LPWStr)] string accessName,
            [In, MarshalAs(UnmanagedType.Interface)] IKeyStore metadata,
            [Out, MarshalAs(UnmanagedType.Interface)] out IModelObject namespaceModelObject);
        
        [PreserveSig]
        HRESULT CreateTypedIntrinsicObjectEx(
            [In, MarshalAs(UnmanagedType.Interface)] IDebugHostContext context,
            [In, MarshalAs(UnmanagedType.Struct)] object intrinsicData,
            [In, MarshalAs(UnmanagedType.Interface)] IDebugHostType type,
            [Out, MarshalAs(UnmanagedType.Interface)] out IModelObject @object);
    }
}
