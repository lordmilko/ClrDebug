using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    [Guid("34625881-7EB3-4524-817B-8DB9D064C760")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [ComImport]
    public interface IXCLRDataModule2
    {
        [PreserveSig]
        HRESULT SetJITCompilerFlags(
            [In] int dwFlags);
    }
}
