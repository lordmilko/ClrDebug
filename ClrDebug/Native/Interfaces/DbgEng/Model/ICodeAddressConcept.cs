using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("C7371568-5C78-4A00-A4AB-6EF8823184CB")]
    [ComImport]
    public interface ICodeAddressConcept
    {
        [PreserveSig]
        HRESULT GetContainingSymbol(
            [In, MarshalAs(UnmanagedType.Interface)] IModelObject pContextObject,
            [Out, MarshalAs(UnmanagedType.Interface)] out IDebugHostSymbol ppSymbol);
    }
}
