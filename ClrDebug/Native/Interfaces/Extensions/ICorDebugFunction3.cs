using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
#if GENERATED_MARSHALLING
using System.Runtime.InteropServices.Marshalling;
#endif

namespace ClrDebug
{
    /// <summary>
    /// [Supported in the .NET Framework 4.5.2 and later versions] Logically extends the <see cref="ICorDebugFunction"/> interface to provide access to code from a ReJIT request.
    /// </summary>
    [Guid("09B70F28-E465-482D-99E0-81A165EB0532")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
#if !GENERATED_MARSHALLING
    [ComImport]
#else
    [GeneratedComInterface]
#endif
    public partial interface ICorDebugFunction3
    {
        /// <summary>
        /// [Supported in the .NET Framework 4.5.2 and later versions] Gets an interface pointer to an <see cref="ICorDebugILCode"/> that contains the IL from an active ReJIT request.
        /// </summary>
        /// <param name="ppReJitedILCode">A pointer to the IL from an active ReJIT request.</param>
        /// <remarks>
        /// If the method represented by this <see cref="ICorDebugFunction3"/> object has an active ReJIT request, ppReJitedILCode returns
        /// a pointer to its IL. If there is no active request, which is a common case, then ppReJitedILCode is null. A ReJIT
        /// request becomes active just after execution returns from the ICorProfilerCallback4.GetReJITParameters method call.
        /// It may not yet be JIT-compiled, and threads may still be executing in the original version of the code. A ReJIT
        /// request becomes inactive during the profiler's call to the ICorProfilerInfo4.RequestRevert method. Even after the
        /// IL is reverted, a thread can still be executing in the JIT-recompiled (ReJIT) code.
        /// </remarks>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT GetActiveReJitRequestILCode(
            [Out, MarshalAs(UnmanagedType.Interface)] out ICorDebugILCode ppReJitedILCode);
    }
}
