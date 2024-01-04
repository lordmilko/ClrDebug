using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("A4952C59-7144-4C76-873B-6046C0955FFC")]
    [ComImport]
    public interface IObjectWrapperConcept
    {
        [PreserveSig]
        HRESULT GetWrappedObject(
            [In, MarshalAs(UnmanagedType.Interface)] IModelObject pContextObject,
            [Out, MarshalAs(UnmanagedType.Interface)] out IModelObject wrappedObject,
            [Out] out WrappedObjectPreference pUsagePreference);
    }
}
