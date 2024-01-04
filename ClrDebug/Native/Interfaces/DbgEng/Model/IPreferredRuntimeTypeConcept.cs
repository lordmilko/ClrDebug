using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("9D6C1D7B-A76F-4618-8068-5F76BD9A4E8A")]
    [ComImport]
    public interface IPreferredRuntimeTypeConcept
    {
        [PreserveSig]
        HRESULT CastToPreferredRuntimeType(
            [In, MarshalAs(UnmanagedType.Interface)] IModelObject contextObject,
            [Out, MarshalAs(UnmanagedType.Interface)] out IModelObject @object);
    }
}
