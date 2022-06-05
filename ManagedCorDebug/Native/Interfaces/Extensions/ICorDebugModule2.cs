using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    /// <summary>
    /// Serves as a logical extension to the ICorDebugModule interface.
    /// </summary>
    [Guid("7FCC5FB5-49C0-41DE-9938-3B88B5B9ADD7")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [ComImport]
    public interface ICorDebugModule2
    {
        /// <summary>
        /// Sets the Just My Code (JMC) status of all methods of all the classes in this ICorDebugModule2 to the specified value, except those in the pTokens array, which it sets to the opposite value.
        /// </summary>
        /// <param name="bIsJustMyCode">[in] Set to true if the code is to be debugged; otherwise, set to false.</param>
        /// <param name="cTokens">[in] The size of the pTokens array.</param>
        /// <param name="pTokens">[in] An array of mdToken values, each of which refers to a method that will have its JMC status set to !bIsJustMycode.</param>
        /// <remarks>
        /// The JMC status of each method that is specified in the pTokens array is set to the opposite of the bIsJustMycode
        /// value. The status of all other methods in this module is set to the bIsJustMycode value. The SetJMCStatus method
        /// erases all previous JMC settings in this module. The SetJMCStatus method returns an S_OK HRESULT if all functions
        /// were set successfully. It returns a CORDBG_E_FUNCTION_NOT_DEBUGGABLE HRESULT if some functions that are marked
        /// true are not debuggable.
        /// </remarks>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT SetJMCStatus([In] int bIsJustMyCode, [In] uint cTokens, [In] ref uint pTokens);

        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT ApplyChanges([In] uint cbMetadata, [In] ref byte pbMetadata, [In] uint cbIL, [In] ref byte pbIL);

        /// <summary>
        /// Sets the flags that control the just-in-time (JIT) compilation of this ICorDebugModule2.
        /// </summary>
        /// <param name="dwFlags">[in] A bitwise combination of the <see cref="CorDebugJITCompilerFlags"/> enumeration values.</param>
        /// <remarks>
        /// If the dwFlags value is invalid, the SetJITCompilerFlags method will fail. The SetJITCompilerFlags method can be
        /// called only from within the <see cref="ICorDebugManagedCallback.LoadModule"/> callback for this module. Attempts
        /// to call it after the ICorDebugManagedCallback::LoadModule callback has been delivered will fail. Edit and Continue
        /// is not supported on 64-bit or Win9x platforms. Therefore, if you call the SetJITCompilerFlags method on either
        /// of these two platforms with the CORDEBUG_JIT_ENABLE_ENC flag set in dwFlags, the SetJITCompilerFlags method and
        /// all methods specific to Edit and Continue, such as <see cref="ICorDebugModule2.ApplyChanges"/>, will fail.
        /// </remarks>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT SetJITCompilerFlags([In] uint dwFlags);

        /// <summary>
        /// Gets the flags that control the just-in-time (JIT) compilation of this ICorDebugModule2.
        /// </summary>
        /// <param name="pdwFlags">[out] A pointer to a value of the <see cref="CorDebugJITCompilerFlags"/> enumeration that controls the JIT compilation.</param>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT GetJITCompilerFlags(out uint pdwFlags);

        /// <summary>
        /// Resolves the assembly referenced by the specified metadata token.
        /// </summary>
        /// <param name="tkAssemblyRef">[in] An mdToken value that references the assembly.</param>
        /// <param name="ppAssembly">[out] A pointer to the address of an ICorDebugAssembly object that represents the assembly.</param>
        /// <remarks>
        /// If the assembly is not already loaded when ResolveAssembly is called, an HRESULT value of CORDBG_E_CANNOT_RESOLVE_ASSEMBLY
        /// is returned.
        /// </remarks>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT ResolveAssembly([In] uint tkAssemblyRef,
            [MarshalAs(UnmanagedType.Interface)] out ICorDebugAssembly ppAssembly);
    }
}