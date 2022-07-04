namespace ClrDebug
{
    /// <summary>
    /// Represents a local variable or argument of a function.
    /// </summary>
    public class CorDebugVariableHome : ComObject<ICorDebugVariableHome>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CorDebugVariableHome"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
        public CorDebugVariableHome(ICorDebugVariableHome raw) : base(raw)
        {
        }

        #region ICorDebugVariableHome
        #region Code

        /// <summary>
        /// Gets the "ICorDebugCode" instance that contains this <see cref="ICorDebugVariableHome"/> object.
        /// </summary>
        public CorDebugCode Code
        {
            get
            {
                CorDebugCode ppCodeResult;
                TryGetCode(out ppCodeResult).ThrowOnNotOK();

                return ppCodeResult;
            }
        }

        /// <summary>
        /// Gets the "ICorDebugCode" instance that contains this <see cref="ICorDebugVariableHome"/> object.
        /// </summary>
        /// <param name="ppCodeResult">[out] A pointer to the address of the "ICorDebugCode" instance that contains this <see cref="ICorDebugVariableHome"/> object.</param>
        public HRESULT TryGetCode(out CorDebugCode ppCodeResult)
        {
            /*HRESULT GetCode([Out, MarshalAs(UnmanagedType.Interface)] out ICorDebugCode ppCode);*/
            ICorDebugCode ppCode;
            HRESULT hr = Raw.GetCode(out ppCode);

            if (hr == HRESULT.S_OK)
                ppCodeResult = new CorDebugCode(ppCode);
            else
                ppCodeResult = default(CorDebugCode);

            return hr;
        }

        #endregion
        #region SlotIndex

        /// <summary>
        /// Gets the managed slot-index of a local variable.
        /// </summary>
        public int SlotIndex
        {
            get
            {
                int pSlotIndex;
                TryGetSlotIndex(out pSlotIndex).ThrowOnNotOK();

                return pSlotIndex;
            }
        }

        /// <summary>
        /// Gets the managed slot-index of a local variable.
        /// </summary>
        /// <param name="pSlotIndex">[out] A pointer to the slot-index of a local variable.</param>
        /// <returns>
        /// The method returns the following values.
        /// 
        /// | Value  | Description                                                                              |
        /// | ------ | ---------------------------------------------------------------------------------------- |
        /// | S_OK   | The method call returned a slot-index value in pSlotIndex.                               |
        /// | E_FAIL | The current <see cref="ICorDebugVariableHome"/> instance represents a function argument. |
        /// </returns>
        /// <remarks>
        /// The slot-index can be used to retrieve the metadata for this local variable.
        /// </remarks>
        public HRESULT TryGetSlotIndex(out int pSlotIndex)
        {
            /*HRESULT GetSlotIndex([Out] out int pSlotIndex);*/
            return Raw.GetSlotIndex(out pSlotIndex);
        }

        #endregion
        #region ArgumentIndex

        /// <summary>
        /// Gets the index of a function argument.
        /// </summary>
        public int ArgumentIndex
        {
            get
            {
                int pArgumentIndex;
                TryGetArgumentIndex(out pArgumentIndex).ThrowOnNotOK();

                return pArgumentIndex;
            }
        }

        /// <summary>
        /// Gets the index of a function argument.
        /// </summary>
        /// <param name="pArgumentIndex">[out] A pointer to the argument index.</param>
        /// <returns>
        /// The method returns the following values.
        /// 
        /// | Value  | Description                                                                           |
        /// | ------ | ------------------------------------------------------------------------------------- |
        /// | S_OK   | The method call returned a valid argument index.                                      |
        /// | E_FAIL | The current <see cref="ICorDebugVariableHome"/> instance represents a local variable. |
        /// </returns>
        /// <remarks>
        /// The argument index can be used to retrieve metadata for this argument.
        /// </remarks>
        public HRESULT TryGetArgumentIndex(out int pArgumentIndex)
        {
            /*HRESULT GetArgumentIndex([Out] out int pArgumentIndex);*/
            return Raw.GetArgumentIndex(out pArgumentIndex);
        }

        #endregion
        #region LiveRange

        /// <summary>
        /// Gets the native range over which this variable is live.
        /// </summary>
        public GetLiveRangeResult LiveRange
        {
            get
            {
                GetLiveRangeResult result;
                TryGetLiveRange(out result).ThrowOnNotOK();

                return result;
            }
        }

        /// <summary>
        /// Gets the native range over which this variable is live.
        /// </summary>
        /// <param name="result">The values that were emitted from the COM method.</param>
        public HRESULT TryGetLiveRange(out GetLiveRangeResult result)
        {
            /*HRESULT GetLiveRange([Out] out int pStartOffset, [Out] out int pEndOffset);*/
            int pStartOffset;
            int pEndOffset;
            HRESULT hr = Raw.GetLiveRange(out pStartOffset, out pEndOffset);

            if (hr == HRESULT.S_OK)
                result = new GetLiveRangeResult(pStartOffset, pEndOffset);
            else
                result = default(GetLiveRangeResult);

            return hr;
        }

        #endregion
        #region LocationType

        /// <summary>
        /// Gets the type of the variable's native location.
        /// </summary>
        public VariableLocationType LocationType
        {
            get
            {
                VariableLocationType pLocationType;
                TryGetLocationType(out pLocationType).ThrowOnNotOK();

                return pLocationType;
            }
        }

        /// <summary>
        /// Gets the type of the variable's native location.
        /// </summary>
        /// <param name="pLocationType">[out] A pointer to the type of the variable's native location. See the <see cref="VariableLocationType"/> enumeration for more information.</param>
        public HRESULT TryGetLocationType(out VariableLocationType pLocationType)
        {
            /*HRESULT GetLocationType([Out] out VariableLocationType pLocationType);*/
            return Raw.GetLocationType(out pLocationType);
        }

        #endregion
        #region Register

        /// <summary>
        /// Gets the register that contains a variable with a location type of VLT_REGISTER, and the base register for a variable with a location type of VLT_REGISTER_RELATIVE.
        /// </summary>
        public CorDebugRegister Register
        {
            get
            {
                CorDebugRegister pRegister;
                TryGetRegister(out pRegister).ThrowOnNotOK();

                return pRegister;
            }
        }

        /// <summary>
        /// Gets the register that contains a variable with a location type of VLT_REGISTER, and the base register for a variable with a location type of VLT_REGISTER_RELATIVE.
        /// </summary>
        /// <param name="pRegister">[out] A <see cref="CorDebugRegister"/> enumeration value that indicates the register for a variable with a location type of VLT_REGISTER, and the base register for a variable with a location type of VLT_REGISTER_RELATIVE.</param>
        /// <returns>
        /// The method returns the following values:
        /// 
        /// | Value  | Description                                                          |
        /// | ------ | -------------------------------------------------------------------- |
        /// | S_OK   | The variable is in the register indicated by the pRegister argument. |
        /// | E_FAIL | The variable is not in a register or a register-relative location.   |
        /// </returns>
        public HRESULT TryGetRegister(out CorDebugRegister pRegister)
        {
            /*HRESULT GetRegister([Out] out CorDebugRegister pRegister);*/
            return Raw.GetRegister(out pRegister);
        }

        #endregion
        #region Offset

        /// <summary>
        /// Gets the offset from the base register for a variable.
        /// </summary>
        public int Offset
        {
            get
            {
                int pOffset;
                TryGetOffset(out pOffset).ThrowOnNotOK();

                return pOffset;
            }
        }

        /// <summary>
        /// Gets the offset from the base register for a variable.
        /// </summary>
        /// <param name="pOffset">[out] The offset from the base register.</param>
        /// <returns>
        /// The method returns the following values:
        /// 
        /// | Value  | Description                                                 |
        /// | ------ | ----------------------------------------------------------- |
        /// | S_OK   | The variable is in a register-relative memory location.     |
        /// | E_FAIL | The variable is not in a register-relative memory location. |
        /// </returns>
        public HRESULT TryGetOffset(out int pOffset)
        {
            /*HRESULT GetOffset([Out] out int pOffset);*/
            return Raw.GetOffset(out pOffset);
        }

        #endregion
        #endregion
    }
}
