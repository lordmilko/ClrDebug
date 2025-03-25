using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
#if GENERATED_MARSHALLING
using System.Runtime.InteropServices.Marshalling;
#endif
using System.Threading;

namespace ClrDebug
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("B35DD495-A555-463B-9BE9-C55338486BB8")]
#if !GENERATED_MARSHALLING
    [ComImport]
#else
    [GeneratedComInterface]
#endif
    public partial interface ICorDebugHeapValue4
    {
        [PreserveSig]
        HRESULT CreatePinnedHandle(
            [Out] out ICorDebugHandleValue ppHandle);
    }
}
