using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("F5D49D0C-0B02-4301-9C9B-B3A6037628F3")]
    [ComImport]
    public interface IIterableConcept
    {
        [PreserveSig]
        HRESULT GetDefaultIndexDimensionality(
            [In, MarshalAs(UnmanagedType.Interface)] IModelObject contextObject,
            [Out] out long dimensionality);
        
        [PreserveSig]
        HRESULT GetIterator(
            [In, MarshalAs(UnmanagedType.Interface)] IModelObject contextObject,
            [Out, MarshalAs(UnmanagedType.Interface)] out IModelIterator iterator);
    }
}
