﻿using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
#if GENERATED_MARSHALLING
using System.Runtime.InteropServices.Marshalling;
#endif

namespace ClrDebug
{
    /// <summary>
    /// A specialized implementation of <see cref="ICorDebugFrame"/> used for native frames.
    /// </summary>
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("03E26314-4F76-11D3-88C6-006097945418")]
#if !GENERATED_MARSHALLING
    [ComImport]
#else
    [GeneratedComInterface]
#endif
    public partial interface ICorDebugNativeFrame : ICorDebugFrame
    {
#if !GENERATED_MARSHALLING
        /// <summary>
        /// Gets a pointer to the chain this frame is a part of.
        /// </summary>
        /// <param name="ppChain">[out] A pointer to the address of an <see cref="ICorDebugChain"/> object that represents the chain containing this frame.</param>
        [PreserveSig]
        new HRESULT GetChain(
            [Out, MarshalAs(UnmanagedType.Interface)] out ICorDebugChain ppChain);

        /// <summary>
        /// Gets a pointer to the code associated with this stack frame.
        /// </summary>
        /// <param name="ppCode">[out] A pointer to the address of an <see cref="ICorDebugCode"/> object that represents the code associated with this frame.</param>
        [PreserveSig]
        new HRESULT GetCode(
            [Out, MarshalAs(UnmanagedType.Interface)] out ICorDebugCode ppCode);

        /// <summary>
        /// Gets the function that contains the code associated with this stack frame.
        /// </summary>
        /// <param name="ppFunction">[out] A pointer to the address of an <see cref="ICorDebugFunction"/> object that represents the function containing the code associated with this stack frame.</param>
        /// <remarks>
        /// The GetFunction method may fail if the frame is not associated with any particular function.
        /// </remarks>
        [PreserveSig]
        new HRESULT GetFunction(
            [Out, MarshalAs(UnmanagedType.Interface)] out ICorDebugFunction ppFunction);

        /// <summary>
        /// Gets the metadata token for the function that contains the code associated with this stack frame.
        /// </summary>
        /// <param name="pToken">[out] A pointer to an <see cref="mdMethodDef"/> token that references the metadata for the function.</param>
        [PreserveSig]
        new HRESULT GetFunctionToken(
            [Out] out mdMethodDef pToken);

        /// <summary>
        /// Gets the absolute address range of this stack frame.
        /// </summary>
        /// <param name="pStart">[out] A pointer to a <see cref="CORDB_ADDRESS"/> that specifies the starting address of the stack frame represented by this <see cref="ICorDebugFrame"/> object.</param>
        /// <param name="pEnd">[out] A pointer to a <see cref="CORDB_ADDRESS"/> that specifies the ending address of the stack frame represented by this <see cref="ICorDebugFrame"/> object.</param>
        /// <remarks>
        /// The address range of the stack is useful for piecing together interleaved stack traces gathered from multiple debugging
        /// engines. The numeric range provides no information about the contents of the stack frame. It is meaningful only
        /// for comparison of stack frame locations.
        /// </remarks>
        [PreserveSig]
        new HRESULT GetStackRange(
            [Out] out CORDB_ADDRESS pStart,
            [Out] out CORDB_ADDRESS pEnd);

        /// <summary>
        /// Gets a pointer to the <see cref="ICorDebugFrame"/> object in the current chain that called this frame.
        /// </summary>
        /// <param name="ppFrame">[out] A pointer to the address of an <see cref="ICorDebugFrame"/> object that represents the calling frame. This value is null if the called frame is the outermost frame in the current chain.</param>
        [PreserveSig]
        new HRESULT GetCaller(
            [Out, MarshalAs(UnmanagedType.Interface)] out ICorDebugFrame ppFrame);

        /// <summary>
        /// Gets a pointer to the <see cref="ICorDebugFrame"/> object in the current chain that this frame called.
        /// </summary>
        /// <param name="ppFrame">[out] A pointer to the address of an <see cref="ICorDebugFrame"/> object that represents the called frame. This value is null if the calling frame is the innermost frame in the current chain.</param>
        [PreserveSig]
        new HRESULT GetCallee(
            [Out, MarshalAs(UnmanagedType.Interface)] out ICorDebugFrame ppFrame);

        /// <summary>
        /// Gets a stepper that allows the debugger to perform stepping operations relative to this <see cref="ICorDebugFrame"/>.
        /// </summary>
        /// <param name="ppStepper">[out] A pointer to the address of an <see cref="ICorDebugStepper"/> object that allows the debugger to perform stepping operations relative to the current frame.</param>
        /// <remarks>
        /// If the frame is not active, the stepper object will typically have to return to the frame before the step is completed.
        /// </remarks>
        [PreserveSig]
        new HRESULT CreateStepper(
            [Out, MarshalAs(UnmanagedType.Interface)] out ICorDebugStepper ppStepper);
#endif

        /// <summary>
        /// Gets the native code offset location to which the instruction pointer is currently set.
        /// </summary>
        /// <param name="pnOffset">[out] A pointer to the offset location in the native code.</param>
        /// <remarks>
        /// If the stack frame that is represented by this "ICorDebugNativeFrame" is active, the offset is the address of the
        /// next instruction to be executed. If this stack frame is not active, the offset is the address of the next instruction
        /// to be executed when the stack frame is reactivated.
        /// </remarks>
        [PreserveSig]
        HRESULT GetIP(
            [Out] out int pnOffset);

        /// <summary>
        /// Sets the instruction pointer to the specified offset location in native code.
        /// </summary>
        /// <param name="nOffset">[in] The offset location in the native code.</param>
        /// <remarks>
        /// Calls to SetIP immediately invalidate all frames and chains for the current thread. If the debugger needs frame
        /// information after a call to SetIP, it must perform a new stack trace. <see cref="ICorDebug"/> will attempt to keep
        /// the stack frame in a valid state. However, even if the frame is in a valid state, as far as the runtime is concerned,
        /// there still may be problems, such as uninitialized local variables, and so on. The caller is responsible for insuring
        /// coherency of the running program. On 64-bit platforms, the instruction pointer cannot be moved out of a catch or
        /// finally block. If SetIP is called to make such a move on a 64-bit platform, it will return an <see cref="HRESULT"/> indicating
        /// failure.
        /// </remarks>
        [PreserveSig]
        HRESULT SetIP(
            [In] int nOffset);

        /// <summary>
        /// Gets the register set for this stack frame.
        /// </summary>
        /// <param name="ppRegisters">[out] A pointer to the address of an <see cref="ICorDebugRegisterSet"/> object that represents the register set for this stack frame.</param>
        [PreserveSig]
        HRESULT GetRegisterSet(
            [Out, MarshalAs(UnmanagedType.Interface)] out ICorDebugRegisterSet ppRegisters);

        /// <summary>
        /// Gets the value of an argument or local variable that is stored in the specified register for this native frame.
        /// </summary>
        /// <param name="reg">[in] A value of the "CorDebugRegister" enumeration that specifies the register containing the value.</param>
        /// <param name="cbSigBlob">[in] An integer that specifies the size of the binary metadata signature which is referenced by the pvSigBlob parameter.</param>
        /// <param name="pvSigBlob">[in] A PCCOR_SIGNATURE value that points to the binary metadata signature of the value's type.</param>
        /// <param name="ppValue">[out] A pointer to the address of an "ICorDebugValue" object representing the retrieved value that is stored in the specified register.</param>
        /// <remarks>
        /// The GetLocalRegisterValue method can be used either in a native frame or a just-in-time (JIT)-compiled frame.
        /// </remarks>
        [PreserveSig]
        HRESULT GetLocalRegisterValue(
            [In] CorDebugRegister reg,
            [In] int cbSigBlob,
            [In] IntPtr pvSigBlob,
            [Out, MarshalAs(UnmanagedType.Interface)] out ICorDebugValue ppValue);

        /// <summary>
        /// Gets the value of an argument or local variable that is stored in the two specified registers for this native frame.
        /// </summary>
        /// <param name="highWordReg">[in] A value of the "CorDebugRegister" enumeration that specifies the register containing the high word of the value.</param>
        /// <param name="lowWordReg">[in] A value of the <see cref="CorDebugRegister"/> enumeration that specifies the register containing the low word of the value.</param>
        /// <param name="cbSigBlob">[in] An integer that specifies the size of the binary metadata signature which is referenced by the pvSigBlob parameter.</param>
        /// <param name="pvSigBlob">[in] A PCCOR_SIGNATURE value that points to the binary metadata signature of the value's type.</param>
        /// <param name="ppValue">[out] A pointer to the address of an "ICorDebugValue" object representing the retrieved value that is stored in the specified registers.</param>
        /// <remarks>
        /// The GetLocalDoubleRegisterValue method can be used either in a native frame or a just-in-time (JIT)-compiled frame.
        /// </remarks>
        [PreserveSig]
        HRESULT GetLocalDoubleRegisterValue(
            [In] CorDebugRegister highWordReg,
            [In] CorDebugRegister lowWordReg,
            [In] int cbSigBlob,
            [In] IntPtr pvSigBlob,
            [Out, MarshalAs(UnmanagedType.Interface)] out ICorDebugValue ppValue);

        /// <summary>
        /// Gets the value of an argument or local variable that is stored in the specified memory location for this native frame.
        /// </summary>
        /// <param name="address">[in] A <see cref="CORDB_ADDRESS"/> value that specifies the memory location containing the value.</param>
        /// <param name="cbSigBlob">[in] An integer that specifies the size of the binary metadata signature which is referenced by the pvSigBlob parameter.</param>
        /// <param name="pvSigBlob">[in] A PCCOR_SIGNATURE value that points to the binary metadata signature of the value's type.</param>
        /// <param name="ppValue">[out] A pointer to the address of an "ICorDebugValue" object representing the retrieved value that is stored in the specified memory location.</param>
        [PreserveSig]
        HRESULT GetLocalMemoryValue(
            [In] CORDB_ADDRESS address,
            [In] int cbSigBlob,
            [In] IntPtr pvSigBlob,
            [Out, MarshalAs(UnmanagedType.Interface)] out ICorDebugValue ppValue);

        /// <summary>
        /// Gets the value of an argument or local variable, of which the low word and high word are stored in the memory location and specified register, respectively, for this native frame.
        /// </summary>
        /// <param name="highWordReg">[in] A value of the "CorDebugRegister" enumeration that specifies the register containing the high word of the value.</param>
        /// <param name="lowWordAddress">[in] A <see cref="CORDB_ADDRESS"/> value that specifies the memory location containing the low word of the value.</param>
        /// <param name="cbSigBlob">[in] An integer that specifies the size of the binary metadata signature which is referenced by the pvSigBlob parameter.</param>
        /// <param name="pvSigBlob">[in] A PCCOR_SIGNATURE value that points to the binary metadata signature of the value's type.</param>
        /// <param name="ppValue">[out] A pointer to the address of an "ICorDebugValue" object representing the retrieved value that is stored in the specified register and memory location.</param>
        [PreserveSig]
        HRESULT GetLocalRegisterMemoryValue(
            [In] CorDebugRegister highWordReg,
            [In] CORDB_ADDRESS lowWordAddress,
            [In] int cbSigBlob,
            [In] IntPtr pvSigBlob,
            [Out, MarshalAs(UnmanagedType.Interface)] out ICorDebugValue ppValue);

        /// <summary>
        /// Gets the value of an argument or local variable, of which the low word and high word are stored in the specified register and memory location, respectively, for this native frame.
        /// </summary>
        /// <param name="highWordAddress">[in] A <see cref="CORDB_ADDRESS"/> value that specifies the memory location containing the high word of the value.</param>
        /// <param name="lowWordRegister">[in] A value of the "CorDebugRegister" enumeration that specifies the register containing the low word of the value.</param>
        /// <param name="cbSigBlob">[in] An integer that specifies the size of the binary metadata signature which is referenced by the pvSigBlob parameter.</param>
        /// <param name="pvSigBlob">[in] A PCCOR_SIGNATURE value that points to the binary metadata signature of the value's type.</param>
        /// <param name="ppValue">[out] A pointer to the address of an "ICorDebugValue" object representing the retrieved value that is stored in the specified register and memory location.</param>
        [PreserveSig]
        HRESULT GetLocalMemoryRegisterValue(
            [In] CORDB_ADDRESS highWordAddress,
            [In] CorDebugRegister lowWordRegister,
            [In] int cbSigBlob,
            [In] IntPtr pvSigBlob,
            [Out, MarshalAs(UnmanagedType.Interface)] out ICorDebugValue ppValue);

        /// <summary>
        /// Gets an <see cref="HRESULT"/> that indicates whether it is safe to set the instruction pointer (IP) to the specified offset location in native code.
        /// </summary>
        /// <param name="nOffset">[in] The desired setting for the instruction pointer.</param>
        /// <remarks>
        /// Use the CanSetIP method prior to calling the <see cref="SetIP"/> method. If CanSetIP returns any <see cref="HRESULT"/> other
        /// than S_OK, you can still invoke <see cref="SetIP"/>, but there is no guarantee that the debugger will continue
        /// the safe and correct execution of the code being debugged.
        /// </remarks>
        [PreserveSig]
        HRESULT CanSetIP(
            [In] int nOffset);
    }
}
