using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("A7830646-9F0C-4A31-BA19-503F33E6C8A3")]
    [ComImport]
    public interface IComparableConcept
    {
        [PreserveSig]
        HRESULT CompareObjects(
            [In, MarshalAs(UnmanagedType.Interface)] IModelObject contextObject,
            [In, MarshalAs(UnmanagedType.Interface)] IModelObject otherObject,
            [Out] out int comparisonResult);
    }
}
