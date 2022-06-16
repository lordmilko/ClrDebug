using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    /// <summary>
    /// Represents the set of registers available on the computer that is currently executing code.
    /// </summary>
    /// <remarks>
    /// The <see cref="ICorDebugRegisterSet"/> interface supports only 32-bit registers. Use the <see cref="ICorDebugRegisterSet2"/>
    /// interface on platforms such as IA-64 that require additional registers.
    /// </remarks>
    public class CorDebugRegisterSet : ComObject<ICorDebugRegisterSet>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CorDebugRegisterSet"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
        public CorDebugRegisterSet(ICorDebugRegisterSet raw) : base(raw)
        {
        }

        #region ICorDebugRegisterSet
        #region RegistersAvailable

        /// <summary>
        /// Gets a bit mask indicating which registers in this <see cref="ICorDebugRegisterSet"/> are currently available.
        /// </summary>
        public long RegistersAvailable
        {
            get
            {
                HRESULT hr;
                long pAvailable;

                if ((hr = TryGetRegistersAvailable(out pAvailable)) != HRESULT.S_OK)
                    Marshal.ThrowExceptionForHR((int) hr);

                return pAvailable;
            }
        }

        /// <summary>
        /// Gets a bit mask indicating which registers in this <see cref="ICorDebugRegisterSet"/> are currently available.
        /// </summary>
        /// <param name="pAvailable">[out] A bit mask that indicates which registers are currently available.</param>
        /// <remarks>
        /// A register may be unavailable if its value cannot be determined for the given situation. The returned mask contains
        /// a bit for each register (1 &lt; &lt; the register index). The bit value is 1 if the register is available, or 0
        /// if it is not available.
        /// </remarks>
        public HRESULT TryGetRegistersAvailable(out long pAvailable)
        {
            /*HRESULT GetRegistersAvailable(out long pAvailable);*/
            return Raw.GetRegistersAvailable(out pAvailable);
        }

        #endregion
        #region GetRegisters

        /// <summary>
        /// Gets the value of each register (on the computer that is currently executing code) that is specified by the bit mask.
        /// </summary>
        /// <param name="mask">[in] A bit mask that specifies which register values are to be retrieved. Each bit corresponds to a register. If a bit is set to one, the register's value is retrieved; otherwise, the register's value is not retrieved.</param>
        /// <param name="regCount">[in] The number of register values to be retrieved.</param>
        /// <returns>[out] An array of <see cref="CORDB_REGISTER"/> objects, each of which receives a value of a register.</returns>
        /// <remarks>
        /// The size of the array should be equal to the number of bits set to one in the bit mask. The regCount parameter
        /// specifies the number of elements in the buffer that will receive the register values. If the regCount value is
        /// too small for the number of registers indicated by the mask, the higher numbered registers will be truncated from
        /// the set. If the regCount value is too large, the unused regBuffer elements will be unmodified. If the bit mask
        /// specifies a register that is unavailable, GetRegisters returns an indeterminate value for that register.
        /// </remarks>
        public CORDB_REGISTER[] GetRegisters(long mask, int regCount)
        {
            HRESULT hr;
            CORDB_REGISTER[] regBufferResult;

            if ((hr = TryGetRegisters(mask, regCount, out regBufferResult)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return regBufferResult;
        }

        /// <summary>
        /// Gets the value of each register (on the computer that is currently executing code) that is specified by the bit mask.
        /// </summary>
        /// <param name="mask">[in] A bit mask that specifies which register values are to be retrieved. Each bit corresponds to a register. If a bit is set to one, the register's value is retrieved; otherwise, the register's value is not retrieved.</param>
        /// <param name="regCount">[in] The number of register values to be retrieved.</param>
        /// <param name="regBufferResult">[out] An array of <see cref="CORDB_REGISTER"/> objects, each of which receives a value of a register.</param>
        /// <remarks>
        /// The size of the array should be equal to the number of bits set to one in the bit mask. The regCount parameter
        /// specifies the number of elements in the buffer that will receive the register values. If the regCount value is
        /// too small for the number of registers indicated by the mask, the higher numbered registers will be truncated from
        /// the set. If the regCount value is too large, the unused regBuffer elements will be unmodified. If the bit mask
        /// specifies a register that is unavailable, GetRegisters returns an indeterminate value for that register.
        /// </remarks>
        public HRESULT TryGetRegisters(long mask, int regCount, out CORDB_REGISTER[] regBufferResult)
        {
            /*HRESULT GetRegisters([In] long mask, [In] int regCount, [MarshalAs(UnmanagedType.LPArray), Out]
            CORDB_REGISTER[] regBuffer);*/
            CORDB_REGISTER[] regBuffer = null;
            HRESULT hr = Raw.GetRegisters(mask, regCount, regBuffer);

            if (hr == HRESULT.S_OK)
                regBufferResult = regBuffer;
            else
                regBufferResult = default(CORDB_REGISTER[]);

            return hr;
        }

        #endregion
        #region SetRegisters

        /// <summary>
        /// SetRegisters is not implemented in the .NET Framework version 2.0. Do not call this method.
        /// </summary>
        public void SetRegisters(long mask, int regCount, IntPtr regBuffer)
        {
            HRESULT hr;

            if ((hr = TrySetRegisters(mask, regCount, regBuffer)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        /// <summary>
        /// SetRegisters is not implemented in the .NET Framework version 2.0. Do not call this method.
        /// </summary>
        public HRESULT TrySetRegisters(long mask, int regCount, IntPtr regBuffer)
        {
            /*HRESULT SetRegisters([In] long mask, [In] int regCount, [In] IntPtr regBuffer);*/
            return Raw.SetRegisters(mask, regCount, regBuffer);
        }

        #endregion
        #region GetThreadContext

        /// <summary>
        /// Gets the context of the current thread.
        /// </summary>
        /// <param name="contextSize">[in] The size, in bytes, of the context array.</param>
        /// <returns>[in, out] An array of bytes that compose the Win32 CONTEXT structure for the current platform.</returns>
        /// <remarks>
        /// The debugger should call this function instead of the Win32 GetThreadContext function, because the thread may be
        /// in a "hijacked" state where its context has been temporarily changed. The data returned is a Win32 CONTEXT structure
        /// for the current platform. For non-leaf frames, clients should check which registers are valid by using <see cref="GetRegistersAvailable"/>.
        /// </remarks>
        public byte[] GetThreadContext(int contextSize)
        {
            HRESULT hr;
            byte[] contextResult;

            if ((hr = TryGetThreadContext(contextSize, out contextResult)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return contextResult;
        }

        /// <summary>
        /// Gets the context of the current thread.
        /// </summary>
        /// <param name="contextSize">[in] The size, in bytes, of the context array.</param>
        /// <param name="contextResult">[in, out] An array of bytes that compose the Win32 CONTEXT structure for the current platform.</param>
        /// <remarks>
        /// The debugger should call this function instead of the Win32 GetThreadContext function, because the thread may be
        /// in a "hijacked" state where its context has been temporarily changed. The data returned is a Win32 CONTEXT structure
        /// for the current platform. For non-leaf frames, clients should check which registers are valid by using <see cref="GetRegistersAvailable"/>.
        /// </remarks>
        public HRESULT TryGetThreadContext(int contextSize, out byte[] contextResult)
        {
            /*HRESULT GetThreadContext([In] int contextSize, [MarshalAs(UnmanagedType.LPArray), In, Out]
            byte[] context);*/
            byte[] context = null;
            HRESULT hr = Raw.GetThreadContext(contextSize, context);

            if (hr == HRESULT.S_OK)
                contextResult = context;
            else
                contextResult = default(byte[]);

            return hr;
        }

        #endregion
        #region SetThreadContext

        /// <summary>
        /// SetThreadContext is not implemented in the .NET Framework version 2.0. Do not call this method.
        /// </summary>
        public void SetThreadContext(int contextSize, byte[] context)
        {
            HRESULT hr;

            if ((hr = TrySetThreadContext(contextSize, context)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        /// <summary>
        /// SetThreadContext is not implemented in the .NET Framework version 2.0. Do not call this method.
        /// </summary>
        public HRESULT TrySetThreadContext(int contextSize, byte[] context)
        {
            /*HRESULT SetThreadContext([In] int contextSize, [MarshalAs(UnmanagedType.Interface), In]
            byte[] context);*/
            return Raw.SetThreadContext(contextSize, context);
        }

        #endregion
        #endregion
        #region ICorDebugRegisterSet2

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public ICorDebugRegisterSet2 Raw2 => (ICorDebugRegisterSet2) Raw;

        #region GetRegistersAvailable

        /// <summary>
        /// Gets an array of bytes that provides a bitmap of the available registers.
        /// </summary>
        /// <param name="numChunks">[in] The size of the availableRegChunks array.</param>
        /// <returns>[out] An array of bytes, each bit of which corresponds to a register. If a register is available, the register's corresponding bit is set.</returns>
        /// <remarks>
        /// The values of the <see cref="CorDebugRegister"/> enumeration specify the registers of different microprocessors. The upper five
        /// bits of each value are the index into the availableRegChunks array of bytes. The lower three bits of each value
        /// identify the bit position within the indexed byte. Given a <see cref="CorDebugRegister"/> value that specifies a particular register,
        /// the register's position in the mask is determined as follows:
        /// </remarks>
        public IntPtr GetRegistersAvailable(int numChunks)
        {
            HRESULT hr;
            IntPtr availableRegChunks;

            if ((hr = TryGetRegistersAvailable(numChunks, out availableRegChunks)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return availableRegChunks;
        }

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
        public HRESULT TryGetRegistersAvailable(int numChunks, out IntPtr availableRegChunks)
        {
            /*HRESULT GetRegistersAvailable([In] int numChunks, out IntPtr availableRegChunks);*/
            return Raw2.GetRegistersAvailable(numChunks, out availableRegChunks);
        }

        #endregion
        #region GetRegisters

        /// <summary>
        /// Gets the value of each register (for the platform on which code is currently executing) that is specified by the given bit mask.
        /// </summary>
        /// <param name="maskCount">[in] The size, in bytes, of the mask array.</param>
        /// <param name="mask">[in] An array of bytes, each bit of which corresponds to a register. If the bit is 1, the corresponding register's value will be retrieved.</param>
        /// <param name="regCount">[in] The number of register values to be retrieved.</param>
        /// <returns>[out] An array of <see cref="CORDB_REGISTER"/> objects, each of which receives the value of a register.</returns>
        /// <remarks>
        /// The GetRegisters method returns an array of values from the registers that are specified by the mask. The array
        /// does not contain values of registers whose mask bit is not set. Thus, the size of the regBuffer array must be equal
        /// to the number of 1's in the mask. If the value of regCount is too small for the number of registers indicated by
        /// the mask, the values of the higher numbered registers will be truncated from the set. If regCount is too large,
        /// the unused regBuffer elements will be unmodified. If an unavailable register is indicated by the mask, an indeterminate
        /// value will be returned for that register. The <see cref="GetRegisters(int, byte[], int)"/> method is necessary for platforms
        /// that have more than 64 registers. For example, IA64 has 128 general purpose registers and 128 floating-point registers,
        /// so you need more than 64 bits in the bit mask. If you don't have more than 64 registers, as is the case on platforms
        /// such as x86, the GetRegisters method just translates the bytes in the mask byte array into a ULONG64 and then calls
        /// the <see cref="GetRegisters(int, byte[], int)"/> method, which takes the ULONG64 mask.
        /// </remarks>
        public CORDB_REGISTER[] GetRegisters(int maskCount, byte[] mask, int regCount)
        {
            HRESULT hr;
            CORDB_REGISTER[] regBuffer;

            if ((hr = TryGetRegisters(maskCount, mask, regCount, out regBuffer)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return regBuffer;
        }

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
        /// value will be returned for that register. The <see cref="GetRegisters(int, byte[], int)"/> method is necessary for platforms
        /// that have more than 64 registers. For example, IA64 has 128 general purpose registers and 128 floating-point registers,
        /// so you need more than 64 bits in the bit mask. If you don't have more than 64 registers, as is the case on platforms
        /// such as x86, the GetRegisters method just translates the bytes in the mask byte array into a ULONG64 and then calls
        /// the <see cref="GetRegisters(int, byte[], int)"/> method, which takes the ULONG64 mask.
        /// </remarks>
        public HRESULT TryGetRegisters(int maskCount, byte[] mask, int regCount, out CORDB_REGISTER[] regBuffer)
        {
            /*HRESULT GetRegisters([In] int maskCount, [In] byte[] mask, [In] int regCount, out CORDB_REGISTER[] regBuffer);*/
            return Raw2.GetRegisters(maskCount, mask, regCount, out regBuffer);
        }

        #endregion
        #region SetRegisters

        /// <summary>
        /// SetRegisters is not implemented in the .NET Framework version 2.0. Do not call this method.
        /// </summary>
        public void SetRegisters(int maskCount, byte[] mask, int regCount, CORDB_REGISTER[] regBuffer)
        {
            HRESULT hr;

            if ((hr = TrySetRegisters(maskCount, mask, regCount, regBuffer)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        /// <summary>
        /// SetRegisters is not implemented in the .NET Framework version 2.0. Do not call this method.
        /// </summary>
        public HRESULT TrySetRegisters(int maskCount, byte[] mask, int regCount, CORDB_REGISTER[] regBuffer)
        {
            /*HRESULT SetRegisters([In] int maskCount, [In] byte[] mask, [In] int regCount, [In] CORDB_REGISTER[] regBuffer);*/
            return Raw2.SetRegisters(maskCount, mask, regCount, regBuffer);
        }

        #endregion
        #endregion
    }
}