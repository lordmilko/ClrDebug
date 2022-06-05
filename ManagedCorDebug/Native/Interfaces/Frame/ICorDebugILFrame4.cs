using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    /// <summary>
    /// [Supported in the .NET Framework 4.5.2 and later versions]<para/>
    /// Provides methods that allow you to access the local variables and code in a stack frame of intermediate language (IL) code. A parameter specifies whether the debugger has access to variables and code added in profiler ReJIT instrumentation.
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
        /// [Supported in the .NET Framework 4.5.2 and later versions]<para/>
        /// Gets an enumerator for the local variable in the frame, and optionally includes variables added in profiler ReJIT instrumentation.
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

        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT GetLocalVariableEx([In] ILCodeKind flags, [In] uint dwIndex,
            [MarshalAs(UnmanagedType.Interface)] out ICorDebugValue ppValue);

        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT GetCodeEx([In] ILCodeKind flags, [MarshalAs(UnmanagedType.Interface)] out ICorDebugCode ppCode);
    }
}