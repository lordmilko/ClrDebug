namespace ClrDebug.DIA
{
    /// <summary>
    /// Exposes the details of a stack frame.
    /// </summary>
    /// <remarks>
    /// The details available for a frame are for execution points within the address range indicated by the address and
    /// block length. Obtain this interface by calling the <see cref="DiaEnumFrameData.MoveNext"/> or <see cref="DiaEnumFrameData.Item"/>
    /// methods. See the <see cref="IDiaEnumFrameData"/> interface for details.
    /// </remarks>
    public class DiaFrameData : ComObject<IDiaFrameData>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DiaFrameData"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
        public DiaFrameData(IDiaFrameData raw) : base(raw)
        {
        }

        #region IDiaFrameData
        #region AddressSection

        /// <summary>
        /// Retrieves the section part of the code address for the frame.
        /// </summary>
        public int AddressSection
        {
            get
            {
                int pRetVal;
                TryGetAddressSection(out pRetVal).ThrowOnNotOK();

                return pRetVal;
            }
        }

        /// <summary>
        /// Retrieves the section part of the code address for the frame.
        /// </summary>
        /// <param name="pRetVal">[out] Returns the section part of the code address for the frame.</param>
        /// <returns>If successful, returns S_OK. Returns S_FALSE if this property is not supported. Otherwise, returns an error code.</returns>
        public HRESULT TryGetAddressSection(out int pRetVal)
        {
            /*HRESULT get_addressSection(
            [Out] out int pRetVal);*/
            return Raw.get_addressSection(out pRetVal);
        }

        #endregion
        #region AddressOffset

        /// <summary>
        /// Retrieves the offset part of the code address for the frame.
        /// </summary>
        public int AddressOffset
        {
            get
            {
                int pRetVal;
                TryGetAddressOffset(out pRetVal).ThrowOnNotOK();

                return pRetVal;
            }
        }

        /// <summary>
        /// Retrieves the offset part of the code address for the frame.
        /// </summary>
        /// <param name="pRetVal">[out] Returns the offset part of the code address for the frame.</param>
        /// <returns>If successful, returns S_OK. Returns S_FALSE if this property is not supported. Otherwise, returns an error code.</returns>
        public HRESULT TryGetAddressOffset(out int pRetVal)
        {
            /*HRESULT get_addressOffset(
            [Out] out int pRetVal);*/
            return Raw.get_addressOffset(out pRetVal);
        }

        #endregion
        #region RelativeVirtualAddress

        /// <summary>
        /// Retrieves the relative virtual address (RVA) of the code for the frame.
        /// </summary>
        public int RelativeVirtualAddress
        {
            get
            {
                int pRetVal;
                TryGetRelativeVirtualAddress(out pRetVal).ThrowOnNotOK();

                return pRetVal;
            }
        }

        /// <summary>
        /// Retrieves the relative virtual address (RVA) of the code for the frame.
        /// </summary>
        /// <param name="pRetVal">[out] Returns the relative virtual address of the code for the frame.</param>
        /// <returns>If successful, returns S_OK. Returns S_FALSE if this property is not supported. Otherwise, returns an error code.</returns>
        public HRESULT TryGetRelativeVirtualAddress(out int pRetVal)
        {
            /*HRESULT get_relativeVirtualAddress(
            [Out] out int pRetVal);*/
            return Raw.get_relativeVirtualAddress(out pRetVal);
        }

        #endregion
        #region VirtualAddress

        /// <summary>
        /// Retrieves the virtual address (VA) of the code for the frame.
        /// </summary>
        public long VirtualAddress
        {
            get
            {
                long pRetVal;
                TryGetVirtualAddress(out pRetVal).ThrowOnNotOK();

                return pRetVal;
            }
        }

        /// <summary>
        /// Retrieves the virtual address (VA) of the code for the frame.
        /// </summary>
        /// <param name="pRetVal">[out] Returns the virtual address of the code for the frame.</param>
        /// <returns>If successful, returns S_OK. Returns S_FALSE if this property is not supported. Otherwise, returns an error code.</returns>
        public HRESULT TryGetVirtualAddress(out long pRetVal)
        {
            /*HRESULT get_virtualAddress(
            [Out] out long pRetVal);*/
            return Raw.get_virtualAddress(out pRetVal);
        }

        #endregion
        #region LengthBlock

        /// <summary>
        /// Retrieves the length, in bytes, of the block of code described by the frame.
        /// </summary>
        public int LengthBlock
        {
            get
            {
                int pRetVal;
                TryGetLengthBlock(out pRetVal).ThrowOnNotOK();

                return pRetVal;
            }
        }

        /// <summary>
        /// Retrieves the length, in bytes, of the block of code described by the frame.
        /// </summary>
        /// <param name="pRetVal">[out] Returns the number of bytes of code in the frame.</param>
        /// <returns>If successful, returns S_OK. Returns S_FALSE if this property is not supported. Otherwise, returns an error code.</returns>
        /// <remarks>
        /// The value returned by this method is typically used in the interpretation of a program string (see the <see cref="Program"/>
        /// property for the definition of a program string).
        /// </remarks>
        public HRESULT TryGetLengthBlock(out int pRetVal)
        {
            /*HRESULT get_lengthBlock(
            [Out] out int pRetVal);*/
            return Raw.get_lengthBlock(out pRetVal);
        }

        #endregion
        #region LengthLocals

        /// <summary>
        /// Retrieves the number of bytes of local variables pushed on the stack.
        /// </summary>
        public int LengthLocals
        {
            get
            {
                int pRetVal;
                TryGetLengthLocals(out pRetVal).ThrowOnNotOK();

                return pRetVal;
            }
        }

        /// <summary>
        /// Retrieves the number of bytes of local variables pushed on the stack.
        /// </summary>
        /// <param name="pRetVal">[out] Returns the number of bytes of local variables.</param>
        /// <returns>If successful, returns S_OK. Returns S_FALSE if this property is not supported. Otherwise, returns an error code.</returns>
        /// <remarks>
        /// The value returned by this method is typically used in the interpretation of a program string (see the <see cref="Program"/>
        /// property for the definition of a program string).
        /// </remarks>
        public HRESULT TryGetLengthLocals(out int pRetVal)
        {
            /*HRESULT get_lengthLocals(
            [Out] out int pRetVal);*/
            return Raw.get_lengthLocals(out pRetVal);
        }

        #endregion
        #region LengthParams

        /// <summary>
        /// Retrieves the number of bytes of parameters pushed on the stack.
        /// </summary>
        public int LengthParams
        {
            get
            {
                int pRetVal;
                TryGetLengthParams(out pRetVal).ThrowOnNotOK();

                return pRetVal;
            }
        }

        /// <summary>
        /// Retrieves the number of bytes of parameters pushed on the stack.
        /// </summary>
        /// <param name="pRetVal">[out] Returns the number of bytes of parameters.</param>
        /// <returns>If successful, returns S_OK. Returns S_FALSE if this property is not supported. Otherwise, returns an error code.</returns>
        /// <remarks>
        /// The value returned by this method is typically used in the interpretation of a program string (see the <see cref="Program"/>
        /// property for the definition of a program string).
        /// </remarks>
        public HRESULT TryGetLengthParams(out int pRetVal)
        {
            /*HRESULT get_lengthParams(
            [Out] out int pRetVal);*/
            return Raw.get_lengthParams(out pRetVal);
        }

        #endregion
        #region MaxStack

        /// <summary>
        /// Retrieves the maximum number of bytes pushed on the stack in the frame.
        /// </summary>
        public int MaxStack
        {
            get
            {
                int pRetVal;
                TryGetMaxStack(out pRetVal).ThrowOnNotOK();

                return pRetVal;
            }
        }

        /// <summary>
        /// Retrieves the maximum number of bytes pushed on the stack in the frame.
        /// </summary>
        /// <param name="pRetVal">[out] Returns the maximum number of bytes pushed on the stack.</param>
        /// <returns>If successful, returns S_OK. Returns S_FALSE if this property is not supported. Otherwise, returns an error code.</returns>
        /// <remarks>
        /// The value returned by this method is typically used in the interpretation of a program string (see the <see cref="Program"/>
        /// property for the definition of a program string).
        /// </remarks>
        public HRESULT TryGetMaxStack(out int pRetVal)
        {
            /*HRESULT get_maxStack(
            [Out] out int pRetVal);*/
            return Raw.get_maxStack(out pRetVal);
        }

        #endregion
        #region LengthProlog

        /// <summary>
        /// Retrieves the number of bytes of prologue code in the block.
        /// </summary>
        public int LengthProlog
        {
            get
            {
                int pRetVal;
                TryGetLengthProlog(out pRetVal).ThrowOnNotOK();

                return pRetVal;
            }
        }

        /// <summary>
        /// Retrieves the number of bytes of prologue code in the block.
        /// </summary>
        /// <param name="pRetVal">[out] Returns the number of bytes of prologue code.</param>
        /// <returns>If successful, returns S_OK. Returns S_FALSE if this property is not supported. Otherwise, returns an error code.</returns>
        /// <remarks>
        /// The prologue code is a sequence of instructions that preserves registers, sets the CPU state, and establishes the
        /// stack for the function.
        /// </remarks>
        public HRESULT TryGetLengthProlog(out int pRetVal)
        {
            /*HRESULT get_lengthProlog(
            [Out] out int pRetVal);*/
            return Raw.get_lengthProlog(out pRetVal);
        }

        #endregion
        #region LengthSavedRegisters

        /// <summary>
        /// Retrieves the number of bytes of saved registers pushed on the stack.
        /// </summary>
        public int LengthSavedRegisters
        {
            get
            {
                int pRetVal;
                TryGetLengthSavedRegisters(out pRetVal).ThrowOnNotOK();

                return pRetVal;
            }
        }

        /// <summary>
        /// Retrieves the number of bytes of saved registers pushed on the stack.
        /// </summary>
        /// <param name="pRetVal">[out] Returns the number of bytes of saved registers.</param>
        /// <returns>If successful, returns S_OK. Returns S_FALSE if this property is not supported. Otherwise, returns an error code.</returns>
        /// <remarks>
        /// The value returned by this method is typically used in the interpretation of a program string (see the <see cref="Program"/>
        /// property for the definition of a program string).
        /// </remarks>
        public HRESULT TryGetLengthSavedRegisters(out int pRetVal)
        {
            /*HRESULT get_lengthSavedRegisters(
            [Out] out int pRetVal);*/
            return Raw.get_lengthSavedRegisters(out pRetVal);
        }

        #endregion
        #region Program

        /// <summary>
        /// Retrieves the program string that is used to compute the register set before the call to the current function.
        /// </summary>
        public string Program
        {
            get
            {
                string pRetVal;
                TryGetProgram(out pRetVal).ThrowOnNotOK();

                return pRetVal;
            }
        }

        /// <summary>
        /// Retrieves the program string that is used to compute the register set before the call to the current function.
        /// </summary>
        /// <param name="pRetVal">[out] Returns the program string.</param>
        /// <returns>If successful, returns S_OK. Returns S_FALSE if this property is not supported. Otherwise, returns an error code.</returns>
        /// <remarks>
        /// The program string is a sequence of macros that is interpreted in order to establish the prologue. For example,
        /// a typical stack frame might use the program string "$T0 $ebp = $eip $T0 4 + ^ = $ebp $T0 ^ = $esp $T0 8 + =". The
        /// format is reverse polish notation, where the operators follow the operands. T0 represents a temporary variable
        /// on the stack. This example performs the following steps:
        /// </remarks>
        public HRESULT TryGetProgram(out string pRetVal)
        {
            /*HRESULT get_program(
            [Out, MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(DiaStringMarshaller))] out string pRetVal);*/
            return Raw.get_program(out pRetVal);
        }

        #endregion
        #region SystemExceptionHandling

        /// <summary>
        /// Retrieves a flag that indicates whether system exception handling is in effect.
        /// </summary>
        public bool SystemExceptionHandling
        {
            get
            {
                bool pRetVal;
                TryGetSystemExceptionHandling(out pRetVal).ThrowOnFailed();

                return pRetVal;
            }
        }

        /// <summary>
        /// Retrieves a flag that indicates whether system exception handling is in effect.
        /// </summary>
        /// <param name="pRetVal">[out] Returns TRUE if system exception handling is in effect; otherwise, returns FALSE.</param>
        /// <returns>If successful, returns S_OK. Returns S_FALSE if this property is not supported. Otherwise, returns an error code.</returns>
        /// <remarks>
        /// System exception handling is more commonly known as structured exception handling. To determine if C++ exception
        /// handling is in effect, call the <see cref="CplusplusExceptionHandling"/> property.
        /// </remarks>
        public HRESULT TryGetSystemExceptionHandling(out bool pRetVal)
        {
            /*HRESULT get_systemExceptionHandling(
            [Out, MarshalAs(UnmanagedType.Bool)] out bool pRetVal);*/
            return Raw.get_systemExceptionHandling(out pRetVal);
        }

        #endregion
        #region CplusplusExceptionHandling

        /// <summary>
        /// Retrieves a flag that indicates whether C++ exception handling is in effect.
        /// </summary>
        public bool CplusplusExceptionHandling
        {
            get
            {
                bool pRetVal;
                TryGetCplusplusExceptionHandling(out pRetVal).ThrowOnFailed();

                return pRetVal;
            }
        }

        /// <summary>
        /// Retrieves a flag that indicates whether C++ exception handling is in effect.
        /// </summary>
        /// <param name="pRetVal">[out] Returns TRUE if C++ exception handling is in effect; otherwise, returns FALSE.</param>
        /// <returns>If successful, returns S_OK. Returns S_FALSE if this property is not supported. Otherwise, returns an error code.</returns>
        /// <remarks>
        /// To determine if structured exception handling is in effect (which is very different from C++ exception handling),
        /// call the <see cref="SystemExceptionHandling"/> property.
        /// </remarks>
        public HRESULT TryGetCplusplusExceptionHandling(out bool pRetVal)
        {
            /*HRESULT get_cplusplusExceptionHandling(
            [Out, MarshalAs(UnmanagedType.Bool)] out bool pRetVal);*/
            return Raw.get_cplusplusExceptionHandling(out pRetVal);
        }

        #endregion
        #region FunctionStart

        /// <summary>
        /// Retrieves a flag that indicates whether the block contains the entry point of a function.
        /// </summary>
        public bool FunctionStart
        {
            get
            {
                bool pRetVal;
                TryGetFunctionStart(out pRetVal).ThrowOnFailed();

                return pRetVal;
            }
        }

        /// <summary>
        /// Retrieves a flag that indicates whether the block contains the entry point of a function.
        /// </summary>
        /// <param name="pRetVal">[out] Returns TRUE if the block contains the entry point; otherwise returns FALSE.</param>
        /// <returns>If successful, returns S_OK. Returns S_FALSE if this property is not supported. Otherwise, returns an error code.</returns>
        /// <remarks>
        /// It is possible for a stack frame to not be the start of a function because the frame represents an inline method
        /// or function inserted into a function.
        /// </remarks>
        public HRESULT TryGetFunctionStart(out bool pRetVal)
        {
            /*HRESULT get_functionStart(
            [Out, MarshalAs(UnmanagedType.Bool)] out bool pRetVal);*/
            return Raw.get_functionStart(out pRetVal);
        }

        #endregion
        #region AllocatesBasePointer

        /// <summary>
        /// Retrieves a flag that indicates whether the base pointer is allocated for code in this address range. This method is deprecated.
        /// </summary>
        public bool AllocatesBasePointer
        {
            get
            {
                bool pRetVal;
                TryGetAllocatesBasePointer(out pRetVal).ThrowOnFailed();

                return pRetVal;
            }
        }

        /// <summary>
        /// Retrieves a flag that indicates whether the base pointer is allocated for code in this address range. This method is deprecated.
        /// </summary>
        /// <param name="pRetVal">[out] Returns TRUE if a base pointer is allocated; otherwise, returns FALSE.</param>
        /// <returns>If successful, returns S_OK. Returns S_FALSE if this property is not supported. Otherwise, returns an error code.</returns>
        /// <remarks>
        /// This property should be used only by code that formerly accessed FPO_DATA, or when the program string returned
        /// by the <see cref="Program"/> property is NULL. Otherwise, the program string contains all the information needed
        /// to compute previous register values.
        /// </remarks>
        public HRESULT TryGetAllocatesBasePointer(out bool pRetVal)
        {
            /*HRESULT get_allocatesBasePointer(
            [Out, MarshalAs(UnmanagedType.Bool)] out bool pRetVal);*/
            return Raw.get_allocatesBasePointer(out pRetVal);
        }

        #endregion
        #region Type

        /// <summary>
        /// Retrieves the compiler-specific frame type.
        /// </summary>
        public StackFrameTypeEnum Type
        {
            get
            {
                StackFrameTypeEnum pRetVal;
                TryGetType(out pRetVal).ThrowOnNotOK();

                return pRetVal;
            }
        }

        /// <summary>
        /// Retrieves the compiler-specific frame type.
        /// </summary>
        /// <param name="pRetVal">[out] Returns a value from the <see cref="StackFrameTypeEnum"/> enumeration that indicates the compiler-specific frame type.</param>
        /// <returns>If successful, returns S_OK. Returns S_FALSE if this property is not supported. Otherwise, returns an error code.</returns>
        public HRESULT TryGetType(out StackFrameTypeEnum pRetVal)
        {
            /*HRESULT get_type(
            [Out] out StackFrameTypeEnum pRetVal);*/
            return Raw.get_type(out pRetVal);
        }

        #endregion
        #region FunctionParent

        /// <summary>
        /// Retrieves a frame data interface for the enclosing function.
        /// </summary>
        public DiaFrameData FunctionParent
        {
            get
            {
                DiaFrameData pRetValResult;
                TryGetFunctionParent(out pRetValResult).ThrowOnNotOK();

                return pRetValResult;
            }
        }

        /// <summary>
        /// Retrieves a frame data interface for the enclosing function.
        /// </summary>
        /// <param name="pRetValResult">[out] Returns an <see cref="IDiaFrameData"/> object for the enclosing function.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns an error code.</returns>
        public HRESULT TryGetFunctionParent(out DiaFrameData pRetValResult)
        {
            /*HRESULT get_functionParent(
            [Out, MarshalAs(UnmanagedType.Interface)] out IDiaFrameData pRetVal);*/
            IDiaFrameData pRetVal;
            HRESULT hr = Raw.get_functionParent(out pRetVal);

            if (hr == HRESULT.S_OK)
                pRetValResult = pRetVal == null ? null : new DiaFrameData(pRetVal);
            else
                pRetValResult = default(DiaFrameData);

            return hr;
        }

        #endregion
        #region Execute

        /// <summary>
        /// Performs stack unwinding and returns results in a stack walk frame interface.
        /// </summary>
        /// <param name="frame">[in] An <see cref="IDiaStackWalkFrame"/> object that holds the state of frame registers.</param>
        /// <remarks>
        /// This method is called during debugging to unwind the stack. The <see cref="IDiaStackWalkFrame"/> object is implemented
        /// by the client application to receive updates to the registers and to provide methods used by the execute method.
        /// </remarks>
        public void Execute(IDiaStackWalkFrame frame)
        {
            TryExecute(frame).ThrowOnNotOK();
        }

        /// <summary>
        /// Performs stack unwinding and returns results in a stack walk frame interface.
        /// </summary>
        /// <param name="frame">[in] An <see cref="IDiaStackWalkFrame"/> object that holds the state of frame registers.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns an error code. The following table shows the possible return values for this method.</returns>
        /// <remarks>
        /// This method is called during debugging to unwind the stack. The <see cref="IDiaStackWalkFrame"/> object is implemented
        /// by the client application to receive updates to the registers and to provide methods used by the execute method.
        /// </remarks>
        public HRESULT TryExecute(IDiaStackWalkFrame frame)
        {
            /*HRESULT execute(
            [In, MarshalAs(UnmanagedType.Interface)] IDiaStackWalkFrame frame);*/
            return Raw.execute(frame);
        }

        #endregion
        #endregion
    }
}
