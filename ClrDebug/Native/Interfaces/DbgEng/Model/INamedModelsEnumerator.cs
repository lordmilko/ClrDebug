using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("47BBFC0B-0B20-4E0C-882B-465D6CCAC97C")]
    [ComImport]
    public interface INamedModelsEnumerator
    {
        [PreserveSig]
        HRESULT Reset();
        
        [PreserveSig]
        HRESULT GetNext(
            [Out, MarshalAs(UnmanagedType.BStr)] out string pModelName,
            [Out, MarshalAs(UnmanagedType.Interface)] out IModelObject ppModel);
    }
}
