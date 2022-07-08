using System;
using System.Runtime.InteropServices;
using System.Text;

namespace ClrDebug.DbgEng
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("7df74a86-b03f-407f-90ab-a20dadcead08")]
    [ComImport]
    public interface IDebugControl3 : IDebugControl2
    {
        #region IDebugControl

        /// <summary>
        /// The GetInterrupt method checks whether a user interrupt was issued.
        /// </summary>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// If a user interrupt was issued, it is cleared when this method is called. Examples of user interrupts include pressing
        /// Ctrl+C or pressing the Stop button in a debugger. Calling <see cref="SetInterrupt"/> also causes a user interrupt.
        /// </remarks>
        [PreserveSig]
        new HRESULT GetInterrupt();

        /// <summary>
        /// The SetInterrupt method registers a user interrupt or breaks into the debugger.
        /// </summary>
        /// <param name="Flags">[in] Specifies the type of interrupt to register. Flags can take one of the values listed in the following table.<para/>
        /// Otherwise, when the target is suspended, the engine will register a user interrupt. Otherwise, when the target is suspended, register a user interrupt.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// This method can be called at any time and from any thread. Once the interrupt has been registered, this method
        /// returns immediately. If Flags is DEBUG_INTERRUPT_ACTIVE, and the interrupt times out, the engine will generate
        /// a synthetic exception event. This event will be sent to event callback's <see cref="IDebugEventCallbacks.Exception"/>
        /// method. The amount of time before the interrupt times out can be set using <see cref="SetInterruptTimeout"/>.
        /// </remarks>
        [PreserveSig]
        new HRESULT SetInterrupt(
            [In] DEBUG_INTERRUPT Flags);

        /// <summary>
        /// The GetInterruptTimeout method returns the number of seconds that the engine will wait when requesting a break into the debugger.
        /// </summary>
        /// <param name="Seconds">[out] Receives the number of seconds that the engine will wait for the target when requesting a break into the debugger.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// The engine requests a break into the debugger when <see cref="SetInterrupt"/> is called with DEBUG_INTERRUPT_ACTIVE.
        /// If this interrupt times out, the engine will generate a synthetic exception event. This event will be sent to event
        /// callback objects's <see cref="IDebugEventCallbacks.Exception"/> method. Most targets do not support interrupt time-outs.
        /// Live user-mode debugging is one of the targets that does support them.
        /// </remarks>
        [PreserveSig]
        new HRESULT GetInterruptTimeout(
            [Out] out uint Seconds);

        /// <summary>
        /// The SetInterruptTimeout method sets the number of seconds that the debugger engine should wait when requesting a break into the debugger.
        /// </summary>
        /// <param name="Seconds">[in] Specifies the number of seconds that the engine should wait for the target when requesting a break into the debugger.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// The engine requests a break into the debugger when <see cref="SetInterrupt"/> is called with the DEBUG_INTERRUPT_ACTIVE
        /// flag. If an interrupt times out, the engine will generate a synthetic exception event. This event will be sent
        /// to event callback objects's <see cref="IDebugEventCallbacks.Exception"/> method. Most targets do not support interrupt
        /// time-outs. Live user-mode debugging is one of the targets that does support them.
        /// </remarks>
        [PreserveSig]
        new HRESULT SetInterruptTimeout(
            [In] uint Seconds);

        /// <summary>
        /// The GetLogFile method returns the name of the currently open log file.
        /// </summary>
        /// <param name="Buffer">[out, optional] Receives the name of the currently open log file. If Buffer is NULL, this information is not returned.</param>
        /// <param name="BufferSize">[in] Specifies the size, in characters, of the Buffer buffer.</param>
        /// <param name="FileSize">[out, optional] Receives the size, in characters, of the name of the log file. If FileSize is NULL, this information is not returned.</param>
        /// <param name="Append">[out] Receives TRUE if log messages are appended to the log file, or FALSE if the contents of the log file were discarded when the file was opened.</param>
        /// <returns>This method can also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// GetLogFile and GetLogFileWide behave the same way as <see cref="IDebugControl4.GetLogFile2"/> and GetLogFile2Wide
        /// with Append receiving only the information about the DEBUG_LOG_APPEND flag. For more information about log files,
        /// see Using Input and Output.
        /// </remarks>
        [PreserveSig]
        new HRESULT GetLogFile(
            [Out, MarshalAs(UnmanagedType.LPStr)] StringBuilder Buffer,
            [In] int BufferSize,
            [Out] out uint FileSize,
            [Out, MarshalAs(UnmanagedType.Bool)] out bool Append);

        /// <summary>
        /// The OpenLogFile method opens a log file that will receive output from the client objects.
        /// </summary>
        /// <param name="File">[in] Specifies the name of the log file. File can include a relative or absolute path; relative paths are relative to the directory in which the debugger was started.<para/>
        /// If the file does not exist, it will be created.</param>
        /// <param name="Append">[in] Specifies whether or not to append log messages to an existing log file. If TRUE, log messages will be appended to the file; if FALSE, the contents of any existing file matching File are discarded.</param>
        /// <returns>This method can also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// OpenLogFile and OpenLogFileWide behave the same way as <see cref="IDebugControl4.OpenLogFile2"/> and OpenLogFile2Wide
        /// with Flags set to DEBUG_LOG_APPEND if Append is TRUE and DEBUG_LOG_DEFAULT otherwise. Only one log file can be
        /// open at a time. If there is already a log file open, it will be closed. For more information about log files, see
        /// Using Input and Output.
        /// </remarks>
        [PreserveSig]
        new HRESULT OpenLogFile(
            [In, MarshalAs(UnmanagedType.LPStr)] string File,
            [In, MarshalAs(UnmanagedType.Bool)] bool Append);

        /// <summary>
        /// The CloseLogFile method closes the currently-open log file.
        /// </summary>
        /// <returns>This method can also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// If no log file is open, this method has no effect. For more about log files, see Using Input and Output.
        /// </remarks>
        [PreserveSig]
        new HRESULT CloseLogFile();

        /// <summary>
        /// The GetLogMask method returns the output mask for the currently open log file.
        /// </summary>
        /// <param name="Mask">[out] Receives the output mask for the log file. See DEBUG_OUTPUT_XXX for details about how to interpret this value.</param>
        /// <returns>This method can also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// For more information about log files, see Using Input and Output.
        /// </remarks>
        [PreserveSig]
        new HRESULT GetLogMask(
            [Out] out DEBUG_OUTPUT Mask);

        /// <summary>
        /// The SetLogMask method sets the output mask for the currently open log file.
        /// </summary>
        /// <param name="Mask">[in] Specifies the new output mask for the log file. See DEBUG_OUTPUT_XXX for details about this value.</param>
        /// <returns>This method can also return error values. See Return Values for more details.</returns>
        [PreserveSig]
        new HRESULT SetLogMask(
            [In] DEBUG_OUTPUT Mask);

        /// <summary>
        /// The Input method requests an input string from the debugger engine.
        /// </summary>
        /// <param name="Buffer">[out] Receives the input string from the engine.</param>
        /// <param name="BufferSize">[in] Specifies the size, in characters, of the buffer that Buffer specifies. This size includes the space for the '\0' terminating character.</param>
        /// <param name="InputSize">[out, optional] Receives the number of characters returned in Buffer. This size includes the space for the '\0' terminating character.<para/>
        /// If InputSize is NULL, this information is not returned.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// For an overview of input in the debugger engine, see Input and Output.
        /// </remarks>
        [PreserveSig]
        new HRESULT Input(
            [Out, MarshalAs(UnmanagedType.LPStr)] StringBuilder Buffer,
            [In] int BufferSize,
            [Out] out uint InputSize);

        /// <summary>
        /// The ReturnInput method is used by IDebugInputCallbacks objects to send an input string to the engine following a request for input.
        /// </summary>
        /// <param name="Buffer">[in] Specifies the input string being sent to the engine.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// For an overview of input in the debugger engine, see Input and Output.
        /// </remarks>
        [PreserveSig]
        new HRESULT ReturnInput(
            [In, MarshalAs(UnmanagedType.LPStr)] string Buffer);

        /// <summary>
        /// The Output method formats a string and send the result to output callbacks that have been registered with the engine's clients.
        /// </summary>
        /// <param name="Mask">[in] Specifies the output-type bit field. See DEBUG_OUTPUT_XXX for possible values.</param>
        /// <param name="Format">[in] Specifies the format string, as in printf. In general, conversion characters work exactly as in C. For the floating-point conversion characters the 64-bit argument is interpreted as a 32-bit floating-point number unless the l modifier is used.<para/>
        /// The %p conversion character is supported, but it represents a pointer in a target's address space. It cannot have any modifiers and it uses the debugger's internal address formatting.<para/>
        /// The following additional conversion characters are supported.</param>
        /// <param name="...">Specifies additional parameters that contain values to be inserted into the output during formatting.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// When generating very large output strings, it is possible to reach the limits of the debugger engine or of the
        /// operating system. For example, some versions of the debugger engine have a 16K character limit for a single output.
        /// If you find that very large output is getting truncated, you might need to split your output into multiple requests.
        /// </remarks>
        [PreserveSig]
        new HRESULT Output(
            [In] DEBUG_OUTPUT Mask,
            [In, MarshalAs(UnmanagedType.LPStr)] string Format);

        /// <summary>
        /// The OutputVaList method formats a string and sends the result to the output callbacks that are registered with the engine's clients.
        /// </summary>
        /// <param name="Mask">[in] Specifies the output-type bit field. See DEBUG_OUTPUT_XXX for possible values.</param>
        /// <param name="Format">[in] Specifies the format string, as in printf. Typically, conversion characters work exactly as they do in C. For the floating-point conversion characters, the 64-bit argument is interpreted as a 32-bit floating-point number unless the l modifier is used.<para/>
        /// The %p conversion character is supported, but it represents a pointer in a target's address space. It might not have any modifiers, and it uses the debugger's internal address formatting.<para/>
        /// The following additional conversion characters are supported.</param>
        /// <param name="va_list_Args">[in] Specifies additional parameters that represent values to be inserted into the output during formatting. Args must be initialized using va_start.<para/>
        /// This method does not call va_end.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// When generating very large output strings, it is possible to reach the limits of the debugger engine or of the
        /// operating system. For example, some versions of the debugger engine have a 16K character limit for a single output.
        /// If you find that very large output is getting truncated, you might need to split your output into multiple requests.
        /// </remarks>
        [PreserveSig]
        [Obsolete("This method cannot be safely called from managed code")]
        new HRESULT OutputVaList(
            [In] DEBUG_OUTPUT Mask,
            [In, MarshalAs(UnmanagedType.LPStr)] string Format,
            [In] IntPtr va_list_Args);

        /// <summary>
        /// The ControlledOutput method formats a string and sends the result to output callbacks that were registered with some of the engine's clients.
        /// </summary>
        /// <param name="OutputControl">[in] Specifies an output control that determines which of the clients' output callbacks will receive the output.<para/>
        /// For possible values, see DEBUG_OUTCTL_XXX. For more information about output, see Input and Output.</param>
        /// <param name="Mask">[in] Specifies the output-type bit field. See DEBUG_OUTPUT_XXX for possible values.</param>
        /// <param name="Format">[in] Specifies the format string, as in printf. Typically, conversion characters work exactly as they do in C. For the floating-point conversion characters, the 64-bit argument is interpreted as a 32-bit floating-point number unless the l modifier is used.<para/>
        /// The %p conversion character is supported, but it represents a pointer in a target's address space. It might not have any modifiers and it uses the debugger's internal address formatting.<para/>
        /// The following additional conversion characters are supported. The %Y format specifier can be used to support the Debugger Markup Language (DML).<para/>
        /// For more information, see Customizing Debugger Output Using DML. The following table summarizes the use of the %Y format specifier.<para/>
        /// This code snippet illustrates the use of the %Y format specifier. This sample code would generate the following output.</param>
        /// <param name="...">Specifies additional parameters that represent values to be inserted into the output during formatting.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// When generating very large output strings, it is possible to reach the limits of the debugger engine or of the
        /// operating system. For example, some versions of the debugger engine have a 16K character limit for a single output.
        /// If you find that very large output is getting truncated, you might need to split your output into multiple requests.
        /// </remarks>
        [PreserveSig]
        new HRESULT ControlledOutput(
            [In] DEBUG_OUTCTL OutputControl,
            [In] DEBUG_OUTPUT Mask,
            [In, MarshalAs(UnmanagedType.LPStr)] string Format);

        /// <summary>
        /// The ControlledOutputVaList method formats a string and sends the result to output callbacks that were registered with some of the engine's clients.
        /// </summary>
        /// <param name="OutputControl">[in] Specifies an output control that determines which client's output callbacks will receive the output. For possible values, see DEBUG_OUTCTL_XXX.<para/>
        /// For more information about output, see Input and Output.</param>
        /// <param name="Mask">[in] Specifies the output-type bit field. See DEBUG_OUTPUT_XXX for possible values.</param>
        /// <param name="Format">[in] Specifies the format string, as in printf. Typically, conversion characters work exactly as they do in C. For the floating-point conversion characters, the 64-bit argument is interpreted as a 32-bit floating-point number unless the l modifier is used.<para/>
        /// The %p conversion character is supported, but it represents a pointer in a target's address space. It might not have any modifiers, and it uses the debugger's internal address formatting.<para/>
        /// The following additional conversion characters are supported. The %Y format specifier can be used to support the Debugger Markup Language (DML).<para/>
        /// For more information, see Customizing Debugger Output Using DML. The following table summarizes the use of the %Y format specifier.<para/>
        /// This code snippet illustrates the use of the %Y format specifier. This sample code would generate the following output.</param>
        /// <param name="va_list_Args">[in] Specifies additional parameters that represent values to be inserted into the output during formatting. Args must be initialized using va_start.<para/>
        /// This method does not call va_end.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// When generating very large output strings, it is possible to reach the limits of the debugger engine or of the
        /// operating system. For example, some versions of the debugger engine have a 16K character limit for a single output.
        /// If you find that very large output is getting truncated, you might need to split your output into multiple requests.
        /// The macros va_list, va_start, and va_end are defined in Stdarg.h.
        /// </remarks>
        [PreserveSig]
        [Obsolete("This method cannot be safely called from managed code")]
        new HRESULT ControlledOutputVaList(
            [In] DEBUG_OUTCTL OutputControl,
            [In] DEBUG_OUTPUT Mask,
            [In, MarshalAs(UnmanagedType.LPStr)] string Format,
            [In] IntPtr va_list_Args);

        /// <summary>
        /// The OutputPrompt method formats and sends a user prompt to the output callback objects.
        /// </summary>
        /// <param name="OutputControl">[in] Specifies an output control that determines which of the client's output callbacks will receive the output.<para/>
        /// For possible values, see DEBUG_OUTCTL_XXX.</param>
        /// <param name="Format">[in, optional] Specifies the format string, as in printf. Typically, conversion characters work exactly as they do in C.<para/>
        /// For the floating-point conversion characters, the 64-bit argument is interpreted as a 32-bit floating-point number unless the l modifier is used.<para/>
        /// The %p conversion character is supported, but it represents a pointer in a target's address space. It might not have any modifiers and it uses the debugger's internal address formatting.<para/>
        /// The following additional conversion characters are supported. If Format is NULL, only the standard prompt text is sent to the output callbacks.</param>
        /// <param name="...">Specifies additional parameters that represent values to be inserted into the output during formatting.</param>
        /// <returns>This method can also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// OutputPrompt and OutputPromptWide can be used to prompt the user for input. The standard prompt will be sent to
        /// the output callbacks before the formatted text described by Format. The contents of the standard prompt is returned
        /// by the method <see cref="GetPromptText"/>. The prompt text is sent to the output callbacks with the DEBUG_OUTPUT_PROMPT
        /// output mask set. For more information about prompting the user, see Using Input and Output.
        /// </remarks>
        [PreserveSig]
        new HRESULT OutputPrompt(
            [In] DEBUG_OUTCTL OutputControl,
            [In, MarshalAs(UnmanagedType.LPStr)] string Format);

        /// <summary>
        /// The OutputPromptVaList method formats and sends a user prompt to the output callback objects.
        /// </summary>
        /// <param name="OutputControl">[in] Specifies an output control that determines which of the client's output callbacks will receive the output.<para/>
        /// For possible values, see DEBUG_OUTCTL_XXX.</param>
        /// <param name="Format">[in, optional] Specifies the format string, as in printf. Typically, conversion characters work exactly as they do in C.<para/>
        /// For the floating-point conversion characters, the 64-bit argument is interpreted as a 32-bit floating-point number unless the l modifier is used.<para/>
        /// The %p conversion character is supported, but it represents a pointer in a target's address space. It might not have any modifiers and it uses the debugger's internal address formatting.<para/>
        /// The following additional conversion characters are supported. If Format is NULL, only the standard prompt text is sent to the output callbacks.</param>
        /// <param name="va_list_Args">[in] Specifies additional parameters that represent values to be inserted into the output during formatting. Args must be initialized using va_start.<para/>
        /// This method does not call va_end.</param>
        /// <returns>This method can also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// OutputPromptVaList and OutputPromptVaListWide can be used to prompt the user for input. The standard prompt will
        /// be sent to the output callbacks before the formatted text described by Format. The contents of the standard prompt
        /// is returned by the method <see cref="GetPromptText"/>. The prompt text is sent to the output callbacks with the
        /// DEBUG_OUTPUT_PROMPT output mask set. For more information about prompting the user, see Using Input and Output.
        /// </remarks>
        [PreserveSig]
        [Obsolete("This method cannot be safely called from managed code")]
        new HRESULT OutputPromptVaList(
            [In] DEBUG_OUTCTL OutputControl,
            [In, MarshalAs(UnmanagedType.LPStr)] string Format,
            [In] IntPtr va_list_Args);

        /// <summary>
        /// The GetPromptText method returns the standard prompt text that will be prepended to the formatted output specified in the OutputPrompt and <see cref="OutputPromptVaList"/> methods.
        /// </summary>
        /// <param name="Buffer">[out, optional] Receives the prompt text. If Buffer is NULL, this information is not returned.</param>
        /// <param name="BufferSize">[in] Specifies the size, in characters, of the Buffer buffer.</param>
        /// <param name="TextSize">[out, optional] Receives the size, in characters, of the prompt text. If TextSize is NULL, this information is not returned.</param>
        /// <returns>This method can also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// For more information about prompting the user, see Using Input and Output.
        /// </remarks>
        [PreserveSig]
        new HRESULT GetPromptText(
            [Out, MarshalAs(UnmanagedType.LPStr)] StringBuilder Buffer,
            [In] int BufferSize,
            [Out] out uint TextSize);

        /// <summary>
        /// The OutputCurrentState method prints the current state of the current target to the debugger console.
        /// </summary>
        /// <param name="OutputControl">[in] Specifies which clients to send the output to. For possible values see DEBUG_OUTCTL_XXX.</param>
        /// <param name="Flags">[in] Specifies the bit set that determines the information to print to the debugger console. Flags can be any combination of values from the following table.<para/>
        /// Alternatively, Flags can be set to DEBUG_CURRENT_DEFAULT. This value includes all of the above flags.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// Setting the flags contained in Flags merely allows the information to be printed. The information will not always
        /// be printed (for example, it will not be printed if it is not available). This is the same status information that
        /// is printed when breaking into the debugger. For more information, see Target Information.
        /// </remarks>
        [PreserveSig]
        new HRESULT OutputCurrentState(
            [In] DEBUG_OUTCTL OutputControl,
            [In] DEBUG_CURRENT Flags);

        /// <summary>
        /// The OutputVersionInformation method prints version information about the debugger engine to the debugger console.
        /// </summary>
        /// <param name="OutputControl">[in] Specifies where to send the output. For possible values, see DEBUG_OUTCTL_XXX.</param>
        /// <returns>This method may also return other error values, including error values caused by the engine being busy. See Return Values for more details.</returns>
        /// <remarks>
        /// The information that is sent to the output can include the mode of the debugger, the path and version of the debugger
        /// DLLs, the extension DLL search path, the extension DLL chain, and the version of the operating system that is running
        /// on the host computer. For more information, see Target Information.
        /// </remarks>
        [PreserveSig]
        new HRESULT OutputVersionInformation(
            [In] DEBUG_OUTCTL OutputControl);

        /// <summary>
        /// The GetNotifyEventHandle method receives the handle of the event that will be signaled after the next exception in a target.
        /// </summary>
        /// <param name="Handle">[out] Receives the handle of the event that will be signaled. If Handle is NULL, no event will be signaled.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// If an event to be signaled was set and an exception occurs in a target, when the engine resumes execution in the
        /// target again, the event will be signaled. The event will only be signaled once. After it has been signaled, this
        /// method will return NULL to Handle, unless <see cref="SetNotifyEventHandle"/> is called to set another event to
        /// signal.
        /// </remarks>
        [PreserveSig]
        new HRESULT GetNotifyEventHandle(
            [Out] out ulong Handle);

        /// <summary>
        /// The SetNotifyEventHandle method sets the event that will be signaled after the next exception in a target.
        /// </summary>
        /// <param name="Handle">[in] Specifies the handle of the event to signal. If Handle is NULL, no event will be signaled.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// After setting the event to signal, and after the next exception occurs in a target, when the engine resumes execution
        /// in the target, the event will be signaled. The event will only be signaled once. After it has been signaled, GetNotifyEventHandle
        /// will return NULL, unless this method is called to set another event to signal.
        /// </remarks>
        [PreserveSig]
        new HRESULT SetNotifyEventHandle(
            [In] ulong Handle);

        /// <summary>
        /// The Assemble method assembles a single processor instruction. The assembled instruction is placed in the target's memory.
        /// </summary>
        /// <param name="Offset">[in] Specifies the location in the target's memory to place the assembled instruction.</param>
        /// <param name="Instr">[in] Specifies the instruction to assemble. The instruction is assembled according to the target's effective processor type (returned by <see cref="SetEffectiveProcessorType"/>).</param>
        /// <param name="EndOffset">[out] Receives the location in the target's memory immediately following the assembled instruction. EndOffset can be used when assembling multiple instructions.</param>
        /// <returns>This method can also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// The assembly language depends on the effective processor type of the target machine. For information about the
        /// assembly language, see the processor documentation. For an overview of using assembly in debugger applications,
        /// see Debugging in Assembly Mode. For more information about using assembly with the debugger engine API, see Assembling
        /// and Disassembling Instructions.
        /// </remarks>
        [PreserveSig]
        new HRESULT Assemble(
            [In] ulong Offset,
            [In, MarshalAs(UnmanagedType.LPStr)] string Instr,
            [Out] out ulong EndOffset);

        /// <summary>
        /// The Disassemble method disassembles a processor instruction in the target's memory.
        /// </summary>
        /// <param name="Offset">[in] Specifies the location in the target's memory of the instruction to disassemble.</param>
        /// <param name="Flags">[in] Specifies the bit-flags that affect the behavior of this method. Currently the only flag that can be set is DEBUG_DISASM_EFFECTIVE_ADDRESS; when set, the engine will compute the effective address from the current register information and display it.</param>
        /// <param name="Buffer">[out, optional] Receives the disassembled instruction. If Buffer is NULL, this information is not returned.</param>
        /// <param name="BufferSize">[in] Specifies the size, in characters, of the Buffer buffer.</param>
        /// <param name="DisassemblySize">[out, optional] Receives the size, in characters, of the disassembled instruction. If DisassemblySize is NULL, this information is not returned.</param>
        /// <param name="EndOffset">[out] Receives the location in the target's memory of the instruction following the disassembled instruction.</param>
        /// <returns>This method can also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// The assembly language depends on the effective processor type of the target system. For information about the assembly
        /// language, see the processor documentation. The disassembly options--returned by <see cref="GetAssemblyOptions"/>--affect
        /// the operation of this method. For an overview of using assembly in debugger applications, see Debugging in Assembly
        /// Mode. For more information about using assembly with the debugger engine API, see Assembling and Disassembling
        /// Instructions.
        /// </remarks>
        [PreserveSig]
        new HRESULT Disassemble(
            [In] ulong Offset,
            [In] DEBUG_DISASM Flags,
            [Out, MarshalAs(UnmanagedType.LPStr)] StringBuilder Buffer,
            [In] int BufferSize,
            [Out] out uint DisassemblySize,
            [Out] out ulong EndOffset);

        /// <summary>
        /// The GetDisassembleEffectiveOffset method returns the address of the last instruction disassembled using <see cref="Disassemble"/>.
        /// </summary>
        /// <param name="Offset">[out] Receives the address in the target's memory of the effective offset from the last instruction disassembled.</param>
        /// <returns>This method can also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// The effective offset is the memory location used by an instruction. For example, if the last instruction to be
        /// disassembled is move ax, [ebp+4], the effective address is the value of ebp+4. This corresponds to the $ea pseudo-register.
        /// For more information about using assembly with the debugger engine API, see Assembling and Disassembling Instructions.
        /// </remarks>
        [PreserveSig]
        new HRESULT GetDisassembleEffectiveOffset(
            [Out] out ulong Offset);

        /// <summary>
        /// The OutputDisassembly method disassembles a processor instruction and sends the disassembly to the output callbacks.
        /// </summary>
        /// <param name="OutputControl">[in] Specifies the output control that determines which client's output callbacks receive the output. For possible values, see DEBUG_OUTCTL_XXX.<para/>
        /// For more information about output, see Input and Output.</param>
        /// <param name="Offset">[in] Specifies the location in the target's memory of the instruction to disassemble.</param>
        /// <param name="Flags">[in] Specifies the bit-flags that affect the behavior of this method. The following table lists the bits that can be set.</param>
        /// <param name="EndOffset">[out] Receives the location in the target's memory of the instruction that follows the disassembled instruction.</param>
        /// <returns>This method can also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// The assembly language depends on the effective processor type of the target system. For information about the assembly
        /// language, see the processor documentation. For an overview of using assembly in debugger applications, see Debugging
        /// in Assembly Mode. For more information about using assembly with the debugger engine API, see Assembling and Disassembling
        /// Instructions.
        /// </remarks>
        [PreserveSig]
        new HRESULT OutputDisassembly(
            [In] DEBUG_OUTCTL OutputControl,
            [In] ulong Offset,
            [In] DEBUG_DISASM Flags,
            [Out] out ulong EndOffset);

        /// <summary>
        /// The OutputDisassemblyLines method disassembles several processor instructions and sends the resulting assembly instructions to the output callbacks.
        /// </summary>
        /// <param name="OutputControl">[in] Specifies the output control that determines which client's output callbacks receive the output. For possible values, see DEBUG_OUTCTL_XXX.<para/>
        /// For more information about output, see Input and Output.</param>
        /// <param name="PreviousLines">[in] Specifies the number of lines of instructions before the instruction at Offset to include in the output. Typically, each instruction is output on a single line.<para/>
        /// However, some instructions can take up several lines of output; this can cause the number of lines output before the instruction at Offset to be greater than PreviousLines.</param>
        /// <param name="TotalLines">[in] Specifies the total number of lines of instructions to include in the output. Typically, each instruction is output on a single line.<para/>
        /// However, some instructions can take up several lines of output; this can cause the number of lines output to be greater than TotalLines.</param>
        /// <param name="Offset">[in] Specifies the location in the target's memory of the instructions to disassemble. The disassembly output will start PreviousLines lines before these processor instructions.</param>
        /// <param name="Flags">[in] Specifies the bit-flags that affect the behavior of this method. The following table lists the bits that can be set.</param>
        /// <param name="OffsetLine">[out, optional] Receives the line number in the output that contains the instruction at Offset. If OffsetLine is NULL, this information is not returned.</param>
        /// <param name="StartOffset">[out, optional] Receives the location in the target's memory of the first instruction included in the output. If StartOffset is NULL, this information is not returned.</param>
        /// <param name="EndOffset">[out, optional] Receives the locaiton in the target's memory of the instruction that follows the last disassembled instruction.</param>
        /// <param name="LineOffsets">[out, optional] Receives the locations in the target's memory of the instructions included in the output starting with the instruction at Offset.<para/>
        /// LineOffsets is an array that contains TotalLines elements. Offset is the value of first entry in this array unless there was an error disassembling the instructions before this instruction.<para/>
        /// In this case, the first entry will contain DEBUG_ANY_ID and Offset will be placed in the second entry in the array (index one).<para/>
        /// If the output for an instruction spans multiple lines, the element in the array that corresponds to the first line of the instruction will contain the address of the instruction.<para/>
        /// If LineOffsets is NULL, this information is not returned.</param>
        /// <returns>This method can also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// The assembly language depends on the effective processor type of the target system. For information about the assembly
        /// language, see the processor documentation. For an overview of using assembly in debugger applications, see Debugging
        /// in Assembly Mode. For more information about using assembly with the debugger engine API, see Assembling and Disassembling
        /// Instructions.
        /// </remarks>
        [PreserveSig]
        new HRESULT OutputDisassemblyLines(
            [In] DEBUG_OUTCTL OutputControl,
            [In] uint PreviousLines,
            [In] uint TotalLines,
            [In] ulong Offset,
            [In] DEBUG_DISASM Flags,
            [Out] out uint OffsetLine,
            [Out] out ulong StartOffset,
            [Out] out ulong EndOffset,
            [Out, MarshalAs(UnmanagedType.LPArray)] ulong[] LineOffsets);

        /// <summary>
        /// The GetNearInstruction method returns the location of a processor instruction relative to a given location.
        /// </summary>
        /// <param name="Offset">[in] Specifies the location in the process's virtual address space from which to start looking for the desired instruction.</param>
        /// <param name="Delta">[in] Specifies the number of instructions from Offset of the desired instruction. If Delta is negative, the returned offset is before Offset (see the Remarks section for more information).</param>
        /// <param name="NearOffset">[out] Receives the location in the process's virtual address space of the instruction that is Delta instructions away from Offset.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// On some architectures, like x86 and x64, the size of an instruction may vary. On these architectures, when Delta
        /// is negative, the desired instruction location might not be uniquely defined. In this case, the debugger engine
        /// will search backward from Offset until it encounters a location such that there are the Delta number of instructions
        /// between that location and Offset.
        /// </remarks>
        [PreserveSig]
        new HRESULT GetNearInstruction(
            [In] ulong Offset,
            [In] int Delta,
            [Out] out ulong NearOffset);

        /// <summary>
        /// The GetStackTrace method returns the frames at the top of the specified call stack.
        /// </summary>
        /// <param name="FrameOffset">[in] Specifies the location of the stack frame at the top of the stack. If FrameOffset is set to zero, the current frame pointer is used instead.</param>
        /// <param name="StackOffset">[in] Specifies the location of the current stack. If StackOffset is set to zero, the current stack pointer is used instead.</param>
        /// <param name="InstructionOffset">[in] Specifies the location of the instruction of interest for the function that is represented by the stack frame at the top of the stack.<para/>
        /// If InstructionOffset is set to zero, the current instruction is used instead.</param>
        /// <param name="Frames">[out] Receives the stack frames. The number of elements this array holds is FrameSize.</param>
        /// <param name="FramesFilled">[out, optional] Receives the number of frames that were placed in the array Frames. If FramesFilled is NULL, this information is not returned.</param>
        /// <param name="FrameSize">[in] Specifies the number of items in the Frames array.</param>
        /// <returns>This method may also return other error values. See Return Values for more details.</returns>
        /// <remarks>
        /// The stack trace returned to Frames can be printed using <see cref="OutputStackTrace"/>.
        /// </remarks>
        [PreserveSig]
        new HRESULT GetStackTrace(
            [In] ulong FrameOffset,
            [In] ulong StackOffset,
            [In] ulong InstructionOffset,
            [Out, MarshalAs(UnmanagedType.LPArray)] DEBUG_STACK_FRAME[] Frames,
            [In] int FrameSize,
            [Out] out uint FramesFilled);

        /// <summary>
        /// The GetReturnOffset method returns the return address for the current function.
        /// </summary>
        /// <param name="Offset">[out] Receives the return address.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// The return address is the location in the process's virtual address space of the instruction that will be executed
        /// when the current function returns.
        /// </remarks>
        [PreserveSig]
        new HRESULT GetReturnOffset(
            [Out] out ulong Offset);

        /// <summary>
        /// The OutputStackTrace method outputs either the supplied stack frame or the current stack frames.
        /// </summary>
        /// <param name="OutputControl">[in] Specifies where to send the output. For possible values, see DEBUG_OUTCTL_XXX.</param>
        /// <param name="Frames">[in, optional] Specifies the array of stack frames to output. The number of elements in this array is FramesSize.<para/>
        /// If Frames is NULL, the current stack frames are used.</param>
        /// <param name="FramesSize">[in] Specifies the number of frames to output.</param>
        /// <param name="Flags">[in] Specifies bit flags that determine what information to output for each frame. Flags can be any combination of values from the following table.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// The array of stack frames can be obtained using <see cref="GetStackTrace"/>.
        /// </remarks>
        [PreserveSig]
        new HRESULT OutputStackTrace(
            [In] DEBUG_OUTCTL OutputControl,
            [In, MarshalAs(UnmanagedType.LPArray)] DEBUG_STACK_FRAME[] Frames,
            [In] int FramesSize,
            [In] DEBUG_STACK Flags);

        /// <summary>
        /// The GetDebuggeeType method describes the nature of the current target.
        /// </summary>
        /// <param name="Class">[out] Receives the class of the current target. It will be set to one of the values in the following table.</param>
        /// <param name="Qualifier">[out] Provides more details about the type of the target. Its interpretation depends on the value of Class. When class is DEBUG_CLASS_UNINITIALIZED, Qualifier returns zero.<para/>
        /// The following values are applicable for kernel-mode targets. The following values are applicable for user-mode targets.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        [PreserveSig]
        new HRESULT GetDebuggeeType(
            [Out] out DEBUG_CLASS Class,
            [Out] out DEBUG_CLASS_QUALIFIER Qualifier);

        /// <summary>
        /// The GetActualProcessorType method returns the processor type of the physical processor of the computer that is running the target.
        /// </summary>
        /// <param name="Type">[out] Receives the type of the processor. The processor types are listed in the following table.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// For more information, see Target Information.
        /// </remarks>
        [PreserveSig]
        new HRESULT GetActualProcessorType(
            [Out] out IMAGE_FILE_MACHINE Type);

        /// <summary>
        /// The GetExecutingProcessorType method returns the executing processor type for the processor for which the last event occurred.
        /// </summary>
        /// <param name="Type">[out] Receives the processor type. See <see cref="GetActualProcessorType"/> for a list of possible values this parameter can receive.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// For more information, see Target Information.
        /// </remarks>
        [PreserveSig]
        new HRESULT GetExecutingProcessorType(
            [Out] out IMAGE_FILE_MACHINE Type);

        /// <summary>
        /// The GetNumberPossibleExecutingProcessorTypes method returns the number of processor types that are supported by the computer running the current target.
        /// </summary>
        /// <param name="Number">[out] Receives the number of processor types.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// For more information, see Target Information.
        /// </remarks>
        [PreserveSig]
        new HRESULT GetNumberPossibleExecutingProcessorTypes(
            [Out] out uint Number);

        /// <summary>
        /// The GetPossibleExecutingProcessorTypes method returns the processor types that are supported by the computer running the current target.
        /// </summary>
        /// <param name="Start">[in] Specifies the index of the first processor type to return. The processor types are indexed by numbers zero through to the number of processor types supported by the current target minus one.<para/>
        /// The number of processor types supported by the current target can be found using <see cref="GetNumberPossibleExecutingProcessorTypes"/>.</param>
        /// <param name="Count">[in] Specifies how many processor types to return.</param>
        /// <param name="Types">[out] Receives the list of processor types. The number of elements this array holds is Count. For a description of the processor types see <see cref="GetActualProcessorType"/>.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// For more information, see Target Information.
        /// </remarks>
        [PreserveSig]
        new HRESULT GetPossibleExecutingProcessorTypes(
            [In] uint Start,
            [In] uint Count,
            [Out, MarshalAs(UnmanagedType.LPArray)] IMAGE_FILE_MACHINE[] Types);

        /// <summary>
        /// The GetNumberProcessors method returns the number of processors on the computer running the current target.
        /// </summary>
        /// <param name="Number">[out] Receives the number of processors.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// For more information, see Target Information.
        /// </remarks>
        [PreserveSig]
        new HRESULT GetNumberProcessors(
            [Out] out uint Number);

        /// <summary>
        /// The GetSystemVersion method returns information that identifies the operating system on the computer that is running the current target.
        /// </summary>
        /// <param name="PlatformId">[out] Receives the platform ID. PlatformId is always VER_PLATFORM_WIN32_NT for NT-based Windows.</param>
        /// <param name="Major">[out] Receives 0xF if the target's operating system is a free build, or 0xC if the operating system is a checked build.</param>
        /// <param name="Minor">[out] Receives the build number for the target's operating system.</param>
        /// <param name="ServicePackString">[out, optional] Receives the string for the service pack level of the target computer. If ServicePackString is NULL, this information is not returned.<para/>
        /// If no service pack is installed, ServicePackString can be empty.</param>
        /// <param name="ServicePackStringSize">[in] Specifies the size, in characters, of the buffer that ServicePackString specifies. This size includes the space for the '\0' terminating character.</param>
        /// <param name="ServicePackStringUsed">[out, optional] Receives the size, in characters, of the string of the service pack level. This size includes the space for the '\0' terminating character.<para/>
        /// If ServicePackStringUsed is NULL, this information is not returned.</param>
        /// <param name="ServicePackNumber">[out] Receives the service pack level of the target's operating system.</param>
        /// <param name="BuildString">[out, optional] Receives the string that identifies the build of the system. If BuildString is NULL, this information is not returned.</param>
        /// <param name="BuildStringSize">[in] Specifies the size, in characters, of the buffer that BuildString specifies. This size includes the space for the '\0' terminating character.</param>
        /// <param name="BuildStringUsed">[out, optional] Receives the size, in characters, of the string that identifies the build. This size includes the space for the '\0' terminating character.<para/>
        /// If BuildStringUsed is NULL, this information is not returned.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// For more information, see Target Information.
        /// </remarks>
        [PreserveSig]
        new HRESULT GetSystemVersion(
            [Out] out uint PlatformId,
            [Out] out uint Major,
            [Out] out uint Minor,
            [Out, MarshalAs(UnmanagedType.LPStr)] StringBuilder ServicePackString,
            [In] int ServicePackStringSize,
            [Out] out uint ServicePackStringUsed,
            [Out] out uint ServicePackNumber,
            [Out, MarshalAs(UnmanagedType.LPStr)] StringBuilder BuildString,
            [In] int BuildStringSize,
            [Out] out uint BuildStringUsed);

        /// <summary>
        /// The GetPageSize method returns the page size for the effective processor mode.
        /// </summary>
        /// <param name="Size">[out] Receives the page size.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        [PreserveSig]
        new HRESULT GetPageSize(
            [Out] out uint Size);

        /// <summary>
        /// The IsPointer64Bit method determines if the effective processor uses 64-bit pointers.
        /// </summary>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        [PreserveSig]
        new HRESULT IsPointer64Bit();

        /// <summary>
        /// The ReadBugCheckData method reads the kernel bug check code and related parameters.
        /// </summary>
        /// <param name="Code">[out] Receives the bug check code.</param>
        /// <param name="Arg1">[out] Receives the first parameter associated with the bug check. The interpretation of this parameter depends on the bug check code.</param>
        /// <param name="Arg2">[out] Receives the second parameter associated with the bug check. The interpretation of this parameter depends on the bug check code.</param>
        /// <param name="Arg3">[out] Receives the third parameter associated with the bug check. The interpretation of this parameter depends on the bug check code.</param>
        /// <param name="Arg4">[out] Receives the fourth parameter associated with the bug check. The interpretation of this parameter depends on the bug check code.</param>
        /// <returns>This method can also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// This method is only available in kernel-mode debugging. For more information about bug checks, including a list
        /// of bug check codes and their interpretations, see Bug Checks (Blue Screens).
        /// </remarks>
        [PreserveSig]
        new HRESULT ReadBugCheckData(
            [Out] out uint Code,
            [Out] out ulong Arg1,
            [Out] out ulong Arg2,
            [Out] out ulong Arg3,
            [Out] out ulong Arg4);

        /// <summary>
        /// The GetNumberSupportedProcessorTypes method returns the number of processor types supported by the engine.
        /// </summary>
        /// <param name="Number">[out] Receives the number of processor types.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// For more information, see Target Information.
        /// </remarks>
        [PreserveSig]
        new HRESULT GetNumberSupportedProcessorTypes(
            [Out] out uint Number);

        /// <summary>
        /// The GetSupportedProcessorTypes method returns the processor types supported by the debugger engine.
        /// </summary>
        /// <param name="Start">[in] Specifies the index of the first processor type to return. The supported processor types are indexed by the numbers zero through the number of supported processor types minus one.<para/>
        /// The number of supported processor types can be found using <see cref="GetNumberSupportedProcessorTypes"/>.</param>
        /// <param name="Count">[in] Specifies the number of processor types to return.</param>
        /// <param name="Types">[out] Receives the list of processor types. The number of elements this array holds is Count. For a description of the processor types, see <see cref="GetActualProcessorType"/>.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// For more information, see Target Information.
        /// </remarks>
        [PreserveSig]
        new HRESULT GetSupportedProcessorTypes(
            [In] uint Start,
            [In] uint Count,
            [Out, MarshalAs(UnmanagedType.LPArray)] IMAGE_FILE_MACHINE[] Types);

        /// <summary>
        /// The GetProcessorTypeNames method returns the full name and abbreviated name of the specified processor type.
        /// </summary>
        /// <param name="Type">[in] Specifies the type of the processor whose name is requested. See <see cref="GetActualProcessorType"/> for a list of possible values.</param>
        /// <param name="FullNameBuffer">[out, optional] Receives the full name of the processor type. If FullNameBuffer is NULL, this information is not returned.</param>
        /// <param name="FullNameBufferSize">[in] Specifies the size, in characters, of the buffer that FullNameBuffer specifies. This size includes the space for the '\0' terminating character.</param>
        /// <param name="FullNameSize">[out, optional] Receives the size in characters of the full name of the processor type. This size includes the space for the '\0' terminating character.<para/>
        /// If FullNameSize is NULL, this information is not returned.</param>
        /// <param name="AbbrevNameBuffer">[out, optional] Receives the abbreviated name of the processor type. If AbbrevNameBuffer is NULL, this information is not returned.</param>
        /// <param name="AbbrevNameBufferSize">[in] Specifies the size, in characters, of the buffer that AbbrevNameBuffer specifies. This size includes the space for the '\0' terminating character.</param>
        /// <param name="AbbrevNameSize">[out, optional] Receives the size in characters of the abbreviated name of the processor type. This size includes the space for the '\0' terminating character.<para/>
        /// If AbbrevNameSize is NULL, this information is not returned.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// For more information, see Target Information.
        /// </remarks>
        [PreserveSig]
        new HRESULT GetProcessorTypeNames(
            [In] IMAGE_FILE_MACHINE Type,
            [Out, MarshalAs(UnmanagedType.LPStr)] StringBuilder FullNameBuffer,
            [In] int FullNameBufferSize,
            [Out] out uint FullNameSize,
            [Out, MarshalAs(UnmanagedType.LPStr)] StringBuilder AbbrevNameBuffer,
            [In] int AbbrevNameBufferSize,
            [Out] out uint AbbrevNameSize);

        /// <summary>
        /// The GetEffectiveProcessorType method returns the effective processor type of the processor of the computer that is running the target.
        /// </summary>
        /// <param name="Type">[out] Receives the type of the processor. For possible values, see the Type parameter in <see cref="GetActualProcessorType"/>.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// For more information, see Target Information.
        /// </remarks>
        [PreserveSig]
        new HRESULT GetEffectiveProcessorType(
            [Out] out IMAGE_FILE_MACHINE Type);

        /// <summary>
        /// The SetEffectiveProcessorType method sets the effective processor type of the processor of the computer that is running the target.
        /// </summary>
        /// <param name="Type">[in] Specifies the type of the processor. For possible values, see the Type parameter in <see cref="GetActualProcessorType"/>.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// For more information, see Target Information.
        /// </remarks>
        [PreserveSig]
        new HRESULT SetEffectiveProcessorType(
            [In] IMAGE_FILE_MACHINE Type);

        /// <summary>
        /// The GetExecutionStatus method returns information about the execution status of the debugger engine.
        /// </summary>
        /// <param name="Status">[out] Receives the execution status. This will be set to one of the values in the following table. Note that the description of these values differs slightly from the description in DEBUG_STATUS_XXX.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// For more information, see Target Information.
        /// </remarks>
        [PreserveSig]
        new HRESULT GetExecutionStatus(
            [Out] out DEBUG_STATUS Status);

        /// <summary>
        /// The SetExecutionStatus method requests that the debugger engine enter an executable state. Actual execution will not occur until the next time <see cref="WaitForEvent"/> is called.
        /// </summary>
        /// <param name="Status">[in] Specifies the mode for the engine to use when executing. Possible values are those values in the table in DEBUG_STATUS_XXX whose precedence lies between DEBUG_STATUS_GO and DEBUG_STATUS_STEP_INTO.</param>
        /// <returns>This method may also return other error values. See Return Values for more details.</returns>
        /// <remarks>
        /// For more information, see Target Information.
        /// </remarks>
        [PreserveSig]
        new HRESULT SetExecutionStatus(
            [In] DEBUG_STATUS Status);

        /// <summary>
        /// The GetCodeLevel method returns the current code level and is mainly used when stepping through code.
        /// </summary>
        /// <param name="Level">[out] Receives the current code level. Level can take one of the values in the following table.</param>
        /// <returns>This method can also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// For more information about the code level, see Using Source Files.
        /// </remarks>
        [PreserveSig]
        new HRESULT GetCodeLevel(
            [Out] out DEBUG_LEVEL Level);

        /// <summary>
        /// The SetCodeLevel method sets the current code level and is mainly used when stepping through code.
        /// </summary>
        /// <param name="Level">[in] Specifies the current code level. Level can take one of the values in the following table.</param>
        /// <returns>This method can also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// For more information about the code level, see Using Source Files.
        /// </remarks>
        [PreserveSig]
        new HRESULT SetCodeLevel(
            [In] DEBUG_LEVEL Level);

        /// <summary>
        /// The GetEngineOptions method returns the engine's options.
        /// </summary>
        /// <param name="Options">[out] Receives a bit-set that contains the engine's options. For a description of the engine options, see DEBUG_ENGOPT_XXX.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        [PreserveSig]
        new HRESULT GetEngineOptions(
            [Out] out DEBUG_ENGOPT Options);

        /// <summary>
        /// The AddEngineOptions method turns on some of the debugger engine's options.
        /// </summary>
        /// <param name="Options">[in] Specifies engine options to turn on. Options is a bit-set that will be combined with the existing engine options using the bitwise-OR operator.<para/>
        /// For a description of the engine options, see DEBUG_ENGOPT_XXX.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// After the engine options have been changed, the engine sends out notification to each client's event callback object
        /// by passing the DEBUG_CES_ENGINE_OPTIONS flag to the <see cref="IDebugEventCallbacks.ChangeEngineState"/> method.
        /// </remarks>
        [PreserveSig]
        new HRESULT AddEngineOptions(
            [In] DEBUG_ENGOPT Options);

        /// <summary>
        /// The RemoveEngineOptions method turns off some of the engine's options.
        /// </summary>
        /// <param name="Options">[in] Specifies the engine options to turn off. Options is a bit-set; the new value of the engine's options will equal the bitwise-NOT of Options combined with old value using the bitwise-AND operator (new_value := old_value AND NOT Options).<para/>
        /// For a description of the engine options, see DEBUG_ENGOPT_XXX.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// After the engine options have been changed, the engine sends out notification to each client's event callback object
        /// by passing the DEBUG_CES_ENGINE_OPTIONS flag to the <see cref="IDebugEventCallbacks.ChangeEngineState"/> method.
        /// </remarks>
        [PreserveSig]
        new HRESULT RemoveEngineOptions(
            [In] DEBUG_ENGOPT Options);

        /// <summary>
        /// The SetEngineOptions method changes the engine's options.
        /// </summary>
        /// <param name="Options">[in] Specifies the engine's new options. Options is a bit-set; it will replace the existing symbol options. For a description of the engine options, see Remarks.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// This method will set the engine's options to those specified in Options. Unlike <see cref="AddEngineOptions"/>,
        /// any symbol options that are not listed in the Options bit-set will be removed. After the engine options have been
        /// changed, the engine sends out notification to each client's event callback object by passing the DEBUG_CES_ENGINE_OPTIONS
        /// flag to the <see cref="IDebugEventCallbacks.ChangeEngineState"/> method. The following global options affect the
        /// behavior of the debugger engine: This option cannot be set if DEBUG_ENGOPT_DISALLOW_NETWORK_PATHS is set. This
        /// option cannot be set if DEBUG_ENGOPT_ALLOW_NETWORK_PATHS is set. For example, this option allows Windows 3.51 binaries
        /// to run when debugging Windows 3.1 and 3.5 systems. The debugger attempts to load images when debugging minidumps
        /// that do not contain images. When setting software breakpoints, the engine transparently alters the target's memory
        /// to insert an interrupt instruction. This option is useful when multiple threads can use the code for which the
        /// breakpoint is set. However, it can introduce the possibility of deadlocks. After this option has been set, it cannot
        /// be unset.
        /// </remarks>
        [PreserveSig]
        new HRESULT SetEngineOptions(
            [In] DEBUG_ENGOPT Options);

        /// <summary>
        /// The GetSystemErrorControl method returns the control values for handling system errors.
        /// </summary>
        /// <param name="OutputLevel">[out] Receives the level at which system errors are printed to the engine's output. If the level of the system error is less than or equal to OutputLevel, the error is printed to the debugger console.</param>
        /// <param name="BreakLevel">[out] Receives the level at which system errors break into the debugger. If the level of the system error is less than or equal to BreakLevel, the error breaks into the debugger.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// The level of a system error can take one of the following three values, listed from lowest to highest: SLE_ERROR,
        /// SLE_MINORERROR, and SLE_WARNING. These values are defined in Winuser.h. When a system error occurs, the engine
        /// calls the <see cref="IDebugEventCallbacks.SystemError"/> method of the event callbacks. If the level is less than
        /// or equal to BreakLevel, the error will break into the debugger. If the level is greater than BreakLevel, the engine
        /// will proceed with execution in the target as indicated by the IDebugEventCallbacks::SystemError method calls. For
        /// more information about how the engine proceeds after an event, see Monitoring Events.
        /// </remarks>
        [PreserveSig]
        new HRESULT GetSystemErrorControl(
            [Out] out ERROR_LEVEL OutputLevel,
            [Out] out ERROR_LEVEL BreakLevel);

        /// <summary>
        /// The SetSystemErrorControl method sets the control values for handling system errors.
        /// </summary>
        /// <param name="OutputLevel">[in] Specifies the level at which system errors are printed to the engine's output. If the level of the system error is less than or equal to OutputLevel, the error is printed to the debugger console.</param>
        /// <param name="BreakLevel">[in] Specifies the level at which system errors break into the debugger. If the level of the system error is less than or equal to BreakLevel, the error breaks into the debugger.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// The level of a system error can take one of the following three values, listed from lowest to highest: SLE_ERROR,
        /// SLE_MINORERROR, and SLE_WARNING. These values are defined in Winuser.h. When a system error occurs, the engine
        /// calls the <see cref="IDebugEventCallbacks.SystemError"/> method of the event callbacks. If the level is less than
        /// or equal to the BreakLevel parameter, the error will break into the debugger. If the level is greater than BreakLevel,
        /// the engine will proceed with execution in the target as indicated by the IDebugEventCallbacks::SystemError method
        /// calls. For more information about how the engine proceeds after an event, see Monitoring Events.
        /// </remarks>
        [PreserveSig]
        new HRESULT SetSystemErrorControl(
            [In] ERROR_LEVEL OutputLevel,
            [In] ERROR_LEVEL BreakLevel);

        /// <summary>
        /// The GetTextMacro method returns the value of a fixed-name alias.
        /// </summary>
        /// <param name="Slot">[in] Specifies the number of the fixed-name alias. Slot can take the values 0, 1, ..., 9, that represent the fixed-name aliases $u0, $u1, ..., $u9.</param>
        /// <param name="Buffer">[out, optional] Receives the value of the alias specified by Slot. If Buffer is NULL, this information is not returned.</param>
        /// <param name="BufferSize">[in] Specifies the size, in characters, of the Buffer buffer.</param>
        /// <param name="MacroSize">[out, optional] Receives the size, in characters, of the value of the alias.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// Before executing commands or evaluating expressions, the debugger engine will replace the alias specified by Slot
        /// with the value of the alias (returned to the Buffer buffer). For an overview of aliases used by the debugger engine,
        /// see Using Aliases. For more information about using aliases with the debugger engine API, see Interacting with
        /// the Engine.
        /// </remarks>
        [PreserveSig]
        new HRESULT GetTextMacro(
            [In] uint Slot,
            [Out, MarshalAs(UnmanagedType.LPStr)] StringBuilder Buffer,
            [In] int BufferSize,
            [Out] out uint MacroSize);

        /// <summary>
        /// The SetTextMacro method sets the value of a fixed-name alias.
        /// </summary>
        /// <param name="Slot">[in] Specifies the number of the fixed-name alias. Slot can take the values 0, 1, ..., 9, that represent the fixed-name aliases $u0, $u1, ..., $u9.</param>
        /// <param name="Macro">[in] Specifies the new value of the alias specified by Slot. The debugger engine makes a copy of this string.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// Before executing commands or evaluating expressions, the debugger engine will replace the alias specified by Slot
        /// with the value of the alias (specified by Macro). For an overview of aliases used by the debugger engine, see Using
        /// Aliases. For more information about using aliases with the debugger engine API, see Interacting with the Engine.
        /// </remarks>
        [PreserveSig]
        new HRESULT SetTextMacro(
            [In] uint Slot,
            [In, MarshalAs(UnmanagedType.LPStr)] string Macro);

        /// <summary>
        /// The GetRadix method returns the default radix (number base) used by the debugger engine when it evaluates and displays MASM expressions, and when it displays symbol information.
        /// </summary>
        /// <param name="Radix">[out] Receives the default radix.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// For more information about the default radix, see Using Input and Output.
        /// </remarks>
        [PreserveSig]
        new HRESULT GetRadix(
            [Out] out uint Radix);

        /// <summary>
        /// The SetRadix method sets the default radix (number base) used by the debugger engine when it evaluates and displays MASM expressions, and when it displays symbol information.
        /// </summary>
        /// <param name="Radix">[in] Specifies the new default radix. The following table contains the possible values for the radix.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// When the radix is changed, the engine notifies the event callbacks by passing the DEBUG_CES_RADIX flag to the <see
        /// cref="IDebugEventCallbacks.ChangeEngineState"/> callback method. For more information about the default radix,
        /// see Using Input and Output.
        /// </remarks>
        [PreserveSig]
        new HRESULT SetRadix(
            [In] uint Radix);

        /// <summary>
        /// The Evaluate method evaluates an expression, returning the result.
        /// </summary>
        /// <param name="Expression">[in] Specifies the expression to be evaluated.</param>
        /// <param name="DesiredType">[in] Specifies the desired return type. Possible values are described in <see cref="DEBUG_VALUE"/>; with the addition of DEBUG_VALUE_INVALID, which indicates that the return type should be the expression's natural type.</param>
        /// <param name="Value">[out] Receives the value of the expression.</param>
        /// <param name="RemainderIndex">[out, optional] Receives the index of the first character of the expression not used in the evaluation. If RemainderIndex is NULL, this information isn't returned.</param>
        /// <returns>This method may also return other error values. See Return Values for more details.</returns>
        /// <remarks>
        /// Expressions are evaluated by the current expression evaluator. The engine contains multiple expression evaluators;
        /// each supports a different syntax. The current expression evaluator can be chosen by using <see cref="SetExpressionSyntax"/>.
        /// For details of the available expression evaluators and their syntaxes, see Numerical Expression Syntax. If an error
        /// occurs while evaluating the expression, returning E_FAIL, the RemainderIndex variable can be used to determine
        /// approximately where in the expression the error occurred.
        /// </remarks>
        [PreserveSig]
        new HRESULT Evaluate(
            [In, MarshalAs(UnmanagedType.LPStr)] string Expression,
            [In] DEBUG_VALUE_TYPE DesiredType,
            [Out] out DEBUG_VALUE Value,
            [Out] out uint RemainderIndex);

        /// <summary>
        /// The CoerceValue method converts a value of one type into a value of another type.
        /// </summary>
        /// <param name="In">[in] Specifies the value to be converted</param>
        /// <param name="OutType">[in] Specifies the desired type for the converted value. See <see cref="DEBUG_VALUE"/> for possible values.</param>
        /// <param name="Out">[out] Receives the converted value. The type of this value will be the type specified by OutType.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// This method converts a value of one type into a value of another type. If the specified OutType is not capable
        /// of containing the information supplied by the In variable, data will be lost.
        /// </remarks>
        [PreserveSig]
        new HRESULT CoerceValue(
            [In] DEBUG_VALUE In,
            [In] DEBUG_VALUE_TYPE OutType,
            [Out] out DEBUG_VALUE Out);

        /// <summary>
        /// The CoerceValues method converts an array of values into an array of values of different types.
        /// </summary>
        /// <param name="Count">[in] Specifies the number of values to convert.</param>
        /// <param name="In">[in] Specifies the array of values to convert. The number of elements that this array holds is Count.</param>
        /// <param name="Out">[out] Specifies the array to be populated by the converted values. The types of these values are specified by OutType.<para/>
        /// The number of elements that this array holds is Count.</param>
        /// <param name="OutType">[in] Specifies the array of desired types for the converted values. For possible values, see <see cref="DEBUG_VALUE"/>.<para/>
        /// The number of elements that this array holds is Count.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// This method converts an array of values of one type into values of another type. Some of these conversions can
        /// result in loss of precision.
        /// </remarks>
        [PreserveSig]
        new HRESULT CoerceValues(
            [In] uint Count,
            [In, MarshalAs(UnmanagedType.LPArray)] DEBUG_VALUE[] In,
            [In, MarshalAs(UnmanagedType.LPArray)] DEBUG_VALUE_TYPE[] OutType,
            [Out, MarshalAs(UnmanagedType.LPArray)] DEBUG_VALUE[] Out);

        /// <summary>
        /// The Execute method executes the specified debugger commands.
        /// </summary>
        /// <param name="OutputControl">[in] Specifies the output control to use while executing the command. For possible values, see DEBUG_OUTCTL_XXX.<para/>
        /// For more information about output, see Input and Output.</param>
        /// <param name="Command">[in] Specifies the command string to execute. The command is interpreted like those typed into a debugger command window.<para/>
        /// This command string can contain multiple commands for the engine to execute. See Debugger Commands for the command reference.</param>
        /// <param name="Flags">[in] Specifies a bit field of execution options for the command. The default options are to log the command but to not send it to the output.<para/>
        /// The following table lists the bits that can be set.</param>
        /// <returns>This method can also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// This method executes the given command string. If the string has multiple commands, this method will not return
        /// until all of the commands have been executed. If the sequence of commands involves waiting for the target to execute,
        /// this method can take an arbitrary amount of time to complete.
        /// </remarks>
        [PreserveSig]
        new HRESULT Execute(
            [In] DEBUG_OUTCTL OutputControl,
            [In, MarshalAs(UnmanagedType.LPStr)] string Command,
            [In] DEBUG_EXECUTE Flags);

        /// <summary>
        /// The ExecuteCommandFile method opens the specified file and executes the debugger commands that are contained within.
        /// </summary>
        /// <param name="OutputControl">[in] Specifies where to send the output of the command. For possible values, see DEBUG_OUTCTL_XXX. For more information about output, see Input and Output.</param>
        /// <param name="CommandFile">[in] Specifies the name of the file that contains the commands to execute. This file is opened for reading and its contents are interpreted as if they had been typed into the debugger console.</param>
        /// <param name="Flags">[in] Specifies execution options for the command. The default options are to log the command but not to send it to the output.<para/>
        /// For details about the values that Flags can take, see <see cref="Execute"/>.</param>
        /// <returns>This method might also return error values, including error values caused by a failure to open the specified file.<para/>
        /// For more information, see Return Values.</returns>
        /// <remarks>
        /// This method reads the specified file and execute the commands one line at a time using <see cref="Execute"/>. If
        /// an exception occurred while executing a line, the execution will continue with the next line.
        /// </remarks>
        [PreserveSig]
        new HRESULT ExecuteCommandFile(
            [In] DEBUG_OUTCTL OutputControl,
            [In, MarshalAs(UnmanagedType.LPStr)] string CommandFile,
            [In] DEBUG_EXECUTE Flags);

        /// <summary>
        /// The GetNumberBreakpoints method returns the number of breakpoints for the current process.
        /// </summary>
        /// <param name="Number">[out] Receives the number of breakpoints.</param>
        /// <returns>This method can also return error values. See Return Values for more details.</returns>
        [PreserveSig]
        new HRESULT GetNumberBreakpoints(
            [Out] out uint Number);

        /// <summary>
        /// The GetBreakpointByIndex method returns the breakpoint located at the specified index.
        /// </summary>
        /// <param name="Index">[in] Specifies the zero-based index of the breakpoint to return. This is specific to the current process. The value of Index should be between zero and the total number of breakpoints minus one.<para/>
        /// The total number of breakpoints can be determined by calling <see cref="GetNumberBreakpoints"/>.</param>
        /// <param name="bp">[out] Receives the returned breakpoint.</param>
        /// <returns>This method can also return other error values. See Return Values for more details.</returns>
        /// <remarks>
        /// The index and returned breakpoint are specific to the current process. The same index will return a different breakpoint
        /// if the current process is changed.
        /// </remarks>
        [PreserveSig]
        new HRESULT GetBreakpointByIndex(
            [In] uint Index,
            [Out, MarshalAs(UnmanagedType.Interface)]
            out IDebugBreakpoint bp);

        /// <summary>
        /// The GetBreakpointById method returns the breakpoint with the specified breakpoint ID.
        /// </summary>
        /// <param name="Id">[in] Specifies the breakpoint ID of the breakpoint to return.</param>
        /// <param name="bp">[out] Receives the breakpoint.</param>
        /// <returns>This method can also return other error values. See Return Values for more details.</returns>
        /// <remarks>
        /// If the specified breakpoint does not belong to the current process, the method will fail.
        /// </remarks>
        [PreserveSig]
        new HRESULT GetBreakpointById(
            [In] uint Id,
            [Out, MarshalAs(UnmanagedType.Interface)]
            out IDebugBreakpoint bp);

        /// <summary>
        /// The GetBreakpointParameters method returns the parameters of one or more breakpoints.
        /// </summary>
        /// <param name="Count">[in] Specifies the number of breakpoints whose parameters are being requested.</param>
        /// <param name="Ids">[in, optional] Specifies an array containing the IDs of the breakpoints whose parameters are being requested. The number of items in this array must be equal to the value specified in Count.<para/>
        /// If Ids is NULL, Start is used instead.</param>
        /// <param name="Start">[in] Specifies the beginning index of the breakpoints whose parameters are being requested. The parameters for breakpoints with indices Start through Start plus Count minus one will be returned.<para/>
        /// Start is used only if Ids is NULL.</param>
        /// <param name="Params">[out] Receives the parameters for the specified breakpoints. The size of this array is equal to the value of Count.<para/>
        /// For details on the structure returned, see <see cref="DEBUG_BREAKPOINT_PARAMETERS"/>.</param>
        /// <returns>This method can also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// Some of the parameters might not be returned. This happens if either a breakpoint could not be found or a breakpoint
        /// is private (see <see cref="IDebugBreakpoint.GetFlags"/>).
        /// </remarks>
        [PreserveSig]
        new HRESULT GetBreakpointParameters(
            [In] uint Count,
            [In, MarshalAs(UnmanagedType.LPArray)] uint[] Ids,
            [In] uint Start,
            [Out, MarshalAs(UnmanagedType.LPArray)] DEBUG_BREAKPOINT_PARAMETERS[] Params);

        /// <summary>
        /// The AddBreakpoint method creates a new breakpoint for the current target.
        /// </summary>
        /// <param name="Type">[in] Specifies the breakpoint type of the new breakpoint. This can be either of the following values:</param>
        /// <param name="DesiredId">[in] Specifies the desired ID of the new breakpoint. If it is DEBUG_ANY_ID, the engine will pick an unused ID.</param>
        /// <param name="Bp">[out] Receives an interface pointer to the new breakpoint.</param>
        /// <returns>This method may also return other error values. See Return Values for more details.</returns>
        /// <remarks>
        /// If DesiredId is not DEBUG_ANY_ID and another breakpoint already uses the ID DesiredId, these methods will fail.
        /// Breakpoints are created empty and disabled. See Using Breakpoints for details on configuring and enabling the breakpoint.
        /// The client is saved as the adder of the new breakpoint. See <see cref="IDebugBreakpoint.GetAdder"/>.
        /// </remarks>
        [PreserveSig]
        new HRESULT AddBreakpoint(
            [In] DEBUG_BREAKPOINT_TYPE Type,
            [In] uint DesiredId,
            [Out, MarshalAs(UnmanagedType.Interface)]
            out IDebugBreakpoint Bp);

        /// <summary>
        /// The RemoveBreakpoint method removes a breakpoint.
        /// </summary>
        /// <param name="Bp">[in] Specifies an interface pointer to breakpoint to remove.</param>
        /// <returns>This method may also return other error values. See Return Values for more details.</returns>
        /// <remarks>
        /// After RemoveBreakpoint and RemoveBreakpoint2 are called, the breakpoint object specified in the Bp parameter must
        /// not be used again.
        /// </remarks>
        [PreserveSig]
        new HRESULT RemoveBreakpoint(
            [In, MarshalAs(UnmanagedType.Interface)]
            IDebugBreakpoint Bp);

        /// <summary>
        /// The AddExtension method loads an extension library into the debugger engine.
        /// </summary>
        /// <param name="Path">[in] Specifies the fully qualified path and file name of the extension library to load.</param>
        /// <param name="Flags">[in] Set to zero.</param>
        /// <param name="Handle">[out] Receives the handle of the loaded extension library.</param>
        /// <returns>This method can also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// If the extension library has already been loaded, the handle to already loaded library is returned. The extension
        /// library is not loaded again. The extension library is loaded into the host engine and Path contains a path and
        /// file name for this instance of the debugger engine. AddExtension does not complete the process of loading and initializing
        /// the extension DLL. To make the extension available for use, make a subsequent call to the <see cref="GetExtensionFunction"/>.
        /// For more information on using extension libraries, see Calling Extensions and Extension Functions.
        /// </remarks>
        [PreserveSig]
        new HRESULT AddExtension(
            [In, MarshalAs(UnmanagedType.LPStr)] string Path,
            [In] uint Flags,
            [Out] out ulong Handle);

        /// <summary>
        /// The RemoveExtension method unloads an extension library.
        /// </summary>
        /// <param name="Handle">[in] Specifies the handle of the extension library to unload. This is the handle returned by <see cref="AddExtension"/>.</param>
        /// <returns>This method can also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// For more information on using extension libraries, see Calling Extensions and Extension Functions.
        /// </remarks>
        [PreserveSig]
        new HRESULT RemoveExtension(
            [In] ulong Handle);

        /// <summary>
        /// The GetExtensionByPath method returns the handle for an already loaded extension library.
        /// </summary>
        /// <param name="Path">[in] Specifies the fully qualified path and file name of the extension library.</param>
        /// <param name="Handle">[out] Receives the handle of the extension library.</param>
        /// <returns>This method can also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// Extension libraries are loaded into the host engine, which is where this method looks for the requested extension
        /// library. Path is a path and file name for the host engine. For more information on using extension libraries, see
        /// Calling Extensions and Extension Functions.
        /// </remarks>
        [PreserveSig]
        new HRESULT GetExtensionByPath(
            [In, MarshalAs(UnmanagedType.LPStr)] string Path,
            [Out] out ulong Handle);

        /// <summary>
        /// The CallExtension method calls a debugger extension.
        /// </summary>
        /// <param name="Handle">[in] Specifies the handle of the extension library that contains the extension to call. If Handle is zero, the engine will walk the extension library chain searching for the extension.</param>
        /// <param name="Function">[in] Specifies the name of the extension to call.</param>
        /// <param name="Arguments">[in, optional] Specifies the arguments to pass to the extension. Arguments is a string that will be parsed by the extension, just like the extension will parse arguments passed to it when called as an extension command.</param>
        /// <returns>This method can also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// If Handle is zero, the engine searches each extension library until it finds one that contains the extension; the
        /// extension will then be called. If the extension returns DEBUG_EXTENSION_CONTINUE_SEARCH, the search will continue.
        /// For more information on using extension libraries, see Calling Extensions and Extension Functions.
        /// </remarks>
        [PreserveSig]
        new HRESULT CallExtension(
            [In] ulong Handle,
            [In, MarshalAs(UnmanagedType.LPStr)] string Function,
            [In, MarshalAs(UnmanagedType.LPStr)] string Arguments);

        /// <summary>
        /// The GetExtensionFunction method returns a pointer to an extension function from an extension library.
        /// </summary>
        /// <param name="Handle">[in] Specifies the handle of the extension library that contains the extension function. If Handle is zero, the engine will walk the extension library chain searching for the extension function.</param>
        /// <param name="FuncName">[in] Specifies the name of the extension function to return. When searching the extension libraries for the function, the debugger engine will prepend "EFN" to the name.<para/>
        /// For example, if FuncName is "SampleFunction", the engine will search the extension libraries for "_EFN_SampleFunction".</param>
        /// <param name="Function">[out] Receives the extension function.</param>
        /// <returns>This method can also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// Extension libraries are loaded into the host engine and extension functions cannot be called remotely. The current
        /// client must not be a debugging client, it must belong to the host engine. The extension function can have any function
        /// prototype. In order for any program to call this extension function, the extension function should be cast to the
        /// correct prototype. For more information on using extension functions, see Calling Extensions and Extension Functions.
        /// </remarks>
        [PreserveSig]
        new HRESULT GetExtensionFunction(
            [In] ulong Handle,
            [In, MarshalAs(UnmanagedType.LPStr)] string FuncName,
            [Out] out IntPtr Function);

        /// <summary>
        /// The GetWindbgExtensionApis32 method returns a structure that facilitates using the WdbgExts API.
        /// </summary>
        /// <param name="Api">[in, out] Receives a WINDBG_EXTENSION_APIS32 structure. This structure contains the functions used by the WdbgExts API.<para/>
        /// The nSize member of this structure must be set to the size of the structure before it is passed to this method.</param>
        /// <returns>This method may also return other error values. See Return Values for more details.</returns>
        /// <remarks>
        /// If you are including Wdbgexts.h in your extension code, you should call this method during the initialization of
        /// the extension DLL (see DebugExtensionInitialize). Many WdbgExts functions are really macros. To ensure that these
        /// macros work correctly, the structure received by the Api parameter should be stored in a global variable named
        /// ExtensionApis. For a list of the functions provided by the WdbgExts API, see WdbgExts Functions.
        /// </remarks>
        [PreserveSig]
        new HRESULT GetWindbgExtensionApis32(
            [In, Out] ref WINDBG_EXTENSION_APIS Api); //Must initialize nSize, hence ref

        /// <summary>
        /// The GetWindbgExtensionApis64 method returns a structure that facilitates using the WdbgExts API.
        /// </summary>
        /// <param name="Api">[in, out] Receives a WINDBG_EXTENSION_APIS64 structure. This structure contains the functions used by the WdbgExts API.<para/>
        /// The nSize member of this structure must be set to the size of the structure before it is passed to this method.</param>
        /// <returns>This method may also return other error values. See Return Values for more details.</returns>
        /// <remarks>
        /// If you are including Wdbgexts.h in your extension code, you should call this method during the initialization of
        /// the extension DLL (see DebugExtensionInitialize). Many WdbgExts functions are really macros. To ensure that these
        /// macros work correctly, the structure received by the Api parameter should be stored in a global variable named
        /// ExtensionApis. The WINDBG_EXTENSION_APIS64 structure returned by this method serves the same purpose as the one
        /// provided to the callback function WinDbgExtensionDllInit (used by WdbgExts extensions). For a list of the functions
        /// provided by the WdbgExts API, see WdbgExts Functions.
        /// </remarks>
        [PreserveSig]
        new HRESULT GetWindbgExtensionApis64(
            [In, Out] ref WINDBG_EXTENSION_APIS Api); //Must initialize nSize, hence ref

        /// <summary>
        /// The GetNumberEventFilters method returns the number of event filters currently used by the engine.
        /// </summary>
        /// <param name="SpecificEvents">[out] Receives the number of events that can be controlled using the specific event filters. These events are enumerated using some of the DEBUG_FILTER_XXX constants.</param>
        /// <param name="SpecificExceptions">[out] Receives the number of exceptions that can be controlled using the specific exception filters. The first specific exception filter is the default exception filter.<para/>
        /// The exceptions controlled by the other specific exception filters will always have their own filter and will not inherit their behavior from the default specific exception filter.<para/>
        /// These exception filters are identified by their exception code. See Specific Exceptions for a list of the specific exception filters.</param>
        /// <param name="ArbitraryExceptions">[out] Receives the number of arbitrary exception filters currently used by the engine. These exception filters are identified by their exception code.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// For more information about event filters, see Event Filters.
        /// </remarks>
        [PreserveSig]
        new HRESULT GetNumberEventFilters(
            [Out] out uint SpecificEvents,
            [Out] out uint SpecificExceptions,
            [Out] out uint ArbitraryExceptions);

        /// <summary>
        /// The GetEventFilterText method returns a short description of an event for a specific filter.
        /// </summary>
        /// <param name="Index">[in] Specifies the index of the event filter whose description will be returned. Only the specific filters have a description attached to them; Index must refer to a specific filter.</param>
        /// <param name="Buffer">[out, optional] Receives the description of the specific filter.</param>
        /// <param name="BufferSize">[in] Specifies the size, in characters, of the buffer that Buffer specifies. This size includes the space for the '\0' terminating character.</param>
        /// <param name="TextSize">[out, optional] Receives the size of the event description. This size includes the space for the '\0' terminating character.<para/>
        /// If TextSize is NULL, this information is not returned.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// For more information about event filters, see Event Filters.
        /// </remarks>
        [PreserveSig]
        new HRESULT GetEventFilterText(
            [In] uint Index,
            [Out, MarshalAs(UnmanagedType.LPStr)] StringBuilder Buffer,
            [In] int BufferSize,
            [Out] out uint TextSize);

        /// <summary>
        /// The GetEventFilterCommand method returns the debugger command that the engine will execute when a specified event occurs.
        /// </summary>
        /// <param name="Index">[in] Specifies the index of the event filter. Index can take any value between zero and one less than the total number of event filters returned by <see cref="GetNumberEventFilters"/> (inclusive).<para/>
        /// For more information about the index of the filters, see Index and Exception Code.</param>
        /// <param name="Buffer">[out, optional] Receives the debugger command that the engine will execute when the event occurs.</param>
        /// <param name="BufferSize">[in] Specifies the size, in characters, of the buffer that Buffer specifies. This size includes the space for the '\0' terminating character.</param>
        /// <param name="CommandSize">[out, optional] Receives the size in characters of the command. This size includes the space for the '\0' terminating character.<para/>
        /// If CommandSize is NULL, this information is not returned.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// For more information about event filters, see Event Filters.
        /// </remarks>
        [PreserveSig]
        new HRESULT GetEventFilterCommand(
            [In] uint Index,
            [Out, MarshalAs(UnmanagedType.LPStr)] StringBuilder Buffer,
            [In] int BufferSize,
            [Out] out uint CommandSize);

        /// <summary>
        /// The SetEventFilterCommand method sets a debugger command for the engine to execute when a specified event occurs.
        /// </summary>
        /// <param name="Index">[in] Specifies the index of the event filter. Index can take any value between zero and one less than the total number of event filters returned by GetNumberEventFilters (inclusive).<para/>
        /// For more information about the index of the filters, see Index and Exception Code.</param>
        /// <param name="Command">[in] Specifies the debugger command for the engine to execute when the event occurs.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// For more information about event filters, see Event Filters.
        /// </remarks>
        [PreserveSig]
        new HRESULT SetEventFilterCommand(
            [In] uint Index,
            [In, MarshalAs(UnmanagedType.LPStr)] string Command);

        /// <summary>
        /// The GetSpecificFilterParameters method returns the parameters for specific event filters.
        /// </summary>
        /// <param name="Start">[in] Specifies the index of the first specific event filter whose parameters will be returned.</param>
        /// <param name="Count">[in] Specifies the number of specific event filters to return parameters for.</param>
        /// <param name="Params">[out] Receives the parameters for the specific event filters. Params is an array of elements of type <see cref="DEBUG_SPECIFIC_FILTER_PARAMETERS"/>.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// For more information about event filters, see Event Filters.
        /// </remarks>
        [PreserveSig]
        new HRESULT GetSpecificFilterParameters(
            [In] uint Start,
            [In] uint Count,
            [Out, MarshalAs(UnmanagedType.LPArray)] DEBUG_SPECIFIC_FILTER_PARAMETERS[] Params);

        /// <summary>
        /// The SetSpecificFilterParameters method changes the break status and handling status for some specific event filters.
        /// </summary>
        /// <param name="Start">[in] Specifies the index of the first specific event filter whose parameters will be changed.</param>
        /// <param name="Count">[in] Specifies the number of specific event filters whose parameters will be changed.</param>
        /// <param name="Params">[in] Specifies an array of specific event filter parameters of type <see cref="DEBUG_SPECIFIC_FILTER_PARAMETERS"/>.<para/>
        /// Only the ExecutionOption and ContinueOption members are used. ExceptionOption specifies the new break status and ContinueOption specifies the new handling status.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// For more information about event filters, see Event Filters.
        /// </remarks>
        [PreserveSig]
        new HRESULT SetSpecificFilterParameters(
            [In] uint Start,
            [In] uint Count,
            [In, MarshalAs(UnmanagedType.LPArray)] DEBUG_SPECIFIC_FILTER_PARAMETERS[] Params);

        [PreserveSig]
        new HRESULT GetSpecificEventFilterArgument(
            [In] uint Index,
            [Out, MarshalAs(UnmanagedType.LPStr)] StringBuilder Buffer,
            [In] int BufferSize,
            [Out] out uint ArgumentSize);

        [PreserveSig]
        new HRESULT SetSpecificEventFilterArgument(
            [In] uint Index,
            [In, MarshalAs(UnmanagedType.LPStr)] string Argument);

        /// <summary>
        /// The GetExceptionFilterParameters method returns the parameters for exception filters specified by exception codes or by index.
        /// </summary>
        /// <param name="Count">[in] Specifies the number of exception filters for which to return parameters.</param>
        /// <param name="Codes">[in, optional] Specifies an array of exception codes. The parameters for the exception filters with these exception codes will be returned.<para/>
        /// If Codes is NULL, Start is used instead.</param>
        /// <param name="Start">[in] Specifies the index of the first exception filter. The parameters for the exception filters starting at Start will be returned.<para/>
        /// If Codes is not NULL, Start is ignored.</param>
        /// <param name="Params">[out] Receives the parameters for the exception filters specified by Codes or Start. Params is an array of elements of type <see cref="DEBUG_EXCEPTION_FILTER_PARAMETERS"/>.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// For more information about event filters, see Event Filters.
        /// </remarks>
        [PreserveSig]
        new HRESULT GetExceptionFilterParameters(
            [In] uint Count,
            [In, MarshalAs(UnmanagedType.LPArray)]
            uint[] Codes,
            [In] uint Start,
            [Out, MarshalAs(UnmanagedType.LPArray)] DEBUG_EXCEPTION_FILTER_PARAMETERS[] Params);

        /// <summary>
        /// The SetExceptionFilterParameters method changes the break status and handling status for some exception filters.
        /// </summary>
        /// <param name="Count">[in] Specifies the number of exception filters to change the parameters for.</param>
        /// <param name="Params">[in] Specifies an array of exception filter parameters of type <see cref="DEBUG_EXCEPTION_FILTER_PARAMETERS"/>.<para/>
        /// Only the ExecutionOption, ContinueOption, and ExceptionCode fields of these parameters are used. The ExceptionCode field is used to identify the exception whose exception filter will be changed.<para/>
        /// ExceptionOption specifies the new break status and ContinueOption specifies the new handling status. If the value of the ExceptionOption field is DEBUG_FILTER_REMOVE and the exception filter is an arbitrary exception filter, the exception filter will be removed.</param>
        /// <returns>This method may also return error values. See Return Values for more details. has been exceeded.</returns>
        /// <remarks>
        /// For each of the exception filter parameters in Params, if the exception, identified by exception code, already
        /// has a filter (specific or arbitrary), that filter will be changed. Otherwise, a new arbitrary exception filter
        /// will be added for the exception. For more information about event filters, see Event Filters.
        /// </remarks>
        [PreserveSig]
        new HRESULT SetExceptionFilterParameters(
            [In] uint Count,
            [In, MarshalAs(UnmanagedType.LPArray)] DEBUG_EXCEPTION_FILTER_PARAMETERS[] Params);

        /// <summary>
        /// The GetExceptionFilterSecondCommand method returns the command that will be executed by the debugger engine upon the second chance of a specified exception.
        /// </summary>
        /// <param name="Index">[in] Specifies the index of the exception filter whose second-chance command will be returned. Index can also refer to the default exception filter to return the second-chance command for those exceptions that do not have a specific or arbitrary exception filter.</param>
        /// <param name="Buffer">[out, optional] Receives the second-chance command for the exception filter.</param>
        /// <param name="BufferSize">[in] Specifies the size, in characters, of the buffer that Buffer specifies. This size includes the space for the '\0' terminating character.</param>
        /// <param name="CommandSize">[out, optional] Receives the size, in characters, of the second-chance command for the exception filter. This size includes the space for the '\0' terminating character.<para/>
        /// If CommandSize is NULL, this information is not returned.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// Only exception filters support a second-chance command. If Index refers to a specific event filter, the command
        /// returned to Buffer will be empty. The returned command will also be empty if no second-chance command has been
        /// set for the specified exception. For more information about event filters, see Event Filters.
        /// </remarks>
        [PreserveSig]
        new HRESULT GetExceptionFilterSecondCommand(
            [In] uint Index,
            [Out, MarshalAs(UnmanagedType.LPStr)] StringBuilder Buffer,
            [In] int BufferSize,
            [Out] out uint CommandSize);

        /// <summary>
        /// The SetExceptionFilterSecondCommand method sets the command that will be executed by the debugger engine on the second chance of a specified exception.
        /// </summary>
        /// <param name="Index">[in] Specifies the index of the exception filter whose second-chance command will be set. Index must not refer to the specific event filters as these are not exception filters and only exception events get a second chance.<para/>
        /// If Index refers to the default exception filter, the second-chance command is set for all exceptions that do not have an exception filter.</param>
        /// <param name="Command">[in] Receives the second-chance command for the exception filter.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// For more information about event filters, see Event Filters.
        /// </remarks>
        [PreserveSig]
        new HRESULT SetExceptionFilterSecondCommand(
            [In] uint Index,
            [In, MarshalAs(UnmanagedType.LPStr)] string Command);

        /// <param name="Flags">[in] Set to zero. There are currently no flags that can be used in this parameter.</param>
        /// <param name="Timeout">[in] Specifies how many milliseconds to wait before this method will return. If Timeout is INFINITE, this method will not return until an event that breaks into the debugger engine application occurs or an exit interrupt is issued.<para/>
        /// If the current session has a live kernel target, Timeout must be set to INFINITE.</param>
        /// <returns>This method may return other error values and the above error values may have additional meanings. See Return Values for more details.</returns>
        /// <remarks>
        /// The method can be called only from the thread that started the debugger session. When an event occurs, the debugger
        /// engine will process the event and call the event callbacks. If one of these callbacks indicates that the event
        /// should break into the debugger engine application (by returning DEBUG_STATUS_BREAK), this method will return; otherwise,
        /// it will continue waiting for an event. The event filters can also specify that an event should break into the debugger
        /// engine application. For more information about event filters, see Controlling Exceptions and Events. This method
        /// is not re-entrant. Once it has been called, it cannot be called again on any client until it has returned. In particular,
        /// it cannot be called from the event callbacks, including extensions and commands executed by the callbacks. If none
        /// of the targets are capable of generating events -- for example, all the targets have exited -- this method will
        /// end the current session, discard the targets, and then return E_UNEXPECTED. The constant INFINITE is defined in
        /// Winbase.h. For more information about using WaitForEvent to control the execution flow of the debugger application
        /// and targets, see Debugging Session and Execution Model. For details on the event callbacks, see Monitoring Events.
        /// </remarks>
        [PreserveSig]
        new HRESULT WaitForEvent(
            [In] DEBUG_WAIT Flags,
            [In] int Timeout);

        /// <summary>
        /// The GetLastEventInformation method returns information about the last event that occurred in a target.
        /// </summary>
        /// <param name="Type">[out] Receives the type of the last event generated by the target. For a list of possible types, see DEBUG_EVENT_XXX.</param>
        /// <param name="ProcessId">[out] Receives the process ID of the process in which the event occurred. If this information is not available, DEBUG_ANY_ID will be returned instead.</param>
        /// <param name="ThreadId">[out] Receives the thread index (not the thread ID) of the thread in which the last event occurred. If this information is not available, DEBUG_ANY_ID will be returned instead.</param>
        /// <param name="ExtraInformation">[out, optional] Receives extra information about the event. The contents of this extra information depends on the type of the event.<para/>
        /// If ExtraInformation is NULL, this information is not returned.</param>
        /// <param name="ExtraInformationSize">[in] Specifies the size, in bytes, of the buffer that ExtraInformation specifies.</param>
        /// <param name="ExtraInformationUsed">[out, optional] Receives the size, in bytes, of extra information. If ExtraInformationUsed is NULL, this information is not returned.</param>
        /// <param name="Description">[out, optional] Receives the description of the event. If Description is NULL, this information is not returned.</param>
        /// <param name="DescriptionSize">[in] Specifies the size, in characters, of the buffer that Description specifies. This size includes the space for the '\0' terminating character.</param>
        /// <param name="DescriptionUsed">[out, optional] Receives the size in characters of the description of the event. This size includes the space for the '\0' terminating character.<para/>
        /// If DescriptionUsed is NULL, this information is not returned.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// For thread and process creation events, the thread index and process ID returned to ThreadId and ProcessId are
        /// for the newly created thread or process. For more information about the last event, see the topic Event Information.
        /// </remarks>
        [PreserveSig]
        new HRESULT GetLastEventInformation(
            [Out] out DEBUG_EVENT_TYPE Type,
            [Out] out uint ProcessId,
            [Out] out uint ThreadId,
            [In] IntPtr ExtraInformation,
            [In] uint ExtraInformationSize,
            [Out] out uint ExtraInformationUsed,
            [Out, MarshalAs(UnmanagedType.LPStr)] StringBuilder Description,
            [In] int DescriptionSize,
            [Out] out uint DescriptionUsed);

        #endregion
        #region IDebugControl2

        /// <summary>
        /// The GetCurrentTimeDate method returns the time of the current target.
        /// </summary>
        /// <param name="TimeDate">[out] Receives the time and date. This is the number of seconds since the beginning of 1970, or 0 if the current time could not be determined.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// For live debugging sessions, this will be the current time as reported by the target's computer. For static debugging
        /// sessions, such as crash dump files, this will be the time the crash dump file was created. For more information,
        /// see Target Information.
        /// </remarks>
        [PreserveSig]
        new HRESULT GetCurrentTimeDate(
            [Out] out uint TimeDate);

        /// <summary>
        /// The GetCurrentSystemUpTime method returns the number of seconds the current target's computer has been running since it was last started.
        /// </summary>
        /// <param name="UpTime">[out] Receives the number of seconds the computer has been running, or 0 if the engine is unable to determine the running time.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// For more information, see Target Information.
        /// </remarks>
        [PreserveSig]
        new HRESULT GetCurrentSystemUpTime(
            [Out] out uint UpTime);

        /// <summary>
        /// The GetDumpFormatFlags method returns the flags that describe what information is available in a dump file target.
        /// </summary>
        /// <param name="FormatFlags">[out] Receives the flags that describe the information included in a dump file. Different dump files support different sets of format information.<para/>
        /// For example, see DEBUG_FORMAT_XXX for a description of the flags used for user-mode Minidump files.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// This method is only available when debugging crash dump files. If the crash dump file is in a default format or
        /// does not have variable formats, zero will be returned to FormatFlags.
        /// </remarks>
        [PreserveSig]
        new HRESULT GetDumpFormatFlags(
            [Out] out DEBUG_FORMAT FormatFlags);

        /// <summary>
        /// The GetNumberTextReplacements method returns the number of currently defined user-named and automatic aliases.
        /// </summary>
        /// <param name="NumRepl">[out] Receives the total number of user-named and automatic aliases.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// For an overview of aliases used by the debugger engine, see Using Aliases. For more information about using aliases
        /// with the debugger engine API, see Interacting with the Engine.
        /// </remarks>
        [PreserveSig]
        new HRESULT GetNumberTextReplacements(
            [Out] out uint NumRepl);

        /// <summary>
        /// The GetTextReplacement method returns the value of a user-named alias or an automatic alias.
        /// </summary>
        /// <param name="SrcText">[in, optional] Specifies the name of the alias. The engine first searches the user-named aliases for one with this name.<para/>
        /// Then, if no match is found, the automatic aliases are searched. If SrcText is NULL, Index is used to specify the alias.</param>
        /// <param name="Index">[in] Specifies the index of an alias. The indexes of the user-named aliases come before the indexes of the automatic aliases.<para/>
        /// Index is only used if SrcText is NULL. Index can be used along with <see cref="GetNumberTextReplacements"/> to iterate over all the user-named and automatic aliases.</param>
        /// <param name="SrcBuffer">[out, optional] Receives the name of the alias. This is the name specified in SrcText, if SrcText is not NULL. If SrcBuffer is NULL, this information is not returned.</param>
        /// <param name="SrcBufferSize">[in] Specifies the size, in characters, of the SrcBuffer buffer.</param>
        /// <param name="SrcSize">[out, optional] Receives the size, in characters, of the name of the alias. If SrcSize is NULL, this information is not returned.</param>
        /// <param name="DstBuffer">[out, optional] Receives the value of the alias specified by SrcText and Index. If DstBuffer is NULL, this information is not returned.</param>
        /// <param name="DstBufferSize">[in] Specifies the size, in characters, of the DstBuffer buffer.</param>
        /// <param name="DstSize">[out, optional] Receives the size, in characters, of the value of the alias. If DstSize is NULL, this information is not returned.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// Before executing commands or evaluating expressions, the debugger engine will replace the alias specified by SrcBuffer
        /// with the value of the alias (specified by DstBuffer). For an overview of aliases used by the debugger engine, see
        /// Using Aliases. For more information about using aliases with the debugger engine API, see Interacting with the
        /// Engine.
        /// </remarks>
        [PreserveSig]
        new HRESULT GetTextReplacement(
            [In, MarshalAs(UnmanagedType.LPStr)] string SrcText,
            [In] uint Index,
            [Out, MarshalAs(UnmanagedType.LPStr)] StringBuilder SrcBuffer,
            [In] int SrcBufferSize,
            [Out] out uint SrcSize,
            [Out, MarshalAs(UnmanagedType.LPStr)] StringBuilder DstBuffer,
            [In] int DstBufferSize,
            [Out] out uint DstSize);

        /// <summary>
        /// The SetTextReplacement method sets the value of a user-named alias.
        /// </summary>
        /// <param name="SrcText">[in] Specifies the name of the user-named alias. The debugger engine makes a copy of this string. If SrcText is the same as the name of an automatic alias, the automatic alias is hidden by the new user-named alias.</param>
        /// <param name="DstText">[in, optional] Specifies the value of the user-named alias. The debugger engine makes a copy of this string. If DstText is NULL, the user-named alias is removed.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// Before executing commands or evaluating expressions, the debugger engine will replace the alias specified by SrcText
        /// with the value of the alias (specified by DstText). If SrcText is an asterisk (*) and DstText is NULL, all user-named
        /// aliases are removed. This is the same behavior as the <see cref="RemoveTextReplacements"/> method. When an alias
        /// is changed by this method, the event callbacks are notified by passing the DEBUG_CES_TEXT_REPLACEMENTS flag to
        /// the <see cref="IDebugEventCallbacks.ChangeEngineState"/> callback method. For an overview of aliases used by the
        /// debugger engine, see Using Aliases. For more information about using aliases with the debugger engine API, see
        /// Interacting with the Engine.
        /// </remarks>
        [PreserveSig]
        new HRESULT SetTextReplacement(
            [In, MarshalAs(UnmanagedType.LPStr)] string SrcText,
            [In, MarshalAs(UnmanagedType.LPStr)] string DstText);

        /// <summary>
        /// The RemoveTextReplacements method removes all user-named aliases.
        /// </summary>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// For an overview of aliases used by the debugger engine, see Using Aliases. For more information about using aliases
        /// with the debugger engine API, see Interacting with the Engine.
        /// </remarks>
        [PreserveSig]
        new HRESULT RemoveTextReplacements();

        /// <summary>
        /// The OutputTextReplacements method prints all the currently defined user-named aliases to the debugger's output stream.
        /// </summary>
        /// <param name="OutputControl">[in] Specifies the output control to use when printing the aliases. For possible values, see DEBUG_OUTCTL_XXX.</param>
        /// <param name="Flags">[in] Must be set to DEBUG_OUT_TEXT_REPL_DEFAULT.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// For an overview of aliases used by the debugger engine, see Using Aliases. For more information about using aliases
        /// with the debugger engine API, see Interacting with the Engine.
        /// </remarks>
        [PreserveSig]
        new HRESULT OutputTextReplacements(
            [In] DEBUG_OUTCTL OutputControl,
            [In] DEBUG_OUT_TEXT_REPL Flags);

        #endregion
        #region IDebugControl3

        /// <summary>
        /// The GetAssemblyOptions method returns the assembly and disassembly options that affect how the debugger engine assembles and disassembles processor instructions for the target.
        /// </summary>
        /// <param name="Options">[out] Receives a bit-set that contains the assembly and disassembly options. For a description of these options, see DEBUG_ASMOPT_XXX.</param>
        /// <returns>This method can also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// For more information about using assembly with the debugger engine API, see Assembling and Disassembling Instructions.
        /// </remarks>
        [PreserveSig]
        HRESULT GetAssemblyOptions(
            [Out] out DEBUG_ASMOPT Options);

        /// <summary>
        /// The AddAssemblyOptions method turns on some of the assembly and disassembly options.
        /// </summary>
        /// <param name="Options">[in] Specifies the assembly and disassembly options to turn on. Options is a bit-set that will be combined with the existing engine options using the bitwise OR operator.<para/>
        /// For a description of the options, see DEBUG_ASMOPT_XXX.</param>
        /// <returns>These methods can also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// For more information about using assembly with the debugger engine API, see Assembling and Disassembling Instructions.
        /// </remarks>
        [PreserveSig]
        HRESULT AddAssemblyOptions(
            [In] DEBUG_ASMOPT Options);

        /// <summary>
        /// The RemoveAssemblyOptions method turns off some of the assembly and disassembly options.
        /// </summary>
        /// <param name="Options">[in] Specifies the assembly and disassembly options to turn off. Options is a bit-set; the new value of the engine's options will equal the bitwise NOT of Options combined with the old value by using the bitwise AND operator.<para/>
        /// For a description of the assembly and disassembly options, see DEBUG_ASMOPT_XXX.</param>
        /// <returns>This method can also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// For more information about using assembly with the debugger engine API, see Assembling and Disassembling Instructions.
        /// </remarks>
        [PreserveSig]
        HRESULT RemoveAssemblyOptions(
            [In] DEBUG_ASMOPT Options);

        /// <summary>
        /// The SetAssemblyOptions method sets the assembly and disassembly options that affect how the debugger engine assembles and disassembles processor instructions for the target.
        /// </summary>
        /// <param name="Options">[in] Specifies the new assembly and disassembly options to be used by the debugger engine. Options is a bit-set; it will replace the existing assembly and disassembly options.<para/>
        /// For possible values, see Remarks. DEBUG_ASMOPT_DEFAULT can be used to set the default options.</param>
        /// <returns>This method can also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// For more information about using assembly with the debugger engine API, see Assembling and Disassembling Instructions.
        /// The assembly and disassembly options affect how the debugger engine assembles and disassembles processor instructions
        /// for the target. The options are represented by a bitset with the following bit flags. This is equivalent to the
        /// verbose option in the .asm command. This is equivalent to the no_code_bytes option in the .asm command. This is
        /// equivalent to the ignore_output_width option in the .asm command. This is equivalent to the source_line option
        /// in the .asm command. Additionally, the value DEBUG_ASMOPT_DEFAULT represents the default set of assembly and disassembly
        /// options. This means that all the options in the preceding table are turned off.
        /// </remarks>
        [PreserveSig]
        HRESULT SetAssemblyOptions(
            [In] DEBUG_ASMOPT Options);

        /// <summary>
        /// The GetExpressionSyntax method returns the current syntax that the engine is using for evaluating expressions.
        /// </summary>
        /// <param name="Flags">[out] Receives the expression syntax. It is set to one of the following values: Expressions will be evaluated according to MASM syntax.<para/>
        /// For details of this syntax, see MASM Numbers and Operators. Expressions will be evaluated according to C++ syntax.<para/>
        /// For details of this syntax, see C++ Numbers and Operators.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        [PreserveSig]
        HRESULT GetExpressionSyntax(
            [Out] out DEBUG_EXPR Flags);

        /// <summary>
        /// The SetExpressionSyntax method sets the syntax that the engine will use to evaluate expressions.
        /// </summary>
        /// <param name="Flags">[in] Specifies the syntax that the engine will use to evaluate expressions. It can be one of the following values: Expressions will be evaluated according to MASM syntax.<para/>
        /// For details of this syntax, see MASM Numbers and Operators. Expressions will be evaluated according to C++ syntax.<para/>
        /// For details of this syntax, see C++ Numbers and Operators.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// The expression syntax is a global setting within the engine, so setting the expression syntax will affect all clients.
        /// The expression syntax of the engine determines how the engine will interpret expressions passed to <see cref="Evaluate"/>,
        /// <see cref="Execute"/>, and any other method that evaluates an expression. After the expression syntax has been
        /// changed, the engine sends out notification to the <see cref="IDebugEventCallbacks"/> registered with each client.
        /// It also passes the DEBUG_CES_EXPRESSION_SYNTAX flag to the <see cref="IDebugEventCallbacks.ChangeEngineState"/>
        /// method.
        /// </remarks>
        [PreserveSig]
        HRESULT SetExpressionSyntax(
            [In] DEBUG_EXPR Flags);

        /// <summary>
        /// The SetExpressionSyntaxByName method sets the syntax that the engine will use to evaluate expressions.
        /// </summary>
        /// <param name="AbbrevName">[in] Specifies the abbreviated name of the syntax. It can be one of the following strings: Expressions will be evaluated according to C++ syntax.<para/>
        /// For details of this syntax, see C++ Numbers and Operators. Expressions will be evaluated according to MASM syntax.<para/>
        /// For details of this syntax, see MASM Numbers and Operators.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// The expression syntax is a global setting within the engine, so setting the expression syntax will affect all clients.
        /// The expression syntax of the engine determines how the engine will interpret expressions passed to <see cref="Evaluate"/>,
        /// <see cref="Execute"/>, and any other method that evaluates an expression. After the expression syntax has been
        /// changed, the engine sends out notification to the <see cref="IDebugEventCallbacks"/> callback object registered
        /// with each client. It also passes the DEBUG_CES_EXPRESSION_SYNTAX flag to the <see cref="IDebugEventCallbacks.ChangeEngineState"/>
        /// method.
        /// </remarks>
        [PreserveSig]
        HRESULT SetExpressionSyntaxByName(
            [In, MarshalAs(UnmanagedType.LPStr)] string AbbrevName);

        /// <summary>
        /// The GetNumberExpressionSyntaxes method returns the number of expression syntaxes that are supported by the engine.
        /// </summary>
        /// <param name="Number">[out] Receives the number of expression syntaxes.</param>
        /// <returns>This method can also return error values. See Return Values for more details.</returns>
        [PreserveSig]
        HRESULT GetNumberExpressionSyntaxes(
            [Out] out uint Number);

        /// <summary>
        /// The GetExpressionSyntaxNames method returns the full and abbreviated names of an expression syntax.
        /// </summary>
        /// <param name="Index">[in] Specifies the index of the expression syntax. Index should be between zero and the number of expression syntaxes returned by <see cref="GetNumberExpressionSyntaxes"/> minus one.</param>
        /// <param name="FullNameBuffer">[out, optional] Receives the full name of the expression syntax. If FullNameBuffer is NULL, this information is not returned.</param>
        /// <param name="FullNameBufferSize">[in] Specifies the size, in characters, of the buffer FullNameBuffer. This size includes the space for the '\0' terminating character.</param>
        /// <param name="FullNameSize">[out, optional] Receives the size, in characters, of the full name of the expression syntax. This size includes the space for the '\0' terminating character.<para/>
        /// If FullNameSize is NULL, this information is not returned.</param>
        /// <param name="AbbrevNameBuffer">[out, optional] Receives the abbreviated name of the expression syntax. This size includes the space for the '\0' terminating character.<para/>
        /// If AbbrevNameBuffer is NULL, this information is not returned.</param>
        /// <param name="AbbrevNameBufferSize">[in] Specifies the size, in characters, of the buffer AbbrevNameBufferSize. This size includes the space for the '\0' terminating character.</param>
        /// <param name="AbbrevNameSize">[out, optional] Receives the size, in characters, of the abbreviated name of the expression syntax. This size includes the space for the '\0' terminating character.<para/>
        /// If AbbrevNameSize is NULL, this information is not returned.</param>
        /// <returns>This method can also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// Currently, there are two expression syntaxes, their full names are "Microsoft Assembler expressions" and "C++ source
        /// expressions." The corresponding abbreviated expression syntaxes are "MASM" and "C++."
        /// </remarks>
        [PreserveSig]
        HRESULT GetExpressionSyntaxNames(
            [In] uint Index,
            [Out, MarshalAs(UnmanagedType.LPStr)] StringBuilder FullNameBuffer,
            [In] int FullNameBufferSize,
            [Out] out uint FullNameSize,
            [Out, MarshalAs(UnmanagedType.LPStr)] StringBuilder AbbrevNameBuffer,
            [In] int AbbrevNameBufferSize,
            [Out] out uint AbbrevNameSize);

        /// <summary>
        /// The GetNumberEvents method returns the number of events for the current target, if the number of events is fixed.
        /// </summary>
        /// <param name="Events">[out] Receives the number of events stored in the target. If the target offers multiple events, Events will be set to the number of events available.<para/>
        /// Otherwise, Events will be set to one.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// Crash dump files contain a static list of events; each event represents a snapshot of the target at a particular
        /// point in time. If the current target is a crash dump file, this method sets Events to the number of stored events
        /// and returns S_OK. Live targets generate events dynamically and do not necessarily have a known set of events. If
        /// the current target is a live target with unconstrained number of events, this method sets Events to the number
        /// of events currently available and returns S_FALSE. For more information, see the topic Event Information.
        /// </remarks>
        [PreserveSig]
        HRESULT GetNumberEvents(
            [Out] out uint Events);

        /// <summary>
        /// The GetEventIndexDescription method describes the specified event in a static list of events for the current target.
        /// </summary>
        /// <param name="Index">[in] Specifies the index of the event whose description will be returned.</param>
        /// <param name="Which">[in] Specifies which piece of the event description to return. Currently only DEBUG_EINDEX_NAME is supported; this returns the name of the event.</param>
        /// <param name="Buffer">[in, optional] Receives the description of the event. If Buffer is NULL, this information is not returned.</param>
        /// <param name="BufferSize">[in] Specifies the size, in characters, of the Buffer buffer.</param>
        /// <param name="DescSize">[out, optional] Receives the size, in characters, of the description. If DescSize is NULL, this information is not returned.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// The amount of descriptive information available for a particular target varies depending on the type of the target.
        /// </remarks>
        [PreserveSig]
        HRESULT GetEventIndexDescription(
            [In] uint Index,
            [In] DEBUG_EINDEX Which,
            [Out, MarshalAs(UnmanagedType.LPStr)] StringBuilder Buffer,
            [In] int BufferSize,
            [Out] out uint DescSize);

        /// <summary>
        /// The GetCurrentEventIndex method returns the index of the current event within the current list of events for the current target, if such a list exists.
        /// </summary>
        /// <param name="Index">[out] Receives the index of the current event in the target. The index will be a number between zero and one less than the number of events returned by <see cref="GetNumberEvents"/>.<para/>
        /// The index of the first event is zero.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// Targets that do not have fixed sets of events will always return zero to Index.
        /// </remarks>
        [PreserveSig]
        HRESULT GetCurrentEventIndex(
            [Out] out uint Index);

        /// <summary>
        /// The SetNextEventIndex method sets the next event for the current target by selecting the event from the static list of events for the target, if such a list exists.
        /// </summary>
        /// <param name="Relation">[in] Specifies how to interpret Value when setting the index of the next event. Possible values are: DEBUG_EINDEX_FROM_START, DEBUG_EINDEX_FROM_END, and DEBUG_EINDEX_FROM_CURRENT.</param>
        /// <param name="Value">[in] Specifies the index of the next event relative to the first, last, or current event. The interpretation of Value depends on the value of Relation, as follows.<para/>
        /// The resulting index must be greater than zero and one less than the number of events returned by <see cref="GetNumberEvents"/>.</param>
        /// <param name="NextIndex">[out] Receives the index of the next event. If NextIndex is NULL, this information is not returned.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// If the specified event is the same as the current event, this method does nothing. Otherwise, this method sets
        /// the execution status of the target to DEBUG_STATUS_GO (and notifies the event callbacks). When <see cref="WaitForEvent"/>
        /// is called, the engine will generate the specified event for the event callbacks and set it as the current event.
        /// This method is only useful if the target offers a list of events.
        /// </remarks>
        [PreserveSig]
        HRESULT SetNextEventIndex(
            [In] DEBUG_EINDEX Relation,
            [In] uint Value,
            [Out] out uint NextIndex);

        #endregion
    }
}
