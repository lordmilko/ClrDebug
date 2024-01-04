using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("7FC09C9F-632D-48E8-A97B-2F4F2E5C1161")]
    [ComImport]
    public interface IActionQueryConcept
    {
        [PreserveSig]
        HRESULT EnumerateActions(
            [In, MarshalAs(UnmanagedType.Interface)] IModelObject contextObject,
            [Out, MarshalAs(UnmanagedType.Interface)] out IActionEnumerator actionEnumerator);
    }
}
