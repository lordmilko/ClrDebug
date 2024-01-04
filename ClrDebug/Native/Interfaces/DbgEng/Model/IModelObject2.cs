using System;
using System.Runtime.InteropServices;
using ClrDebug.TypeLib;

namespace ClrDebug.DbgEng
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("D61E19F4-AB3D-4344-9F7B-0993F3D58745")]
    [ComImport]
    public interface IModelObject2 : IModelObject
    {
        [PreserveSig]
        new HRESULT GetContext(
            [Out, MarshalAs(UnmanagedType.Interface)] out IDebugHostContext context);
        
        [PreserveSig]
        new HRESULT GetKind(
            [Out] out ModelObjectKind kind);
        
        [PreserveSig]
        new HRESULT GetIntrinsicValue(
            [Out, MarshalAs(UnmanagedType.Struct)] out object intrinsicData);
        
        [PreserveSig]
        new HRESULT GetIntrinsicValueAs(
            [In] VARENUM vt,
            [Out, MarshalAs(UnmanagedType.Struct)] out object intrinsicData);
        
        [PreserveSig]
        new HRESULT GetKeyValue(
            [In, MarshalAs(UnmanagedType.LPWStr)] string key,
            [Out, MarshalAs(UnmanagedType.Interface)] out IModelObject @object,
            [Out, MarshalAs(UnmanagedType.Interface)] out IKeyStore metadata);
        
        [PreserveSig]
        new HRESULT SetKeyValue(
            [In, MarshalAs(UnmanagedType.LPWStr)] string key,
            [In, MarshalAs(UnmanagedType.Interface)] IModelObject @object);
        
        [PreserveSig]
        new HRESULT EnumerateKeyValues(
            [Out, MarshalAs(UnmanagedType.Interface)] out IKeyEnumerator enumerator);
        
        [PreserveSig]
        new HRESULT GetRawValue(
            [In] SymbolKind kind,
            [In, MarshalAs(UnmanagedType.LPWStr)] string name,
            [In] int searchFlags,
            [Out, MarshalAs(UnmanagedType.Interface)] out IModelObject @object);
        
        [PreserveSig]
        new HRESULT EnumerateRawValues(
            [In] SymbolKind kind,
            [In] int searchFlags,
            [Out, MarshalAs(UnmanagedType.Interface)] out IRawEnumerator enumerator);
        
        [PreserveSig]
        new HRESULT Dereference(
            [Out, MarshalAs(UnmanagedType.Interface)] out IModelObject @object);
        
        [PreserveSig]
        new HRESULT TryCastToRuntimeType(
            [Out, MarshalAs(UnmanagedType.Interface)] out IModelObject runtimeTypedObject);
        
        [PreserveSig]
        new HRESULT GetConcept(
            [In, MarshalAs(UnmanagedType.LPStruct)] Guid conceptId,
            [Out, MarshalAs(UnmanagedType.Interface)] out object conceptInterface,
            [Out, MarshalAs(UnmanagedType.Interface)] out IKeyStore conceptMetadata);
        
        [PreserveSig]
        new HRESULT GetLocation(
            [Out] out Location location);
        
        [PreserveSig]
        new HRESULT GetTypeInfo(
            [Out, MarshalAs(UnmanagedType.Interface)] out IDebugHostType type);
        
        [PreserveSig]
        new HRESULT GetTargetInfo(
            [Out] out Location location,
            [Out, MarshalAs(UnmanagedType.Interface)] out IDebugHostType type);
        
        [PreserveSig]
        new HRESULT GetNumberOfParentModels(
            [Out] out long numModels);
        
        [PreserveSig]
        new HRESULT GetParentModel(
            [In] long i,
            [Out, MarshalAs(UnmanagedType.Interface)] out IModelObject model,
            [Out, MarshalAs(UnmanagedType.Interface)] out IModelObject contextObject);
        
        [PreserveSig]
        new HRESULT AddParentModel(
            [In, MarshalAs(UnmanagedType.Interface)] IModelObject model,
            [In, MarshalAs(UnmanagedType.Interface)] IModelObject contextObject,
            [In, MarshalAs(UnmanagedType.U1)] bool @override);
        
        [PreserveSig]
        new HRESULT RemoveParentModel(
            [In, MarshalAs(UnmanagedType.Interface)] IModelObject model);
        
        [PreserveSig]
        new HRESULT GetKey(
            [In, MarshalAs(UnmanagedType.LPWStr)] string key,
            [Out, MarshalAs(UnmanagedType.Interface)] out IModelObject @object,
            [Out, MarshalAs(UnmanagedType.Interface)] out IKeyStore metadata);
        
        [PreserveSig]
        new HRESULT GetKeyReference(
            [In, MarshalAs(UnmanagedType.LPWStr)] string key,
            [Out, MarshalAs(UnmanagedType.Interface)] out IModelObject objectReference,
            [Out, MarshalAs(UnmanagedType.Interface)] out IKeyStore metadata);
        
        [PreserveSig]
        new HRESULT SetKey(
            [In, MarshalAs(UnmanagedType.LPWStr)] string key,
            [In, MarshalAs(UnmanagedType.Interface)] IModelObject @object,
            [In, MarshalAs(UnmanagedType.Interface)] IKeyStore metadata);
        
        [PreserveSig]
        new HRESULT ClearKeys();
        
        [PreserveSig]
        new HRESULT EnumerateKeys(
            [Out, MarshalAs(UnmanagedType.Interface)] out IKeyEnumerator enumerator);
        
        [PreserveSig]
        new HRESULT EnumerateKeyReferences(
            [Out, MarshalAs(UnmanagedType.Interface)] out IKeyEnumerator enumerator);
        
        [PreserveSig]
        new HRESULT SetConcept(
            [In, MarshalAs(UnmanagedType.LPStruct)] Guid conceptId,
            [In, MarshalAs(UnmanagedType.Interface)] object conceptInterface,
            [In, MarshalAs(UnmanagedType.Interface)] IKeyStore conceptMetadata);
        
        [PreserveSig]
        new HRESULT ClearConcepts();
        
        [PreserveSig]
        new HRESULT GetRawReference(
            [In] SymbolKind kind,
            [In, MarshalAs(UnmanagedType.LPWStr)] string name,
            [In] int searchFlags,
            [Out, MarshalAs(UnmanagedType.Interface)] out IModelObject @object);
        
        [PreserveSig]
        new HRESULT EnumerateRawReferences(
            [In] SymbolKind kind,
            [In] int searchFlags,
            [Out, MarshalAs(UnmanagedType.Interface)] out IRawEnumerator enumerator);
        
        [PreserveSig]
        new HRESULT SetContextForDataModel(
            [In, MarshalAs(UnmanagedType.Interface)] IModelObject dataModelObject,
            [In, MarshalAs(UnmanagedType.Interface)] object context);
        
        [PreserveSig]
        new HRESULT GetContextForDataModel(
            [In, MarshalAs(UnmanagedType.Interface)] IModelObject dataModelObject,
            [Out, MarshalAs(UnmanagedType.Interface)] out object context);
        
        [PreserveSig]
        new HRESULT Compare(
            [In, MarshalAs(UnmanagedType.Interface)] IModelObject other,
            [Out, MarshalAs(UnmanagedType.Interface)] out IModelObject ppResult);
        
        [PreserveSig]
        new HRESULT IsEqualTo(
            [In, MarshalAs(UnmanagedType.Interface)] IModelObject other,
            [Out, MarshalAs(UnmanagedType.U1)] out bool equal);
        
        [PreserveSig]
        HRESULT EnumerateOwnKeyValues(
            [Out, MarshalAs(UnmanagedType.Interface)] out IKeyEnumerator ppEnumerator);
        
        [PreserveSig]
        HRESULT EnumerateOwnKeys(
            [Out, MarshalAs(UnmanagedType.Interface)] out IKeyEnumerator ppEnumerator);
        
        [PreserveSig]
        HRESULT EnumerateOwnKeyReferences(
            [Out, MarshalAs(UnmanagedType.Interface)] out IKeyEnumerator ppEnumerator);
    }
}
