using System;
using System.Runtime.InteropServices;
using SRI = System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    /// <summary>
    /// The ISvcRegisterContext unit describes a set of registers and their values. A register context for a standard supported platform can optionally support ISvcClassicRegisterContext where the given register context can be represented by a platform specific Windows CONTEXT structure.<para/>
    /// In addition, a register context which holds a set of "special context" for a standard supported platform can optionally support ISvcClassicSpecialContext where that part of the register context can be presented by a platform specific Windows KSPECIAL_REGISTERS structure.
    /// </summary>
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("CA1AFE05-244C-4FA3-BED4-A355418587EF")]
    [ComImport]
    public interface ISvcRegisterContext
    {
        /// <summary>
        /// Returns the architecture of the registers that this register context holds. This is either a DEBUG_ARCHDEF_* standard GUID or is a GUID defining a custom architecture.
        /// </summary>
        [PreserveSig]
        HRESULT GetArchitectureGuid(
            [Out] out Guid architecture);

        /// <summary>
        /// Gets the value of a register as given by its canonical register number. The following error codes carry special meaning E_INSUFFICIENT_BUFFER: The in-passed buffer is not large enough to hold the register value.<para/>
        /// The actual size of the register is returned in registerSize. E_NOT_SET : The register context does not contain a value for the given register and such cannot be retrieved.
        /// </summary>
        [PreserveSig]
        HRESULT GetRegisterValue(
            [In] int registerId,
            [Out] IntPtr buffer,
            [In] int bufferSize,
            [Out] out int registerSize);

        /// <summary>
        /// Similar to GetRegisterValue, this is a convenience method for integer/GPR registers of 64-bits or less where the value of the register will be zero extended to 64-bits and returned.
        /// </summary>
        [PreserveSig]
        HRESULT GetRegisterValue64(
            [In] int registerId,
            [Out] out long pRegisterValue);

        /// <summary>
        /// Behaves as GetRegisterValue64 but on an abstract ID.
        /// </summary>
        [PreserveSig]
        HRESULT GetAbstractRegisterValue64(
            [In] SvcAbstractRegister abstractId,
            [Out] out long pRegisterValue);

        /// <summary>
        /// Sets the value of a register as given by its canonical register number. The following error codes carry special meaning E_INSUFFICIENT_BUFFER: The in-passed buffer is not large enough for the register's value.<para/>
        /// The required size of the register value is returned in registerSize. E_NOTIMPL : The context does not allow the setting of this register value.
        /// </summary>
        [PreserveSig]
        HRESULT SetRegisterValue(
            [In] int registerId,
            [In] IntPtr buffer,
            [In] int bufferSize,
            [Out] out int registerSize);

        /// <summary>
        /// Similar to SetRegisterValue, this is a convenience method for integer/GPR registers of 64-bits or less where the value of the register will be set from a (presumed) zero extended 64-bit value.
        /// </summary>
        [PreserveSig]
        HRESULT SetRegisterValue64(
            [In] int registerId,
            [In] long registerValue);

        /// <summary>
        /// Behaves as SetRegisterValue64 but on an abstract ID.
        /// </summary>
        [PreserveSig]
        HRESULT SetAbstractRegisterValue64(
            [In] SvcAbstractRegister abstractId,
            [In] long registerValue);

        /// <summary>
        /// Gets the value of multiple registers in a single call. Registers are given by a structure defining their canonical register number and the position the value should be placed within an output structure.
        /// </summary>
        [PreserveSig]
        HRESULT GetRegisterValues(
            [In] int registerCount,
            [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] RegisterInformationQuery[] pRegisters,
            [In] int bufferSize,
            [Out] IntPtr buffer,
            [SRI.Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] int[] registerSizes);

        /// <summary>
        /// Sets the value of multiple registers in a single call. Registers are given by a structure defining their canonical register number and the position the value should be retrieved from within an input structure.
        /// </summary>
        [PreserveSig]
        HRESULT SetRegisterValues(
            [In] int registerCount,
            [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] RegisterInformationQuery[] pRegisters,
            [In] int bufferSize,
            [In] IntPtr buffer,
            [SRI.Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] int[] registerSizes);

        /// <summary>
        /// Copies the values of one register context into this register context.
        /// </summary>
        [PreserveSig]
        HRESULT SetToContext(
            [In, MarshalAs(UnmanagedType.Interface)] ISvcRegisterContext registerContext);

        /// <summary>
        /// Creates a duplicate copy of the register context. Changes made to the duplicate copy do not affect the original.
        /// </summary>
        [PreserveSig]
        HRESULT Duplicate(
            [Out, MarshalAs(UnmanagedType.Interface)] out ISvcRegisterContext duplicateContext);
    }
}
