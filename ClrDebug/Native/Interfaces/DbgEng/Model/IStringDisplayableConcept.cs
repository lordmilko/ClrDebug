using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("D28E8D70-6C00-4205-940D-501016601EA3")]
    [ComImport]
    public interface IStringDisplayableConcept
    {
        [PreserveSig]
        HRESULT ToDisplayString(
            [In, MarshalAs(UnmanagedType.Interface)] IModelObject contextObject,
            [In, MarshalAs(UnmanagedType.Interface)] IKeyStore metadata,
            [Out, MarshalAs(UnmanagedType.BStr)] out string displayString);
    }
}
