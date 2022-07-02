using System;
using System.Diagnostics;
using System.Linq;

namespace ClrDebug
{
    /// <summary>
    /// Represents a stack frame of Microsoft intermediate language (MSIL) code. This interface is a subclass of the <see cref="ICorDebugFrame"/> interface.
    /// </summary>
    /// <remarks>
    /// The <see cref="ICorDebugILFrame"/> interface is a specialized <see cref="ICorDebugFrame"/> interface. It is used either for MSIL code frames
    /// or for just-in-time (JIT) compiled frames. The JIT-compiled frames implement both the <see cref="ICorDebugILFrame"/> interface
    /// and the <see cref="ICorDebugNativeFrame"/> interface.
    /// </remarks>
    public class CorDebugILFrame : CorDebugFrame
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CorDebugILFrame"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
        public CorDebugILFrame(ICorDebugILFrame raw) : base(raw)
        {
        }

        #region ICorDebugILFrame

        public new ICorDebugILFrame Raw => (ICorDebugILFrame) base.Raw;

        #region StackDepth

        /// <summary>
        /// This method has not been implemented.
        /// </summary>
        public int StackDepth
        {
            get
            {
                int pDepth;
                TryGetStackDepth(out pDepth).ThrowOnNotOK();

                return pDepth;
            }
        }

        /// <summary>
        /// This method has not been implemented.
        /// </summary>
        public HRESULT TryGetStackDepth(out int pDepth)
        {
            /*HRESULT GetStackDepth([Out] out int pDepth);*/
            return Raw.GetStackDepth(out pDepth);
        }

        #endregion
        #region GetIP

        /// <summary>
        /// Gets the value of the instruction pointer and a bitwise combination value that describes how the value of the instruction pointer was obtained.
        /// </summary>
        /// <returns>The values that were emitted from the COM method.</returns>
        /// <remarks>
        /// The value of the instruction pointer is the stack frame's offset into the function's Microsoft intermediate language
        /// (MSIL) code. If the stack frame is active, this address is the next instruction to execute. If the stack frame
        /// is not active, this address is the next instruction to execute when the stack frame is reactivated. If this frame
        /// is a just-in-time (JIT) compiled frame, the value of the instruction pointer will be determined by mapping backwards
        /// from the actual native instruction pointer, so the value may be only approximate.
        /// </remarks>
        public GetIPResult GetIP()
        {
            GetIPResult result;
            TryGetIP(out result).ThrowOnNotOK();

            return result;
        }

        /// <summary>
        /// Gets the value of the instruction pointer and a bitwise combination value that describes how the value of the instruction pointer was obtained.
        /// </summary>
        /// <param name="result">The values that were emitted from the COM method.</param>
        /// <remarks>
        /// The value of the instruction pointer is the stack frame's offset into the function's Microsoft intermediate language
        /// (MSIL) code. If the stack frame is active, this address is the next instruction to execute. If the stack frame
        /// is not active, this address is the next instruction to execute when the stack frame is reactivated. If this frame
        /// is a just-in-time (JIT) compiled frame, the value of the instruction pointer will be determined by mapping backwards
        /// from the actual native instruction pointer, so the value may be only approximate.
        /// </remarks>
        public HRESULT TryGetIP(out GetIPResult result)
        {
            /*HRESULT GetIP([Out] out int pnOffset, [Out] out CorDebugMappingResult pMappingResult);*/
            int pnOffset;
            CorDebugMappingResult pMappingResult;
            HRESULT hr = Raw.GetIP(out pnOffset, out pMappingResult);

            if (hr == HRESULT.S_OK)
                result = new GetIPResult(pnOffset, pMappingResult);
            else
                result = default(GetIPResult);

            return hr;
        }

        #endregion
        #region SetIP

        /// <summary>
        /// Sets the instruction pointer to the specified offset location in the Microsoft intermediate language (MSIL) code.
        /// </summary>
        /// <param name="nOffset">The offset location in the MSIL code.</param>
        /// <remarks>
        /// Calls to SetIP immediately invalidate all frames and chains for the current thread. If the debugger needs frame
        /// information after a call to SetIP, it must perform a new stack trace. <see cref="ICorDebug"/> will attempt to keep
        /// the stack frame in a valid state. However, even if the frame is in a valid state, there still may be problems such
        /// as uninitialized local variables. The caller is responsible for ensuring the coherency of the running program.
        /// On 64-bit platforms, the instruction pointer cannot be moved out of a catch or finally block. If SetIP is called
        /// to make such a move on a 64-bit platform, it will return an <see cref="HRESULT"/> indicating failure.
        /// </remarks>
        public void SetIP(int nOffset)
        {
            TrySetIP(nOffset).ThrowOnNotOK();
        }

        /// <summary>
        /// Sets the instruction pointer to the specified offset location in the Microsoft intermediate language (MSIL) code.
        /// </summary>
        /// <param name="nOffset">The offset location in the MSIL code.</param>
        /// <remarks>
        /// Calls to SetIP immediately invalidate all frames and chains for the current thread. If the debugger needs frame
        /// information after a call to SetIP, it must perform a new stack trace. <see cref="ICorDebug"/> will attempt to keep
        /// the stack frame in a valid state. However, even if the frame is in a valid state, there still may be problems such
        /// as uninitialized local variables. The caller is responsible for ensuring the coherency of the running program.
        /// On 64-bit platforms, the instruction pointer cannot be moved out of a catch or finally block. If SetIP is called
        /// to make such a move on a 64-bit platform, it will return an <see cref="HRESULT"/> indicating failure.
        /// </remarks>
        public HRESULT TrySetIP(int nOffset)
        {
            /*HRESULT SetIP([In] int nOffset);*/
            return Raw.SetIP(nOffset);
        }

        #endregion
        #region EnumerateLocalVariables

        /// <summary>
        /// Gets an enumerator for the local variables in this frame.
        /// </summary>
        public CorDebugValue[] LocalVariables => EnumerateLocalVariables().ToArray();

        /// <summary>
        /// Gets an enumerator for the local variables in this frame.
        /// </summary>
        /// <returns>[out] A pointer to the address of an <see cref="ICorDebugValueEnum"/> object that is the enumerator for the local variables in this frame.</returns>
        /// <remarks>
        /// EnumerateLocalVariables gets an enumerator that can list the local variables available in the call frame that is
        /// represented by this <see cref="ICorDebugILFrame"/> object. The list may not include all of the local variables in the running
        /// function, because some of them may not be active.
        /// </remarks>
        public CorDebugValueEnum EnumerateLocalVariables()
        {
            CorDebugValueEnum ppValueEnumResult;
            TryEnumerateLocalVariables(out ppValueEnumResult).ThrowOnNotOK();

            return ppValueEnumResult;
        }

        /// <summary>
        /// Gets an enumerator for the local variables in this frame.
        /// </summary>
        /// <param name="ppValueEnumResult">[out] A pointer to the address of an <see cref="ICorDebugValueEnum"/> object that is the enumerator for the local variables in this frame.</param>
        /// <remarks>
        /// EnumerateLocalVariables gets an enumerator that can list the local variables available in the call frame that is
        /// represented by this <see cref="ICorDebugILFrame"/> object. The list may not include all of the local variables in the running
        /// function, because some of them may not be active.
        /// </remarks>
        public HRESULT TryEnumerateLocalVariables(out CorDebugValueEnum ppValueEnumResult)
        {
            /*HRESULT EnumerateLocalVariables([Out, MarshalAs(UnmanagedType.Interface)] out ICorDebugValueEnum ppValueEnum);*/
            ICorDebugValueEnum ppValueEnum;
            HRESULT hr = Raw.EnumerateLocalVariables(out ppValueEnum);

            if (hr == HRESULT.S_OK)
                ppValueEnumResult = new CorDebugValueEnum(ppValueEnum);
            else
                ppValueEnumResult = default(CorDebugValueEnum);

            return hr;
        }

        #endregion
        #region GetLocalVariable

        /// <summary>
        /// Gets the value of the specified local variable in this Microsoft intermediate language (MSIL) stack frame.
        /// </summary>
        /// <param name="dwIndex">[in] The index of the local variable in this MSIL stack frame.</param>
        /// <returns>[out] A pointer to the address of an <see cref="ICorDebugValue"/> object that represents the retrieved value.</returns>
        /// <remarks>
        /// The GetLocalVariable method can be used either in an MSIL stack frame or in a just-in-time (JIT) compiled frame.
        /// </remarks>
        public CorDebugValue GetLocalVariable(int dwIndex)
        {
            CorDebugValue ppValueResult;
            TryGetLocalVariable(dwIndex, out ppValueResult).ThrowOnNotOK();

            return ppValueResult;
        }

        /// <summary>
        /// Gets the value of the specified local variable in this Microsoft intermediate language (MSIL) stack frame.
        /// </summary>
        /// <param name="dwIndex">[in] The index of the local variable in this MSIL stack frame.</param>
        /// <param name="ppValueResult">[out] A pointer to the address of an <see cref="ICorDebugValue"/> object that represents the retrieved value.</param>
        /// <remarks>
        /// The GetLocalVariable method can be used either in an MSIL stack frame or in a just-in-time (JIT) compiled frame.
        /// </remarks>
        public HRESULT TryGetLocalVariable(int dwIndex, out CorDebugValue ppValueResult)
        {
            /*HRESULT GetLocalVariable([In] int dwIndex, [Out, MarshalAs(UnmanagedType.Interface)] out ICorDebugValue ppValue);*/
            ICorDebugValue ppValue;
            HRESULT hr = Raw.GetLocalVariable(dwIndex, out ppValue);

            if (hr == HRESULT.S_OK)
                ppValueResult = CorDebugValue.New(ppValue);
            else
                ppValueResult = default(CorDebugValue);

            return hr;
        }

        #endregion
        #region EnumerateArguments

        /// <summary>
        /// Gets an enumerator for the arguments in this frame.
        /// </summary>
        public CorDebugValue[] Arguments => EnumerateArguments().ToArray();

        /// <summary>
        /// Gets an enumerator for the arguments in this frame.
        /// </summary>
        /// <returns>[out] A pointer to the address of an <see cref="ICorDebugValueEnum"/> object that is the enumerator for the arguments in this frame.</returns>
        /// <remarks>
        /// EnumerateArguments gets an enumerator that can list the arguments available in the call frame that is represented
        /// by this <see cref="ICorDebugILFrame"/> object. The list will include arguments that are vararg (that is, a variable number of
        /// arguments) as well as arguments that are not vararg.
        /// </remarks>
        public CorDebugValueEnum EnumerateArguments()
        {
            CorDebugValueEnum ppValueEnumResult;
            TryEnumerateArguments(out ppValueEnumResult).ThrowOnNotOK();

            return ppValueEnumResult;
        }

        /// <summary>
        /// Gets an enumerator for the arguments in this frame.
        /// </summary>
        /// <param name="ppValueEnumResult">[out] A pointer to the address of an <see cref="ICorDebugValueEnum"/> object that is the enumerator for the arguments in this frame.</param>
        /// <remarks>
        /// EnumerateArguments gets an enumerator that can list the arguments available in the call frame that is represented
        /// by this <see cref="ICorDebugILFrame"/> object. The list will include arguments that are vararg (that is, a variable number of
        /// arguments) as well as arguments that are not vararg.
        /// </remarks>
        public HRESULT TryEnumerateArguments(out CorDebugValueEnum ppValueEnumResult)
        {
            /*HRESULT EnumerateArguments([Out, MarshalAs(UnmanagedType.Interface)] out ICorDebugValueEnum ppValueEnum);*/
            ICorDebugValueEnum ppValueEnum;
            HRESULT hr = Raw.EnumerateArguments(out ppValueEnum);

            if (hr == HRESULT.S_OK)
                ppValueEnumResult = new CorDebugValueEnum(ppValueEnum);
            else
                ppValueEnumResult = default(CorDebugValueEnum);

            return hr;
        }

        #endregion
        #region GetArgument

        /// <summary>
        /// Gets the value of the specified argument in this Microsoft intermediate language (MSIL) stack frame.
        /// </summary>
        /// <param name="dwIndex">[in] The index of the argument in this MSIL stack frame.</param>
        /// <returns>[out] A pointer to the address of an <see cref="ICorDebugValue"/> object that represents the retrieved value.</returns>
        /// <remarks>
        /// The GetArgument method can be used either in an MSIL stack frame or in a just-in-time (JIT) compiled frame.
        /// </remarks>
        public CorDebugValue GetArgument(int dwIndex)
        {
            CorDebugValue ppValueResult;
            TryGetArgument(dwIndex, out ppValueResult).ThrowOnNotOK();

            return ppValueResult;
        }

        /// <summary>
        /// Gets the value of the specified argument in this Microsoft intermediate language (MSIL) stack frame.
        /// </summary>
        /// <param name="dwIndex">[in] The index of the argument in this MSIL stack frame.</param>
        /// <param name="ppValueResult">[out] A pointer to the address of an <see cref="ICorDebugValue"/> object that represents the retrieved value.</param>
        /// <remarks>
        /// The GetArgument method can be used either in an MSIL stack frame or in a just-in-time (JIT) compiled frame.
        /// </remarks>
        public HRESULT TryGetArgument(int dwIndex, out CorDebugValue ppValueResult)
        {
            /*HRESULT GetArgument([In] int dwIndex, [Out, MarshalAs(UnmanagedType.Interface)] out ICorDebugValue ppValue);*/
            ICorDebugValue ppValue;
            HRESULT hr = Raw.GetArgument(dwIndex, out ppValue);

            if (hr == HRESULT.S_OK)
                ppValueResult = CorDebugValue.New(ppValue);
            else
                ppValueResult = default(CorDebugValue);

            return hr;
        }

        #endregion
        #region GetStackValue

        /// <summary>
        /// This method has not been implemented.
        /// </summary>
        public CorDebugValue GetStackValue(int dwIndex)
        {
            CorDebugValue ppValueResult;
            TryGetStackValue(dwIndex, out ppValueResult).ThrowOnNotOK();

            return ppValueResult;
        }

        /// <summary>
        /// This method has not been implemented.
        /// </summary>
        public HRESULT TryGetStackValue(int dwIndex, out CorDebugValue ppValueResult)
        {
            /*HRESULT GetStackValue([In] int dwIndex, [Out, MarshalAs(UnmanagedType.Interface)] out ICorDebugValue ppValue);*/
            ICorDebugValue ppValue;
            HRESULT hr = Raw.GetStackValue(dwIndex, out ppValue);

            if (hr == HRESULT.S_OK)
                ppValueResult = CorDebugValue.New(ppValue);
            else
                ppValueResult = default(CorDebugValue);

            return hr;
        }

        #endregion
        #region CanSetIP

        /// <summary>
        /// Gets an <see cref="HRESULT"/> that indicates whether it is safe to set the instruction pointer to the specified offset location in Microsoft Intermediate Language (MSIL) code.
        /// </summary>
        /// <param name="nOffset">[in] The desired setting for the instruction pointer.</param>
        /// <remarks>
        /// Use the CanSetIP method before calling the <see cref="SetIP"/> method. If CanSetIP returns any <see cref="HRESULT"/> other than
        /// S_OK, you can still invoke <see cref="SetIP"/>, but there is no guarantee that the debugger will continue the
        /// safe and correct execution of the code being debugged.
        /// </remarks>
        public void CanSetIP(int nOffset)
        {
            TryCanSetIP(nOffset).ThrowOnNotOK();
        }

        /// <summary>
        /// Gets an <see cref="HRESULT"/> that indicates whether it is safe to set the instruction pointer to the specified offset location in Microsoft Intermediate Language (MSIL) code.
        /// </summary>
        /// <param name="nOffset">[in] The desired setting for the instruction pointer.</param>
        /// <remarks>
        /// Use the CanSetIP method before calling the <see cref="SetIP"/> method. If CanSetIP returns any <see cref="HRESULT"/> other than
        /// S_OK, you can still invoke <see cref="SetIP"/>, but there is no guarantee that the debugger will continue the
        /// safe and correct execution of the code being debugged.
        /// </remarks>
        public HRESULT TryCanSetIP(int nOffset)
        {
            /*HRESULT CanSetIP([In] int nOffset);*/
            return Raw.CanSetIP(nOffset);
        }

        #endregion
        #endregion
        #region ICorDebugILFrame2

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public ICorDebugILFrame2 Raw2 => (ICorDebugILFrame2) Raw;

        #region RemapFunction

        /// <summary>
        /// Remaps an edited function by specifying the new Microsoft intermediate language (MSIL) offset
        /// </summary>
        /// <param name="newILOffset">[in] The stack frame's new MSIL offset at which the instruction pointer should be placed. This value must be a sequence point.<para/>
        /// It is the caller’s responsibility to ensure the validity of this value. For example, the MSIL offset is not valid if it is outside the bounds of the function.</param>
        /// <remarks>
        /// When a frame’s function has been edited, the debugger can call the RemapFunction method to swap in the latest version
        /// of the frame's function so it can be executed. The code execution will begin at the given MSIL offset. The RemapFunction
        /// method can be called only in the context of the current frame, and only in one of the following cases:
        /// </remarks>
        public void RemapFunction(int newILOffset)
        {
            TryRemapFunction(newILOffset).ThrowOnNotOK();
        }

        /// <summary>
        /// Remaps an edited function by specifying the new Microsoft intermediate language (MSIL) offset
        /// </summary>
        /// <param name="newILOffset">[in] The stack frame's new MSIL offset at which the instruction pointer should be placed. This value must be a sequence point.<para/>
        /// It is the caller’s responsibility to ensure the validity of this value. For example, the MSIL offset is not valid if it is outside the bounds of the function.</param>
        /// <remarks>
        /// When a frame’s function has been edited, the debugger can call the RemapFunction method to swap in the latest version
        /// of the frame's function so it can be executed. The code execution will begin at the given MSIL offset. The RemapFunction
        /// method can be called only in the context of the current frame, and only in one of the following cases:
        /// </remarks>
        public HRESULT TryRemapFunction(int newILOffset)
        {
            /*HRESULT RemapFunction([In] int newILOffset);*/
            return Raw2.RemapFunction(newILOffset);
        }

        #endregion
        #region EnumerateTypeParameters

        /// <summary>
        /// Gets an <see cref="ICorDebugTypeEnum"/> object that contains the <see cref="Type"/> parameters in this frame.
        /// </summary>
        public CorDebugType[] TypeParameters => EnumerateTypeParameters().ToArray();

        /// <summary>
        /// Gets an <see cref="ICorDebugTypeEnum"/> object that contains the <see cref="Type"/> parameters in this frame.
        /// </summary>
        /// <returns>A pointer to the address of a <see cref="ICorDebugTypeEnum"/> interface object that allows enumeration of type parameters. The list of type parameters include the class type parameters (if any) followed by the method type parameters (if any).</returns>
        /// <remarks>
        /// Use the <see cref="MetaDataImport.EnumGenericParams"/> method to determine how many class type parameters and
        /// method type parameters this list contains. The type parameters are not always available.
        /// </remarks>
        public CorDebugTypeEnum EnumerateTypeParameters()
        {
            CorDebugTypeEnum ppTyParEnumResult;
            TryEnumerateTypeParameters(out ppTyParEnumResult).ThrowOnNotOK();

            return ppTyParEnumResult;
        }

        /// <summary>
        /// Gets an <see cref="ICorDebugTypeEnum"/> object that contains the <see cref="Type"/> parameters in this frame.
        /// </summary>
        /// <param name="ppTyParEnumResult">A pointer to the address of a <see cref="ICorDebugTypeEnum"/> interface object that allows enumeration of type parameters. The list of type parameters include the class type parameters (if any) followed by the method type parameters (if any).</param>
        /// <remarks>
        /// Use the <see cref="MetaDataImport.EnumGenericParams"/> method to determine how many class type parameters and
        /// method type parameters this list contains. The type parameters are not always available.
        /// </remarks>
        public HRESULT TryEnumerateTypeParameters(out CorDebugTypeEnum ppTyParEnumResult)
        {
            /*HRESULT EnumerateTypeParameters([Out, MarshalAs(UnmanagedType.Interface)] out ICorDebugTypeEnum ppTyParEnum);*/
            ICorDebugTypeEnum ppTyParEnum;
            HRESULT hr = Raw2.EnumerateTypeParameters(out ppTyParEnum);

            if (hr == HRESULT.S_OK)
                ppTyParEnumResult = new CorDebugTypeEnum(ppTyParEnum);
            else
                ppTyParEnumResult = default(CorDebugTypeEnum);

            return hr;
        }

        #endregion
        #endregion
        #region ICorDebugILFrame3

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public ICorDebugILFrame3 Raw3 => (ICorDebugILFrame3) Raw;

        #region GetReturnValueForILOffset

        /// <summary>
        /// Gets an "ICorDebugValue" object that encapsulates the return value of a function.
        /// </summary>
        /// <param name="ilOffset">The IL offset. See the Remarks section.</param>
        /// <returns>A pointer to the address of an "ICorDebugValue" interface object that provides information about the return value of a function call.</returns>
        /// <remarks>
        /// This method is used along with the <see cref="CorDebugCode.GetReturnValueLiveOffset"/> method to get the return
        /// value of a method. It is particularly useful in the case of methods whose return values are ignored, as in the
        /// following two code examples. The first example calls the <see cref="int.TryParse(string, out int)"/> method, but
        /// ignores the method's return value. [!code-csharpUnmanaged.Debugging.MRV#1][!code-vbUnmanaged.Debugging.MRV#1] The
        /// second example illustrates a much more common problem in debugging. Because a method is used as an argument in
        /// a method call, its return value is accessible only when the debugger steps through the called method. In many cases,
        /// particularly when the called method is defined in an external library, that is not possible. [!code-csharpUnmanaged.Debugging.MRV#2][!code-vbUnmanaged.Debugging.MRV#2]
        /// If you pass the <see cref="CorDebugCode.GetReturnValueLiveOffset"/> method an IL offset to a function call site,
        /// it returns one or more native offsets. The debugger can then set breakpoints on these native offsets in the function.
        /// When the debugger hits one of the breakpoints, you can then pass the same IL offset that you passed to this method
        /// to get the return value. The debugger should then clear all the breakpoints that it set. The IL offset specified
        /// by the ILOffset parameter should be at a function call site, and the debuggee should be stopped at a breakpoint
        /// set at the native offset returned by the <see cref="CorDebugCode.GetReturnValueLiveOffset"/> method for the same
        /// IL offset. If the debuggee is not stopped at the correct location for the specified IL offset, the API will fail.
        /// If the function call doesn't return a value, the API will fail. The ICorDebugILFrame3::GetReturnValueForILOffset
        /// method is available only on x86-based and AMD64 systems.
        /// </remarks>
        public CorDebugValue GetReturnValueForILOffset(int ilOffset)
        {
            CorDebugValue ppReturnValueResult;
            TryGetReturnValueForILOffset(ilOffset, out ppReturnValueResult).ThrowOnNotOK();

            return ppReturnValueResult;
        }

        /// <summary>
        /// Gets an "ICorDebugValue" object that encapsulates the return value of a function.
        /// </summary>
        /// <param name="ilOffset">The IL offset. See the Remarks section.</param>
        /// <param name="ppReturnValueResult">A pointer to the address of an "ICorDebugValue" interface object that provides information about the return value of a function call.</param>
        /// <remarks>
        /// This method is used along with the <see cref="CorDebugCode.GetReturnValueLiveOffset"/> method to get the return
        /// value of a method. It is particularly useful in the case of methods whose return values are ignored, as in the
        /// following two code examples. The first example calls the <see cref="int.TryParse(string, out int)"/> method, but
        /// ignores the method's return value. [!code-csharpUnmanaged.Debugging.MRV#1][!code-vbUnmanaged.Debugging.MRV#1] The
        /// second example illustrates a much more common problem in debugging. Because a method is used as an argument in
        /// a method call, its return value is accessible only when the debugger steps through the called method. In many cases,
        /// particularly when the called method is defined in an external library, that is not possible. [!code-csharpUnmanaged.Debugging.MRV#2][!code-vbUnmanaged.Debugging.MRV#2]
        /// If you pass the <see cref="CorDebugCode.GetReturnValueLiveOffset"/> method an IL offset to a function call site,
        /// it returns one or more native offsets. The debugger can then set breakpoints on these native offsets in the function.
        /// When the debugger hits one of the breakpoints, you can then pass the same IL offset that you passed to this method
        /// to get the return value. The debugger should then clear all the breakpoints that it set. The IL offset specified
        /// by the ILOffset parameter should be at a function call site, and the debuggee should be stopped at a breakpoint
        /// set at the native offset returned by the <see cref="CorDebugCode.GetReturnValueLiveOffset"/> method for the same
        /// IL offset. If the debuggee is not stopped at the correct location for the specified IL offset, the API will fail.
        /// If the function call doesn't return a value, the API will fail. The ICorDebugILFrame3::GetReturnValueForILOffset
        /// method is available only on x86-based and AMD64 systems.
        /// </remarks>
        public HRESULT TryGetReturnValueForILOffset(int ilOffset, out CorDebugValue ppReturnValueResult)
        {
            /*HRESULT GetReturnValueForILOffset([In] int ilOffset,
            [Out, MarshalAs(UnmanagedType.Interface)] out ICorDebugValue ppReturnValue);*/
            ICorDebugValue ppReturnValue;
            HRESULT hr = Raw3.GetReturnValueForILOffset(ilOffset, out ppReturnValue);

            if (hr == HRESULT.S_OK)
                ppReturnValueResult = CorDebugValue.New(ppReturnValue);
            else
                ppReturnValueResult = default(CorDebugValue);

            return hr;
        }

        #endregion
        #endregion
        #region ICorDebugILFrame4

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public ICorDebugILFrame4 Raw4 => (ICorDebugILFrame4) Raw;

        #region EnumerateLocalVariablesEx

        /// <summary>
        /// [Supported in the .NET Framework 4.5.2 and later versions] Gets an enumerator for the local variable in the frame, and optionally includes variables added in profiler ReJIT instrumentation.
        /// </summary>
        /// <param name="flags">[in] An <see cref="ILCodeKind"/> enumeration member that specifies whether variables added in profiler ReJIT instrumentation are included in the frame.</param>
        /// <returns>[out] A pointer to the address of an "ICorDebugValueEnum" object that is the enumerator for the local variables in this frame.</returns>
        /// <remarks>
        /// This method is similar to the <see cref="EnumerateLocalVariables"/> method, except that it optionally
        /// accesses variables added in profiler ReJIT instrumentation. Setting flags to ILCODE_ORIGINAL_IL is equivalent to
        /// calling <see cref="EnumerateLocalVariables"/>. Setting flags to ILCODE_REJIT_IL allows the debugger
        /// to access the local variables added in profiler ReJIT instrumentation. If the intermediate language (IL) is not
        /// instrumented, the enumeration is empty and the method returns S_OK. The enumerator may not include all of the local
        /// variables in the running method, since some of them may not be active.
        /// </remarks>
        public CorDebugValueEnum EnumerateLocalVariablesEx(ILCodeKind flags)
        {
            CorDebugValueEnum ppValueEnumResult;
            TryEnumerateLocalVariablesEx(flags, out ppValueEnumResult).ThrowOnNotOK();

            return ppValueEnumResult;
        }

        /// <summary>
        /// [Supported in the .NET Framework 4.5.2 and later versions] Gets an enumerator for the local variable in the frame, and optionally includes variables added in profiler ReJIT instrumentation.
        /// </summary>
        /// <param name="flags">[in] An <see cref="ILCodeKind"/> enumeration member that specifies whether variables added in profiler ReJIT instrumentation are included in the frame.</param>
        /// <param name="ppValueEnumResult">[out] A pointer to the address of an "ICorDebugValueEnum" object that is the enumerator for the local variables in this frame.</param>
        /// <remarks>
        /// This method is similar to the <see cref="EnumerateLocalVariables"/> method, except that it optionally
        /// accesses variables added in profiler ReJIT instrumentation. Setting flags to ILCODE_ORIGINAL_IL is equivalent to
        /// calling <see cref="EnumerateLocalVariables"/>. Setting flags to ILCODE_REJIT_IL allows the debugger
        /// to access the local variables added in profiler ReJIT instrumentation. If the intermediate language (IL) is not
        /// instrumented, the enumeration is empty and the method returns S_OK. The enumerator may not include all of the local
        /// variables in the running method, since some of them may not be active.
        /// </remarks>
        public HRESULT TryEnumerateLocalVariablesEx(ILCodeKind flags, out CorDebugValueEnum ppValueEnumResult)
        {
            /*HRESULT EnumerateLocalVariablesEx([In] ILCodeKind flags,
            [Out, MarshalAs(UnmanagedType.Interface)] out ICorDebugValueEnum ppValueEnum);*/
            ICorDebugValueEnum ppValueEnum;
            HRESULT hr = Raw4.EnumerateLocalVariablesEx(flags, out ppValueEnum);

            if (hr == HRESULT.S_OK)
                ppValueEnumResult = new CorDebugValueEnum(ppValueEnum);
            else
                ppValueEnumResult = default(CorDebugValueEnum);

            return hr;
        }

        #endregion
        #region GetLocalVariableEx

        /// <summary>
        /// [Supported in the .NET Framework 4.5.2 and later versions] Gets the value of the specified local variable in this intermediate language (IL) stack frame, and optionally accesses a variable added in profiler ReJIT instrumentation.
        /// </summary>
        /// <param name="flags">[in] An <see cref="ILCodeKind"/> enumeration member that specifies whether a variable added in profiler ReJIT instrumentation is included in the frame.</param>
        /// <param name="dwIndex">[in] The index of the local variable in the IL stack frame.</param>
        /// <returns>[out] A pointer to the address of an "ICorDebugValue" object that represents the retrieved value.</returns>
        /// <remarks>
        /// This method is similar to the <see cref="GetLocalVariable"/> method, except that it optionally
        /// accesses a variable added in profiler ReJIT instrumentation. Calling this method with a flags value of ILCODE_ORIGINAL_IL
        /// is equivalent to calling <see cref="GetLocalVariable"/>; if the method is instrumented with additional
        /// local variables, those variables cannot be accessed. ILCODE_REJIT_IL allows the debugger to access the local variables
        /// added in profiler ReJIT instrumentation. If the IL is not instrumented, the method returns E_INVALIDARG.
        /// </remarks>
        public CorDebugValue GetLocalVariableEx(ILCodeKind flags, int dwIndex)
        {
            CorDebugValue ppValueResult;
            TryGetLocalVariableEx(flags, dwIndex, out ppValueResult).ThrowOnNotOK();

            return ppValueResult;
        }

        /// <summary>
        /// [Supported in the .NET Framework 4.5.2 and later versions] Gets the value of the specified local variable in this intermediate language (IL) stack frame, and optionally accesses a variable added in profiler ReJIT instrumentation.
        /// </summary>
        /// <param name="flags">[in] An <see cref="ILCodeKind"/> enumeration member that specifies whether a variable added in profiler ReJIT instrumentation is included in the frame.</param>
        /// <param name="dwIndex">[in] The index of the local variable in the IL stack frame.</param>
        /// <param name="ppValueResult">[out] A pointer to the address of an "ICorDebugValue" object that represents the retrieved value.</param>
        /// <remarks>
        /// This method is similar to the <see cref="GetLocalVariable"/> method, except that it optionally
        /// accesses a variable added in profiler ReJIT instrumentation. Calling this method with a flags value of ILCODE_ORIGINAL_IL
        /// is equivalent to calling <see cref="GetLocalVariable"/>; if the method is instrumented with additional
        /// local variables, those variables cannot be accessed. ILCODE_REJIT_IL allows the debugger to access the local variables
        /// added in profiler ReJIT instrumentation. If the IL is not instrumented, the method returns E_INVALIDARG.
        /// </remarks>
        public HRESULT TryGetLocalVariableEx(ILCodeKind flags, int dwIndex, out CorDebugValue ppValueResult)
        {
            /*HRESULT GetLocalVariableEx(
            [In] ILCodeKind flags,
            [In] int dwIndex,
            [Out, MarshalAs(UnmanagedType.Interface)] out ICorDebugValue ppValue);*/
            ICorDebugValue ppValue;
            HRESULT hr = Raw4.GetLocalVariableEx(flags, dwIndex, out ppValue);

            if (hr == HRESULT.S_OK)
                ppValueResult = CorDebugValue.New(ppValue);
            else
                ppValueResult = default(CorDebugValue);

            return hr;
        }

        #endregion
        #region GetCodeEx

        /// <summary>
        /// [Supported in the .NET Framework 4.5.2 and later versions] Gets a pointer to the code that this stack frame is executing.
        /// </summary>
        /// <param name="flags">[in] An <see cref="ILCodeKind"/> enumeration member that specifies whether the intermediate language (IL) defined by the profiler's ReJIT request is included in the frame.</param>
        /// <returns>[out] A pointer to the address of an "ICorDebugCode" object that represents the code that this stack frame is executing.</returns>
        /// <remarks>
        /// This method is similar to the <see cref="CorDebugFrame.Code"/> property, except that it optionally accesses code
        /// defined by the profiler's ReJIT request. Calling this method with a flags value of ILCODE_ORIGINAL_IL is equivalent
        /// to calling <see cref="CorDebugFrame.Code"/>; if the method is instrumented, its IL will not be accessible.
        /// ILCODE_REJIT_IL allows the debugger to access the IL defined by the profiler's ReJIT request. If the IL is not
        /// instrumented, ppCode is null, and the method returns S_OK.
        /// </remarks>
        public CorDebugCode GetCodeEx(ILCodeKind flags)
        {
            CorDebugCode ppCodeResult;
            TryGetCodeEx(flags, out ppCodeResult).ThrowOnNotOK();

            return ppCodeResult;
        }

        /// <summary>
        /// [Supported in the .NET Framework 4.5.2 and later versions] Gets a pointer to the code that this stack frame is executing.
        /// </summary>
        /// <param name="flags">[in] An <see cref="ILCodeKind"/> enumeration member that specifies whether the intermediate language (IL) defined by the profiler's ReJIT request is included in the frame.</param>
        /// <param name="ppCodeResult">[out] A pointer to the address of an "ICorDebugCode" object that represents the code that this stack frame is executing.</param>
        /// <remarks>
        /// This method is similar to the <see cref="CorDebugFrame.Code"/> property, except that it optionally accesses code
        /// defined by the profiler's ReJIT request. Calling this method with a flags value of ILCODE_ORIGINAL_IL is equivalent
        /// to calling <see cref="CorDebugFrame.Code"/>; if the method is instrumented, its IL will not be accessible.
        /// ILCODE_REJIT_IL allows the debugger to access the IL defined by the profiler's ReJIT request. If the IL is not
        /// instrumented, ppCode is null, and the method returns S_OK.
        /// </remarks>
        public HRESULT TryGetCodeEx(ILCodeKind flags, out CorDebugCode ppCodeResult)
        {
            /*HRESULT GetCodeEx(
            [In] ILCodeKind flags,
            [Out, MarshalAs(UnmanagedType.Interface)] out ICorDebugCode ppCode);*/
            ICorDebugCode ppCode;
            HRESULT hr = Raw4.GetCodeEx(flags, out ppCode);

            if (hr == HRESULT.S_OK)
                ppCodeResult = new CorDebugCode(ppCode);
            else
                ppCodeResult = default(CorDebugCode);

            return hr;
        }

        #endregion
        #endregion
    }
}