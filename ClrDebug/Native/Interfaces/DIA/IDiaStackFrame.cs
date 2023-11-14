using System.Runtime.InteropServices;

namespace ClrDebug.DIA
{
    /// <summary>
    /// Exposes the properties of a stack frame.
    /// </summary>
    /// <remarks>
    /// A stack frame is an abstraction of a function call during its execution. Obtain this interface by calling the IDiaEnumStackFrames
    /// method. See the IDiaEnumStackFrames interface for an example on obtaining the IDiaStackFrame interface.
    /// </remarks>
    [Guid("5EDBC96D-CDD6-4792-AFBE-CC89007D9610")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [ComImport]
    public interface IDiaStackFrame
    {
        /// <summary>
        /// Retrieves the frame type.
        /// </summary>
        /// <param name="pRetVal">[out] Returns a value from the StackFrameTypeEnum Enumeration enumeration.</param>
        /// <returns>If successful, returns S_OK. Returns S_FALSE if the property is not supported. Otherwise, returns an error code.</returns>
        [PreserveSig]
        HRESULT get_type(
            [Out] out StackFrameTypeEnum pRetVal);

        /// <summary>
        /// Retrieves the base address of the frame.
        /// </summary>
        /// <param name="pRetVal">[out] Returns the base address.</param>
        /// <returns>If successful, returns S_OK. Returns S_FALSE if the property is not supported. Otherwise, returns an error code.</returns>
        [PreserveSig]
        HRESULT get_base(
            [Out] out long pRetVal);

        /// <summary>
        /// Retrieves the size of the stack frame in bytes.
        /// </summary>
        /// <param name="pRetVal">[out] Returns the size of the stack frame in bytes.</param>
        /// <returns>If successful, returns S_OK. Returns S_FALSE if the property is not supported. Otherwise, returns an error code.</returns>
        [PreserveSig]
        HRESULT get_size(
            [Out] out int pRetVal);

        /// <summary>
        /// Retrieves the return address of the frame.
        /// </summary>
        /// <param name="pRetVal">[out] Returns the return address of the frame.</param>
        /// <returns>If successful, returns S_OK. Returns S_FALSE if the property is not supported. Otherwise, returns an error code.</returns>
        [PreserveSig]
        HRESULT get_returnAddress(
            [Out] out long pRetVal);

        /// <summary>
        /// Retrieves the base address of the local variables for the frame.
        /// </summary>
        /// <param name="pRetVal">[out] Returns the base address of the local variables.</param>
        /// <returns>If successful, returns S_OK. Returns S_FALSE if the property is not supported. Otherwise, returns an error code.</returns>
        [PreserveSig]
        HRESULT get_localsBase(
            [Out] out long pRetVal);

        /// <summary>
        /// Retrieves the number of bytes of local variables pushed on the stack.
        /// </summary>
        /// <param name="pRetVal">[out] Returns the number of bytes of local variables.</param>
        /// <returns>If successful, returns S_OK. Returns S_FALSE if the property is not supported. Otherwise, returns an error code.</returns>
        [PreserveSig]
        HRESULT get_lengthLocals(
            [Out] out int pRetVal);

        /// <summary>
        /// Retrieves the number of bytes of parameters pushed on the stack.
        /// </summary>
        /// <param name="pRetVal">[out] Returns the number of bytes of parameters.</param>
        /// <returns>If successful, returns S_OK. Returns S_FALSE if the property is not supported. Otherwise, returns an error code.</returns>
        [PreserveSig]
        HRESULT get_lengthParams(
            [Out] out int pRetVal);

        /// <summary>
        /// Retrieves the number of bytes of prologue code in the block.
        /// </summary>
        /// <param name="pRetVal">[out] Returns the number of bytes of prologue code.</param>
        /// <returns>If successful, returns S_OK. Returns S_FALSE if the property is not supported. Otherwise, returns an error code.</returns>
        [PreserveSig]
        HRESULT get_lengthProlog(
            [Out] out int pRetVal);

        /// <summary>
        /// Retrieves the number of bytes of saved registers pushed on the stack.
        /// </summary>
        /// <param name="pRetVal">[out] Returns the number of bytes of saved registers.</param>
        /// <returns>If successful, returns S_OK. Returns S_FALSE if the property is not supported. Otherwise, returns an error code.</returns>
        [PreserveSig]
        HRESULT get_lengthSavedRegisters(
            [Out] out int pRetVal);

        /// <summary>
        /// Retrieves a flag that indicates whether system exception handling is in effect.
        /// </summary>
        /// <param name="pRetVal">[out] Returns TRUE if system exception handling is in effect for this frame; otherwise, returns FALSE.</param>
        /// <returns>If successful, returns S_OK. Returns S_FALSE if the property is not supported. Otherwise, returns an error code.</returns>
        /// <remarks>
        /// System exception handling is also known as structured exception handling. This is not the same thing as C++ exception
        /// handling. To determine if C++ exception handling is in effect, call the IDiaStackFrame method.
        /// </remarks>
        [PreserveSig]
        HRESULT get_systemExceptionHandling(
            [Out] out bool pRetVal);

        /// <summary>
        /// Retrieves a flag that indicates if C++ exception handling is in effect.
        /// </summary>
        /// <param name="pRetVal">[out] Returns TRUE if C++ exception handling is in effect for this frame; otherwise, returns FALSE.</param>
        /// <returns>If successful, returns S_OK. Returns S_FALSE if the property is not supported. Otherwise, returns an error code.</returns>
        /// <remarks>
        /// C++ exception handling is not the same as structured or system exception handling. To determine if structured exception
        /// handling is in effect, call the IDiaStackFrame method.
        /// </remarks>
        [PreserveSig]
        HRESULT get_cplusplusExceptionHandling(
            [Out] out bool pRetVal);

        /// <summary>
        /// Retrieves a flag that indicates whether the block contains the entry point of a function.
        /// </summary>
        /// <param name="pRetVal">[out] Returns TRUE if the stack frame contains the entry point of a function; otherwise, returns FALSE.</param>
        /// <returns>If successful, returns S_OK. Returns S_FALSE if the property is not supported. Otherwise, returns an error code.</returns>
        [PreserveSig]
        HRESULT get_functionStart(
            [Out] out bool pRetVal);

        /// <summary>
        /// Retrieves a flag that indicates whether the base pointer is allocated for code in this address range.
        /// </summary>
        /// <param name="pRetVal">[out] Returns TRUE if a base pointer is allocated for code in this frame; otherwise, returns FALSE.</param>
        /// <returns>If successful, returns S_OK. Returns S_FALSE if the property is not supported. Otherwise, returns an error code.</returns>
        [PreserveSig]
        HRESULT get_allocatesBasePointer(
            [Out] out bool pRetVal);

        /// <summary>
        /// Retrieves the maximum number of bytes pushed on the stack in the frame.
        /// </summary>
        /// <param name="pRetVal">[out] Returns the maximum number of bytes pushed on the stack.</param>
        /// <returns>If successful, returns S_OK. Returns S_FALSE if the property is not supported. Otherwise, returns an error code.</returns>
        [PreserveSig]
        HRESULT get_maxStack(
            [Out] out int pRetVal);

        /// <summary>
        /// Retrieves the value of a specified register as stored in the stack frame.
        /// </summary>
        /// <param name="index">[in] One of the CV_HREG_e Enumeration enumeration values.</param>
        /// <param name="pRetVal">[out] Value stored in the register.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns error code.</returns>
        [PreserveSig]
        HRESULT get_registerValue(
            [In] CV_HREG_e index,
            [Out] out long pRetVal);
    }
}
