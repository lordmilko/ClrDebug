using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace ClrDebug
{
    /// <summary>
    /// Extends the capabilities of the <see cref="ICorDebugRegisterSet"/> interface for hardware platforms that have more than 64 registers.
    /// </summary>
    [Guid("6DC7BA3F-89BA-4459-9EC1-9D60937B468D")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [ComImport]
    public interface ICorDebugRegisterSet2
    {
        /// <summary>
        /// Gets an array of bytes that provides a bitmap of the available registers.
        /// </summary>
        /// <param name="numChunks">[in] The size of the availableRegChunks array.</param>
        /// <param name="availableRegChunks">[out] An array of bytes, each bit of which corresponds to a register. If a register is available, the register's corresponding bit is set.</param>
        /// <remarks>
        /// The values of the <see cref="CorDebugRegister"/> enumeration specify the registers of different microprocessors. The upper five
        /// bits of each value are the index into the availableRegChunks array of bytes. The lower three bits of each value
        /// identify the bit position within the indexed byte. Given a <see cref="CorDebugRegister"/> value that specifies a particular register,
        /// the register's position in the mask is determined as follows:
        /// </remarks>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT GetRegistersAvailable(
            [In] int numChunks,
            [Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] byte[] availableRegChunks);

        /// <summary>
        /// Gets the value of each register (for the platform on which code is currently executing) that is specified by the given bit mask.
        /// </summary>
        /// <param name="maskCount">[in] The size, in bytes, of the mask array.</param>
        /// <param name="mask">[in] An array of bytes, each bit of which corresponds to a register. If the bit is 1, the corresponding register's value will be retrieved.</param>
        /// <param name="regCount">[in] The number of register values to be retrieved.</param>
        /// <param name="regBuffer">[out] An array of <see cref="CORDB_REGISTER"/> objects, each of which receives the value of a register.</param>
        /// <remarks>
        /// The GetRegisters method returns an array of values from the registers that are specified by the mask. The array
        /// does not contain values of registers whose mask bit is not set. Thus, the size of the regBuffer array must be equal
        /// to the number of 1's in the mask. If the value of regCount is too small for the number of registers indicated by
        /// the mask, the values of the higher numbered registers will be truncated from the set. If regCount is too large,
        /// the unused regBuffer elements will be unmodified. If an unavailable register is indicated by the mask, an indeterminate
        /// value will be returned for that register. The <see cref="GetRegisters"/> method is necessary for platforms
        /// that have more than 64 registers. For example, IA64 has 128 general purpose registers and 128 floating-point registers,
        /// so you need more than 64 bits in the bit mask. If you don't have more than 64 registers, as is the case on platforms
        /// such as x86, the GetRegisters method just translates the bytes in the mask byte array into a ULONG64 and then calls
        /// the <see cref="ICorDebugRegisterSet.GetRegisters"/> method, which takes the ULONG64 mask.
        /// </remarks>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT GetRegisters(
            [In] int maskCount,
            [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] byte[] mask,
            [In] int regCount,
            [Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] CORDB_REGISTER[] regBuffer);

        /// <summary>
        /// SetRegisters is not implemented in the .NET Framework version 2.0. Do not call this method.
        /// </summary>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT SetRegisters(
            [In] int maskCount,
            [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] byte[] mask,
            [In] int regCount,
            [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] CORDB_REGISTER[] regBuffer);
    }
}
