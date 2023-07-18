using System.Runtime.InteropServices;
#if GENERATED_MARSHALLING
using System.Runtime.InteropServices.Marshalling;
#endif

namespace ClrDebug
{
    [Guid("34625881-7EB3-4524-817B-8DB9D064C760")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
#if !GENERATED_MARSHALLING
    [ComImport]
#else
    [GeneratedComInterface]
#endif
    public partial interface IXCLRDataModule2
    {
        [PreserveSig]
        HRESULT SetJITCompilerFlags(
            [In] CorDebugJITCompilerFlags dwFlags);
    }
}
