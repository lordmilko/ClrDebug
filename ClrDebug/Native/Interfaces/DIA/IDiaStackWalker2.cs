using System.Runtime.InteropServices;

namespace ClrDebug.DIA
{
    [Guid("7C185885-A015-4CAC-9411-0F4FB39B1F3A")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [ComImport]
    public interface IDiaStackWalker2 : IDiaStackWalker
    {
        [PreserveSig]
        new HRESULT getEnumFrames(
            [MarshalAs(UnmanagedType.Interface), In] IDiaStackWalkHelper pHelper,
            [Out, MarshalAs(UnmanagedType.Interface)] out IDiaEnumStackFrames ppenum);

        [PreserveSig]
        new HRESULT getEnumFrames2(
            [In] CV_CPU_TYPE_e cpuid,
            [MarshalAs(UnmanagedType.Interface), In] IDiaStackWalkHelper pHelper,
            [Out, MarshalAs(UnmanagedType.Interface)] out IDiaEnumStackFrames ppenum);
    }
}
