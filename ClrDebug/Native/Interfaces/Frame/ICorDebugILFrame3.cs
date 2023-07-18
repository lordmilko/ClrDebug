using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
#if GENERATED_MARSHALLING
using System.Runtime.InteropServices.Marshalling;
#endif

namespace ClrDebug
{
    /// <summary>
    /// Provides a method that encapsulates the return value of a function. <see cref="ICorDebugILFrame3"/> is a logical extension of the <see cref="ICorDebugILFrame"/> and <see cref="ICorDebugILFrame2"/> interfaces.
    /// </summary>
    [Guid("9A9E2ED6-04DF-4FE0-BB50-CAB64126AD24")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
#if !GENERATED_MARSHALLING
    [ComImport]
#else
    [GeneratedComInterface]
#endif
    public partial interface ICorDebugILFrame3
    {
        /// <summary>
        /// Gets an "ICorDebugValue" object that encapsulates the return value of a function.
        /// </summary>
        /// <param name="ilOffset">The IL offset. See the Remarks section.</param>
        /// <param name="ppReturnValue">A pointer to the address of an "ICorDebugValue" interface object that provides information about the return value of a function call.</param>
        /// <remarks>
        /// This method is used along with the <see cref="ICorDebugCode3.GetReturnValueLiveOffset"/> method to get the return
        /// value of a method. It is particularly useful in the case of methods whose return values are ignored, as in the
        /// following two code examples. The first example calls the <see cref="int.TryParse(string, out int)"/> method, but
        /// ignores the method's return value. [!code-csharpUnmanaged.Debugging.MRV#1][!code-vbUnmanaged.Debugging.MRV#1] The
        /// second example illustrates a much more common problem in debugging. Because a method is used as an argument in
        /// a method call, its return value is accessible only when the debugger steps through the called method. In many cases,
        /// particularly when the called method is defined in an external library, that is not possible. [!code-csharpUnmanaged.Debugging.MRV#2][!code-vbUnmanaged.Debugging.MRV#2]
        /// If you pass the <see cref="ICorDebugCode3.GetReturnValueLiveOffset"/> method an IL offset to a function call site,
        /// it returns one or more native offsets. The debugger can then set breakpoints on these native offsets in the function.
        /// When the debugger hits one of the breakpoints, you can then pass the same IL offset that you passed to this method
        /// to get the return value. The debugger should then clear all the breakpoints that it set. The IL offset specified
        /// by the ILOffset parameter should be at a function call site, and the debuggee should be stopped at a breakpoint
        /// set at the native offset returned by the <see cref="ICorDebugCode3.GetReturnValueLiveOffset"/> method for the same
        /// IL offset. If the debuggee is not stopped at the correct location for the specified IL offset, the API will fail.
        /// If the function call doesn't return a value, the API will fail. The ICorDebugILFrame3::GetReturnValueForILOffset
        /// method is available only on x86-based and AMD64 systems.
        /// </remarks>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT GetReturnValueForILOffset(
            [In] int ilOffset,
            [Out, MarshalAs(UnmanagedType.Interface)] out ICorDebugValue ppReturnValue);
    }
}
