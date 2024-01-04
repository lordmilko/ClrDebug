using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("D1FAD99F-3F53-4457-850C-8051DF2D3FB5")]
    [ComImport]
    public interface IIndexableConcept
    {
        [PreserveSig]
        HRESULT GetDimensionality(
            [In, MarshalAs(UnmanagedType.Interface)] IModelObject contextObject,
            [Out] out long dimensionality);
        
        [PreserveSig]
        HRESULT GetAt(
            [In, MarshalAs(UnmanagedType.Interface)] IModelObject contextObject,
            [In] long indexerCount,
            [In, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.Interface, SizeParamIndex = 1)] IModelObject[] indexers,
            [Out, MarshalAs(UnmanagedType.Interface)] out IModelObject @object,
            [Out, MarshalAs(UnmanagedType.Interface)] out IKeyStore metadata);
        
        [PreserveSig]
        HRESULT SetAt(
            [In, MarshalAs(UnmanagedType.Interface)] IModelObject contextObject,
            [In] long indexerCount,
            [In, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.Interface, SizeParamIndex = 1)] IModelObject[] indexers,
            [In, MarshalAs(UnmanagedType.Interface)] IModelObject value);
    }
}
