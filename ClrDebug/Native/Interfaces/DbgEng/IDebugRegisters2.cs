using System.Runtime.InteropServices;
using System.Text;

namespace ClrDebug.DbgEng
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("1656afa9-19c6-4e3a-97e7-5dc9160cf9c4")]
    [ComImport]
    public interface IDebugRegisters2 : IDebugRegisters
    {
        #region IDebugRegisters

        /// <summary>
        /// The GetNumberRegisters method returns the number of registers on the target computer.
        /// </summary>
        /// <param name="Number">[out] Receives the number of registers on the target's computer.</param>
        /// <returns>This list does not contain all the errors that might occur. For a list of possible errors, see HRESULT Values.</returns>
        /// <remarks>
        /// For an overview of the <see cref="IDebugRegisters"/> interface and other register-related methods, see Registers.
        /// </remarks>
        [PreserveSig]
        new HRESULT GetNumberRegisters(
            [Out] out uint Number);

        /// <summary>
        /// The GetDescription method returns the description of a register.
        /// </summary>
        /// <param name="Register">[in] Specifies the index of the register for which the description is requested.</param>
        /// <param name="NameBuffer">[out, optional] Specifies the buffer in which to store the name of the register. If NameBuffer is NULL, this information is not returned.</param>
        /// <param name="NameBufferSize">[in] Specifies the size, in characters, of the buffer that NameBuffer specifies. This size includes the space for the '\0' terminating character.</param>
        /// <param name="NameSize">[out, optional] Receives the size, in characters, of the register's name in NameBuffer buffer. This size includes the space for the '\0' terminating character.<para/>
        /// If NameSize is NULL, this information is not returned.</param>
        /// <param name="Desc">[out, optional] Receives the description of the register. See <see cref="DEBUG_REGISTER_DESCRIPTION"/> for more details.</param>
        /// <returns>This list does not contain all the errors that might occur. For a list of possible errors, see HRESULT Values.</returns>
        /// <remarks>
        /// For an overview of the <see cref="IDebugRegisters"/> interface and other register-related methods, see Registers.
        /// </remarks>
        [PreserveSig]
        new HRESULT GetDescription(
            [In] uint Register,
            [Out, MarshalAs(UnmanagedType.LPStr)] StringBuilder NameBuffer,
            [In] int NameBufferSize,
            [Out] out uint NameSize,
            [Out] out DEBUG_REGISTER_DESCRIPTION Desc);

        /// <summary>
        /// The GetIndexByName method returns the index of the named register.
        /// </summary>
        /// <param name="Name">[in] Specifies the name of the register whose index is requested.</param>
        /// <param name="Index">[out] Receives the index of the register.</param>
        /// <returns>This list does not contain all the errors that might occur. For a list of possible errors, see HRESULT Values.</returns>
        /// <remarks>
        /// For an overview of the <see cref="IDebugRegisters"/> interface and other register-related methods, see Registers.
        /// </remarks>
        [PreserveSig]
        new HRESULT GetIndexByName(
            [In, MarshalAs(UnmanagedType.LPStr)] string Name,
            [Out] out uint Index);

        /// <summary>
        /// The GetValue method gets the value of one of the target's registers.
        /// </summary>
        /// <param name="Register">[in] Specifies the index of the register whose value is requested.</param>
        /// <param name="Value">[out] Receives the value of the register. See <see cref="DEBUG_VALUE"/> for a description of this parameter type.</param>
        /// <returns>This list does not contain all the errors that might occur. For a list of possible errors, see HRESULT Values.</returns>
        /// <remarks>
        /// To receive the values of multiple registers, use the <see cref="GetValues"/> method instead. For an overview of
        /// the <see cref="IDebugRegisters"/> interface and other register-related methods, see Registers.
        /// </remarks>
        [PreserveSig]
        new HRESULT GetValue(
            [In] uint Register,
            [Out] out DEBUG_VALUE Value);

        /// <summary>
        /// The SetValue method sets the value of one of the target's registers.
        /// </summary>
        /// <param name="Register">[in] Specifies the index of the register whose value is to be set.</param>
        /// <param name="Value">[in] Specifies the value to which to set the register. See <see cref="DEBUG_VALUE"/> for a description of this parameter type.</param>
        /// <returns>This list does not contain all the errors that might occur. For a list of possible errors, see HRESULT Values.</returns>
        /// <remarks>
        /// The engine does its best to coerce the value of Value into the type of the register; this coercion is the same
        /// as that performed by <see cref="IDebugControl.CoerceValue"/>. If the value is larger than what the register can
        /// hold, the least significant bits are dropped. Floating-point and integer conversions will also be performed if
        /// necessary. When a subregister is altered, the register containing it is also altered. To set the values of multiple
        /// registers, use the <see cref="SetValues"/> method instead. For an overview of the <see cref="IDebugRegisters"/>
        /// interface and other register-related methods, see Registers.
        /// </remarks>
        [PreserveSig]
        new HRESULT SetValue(
            [In] uint Register,
            [In] DEBUG_VALUE Value);

        /// <summary>
        /// The GetValues method gets the value of several of the target's registers.
        /// </summary>
        /// <param name="Count">[in] Specifies the number of registers whose values are requested.</param>
        /// <param name="Indices">[in, optional] Specifies an array that contains the indices of the registers from which to get the values. The number of elements in this array is Count.<para/>
        /// If Indices is NULL, Start is used instead.</param>
        /// <param name="Start">[in] If Indices is NULL, the registers will be read consecutively starting at this index. Otherwise it is ignored.</param>
        /// <param name="Values">[out] Receives the values of the registers. The number of elements this array holds is Count. See <see cref="DEBUG_VALUE"/> for a description of this parameter type.</param>
        /// <returns>This list does not contain all the errors that might occur. For a list of possible errors, see HRESULT Values.</returns>
        /// <remarks>
        /// GetValues gets the value of several of the target's registers. If the return value is not S_OK, some of the registers
        /// still might have been read. If the target was not accessible, the return type is E_UNEXPECTED and Values is unchanged;
        /// otherwise, Values will contain partial results and the registers that could not be read will have type DEBUG_VALUE_INVALID.
        /// Ambiguity in the case of the return value E_UNEXPECTED can be avoided by setting the memory of Values to zero before
        /// calling this method. To receive the value of only a single register, use the GetValue method instead. The method
        /// <see cref="GetValues2"/> performs the same task as this method but also allows the register source to be specified.
        /// For an overview of the <see cref="IDebugRegisters"/> interface and other register-related methods, see Registers.
        /// </remarks>
        [PreserveSig]
        new HRESULT GetValues(
            [In] uint Count,
            [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] uint[] Indices,
            [In] uint Start,
            [Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] DEBUG_VALUE[] Values);

        /// <summary>
        /// The SetValues method sets the value of several of the target's registers.
        /// </summary>
        /// <param name="Count">[in] Specifies the number of registers for which to set the values.</param>
        /// <param name="Indices">[in, optional] Specifies an array that contains the indices of the registers for which to set the values. The number of elements in this array is Count.<para/>
        /// If Indices is NULL, Start is used instead.</param>
        /// <param name="Start">[in] If Indices is NULL, the registers will be set consecutively starting at this index. Otherwise it is ignored.</param>
        /// <param name="Values">[in] Specifies the array that contains values to which to set the registers. The number of elements this array holds is Count.<para/>
        /// See <see cref="DEBUG_VALUE"/> for a description of this parameter type.</param>
        /// <returns>This list does not contain all the errors that might occur. For a list of possible errors, see HRESULT Values.</returns>
        /// <remarks>
        /// The engine does its best to coerce the values in Values into the type of the registers; this coercion is the same
        /// as that performed by <see cref="IDebugControl.CoerceValue"/>. If the value is larger than what the register can
        /// hold, the least significant bits are dropped. Floating-point and integer conversions will also be performed if
        /// necessary. If the return value is not S_OK, some of the registers still might have been set. When a subregister
        /// is altered, the register containing it is also altered. To set the value of only a single register, use the SetValue
        /// method instead. The method <see cref="SetValues2"/> performs the same task as this method but also allows the register
        /// source to be specified. For an overview of the <see cref="IDebugRegisters"/> interface and other register-related
        /// methods, see Registers.
        /// </remarks>
        [PreserveSig]
        new HRESULT SetValues(
            [In] uint Count,
            [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)]
            uint[] Indices,
            [In] uint Start,
            [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)]
            DEBUG_VALUE[] Values);

        /// <summary>
        /// The OutputRegisters method formats and sends the target's registers to the clients as output.
        /// </summary>
        /// <param name="OutputControl">[in] Specifies which clients should be sent the output of the formatted registers. See DEBUG_OUTCTL_XXX for possible values.</param>
        /// <param name="Flags">[in] Specifies which set of registers to print. This can either be DEBUG_REGISTERS_DEFAULT to print commonly used registers, DEBUG_REGISTERS_ALL to print all the sets of registers, or a combination of the values listed in the following table.</param>
        /// <returns>This list does not contain all the errors that might occur. For a list of possible errors, see HRESULT Values.</returns>
        /// <remarks>
        /// The registers are formatted in a way that is specific to the target architecture's register set. The method <see
        /// cref="OutputRegisters2"/> performs the same task as this method but also allows the register source to be specified.
        /// For an overview of the <see cref="IDebugRegisters"/> interface and other register-related methods, see Registers.
        /// For details on sending output to the clients, see Input and Output.
        /// </remarks>
        [PreserveSig]
        new HRESULT OutputRegisters(
            [In] DEBUG_OUTCTL OutputControl,
            [In] DEBUG_REGISTERS Flags);

        /// <summary>
        /// The GetInstructionOffset method returns the location of the current thread's current instruction.
        /// </summary>
        /// <param name="Offset">[out] Receives the location in the target's virtual address space of the target's current instruction.</param>
        /// <returns>This list does not contain all the errors that might occur. For a list of possible errors, see HRESULT Values.</returns>
        /// <remarks>
        /// The meaning of the value returned by this method is architecture-dependent. In particular, for an Itanium processor,
        /// the virtual address returned can indicate an address within a bundle. The method <see cref="GetInstructionOffset2"/>
        /// performs the same task as this method but also allows the register source to be specified. For an overview of the
        /// <see cref="IDebugRegisters"/> interface and other register-related methods, see Registers.
        /// </remarks>
        [PreserveSig]
        new HRESULT GetInstructionOffset(
            [Out] out ulong Offset);

        /// <summary>
        /// The GetStackOffset method returns the current thread's current stack location.
        /// </summary>
        /// <param name="Offset">[out] Receives the location in the process's virtual address space of the current thread's current stack location.</param>
        /// <returns>This list does not contain all the errors that might occur. For a list of possible errors, see HRESULT Values.</returns>
        /// <remarks>
        /// The meaning of value returned by this method is architecture specific. The method <see cref="GetStackOffset2"/>
        /// performs the same task as this method but also allows the register source to be specified. For an overview of the
        /// <see cref="IDebugRegisters"/> interface and other register-related methods, see Registers.
        /// </remarks>
        [PreserveSig]
        new HRESULT GetStackOffset(
            [Out] out ulong Offset);

        /// <summary>
        /// The GetFrameOffset method returns the location of the stack frame for the current function.
        /// </summary>
        /// <param name="Offset">[out] The location in the target's virtual address space of the stack frame for the current function.</param>
        /// <returns>This list does not contain all the errors that might occur. For a list of possible errors, see HRESULT Values.</returns>
        /// <remarks>
        /// The meaning of value returned by this method is architecture-specific. The method <see cref="GetFrameOffset2"/>
        /// performs the same task as this method but also allows the register source to be specified. For an overview of the
        /// <see cref="IDebugRegisters"/> interface and other register-related methods, see Registers.
        /// </remarks>
        [PreserveSig]
        new HRESULT GetFrameOffset(
            [Out] out ulong Offset);

        #endregion
        #region IDebugRegisters2

        /// <summary>
        /// The GetDescriptionWide method returns the description of a register.
        /// </summary>
        /// <param name="Register">[in] Specifies the index of the register for which the description is requested.</param>
        /// <param name="NameBuffer">[out, optional] Specifies the buffer in which to store the name of the register. If NameBuffer is NULL, this information is not returned.</param>
        /// <param name="NameBufferSize">[in] Specifies the size, in characters, of the buffer that NameBuffer specifies. This size includes the space for the '\0' terminating character.</param>
        /// <param name="NameSize">[out, optional] Receives the size, in characters, of the register's name in NameBuffer buffer. This size includes the space for the '\0' terminating character.<para/>
        /// If NameSize is NULL, this information is not returned.</param>
        /// <param name="Desc">[out, optional] Receives the description of the register. See <see cref="DEBUG_REGISTER_DESCRIPTION"/> for more details.</param>
        /// <returns>This list does not contain all the errors that might occur. For a list of possible errors, see HRESULT Values.</returns>
        /// <remarks>
        /// For an overview of the <see cref="IDebugRegisters"/> interface and other register-related methods, see Registers.
        /// </remarks>
        [PreserveSig]
        HRESULT GetDescriptionWide(
            [In] uint Register,
            [Out, MarshalAs(UnmanagedType.LPWStr)]
            StringBuilder NameBuffer,
            [In] int NameBufferSize,
            [Out] out uint NameSize,
            [Out] out DEBUG_REGISTER_DESCRIPTION Desc);

        /// <summary>
        /// The GetIndexByNameWide method returns the index of the named register.
        /// </summary>
        /// <param name="Name">[in] Specifies the name of the register whose index is requested.</param>
        /// <param name="Index">[out] Receives the index of the register.</param>
        /// <returns>This list does not contain all the errors that might occur. For a list of possible errors, see HRESULT Values.</returns>
        /// <remarks>
        /// For an overview of the <see cref="IDebugRegisters"/> interface and other register-related methods, see Registers.
        /// </remarks>
        [PreserveSig]
        HRESULT GetIndexByNameWide(
            [In, MarshalAs(UnmanagedType.LPWStr)] string Name,
            [Out] out uint Index);

        /// <summary>
        /// The GetNumberPseudoRegisters method returns the number of pseudo-registers that are maintained by the debugger engine.
        /// </summary>
        /// <param name="Number">[out] Receives the number of pseudo-registers that are maintained by the debugger engine.</param>
        /// <returns>This list does not contain all the errors that might occur. For a list of possible errors, see HRESULT Values.</returns>
        /// <remarks>
        /// Not all of the pseudo-registers are available in all debugging sessions or at all times in a particular session.
        /// The valid indices for pseudo-registers are between zero and the number of pseudo-registers, minus one. For an overview
        /// of the <see cref="IDebugRegisters"/> interface and other register-related methods, see Registers.
        /// </remarks>
        [PreserveSig]
        HRESULT GetNumberPseudoRegisters(
            [Out] out uint Number);

        /// <summary>
        /// The GetPseudoDescription method returns a description of a pseudo-register, including its name and type.
        /// </summary>
        /// <param name="Register">[in] Specifies the index of the pseudo-register whose description is requested. The index is always between zero and the number of pseudo-registers (returned by <see cref="GetNumberPseudoRegisters"/>) minus one.</param>
        /// <param name="NameBuffer">[out, optional] Receives the name of the pseudo-register. If NameBuffer is NULL, this information is not returned.</param>
        /// <param name="NameBufferSize">[in] Specifies the size, in characters, of the buffer that NameBuffer specifies. This size includes the space for the '\0' terminating character.</param>
        /// <param name="NameSize">[out, optional] Receives the size in characters of the name of the pseudo-register. This size includes the space for the '\0' terminating character.<para/>
        /// If NameSize is NULL, this information is not returned.</param>
        /// <param name="TypeModule">[out, optional] Receives the base address of the module to which the register's type belongs. If the type of the register is not known, zero is returned.<para/>
        /// If TypeModule is NULL, no information is returned.</param>
        /// <param name="TypeId">[out, optional] Receives the type ID of the type within the module returned in TypeModule. If the type ID is not known, zero is returned.<para/>
        /// If TypeId is NULL, no information is returned.</param>
        /// <returns>This list does not contain all the errors that might occur. For a list of possible errors, see HRESULT Values.</returns>
        /// <remarks>
        /// Descriptions are not always available for all registers. If a pseudo-register does not have a value - for example,
        /// $eventip will not have a value before an event has occurred - or a type cannot be determined for a pseudo-register,
        /// this method will return E_FAIL. For an overview of the <see cref="IDebugRegisters"/> interface and other register-related
        /// methods, see Registers.
        /// </remarks>
        [PreserveSig]
        HRESULT GetPseudoDescription(
            [In] uint Register,
            [Out, MarshalAs(UnmanagedType.LPStr)] StringBuilder NameBuffer,
            [In] int NameBufferSize,
            [Out] out uint NameSize,
            [Out] out ulong TypeModule,
            [Out] out uint TypeId);

        /// <summary>
        /// The GetPseudoDescriptionWide method returns a description of a pseudo-register, including its name and type.
        /// </summary>
        /// <param name="Register">[in] Specifies the index of the pseudo-register whose description is requested. The index is always between zero and the number of pseudo-registers (returned by <see cref="GetNumberPseudoRegisters"/>) minus one.</param>
        /// <param name="NameBuffer">[out, optional] Receives the name of the pseudo-register. If NameBuffer is NULL, this information is not returned.</param>
        /// <param name="NameBufferSize">[in] Specifies the size, in characters, of the buffer that NameBuffer specifies. This size includes the space for the '\0' terminating character.</param>
        /// <param name="NameSize">[out, optional] Receives the size in characters of the name of the pseudo-register. This size includes the space for the '\0' terminating character.<para/>
        /// If NameSize is NULL, this information is not returned.</param>
        /// <param name="TypeModule">[out, optional] Receives the base address of the module to which the register's type belongs. If the type of the register is not known, zero is returned.<para/>
        /// If TypeModule is NULL, no information is returned.</param>
        /// <param name="TypeId">[out, optional] Receives the type ID of the type within the module returned in TypeModule. If the type ID is not known, zero is returned.<para/>
        /// If TypeId is NULL, no information is returned.</param>
        /// <returns>This list does not contain all the errors that might occur. For a list of possible errors, see HRESULT Values.</returns>
        /// <remarks>
        /// Descriptions are not always available for all registers. If a pseudo-register does not have a value - for example,
        /// $eventip will not have a value before an event has occurred - or a type cannot be determined for a pseudo-register,
        /// this method will return E_FAIL. For an overview of the <see cref="IDebugRegisters"/> interface and other register-related
        /// methods, see Registers.
        /// </remarks>
        [PreserveSig]
        HRESULT GetPseudoDescriptionWide(
            [In] uint Register,
            [Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder NameBuffer,
            [In] int NameBufferSize,
            [Out] out uint NameSize,
            [Out] out ulong TypeModule,
            [Out] out uint TypeId);

        /// <summary>
        /// The GetPseudoIndexByName method returns the index of a pseudo-register.
        /// </summary>
        /// <param name="Name">[in] Specifies the name of the pseudo-register whose index is requested. The name includes the leading dollar sign ( $ ), for example, "$frame".</param>
        /// <param name="Index">[out] Receives the index of the pseudo-register.</param>
        /// <returns>This list does not contain all the errors that might occur. For a list of possible errors, see HRESULT Values.</returns>
        /// <remarks>
        /// For the names of all the pseudo-registers, see Pseudo-Register Syntax. For an overview of the <see cref="IDebugRegisters"/>
        /// interface and other register-related methods, see Registers.
        /// </remarks>
        [PreserveSig]
        HRESULT GetPseudoIndexByName(
            [In, MarshalAs(UnmanagedType.LPStr)] string Name,
            [Out] out uint Index);

        /// <summary>
        /// The GetPseudoIndexByNameWide method returns the index of a pseudo-register.
        /// </summary>
        /// <param name="Name">[in] Specifies the name of the pseudo-register whose index is requested. The name includes the leading dollar sign ( $ ), for example, "$frame".</param>
        /// <param name="Index">[out] Receives the index of the pseudo-register.</param>
        /// <returns>This list does not contain all the errors that might occur. For a list of possible errors, see HRESULT Values.</returns>
        /// <remarks>
        /// For the names of all the pseudo-registers, see Pseudo-Register Syntax. For an overview of the <see cref="IDebugRegisters"/>
        /// interface and other register-related methods, see Registers.
        /// </remarks>
        [PreserveSig]
        HRESULT GetPseudoIndexByNameWide(
            [In, MarshalAs(UnmanagedType.LPWStr)] string Name,
            [Out] out uint Index);

        /// <summary>
        /// The GetPseudoValues method returns the values of a number of pseudo-registers.
        /// </summary>
        /// <param name="Source">[in] Specifies the register source to query. The possible values are listed in the following table.</param>
        /// <param name="Count">[in] Specifies the number of pseudo-registers whose values are being requested.</param>
        /// <param name="Indices">[in, optional] Specifies an array of indices of pseudo-registers whose values will be returned. The size of Indices is Count.<para/>
        /// If Indices is NULL, Start is used to specify the indices instead.</param>
        /// <param name="Start">[in] Specifies the index of the first pseudo-register whose value will be returned. The pseudo-registers, with indices between Start and Start plus Count minus one, will be returned.<para/>
        /// Start is only used if Indices is NULL.</param>
        /// <param name="Values">[out] Receives the values of the specified pseudo-registers. The number of elements that this array holds is Count.<para/>
        /// See <see cref="DEBUG_VALUE"/> for a description of this parameter type.</param>
        /// <returns>This list does not contain all the errors that might occur. For a list of possible errors, see HRESULT Values.</returns>
        /// <remarks>
        /// For an overview of the <see cref="IDebugRegisters"/> interface and other register-related methods, see Registers.
        /// </remarks>
        [PreserveSig]
        HRESULT GetPseudoValues(
            [In] DEBUG_REGSRC Source,
            [In] uint Count,
            [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)]
            uint[] Indices,
            [In] uint Start,
            [Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)]
            DEBUG_VALUE[] Values);

        /// <summary>
        /// The SetPseudoValues method sets the value of several pseudo-registers.
        /// </summary>
        /// <param name="Source">[in] Specifies the register source to query. The possible values are listed in the following table.</param>
        /// <param name="Count">[in] Specifies the number of pseudo-registers whose values are being set.</param>
        /// <param name="Indices">[in, optional] Specifies an array of indices of pseudo-registers. These are the pseudo-registers whose values will be set.<para/>
        /// The size of Indices is Count. If Indices is NULL, Start is used to specify the indices instead.</param>
        /// <param name="Start">[in] Specifies the index of the first pseudo-register whose value will be set. The pseudo-registers with indices between Start and Start plus Count minus one, will be set.<para/>
        /// Start is only used if Indices is NULL.</param>
        /// <param name="Values">[in] Specifies the new values of the pseudo-registers. The number of elements this array holds is Count. See <see cref="DEBUG_VALUE"/> for a description of this parameter type.</param>
        /// <returns>This list does not contain all the errors that might occur. For a list of possible errors, see HRESULT Values.</returns>
        /// <remarks>
        /// For an overview of the <see cref="IDebugRegisters"/> interface and other register-related methods, see Registers.
        /// </remarks>
        [PreserveSig]
        HRESULT SetPseudoValues(
            [In] DEBUG_REGSRC Source,
            [In] uint Count,
            [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)]
            uint[] Indices,
            [In] uint Start,
            [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)]
            DEBUG_VALUE[] Values);

        /// <summary>
        /// The GetValues2 method fetches the value of several of the target's registers.
        /// </summary>
        /// <param name="Source">[in] Specifies the register source to query. The possible values are listed in the following table.</param>
        /// <param name="Count">[in] Specifies the number of registers whose values are requested.</param>
        /// <param name="Indices">[in, optional] Specifies an array that contains the indices of the registers from which to get the values. The number of elements in this array is Count.<para/>
        /// If Indices is NULL, Start is used instead.</param>
        /// <param name="Start">[in] If Indices is NULL, the registers will be read consecutively starting at this index. Otherwise, it is ignored.</param>
        /// <param name="Values">[out] Receives the values of the registers. The number of elements that this array holds is Count. See <see cref="DEBUG_VALUE"/> for a description of this parameter type.</param>
        /// <returns>This list does not contain all the erros that might occur. For a list of possible errors, see HRESULT Values.</returns>
        /// <remarks>
        /// If the return value is not S_OK, some of the registers still might have been read. If the target was not accessible,
        /// the return type is E_UNEXPECTED and Values is unchanged. Otherwise, Values will contain partial results and the
        /// registers that could not be read will have type DEBUG_VALUE_INVALID. Ambiguity in the case of the return value
        /// E_UNEXPECTED can be avoided by setting the memory of Values to zero before calling this method. The method <see
        /// cref="GetValues"/> performs the same task as this method but always uses the target as the register source. For
        /// an overview of the <see cref="IDebugRegisters"/> interface and other register-related methods, see Registers.
        /// </remarks>
        [PreserveSig]
        HRESULT GetValues2(
            [In] DEBUG_REGSRC Source,
            [In] uint Count,
            [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)]
            uint[] Indices,
            [In] uint Start,
            [Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)]
            DEBUG_VALUE[] Values);

        /// <summary>
        /// The SetValues2 method sets the value of several of the target's registers.
        /// </summary>
        /// <param name="Source">[in] Specifies the register source to query. The possible values are listed in the following table.</param>
        /// <param name="Count">[in] Specifies the number of registers for which to set the values.</param>
        /// <param name="Indices">[in, optional] Specifies an array that contains the indices of the registers for which to set the values. The number of elements in this array is Count.<para/>
        /// If Indices is NULL, Start is used instead.</param>
        /// <param name="Start">[in] If Indices is NULL, the registers will be set consecutively starting at this index. Otherwise, it is ignored.</param>
        /// <param name="Values">[in] An array that contains the values to which to set the registers. The number of elements that this array holds is Count.<para/>
        /// See <see cref="DEBUG_VALUE"/> for a description of this parameter type.</param>
        /// <returns>This list does not contain all the errors that might occur. For a list of possible errors, see HRESULT Values.</returns>
        /// <remarks>
        /// The engine does its best to cast the values in Values into the type of the registers; this conversion is the same
        /// as that performed by <see cref="IDebugControl.CoerceValue"/>. If the value is larger than what the register can
        /// hold, the least significant bits are dropped. Floating-point and integer conversions will also be performed if
        /// necessary. If the return value is not S_OK, some of the registers still might have been set. When a subregister
        /// is altered, the register that contains it is also altered. The method <see cref="SetValues"/> performs the same
        /// task as this method but always uses the target as the register source. For an overview of the <see cref="IDebugRegisters"/>
        /// interface and other register-related methods, see Registers.
        /// </remarks>
        [PreserveSig]
        HRESULT SetValues2(
            [In] DEBUG_REGSRC Source,
            [In] uint Count,
            [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)]
            uint[] Indices,
            [In] uint Start,
            [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)]
            DEBUG_VALUE[] Values);

        /// <summary>
        /// The OutputRegisters2 method formats and outputs the target's registers.
        /// </summary>
        /// <param name="OutputControl">[in] Specifies which clients should be sent the output of the formatted registers. See DEBUG_OUTCTL_XXX for possible values.</param>
        /// <param name="Source">[in] Specifies the register source to query. The possible values are listed in the following table.</param>
        /// <param name="Flags">[in] Specifies which register sets to print. This can either be DEBUG_REGISTERS_DEFAULT to print commonly used registers, DEBUG_REGISTERS_ALL to print all of the register sets, or a combination of the values listed in the following table.</param>
        /// <returns>This list does not contain all the errors that might occur. For a list of possible errors, see HRESULT Values.</returns>
        /// <remarks>
        /// The registers are formatted in a way that is specific to the target architecture's register set. The method <see
        /// cref="OutputRegisters"/> performs the same task as this method but always uses the target as the register source.
        /// For an overview of the <see cref="IDebugRegisters"/> interface and other register-related methods, see Registers.
        /// </remarks>
        [PreserveSig]
        HRESULT OutputRegisters2(
            [In] DEBUG_OUTCTL OutputControl,
            [In] DEBUG_REGSRC Source,
            [In] DEBUG_REGISTERS Flags);

        /// <summary>
        /// The GetInstructionOffset2 method returns the location of the current thread's current instruction.
        /// </summary>
        /// <param name="Source">[in] Specifies the register source to query. The possible values are listed in the following table.</param>
        /// <param name="Offset">[out] Receives the location in the process's virtual address space of the current instruction of the current thread.</param>
        /// <returns>This list does not contain all the errors that might occur. For a list of possible errors, see HRESULT Values.</returns>
        /// <remarks>
        /// The meaning of the value that is returned by this method is architecture-dependent. In particular, for an Itanium-based
        /// processor, the virtual address that is returned can indicate an address within a bundle. The method <see cref="GetInstructionOffset"/>
        /// performs the same task as this method but always uses the target as the register source. For an overview of the
        /// <see cref="IDebugRegisters"/> interface and other register-related methods, see Registers.
        /// </remarks>
        [PreserveSig]
        HRESULT GetInstructionOffset2(
            [In] DEBUG_REGSRC Source,
            [Out] out ulong Offset);

        /// <summary>
        /// The GetStackOffset2 method returns the current thread's current stack location.
        /// </summary>
        /// <param name="Source">[in] Specifies the register source to query. The possible values are listed in the following table.</param>
        /// <param name="Offset">[out] Receives the location in the process's virtual address space of the current thread's current stack.</param>
        /// <returns>This list does not contain all the errors that might occur. For a list of possible errors, see HRESULT Values.</returns>
        [PreserveSig]
        HRESULT GetStackOffset2(
            [In] DEBUG_REGSRC Source,
            [Out] out ulong Offset);

        /// <summary>
        /// The GetFrameOffset2 method returns the location of the stack frame for the current function.
        /// </summary>
        /// <param name="Source">[in] Specifies the register source to query. The possible values are listed in the following table.</param>
        /// <param name="Offset">[out] The location in the process's virtual address space of the stack frame for the current function.</param>
        /// <returns>This list does not contain all the errors that might occur. For a list of possible errors, see HRESULT Values.</returns>
        /// <remarks>
        /// The meaning of the value that is returned by this method is architecture-specific. The method <see cref="GetFrameOffset"/>
        /// performs the same task as this method but always uses the target as the register source. For an overview of the
        /// <see cref="IDebugRegisters"/> interface and other register-related methods, see Registers.
        /// </remarks>
        [PreserveSig]
        HRESULT GetFrameOffset2(
            [In] DEBUG_REGSRC Source,
            [Out] out ulong Offset);

        #endregion
    }
}
