using System.Runtime.InteropServices;

namespace ClrDebug.DIA
{
    /// <summary>
    /// Exposes the details of a stack frame.
    /// </summary>
    /// <remarks>
    /// The details available for a frame are for execution points within the address range indicated by the address and
    /// block length. Obtain this interface by calling the IDiaEnumFrameData or IDiaEnumFrameData methods. See the IDiaEnumFrameData
    /// interface for details.
    /// </remarks>
    [Guid("A39184B7-6A36-42DE-8EEC-7DF9F3F59F33")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [ComImport]
    public interface IDiaFrameData
    {
        /// <summary>
        /// Retrieves the section part of the code address for the frame.
        /// </summary>
        /// <param name="pRetVal">[out] Returns the section part of the code address for the frame.</param>
        /// <returns>If successful, returns S_OK. Returns S_FALSE if this property is not supported. Otherwise, returns an error code.</returns>
        [PreserveSig]
        HRESULT get_addressSection(
            [Out] out int pRetVal);

        /// <summary>
        /// Retrieves the offset part of the code address for the frame.
        /// </summary>
        /// <param name="pRetVal">[out] Returns the offset part of the code address for the frame.</param>
        /// <returns>If successful, returns S_OK. Returns S_FALSE if this property is not supported. Otherwise, returns an error code.</returns>
        [PreserveSig]
        HRESULT get_addressOffset(
            [Out] out int pRetVal);

        /// <summary>
        /// Retrieves the relative virtual address (RVA) of the code for the frame.
        /// </summary>
        /// <param name="pRetVal">[out] Returns the relative virtual address of the code for the frame.</param>
        /// <returns>If successful, returns S_OK. Returns S_FALSE if this property is not supported. Otherwise, returns an error code.</returns>
        [PreserveSig]
        HRESULT get_relativeVirtualAddress(
            [Out] out int pRetVal);

        /// <summary>
        /// Retrieves the virtual address (VA) of the code for the frame.
        /// </summary>
        /// <param name="pRetVal">[out] Returns the virtual address of the code for the frame.</param>
        /// <returns>If successful, returns S_OK. Returns S_FALSE if this property is not supported. Otherwise, returns an error code.</returns>
        [PreserveSig]
        HRESULT get_virtualAddress(
            [Out] out long pRetVal);

        /// <summary>
        /// Retrieves the length, in bytes, of the block of code described by the frame.
        /// </summary>
        /// <param name="pRetVal">[out] Returns the number of bytes of code in the frame.</param>
        /// <returns>If successful, returns S_OK. Returns S_FALSE if this property is not supported. Otherwise, returns an error code.</returns>
        /// <remarks>
        /// The value returned by this method is typically used in the interpretation of a program string (see the IDiaFrameData
        /// method for the definition of a program string).
        /// </remarks>
        [PreserveSig]
        HRESULT get_lengthBlock(
            [Out] out int pRetVal);

        /// <summary>
        /// Retrieves the number of bytes of local variables pushed on the stack.
        /// </summary>
        /// <param name="pRetVal">[out] Returns the number of bytes of local variables.</param>
        /// <returns>If successful, returns S_OK. Returns S_FALSE if this property is not supported. Otherwise, returns an error code.</returns>
        /// <remarks>
        /// The value returned by this method is typically used in the interpretation of a program string (see the IDiaFrameData
        /// method for the definition of a program string).
        /// </remarks>
        [PreserveSig]
        HRESULT get_lengthLocals(
            [Out] out int pRetVal);

        /// <summary>
        /// Retrieves the number of bytes of parameters pushed on the stack.
        /// </summary>
        /// <param name="pRetVal">[out] Returns the number of bytes of parameters.</param>
        /// <returns>If successful, returns S_OK. Returns S_FALSE if this property is not supported. Otherwise, returns an error code.</returns>
        /// <remarks>
        /// The value returned by this method is typically used in the interpretation of a program string (see the IDiaFrameData
        /// method for the definition of a program string).
        /// </remarks>
        [PreserveSig]
        HRESULT get_lengthParams(
            [Out] out int pRetVal);

        /// <summary>
        /// Retrieves the maximum number of bytes pushed on the stack in the frame.
        /// </summary>
        /// <param name="pRetVal">[out] Returns the maximum number of bytes pushed on the stack.</param>
        /// <returns>If successful, returns S_OK. Returns S_FALSE if this property is not supported. Otherwise, returns an error code.</returns>
        /// <remarks>
        /// The value returned by this method is typically used in the interpretation of a program string (see the IDiaFrameData
        /// method for the definition of a program string).
        /// </remarks>
        [PreserveSig]
        HRESULT get_maxStack(
            [Out] out int pRetVal);

        /// <summary>
        /// Retrieves the number of bytes of prologue code in the block.
        /// </summary>
        /// <param name="pRetVal">[out] Returns the number of bytes of prologue code.</param>
        /// <returns>If successful, returns S_OK. Returns S_FALSE if this property is not supported. Otherwise, returns an error code.</returns>
        /// <remarks>
        /// The prologue code is a sequence of instructions that preserves registers, sets the CPU state, and establishes the
        /// stack for the function.
        /// </remarks>
        [PreserveSig]
        HRESULT get_lengthProlog(
            [Out] out int pRetVal);

        /// <summary>
        /// Retrieves the number of bytes of saved registers pushed on the stack.
        /// </summary>
        /// <param name="pRetVal">[out] Returns the number of bytes of saved registers.</param>
        /// <returns>If successful, returns S_OK. Returns S_FALSE if this property is not supported. Otherwise, returns an error code.</returns>
        /// <remarks>
        /// The value returned by this method is typically used in the interpretation of a program string (see the IDiaFrameData
        /// method for the definition of a program string).
        /// </remarks>
        [PreserveSig]
        HRESULT get_lengthSavedRegisters(
            [Out] out int pRetVal);

        /// <summary>
        /// Retrieves the program string that is used to compute the register set before the call to the current function.
        /// </summary>
        /// <param name="pRetVal">[out] Returns the program string.</param>
        /// <returns>If successful, returns S_OK. Returns S_FALSE if this property is not supported. Otherwise, returns an error code.</returns>
        /// <remarks>
        /// The program string is a sequence of macros that is interpreted in order to establish the prologue. For example,
        /// a typical stack frame might use the program string "$T0 $ebp = $eip $T0 4 + ^ = $ebp $T0 ^ = $esp $T0 8 + =". The
        /// format is reverse polish notation, where the operators follow the operands. T0 represents a temporary variable
        /// on the stack. This example performs the following steps:
        /// </remarks>
        [PreserveSig]
        HRESULT get_program(
            [Out, MarshalAs(UnmanagedType.BStr)] out string pRetVal);

        /// <summary>
        /// Retrieves a flag that indicates whether system exception handling is in effect.
        /// </summary>
        /// <param name="pRetVal">[out] Returns TRUE if system exception handling is in effect; otherwise, returns FALSE.</param>
        /// <returns>If successful, returns S_OK. Returns S_FALSE if this property is not supported. Otherwise, returns an error code.</returns>
        /// <remarks>
        /// System exception handling is more commonly known as structured exception handling. To determine if C++ exception
        /// handling is in effect, call the IDiaFrameData method.
        /// </remarks>
        [PreserveSig]
        HRESULT get_systemExceptionHandling(
            [Out] out bool pRetVal);

        /// <summary>
        /// Retrieves a flag that indicates whether C++ exception handling is in effect.
        /// </summary>
        /// <param name="pRetVal">[out] Returns TRUE if C++ exception handling is in effect; otherwise, returns FALSE.</param>
        /// <returns>If successful, returns S_OK. Returns S_FALSE if this property is not supported. Otherwise, returns an error code.</returns>
        /// <remarks>
        /// To determine if structured exception handling is in effect (which is very different from C++ exception handling),
        /// call the IDiaFrameData method.
        /// </remarks>
        [PreserveSig]
        HRESULT get_cplusplusExceptionHandling(
            [Out] out bool pRetVal);

        /// <summary>
        /// Retrieves a flag that indicates whether the block contains the entry point of a function.
        /// </summary>
        /// <param name="pRetVal">[out] Returns TRUE if the block contains the entry point; otherwise returns FALSE.</param>
        /// <returns>If successful, returns S_OK. Returns S_FALSE if this property is not supported. Otherwise, returns an error code.</returns>
        /// <remarks>
        /// It is possible for a stack frame to not be the start of a function because the frame represents an inline method
        /// or function inserted into a function.
        /// </remarks>
        [PreserveSig]
        HRESULT get_functionStart(
            [Out] out bool pRetVal);

        /// <summary>
        /// Retrieves a flag that indicates whether the base pointer is allocated for code in this address range. This method is deprecated.
        /// </summary>
        /// <param name="pRetVal">[out] Returns TRUE if a base pointer is allocated; otherwise, returns FALSE.</param>
        /// <returns>If successful, returns S_OK. Returns S_FALSE if this property is not supported. Otherwise, returns an error code.</returns>
        /// <remarks>
        /// This property should be used only by code that formerly accessed FPO_DATA, or when the program string returned
        /// by the IDiaFrameData method is NULL. Otherwise, the program string contains all the information needed to compute
        /// previous register values.
        /// </remarks>
        [PreserveSig]
        HRESULT get_allocatesBasePointer(
            [Out] out bool pRetVal);

        /// <summary>
        /// Retrieves the compiler-specific frame type.
        /// </summary>
        /// <param name="pRetVal">[out] Returns a value from the StackFrameTypeEnum Enumeration enumeration that indicates the compiler-specific frame type.</param>
        /// <returns>If successful, returns S_OK. Returns S_FALSE if this property is not supported. Otherwise, returns an error code.</returns>
        [PreserveSig]
        HRESULT get_type(
            [Out] out StackFrameTypeEnum pRetVal);

        /// <summary>
        /// Retrieves a frame data interface for the enclosing function.
        /// </summary>
        /// <param name="pRetVal">[out] Returns an IDiaFrameData object for the enclosing function.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns an error code.</returns>
        [PreserveSig]
        HRESULT get_functionParent(
            [Out, MarshalAs(UnmanagedType.Interface)] out IDiaFrameData pRetVal);

        /// <summary>
        /// Performs stack unwinding and returns results in a stack walk frame interface.
        /// </summary>
        /// <param name="frame">[in] An IDiaStackWalkFrame object that holds the state of frame registers.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns an error code. The following table shows the possible return values for this method.</returns>
        /// <remarks>
        /// This method is called during debugging to unwind the stack. The IDiaStackWalkFrame object is implemented by the
        /// client application to receive updates to the registers and to provide methods used by the execute method.
        /// </remarks>
        [PreserveSig]
        HRESULT execute(
            [In, MarshalAs(UnmanagedType.Interface)] IDiaStackWalkFrame frame);
    }
}
