using System.Runtime.InteropServices;
#if GENERATED_MARSHALLING
using System.Runtime.InteropServices.Marshalling;
#endif

namespace ClrDebug.DbgEng
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("36A82767-6ED1-4E47-A7A7-D517A8691534")]
#if !GENERATED_MARSHALLING
    [ComImport]
#else
    [GeneratedComInterface]
#endif
    public partial interface IComponentStackUnwindContextInitializer
    {
        /// <summary>
        /// Initializes the DEBUG_COMPONENTSVC_STACKUNWIND_CONTEXT component.
        /// </summary>
        [PreserveSig]
        HRESULT Initialize(
            [In, MarshalAs(UnmanagedType.Interface)] ISvcProcess unwindProcess,
            [In, MarshalAs(UnmanagedType.Interface)] ISvcThread unwindThread);
    }
}
