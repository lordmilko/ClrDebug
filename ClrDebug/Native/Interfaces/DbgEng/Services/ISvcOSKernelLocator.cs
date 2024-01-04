using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("995F51EF-FE22-441E-BCE6-0F6FECFB9A0A")]
    [ComImport]
    public interface ISvcOSKernelLocator
    {
        [PreserveSig]
        HRESULT GetKernelBase(
            [Out] out long pKernelBase);
        
        [PreserveSig]
        HRESULT CreateOSKernelComponent(
            [Out, MarshalAs(UnmanagedType.Interface)] out IDebugServiceLayer ppServiceLayer);
    }
}
