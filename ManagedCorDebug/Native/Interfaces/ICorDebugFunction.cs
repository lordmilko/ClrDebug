using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    [Guid("CC7BCAF3-8A68-11D2-983C-0000F808342D")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [ComImport]
    public interface ICorDebugFunction
    {
        /// <summary>
        /// Gets the module in which this function is defined.
        /// </summary>
        /// <param name="ppModule">[out] A pointer to the address of an ICorDebugModule object that represents the module in which this function is defined.</param>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT GetModule([MarshalAs(UnmanagedType.Interface)] out ICorDebugModule ppModule);

        /// <summary>
        /// Gets an ICorDebugClass object that represents the class this function is a member of.
        /// </summary>
        /// <param name="ppClass">[out] A pointer to the address of the ICorDebugClass object that represents the class, or null, if this function is not a member of a class.</param>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT GetClass([MarshalAs(UnmanagedType.Interface)] out ICorDebugClass ppClass);

        /// <summary>
        /// Gets the metadata token for this function.
        /// </summary>
        /// <param name="pMethodDef">[out] A pointer to an mdMethodDef token that references the metadata for this function.</param>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT GetToken(out uint pMethodDef);

        /// <summary>
        /// Gets the ICorDebugCode instance that represents the Microsoft intermediate language (MSIL) code associated with this ICorDebugFunction object.
        /// </summary>
        /// <param name="ppCode">[out] A pointer to the ICorDebugCode instance, or null, if the function was not compiled into MSIL.</param>
        /// <remarks>
        /// If Edit and Continue has been allowed on this function, the GetILCode method will get the MSIL code corresponding
        /// to this function's edited version of the code in the common language runtime (CLR).
        /// </remarks>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT GetILCode([MarshalAs(UnmanagedType.Interface)] out ICorDebugCode ppCode);

        /// <summary>
        /// Gets the native code for the function that is represented by this ICorDebugFunction instance.
        /// </summary>
        /// <param name="ppCode">[out] A pointer to the ICorDebugCode instance that represents the native code for this function, or null, if this function is Microsoft intermediate language (MSIL) code that has not been just-in-time (JIT) compiled.</param>
        /// <remarks>
        /// If the function that is represented by this ICorDebugFunction instance has been JIT-compiled more than once, as
        /// in the case of generic types, GetNativeCode returns a random native code object.
        /// </remarks>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT GetNativeCode([MarshalAs(UnmanagedType.Interface)] out ICorDebugCode ppCode);

        /// <summary>
        /// Creates a breakpoint at the beginning of this function.
        /// </summary>
        /// <param name="ppBreakpoint">[out] A pointer to the address of an ICorDebugFunctionBreakpoint object that represents the new breakpoint for the function.</param>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT CreateBreakpoint([MarshalAs(UnmanagedType.Interface)] out ICorDebugFunctionBreakpoint ppBreakpoint);

        /// <summary>
        /// Gets the metadata token for the local variable signature of the function that is represented by this ICorDebugFunction instance.
        /// </summary>
        /// <param name="pmdSig">[out] A pointer to the mdSignature token for the local variable signature of this function, or mdSignatureNil, if this function has no local variables.</param>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT GetLocalVarSigToken(out uint pmdSig);

        /// <summary>
        /// Gets the version number of the latest edit made to the function represented by this ICorDebugFunction object.
        /// </summary>
        /// <param name="pnCurrentVersion">[out] A pointer to an integer value that is the version number of the latest edit made to this function.</param>
        /// <remarks>
        /// The version number of the latest edit made to this function may be greater than the version number of the function
        /// itself. Use either the <see cref="ICorDebugFunction2.GetVersionNumber"/> method or the <see cref="ICorDebugCode.GetVersionNumber"/>
        /// method to retrieve the version number of the function.
        /// </remarks>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT GetCurrentVersionNumber(out uint pnCurrentVersion);
    }
}