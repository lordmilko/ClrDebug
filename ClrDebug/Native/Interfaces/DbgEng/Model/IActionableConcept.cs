using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("2CD9906F-F1B3-4463-828A-0ADDAFE8BAAE")]
    [ComImport]
    public interface IActionableConcept
    {
        [PreserveSig]
        HRESULT EnumerateActions(
            [In, MarshalAs(UnmanagedType.Interface)] IModelObject contextObject,
            [Out, MarshalAs(UnmanagedType.Interface)] out IActionEnumerator actionEnumerator);
    }
}
