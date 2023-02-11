using System;

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
    public class CorProfilerFunctionControl : ComObject<ICorProfilerFunctionControl>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CorProfilerFunctionControl"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
        public CorProfilerFunctionControl(ICorProfilerFunctionControl raw) : base(raw)
        {
        }

        #region ICorProfilerFunctionControl
        #region SetCodegenFlags

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
        /// cref="CorProfilerInfo.EventMask"/> property (with the values COR_PRF_DISABLE_INLINING and COR_PRF_DISABLE_OPTIMIZATIONS),
        /// and the profiler’s <see cref="ICorProfilerCallback.JITInlining"/> callback. The JIT compiler gives precedence to
        /// a source that requests the least amount of optimizing. For example, if the profiler specifies COR_PRF_DISABLE_INLINING
        /// on startup, but does not specify COR_PRF_CODEGEN_DISABLE_INLINING in the <see cref="SetCodegenFlags"/> callback,
        /// inlining is still disabled. Similarly, if the profiler does not specify COR_PRF_CODEGEN_DISABLE_INLINING in SetCodegenFlags,
        /// but then disables inlining by using the <see cref="ICorProfilerCallback.JITInlining"/> callback, inlining is disabled.
        /// </remarks>
        public void SetCodegenFlags(COR_PRF_CODEGEN_FLAGS flags)
        {
            TrySetCodegenFlags(flags).ThrowOnNotOK();
        }

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
        /// cref="CorProfilerInfo.EventMask"/> property (with the values COR_PRF_DISABLE_INLINING and COR_PRF_DISABLE_OPTIMIZATIONS),
        /// and the profiler’s <see cref="ICorProfilerCallback.JITInlining"/> callback. The JIT compiler gives precedence to
        /// a source that requests the least amount of optimizing. For example, if the profiler specifies COR_PRF_DISABLE_INLINING
        /// on startup, but does not specify COR_PRF_CODEGEN_DISABLE_INLINING in the <see cref="SetCodegenFlags"/> callback,
        /// inlining is still disabled. Similarly, if the profiler does not specify COR_PRF_CODEGEN_DISABLE_INLINING in SetCodegenFlags,
        /// but then disables inlining by using the <see cref="ICorProfilerCallback.JITInlining"/> callback, inlining is disabled.
        /// </remarks>
        public HRESULT TrySetCodegenFlags(COR_PRF_CODEGEN_FLAGS flags)
        {
            /*HRESULT SetCodegenFlags(
            [In] COR_PRF_CODEGEN_FLAGS flags);*/
            return Raw.SetCodegenFlags(flags);
        }

        #endregion
        #region SetILFunctionBody

        /// <summary>
        /// Replaces the Common Intermediate Language (CIL) body of the method.
        /// </summary>
        /// <param name="cbNewILMethodHeader">[in] The total size of the new CIL, including the header and any structures that come after the body.</param>
        /// <param name="pbNewILMethodHeader">[in] A pointer to the new CIL header.</param>
        /// <remarks>
        /// Unlike the <see cref="CorProfilerInfo.SetILFunctionBody"/> method, the SetILFunctionBody method manages the memory
        /// required for the new CIL body. This means that the CIL body provided by the profiler does not have to be allocated
        /// by using the <see cref="IMethodMalloc"/> interface or allocated within a particular range. It can be allocated
        /// on any heap. The profiler can free the memory used for its CIL body after SetILFunctionBody returns.
        /// </remarks>
        public void SetILFunctionBody(int cbNewILMethodHeader, IntPtr pbNewILMethodHeader)
        {
            TrySetILFunctionBody(cbNewILMethodHeader, pbNewILMethodHeader).ThrowOnNotOK();
        }

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
        /// Unlike the <see cref="CorProfilerInfo.SetILFunctionBody"/> method, the SetILFunctionBody method manages the memory
        /// required for the new CIL body. This means that the CIL body provided by the profiler does not have to be allocated
        /// by using the <see cref="IMethodMalloc"/> interface or allocated within a particular range. It can be allocated
        /// on any heap. The profiler can free the memory used for its CIL body after SetILFunctionBody returns.
        /// </remarks>
        public HRESULT TrySetILFunctionBody(int cbNewILMethodHeader, IntPtr pbNewILMethodHeader)
        {
            /*HRESULT SetILFunctionBody(
            [In] int cbNewILMethodHeader,
            [In] IntPtr pbNewILMethodHeader);*/
            return Raw.SetILFunctionBody(cbNewILMethodHeader, pbNewILMethodHeader);
        }

        #endregion
        #region SetILInstrumentedCodeMap

        /// <summary>
        /// Sets a code map for the specified function by using the specified Common Intermediate Language (CIL) map entries.
        /// </summary>
        /// <param name="cILMapEntries">[in] The number of entries in the map.</param>
        /// <param name="rgILMapEntries">[in] The caller-allocated array of COR_IL_MAP entries. The interpretation of these entries is the same as for the <see cref="CorProfilerInfo.SetILInstrumentedCodeMap"/> method.</param>
        /// <remarks>
        /// Setting the mapping by calling this method allows the debugger to retrieve the mapping by calling ICorDebugILCode2.
        /// It also allows the debugger to use the mapping internally when calculating IL offsets for stack traces and variable
        /// lifetimes.
        /// </remarks>
        public void SetILInstrumentedCodeMap(int cILMapEntries, COR_IL_MAP[] rgILMapEntries)
        {
            TrySetILInstrumentedCodeMap(cILMapEntries, rgILMapEntries).ThrowOnNotOK();
        }

        /// <summary>
        /// Sets a code map for the specified function by using the specified Common Intermediate Language (CIL) map entries.
        /// </summary>
        /// <param name="cILMapEntries">[in] The number of entries in the map.</param>
        /// <param name="rgILMapEntries">[in] The caller-allocated array of COR_IL_MAP entries. The interpretation of these entries is the same as for the <see cref="CorProfilerInfo.SetILInstrumentedCodeMap"/> method.</param>
        /// <remarks>
        /// Setting the mapping by calling this method allows the debugger to retrieve the mapping by calling ICorDebugILCode2.
        /// It also allows the debugger to use the mapping internally when calculating IL offsets for stack traces and variable
        /// lifetimes.
        /// </remarks>
        public HRESULT TrySetILInstrumentedCodeMap(int cILMapEntries, COR_IL_MAP[] rgILMapEntries)
        {
            /*HRESULT SetILInstrumentedCodeMap(
            [In] int cILMapEntries,
            [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] COR_IL_MAP[] rgILMapEntries);*/
            return Raw.SetILInstrumentedCodeMap(cILMapEntries, rgILMapEntries);
        }

        #endregion
        #endregion
    }
}
