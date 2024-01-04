using System;
using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("95A7F7DD-602E-483F-9D06-A15C0EE13174")]
    [ComImport]
    public interface IDynamicConceptProviderConcept
    {
        [PreserveSig]
        HRESULT GetConcept(
            [In, MarshalAs(UnmanagedType.Interface)] IModelObject contextObject,
            [In, MarshalAs(UnmanagedType.LPStruct)] Guid conceptId,
            [Out, MarshalAs(UnmanagedType.Interface)] out object conceptInterface,
            [Out, MarshalAs(UnmanagedType.Interface)] out IKeyStore conceptMetadata,
            [Out, MarshalAs(UnmanagedType.U1)] out bool hasConcept);
        
        [PreserveSig]
        HRESULT SetConcept(
            [In, MarshalAs(UnmanagedType.Interface)] IModelObject contextObject,
            [In, MarshalAs(UnmanagedType.LPStruct)] Guid conceptId,
            [In, MarshalAs(UnmanagedType.Interface)] object conceptInterface,
            [In, MarshalAs(UnmanagedType.Interface)] IKeyStore conceptMetadata);
        
        [PreserveSig]
        HRESULT NotifyParent(
            [In, MarshalAs(UnmanagedType.Interface)] IModelObject parentModel);
        
        [PreserveSig]
        HRESULT NotifyParentChange(
            [In, MarshalAs(UnmanagedType.Interface)] IModelObject parentModel);
        
        [PreserveSig]
        HRESULT NotifyDestruct();
    }
}
