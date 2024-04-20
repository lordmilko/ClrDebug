using System.Runtime.InteropServices;
using SRI = System.Runtime.InteropServices;
#if GENERATED_MARSHALLING
using System.Runtime.InteropServices.Marshalling;
#endif

namespace ClrDebug.DIA
{
    /// <summary>
    /// Maintains stack context between invocations of the <see cref="IDiaFrameData.execute"/> method.
    /// </summary>
    /// <remarks>
    /// This interface is used during program execution to read and write registers as well as access memory and find return
    /// addresses. The client application implements this interface and passes an instance of the interface to the <see
    /// cref="IDiaFrameData.execute"/> method. The same instance of this interface is used again and again to maintain
    /// the state of the registers during each invocation of the execute method. The execute method also uses this interface
    /// to determine the return address.
    /// </remarks>
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("07C590C1-438D-4F47-BDCD-4397BC81AD75")]
#if !GENERATED_MARSHALLING
    [ComImport]
#else
    [GeneratedComInterface]
#endif
    public partial interface IDiaStackWalkFrame
    {
        /// <summary>
        /// Retrieves the value of a register.
        /// </summary>
        /// <param name="index">[in] A value from the <see cref="CV_HREG_e"/> enumeration specifying the register to get the value for.</param>
        /// <param name="pRetVal">[out] Returns the current value of the register.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns an error code.</returns>
        [PreserveSig]
        HRESULT get_registerValue(
            [In] CV_HREG_e index,
            [Out] out long pRetVal);

        /// <summary>
        /// Sets the value of a register.
        /// </summary>
        /// <param name="index">[in] A value from the <see cref="CV_HREG_e"/> enumeration specifying the register to write to.</param>
        /// <param name="NewVal">[in] The new register value.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns an error code.</returns>
        [PreserveSig]
        HRESULT put_registerValue(
            [In] CV_HREG_e index,
            [In] long NewVal);

        /// <summary>
        /// Reads memory from image.
        /// </summary>
        /// <param name="type">[in] One of the <see cref="MemoryTypeEnum"/> enumeration values that specifies the kind of memory to access.</param>
        /// <param name="va">[in] Virtual address location in image to begin reading.</param>
        /// <param name="cbData">[in] Size of the data buffer, in bytes.</param>
        /// <param name="pcbData">[out] Returns the number of bytes returned. If data is NULL, then pcbData contains the total number of bytes of data available.</param>
        /// <param name="pbData">[out] A buffer that is to be filled in with data from the specified location.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns an error code.</returns>
        [PreserveSig]
        HRESULT readMemory(
            [In] MemoryTypeEnum type,
            [In] long va,
            [In] int cbData,
            [Out] out int pcbData,
            [SRI.Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U1, SizeParamIndex = 2)] byte[] pbData);

        /// <summary>
        /// Searches the specified stack frame for the nearest function return address.
        /// </summary>
        /// <param name="frame">[in] An <see cref="IDiaFrameData"/> object that represents the current stack frame.</param>
        /// <param name="returnAddress">[out] Returns the nearest function return address.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns an error code.</returns>
        [PreserveSig]
        HRESULT searchForReturnAddress(
            [MarshalAs(UnmanagedType.Interface), In] IDiaFrameData frame,
            [Out] out long returnAddress);

        /// <summary>
        /// Searches the specified stack frame for a return address at or near the specified address.
        /// </summary>
        /// <param name="frame">[in] An <see cref="IDiaFrameData"/> object that represents the current stack frame.</param>
        /// <param name="startAddress">[in] A virtual memory address from which to begin searching.</param>
        /// <param name="returnAddress">[out] Returns the nearest function return address to startAddress.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns an error code.</returns>
        [PreserveSig]
        HRESULT searchForReturnAddressStart(
            [MarshalAs(UnmanagedType.Interface), In] IDiaFrameData frame,
            [In] long startAddress,
            [Out] out long returnAddress);
    }
}
