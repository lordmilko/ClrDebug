using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("8E18CBC7-B80A-4C42-A10D-A56E17A555CE")]
    [ComImport]
    public interface ISvcOSKernelObjectAccessor
    {
        [PreserveSig]
        HRESULT GetObjectFromAssociatedKernelObject(
            [In] long kernelObjectAddress,
            [Out, MarshalAs(UnmanagedType.Interface)] out object serviceObject);
    }
}
