using System.Runtime.InteropServices;
#if GENERATED_MARSHALLING
using System.Runtime.InteropServices.Marshalling;
#endif

namespace ClrDebug.DbgEng
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("93ABD785-449B-4C64-931D-A2D5B2488205")]
#if !GENERATED_MARSHALLING
    [ComImport]
#else
    [GeneratedComInterface]
#endif
    public partial interface IComponentDwarfStackUnwinderInitializer
    {
        /// <summary>
        /// Initializes the DEBUG_COMPONENT_DWARF_STACK_UNWINDER component. It takes an optional stack unwinder which can be used as a fallback by the DWARF stack unwinder.<para/>
        /// (This is used for ARM targets atm.).
        /// </summary>
        [PreserveSig]
        HRESULT Initialize(
            [In, MarshalAs(UnmanagedType.Interface)] ISvcStackFrameUnwind pSecondaryUnwinder);
    }
}
