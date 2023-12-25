namespace ClrDebug.DIA
{
    /// <summary>
    /// Maintains stack context between invocations of the IDiaFrameData method.
    /// </summary>
    /// <remarks>
    /// This interface is used during program execution to read and write registers as well as access memory and find return
    /// addresses. The client application implements this interface and passes an instance of the interface to the IDiaFrameData
    /// method. The same instance of this interface is used again and again to maintain the state of the registers during
    /// each invocation of the execute method. The execute method also uses this interface to determine the return address.
    /// </remarks>
    public class DiaStackWalkFrame : ComObject<IDiaStackWalkFrame>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DiaStackWalkFrame"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
        public DiaStackWalkFrame(IDiaStackWalkFrame raw) : base(raw)
        {
        }

        #region IDiaStackWalkFrame
        #region GetRegisterValue

        /// <summary>
        /// Retrieves the value of a register.
        /// </summary>
        /// <param name="index">[in] A value from the CV_HREG_e Enumeration enumeration specifying the register to get the value for.</param>
        /// <returns>[out] Returns the current value of the register.</returns>
        public long GetRegisterValue(int index)
        {
            long pRetVal;
            TryGetRegisterValue(index, out pRetVal).ThrowOnNotOK();

            return pRetVal;
        }

        /// <summary>
        /// Retrieves the value of a register.
        /// </summary>
        /// <param name="index">[in] A value from the CV_HREG_e Enumeration enumeration specifying the register to get the value for.</param>
        /// <param name="pRetVal">[out] Returns the current value of the register.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns an error code.</returns>
        public HRESULT TryGetRegisterValue(int index, out long pRetVal)
        {
            /*HRESULT get_registerValue(
            [In] int index,
            [Out] out long pRetVal);*/
            return Raw.get_registerValue(index, out pRetVal);
        }

        #endregion
        #region PutRegisterValue

        /// <summary>
        /// Sets the value of a register.
        /// </summary>
        /// <param name="index">[in] A value from the CV_HREG_e Enumeration enumeration specifying the register to write to.</param>
        /// <param name="pRetVal">[in] The new register value.</param>
        public void PutRegisterValue(int index, long pRetVal)
        {
            TryPutRegisterValue(index, pRetVal).ThrowOnNotOK();
        }

        /// <summary>
        /// Sets the value of a register.
        /// </summary>
        /// <param name="index">[in] A value from the CV_HREG_e Enumeration enumeration specifying the register to write to.</param>
        /// <param name="pRetVal">[in] The new register value.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns an error code.</returns>
        public HRESULT TryPutRegisterValue(int index, long pRetVal)
        {
            /*HRESULT put_registerValue(
            [In] int index,
            [In] long pRetVal);*/
            return Raw.put_registerValue(index, pRetVal);
        }

        #endregion
        #region ReadMemory

        /// <summary>
        /// Reads memory from image.
        /// </summary>
        /// <param name="type">[in] One of the MemoryTypeEnum Enumeration enumeration values that specifies the kind of memory to access.</param>
        /// <param name="va">[in] Virtual address location in image to begin reading.</param>
        /// <returns>[out] A buffer that is to be filled in with data from the specified location.</returns>
        public byte[] ReadMemory(MemoryTypeEnum type, long va)
        {
            byte[] pbData;
            TryReadMemory(type, va, out pbData).ThrowOnNotOK();

            return pbData;
        }

        /// <summary>
        /// Reads memory from image.
        /// </summary>
        /// <param name="type">[in] One of the MemoryTypeEnum Enumeration enumeration values that specifies the kind of memory to access.</param>
        /// <param name="va">[in] Virtual address location in image to begin reading.</param>
        /// <param name="pbData">[out] A buffer that is to be filled in with data from the specified location.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns an error code.</returns>
        public HRESULT TryReadMemory(MemoryTypeEnum type, long va, out byte[] pbData)
        {
            /*HRESULT readMemory(
            [In] MemoryTypeEnum type,
            [In] long va,
            [In] int cbData,
            [Out] out int pcbData,
            [SRI.Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U1, SizeParamIndex = 2)] byte[] pbData);*/
            int cbData = 0;
            int pcbData;
            pbData = null;
            HRESULT hr = Raw.readMemory(type, va, cbData, out pcbData, null);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER && hr != HRESULT.S_OK)
                goto fail;

            cbData = pcbData;
            pbData = new byte[cbData];
            hr = Raw.readMemory(type, va, cbData, out pcbData, pbData);
            fail:
            return hr;
        }

        #endregion
        #region SearchForReturnAddress

        /// <summary>
        /// Searches the specified stack frame for the nearest function return address.
        /// </summary>
        /// <param name="frame">[in] An IDiaFrameData object that represents the current stack frame.</param>
        /// <returns>[out] Returns the nearest function return address.</returns>
        public long SearchForReturnAddress(IDiaFrameData frame)
        {
            long returnAddress;
            TrySearchForReturnAddress(frame, out returnAddress).ThrowOnNotOK();

            return returnAddress;
        }

        /// <summary>
        /// Searches the specified stack frame for the nearest function return address.
        /// </summary>
        /// <param name="frame">[in] An IDiaFrameData object that represents the current stack frame.</param>
        /// <param name="returnAddress">[out] Returns the nearest function return address.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns an error code.</returns>
        public HRESULT TrySearchForReturnAddress(IDiaFrameData frame, out long returnAddress)
        {
            /*HRESULT searchForReturnAddress(
            [MarshalAs(UnmanagedType.Interface), In] IDiaFrameData frame,
            [Out] out long returnAddress);*/
            return Raw.searchForReturnAddress(frame, out returnAddress);
        }

        #endregion
        #region SearchForReturnAddressStart

        /// <summary>
        /// Searches the specified stack frame for a return address at or near the specified address.
        /// </summary>
        /// <param name="frame">[in] An IDiaFrameData object that represents the current stack frame.</param>
        /// <param name="startAddress">[in] A virtual memory address from which to begin searching.</param>
        /// <returns>[out] Returns the nearest function return address to startAddress.</returns>
        public long SearchForReturnAddressStart(IDiaFrameData frame, long startAddress)
        {
            long returnAddress;
            TrySearchForReturnAddressStart(frame, startAddress, out returnAddress).ThrowOnNotOK();

            return returnAddress;
        }

        /// <summary>
        /// Searches the specified stack frame for a return address at or near the specified address.
        /// </summary>
        /// <param name="frame">[in] An IDiaFrameData object that represents the current stack frame.</param>
        /// <param name="startAddress">[in] A virtual memory address from which to begin searching.</param>
        /// <param name="returnAddress">[out] Returns the nearest function return address to startAddress.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns an error code.</returns>
        public HRESULT TrySearchForReturnAddressStart(IDiaFrameData frame, long startAddress, out long returnAddress)
        {
            /*HRESULT searchForReturnAddressStart(
            [MarshalAs(UnmanagedType.Interface), In] IDiaFrameData frame,
            [In] long startAddress,
            [Out] out long returnAddress);*/
            return Raw.searchForReturnAddressStart(frame, startAddress, out returnAddress);
        }

        #endregion
        #endregion
    }
}
