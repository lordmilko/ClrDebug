using System.Runtime.InteropServices;
#if GENERATED_MARSHALLING
using System.Runtime.InteropServices.Marshalling;
#endif

namespace ClrDebug.DbgEng
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("A325D2E2-39BB-48D9-875A-8DE64F62D282")]
#if !GENERATED_MARSHALLING
    [ComImport]
#else
    [GeneratedComInterface]
#endif
    public partial interface IComponentPseudoStreamMapperInitializer
    {
        /// <summary>
        /// Initializes the component.
        /// </summary>
        [PreserveSig]
        HRESULT Initialize(
            [In, MarshalAs(UnmanagedType.Interface)] ISvcDebugSourceFile pUnderlyingFile);
    }
}
