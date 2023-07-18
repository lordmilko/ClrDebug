using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
#if GENERATED_MARSHALLING
using System.Runtime.InteropServices.Marshalling;
#endif

namespace ClrDebug
{
    /// <summary>
    /// Provides methods that allow a code profiler to communicate with the common language runtime (CLR) to control how the JIT compiler should generate code when recompiling a specific method.
    /// </summary>
    /// <remarks>
    /// The ICorProfilerFunctionControl interface provides methods for controlling code generation for a single recompiled
    /// function. The profiler obtains an instance of this interface through the <see cref="ICorProfilerCallback4.GetReJITParameters"/>
    /// callback. Each instance of ICorProfilerFunctionControl controls all instances of one function.
    /// </remarks>
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("F0963021-E1EA-4732-8581-E01B0BD3C0C6")]
#if !GENERATED_MARSHALLING
    [ComImport]
#else
    [GeneratedComInterface]
#endif
    public partial interface ICorProfilerFunctionControl
    {
        /// <summary>
        /// Sets one or more flags from the COR_PRF_CODEGEN_FLAGS enumeration to control code generation for a just-in-time (JIT) recompiled function.
        /// </summary>
        /// <param name="flags">[in] One or more flags from the COR_PRF_CODEGEN_FLAGS enumeration.</param>
        /// <remarks>
        /// The profiler obtains an instance of this interface through the <see cref="ICorProfilerCallback4.GetReJITParameters"/>
        /// callback. SetCodegenFlags allows the profiler to control the code generation for the recompiled function. As with
        /// all other JIT recompilation parameters, the code generation flags apply to all instances of the function. The JIT
        /// compiler considers these compilation flags, along with other flags specified by other sources, when compiling a
        /// function. The other sources include the debugger, global flags set by the profiler on startup by using the <see
        /// cref="ICorProfilerInfo.SetEventMask"/> method (with the values COR_PRF_DISABLE_INLINING and COR_PRF_DISABLE_OPTIMIZATIONS),
        /// and the profiler’s <see cref="ICorProfilerCallback.JITInlining"/> callback. The JIT compiler gives precedence to
        /// a source that requests the least amount of optimizing. For example, if the profiler specifies COR_PRF_DISABLE_INLINING
        /// on startup, but does not specify COR_PRF_CODEGEN_DISABLE_INLINING in the <see cref="SetCodegenFlags"/> callback,
        /// inlining is still disabled. Similarly, if the profiler does not specify COR_PRF_CODEGEN_DISABLE_INLINING in SetCodegenFlags,
        /// but then disables inlining by using the <see cref="ICorProfilerCallback.JITInlining"/> callback, inlining is disabled.
        /// </remarks>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT SetCodegenFlags(
            [In] COR_PRF_CODEGEN_FLAGS flags);

        /// <summary>
        /// Replaces the Common Intermediate Language (CIL) body of the method.
        /// </summary>
        /// <param name="cbNewILMethodHeader">[in] The total size of the new CIL, including the header and any structures that come after the body.</param>
        /// <param name="pbNewILMethodHeader">[in] A pointer to the new CIL header.</param>
        /// <returns>
        /// This method returns the following specific HRESULTs.
        /// 
        /// | HRESULT | Description                     |
        /// | ------- | ------------------------------- |
        /// | S_OK    | The replacement was successful. |
        /// </returns>
        /// <remarks>
        /// Unlike the <see cref="ICorProfilerInfo.SetILFunctionBody"/> method, the SetILFunctionBody method manages the memory
        /// required for the new CIL body. This means that the CIL body provided by the profiler does not have to be allocated
        /// by using the <see cref="IMethodMalloc"/> interface or allocated within a particular range. It can be allocated
        /// on any heap. The profiler can free the memory used for its CIL body after SetILFunctionBody returns.
        /// </remarks>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT SetILFunctionBody(
            [In] int cbNewILMethodHeader,
            [In] IntPtr pbNewILMethodHeader);

        /// <summary>
        /// Sets a code map for the specified function by using the specified Common Intermediate Language (CIL) map entries.
        /// </summary>
        /// <param name="cILMapEntries">[in] The number of entries in the map.</param>
        /// <param name="rgILMapEntries">[in] The caller-allocated array of COR_IL_MAP entries. The interpretation of these entries is the same as for the <see cref="ICorProfilerInfo.SetILInstrumentedCodeMap"/> method.</param>
        /// <remarks>
        /// Setting the mapping by calling this method allows the debugger to retrieve the mapping by calling ICorDebugILCode2.
        /// It also allows the debugger to use the mapping internally when calculating IL offsets for stack traces and variable
        /// lifetimes.
        /// </remarks>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT SetILInstrumentedCodeMap(
            [In] int cILMapEntries,
            [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] COR_IL_MAP[] rgILMapEntries);
    }
}
