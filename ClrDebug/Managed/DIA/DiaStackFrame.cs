namespace ClrDebug.DIA
{
    /// <summary>
    /// Exposes the properties of a stack frame.
    /// </summary>
    /// <remarks>
    /// A stack frame is an abstraction of a function call during its execution. Obtain this interface by calling the <see
    /// cref="DiaEnumStackFrames.MoveNext"/> method. See the <see cref="IDiaEnumStackFrames"/> interface for an example on
    /// obtaining the IDiaStackFrame interface.
    /// </remarks>
    public class DiaStackFrame : ComObject<IDiaStackFrame>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DiaStackFrame"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
        public DiaStackFrame(IDiaStackFrame raw) : base(raw)
        {
        }

        #region IDiaStackFrame
        #region Type

        /// <summary>
        /// Retrieves the frame type.
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
        /// Retrieves the frame type.
        /// </summary>
        /// <param name="pRetVal">[out] Returns a value from the <see cref="StackFrameTypeEnum"/> enumeration.</param>
        /// <returns>If successful, returns S_OK. Returns S_FALSE if the property is not supported. Otherwise, returns an error code.</returns>
        public HRESULT TryGetType(out StackFrameTypeEnum pRetVal)
        {
            /*HRESULT get_type(
            [Out] out StackFrameTypeEnum pRetVal);*/
            return Raw.get_type(out pRetVal);
        }

        #endregion
        #region Base

        /// <summary>
        /// Retrieves the base address of the frame.
        /// </summary>
        public long Base
        {
            get
            {
                long pRetVal;
                TryGetBase(out pRetVal).ThrowOnNotOK();

                return pRetVal;
            }
        }

        /// <summary>
        /// Retrieves the base address of the frame.
        /// </summary>
        /// <param name="pRetVal">[out] Returns the base address.</param>
        /// <returns>If successful, returns S_OK. Returns S_FALSE if the property is not supported. Otherwise, returns an error code.</returns>
        public HRESULT TryGetBase(out long pRetVal)
        {
            /*HRESULT get_base(
            [Out] out long pRetVal);*/
            return Raw.get_base(out pRetVal);
        }

        #endregion
        #region Size

        /// <summary>
        /// Retrieves the size of the stack frame in bytes.
        /// </summary>
        public int Size
        {
            get
            {
                int pRetVal;
                TryGetSize(out pRetVal).ThrowOnNotOK();

                return pRetVal;
            }
        }

        /// <summary>
        /// Retrieves the size of the stack frame in bytes.
        /// </summary>
        /// <param name="pRetVal">[out] Returns the size of the stack frame in bytes.</param>
        /// <returns>If successful, returns S_OK. Returns S_FALSE if the property is not supported. Otherwise, returns an error code.</returns>
        public HRESULT TryGetSize(out int pRetVal)
        {
            /*HRESULT get_size(
            [Out] out int pRetVal);*/
            return Raw.get_size(out pRetVal);
        }

        #endregion
        #region ReturnAddress

        /// <summary>
        /// Retrieves the return address of the frame.
        /// </summary>
        public long ReturnAddress
        {
            get
            {
                long pRetVal;
                TryGetReturnAddress(out pRetVal).ThrowOnNotOK();

                return pRetVal;
            }
        }

        /// <summary>
        /// Retrieves the return address of the frame.
        /// </summary>
        /// <param name="pRetVal">[out] Returns the return address of the frame.</param>
        /// <returns>If successful, returns S_OK. Returns S_FALSE if the property is not supported. Otherwise, returns an error code.</returns>
        public HRESULT TryGetReturnAddress(out long pRetVal)
        {
            /*HRESULT get_returnAddress(
            [Out] out long pRetVal);*/
            return Raw.get_returnAddress(out pRetVal);
        }

        #endregion
        #region LocalsBase

        /// <summary>
        /// Retrieves the base address of the local variables for the frame.
        /// </summary>
        public long LocalsBase
        {
            get
            {
                long pRetVal;
                TryGetLocalsBase(out pRetVal).ThrowOnNotOK();

                return pRetVal;
            }
        }

        /// <summary>
        /// Retrieves the base address of the local variables for the frame.
        /// </summary>
        /// <param name="pRetVal">[out] Returns the base address of the local variables.</param>
        /// <returns>If successful, returns S_OK. Returns S_FALSE if the property is not supported. Otherwise, returns an error code.</returns>
        public HRESULT TryGetLocalsBase(out long pRetVal)
        {
            /*HRESULT get_localsBase(
            [Out] out long pRetVal);*/
            return Raw.get_localsBase(out pRetVal);
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
        /// <returns>If successful, returns S_OK. Returns S_FALSE if the property is not supported. Otherwise, returns an error code.</returns>
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
        /// <returns>If successful, returns S_OK. Returns S_FALSE if the property is not supported. Otherwise, returns an error code.</returns>
        public HRESULT TryGetLengthParams(out int pRetVal)
        {
            /*HRESULT get_lengthParams(
            [Out] out int pRetVal);*/
            return Raw.get_lengthParams(out pRetVal);
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
        /// <returns>If successful, returns S_OK. Returns S_FALSE if the property is not supported. Otherwise, returns an error code.</returns>
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
        /// <returns>If successful, returns S_OK. Returns S_FALSE if the property is not supported. Otherwise, returns an error code.</returns>
        public HRESULT TryGetLengthSavedRegisters(out int pRetVal)
        {
            /*HRESULT get_lengthSavedRegisters(
            [Out] out int pRetVal);*/
            return Raw.get_lengthSavedRegisters(out pRetVal);
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
        /// <param name="pRetVal">[out] Returns TRUE if system exception handling is in effect for this frame; otherwise, returns FALSE.</param>
        /// <returns>If successful, returns S_OK. Returns S_FALSE if the property is not supported. Otherwise, returns an error code.</returns>
        /// <remarks>
        /// System exception handling is also known as structured exception handling. This is not the same thing as C++ exception
        /// handling. To determine if C++ exception handling is in effect, call the <see cref="CplusplusExceptionHandling"/>
        /// property.
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
        /// Retrieves a flag that indicates if C++ exception handling is in effect.
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
        /// Retrieves a flag that indicates if C++ exception handling is in effect.
        /// </summary>
        /// <param name="pRetVal">[out] Returns TRUE if C++ exception handling is in effect for this frame; otherwise, returns FALSE.</param>
        /// <returns>If successful, returns S_OK. Returns S_FALSE if the property is not supported. Otherwise, returns an error code.</returns>
        /// <remarks>
        /// C++ exception handling is not the same as structured or system exception handling. To determine if structured exception
        /// handling is in effect, call the <see cref="SystemExceptionHandling"/> property.
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
        /// <param name="pRetVal">[out] Returns TRUE if the stack frame contains the entry point of a function; otherwise, returns FALSE.</param>
        /// <returns>If successful, returns S_OK. Returns S_FALSE if the property is not supported. Otherwise, returns an error code.</returns>
        public HRESULT TryGetFunctionStart(out bool pRetVal)
        {
            /*HRESULT get_functionStart(
            [Out, MarshalAs(UnmanagedType.Bool)] out bool pRetVal);*/
            return Raw.get_functionStart(out pRetVal);
        }

        #endregion
        #region AllocatesBasePointer

        /// <summary>
        /// Retrieves a flag that indicates whether the base pointer is allocated for code in this address range.
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
        /// Retrieves a flag that indicates whether the base pointer is allocated for code in this address range.
        /// </summary>
        /// <param name="pRetVal">[out] Returns TRUE if a base pointer is allocated for code in this frame; otherwise, returns FALSE.</param>
        /// <returns>If successful, returns S_OK. Returns S_FALSE if the property is not supported. Otherwise, returns an error code.</returns>
        public HRESULT TryGetAllocatesBasePointer(out bool pRetVal)
        {
            /*HRESULT get_allocatesBasePointer(
            [Out, MarshalAs(UnmanagedType.Bool)] out bool pRetVal);*/
            return Raw.get_allocatesBasePointer(out pRetVal);
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
        /// <returns>If successful, returns S_OK. Returns S_FALSE if the property is not supported. Otherwise, returns an error code.</returns>
        public HRESULT TryGetMaxStack(out int pRetVal)
        {
            /*HRESULT get_maxStack(
            [Out] out int pRetVal);*/
            return Raw.get_maxStack(out pRetVal);
        }

        #endregion
        #region GetRegisterValue

        /// <summary>
        /// Retrieves the value of a specified register as stored in the stack frame.
        /// </summary>
        /// <param name="index">[in] One of the <see cref="CV_HREG_e"/> enumeration values.</param>
        /// <returns>[out] Value stored in the register.</returns>
        public long GetRegisterValue(CV_HREG_e index)
        {
            long pRetVal;
            TryGetRegisterValue(index, out pRetVal).ThrowOnNotOK();

            return pRetVal;
        }

        /// <summary>
        /// Retrieves the value of a specified register as stored in the stack frame.
        /// </summary>
        /// <param name="index">[in] One of the <see cref="CV_HREG_e"/> enumeration values.</param>
        /// <param name="pRetVal">[out] Value stored in the register.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns error code.</returns>
        public HRESULT TryGetRegisterValue(CV_HREG_e index, out long pRetVal)
        {
            /*HRESULT get_registerValue(
            [In] CV_HREG_e index,
            [Out] out long pRetVal);*/
            return Raw.get_registerValue(index, out pRetVal);
        }

        #endregion
        #endregion
    }
}
