﻿using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Text;
using ClrDebug.DbgEng.Vtbl;

namespace ClrDebug.DbgEng
{
    public unsafe class DebugRegisters : RuntimeCallableWrapper
    {
        public static readonly Guid IID_IDebugRegisters = new Guid("ce289126-9e84-45a7-937e-67bb18691493");

        #region Vtbl

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private new IDebugRegistersVtbl* Vtbl => (IDebugRegistersVtbl*) base.Vtbl;

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private IDebugRegisters2Vtbl* Vtbl2 => (IDebugRegisters2Vtbl*) base.Vtbl;

        #endregion
        
        public DebugRegisters(IntPtr raw) : base(raw, IID_IDebugRegisters)
        {
        }

        public DebugRegisters(IDebugRegisters raw) : base(raw)
        {
        }

        #region IDebugRegisters
        #region NumberRegisters

        /// <summary>
        /// The GetNumberRegisters method returns the number of registers on the target computer.
        /// </summary>
        public uint NumberRegisters
        {
            get
            {
                uint number;
                TryGetNumberRegisters(out number).ThrowDbgEngNotOk();

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
        public HRESULT TryGetNumberRegisters(out uint number)
        {
            InitDelegate(ref getNumberRegisters, Vtbl->GetNumberRegisters);

            /*HRESULT GetNumberRegisters(
            [Out] out uint Number);*/
            return getNumberRegisters(Raw, out number);
        }

        #endregion
        #region InstructionOffset

        /// <summary>
        /// The GetInstructionOffset method returns the location of the current thread's current instruction.
        /// </summary>
        public ulong InstructionOffset
        {
            get
            {
                ulong offset;
                TryGetInstructionOffset(out offset).ThrowDbgEngNotOk();

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
        public HRESULT TryGetInstructionOffset(out ulong offset)
        {
            InitDelegate(ref getInstructionOffset, Vtbl->GetInstructionOffset);

            /*HRESULT GetInstructionOffset(
            [Out] out ulong Offset);*/
            return getInstructionOffset(Raw, out offset);
        }

        #endregion
        #region StackOffset

        /// <summary>
        /// The GetStackOffset method returns the current thread's current stack location.
        /// </summary>
        public ulong StackOffset
        {
            get
            {
                ulong offset;
                TryGetStackOffset(out offset).ThrowDbgEngNotOk();

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
        public HRESULT TryGetStackOffset(out ulong offset)
        {
            InitDelegate(ref getStackOffset, Vtbl->GetStackOffset);

            /*HRESULT GetStackOffset(
            [Out] out ulong Offset);*/
            return getStackOffset(Raw, out offset);
        }

        #endregion
        #region FrameOffset

        /// <summary>
        /// The GetFrameOffset method returns the location of the stack frame for the current function.
        /// </summary>
        public ulong FrameOffset
        {
            get
            {
                ulong offset;
                TryGetFrameOffset(out offset).ThrowDbgEngNotOk();

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
        public HRESULT TryGetFrameOffset(out ulong offset)
        {
            InitDelegate(ref getFrameOffset, Vtbl->GetFrameOffset);

            /*HRESULT GetFrameOffset(
            [Out] out ulong Offset);*/
            return getFrameOffset(Raw, out offset);
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
        public GetDescriptionResult GetDescription(uint register)
        {
            GetDescriptionResult result;
            TryGetDescription(register, out result).ThrowDbgEngNotOk();

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
        public HRESULT TryGetDescription(uint register, out GetDescriptionResult result)
        {
            InitDelegate(ref getDescription, Vtbl->GetDescription);
            /*HRESULT GetDescription(
            [In] uint Register,
            [Out, MarshalAs(UnmanagedType.LPStr)] StringBuilder NameBuffer,
            [In] int NameBufferSize,
            [Out] out uint NameSize,
            [Out] out DEBUG_REGISTER_DESCRIPTION Desc);*/
            StringBuilder nameBuffer;
            int nameBufferSize = 0;
            uint nameSize;
            DEBUG_REGISTER_DESCRIPTION desc;
            HRESULT hr = getDescription(Raw, register, null, nameBufferSize, out nameSize, out desc);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER && hr != HRESULT.S_OK)
                goto fail;

            nameBufferSize = (int) nameSize;
            nameBuffer = new StringBuilder(nameBufferSize);
            hr = getDescription(Raw, register, nameBuffer, nameBufferSize, out nameSize, out desc);

            if (hr == HRESULT.S_OK)
            {
                result = new GetDescriptionResult(nameBuffer.ToString(), desc);

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
        public uint GetIndexByName(string name)
        {
            uint index;
            TryGetIndexByName(name, out index).ThrowDbgEngNotOk();

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
        public HRESULT TryGetIndexByName(string name, out uint index)
        {
            InitDelegate(ref getIndexByName, Vtbl->GetIndexByName);

            /*HRESULT GetIndexByName(
            [In, MarshalAs(UnmanagedType.LPStr)] string Name,
            [Out] out uint Index);*/
            return getIndexByName(Raw, name, out index);
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
        public DEBUG_VALUE GetValue(uint register)
        {
            DEBUG_VALUE value;
            TryGetValue(register, out value).ThrowDbgEngNotOk();

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
        public HRESULT TryGetValue(uint register, out DEBUG_VALUE value)
        {
            InitDelegate(ref getValue, Vtbl->GetValue);

            /*HRESULT GetValue(
            [In] uint Register,
            [Out] out DEBUG_VALUE Value);*/
            return getValue(Raw, register, out value);
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
        public void SetValue(uint register, DEBUG_VALUE value)
        {
            TrySetValue(register, value).ThrowDbgEngNotOk();
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
        public HRESULT TrySetValue(uint register, DEBUG_VALUE value)
        {
            InitDelegate(ref setValue, Vtbl->SetValue);

            /*HRESULT SetValue(
            [In] uint Register,
            [In] DEBUG_VALUE Value);*/
            return setValue(Raw, register, value);
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
        public DEBUG_VALUE[] GetValues(uint count, uint[] indices, uint start)
        {
            DEBUG_VALUE[] values;
            TryGetValues(count, indices, start, out values).ThrowDbgEngNotOk();

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
        public HRESULT TryGetValues(uint count, uint[] indices, uint start, out DEBUG_VALUE[] values)
        {
            InitDelegate(ref getValues, Vtbl->GetValues);
            /*HRESULT GetValues(
            [In] uint Count,
            [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] uint[] Indices,
            [In] uint Start,
            [Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] DEBUG_VALUE[] Values);*/
            values = new DEBUG_VALUE[(int) count];
            HRESULT hr = getValues(Raw, count, indices, start, values);

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
        public void SetValues(uint count, uint[] indices, uint start, DEBUG_VALUE[] values)
        {
            TrySetValues(count, indices, start, values).ThrowDbgEngNotOk();
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
        public HRESULT TrySetValues(uint count, uint[] indices, uint start, DEBUG_VALUE[] values)
        {
            InitDelegate(ref setValues, Vtbl->SetValues);

            /*HRESULT SetValues(
            [In] uint Count,
            [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] uint[] Indices,
            [In] uint Start,
            [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] DEBUG_VALUE[] Values);*/
            return setValues(Raw, count, indices, start, values);
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
        ///cref="OutputRegisters2"/> performs the same task as this method but also allows the register source
        /// to be specified. For an overview of the <see cref="IDebugRegisters"/> interface and other register-related methods,
        /// see Registers. For details on sending output to the clients, see Input and Output.
        /// </remarks>
        public void OutputRegisters(DEBUG_OUTCTL outputControl, DEBUG_REGISTERS flags)
        {
            TryOutputRegisters(outputControl, flags).ThrowDbgEngNotOk();
        }

        /// <summary>
        /// The OutputRegisters method formats and sends the target's registers to the clients as output.
        /// </summary>
        /// <param name="outputControl">[in] Specifies which clients should be sent the output of the formatted registers. See DEBUG_OUTCTL_XXX for possible values.</param>
        /// <param name="flags">[in] Specifies which set of registers to print. This can either be DEBUG_REGISTERS_DEFAULT to print commonly used registers, DEBUG_REGISTERS_ALL to print all the sets of registers, or a combination of the values listed in the following table.</param>
        /// <returns>This list does not contain all the errors that might occur. For a list of possible errors, see HRESULT Values.</returns>
        /// <remarks>
        /// The registers are formatted in a way that is specific to the target architecture's register set. The method <see 
        ///cref="OutputRegisters2"/> performs the same task as this method but also allows the register source
        /// to be specified. For an overview of the <see cref="IDebugRegisters"/> interface and other register-related methods,
        /// see Registers. For details on sending output to the clients, see Input and Output.
        /// </remarks>
        public HRESULT TryOutputRegisters(DEBUG_OUTCTL outputControl, DEBUG_REGISTERS flags)
        {
            InitDelegate(ref outputRegisters, Vtbl->OutputRegisters);

            /*HRESULT OutputRegisters(
            [In] DEBUG_OUTCTL OutputControl,
            [In] DEBUG_REGISTERS Flags);*/
            return outputRegisters(Raw, outputControl, flags);
        }

        #endregion
        #endregion
        #region IDebugRegisters2
        #region NumberPseudoRegisters

        /// <summary>
        /// The GetNumberPseudoRegisters method returns the number of pseudo-registers that are maintained by the debugger engine.
        /// </summary>
        public uint NumberPseudoRegisters
        {
            get
            {
                uint number;
                TryGetNumberPseudoRegisters(out number).ThrowDbgEngNotOk();

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
        public HRESULT TryGetNumberPseudoRegisters(out uint number)
        {
            InitDelegate(ref getNumberPseudoRegisters, Vtbl2->GetNumberPseudoRegisters);

            /*HRESULT GetNumberPseudoRegisters(
            [Out] out uint Number);*/
            return getNumberPseudoRegisters(Raw, out number);
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
        public GetDescriptionWideResult GetDescriptionWide(uint register)
        {
            GetDescriptionWideResult result;
            TryGetDescriptionWide(register, out result).ThrowDbgEngNotOk();

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
        public HRESULT TryGetDescriptionWide(uint register, out GetDescriptionWideResult result)
        {
            InitDelegate(ref getDescriptionWide, Vtbl2->GetDescriptionWide);
            /*HRESULT GetDescriptionWide(
            [In] uint Register,
            [Out, MarshalAs(UnmanagedType.LPWStr)]
            StringBuilder NameBuffer,
            [In] int NameBufferSize,
            [Out] out uint NameSize,
            [Out] out DEBUG_REGISTER_DESCRIPTION Desc);*/
            StringBuilder nameBuffer;
            int nameBufferSize = 0;
            uint nameSize;
            DEBUG_REGISTER_DESCRIPTION desc;
            HRESULT hr = getDescriptionWide(Raw, register, null, nameBufferSize, out nameSize, out desc);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER && hr != HRESULT.S_OK)
                goto fail;

            nameBufferSize = (int) nameSize;
            nameBuffer = new StringBuilder(nameBufferSize);
            hr = getDescriptionWide(Raw, register, nameBuffer, nameBufferSize, out nameSize, out desc);

            if (hr == HRESULT.S_OK)
            {
                result = new GetDescriptionWideResult(nameBuffer.ToString(), desc);

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
        public uint GetIndexByNameWide(string name)
        {
            uint index;
            TryGetIndexByNameWide(name, out index).ThrowDbgEngNotOk();

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
        public HRESULT TryGetIndexByNameWide(string name, out uint index)
        {
            InitDelegate(ref getIndexByNameWide, Vtbl2->GetIndexByNameWide);

            /*HRESULT GetIndexByNameWide(
            [In, MarshalAs(UnmanagedType.LPWStr)] string Name,
            [Out] out uint Index);*/
            return getIndexByNameWide(Raw, name, out index);
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
        public GetPseudoDescriptionResult GetPseudoDescription(uint register)
        {
            GetPseudoDescriptionResult result;
            TryGetPseudoDescription(register, out result).ThrowDbgEngNotOk();

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
        public HRESULT TryGetPseudoDescription(uint register, out GetPseudoDescriptionResult result)
        {
            InitDelegate(ref getPseudoDescription, Vtbl2->GetPseudoDescription);
            /*HRESULT GetPseudoDescription(
            [In] uint Register,
            [Out, MarshalAs(UnmanagedType.LPStr)] StringBuilder NameBuffer,
            [In] int NameBufferSize,
            [Out] out uint NameSize,
            [Out] out ulong TypeModule,
            [Out] out uint TypeId);*/
            StringBuilder nameBuffer;
            int nameBufferSize = 0;
            uint nameSize;
            ulong typeModule;
            uint typeId;
            HRESULT hr = getPseudoDescription(Raw, register, null, nameBufferSize, out nameSize, out typeModule, out typeId);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER && hr != HRESULT.S_OK)
                goto fail;

            nameBufferSize = (int) nameSize;
            nameBuffer = new StringBuilder(nameBufferSize);
            hr = getPseudoDescription(Raw, register, nameBuffer, nameBufferSize, out nameSize, out typeModule, out typeId);

            if (hr == HRESULT.S_OK)
            {
                result = new GetPseudoDescriptionResult(nameBuffer.ToString(), typeModule, typeId);

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
        public GetPseudoDescriptionWideResult GetPseudoDescriptionWide(uint register)
        {
            GetPseudoDescriptionWideResult result;
            TryGetPseudoDescriptionWide(register, out result).ThrowDbgEngNotOk();

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
        public HRESULT TryGetPseudoDescriptionWide(uint register, out GetPseudoDescriptionWideResult result)
        {
            InitDelegate(ref getPseudoDescriptionWide, Vtbl2->GetPseudoDescriptionWide);
            /*HRESULT GetPseudoDescriptionWide(
            [In] uint Register,
            [Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder NameBuffer,
            [In] int NameBufferSize,
            [Out] out uint NameSize,
            [Out] out ulong TypeModule,
            [Out] out uint TypeId);*/
            StringBuilder nameBuffer;
            int nameBufferSize = 0;
            uint nameSize;
            ulong typeModule;
            uint typeId;
            HRESULT hr = getPseudoDescriptionWide(Raw, register, null, nameBufferSize, out nameSize, out typeModule, out typeId);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER && hr != HRESULT.S_OK)
                goto fail;

            nameBufferSize = (int) nameSize;
            nameBuffer = new StringBuilder(nameBufferSize);
            hr = getPseudoDescriptionWide(Raw, register, nameBuffer, nameBufferSize, out nameSize, out typeModule, out typeId);

            if (hr == HRESULT.S_OK)
            {
                result = new GetPseudoDescriptionWideResult(nameBuffer.ToString(), typeModule, typeId);

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
        public uint GetPseudoIndexByName(string name)
        {
            uint index;
            TryGetPseudoIndexByName(name, out index).ThrowDbgEngNotOk();

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
        public HRESULT TryGetPseudoIndexByName(string name, out uint index)
        {
            InitDelegate(ref getPseudoIndexByName, Vtbl2->GetPseudoIndexByName);

            /*HRESULT GetPseudoIndexByName(
            [In, MarshalAs(UnmanagedType.LPStr)] string Name,
            [Out] out uint Index);*/
            return getPseudoIndexByName(Raw, name, out index);
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
        public uint GetPseudoIndexByNameWide(string name)
        {
            uint index;
            TryGetPseudoIndexByNameWide(name, out index).ThrowDbgEngNotOk();

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
        public HRESULT TryGetPseudoIndexByNameWide(string name, out uint index)
        {
            InitDelegate(ref getPseudoIndexByNameWide, Vtbl2->GetPseudoIndexByNameWide);

            /*HRESULT GetPseudoIndexByNameWide(
            [In, MarshalAs(UnmanagedType.LPWStr)] string Name,
            [Out] out uint Index);*/
            return getPseudoIndexByNameWide(Raw, name, out index);
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
        public DEBUG_VALUE[] GetPseudoValues(DEBUG_REGSRC source, uint count, uint[] indices, uint start)
        {
            DEBUG_VALUE[] values;
            TryGetPseudoValues(source, count, indices, start, out values).ThrowDbgEngNotOk();

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
        public HRESULT TryGetPseudoValues(DEBUG_REGSRC source, uint count, uint[] indices, uint start, out DEBUG_VALUE[] values)
        {
            InitDelegate(ref getPseudoValues, Vtbl2->GetPseudoValues);
            /*HRESULT GetPseudoValues(
            [In] DEBUG_REGSRC Source,
            [In] uint Count,
            [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)]
            uint[] Indices,
            [In] uint Start,
            [Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)]
            DEBUG_VALUE[] Values);*/
            values = new DEBUG_VALUE[(int) count];
            HRESULT hr = getPseudoValues(Raw, source, count, indices, start, values);

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
        public void SetPseudoValues(DEBUG_REGSRC source, uint count, uint[] indices, uint start, DEBUG_VALUE[] values)
        {
            TrySetPseudoValues(source, count, indices, start, values).ThrowDbgEngNotOk();
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
        public HRESULT TrySetPseudoValues(DEBUG_REGSRC source, uint count, uint[] indices, uint start, DEBUG_VALUE[] values)
        {
            InitDelegate(ref setPseudoValues, Vtbl2->SetPseudoValues);

            /*HRESULT SetPseudoValues(
            [In] DEBUG_REGSRC Source,
            [In] uint Count,
            [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)]
            uint[] Indices,
            [In] uint Start,
            [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)]
            DEBUG_VALUE[] Values);*/
            return setPseudoValues(Raw, source, count, indices, start, values);
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
        ///cref="GetValues"/> performs the same task as this method but always uses the target as the register source. For
        /// an overview of the <see cref="IDebugRegisters"/> interface and other register-related methods, see Registers.
        /// </remarks>
        public DEBUG_VALUE[] GetValues2(DEBUG_REGSRC source, uint count, uint[] indices, uint start)
        {
            DEBUG_VALUE[] values;
            TryGetValues2(source, count, indices, start, out values).ThrowDbgEngNotOk();

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
        /// <returns>This list does not contain all the erros that might occur. For a list of possible errors, see HRESULT Values.</returns>
        /// <remarks>
        /// If the return value is not S_OK, some of the registers still might have been read. If the target was not accessible,
        /// the return type is E_UNEXPECTED and Values is unchanged. Otherwise, Values will contain partial results and the
        /// registers that could not be read will have type DEBUG_VALUE_INVALID. Ambiguity in the case of the return value
        /// E_UNEXPECTED can be avoided by setting the memory of Values to zero before calling this method. The method <see 
        ///cref="GetValues"/> performs the same task as this method but always uses the target as the register source. For
        /// an overview of the <see cref="IDebugRegisters"/> interface and other register-related methods, see Registers.
        /// </remarks>
        public HRESULT TryGetValues2(DEBUG_REGSRC source, uint count, uint[] indices, uint start, out DEBUG_VALUE[] values)
        {
            InitDelegate(ref getValues2, Vtbl2->GetValues2);
            /*HRESULT GetValues2(
            [In] DEBUG_REGSRC Source,
            [In] uint Count,
            [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)]
            uint[] Indices,
            [In] uint Start,
            [Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)]
            DEBUG_VALUE[] Values);*/
            values = new DEBUG_VALUE[(int) count];
            HRESULT hr = getValues2(Raw, source, count, indices, start, values);

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
        public void SetValues2(DEBUG_REGSRC source, uint count, uint[] indices, uint start, DEBUG_VALUE[] values)
        {
            TrySetValues2(source, count, indices, start, values).ThrowDbgEngNotOk();
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
        public HRESULT TrySetValues2(DEBUG_REGSRC source, uint count, uint[] indices, uint start, DEBUG_VALUE[] values)
        {
            InitDelegate(ref setValues2, Vtbl2->SetValues2);

            /*HRESULT SetValues2(
            [In] DEBUG_REGSRC Source,
            [In] uint Count,
            [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)]
            uint[] Indices,
            [In] uint Start,
            [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)]
            DEBUG_VALUE[] Values);*/
            return setValues2(Raw, source, count, indices, start, values);
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
        ///cref="OutputRegisters"/> performs the same task as this method but always uses the target as the register source.
        /// For an overview of the <see cref="IDebugRegisters"/> interface and other register-related methods, see Registers.
        /// </remarks>
        public void OutputRegisters2(DEBUG_OUTCTL outputControl, DEBUG_REGSRC source, DEBUG_REGISTERS flags)
        {
            TryOutputRegisters2(outputControl, source, flags).ThrowDbgEngNotOk();
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
        ///cref="OutputRegisters"/> performs the same task as this method but always uses the target as the register source.
        /// For an overview of the <see cref="IDebugRegisters"/> interface and other register-related methods, see Registers.
        /// </remarks>
        public HRESULT TryOutputRegisters2(DEBUG_OUTCTL outputControl, DEBUG_REGSRC source, DEBUG_REGISTERS flags)
        {
            InitDelegate(ref outputRegisters2, Vtbl2->OutputRegisters2);

            /*HRESULT OutputRegisters2(
            [In] DEBUG_OUTCTL OutputControl,
            [In] DEBUG_REGSRC Source,
            [In] DEBUG_REGISTERS Flags);*/
            return outputRegisters2(Raw, outputControl, source, flags);
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
        public ulong GetInstructionOffset2(DEBUG_REGSRC source)
        {
            ulong offset;
            TryGetInstructionOffset2(source, out offset).ThrowDbgEngNotOk();

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
        public HRESULT TryGetInstructionOffset2(DEBUG_REGSRC source, out ulong offset)
        {
            InitDelegate(ref getInstructionOffset2, Vtbl2->GetInstructionOffset2);

            /*HRESULT GetInstructionOffset2(
            [In] DEBUG_REGSRC Source,
            [Out] out ulong Offset);*/
            return getInstructionOffset2(Raw, source, out offset);
        }

        #endregion
        #region GetStackOffset2

        /// <summary>
        /// The GetStackOffset2 method returns the current thread's current stack location.
        /// </summary>
        /// <param name="source">[in] Specifies the register source to query. The possible values are listed in the following table.</param>
        /// <returns>[out] Receives the location in the process's virtual address space of the current thread's current stack.</returns>
        public ulong GetStackOffset2(DEBUG_REGSRC source)
        {
            ulong offset;
            TryGetStackOffset2(source, out offset).ThrowDbgEngNotOk();

            return offset;
        }

        /// <summary>
        /// The GetStackOffset2 method returns the current thread's current stack location.
        /// </summary>
        /// <param name="source">[in] Specifies the register source to query. The possible values are listed in the following table.</param>
        /// <param name="offset">[out] Receives the location in the process's virtual address space of the current thread's current stack.</param>
        /// <returns>This list does not contain all the errors that might occur. For a list of possible errors, see HRESULT Values.</returns>
        public HRESULT TryGetStackOffset2(DEBUG_REGSRC source, out ulong offset)
        {
            InitDelegate(ref getStackOffset2, Vtbl2->GetStackOffset2);

            /*HRESULT GetStackOffset2(
            [In] DEBUG_REGSRC Source,
            [Out] out ulong Offset);*/
            return getStackOffset2(Raw, source, out offset);
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
        public ulong GetFrameOffset2(DEBUG_REGSRC source)
        {
            ulong offset;
            TryGetFrameOffset2(source, out offset).ThrowDbgEngNotOk();

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
        public HRESULT TryGetFrameOffset2(DEBUG_REGSRC source, out ulong offset)
        {
            InitDelegate(ref getFrameOffset2, Vtbl2->GetFrameOffset2);

            /*HRESULT GetFrameOffset2(
            [In] DEBUG_REGSRC Source,
            [Out] out ulong Offset);*/
            return getFrameOffset2(Raw, source, out offset);
        }

        #endregion
        #endregion
        #region Cached Delegates
        #region IDebugRegisters

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private GetNumberRegistersDelegate getNumberRegisters;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private GetInstructionOffsetDelegate getInstructionOffset;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private GetStackOffsetDelegate getStackOffset;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private GetFrameOffsetDelegate getFrameOffset;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private GetDescriptionDelegate getDescription;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private GetIndexByNameDelegate getIndexByName;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private GetValueDelegate getValue;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private SetValueDelegate setValue;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private GetValuesDelegate getValues;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private SetValuesDelegate setValues;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private OutputRegistersDelegate outputRegisters;

        #endregion
        #region IDebugRegisters2

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private GetNumberPseudoRegistersDelegate getNumberPseudoRegisters;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private GetDescriptionWideDelegate getDescriptionWide;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private GetIndexByNameWideDelegate getIndexByNameWide;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private GetPseudoDescriptionDelegate getPseudoDescription;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private GetPseudoDescriptionWideDelegate getPseudoDescriptionWide;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private GetPseudoIndexByNameDelegate getPseudoIndexByName;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private GetPseudoIndexByNameWideDelegate getPseudoIndexByNameWide;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private GetPseudoValuesDelegate getPseudoValues;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private SetPseudoValuesDelegate setPseudoValues;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private GetValues2Delegate getValues2;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private SetValues2Delegate setValues2;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private OutputRegisters2Delegate outputRegisters2;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private GetInstructionOffset2Delegate getInstructionOffset2;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private GetStackOffset2Delegate getStackOffset2;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private GetFrameOffset2Delegate getFrameOffset2;

        #endregion
        #endregion
        #region Delegates
        #region IDebugRegisters

        private delegate HRESULT GetNumberRegistersDelegate(IntPtr self, [Out] out uint Number);
        private delegate HRESULT GetInstructionOffsetDelegate(IntPtr self, [Out] out ulong Offset);
        private delegate HRESULT GetStackOffsetDelegate(IntPtr self, [Out] out ulong Offset);
        private delegate HRESULT GetFrameOffsetDelegate(IntPtr self, [Out] out ulong Offset);
        private delegate HRESULT GetDescriptionDelegate(IntPtr self, [In] uint Register, [Out, MarshalAs(UnmanagedType.LPStr)] StringBuilder NameBuffer, [In] int NameBufferSize, [Out] out uint NameSize, [Out] out DEBUG_REGISTER_DESCRIPTION Desc);
        private delegate HRESULT GetIndexByNameDelegate(IntPtr self, [In, MarshalAs(UnmanagedType.LPStr)] string Name, [Out] out uint Index);
        private delegate HRESULT GetValueDelegate(IntPtr self, [In] uint Register, [Out] out DEBUG_VALUE Value);
        private delegate HRESULT SetValueDelegate(IntPtr self, [In] uint Register, [In] DEBUG_VALUE Value);
        private delegate HRESULT GetValuesDelegate(IntPtr self, [In] uint Count, [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] uint[] Indices, [In] uint Start, [Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] DEBUG_VALUE[] Values);
        private delegate HRESULT SetValuesDelegate(IntPtr self, [In] uint Count, [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] uint[] Indices, [In] uint Start, [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] DEBUG_VALUE[] Values);
        private delegate HRESULT OutputRegistersDelegate(IntPtr self, [In] DEBUG_OUTCTL OutputControl, [In] DEBUG_REGISTERS Flags);

        #endregion
        #region IDebugRegisters2

        private delegate HRESULT GetNumberPseudoRegistersDelegate(IntPtr self, [Out] out uint Number);
        private delegate HRESULT GetDescriptionWideDelegate(IntPtr self, [In] uint Register, [Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder NameBuffer, [In] int NameBufferSize, [Out] out uint NameSize, [Out] out DEBUG_REGISTER_DESCRIPTION Desc);
        private delegate HRESULT GetIndexByNameWideDelegate(IntPtr self, [In, MarshalAs(UnmanagedType.LPWStr)] string Name, [Out] out uint Index);
        private delegate HRESULT GetPseudoDescriptionDelegate(IntPtr self, [In] uint Register, [Out, MarshalAs(UnmanagedType.LPStr)] StringBuilder NameBuffer, [In] int NameBufferSize, [Out] out uint NameSize, [Out] out ulong TypeModule, [Out] out uint TypeId);
        private delegate HRESULT GetPseudoDescriptionWideDelegate(IntPtr self, [In] uint Register, [Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder NameBuffer, [In] int NameBufferSize, [Out] out uint NameSize, [Out] out ulong TypeModule, [Out] out uint TypeId);
        private delegate HRESULT GetPseudoIndexByNameDelegate(IntPtr self, [In, MarshalAs(UnmanagedType.LPStr)] string Name, [Out] out uint Index);
        private delegate HRESULT GetPseudoIndexByNameWideDelegate(IntPtr self, [In, MarshalAs(UnmanagedType.LPWStr)] string Name, [Out] out uint Index);
        private delegate HRESULT GetPseudoValuesDelegate(IntPtr self, [In] DEBUG_REGSRC Source, [In] uint Count, [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] uint[] Indices, [In] uint Start, [Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] DEBUG_VALUE[] Values);
        private delegate HRESULT SetPseudoValuesDelegate(IntPtr self, [In] DEBUG_REGSRC Source, [In] uint Count, [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] uint[] Indices, [In] uint Start, [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] DEBUG_VALUE[] Values);
        private delegate HRESULT GetValues2Delegate(IntPtr self, [In] DEBUG_REGSRC Source, [In] uint Count, [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] uint[] Indices, [In] uint Start, [Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] DEBUG_VALUE[] Values);
        private delegate HRESULT SetValues2Delegate(IntPtr self, [In] DEBUG_REGSRC Source, [In] uint Count, [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] uint[] Indices, [In] uint Start, [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] DEBUG_VALUE[] Values);
        private delegate HRESULT OutputRegisters2Delegate(IntPtr self, [In] DEBUG_OUTCTL OutputControl, [In] DEBUG_REGSRC Source, [In] DEBUG_REGISTERS Flags);
        private delegate HRESULT GetInstructionOffset2Delegate(IntPtr self, [In] DEBUG_REGSRC Source, [Out] out ulong Offset);
        private delegate HRESULT GetStackOffset2Delegate(IntPtr self, [In] DEBUG_REGSRC Source, [Out] out ulong Offset);
        private delegate HRESULT GetFrameOffset2Delegate(IntPtr self, [In] DEBUG_REGSRC Source, [Out] out ulong Offset);

        #endregion
        #endregion
    }
}
