using System;
using System.Runtime.InteropServices;
using ClrDebug.TypeLib;

namespace ClrDebug.DbgEng
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("E28C7893-3F4B-4B96-BACA-293CDC55F45D")]
    [ComImport]
    public interface IModelObject
    {
        [PreserveSig]
        HRESULT GetContext(
            [Out, MarshalAs(UnmanagedType.Interface)] out IDebugHostContext context);
        
        [PreserveSig]
        HRESULT GetKind(
            [Out] out ModelObjectKind kind);
        
        [PreserveSig]
        HRESULT GetIntrinsicValue(
            [Out, MarshalAs(UnmanagedType.Struct)] out object intrinsicData);
        
        [PreserveSig]
        HRESULT GetIntrinsicValueAs(
            [In] VARENUM vt,
            [Out, MarshalAs(UnmanagedType.Struct)] out object intrinsicData);
        
        [PreserveSig]
        HRESULT GetKeyValue(
            [In, MarshalAs(UnmanagedType.LPWStr)] string key,
            [Out, MarshalAs(UnmanagedType.Interface)] out IModelObject @object,
            [Out, MarshalAs(UnmanagedType.Interface)] out IKeyStore metadata);
        
        [PreserveSig]
        HRESULT SetKeyValue(
            [In, MarshalAs(UnmanagedType.LPWStr)] string key,
            [In, MarshalAs(UnmanagedType.Interface)] IModelObject @object);
        
        [PreserveSig]
        HRESULT EnumerateKeyValues(
            [Out, MarshalAs(UnmanagedType.Interface)] out IKeyEnumerator enumerator);
        
        [PreserveSig]
        HRESULT GetRawValue(
            [In] SymbolKind kind,
            [In, MarshalAs(UnmanagedType.LPWStr)] string name,
            [In] int searchFlags,
            [Out, MarshalAs(UnmanagedType.Interface)] out IModelObject @object);
        
        [PreserveSig]
        HRESULT EnumerateRawValues(
            [In] SymbolKind kind,
            [In] int searchFlags,
            [Out, MarshalAs(UnmanagedType.Interface)] out IRawEnumerator enumerator);
        
        [PreserveSig]
        HRESULT Dereference(
            [Out, MarshalAs(UnmanagedType.Interface)] out IModelObject @object);
        
        [PreserveSig]
        HRESULT TryCastToRuntimeType(
            [Out, MarshalAs(UnmanagedType.Interface)] out IModelObject runtimeTypedObject);
        
        [PreserveSig]
        HRESULT GetConcept(
            [In, MarshalAs(UnmanagedType.LPStruct)] Guid conceptId,
            [Out, MarshalAs(UnmanagedType.Interface)] out object conceptInterface,
            [Out, MarshalAs(UnmanagedType.Interface)] out IKeyStore conceptMetadata);
        
        [PreserveSig]
        HRESULT GetLocation(
            [Out] out Location location);
        
        [PreserveSig]
        HRESULT GetTypeInfo(
            [Out, MarshalAs(UnmanagedType.Interface)] out IDebugHostType type);
        
        [PreserveSig]
        HRESULT GetTargetInfo(
            [Out] out Location location,
            [Out, MarshalAs(UnmanagedType.Interface)] out IDebugHostType type);
        
        [PreserveSig]
        HRESULT GetNumberOfParentModels(
            [Out] out long numModels);
        
        [PreserveSig]
        HRESULT GetParentModel(
            [In] long i,
            [Out, MarshalAs(UnmanagedType.Interface)] out IModelObject model,
            [Out, MarshalAs(UnmanagedType.Interface)] out IModelObject contextObject);
        
        [PreserveSig]
        HRESULT AddParentModel(
            [In, MarshalAs(UnmanagedType.Interface)] IModelObject model,
            [In, MarshalAs(UnmanagedType.Interface)] IModelObject contextObject,
            [In, MarshalAs(UnmanagedType.U1)] bool @override);
        
        [PreserveSig]
        HRESULT RemoveParentModel(
            [In, MarshalAs(UnmanagedType.Interface)] IModelObject model);
        
        [PreserveSig]
        HRESULT GetKey(
            [In, MarshalAs(UnmanagedType.LPWStr)] string key,
            [Out, MarshalAs(UnmanagedType.Interface)] out IModelObject @object,
            [Out, MarshalAs(UnmanagedType.Interface)] out IKeyStore metadata);
        
        [PreserveSig]
        HRESULT GetKeyReference(
            [In, MarshalAs(UnmanagedType.LPWStr)] string key,
            [Out, MarshalAs(UnmanagedType.Interface)] out IModelObject objectReference,
            [Out, MarshalAs(UnmanagedType.Interface)] out IKeyStore metadata);
        
        [PreserveSig]
        HRESULT SetKey(
            [In, MarshalAs(UnmanagedType.LPWStr)] string key,
            [In, MarshalAs(UnmanagedType.Interface)] IModelObject @object,
            [In, MarshalAs(UnmanagedType.Interface)] IKeyStore metadata);
        
        [PreserveSig]
        HRESULT ClearKeys();
        
        [PreserveSig]
        HRESULT EnumerateKeys(
            [Out, MarshalAs(UnmanagedType.Interface)] out IKeyEnumerator enumerator);
        
        [PreserveSig]
        HRESULT EnumerateKeyReferences(
            [Out, MarshalAs(UnmanagedType.Interface)] out IKeyEnumerator enumerator);
        
        [PreserveSig]
        HRESULT SetConcept(
            [In, MarshalAs(UnmanagedType.LPStruct)] Guid conceptId,
            [In, MarshalAs(UnmanagedType.Interface)] object conceptInterface,
            [In, MarshalAs(UnmanagedType.Interface)] IKeyStore conceptMetadata);
        
        [PreserveSig]
        HRESULT ClearConcepts();
        
        [PreserveSig]
        HRESULT GetRawReference(
            [In] SymbolKind kind,
            [In, MarshalAs(UnmanagedType.LPWStr)] string name,
            [In] int searchFlags,
            [Out, MarshalAs(UnmanagedType.Interface)] out IModelObject @object);
        
        [PreserveSig]
        HRESULT EnumerateRawReferences(
            [In] SymbolKind kind,
            [In] int searchFlags,
            [Out, MarshalAs(UnmanagedType.Interface)] out IRawEnumerator enumerator);
        
        [PreserveSig]
        HRESULT SetContextForDataModel(
            [In, MarshalAs(UnmanagedType.Interface)] IModelObject dataModelObject,
            [In, MarshalAs(UnmanagedType.Interface)] object context);
        
        [PreserveSig]
        HRESULT GetContextForDataModel(
            [In, MarshalAs(UnmanagedType.Interface)] IModelObject dataModelObject,
            [Out, MarshalAs(UnmanagedType.Interface)] out object context);
        
        [PreserveSig]
        HRESULT Compare(
            [In, MarshalAs(UnmanagedType.Interface)] IModelObject other,
            [Out, MarshalAs(UnmanagedType.Interface)] out IModelObject ppResult);
        
        [PreserveSig]
        HRESULT IsEqualTo(
            [In, MarshalAs(UnmanagedType.Interface)] IModelObject other,
            [Out, MarshalAs(UnmanagedType.U1)] out bool equal);
    }
}
