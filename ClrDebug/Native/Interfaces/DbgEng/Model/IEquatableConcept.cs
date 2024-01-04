using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("C52D5D3D-609D-4D5D-8A82-46B0ACDEC4F4")]
    [ComImport]
    public interface IEquatableConcept
    {
        [PreserveSig]
        HRESULT AreObjectsEqual(
            [In, MarshalAs(UnmanagedType.Interface)] IModelObject contextObject,
            [In, MarshalAs(UnmanagedType.Interface)] IModelObject otherObject,
            [Out, MarshalAs(UnmanagedType.U1)] out bool isEqual);
    }
}
