using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    /// <summary>
    /// Serves as a logical extension to the <see cref="ICorDebugModule"/> interface.
    /// </summary>
    [Guid("7FCC5FB5-49C0-41DE-9938-3B88B5B9ADD7")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [ComImport]
    public interface ICorDebugModule2
    {
        /// <summary>
        /// Sets the Just My Code (JMC) status of all methods of all the classes in this <see cref="ICorDebugModule2"/> to the specified value, except those in the pTokens array, which it sets to the opposite value.
        /// </summary>
        /// <param name="bIsJustMyCode">[in] Set to true if the code is to be debugged; otherwise, set to false.</param>
        /// <param name="cTokens">[in] The size of the pTokens array.</param>
        /// <param name="pTokens">[in] An array of <see cref="mdToken"/> values, each of which refers to a method that will have its JMC status set to !bIsJustMycode.</param>
        /// <remarks>
        /// The JMC status of each method that is specified in the pTokens array is set to the opposite of the bIsJustMycode
        /// value. The status of all other methods in this module is set to the bIsJustMycode value. The SetJMCStatus method
        /// erases all previous JMC settings in this module. The SetJMCStatus method returns an S_OK <see cref="HRESULT"/> if all functions
        /// were set successfully. It returns a CORDBG_E_FUNCTION_NOT_DEBUGGABLE <see cref="HRESULT"/> if some functions that are marked
        /// true are not debuggable.
        /// </remarks>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT SetJMCStatus([In] int bIsJustMyCode, [In] int cTokens, [In, MarshalAs(UnmanagedType.LPArray)] mdToken[] pTokens);

        /// <summary>
        /// Applies the changes in the metadata and the changes in the Microsoft intermediate language (MSIL) code to the running process.
        /// </summary>
        /// <param name="cbMetadata">[in] Size, in bytes, of the delta metadata.</param>
        /// <param name="pbMetadata">[in] Buffer that contains the delta metadata. The address of the buffer is returned from the <see cref="IMetaDataEmit2.SaveDeltaToMemory"/> method.<para/>
        /// The relative virtual addresses (RVAs) in the metadata should be relative to the start of the MSIL code.</param>
        /// <param name="cbIL">[in] Size, in bytes, of the delta MSIL code.</param>
        /// <param name="pbIL">[in] Buffer that contains the updated MSIL code.</param>
        /// <remarks>
        /// The pbMetadata parameter is in a special delta metadata format (as output by <see cref="IMetaDataEmit2.SaveDeltaToMemory"/>).
        /// pbMetadata takes previous metadata as a base and describes individual changes to apply to that base. In contrast,
        /// the pbIL[] parameter contains the new MSIL for the updated method, and is meant to completely replace the previous
        /// MSIL for that method When the delta MSIL and the metadata have been created in the debugger’s memory, the debugger
        /// calls ApplyChanges to send the changes into the common language runtime (CLR). The runtime updates its metadata
        /// tables, places the new MSIL into the process, and sets up a just-in-time (JIT) compilation of the new MSIL. When
        /// the changes have been applied, the debugger should call <see cref="IMetaDataEmit2.ResetENCLog"/> to prepare for
        /// the next editing session. The debugger may then continue the process. Whenever the debugger calls ApplyChanges
        /// on a module that has delta metadata, it should also call <see cref="IMetaDataEmit.ApplyEditAndContinue"/> with
        /// the same delta metadata on all of its copies of that module’s metadata except for the copy used to emit the changes.
        /// If a copy of the metadata somehow becomes out-of-sync with the actual metadata, the debugger can always throw away
        /// that copy and obtain a new copy. If the ApplyChanges method fails, the debug session is in an invalid state and
        /// must be restarted.
        /// </remarks>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT ApplyChanges([In] int cbMetadata, [In] IntPtr pbMetadata, [In] int cbIL, [In] IntPtr pbIL);

        /// <summary>
        /// Sets the flags that control the just-in-time (JIT) compilation of this <see cref="ICorDebugModule2"/>.
        /// </summary>
        /// <param name="dwFlags">[in] A bitwise combination of the <see cref="CorDebugJITCompilerFlags"/> enumeration values.</param>
        /// <remarks>
        /// If the dwFlags value is invalid, the SetJITCompilerFlags method will fail. The SetJITCompilerFlags method can be
        /// called only from within the <see cref="ICorDebugManagedCallback.LoadModule"/> callback for this module. Attempts
        /// to call it after the <see cref="ICorDebugManagedCallback.LoadModule"/> callback has been delivered will fail. Edit and Continue
        /// is not supported on 64-bit or Win9x platforms. Therefore, if you call the SetJITCompilerFlags method on either
        /// of these two platforms with the CORDEBUG_JIT_ENABLE_ENC flag set in dwFlags, the SetJITCompilerFlags method and
        /// all methods specific to Edit and Continue, such as <see cref="ApplyChanges"/>, will fail.
        /// </remarks>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT SetJITCompilerFlags([In] int dwFlags);

        /// <summary>
        /// Gets the flags that control the just-in-time (JIT) compilation of this <see cref="ICorDebugModule2"/>.
        /// </summary>
        /// <param name="pdwFlags">[out] A pointer to a value of the <see cref="CorDebugJITCompilerFlags"/> enumeration that controls the JIT compilation.</param>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT GetJITCompilerFlags([Out] out int pdwFlags);

        /// <summary>
        /// Resolves the assembly referenced by the specified metadata token.
        /// </summary>
        /// <param name="tkAssemblyRef">[in] An <see cref="mdToken"/> value that references the assembly.</param>
        /// <param name="ppAssembly">[out] A pointer to the address of an <see cref="ICorDebugAssembly"/> object that represents the assembly.</param>
        /// <remarks>
        /// If the assembly is not already loaded when ResolveAssembly is called, an <see cref="HRESULT"/> value of CORDBG_E_CANNOT_RESOLVE_ASSEMBLY
        /// is returned.
        /// </remarks>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT ResolveAssembly([In] mdToken tkAssemblyRef,
            [Out, MarshalAs(UnmanagedType.Interface)] out ICorDebugAssembly ppAssembly);
    }
}