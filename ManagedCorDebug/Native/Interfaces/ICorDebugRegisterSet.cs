using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    /// <summary>
    /// Represents the set of registers available on the computer that is currently executing code.
    /// </summary>
    /// <remarks>
    /// The ICorDebugRegisterSet interface supports only 32-bit registers. Use the <see cref="ICorDebugRegisterSet2"/>
    /// interface on platforms such as IA-64 that require additional registers.
    /// </remarks>
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("CC7BCB0B-8A68-11D2-983C-0000F808342D")]
    [ComImport]
    public interface ICorDebugRegisterSet
    {
        /// <summary>
        /// Gets a bit mask indicating which registers in this <see cref="ICorDebugRegisterSet"/> are currently available.
        /// </summary>
        /// <param name="pAvailable">[out] A bit mask that indicates which registers are currently available.</param>
        /// <remarks>
        /// A register may be unavailable if its value cannot be determined for the given situation. The returned mask contains
        /// a bit for each register (1 &lt;&lt; the register index). The bit value is 1 if the register is available, or 0
        /// if it is not available.
        /// </remarks>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT GetRegistersAvailable(out ulong pAvailable);

        /// <summary>
        /// Gets the value of each register (on the computer that is currently executing code) that is specified by the bit mask.
        /// </summary>
        /// <param name="mask">[in] A bit mask that specifies which register values are to be retrieved. Each bit corresponds to a register. If a bit is set to one, the register's value is retrieved; otherwise, the register's value is not retrieved.</param>
        /// <param name="regCount">[in] The number of register values to be retrieved.</param>
        /// <param name="regBuffer">[out] An array of CORDB_REGISTER objects, each of which receives a value of a register.</param>
        /// <remarks>
        /// The size of the array should be equal to the number of bits set to one in the bit mask. The regCount parameter
        /// specifies the number of elements in the buffer that will receive the register values. If the regCount value is
        /// too small for the number of registers indicated by the mask, the higher numbered registers will be truncated from
        /// the set. If the regCount value is too large, the unused regBuffer elements will be unmodified. If the bit mask
        /// specifies a register that is unavailable, GetRegisters returns an indeterminate value for that register.
        /// </remarks>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT GetRegisters([In] ulong mask, [In] uint regCount, [MarshalAs(UnmanagedType.LPArray), Out]
            CORDB_REGISTER[] regBuffer);

        /// <summary>
        /// SetRegisters is not implemented in the .NET Framework version 2.0. Do not call this method.
        /// </summary>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT SetRegisters([In] ulong mask, [In] uint regCount, [In] IntPtr regBuffer);

        /// <summary>
        /// Gets the context of the current thread.
        /// </summary>
        /// <param name="contextSize">[in] The size, in bytes, of the context array.</param>
        /// <param name="context">[in, out] An array of bytes that compose the Win32 CONTEXT structure for the current platform.</param>
        /// <remarks>
        /// The debugger should call this function instead of the Win32 GetThreadContext function, because the thread may be
        /// in a "hijacked" state where its context has been temporarily changed. The data returned is a Win32 CONTEXT structure
        /// for the current platform. For non-leaf frames, clients should check which registers are valid by using <see cref="ICorDebugRegisterSet.GetRegistersAvailable"/>.
        /// </remarks>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT GetThreadContext([In] uint contextSize, [MarshalAs(UnmanagedType.LPArray), In, Out]
            byte[] context);

        /// <summary>
        /// SetThreadContext is not implemented in the .NET Framework version 2.0. Do not call this method.
        /// </summary>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT SetThreadContext([In] uint contextSize, [MarshalAs(UnmanagedType.Interface), In]
            byte[] context);
    }
}