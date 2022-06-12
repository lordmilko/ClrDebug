using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    /// <summary>
    /// [Supported in the .NET Framework 4.5.2 and later versions] Provides methods that allow you to access the local variables and code in a stack frame of intermediate language (IL) code.<para/>
    /// A parameter specifies whether the debugger has access to variables and code added in profiler ReJIT instrumentation.
    /// </summary>
    /// <remarks>
    /// These methods offer functionality in addition to that provided by the <see cref="ICorDebugILFrame.EnumerateLocalVariables"/>,
    /// <see cref="ICorDebugFrame.GetCode"/>, and <see cref="ICorDebugILFrame.GetLocalVariable"/> methods. Each method
    /// includes a flags parameter that specifies whether additional local variables or code defined by a profiler's ReJIT
    /// request are visible.
    /// </remarks>
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("AD914A30-C6D1-4AC5-9C5E-577F3BAA8A45")]
    [ComImport]
    public interface ICorDebugILFrame4
    {
        /// <summary>
        /// [Supported in the .NET Framework 4.5.2 and later versions] Gets an enumerator for the local variable in the frame, and optionally includes variables added in profiler ReJIT instrumentation.
        /// </summary>
        /// <param name="flags">[in] An <see cref="ILCodeKind"/> enumeration member that specifies whether variables added in profiler ReJIT instrumentation are included in the frame.</param>
        /// <param name="ppValueEnum">[out] A pointer to the address of an "ICorDebugValueEnum" object that is the enumerator for the local variables in this frame.</param>
        /// <remarks>
        /// This method is similar to the <see cref="ICorDebugILFrame.EnumerateLocalVariables"/> method, except that it optionally
        /// accesses variables added in profiler ReJIT instrumentation. Setting flags to ILCODE_ORIGINAL_IL is equivalent to
        /// calling <see cref="ICorDebugILFrame.EnumerateLocalVariables"/>. Setting flags to ILCODE_REJIT_IL allows the debugger
        /// to access the local variables added in profiler ReJIT instrumentation. If the intermediate language (IL) is not
        /// instrumented, the enumeration is empty and the method returns S_OK. The enumerator may not include all of the local
        /// variables in the running method, since some of them may not be active.
        /// </remarks>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT EnumerateLocalVariablesEx([In] ILCodeKind flags,
            [MarshalAs(UnmanagedType.Interface)] out ICorDebugValueEnum ppValueEnum);

        /// <summary>
        /// [Supported in the .NET Framework 4.5.2 and later versions] Gets the value of the specified local variable in this intermediate language (IL) stack frame, and optionally accesses a variable added in profiler ReJIT instrumentation.
        /// </summary>
        /// <param name="flags">[in] An <see cref="ILCodeKind"/> enumeration member that specifies whether a variable added in profiler ReJIT instrumentation is included in the frame.</param>
        /// <param name="dwIndex">[in] The index of the local variable in the IL stack frame.</param>
        /// <param name="ppValue">[out] A pointer to the address of an "ICorDebugValue" object that represents the retrieved value.</param>
        /// <remarks>
        /// This method is similar to the <see cref="ICorDebugILFrame.GetLocalVariable"/> method, except that it optionally
        /// accesses a variable added in profiler ReJIT instrumentation. Calling this method with a flags value of ILCODE_ORIGINAL_IL
        /// is equivalent to calling <see cref="ICorDebugILFrame.GetLocalVariable"/>; if the method is instrumented with additional
        /// local variables, those variables cannot be accessed. ILCODE_REJIT_IL allows the debugger to access the local variables
        /// added in profiler ReJIT instrumentation. If the IL is not instrumented, the method returns E_INVALIDARG.
        /// </remarks>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT GetLocalVariableEx(
            [In] ILCodeKind flags,
            [In] int dwIndex,
            [MarshalAs(UnmanagedType.Interface)] out ICorDebugValue ppValue);

        /// <summary>
        /// [Supported in the .NET Framework 4.5.2 and later versions] Gets a pointer to the code that this stack frame is executing.
        /// </summary>
        /// <param name="flags">[in] An <see cref="ILCodeKind"/> enumeration member that specifies whether the intermediate language (IL) defined by the profiler's ReJIT request is included in the frame.</param>
        /// <param name="ppCode">[out] A pointer to the address of an "ICorDebugCode" object that represents the code that this stack frame is executing.</param>
        /// <remarks>
        /// This method is similar to the <see cref="ICorDebugFrame.GetCode"/> method, except that it optionally accesses code
        /// defined by the profiler's ReJIT request. Calling this method with a flags value of ILCODE_ORIGINAL_IL is equivalent
        /// to calling <see cref="ICorDebugFrame.GetCode"/>; if the method is instrumented, its IL will not be accessible.
        /// ILCODE_REJIT_IL allows the debugger to access the IL defined by the profiler's ReJIT request. If the IL is not
        /// instrumented, ppCode is null, and the method returns S_OK.
        /// </remarks>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT GetCodeEx(
            [In] ILCodeKind flags,
            [MarshalAs(UnmanagedType.Interface)] out ICorDebugCode ppCode);
    }
}