using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    /// <summary>
    /// Represents a local variable or argument of a function.
    /// </summary>
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("50847B8D-F43F-41B0-924C-6383A5F2278B")]
    [ComImport]
    public interface ICorDebugVariableHome
    {
        /// <summary>
        /// Gets the "ICorDebugCode" instance that contains this <see cref="ICorDebugVariableHome"/> object.
        /// </summary>
        /// <param name="ppCode">[out] A pointer to the address of the "ICorDebugCode" instance that contains this <see cref="ICorDebugVariableHome"/> object.</param>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT GetCode([Out, MarshalAs(UnmanagedType.Interface)] out ICorDebugCode ppCode);

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
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT GetSlotIndex([Out] out int pSlotIndex);

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
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT GetArgumentIndex([Out] out int pArgumentIndex);

        /// <summary>
        /// Gets the native range over which this variable is live.
        /// </summary>
        /// <param name="pStartOffset">[out] The logical offset at which the variable is first live.</param>
        /// <param name="pEndOffset">[out] The logical offset immediately after the point at which the variable is last live.</param>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT GetLiveRange([Out] out int pStartOffset, [Out] out int pEndOffset);

        /// <summary>
        /// Gets the type of the variable's native location.
        /// </summary>
        /// <param name="pLocationType">[out] A pointer to the type of the variable's native location. See the <see cref="VariableLocationType"/> enumeration for more information.</param>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT GetLocationType([Out] out VariableLocationType pLocationType);

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
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT GetRegister([Out] out CorDebugRegister pRegister);

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
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT GetOffset([Out] out int pOffset);
    }
}