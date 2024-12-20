using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("862E028B-A31A-4AAA-9661-6470F3D50B25")]
    [ComImport]
    public interface ISvcBreakpoint
    {
        /// <summary>
        /// Gets the kind of breakpoint that this ISvcBreakpoint represents.
        /// </summary>
        [PreserveSig]
        BreakpointKind GetKind();

        /// <summary>
        /// Gets the process key which this breakpoint is set within.
        /// </summary>
        [PreserveSig]
        long GetProcessKey();

        /// <summary>
        /// Gets the address for this breakpoint.
        /// </summary>
        [PreserveSig]
        long GetAddress();

        /// <summary>
        /// Deletes the breakpoint.
        /// </summary>
        [PreserveSig]
        HRESULT Delete();

        /// <summary>
        /// Disables the breakpoint. Disable is an on/off operation. You cannot disable a disabled breakpoint. Calling Disable on a disabled breakpoint will return S_FALSE as an indication that the breakpoint is disabled BUT that the Disable call was not the actor which performed the operation.
        /// </summary>
        [PreserveSig]
        HRESULT Disable();

        /// <summary>
        /// Enables the breakpoint. Enable is an on/off operation. You cannot enable an enabled breakpoint. Calling Enable on an enabled breakpoint will return S_FALSE as an indication that the breakpoint is enabled BUT that the Enable call was not the actor which performed the operation.
        /// </summary>
        [PreserveSig]
        HRESULT Enable();

        /// <summary>
        /// Gets the data access flags for this breakpoint. This method will fail when called on a breakpoint which is not a data breakpoint.
        /// </summary>
        [PreserveSig]
        HRESULT GetDataAccessFlags(
            [Out] out DataAccessFlags pFlags);

        /// <summary>
        /// Gets the data access width for this breakpoint. This method will fail when called on a breakpoint which is not a data brakpoint.
        /// </summary>
        [PreserveSig]
        HRESULT GetDataWidth(
            [Out] out long pWidth);
    }
}
