using System.Runtime.InteropServices;
#if GENERATED_MARSHALLING
using System.Runtime.InteropServices.Marshalling;
#endif

namespace ClrDebug.DbgEng
{
    //Create this interface by requesting it from DebugCreate()

    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("046c9341-f0aa-400b-b1c3-617e1372d1a4")]
#if !GENERATED_MARSHALLING
    [ComImport]
#else
    [GeneratedComInterface]
#endif
    public partial interface IDebugTestHook
    {
        [PreserveSig]
        HRESULT SetValue(
            [In] DEBUG_HOOK_INDEX index,
            [In] long value);
    }
}
