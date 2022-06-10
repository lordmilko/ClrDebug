using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    /// <summary>
    /// Represents a step in code execution that is performed by a debugger, serves as an identifier between the issuance and completion of a command, and provides a way to cancel a step.
    /// </summary>
    /// <remarks>
    /// The <see cref="ICorDebugStepper"/> interface serves the following purposes: There can be more than one stepper per thread. For
    /// example, a breakpoint may be hit while stepping over a function, and the user may wish to start a new stepping
    /// operation inside that function. It is up to the debugger to determine how to handle this situation. The debugger
    /// may want to cancel the original stepping operation or nest the two operations. The <see cref="ICorDebugStepper"/> interface supports
    /// both choices. A stepper may migrate between threads if the common language runtime (CLR) makes a cross-threaded,
    /// marshalled call.
    /// </remarks>
    [Guid("CC7BCAEC-8A68-11D2-983C-0000F808342D")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [ComImport]
    public interface ICorDebugStepper
    {
        /// <summary>
        /// Gets a value that indicates whether this <see cref="ICorDebugStepper"/> is currently executing a step.
        /// </summary>
        /// <param name="pbActive">[out] Returns true if the stepper is currently executing a step; otherwise, returns false.</param>
        /// <remarks>
        /// Any step action remains active until the debugger receives a <see cref="ICorDebugManagedCallback.StepComplete"/>
        /// call, which automatically deactivates the stepper. A stepper may also be deactivated prematurely by calling <see
        /// cref="Deactivate"/> before the callback condition is reached.
        /// </remarks>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT IsActive(out int pbActive);

        /// <summary>
        /// Causes this <see cref="ICorDebugStepper"/> to cancel the last step command that it received.
        /// </summary>
        /// <remarks>
        /// A new stepping command may be issued after the most recently received step command has been canceled.
        /// </remarks>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT Deactivate();

        /// <summary>
        /// Sets a value that specifies the types of code that are stepped into.
        /// </summary>
        /// <param name="mask">[in] A combination of values of the <see cref="CorDebugIntercept"/> enumeration that specifies the types of code.</param>
        /// <remarks>
        /// If the bit for an interceptor is set, the stepper will complete when the given type of intercepting code is encountered.
        /// If the bit is cleared, the intercepting code will be skipped. The SetInterceptMask method may have unforeseen interactions
        /// with <see cref="SetUnmappedStopMask"/> (from the user's point of view). For example, if the only visible (that
        /// is, non-internal) portion of class initialization code lacks mapping information and STOP_NO_MAPPING_INFO isn't
        /// set (see the <see cref="SetUnmappedStopMask"/> method and the <see cref="CorDebugUnmappedStop"/> enumeration), the stepper will
        /// step over the class initialization. By default, only the INTERCEPT_NONE value of the <see cref="CorDebugIntercept"/> enumeration
        /// will be used.
        /// </remarks>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT SetInterceptMask([In] CorDebugIntercept mask);

        /// <summary>
        /// Sets a value that specifies the type of unmapped code in which execution will halt.
        /// </summary>
        /// <param name="mask">[in] A value of the <see cref="CorDebugUnmappedStop"/> enumeration that specifies the type of unmapped code in which the debugger will halt execution.<para/>
        /// The default value is STOP_OTHER_UNMAPPED. The value STOP_UNMANAGED is only valid with interop debugging.</param>
        /// <remarks>
        /// When the debugger finds a just-in-time (JIT) compilation that has no corresponding mapping to Microsoft intermediate
        /// language (MSIL), it halts execution if the flag specifying that type of unmapped code has been set; otherwise,
        /// stepping transparently continues. If the debugger doesn't use a stepper to enter a method, then it won't necessarily
        /// step over unmapped code.
        /// </remarks>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT SetUnmappedStopMask([In] CorDebugUnmappedStop mask);

        /// <summary>
        /// Causes this <see cref="ICorDebugStepper"/> to single-step through its containing thread, and optionally, to continue single-stepping through functions that are called within the thread.
        /// </summary>
        /// <param name="bStepIn">[in] Set to true to step into a function that is called within the thread. Set to false to step over the function.</param>
        /// <remarks>
        /// The step completes when the common language runtime performs the next managed instruction in this stepper's frame.
        /// If Step is called on a stepper, which is not in managed code, the step will complete when the next managed code
        /// instruction is executed by the thread.
        /// </remarks>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT Step([In] int bStepIn);

        /// <summary>
        /// Causes this <see cref="ICorDebugStepper"/> to single-step through its containing thread, and to return when it reaches code beyond the last of the specified ranges.
        /// </summary>
        /// <param name="bStepIn">[in] Set to true to step into a function that is called within the thread. Set to false to step over the function.</param>
        /// <param name="ranges">[in] An array of <see cref="COR_DEBUG_STEP_RANGE"/> structures, each of which specifies a range.</param>
        /// <param name="cRangeCount">[in] The size of the ranges array.</param>
        /// <remarks>
        /// The StepRange method works like the <see cref="Step"/> method, except that it does not complete until code outside
        /// the given range is reached. This can be more efficient than stepping one instruction at a time. Ranges are specified
        /// as a list of offset pairs from the start of the stepper's frame. Ranges are relative to the Microsoft intermediate
        /// language (MSIL) code of a method. Call <see cref="SetRangeIL"/> with false to make the ranges relative to the native
        /// code of a method.
        /// </remarks>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT StepRange([In] int bStepIn, [In] ref COR_DEBUG_STEP_RANGE ranges, [In] uint cRangeCount);

        /// <summary>
        /// Causes this <see cref="ICorDebugStepper"/> to single-step through its containing thread, and to complete when the current frame returns control to the calling frame.
        /// </summary>
        /// <remarks>
        /// A StepOut operation will complete after returning normally from the current frame to the calling frame. If StepOut
        /// is called when in unmanaged code, the step will complete when the current frame returns to the managed code that
        /// called it. In the .NET Framework version 2.0, do not use StepOut with the STOP_UNMANAGED flag set because it will
        /// fail. (Use <see cref="SetUnmappedStopMask"/> to set flags for stepping.) Interop debuggers must step out to native
        /// code themselves.
        /// </remarks>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT StepOut();

        /// <summary>
        /// Sets a value that specifies whether calls to <see cref="StepRange"/> pass argument values that are relative to the native code or relative to Microsoft intermediate language (MSIL) code of the method that is being stepped through.
        /// </summary>
        /// <param name="bIL">[in] Set to true to specify that the ranges are relative to the MSIL code. Set to false to specify that the ranges are relative to the native code.<para/>
        /// The default value is true.</param>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT SetRangeIL([In] int bIL);
    }
}