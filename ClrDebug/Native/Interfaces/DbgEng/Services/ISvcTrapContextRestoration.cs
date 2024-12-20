using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("3870640B-8D1E-469D-8552-F38D48E28766")]
    [ComImport]
    public interface ISvcTrapContextRestoration
    {
        /// <summary>
        /// Given a register context of a trap handler (e.g.: a signal frame), restores the register context at the trap point.<para/>
        /// This operates in one of two modes - trapContext == 0: the input context is effectively for a stack frame and the location of the trap context should be determined from the trapKind and the input context.<para/>
        /// The restored context is a copy of the input context overwritten with the register values of the trap context. - trapContext != 0: the location of the trap context is given by trapContext.<para/>
        /// The restored context is a copy of the input context (which may just be an empty register context for the architecture) overwritten with the register values of the rap context.
        /// </summary>
        [PreserveSig]
        HRESULT ReadTrapContext(
            [In] TrapContextKind trapKind,
            [In, MarshalAs(UnmanagedType.Interface)] ISvcAddressContext pAddressContext,
            [In, MarshalAs(UnmanagedType.Interface)] ISvcRegisterContext pInContext,
            [In] long trapContext,
            [Out, MarshalAs(UnmanagedType.Interface)] out ISvcRegisterContext ppOutContext);
    }
}
