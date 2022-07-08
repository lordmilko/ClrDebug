using System.Runtime.InteropServices;
using System.Text;

namespace ClrDebug.DbgEng
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("ce289126-9e84-45a7-937e-67bb18691493")]
    [ComImport]
    public interface IDebugRegisters
    {
        /// <summary>
        /// The GetNumberRegisters method returns the number of registers on the target computer.
        /// </summary>
        /// <param name="Number">[out] Receives the number of registers on the target's computer.</param>
        /// <returns>This list does not contain all the errors that might occur. For a list of possible errors, see HRESULT Values.</returns>
        /// <remarks>
        /// For an overview of the <see cref="IDebugRegisters"/> interface and other register-related methods, see Registers.
        /// </remarks>
        [PreserveSig]
        HRESULT GetNumberRegisters(
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
        HRESULT GetDescription(
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
        HRESULT GetIndexByName(
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
        HRESULT GetValue(
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
        HRESULT SetValue(
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
        /// <see cref="IDebugRegisters2.GetValues2"/> performs the same task as this method but also allows the register source
        /// to be specified. For an overview of the <see cref="IDebugRegisters"/> interface and other register-related methods,
        /// see Registers.
        /// </remarks>
        [PreserveSig]
        HRESULT GetValues(
            [In] uint Count,
            [In, MarshalAs(UnmanagedType.LPArray)] uint[] Indices,
            [In] uint Start,
            [Out, MarshalAs(UnmanagedType.LPArray)] DEBUG_VALUE[] Values);

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
        /// method instead. The method <see cref="IDebugRegisters2.SetValues2"/> performs the same task as this method but
        /// also allows the register source to be specified. For an overview of the <see cref="IDebugRegisters"/> interface
        /// and other register-related methods, see Registers.
        /// </remarks>
        [PreserveSig]
        HRESULT SetValues(
            [In] uint Count,
            [In, MarshalAs(UnmanagedType.LPArray)] uint[] Indices,
            [In] uint Start,
            [In, MarshalAs(UnmanagedType.LPArray)] DEBUG_VALUE[] Values);

        /// <summary>
        /// The OutputRegisters method formats and sends the target's registers to the clients as output.
        /// </summary>
        /// <param name="OutputControl">[in] Specifies which clients should be sent the output of the formatted registers. See DEBUG_OUTCTL_XXX for possible values.</param>
        /// <param name="Flags">[in] Specifies which set of registers to print. This can either be DEBUG_REGISTERS_DEFAULT to print commonly used registers, DEBUG_REGISTERS_ALL to print all the sets of registers, or a combination of the values listed in the following table.</param>
        /// <returns>This list does not contain all the errors that might occur. For a list of possible errors, see HRESULT Values.</returns>
        /// <remarks>
        /// The registers are formatted in a way that is specific to the target architecture's register set. The method <see
        /// cref="IDebugRegisters2.OutputRegisters2"/> performs the same task as this method but also allows the register source
        /// to be specified. For an overview of the <see cref="IDebugRegisters"/> interface and other register-related methods,
        /// see Registers. For details on sending output to the clients, see Input and Output.
        /// </remarks>
        [PreserveSig]
        HRESULT OutputRegisters(
            [In] DEBUG_OUTCTL OutputControl,
            [In] DEBUG_REGISTERS Flags);

        /// <summary>
        /// The GetInstructionOffset method returns the location of the current thread's current instruction.
        /// </summary>
        /// <param name="Offset">[out] Receives the location in the target's virtual address space of the target's current instruction.</param>
        /// <returns>This list does not contain all the errors that might occur. For a list of possible errors, see HRESULT Values.</returns>
        /// <remarks>
        /// The meaning of the value returned by this method is architecture-dependent. In particular, for an Itanium processor,
        /// the virtual address returned can indicate an address within a bundle. The method <see cref="IDebugRegisters2.GetInstructionOffset2"/>
        /// performs the same task as this method but also allows the register source to be specified. For an overview of the
        /// <see cref="IDebugRegisters"/> interface and other register-related methods, see Registers.
        /// </remarks>
        [PreserveSig]
        HRESULT GetInstructionOffset(
            [Out] out ulong Offset);

        /// <summary>
        /// The GetStackOffset method returns the current thread's current stack location.
        /// </summary>
        /// <param name="Offset">[out] Receives the location in the process's virtual address space of the current thread's current stack location.</param>
        /// <returns>This list does not contain all the errors that might occur. For a list of possible errors, see HRESULT Values.</returns>
        /// <remarks>
        /// The meaning of value returned by this method is architecture specific. The method <see cref="IDebugRegisters2.GetStackOffset2"/>
        /// performs the same task as this method but also allows the register source to be specified. For an overview of the
        /// <see cref="IDebugRegisters"/> interface and other register-related methods, see Registers.
        /// </remarks>
        [PreserveSig]
        HRESULT GetStackOffset(
            [Out] out ulong Offset);

        /// <summary>
        /// The GetFrameOffset method returns the location of the stack frame for the current function.
        /// </summary>
        /// <param name="Offset">[out] The location in the target's virtual address space of the stack frame for the current function.</param>
        /// <returns>This list does not contain all the errors that might occur. For a list of possible errors, see HRESULT Values.</returns>
        /// <remarks>
        /// The meaning of value returned by this method is architecture-specific. The method <see cref="IDebugRegisters2.GetFrameOffset2"/>
        /// performs the same task as this method but also allows the register source to be specified. For an overview of the
        /// <see cref="IDebugRegisters"/> interface and other register-related methods, see Registers.
        /// </remarks>
        [PreserveSig]
        HRESULT GetFrameOffset(
            [Out] out ulong Offset);
    }
}
