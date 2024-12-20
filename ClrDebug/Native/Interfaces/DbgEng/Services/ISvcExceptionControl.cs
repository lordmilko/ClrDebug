using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    /// <summary>
    /// Notes If a target which supports live debugging issues a state change notification to the halted state for an "exception", that "exception" should support both ISvcExceptionInformation *AND* ISvcExceptionControl.<para/>
    /// This interface is only necessary for controlling exception flow within a live target.
    /// </summary>
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("5A37C25E-4F8D-47BE-87F5-94A933824A83")]
    [ComImport]
    public interface ISvcExceptionControl
    {
        /// <summary>
        /// Indicates whether this exception is the first or second chance. If the target cannot make a determination of first/second chance, E_NOTIMPL should be returned.
        /// </summary>
        [PreserveSig]
        HRESULT IsFirstChance(
            [Out, MarshalAs(UnmanagedType.U1)] out bool isFirstChance);

        /// <summary>
        /// Indicates whether this exception will be passed onto the target or will be considered handled by the halt.
        /// </summary>
        [return: MarshalAs(UnmanagedType.U1)]
        bool WillPassToTarget();

        /// <summary>
        /// Indicates that this exception should be passed to the target. Flags are currently reserved and should be set to zero.<para/>
        /// If this exception is a form that CANNOT be passed to the target, E_ILLEGAL_METHOD_CALL should be returned. If the target is incapable of passing the exception on, E_NOTIMPL should be returned.<para/>
        /// NOTE: The exception is not *ACTUALLY* passed to the target until the target resumes execution via a call to the step controller.
        /// </summary>
        [PreserveSig]
        HRESULT PassToTarget(
            [In] int flags);

        /// <summary>
        /// Indicates that this exception should *NOT* be passed to the target and should be considered handled by the debugger.<para/>
        /// Flags are currently reserved and should be set to zero. If this exception is a form that CANNOT be passed to the target, E_ILLEGAL_METHOD_CALL should be returned.<para/>
        /// If the target is incapable of handling exceptions without passing them on, E_NOTIMPL should be returned. NOTE: The excepiton is not *ACTUALLY* handled and dismissed until the target resumes execution via a call to the step controller.
        /// </summary>
        [PreserveSig]
        HRESULT Handle(
            [In] int flags);
    }
}
