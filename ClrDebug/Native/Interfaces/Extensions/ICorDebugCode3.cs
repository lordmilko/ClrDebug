using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
#if GENERATED_MARSHALLING
using System.Runtime.InteropServices.Marshalling;
#endif

namespace ClrDebug
{
    /// <summary>
    /// Provides a method that extends "ICorDebugCode" and "ICorDebugCode2" to provide information about a managed return value.
    /// </summary>
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("D13D3E88-E1F2-4020-AA1D-3D162DCBE966")]
#if !GENERATED_MARSHALLING
    [ComImport]
#else
    [GeneratedComInterface]
#endif
    public partial interface ICorDebugCode3
    {
        /// <summary>
        /// For a specified IL offset, gets the native offsets where a breakpoint should be placed so that the debugger can obtain the return value from a function.
        /// </summary>
        /// <param name="ilOffset">The IL offset. It must be a function call site or the function call will fail.</param>
        /// <param name="bufferSize">The number of bytes available to store pOffsets.</param>
        /// <param name="pFetched">A pointer to the number of offsets actually returned. Usually, its value is 1, but a single IL instruction can map to multiple CALL assembly instructions.</param>
        /// <param name="pOffsets">An array of native offsets. Typically, pOffsets contains a single offset, although a single IL instruction can map to multiple map to multiple CALL assembly instructions.</param>
        /// <remarks>
        /// This method is used along with the <see cref="ICorDebugILFrame3.GetReturnValueForILOffset"/> method to get the
        /// return value of a method that returns a reference type. Passing an IL offset to a function call site to this method
        /// returns one or more native offsets. The debugger can then set breakpoints on these native offsets in the function.
        /// When the debugger hits one of the breakpoints, you can then pass the same IL offset that you passed to this method
        /// to the <see cref="ICorDebugILFrame3.GetReturnValueForILOffset"/> method to get the return value. The debugger should
        /// then clear all the breakpoints that it set. The function returns the <see cref="HRESULT"/> values shown in the following table.
        /// The <see cref="GetReturnValueLiveOffset"/> method is available only on x86-based and AMD64 systems.
        /// </remarks>
        [PreserveSig]
        HRESULT GetReturnValueLiveOffset(
            [In] int ilOffset,
            [In] int bufferSize,
            [Out] out int pFetched,
            [Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] int[] pOffsets); //The docs say that bufferSize describes bytes, but the actual code in dotnet/runtime contradicts that
    }
}
