using System.Diagnostics;
using static ClrDebug.Extensions;

namespace ClrDebug.DbgEng
{
    public class DebugRegisters : ComObject<IDebugRegisters>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DebugRegisters"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
        public DebugRegisters(IDebugRegisters raw) : base(raw)
        {
        }

        #region IDebugRegisters
        #region NumberRegisters

        /// <summary>
        /// The GetNumberRegisters method returns the number of registers on the target computer.
        /// </summary>
        public int NumberRegisters
        {
            get
            {
                int number;
                TryGetNumberRegisters(out number).ThrowDbgEngNotOK();

                return number;
            }
        }

        /// <summary>
        /// The GetNumberRegisters method returns the number of registers on the target computer.
        /// </summary>
        /// <param name="number">[out] Receives the number of registers on the target's computer.</param>
        /// <returns>This list does not contain all the errors that might occur. For a list of possible errors, see HRESULT Values.</returns>
        /// <remarks>
        /// For an overview of the <see cref="IDebugRegisters"/> interface and other register-related methods, see Registers.
        /// </remarks>
        public HRESULT TryGetNumberRegisters(out int number)
        {
            /*HRESULT GetNumberRegisters(
            [Out] out int Number);*/
            return Raw.GetNumberRegisters(out number);
        }

        #endregion
        #region InstructionOffset

        /// <summary>
        /// The GetInstructionOffset method returns the location of the current thread's current instruction.
        /// </summary>
        public long InstructionOffset
        {
            get
            {
                long offset;
                TryGetInstructionOffset(out offset).ThrowDbgEngNotOK();

                return offset;
            }
        }

        /// <summary>
        /// The GetInstructionOffset method returns the location of the current thread's current instruction.
        /// </summary>
        /// <param name="offset">[out] Receives the location in the target's virtual address space of the target's current instruction.</param>
        /// <returns>This list does not contain all the errors that might occur. For a list of possible errors, see HRESULT Values.</returns>
        /// <remarks>
        /// The meaning of the value returned by this method is architecture-dependent. In particular, for an Itanium processor,
        /// the virtual address returned can indicate an address within a bundle. The method <see cref="GetInstructionOffset2"/>
        /// performs the same task as this method but also allows the register source to be specified. For an overview of the
        /// <see cref="IDebugRegisters"/> interface and other register-related methods, see Registers.
        /// </remarks>
        public HRESULT TryGetInstructionOffset(out long offset)
        {
            /*HRESULT GetInstructionOffset(
            [Out] out long Offset);*/
            return Raw.GetInstructionOffset(out offset);
        }

        #endregion
        #region StackOffset

        /// <summary>
        /// The GetStackOffset method returns the current thread's current stack location.
        /// </summary>
        public long StackOffset
        {
            get
            {
                long offset;
                TryGetStackOffset(out offset).ThrowDbgEngNotOK();

                return offset;
            }
        }

        /// <summary>
        /// The GetStackOffset method returns the current thread's current stack location.
        /// </summary>
        /// <param name="offset">[out] Receives the location in the process's virtual address space of the current thread's current stack location.</param>
        /// <returns>This list does not contain all the errors that might occur. For a list of possible errors, see HRESULT Values.</returns>
        /// <remarks>
        /// The meaning of value returned by this method is architecture specific. The method <see cref="GetStackOffset2"/>
        /// performs the same task as this method but also allows the register source to be specified. For an overview of the
        /// <see cref="IDebugRegisters"/> interface and other register-related methods, see Registers.
        /// </remarks>
        public HRESULT TryGetStackOffset(out long offset)
        {
            /*HRESULT GetStackOffset(
            [Out] out long Offset);*/
            return Raw.GetStackOffset(out offset);
        }

        #endregion
        #region FrameOffset

        /// <summary>
        /// The GetFrameOffset method returns the location of the stack frame for the current function.
        /// </summary>
        public long FrameOffset
        {
            get
            {
                long offset;
                TryGetFrameOffset(out offset).ThrowDbgEngNotOK();

                return offset;
            }
        }

        /// <summary>
        /// The GetFrameOffset method returns the location of the stack frame for the current function.
        /// </summary>
        /// <param name="offset">[out] The location in the target's virtual address space of the stack frame for the current function.</param>
        /// <returns>This list does not contain all the errors that might occur. For a list of possible errors, see HRESULT Values.</returns>
        /// <remarks>
        /// The meaning of value returned by this method is architecture-specific. The method <see cref="GetFrameOffset2"/>
        /// performs the same task as this method but also allows the register source to be specified. For an overview of the
        /// <see cref="IDebugRegisters"/> interface and other register-related methods, see Registers.
        /// </remarks>
        public HRESULT TryGetFrameOffset(out long offset)
        {
            /*HRESULT GetFrameOffset(
            [Out] out long Offset);*/
            return Raw.GetFrameOffset(out offset);
        }

        #endregion
        #region GetDescription

        /// <summary>
        /// The GetDescription method returns the description of a register.
        /// </summary>
        /// <param name="register">[in] Specifies the index of the register for which the description is requested.</param>
        /// <returns>The values that were emitted from the COM method.</returns>
        /// <remarks>
        /// For an overview of the <see cref="IDebugRegisters"/> interface and other register-related methods, see Registers.
        /// </remarks>
        public GetDescriptionResult GetDescription(int register)
        {
            GetDescriptionResult result;
            TryGetDescription(register, out result).ThrowDbgEngNotOK();

            return result;
        }

        /// <summary>
        /// The GetDescription method returns the description of a register.
        /// </summary>
        /// <param name="register">[in] Specifies the index of the register for which the description is requested.</param>
        /// <param name="result">The values that were emitted from the COM method.</param>
        /// <returns>This list does not contain all the errors that might occur. For a list of possible errors, see HRESULT Values.</returns>
        /// <remarks>
        /// For an overview of the <see cref="IDebugRegisters"/> interface and other register-related methods, see Registers.
        /// </remarks>
        public HRESULT TryGetDescription(int register, out GetDescriptionResult result)
        {
            /*HRESULT GetDescription(
            [In] int Register,
            [SRI.Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U1, SizeParamIndex = 2)] byte[] NameBuffer,
            [In] int NameBufferSize,
            [Out] out int NameSize,
            [Out] out DEBUG_REGISTER_DESCRIPTION Desc);*/
            byte[] nameBuffer;
            int nameBufferSize = 0;
            int nameSize;
            DEBUG_REGISTER_DESCRIPTION desc;
            HRESULT hr = Raw.GetDescription(register, null, nameBufferSize, out nameSize, out desc);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER && hr != HRESULT.S_OK)
                goto fail;

            nameBufferSize = nameSize;
            nameBuffer = new byte[nameBufferSize];
            hr = Raw.GetDescription(register, nameBuffer, nameBufferSize, out nameSize, out desc);

            if (hr == HRESULT.S_OK)
            {
                result = new GetDescriptionResult(CreateString(nameBuffer, nameSize), desc);

                return hr;
            }

            fail:
            result = default(GetDescriptionResult);

            return hr;
        }

        #endregion
        #region GetIndexByName

        /// <summary>
        /// The GetIndexByName method returns the index of the named register.
        /// </summary>
        /// <param name="name">[in] Specifies the name of the register whose index is requested.</param>
        /// <returns>[out] Receives the index of the register.</returns>
        /// <remarks>
        /// For an overview of the <see cref="IDebugRegisters"/> interface and other register-related methods, see Registers.
        /// </remarks>
        public int GetIndexByName(string name)
        {
            int index;
            TryGetIndexByName(name, out index).ThrowDbgEngNotOK();

            return index;
        }

        /// <summary>
        /// The GetIndexByName method returns the index of the named register.
        /// </summary>
        /// <param name="name">[in] Specifies the name of the register whose index is requested.</param>
        /// <param name="index">[out] Receives the index of the register.</param>
        /// <returns>This list does not contain all the errors that might occur. For a list of possible errors, see HRESULT Values.</returns>
        /// <remarks>
        /// For an overview of the <see cref="IDebugRegisters"/> interface and other register-related methods, see Registers.
        /// </remarks>
        public HRESULT TryGetIndexByName(string name, out int index)
        {
            /*HRESULT GetIndexByName(
            [In, MarshalAs(UnmanagedType.LPStr)] string Name,
            [Out] out int Index);*/
            return Raw.GetIndexByName(name, out index);
        }

        #endregion
        #region GetValue

        /// <summary>
        /// The GetValue method gets the value of one of the target's registers.
        /// </summary>
        /// <param name="register">[in] Specifies the index of the register whose value is requested.</param>
        /// <returns>[out] Receives the value of the register. See <see cref="DEBUG_VALUE"/> for a description of this parameter type.</returns>
        /// <remarks>
        /// To receive the values of multiple registers, use the <see cref="GetValues"/> method instead. For an overview of
        /// the <see cref="IDebugRegisters"/> interface and other register-related methods, see Registers.
        /// </remarks>
        public DEBUG_VALUE GetValue(int register)
        {
            DEBUG_VALUE value;
            TryGetValue(register, out value).ThrowDbgEngNotOK();

            return value;
        }

        /// <summary>
        /// The GetValue method gets the value of one of the target's registers.
        /// </summary>
        /// <param name="register">[in] Specifies the index of the register whose value is requested.</param>
        /// <param name="value">[out] Receives the value of the register. See <see cref="DEBUG_VALUE"/> for a description of this parameter type.</param>
        /// <returns>This list does not contain all the errors that might occur. For a list of possible errors, see HRESULT Values.</returns>
        /// <remarks>
        /// To receive the values of multiple registers, use the <see cref="GetValues"/> method instead. For an overview of
        /// the <see cref="IDebugRegisters"/> interface and other register-related methods, see Registers.
        /// </remarks>
        public HRESULT TryGetValue(int register, out DEBUG_VALUE value)
        {
            /*HRESULT GetValue(
            [In] int Register,
            [Out] out DEBUG_VALUE Value);*/
            return Raw.GetValue(register, out value);
        }

        #endregion
        #region SetValue

        /// <summary>
        /// The SetValue method sets the value of one of the target's registers.
        /// </summary>
        /// <param name="register">[in] Specifies the index of the register whose value is to be set.</param>
        /// <param name="value">[in] Specifies the value to which to set the register. See <see cref="DEBUG_VALUE"/> for a description of this parameter type.</param>
        /// <remarks>
        /// The engine does its best to coerce the value of Value into the type of the register; this coercion is the same
        /// as that performed by <see cref="DebugControl.CoerceValue"/>. If the value is larger than what the register can
        /// hold, the least significant bits are dropped. Floating-point and integer conversions will also be performed if
        /// necessary. When a subregister is altered, the register containing it is also altered. To set the values of multiple
        /// registers, use the <see cref="SetValues"/> method instead. For an overview of the <see cref="IDebugRegisters"/>
        /// interface and other register-related methods, see Registers.
        /// </remarks>
        public void SetValue(int register, DEBUG_VALUE value)
        {
            TrySetValue(register, value).ThrowDbgEngNotOK();
        }

        /// <summary>
        /// The SetValue method sets the value of one of the target's registers.
        /// </summary>
        /// <param name="register">[in] Specifies the index of the register whose value is to be set.</param>
        /// <param name="value">[in] Specifies the value to which to set the register. See <see cref="DEBUG_VALUE"/> for a description of this parameter type.</param>
        /// <returns>This list does not contain all the errors that might occur. For a list of possible errors, see HRESULT Values.</returns>
        /// <remarks>
        /// The engine does its best to coerce the value of Value into the type of the register; this coercion is the same
        /// as that performed by <see cref="DebugControl.CoerceValue"/>. If the value is larger than what the register can
        /// hold, the least significant bits are dropped. Floating-point and integer conversions will also be performed if
        /// necessary. When a subregister is altered, the register containing it is also altered. To set the values of multiple
        /// registers, use the <see cref="SetValues"/> method instead. For an overview of the <see cref="IDebugRegisters"/>
        /// interface and other register-related methods, see Registers.
        /// </remarks>
        public HRESULT TrySetValue(int register, DEBUG_VALUE value)
        {
            /*HRESULT SetValue(
            [In] int Register,
            [In] ref DEBUG_VALUE Value);*/
            return Raw.SetValue(register, ref value);
        }

        #endregion
        #region GetValues

        /// <summary>
        /// The GetValues method gets the value of several of the target's registers.
        /// </summary>
        /// <param name="count">[in] Specifies the number of registers whose values are requested.</param>
        /// <param name="indices">[in, optional] Specifies an array that contains the indices of the registers from which to get the values. The number of elements in this array is Count.<para/>
        /// If Indices is NULL, Start is used instead.</param>
        /// <param name="start">[in] If Indices is NULL, the registers will be read consecutively starting at this index. Otherwise it is ignored.</param>
        /// <returns>[out] Receives the values of the registers. The number of elements this array holds is Count. See <see cref="DEBUG_VALUE"/> for a description of this parameter type.</returns>
        /// <remarks>
        /// GetValues gets the value of several of the target's registers. If the return value is not S_OK, some of the registers
        /// still might have been read. If the target was not accessible, the return type is E_UNEXPECTED and Values is unchanged;
        /// otherwise, Values will contain partial results and the registers that could not be read will have type DEBUG_VALUE_INVALID.
        /// Ambiguity in the case of the return value E_UNEXPECTED can be avoided by setting the memory of Values to zero before
        /// calling this method. To receive the value of only a single register, use the GetValue method instead. The method
        /// <see cref="GetValues2"/> performs the same task as this method but also allows the register source
        /// to be specified. For an overview of the <see cref="IDebugRegisters"/> interface and other register-related methods,
        /// see Registers.
        /// </remarks>
        public DEBUG_VALUE[] GetValues(int count, int[] indices, int start)
        {
            DEBUG_VALUE[] values;
            TryGetValues(count, indices, start, out values).ThrowDbgEngNotOK();

            return values;
        }

        /// <summary>
        /// The GetValues method gets the value of several of the target's registers.
        /// </summary>
        /// <param name="count">[in] Specifies the number of registers whose values are requested.</param>
        /// <param name="indices">[in, optional] Specifies an array that contains the indices of the registers from which to get the values. The number of elements in this array is Count.<para/>
        /// If Indices is NULL, Start is used instead.</param>
        /// <param name="start">[in] If Indices is NULL, the registers will be read consecutively starting at this index. Otherwise it is ignored.</param>
        /// <param name="values">[out] Receives the values of the registers. The number of elements this array holds is Count. See <see cref="DEBUG_VALUE"/> for a description of this parameter type.</param>
        /// <returns>This list does not contain all the errors that might occur. For a list of possible errors, see HRESULT Values.</returns>
        /// <remarks>
        /// GetValues gets the value of several of the target's registers. If the return value is not S_OK, some of the registers
        /// still might have been read. If the target was not accessible, the return type is E_UNEXPECTED and Values is unchanged;
        /// otherwise, Values will contain partial results and the registers that could not be read will have type DEBUG_VALUE_INVALID.
        /// Ambiguity in the case of the return value E_UNEXPECTED can be avoided by setting the memory of Values to zero before
        /// calling this method. To receive the value of only a single register, use the GetValue method instead. The method
        /// <see cref="GetValues2"/> performs the same task as this method but also allows the register source
        /// to be specified. For an overview of the <see cref="IDebugRegisters"/> interface and other register-related methods,
        /// see Registers.
        /// </remarks>
        public HRESULT TryGetValues(int count, int[] indices, int start, out DEBUG_VALUE[] values)
        {
            /*HRESULT GetValues(
            [In] int Count,
            [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] int[] Indices,
            [In] int Start,
            [SRI.Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] DEBUG_VALUE[] Values);*/
            values = new DEBUG_VALUE[count];
            HRESULT hr = Raw.GetValues(count, indices, start, values);

            return hr;
        }

        #endregion
        #region SetValues

        /// <summary>
        /// The SetValues method sets the value of several of the target's registers.
        /// </summary>
        /// <param name="count">[in] Specifies the number of registers for which to set the values.</param>
        /// <param name="indices">[in, optional] Specifies an array that contains the indices of the registers for which to set the values. The number of elements in this array is Count.<para/>
        /// If Indices is NULL, Start is used instead.</param>
        /// <param name="start">[in] If Indices is NULL, the registers will be set consecutively starting at this index. Otherwise it is ignored.</param>
        /// <param name="values">[in] Specifies the array that contains values to which to set the registers. The number of elements this array holds is Count.<para/>
        /// See <see cref="DEBUG_VALUE"/> for a description of this parameter type.</param>
        /// <remarks>
        /// The engine does its best to coerce the values in Values into the type of the registers; this coercion is the same
        /// as that performed by <see cref="DebugControl.CoerceValue"/>. If the value is larger than what the register can
        /// hold, the least significant bits are dropped. Floating-point and integer conversions will also be performed if
        /// necessary. If the return value is not S_OK, some of the registers still might have been set. When a subregister
        /// is altered, the register containing it is also altered. To set the value of only a single register, use the SetValue
        /// method instead. The method <see cref="SetValues2"/> performs the same task as this method but
        /// also allows the register source to be specified. For an overview of the <see cref="IDebugRegisters"/> interface
        /// and other register-related methods, see Registers.
        /// </remarks>
        public void SetValues(int count, int[] indices, int start, DEBUG_VALUE[] values)
        {
            TrySetValues(count, indices, start, values).ThrowDbgEngNotOK();
        }

        /// <summary>
        /// The SetValues method sets the value of several of the target's registers.
        /// </summary>
        /// <param name="count">[in] Specifies the number of registers for which to set the values.</param>
        /// <param name="indices">[in, optional] Specifies an array that contains the indices of the registers for which to set the values. The number of elements in this array is Count.<para/>
        /// If Indices is NULL, Start is used instead.</param>
        /// <param name="start">[in] If Indices is NULL, the registers will be set consecutively starting at this index. Otherwise it is ignored.</param>
        /// <param name="values">[in] Specifies the array that contains values to which to set the registers. The number of elements this array holds is Count.<para/>
        /// See <see cref="DEBUG_VALUE"/> for a description of this parameter type.</param>
        /// <returns>This list does not contain all the errors that might occur. For a list of possible errors, see HRESULT Values.</returns>
        /// <remarks>
        /// The engine does its best to coerce the values in Values into the type of the registers; this coercion is the same
        /// as that performed by <see cref="DebugControl.CoerceValue"/>. If the value is larger than what the register can
        /// hold, the least significant bits are dropped. Floating-point and integer conversions will also be performed if
        /// necessary. If the return value is not S_OK, some of the registers still might have been set. When a subregister
        /// is altered, the register containing it is also altered. To set the value of only a single register, use the SetValue
        /// method instead. The method <see cref="SetValues2"/> performs the same task as this method but
        /// also allows the register source to be specified. For an overview of the <see cref="IDebugRegisters"/> interface
        /// and other register-related methods, see Registers.
        /// </remarks>
        public HRESULT TrySetValues(int count, int[] indices, int start, DEBUG_VALUE[] values)
        {
            /*HRESULT SetValues(
            [In] int Count,
            [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] int[] Indices,
            [In] int Start,
            [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] DEBUG_VALUE[] Values);*/
            return Raw.SetValues(count, indices, start, values);
        }

        #endregion
        #region OutputRegisters

        /// <summary>
        /// The OutputRegisters method formats and sends the target's registers to the clients as output.
        /// </summary>
        /// <param name="outputControl">[in] Specifies which clients should be sent the output of the formatted registers. See DEBUG_OUTCTL_XXX for possible values.</param>
        /// <param name="flags">[in] Specifies which set of registers to print. This can either be DEBUG_REGISTERS_DEFAULT to print commonly used registers, DEBUG_REGISTERS_ALL to print all the sets of registers, or a combination of the values listed in the following table.</param>
        /// <remarks>
        /// The registers are formatted in a way that is specific to the target architecture's register set. The method <see
        /// cref="OutputRegisters2"/> performs the same task as this method but also allows the register source
        /// to be specified. For an overview of the <see cref="IDebugRegisters"/> interface and other register-related methods,
        /// see Registers. For details on sending output to the clients, see Input and Output.
        /// </remarks>
        public void OutputRegisters(DEBUG_OUTCTL outputControl, DEBUG_REGISTERS flags)
        {
            TryOutputRegisters(outputControl, flags).ThrowDbgEngNotOK();
        }

        /// <summary>
        /// The OutputRegisters method formats and sends the target's registers to the clients as output.
        /// </summary>
        /// <param name="outputControl">[in] Specifies which clients should be sent the output of the formatted registers. See DEBUG_OUTCTL_XXX for possible values.</param>
        /// <param name="flags">[in] Specifies which set of registers to print. This can either be DEBUG_REGISTERS_DEFAULT to print commonly used registers, DEBUG_REGISTERS_ALL to print all the sets of registers, or a combination of the values listed in the following table.</param>
        /// <returns>This list does not contain all the errors that might occur. For a list of possible errors, see HRESULT Values.</returns>
        /// <remarks>
        /// The registers are formatted in a way that is specific to the target architecture's register set. The method <see
        /// cref="OutputRegisters2"/> performs the same task as this method but also allows the register source
        /// to be specified. For an overview of the <see cref="IDebugRegisters"/> interface and other register-related methods,
        /// see Registers. For details on sending output to the clients, see Input and Output.
        /// </remarks>
        public HRESULT TryOutputRegisters(DEBUG_OUTCTL outputControl, DEBUG_REGISTERS flags)
        {
            /*HRESULT OutputRegisters(
            [In] DEBUG_OUTCTL OutputControl,
            [In] DEBUG_REGISTERS Flags);*/
            return Raw.OutputRegisters(outputControl, flags);
        }

        #endregion
        #endregion
        #region IDebugRegisters2

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public IDebugRegisters2 Raw2 => (IDebugRegisters2) Raw;

        #region NumberPseudoRegisters

        /// <summary>
        /// The GetNumberPseudoRegisters method returns the number of pseudo-registers that are maintained by the debugger engine.
        /// </summary>
        public int NumberPseudoRegisters
        {
            get
            {
                int number;
                TryGetNumberPseudoRegisters(out number).ThrowDbgEngNotOK();

                return number;
            }
        }

        /// <summary>
        /// The GetNumberPseudoRegisters method returns the number of pseudo-registers that are maintained by the debugger engine.
        /// </summary>
        /// <param name="number">[out] Receives the number of pseudo-registers that are maintained by the debugger engine.</param>
        /// <returns>This list does not contain all the errors that might occur. For a list of possible errors, see HRESULT Values.</returns>
        /// <remarks>
        /// Not all of the pseudo-registers are available in all debugging sessions or at all times in a particular session.
        /// The valid indices for pseudo-registers are between zero and the number of pseudo-registers, minus one. For an overview
        /// of the <see cref="IDebugRegisters"/> interface and other register-related methods, see Registers.
        /// </remarks>
        public HRESULT TryGetNumberPseudoRegisters(out int number)
        {
            /*HRESULT GetNumberPseudoRegisters(
            [Out] out int Number);*/
            return Raw2.GetNumberPseudoRegisters(out number);
        }

        #endregion
        #region GetDescriptionWide

        /// <summary>
        /// The GetDescriptionWide method returns the description of a register.
        /// </summary>
        /// <param name="register">[in] Specifies the index of the register for which the description is requested.</param>
        /// <returns>The values that were emitted from the COM method.</returns>
        /// <remarks>
        /// For an overview of the <see cref="IDebugRegisters"/> interface and other register-related methods, see Registers.
        /// </remarks>
        public GetDescriptionWideResult GetDescriptionWide(int register)
        {
            GetDescriptionWideResult result;
            TryGetDescriptionWide(register, out result).ThrowDbgEngNotOK();

            return result;
        }

        /// <summary>
        /// The GetDescriptionWide method returns the description of a register.
        /// </summary>
        /// <param name="register">[in] Specifies the index of the register for which the description is requested.</param>
        /// <param name="result">The values that were emitted from the COM method.</param>
        /// <returns>This list does not contain all the errors that might occur. For a list of possible errors, see HRESULT Values.</returns>
        /// <remarks>
        /// For an overview of the <see cref="IDebugRegisters"/> interface and other register-related methods, see Registers.
        /// </remarks>
        public HRESULT TryGetDescriptionWide(int register, out GetDescriptionWideResult result)
        {
            /*HRESULT GetDescriptionWide(
            [In] int Register,
            [SRI.Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U2, SizeParamIndex = 2)] char[] NameBuffer,
            [In] int NameBufferSize,
            [Out] out int NameSize,
            [Out] out DEBUG_REGISTER_DESCRIPTION Desc);*/
            char[] nameBuffer;
            int nameBufferSize = 0;
            int nameSize;
            DEBUG_REGISTER_DESCRIPTION desc;
            HRESULT hr = Raw2.GetDescriptionWide(register, null, nameBufferSize, out nameSize, out desc);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER && hr != HRESULT.S_OK)
                goto fail;

            nameBufferSize = nameSize;
            nameBuffer = new char[nameBufferSize];
            hr = Raw2.GetDescriptionWide(register, nameBuffer, nameBufferSize, out nameSize, out desc);

            if (hr == HRESULT.S_OK)
            {
                result = new GetDescriptionWideResult(CreateString(nameBuffer, nameSize), desc);

                return hr;
            }

            fail:
            result = default(GetDescriptionWideResult);

            return hr;
        }

        #endregion
        #region GetIndexByNameWide

        /// <summary>
        /// The GetIndexByNameWide method returns the index of the named register.
        /// </summary>
        /// <param name="name">[in] Specifies the name of the register whose index is requested.</param>
        /// <returns>[out] Receives the index of the register.</returns>
        /// <remarks>
        /// For an overview of the <see cref="IDebugRegisters"/> interface and other register-related methods, see Registers.
        /// </remarks>
        public int GetIndexByNameWide(string name)
        {
            int index;
            TryGetIndexByNameWide(name, out index).ThrowDbgEngNotOK();

            return index;
        }

        /// <summary>
        /// The GetIndexByNameWide method returns the index of the named register.
        /// </summary>
        /// <param name="name">[in] Specifies the name of the register whose index is requested.</param>
        /// <param name="index">[out] Receives the index of the register.</param>
        /// <returns>This list does not contain all the errors that might occur. For a list of possible errors, see HRESULT Values.</returns>
        /// <remarks>
        /// For an overview of the <see cref="IDebugRegisters"/> interface and other register-related methods, see Registers.
        /// </remarks>
        public HRESULT TryGetIndexByNameWide(string name, out int index)
        {
            /*HRESULT GetIndexByNameWide(
            [In, MarshalAs(UnmanagedType.LPWStr)] string Name,
            [Out] out int Index);*/
            return Raw2.GetIndexByNameWide(name, out index);
        }

        #endregion
        #region GetPseudoDescription

        /// <summary>
        /// The GetPseudoDescription method returns a description of a pseudo-register, including its name and type.
        /// </summary>
        /// <param name="register">[in] Specifies the index of the pseudo-register whose description is requested. The index is always between zero and the number of pseudo-registers (returned by <see cref="NumberPseudoRegisters"/>) minus one.</param>
        /// <returns>The values that were emitted from the COM method.</returns>
        /// <remarks>
        /// Descriptions are not always available for all registers. If a pseudo-register does not have a value - for example,
        /// $eventip will not have a value before an event has occurred - or a type cannot be determined for a pseudo-register,
        /// this method will return E_FAIL. For an overview of the <see cref="IDebugRegisters"/> interface and other register-related
        /// methods, see Registers.
        /// </remarks>
        public GetPseudoDescriptionResult GetPseudoDescription(int register)
        {
            GetPseudoDescriptionResult result;
            TryGetPseudoDescription(register, out result).ThrowDbgEngNotOK();

            return result;
        }

        /// <summary>
        /// The GetPseudoDescription method returns a description of a pseudo-register, including its name and type.
        /// </summary>
        /// <param name="register">[in] Specifies the index of the pseudo-register whose description is requested. The index is always between zero and the number of pseudo-registers (returned by <see cref="NumberPseudoRegisters"/>) minus one.</param>
        /// <param name="result">The values that were emitted from the COM method.</param>
        /// <returns>This list does not contain all the errors that might occur. For a list of possible errors, see HRESULT Values.</returns>
        /// <remarks>
        /// Descriptions are not always available for all registers. If a pseudo-register does not have a value - for example,
        /// $eventip will not have a value before an event has occurred - or a type cannot be determined for a pseudo-register,
        /// this method will return E_FAIL. For an overview of the <see cref="IDebugRegisters"/> interface and other register-related
        /// methods, see Registers.
        /// </remarks>
        public HRESULT TryGetPseudoDescription(int register, out GetPseudoDescriptionResult result)
        {
            /*HRESULT GetPseudoDescription(
            [In] int Register,
            [SRI.Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U1, SizeParamIndex = 2)] byte[] NameBuffer,
            [In] int NameBufferSize,
            [Out] out int NameSize,
            [Out] out long TypeModule,
            [Out] out int TypeId);*/
            byte[] nameBuffer;
            int nameBufferSize = 0;
            int nameSize;
            long typeModule;
            int typeId;
            HRESULT hr = Raw2.GetPseudoDescription(register, null, nameBufferSize, out nameSize, out typeModule, out typeId);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER && hr != HRESULT.S_OK)
                goto fail;

            nameBufferSize = nameSize;
            nameBuffer = new byte[nameBufferSize];
            hr = Raw2.GetPseudoDescription(register, nameBuffer, nameBufferSize, out nameSize, out typeModule, out typeId);

            if (hr == HRESULT.S_OK)
            {
                result = new GetPseudoDescriptionResult(CreateString(nameBuffer, nameSize), typeModule, typeId);

                return hr;
            }

            fail:
            result = default(GetPseudoDescriptionResult);

            return hr;
        }

        #endregion
        #region GetPseudoDescriptionWide

        /// <summary>
        /// The GetPseudoDescriptionWide method returns a description of a pseudo-register, including its name and type.
        /// </summary>
        /// <param name="register">[in] Specifies the index of the pseudo-register whose description is requested. The index is always between zero and the number of pseudo-registers (returned by <see cref="NumberPseudoRegisters"/>) minus one.</param>
        /// <returns>The values that were emitted from the COM method.</returns>
        /// <remarks>
        /// Descriptions are not always available for all registers. If a pseudo-register does not have a value - for example,
        /// $eventip will not have a value before an event has occurred - or a type cannot be determined for a pseudo-register,
        /// this method will return E_FAIL. For an overview of the <see cref="IDebugRegisters"/> interface and other register-related
        /// methods, see Registers.
        /// </remarks>
        public GetPseudoDescriptionWideResult GetPseudoDescriptionWide(int register)
        {
            GetPseudoDescriptionWideResult result;
            TryGetPseudoDescriptionWide(register, out result).ThrowDbgEngNotOK();

            return result;
        }

        /// <summary>
        /// The GetPseudoDescriptionWide method returns a description of a pseudo-register, including its name and type.
        /// </summary>
        /// <param name="register">[in] Specifies the index of the pseudo-register whose description is requested. The index is always between zero and the number of pseudo-registers (returned by <see cref="NumberPseudoRegisters"/>) minus one.</param>
        /// <param name="result">The values that were emitted from the COM method.</param>
        /// <returns>This list does not contain all the errors that might occur. For a list of possible errors, see HRESULT Values.</returns>
        /// <remarks>
        /// Descriptions are not always available for all registers. If a pseudo-register does not have a value - for example,
        /// $eventip will not have a value before an event has occurred - or a type cannot be determined for a pseudo-register,
        /// this method will return E_FAIL. For an overview of the <see cref="IDebugRegisters"/> interface and other register-related
        /// methods, see Registers.
        /// </remarks>
        public HRESULT TryGetPseudoDescriptionWide(int register, out GetPseudoDescriptionWideResult result)
        {
            /*HRESULT GetPseudoDescriptionWide(
            [In] int Register,
            [SRI.Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U2, SizeParamIndex = 2)] char[] NameBuffer,
            [In] int NameBufferSize,
            [Out] out int NameSize,
            [Out] out long TypeModule,
            [Out] out int TypeId);*/
            char[] nameBuffer;
            int nameBufferSize = 0;
            int nameSize;
            long typeModule;
            int typeId;
            HRESULT hr = Raw2.GetPseudoDescriptionWide(register, null, nameBufferSize, out nameSize, out typeModule, out typeId);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER && hr != HRESULT.S_OK)
                goto fail;

            nameBufferSize = nameSize;
            nameBuffer = new char[nameBufferSize];
            hr = Raw2.GetPseudoDescriptionWide(register, nameBuffer, nameBufferSize, out nameSize, out typeModule, out typeId);

            if (hr == HRESULT.S_OK)
            {
                result = new GetPseudoDescriptionWideResult(CreateString(nameBuffer, nameSize), typeModule, typeId);

                return hr;
            }

            fail:
            result = default(GetPseudoDescriptionWideResult);

            return hr;
        }

        #endregion
        #region GetPseudoIndexByName

        /// <summary>
        /// The GetPseudoIndexByName method returns the index of a pseudo-register.
        /// </summary>
        /// <param name="name">[in] Specifies the name of the pseudo-register whose index is requested. The name includes the leading dollar sign ( $ ), for example, "$frame".</param>
        /// <returns>[out] Receives the index of the pseudo-register.</returns>
        /// <remarks>
        /// For the names of all the pseudo-registers, see Pseudo-Register Syntax. For an overview of the <see cref="IDebugRegisters"/>
        /// interface and other register-related methods, see Registers.
        /// </remarks>
        public int GetPseudoIndexByName(string name)
        {
            int index;
            TryGetPseudoIndexByName(name, out index).ThrowDbgEngNotOK();

            return index;
        }

        /// <summary>
        /// The GetPseudoIndexByName method returns the index of a pseudo-register.
        /// </summary>
        /// <param name="name">[in] Specifies the name of the pseudo-register whose index is requested. The name includes the leading dollar sign ( $ ), for example, "$frame".</param>
        /// <param name="index">[out] Receives the index of the pseudo-register.</param>
        /// <returns>This list does not contain all the errors that might occur. For a list of possible errors, see HRESULT Values.</returns>
        /// <remarks>
        /// For the names of all the pseudo-registers, see Pseudo-Register Syntax. For an overview of the <see cref="IDebugRegisters"/>
        /// interface and other register-related methods, see Registers.
        /// </remarks>
        public HRESULT TryGetPseudoIndexByName(string name, out int index)
        {
            /*HRESULT GetPseudoIndexByName(
            [In, MarshalAs(UnmanagedType.LPStr)] string Name,
            [Out] out int Index);*/
            return Raw2.GetPseudoIndexByName(name, out index);
        }

        #endregion
        #region GetPseudoIndexByNameWide

        /// <summary>
        /// The GetPseudoIndexByNameWide method returns the index of a pseudo-register.
        /// </summary>
        /// <param name="name">[in] Specifies the name of the pseudo-register whose index is requested. The name includes the leading dollar sign ( $ ), for example, "$frame".</param>
        /// <returns>[out] Receives the index of the pseudo-register.</returns>
        /// <remarks>
        /// For the names of all the pseudo-registers, see Pseudo-Register Syntax. For an overview of the <see cref="IDebugRegisters"/>
        /// interface and other register-related methods, see Registers.
        /// </remarks>
        public int GetPseudoIndexByNameWide(string name)
        {
            int index;
            TryGetPseudoIndexByNameWide(name, out index).ThrowDbgEngNotOK();

            return index;
        }

        /// <summary>
        /// The GetPseudoIndexByNameWide method returns the index of a pseudo-register.
        /// </summary>
        /// <param name="name">[in] Specifies the name of the pseudo-register whose index is requested. The name includes the leading dollar sign ( $ ), for example, "$frame".</param>
        /// <param name="index">[out] Receives the index of the pseudo-register.</param>
        /// <returns>This list does not contain all the errors that might occur. For a list of possible errors, see HRESULT Values.</returns>
        /// <remarks>
        /// For the names of all the pseudo-registers, see Pseudo-Register Syntax. For an overview of the <see cref="IDebugRegisters"/>
        /// interface and other register-related methods, see Registers.
        /// </remarks>
        public HRESULT TryGetPseudoIndexByNameWide(string name, out int index)
        {
            /*HRESULT GetPseudoIndexByNameWide(
            [In, MarshalAs(UnmanagedType.LPWStr)] string Name,
            [Out] out int Index);*/
            return Raw2.GetPseudoIndexByNameWide(name, out index);
        }

        #endregion
        #region GetPseudoValues

        /// <summary>
        /// The GetPseudoValues method returns the values of a number of pseudo-registers.
        /// </summary>
        /// <param name="source">[in] Specifies the register source to query. The possible values are listed in the following table.</param>
        /// <param name="count">[in] Specifies the number of pseudo-registers whose values are being requested.</param>
        /// <param name="indices">[in, optional] Specifies an array of indices of pseudo-registers whose values will be returned. The size of Indices is Count.<para/>
        /// If Indices is NULL, Start is used to specify the indices instead.</param>
        /// <param name="start">[in] Specifies the index of the first pseudo-register whose value will be returned. The pseudo-registers, with indices between Start and Start plus Count minus one, will be returned.<para/>
        /// Start is only used if Indices is NULL.</param>
        /// <returns>[out] Receives the values of the specified pseudo-registers. The number of elements that this array holds is Count.<para/>
        /// See <see cref="DEBUG_VALUE"/> for a description of this parameter type.</returns>
        /// <remarks>
        /// For an overview of the <see cref="IDebugRegisters"/> interface and other register-related methods, see Registers.
        /// </remarks>
        public DEBUG_VALUE[] GetPseudoValues(DEBUG_REGSRC source, int count, int[] indices, int start)
        {
            DEBUG_VALUE[] values;
            TryGetPseudoValues(source, count, indices, start, out values).ThrowDbgEngNotOK();

            return values;
        }

        /// <summary>
        /// The GetPseudoValues method returns the values of a number of pseudo-registers.
        /// </summary>
        /// <param name="source">[in] Specifies the register source to query. The possible values are listed in the following table.</param>
        /// <param name="count">[in] Specifies the number of pseudo-registers whose values are being requested.</param>
        /// <param name="indices">[in, optional] Specifies an array of indices of pseudo-registers whose values will be returned. The size of Indices is Count.<para/>
        /// If Indices is NULL, Start is used to specify the indices instead.</param>
        /// <param name="start">[in] Specifies the index of the first pseudo-register whose value will be returned. The pseudo-registers, with indices between Start and Start plus Count minus one, will be returned.<para/>
        /// Start is only used if Indices is NULL.</param>
        /// <param name="values">[out] Receives the values of the specified pseudo-registers. The number of elements that this array holds is Count.<para/>
        /// See <see cref="DEBUG_VALUE"/> for a description of this parameter type.</param>
        /// <returns>This list does not contain all the errors that might occur. For a list of possible errors, see HRESULT Values.</returns>
        /// <remarks>
        /// For an overview of the <see cref="IDebugRegisters"/> interface and other register-related methods, see Registers.
        /// </remarks>
        public HRESULT TryGetPseudoValues(DEBUG_REGSRC source, int count, int[] indices, int start, out DEBUG_VALUE[] values)
        {
            /*HRESULT GetPseudoValues(
            [In] DEBUG_REGSRC Source,
            [In] int Count,
            [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] int[] Indices,
            [In] int Start,
            [SRI.Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] DEBUG_VALUE[] Values);*/
            values = new DEBUG_VALUE[count];
            HRESULT hr = Raw2.GetPseudoValues(source, count, indices, start, values);

            return hr;
        }

        #endregion
        #region SetPseudoValues

        /// <summary>
        /// The SetPseudoValues method sets the value of several pseudo-registers.
        /// </summary>
        /// <param name="source">[in] Specifies the register source to query. The possible values are listed in the following table.</param>
        /// <param name="count">[in] Specifies the number of pseudo-registers whose values are being set.</param>
        /// <param name="indices">[in, optional] Specifies an array of indices of pseudo-registers. These are the pseudo-registers whose values will be set.<para/>
        /// The size of Indices is Count. If Indices is NULL, Start is used to specify the indices instead.</param>
        /// <param name="start">[in] Specifies the index of the first pseudo-register whose value will be set. The pseudo-registers with indices between Start and Start plus Count minus one, will be set.<para/>
        /// Start is only used if Indices is NULL.</param>
        /// <param name="values">[in] Specifies the new values of the pseudo-registers. The number of elements this array holds is Count. See <see cref="DEBUG_VALUE"/> for a description of this parameter type.</param>
        /// <remarks>
        /// For an overview of the <see cref="IDebugRegisters"/> interface and other register-related methods, see Registers.
        /// </remarks>
        public void SetPseudoValues(DEBUG_REGSRC source, int count, int[] indices, int start, DEBUG_VALUE[] values)
        {
            TrySetPseudoValues(source, count, indices, start, values).ThrowDbgEngNotOK();
        }

        /// <summary>
        /// The SetPseudoValues method sets the value of several pseudo-registers.
        /// </summary>
        /// <param name="source">[in] Specifies the register source to query. The possible values are listed in the following table.</param>
        /// <param name="count">[in] Specifies the number of pseudo-registers whose values are being set.</param>
        /// <param name="indices">[in, optional] Specifies an array of indices of pseudo-registers. These are the pseudo-registers whose values will be set.<para/>
        /// The size of Indices is Count. If Indices is NULL, Start is used to specify the indices instead.</param>
        /// <param name="start">[in] Specifies the index of the first pseudo-register whose value will be set. The pseudo-registers with indices between Start and Start plus Count minus one, will be set.<para/>
        /// Start is only used if Indices is NULL.</param>
        /// <param name="values">[in] Specifies the new values of the pseudo-registers. The number of elements this array holds is Count. See <see cref="DEBUG_VALUE"/> for a description of this parameter type.</param>
        /// <returns>This list does not contain all the errors that might occur. For a list of possible errors, see HRESULT Values.</returns>
        /// <remarks>
        /// For an overview of the <see cref="IDebugRegisters"/> interface and other register-related methods, see Registers.
        /// </remarks>
        public HRESULT TrySetPseudoValues(DEBUG_REGSRC source, int count, int[] indices, int start, DEBUG_VALUE[] values)
        {
            /*HRESULT SetPseudoValues(
            [In] DEBUG_REGSRC Source,
            [In] int Count,
            [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] int[] Indices,
            [In] int Start,
            [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] DEBUG_VALUE[] Values);*/
            return Raw2.SetPseudoValues(source, count, indices, start, values);
        }

        #endregion
        #region GetValues2

        /// <summary>
        /// The GetValues2 method fetches the value of several of the target's registers.
        /// </summary>
        /// <param name="source">[in] Specifies the register source to query. The possible values are listed in the following table.</param>
        /// <param name="count">[in] Specifies the number of registers whose values are requested.</param>
        /// <param name="indices">[in, optional] Specifies an array that contains the indices of the registers from which to get the values. The number of elements in this array is Count.<para/>
        /// If Indices is NULL, Start is used instead.</param>
        /// <param name="start">[in] If Indices is NULL, the registers will be read consecutively starting at this index. Otherwise, it is ignored.</param>
        /// <returns>[out] Receives the values of the registers. The number of elements that this array holds is Count. See <see cref="DEBUG_VALUE"/> for a description of this parameter type.</returns>
        /// <remarks>
        /// If the return value is not S_OK, some of the registers still might have been read. If the target was not accessible,
        /// the return type is E_UNEXPECTED and Values is unchanged. Otherwise, Values will contain partial results and the
        /// registers that could not be read will have type DEBUG_VALUE_INVALID. Ambiguity in the case of the return value
        /// E_UNEXPECTED can be avoided by setting the memory of Values to zero before calling this method. The method <see
        /// cref="GetValues"/> performs the same task as this method but always uses the target as the register source. For
        /// an overview of the <see cref="IDebugRegisters"/> interface and other register-related methods, see Registers.
        /// </remarks>
        public DEBUG_VALUE[] GetValues2(DEBUG_REGSRC source, int count, int[] indices, int start)
        {
            DEBUG_VALUE[] values;
            TryGetValues2(source, count, indices, start, out values).ThrowDbgEngNotOK();

            return values;
        }

        /// <summary>
        /// The GetValues2 method fetches the value of several of the target's registers.
        /// </summary>
        /// <param name="source">[in] Specifies the register source to query. The possible values are listed in the following table.</param>
        /// <param name="count">[in] Specifies the number of registers whose values are requested.</param>
        /// <param name="indices">[in, optional] Specifies an array that contains the indices of the registers from which to get the values. The number of elements in this array is Count.<para/>
        /// If Indices is NULL, Start is used instead.</param>
        /// <param name="start">[in] If Indices is NULL, the registers will be read consecutively starting at this index. Otherwise, it is ignored.</param>
        /// <param name="values">[out] Receives the values of the registers. The number of elements that this array holds is Count. See <see cref="DEBUG_VALUE"/> for a description of this parameter type.</param>
        /// <returns>This list does not contain all the errors that might occur. For a list of possible errors, see HRESULT Values.</returns>
        /// <remarks>
        /// If the return value is not S_OK, some of the registers still might have been read. If the target was not accessible,
        /// the return type is E_UNEXPECTED and Values is unchanged. Otherwise, Values will contain partial results and the
        /// registers that could not be read will have type DEBUG_VALUE_INVALID. Ambiguity in the case of the return value
        /// E_UNEXPECTED can be avoided by setting the memory of Values to zero before calling this method. The method <see
        /// cref="GetValues"/> performs the same task as this method but always uses the target as the register source. For
        /// an overview of the <see cref="IDebugRegisters"/> interface and other register-related methods, see Registers.
        /// </remarks>
        public HRESULT TryGetValues2(DEBUG_REGSRC source, int count, int[] indices, int start, out DEBUG_VALUE[] values)
        {
            /*HRESULT GetValues2(
            [In] DEBUG_REGSRC Source,
            [In] int Count,
            [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] int[] Indices,
            [In] int Start,
            [SRI.Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] DEBUG_VALUE[] Values);*/
            values = new DEBUG_VALUE[count];
            HRESULT hr = Raw2.GetValues2(source, count, indices, start, values);

            return hr;
        }

        #endregion
        #region SetValues2

        /// <summary>
        /// The SetValues2 method sets the value of several of the target's registers.
        /// </summary>
        /// <param name="source">[in] Specifies the register source to query. The possible values are listed in the following table.</param>
        /// <param name="count">[in] Specifies the number of registers for which to set the values.</param>
        /// <param name="indices">[in, optional] Specifies an array that contains the indices of the registers for which to set the values. The number of elements in this array is Count.<para/>
        /// If Indices is NULL, Start is used instead.</param>
        /// <param name="start">[in] If Indices is NULL, the registers will be set consecutively starting at this index. Otherwise, it is ignored.</param>
        /// <param name="values">[in] An array that contains the values to which to set the registers. The number of elements that this array holds is Count.<para/>
        /// See <see cref="DEBUG_VALUE"/> for a description of this parameter type.</param>
        /// <remarks>
        /// The engine does its best to cast the values in Values into the type of the registers; this conversion is the same
        /// as that performed by <see cref="DebugControl.CoerceValue"/>. If the value is larger than what the register can
        /// hold, the least significant bits are dropped. Floating-point and integer conversions will also be performed if
        /// necessary. If the return value is not S_OK, some of the registers still might have been set. When a subregister
        /// is altered, the register that contains it is also altered. The method <see cref="SetValues"/> performs the same
        /// task as this method but always uses the target as the register source. For an overview of the <see cref="IDebugRegisters"/>
        /// interface and other register-related methods, see Registers.
        /// </remarks>
        public void SetValues2(DEBUG_REGSRC source, int count, int[] indices, int start, DEBUG_VALUE[] values)
        {
            TrySetValues2(source, count, indices, start, values).ThrowDbgEngNotOK();
        }

        /// <summary>
        /// The SetValues2 method sets the value of several of the target's registers.
        /// </summary>
        /// <param name="source">[in] Specifies the register source to query. The possible values are listed in the following table.</param>
        /// <param name="count">[in] Specifies the number of registers for which to set the values.</param>
        /// <param name="indices">[in, optional] Specifies an array that contains the indices of the registers for which to set the values. The number of elements in this array is Count.<para/>
        /// If Indices is NULL, Start is used instead.</param>
        /// <param name="start">[in] If Indices is NULL, the registers will be set consecutively starting at this index. Otherwise, it is ignored.</param>
        /// <param name="values">[in] An array that contains the values to which to set the registers. The number of elements that this array holds is Count.<para/>
        /// See <see cref="DEBUG_VALUE"/> for a description of this parameter type.</param>
        /// <returns>This list does not contain all the errors that might occur. For a list of possible errors, see HRESULT Values.</returns>
        /// <remarks>
        /// The engine does its best to cast the values in Values into the type of the registers; this conversion is the same
        /// as that performed by <see cref="DebugControl.CoerceValue"/>. If the value is larger than what the register can
        /// hold, the least significant bits are dropped. Floating-point and integer conversions will also be performed if
        /// necessary. If the return value is not S_OK, some of the registers still might have been set. When a subregister
        /// is altered, the register that contains it is also altered. The method <see cref="SetValues"/> performs the same
        /// task as this method but always uses the target as the register source. For an overview of the <see cref="IDebugRegisters"/>
        /// interface and other register-related methods, see Registers.
        /// </remarks>
        public HRESULT TrySetValues2(DEBUG_REGSRC source, int count, int[] indices, int start, DEBUG_VALUE[] values)
        {
            /*HRESULT SetValues2(
            [In] DEBUG_REGSRC Source,
            [In] int Count,
            [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] int[] Indices,
            [In] int Start,
            [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] DEBUG_VALUE[] Values);*/
            return Raw2.SetValues2(source, count, indices, start, values);
        }

        #endregion
        #region OutputRegisters2

        /// <summary>
        /// The OutputRegisters2 method formats and outputs the target's registers.
        /// </summary>
        /// <param name="outputControl">[in] Specifies which clients should be sent the output of the formatted registers. See DEBUG_OUTCTL_XXX for possible values.</param>
        /// <param name="source">[in] Specifies the register source to query. The possible values are listed in the following table.</param>
        /// <param name="flags">[in] Specifies which register sets to print. This can either be DEBUG_REGISTERS_DEFAULT to print commonly used registers, DEBUG_REGISTERS_ALL to print all of the register sets, or a combination of the values listed in the following table.</param>
        /// <remarks>
        /// The registers are formatted in a way that is specific to the target architecture's register set. The method <see
        /// cref="OutputRegisters"/> performs the same task as this method but always uses the target as the register source.
        /// For an overview of the <see cref="IDebugRegisters"/> interface and other register-related methods, see Registers.
        /// </remarks>
        public void OutputRegisters2(DEBUG_OUTCTL outputControl, DEBUG_REGSRC source, DEBUG_REGISTERS flags)
        {
            TryOutputRegisters2(outputControl, source, flags).ThrowDbgEngNotOK();
        }

        /// <summary>
        /// The OutputRegisters2 method formats and outputs the target's registers.
        /// </summary>
        /// <param name="outputControl">[in] Specifies which clients should be sent the output of the formatted registers. See DEBUG_OUTCTL_XXX for possible values.</param>
        /// <param name="source">[in] Specifies the register source to query. The possible values are listed in the following table.</param>
        /// <param name="flags">[in] Specifies which register sets to print. This can either be DEBUG_REGISTERS_DEFAULT to print commonly used registers, DEBUG_REGISTERS_ALL to print all of the register sets, or a combination of the values listed in the following table.</param>
        /// <returns>This list does not contain all the errors that might occur. For a list of possible errors, see HRESULT Values.</returns>
        /// <remarks>
        /// The registers are formatted in a way that is specific to the target architecture's register set. The method <see
        /// cref="OutputRegisters"/> performs the same task as this method but always uses the target as the register source.
        /// For an overview of the <see cref="IDebugRegisters"/> interface and other register-related methods, see Registers.
        /// </remarks>
        public HRESULT TryOutputRegisters2(DEBUG_OUTCTL outputControl, DEBUG_REGSRC source, DEBUG_REGISTERS flags)
        {
            /*HRESULT OutputRegisters2(
            [In] DEBUG_OUTCTL OutputControl,
            [In] DEBUG_REGSRC Source,
            [In] DEBUG_REGISTERS Flags);*/
            return Raw2.OutputRegisters2(outputControl, source, flags);
        }

        #endregion
        #region GetInstructionOffset2

        /// <summary>
        /// The GetInstructionOffset2 method returns the location of the current thread's current instruction.
        /// </summary>
        /// <param name="source">[in] Specifies the register source to query. The possible values are listed in the following table.</param>
        /// <returns>[out] Receives the location in the process's virtual address space of the current instruction of the current thread.</returns>
        /// <remarks>
        /// The meaning of the value that is returned by this method is architecture-dependent. In particular, for an Itanium-based
        /// processor, the virtual address that is returned can indicate an address within a bundle. The method <see cref="InstructionOffset"/>
        /// performs the same task as this method but always uses the target as the register source. For an overview of the
        /// <see cref="IDebugRegisters"/> interface and other register-related methods, see Registers.
        /// </remarks>
        public long GetInstructionOffset2(DEBUG_REGSRC source)
        {
            long offset;
            TryGetInstructionOffset2(source, out offset).ThrowDbgEngNotOK();

            return offset;
        }

        /// <summary>
        /// The GetInstructionOffset2 method returns the location of the current thread's current instruction.
        /// </summary>
        /// <param name="source">[in] Specifies the register source to query. The possible values are listed in the following table.</param>
        /// <param name="offset">[out] Receives the location in the process's virtual address space of the current instruction of the current thread.</param>
        /// <returns>This list does not contain all the errors that might occur. For a list of possible errors, see HRESULT Values.</returns>
        /// <remarks>
        /// The meaning of the value that is returned by this method is architecture-dependent. In particular, for an Itanium-based
        /// processor, the virtual address that is returned can indicate an address within a bundle. The method <see cref="InstructionOffset"/>
        /// performs the same task as this method but always uses the target as the register source. For an overview of the
        /// <see cref="IDebugRegisters"/> interface and other register-related methods, see Registers.
        /// </remarks>
        public HRESULT TryGetInstructionOffset2(DEBUG_REGSRC source, out long offset)
        {
            /*HRESULT GetInstructionOffset2(
            [In] DEBUG_REGSRC Source,
            [Out] out long Offset);*/
            return Raw2.GetInstructionOffset2(source, out offset);
        }

        #endregion
        #region GetStackOffset2

        /// <summary>
        /// The GetStackOffset2 method returns the current thread's current stack location.
        /// </summary>
        /// <param name="source">[in] Specifies the register source to query. The possible values are listed in the following table.</param>
        /// <returns>[out] Receives the location in the process's virtual address space of the current thread's current stack.</returns>
        public long GetStackOffset2(DEBUG_REGSRC source)
        {
            long offset;
            TryGetStackOffset2(source, out offset).ThrowDbgEngNotOK();

            return offset;
        }

        /// <summary>
        /// The GetStackOffset2 method returns the current thread's current stack location.
        /// </summary>
        /// <param name="source">[in] Specifies the register source to query. The possible values are listed in the following table.</param>
        /// <param name="offset">[out] Receives the location in the process's virtual address space of the current thread's current stack.</param>
        /// <returns>This list does not contain all the errors that might occur. For a list of possible errors, see HRESULT Values.</returns>
        public HRESULT TryGetStackOffset2(DEBUG_REGSRC source, out long offset)
        {
            /*HRESULT GetStackOffset2(
            [In] DEBUG_REGSRC Source,
            [Out] out long Offset);*/
            return Raw2.GetStackOffset2(source, out offset);
        }

        #endregion
        #region GetFrameOffset2

        /// <summary>
        /// The GetFrameOffset2 method returns the location of the stack frame for the current function.
        /// </summary>
        /// <param name="source">[in] Specifies the register source to query. The possible values are listed in the following table.</param>
        /// <returns>[out] The location in the process's virtual address space of the stack frame for the current function.</returns>
        /// <remarks>
        /// The meaning of the value that is returned by this method is architecture-specific. The method <see cref="FrameOffset"/>
        /// performs the same task as this method but always uses the target as the register source. For an overview of the
        /// <see cref="IDebugRegisters"/> interface and other register-related methods, see Registers.
        /// </remarks>
        public long GetFrameOffset2(DEBUG_REGSRC source)
        {
            long offset;
            TryGetFrameOffset2(source, out offset).ThrowDbgEngNotOK();

            return offset;
        }

        /// <summary>
        /// The GetFrameOffset2 method returns the location of the stack frame for the current function.
        /// </summary>
        /// <param name="source">[in] Specifies the register source to query. The possible values are listed in the following table.</param>
        /// <param name="offset">[out] The location in the process's virtual address space of the stack frame for the current function.</param>
        /// <returns>This list does not contain all the errors that might occur. For a list of possible errors, see HRESULT Values.</returns>
        /// <remarks>
        /// The meaning of the value that is returned by this method is architecture-specific. The method <see cref="FrameOffset"/>
        /// performs the same task as this method but always uses the target as the register source. For an overview of the
        /// <see cref="IDebugRegisters"/> interface and other register-related methods, see Registers.
        /// </remarks>
        public HRESULT TryGetFrameOffset2(DEBUG_REGSRC source, out long offset)
        {
            /*HRESULT GetFrameOffset2(
            [In] DEBUG_REGSRC Source,
            [Out] out long Offset);*/
            return Raw2.GetFrameOffset2(source, out offset);
        }

        #endregion
        #endregion
    }
}
