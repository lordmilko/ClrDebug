using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    /// <summary>
    /// A logical extension of the ICorDebugProcess interface, which represents a process running managed code.
    /// </summary>
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("AD1B3588-0EF0-4744-A496-AA09A9F80371")]
    [ComImport]
    public interface ICorDebugProcess2
    {
        /// <summary>
        /// Gets the thread on which the task with the specified identifier is executing.
        /// </summary>
        /// <param name="taskid">[in] The identifier of the task.</param>
        /// <param name="ppThread">[out] A pointer to the address of an ICorDebugThread2 object that represents the thread to be retrieved.</param>
        /// <remarks>
        /// The host can set the task identifier by using the <see cref="ICLRTask.SetTaskIdentifier"/> method.
        /// </remarks>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT GetThreadForTaskID([In] ulong taskid, [MarshalAs(UnmanagedType.Interface)] out ICorDebugThread2 ppThread);

        /// <summary>
        /// Gets the version number of the common language runtime (CLR) that is running in this process.
        /// </summary>
        /// <param name="version">[out] A pointer to a COR_VERSION structure that stores the version number of the runtime.</param>
        /// <remarks>
        /// The GetVersion method returns an error code if no runtime has been loaded in the process.
        /// </remarks>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT GetVersion(out COR_VERSION version);

        /// <summary>
        /// Sets an unmanaged breakpoint at the specified native image offset.
        /// </summary>
        /// <param name="address">[in] A CORDB_ADDRESS object that specifies the native image offset.</param>
        /// <param name="bufsize">[in] The size, in bytes, of the buffer array.</param>
        /// <param name="buffer">[out] An array that contains the opcode that is replaced by the breakpoint.</param>
        /// <param name="bufLen">[out] A pointer to the number of bytes returned in the buffer array.</param>
        /// <remarks>
        /// If the native image offset is within the common language runtime (CLR), the breakpoint will be ignored. This allows
        /// the CLR to avoid dispatching an out-of-band breakpoint, when the breakpoint is set by the debugger.
        /// </remarks>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT SetUnmanagedBreakpoint(
            [In] CORDB_ADDRESS address,
            [In] uint bufsize,
            [Out] byte[] buffer,
            out uint bufLen);

        /// <summary>
        /// Removes a previously set breakpoint at the given address.
        /// </summary>
        /// <param name="address">[in] A CORDB_ADDRESS value that specifies the address at which the breakpoint was set.</param>
        /// <remarks>
        /// The specified breakpoint would have been previously set by an earlier call to <see cref="SetUnmanagedBreakpoint"/>.
        /// The ClearUnmanagedBreakpoint method can be called while the process being debugged is running. The ClearUnmanagedBreakpoint
        /// method returns a failure code if the debugger is attached in managed-only mode or if no breakpoint exists at the
        /// specified address.
        /// </remarks>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT ClearUnmanagedBreakpoint([In] CORDB_ADDRESS address);

        /// <summary>
        /// Sets the flags that must be embedded in a precompiled image in order for the runtime to load that image into the current process.
        /// </summary>
        /// <param name="pdwFlags">[in] A value of the <see cref="CorDebugJITCompilerFlags"/> enumeration that specifies the compiler flags used to select the correct pre-compiled image.</param>
        /// <remarks>
        /// The SetDesiredNGENCompilerFlags method specifies the flags that must be embedded in a precompiled image so that
        /// the runtime will load that image into this process. The flags set by this method are used only to select the correct
        /// precompiled image. If no such image exists, the runtime will load the Microsoft intermediate language (MSIL) image
        /// and the just-in-time (JIT) compiler instead. In that case, the debugger must still use the <see cref="ICorDebugModule2.SetJITCompilerFlags"/>
        /// method to set the flags as desired for the JIT compilation. If an image is loaded, but some JIT compiling must
        /// take place for that image (which will be the case if the image contains generics), the compiler flags specified
        /// by the SetDesiredNGENCompilerFlags method will apply to the extra JIT compilation. The SetDesiredNGENCompilerFlags
        /// method must be called during the <see cref="ICorDebugManagedCallback.CreateProcess"/> callback. Attempts to call
        /// the SetDesiredNGENCompilerFlags method afterwards will fail. Also, attempts to set flags that are either not defined
        /// in the CorDebugJITCompilerFlags enumeration or are not legal for the given process will fail.
        /// </remarks>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT SetDesiredNGENCompilerFlags([In] uint pdwFlags);

        /// <summary>
        /// Gets the current compiler flag settings that the common language runtime (CLR) uses to select the correct precompiled (that is, native) image to be loaded into this process.
        /// </summary>
        /// <param name="pdwFlags">[out] A pointer to a bitwise combination of the <see cref="CorDebugJITCompilerFlags"/> enumeration values that are used to select the correct precompiled image to be loaded.</param>
        /// <remarks>
        /// Use the <see cref="SetDesiredNGENCompilerFlags"/> method to set the flags that the CLR will use to select the correct
        /// pre-compiled image to load.
        /// </remarks>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT GetDesiredNGENCompilerFlags(out uint pdwFlags);

        /// <summary>
        /// Gets a reference pointer to the specified managed object that has a garbage collection handle.
        /// </summary>
        /// <param name="handle">[in] A pointer to a managed object that has a garbage collection handle. This value is a <see cref="IntPtr"/> object and can be retrieved from the <see cref="GCHandle"/> for the managed object.</param>
        /// <param name="pOutValue">[out] A pointer to the address of an ICorDebugReferenceValue object that represents a reference to the specified managed object.</param>
        /// <remarks>
        /// Do not confuse the returned reference value with a garbage collection reference value. The returned reference behaves
        /// like a normal reference. It is disabled when code execution continues after a breakpoint. The lifetime of the target
        /// object is not affected by the lifetime of the reference value.
        /// </remarks>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT GetReferenceValueFromGCHandle([In] IntPtr handle, [MarshalAs(UnmanagedType.Interface)] out ICorDebugReferenceValue pOutValue);
    }
}