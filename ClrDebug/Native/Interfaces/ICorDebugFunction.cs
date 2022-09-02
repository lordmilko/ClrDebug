using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace ClrDebug
{
    /// <summary>
    /// Represents a managed function or method.
    /// </summary>
    /// <remarks>
    /// The <see cref="ICorDebugFunction"/> interface does not represent a function with generic type parameters. For example, an <see cref="ICorDebugFunction"/>
    /// instance would represent Func&lt;T&gt; but not Func&lt;string&gt;. Call <see cref="ICorDebugILFrame2.EnumerateTypeParameters"/>
    /// to get the generic type parameters. The relationship between a method's metadata token, <see cref="mdMethodDef"/>, and a method's
    /// <see cref="ICorDebugFunction"/> object is dependent upon whether Edit and Continue is allowed on the function:
    /// </remarks>
    [Guid("CC7BCAF3-8A68-11D2-983C-0000F808342D")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [ComImport]
    public interface ICorDebugFunction
    {
        /// <summary>
        /// Gets the module in which this function is defined.
        /// </summary>
        /// <param name="ppModule">[out] A pointer to the address of an <see cref="ICorDebugModule"/> object that represents the module in which this function is defined.</param>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT GetModule(
            [Out, MarshalAs(UnmanagedType.Interface)] out ICorDebugModule ppModule);

        /// <summary>
        /// Gets an <see cref="ICorDebugClass"/> object that represents the class this function is a member of.
        /// </summary>
        /// <param name="ppClass">[out] A pointer to the address of the <see cref="ICorDebugClass"/> object that represents the class, or null, if this function is not a member of a class.</param>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT GetClass(
            [Out, MarshalAs(UnmanagedType.Interface)] out ICorDebugClass ppClass);

        /// <summary>
        /// Gets the metadata token for this function.
        /// </summary>
        /// <param name="pMethodDef">[out] A pointer to an <see cref="mdMethodDef"/> token that references the metadata for this function.</param>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT GetToken(
            [Out] out mdMethodDef pMethodDef);

        /// <summary>
        /// Gets the <see cref="ICorDebugCode"/> instance that represents the Microsoft intermediate language (MSIL) code associated with this <see cref="ICorDebugFunction"/> object.
        /// </summary>
        /// <param name="ppCode">[out] A pointer to the <see cref="ICorDebugCode"/> instance, or null, if the function was not compiled into MSIL.</param>
        /// <remarks>
        /// If Edit and Continue has been allowed on this function, the GetILCode method will get the MSIL code corresponding
        /// to this function's edited version of the code in the common language runtime (CLR).
        /// </remarks>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT GetILCode(
            [Out, MarshalAs(UnmanagedType.Interface)] out ICorDebugCode ppCode);

        /// <summary>
        /// Gets the native code for the function that is represented by this <see cref="ICorDebugFunction"/> instance.
        /// </summary>
        /// <param name="ppCode">[out] A pointer to the <see cref="ICorDebugCode"/> instance that represents the native code for this function, or null, if this function is Microsoft intermediate language (MSIL) code that has not been just-in-time (JIT) compiled.</param>
        /// <remarks>
        /// If the function that is represented by this <see cref="ICorDebugFunction"/> instance has been JIT-compiled more than once, as
        /// in the case of generic types, GetNativeCode returns a random native code object.
        /// </remarks>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT GetNativeCode(
            [Out, MarshalAs(UnmanagedType.Interface)] out ICorDebugCode ppCode);

        /// <summary>
        /// Creates a breakpoint at the beginning of this function.
        /// </summary>
        /// <param name="ppBreakpoint">[out] A pointer to the address of an <see cref="ICorDebugFunctionBreakpoint"/> object that represents the new breakpoint for the function.</param>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT CreateBreakpoint(
            [Out, MarshalAs(UnmanagedType.Interface)] out ICorDebugFunctionBreakpoint ppBreakpoint);

        /// <summary>
        /// Gets the metadata token for the local variable signature of the function that is represented by this <see cref="ICorDebugFunction"/> instance.
        /// </summary>
        /// <param name="pmdSig">[out] A pointer to the <see cref="mdSignature"/> token for the local variable signature of this function, or mdSignatureNil, if this function has no local variables.</param>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT GetLocalVarSigToken(
            [Out] out mdSignature pmdSig);

        /// <summary>
        /// Gets the version number of the latest edit made to the function represented by this <see cref="ICorDebugFunction"/> object.
        /// </summary>
        /// <param name="pnCurrentVersion">[out] A pointer to an integer value that is the version number of the latest edit made to this function.</param>
        /// <remarks>
        /// The version number of the latest edit made to this function may be greater than the version number of the function
        /// itself. Use either the <see cref="ICorDebugFunction2.GetVersionNumber"/> method or the <see cref="ICorDebugCode.GetVersionNumber"/>
        /// method to retrieve the version number of the function.
        /// </remarks>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT GetCurrentVersionNumber(
            [Out] out int pnCurrentVersion);
    }
}
