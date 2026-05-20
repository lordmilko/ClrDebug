using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using static ClrDebug.Extensions;

namespace ClrDebug.DbgEng
{
    public class DebugControl : ComObject<IDebugControl>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DebugControl"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
        public DebugControl(IDebugControl raw) : base(raw)
        {
        }

        #region IDebugControl
        #region InterruptTimeout

        /// <summary>
        /// The GetInterruptTimeout method returns the number of seconds that the engine will wait when requesting a break into the debugger.
        /// </summary>
        public int InterruptTimeout
        {
            get
            {
                int seconds;
                TryGetInterruptTimeout(out seconds).ThrowDbgEngNotOK();

                return seconds;
            }
            set
            {
                TrySetInterruptTimeout(value).ThrowDbgEngNotOK();
            }
        }

        /// <summary>
        /// The GetInterruptTimeout method returns the number of seconds that the engine will wait when requesting a break into the debugger.
        /// </summary>
        /// <param name="seconds">[out] Receives the number of seconds that the engine will wait for the target when requesting a break into the debugger.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// The engine requests a break into the debugger when <see cref="SetInterrupt"/> is called with DEBUG_INTERRUPT_ACTIVE.
        /// If this interrupt times out, the engine will generate a synthetic exception event. This event will be sent to event
        /// callback objects's <see cref="IDebugEventCallbacks.Exception"/> method. Most targets do not support interrupt time-outs.
        /// Live user-mode debugging is one of the targets that does support them.
        /// </remarks>
        public HRESULT TryGetInterruptTimeout(out int seconds)
        {
            /*HRESULT GetInterruptTimeout(
            [Out] out int Seconds);*/
            return Raw.GetInterruptTimeout(out seconds);
        }

        /// <summary>
        /// The SetInterruptTimeout method sets the number of seconds that the debugger engine should wait when requesting a break into the debugger.
        /// </summary>
        /// <param name="seconds">[in] Specifies the number of seconds that the engine should wait for the target when requesting a break into the debugger.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// The engine requests a break into the debugger when <see cref="SetInterrupt"/> is called with the DEBUG_INTERRUPT_ACTIVE
        /// flag. If an interrupt times out, the engine will generate a synthetic exception event. This event will be sent
        /// to event callback objects's <see cref="IDebugEventCallbacks.Exception"/> method. Most targets do not support interrupt
        /// time-outs. Live user-mode debugging is one of the targets that does support them.
        /// </remarks>
        public HRESULT TrySetInterruptTimeout(int seconds)
        {
            /*HRESULT SetInterruptTimeout(
            [In] int Seconds);*/
            return Raw.SetInterruptTimeout(seconds);
        }

        #endregion
        #region LogFile

        /// <summary>
        /// The GetLogFile method returns the name of the currently open log file.
        /// </summary>
        public GetLogFileResult LogFile
        {
            get
            {
                GetLogFileResult result;
                TryGetLogFile(out result).ThrowDbgEngNotOK();

                return result;
            }
        }

        /// <summary>
        /// The GetLogFile method returns the name of the currently open log file.
        /// </summary>
        /// <param name="result">The values that were emitted from the COM method.</param>
        /// <returns>This method can also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// GetLogFile and GetLogFileWide behave the same way as <see cref="LogFile2"/> and GetLogFile2Wide
        /// with Append receiving only the information about the DEBUG_LOG_APPEND flag. For more information about log files,
        /// see Using Input and Output.
        /// </remarks>
        public HRESULT TryGetLogFile(out GetLogFileResult result)
        {
            /*HRESULT GetLogFile(
            [SRI.Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U1, SizeParamIndex = 1)] byte[] Buffer,
            [In] int BufferSize,
            [Out] out int FileSize,
            [Out, MarshalAs(UnmanagedType.Bool)] out bool Append);*/
            byte[] buffer;
            int bufferSize = 0;
            int fileSize;
            bool append;
            HRESULT hr = Raw.GetLogFile(null, bufferSize, out fileSize, out append);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER && hr != HRESULT.S_OK)
                goto fail;

            bufferSize = fileSize;
            buffer = new byte[bufferSize];
            hr = Raw.GetLogFile(buffer, bufferSize, out fileSize, out append);

            if (hr == HRESULT.S_OK)
            {
                result = new GetLogFileResult(CreateString(buffer, fileSize), append);

                return hr;
            }

            fail:
            result = default(GetLogFileResult);

            return hr;
        }

        #endregion
        #region LogMask

        /// <summary>
        /// The GetLogMask method returns the output mask for the currently open log file.
        /// </summary>
        public DEBUG_OUTPUT LogMask
        {
            get
            {
                DEBUG_OUTPUT mask;
                TryGetLogMask(out mask).ThrowDbgEngNotOK();

                return mask;
            }
            set
            {
                TrySetLogMask(value).ThrowDbgEngNotOK();
            }
        }

        /// <summary>
        /// The GetLogMask method returns the output mask for the currently open log file.
        /// </summary>
        /// <param name="mask">[out] Receives the output mask for the log file. See DEBUG_OUTPUT_XXX for details about how to interpret this value.</param>
        /// <returns>This method can also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// For more information about log files, see Using Input and Output.
        /// </remarks>
        public HRESULT TryGetLogMask(out DEBUG_OUTPUT mask)
        {
            /*HRESULT GetLogMask(
            [Out] out DEBUG_OUTPUT Mask);*/
            return Raw.GetLogMask(out mask);
        }

        /// <summary>
        /// The SetLogMask method sets the output mask for the currently open log file.
        /// </summary>
        /// <param name="mask">[in] Specifies the new output mask for the log file. See DEBUG_OUTPUT_XXX for details about this value.</param>
        /// <returns>This method can also return error values. See Return Values for more details.</returns>
        public HRESULT TrySetLogMask(DEBUG_OUTPUT mask)
        {
            /*HRESULT SetLogMask(
            [In] DEBUG_OUTPUT Mask);*/
            return Raw.SetLogMask(mask);
        }

        #endregion
        #region PromptText

        /// <summary>
        /// The GetPromptText method returns the standard prompt text that will be prepended to the formatted output specified in the OutputPrompt and <see cref="OutputPromptVaList"/> methods.
        /// </summary>
        public string PromptText
        {
            get
            {
                string bufferResult;
                TryGetPromptText(out bufferResult).ThrowDbgEngNotOK();

                return bufferResult;
            }
        }

        /// <summary>
        /// The GetPromptText method returns the standard prompt text that will be prepended to the formatted output specified in the OutputPrompt and <see cref="OutputPromptVaList"/> methods.
        /// </summary>
        /// <param name="bufferResult">[out, optional] Receives the prompt text. If Buffer is NULL, this information is not returned.</param>
        /// <returns>This method can also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// For more information about prompting the user, see Using Input and Output.
        /// </remarks>
        public HRESULT TryGetPromptText(out string bufferResult)
        {
            /*HRESULT GetPromptText(
            [SRI.Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U1, SizeParamIndex = 1)] byte[] Buffer,
            [In] int BufferSize,
            [Out] out int TextSize);*/
            byte[] buffer;
            int bufferSize = 0;
            int textSize;
            HRESULT hr = Raw.GetPromptText(null, bufferSize, out textSize);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER && hr != HRESULT.S_OK)
                goto fail;

            bufferSize = textSize;
            buffer = new byte[bufferSize];
            hr = Raw.GetPromptText(buffer, bufferSize, out textSize);

            if (hr == HRESULT.S_OK)
            {
                bufferResult = CreateString(buffer, textSize);

                return hr;
            }

            fail:
            bufferResult = default(string);

            return hr;
        }

        #endregion
        #region NotifyEventHandle

        /// <summary>
        /// The GetNotifyEventHandle method receives the handle of the event that will be signaled after the next exception in a target.
        /// </summary>
        public long NotifyEventHandle
        {
            get
            {
                long handle;
                TryGetNotifyEventHandle(out handle).ThrowDbgEngNotOK();

                return handle;
            }
            set
            {
                TrySetNotifyEventHandle(value).ThrowDbgEngNotOK();
            }
        }

        /// <summary>
        /// The GetNotifyEventHandle method receives the handle of the event that will be signaled after the next exception in a target.
        /// </summary>
        /// <param name="handle">[out] Receives the handle of the event that will be signaled. If Handle is NULL, no event will be signaled.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// If an event to be signaled was set and an exception occurs in a target, when the engine resumes execution in the
        /// target again, the event will be signaled. The event will only be signaled once. After it has been signaled, this
        /// method will return NULL to Handle, unless <see cref="NotifyEventHandle"/> is called to set another event to
        /// signal.
        /// </remarks>
        public HRESULT TryGetNotifyEventHandle(out long handle)
        {
            /*HRESULT GetNotifyEventHandle(
            [Out] out long Handle);*/
            return Raw.GetNotifyEventHandle(out handle);
        }

        /// <summary>
        /// The SetNotifyEventHandle method sets the event that will be signaled after the next exception in a target.
        /// </summary>
        /// <param name="handle">[in] Specifies the handle of the event to signal. If Handle is NULL, no event will be signaled.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// After setting the event to signal, and after the next exception occurs in a target, when the engine resumes execution
        /// in the target, the event will be signaled. The event will only be signaled once. After it has been signaled, GetNotifyEventHandle
        /// will return NULL, unless this method is called to set another event to signal.
        /// </remarks>
        public HRESULT TrySetNotifyEventHandle(long handle)
        {
            /*HRESULT SetNotifyEventHandle(
            [In] long Handle);*/
            return Raw.SetNotifyEventHandle(handle);
        }

        #endregion
        #region DisassembleEffectiveOffset

        /// <summary>
        /// The GetDisassembleEffectiveOffset method returns the address of the last instruction disassembled using <see cref="Disassemble"/>.
        /// </summary>
        public long DisassembleEffectiveOffset
        {
            get
            {
                long offset;
                TryGetDisassembleEffectiveOffset(out offset).ThrowDbgEngNotOK();

                return offset;
            }
        }

        /// <summary>
        /// The GetDisassembleEffectiveOffset method returns the address of the last instruction disassembled using <see cref="Disassemble"/>.
        /// </summary>
        /// <param name="offset">[out] Receives the address in the target's memory of the effective offset from the last instruction disassembled.</param>
        /// <returns>This method can also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// The effective offset is the memory location used by an instruction. For example, if the last instruction to be
        /// disassembled is move ax, [ebp+4], the effective address is the value of ebp+4. This corresponds to the $ea pseudo-register.
        /// For more information about using assembly with the debugger engine API, see Assembling and Disassembling Instructions.
        /// </remarks>
        public HRESULT TryGetDisassembleEffectiveOffset(out long offset)
        {
            /*HRESULT GetDisassembleEffectiveOffset(
            [Out] out long Offset);*/
            return Raw.GetDisassembleEffectiveOffset(out offset);
        }

        #endregion
        #region ReturnOffset

        /// <summary>
        /// The GetReturnOffset method returns the return address for the current function.
        /// </summary>
        public long ReturnOffset
        {
            get
            {
                long offset;
                TryGetReturnOffset(out offset).ThrowDbgEngNotOK();

                return offset;
            }
        }

        /// <summary>
        /// The GetReturnOffset method returns the return address for the current function.
        /// </summary>
        /// <param name="offset">[out] Receives the return address.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// The return address is the location in the process's virtual address space of the instruction that will be executed
        /// when the current function returns.
        /// </remarks>
        public HRESULT TryGetReturnOffset(out long offset)
        {
            /*HRESULT GetReturnOffset(
            [Out] out long Offset);*/
            return Raw.GetReturnOffset(out offset);
        }

        #endregion
        #region DebuggeeType

        /// <summary>
        /// The GetDebuggeeType method describes the nature of the current target.
        /// </summary>
        public GetDebuggeeTypeResult DebuggeeType
        {
            get
            {
                GetDebuggeeTypeResult result;
                TryGetDebuggeeType(out result).ThrowDbgEngNotOK();

                return result;
            }
        }

        /// <summary>
        /// The GetDebuggeeType method describes the nature of the current target.
        /// </summary>
        /// <param name="result">The values that were emitted from the COM method.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        public HRESULT TryGetDebuggeeType(out GetDebuggeeTypeResult result)
        {
            /*HRESULT GetDebuggeeType(
            [Out] out DEBUG_CLASS Class,
            [Out] out DEBUG_CLASS_QUALIFIER Qualifier);*/
            DEBUG_CLASS @class;
            DEBUG_CLASS_QUALIFIER qualifier;
            HRESULT hr = Raw.GetDebuggeeType(out @class, out qualifier);

            if (hr == HRESULT.S_OK)
                result = new GetDebuggeeTypeResult(@class, qualifier);
            else
                result = default(GetDebuggeeTypeResult);

            return hr;
        }

        #endregion
        #region ActualProcessorType

        /// <summary>
        /// The GetActualProcessorType method returns the processor type of the physical processor of the computer that is running the target.
        /// </summary>
        public IMAGE_FILE_MACHINE ActualProcessorType
        {
            get
            {
                IMAGE_FILE_MACHINE type;
                TryGetActualProcessorType(out type).ThrowDbgEngNotOK();

                return type;
            }
        }

        /// <summary>
        /// The GetActualProcessorType method returns the processor type of the physical processor of the computer that is running the target.
        /// </summary>
        /// <param name="type">[out] Receives the type of the processor. The processor types are listed in the following table.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// For more information, see Target Information.
        /// </remarks>
        public HRESULT TryGetActualProcessorType(out IMAGE_FILE_MACHINE type)
        {
            /*HRESULT GetActualProcessorType(
            [Out] out IMAGE_FILE_MACHINE Type);*/
            return Raw.GetActualProcessorType(out type);
        }

        #endregion
        #region ExecutingProcessorType

        /// <summary>
        /// The GetExecutingProcessorType method returns the executing processor type for the processor for which the last event occurred.
        /// </summary>
        public IMAGE_FILE_MACHINE ExecutingProcessorType
        {
            get
            {
                IMAGE_FILE_MACHINE type;
                TryGetExecutingProcessorType(out type).ThrowDbgEngNotOK();

                return type;
            }
        }

        /// <summary>
        /// The GetExecutingProcessorType method returns the executing processor type for the processor for which the last event occurred.
        /// </summary>
        /// <param name="type">[out] Receives the processor type. See <see cref="ActualProcessorType"/> for a list of possible values this parameter can receive.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// For more information, see Target Information.
        /// </remarks>
        public HRESULT TryGetExecutingProcessorType(out IMAGE_FILE_MACHINE type)
        {
            /*HRESULT GetExecutingProcessorType(
            [Out] out IMAGE_FILE_MACHINE Type);*/
            return Raw.GetExecutingProcessorType(out type);
        }

        #endregion
        #region NumberPossibleExecutingProcessorTypes

        /// <summary>
        /// The GetNumberPossibleExecutingProcessorTypes method returns the number of processor types that are supported by the computer running the current target.
        /// </summary>
        public int NumberPossibleExecutingProcessorTypes
        {
            get
            {
                int number;
                TryGetNumberPossibleExecutingProcessorTypes(out number).ThrowDbgEngNotOK();

                return number;
            }
        }

        /// <summary>
        /// The GetNumberPossibleExecutingProcessorTypes method returns the number of processor types that are supported by the computer running the current target.
        /// </summary>
        /// <param name="number">[out] Receives the number of processor types.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// For more information, see Target Information.
        /// </remarks>
        public HRESULT TryGetNumberPossibleExecutingProcessorTypes(out int number)
        {
            /*HRESULT GetNumberPossibleExecutingProcessorTypes(
            [Out] out int Number);*/
            return Raw.GetNumberPossibleExecutingProcessorTypes(out number);
        }

        #endregion
        #region NumberProcessors

        /// <summary>
        /// The GetNumberProcessors method returns the number of processors on the computer running the current target.
        /// </summary>
        public int NumberProcessors
        {
            get
            {
                int number;
                TryGetNumberProcessors(out number).ThrowDbgEngNotOK();

                return number;
            }
        }

        /// <summary>
        /// The GetNumberProcessors method returns the number of processors on the computer running the current target.
        /// </summary>
        /// <param name="number">[out] Receives the number of processors.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// For more information, see Target Information.
        /// </remarks>
        public HRESULT TryGetNumberProcessors(out int number)
        {
            /*HRESULT GetNumberProcessors(
            [Out] out int Number);*/
            return Raw.GetNumberProcessors(out number);
        }

        #endregion
        #region SystemVersion

        /// <summary>
        /// The GetSystemVersion method returns information that identifies the operating system on the computer that is running the current target.
        /// </summary>
        public GetSystemVersionResult SystemVersion
        {
            get
            {
                GetSystemVersionResult result;
                TryGetSystemVersion(out result).ThrowDbgEngNotOK();

                return result;
            }
        }

        /// <summary>
        /// The GetSystemVersion method returns information that identifies the operating system on the computer that is running the current target.
        /// </summary>
        /// <param name="result">The values that were emitted from the COM method.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// For more information, see Target Information.
        /// </remarks>
        public HRESULT TryGetSystemVersion(out GetSystemVersionResult result)
        {
            /*HRESULT GetSystemVersion(
            [Out] out int PlatformId,
            [Out] out int Major,
            [Out] out int Minor,
            [SRI.Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U1, SizeParamIndex = 4)] byte[] ServicePackString,
            [In] int ServicePackStringSize,
            [Out] out int ServicePackStringUsed,
            [Out] out int ServicePackNumber,
            [SRI.Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U1, SizeParamIndex = 8)] byte[] BuildString,
            [In] int BuildStringSize,
            [Out] out int BuildStringUsed);*/
            int platformId;
            int major;
            int minor;
            byte[] servicePackString;
            int servicePackStringSize = 0;
            int servicePackStringUsed;
            int servicePackNumber;
            byte[] buildString;
            int buildStringSize = 0;
            int buildStringUsed;
            HRESULT hr = Raw.GetSystemVersion(out platformId, out major, out minor, null, servicePackStringSize, out servicePackStringUsed, out servicePackNumber, null, buildStringSize, out buildStringUsed);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER && hr != HRESULT.S_OK)
                goto fail;

            servicePackStringSize = servicePackStringUsed;
            servicePackString = new byte[servicePackStringSize];
            buildStringSize = buildStringUsed;
            buildString = new byte[buildStringSize];
            hr = Raw.GetSystemVersion(out platformId, out major, out minor, servicePackString, servicePackStringSize, out servicePackStringUsed, out servicePackNumber, buildString, buildStringSize, out buildStringUsed);

            if (hr == HRESULT.S_OK)
            {
                result = new GetSystemVersionResult(platformId, major, minor, CreateString(servicePackString, servicePackStringUsed), servicePackNumber, CreateString(buildString, buildStringUsed));

                return hr;
            }

            fail:
            result = default(GetSystemVersionResult);

            return hr;
        }

        #endregion
        #region PageSize

        /// <summary>
        /// The GetPageSize method returns the page size for the effective processor mode.
        /// </summary>
        public int PageSize
        {
            get
            {
                int size;
                TryGetPageSize(out size).ThrowDbgEngNotOK();

                return size;
            }
        }

        /// <summary>
        /// The GetPageSize method returns the page size for the effective processor mode.
        /// </summary>
        /// <param name="size">[out] Receives the page size.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        public HRESULT TryGetPageSize(out int size)
        {
            /*HRESULT GetPageSize(
            [Out] out int Size);*/
            return Raw.GetPageSize(out size);
        }

        #endregion
        #region IsPointer64Bit

        /// <summary>
        /// The IsPointer64Bit method determines if the effective processor uses 64-bit pointers.
        /// </summary>
        public bool IsPointer64Bit
        {
            get
            {
                HRESULT hr = TryIsPointer64Bit();
                hr.ThrowDbgEngFailed();

                return hr == HRESULT.S_OK;
            }
        }

        /// <summary>
        /// The IsPointer64Bit method determines if the effective processor uses 64-bit pointers.
        /// </summary>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        public HRESULT TryIsPointer64Bit()
        {
            /*HRESULT IsPointer64Bit();*/
            return Raw.IsPointer64Bit();
        }

        #endregion
        #region NumberSupportedProcessorTypes

        /// <summary>
        /// The GetNumberSupportedProcessorTypes method returns the number of processor types supported by the engine.
        /// </summary>
        public int NumberSupportedProcessorTypes
        {
            get
            {
                int number;
                TryGetNumberSupportedProcessorTypes(out number).ThrowDbgEngNotOK();

                return number;
            }
        }

        /// <summary>
        /// The GetNumberSupportedProcessorTypes method returns the number of processor types supported by the engine.
        /// </summary>
        /// <param name="number">[out] Receives the number of processor types.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// For more information, see Target Information.
        /// </remarks>
        public HRESULT TryGetNumberSupportedProcessorTypes(out int number)
        {
            /*HRESULT GetNumberSupportedProcessorTypes(
            [Out] out int Number);*/
            return Raw.GetNumberSupportedProcessorTypes(out number);
        }

        #endregion
        #region EffectiveProcessorType

        /// <summary>
        /// The GetEffectiveProcessorType method returns the effective processor type of the processor of the computer that is running the target.
        /// </summary>
        public IMAGE_FILE_MACHINE EffectiveProcessorType
        {
            get
            {
                IMAGE_FILE_MACHINE type;
                TryGetEffectiveProcessorType(out type).ThrowDbgEngNotOK();

                return type;
            }
            set
            {
                TrySetEffectiveProcessorType(value).ThrowDbgEngNotOK();
            }
        }

        /// <summary>
        /// The GetEffectiveProcessorType method returns the effective processor type of the processor of the computer that is running the target.
        /// </summary>
        /// <param name="type">[out] Receives the type of the processor. For possible values, see the Type parameter in <see cref="ActualProcessorType"/>.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// For more information, see Target Information.
        /// </remarks>
        public HRESULT TryGetEffectiveProcessorType(out IMAGE_FILE_MACHINE type)
        {
            /*HRESULT GetEffectiveProcessorType(
            [Out] out IMAGE_FILE_MACHINE Type);*/
            return Raw.GetEffectiveProcessorType(out type);
        }

        /// <summary>
        /// The SetEffectiveProcessorType method sets the effective processor type of the processor of the computer that is running the target.
        /// </summary>
        /// <param name="type">[in] Specifies the type of the processor. For possible values, see the Type parameter in <see cref="ActualProcessorType"/>.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// For more information, see Target Information.
        /// </remarks>
        public HRESULT TrySetEffectiveProcessorType(IMAGE_FILE_MACHINE type)
        {
            /*HRESULT SetEffectiveProcessorType(
            [In] IMAGE_FILE_MACHINE Type);*/
            return Raw.SetEffectiveProcessorType(type);
        }

        #endregion
        #region ExecutionStatus

        /// <summary>
        /// The GetExecutionStatus method returns information about the execution status of the debugger engine.
        /// </summary>
        public DEBUG_STATUS ExecutionStatus
        {
            get
            {
                DEBUG_STATUS status;
                TryGetExecutionStatus(out status).ThrowDbgEngNotOK();

                return status;
            }
            set
            {
                TrySetExecutionStatus(value).ThrowDbgEngNotOK();
            }
        }

        /// <summary>
        /// The GetExecutionStatus method returns information about the execution status of the debugger engine.
        /// </summary>
        /// <param name="status">[out] Receives the execution status. This will be set to one of the values in the following table. Note that the description of these values differs slightly from the description in DEBUG_STATUS_XXX.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// For more information, see Target Information.
        /// </remarks>
        public HRESULT TryGetExecutionStatus(out DEBUG_STATUS status)
        {
            /*HRESULT GetExecutionStatus(
            [Out] out DEBUG_STATUS Status);*/
            return Raw.GetExecutionStatus(out status);
        }

        /// <summary>
        /// The SetExecutionStatus method requests that the debugger engine enter an executable state. Actual execution will not occur until the next time <see cref="WaitForEvent"/> is called.
        /// </summary>
        /// <param name="status">[in] Specifies the mode for the engine to use when executing. Possible values are those values in the table in DEBUG_STATUS_XXX whose precedence lies between DEBUG_STATUS_GO and DEBUG_STATUS_STEP_INTO.</param>
        /// <returns>This method may also return other error values. See Return Values for more details.</returns>
        /// <remarks>
        /// For more information, see Target Information.
        /// </remarks>
        public HRESULT TrySetExecutionStatus(DEBUG_STATUS status)
        {
            /*HRESULT SetExecutionStatus(
            [In] DEBUG_STATUS Status);*/
            return Raw.SetExecutionStatus(status);
        }

        #endregion
        #region CodeLevel

        /// <summary>
        /// The GetCodeLevel method returns the current code level and is mainly used when stepping through code.
        /// </summary>
        public DEBUG_LEVEL CodeLevel
        {
            get
            {
                DEBUG_LEVEL level;
                TryGetCodeLevel(out level).ThrowDbgEngNotOK();

                return level;
            }
            set
            {
                TrySetCodeLevel(value).ThrowDbgEngNotOK();
            }
        }

        /// <summary>
        /// The GetCodeLevel method returns the current code level and is mainly used when stepping through code.
        /// </summary>
        /// <param name="level">[out] Receives the current code level. Level can take one of the values in the following table.</param>
        /// <returns>This method can also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// For more information about the code level, see Using Source Files.
        /// </remarks>
        public HRESULT TryGetCodeLevel(out DEBUG_LEVEL level)
        {
            /*HRESULT GetCodeLevel(
            [Out] out DEBUG_LEVEL Level);*/
            return Raw.GetCodeLevel(out level);
        }

        /// <summary>
        /// The SetCodeLevel method sets the current code level and is mainly used when stepping through code.
        /// </summary>
        /// <param name="level">[in] Specifies the current code level. Level can take one of the values in the following table.</param>
        /// <returns>This method can also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// For more information about the code level, see Using Source Files.
        /// </remarks>
        public HRESULT TrySetCodeLevel(DEBUG_LEVEL level)
        {
            /*HRESULT SetCodeLevel(
            [In] DEBUG_LEVEL Level);*/
            return Raw.SetCodeLevel(level);
        }

        #endregion
        #region EngineOptions

        /// <summary>
        /// The GetEngineOptions method returns the engine's options.
        /// </summary>
        public DEBUG_ENGOPT EngineOptions
        {
            get
            {
                DEBUG_ENGOPT options;
                TryGetEngineOptions(out options).ThrowDbgEngNotOK();

                return options;
            }
            set
            {
                TrySetEngineOptions(value).ThrowDbgEngNotOK();
            }
        }

        /// <summary>
        /// The GetEngineOptions method returns the engine's options.
        /// </summary>
        /// <param name="options">[out] Receives a bit-set that contains the engine's options. For a description of the engine options, see DEBUG_ENGOPT_XXX.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        public HRESULT TryGetEngineOptions(out DEBUG_ENGOPT options)
        {
            /*HRESULT GetEngineOptions(
            [Out] out DEBUG_ENGOPT Options);*/
            return Raw.GetEngineOptions(out options);
        }

        /// <summary>
        /// The SetEngineOptions method changes the engine's options.
        /// </summary>
        /// <param name="options">[in] Specifies the engine's new options. Options is a bit-set; it will replace the existing symbol options. For a description of the engine options, see Remarks.</param>
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
        public HRESULT TrySetEngineOptions(DEBUG_ENGOPT options)
        {
            /*HRESULT SetEngineOptions(
            [In] DEBUG_ENGOPT Options);*/
            return Raw.SetEngineOptions(options);
        }

        #endregion
        #region SystemErrorControl

        /// <summary>
        /// The GetSystemErrorControl method returns the control values for handling system errors.
        /// </summary>
        public GetSystemErrorControlResult SystemErrorControl
        {
            get
            {
                GetSystemErrorControlResult result;
                TryGetSystemErrorControl(out result).ThrowDbgEngNotOK();

                return result;
            }
        }

        /// <summary>
        /// The GetSystemErrorControl method returns the control values for handling system errors.
        /// </summary>
        /// <param name="result">The values that were emitted from the COM method.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// The level of a system error can take one of the following three values, listed from lowest to highest: SLE_ERROR,
        /// SLE_MINORERROR, and SLE_WARNING. These values are defined in Winuser.h. When a system error occurs, the engine
        /// calls the <see cref="IDebugEventCallbacks.SystemError"/> method of the event callbacks. If the level is less than
        /// or equal to BreakLevel, the error will break into the debugger. If the level is greater than BreakLevel, the engine
        /// will proceed with execution in the target as indicated by the IDebugEventCallbacks::SystemError method calls. For
        /// more information about how the engine proceeds after an event, see Monitoring Events.
        /// </remarks>
        public HRESULT TryGetSystemErrorControl(out GetSystemErrorControlResult result)
        {
            /*HRESULT GetSystemErrorControl(
            [Out] out ERROR_LEVEL OutputLevel,
            [Out] out ERROR_LEVEL BreakLevel);*/
            ERROR_LEVEL outputLevel;
            ERROR_LEVEL breakLevel;
            HRESULT hr = Raw.GetSystemErrorControl(out outputLevel, out breakLevel);

            if (hr == HRESULT.S_OK)
                result = new GetSystemErrorControlResult(outputLevel, breakLevel);
            else
                result = default(GetSystemErrorControlResult);

            return hr;
        }

        #endregion
        #region Radix

        /// <summary>
        /// The GetRadix method returns the default radix (number base) used by the debugger engine when it evaluates and displays MASM expressions, and when it displays symbol information.
        /// </summary>
        public int Radix
        {
            get
            {
                int radix;
                TryGetRadix(out radix).ThrowDbgEngNotOK();

                return radix;
            }
            set
            {
                TrySetRadix(value).ThrowDbgEngNotOK();
            }
        }

        /// <summary>
        /// The GetRadix method returns the default radix (number base) used by the debugger engine when it evaluates and displays MASM expressions, and when it displays symbol information.
        /// </summary>
        /// <param name="radix">[out] Receives the default radix.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// For more information about the default radix, see Using Input and Output.
        /// </remarks>
        public HRESULT TryGetRadix(out int radix)
        {
            /*HRESULT GetRadix(
            [Out] out int Radix);*/
            return Raw.GetRadix(out radix);
        }

        /// <summary>
        /// The SetRadix method sets the default radix (number base) used by the debugger engine when it evaluates and displays MASM expressions, and when it displays symbol information.
        /// </summary>
        /// <param name="radix">[in] Specifies the new default radix. The following table contains the possible values for the radix.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// When the radix is changed, the engine notifies the event callbacks by passing the DEBUG_CES_RADIX flag to the <see
        /// cref="IDebugEventCallbacks.ChangeEngineState"/> callback method. For more information about the default radix,
        /// see Using Input and Output.
        /// </remarks>
        public HRESULT TrySetRadix(int radix)
        {
            /*HRESULT SetRadix(
            [In] int Radix);*/
            return Raw.SetRadix(radix);
        }

        #endregion
        #region NumberBreakpoints

        /// <summary>
        /// The GetNumberBreakpoints method returns the number of breakpoints for the current process.
        /// </summary>
        public int NumberBreakpoints
        {
            get
            {
                int number;
                TryGetNumberBreakpoints(out number).ThrowDbgEngNotOK();

                return number;
            }
        }

        /// <summary>
        /// The GetNumberBreakpoints method returns the number of breakpoints for the current process.
        /// </summary>
        /// <param name="number">[out] Receives the number of breakpoints.</param>
        /// <returns>This method can also return error values. See Return Values for more details.</returns>
        public HRESULT TryGetNumberBreakpoints(out int number)
        {
            /*HRESULT GetNumberBreakpoints(
            [Out] out int Number);*/
            return Raw.GetNumberBreakpoints(out number);
        }

        #endregion
        #region NumberEventFilters

        /// <summary>
        /// The GetNumberEventFilters method returns the number of event filters currently used by the engine.
        /// </summary>
        public GetNumberEventFiltersResult NumberEventFilters
        {
            get
            {
                GetNumberEventFiltersResult result;
                TryGetNumberEventFilters(out result).ThrowDbgEngNotOK();

                return result;
            }
        }

        /// <summary>
        /// The GetNumberEventFilters method returns the number of event filters currently used by the engine.
        /// </summary>
        /// <param name="result">The values that were emitted from the COM method.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// For more information about event filters, see Event Filters.
        /// </remarks>
        public HRESULT TryGetNumberEventFilters(out GetNumberEventFiltersResult result)
        {
            /*HRESULT GetNumberEventFilters(
            [Out] out int SpecificEvents,
            [Out] out int SpecificExceptions,
            [Out] out int ArbitraryExceptions);*/
            int specificEvents;
            int specificExceptions;
            int arbitraryExceptions;
            HRESULT hr = Raw.GetNumberEventFilters(out specificEvents, out specificExceptions, out arbitraryExceptions);

            if (hr == HRESULT.S_OK)
                result = new GetNumberEventFiltersResult(specificEvents, specificExceptions, arbitraryExceptions);
            else
                result = default(GetNumberEventFiltersResult);

            return hr;
        }

        #endregion
        #region LastEventInformation

        /// <summary>
        /// The GetLastEventInformation method returns information about the last event that occurred in a target.
        /// </summary>
        public GetLastEventInformationResult LastEventInformation
        {
            get
            {
                GetLastEventInformationResult result;
                TryGetLastEventInformation(out result).ThrowDbgEngNotOK();

                return result;
            }
        }

        /// <summary>
        /// The GetLastEventInformation method returns information about the last event that occurred in a target.
        /// </summary>
        /// <param name="result">The values that were emitted from the COM method.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// For thread and process creation events, the thread index and process ID returned to ThreadId and ProcessId are
        /// for the newly created thread or process. For more information about the last event, see the topic Event Information.
        /// </remarks>
        public HRESULT TryGetLastEventInformation(out GetLastEventInformationResult result)
        {
            /*HRESULT GetLastEventInformation(
            [Out] out DEBUG_EVENT_TYPE Type,
            [Out] out int ProcessId,
            [Out] out int ThreadId,
            [Out, ComAliasName("IntPtr")] out DEBUG_LAST_EVENT_INFO ExtraInformation,
            [In] int ExtraInformationSize,
            [Out] out int ExtraInformationUsed,
            [SRI.Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U1, SizeParamIndex = 7)] byte[] Description,
            [In] int DescriptionSize,
            [Out] out int DescriptionUsed);*/
            DEBUG_EVENT_TYPE type;
            int processId;
            int threadId;
            DEBUG_LAST_EVENT_INFO extraInformation;
            int extraInformationSize = Marshal.SizeOf<DEBUG_LAST_EVENT_INFO>();
            int extraInformationUsed;
            byte[] description;
            int descriptionSize = 0;
            int descriptionUsed;
            HRESULT hr = Raw.GetLastEventInformation(out type, out processId, out threadId, out extraInformation, extraInformationSize, out extraInformationUsed, null, descriptionSize, out descriptionUsed);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER && hr != HRESULT.S_OK)
                goto fail;

            descriptionSize = descriptionUsed;
            description = new byte[descriptionSize];
            hr = Raw.GetLastEventInformation(out type, out processId, out threadId, out extraInformation, extraInformationSize, out extraInformationUsed, description, descriptionSize, out descriptionUsed);

            if (hr == HRESULT.S_OK)
            {
                result = new GetLastEventInformationResult(type, processId, threadId, extraInformation, CreateString(description, descriptionUsed));

                return hr;
            }

            fail:
            result = default(GetLastEventInformationResult);

            return hr;
        }

        #endregion
        #region GetInterrupt

        /// <summary>
        /// The GetInterrupt method checks whether a user interrupt was issued.
        /// </summary>
        /// <remarks>
        /// If a user interrupt was issued, it is cleared when this method is called. Examples of user interrupts include pressing
        /// Ctrl+C or pressing the Stop button in a debugger. Calling <see cref="SetInterrupt"/> also causes a user interrupt.
        /// </remarks>
        public void GetInterrupt()
        {
            TryGetInterrupt().ThrowDbgEngNotOK();
        }

        /// <summary>
        /// The GetInterrupt method checks whether a user interrupt was issued.
        /// </summary>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// If a user interrupt was issued, it is cleared when this method is called. Examples of user interrupts include pressing
        /// Ctrl+C or pressing the Stop button in a debugger. Calling <see cref="SetInterrupt"/> also causes a user interrupt.
        /// </remarks>
        public HRESULT TryGetInterrupt()
        {
            /*HRESULT GetInterrupt();*/
            return Raw.GetInterrupt();
        }

        #endregion
        #region SetInterrupt

        /// <summary>
        /// The SetInterrupt method registers a user interrupt or breaks into the debugger.
        /// </summary>
        /// <param name="flags">[in] Specifies the type of interrupt to register. Flags can take one of the values listed in the following table.<para/>
        /// Otherwise, when the target is suspended, the engine will register a user interrupt. Otherwise, when the target is suspended, register a user interrupt.</param>
        /// <remarks>
        /// This method can be called at any time and from any thread. Once the interrupt has been registered, this method
        /// returns immediately. If Flags is DEBUG_INTERRUPT_ACTIVE, and the interrupt times out, the engine will generate
        /// a synthetic exception event. This event will be sent to event callback's <see cref="IDebugEventCallbacks.Exception"/>
        /// method. The amount of time before the interrupt times out can be set using <see cref="InterruptTimeout"/>.
        /// </remarks>
        public void SetInterrupt(DEBUG_INTERRUPT flags)
        {
            TrySetInterrupt(flags).ThrowDbgEngNotOK();
        }

        /// <summary>
        /// The SetInterrupt method registers a user interrupt or breaks into the debugger.
        /// </summary>
        /// <param name="flags">[in] Specifies the type of interrupt to register. Flags can take one of the values listed in the following table.<para/>
        /// Otherwise, when the target is suspended, the engine will register a user interrupt. Otherwise, when the target is suspended, register a user interrupt.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// This method can be called at any time and from any thread. Once the interrupt has been registered, this method
        /// returns immediately. If Flags is DEBUG_INTERRUPT_ACTIVE, and the interrupt times out, the engine will generate
        /// a synthetic exception event. This event will be sent to event callback's <see cref="IDebugEventCallbacks.Exception"/>
        /// method. The amount of time before the interrupt times out can be set using <see cref="InterruptTimeout"/>.
        /// </remarks>
        public HRESULT TrySetInterrupt(DEBUG_INTERRUPT flags)
        {
            /*HRESULT SetInterrupt(
            [In] DEBUG_INTERRUPT Flags);*/
            return Raw.SetInterrupt(flags);
        }

        #endregion
        #region OpenLogFile

        /// <summary>
        /// The OpenLogFile method opens a log file that will receive output from the client objects.
        /// </summary>
        /// <param name="file">[in] Specifies the name of the log file. File can include a relative or absolute path; relative paths are relative to the directory in which the debugger was started.<para/>
        /// If the file does not exist, it will be created.</param>
        /// <param name="append">[in] Specifies whether or not to append log messages to an existing log file. If TRUE, log messages will be appended to the file; if FALSE, the contents of any existing file matching File are discarded.</param>
        /// <remarks>
        /// OpenLogFile and OpenLogFileWide behave the same way as <see cref="OpenLogFile2"/> and OpenLogFile2Wide
        /// with Flags set to DEBUG_LOG_APPEND if Append is TRUE and DEBUG_LOG_DEFAULT otherwise. Only one log file can be
        /// open at a time. If there is already a log file open, it will be closed. For more information about log files, see
        /// Using Input and Output.
        /// </remarks>
        public void OpenLogFile(string file, bool append)
        {
            TryOpenLogFile(file, append).ThrowDbgEngNotOK();
        }

        /// <summary>
        /// The OpenLogFile method opens a log file that will receive output from the client objects.
        /// </summary>
        /// <param name="file">[in] Specifies the name of the log file. File can include a relative or absolute path; relative paths are relative to the directory in which the debugger was started.<para/>
        /// If the file does not exist, it will be created.</param>
        /// <param name="append">[in] Specifies whether or not to append log messages to an existing log file. If TRUE, log messages will be appended to the file; if FALSE, the contents of any existing file matching File are discarded.</param>
        /// <returns>This method can also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// OpenLogFile and OpenLogFileWide behave the same way as <see cref="OpenLogFile2"/> and OpenLogFile2Wide
        /// with Flags set to DEBUG_LOG_APPEND if Append is TRUE and DEBUG_LOG_DEFAULT otherwise. Only one log file can be
        /// open at a time. If there is already a log file open, it will be closed. For more information about log files, see
        /// Using Input and Output.
        /// </remarks>
        public HRESULT TryOpenLogFile(string file, bool append)
        {
            /*HRESULT OpenLogFile(
            [In, MarshalAs(UnmanagedType.LPStr)] string File,
            [In, MarshalAs(UnmanagedType.Bool)] bool Append);*/
            return Raw.OpenLogFile(file, append);
        }

        #endregion
        #region CloseLogFile

        /// <summary>
        /// The CloseLogFile method closes the currently-open log file.
        /// </summary>
        /// <remarks>
        /// If no log file is open, this method has no effect. For more about log files, see Using Input and Output.
        /// </remarks>
        public void CloseLogFile()
        {
            TryCloseLogFile().ThrowDbgEngNotOK();
        }

        /// <summary>
        /// The CloseLogFile method closes the currently-open log file.
        /// </summary>
        /// <returns>This method can also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// If no log file is open, this method has no effect. For more about log files, see Using Input and Output.
        /// </remarks>
        public HRESULT TryCloseLogFile()
        {
            /*HRESULT CloseLogFile();*/
            return Raw.CloseLogFile();
        }

        #endregion
        #region Input

        /// <summary>
        /// The Input method requests an input string from the debugger engine.
        /// </summary>
        /// <returns>[out] Receives the input string from the engine.</returns>
        /// <remarks>
        /// For an overview of input in the debugger engine, see Input and Output.
        /// </remarks>
        public string Input()
        {
            string bufferResult;
            TryInput(out bufferResult).ThrowDbgEngNotOK();

            return bufferResult;
        }

        /// <summary>
        /// The Input method requests an input string from the debugger engine.
        /// </summary>
        /// <param name="bufferResult">[out] Receives the input string from the engine.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// For an overview of input in the debugger engine, see Input and Output.
        /// </remarks>
        public HRESULT TryInput(out string bufferResult)
        {
            /*HRESULT Input(
            [SRI.Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U1, SizeParamIndex = 1)] byte[] Buffer,
            [In] int BufferSize,
            [Out] out int InputSize);*/
            byte[] buffer;
            int bufferSize = 0;
            int inputSize;
            HRESULT hr = Raw.Input(null, bufferSize, out inputSize);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER && hr != HRESULT.S_OK)
                goto fail;

            bufferSize = inputSize;
            buffer = new byte[bufferSize];
            hr = Raw.Input(buffer, bufferSize, out inputSize);

            if (hr == HRESULT.S_OK)
            {
                bufferResult = CreateString(buffer, inputSize);

                return hr;
            }

            fail:
            bufferResult = default(string);

            return hr;
        }

        #endregion
        #region ReturnInput

        /// <summary>
        /// The ReturnInput method is used by IDebugInputCallbacks objects to send an input string to the engine following a request for input.
        /// </summary>
        /// <param name="buffer">[in] Specifies the input string being sent to the engine.</param>
        /// <remarks>
        /// For an overview of input in the debugger engine, see Input and Output.
        /// </remarks>
        public void ReturnInput(string buffer)
        {
            TryReturnInput(buffer).ThrowDbgEngNotOK();
        }

        /// <summary>
        /// The ReturnInput method is used by IDebugInputCallbacks objects to send an input string to the engine following a request for input.
        /// </summary>
        /// <param name="buffer">[in] Specifies the input string being sent to the engine.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// For an overview of input in the debugger engine, see Input and Output.
        /// </remarks>
        public HRESULT TryReturnInput(string buffer)
        {
            /*HRESULT ReturnInput(
            [In, MarshalAs(UnmanagedType.LPStr)] string Buffer);*/
            return Raw.ReturnInput(buffer);
        }

        #endregion
        #region Output

        /// <summary>
        /// The Output method formats a string and send the result to output callbacks that have been registered with the engine's clients.
        /// </summary>
        /// <param name="mask">[in] Specifies the output-type bit field. See DEBUG_OUTPUT_XXX for possible values.</param>
        /// <param name="format">[in] Specifies the format string, as in printf. In general, conversion characters work exactly as in C. For the floating-point conversion characters the 64-bit argument is interpreted as a 32-bit floating-point number unless the l modifier is used.<para/>
        /// The %p conversion character is supported, but it represents a pointer in a target's address space. It cannot have any modifiers and it uses the debugger's internal address formatting.<para/>
        /// The following additional conversion characters are supported.</param>
        /// <remarks>
        /// When generating very large output strings, it is possible to reach the limits of the debugger engine or of the
        /// operating system. For example, some versions of the debugger engine have a 16K character limit for a single output.
        /// If you find that very large output is getting truncated, you might need to split your output into multiple requests.
        /// </remarks>
        public void Output(DEBUG_OUTPUT mask, string format)
        {
            TryOutput(mask, format).ThrowDbgEngNotOK();
        }

        /// <summary>
        /// The Output method formats a string and send the result to output callbacks that have been registered with the engine's clients.
        /// </summary>
        /// <param name="mask">[in] Specifies the output-type bit field. See DEBUG_OUTPUT_XXX for possible values.</param>
        /// <param name="format">[in] Specifies the format string, as in printf. In general, conversion characters work exactly as in C. For the floating-point conversion characters the 64-bit argument is interpreted as a 32-bit floating-point number unless the l modifier is used.<para/>
        /// The %p conversion character is supported, but it represents a pointer in a target's address space. It cannot have any modifiers and it uses the debugger's internal address formatting.<para/>
        /// The following additional conversion characters are supported.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// When generating very large output strings, it is possible to reach the limits of the debugger engine or of the
        /// operating system. For example, some versions of the debugger engine have a 16K character limit for a single output.
        /// If you find that very large output is getting truncated, you might need to split your output into multiple requests.
        /// </remarks>
        public HRESULT TryOutput(DEBUG_OUTPUT mask, string format)
        {
            /*HRESULT Output(
            [In] DEBUG_OUTPUT Mask,
            [In, MarshalAs(UnmanagedType.LPStr)] string Format);*/
            return Raw.Output(mask, format);
        }

        #endregion
        #region OutputVaList

        /// <summary>
        /// The OutputVaList method formats a string and sends the result to the output callbacks that are registered with the engine's clients.
        /// </summary>
        /// <param name="mask">[in] Specifies the output-type bit field. See DEBUG_OUTPUT_XXX for possible values.</param>
        /// <param name="format">[in] Specifies the format string, as in printf. Typically, conversion characters work exactly as they do in C. For the floating-point conversion characters, the 64-bit argument is interpreted as a 32-bit floating-point number unless the l modifier is used.<para/>
        /// The %p conversion character is supported, but it represents a pointer in a target's address space. It might not have any modifiers, and it uses the debugger's internal address formatting.<para/>
        /// The following additional conversion characters are supported.</param>
        /// <param name="va_list_Args">[in] Specifies additional parameters that represent values to be inserted into the output during formatting. Args must be initialized using va_start.<para/>
        /// This method does not call va_end.</param>
        /// <remarks>
        /// When generating very large output strings, it is possible to reach the limits of the debugger engine or of the
        /// operating system. For example, some versions of the debugger engine have a 16K character limit for a single output.
        /// If you find that very large output is getting truncated, you might need to split your output into multiple requests.
        /// </remarks>
        [Obsolete("This method cannot be safely called from managed code")]
        public void OutputVaList(DEBUG_OUTPUT mask, string format, IntPtr va_list_Args)
        {
            TryOutputVaList(mask, format, va_list_Args).ThrowDbgEngNotOK();
        }

        /// <summary>
        /// The OutputVaList method formats a string and sends the result to the output callbacks that are registered with the engine's clients.
        /// </summary>
        /// <param name="mask">[in] Specifies the output-type bit field. See DEBUG_OUTPUT_XXX for possible values.</param>
        /// <param name="format">[in] Specifies the format string, as in printf. Typically, conversion characters work exactly as they do in C. For the floating-point conversion characters, the 64-bit argument is interpreted as a 32-bit floating-point number unless the l modifier is used.<para/>
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
        [Obsolete("This method cannot be safely called from managed code")]
        public HRESULT TryOutputVaList(DEBUG_OUTPUT mask, string format, IntPtr va_list_Args)
        {
            /*HRESULT OutputVaList(
            [In] DEBUG_OUTPUT Mask,
            [In, MarshalAs(UnmanagedType.LPStr)] string Format,
            [In] IntPtr va_list_Args);*/
            return Raw.OutputVaList(mask, format, va_list_Args);
        }

        #endregion
        #region ControlledOutput

        /// <summary>
        /// The ControlledOutput method formats a string and sends the result to output callbacks that were registered with some of the engine's clients.
        /// </summary>
        /// <param name="outputControl">[in] Specifies an output control that determines which of the clients' output callbacks will receive the output.<para/>
        /// For possible values, see DEBUG_OUTCTL_XXX. For more information about output, see Input and Output.</param>
        /// <param name="mask">[in] Specifies the output-type bit field. See DEBUG_OUTPUT_XXX for possible values.</param>
        /// <param name="format">[in] Specifies the format string, as in printf. Typically, conversion characters work exactly as they do in C. For the floating-point conversion characters, the 64-bit argument is interpreted as a 32-bit floating-point number unless the l modifier is used.<para/>
        /// The %p conversion character is supported, but it represents a pointer in a target's address space. It might not have any modifiers and it uses the debugger's internal address formatting.<para/>
        /// The following additional conversion characters are supported. The %Y format specifier can be used to support the Debugger Markup Language (DML).<para/>
        /// For more information, see Customizing Debugger Output Using DML. The following table summarizes the use of the %Y format specifier.<para/>
        /// This code snippet illustrates the use of the %Y format specifier. This sample code would generate the following output.</param>
        /// <remarks>
        /// When generating very large output strings, it is possible to reach the limits of the debugger engine or of the
        /// operating system. For example, some versions of the debugger engine have a 16K character limit for a single output.
        /// If you find that very large output is getting truncated, you might need to split your output into multiple requests.
        /// </remarks>
        public void ControlledOutput(DEBUG_OUTCTL outputControl, DEBUG_OUTPUT mask, string format)
        {
            TryControlledOutput(outputControl, mask, format).ThrowDbgEngNotOK();
        }

        /// <summary>
        /// The ControlledOutput method formats a string and sends the result to output callbacks that were registered with some of the engine's clients.
        /// </summary>
        /// <param name="outputControl">[in] Specifies an output control that determines which of the clients' output callbacks will receive the output.<para/>
        /// For possible values, see DEBUG_OUTCTL_XXX. For more information about output, see Input and Output.</param>
        /// <param name="mask">[in] Specifies the output-type bit field. See DEBUG_OUTPUT_XXX for possible values.</param>
        /// <param name="format">[in] Specifies the format string, as in printf. Typically, conversion characters work exactly as they do in C. For the floating-point conversion characters, the 64-bit argument is interpreted as a 32-bit floating-point number unless the l modifier is used.<para/>
        /// The %p conversion character is supported, but it represents a pointer in a target's address space. It might not have any modifiers and it uses the debugger's internal address formatting.<para/>
        /// The following additional conversion characters are supported. The %Y format specifier can be used to support the Debugger Markup Language (DML).<para/>
        /// For more information, see Customizing Debugger Output Using DML. The following table summarizes the use of the %Y format specifier.<para/>
        /// This code snippet illustrates the use of the %Y format specifier. This sample code would generate the following output.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// When generating very large output strings, it is possible to reach the limits of the debugger engine or of the
        /// operating system. For example, some versions of the debugger engine have a 16K character limit for a single output.
        /// If you find that very large output is getting truncated, you might need to split your output into multiple requests.
        /// </remarks>
        public HRESULT TryControlledOutput(DEBUG_OUTCTL outputControl, DEBUG_OUTPUT mask, string format)
        {
            /*HRESULT ControlledOutput(
            [In] DEBUG_OUTCTL OutputControl,
            [In] DEBUG_OUTPUT Mask,
            [In, MarshalAs(UnmanagedType.LPStr)] string Format);*/
            return Raw.ControlledOutput(outputControl, mask, format);
        }

        #endregion
        #region ControlledOutputVaList

        /// <summary>
        /// The ControlledOutputVaList method formats a string and sends the result to output callbacks that were registered with some of the engine's clients.
        /// </summary>
        /// <param name="outputControl">[in] Specifies an output control that determines which client's output callbacks will receive the output. For possible values, see DEBUG_OUTCTL_XXX.<para/>
        /// For more information about output, see Input and Output.</param>
        /// <param name="mask">[in] Specifies the output-type bit field. See DEBUG_OUTPUT_XXX for possible values.</param>
        /// <param name="format">[in] Specifies the format string, as in printf. Typically, conversion characters work exactly as they do in C. For the floating-point conversion characters, the 64-bit argument is interpreted as a 32-bit floating-point number unless the l modifier is used.<para/>
        /// The %p conversion character is supported, but it represents a pointer in a target's address space. It might not have any modifiers, and it uses the debugger's internal address formatting.<para/>
        /// The following additional conversion characters are supported. The %Y format specifier can be used to support the Debugger Markup Language (DML).<para/>
        /// For more information, see Customizing Debugger Output Using DML. The following table summarizes the use of the %Y format specifier.<para/>
        /// This code snippet illustrates the use of the %Y format specifier. This sample code would generate the following output.</param>
        /// <param name="va_list_Args">[in] Specifies additional parameters that represent values to be inserted into the output during formatting. Args must be initialized using va_start.<para/>
        /// This method does not call va_end.</param>
        /// <remarks>
        /// When generating very large output strings, it is possible to reach the limits of the debugger engine or of the
        /// operating system. For example, some versions of the debugger engine have a 16K character limit for a single output.
        /// If you find that very large output is getting truncated, you might need to split your output into multiple requests.
        /// The macros va_list, va_start, and va_end are defined in Stdarg.h.
        /// </remarks>
        [Obsolete("This method cannot be safely called from managed code")]
        public void ControlledOutputVaList(DEBUG_OUTCTL outputControl, DEBUG_OUTPUT mask, string format, IntPtr va_list_Args)
        {
            TryControlledOutputVaList(outputControl, mask, format, va_list_Args).ThrowDbgEngNotOK();
        }

        /// <summary>
        /// The ControlledOutputVaList method formats a string and sends the result to output callbacks that were registered with some of the engine's clients.
        /// </summary>
        /// <param name="outputControl">[in] Specifies an output control that determines which client's output callbacks will receive the output. For possible values, see DEBUG_OUTCTL_XXX.<para/>
        /// For more information about output, see Input and Output.</param>
        /// <param name="mask">[in] Specifies the output-type bit field. See DEBUG_OUTPUT_XXX for possible values.</param>
        /// <param name="format">[in] Specifies the format string, as in printf. Typically, conversion characters work exactly as they do in C. For the floating-point conversion characters, the 64-bit argument is interpreted as a 32-bit floating-point number unless the l modifier is used.<para/>
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
        [Obsolete("This method cannot be safely called from managed code")]
        public HRESULT TryControlledOutputVaList(DEBUG_OUTCTL outputControl, DEBUG_OUTPUT mask, string format, IntPtr va_list_Args)
        {
            /*HRESULT ControlledOutputVaList(
            [In] DEBUG_OUTCTL OutputControl,
            [In] DEBUG_OUTPUT Mask,
            [In, MarshalAs(UnmanagedType.LPStr)] string Format,
            [In] IntPtr va_list_Args);*/
            return Raw.ControlledOutputVaList(outputControl, mask, format, va_list_Args);
        }

        #endregion
        #region OutputPrompt

        /// <summary>
        /// The OutputPrompt method formats and sends a user prompt to the output callback objects.
        /// </summary>
        /// <param name="outputControl">[in] Specifies an output control that determines which of the client's output callbacks will receive the output.<para/>
        /// For possible values, see DEBUG_OUTCTL_XXX.</param>
        /// <param name="format">[in, optional] Specifies the format string, as in printf. Typically, conversion characters work exactly as they do in C.<para/>
        /// For the floating-point conversion characters, the 64-bit argument is interpreted as a 32-bit floating-point number unless the l modifier is used.<para/>
        /// The %p conversion character is supported, but it represents a pointer in a target's address space. It might not have any modifiers and it uses the debugger's internal address formatting.<para/>
        /// The following additional conversion characters are supported. If Format is NULL, only the standard prompt text is sent to the output callbacks.</param>
        /// <remarks>
        /// OutputPrompt and OutputPromptWide can be used to prompt the user for input. The standard prompt will be sent to
        /// the output callbacks before the formatted text described by Format. The contents of the standard prompt is returned
        /// by the method <see cref="PromptText"/>. The prompt text is sent to the output callbacks with the DEBUG_OUTPUT_PROMPT
        /// output mask set. For more information about prompting the user, see Using Input and Output.
        /// </remarks>
        public void OutputPrompt(DEBUG_OUTCTL outputControl, string format)
        {
            TryOutputPrompt(outputControl, format).ThrowDbgEngNotOK();
        }

        /// <summary>
        /// The OutputPrompt method formats and sends a user prompt to the output callback objects.
        /// </summary>
        /// <param name="outputControl">[in] Specifies an output control that determines which of the client's output callbacks will receive the output.<para/>
        /// For possible values, see DEBUG_OUTCTL_XXX.</param>
        /// <param name="format">[in, optional] Specifies the format string, as in printf. Typically, conversion characters work exactly as they do in C.<para/>
        /// For the floating-point conversion characters, the 64-bit argument is interpreted as a 32-bit floating-point number unless the l modifier is used.<para/>
        /// The %p conversion character is supported, but it represents a pointer in a target's address space. It might not have any modifiers and it uses the debugger's internal address formatting.<para/>
        /// The following additional conversion characters are supported. If Format is NULL, only the standard prompt text is sent to the output callbacks.</param>
        /// <returns>This method can also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// OutputPrompt and OutputPromptWide can be used to prompt the user for input. The standard prompt will be sent to
        /// the output callbacks before the formatted text described by Format. The contents of the standard prompt is returned
        /// by the method <see cref="PromptText"/>. The prompt text is sent to the output callbacks with the DEBUG_OUTPUT_PROMPT
        /// output mask set. For more information about prompting the user, see Using Input and Output.
        /// </remarks>
        public HRESULT TryOutputPrompt(DEBUG_OUTCTL outputControl, string format)
        {
            /*HRESULT OutputPrompt(
            [In] DEBUG_OUTCTL OutputControl,
            [In, MarshalAs(UnmanagedType.LPStr)] string Format);*/
            return Raw.OutputPrompt(outputControl, format);
        }

        #endregion
        #region OutputPromptVaList

        /// <summary>
        /// The OutputPromptVaList method formats and sends a user prompt to the output callback objects.
        /// </summary>
        /// <param name="outputControl">[in] Specifies an output control that determines which of the client's output callbacks will receive the output.<para/>
        /// For possible values, see DEBUG_OUTCTL_XXX.</param>
        /// <param name="format">[in, optional] Specifies the format string, as in printf. Typically, conversion characters work exactly as they do in C.<para/>
        /// For the floating-point conversion characters, the 64-bit argument is interpreted as a 32-bit floating-point number unless the l modifier is used.<para/>
        /// The %p conversion character is supported, but it represents a pointer in a target's address space. It might not have any modifiers and it uses the debugger's internal address formatting.<para/>
        /// The following additional conversion characters are supported. If Format is NULL, only the standard prompt text is sent to the output callbacks.</param>
        /// <param name="va_list_Args">[in] Specifies additional parameters that represent values to be inserted into the output during formatting. Args must be initialized using va_start.<para/>
        /// This method does not call va_end.</param>
        /// <remarks>
        /// OutputPromptVaList and OutputPromptVaListWide can be used to prompt the user for input. The standard prompt will
        /// be sent to the output callbacks before the formatted text described by Format. The contents of the standard prompt
        /// is returned by the method <see cref="PromptText"/>. The prompt text is sent to the output callbacks with the
        /// DEBUG_OUTPUT_PROMPT output mask set. For more information about prompting the user, see Using Input and Output.
        /// </remarks>
        [Obsolete("This method cannot be safely called from managed code")]
        public void OutputPromptVaList(DEBUG_OUTCTL outputControl, string format, IntPtr va_list_Args)
        {
            TryOutputPromptVaList(outputControl, format, va_list_Args).ThrowDbgEngNotOK();
        }

        /// <summary>
        /// The OutputPromptVaList method formats and sends a user prompt to the output callback objects.
        /// </summary>
        /// <param name="outputControl">[in] Specifies an output control that determines which of the client's output callbacks will receive the output.<para/>
        /// For possible values, see DEBUG_OUTCTL_XXX.</param>
        /// <param name="format">[in, optional] Specifies the format string, as in printf. Typically, conversion characters work exactly as they do in C.<para/>
        /// For the floating-point conversion characters, the 64-bit argument is interpreted as a 32-bit floating-point number unless the l modifier is used.<para/>
        /// The %p conversion character is supported, but it represents a pointer in a target's address space. It might not have any modifiers and it uses the debugger's internal address formatting.<para/>
        /// The following additional conversion characters are supported. If Format is NULL, only the standard prompt text is sent to the output callbacks.</param>
        /// <param name="va_list_Args">[in] Specifies additional parameters that represent values to be inserted into the output during formatting. Args must be initialized using va_start.<para/>
        /// This method does not call va_end.</param>
        /// <returns>This method can also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// OutputPromptVaList and OutputPromptVaListWide can be used to prompt the user for input. The standard prompt will
        /// be sent to the output callbacks before the formatted text described by Format. The contents of the standard prompt
        /// is returned by the method <see cref="PromptText"/>. The prompt text is sent to the output callbacks with the
        /// DEBUG_OUTPUT_PROMPT output mask set. For more information about prompting the user, see Using Input and Output.
        /// </remarks>
        [Obsolete("This method cannot be safely called from managed code")]
        public HRESULT TryOutputPromptVaList(DEBUG_OUTCTL outputControl, string format, IntPtr va_list_Args)
        {
            /*HRESULT OutputPromptVaList(
            [In] DEBUG_OUTCTL OutputControl,
            [In, MarshalAs(UnmanagedType.LPStr)] string Format,
            [In] IntPtr va_list_Args);*/
            return Raw.OutputPromptVaList(outputControl, format, va_list_Args);
        }

        #endregion
        #region OutputCurrentState

        /// <summary>
        /// The OutputCurrentState method prints the current state of the current target to the debugger console.
        /// </summary>
        /// <param name="outputControl">[in] Specifies which clients to send the output to. For possible values see DEBUG_OUTCTL_XXX.</param>
        /// <param name="flags">[in] Specifies the bit set that determines the information to print to the debugger console. Flags can be any combination of values from the following table.<para/>
        /// Alternatively, Flags can be set to DEBUG_CURRENT_DEFAULT. This value includes all of the above flags.</param>
        /// <remarks>
        /// Setting the flags contained in Flags merely allows the information to be printed. The information will not always
        /// be printed (for example, it will not be printed if it is not available). This is the same status information that
        /// is printed when breaking into the debugger. For more information, see Target Information.
        /// </remarks>
        public void OutputCurrentState(DEBUG_OUTCTL outputControl, DEBUG_CURRENT flags)
        {
            TryOutputCurrentState(outputControl, flags).ThrowDbgEngNotOK();
        }

        /// <summary>
        /// The OutputCurrentState method prints the current state of the current target to the debugger console.
        /// </summary>
        /// <param name="outputControl">[in] Specifies which clients to send the output to. For possible values see DEBUG_OUTCTL_XXX.</param>
        /// <param name="flags">[in] Specifies the bit set that determines the information to print to the debugger console. Flags can be any combination of values from the following table.<para/>
        /// Alternatively, Flags can be set to DEBUG_CURRENT_DEFAULT. This value includes all of the above flags.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// Setting the flags contained in Flags merely allows the information to be printed. The information will not always
        /// be printed (for example, it will not be printed if it is not available). This is the same status information that
        /// is printed when breaking into the debugger. For more information, see Target Information.
        /// </remarks>
        public HRESULT TryOutputCurrentState(DEBUG_OUTCTL outputControl, DEBUG_CURRENT flags)
        {
            /*HRESULT OutputCurrentState(
            [In] DEBUG_OUTCTL OutputControl,
            [In] DEBUG_CURRENT Flags);*/
            return Raw.OutputCurrentState(outputControl, flags);
        }

        #endregion
        #region OutputVersionInformation

        /// <summary>
        /// The OutputVersionInformation method prints version information about the debugger engine to the debugger console.
        /// </summary>
        /// <param name="outputControl">[in] Specifies where to send the output. For possible values, see DEBUG_OUTCTL_XXX.</param>
        /// <remarks>
        /// The information that is sent to the output can include the mode of the debugger, the path and version of the debugger
        /// DLLs, the extension DLL search path, the extension DLL chain, and the version of the operating system that is running
        /// on the host computer. For more information, see Target Information.
        /// </remarks>
        public void OutputVersionInformation(DEBUG_OUTCTL outputControl)
        {
            TryOutputVersionInformation(outputControl).ThrowDbgEngNotOK();
        }

        /// <summary>
        /// The OutputVersionInformation method prints version information about the debugger engine to the debugger console.
        /// </summary>
        /// <param name="outputControl">[in] Specifies where to send the output. For possible values, see DEBUG_OUTCTL_XXX.</param>
        /// <returns>This method may also return other error values, including error values caused by the engine being busy. See Return Values for more details.</returns>
        /// <remarks>
        /// The information that is sent to the output can include the mode of the debugger, the path and version of the debugger
        /// DLLs, the extension DLL search path, the extension DLL chain, and the version of the operating system that is running
        /// on the host computer. For more information, see Target Information.
        /// </remarks>
        public HRESULT TryOutputVersionInformation(DEBUG_OUTCTL outputControl)
        {
            /*HRESULT OutputVersionInformation(
            [In] DEBUG_OUTCTL OutputControl);*/
            return Raw.OutputVersionInformation(outputControl);
        }

        #endregion
        #region Assemble

        /// <summary>
        /// The Assemble method assembles a single processor instruction. The assembled instruction is placed in the target's memory.
        /// </summary>
        /// <param name="offset">[in] Specifies the location in the target's memory to place the assembled instruction.</param>
        /// <param name="instr">[in] Specifies the instruction to assemble. The instruction is assembled according to the target's effective processor type (returned by <see cref="EffectiveProcessorType"/>).</param>
        /// <returns>[out] Receives the location in the target's memory immediately following the assembled instruction. EndOffset can be used when assembling multiple instructions.</returns>
        /// <remarks>
        /// The assembly language depends on the effective processor type of the target machine. For information about the
        /// assembly language, see the processor documentation. For an overview of using assembly in debugger applications,
        /// see Debugging in Assembly Mode. For more information about using assembly with the debugger engine API, see Assembling
        /// and Disassembling Instructions.
        /// </remarks>
        public long Assemble(long offset, string instr)
        {
            long endOffset;
            TryAssemble(offset, instr, out endOffset).ThrowDbgEngNotOK();

            return endOffset;
        }

        /// <summary>
        /// The Assemble method assembles a single processor instruction. The assembled instruction is placed in the target's memory.
        /// </summary>
        /// <param name="offset">[in] Specifies the location in the target's memory to place the assembled instruction.</param>
        /// <param name="instr">[in] Specifies the instruction to assemble. The instruction is assembled according to the target's effective processor type (returned by <see cref="EffectiveProcessorType"/>).</param>
        /// <param name="endOffset">[out] Receives the location in the target's memory immediately following the assembled instruction. EndOffset can be used when assembling multiple instructions.</param>
        /// <returns>This method can also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// The assembly language depends on the effective processor type of the target machine. For information about the
        /// assembly language, see the processor documentation. For an overview of using assembly in debugger applications,
        /// see Debugging in Assembly Mode. For more information about using assembly with the debugger engine API, see Assembling
        /// and Disassembling Instructions.
        /// </remarks>
        public HRESULT TryAssemble(long offset, string instr, out long endOffset)
        {
            /*HRESULT Assemble(
            [In] long Offset,
            [In, MarshalAs(UnmanagedType.LPStr)] string Instr,
            [Out] out long EndOffset);*/
            return Raw.Assemble(offset, instr, out endOffset);
        }

        #endregion
        #region Disassemble

        /// <summary>
        /// The Disassemble method disassembles a processor instruction in the target's memory.
        /// </summary>
        /// <param name="offset">[in] Specifies the location in the target's memory of the instruction to disassemble.</param>
        /// <param name="flags">[in] Specifies the bit-flags that affect the behavior of this method. Currently the only flag that can be set is DEBUG_DISASM_EFFECTIVE_ADDRESS; when set, the engine will compute the effective address from the current register information and display it.</param>
        /// <returns>The values that were emitted from the COM method.</returns>
        /// <remarks>
        /// The assembly language depends on the effective processor type of the target system. For information about the assembly
        /// language, see the processor documentation. The disassembly options--returned by <see cref="AssemblyOptions"/>--affect
        /// the operation of this method. For an overview of using assembly in debugger applications, see Debugging in Assembly
        /// Mode. For more information about using assembly with the debugger engine API, see Assembling and Disassembling
        /// Instructions.
        /// </remarks>
        public DisassembleResult Disassemble(long offset, DEBUG_DISASM flags)
        {
            DisassembleResult result;
            TryDisassemble(offset, flags, out result).ThrowDbgEngNotOK();

            return result;
        }

        /// <summary>
        /// The Disassemble method disassembles a processor instruction in the target's memory.
        /// </summary>
        /// <param name="offset">[in] Specifies the location in the target's memory of the instruction to disassemble.</param>
        /// <param name="flags">[in] Specifies the bit-flags that affect the behavior of this method. Currently the only flag that can be set is DEBUG_DISASM_EFFECTIVE_ADDRESS; when set, the engine will compute the effective address from the current register information and display it.</param>
        /// <param name="result">The values that were emitted from the COM method.</param>
        /// <returns>This method can also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// The assembly language depends on the effective processor type of the target system. For information about the assembly
        /// language, see the processor documentation. The disassembly options--returned by <see cref="AssemblyOptions"/>--affect
        /// the operation of this method. For an overview of using assembly in debugger applications, see Debugging in Assembly
        /// Mode. For more information about using assembly with the debugger engine API, see Assembling and Disassembling
        /// Instructions.
        /// </remarks>
        public HRESULT TryDisassemble(long offset, DEBUG_DISASM flags, out DisassembleResult result)
        {
            /*HRESULT Disassemble(
            [In] long Offset,
            [In] DEBUG_DISASM Flags,
            [SRI.Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U1, SizeParamIndex = 3)] byte[] Buffer,
            [In] int BufferSize,
            [Out] out int DisassemblySize,
            [Out] out long EndOffset);*/
            byte[] buffer;
            int bufferSize = 0;
            int disassemblySize;
            long endOffset;
            HRESULT hr = Raw.Disassemble(offset, flags, null, bufferSize, out disassemblySize, out endOffset);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER && hr != HRESULT.S_OK)
                goto fail;

            bufferSize = disassemblySize;
            buffer = new byte[bufferSize];
            hr = Raw.Disassemble(offset, flags, buffer, bufferSize, out disassemblySize, out endOffset);

            if (hr == HRESULT.S_OK)
            {
                result = new DisassembleResult(CreateString(buffer, disassemblySize), endOffset);

                return hr;
            }

            fail:
            result = default(DisassembleResult);

            return hr;
        }

        #endregion
        #region OutputDisassembly

        /// <summary>
        /// The OutputDisassembly method disassembles a processor instruction and sends the disassembly to the output callbacks.
        /// </summary>
        /// <param name="outputControl">[in] Specifies the output control that determines which client's output callbacks receive the output. For possible values, see DEBUG_OUTCTL_XXX.<para/>
        /// For more information about output, see Input and Output.</param>
        /// <param name="offset">[in] Specifies the location in the target's memory of the instruction to disassemble.</param>
        /// <param name="flags">[in] Specifies the bit-flags that affect the behavior of this method. The following table lists the bits that can be set.</param>
        /// <returns>[out] Receives the location in the target's memory of the instruction that follows the disassembled instruction.</returns>
        /// <remarks>
        /// The assembly language depends on the effective processor type of the target system. For information about the assembly
        /// language, see the processor documentation. For an overview of using assembly in debugger applications, see Debugging
        /// in Assembly Mode. For more information about using assembly with the debugger engine API, see Assembling and Disassembling
        /// Instructions.
        /// </remarks>
        public long OutputDisassembly(DEBUG_OUTCTL outputControl, long offset, DEBUG_DISASM flags)
        {
            long endOffset;
            TryOutputDisassembly(outputControl, offset, flags, out endOffset).ThrowDbgEngNotOK();

            return endOffset;
        }

        /// <summary>
        /// The OutputDisassembly method disassembles a processor instruction and sends the disassembly to the output callbacks.
        /// </summary>
        /// <param name="outputControl">[in] Specifies the output control that determines which client's output callbacks receive the output. For possible values, see DEBUG_OUTCTL_XXX.<para/>
        /// For more information about output, see Input and Output.</param>
        /// <param name="offset">[in] Specifies the location in the target's memory of the instruction to disassemble.</param>
        /// <param name="flags">[in] Specifies the bit-flags that affect the behavior of this method. The following table lists the bits that can be set.</param>
        /// <param name="endOffset">[out] Receives the location in the target's memory of the instruction that follows the disassembled instruction.</param>
        /// <returns>This method can also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// The assembly language depends on the effective processor type of the target system. For information about the assembly
        /// language, see the processor documentation. For an overview of using assembly in debugger applications, see Debugging
        /// in Assembly Mode. For more information about using assembly with the debugger engine API, see Assembling and Disassembling
        /// Instructions.
        /// </remarks>
        public HRESULT TryOutputDisassembly(DEBUG_OUTCTL outputControl, long offset, DEBUG_DISASM flags, out long endOffset)
        {
            /*HRESULT OutputDisassembly(
            [In] DEBUG_OUTCTL OutputControl,
            [In] long Offset,
            [In] DEBUG_DISASM Flags,
            [Out] out long EndOffset);*/
            return Raw.OutputDisassembly(outputControl, offset, flags, out endOffset);
        }

        #endregion
        #region OutputDisassemblyLines

        /// <summary>
        /// The OutputDisassemblyLines method disassembles several processor instructions and sends the resulting assembly instructions to the output callbacks.
        /// </summary>
        /// <param name="outputControl">[in] Specifies the output control that determines which client's output callbacks receive the output. For possible values, see DEBUG_OUTCTL_XXX.<para/>
        /// For more information about output, see Input and Output.</param>
        /// <param name="previousLines">[in] Specifies the number of lines of instructions before the instruction at Offset to include in the output. Typically, each instruction is output on a single line.<para/>
        /// However, some instructions can take up several lines of output; this can cause the number of lines output before the instruction at Offset to be greater than PreviousLines.</param>
        /// <param name="totalLines">[in] Specifies the total number of lines of instructions to include in the output. Typically, each instruction is output on a single line.<para/>
        /// However, some instructions can take up several lines of output; this can cause the number of lines output to be greater than TotalLines.</param>
        /// <param name="offset">[in] Specifies the location in the target's memory of the instructions to disassemble. The disassembly output will start PreviousLines lines before these processor instructions.</param>
        /// <param name="flags">[in] Specifies the bit-flags that affect the behavior of this method. The following table lists the bits that can be set.</param>
        /// <returns>The values that were emitted from the COM method.</returns>
        /// <remarks>
        /// The assembly language depends on the effective processor type of the target system. For information about the assembly
        /// language, see the processor documentation. For an overview of using assembly in debugger applications, see Debugging
        /// in Assembly Mode. For more information about using assembly with the debugger engine API, see Assembling and Disassembling
        /// Instructions.
        /// </remarks>
        public OutputDisassemblyLinesResult OutputDisassemblyLines(DEBUG_OUTCTL outputControl, int previousLines, int totalLines, long offset, DEBUG_DISASM flags)
        {
            OutputDisassemblyLinesResult result;
            TryOutputDisassemblyLines(outputControl, previousLines, totalLines, offset, flags, out result).ThrowDbgEngNotOK();

            return result;
        }

        /// <summary>
        /// The OutputDisassemblyLines method disassembles several processor instructions and sends the resulting assembly instructions to the output callbacks.
        /// </summary>
        /// <param name="outputControl">[in] Specifies the output control that determines which client's output callbacks receive the output. For possible values, see DEBUG_OUTCTL_XXX.<para/>
        /// For more information about output, see Input and Output.</param>
        /// <param name="previousLines">[in] Specifies the number of lines of instructions before the instruction at Offset to include in the output. Typically, each instruction is output on a single line.<para/>
        /// However, some instructions can take up several lines of output; this can cause the number of lines output before the instruction at Offset to be greater than PreviousLines.</param>
        /// <param name="totalLines">[in] Specifies the total number of lines of instructions to include in the output. Typically, each instruction is output on a single line.<para/>
        /// However, some instructions can take up several lines of output; this can cause the number of lines output to be greater than TotalLines.</param>
        /// <param name="offset">[in] Specifies the location in the target's memory of the instructions to disassemble. The disassembly output will start PreviousLines lines before these processor instructions.</param>
        /// <param name="flags">[in] Specifies the bit-flags that affect the behavior of this method. The following table lists the bits that can be set.</param>
        /// <param name="result">The values that were emitted from the COM method.</param>
        /// <returns>This method can also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// The assembly language depends on the effective processor type of the target system. For information about the assembly
        /// language, see the processor documentation. For an overview of using assembly in debugger applications, see Debugging
        /// in Assembly Mode. For more information about using assembly with the debugger engine API, see Assembling and Disassembling
        /// Instructions.
        /// </remarks>
        public HRESULT TryOutputDisassemblyLines(DEBUG_OUTCTL outputControl, int previousLines, int totalLines, long offset, DEBUG_DISASM flags, out OutputDisassemblyLinesResult result)
        {
            /*HRESULT OutputDisassemblyLines(
            [In] DEBUG_OUTCTL OutputControl,
            [In] int PreviousLines,
            [In] int TotalLines,
            [In] long Offset,
            [In] DEBUG_DISASM Flags,
            [Out] out int OffsetLine,
            [Out] out long StartOffset,
            [Out] out long EndOffset,
            [SRI.Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] long[] LineOffsets);*/
            int offsetLine;
            long startOffset;
            long endOffset;
            long[] lineOffsets = new long[totalLines];
            HRESULT hr = Raw.OutputDisassemblyLines(outputControl, previousLines, totalLines, offset, flags, out offsetLine, out startOffset, out endOffset, lineOffsets);

            if (hr == HRESULT.S_OK)
                result = new OutputDisassemblyLinesResult(offsetLine, startOffset, endOffset, lineOffsets);
            else
                result = default(OutputDisassemblyLinesResult);

            return hr;
        }

        #endregion
        #region GetNearInstruction

        /// <summary>
        /// The GetNearInstruction method returns the location of a processor instruction relative to a given location.
        /// </summary>
        /// <param name="offset">[in] Specifies the location in the process's virtual address space from which to start looking for the desired instruction.</param>
        /// <param name="delta">[in] Specifies the number of instructions from Offset of the desired instruction. If Delta is negative, the returned offset is before Offset (see the Remarks section for more information).</param>
        /// <returns>[out] Receives the location in the process's virtual address space of the instruction that is Delta instructions away from Offset.</returns>
        /// <remarks>
        /// On some architectures, like x86 and x64, the size of an instruction may vary. On these architectures, when Delta
        /// is negative, the desired instruction location might not be uniquely defined. In this case, the debugger engine
        /// will search backward from Offset until it encounters a location such that there are the Delta number of instructions
        /// between that location and Offset.
        /// </remarks>
        public long GetNearInstruction(long offset, int delta)
        {
            long nearOffset;
            TryGetNearInstruction(offset, delta, out nearOffset).ThrowDbgEngNotOK();

            return nearOffset;
        }

        /// <summary>
        /// The GetNearInstruction method returns the location of a processor instruction relative to a given location.
        /// </summary>
        /// <param name="offset">[in] Specifies the location in the process's virtual address space from which to start looking for the desired instruction.</param>
        /// <param name="delta">[in] Specifies the number of instructions from Offset of the desired instruction. If Delta is negative, the returned offset is before Offset (see the Remarks section for more information).</param>
        /// <param name="nearOffset">[out] Receives the location in the process's virtual address space of the instruction that is Delta instructions away from Offset.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// On some architectures, like x86 and x64, the size of an instruction may vary. On these architectures, when Delta
        /// is negative, the desired instruction location might not be uniquely defined. In this case, the debugger engine
        /// will search backward from Offset until it encounters a location such that there are the Delta number of instructions
        /// between that location and Offset.
        /// </remarks>
        public HRESULT TryGetNearInstruction(long offset, int delta, out long nearOffset)
        {
            /*HRESULT GetNearInstruction(
            [In] long Offset,
            [In] int Delta,
            [Out] out long NearOffset);*/
            return Raw.GetNearInstruction(offset, delta, out nearOffset);
        }

        #endregion
        #region GetStackTrace

        /// <summary>
        /// The GetStackTrace method returns the frames at the top of the specified call stack.
        /// </summary>
        /// <param name="frameOffset">[in] Specifies the location of the stack frame at the top of the stack. If FrameOffset is set to zero, the current frame pointer is used instead.</param>
        /// <param name="stackOffset">[in] Specifies the location of the current stack. If StackOffset is set to zero, the current stack pointer is used instead.</param>
        /// <param name="instructionOffset">[in] Specifies the location of the instruction of interest for the function that is represented by the stack frame at the top of the stack.<para/>
        /// If InstructionOffset is set to zero, the current instruction is used instead.</param>
        /// <param name="frameSize">[in] Specifies the number of items in the Frames array.</param>
        /// <returns>[out] Receives the stack frames. The number of elements this array holds is FrameSize.</returns>
        /// <remarks>
        /// The stack trace returned to Frames can be printed using <see cref="OutputStackTrace"/>.
        /// </remarks>
        public DEBUG_STACK_FRAME[] GetStackTrace(long frameOffset, long stackOffset, long instructionOffset, int frameSize)
        {
            DEBUG_STACK_FRAME[] frames;
            TryGetStackTrace(frameOffset, stackOffset, instructionOffset, frameSize, out frames).ThrowDbgEngNotOK();

            return frames;
        }

        /// <summary>
        /// The GetStackTrace method returns the frames at the top of the specified call stack.
        /// </summary>
        /// <param name="frameOffset">[in] Specifies the location of the stack frame at the top of the stack. If FrameOffset is set to zero, the current frame pointer is used instead.</param>
        /// <param name="stackOffset">[in] Specifies the location of the current stack. If StackOffset is set to zero, the current stack pointer is used instead.</param>
        /// <param name="instructionOffset">[in] Specifies the location of the instruction of interest for the function that is represented by the stack frame at the top of the stack.<para/>
        /// If InstructionOffset is set to zero, the current instruction is used instead.</param>
        /// <param name="frames">[out] Receives the stack frames. The number of elements this array holds is FrameSize.</param>
        /// <param name="frameSize">[in] Specifies the number of items in the Frames array.</param>
        /// <returns>This method may also return other error values. See Return Values for more details.</returns>
        /// <remarks>
        /// The stack trace returned to Frames can be printed using <see cref="OutputStackTrace"/>.
        /// </remarks>
        public HRESULT TryGetStackTrace(long frameOffset, long stackOffset, long instructionOffset, int frameSize, out DEBUG_STACK_FRAME[] frames)
        {
            /*HRESULT GetStackTrace(
            [In] long FrameOffset,
            [In] long StackOffset,
            [In] long InstructionOffset,
            [SRI.Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 4)] DEBUG_STACK_FRAME[] Frames,
            [In] int FrameSize,
            [Out] out int FramesFilled);*/
            frames = new DEBUG_STACK_FRAME[frameSize];
            int framesFilled;
            HRESULT hr = Raw.GetStackTrace(frameOffset, stackOffset, instructionOffset, frames, frameSize, out framesFilled);

            if (frameSize != framesFilled)
                Array.Resize(ref frames, framesFilled);

            return hr;
        }

        #endregion
        #region OutputStackTrace

        /// <summary>
        /// The OutputStackTrace method outputs either the supplied stack frame or the current stack frames.
        /// </summary>
        /// <param name="outputControl">[in] Specifies where to send the output. For possible values, see DEBUG_OUTCTL_XXX.</param>
        /// <param name="frames">[in, optional] Specifies the array of stack frames to output. The number of elements in this array is FramesSize.<para/>
        /// If Frames is NULL, the current stack frames are used.</param>
        /// <param name="framesSize">[in] Specifies the number of frames to output.</param>
        /// <param name="flags">[in] Specifies bit flags that determine what information to output for each frame. Flags can be any combination of values from the following table.</param>
        /// <remarks>
        /// The array of stack frames can be obtained using <see cref="GetStackTrace"/>.
        /// </remarks>
        public void OutputStackTrace(DEBUG_OUTCTL outputControl, DEBUG_STACK_FRAME[] frames, int framesSize, DEBUG_STACK flags)
        {
            TryOutputStackTrace(outputControl, frames, framesSize, flags).ThrowDbgEngNotOK();
        }

        /// <summary>
        /// The OutputStackTrace method outputs either the supplied stack frame or the current stack frames.
        /// </summary>
        /// <param name="outputControl">[in] Specifies where to send the output. For possible values, see DEBUG_OUTCTL_XXX.</param>
        /// <param name="frames">[in, optional] Specifies the array of stack frames to output. The number of elements in this array is FramesSize.<para/>
        /// If Frames is NULL, the current stack frames are used.</param>
        /// <param name="framesSize">[in] Specifies the number of frames to output.</param>
        /// <param name="flags">[in] Specifies bit flags that determine what information to output for each frame. Flags can be any combination of values from the following table.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// The array of stack frames can be obtained using <see cref="GetStackTrace"/>.
        /// </remarks>
        public HRESULT TryOutputStackTrace(DEBUG_OUTCTL outputControl, DEBUG_STACK_FRAME[] frames, int framesSize, DEBUG_STACK flags)
        {
            /*HRESULT OutputStackTrace(
            [In] DEBUG_OUTCTL OutputControl,
            [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] DEBUG_STACK_FRAME[] Frames,
            [In] int FramesSize,
            [In] DEBUG_STACK Flags);*/
            return Raw.OutputStackTrace(outputControl, frames, framesSize, flags);
        }

        #endregion
        #region GetPossibleExecutingProcessorTypes

        /// <summary>
        /// The GetPossibleExecutingProcessorTypes method returns the processor types that are supported by the computer running the current target.
        /// </summary>
        /// <param name="start">[in] Specifies the index of the first processor type to return. The processor types are indexed by numbers zero through to the number of processor types supported by the current target minus one.<para/>
        /// The number of processor types supported by the current target can be found using <see cref="NumberPossibleExecutingProcessorTypes"/>.</param>
        /// <param name="count">[in] Specifies how many processor types to return.</param>
        /// <returns>[out] Receives the list of processor types. The number of elements this array holds is Count. For a description of the processor types see <see cref="ActualProcessorType"/>.</returns>
        /// <remarks>
        /// For more information, see Target Information.
        /// </remarks>
        public IMAGE_FILE_MACHINE[] GetPossibleExecutingProcessorTypes(int start, int count)
        {
            IMAGE_FILE_MACHINE[] types;
            TryGetPossibleExecutingProcessorTypes(start, count, out types).ThrowDbgEngNotOK();

            return types;
        }

        /// <summary>
        /// The GetPossibleExecutingProcessorTypes method returns the processor types that are supported by the computer running the current target.
        /// </summary>
        /// <param name="start">[in] Specifies the index of the first processor type to return. The processor types are indexed by numbers zero through to the number of processor types supported by the current target minus one.<para/>
        /// The number of processor types supported by the current target can be found using <see cref="NumberPossibleExecutingProcessorTypes"/>.</param>
        /// <param name="count">[in] Specifies how many processor types to return.</param>
        /// <param name="types">[out] Receives the list of processor types. The number of elements this array holds is Count. For a description of the processor types see <see cref="ActualProcessorType"/>.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// For more information, see Target Information.
        /// </remarks>
        public HRESULT TryGetPossibleExecutingProcessorTypes(int start, int count, out IMAGE_FILE_MACHINE[] types)
        {
            /*HRESULT GetPossibleExecutingProcessorTypes(
            [In] int Start,
            [In] int Count,
            [SRI.Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] IMAGE_FILE_MACHINE[] Types);*/
            types = new IMAGE_FILE_MACHINE[count];
            HRESULT hr = Raw.GetPossibleExecutingProcessorTypes(start, count, types);

            return hr;
        }

        #endregion
        #region ReadBugCheckData

        /// <summary>
        /// The ReadBugCheckData method reads the kernel bug check code and related parameters.
        /// </summary>
        /// <returns>The values that were emitted from the COM method.</returns>
        /// <remarks>
        /// This method is only available in kernel-mode debugging. For more information about bug checks, including a list
        /// of bug check codes and their interpretations, see Bug Checks (Blue Screens).
        /// </remarks>
        public ReadBugCheckDataResult ReadBugCheckData()
        {
            ReadBugCheckDataResult result;
            TryReadBugCheckData(out result).ThrowDbgEngNotOK();

            return result;
        }

        /// <summary>
        /// The ReadBugCheckData method reads the kernel bug check code and related parameters.
        /// </summary>
        /// <param name="result">The values that were emitted from the COM method.</param>
        /// <returns>This method can also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// This method is only available in kernel-mode debugging. For more information about bug checks, including a list
        /// of bug check codes and their interpretations, see Bug Checks (Blue Screens).
        /// </remarks>
        public HRESULT TryReadBugCheckData(out ReadBugCheckDataResult result)
        {
            /*HRESULT ReadBugCheckData(
            [Out] out int Code,
            [Out] out long Arg1,
            [Out] out long Arg2,
            [Out] out long Arg3,
            [Out] out long Arg4);*/
            int code;
            long arg1;
            long arg2;
            long arg3;
            long arg4;
            HRESULT hr = Raw.ReadBugCheckData(out code, out arg1, out arg2, out arg3, out arg4);

            if (hr == HRESULT.S_OK)
                result = new ReadBugCheckDataResult(code, arg1, arg2, arg3, arg4);
            else
                result = default(ReadBugCheckDataResult);

            return hr;
        }

        #endregion
        #region GetSupportedProcessorTypes

        /// <summary>
        /// The GetSupportedProcessorTypes method returns the processor types supported by the debugger engine.
        /// </summary>
        /// <param name="start">[in] Specifies the index of the first processor type to return. The supported processor types are indexed by the numbers zero through the number of supported processor types minus one.<para/>
        /// The number of supported processor types can be found using <see cref="NumberSupportedProcessorTypes"/>.</param>
        /// <param name="count">[in] Specifies the number of processor types to return.</param>
        /// <returns>[out] Receives the list of processor types. The number of elements this array holds is Count. For a description of the processor types, see <see cref="ActualProcessorType"/>.</returns>
        /// <remarks>
        /// For more information, see Target Information.
        /// </remarks>
        public IMAGE_FILE_MACHINE[] GetSupportedProcessorTypes(int start, int count)
        {
            IMAGE_FILE_MACHINE[] types;
            TryGetSupportedProcessorTypes(start, count, out types).ThrowDbgEngNotOK();

            return types;
        }

        /// <summary>
        /// The GetSupportedProcessorTypes method returns the processor types supported by the debugger engine.
        /// </summary>
        /// <param name="start">[in] Specifies the index of the first processor type to return. The supported processor types are indexed by the numbers zero through the number of supported processor types minus one.<para/>
        /// The number of supported processor types can be found using <see cref="NumberSupportedProcessorTypes"/>.</param>
        /// <param name="count">[in] Specifies the number of processor types to return.</param>
        /// <param name="types">[out] Receives the list of processor types. The number of elements this array holds is Count. For a description of the processor types, see <see cref="ActualProcessorType"/>.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// For more information, see Target Information.
        /// </remarks>
        public HRESULT TryGetSupportedProcessorTypes(int start, int count, out IMAGE_FILE_MACHINE[] types)
        {
            /*HRESULT GetSupportedProcessorTypes(
            [In] int Start,
            [In] int Count,
            [SRI.Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] IMAGE_FILE_MACHINE[] Types);*/
            types = new IMAGE_FILE_MACHINE[count];
            HRESULT hr = Raw.GetSupportedProcessorTypes(start, count, types);

            return hr;
        }

        #endregion
        #region GetProcessorTypeNames

        /// <summary>
        /// The GetProcessorTypeNames method returns the full name and abbreviated name of the specified processor type.
        /// </summary>
        /// <param name="type">[in] Specifies the type of the processor whose name is requested. See <see cref="ActualProcessorType"/> for a list of possible values.</param>
        /// <returns>The values that were emitted from the COM method.</returns>
        /// <remarks>
        /// For more information, see Target Information.
        /// </remarks>
        public GetProcessorTypeNamesResult GetProcessorTypeNames(IMAGE_FILE_MACHINE type)
        {
            GetProcessorTypeNamesResult result;
            TryGetProcessorTypeNames(type, out result).ThrowDbgEngNotOK();

            return result;
        }

        /// <summary>
        /// The GetProcessorTypeNames method returns the full name and abbreviated name of the specified processor type.
        /// </summary>
        /// <param name="type">[in] Specifies the type of the processor whose name is requested. See <see cref="ActualProcessorType"/> for a list of possible values.</param>
        /// <param name="result">The values that were emitted from the COM method.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// For more information, see Target Information.
        /// </remarks>
        public HRESULT TryGetProcessorTypeNames(IMAGE_FILE_MACHINE type, out GetProcessorTypeNamesResult result)
        {
            /*HRESULT GetProcessorTypeNames(
            [In] IMAGE_FILE_MACHINE Type,
            [SRI.Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U1, SizeParamIndex = 2)] byte[] FullNameBuffer,
            [In] int FullNameBufferSize,
            [Out] out int FullNameSize,
            [SRI.Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U1, SizeParamIndex = 5)] byte[] AbbrevNameBuffer,
            [In] int AbbrevNameBufferSize,
            [Out] out int AbbrevNameSize);*/
            byte[] fullNameBuffer;
            int fullNameBufferSize = 0;
            int fullNameSize;
            byte[] abbrevNameBuffer;
            int abbrevNameBufferSize = 0;
            int abbrevNameSize;
            HRESULT hr = Raw.GetProcessorTypeNames(type, null, fullNameBufferSize, out fullNameSize, null, abbrevNameBufferSize, out abbrevNameSize);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER && hr != HRESULT.S_OK)
                goto fail;

            fullNameBufferSize = fullNameSize;
            fullNameBuffer = new byte[fullNameBufferSize];
            abbrevNameBufferSize = abbrevNameSize;
            abbrevNameBuffer = new byte[abbrevNameBufferSize];
            hr = Raw.GetProcessorTypeNames(type, fullNameBuffer, fullNameBufferSize, out fullNameSize, abbrevNameBuffer, abbrevNameBufferSize, out abbrevNameSize);

            if (hr == HRESULT.S_OK)
            {
                result = new GetProcessorTypeNamesResult(CreateString(fullNameBuffer, fullNameSize), CreateString(abbrevNameBuffer, abbrevNameSize));

                return hr;
            }

            fail:
            result = default(GetProcessorTypeNamesResult);

            return hr;
        }

        #endregion
        #region AddEngineOptions

        /// <summary>
        /// The AddEngineOptions method turns on some of the debugger engine's options.
        /// </summary>
        /// <param name="options">[in] Specifies engine options to turn on. Options is a bit-set that will be combined with the existing engine options using the bitwise-OR operator.<para/>
        /// For a description of the engine options, see DEBUG_ENGOPT_XXX.</param>
        /// <remarks>
        /// After the engine options have been changed, the engine sends out notification to each client's event callback object
        /// by passing the DEBUG_CES_ENGINE_OPTIONS flag to the <see cref="IDebugEventCallbacks.ChangeEngineState"/> method.
        /// </remarks>
        public void AddEngineOptions(DEBUG_ENGOPT options)
        {
            TryAddEngineOptions(options).ThrowDbgEngNotOK();
        }

        /// <summary>
        /// The AddEngineOptions method turns on some of the debugger engine's options.
        /// </summary>
        /// <param name="options">[in] Specifies engine options to turn on. Options is a bit-set that will be combined with the existing engine options using the bitwise-OR operator.<para/>
        /// For a description of the engine options, see DEBUG_ENGOPT_XXX.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// After the engine options have been changed, the engine sends out notification to each client's event callback object
        /// by passing the DEBUG_CES_ENGINE_OPTIONS flag to the <see cref="IDebugEventCallbacks.ChangeEngineState"/> method.
        /// </remarks>
        public HRESULT TryAddEngineOptions(DEBUG_ENGOPT options)
        {
            /*HRESULT AddEngineOptions(
            [In] DEBUG_ENGOPT Options);*/
            return Raw.AddEngineOptions(options);
        }

        #endregion
        #region RemoveEngineOptions

        /// <summary>
        /// The RemoveEngineOptions method turns off some of the engine's options.
        /// </summary>
        /// <param name="options">[in] Specifies the engine options to turn off. Options is a bit-set; the new value of the engine's options will equal the bitwise-NOT of Options combined with old value using the bitwise-AND operator (new_value := old_value AND NOT Options).<para/>
        /// For a description of the engine options, see DEBUG_ENGOPT_XXX.</param>
        /// <remarks>
        /// After the engine options have been changed, the engine sends out notification to each client's event callback object
        /// by passing the DEBUG_CES_ENGINE_OPTIONS flag to the <see cref="IDebugEventCallbacks.ChangeEngineState"/> method.
        /// </remarks>
        public void RemoveEngineOptions(DEBUG_ENGOPT options)
        {
            TryRemoveEngineOptions(options).ThrowDbgEngNotOK();
        }

        /// <summary>
        /// The RemoveEngineOptions method turns off some of the engine's options.
        /// </summary>
        /// <param name="options">[in] Specifies the engine options to turn off. Options is a bit-set; the new value of the engine's options will equal the bitwise-NOT of Options combined with old value using the bitwise-AND operator (new_value := old_value AND NOT Options).<para/>
        /// For a description of the engine options, see DEBUG_ENGOPT_XXX.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// After the engine options have been changed, the engine sends out notification to each client's event callback object
        /// by passing the DEBUG_CES_ENGINE_OPTIONS flag to the <see cref="IDebugEventCallbacks.ChangeEngineState"/> method.
        /// </remarks>
        public HRESULT TryRemoveEngineOptions(DEBUG_ENGOPT options)
        {
            /*HRESULT RemoveEngineOptions(
            [In] DEBUG_ENGOPT Options);*/
            return Raw.RemoveEngineOptions(options);
        }

        #endregion
        #region SetSystemErrorControl

        /// <summary>
        /// The SetSystemErrorControl method sets the control values for handling system errors.
        /// </summary>
        /// <param name="outputLevel">[in] Specifies the level at which system errors are printed to the engine's output. If the level of the system error is less than or equal to OutputLevel, the error is printed to the debugger console.</param>
        /// <param name="breakLevel">[in] Specifies the level at which system errors break into the debugger. If the level of the system error is less than or equal to BreakLevel, the error breaks into the debugger.</param>
        /// <remarks>
        /// The level of a system error can take one of the following three values, listed from lowest to highest: SLE_ERROR,
        /// SLE_MINORERROR, and SLE_WARNING. These values are defined in Winuser.h. When a system error occurs, the engine
        /// calls the <see cref="IDebugEventCallbacks.SystemError"/> method of the event callbacks. If the level is less than
        /// or equal to the BreakLevel parameter, the error will break into the debugger. If the level is greater than BreakLevel,
        /// the engine will proceed with execution in the target as indicated by the IDebugEventCallbacks::SystemError method
        /// calls. For more information about how the engine proceeds after an event, see Monitoring Events.
        /// </remarks>
        public void SetSystemErrorControl(ERROR_LEVEL outputLevel, ERROR_LEVEL breakLevel)
        {
            TrySetSystemErrorControl(outputLevel, breakLevel).ThrowDbgEngNotOK();
        }

        /// <summary>
        /// The SetSystemErrorControl method sets the control values for handling system errors.
        /// </summary>
        /// <param name="outputLevel">[in] Specifies the level at which system errors are printed to the engine's output. If the level of the system error is less than or equal to OutputLevel, the error is printed to the debugger console.</param>
        /// <param name="breakLevel">[in] Specifies the level at which system errors break into the debugger. If the level of the system error is less than or equal to BreakLevel, the error breaks into the debugger.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// The level of a system error can take one of the following three values, listed from lowest to highest: SLE_ERROR,
        /// SLE_MINORERROR, and SLE_WARNING. These values are defined in Winuser.h. When a system error occurs, the engine
        /// calls the <see cref="IDebugEventCallbacks.SystemError"/> method of the event callbacks. If the level is less than
        /// or equal to the BreakLevel parameter, the error will break into the debugger. If the level is greater than BreakLevel,
        /// the engine will proceed with execution in the target as indicated by the IDebugEventCallbacks::SystemError method
        /// calls. For more information about how the engine proceeds after an event, see Monitoring Events.
        /// </remarks>
        public HRESULT TrySetSystemErrorControl(ERROR_LEVEL outputLevel, ERROR_LEVEL breakLevel)
        {
            /*HRESULT SetSystemErrorControl(
            [In] ERROR_LEVEL OutputLevel,
            [In] ERROR_LEVEL BreakLevel);*/
            return Raw.SetSystemErrorControl(outputLevel, breakLevel);
        }

        #endregion
        #region GetTextMacro

        /// <summary>
        /// The GetTextMacro method returns the value of a fixed-name alias.
        /// </summary>
        /// <param name="slot">[in] Specifies the number of the fixed-name alias. Slot can take the values 0, 1, ..., 9, that represent the fixed-name aliases $u0, $u1, ..., $u9.</param>
        /// <returns>[out, optional] Receives the value of the alias specified by Slot. If Buffer is NULL, this information is not returned.</returns>
        /// <remarks>
        /// Before executing commands or evaluating expressions, the debugger engine will replace the alias specified by Slot
        /// with the value of the alias (returned to the Buffer buffer). For an overview of aliases used by the debugger engine,
        /// see Using Aliases. For more information about using aliases with the debugger engine API, see Interacting with
        /// the Engine.
        /// </remarks>
        public string GetTextMacro(int slot)
        {
            string bufferResult;
            TryGetTextMacro(slot, out bufferResult).ThrowDbgEngNotOK();

            return bufferResult;
        }

        /// <summary>
        /// The GetTextMacro method returns the value of a fixed-name alias.
        /// </summary>
        /// <param name="slot">[in] Specifies the number of the fixed-name alias. Slot can take the values 0, 1, ..., 9, that represent the fixed-name aliases $u0, $u1, ..., $u9.</param>
        /// <param name="bufferResult">[out, optional] Receives the value of the alias specified by Slot. If Buffer is NULL, this information is not returned.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// Before executing commands or evaluating expressions, the debugger engine will replace the alias specified by Slot
        /// with the value of the alias (returned to the Buffer buffer). For an overview of aliases used by the debugger engine,
        /// see Using Aliases. For more information about using aliases with the debugger engine API, see Interacting with
        /// the Engine.
        /// </remarks>
        public HRESULT TryGetTextMacro(int slot, out string bufferResult)
        {
            /*HRESULT GetTextMacro(
            [In] int Slot,
            [SRI.Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U1, SizeParamIndex = 2)] byte[] Buffer,
            [In] int BufferSize,
            [Out] out int MacroSize);*/
            byte[] buffer;
            int bufferSize = 0;
            int macroSize;
            HRESULT hr = Raw.GetTextMacro(slot, null, bufferSize, out macroSize);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER && hr != HRESULT.S_OK)
                goto fail;

            bufferSize = macroSize;
            buffer = new byte[bufferSize];
            hr = Raw.GetTextMacro(slot, buffer, bufferSize, out macroSize);

            if (hr == HRESULT.S_OK)
            {
                bufferResult = CreateString(buffer, macroSize);

                return hr;
            }

            fail:
            bufferResult = default(string);

            return hr;
        }

        #endregion
        #region SetTextMacro

        /// <summary>
        /// The SetTextMacro method sets the value of a fixed-name alias.
        /// </summary>
        /// <param name="slot">[in] Specifies the number of the fixed-name alias. Slot can take the values 0, 1, ..., 9, that represent the fixed-name aliases $u0, $u1, ..., $u9.</param>
        /// <param name="macro">[in] Specifies the new value of the alias specified by Slot. The debugger engine makes a copy of this string.</param>
        /// <remarks>
        /// Before executing commands or evaluating expressions, the debugger engine will replace the alias specified by Slot
        /// with the value of the alias (specified by Macro). For an overview of aliases used by the debugger engine, see Using
        /// Aliases. For more information about using aliases with the debugger engine API, see Interacting with the Engine.
        /// </remarks>
        public void SetTextMacro(int slot, string macro)
        {
            TrySetTextMacro(slot, macro).ThrowDbgEngNotOK();
        }

        /// <summary>
        /// The SetTextMacro method sets the value of a fixed-name alias.
        /// </summary>
        /// <param name="slot">[in] Specifies the number of the fixed-name alias. Slot can take the values 0, 1, ..., 9, that represent the fixed-name aliases $u0, $u1, ..., $u9.</param>
        /// <param name="macro">[in] Specifies the new value of the alias specified by Slot. The debugger engine makes a copy of this string.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// Before executing commands or evaluating expressions, the debugger engine will replace the alias specified by Slot
        /// with the value of the alias (specified by Macro). For an overview of aliases used by the debugger engine, see Using
        /// Aliases. For more information about using aliases with the debugger engine API, see Interacting with the Engine.
        /// </remarks>
        public HRESULT TrySetTextMacro(int slot, string macro)
        {
            /*HRESULT SetTextMacro(
            [In] int Slot,
            [In, MarshalAs(UnmanagedType.LPStr)] string Macro);*/
            return Raw.SetTextMacro(slot, macro);
        }

        #endregion
        #region Evaluate

        /// <summary>
        /// The Evaluate method evaluates an expression, returning the result.
        /// </summary>
        /// <param name="expression">[in] Specifies the expression to be evaluated.</param>
        /// <param name="desiredType">[in] Specifies the desired return type. Possible values are described in <see cref="DEBUG_VALUE"/>; with the addition of DEBUG_VALUE_INVALID, which indicates that the return type should be the expression's natural type.</param>
        /// <returns>The values that were emitted from the COM method.</returns>
        /// <remarks>
        /// Expressions are evaluated by the current expression evaluator. The engine contains multiple expression evaluators;
        /// each supports a different syntax. The current expression evaluator can be chosen by using <see cref="ExpressionSyntax"/>.
        /// For details of the available expression evaluators and their syntaxes, see Numerical Expression Syntax. If an error
        /// occurs while evaluating the expression, returning E_FAIL, the RemainderIndex variable can be used to determine
        /// approximately where in the expression the error occurred.
        /// </remarks>
        public EvaluateResult Evaluate(string expression, DEBUG_VALUE_TYPE desiredType)
        {
            EvaluateResult result;
            TryEvaluate(expression, desiredType, out result).ThrowDbgEngNotOK();

            return result;
        }

        /// <summary>
        /// The Evaluate method evaluates an expression, returning the result.
        /// </summary>
        /// <param name="expression">[in] Specifies the expression to be evaluated.</param>
        /// <param name="desiredType">[in] Specifies the desired return type. Possible values are described in <see cref="DEBUG_VALUE"/>; with the addition of DEBUG_VALUE_INVALID, which indicates that the return type should be the expression's natural type.</param>
        /// <param name="result">The values that were emitted from the COM method.</param>
        /// <returns>This method may also return other error values. See Return Values for more details.</returns>
        /// <remarks>
        /// Expressions are evaluated by the current expression evaluator. The engine contains multiple expression evaluators;
        /// each supports a different syntax. The current expression evaluator can be chosen by using <see cref="ExpressionSyntax"/>.
        /// For details of the available expression evaluators and their syntaxes, see Numerical Expression Syntax. If an error
        /// occurs while evaluating the expression, returning E_FAIL, the RemainderIndex variable can be used to determine
        /// approximately where in the expression the error occurred.
        /// </remarks>
        public HRESULT TryEvaluate(string expression, DEBUG_VALUE_TYPE desiredType, out EvaluateResult result)
        {
            /*HRESULT Evaluate(
            [In, MarshalAs(UnmanagedType.LPStr)] string Expression,
            [In] DEBUG_VALUE_TYPE DesiredType,
            [Out] out DEBUG_VALUE Value,
            [Out] out int RemainderIndex);*/
            DEBUG_VALUE value;
            int remainderIndex;
            HRESULT hr = Raw.Evaluate(expression, desiredType, out value, out remainderIndex);

            if (hr == HRESULT.S_OK)
                result = new EvaluateResult(value, remainderIndex);
            else
                result = default(EvaluateResult);

            return hr;
        }

        #endregion
        #region CoerceValue

        /// <summary>
        /// The CoerceValue method converts a value of one type into a value of another type.
        /// </summary>
        /// <param name="in">[in] Specifies the value to be converted</param>
        /// <param name="outType">[in] Specifies the desired type for the converted value. See <see cref="DEBUG_VALUE"/> for possible values.</param>
        /// <returns>[out] Receives the converted value. The type of this value will be the type specified by OutType.</returns>
        /// <remarks>
        /// This method converts a value of one type into a value of another type. If the specified OutType is not capable
        /// of containing the information supplied by the In variable, data will be lost.
        /// </remarks>
        public DEBUG_VALUE CoerceValue(DEBUG_VALUE @in, DEBUG_VALUE_TYPE outType)
        {
            DEBUG_VALUE @out;
            TryCoerceValue(@in, outType, out @out).ThrowDbgEngNotOK();

            return @out;
        }

        /// <summary>
        /// The CoerceValue method converts a value of one type into a value of another type.
        /// </summary>
        /// <param name="in">[in] Specifies the value to be converted</param>
        /// <param name="outType">[in] Specifies the desired type for the converted value. See <see cref="DEBUG_VALUE"/> for possible values.</param>
        /// <param name="out">[out] Receives the converted value. The type of this value will be the type specified by OutType.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// This method converts a value of one type into a value of another type. If the specified OutType is not capable
        /// of containing the information supplied by the In variable, data will be lost.
        /// </remarks>
        public HRESULT TryCoerceValue(DEBUG_VALUE @in, DEBUG_VALUE_TYPE outType, out DEBUG_VALUE @out)
        {
            /*HRESULT CoerceValue(
            [In] ref DEBUG_VALUE In,
            [In] DEBUG_VALUE_TYPE OutType,
            [Out] out DEBUG_VALUE Out);*/
            return Raw.CoerceValue(ref @in, outType, out @out);
        }

        #endregion
        #region CoerceValues

        /// <summary>
        /// The CoerceValues method converts an array of values into an array of values of different types.
        /// </summary>
        /// <param name="count">[in] Specifies the number of values to convert.</param>
        /// <param name="in">[in] Specifies the array of values to convert. The number of elements that this array holds is Count.</param>
        /// <param name="outType">[in] Specifies the array of desired types for the converted values. For possible values, see <see cref="DEBUG_VALUE"/>.<para/>
        /// The number of elements that this array holds is Count.</param>
        /// <returns>[out] Specifies the array to be populated by the converted values. The types of these values are specified by OutType.<para/>
        /// The number of elements that this array holds is Count.</returns>
        /// <remarks>
        /// This method converts an array of values of one type into values of another type. Some of these conversions can
        /// result in loss of precision.
        /// </remarks>
        public DEBUG_VALUE[] CoerceValues(int count, DEBUG_VALUE[] @in, DEBUG_VALUE_TYPE[] outType)
        {
            DEBUG_VALUE[] @out;
            TryCoerceValues(count, @in, outType, out @out).ThrowDbgEngNotOK();

            return @out;
        }

        /// <summary>
        /// The CoerceValues method converts an array of values into an array of values of different types.
        /// </summary>
        /// <param name="count">[in] Specifies the number of values to convert.</param>
        /// <param name="in">[in] Specifies the array of values to convert. The number of elements that this array holds is Count.</param>
        /// <param name="outType">[in] Specifies the array of desired types for the converted values. For possible values, see <see cref="DEBUG_VALUE"/>.<para/>
        /// The number of elements that this array holds is Count.</param>
        /// <param name="out">[out] Specifies the array to be populated by the converted values. The types of these values are specified by OutType.<para/>
        /// The number of elements that this array holds is Count.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// This method converts an array of values of one type into values of another type. Some of these conversions can
        /// result in loss of precision.
        /// </remarks>
        public HRESULT TryCoerceValues(int count, DEBUG_VALUE[] @in, DEBUG_VALUE_TYPE[] outType, out DEBUG_VALUE[] @out)
        {
            /*HRESULT CoerceValues(
            [In] int Count,
            [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] DEBUG_VALUE[] In,
            [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] DEBUG_VALUE_TYPE[] OutType,
            [SRI.Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] DEBUG_VALUE[] Out);*/
            @out = new DEBUG_VALUE[count];
            HRESULT hr = Raw.CoerceValues(count, @in, outType, @out);

            return hr;
        }

        #endregion
        #region Execute

        /// <summary>
        /// The Execute method executes the specified debugger commands.
        /// </summary>
        /// <param name="outputControl">[in] Specifies the output control to use while executing the command. For possible values, see DEBUG_OUTCTL_XXX.<para/>
        /// For more information about output, see Input and Output.</param>
        /// <param name="command">[in] Specifies the command string to execute. The command is interpreted like those typed into a debugger command window.<para/>
        /// This command string can contain multiple commands for the engine to execute. See Debugger Commands for the command reference.</param>
        /// <param name="flags">[in] Specifies a bit field of execution options for the command. The default options are to log the command but to not send it to the output.<para/>
        /// The following table lists the bits that can be set.</param>
        /// <remarks>
        /// This method executes the given command string. If the string has multiple commands, this method will not return
        /// until all of the commands have been executed. If the sequence of commands involves waiting for the target to execute,
        /// this method can take an arbitrary amount of time to complete.
        /// </remarks>
        public void Execute(DEBUG_OUTCTL outputControl, string command, DEBUG_EXECUTE flags)
        {
            TryExecute(outputControl, command, flags).ThrowDbgEngNotOK();
        }

        /// <summary>
        /// The Execute method executes the specified debugger commands.
        /// </summary>
        /// <param name="outputControl">[in] Specifies the output control to use while executing the command. For possible values, see DEBUG_OUTCTL_XXX.<para/>
        /// For more information about output, see Input and Output.</param>
        /// <param name="command">[in] Specifies the command string to execute. The command is interpreted like those typed into a debugger command window.<para/>
        /// This command string can contain multiple commands for the engine to execute. See Debugger Commands for the command reference.</param>
        /// <param name="flags">[in] Specifies a bit field of execution options for the command. The default options are to log the command but to not send it to the output.<para/>
        /// The following table lists the bits that can be set.</param>
        /// <returns>This method can also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// This method executes the given command string. If the string has multiple commands, this method will not return
        /// until all of the commands have been executed. If the sequence of commands involves waiting for the target to execute,
        /// this method can take an arbitrary amount of time to complete.
        /// </remarks>
        public HRESULT TryExecute(DEBUG_OUTCTL outputControl, string command, DEBUG_EXECUTE flags)
        {
            /*HRESULT Execute(
            [In] DEBUG_OUTCTL OutputControl,
            [In, MarshalAs(UnmanagedType.LPStr)] string Command,
            [In] DEBUG_EXECUTE Flags);*/
            return Raw.Execute(outputControl, command, flags);
        }

        #endregion
        #region ExecuteCommandFile

        /// <summary>
        /// The ExecuteCommandFile method opens the specified file and executes the debugger commands that are contained within.
        /// </summary>
        /// <param name="outputControl">[in] Specifies where to send the output of the command. For possible values, see DEBUG_OUTCTL_XXX. For more information about output, see Input and Output.</param>
        /// <param name="commandFile">[in] Specifies the name of the file that contains the commands to execute. This file is opened for reading and its contents are interpreted as if they had been typed into the debugger console.</param>
        /// <param name="flags">[in] Specifies execution options for the command. The default options are to log the command but not to send it to the output.<para/>
        /// For details about the values that Flags can take, see <see cref="Execute"/>.</param>
        /// <remarks>
        /// This method reads the specified file and execute the commands one line at a time using <see cref="Execute"/>. If
        /// an exception occurred while executing a line, the execution will continue with the next line.
        /// </remarks>
        public void ExecuteCommandFile(DEBUG_OUTCTL outputControl, string commandFile, DEBUG_EXECUTE flags)
        {
            TryExecuteCommandFile(outputControl, commandFile, flags).ThrowDbgEngNotOK();
        }

        /// <summary>
        /// The ExecuteCommandFile method opens the specified file and executes the debugger commands that are contained within.
        /// </summary>
        /// <param name="outputControl">[in] Specifies where to send the output of the command. For possible values, see DEBUG_OUTCTL_XXX. For more information about output, see Input and Output.</param>
        /// <param name="commandFile">[in] Specifies the name of the file that contains the commands to execute. This file is opened for reading and its contents are interpreted as if they had been typed into the debugger console.</param>
        /// <param name="flags">[in] Specifies execution options for the command. The default options are to log the command but not to send it to the output.<para/>
        /// For details about the values that Flags can take, see <see cref="Execute"/>.</param>
        /// <returns>This method might also return error values, including error values caused by a failure to open the specified file.<para/>
        /// For more information, see Return Values.</returns>
        /// <remarks>
        /// This method reads the specified file and execute the commands one line at a time using <see cref="Execute"/>. If
        /// an exception occurred while executing a line, the execution will continue with the next line.
        /// </remarks>
        public HRESULT TryExecuteCommandFile(DEBUG_OUTCTL outputControl, string commandFile, DEBUG_EXECUTE flags)
        {
            /*HRESULT ExecuteCommandFile(
            [In] DEBUG_OUTCTL OutputControl,
            [In, MarshalAs(UnmanagedType.LPStr)] string CommandFile,
            [In] DEBUG_EXECUTE Flags);*/
            return Raw.ExecuteCommandFile(outputControl, commandFile, flags);
        }

        #endregion
        #region GetBreakpointByIndex

        /// <summary>
        /// The GetBreakpointByIndex method returns the breakpoint located at the specified index.
        /// </summary>
        /// <param name="index">[in] Specifies the zero-based index of the breakpoint to return. This is specific to the current process. The value of Index should be between zero and the total number of breakpoints minus one.<para/>
        /// The total number of breakpoints can be determined by calling <see cref="NumberBreakpoints"/>.</param>
        /// <returns>[out] Receives the returned breakpoint.</returns>
        /// <remarks>
        /// The index and returned breakpoint are specific to the current process. The same index will return a different breakpoint
        /// if the current process is changed.
        /// </remarks>
        public DebugBreakpoint GetBreakpointByIndex(int index)
        {
            DebugBreakpoint bpResult;
            TryGetBreakpointByIndex(index, out bpResult).ThrowDbgEngNotOK();

            return bpResult;
        }

        /// <summary>
        /// The GetBreakpointByIndex method returns the breakpoint located at the specified index.
        /// </summary>
        /// <param name="index">[in] Specifies the zero-based index of the breakpoint to return. This is specific to the current process. The value of Index should be between zero and the total number of breakpoints minus one.<para/>
        /// The total number of breakpoints can be determined by calling <see cref="NumberBreakpoints"/>.</param>
        /// <param name="bpResult">[out] Receives the returned breakpoint.</param>
        /// <returns>This method can also return other error values. See Return Values for more details.</returns>
        /// <remarks>
        /// The index and returned breakpoint are specific to the current process. The same index will return a different breakpoint
        /// if the current process is changed.
        /// </remarks>
        public HRESULT TryGetBreakpointByIndex(int index, out DebugBreakpoint bpResult)
        {
            /*HRESULT GetBreakpointByIndex(
            [In] int Index,
            [Out, MarshalAs(UnmanagedType.Interface), ComAliasName("IDebugBreakpoint")] out IDebugBreakpoint bp);*/
            IDebugBreakpoint bp;
            HRESULT hr = Raw.GetBreakpointByIndex(index, out bp);

            if (hr == HRESULT.S_OK)
                bpResult = bp == null ? null : new DebugBreakpoint(bp);
            else
                bpResult = default(DebugBreakpoint);

            return hr;
        }

        #endregion
        #region GetBreakpointById

        /// <summary>
        /// The GetBreakpointById method returns the breakpoint with the specified breakpoint ID.
        /// </summary>
        /// <param name="id">[in] Specifies the breakpoint ID of the breakpoint to return.</param>
        /// <returns>[out] Receives the breakpoint.</returns>
        /// <remarks>
        /// If the specified breakpoint does not belong to the current process, the method will fail.
        /// </remarks>
        public DebugBreakpoint GetBreakpointById(int id)
        {
            DebugBreakpoint bpResult;
            TryGetBreakpointById(id, out bpResult).ThrowDbgEngNotOK();

            return bpResult;
        }

        /// <summary>
        /// The GetBreakpointById method returns the breakpoint with the specified breakpoint ID.
        /// </summary>
        /// <param name="id">[in] Specifies the breakpoint ID of the breakpoint to return.</param>
        /// <param name="bpResult">[out] Receives the breakpoint.</param>
        /// <returns>This method can also return other error values. See Return Values for more details.</returns>
        /// <remarks>
        /// If the specified breakpoint does not belong to the current process, the method will fail.
        /// </remarks>
        public HRESULT TryGetBreakpointById(int id, out DebugBreakpoint bpResult)
        {
            /*HRESULT GetBreakpointById(
            [In] int Id,
            [Out, MarshalAs(UnmanagedType.Interface), ComAliasName("IDebugBreakpoint")] out IDebugBreakpoint bp);*/
            IDebugBreakpoint bp;
            HRESULT hr = Raw.GetBreakpointById(id, out bp);

            if (hr == HRESULT.S_OK)
                bpResult = bp == null ? null : new DebugBreakpoint(bp);
            else
                bpResult = default(DebugBreakpoint);

            return hr;
        }

        #endregion
        #region GetBreakpointParameters

        /// <summary>
        /// The GetBreakpointParameters method returns the parameters of one or more breakpoints.
        /// </summary>
        /// <param name="count">[in] Specifies the number of breakpoints whose parameters are being requested.</param>
        /// <param name="ids">[in, optional] Specifies an array containing the IDs of the breakpoints whose parameters are being requested. The number of items in this array must be equal to the value specified in Count.<para/>
        /// If Ids is NULL, Start is used instead.</param>
        /// <param name="start">[in] Specifies the beginning index of the breakpoints whose parameters are being requested. The parameters for breakpoints with indices Start through Start plus Count minus one will be returned.<para/>
        /// Start is used only if Ids is NULL.</param>
        /// <returns>[out] Receives the parameters for the specified breakpoints. The size of this array is equal to the value of Count.<para/>
        /// For details on the structure returned, see <see cref="DEBUG_BREAKPOINT_PARAMETERS"/>.</returns>
        /// <remarks>
        /// Some of the parameters might not be returned. This happens if either a breakpoint could not be found or a breakpoint
        /// is private (see <see cref="DebugBreakpoint.Flags"/>).
        /// </remarks>
        public DEBUG_BREAKPOINT_PARAMETERS[] GetBreakpointParameters(int count, int[] ids, int start)
        {
            DEBUG_BREAKPOINT_PARAMETERS[] @params;
            TryGetBreakpointParameters(count, ids, start, out @params).ThrowDbgEngNotOK();

            return @params;
        }

        /// <summary>
        /// The GetBreakpointParameters method returns the parameters of one or more breakpoints.
        /// </summary>
        /// <param name="count">[in] Specifies the number of breakpoints whose parameters are being requested.</param>
        /// <param name="ids">[in, optional] Specifies an array containing the IDs of the breakpoints whose parameters are being requested. The number of items in this array must be equal to the value specified in Count.<para/>
        /// If Ids is NULL, Start is used instead.</param>
        /// <param name="start">[in] Specifies the beginning index of the breakpoints whose parameters are being requested. The parameters for breakpoints with indices Start through Start plus Count minus one will be returned.<para/>
        /// Start is used only if Ids is NULL.</param>
        /// <param name="params">[out] Receives the parameters for the specified breakpoints. The size of this array is equal to the value of Count.<para/>
        /// For details on the structure returned, see <see cref="DEBUG_BREAKPOINT_PARAMETERS"/>.</param>
        /// <returns>This method can also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// Some of the parameters might not be returned. This happens if either a breakpoint could not be found or a breakpoint
        /// is private (see <see cref="DebugBreakpoint.Flags"/>).
        /// </remarks>
        public HRESULT TryGetBreakpointParameters(int count, int[] ids, int start, out DEBUG_BREAKPOINT_PARAMETERS[] @params)
        {
            /*HRESULT GetBreakpointParameters(
            [In] int Count,
            [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] int[] Ids,
            [In] int Start,
            [SRI.Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] DEBUG_BREAKPOINT_PARAMETERS[] Params);*/
            @params = new DEBUG_BREAKPOINT_PARAMETERS[count];
            HRESULT hr = Raw.GetBreakpointParameters(count, ids, start, @params);

            return hr;
        }

        #endregion
        #region AddBreakpoint

        /// <summary>
        /// The AddBreakpoint method creates a new breakpoint for the current target.
        /// </summary>
        /// <param name="type">[in] Specifies the breakpoint type of the new breakpoint. This can be either of the following values:</param>
        /// <param name="desiredId">[in] Specifies the desired ID of the new breakpoint. If it is DEBUG_ANY_ID, the engine will pick an unused ID.</param>
        /// <returns>[out] Receives an interface pointer to the new breakpoint.</returns>
        /// <remarks>
        /// If DesiredId is not DEBUG_ANY_ID and another breakpoint already uses the ID DesiredId, these methods will fail.
        /// Breakpoints are created empty and disabled. See Using Breakpoints for details on configuring and enabling the breakpoint.
        /// The client is saved as the adder of the new breakpoint. See <see cref="DebugBreakpoint.Adder"/>.
        /// </remarks>
        public DebugBreakpoint AddBreakpoint(DEBUG_BREAKPOINT_TYPE type, int desiredId)
        {
            DebugBreakpoint bpResult;
            TryAddBreakpoint(type, desiredId, out bpResult).ThrowDbgEngNotOK();

            return bpResult;
        }

        /// <summary>
        /// The AddBreakpoint method creates a new breakpoint for the current target.
        /// </summary>
        /// <param name="type">[in] Specifies the breakpoint type of the new breakpoint. This can be either of the following values:</param>
        /// <param name="desiredId">[in] Specifies the desired ID of the new breakpoint. If it is DEBUG_ANY_ID, the engine will pick an unused ID.</param>
        /// <param name="bpResult">[out] Receives an interface pointer to the new breakpoint.</param>
        /// <returns>This method may also return other error values. See Return Values for more details.</returns>
        /// <remarks>
        /// If DesiredId is not DEBUG_ANY_ID and another breakpoint already uses the ID DesiredId, these methods will fail.
        /// Breakpoints are created empty and disabled. See Using Breakpoints for details on configuring and enabling the breakpoint.
        /// The client is saved as the adder of the new breakpoint. See <see cref="DebugBreakpoint.Adder"/>.
        /// </remarks>
        public HRESULT TryAddBreakpoint(DEBUG_BREAKPOINT_TYPE type, int desiredId, out DebugBreakpoint bpResult)
        {
            /*HRESULT AddBreakpoint(
            [In] DEBUG_BREAKPOINT_TYPE Type,
            [In] int DesiredId,
            [Out, MarshalAs(UnmanagedType.Interface), ComAliasName("IDebugBreakpoint")] out IDebugBreakpoint Bp);*/
            IDebugBreakpoint bp;
            HRESULT hr = Raw.AddBreakpoint(type, desiredId, out bp);

            if (hr == HRESULT.S_OK)
                bpResult = bp == null ? null : new DebugBreakpoint(bp);
            else
                bpResult = default(DebugBreakpoint);

            return hr;
        }

        #endregion
        #region RemoveBreakpoint

        /// <summary>
        /// The RemoveBreakpoint method removes a breakpoint.
        /// </summary>
        /// <param name="bp">[in] Specifies an interface pointer to breakpoint to remove.</param>
        /// <remarks>
        /// After RemoveBreakpoint and RemoveBreakpoint2 are called, the breakpoint object specified in the Bp parameter must
        /// not be used again.
        /// </remarks>
        public void RemoveBreakpoint(IDebugBreakpoint bp)
        {
            TryRemoveBreakpoint(bp).ThrowDbgEngNotOK();
        }

        /// <summary>
        /// The RemoveBreakpoint method removes a breakpoint.
        /// </summary>
        /// <param name="bp">[in] Specifies an interface pointer to breakpoint to remove.</param>
        /// <returns>This method may also return other error values. See Return Values for more details.</returns>
        /// <remarks>
        /// After RemoveBreakpoint and RemoveBreakpoint2 are called, the breakpoint object specified in the Bp parameter must
        /// not be used again.
        /// </remarks>
        public HRESULT TryRemoveBreakpoint(IDebugBreakpoint bp)
        {
            /*HRESULT RemoveBreakpoint(
            [In, MarshalAs(UnmanagedType.Interface), ComAliasName("IDebugBreakpoint")] IDebugBreakpoint Bp);*/
            return Raw.RemoveBreakpoint(bp);
        }

        #endregion
        #region AddExtension

        /// <summary>
        /// The AddExtension method loads an extension library into the debugger engine.
        /// </summary>
        /// <param name="path">[in] Specifies the fully qualified path and file name of the extension library to load.</param>
        /// <param name="flags">[in] Set to zero.</param>
        /// <returns>[out] Receives the handle of the loaded extension library.</returns>
        /// <remarks>
        /// If the extension library has already been loaded, the handle to already loaded library is returned. The extension
        /// library is not loaded again. The extension library is loaded into the host engine and Path contains a path and
        /// file name for this instance of the debugger engine. AddExtension does not complete the process of loading and initializing
        /// the extension DLL. To make the extension available for use, make a subsequent call to the <see cref="GetExtensionFunction"/>.
        /// For more information on using extension libraries, see Calling Extensions and Extension Functions.
        /// </remarks>
        public long AddExtension(string path, int flags)
        {
            long handle;
            TryAddExtension(path, flags, out handle).ThrowDbgEngNotOK();

            return handle;
        }

        /// <summary>
        /// The AddExtension method loads an extension library into the debugger engine.
        /// </summary>
        /// <param name="path">[in] Specifies the fully qualified path and file name of the extension library to load.</param>
        /// <param name="flags">[in] Set to zero.</param>
        /// <param name="handle">[out] Receives the handle of the loaded extension library.</param>
        /// <returns>This method can also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// If the extension library has already been loaded, the handle to already loaded library is returned. The extension
        /// library is not loaded again. The extension library is loaded into the host engine and Path contains a path and
        /// file name for this instance of the debugger engine. AddExtension does not complete the process of loading and initializing
        /// the extension DLL. To make the extension available for use, make a subsequent call to the <see cref="GetExtensionFunction"/>.
        /// For more information on using extension libraries, see Calling Extensions and Extension Functions.
        /// </remarks>
        public HRESULT TryAddExtension(string path, int flags, out long handle)
        {
            /*HRESULT AddExtension(
            [In, MarshalAs(UnmanagedType.LPStr)] string Path,
            [In] int Flags,
            [Out] out long Handle);*/
            return Raw.AddExtension(path, flags, out handle);
        }

        #endregion
        #region RemoveExtension

        /// <summary>
        /// The RemoveExtension method unloads an extension library.
        /// </summary>
        /// <param name="handle">[in] Specifies the handle of the extension library to unload. This is the handle returned by <see cref="AddExtension"/>.</param>
        /// <remarks>
        /// For more information on using extension libraries, see Calling Extensions and Extension Functions.
        /// </remarks>
        public void RemoveExtension(long handle)
        {
            TryRemoveExtension(handle).ThrowDbgEngNotOK();
        }

        /// <summary>
        /// The RemoveExtension method unloads an extension library.
        /// </summary>
        /// <param name="handle">[in] Specifies the handle of the extension library to unload. This is the handle returned by <see cref="AddExtension"/>.</param>
        /// <returns>This method can also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// For more information on using extension libraries, see Calling Extensions and Extension Functions.
        /// </remarks>
        public HRESULT TryRemoveExtension(long handle)
        {
            /*HRESULT RemoveExtension(
            [In] long Handle);*/
            return Raw.RemoveExtension(handle);
        }

        #endregion
        #region GetExtensionByPath

        /// <summary>
        /// The GetExtensionByPath method returns the handle for an already loaded extension library.
        /// </summary>
        /// <param name="path">[in] Specifies the fully qualified path and file name of the extension library.</param>
        /// <returns>[out] Receives the handle of the extension library.</returns>
        /// <remarks>
        /// Extension libraries are loaded into the host engine, which is where this method looks for the requested extension
        /// library. Path is a path and file name for the host engine. For more information on using extension libraries, see
        /// Calling Extensions and Extension Functions.
        /// </remarks>
        public long GetExtensionByPath(string path)
        {
            long handle;
            TryGetExtensionByPath(path, out handle).ThrowDbgEngNotOK();

            return handle;
        }

        /// <summary>
        /// The GetExtensionByPath method returns the handle for an already loaded extension library.
        /// </summary>
        /// <param name="path">[in] Specifies the fully qualified path and file name of the extension library.</param>
        /// <param name="handle">[out] Receives the handle of the extension library.</param>
        /// <returns>This method can also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// Extension libraries are loaded into the host engine, which is where this method looks for the requested extension
        /// library. Path is a path and file name for the host engine. For more information on using extension libraries, see
        /// Calling Extensions and Extension Functions.
        /// </remarks>
        public HRESULT TryGetExtensionByPath(string path, out long handle)
        {
            /*HRESULT GetExtensionByPath(
            [In, MarshalAs(UnmanagedType.LPStr)] string Path,
            [Out] out long Handle);*/
            return Raw.GetExtensionByPath(path, out handle);
        }

        #endregion
        #region CallExtension

        /// <summary>
        /// The CallExtension method calls a debugger extension.
        /// </summary>
        /// <param name="handle">[in] Specifies the handle of the extension library that contains the extension to call. If Handle is zero, the engine will walk the extension library chain searching for the extension.</param>
        /// <param name="function">[in] Specifies the name of the extension to call.</param>
        /// <param name="arguments">[in, optional] Specifies the arguments to pass to the extension. Arguments is a string that will be parsed by the extension, just like the extension will parse arguments passed to it when called as an extension command.</param>
        /// <remarks>
        /// If Handle is zero, the engine searches each extension library until it finds one that contains the extension; the
        /// extension will then be called. If the extension returns DEBUG_EXTENSION_CONTINUE_SEARCH, the search will continue.
        /// For more information on using extension libraries, see Calling Extensions and Extension Functions.
        /// </remarks>
        public void CallExtension(long handle, string function, string arguments)
        {
            TryCallExtension(handle, function, arguments).ThrowDbgEngNotOK();
        }

        /// <summary>
        /// The CallExtension method calls a debugger extension.
        /// </summary>
        /// <param name="handle">[in] Specifies the handle of the extension library that contains the extension to call. If Handle is zero, the engine will walk the extension library chain searching for the extension.</param>
        /// <param name="function">[in] Specifies the name of the extension to call.</param>
        /// <param name="arguments">[in, optional] Specifies the arguments to pass to the extension. Arguments is a string that will be parsed by the extension, just like the extension will parse arguments passed to it when called as an extension command.</param>
        /// <returns>This method can also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// If Handle is zero, the engine searches each extension library until it finds one that contains the extension; the
        /// extension will then be called. If the extension returns DEBUG_EXTENSION_CONTINUE_SEARCH, the search will continue.
        /// For more information on using extension libraries, see Calling Extensions and Extension Functions.
        /// </remarks>
        public HRESULT TryCallExtension(long handle, string function, string arguments)
        {
            /*HRESULT CallExtension(
            [In] long Handle,
            [In, MarshalAs(UnmanagedType.LPStr)] string Function,
            [In, MarshalAs(UnmanagedType.LPStr)] string Arguments);*/
            return Raw.CallExtension(handle, function, arguments);
        }

        #endregion
        #region GetExtensionFunction

        /// <summary>
        /// The GetExtensionFunction method returns a pointer to an extension function from an extension library.
        /// </summary>
        /// <param name="handle">[in] Specifies the handle of the extension library that contains the extension function. If Handle is zero, the engine will walk the extension library chain searching for the extension function.</param>
        /// <param name="funcName">[in] Specifies the name of the extension function to return. When searching the extension libraries for the function, the debugger engine will prepend "EFN" to the name.<para/>
        /// For example, if FuncName is "SampleFunction", the engine will search the extension libraries for "_EFN_SampleFunction".</param>
        /// <returns>[out] Receives the extension function.</returns>
        /// <remarks>
        /// Extension libraries are loaded into the host engine and extension functions cannot be called remotely. The current
        /// client must not be a debugging client, it must belong to the host engine. The extension function can have any function
        /// prototype. In order for any program to call this extension function, the extension function should be cast to the
        /// correct prototype. For more information on using extension functions, see Calling Extensions and Extension Functions.
        /// </remarks>
        public IntPtr GetExtensionFunction(long handle, string funcName)
        {
            IntPtr function;
            TryGetExtensionFunction(handle, funcName, out function).ThrowDbgEngNotOK();

            return function;
        }

        /// <summary>
        /// The GetExtensionFunction method returns a pointer to an extension function from an extension library.
        /// </summary>
        /// <param name="handle">[in] Specifies the handle of the extension library that contains the extension function. If Handle is zero, the engine will walk the extension library chain searching for the extension function.</param>
        /// <param name="funcName">[in] Specifies the name of the extension function to return. When searching the extension libraries for the function, the debugger engine will prepend "EFN" to the name.<para/>
        /// For example, if FuncName is "SampleFunction", the engine will search the extension libraries for "_EFN_SampleFunction".</param>
        /// <param name="function">[out] Receives the extension function.</param>
        /// <returns>This method can also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// Extension libraries are loaded into the host engine and extension functions cannot be called remotely. The current
        /// client must not be a debugging client, it must belong to the host engine. The extension function can have any function
        /// prototype. In order for any program to call this extension function, the extension function should be cast to the
        /// correct prototype. For more information on using extension functions, see Calling Extensions and Extension Functions.
        /// </remarks>
        public HRESULT TryGetExtensionFunction(long handle, string funcName, out IntPtr function)
        {
            /*HRESULT GetExtensionFunction(
            [In] long Handle,
            [In, MarshalAs(UnmanagedType.LPStr)] string FuncName,
            [Out] out IntPtr Function);*/
            return Raw.GetExtensionFunction(handle, funcName, out function);
        }

        #endregion
        #region GetWindbgExtensionApis32

        /// <summary>
        /// The GetWindbgExtensionApis32 method returns a structure that facilitates using the WdbgExts API.
        /// </summary>
        /// <param name="api">[in, out] Receives a WINDBG_EXTENSION_APIS32 structure. This structure contains the functions used by the WdbgExts API.<para/>
        /// The nSize member of this structure must be set to the size of the structure before it is passed to this method.</param>
        /// <remarks>
        /// If you are including Wdbgexts.h in your extension code, you should call this method during the initialization of
        /// the extension DLL (see DebugExtensionInitialize). Many WdbgExts functions are really macros. To ensure that these
        /// macros work correctly, the structure received by the Api parameter should be stored in a global variable named
        /// ExtensionApis. For a list of the functions provided by the WdbgExts API, see WdbgExts Functions.
        /// </remarks>
        public void GetWindbgExtensionApis32(ref WINDBG_EXTENSION_APIS api)
        {
            TryGetWindbgExtensionApis32(ref api).ThrowDbgEngNotOK();
        }

        /// <summary>
        /// The GetWindbgExtensionApis32 method returns a structure that facilitates using the WdbgExts API.
        /// </summary>
        /// <param name="api">[in, out] Receives a WINDBG_EXTENSION_APIS32 structure. This structure contains the functions used by the WdbgExts API.<para/>
        /// The nSize member of this structure must be set to the size of the structure before it is passed to this method.</param>
        /// <returns>This method may also return other error values. See Return Values for more details.</returns>
        /// <remarks>
        /// If you are including Wdbgexts.h in your extension code, you should call this method during the initialization of
        /// the extension DLL (see DebugExtensionInitialize). Many WdbgExts functions are really macros. To ensure that these
        /// macros work correctly, the structure received by the Api parameter should be stored in a global variable named
        /// ExtensionApis. For a list of the functions provided by the WdbgExts API, see WdbgExts Functions.
        /// </remarks>
        public HRESULT TryGetWindbgExtensionApis32(ref WINDBG_EXTENSION_APIS api)
        {
            /*HRESULT GetWindbgExtensionApis32(
            [In, Out] ref WINDBG_EXTENSION_APIS Api);*/
            return Raw.GetWindbgExtensionApis32(ref api);
        }

        #endregion
        #region GetWindbgExtensionApis64

        /// <summary>
        /// The GetWindbgExtensionApis64 method returns a structure that facilitates using the WdbgExts API.
        /// </summary>
        /// <param name="api">[in, out] Receives a WINDBG_EXTENSION_APIS64 structure. This structure contains the functions used by the WdbgExts API.<para/>
        /// The nSize member of this structure must be set to the size of the structure before it is passed to this method.</param>
        /// <remarks>
        /// If you are including Wdbgexts.h in your extension code, you should call this method during the initialization of
        /// the extension DLL (see DebugExtensionInitialize). Many WdbgExts functions are really macros. To ensure that these
        /// macros work correctly, the structure received by the Api parameter should be stored in a global variable named
        /// ExtensionApis. The WINDBG_EXTENSION_APIS64 structure returned by this method serves the same purpose as the one
        /// provided to the callback function WinDbgExtensionDllInit (used by WdbgExts extensions). For a list of the functions
        /// provided by the WdbgExts API, see WdbgExts Functions.
        /// </remarks>
        public void GetWindbgExtensionApis64(ref WINDBG_EXTENSION_APIS api)
        {
            TryGetWindbgExtensionApis64(ref api).ThrowDbgEngNotOK();
        }

        /// <summary>
        /// The GetWindbgExtensionApis64 method returns a structure that facilitates using the WdbgExts API.
        /// </summary>
        /// <param name="api">[in, out] Receives a WINDBG_EXTENSION_APIS64 structure. This structure contains the functions used by the WdbgExts API.<para/>
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
        public HRESULT TryGetWindbgExtensionApis64(ref WINDBG_EXTENSION_APIS api)
        {
            /*HRESULT GetWindbgExtensionApis64(
            [In, Out] ref WINDBG_EXTENSION_APIS Api);*/
            return Raw.GetWindbgExtensionApis64(ref api);
        }

        #endregion
        #region GetEventFilterText

        /// <summary>
        /// The GetEventFilterText method returns a short description of an event for a specific filter.
        /// </summary>
        /// <param name="index">[in] Specifies the index of the event filter whose description will be returned. Only the specific filters have a description attached to them; Index must refer to a specific filter.</param>
        /// <returns>[out, optional] Receives the description of the specific filter.</returns>
        /// <remarks>
        /// For more information about event filters, see Event Filters.
        /// </remarks>
        public string GetEventFilterText(int index)
        {
            string bufferResult;
            TryGetEventFilterText(index, out bufferResult).ThrowDbgEngNotOK();

            return bufferResult;
        }

        /// <summary>
        /// The GetEventFilterText method returns a short description of an event for a specific filter.
        /// </summary>
        /// <param name="index">[in] Specifies the index of the event filter whose description will be returned. Only the specific filters have a description attached to them; Index must refer to a specific filter.</param>
        /// <param name="bufferResult">[out, optional] Receives the description of the specific filter.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// For more information about event filters, see Event Filters.
        /// </remarks>
        public HRESULT TryGetEventFilterText(int index, out string bufferResult)
        {
            /*HRESULT GetEventFilterText(
            [In] int Index,
            [SRI.Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U1, SizeParamIndex = 2)] byte[] Buffer,
            [In] int BufferSize,
            [Out] out int TextSize);*/
            byte[] buffer;
            int bufferSize = 0;
            int textSize;
            HRESULT hr = Raw.GetEventFilterText(index, null, bufferSize, out textSize);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER && hr != HRESULT.S_OK)
                goto fail;

            bufferSize = textSize;
            buffer = new byte[bufferSize];
            hr = Raw.GetEventFilterText(index, buffer, bufferSize, out textSize);

            if (hr == HRESULT.S_OK)
            {
                bufferResult = CreateString(buffer, textSize);

                return hr;
            }

            fail:
            bufferResult = default(string);

            return hr;
        }

        #endregion
        #region GetEventFilterCommand

        /// <summary>
        /// The GetEventFilterCommand method returns the debugger command that the engine will execute when a specified event occurs.
        /// </summary>
        /// <param name="index">[in] Specifies the index of the event filter. Index can take any value between zero and one less than the total number of event filters returned by <see cref="NumberEventFilters"/> (inclusive).<para/>
        /// For more information about the index of the filters, see Index and Exception Code.</param>
        /// <returns>[out, optional] Receives the debugger command that the engine will execute when the event occurs.</returns>
        /// <remarks>
        /// For more information about event filters, see Event Filters.
        /// </remarks>
        public string GetEventFilterCommand(int index)
        {
            string bufferResult;
            TryGetEventFilterCommand(index, out bufferResult).ThrowDbgEngNotOK();

            return bufferResult;
        }

        /// <summary>
        /// The GetEventFilterCommand method returns the debugger command that the engine will execute when a specified event occurs.
        /// </summary>
        /// <param name="index">[in] Specifies the index of the event filter. Index can take any value between zero and one less than the total number of event filters returned by <see cref="NumberEventFilters"/> (inclusive).<para/>
        /// For more information about the index of the filters, see Index and Exception Code.</param>
        /// <param name="bufferResult">[out, optional] Receives the debugger command that the engine will execute when the event occurs.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// For more information about event filters, see Event Filters.
        /// </remarks>
        public HRESULT TryGetEventFilterCommand(int index, out string bufferResult)
        {
            /*HRESULT GetEventFilterCommand(
            [In] int Index,
            [SRI.Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U1, SizeParamIndex = 2)] byte[] Buffer,
            [In] int BufferSize,
            [Out] out int CommandSize);*/
            byte[] buffer;
            int bufferSize = 0;
            int commandSize;
            HRESULT hr = Raw.GetEventFilterCommand(index, null, bufferSize, out commandSize);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER && hr != HRESULT.S_OK)
                goto fail;

            bufferSize = commandSize;
            buffer = new byte[bufferSize];
            hr = Raw.GetEventFilterCommand(index, buffer, bufferSize, out commandSize);

            if (hr == HRESULT.S_OK)
            {
                bufferResult = CreateString(buffer, commandSize);

                return hr;
            }

            fail:
            bufferResult = default(string);

            return hr;
        }

        #endregion
        #region SetEventFilterCommand

        /// <summary>
        /// The SetEventFilterCommand method sets a debugger command for the engine to execute when a specified event occurs.
        /// </summary>
        /// <param name="index">[in] Specifies the index of the event filter. Index can take any value between zero and one less than the total number of event filters returned by GetNumberEventFilters (inclusive).<para/>
        /// For more information about the index of the filters, see Index and Exception Code.</param>
        /// <param name="command">[in] Specifies the debugger command for the engine to execute when the event occurs.</param>
        /// <remarks>
        /// For more information about event filters, see Event Filters.
        /// </remarks>
        public void SetEventFilterCommand(int index, string command)
        {
            TrySetEventFilterCommand(index, command).ThrowDbgEngNotOK();
        }

        /// <summary>
        /// The SetEventFilterCommand method sets a debugger command for the engine to execute when a specified event occurs.
        /// </summary>
        /// <param name="index">[in] Specifies the index of the event filter. Index can take any value between zero and one less than the total number of event filters returned by GetNumberEventFilters (inclusive).<para/>
        /// For more information about the index of the filters, see Index and Exception Code.</param>
        /// <param name="command">[in] Specifies the debugger command for the engine to execute when the event occurs.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// For more information about event filters, see Event Filters.
        /// </remarks>
        public HRESULT TrySetEventFilterCommand(int index, string command)
        {
            /*HRESULT SetEventFilterCommand(
            [In] int Index,
            [In, MarshalAs(UnmanagedType.LPStr)] string Command);*/
            return Raw.SetEventFilterCommand(index, command);
        }

        #endregion
        #region GetSpecificFilterParameters

        /// <summary>
        /// The GetSpecificFilterParameters method returns the parameters for specific event filters.
        /// </summary>
        /// <param name="start">[in] Specifies the index of the first specific event filter whose parameters will be returned.</param>
        /// <param name="count">[in] Specifies the number of specific event filters to return parameters for.</param>
        /// <returns>[out] Receives the parameters for the specific event filters. Params is an array of elements of type <see cref="DEBUG_SPECIFIC_FILTER_PARAMETERS"/>.</returns>
        /// <remarks>
        /// For more information about event filters, see Event Filters.
        /// </remarks>
        public DEBUG_SPECIFIC_FILTER_PARAMETERS[] GetSpecificFilterParameters(int start, int count)
        {
            DEBUG_SPECIFIC_FILTER_PARAMETERS[] @params;
            TryGetSpecificFilterParameters(start, count, out @params).ThrowDbgEngNotOK();

            return @params;
        }

        /// <summary>
        /// The GetSpecificFilterParameters method returns the parameters for specific event filters.
        /// </summary>
        /// <param name="start">[in] Specifies the index of the first specific event filter whose parameters will be returned.</param>
        /// <param name="count">[in] Specifies the number of specific event filters to return parameters for.</param>
        /// <param name="params">[out] Receives the parameters for the specific event filters. Params is an array of elements of type <see cref="DEBUG_SPECIFIC_FILTER_PARAMETERS"/>.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// For more information about event filters, see Event Filters.
        /// </remarks>
        public HRESULT TryGetSpecificFilterParameters(int start, int count, out DEBUG_SPECIFIC_FILTER_PARAMETERS[] @params)
        {
            /*HRESULT GetSpecificFilterParameters(
            [In] int Start,
            [In] int Count,
            [SRI.Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] DEBUG_SPECIFIC_FILTER_PARAMETERS[] Params);*/
            @params = new DEBUG_SPECIFIC_FILTER_PARAMETERS[count];
            HRESULT hr = Raw.GetSpecificFilterParameters(start, count, @params);

            return hr;
        }

        #endregion
        #region SetSpecificFilterParameters

        /// <summary>
        /// The SetSpecificFilterParameters method changes the break status and handling status for some specific event filters.
        /// </summary>
        /// <param name="start">[in] Specifies the index of the first specific event filter whose parameters will be changed.</param>
        /// <param name="count">[in] Specifies the number of specific event filters whose parameters will be changed.</param>
        /// <param name="params">[in] Specifies an array of specific event filter parameters of type <see cref="DEBUG_SPECIFIC_FILTER_PARAMETERS"/>.<para/>
        /// Only the ExecutionOption and ContinueOption members are used. ExceptionOption specifies the new break status and ContinueOption specifies the new handling status.</param>
        /// <remarks>
        /// For more information about event filters, see Event Filters.
        /// </remarks>
        public void SetSpecificFilterParameters(int start, int count, DEBUG_SPECIFIC_FILTER_PARAMETERS[] @params)
        {
            TrySetSpecificFilterParameters(start, count, @params).ThrowDbgEngNotOK();
        }

        /// <summary>
        /// The SetSpecificFilterParameters method changes the break status and handling status for some specific event filters.
        /// </summary>
        /// <param name="start">[in] Specifies the index of the first specific event filter whose parameters will be changed.</param>
        /// <param name="count">[in] Specifies the number of specific event filters whose parameters will be changed.</param>
        /// <param name="params">[in] Specifies an array of specific event filter parameters of type <see cref="DEBUG_SPECIFIC_FILTER_PARAMETERS"/>.<para/>
        /// Only the ExecutionOption and ContinueOption members are used. ExceptionOption specifies the new break status and ContinueOption specifies the new handling status.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// For more information about event filters, see Event Filters.
        /// </remarks>
        public HRESULT TrySetSpecificFilterParameters(int start, int count, DEBUG_SPECIFIC_FILTER_PARAMETERS[] @params)
        {
            /*HRESULT SetSpecificFilterParameters(
            [In] int Start,
            [In] int Count,
            [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] DEBUG_SPECIFIC_FILTER_PARAMETERS[] Params);*/
            return Raw.SetSpecificFilterParameters(start, count, @params);
        }

        #endregion
        #region GetSpecificFilterArgument

        public string GetSpecificFilterArgument(int index)
        {
            string bufferResult;
            TryGetSpecificFilterArgument(index, out bufferResult).ThrowDbgEngNotOK();

            return bufferResult;
        }

        public HRESULT TryGetSpecificFilterArgument(int index, out string bufferResult)
        {
            /*HRESULT GetSpecificFilterArgument( //todo: rename this in all other idebugcontrol files and also regenerate method help
            [In] int Index,
            [SRI.Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U1, SizeParamIndex = 2)] byte[] Buffer,
            [In] int BufferSize,
            [Out] out int ArgumentSize);*/
            byte[] buffer;
            int bufferSize = 0;
            int argumentSize;
            HRESULT hr = Raw.GetSpecificFilterArgument(index, null, bufferSize, out argumentSize);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER && hr != HRESULT.S_OK)
                goto fail;

            bufferSize = argumentSize;
            buffer = new byte[bufferSize];
            hr = Raw.GetSpecificFilterArgument(index, buffer, bufferSize, out argumentSize);

            if (hr == HRESULT.S_OK)
            {
                bufferResult = CreateString(buffer, argumentSize);

                return hr;
            }

            fail:
            bufferResult = default(string);

            return hr;
        }

        #endregion
        #region SetSpecificFilterArgument

        public void SetSpecificFilterArgument(int index, string argument)
        {
            TrySetSpecificFilterArgument(index, argument).ThrowDbgEngNotOK();
        }

        public HRESULT TrySetSpecificFilterArgument(int index, string argument)
        {
            /*HRESULT SetSpecificFilterArgument( //todo: rename this in all other idebugcontrol files and also regenerate method help
            [In] int Index,
            [In, MarshalAs(UnmanagedType.LPStr)] string Argument);*/
            return Raw.SetSpecificFilterArgument(index, argument);
        }

        #endregion
        #region GetExceptionFilterParameters

        /// <summary>
        /// The GetExceptionFilterParameters method returns the parameters for exception filters specified by exception codes or by index.
        /// </summary>
        /// <param name="count">[in] Specifies the number of exception filters for which to return parameters.</param>
        /// <param name="codes">[in, optional] Specifies an array of exception codes. The parameters for the exception filters with these exception codes will be returned.<para/>
        /// If Codes is NULL, Start is used instead.</param>
        /// <param name="start">[in] Specifies the index of the first exception filter. The parameters for the exception filters starting at Start will be returned.<para/>
        /// If Codes is not NULL, Start is ignored.</param>
        /// <returns>[out] Receives the parameters for the exception filters specified by Codes or Start. Params is an array of elements of type <see cref="DEBUG_EXCEPTION_FILTER_PARAMETERS"/>.</returns>
        /// <remarks>
        /// For more information about event filters, see Event Filters.
        /// </remarks>
        public DEBUG_EXCEPTION_FILTER_PARAMETERS[] GetExceptionFilterParameters(int count, int[] codes, int start)
        {
            DEBUG_EXCEPTION_FILTER_PARAMETERS[] @params;
            TryGetExceptionFilterParameters(count, codes, start, out @params).ThrowDbgEngNotOK();

            return @params;
        }

        /// <summary>
        /// The GetExceptionFilterParameters method returns the parameters for exception filters specified by exception codes or by index.
        /// </summary>
        /// <param name="count">[in] Specifies the number of exception filters for which to return parameters.</param>
        /// <param name="codes">[in, optional] Specifies an array of exception codes. The parameters for the exception filters with these exception codes will be returned.<para/>
        /// If Codes is NULL, Start is used instead.</param>
        /// <param name="start">[in] Specifies the index of the first exception filter. The parameters for the exception filters starting at Start will be returned.<para/>
        /// If Codes is not NULL, Start is ignored.</param>
        /// <param name="params">[out] Receives the parameters for the exception filters specified by Codes or Start. Params is an array of elements of type <see cref="DEBUG_EXCEPTION_FILTER_PARAMETERS"/>.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// For more information about event filters, see Event Filters.
        /// </remarks>
        public HRESULT TryGetExceptionFilterParameters(int count, int[] codes, int start, out DEBUG_EXCEPTION_FILTER_PARAMETERS[] @params)
        {
            /*HRESULT GetExceptionFilterParameters(
            [In] int Count,
            [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] int[] Codes,
            [In] int Start,
            [SRI.Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] DEBUG_EXCEPTION_FILTER_PARAMETERS[] Params);*/
            @params = new DEBUG_EXCEPTION_FILTER_PARAMETERS[count];
            HRESULT hr = Raw.GetExceptionFilterParameters(count, codes, start, @params);

            return hr;
        }

        #endregion
        #region SetExceptionFilterParameters

        /// <summary>
        /// The SetExceptionFilterParameters method changes the break status and handling status for some exception filters.
        /// </summary>
        /// <param name="count">[in] Specifies the number of exception filters to change the parameters for.</param>
        /// <param name="params">[in] Specifies an array of exception filter parameters of type <see cref="DEBUG_EXCEPTION_FILTER_PARAMETERS"/>.<para/>
        /// Only the ExecutionOption, ContinueOption, and ExceptionCode fields of these parameters are used. The ExceptionCode field is used to identify the exception whose exception filter will be changed.<para/>
        /// ExceptionOption specifies the new break status and ContinueOption specifies the new handling status. If the value of the ExceptionOption field is DEBUG_FILTER_REMOVE and the exception filter is an arbitrary exception filter, the exception filter will be removed.</param>
        /// <remarks>
        /// For each of the exception filter parameters in Params, if the exception, identified by exception code, already
        /// has a filter (specific or arbitrary), that filter will be changed. Otherwise, a new arbitrary exception filter
        /// will be added for the exception. For more information about event filters, see Event Filters.
        /// </remarks>
        public void SetExceptionFilterParameters(int count, DEBUG_EXCEPTION_FILTER_PARAMETERS[] @params)
        {
            TrySetExceptionFilterParameters(count, @params).ThrowDbgEngNotOK();
        }

        /// <summary>
        /// The SetExceptionFilterParameters method changes the break status and handling status for some exception filters.
        /// </summary>
        /// <param name="count">[in] Specifies the number of exception filters to change the parameters for.</param>
        /// <param name="params">[in] Specifies an array of exception filter parameters of type <see cref="DEBUG_EXCEPTION_FILTER_PARAMETERS"/>.<para/>
        /// Only the ExecutionOption, ContinueOption, and ExceptionCode fields of these parameters are used. The ExceptionCode field is used to identify the exception whose exception filter will be changed.<para/>
        /// ExceptionOption specifies the new break status and ContinueOption specifies the new handling status. If the value of the ExceptionOption field is DEBUG_FILTER_REMOVE and the exception filter is an arbitrary exception filter, the exception filter will be removed.</param>
        /// <returns>This method may also return error values. See Return Values for more details. has been exceeded.</returns>
        /// <remarks>
        /// For each of the exception filter parameters in Params, if the exception, identified by exception code, already
        /// has a filter (specific or arbitrary), that filter will be changed. Otherwise, a new arbitrary exception filter
        /// will be added for the exception. For more information about event filters, see Event Filters.
        /// </remarks>
        public HRESULT TrySetExceptionFilterParameters(int count, DEBUG_EXCEPTION_FILTER_PARAMETERS[] @params)
        {
            /*HRESULT SetExceptionFilterParameters(
            [In] int Count,
            [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] DEBUG_EXCEPTION_FILTER_PARAMETERS[] Params);*/
            return Raw.SetExceptionFilterParameters(count, @params);
        }

        #endregion
        #region GetExceptionFilterSecondCommand

        /// <summary>
        /// The GetExceptionFilterSecondCommand method returns the command that will be executed by the debugger engine upon the second chance of a specified exception.
        /// </summary>
        /// <param name="index">[in] Specifies the index of the exception filter whose second-chance command will be returned. Index can also refer to the default exception filter to return the second-chance command for those exceptions that do not have a specific or arbitrary exception filter.</param>
        /// <returns>[out, optional] Receives the second-chance command for the exception filter.</returns>
        /// <remarks>
        /// Only exception filters support a second-chance command. If Index refers to a specific event filter, the command
        /// returned to Buffer will be empty. The returned command will also be empty if no second-chance command has been
        /// set for the specified exception. For more information about event filters, see Event Filters.
        /// </remarks>
        public string GetExceptionFilterSecondCommand(int index)
        {
            string bufferResult;
            TryGetExceptionFilterSecondCommand(index, out bufferResult).ThrowDbgEngNotOK();

            return bufferResult;
        }

        /// <summary>
        /// The GetExceptionFilterSecondCommand method returns the command that will be executed by the debugger engine upon the second chance of a specified exception.
        /// </summary>
        /// <param name="index">[in] Specifies the index of the exception filter whose second-chance command will be returned. Index can also refer to the default exception filter to return the second-chance command for those exceptions that do not have a specific or arbitrary exception filter.</param>
        /// <param name="bufferResult">[out, optional] Receives the second-chance command for the exception filter.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// Only exception filters support a second-chance command. If Index refers to a specific event filter, the command
        /// returned to Buffer will be empty. The returned command will also be empty if no second-chance command has been
        /// set for the specified exception. For more information about event filters, see Event Filters.
        /// </remarks>
        public HRESULT TryGetExceptionFilterSecondCommand(int index, out string bufferResult)
        {
            /*HRESULT GetExceptionFilterSecondCommand(
            [In] int Index,
            [SRI.Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U1, SizeParamIndex = 2)] byte[] Buffer,
            [In] int BufferSize,
            [Out] out int CommandSize);*/
            byte[] buffer;
            int bufferSize = 0;
            int commandSize;
            HRESULT hr = Raw.GetExceptionFilterSecondCommand(index, null, bufferSize, out commandSize);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER && hr != HRESULT.S_OK)
                goto fail;

            bufferSize = commandSize;
            buffer = new byte[bufferSize];
            hr = Raw.GetExceptionFilterSecondCommand(index, buffer, bufferSize, out commandSize);

            if (hr == HRESULT.S_OK)
            {
                bufferResult = CreateString(buffer, commandSize);

                return hr;
            }

            fail:
            bufferResult = default(string);

            return hr;
        }

        #endregion
        #region SetExceptionFilterSecondCommand

        /// <summary>
        /// The SetExceptionFilterSecondCommand method sets the command that will be executed by the debugger engine on the second chance of a specified exception.
        /// </summary>
        /// <param name="index">[in] Specifies the index of the exception filter whose second-chance command will be set. Index must not refer to the specific event filters as these are not exception filters and only exception events get a second chance.<para/>
        /// If Index refers to the default exception filter, the second-chance command is set for all exceptions that do not have an exception filter.</param>
        /// <param name="command">[in] Receives the second-chance command for the exception filter.</param>
        /// <remarks>
        /// For more information about event filters, see Event Filters.
        /// </remarks>
        public void SetExceptionFilterSecondCommand(int index, string command)
        {
            TrySetExceptionFilterSecondCommand(index, command).ThrowDbgEngNotOK();
        }

        /// <summary>
        /// The SetExceptionFilterSecondCommand method sets the command that will be executed by the debugger engine on the second chance of a specified exception.
        /// </summary>
        /// <param name="index">[in] Specifies the index of the exception filter whose second-chance command will be set. Index must not refer to the specific event filters as these are not exception filters and only exception events get a second chance.<para/>
        /// If Index refers to the default exception filter, the second-chance command is set for all exceptions that do not have an exception filter.</param>
        /// <param name="command">[in] Receives the second-chance command for the exception filter.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// For more information about event filters, see Event Filters.
        /// </remarks>
        public HRESULT TrySetExceptionFilterSecondCommand(int index, string command)
        {
            /*HRESULT SetExceptionFilterSecondCommand(
            [In] int Index,
            [In, MarshalAs(UnmanagedType.LPStr)] string Command);*/
            return Raw.SetExceptionFilterSecondCommand(index, command);
        }

        #endregion
        #region WaitForEvent

        /// <param name="flags">[in] Set to zero. There are currently no flags that can be used in this parameter.</param>
        /// <param name="timeout">[in] Specifies how many milliseconds to wait before this method will return. If Timeout is INFINITE, this method will not return until an event that breaks into the debugger engine application occurs or an exit interrupt is issued.<para/>
        /// If the current session has a live kernel target, Timeout must be set to INFINITE.</param>
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
        public void WaitForEvent(DEBUG_WAIT flags, int timeout)
        {
            TryWaitForEvent(flags, timeout).ThrowDbgEngNotOK();
        }

        /// <param name="flags">[in] Set to zero. There are currently no flags that can be used in this parameter.</param>
        /// <param name="timeout">[in] Specifies how many milliseconds to wait before this method will return. If Timeout is INFINITE, this method will not return until an event that breaks into the debugger engine application occurs or an exit interrupt is issued.<para/>
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
        public HRESULT TryWaitForEvent(DEBUG_WAIT flags, int timeout)
        {
            /*HRESULT WaitForEvent(
            [In] DEBUG_WAIT Flags,
            [In] int Timeout);*/
            return Raw.WaitForEvent(flags, timeout);
        }

        #endregion
        #endregion
        #region IDebugControl2

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public IDebugControl2 Raw2 => (IDebugControl2) Raw;

        #region CurrentTimeDate

        /// <summary>
        /// The GetCurrentTimeDate method returns the time of the current target.
        /// </summary>
        public int CurrentTimeDate
        {
            get
            {
                int timeDate;
                TryGetCurrentTimeDate(out timeDate).ThrowDbgEngNotOK();

                return timeDate;
            }
        }

        /// <summary>
        /// The GetCurrentTimeDate method returns the time of the current target.
        /// </summary>
        /// <param name="timeDate">[out] Receives the time and date. This is the number of seconds since the beginning of 1970, or 0 if the current time could not be determined.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// For live debugging sessions, this will be the current time as reported by the target's computer. For static debugging
        /// sessions, such as crash dump files, this will be the time the crash dump file was created. For more information,
        /// see Target Information.
        /// </remarks>
        public HRESULT TryGetCurrentTimeDate(out int timeDate)
        {
            /*HRESULT GetCurrentTimeDate(
            [Out] out int TimeDate);*/
            return Raw2.GetCurrentTimeDate(out timeDate);
        }

        #endregion
        #region CurrentSystemUpTime

        /// <summary>
        /// The GetCurrentSystemUpTime method returns the number of seconds the current target's computer has been running since it was last started.
        /// </summary>
        public int CurrentSystemUpTime
        {
            get
            {
                int upTime;
                TryGetCurrentSystemUpTime(out upTime).ThrowDbgEngNotOK();

                return upTime;
            }
        }

        /// <summary>
        /// The GetCurrentSystemUpTime method returns the number of seconds the current target's computer has been running since it was last started.
        /// </summary>
        /// <param name="upTime">[out] Receives the number of seconds the computer has been running, or 0 if the engine is unable to determine the running time.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// For more information, see Target Information.
        /// </remarks>
        public HRESULT TryGetCurrentSystemUpTime(out int upTime)
        {
            /*HRESULT GetCurrentSystemUpTime(
            [Out] out int UpTime);*/
            return Raw2.GetCurrentSystemUpTime(out upTime);
        }

        #endregion
        #region DumpFormatFlags

        /// <summary>
        /// The GetDumpFormatFlags method returns the flags that describe what information is available in a dump file target.
        /// </summary>
        public DEBUG_FORMAT DumpFormatFlags
        {
            get
            {
                DEBUG_FORMAT formatFlags;
                TryGetDumpFormatFlags(out formatFlags).ThrowDbgEngNotOK();

                return formatFlags;
            }
        }

        /// <summary>
        /// The GetDumpFormatFlags method returns the flags that describe what information is available in a dump file target.
        /// </summary>
        /// <param name="formatFlags">[out] Receives the flags that describe the information included in a dump file. Different dump files support different sets of format information.<para/>
        /// For example, see DEBUG_FORMAT_XXX for a description of the flags used for user-mode Minidump files.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// This method is only available when debugging crash dump files. If the crash dump file is in a default format or
        /// does not have variable formats, zero will be returned to FormatFlags.
        /// </remarks>
        public HRESULT TryGetDumpFormatFlags(out DEBUG_FORMAT formatFlags)
        {
            /*HRESULT GetDumpFormatFlags(
            [Out] out DEBUG_FORMAT FormatFlags);*/
            return Raw2.GetDumpFormatFlags(out formatFlags);
        }

        #endregion
        #region NumberTextReplacements

        /// <summary>
        /// The GetNumberTextReplacements method returns the number of currently defined user-named and automatic aliases.
        /// </summary>
        public int NumberTextReplacements
        {
            get
            {
                int numRepl;
                TryGetNumberTextReplacements(out numRepl).ThrowDbgEngNotOK();

                return numRepl;
            }
        }

        /// <summary>
        /// The GetNumberTextReplacements method returns the number of currently defined user-named and automatic aliases.
        /// </summary>
        /// <param name="numRepl">[out] Receives the total number of user-named and automatic aliases.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// For an overview of aliases used by the debugger engine, see Using Aliases. For more information about using aliases
        /// with the debugger engine API, see Interacting with the Engine.
        /// </remarks>
        public HRESULT TryGetNumberTextReplacements(out int numRepl)
        {
            /*HRESULT GetNumberTextReplacements(
            [Out] out int NumRepl);*/
            return Raw2.GetNumberTextReplacements(out numRepl);
        }

        #endregion
        #region GetTextReplacement

        /// <summary>
        /// The GetTextReplacement method returns the value of a user-named alias or an automatic alias.
        /// </summary>
        /// <param name="srcText">[in, optional] Specifies the name of the alias. The engine first searches the user-named aliases for one with this name.<para/>
        /// Then, if no match is found, the automatic aliases are searched. If SrcText is NULL, Index is used to specify the alias.</param>
        /// <param name="index">[in] Specifies the index of an alias. The indexes of the user-named aliases come before the indexes of the automatic aliases.<para/>
        /// Index is only used if SrcText is NULL. Index can be used along with <see cref="NumberTextReplacements"/> to iterate over all the user-named and automatic aliases.</param>
        /// <returns>The values that were emitted from the COM method.</returns>
        /// <remarks>
        /// Before executing commands or evaluating expressions, the debugger engine will replace the alias specified by SrcBuffer
        /// with the value of the alias (specified by DstBuffer). For an overview of aliases used by the debugger engine, see
        /// Using Aliases. For more information about using aliases with the debugger engine API, see Interacting with the
        /// Engine.
        /// </remarks>
        public GetTextReplacementResult GetTextReplacement(string srcText, int index)
        {
            GetTextReplacementResult result;
            TryGetTextReplacement(srcText, index, out result).ThrowDbgEngNotOK();

            return result;
        }

        /// <summary>
        /// The GetTextReplacement method returns the value of a user-named alias or an automatic alias.
        /// </summary>
        /// <param name="srcText">[in, optional] Specifies the name of the alias. The engine first searches the user-named aliases for one with this name.<para/>
        /// Then, if no match is found, the automatic aliases are searched. If SrcText is NULL, Index is used to specify the alias.</param>
        /// <param name="index">[in] Specifies the index of an alias. The indexes of the user-named aliases come before the indexes of the automatic aliases.<para/>
        /// Index is only used if SrcText is NULL. Index can be used along with <see cref="NumberTextReplacements"/> to iterate over all the user-named and automatic aliases.</param>
        /// <param name="result">The values that were emitted from the COM method.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// Before executing commands or evaluating expressions, the debugger engine will replace the alias specified by SrcBuffer
        /// with the value of the alias (specified by DstBuffer). For an overview of aliases used by the debugger engine, see
        /// Using Aliases. For more information about using aliases with the debugger engine API, see Interacting with the
        /// Engine.
        /// </remarks>
        public HRESULT TryGetTextReplacement(string srcText, int index, out GetTextReplacementResult result)
        {
            /*HRESULT GetTextReplacement(
            [In, MarshalAs(UnmanagedType.LPStr)] string SrcText,
            [In] int Index,
            [SRI.Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U1, SizeParamIndex = 3)] byte[] SrcBuffer,
            [In] int SrcBufferSize,
            [Out] out int SrcSize,
            [SRI.Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U1, SizeParamIndex = 6)] byte[] DstBuffer,
            [In] int DstBufferSize,
            [Out] out int DstSize);*/
            byte[] srcBuffer;
            int srcBufferSize = 0;
            int srcSize;
            byte[] dstBuffer;
            int dstBufferSize = 0;
            int dstSize;
            HRESULT hr = Raw2.GetTextReplacement(srcText, index, null, srcBufferSize, out srcSize, null, dstBufferSize, out dstSize);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER && hr != HRESULT.S_OK)
                goto fail;

            srcBufferSize = srcSize;
            srcBuffer = new byte[srcBufferSize];
            dstBufferSize = dstSize;
            dstBuffer = new byte[dstBufferSize];
            hr = Raw2.GetTextReplacement(srcText, index, srcBuffer, srcBufferSize, out srcSize, dstBuffer, dstBufferSize, out dstSize);

            if (hr == HRESULT.S_OK)
            {
                result = new GetTextReplacementResult(CreateString(srcBuffer, srcSize), CreateString(dstBuffer, dstSize));

                return hr;
            }

            fail:
            result = default(GetTextReplacementResult);

            return hr;
        }

        #endregion
        #region SetTextReplacement

        /// <summary>
        /// The SetTextReplacement method sets the value of a user-named alias.
        /// </summary>
        /// <param name="srcText">[in] Specifies the name of the user-named alias. The debugger engine makes a copy of this string. If SrcText is the same as the name of an automatic alias, the automatic alias is hidden by the new user-named alias.</param>
        /// <param name="dstText">[in, optional] Specifies the value of the user-named alias. The debugger engine makes a copy of this string. If DstText is NULL, the user-named alias is removed.</param>
        /// <remarks>
        /// Before executing commands or evaluating expressions, the debugger engine will replace the alias specified by SrcText
        /// with the value of the alias (specified by DstText). If SrcText is an asterisk (*) and DstText is NULL, all user-named
        /// aliases are removed. This is the same behavior as the <see cref="RemoveTextReplacements"/> method. When an alias
        /// is changed by this method, the event callbacks are notified by passing the DEBUG_CES_TEXT_REPLACEMENTS flag to
        /// the <see cref="IDebugEventCallbacks.ChangeEngineState"/> callback method. For an overview of aliases used by the
        /// debugger engine, see Using Aliases. For more information about using aliases with the debugger engine API, see
        /// Interacting with the Engine.
        /// </remarks>
        public void SetTextReplacement(string srcText, string dstText)
        {
            TrySetTextReplacement(srcText, dstText).ThrowDbgEngNotOK();
        }

        /// <summary>
        /// The SetTextReplacement method sets the value of a user-named alias.
        /// </summary>
        /// <param name="srcText">[in] Specifies the name of the user-named alias. The debugger engine makes a copy of this string. If SrcText is the same as the name of an automatic alias, the automatic alias is hidden by the new user-named alias.</param>
        /// <param name="dstText">[in, optional] Specifies the value of the user-named alias. The debugger engine makes a copy of this string. If DstText is NULL, the user-named alias is removed.</param>
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
        public HRESULT TrySetTextReplacement(string srcText, string dstText)
        {
            /*HRESULT SetTextReplacement(
            [In, MarshalAs(UnmanagedType.LPStr)] string SrcText,
            [In, MarshalAs(UnmanagedType.LPStr)] string DstText);*/
            return Raw2.SetTextReplacement(srcText, dstText);
        }

        #endregion
        #region RemoveTextReplacements

        /// <summary>
        /// The RemoveTextReplacements method removes all user-named aliases.
        /// </summary>
        /// <remarks>
        /// For an overview of aliases used by the debugger engine, see Using Aliases. For more information about using aliases
        /// with the debugger engine API, see Interacting with the Engine.
        /// </remarks>
        public void RemoveTextReplacements()
        {
            TryRemoveTextReplacements().ThrowDbgEngNotOK();
        }

        /// <summary>
        /// The RemoveTextReplacements method removes all user-named aliases.
        /// </summary>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// For an overview of aliases used by the debugger engine, see Using Aliases. For more information about using aliases
        /// with the debugger engine API, see Interacting with the Engine.
        /// </remarks>
        public HRESULT TryRemoveTextReplacements()
        {
            /*HRESULT RemoveTextReplacements();*/
            return Raw2.RemoveTextReplacements();
        }

        #endregion
        #region OutputTextReplacements

        /// <summary>
        /// The OutputTextReplacements method prints all the currently defined user-named aliases to the debugger's output stream.
        /// </summary>
        /// <param name="outputControl">[in] Specifies the output control to use when printing the aliases. For possible values, see DEBUG_OUTCTL_XXX.</param>
        /// <param name="flags">[in] Must be set to DEBUG_OUT_TEXT_REPL_DEFAULT.</param>
        /// <remarks>
        /// For an overview of aliases used by the debugger engine, see Using Aliases. For more information about using aliases
        /// with the debugger engine API, see Interacting with the Engine.
        /// </remarks>
        public void OutputTextReplacements(DEBUG_OUTCTL outputControl, DEBUG_OUT_TEXT_REPL flags)
        {
            TryOutputTextReplacements(outputControl, flags).ThrowDbgEngNotOK();
        }

        /// <summary>
        /// The OutputTextReplacements method prints all the currently defined user-named aliases to the debugger's output stream.
        /// </summary>
        /// <param name="outputControl">[in] Specifies the output control to use when printing the aliases. For possible values, see DEBUG_OUTCTL_XXX.</param>
        /// <param name="flags">[in] Must be set to DEBUG_OUT_TEXT_REPL_DEFAULT.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// For an overview of aliases used by the debugger engine, see Using Aliases. For more information about using aliases
        /// with the debugger engine API, see Interacting with the Engine.
        /// </remarks>
        public HRESULT TryOutputTextReplacements(DEBUG_OUTCTL outputControl, DEBUG_OUT_TEXT_REPL flags)
        {
            /*HRESULT OutputTextReplacements(
            [In] DEBUG_OUTCTL OutputControl,
            [In] DEBUG_OUT_TEXT_REPL Flags);*/
            return Raw2.OutputTextReplacements(outputControl, flags);
        }

        #endregion
        #endregion
        #region IDebugControl3

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public IDebugControl3 Raw3 => (IDebugControl3) Raw;

        #region AssemblyOptions

        /// <summary>
        /// The GetAssemblyOptions method returns the assembly and disassembly options that affect how the debugger engine assembles and disassembles processor instructions for the target.
        /// </summary>
        public DEBUG_ASMOPT AssemblyOptions
        {
            get
            {
                DEBUG_ASMOPT options;
                TryGetAssemblyOptions(out options).ThrowDbgEngNotOK();

                return options;
            }
            set
            {
                TrySetAssemblyOptions(value).ThrowDbgEngNotOK();
            }
        }

        /// <summary>
        /// The GetAssemblyOptions method returns the assembly and disassembly options that affect how the debugger engine assembles and disassembles processor instructions for the target.
        /// </summary>
        /// <param name="options">[out] Receives a bit-set that contains the assembly and disassembly options. For a description of these options, see DEBUG_ASMOPT_XXX.</param>
        /// <returns>This method can also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// For more information about using assembly with the debugger engine API, see Assembling and Disassembling Instructions.
        /// </remarks>
        public HRESULT TryGetAssemblyOptions(out DEBUG_ASMOPT options)
        {
            /*HRESULT GetAssemblyOptions(
            [Out] out DEBUG_ASMOPT Options);*/
            return Raw3.GetAssemblyOptions(out options);
        }

        /// <summary>
        /// The SetAssemblyOptions method sets the assembly and disassembly options that affect how the debugger engine assembles and disassembles processor instructions for the target.
        /// </summary>
        /// <param name="options">[in] Specifies the new assembly and disassembly options to be used by the debugger engine. Options is a bit-set; it will replace the existing assembly and disassembly options.<para/>
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
        public HRESULT TrySetAssemblyOptions(DEBUG_ASMOPT options)
        {
            /*HRESULT SetAssemblyOptions(
            [In] DEBUG_ASMOPT Options);*/
            return Raw3.SetAssemblyOptions(options);
        }

        #endregion
        #region ExpressionSyntax

        /// <summary>
        /// The GetExpressionSyntax method returns the current syntax that the engine is using for evaluating expressions.
        /// </summary>
        public DEBUG_EXPR ExpressionSyntax
        {
            get
            {
                DEBUG_EXPR flags;
                TryGetExpressionSyntax(out flags).ThrowDbgEngNotOK();

                return flags;
            }
            set
            {
                TrySetExpressionSyntax(value).ThrowDbgEngNotOK();
            }
        }

        /// <summary>
        /// The GetExpressionSyntax method returns the current syntax that the engine is using for evaluating expressions.
        /// </summary>
        /// <param name="flags">[out] Receives the expression syntax. It is set to one of the following values: Expressions will be evaluated according to MASM syntax.<para/>
        /// For details of this syntax, see MASM Numbers and Operators. Expressions will be evaluated according to C++ syntax.<para/>
        /// For details of this syntax, see C++ Numbers and Operators.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        public HRESULT TryGetExpressionSyntax(out DEBUG_EXPR flags)
        {
            /*HRESULT GetExpressionSyntax(
            [Out] out DEBUG_EXPR Flags);*/
            return Raw3.GetExpressionSyntax(out flags);
        }

        /// <summary>
        /// The SetExpressionSyntax method sets the syntax that the engine will use to evaluate expressions.
        /// </summary>
        /// <param name="flags">[in] Specifies the syntax that the engine will use to evaluate expressions. It can be one of the following values: Expressions will be evaluated according to MASM syntax.<para/>
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
        public HRESULT TrySetExpressionSyntax(DEBUG_EXPR flags)
        {
            /*HRESULT SetExpressionSyntax(
            [In] DEBUG_EXPR Flags);*/
            return Raw3.SetExpressionSyntax(flags);
        }

        #endregion
        #region NumberExpressionSyntaxes

        /// <summary>
        /// The GetNumberExpressionSyntaxes method returns the number of expression syntaxes that are supported by the engine.
        /// </summary>
        public int NumberExpressionSyntaxes
        {
            get
            {
                int number;
                TryGetNumberExpressionSyntaxes(out number).ThrowDbgEngNotOK();

                return number;
            }
        }

        /// <summary>
        /// The GetNumberExpressionSyntaxes method returns the number of expression syntaxes that are supported by the engine.
        /// </summary>
        /// <param name="number">[out] Receives the number of expression syntaxes.</param>
        /// <returns>This method can also return error values. See Return Values for more details.</returns>
        public HRESULT TryGetNumberExpressionSyntaxes(out int number)
        {
            /*HRESULT GetNumberExpressionSyntaxes(
            [Out] out int Number);*/
            return Raw3.GetNumberExpressionSyntaxes(out number);
        }

        #endregion
        #region NumberEvents

        /// <summary>
        /// The GetNumberEvents method returns the number of events for the current target, if the number of events is fixed.
        /// </summary>
        public int NumberEvents
        {
            get
            {
                int events;
                TryGetNumberEvents(out events).ThrowDbgEngNotOK();

                return events;
            }
        }

        /// <summary>
        /// The GetNumberEvents method returns the number of events for the current target, if the number of events is fixed.
        /// </summary>
        /// <param name="events">[out] Receives the number of events stored in the target. If the target offers multiple events, Events will be set to the number of events available.<para/>
        /// Otherwise, Events will be set to one.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// Crash dump files contain a static list of events; each event represents a snapshot of the target at a particular
        /// point in time. If the current target is a crash dump file, this method sets Events to the number of stored events
        /// and returns S_OK. Live targets generate events dynamically and do not necessarily have a known set of events. If
        /// the current target is a live target with unconstrained number of events, this method sets Events to the number
        /// of events currently available and returns S_FALSE. For more information, see the topic Event Information.
        /// </remarks>
        public HRESULT TryGetNumberEvents(out int events)
        {
            /*HRESULT GetNumberEvents(
            [Out] out int Events);*/
            return Raw3.GetNumberEvents(out events);
        }

        #endregion
        #region CurrentEventIndex

        /// <summary>
        /// The GetCurrentEventIndex method returns the index of the current event within the current list of events for the current target, if such a list exists.
        /// </summary>
        public int CurrentEventIndex
        {
            get
            {
                int index;
                TryGetCurrentEventIndex(out index).ThrowDbgEngNotOK();

                return index;
            }
        }

        /// <summary>
        /// The GetCurrentEventIndex method returns the index of the current event within the current list of events for the current target, if such a list exists.
        /// </summary>
        /// <param name="index">[out] Receives the index of the current event in the target. The index will be a number between zero and one less than the number of events returned by <see cref="NumberEvents"/>.<para/>
        /// The index of the first event is zero.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// Targets that do not have fixed sets of events will always return zero to Index.
        /// </remarks>
        public HRESULT TryGetCurrentEventIndex(out int index)
        {
            /*HRESULT GetCurrentEventIndex(
            [Out] out int Index);*/
            return Raw3.GetCurrentEventIndex(out index);
        }

        #endregion
        #region AddAssemblyOptions

        /// <summary>
        /// The AddAssemblyOptions method turns on some of the assembly and disassembly options.
        /// </summary>
        /// <param name="options">[in] Specifies the assembly and disassembly options to turn on. Options is a bit-set that will be combined with the existing engine options using the bitwise OR operator.<para/>
        /// For a description of the options, see DEBUG_ASMOPT_XXX.</param>
        /// <remarks>
        /// For more information about using assembly with the debugger engine API, see Assembling and Disassembling Instructions.
        /// </remarks>
        public void AddAssemblyOptions(DEBUG_ASMOPT options)
        {
            TryAddAssemblyOptions(options).ThrowDbgEngNotOK();
        }

        /// <summary>
        /// The AddAssemblyOptions method turns on some of the assembly and disassembly options.
        /// </summary>
        /// <param name="options">[in] Specifies the assembly and disassembly options to turn on. Options is a bit-set that will be combined with the existing engine options using the bitwise OR operator.<para/>
        /// For a description of the options, see DEBUG_ASMOPT_XXX.</param>
        /// <returns>These methods can also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// For more information about using assembly with the debugger engine API, see Assembling and Disassembling Instructions.
        /// </remarks>
        public HRESULT TryAddAssemblyOptions(DEBUG_ASMOPT options)
        {
            /*HRESULT AddAssemblyOptions(
            [In] DEBUG_ASMOPT Options);*/
            return Raw3.AddAssemblyOptions(options);
        }

        #endregion
        #region RemoveAssemblyOptions

        /// <summary>
        /// The RemoveAssemblyOptions method turns off some of the assembly and disassembly options.
        /// </summary>
        /// <param name="options">[in] Specifies the assembly and disassembly options to turn off. Options is a bit-set; the new value of the engine's options will equal the bitwise NOT of Options combined with the old value by using the bitwise AND operator.<para/>
        /// For a description of the assembly and disassembly options, see DEBUG_ASMOPT_XXX.</param>
        /// <remarks>
        /// For more information about using assembly with the debugger engine API, see Assembling and Disassembling Instructions.
        /// </remarks>
        public void RemoveAssemblyOptions(DEBUG_ASMOPT options)
        {
            TryRemoveAssemblyOptions(options).ThrowDbgEngNotOK();
        }

        /// <summary>
        /// The RemoveAssemblyOptions method turns off some of the assembly and disassembly options.
        /// </summary>
        /// <param name="options">[in] Specifies the assembly and disassembly options to turn off. Options is a bit-set; the new value of the engine's options will equal the bitwise NOT of Options combined with the old value by using the bitwise AND operator.<para/>
        /// For a description of the assembly and disassembly options, see DEBUG_ASMOPT_XXX.</param>
        /// <returns>This method can also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// For more information about using assembly with the debugger engine API, see Assembling and Disassembling Instructions.
        /// </remarks>
        public HRESULT TryRemoveAssemblyOptions(DEBUG_ASMOPT options)
        {
            /*HRESULT RemoveAssemblyOptions(
            [In] DEBUG_ASMOPT Options);*/
            return Raw3.RemoveAssemblyOptions(options);
        }

        #endregion
        #region SetExpressionSyntaxByName

        /// <summary>
        /// The SetExpressionSyntaxByName method sets the syntax that the engine will use to evaluate expressions.
        /// </summary>
        /// <param name="abbrevName">[in] Specifies the abbreviated name of the syntax. It can be one of the following strings: Expressions will be evaluated according to C++ syntax.<para/>
        /// For details of this syntax, see C++ Numbers and Operators. Expressions will be evaluated according to MASM syntax.<para/>
        /// For details of this syntax, see MASM Numbers and Operators.</param>
        /// <remarks>
        /// The expression syntax is a global setting within the engine, so setting the expression syntax will affect all clients.
        /// The expression syntax of the engine determines how the engine will interpret expressions passed to <see cref="Evaluate"/>,
        /// <see cref="Execute"/>, and any other method that evaluates an expression. After the expression syntax has been
        /// changed, the engine sends out notification to the <see cref="IDebugEventCallbacks"/> callback object registered
        /// with each client. It also passes the DEBUG_CES_EXPRESSION_SYNTAX flag to the <see cref="IDebugEventCallbacks.ChangeEngineState"/>
        /// method.
        /// </remarks>
        public void SetExpressionSyntaxByName(string abbrevName)
        {
            TrySetExpressionSyntaxByName(abbrevName).ThrowDbgEngNotOK();
        }

        /// <summary>
        /// The SetExpressionSyntaxByName method sets the syntax that the engine will use to evaluate expressions.
        /// </summary>
        /// <param name="abbrevName">[in] Specifies the abbreviated name of the syntax. It can be one of the following strings: Expressions will be evaluated according to C++ syntax.<para/>
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
        public HRESULT TrySetExpressionSyntaxByName(string abbrevName)
        {
            /*HRESULT SetExpressionSyntaxByName(
            [In, MarshalAs(UnmanagedType.LPStr)] string AbbrevName);*/
            return Raw3.SetExpressionSyntaxByName(abbrevName);
        }

        #endregion
        #region GetExpressionSyntaxNames

        /// <summary>
        /// The GetExpressionSyntaxNames method returns the full and abbreviated names of an expression syntax.
        /// </summary>
        /// <param name="index">[in] Specifies the index of the expression syntax. Index should be between zero and the number of expression syntaxes returned by <see cref="NumberExpressionSyntaxes"/> minus one.</param>
        /// <returns>The values that were emitted from the COM method.</returns>
        /// <remarks>
        /// Currently, there are two expression syntaxes, their full names are "Microsoft Assembler expressions" and "C++ source
        /// expressions." The corresponding abbreviated expression syntaxes are "MASM" and "C++."
        /// </remarks>
        public GetExpressionSyntaxNamesResult GetExpressionSyntaxNames(int index)
        {
            GetExpressionSyntaxNamesResult result;
            TryGetExpressionSyntaxNames(index, out result).ThrowDbgEngNotOK();

            return result;
        }

        /// <summary>
        /// The GetExpressionSyntaxNames method returns the full and abbreviated names of an expression syntax.
        /// </summary>
        /// <param name="index">[in] Specifies the index of the expression syntax. Index should be between zero and the number of expression syntaxes returned by <see cref="NumberExpressionSyntaxes"/> minus one.</param>
        /// <param name="result">The values that were emitted from the COM method.</param>
        /// <returns>This method can also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// Currently, there are two expression syntaxes, their full names are "Microsoft Assembler expressions" and "C++ source
        /// expressions." The corresponding abbreviated expression syntaxes are "MASM" and "C++."
        /// </remarks>
        public HRESULT TryGetExpressionSyntaxNames(int index, out GetExpressionSyntaxNamesResult result)
        {
            /*HRESULT GetExpressionSyntaxNames(
            [In] int Index,
            [SRI.Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U1, SizeParamIndex = 2)] byte[] FullNameBuffer,
            [In] int FullNameBufferSize,
            [Out] out int FullNameSize,
            [SRI.Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U1, SizeParamIndex = 5)] byte[] AbbrevNameBuffer,
            [In] int AbbrevNameBufferSize,
            [Out] out int AbbrevNameSize);*/
            byte[] fullNameBuffer;
            int fullNameBufferSize = 0;
            int fullNameSize;
            byte[] abbrevNameBuffer;
            int abbrevNameBufferSize = 0;
            int abbrevNameSize;
            HRESULT hr = Raw3.GetExpressionSyntaxNames(index, null, fullNameBufferSize, out fullNameSize, null, abbrevNameBufferSize, out abbrevNameSize);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER && hr != HRESULT.S_OK)
                goto fail;

            fullNameBufferSize = fullNameSize;
            fullNameBuffer = new byte[fullNameBufferSize];
            abbrevNameBufferSize = abbrevNameSize;
            abbrevNameBuffer = new byte[abbrevNameBufferSize];
            hr = Raw3.GetExpressionSyntaxNames(index, fullNameBuffer, fullNameBufferSize, out fullNameSize, abbrevNameBuffer, abbrevNameBufferSize, out abbrevNameSize);

            if (hr == HRESULT.S_OK)
            {
                result = new GetExpressionSyntaxNamesResult(CreateString(fullNameBuffer, fullNameSize), CreateString(abbrevNameBuffer, abbrevNameSize));

                return hr;
            }

            fail:
            result = default(GetExpressionSyntaxNamesResult);

            return hr;
        }

        #endregion
        #region GetEventIndexDescription

        /// <summary>
        /// The GetEventIndexDescription method describes the specified event in a static list of events for the current target.
        /// </summary>
        /// <param name="index">[in] Specifies the index of the event whose description will be returned.</param>
        /// <param name="which">[in] Specifies which piece of the event description to return. Currently only DEBUG_EINDEX_NAME is supported; this returns the name of the event.</param>
        /// <returns>[in, optional] Receives the description of the event. If Buffer is NULL, this information is not returned.</returns>
        /// <remarks>
        /// The amount of descriptive information available for a particular target varies depending on the type of the target.
        /// </remarks>
        public string GetEventIndexDescription(int index, DEBUG_EINDEX which)
        {
            string bufferResult;
            TryGetEventIndexDescription(index, which, out bufferResult).ThrowDbgEngNotOK();

            return bufferResult;
        }

        /// <summary>
        /// The GetEventIndexDescription method describes the specified event in a static list of events for the current target.
        /// </summary>
        /// <param name="index">[in] Specifies the index of the event whose description will be returned.</param>
        /// <param name="which">[in] Specifies which piece of the event description to return. Currently only DEBUG_EINDEX_NAME is supported; this returns the name of the event.</param>
        /// <param name="bufferResult">[in, optional] Receives the description of the event. If Buffer is NULL, this information is not returned.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// The amount of descriptive information available for a particular target varies depending on the type of the target.
        /// </remarks>
        public HRESULT TryGetEventIndexDescription(int index, DEBUG_EINDEX which, out string bufferResult)
        {
            /*HRESULT GetEventIndexDescription(
            [In] int Index,
            [In] DEBUG_EINDEX Which,
            [SRI.Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U1, SizeParamIndex = 3)] byte[] Buffer,
            [In] int BufferSize,
            [Out] out int DescSize);*/
            byte[] buffer;
            int bufferSize = 0;
            int descSize;
            HRESULT hr = Raw3.GetEventIndexDescription(index, which, null, bufferSize, out descSize);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER && hr != HRESULT.S_OK)
                goto fail;

            bufferSize = descSize;
            buffer = new byte[bufferSize];
            hr = Raw3.GetEventIndexDescription(index, which, buffer, bufferSize, out descSize);

            if (hr == HRESULT.S_OK)
            {
                bufferResult = CreateString(buffer, descSize);

                return hr;
            }

            fail:
            bufferResult = default(string);

            return hr;
        }

        #endregion
        #region SetNextEventIndex

        /// <summary>
        /// The SetNextEventIndex method sets the next event for the current target by selecting the event from the static list of events for the target, if such a list exists.
        /// </summary>
        /// <param name="relation">[in] Specifies how to interpret Value when setting the index of the next event. Possible values are: DEBUG_EINDEX_FROM_START, DEBUG_EINDEX_FROM_END, and DEBUG_EINDEX_FROM_CURRENT.</param>
        /// <param name="value">[in] Specifies the index of the next event relative to the first, last, or current event. The interpretation of Value depends on the value of Relation, as follows.<para/>
        /// The resulting index must be greater than zero and one less than the number of events returned by <see cref="NumberEvents"/>.</param>
        /// <returns>[out] Receives the index of the next event. If NextIndex is NULL, this information is not returned.</returns>
        /// <remarks>
        /// If the specified event is the same as the current event, this method does nothing. Otherwise, this method sets
        /// the execution status of the target to DEBUG_STATUS_GO (and notifies the event callbacks). When <see cref="WaitForEvent"/>
        /// is called, the engine will generate the specified event for the event callbacks and set it as the current event.
        /// This method is only useful if the target offers a list of events.
        /// </remarks>
        public int SetNextEventIndex(DEBUG_EINDEX relation, int value)
        {
            int nextIndex;
            TrySetNextEventIndex(relation, value, out nextIndex).ThrowDbgEngNotOK();

            return nextIndex;
        }

        /// <summary>
        /// The SetNextEventIndex method sets the next event for the current target by selecting the event from the static list of events for the target, if such a list exists.
        /// </summary>
        /// <param name="relation">[in] Specifies how to interpret Value when setting the index of the next event. Possible values are: DEBUG_EINDEX_FROM_START, DEBUG_EINDEX_FROM_END, and DEBUG_EINDEX_FROM_CURRENT.</param>
        /// <param name="value">[in] Specifies the index of the next event relative to the first, last, or current event. The interpretation of Value depends on the value of Relation, as follows.<para/>
        /// The resulting index must be greater than zero and one less than the number of events returned by <see cref="NumberEvents"/>.</param>
        /// <param name="nextIndex">[out] Receives the index of the next event. If NextIndex is NULL, this information is not returned.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// If the specified event is the same as the current event, this method does nothing. Otherwise, this method sets
        /// the execution status of the target to DEBUG_STATUS_GO (and notifies the event callbacks). When <see cref="WaitForEvent"/>
        /// is called, the engine will generate the specified event for the event callbacks and set it as the current event.
        /// This method is only useful if the target offers a list of events.
        /// </remarks>
        public HRESULT TrySetNextEventIndex(DEBUG_EINDEX relation, int value, out int nextIndex)
        {
            /*HRESULT SetNextEventIndex(
            [In] DEBUG_EINDEX Relation,
            [In] int Value,
            [Out] out int NextIndex);*/
            return Raw3.SetNextEventIndex(relation, value, out nextIndex);
        }

        #endregion
        #endregion
        #region IDebugControl4

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public IDebugControl4 Raw4 => (IDebugControl4) Raw;

        #region LogFileWide

        /// <summary>
        /// The GetLogFileWide method returns the name of the currently open log file.
        /// </summary>
        public GetLogFileWideResult LogFileWide
        {
            get
            {
                GetLogFileWideResult result;
                TryGetLogFileWide(out result).ThrowDbgEngNotOK();

                return result;
            }
        }

        /// <summary>
        /// The GetLogFileWide method returns the name of the currently open log file.
        /// </summary>
        /// <param name="result">The values that were emitted from the COM method.</param>
        /// <returns>This method can also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// GetLogFile and GetLogFileWide behave the same way as <see cref="LogFile2"/> and GetLogFile2Wide with Append
        /// receiving only the information about the DEBUG_LOG_APPEND flag. For more information about log files, see Using
        /// Input and Output.
        /// </remarks>
        public HRESULT TryGetLogFileWide(out GetLogFileWideResult result)
        {
            /*HRESULT GetLogFileWide(
            [SRI.Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U2, SizeParamIndex = 1)] char[] Buffer,
            [In] int BufferSize,
            [Out] out int FileSize,
            [Out, MarshalAs(UnmanagedType.Bool)] out bool Append);*/
            char[] buffer;
            int bufferSize = 0;
            int fileSize;
            bool append;
            HRESULT hr = Raw4.GetLogFileWide(null, bufferSize, out fileSize, out append);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER && hr != HRESULT.S_OK)
                goto fail;

            bufferSize = fileSize;
            buffer = new char[bufferSize];
            hr = Raw4.GetLogFileWide(buffer, bufferSize, out fileSize, out append);

            if (hr == HRESULT.S_OK)
            {
                result = new GetLogFileWideResult(CreateString(buffer, fileSize), append);

                return hr;
            }

            fail:
            result = default(GetLogFileWideResult);

            return hr;
        }

        #endregion
        #region PromptTextWide

        /// <summary>
        /// The GetPromptTextWide method returns the standard prompt text that will be prepended to the formatted output specified in the OutputPrompt and <see cref="OutputPromptVaList"/> methods.
        /// </summary>
        public string PromptTextWide
        {
            get
            {
                string bufferResult;
                TryGetPromptTextWide(out bufferResult).ThrowDbgEngNotOK();

                return bufferResult;
            }
        }

        /// <summary>
        /// The GetPromptTextWide method returns the standard prompt text that will be prepended to the formatted output specified in the OutputPrompt and <see cref="OutputPromptVaList"/> methods.
        /// </summary>
        /// <param name="bufferResult">[out, optional] Receives the prompt text. If Buffer is NULL, this information is not returned.</param>
        /// <returns>This method can also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// For more information about prompting the user, see Using Input and Output.
        /// </remarks>
        public HRESULT TryGetPromptTextWide(out string bufferResult)
        {
            /*HRESULT GetPromptTextWide(
            [SRI.Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U2, SizeParamIndex = 1)] char[] Buffer,
            [In] int BufferSize,
            [Out] out int TextSize);*/
            char[] buffer;
            int bufferSize = 0;
            int textSize;
            HRESULT hr = Raw4.GetPromptTextWide(null, bufferSize, out textSize);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER && hr != HRESULT.S_OK)
                goto fail;

            bufferSize = textSize;
            buffer = new char[bufferSize];
            hr = Raw4.GetPromptTextWide(buffer, bufferSize, out textSize);

            if (hr == HRESULT.S_OK)
            {
                bufferResult = CreateString(buffer, textSize);

                return hr;
            }

            fail:
            bufferResult = default(string);

            return hr;
        }

        #endregion
        #region LastEventInformationWide

        /// <summary>
        /// The GetLastEventInformationWide method returns information about the last event that occurred in a target.
        /// </summary>
        public GetLastEventInformationWideResult LastEventInformationWide
        {
            get
            {
                GetLastEventInformationWideResult result;
                TryGetLastEventInformationWide(out result).ThrowDbgEngNotOK();

                return result;
            }
        }

        /// <summary>
        /// The GetLastEventInformationWide method returns information about the last event that occurred in a target.
        /// </summary>
        /// <param name="result">The values that were emitted from the COM method.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// For thread and process creation events, the thread ID and process ID returned to ThreadId and ProcessId are for
        /// the newly created thread or process. For more information about the last event, see the topic Event Information.
        /// </remarks>
        public HRESULT TryGetLastEventInformationWide(out GetLastEventInformationWideResult result)
        {
            /*HRESULT GetLastEventInformationWide(
            [Out] out DEBUG_EVENT_TYPE Type,
            [Out] out int ProcessId,
            [Out] out int ThreadId,
            [Out, ComAliasName("IntPtr")] out DEBUG_LAST_EVENT_INFO ExtraInformation,
            [In] int ExtraInformationSize,
            [Out] out int ExtraInformationUsed,
            [SRI.Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U2, SizeParamIndex = 7)] char[] Description,
            [In] int DescriptionSize,
            [Out] out int DescriptionUsed);*/
            DEBUG_EVENT_TYPE type;
            int processId;
            int threadId;
            DEBUG_LAST_EVENT_INFO extraInformation;
            int extraInformationSize = Marshal.SizeOf<DEBUG_LAST_EVENT_INFO>();
            int extraInformationUsed;
            char[] description;
            int descriptionSize = 0;
            int descriptionUsed;
            HRESULT hr = Raw4.GetLastEventInformationWide(out type, out processId, out threadId, out extraInformation, extraInformationSize, out extraInformationUsed, null, descriptionSize, out descriptionUsed);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER && hr != HRESULT.S_OK)
                goto fail;

            descriptionSize = descriptionUsed;
            description = new char[descriptionSize];
            hr = Raw4.GetLastEventInformationWide(out type, out processId, out threadId, out extraInformation, extraInformationSize, out extraInformationUsed, description, descriptionSize, out descriptionUsed);

            if (hr == HRESULT.S_OK)
            {
                result = new GetLastEventInformationWideResult(type, processId, threadId, extraInformation, CreateString(description, descriptionUsed));

                return hr;
            }

            fail:
            result = default(GetLastEventInformationWideResult);

            return hr;
        }

        #endregion
        #region LogFile2

        /// <summary>
        /// The GetLogFile2 method returns the name of the currently open log file.
        /// </summary>
        public GetLogFile2Result LogFile2
        {
            get
            {
                GetLogFile2Result result;
                TryGetLogFile2(out result).ThrowDbgEngNotOK();

                return result;
            }
        }

        /// <summary>
        /// The GetLogFile2 method returns the name of the currently open log file.
        /// </summary>
        /// <param name="result">The values that were emitted from the COM method.</param>
        /// <returns>This method can also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// For more information about log files, see Using Input and Output.
        /// </remarks>
        public HRESULT TryGetLogFile2(out GetLogFile2Result result)
        {
            /*HRESULT GetLogFile2(
            [SRI.Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U1, SizeParamIndex = 1)] byte[] Buffer,
            [In] int BufferSize,
            [Out] out int FileSize,
            [Out] out DEBUG_LOG Flags);*/
            byte[] buffer;
            int bufferSize = 0;
            int fileSize;
            DEBUG_LOG flags;
            HRESULT hr = Raw4.GetLogFile2(null, bufferSize, out fileSize, out flags);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER && hr != HRESULT.S_OK)
                goto fail;

            bufferSize = fileSize;
            buffer = new byte[bufferSize];
            hr = Raw4.GetLogFile2(buffer, bufferSize, out fileSize, out flags);

            if (hr == HRESULT.S_OK)
            {
                result = new GetLogFile2Result(CreateString(buffer, fileSize), flags);

                return hr;
            }

            fail:
            result = default(GetLogFile2Result);

            return hr;
        }

        #endregion
        #region LogFile2Wide

        /// <summary>
        /// The GetLogFile2Wide method returns the name of the currently open log file.
        /// </summary>
        public GetLogFile2WideResult LogFile2Wide
        {
            get
            {
                GetLogFile2WideResult result;
                TryGetLogFile2Wide(out result).ThrowDbgEngNotOK();

                return result;
            }
        }

        /// <summary>
        /// The GetLogFile2Wide method returns the name of the currently open log file.
        /// </summary>
        /// <param name="result">The values that were emitted from the COM method.</param>
        /// <returns>This method can also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// For more information about log files, see Using Input and Output.
        /// </remarks>
        public HRESULT TryGetLogFile2Wide(out GetLogFile2WideResult result)
        {
            /*HRESULT GetLogFile2Wide(
            [SRI.Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U2, SizeParamIndex = 1)] char[] Buffer,
            [In] int BufferSize,
            [Out] out int FileSize,
            [Out] out DEBUG_LOG Flags);*/
            char[] buffer;
            int bufferSize = 0;
            int fileSize;
            DEBUG_LOG flags;
            HRESULT hr = Raw4.GetLogFile2Wide(null, bufferSize, out fileSize, out flags);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER && hr != HRESULT.S_OK)
                goto fail;

            bufferSize = fileSize;
            buffer = new char[bufferSize];
            hr = Raw4.GetLogFile2Wide(buffer, bufferSize, out fileSize, out flags);

            if (hr == HRESULT.S_OK)
            {
                result = new GetLogFile2WideResult(CreateString(buffer, fileSize), flags);

                return hr;
            }

            fail:
            result = default(GetLogFile2WideResult);

            return hr;
        }

        #endregion
        #region SystemVersionValues

        /// <summary>
        /// The GetSystemVersionValues method returns version number information for the current target.
        /// </summary>
        public GetSystemVersionValuesResult SystemVersionValues
        {
            get
            {
                GetSystemVersionValuesResult result;
                TryGetSystemVersionValues(out result).ThrowDbgEngNotOK();

                return result;
            }
        }

        /// <summary>
        /// The GetSystemVersionValues method returns version number information for the current target.
        /// </summary>
        /// <param name="result">The values that were emitted from the COM method.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// For more information, see Target Information.
        /// </remarks>
        public HRESULT TryGetSystemVersionValues(out GetSystemVersionValuesResult result)
        {
            /*HRESULT GetSystemVersionValues(
            [Out] out int PlatformId,
            [Out] out int Win32Major,
            [Out] out int Win32Minor,
            [Out] out int KdMajor,
            [Out] out int KdMinor);*/
            int platformId;
            int win32Major;
            int win32Minor;
            int kdMajor;
            int kdMinor;
            HRESULT hr = Raw4.GetSystemVersionValues(out platformId, out win32Major, out win32Minor, out kdMajor, out kdMinor);

            if (hr == HRESULT.S_OK)
                result = new GetSystemVersionValuesResult(platformId, win32Major, win32Minor, kdMajor, kdMinor);
            else
                result = default(GetSystemVersionValuesResult);

            return hr;
        }

        #endregion
        #region OpenLogFileWide

        /// <summary>
        /// The OpenLogFileWide method opens a log file that will receive output from the client objects.
        /// </summary>
        /// <param name="file">[in] Specifies the name of the log file. File can include a relative or absolute path; relative paths are relative to the directory in which the debugger was started.<para/>
        /// If the file does not exist, it will be created.</param>
        /// <param name="append">[in] Specifies whether or not to append log messages to an existing log file. If TRUE, log messages will be appended to the file; if FALSE, the contents of any existing file matching File are discarded.</param>
        /// <remarks>
        /// OpenLogFile and OpenLogFileWide behave the same way as <see cref="OpenLogFile2"/> and OpenLogFile2Wide with Flags
        /// set to DEBUG_LOG_APPEND if Append is TRUE and DEBUG_LOG_DEFAULT otherwise. Only one log file can be open at a time.
        /// If there is already a log file open, it will be closed. For more information about log files, see Using Input and
        /// Output.
        /// </remarks>
        public void OpenLogFileWide(string file, bool append)
        {
            TryOpenLogFileWide(file, append).ThrowDbgEngNotOK();
        }

        /// <summary>
        /// The OpenLogFileWide method opens a log file that will receive output from the client objects.
        /// </summary>
        /// <param name="file">[in] Specifies the name of the log file. File can include a relative or absolute path; relative paths are relative to the directory in which the debugger was started.<para/>
        /// If the file does not exist, it will be created.</param>
        /// <param name="append">[in] Specifies whether or not to append log messages to an existing log file. If TRUE, log messages will be appended to the file; if FALSE, the contents of any existing file matching File are discarded.</param>
        /// <returns>This method can also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// OpenLogFile and OpenLogFileWide behave the same way as <see cref="OpenLogFile2"/> and OpenLogFile2Wide with Flags
        /// set to DEBUG_LOG_APPEND if Append is TRUE and DEBUG_LOG_DEFAULT otherwise. Only one log file can be open at a time.
        /// If there is already a log file open, it will be closed. For more information about log files, see Using Input and
        /// Output.
        /// </remarks>
        public HRESULT TryOpenLogFileWide(string file, bool append)
        {
            /*HRESULT OpenLogFileWide(
            [In, MarshalAs(UnmanagedType.LPWStr)] string File,
            [In, MarshalAs(UnmanagedType.Bool)] bool Append);*/
            return Raw4.OpenLogFileWide(file, append);
        }

        #endregion
        #region InputWide

        /// <summary>
        /// The InputWide method requests an input string from the debugger engine.
        /// </summary>
        /// <returns>[out] Receives the input string from the engine.</returns>
        /// <remarks>
        /// For an overview of input in the debugger engine, see Input and Output.
        /// </remarks>
        public string InputWide()
        {
            string bufferResult;
            TryInputWide(out bufferResult).ThrowDbgEngNotOK();

            return bufferResult;
        }

        /// <summary>
        /// The InputWide method requests an input string from the debugger engine.
        /// </summary>
        /// <param name="bufferResult">[out] Receives the input string from the engine.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// For an overview of input in the debugger engine, see Input and Output.
        /// </remarks>
        public HRESULT TryInputWide(out string bufferResult)
        {
            /*HRESULT InputWide(
            [SRI.Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U2, SizeParamIndex = 1)] char[] Buffer,
            [In] int BufferSize,
            [Out] out int InputSize);*/
            char[] buffer;
            int bufferSize = 0;
            int inputSize;
            HRESULT hr = Raw4.InputWide(null, bufferSize, out inputSize);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER && hr != HRESULT.S_OK)
                goto fail;

            bufferSize = inputSize;
            buffer = new char[bufferSize];
            hr = Raw4.InputWide(buffer, bufferSize, out inputSize);

            if (hr == HRESULT.S_OK)
            {
                bufferResult = CreateString(buffer, inputSize);

                return hr;
            }

            fail:
            bufferResult = default(string);

            return hr;
        }

        #endregion
        #region ReturnInputWide

        /// <summary>
        /// The ReturnInputWide method is used by IDebugInputCallbacks objects to send an input string to the engine following a request for input.
        /// </summary>
        /// <param name="buffer">[in] Specifies the input string being sent to the engine.</param>
        /// <remarks>
        /// For an overview of input in the debugger engine, see Input and Output.
        /// </remarks>
        public void ReturnInputWide(string buffer)
        {
            TryReturnInputWide(buffer).ThrowDbgEngNotOK();
        }

        /// <summary>
        /// The ReturnInputWide method is used by IDebugInputCallbacks objects to send an input string to the engine following a request for input.
        /// </summary>
        /// <param name="buffer">[in] Specifies the input string being sent to the engine.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// For an overview of input in the debugger engine, see Input and Output.
        /// </remarks>
        public HRESULT TryReturnInputWide(string buffer)
        {
            /*HRESULT ReturnInputWide(
            [In, MarshalAs(UnmanagedType.LPWStr)] string Buffer);*/
            return Raw4.ReturnInputWide(buffer);
        }

        #endregion
        #region OutputWide

        /// <summary>
        /// The OutputWide method formats a string and send the result to output callbacks that have been registered with the engine's clients.
        /// </summary>
        /// <param name="mask">[in] Specifies the output-type bit field. See DEBUG_OUTPUT_XXX for possible values.</param>
        /// <param name="format">[in] Specifies the format string, as in printf. In general, conversion characters work exactly as in C. For the floating-point conversion characters the 64-bit argument is interpreted as a 32-bit floating-point number unless the l modifier is used.<para/>
        /// The %p conversion character is supported, but it represents a pointer in a target's address space. It cannot have any modifiers and it uses the debugger's internal address formatting.<para/>
        /// The following additional conversion characters are supported.</param>
        /// <remarks>
        /// When generating very large output strings, it is possible to reach the limits of the debugger engine or of the
        /// operating system. For example, some versions of the debugger engine have a 16K character limit for a single output.
        /// If you find that very large output is getting truncated, you might need to split your output into multiple requests.
        /// </remarks>
        public void OutputWide(DEBUG_OUTPUT mask, string format)
        {
            TryOutputWide(mask, format).ThrowDbgEngNotOK();
        }

        /// <summary>
        /// The OutputWide method formats a string and send the result to output callbacks that have been registered with the engine's clients.
        /// </summary>
        /// <param name="mask">[in] Specifies the output-type bit field. See DEBUG_OUTPUT_XXX for possible values.</param>
        /// <param name="format">[in] Specifies the format string, as in printf. In general, conversion characters work exactly as in C. For the floating-point conversion characters the 64-bit argument is interpreted as a 32-bit floating-point number unless the l modifier is used.<para/>
        /// The %p conversion character is supported, but it represents a pointer in a target's address space. It cannot have any modifiers and it uses the debugger's internal address formatting.<para/>
        /// The following additional conversion characters are supported.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// When generating very large output strings, it is possible to reach the limits of the debugger engine or of the
        /// operating system. For example, some versions of the debugger engine have a 16K character limit for a single output.
        /// If you find that very large output is getting truncated, you might need to split your output into multiple requests.
        /// </remarks>
        public HRESULT TryOutputWide(DEBUG_OUTPUT mask, string format)
        {
            /*HRESULT OutputWide(
            [In] DEBUG_OUTPUT Mask,
            [In, MarshalAs(UnmanagedType.LPWStr)] string Format);*/
            return Raw4.OutputWide(mask, format);
        }

        #endregion
        #region OutputVaListWide

        /// <summary>
        /// The OutputVaListWide method formats a string and sends the result to the output callbacks that are registered with the engine's clients.
        /// </summary>
        /// <param name="mask">[in] Specifies the output-type bit field. See DEBUG_OUTPUT_XXX for possible values.</param>
        /// <param name="format">[in] Specifies the format string, as in printf. Typically, conversion characters work exactly as they do in C. For the floating-point conversion characters, the 64-bit argument is interpreted as a 32-bit floating-point number unless the l modifier is used.<para/>
        /// The %p conversion character is supported, but it represents a pointer in a target's address space. It might not have any modifiers, and it uses the debugger's internal address formatting.<para/>
        /// The following additional conversion characters are supported.</param>
        /// <param name="va_list_Args">[in] Specifies additional parameters that represent values to be inserted into the output during formatting. Args must be initialized using va_start.<para/>
        /// This method does not call va_end.</param>
        /// <remarks>
        /// When generating very large output strings, it is possible to reach the limits of the debugger engine or of the
        /// operating system. For example, some versions of the debugger engine have a 16K character limit for a single output.
        /// If you find that very large output is getting truncated, you might need to split your output into multiple requests.
        /// </remarks>
        [Obsolete("This method cannot be safely called from managed code")]
        public void OutputVaListWide(DEBUG_OUTPUT mask, string format, IntPtr va_list_Args)
        {
            TryOutputVaListWide(mask, format, va_list_Args).ThrowDbgEngNotOK();
        }

        /// <summary>
        /// The OutputVaListWide method formats a string and sends the result to the output callbacks that are registered with the engine's clients.
        /// </summary>
        /// <param name="mask">[in] Specifies the output-type bit field. See DEBUG_OUTPUT_XXX for possible values.</param>
        /// <param name="format">[in] Specifies the format string, as in printf. Typically, conversion characters work exactly as they do in C. For the floating-point conversion characters, the 64-bit argument is interpreted as a 32-bit floating-point number unless the l modifier is used.<para/>
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
        [Obsolete("This method cannot be safely called from managed code")]
        public HRESULT TryOutputVaListWide(DEBUG_OUTPUT mask, string format, IntPtr va_list_Args)
        {
            /*HRESULT OutputVaListWide(
            [In] DEBUG_OUTPUT Mask,
            [In, MarshalAs(UnmanagedType.LPWStr)] string Format,
            [In] IntPtr va_list_Args);*/
            return Raw4.OutputVaListWide(mask, format, va_list_Args);
        }

        #endregion
        #region ControlledOutputWide

        /// <summary>
        /// The ControlledOutputWide method formats a string and sends the result to output callbacks that were registered with some of the engine's clients.
        /// </summary>
        /// <param name="outputControl">[in] Specifies an output control that determines which of the clients' output callbacks will receive the output.<para/>
        /// For possible values, see DEBUG_OUTCTL_XXX. For more information about output, see Input and Output.</param>
        /// <param name="mask">[in] Specifies the output-type bit field. See DEBUG_OUTPUT_XXX for possible values.</param>
        /// <param name="format">[in] Specifies the format string, as in printf. Typically, conversion characters work exactly as they do in C. For the floating-point conversion characters, the 64-bit argument is interpreted as a 32-bit floating-point number unless the l modifier is used.<para/>
        /// The %p conversion character is supported, but it represents a pointer in a target's address space. It might not have any modifiers and it uses the debugger's internal address formatting.<para/>
        /// The following additional conversion characters are supported. The %Y format specifier can be used to support the Debugger Markup Language (DML).<para/>
        /// For more information, see Customizing Debugger Output Using DML. The following table summarizes the use of the %Y format specifier.<para/>
        /// This code snippet illustrates the use of the %Y format specifier. This sample code would generate the following output.</param>
        /// <remarks>
        /// When generating very large output strings, it is possible to reach the limits of the debugger engine or of the
        /// operating system. For example, some versions of the debugger engine have a 16K character limit for a single output.
        /// If you find that very large output is getting truncated, you might need to split your output into multiple requests.
        /// </remarks>
        public void ControlledOutputWide(DEBUG_OUTCTL outputControl, DEBUG_OUTPUT mask, string format)
        {
            TryControlledOutputWide(outputControl, mask, format).ThrowDbgEngNotOK();
        }

        /// <summary>
        /// The ControlledOutputWide method formats a string and sends the result to output callbacks that were registered with some of the engine's clients.
        /// </summary>
        /// <param name="outputControl">[in] Specifies an output control that determines which of the clients' output callbacks will receive the output.<para/>
        /// For possible values, see DEBUG_OUTCTL_XXX. For more information about output, see Input and Output.</param>
        /// <param name="mask">[in] Specifies the output-type bit field. See DEBUG_OUTPUT_XXX for possible values.</param>
        /// <param name="format">[in] Specifies the format string, as in printf. Typically, conversion characters work exactly as they do in C. For the floating-point conversion characters, the 64-bit argument is interpreted as a 32-bit floating-point number unless the l modifier is used.<para/>
        /// The %p conversion character is supported, but it represents a pointer in a target's address space. It might not have any modifiers and it uses the debugger's internal address formatting.<para/>
        /// The following additional conversion characters are supported. The %Y format specifier can be used to support the Debugger Markup Language (DML).<para/>
        /// For more information, see Customizing Debugger Output Using DML. The following table summarizes the use of the %Y format specifier.<para/>
        /// This code snippet illustrates the use of the %Y format specifier. This sample code would generate the following output.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// When generating very large output strings, it is possible to reach the limits of the debugger engine or of the
        /// operating system. For example, some versions of the debugger engine have a 16K character limit for a single output.
        /// If you find that very large output is getting truncated, you might need to split your output into multiple requests.
        /// </remarks>
        public HRESULT TryControlledOutputWide(DEBUG_OUTCTL outputControl, DEBUG_OUTPUT mask, string format)
        {
            /*HRESULT ControlledOutputWide(
            [In] DEBUG_OUTCTL OutputControl,
            [In] DEBUG_OUTPUT Mask,
            [In, MarshalAs(UnmanagedType.LPWStr)] string Format);*/
            return Raw4.ControlledOutputWide(outputControl, mask, format);
        }

        #endregion
        #region ControlledOutputVaListWide

        /// <summary>
        /// The ControlledOutputVaListWide method formats a string and sends the result to output callbacks that were registered with some of the engine's clients.
        /// </summary>
        /// <param name="outputControl">[in] Specifies an output control that determines which client's output callbacks will receive the output. For possible values, see DEBUG_OUTCTL_XXX.<para/>
        /// For more information about output, see Input and Output.</param>
        /// <param name="mask">[in] Specifies the output-type bit field. See DEBUG_OUTPUT_XXX for possible values.</param>
        /// <param name="format">[in] Specifies the format string, as in printf. Typically, conversion characters work exactly as they do in C. For the floating-point conversion characters, the 64-bit argument is interpreted as a 32-bit floating-point number unless the l modifier is used.<para/>
        /// The %p conversion character is supported, but it represents a pointer in a target's address space. It might not have any modifiers, and it uses the debugger's internal address formatting.<para/>
        /// The following additional conversion characters are supported. The %Y format specifier can be used to support the Debugger Markup Language (DML).<para/>
        /// For more information, see Customizing Debugger Output Using DML. The following table summarizes the use of the %Y format specifier.<para/>
        /// This code snippet illustrates the use of the %Y format specifier. This sample code would generate the following output.</param>
        /// <param name="va_list_Args">[in] Specifies additional parameters that represent values to be inserted into the output during formatting. Args must be initialized using va_start.<para/>
        /// This method does not call va_end.</param>
        /// <remarks>
        /// When generating very large output strings, it is possible to reach the limits of the debugger engine or of the
        /// operating system. For example, some versions of the debugger engine have a 16K character limit for a single output.
        /// If you find that very large output is getting truncated, you might need to split your output into multiple requests.
        /// The macros va_list, va_start, and va_end are defined in Stdarg.h.
        /// </remarks>
        [Obsolete("This method cannot be safely called from managed code")]
        public void ControlledOutputVaListWide(DEBUG_OUTCTL outputControl, DEBUG_OUTPUT mask, string format, IntPtr va_list_Args)
        {
            TryControlledOutputVaListWide(outputControl, mask, format, va_list_Args).ThrowDbgEngNotOK();
        }

        /// <summary>
        /// The ControlledOutputVaListWide method formats a string and sends the result to output callbacks that were registered with some of the engine's clients.
        /// </summary>
        /// <param name="outputControl">[in] Specifies an output control that determines which client's output callbacks will receive the output. For possible values, see DEBUG_OUTCTL_XXX.<para/>
        /// For more information about output, see Input and Output.</param>
        /// <param name="mask">[in] Specifies the output-type bit field. See DEBUG_OUTPUT_XXX for possible values.</param>
        /// <param name="format">[in] Specifies the format string, as in printf. Typically, conversion characters work exactly as they do in C. For the floating-point conversion characters, the 64-bit argument is interpreted as a 32-bit floating-point number unless the l modifier is used.<para/>
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
        [Obsolete("This method cannot be safely called from managed code")]
        public HRESULT TryControlledOutputVaListWide(DEBUG_OUTCTL outputControl, DEBUG_OUTPUT mask, string format, IntPtr va_list_Args)
        {
            /*HRESULT ControlledOutputVaListWide(
            [In] DEBUG_OUTCTL OutputControl,
            [In] DEBUG_OUTPUT Mask,
            [In, MarshalAs(UnmanagedType.LPWStr)] string Format,
            [In] IntPtr va_list_Args);*/
            return Raw4.ControlledOutputVaListWide(outputControl, mask, format, va_list_Args);
        }

        #endregion
        #region OutputPromptWide

        /// <summary>
        /// The OutputPromptWide method formats and sends a user prompt to the output callback objects.
        /// </summary>
        /// <param name="outputControl">[in] Specifies an output control that determines which of the client's output callbacks will receive the output.<para/>
        /// For possible values, see DEBUG_OUTCTL_XXX.</param>
        /// <param name="format">[in, optional] Specifies the format string, as in printf. Typically, conversion characters work exactly as they do in C.<para/>
        /// For the floating-point conversion characters, the 64-bit argument is interpreted as a 32-bit floating-point number unless the l modifier is used.<para/>
        /// The %p conversion character is supported, but it represents a pointer in a target's address space. It might not have any modifiers and it uses the debugger's internal address formatting.<para/>
        /// The following additional conversion characters are supported. If Format is NULL, only the standard prompt text is sent to the output callbacks.</param>
        /// <remarks>
        /// OutputPrompt and OutputPromptWide can be used to prompt the user for input. The standard prompt will be sent to
        /// the output callbacks before the formatted text described by Format. The contents of the standard prompt is returned
        /// by the method <see cref="PromptText"/>. The prompt text is sent to the output callbacks with the
        /// DEBUG_OUTPUT_PROMPT output mask set. For more information about prompting the user, see Using Input and Output.
        /// </remarks>
        public void OutputPromptWide(DEBUG_OUTCTL outputControl, string format)
        {
            TryOutputPromptWide(outputControl, format).ThrowDbgEngNotOK();
        }

        /// <summary>
        /// The OutputPromptWide method formats and sends a user prompt to the output callback objects.
        /// </summary>
        /// <param name="outputControl">[in] Specifies an output control that determines which of the client's output callbacks will receive the output.<para/>
        /// For possible values, see DEBUG_OUTCTL_XXX.</param>
        /// <param name="format">[in, optional] Specifies the format string, as in printf. Typically, conversion characters work exactly as they do in C.<para/>
        /// For the floating-point conversion characters, the 64-bit argument is interpreted as a 32-bit floating-point number unless the l modifier is used.<para/>
        /// The %p conversion character is supported, but it represents a pointer in a target's address space. It might not have any modifiers and it uses the debugger's internal address formatting.<para/>
        /// The following additional conversion characters are supported. If Format is NULL, only the standard prompt text is sent to the output callbacks.</param>
        /// <returns>This method can also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// OutputPrompt and OutputPromptWide can be used to prompt the user for input. The standard prompt will be sent to
        /// the output callbacks before the formatted text described by Format. The contents of the standard prompt is returned
        /// by the method <see cref="PromptText"/>. The prompt text is sent to the output callbacks with the
        /// DEBUG_OUTPUT_PROMPT output mask set. For more information about prompting the user, see Using Input and Output.
        /// </remarks>
        public HRESULT TryOutputPromptWide(DEBUG_OUTCTL outputControl, string format)
        {
            /*HRESULT OutputPromptWide(
            [In] DEBUG_OUTCTL OutputControl,
            [In, MarshalAs(UnmanagedType.LPWStr)] string Format);*/
            return Raw4.OutputPromptWide(outputControl, format);
        }

        #endregion
        #region OutputPromptVaListWide

        /// <summary>
        /// The OutputPromptVaListWide method formats and sends a user prompt to the output callback objects.
        /// </summary>
        /// <param name="outputControl">[in] Specifies an output control that determines which of the client's output callbacks will receive the output.<para/>
        /// For possible values, see DEBUG_OUTCTL_XXX.</param>
        /// <param name="format">[in, optional] Specifies the format string, as in printf. Typically, conversion characters work exactly as they do in C.<para/>
        /// For the floating-point conversion characters, the 64-bit argument is interpreted as a 32-bit floating-point number unless the l modifier is used.<para/>
        /// The %p conversion character is supported, but it represents a pointer in a target's address space. It might not have any modifiers and it uses the debugger's internal address formatting.<para/>
        /// The following additional conversion characters are supported. If Format is NULL, only the standard prompt text is sent to the output callbacks.</param>
        /// <param name="va_list_Args">[in] Specifies additional parameters that represent values to be inserted into the output during formatting. Args must be initialized using va_start.<para/>
        /// This method does not call va_end.</param>
        /// <remarks>
        /// OutputPromptVaList and OutputPromptVaListWide can be used to prompt the user for input. The standard prompt will
        /// be sent to the output callbacks before the formatted text described by Format. The contents of the standard prompt
        /// is returned by the method <see cref="PromptText"/>. The prompt text is sent to the output callbacks
        /// with the DEBUG_OUTPUT_PROMPT output mask set. For more information about prompting the user, see Using Input and
        /// Output.
        /// </remarks>
        [Obsolete("This method cannot be safely called from managed code")]
        public void OutputPromptVaListWide(DEBUG_OUTCTL outputControl, string format, IntPtr va_list_Args)
        {
            TryOutputPromptVaListWide(outputControl, format, va_list_Args).ThrowDbgEngNotOK();
        }

        /// <summary>
        /// The OutputPromptVaListWide method formats and sends a user prompt to the output callback objects.
        /// </summary>
        /// <param name="outputControl">[in] Specifies an output control that determines which of the client's output callbacks will receive the output.<para/>
        /// For possible values, see DEBUG_OUTCTL_XXX.</param>
        /// <param name="format">[in, optional] Specifies the format string, as in printf. Typically, conversion characters work exactly as they do in C.<para/>
        /// For the floating-point conversion characters, the 64-bit argument is interpreted as a 32-bit floating-point number unless the l modifier is used.<para/>
        /// The %p conversion character is supported, but it represents a pointer in a target's address space. It might not have any modifiers and it uses the debugger's internal address formatting.<para/>
        /// The following additional conversion characters are supported. If Format is NULL, only the standard prompt text is sent to the output callbacks.</param>
        /// <param name="va_list_Args">[in] Specifies additional parameters that represent values to be inserted into the output during formatting. Args must be initialized using va_start.<para/>
        /// This method does not call va_end.</param>
        /// <returns>This method can also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// OutputPromptVaList and OutputPromptVaListWide can be used to prompt the user for input. The standard prompt will
        /// be sent to the output callbacks before the formatted text described by Format. The contents of the standard prompt
        /// is returned by the method <see cref="PromptText"/>. The prompt text is sent to the output callbacks
        /// with the DEBUG_OUTPUT_PROMPT output mask set. For more information about prompting the user, see Using Input and
        /// Output.
        /// </remarks>
        [Obsolete("This method cannot be safely called from managed code")]
        public HRESULT TryOutputPromptVaListWide(DEBUG_OUTCTL outputControl, string format, IntPtr va_list_Args)
        {
            /*HRESULT OutputPromptVaListWide(
            [In] DEBUG_OUTCTL OutputControl,
            [In, MarshalAs(UnmanagedType.LPWStr)] string Format,
            [In] IntPtr va_list_Args);*/
            return Raw4.OutputPromptVaListWide(outputControl, format, va_list_Args);
        }

        #endregion
        #region AssembleWide

        /// <summary>
        /// The AssembleWide method assembles a single processor instruction. The assembled instruction is placed in the target's memory.
        /// </summary>
        /// <param name="offset">[in] Specifies the location in the target's memory to place the assembled instruction.</param>
        /// <param name="instr">[in] Specifies the instruction to assemble. The instruction is assembled according to the target's effective processor type (returned by <see cref="EffectiveProcessorType"/>).</param>
        /// <returns>[out] Receives the location in the target's memory immediately following the assembled instruction. EndOffset can be used when assembling multiple instructions.</returns>
        /// <remarks>
        /// The assembly language depends on the effective processor type of the target machine. For information about the
        /// assembly language, see the processor documentation. For an overview of using assembly in debugger applications,
        /// see Debugging in Assembly Mode. For more information about using assembly with the debugger engine API, see Assembling
        /// and Disassembling Instructions.
        /// </remarks>
        public long AssembleWide(long offset, string instr)
        {
            long endOffset;
            TryAssembleWide(offset, instr, out endOffset).ThrowDbgEngNotOK();

            return endOffset;
        }

        /// <summary>
        /// The AssembleWide method assembles a single processor instruction. The assembled instruction is placed in the target's memory.
        /// </summary>
        /// <param name="offset">[in] Specifies the location in the target's memory to place the assembled instruction.</param>
        /// <param name="instr">[in] Specifies the instruction to assemble. The instruction is assembled according to the target's effective processor type (returned by <see cref="EffectiveProcessorType"/>).</param>
        /// <param name="endOffset">[out] Receives the location in the target's memory immediately following the assembled instruction. EndOffset can be used when assembling multiple instructions.</param>
        /// <returns>This method can also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// The assembly language depends on the effective processor type of the target machine. For information about the
        /// assembly language, see the processor documentation. For an overview of using assembly in debugger applications,
        /// see Debugging in Assembly Mode. For more information about using assembly with the debugger engine API, see Assembling
        /// and Disassembling Instructions.
        /// </remarks>
        public HRESULT TryAssembleWide(long offset, string instr, out long endOffset)
        {
            /*HRESULT AssembleWide(
            [In] long Offset,
            [In, MarshalAs(UnmanagedType.LPWStr)] string Instr,
            [Out] out long EndOffset);*/
            return Raw4.AssembleWide(offset, instr, out endOffset);
        }

        #endregion
        #region DisassembleWide

        /// <summary>
        /// The DisassembleWide method disassembles a processor instruction in the target's memory.
        /// </summary>
        /// <param name="offset">[in] Specifies the location in the target's memory of the instruction to disassemble.</param>
        /// <param name="flags">[in] Specifies the bit-flags that affect the behavior of this method. Currently the only flag that can be set is DEBUG_DISASM_EFFECTIVE_ADDRESS; when set, the engine will compute the effective address from the current register information and display it.</param>
        /// <returns>The values that were emitted from the COM method.</returns>
        /// <remarks>
        /// The assembly language depends on the effective processor type of the target system. For information about the assembly
        /// language, see the processor documentation. The disassembly options--returned by <see cref="AssemblyOptions"/>--affect
        /// the operation of this method. For an overview of using assembly in debugger applications, see Debugging in Assembly
        /// Mode. For more information about using assembly with the debugger engine API, see Assembling and Disassembling
        /// Instructions.
        /// </remarks>
        public DisassembleWideResult DisassembleWide(long offset, DEBUG_DISASM flags)
        {
            DisassembleWideResult result;
            TryDisassembleWide(offset, flags, out result).ThrowDbgEngNotOK();

            return result;
        }

        /// <summary>
        /// The DisassembleWide method disassembles a processor instruction in the target's memory.
        /// </summary>
        /// <param name="offset">[in] Specifies the location in the target's memory of the instruction to disassemble.</param>
        /// <param name="flags">[in] Specifies the bit-flags that affect the behavior of this method. Currently the only flag that can be set is DEBUG_DISASM_EFFECTIVE_ADDRESS; when set, the engine will compute the effective address from the current register information and display it.</param>
        /// <param name="result">The values that were emitted from the COM method.</param>
        /// <returns>This method can also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// The assembly language depends on the effective processor type of the target system. For information about the assembly
        /// language, see the processor documentation. The disassembly options--returned by <see cref="AssemblyOptions"/>--affect
        /// the operation of this method. For an overview of using assembly in debugger applications, see Debugging in Assembly
        /// Mode. For more information about using assembly with the debugger engine API, see Assembling and Disassembling
        /// Instructions.
        /// </remarks>
        public HRESULT TryDisassembleWide(long offset, DEBUG_DISASM flags, out DisassembleWideResult result)
        {
            /*HRESULT DisassembleWide(
            [In] long Offset,
            [In] DEBUG_DISASM Flags,
            [SRI.Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U2, SizeParamIndex = 3)] char[] Buffer,
            [In] int BufferSize,
            [Out] out int DisassemblySize,
            [Out] out long EndOffset);*/
            char[] buffer;
            int bufferSize = 0;
            int disassemblySize;
            long endOffset;
            HRESULT hr = Raw4.DisassembleWide(offset, flags, null, bufferSize, out disassemblySize, out endOffset);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER && hr != HRESULT.S_OK)
                goto fail;

            bufferSize = disassemblySize;
            buffer = new char[bufferSize];
            hr = Raw4.DisassembleWide(offset, flags, buffer, bufferSize, out disassemblySize, out endOffset);

            if (hr == HRESULT.S_OK)
            {
                result = new DisassembleWideResult(CreateString(buffer, disassemblySize), endOffset);

                return hr;
            }

            fail:
            result = default(DisassembleWideResult);

            return hr;
        }

        #endregion
        #region GetProcessorTypeNamesWide

        /// <summary>
        /// The GetProcessorTypeNamesWide method returns the full name and abbreviated name of the specified processor type.
        /// </summary>
        /// <param name="type">[in] Specifies the type of the processor whose name is requested. See <see cref="ActualProcessorType"/> for a list of possible values.</param>
        /// <returns>The values that were emitted from the COM method.</returns>
        /// <remarks>
        /// For more information, see Target Information.
        /// </remarks>
        public GetProcessorTypeNamesWideResult GetProcessorTypeNamesWide(IMAGE_FILE_MACHINE type)
        {
            GetProcessorTypeNamesWideResult result;
            TryGetProcessorTypeNamesWide(type, out result).ThrowDbgEngNotOK();

            return result;
        }

        /// <summary>
        /// The GetProcessorTypeNamesWide method returns the full name and abbreviated name of the specified processor type.
        /// </summary>
        /// <param name="type">[in] Specifies the type of the processor whose name is requested. See <see cref="ActualProcessorType"/> for a list of possible values.</param>
        /// <param name="result">The values that were emitted from the COM method.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// For more information, see Target Information.
        /// </remarks>
        public HRESULT TryGetProcessorTypeNamesWide(IMAGE_FILE_MACHINE type, out GetProcessorTypeNamesWideResult result)
        {
            /*HRESULT GetProcessorTypeNamesWide(
            [In] IMAGE_FILE_MACHINE Type,
            [SRI.Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U2, SizeParamIndex = 2)] char[] FullNameBuffer,
            [In] int FullNameBufferSize,
            [Out] out int FullNameSize,
            [SRI.Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U2, SizeParamIndex = 5)] char[] AbbrevNameBuffer,
            [In] int AbbrevNameBufferSize,
            [Out] out int AbbrevNameSize);*/
            char[] fullNameBuffer;
            int fullNameBufferSize = 0;
            int fullNameSize;
            char[] abbrevNameBuffer;
            int abbrevNameBufferSize = 0;
            int abbrevNameSize;
            HRESULT hr = Raw4.GetProcessorTypeNamesWide(type, null, fullNameBufferSize, out fullNameSize, null, abbrevNameBufferSize, out abbrevNameSize);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER && hr != HRESULT.S_OK)
                goto fail;

            fullNameBufferSize = fullNameSize;
            fullNameBuffer = new char[fullNameBufferSize];
            abbrevNameBufferSize = abbrevNameSize;
            abbrevNameBuffer = new char[abbrevNameBufferSize];
            hr = Raw4.GetProcessorTypeNamesWide(type, fullNameBuffer, fullNameBufferSize, out fullNameSize, abbrevNameBuffer, abbrevNameBufferSize, out abbrevNameSize);

            if (hr == HRESULT.S_OK)
            {
                result = new GetProcessorTypeNamesWideResult(CreateString(fullNameBuffer, fullNameSize), CreateString(abbrevNameBuffer, abbrevNameSize));

                return hr;
            }

            fail:
            result = default(GetProcessorTypeNamesWideResult);

            return hr;
        }

        #endregion
        #region GetTextMacroWide

        /// <summary>
        /// The GetTextMacroWide method returns the value of a fixed-name alias.
        /// </summary>
        /// <param name="slot">[in] Specifies the number of the fixed-name alias. Slot can take the values 0, 1, ..., 9, that represent the fixed-name aliases $u0, $u1, ..., $u9.</param>
        /// <returns>[out, optional] Receives the value of the alias specified by Slot. If Buffer is NULL, this information is not returned.</returns>
        /// <remarks>
        /// Before executing commands or evaluating expressions, the debugger engine will replace the alias specified by Slot
        /// with the value of the alias (returned to the Buffer buffer). For an overview of aliases used by the debugger engine,
        /// see Using Aliases. For more information about using aliases with the debugger engine API, see Interacting with
        /// the Engine.
        /// </remarks>
        public string GetTextMacroWide(int slot)
        {
            string bufferResult;
            TryGetTextMacroWide(slot, out bufferResult).ThrowDbgEngNotOK();

            return bufferResult;
        }

        /// <summary>
        /// The GetTextMacroWide method returns the value of a fixed-name alias.
        /// </summary>
        /// <param name="slot">[in] Specifies the number of the fixed-name alias. Slot can take the values 0, 1, ..., 9, that represent the fixed-name aliases $u0, $u1, ..., $u9.</param>
        /// <param name="bufferResult">[out, optional] Receives the value of the alias specified by Slot. If Buffer is NULL, this information is not returned.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// Before executing commands or evaluating expressions, the debugger engine will replace the alias specified by Slot
        /// with the value of the alias (returned to the Buffer buffer). For an overview of aliases used by the debugger engine,
        /// see Using Aliases. For more information about using aliases with the debugger engine API, see Interacting with
        /// the Engine.
        /// </remarks>
        public HRESULT TryGetTextMacroWide(int slot, out string bufferResult)
        {
            /*HRESULT GetTextMacroWide(
            [In] int Slot,
            [SRI.Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U2, SizeParamIndex = 2)] char[] Buffer,
            [In] int BufferSize,
            [Out] out int MacroSize);*/
            char[] buffer;
            int bufferSize = 0;
            int macroSize;
            HRESULT hr = Raw4.GetTextMacroWide(slot, null, bufferSize, out macroSize);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER && hr != HRESULT.S_OK)
                goto fail;

            bufferSize = macroSize;
            buffer = new char[bufferSize];
            hr = Raw4.GetTextMacroWide(slot, buffer, bufferSize, out macroSize);

            if (hr == HRESULT.S_OK)
            {
                bufferResult = CreateString(buffer, macroSize);

                return hr;
            }

            fail:
            bufferResult = default(string);

            return hr;
        }

        #endregion
        #region SetTextMacroWide

        /// <summary>
        /// The SetTextMacroWide method sets the value of a fixed-name alias.
        /// </summary>
        /// <param name="slot">[in] Specifies the number of the fixed-name alias. Slot can take the values 0, 1, ..., 9, that represent the fixed-name aliases $u0, $u1, ..., $u9.</param>
        /// <param name="macro">[in] Specifies the new value of the alias specified by Slot. The debugger engine makes a copy of this string.</param>
        /// <remarks>
        /// Before executing commands or evaluating expressions, the debugger engine will replace the alias specified by Slot
        /// with the value of the alias (specified by Macro). For an overview of aliases used by the debugger engine, see Using
        /// Aliases. For more information about using aliases with the debugger engine API, see Interacting with the Engine.
        /// </remarks>
        public void SetTextMacroWide(int slot, string macro)
        {
            TrySetTextMacroWide(slot, macro).ThrowDbgEngNotOK();
        }

        /// <summary>
        /// The SetTextMacroWide method sets the value of a fixed-name alias.
        /// </summary>
        /// <param name="slot">[in] Specifies the number of the fixed-name alias. Slot can take the values 0, 1, ..., 9, that represent the fixed-name aliases $u0, $u1, ..., $u9.</param>
        /// <param name="macro">[in] Specifies the new value of the alias specified by Slot. The debugger engine makes a copy of this string.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// Before executing commands or evaluating expressions, the debugger engine will replace the alias specified by Slot
        /// with the value of the alias (specified by Macro). For an overview of aliases used by the debugger engine, see Using
        /// Aliases. For more information about using aliases with the debugger engine API, see Interacting with the Engine.
        /// </remarks>
        public HRESULT TrySetTextMacroWide(int slot, string macro)
        {
            /*HRESULT SetTextMacroWide(
            [In] int Slot,
            [In, MarshalAs(UnmanagedType.LPWStr)] string Macro);*/
            return Raw4.SetTextMacroWide(slot, macro);
        }

        #endregion
        #region EvaluateWide

        /// <summary>
        /// The EvaluateWide method evaluates an expression, returning the result.
        /// </summary>
        /// <param name="expression">[in] Specifies the expression to be evaluated.</param>
        /// <param name="desiredType">[in] Specifies the desired return type. Possible values are described in <see cref="DEBUG_VALUE"/>; with the addition of DEBUG_VALUE_INVALID, which indicates that the return type should be the expression's natural type.</param>
        /// <returns>The values that were emitted from the COM method.</returns>
        /// <remarks>
        /// Expressions are evaluated by the current expression evaluator. The engine contains multiple expression evaluators;
        /// each supports a different syntax. The current expression evaluator can be chosen by using <see cref="ExpressionSyntax"/>.
        /// For details of the available expression evaluators and their syntaxes, see Numerical Expression Syntax. If an error
        /// occurs while evaluating the expression, returning E_FAIL, the RemainderIndex variable can be used to determine
        /// approximately where in the expression the error occurred.
        /// </remarks>
        public EvaluateWideResult EvaluateWide(string expression, DEBUG_VALUE_TYPE desiredType)
        {
            EvaluateWideResult result;
            TryEvaluateWide(expression, desiredType, out result).ThrowDbgEngNotOK();

            return result;
        }

        /// <summary>
        /// The EvaluateWide method evaluates an expression, returning the result.
        /// </summary>
        /// <param name="expression">[in] Specifies the expression to be evaluated.</param>
        /// <param name="desiredType">[in] Specifies the desired return type. Possible values are described in <see cref="DEBUG_VALUE"/>; with the addition of DEBUG_VALUE_INVALID, which indicates that the return type should be the expression's natural type.</param>
        /// <param name="result">The values that were emitted from the COM method.</param>
        /// <returns>This method may also return other error values. See Return Values for more details.</returns>
        /// <remarks>
        /// Expressions are evaluated by the current expression evaluator. The engine contains multiple expression evaluators;
        /// each supports a different syntax. The current expression evaluator can be chosen by using <see cref="ExpressionSyntax"/>.
        /// For details of the available expression evaluators and their syntaxes, see Numerical Expression Syntax. If an error
        /// occurs while evaluating the expression, returning E_FAIL, the RemainderIndex variable can be used to determine
        /// approximately where in the expression the error occurred.
        /// </remarks>
        public HRESULT TryEvaluateWide(string expression, DEBUG_VALUE_TYPE desiredType, out EvaluateWideResult result)
        {
            /*HRESULT EvaluateWide(
            [In, MarshalAs(UnmanagedType.LPWStr)] string Expression,
            [In] DEBUG_VALUE_TYPE DesiredType,
            [Out] out DEBUG_VALUE Value,
            [Out] out int RemainderIndex);*/
            DEBUG_VALUE value;
            int remainderIndex;
            HRESULT hr = Raw4.EvaluateWide(expression, desiredType, out value, out remainderIndex);

            if (hr == HRESULT.S_OK)
                result = new EvaluateWideResult(value, remainderIndex);
            else
                result = default(EvaluateWideResult);

            return hr;
        }

        #endregion
        #region ExecuteWide

        /// <summary>
        /// The ExecuteWide method executes the specified debugger commands.
        /// </summary>
        /// <param name="outputControl">[in] Specifies the output control to use while executing the command. For possible values, see DEBUG_OUTCTL_XXX.<para/>
        /// For more information about output, see Input and Output.</param>
        /// <param name="command">[in] Specifies the command string to execute. The command is interpreted like those typed into a debugger command window.<para/>
        /// This command string can contain multiple commands for the engine to execute. See Debugger Commands for the command reference.</param>
        /// <param name="flags">[in] Specifies a bit field of execution options for the command. The default options are to log the command but to not send it to the output.<para/>
        /// The following table lists the bits that can be set.</param>
        /// <remarks>
        /// This method executes the given command string. If the string has multiple commands, these methods will not return
        /// until all of the commands have been executed. This may involve waiting for the target to execute, so these methods
        /// can take an arbitrary amount of time to complete.
        /// </remarks>
        public void ExecuteWide(DEBUG_OUTCTL outputControl, string command, DEBUG_EXECUTE flags)
        {
            TryExecuteWide(outputControl, command, flags).ThrowDbgEngNotOK();
        }

        /// <summary>
        /// The ExecuteWide method executes the specified debugger commands.
        /// </summary>
        /// <param name="outputControl">[in] Specifies the output control to use while executing the command. For possible values, see DEBUG_OUTCTL_XXX.<para/>
        /// For more information about output, see Input and Output.</param>
        /// <param name="command">[in] Specifies the command string to execute. The command is interpreted like those typed into a debugger command window.<para/>
        /// This command string can contain multiple commands for the engine to execute. See Debugger Commands for the command reference.</param>
        /// <param name="flags">[in] Specifies a bit field of execution options for the command. The default options are to log the command but to not send it to the output.<para/>
        /// The following table lists the bits that can be set.</param>
        /// <returns>This method can also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// This method executes the given command string. If the string has multiple commands, these methods will not return
        /// until all of the commands have been executed. This may involve waiting for the target to execute, so these methods
        /// can take an arbitrary amount of time to complete.
        /// </remarks>
        public HRESULT TryExecuteWide(DEBUG_OUTCTL outputControl, string command, DEBUG_EXECUTE flags)
        {
            /*HRESULT ExecuteWide(
            [In] DEBUG_OUTCTL OutputControl,
            [In, MarshalAs(UnmanagedType.LPWStr)] string Command,
            [In] DEBUG_EXECUTE Flags);*/
            return Raw4.ExecuteWide(outputControl, command, flags);
        }

        #endregion
        #region ExecuteCommandFileWide

        /// <summary>
        /// The ExecuteCommandFileWide method opens the specified file and executes the debugger commands that are contained within.
        /// </summary>
        /// <param name="outputControl">[in] Specifies where to send the output of the command. For possible values, see DEBUG_OUTCTL_XXX. For more information about output, see Input and Output.</param>
        /// <param name="commandFile">[in] Specifies the name of the file that contains the commands to execute. This file is opened for reading and its contents are interpreted as if they had been typed into the debugger console.</param>
        /// <param name="flags">[in] Specifies execution options for the command. The default options are to log the command but not to send it to the output.<para/>
        /// For details about the values that Flags can take, see <see cref="Execute"/>.</param>
        /// <remarks>
        /// This method reads the specified file and execute the commands one line at a time using <see cref="Execute"/>.
        /// If an exception occurred while executing a line, the execution will continue with the next line.
        /// </remarks>
        public void ExecuteCommandFileWide(DEBUG_OUTCTL outputControl, string commandFile, DEBUG_EXECUTE flags)
        {
            TryExecuteCommandFileWide(outputControl, commandFile, flags).ThrowDbgEngNotOK();
        }

        /// <summary>
        /// The ExecuteCommandFileWide method opens the specified file and executes the debugger commands that are contained within.
        /// </summary>
        /// <param name="outputControl">[in] Specifies where to send the output of the command. For possible values, see DEBUG_OUTCTL_XXX. For more information about output, see Input and Output.</param>
        /// <param name="commandFile">[in] Specifies the name of the file that contains the commands to execute. This file is opened for reading and its contents are interpreted as if they had been typed into the debugger console.</param>
        /// <param name="flags">[in] Specifies execution options for the command. The default options are to log the command but not to send it to the output.<para/>
        /// For details about the values that Flags can take, see <see cref="Execute"/>.</param>
        /// <returns>This method might also return error values, including error values caused by a failure to open the specified file.<para/>
        /// For more information, see Return Values.</returns>
        /// <remarks>
        /// This method reads the specified file and execute the commands one line at a time using <see cref="Execute"/>.
        /// If an exception occurred while executing a line, the execution will continue with the next line.
        /// </remarks>
        public HRESULT TryExecuteCommandFileWide(DEBUG_OUTCTL outputControl, string commandFile, DEBUG_EXECUTE flags)
        {
            /*HRESULT ExecuteCommandFileWide(
            [In] DEBUG_OUTCTL OutputControl,
            [In, MarshalAs(UnmanagedType.LPWStr)] string CommandFile,
            [In] DEBUG_EXECUTE Flags);*/
            return Raw4.ExecuteCommandFileWide(outputControl, commandFile, flags);
        }

        #endregion
        #region GetBreakpointByIndex2

        /// <summary>
        /// The GetBreakpointByIndex2 method returns the breakpoint located at the specified index.
        /// </summary>
        /// <param name="index">[in] Specifies the zero-based index of the breakpoint to return. This is specific to the current process. The value of Index should be between zero and the total number of breakpoints minus one.<para/>
        /// The total number of breakpoints can be determined by calling <see cref="NumberBreakpoints"/>.</param>
        /// <returns>[out] Receives the returned breakpoint.</returns>
        /// <remarks>
        /// The index and returned breakpoint are specific to the current process. The same index will return a different breakpoint
        /// if the current process is changed.
        /// </remarks>
        public DebugBreakpoint GetBreakpointByIndex2(int index)
        {
            DebugBreakpoint bpResult;
            TryGetBreakpointByIndex2(index, out bpResult).ThrowDbgEngNotOK();

            return bpResult;
        }

        /// <summary>
        /// The GetBreakpointByIndex2 method returns the breakpoint located at the specified index.
        /// </summary>
        /// <param name="index">[in] Specifies the zero-based index of the breakpoint to return. This is specific to the current process. The value of Index should be between zero and the total number of breakpoints minus one.<para/>
        /// The total number of breakpoints can be determined by calling <see cref="NumberBreakpoints"/>.</param>
        /// <param name="bpResult">[out] Receives the returned breakpoint.</param>
        /// <returns>This method can also return other error values. See Return Values for more details.</returns>
        /// <remarks>
        /// The index and returned breakpoint are specific to the current process. The same index will return a different breakpoint
        /// if the current process is changed.
        /// </remarks>
        public HRESULT TryGetBreakpointByIndex2(int index, out DebugBreakpoint bpResult)
        {
            /*HRESULT GetBreakpointByIndex2(
            [In] int Index,
            [Out, MarshalAs(UnmanagedType.Interface), ComAliasName("IDebugBreakpoint2")] out IDebugBreakpoint2 bp);*/
            IDebugBreakpoint2 bp;
            HRESULT hr = Raw4.GetBreakpointByIndex2(index, out bp);

            if (hr == HRESULT.S_OK)
                bpResult = bp == null ? null : new DebugBreakpoint(bp);
            else
                bpResult = default(DebugBreakpoint);

            return hr;
        }

        #endregion
        #region GetBreakpointById2

        /// <summary>
        /// The GetBreakpointById2 method returns the breakpoint with the specified breakpoint ID.
        /// </summary>
        /// <param name="id">[in] Specifies the breakpoint ID of the breakpoint to return.</param>
        /// <returns>[out] Receives the breakpoint.</returns>
        /// <remarks>
        /// If the specified breakpoint does not belong to the current process, the method will fail.
        /// </remarks>
        public DebugBreakpoint GetBreakpointById2(int id)
        {
            DebugBreakpoint bpResult;
            TryGetBreakpointById2(id, out bpResult).ThrowDbgEngNotOK();

            return bpResult;
        }

        /// <summary>
        /// The GetBreakpointById2 method returns the breakpoint with the specified breakpoint ID.
        /// </summary>
        /// <param name="id">[in] Specifies the breakpoint ID of the breakpoint to return.</param>
        /// <param name="bpResult">[out] Receives the breakpoint.</param>
        /// <returns>This method can also return other error values. See Return Values for more details.</returns>
        /// <remarks>
        /// If the specified breakpoint does not belong to the current process, the method will fail.
        /// </remarks>
        public HRESULT TryGetBreakpointById2(int id, out DebugBreakpoint bpResult)
        {
            /*HRESULT GetBreakpointById2(
            [In] int Id,
            [Out, MarshalAs(UnmanagedType.Interface), ComAliasName("IDebugBreakpoint2")] out IDebugBreakpoint2 bp);*/
            IDebugBreakpoint2 bp;
            HRESULT hr = Raw4.GetBreakpointById2(id, out bp);

            if (hr == HRESULT.S_OK)
                bpResult = bp == null ? null : new DebugBreakpoint(bp);
            else
                bpResult = default(DebugBreakpoint);

            return hr;
        }

        #endregion
        #region AddBreakpoint2

        /// <summary>
        /// The AddBreakpoint2 method creates a new breakpoint for the current target.
        /// </summary>
        /// <param name="type">[in] Specifies the breakpoint type of the new breakpoint. This can be either of the following values:</param>
        /// <param name="desiredId">[in] Specifies the desired ID of the new breakpoint. If it is DEBUG_ANY_ID, the engine will pick an unused ID.</param>
        /// <returns>[out] Receives an interface pointer to the new breakpoint.</returns>
        /// <remarks>
        /// If DesiredId is not DEBUG_ANY_ID and another breakpoint already uses the ID DesiredId, these methods will fail.
        /// Breakpoints are created empty and disabled. See Using Breakpoints for details on configuring and enabling the breakpoint.
        /// The client is saved as the adder of the new breakpoint. See <see cref="DebugBreakpoint.Adder"/>.
        /// </remarks>
        public DebugBreakpoint AddBreakpoint2(DEBUG_BREAKPOINT_TYPE type, int desiredId)
        {
            DebugBreakpoint bpResult;
            TryAddBreakpoint2(type, desiredId, out bpResult).ThrowDbgEngNotOK();

            return bpResult;
        }

        /// <summary>
        /// The AddBreakpoint2 method creates a new breakpoint for the current target.
        /// </summary>
        /// <param name="type">[in] Specifies the breakpoint type of the new breakpoint. This can be either of the following values:</param>
        /// <param name="desiredId">[in] Specifies the desired ID of the new breakpoint. If it is DEBUG_ANY_ID, the engine will pick an unused ID.</param>
        /// <param name="bpResult">[out] Receives an interface pointer to the new breakpoint.</param>
        /// <returns>This method may also return other error values. See Return Values for more details.</returns>
        /// <remarks>
        /// If DesiredId is not DEBUG_ANY_ID and another breakpoint already uses the ID DesiredId, these methods will fail.
        /// Breakpoints are created empty and disabled. See Using Breakpoints for details on configuring and enabling the breakpoint.
        /// The client is saved as the adder of the new breakpoint. See <see cref="DebugBreakpoint.Adder"/>.
        /// </remarks>
        public HRESULT TryAddBreakpoint2(DEBUG_BREAKPOINT_TYPE type, int desiredId, out DebugBreakpoint bpResult)
        {
            /*HRESULT AddBreakpoint2(
            [In] DEBUG_BREAKPOINT_TYPE Type,
            [In] int DesiredId,
            [Out, MarshalAs(UnmanagedType.Interface), ComAliasName("IDebugBreakpoint2")] out IDebugBreakpoint2 Bp);*/
            IDebugBreakpoint2 bp;
            HRESULT hr = Raw4.AddBreakpoint2(type, desiredId, out bp);

            if (hr == HRESULT.S_OK)
                bpResult = bp == null ? null : new DebugBreakpoint(bp);
            else
                bpResult = default(DebugBreakpoint);

            return hr;
        }

        #endregion
        #region RemoveBreakpoint2

        /// <summary>
        /// The RemoveBreakpoint2 method removes a breakpoint.
        /// </summary>
        /// <param name="bp">[in] Specifies an interface pointer to breakpoint to remove.</param>
        /// <remarks>
        /// After RemoveBreakpoint and RemoveBreakpoint2 are called, the breakpoint object specified in the Bp parameter must
        /// not be used again.
        /// </remarks>
        public void RemoveBreakpoint2(IDebugBreakpoint2 bp)
        {
            TryRemoveBreakpoint2(bp).ThrowDbgEngNotOK();
        }

        /// <summary>
        /// The RemoveBreakpoint2 method removes a breakpoint.
        /// </summary>
        /// <param name="bp">[in] Specifies an interface pointer to breakpoint to remove.</param>
        /// <returns>This method may also return other error values. See Return Values for more details.</returns>
        /// <remarks>
        /// After RemoveBreakpoint and RemoveBreakpoint2 are called, the breakpoint object specified in the Bp parameter must
        /// not be used again.
        /// </remarks>
        public HRESULT TryRemoveBreakpoint2(IDebugBreakpoint2 bp)
        {
            /*HRESULT RemoveBreakpoint2(
            [In, MarshalAs(UnmanagedType.Interface), ComAliasName("IDebugBreakpoint2")] IDebugBreakpoint2 Bp);*/
            return Raw4.RemoveBreakpoint2(bp);
        }

        #endregion
        #region AddExtensionWide

        /// <summary>
        /// The AddExtensionWide method loads an extension library into the debugger engine.
        /// </summary>
        /// <param name="path">[in] Specifies the fully qualified path and file name of the extension library to load.</param>
        /// <param name="flags">[in] Set to zero.</param>
        /// <returns>[out] Receives the handle of the loaded extension library.</returns>
        /// <remarks>
        /// If the extension library has already been loaded, the handle to already loaded library is returned. The extension
        /// library is not loaded again. The extension library is loaded into the host engine and Path contains a path and
        /// file name for this instance of the debugger engine. For more information on using extension libraries, see Calling
        /// Extensions and Extension Functions.
        /// </remarks>
        public long AddExtensionWide(string path, int flags)
        {
            long handle;
            TryAddExtensionWide(path, flags, out handle).ThrowDbgEngNotOK();

            return handle;
        }

        /// <summary>
        /// The AddExtensionWide method loads an extension library into the debugger engine.
        /// </summary>
        /// <param name="path">[in] Specifies the fully qualified path and file name of the extension library to load.</param>
        /// <param name="flags">[in] Set to zero.</param>
        /// <param name="handle">[out] Receives the handle of the loaded extension library.</param>
        /// <returns>This method can also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// If the extension library has already been loaded, the handle to already loaded library is returned. The extension
        /// library is not loaded again. The extension library is loaded into the host engine and Path contains a path and
        /// file name for this instance of the debugger engine. For more information on using extension libraries, see Calling
        /// Extensions and Extension Functions.
        /// </remarks>
        public HRESULT TryAddExtensionWide(string path, int flags, out long handle)
        {
            /*HRESULT AddExtensionWide(
            [In, MarshalAs(UnmanagedType.LPWStr)] string Path,
            [In] int Flags,
            [Out] out long Handle);*/
            return Raw4.AddExtensionWide(path, flags, out handle);
        }

        #endregion
        #region GetExtensionByPathWide

        /// <summary>
        /// The GetExtensionByPathWide method returns the handle for an already loaded extension library.
        /// </summary>
        /// <param name="path">[in] Specifies the fully qualified path and file name of the extension library.</param>
        /// <returns>[out] Receives the handle of the extension library.</returns>
        /// <remarks>
        /// Extension libraries are loaded into the host engine, which is where this method looks for the requested extension
        /// library. Path is a path and file name for the host engine. For more information on using extension libraries, see
        /// Calling Extensions and Extension Functions.
        /// </remarks>
        public long GetExtensionByPathWide(string path)
        {
            long handle;
            TryGetExtensionByPathWide(path, out handle).ThrowDbgEngNotOK();

            return handle;
        }

        /// <summary>
        /// The GetExtensionByPathWide method returns the handle for an already loaded extension library.
        /// </summary>
        /// <param name="path">[in] Specifies the fully qualified path and file name of the extension library.</param>
        /// <param name="handle">[out] Receives the handle of the extension library.</param>
        /// <returns>This method can also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// Extension libraries are loaded into the host engine, which is where this method looks for the requested extension
        /// library. Path is a path and file name for the host engine. For more information on using extension libraries, see
        /// Calling Extensions and Extension Functions.
        /// </remarks>
        public HRESULT TryGetExtensionByPathWide(string path, out long handle)
        {
            /*HRESULT GetExtensionByPathWide(
            [In, MarshalAs(UnmanagedType.LPWStr)] string Path,
            [Out] out long Handle);*/
            return Raw4.GetExtensionByPathWide(path, out handle);
        }

        #endregion
        #region CallExtensionWide

        /// <summary>
        /// The CallExtensionWide method calls a debugger extension.
        /// </summary>
        /// <param name="handle">[in] Specifies the handle of the extension library that contains the extension to call. If Handle is zero, the engine will walk the extension library chain searching for the extension.</param>
        /// <param name="function">[in] Specifies the name of the extension to call.</param>
        /// <param name="arguments">[in, optional] Specifies the arguments to pass to the extension. Arguments is a string that will be parsed by the extension, just like the extension will parse arguments passed to it when called as an extension command.</param>
        /// <remarks>
        /// If Handle is zero, the engine searches each extension library until it finds one that contains the extension; the
        /// extension will then be called. If the extension returns DEBUG_EXTENSION_CONTINUE_SEARCH, the search will continue.
        /// For more information on using extension libraries, see Calling Extensions and Extension Functions.
        /// </remarks>
        public void CallExtensionWide(long handle, string function, string arguments)
        {
            TryCallExtensionWide(handle, function, arguments).ThrowDbgEngNotOK();
        }

        /// <summary>
        /// The CallExtensionWide method calls a debugger extension.
        /// </summary>
        /// <param name="handle">[in] Specifies the handle of the extension library that contains the extension to call. If Handle is zero, the engine will walk the extension library chain searching for the extension.</param>
        /// <param name="function">[in] Specifies the name of the extension to call.</param>
        /// <param name="arguments">[in, optional] Specifies the arguments to pass to the extension. Arguments is a string that will be parsed by the extension, just like the extension will parse arguments passed to it when called as an extension command.</param>
        /// <returns>This method can also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// If Handle is zero, the engine searches each extension library until it finds one that contains the extension; the
        /// extension will then be called. If the extension returns DEBUG_EXTENSION_CONTINUE_SEARCH, the search will continue.
        /// For more information on using extension libraries, see Calling Extensions and Extension Functions.
        /// </remarks>
        public HRESULT TryCallExtensionWide(long handle, string function, string arguments)
        {
            /*HRESULT CallExtensionWide(
            [In] long Handle,
            [In, MarshalAs(UnmanagedType.LPWStr)] string Function,
            [In, MarshalAs(UnmanagedType.LPWStr)] string Arguments);*/
            return Raw4.CallExtensionWide(handle, function, arguments);
        }

        #endregion
        #region GetExtensionFunctionWide

        /// <summary>
        /// The GetExtensionFunctionWide method returns a pointer to an extension function from an extension library.
        /// </summary>
        /// <param name="handle">[in] Specifies the handle of the extension library that contains the extension function. If Handle is zero, the engine will walk the extension library chain searching for the extension function.</param>
        /// <param name="funcName">[in] Specifies the name of the extension function to return. When searching the extension libraries for the function, the debugger engine will prepend "EFN" to the name.<para/>
        /// For example, if FuncName is "SampleFunction", the engine will search the extension libraries for "_EFN_SampleFunction".</param>
        /// <returns>[out] Receives the extension function.</returns>
        /// <remarks>
        /// Extension libraries are loaded into the host engine and extension functions cannot be called remotely. The current
        /// client must not be a debugging client, it must belong to the host engine. The extension function can have any function
        /// prototype. In order for any program to call this extension function, the extension function should be cast to the
        /// correct prototype. For more information on using extension functions, see Calling Extensions and Extension Functions.
        /// </remarks>
        public IntPtr GetExtensionFunctionWide(long handle, string funcName)
        {
            IntPtr function;
            TryGetExtensionFunctionWide(handle, funcName, out function).ThrowDbgEngNotOK();

            return function;
        }

        /// <summary>
        /// The GetExtensionFunctionWide method returns a pointer to an extension function from an extension library.
        /// </summary>
        /// <param name="handle">[in] Specifies the handle of the extension library that contains the extension function. If Handle is zero, the engine will walk the extension library chain searching for the extension function.</param>
        /// <param name="funcName">[in] Specifies the name of the extension function to return. When searching the extension libraries for the function, the debugger engine will prepend "EFN" to the name.<para/>
        /// For example, if FuncName is "SampleFunction", the engine will search the extension libraries for "_EFN_SampleFunction".</param>
        /// <param name="function">[out] Receives the extension function.</param>
        /// <returns>This method can also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// Extension libraries are loaded into the host engine and extension functions cannot be called remotely. The current
        /// client must not be a debugging client, it must belong to the host engine. The extension function can have any function
        /// prototype. In order for any program to call this extension function, the extension function should be cast to the
        /// correct prototype. For more information on using extension functions, see Calling Extensions and Extension Functions.
        /// </remarks>
        public HRESULT TryGetExtensionFunctionWide(long handle, string funcName, out IntPtr function)
        {
            /*HRESULT GetExtensionFunctionWide(
            [In] long Handle,
            [In, MarshalAs(UnmanagedType.LPWStr)] string FuncName,
            [Out] out IntPtr Function);*/
            return Raw4.GetExtensionFunctionWide(handle, funcName, out function);
        }

        #endregion
        #region GetEventFilterTextWide

        /// <summary>
        /// The GetEventFilterTextWide method returns a short description of an event for a specific filter.
        /// </summary>
        /// <param name="index">[in] Specifies the index of the event filter whose description will be returned. Only the specific filters have a description attached to them; Index must refer to a specific filter.</param>
        /// <returns>[out, optional] Receives the description of the specific filter.</returns>
        /// <remarks>
        /// For more information about event filters, see Event Filters.
        /// </remarks>
        public string GetEventFilterTextWide(int index)
        {
            string bufferResult;
            TryGetEventFilterTextWide(index, out bufferResult).ThrowDbgEngNotOK();

            return bufferResult;
        }

        /// <summary>
        /// The GetEventFilterTextWide method returns a short description of an event for a specific filter.
        /// </summary>
        /// <param name="index">[in] Specifies the index of the event filter whose description will be returned. Only the specific filters have a description attached to them; Index must refer to a specific filter.</param>
        /// <param name="bufferResult">[out, optional] Receives the description of the specific filter.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// For more information about event filters, see Event Filters.
        /// </remarks>
        public HRESULT TryGetEventFilterTextWide(int index, out string bufferResult)
        {
            /*HRESULT GetEventFilterTextWide(
            [In] int Index,
            [SRI.Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U2, SizeParamIndex = 2)] char[] Buffer,
            [In] int BufferSize,
            [Out] out int TextSize);*/
            char[] buffer;
            int bufferSize = 0;
            int textSize;
            HRESULT hr = Raw4.GetEventFilterTextWide(index, null, bufferSize, out textSize);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER && hr != HRESULT.S_OK)
                goto fail;

            bufferSize = textSize;
            buffer = new char[bufferSize];
            hr = Raw4.GetEventFilterTextWide(index, buffer, bufferSize, out textSize);

            if (hr == HRESULT.S_OK)
            {
                bufferResult = CreateString(buffer, textSize);

                return hr;
            }

            fail:
            bufferResult = default(string);

            return hr;
        }

        #endregion
        #region GetEventFilterCommandWide

        /// <summary>
        /// The GetEventFilterCommandWide method returns the debugger command that the engine will execute when a specified event occurs.
        /// </summary>
        /// <param name="index">[in] Specifies the index of the event filter. Index can take any value between zero and one less than the total number of event filters returned by <see cref="NumberEventFilters"/> (inclusive).<para/>
        /// For more information about the index of the filters, see Index and Exception Code.</param>
        /// <returns>[out, optional] Receives the debugger command that the engine will execute when the event occurs.</returns>
        /// <remarks>
        /// For more information about event filters, see Event Filters.
        /// </remarks>
        public string GetEventFilterCommandWide(int index)
        {
            string bufferResult;
            TryGetEventFilterCommandWide(index, out bufferResult).ThrowDbgEngNotOK();

            return bufferResult;
        }

        /// <summary>
        /// The GetEventFilterCommandWide method returns the debugger command that the engine will execute when a specified event occurs.
        /// </summary>
        /// <param name="index">[in] Specifies the index of the event filter. Index can take any value between zero and one less than the total number of event filters returned by <see cref="NumberEventFilters"/> (inclusive).<para/>
        /// For more information about the index of the filters, see Index and Exception Code.</param>
        /// <param name="bufferResult">[out, optional] Receives the debugger command that the engine will execute when the event occurs.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// For more information about event filters, see Event Filters.
        /// </remarks>
        public HRESULT TryGetEventFilterCommandWide(int index, out string bufferResult)
        {
            /*HRESULT GetEventFilterCommandWide(
            [In] int Index,
            [SRI.Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U2, SizeParamIndex = 2)] char[] Buffer,
            [In] int BufferSize,
            [Out] out int CommandSize);*/
            char[] buffer;
            int bufferSize = 0;
            int commandSize;
            HRESULT hr = Raw4.GetEventFilterCommandWide(index, null, bufferSize, out commandSize);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER && hr != HRESULT.S_OK)
                goto fail;

            bufferSize = commandSize;
            buffer = new char[bufferSize];
            hr = Raw4.GetEventFilterCommandWide(index, buffer, bufferSize, out commandSize);

            if (hr == HRESULT.S_OK)
            {
                bufferResult = CreateString(buffer, commandSize);

                return hr;
            }

            fail:
            bufferResult = default(string);

            return hr;
        }

        #endregion
        #region SetEventFilterCommandWide

        /// <summary>
        /// The SetEventFilterCommandWide method sets a debugger command for the engine to execute when a specified event occurs.
        /// </summary>
        /// <param name="index">[in] Specifies the index of the event filter. Index can take any value between zero and one less than the total number of event filters returned by GetNumberEventFilters (inclusive).<para/>
        /// For more information about the index of the filters, see Index and Exception Code.</param>
        /// <param name="command">[in] Specifies the debugger command for the engine to execute when the event occurs.</param>
        /// <remarks>
        /// For more information about event filters, see Event Filters.
        /// </remarks>
        public void SetEventFilterCommandWide(int index, string command)
        {
            TrySetEventFilterCommandWide(index, command).ThrowDbgEngNotOK();
        }

        /// <summary>
        /// The SetEventFilterCommandWide method sets a debugger command for the engine to execute when a specified event occurs.
        /// </summary>
        /// <param name="index">[in] Specifies the index of the event filter. Index can take any value between zero and one less than the total number of event filters returned by GetNumberEventFilters (inclusive).<para/>
        /// For more information about the index of the filters, see Index and Exception Code.</param>
        /// <param name="command">[in] Specifies the debugger command for the engine to execute when the event occurs.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// For more information about event filters, see Event Filters.
        /// </remarks>
        public HRESULT TrySetEventFilterCommandWide(int index, string command)
        {
            /*HRESULT SetEventFilterCommandWide(
            [In] int Index,
            [In, MarshalAs(UnmanagedType.LPWStr)] string Command);*/
            return Raw4.SetEventFilterCommandWide(index, command);
        }

        #endregion
        #region GetSpecificFilterArgumentWide

        public string GetSpecificFilterArgumentWide(int index)
        {
            string bufferResult;
            TryGetSpecificFilterArgumentWide(index, out bufferResult).ThrowDbgEngNotOK();

            return bufferResult;
        }

        public HRESULT TryGetSpecificFilterArgumentWide(int index, out string bufferResult)
        {
            /*HRESULT GetSpecificFilterArgumentWide(
            [In] int Index,
            [SRI.Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U2, SizeParamIndex = 2)] char[] Buffer,
            [In] int BufferSize,
            [Out] out int ArgumentSize);*/
            char[] buffer;
            int bufferSize = 0;
            int argumentSize;
            HRESULT hr = Raw4.GetSpecificFilterArgumentWide(index, null, bufferSize, out argumentSize);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER && hr != HRESULT.S_OK)
                goto fail;

            bufferSize = argumentSize;
            buffer = new char[bufferSize];
            hr = Raw4.GetSpecificFilterArgumentWide(index, buffer, bufferSize, out argumentSize);

            if (hr == HRESULT.S_OK)
            {
                bufferResult = CreateString(buffer, argumentSize);

                return hr;
            }

            fail:
            bufferResult = default(string);

            return hr;
        }

        #endregion
        #region SetSpecificFilterArgumentWide

        public void SetSpecificFilterArgumentWide(int index, string argument)
        {
            TrySetSpecificFilterArgumentWide(index, argument).ThrowDbgEngNotOK();
        }

        public HRESULT TrySetSpecificFilterArgumentWide(int index, string argument)
        {
            /*HRESULT SetSpecificFilterArgumentWide(
            [In] int Index,
            [In, MarshalAs(UnmanagedType.LPWStr)] string Argument);*/
            return Raw4.SetSpecificFilterArgumentWide(index, argument);
        }

        #endregion
        #region GetExceptionFilterSecondCommandWide

        /// <summary>
        /// The GetExceptionFilterSecondCommandWide method returns the command that will be executed by the debugger engine upon the second chance of a specified exception.
        /// </summary>
        /// <param name="index">[in] Specifies the index of the exception filter whose second-chance command will be returned. Index can also refer to the default exception filter to return the second-chance command for those exceptions that do not have a specific or arbitrary exception filter.</param>
        /// <returns>[out, optional] Receives the second-chance command for the exception filter.</returns>
        /// <remarks>
        /// Only exception filters support a second-chance command. If Index refers to a specific event filter, the command
        /// returned to Buffer will be empty. The returned command will also be empty if no second-chance command has been
        /// set for the specified exception. For more information about event filters, see Event Filters.
        /// </remarks>
        public string GetExceptionFilterSecondCommandWide(int index)
        {
            string bufferResult;
            TryGetExceptionFilterSecondCommandWide(index, out bufferResult).ThrowDbgEngNotOK();

            return bufferResult;
        }

        /// <summary>
        /// The GetExceptionFilterSecondCommandWide method returns the command that will be executed by the debugger engine upon the second chance of a specified exception.
        /// </summary>
        /// <param name="index">[in] Specifies the index of the exception filter whose second-chance command will be returned. Index can also refer to the default exception filter to return the second-chance command for those exceptions that do not have a specific or arbitrary exception filter.</param>
        /// <param name="bufferResult">[out, optional] Receives the second-chance command for the exception filter.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// Only exception filters support a second-chance command. If Index refers to a specific event filter, the command
        /// returned to Buffer will be empty. The returned command will also be empty if no second-chance command has been
        /// set for the specified exception. For more information about event filters, see Event Filters.
        /// </remarks>
        public HRESULT TryGetExceptionFilterSecondCommandWide(int index, out string bufferResult)
        {
            /*HRESULT GetExceptionFilterSecondCommandWide(
            [In] int Index,
            [SRI.Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U2, SizeParamIndex = 2)] char[] Buffer,
            [In] int BufferSize,
            [Out] out int CommandSize);*/
            char[] buffer;
            int bufferSize = 0;
            int commandSize;
            HRESULT hr = Raw4.GetExceptionFilterSecondCommandWide(index, null, bufferSize, out commandSize);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER && hr != HRESULT.S_OK)
                goto fail;

            bufferSize = commandSize;
            buffer = new char[bufferSize];
            hr = Raw4.GetExceptionFilterSecondCommandWide(index, buffer, bufferSize, out commandSize);

            if (hr == HRESULT.S_OK)
            {
                bufferResult = CreateString(buffer, commandSize);

                return hr;
            }

            fail:
            bufferResult = default(string);

            return hr;
        }

        #endregion
        #region SetExceptionFilterSecondCommandWide

        /// <summary>
        /// The SetExceptionFilterSecondCommandWide method sets the command that will be executed by the debugger engine on the second chance of a specified exception.
        /// </summary>
        /// <param name="index">[in] Specifies the index of the exception filter whose second-chance command will be set. Index must not refer to the specific event filters as these are not exception filters and only exception events get a second chance.<para/>
        /// If Index refers to the default exception filter, the second-chance command is set for all exceptions that do not have an exception filter.</param>
        /// <param name="command">[in] Receives the second-chance command for the exception filter.</param>
        /// <remarks>
        /// For more information about event filters, see Event Filters.
        /// </remarks>
        public void SetExceptionFilterSecondCommandWide(int index, string command)
        {
            TrySetExceptionFilterSecondCommandWide(index, command).ThrowDbgEngNotOK();
        }

        /// <summary>
        /// The SetExceptionFilterSecondCommandWide method sets the command that will be executed by the debugger engine on the second chance of a specified exception.
        /// </summary>
        /// <param name="index">[in] Specifies the index of the exception filter whose second-chance command will be set. Index must not refer to the specific event filters as these are not exception filters and only exception events get a second chance.<para/>
        /// If Index refers to the default exception filter, the second-chance command is set for all exceptions that do not have an exception filter.</param>
        /// <param name="command">[in] Receives the second-chance command for the exception filter.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// For more information about event filters, see Event Filters.
        /// </remarks>
        public HRESULT TrySetExceptionFilterSecondCommandWide(int index, string command)
        {
            /*HRESULT SetExceptionFilterSecondCommandWide(
            [In] int Index,
            [In, MarshalAs(UnmanagedType.LPWStr)] string Command);*/
            return Raw4.SetExceptionFilterSecondCommandWide(index, command);
        }

        #endregion
        #region GetTextReplacementWide

        /// <summary>
        /// The GetTextReplacementWide method returns the value of a user-named alias or an automatic alias.
        /// </summary>
        /// <param name="srcText">[in, optional] Specifies the name of the alias. The engine first searches the user-named aliases for one with this name.<para/>
        /// Then, if no match is found, the automatic aliases are searched. If SrcText is NULL, Index is used to specify the alias.</param>
        /// <param name="index">[in] Specifies the index of an alias. The indexes of the user-named aliases come before the indexes of the automatic aliases.<para/>
        /// Index is only used if SrcText is NULL. Index can be used along with <see cref="NumberTextReplacements"/> to iterate over all the user-named and automatic aliases.</param>
        /// <returns>The values that were emitted from the COM method.</returns>
        /// <remarks>
        /// Before executing commands or evaluating expressions, the debugger engine will replace the alias specified by SrcBuffer
        /// with the value of the alias (specified by DstBuffer). For an overview of aliases used by the debugger engine, see
        /// Using Aliases. For more information about using aliases with the debugger engine API, see Interacting with the
        /// Engine.
        /// </remarks>
        public GetTextReplacementWideResult GetTextReplacementWide(string srcText, int index)
        {
            GetTextReplacementWideResult result;
            TryGetTextReplacementWide(srcText, index, out result).ThrowDbgEngNotOK();

            return result;
        }

        /// <summary>
        /// The GetTextReplacementWide method returns the value of a user-named alias or an automatic alias.
        /// </summary>
        /// <param name="srcText">[in, optional] Specifies the name of the alias. The engine first searches the user-named aliases for one with this name.<para/>
        /// Then, if no match is found, the automatic aliases are searched. If SrcText is NULL, Index is used to specify the alias.</param>
        /// <param name="index">[in] Specifies the index of an alias. The indexes of the user-named aliases come before the indexes of the automatic aliases.<para/>
        /// Index is only used if SrcText is NULL. Index can be used along with <see cref="NumberTextReplacements"/> to iterate over all the user-named and automatic aliases.</param>
        /// <param name="result">The values that were emitted from the COM method.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// Before executing commands or evaluating expressions, the debugger engine will replace the alias specified by SrcBuffer
        /// with the value of the alias (specified by DstBuffer). For an overview of aliases used by the debugger engine, see
        /// Using Aliases. For more information about using aliases with the debugger engine API, see Interacting with the
        /// Engine.
        /// </remarks>
        public HRESULT TryGetTextReplacementWide(string srcText, int index, out GetTextReplacementWideResult result)
        {
            /*HRESULT GetTextReplacementWide(
            [In, MarshalAs(UnmanagedType.LPWStr)] string SrcText,
            [In] int Index,
            [SRI.Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U2, SizeParamIndex = 3)] char[] SrcBuffer,
            [In] int SrcBufferSize,
            [Out] out int SrcSize,
            [SRI.Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U2, SizeParamIndex = 6)] char[] DstBuffer,
            [In] int DstBufferSize,
            [Out] out int DstSize);*/
            char[] srcBuffer;
            int srcBufferSize = 0;
            int srcSize;
            char[] dstBuffer;
            int dstBufferSize = 0;
            int dstSize;
            HRESULT hr = Raw4.GetTextReplacementWide(srcText, index, null, srcBufferSize, out srcSize, null, dstBufferSize, out dstSize);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER && hr != HRESULT.S_OK)
                goto fail;

            srcBufferSize = srcSize;
            srcBuffer = new char[srcBufferSize];
            dstBufferSize = dstSize;
            dstBuffer = new char[dstBufferSize];
            hr = Raw4.GetTextReplacementWide(srcText, index, srcBuffer, srcBufferSize, out srcSize, dstBuffer, dstBufferSize, out dstSize);

            if (hr == HRESULT.S_OK)
            {
                result = new GetTextReplacementWideResult(CreateString(srcBuffer, srcSize), CreateString(dstBuffer, dstSize));

                return hr;
            }

            fail:
            result = default(GetTextReplacementWideResult);

            return hr;
        }

        #endregion
        #region SetTextReplacementWide

        /// <summary>
        /// The SetTextReplacementWide method sets the value of a user-named alias.
        /// </summary>
        /// <param name="srcText">[in] Specifies the name of the user-named alias. The debugger engine makes a copy of this string. If SrcText is the same as the name of an automatic alias, the automatic alias is hidden by the new user-named alias.</param>
        /// <param name="dstText">[in, optional] Specifies the value of the user-named alias. The debugger engine makes a copy of this string. If DstText is NULL, the user-named alias is removed.</param>
        /// <remarks>
        /// Before executing commands or evaluating expressions, the debugger engine will replace the alias specified by SrcText
        /// with the value of the alias (specified by DstText). If SrcText is an asterisk (*) and DstText is NULL, all user-named
        /// aliases are removed. This is the same behavior as the <see cref="RemoveTextReplacements"/> method.
        /// When an alias is changed by this method, the event callbacks are notified by passing the DEBUG_CES_TEXT_REPLACEMENTS
        /// flag to the <see cref="IDebugEventCallbacks.ChangeEngineState"/> callback method. For an overview of aliases used
        /// by the debugger engine, see Using Aliases. For more information about using aliases with the debugger engine API,
        /// see Interacting with the Engine.
        /// </remarks>
        public void SetTextReplacementWide(string srcText, string dstText)
        {
            TrySetTextReplacementWide(srcText, dstText).ThrowDbgEngNotOK();
        }

        /// <summary>
        /// The SetTextReplacementWide method sets the value of a user-named alias.
        /// </summary>
        /// <param name="srcText">[in] Specifies the name of the user-named alias. The debugger engine makes a copy of this string. If SrcText is the same as the name of an automatic alias, the automatic alias is hidden by the new user-named alias.</param>
        /// <param name="dstText">[in, optional] Specifies the value of the user-named alias. The debugger engine makes a copy of this string. If DstText is NULL, the user-named alias is removed.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// Before executing commands or evaluating expressions, the debugger engine will replace the alias specified by SrcText
        /// with the value of the alias (specified by DstText). If SrcText is an asterisk (*) and DstText is NULL, all user-named
        /// aliases are removed. This is the same behavior as the <see cref="RemoveTextReplacements"/> method.
        /// When an alias is changed by this method, the event callbacks are notified by passing the DEBUG_CES_TEXT_REPLACEMENTS
        /// flag to the <see cref="IDebugEventCallbacks.ChangeEngineState"/> callback method. For an overview of aliases used
        /// by the debugger engine, see Using Aliases. For more information about using aliases with the debugger engine API,
        /// see Interacting with the Engine.
        /// </remarks>
        public HRESULT TrySetTextReplacementWide(string srcText, string dstText)
        {
            /*HRESULT SetTextReplacementWide(
            [In, MarshalAs(UnmanagedType.LPWStr)] string SrcText,
            [In, MarshalAs(UnmanagedType.LPWStr)] string DstText);*/
            return Raw4.SetTextReplacementWide(srcText, dstText);
        }

        #endregion
        #region SetExpressionSyntaxByNameWide

        /// <summary>
        /// The SetExpressionSyntaxByNameWide method sets the syntax that the engine will use to evaluate expressions.
        /// </summary>
        /// <param name="abbrevName">[in] Specifies the abbreviated name of the syntax. It can be one of the following strings: Expressions will be evaluated according to C++ syntax.<para/>
        /// For details of this syntax, see C++ Numbers and Operators. Expressions will be evaluated according to MASM syntax.<para/>
        /// For details of this syntax, see MASM Numbers and Operators.</param>
        /// <remarks>
        /// The expression syntax is a global setting within the engine, so setting the expression syntax will affect all clients.
        /// The expression syntax of the engine determines how the engine will interpret expressions passed to <see cref="Evaluate"/>,
        /// <see cref="Execute"/>, and any other method that evaluates an expression. After the expression syntax
        /// has been changed, the engine sends out notification to the <see cref="IDebugEventCallbacks"/> callback object registered
        /// with each client. It also passes the DEBUG_CES_EXPRESSION_SYNTAX flag to the <see cref="IDebugEventCallbacks.ChangeEngineState"/>
        /// method.
        /// </remarks>
        public void SetExpressionSyntaxByNameWide(string abbrevName)
        {
            TrySetExpressionSyntaxByNameWide(abbrevName).ThrowDbgEngNotOK();
        }

        /// <summary>
        /// The SetExpressionSyntaxByNameWide method sets the syntax that the engine will use to evaluate expressions.
        /// </summary>
        /// <param name="abbrevName">[in] Specifies the abbreviated name of the syntax. It can be one of the following strings: Expressions will be evaluated according to C++ syntax.<para/>
        /// For details of this syntax, see C++ Numbers and Operators. Expressions will be evaluated according to MASM syntax.<para/>
        /// For details of this syntax, see MASM Numbers and Operators.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// The expression syntax is a global setting within the engine, so setting the expression syntax will affect all clients.
        /// The expression syntax of the engine determines how the engine will interpret expressions passed to <see cref="Evaluate"/>,
        /// <see cref="Execute"/>, and any other method that evaluates an expression. After the expression syntax
        /// has been changed, the engine sends out notification to the <see cref="IDebugEventCallbacks"/> callback object registered
        /// with each client. It also passes the DEBUG_CES_EXPRESSION_SYNTAX flag to the <see cref="IDebugEventCallbacks.ChangeEngineState"/>
        /// method.
        /// </remarks>
        public HRESULT TrySetExpressionSyntaxByNameWide(string abbrevName)
        {
            /*HRESULT SetExpressionSyntaxByNameWide(
            [In, MarshalAs(UnmanagedType.LPWStr)] string AbbrevName);*/
            return Raw4.SetExpressionSyntaxByNameWide(abbrevName);
        }

        #endregion
        #region GetExpressionSyntaxNamesWide

        /// <summary>
        /// The GetExpressionSyntaxNamesWide method returns the full and abbreviated names of an expression syntax.
        /// </summary>
        /// <param name="index">[in] Specifies the index of the expression syntax. Index should be between zero and the number of expression syntaxes returned by <see cref="NumberExpressionSyntaxes"/> minus one.</param>
        /// <returns>The values that were emitted from the COM method.</returns>
        /// <remarks>
        /// Currently, there are two expression syntaxes, their full names are "Microsoft Assembler expressions" and "C++ source
        /// expressions." The corresponding abbreviated expression syntaxes are "MASM" and "C++."
        /// </remarks>
        public GetExpressionSyntaxNamesWideResult GetExpressionSyntaxNamesWide(int index)
        {
            GetExpressionSyntaxNamesWideResult result;
            TryGetExpressionSyntaxNamesWide(index, out result).ThrowDbgEngNotOK();

            return result;
        }

        /// <summary>
        /// The GetExpressionSyntaxNamesWide method returns the full and abbreviated names of an expression syntax.
        /// </summary>
        /// <param name="index">[in] Specifies the index of the expression syntax. Index should be between zero and the number of expression syntaxes returned by <see cref="NumberExpressionSyntaxes"/> minus one.</param>
        /// <param name="result">The values that were emitted from the COM method.</param>
        /// <returns>This method can also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// Currently, there are two expression syntaxes, their full names are "Microsoft Assembler expressions" and "C++ source
        /// expressions." The corresponding abbreviated expression syntaxes are "MASM" and "C++."
        /// </remarks>
        public HRESULT TryGetExpressionSyntaxNamesWide(int index, out GetExpressionSyntaxNamesWideResult result)
        {
            /*HRESULT GetExpressionSyntaxNamesWide(
            [In] int Index,
            [SRI.Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U2, SizeParamIndex = 2)] char[] FullNameBuffer,
            [In] int FullNameBufferSize,
            [Out] out int FullNameSize,
            [SRI.Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U2, SizeParamIndex = 5)] char[] AbbrevNameBuffer,
            [In] int AbbrevNameBufferSize,
            [Out] out int AbbrevNameSize);*/
            char[] fullNameBuffer;
            int fullNameBufferSize = 0;
            int fullNameSize;
            char[] abbrevNameBuffer;
            int abbrevNameBufferSize = 0;
            int abbrevNameSize;
            HRESULT hr = Raw4.GetExpressionSyntaxNamesWide(index, null, fullNameBufferSize, out fullNameSize, null, abbrevNameBufferSize, out abbrevNameSize);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER && hr != HRESULT.S_OK)
                goto fail;

            fullNameBufferSize = fullNameSize;
            fullNameBuffer = new char[fullNameBufferSize];
            abbrevNameBufferSize = abbrevNameSize;
            abbrevNameBuffer = new char[abbrevNameBufferSize];
            hr = Raw4.GetExpressionSyntaxNamesWide(index, fullNameBuffer, fullNameBufferSize, out fullNameSize, abbrevNameBuffer, abbrevNameBufferSize, out abbrevNameSize);

            if (hr == HRESULT.S_OK)
            {
                result = new GetExpressionSyntaxNamesWideResult(CreateString(fullNameBuffer, fullNameSize), CreateString(abbrevNameBuffer, abbrevNameSize));

                return hr;
            }

            fail:
            result = default(GetExpressionSyntaxNamesWideResult);

            return hr;
        }

        #endregion
        #region GetEventIndexDescriptionWide

        /// <summary>
        /// The GetEventIndexDescriptionWide method describes the specified event in a static list of events for the current target.
        /// </summary>
        /// <param name="index">[in] Specifies the index of the event whose description will be returned.</param>
        /// <param name="which">[in] Specifies which piece of the event description to return. Currently only DEBUG_EINDEX_NAME is supported; this returns the name of the event.</param>
        /// <returns>[in, optional] Receives the description of the event. If Buffer is NULL, this information is not returned.</returns>
        /// <remarks>
        /// The amount of descriptive information available for a particular target varies depending on the type of the target.
        /// </remarks>
        public string GetEventIndexDescriptionWide(int index, DEBUG_EINDEX which)
        {
            string bufferResult;
            TryGetEventIndexDescriptionWide(index, which, out bufferResult).ThrowDbgEngNotOK();

            return bufferResult;
        }

        /// <summary>
        /// The GetEventIndexDescriptionWide method describes the specified event in a static list of events for the current target.
        /// </summary>
        /// <param name="index">[in] Specifies the index of the event whose description will be returned.</param>
        /// <param name="which">[in] Specifies which piece of the event description to return. Currently only DEBUG_EINDEX_NAME is supported; this returns the name of the event.</param>
        /// <param name="bufferResult">[in, optional] Receives the description of the event. If Buffer is NULL, this information is not returned.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// The amount of descriptive information available for a particular target varies depending on the type of the target.
        /// </remarks>
        public HRESULT TryGetEventIndexDescriptionWide(int index, DEBUG_EINDEX which, out string bufferResult)
        {
            /*HRESULT GetEventIndexDescriptionWide(
            [In] int Index,
            [In] DEBUG_EINDEX Which,
            [SRI.Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U2, SizeParamIndex = 3)] char[] Buffer,
            [In] int BufferSize,
            [Out] out int DescSize);*/
            char[] buffer;
            int bufferSize = 0;
            int descSize;
            HRESULT hr = Raw4.GetEventIndexDescriptionWide(index, which, null, bufferSize, out descSize);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER && hr != HRESULT.S_OK)
                goto fail;

            bufferSize = descSize;
            buffer = new char[bufferSize];
            hr = Raw4.GetEventIndexDescriptionWide(index, which, buffer, bufferSize, out descSize);

            if (hr == HRESULT.S_OK)
            {
                bufferResult = CreateString(buffer, descSize);

                return hr;
            }

            fail:
            bufferResult = default(string);

            return hr;
        }

        #endregion
        #region OpenLogFile2

        /// <summary>
        /// The OpenLogFile2 method opens a log file that will receive output from the client objects.
        /// </summary>
        /// <param name="file">[in] Specifies the name of the log file. File can include a relative or absolute path; relative paths are relative to the directory in which the debugger was started.<para/>
        /// If the file does not exist, it will be created.</param>
        /// <returns>[in] Specifies the bit-flags that control the nature of the log file. Flags can contain flags from the following table.<para/>
        /// Alternatively, Flags can be set to DEBUG_LOG_DEFAULT for the default set of options that contains none of the flags.</returns>
        /// <remarks>
        /// Only one log file can be open at a time. If there is already a log file open, it will be closed. For more information
        /// about log files, see Using Input and Output.
        /// </remarks>
        public DEBUG_LOG OpenLogFile2(string file)
        {
            DEBUG_LOG flags;
            TryOpenLogFile2(file, out flags).ThrowDbgEngNotOK();

            return flags;
        }

        /// <summary>
        /// The OpenLogFile2 method opens a log file that will receive output from the client objects.
        /// </summary>
        /// <param name="file">[in] Specifies the name of the log file. File can include a relative or absolute path; relative paths are relative to the directory in which the debugger was started.<para/>
        /// If the file does not exist, it will be created.</param>
        /// <param name="flags">[in] Specifies the bit-flags that control the nature of the log file. Flags can contain flags from the following table.<para/>
        /// Alternatively, Flags can be set to DEBUG_LOG_DEFAULT for the default set of options that contains none of the flags.</param>
        /// <returns>This method can also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// Only one log file can be open at a time. If there is already a log file open, it will be closed. For more information
        /// about log files, see Using Input and Output.
        /// </remarks>
        public HRESULT TryOpenLogFile2(string file, out DEBUG_LOG flags)
        {
            /*HRESULT OpenLogFile2(
            [In, MarshalAs(UnmanagedType.LPStr)] string File,
            [Out] out DEBUG_LOG Flags);*/
            return Raw4.OpenLogFile2(file, out flags);
        }

        #endregion
        #region OpenLogFile2Wide

        /// <summary>
        /// The OpenLogFile2Wide method opens a log file that will receive output from the client objects.
        /// </summary>
        /// <param name="file">[in] Specifies the name of the log file. File can include a relative or absolute path; relative paths are relative to the directory in which the debugger was started.<para/>
        /// If the file does not exist, it will be created.</param>
        /// <returns>[in] Specifies the bit-flags that control the nature of the log file. Flags can contain flags from the following table.<para/>
        /// Alternatively, Flags can be set to DEBUG_LOG_DEFAULT for the default set of options that contains none of the flags.</returns>
        /// <remarks>
        /// Only one log file can be open at a time. If there is already a log file open, it will be closed. For more information
        /// about log files, see Using Input and Output.
        /// </remarks>
        public DEBUG_LOG OpenLogFile2Wide(string file)
        {
            DEBUG_LOG flags;
            TryOpenLogFile2Wide(file, out flags).ThrowDbgEngNotOK();

            return flags;
        }

        /// <summary>
        /// The OpenLogFile2Wide method opens a log file that will receive output from the client objects.
        /// </summary>
        /// <param name="file">[in] Specifies the name of the log file. File can include a relative or absolute path; relative paths are relative to the directory in which the debugger was started.<para/>
        /// If the file does not exist, it will be created.</param>
        /// <param name="flags">[in] Specifies the bit-flags that control the nature of the log file. Flags can contain flags from the following table.<para/>
        /// Alternatively, Flags can be set to DEBUG_LOG_DEFAULT for the default set of options that contains none of the flags.</param>
        /// <returns>This method can also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// Only one log file can be open at a time. If there is already a log file open, it will be closed. For more information
        /// about log files, see Using Input and Output.
        /// </remarks>
        public HRESULT TryOpenLogFile2Wide(string file, out DEBUG_LOG flags)
        {
            /*HRESULT OpenLogFile2Wide(
            [In, MarshalAs(UnmanagedType.LPWStr)] string File,
            [Out] out DEBUG_LOG Flags);*/
            return Raw4.OpenLogFile2Wide(file, out flags);
        }

        #endregion
        #region GetSystemVersionString

        /// <summary>
        /// The GetSystemVersionString method returns a string that describes the target's operating system version.
        /// </summary>
        /// <param name="which">[in] Specifies which version string to return. The possible values are listed in the following table.</param>
        /// <returns>[out, optional] Receives the version string. If Buffer is NULL, this information is not returned.</returns>
        /// <remarks>
        /// For more information, see Target Information.
        /// </remarks>
        public string GetSystemVersionString(DEBUG_SYSVERSTR which)
        {
            string bufferResult;
            TryGetSystemVersionString(which, out bufferResult).ThrowDbgEngNotOK();

            return bufferResult;
        }

        /// <summary>
        /// The GetSystemVersionString method returns a string that describes the target's operating system version.
        /// </summary>
        /// <param name="which">[in] Specifies which version string to return. The possible values are listed in the following table.</param>
        /// <param name="bufferResult">[out, optional] Receives the version string. If Buffer is NULL, this information is not returned.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// For more information, see Target Information.
        /// </remarks>
        public HRESULT TryGetSystemVersionString(DEBUG_SYSVERSTR which, out string bufferResult)
        {
            /*HRESULT GetSystemVersionString(
            [In] DEBUG_SYSVERSTR Which,
            [SRI.Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U1, SizeParamIndex = 2)] byte[] Buffer,
            [In] int BufferSize,
            [Out] out int StringSize);*/
            byte[] buffer;
            int bufferSize = 0;
            int stringSize;
            HRESULT hr = Raw4.GetSystemVersionString(which, null, bufferSize, out stringSize);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER && hr != HRESULT.S_OK)
                goto fail;

            bufferSize = stringSize;
            buffer = new byte[bufferSize];
            hr = Raw4.GetSystemVersionString(which, buffer, bufferSize, out stringSize);

            if (hr == HRESULT.S_OK)
            {
                bufferResult = CreateString(buffer, stringSize);

                return hr;
            }

            fail:
            bufferResult = default(string);

            return hr;
        }

        #endregion
        #region GetSystemVersionStringWide

        /// <summary>
        /// The GetSystemVersionStringWide method returns a string that describes the target's operating system version.
        /// </summary>
        /// <param name="which">[in] Specifies which version string to return. The possible values are listed in the following table.</param>
        /// <returns>[out, optional] Receives the version string. If Buffer is NULL, this information is not returned.</returns>
        /// <remarks>
        /// For more information, see Target Information.
        /// </remarks>
        public string GetSystemVersionStringWide(DEBUG_SYSVERSTR which)
        {
            string bufferResult;
            TryGetSystemVersionStringWide(which, out bufferResult).ThrowDbgEngNotOK();

            return bufferResult;
        }

        /// <summary>
        /// The GetSystemVersionStringWide method returns a string that describes the target's operating system version.
        /// </summary>
        /// <param name="which">[in] Specifies which version string to return. The possible values are listed in the following table.</param>
        /// <param name="bufferResult">[out, optional] Receives the version string. If Buffer is NULL, this information is not returned.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// For more information, see Target Information.
        /// </remarks>
        public HRESULT TryGetSystemVersionStringWide(DEBUG_SYSVERSTR which, out string bufferResult)
        {
            /*HRESULT GetSystemVersionStringWide(
            [In] DEBUG_SYSVERSTR Which,
            [SRI.Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U2, SizeParamIndex = 2)] char[] Buffer,
            [In] int BufferSize,
            [Out] out int StringSize);*/
            char[] buffer;
            int bufferSize = 0;
            int stringSize;
            HRESULT hr = Raw4.GetSystemVersionStringWide(which, null, bufferSize, out stringSize);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER && hr != HRESULT.S_OK)
                goto fail;

            bufferSize = stringSize;
            buffer = new char[bufferSize];
            hr = Raw4.GetSystemVersionStringWide(which, buffer, bufferSize, out stringSize);

            if (hr == HRESULT.S_OK)
            {
                bufferResult = CreateString(buffer, stringSize);

                return hr;
            }

            fail:
            bufferResult = default(string);

            return hr;
        }

        #endregion
        #region GetContextStackTrace

        /// <summary>
        /// The GetContextStackTrace method returns the frames at the top of the call stack, starting with an arbitrary register context and returning the reconstructed register context for each stack frame.
        /// </summary>
        /// <param name="startContext">[in, optional] Specifies the register context for the top of the stack.</param>
        /// <param name="startContextSize">[in] Specifies the size, in bytes, of the StartContext register context.</param>
        /// <param name="frameSize">[in] Specifies the number of items in the array Frames.</param>
        /// <param name="frameContexts">[out, optional] Receives the reconstructed register context for each frame in the stack. The entries in this array correspond to the entries in the Frames array.<para/>
        /// The type of the thread context is the CONTEXT structure for the target's effective processor. If FrameContexts is NULL, this information is not returned.</param>
        /// <param name="frameContextsSize">[in] Specifies the size, in bytes, of the memory pointed to by FrameContexts. The number of stack frames returned equals the number of contexts returned, and FrameContextsSize must equal FramesSize times FrameContextsEntrySize.</param>
        /// <param name="frameContextsEntrySize">[in] Specifies the size, in bytes, of each frame context in FrameContexts.</param>
        /// <returns>The values that were emitted from the COM method.</returns>
        /// <remarks>
        /// The stack trace returned to Frames and FrameContexts can be printed using <see cref="OutputContextStackTrace"/>.
        /// It is common for stack unwinds to restore only a subset of the registers. For example, stack unwinds will not always
        /// restore the volatile register state because the volatile registers are scratch registers and code does not need
        /// to preserve them. Registers that are not restored on unwind are left as the last value restored, so care should
        /// be taken when using the register state that might not be restored by an unwind.
        /// </remarks>
        public GetContextStackTraceResult GetContextStackTrace(IntPtr startContext, int startContextSize, int frameSize, IntPtr frameContexts, int frameContextsSize, int frameContextsEntrySize)
        {
            GetContextStackTraceResult result;
            TryGetContextStackTrace(startContext, startContextSize, frameSize, frameContexts, frameContextsSize, frameContextsEntrySize, out result).ThrowDbgEngNotOK();

            return result;
        }

        /// <summary>
        /// The GetContextStackTrace method returns the frames at the top of the call stack, starting with an arbitrary register context and returning the reconstructed register context for each stack frame.
        /// </summary>
        /// <param name="startContext">[in, optional] Specifies the register context for the top of the stack.</param>
        /// <param name="startContextSize">[in] Specifies the size, in bytes, of the StartContext register context.</param>
        /// <param name="frameSize">[in] Specifies the number of items in the array Frames.</param>
        /// <param name="frameContexts">[out, optional] Receives the reconstructed register context for each frame in the stack. The entries in this array correspond to the entries in the Frames array.<para/>
        /// The type of the thread context is the CONTEXT structure for the target's effective processor. If FrameContexts is NULL, this information is not returned.</param>
        /// <param name="frameContextsSize">[in] Specifies the size, in bytes, of the memory pointed to by FrameContexts. The number of stack frames returned equals the number of contexts returned, and FrameContextsSize must equal FramesSize times FrameContextsEntrySize.</param>
        /// <param name="frameContextsEntrySize">[in] Specifies the size, in bytes, of each frame context in FrameContexts.</param>
        /// <param name="result">The values that were emitted from the COM method.</param>
        /// <returns>This method can also return error values. For more information, see Return Values.</returns>
        /// <remarks>
        /// The stack trace returned to Frames and FrameContexts can be printed using <see cref="OutputContextStackTrace"/>.
        /// It is common for stack unwinds to restore only a subset of the registers. For example, stack unwinds will not always
        /// restore the volatile register state because the volatile registers are scratch registers and code does not need
        /// to preserve them. Registers that are not restored on unwind are left as the last value restored, so care should
        /// be taken when using the register state that might not be restored by an unwind.
        /// </remarks>
        public HRESULT TryGetContextStackTrace(IntPtr startContext, int startContextSize, int frameSize, IntPtr frameContexts, int frameContextsSize, int frameContextsEntrySize, out GetContextStackTraceResult result)
        {
            /*HRESULT GetContextStackTrace(
            [In] IntPtr StartContext,
            [In] int StartContextSize,
            [SRI.Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 3)] DEBUG_STACK_FRAME[] Frames,
            [In] int FrameSize,
            [In] IntPtr FrameContexts,
            [In] int FrameContextsSize,
            [In] int FrameContextsEntrySize,
            [Out] out int FramesFilled);*/
            DEBUG_STACK_FRAME[] frames = new DEBUG_STACK_FRAME[frameSize];
            int framesFilled;
            HRESULT hr = Raw4.GetContextStackTrace(startContext, startContextSize, frames, frameSize, frameContexts, frameContextsSize, frameContextsEntrySize, out framesFilled);

            if (hr == HRESULT.S_OK)
                result = new GetContextStackTraceResult(frames, framesFilled);
            else
                result = default(GetContextStackTraceResult);

            return hr;
        }

        #endregion
        #region OutputContextStackTrace

        /// <summary>
        /// The OutputContextStackTrace method prints the call stack specified by an array of stack frames and corresponding register contexts.
        /// </summary>
        /// <param name="outputControl">[in] Specifies where to send the output. For possible values, see DEBUG_OUTCTL_XXX.</param>
        /// <param name="frames">[in] Specifies the array of stack frames to output. The number of elements in this array is FramesSize. If Frames is NULL, the current stack frame is used.</param>
        /// <param name="framesSize">[in] Specifies the number of frames to output.</param>
        /// <param name="frameContexts">[in] Specifies the register context for each frame in the stack. The entries in this array correspond to the entries in the Frames array.<para/>
        /// The type of the thread context is the CONTEXT structure for the target's effective processor.</param>
        /// <param name="frameContextsSize">[in] Specifies the size, in bytes, of the memory pointed to by FrameContexts. The number of stack frames must equal the number of contexts, and FrameContextsSize must equal FramesSize multiplied by FrameContextsEntrySize.</param>
        /// <param name="frameContextsEntrySize">[in] Specifies the size, in bytes, of each frame context in FrameContexts.</param>
        /// <param name="flags">[in] Specifies bit flags that determine what information to output for each frame. Flags can be any combination of values from the following table.</param>
        /// <remarks>
        /// The array of stack frames can be obtained using <see cref="GetContextStackTrace"/>.
        /// </remarks>
        public void OutputContextStackTrace(DEBUG_OUTCTL outputControl, DEBUG_STACK_FRAME[] frames, int framesSize, IntPtr frameContexts, int frameContextsSize, int frameContextsEntrySize, DEBUG_STACK flags)
        {
            TryOutputContextStackTrace(outputControl, frames, framesSize, frameContexts, frameContextsSize, frameContextsEntrySize, flags).ThrowDbgEngNotOK();
        }

        /// <summary>
        /// The OutputContextStackTrace method prints the call stack specified by an array of stack frames and corresponding register contexts.
        /// </summary>
        /// <param name="outputControl">[in] Specifies where to send the output. For possible values, see DEBUG_OUTCTL_XXX.</param>
        /// <param name="frames">[in] Specifies the array of stack frames to output. The number of elements in this array is FramesSize. If Frames is NULL, the current stack frame is used.</param>
        /// <param name="framesSize">[in] Specifies the number of frames to output.</param>
        /// <param name="frameContexts">[in] Specifies the register context for each frame in the stack. The entries in this array correspond to the entries in the Frames array.<para/>
        /// The type of the thread context is the CONTEXT structure for the target's effective processor.</param>
        /// <param name="frameContextsSize">[in] Specifies the size, in bytes, of the memory pointed to by FrameContexts. The number of stack frames must equal the number of contexts, and FrameContextsSize must equal FramesSize multiplied by FrameContextsEntrySize.</param>
        /// <param name="frameContextsEntrySize">[in] Specifies the size, in bytes, of each frame context in FrameContexts.</param>
        /// <param name="flags">[in] Specifies bit flags that determine what information to output for each frame. Flags can be any combination of values from the following table.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// The array of stack frames can be obtained using <see cref="GetContextStackTrace"/>.
        /// </remarks>
        public HRESULT TryOutputContextStackTrace(DEBUG_OUTCTL outputControl, DEBUG_STACK_FRAME[] frames, int framesSize, IntPtr frameContexts, int frameContextsSize, int frameContextsEntrySize, DEBUG_STACK flags)
        {
            /*HRESULT OutputContextStackTrace(
            [In] DEBUG_OUTCTL OutputControl,
            [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] DEBUG_STACK_FRAME[] Frames,
            [In] int FramesSize,
            [In] IntPtr FrameContexts,
            [In] int FrameContextsSize,
            [In] int FrameContextsEntrySize,
            [In] DEBUG_STACK Flags);*/
            return Raw4.OutputContextStackTrace(outputControl, frames, framesSize, frameContexts, frameContextsSize, frameContextsEntrySize, flags);
        }

        #endregion
        #region GetStoredEventInformation

        /// <summary>
        /// The GetStoredEventInformation method retrieves information about an event of interest available in the current target.
        /// </summary>
        /// <param name="context">[out, optional] Receives the thread context of the stored event. The type of the thread context is the CONTEXT structure for the target's effective processor at the time of the event.<para/>
        /// The Context buffer must be large enough to hold this structure. If Context is NULL, this information is not returned.</param>
        /// <param name="contextSize">[in] Specifies the size, in bytes, of the buffer that Context specifies.</param>
        /// <param name="extraInformation">[out, optional] Receives extra information about the event. The contents of this extra information depends on the type of the event.<para/>
        /// If ExtraInformation is NULL, this information is not returned.</param>
        /// <param name="extraInformationSize">[in] Specifies the size, in bytes, of the buffer that ExtraInformation specifies.</param>
        /// <returns>The values that were emitted from the COM method.</returns>
        /// <remarks>
        /// Many targets do not have an event of interest. If the target is a user-mode minidump file, the dump file generator
        /// may store an additional event. Typically, this is the event that provoked the generator to save the dump file.
        /// For more information, see the topic Event Information.
        /// </remarks>
        public GetStoredEventInformationResult GetStoredEventInformation(IntPtr context, int contextSize, IntPtr extraInformation, int extraInformationSize)
        {
            GetStoredEventInformationResult result;
            TryGetStoredEventInformation(context, contextSize, extraInformation, extraInformationSize, out result).ThrowDbgEngNotOK();

            return result;
        }

        /// <summary>
        /// The GetStoredEventInformation method retrieves information about an event of interest available in the current target.
        /// </summary>
        /// <param name="context">[out, optional] Receives the thread context of the stored event. The type of the thread context is the CONTEXT structure for the target's effective processor at the time of the event.<para/>
        /// The Context buffer must be large enough to hold this structure. If Context is NULL, this information is not returned.</param>
        /// <param name="contextSize">[in] Specifies the size, in bytes, of the buffer that Context specifies.</param>
        /// <param name="extraInformation">[out, optional] Receives extra information about the event. The contents of this extra information depends on the type of the event.<para/>
        /// If ExtraInformation is NULL, this information is not returned.</param>
        /// <param name="extraInformationSize">[in] Specifies the size, in bytes, of the buffer that ExtraInformation specifies.</param>
        /// <param name="result">The values that were emitted from the COM method.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// Many targets do not have an event of interest. If the target is a user-mode minidump file, the dump file generator
        /// may store an additional event. Typically, this is the event that provoked the generator to save the dump file.
        /// For more information, see the topic Event Information.
        /// </remarks>
        public HRESULT TryGetStoredEventInformation(IntPtr context, int contextSize, IntPtr extraInformation, int extraInformationSize, out GetStoredEventInformationResult result)
        {
            /*HRESULT GetStoredEventInformation(
            [Out] out DEBUG_EVENT_TYPE Type,
            [Out] out int ProcessId,
            [Out] out int ThreadId,
            [In] IntPtr Context,
            [In] int ContextSize,
            [Out] out int ContextUsed,
            [In] IntPtr ExtraInformation,
            [In] int ExtraInformationSize,
            [Out] out int ExtraInformationUsed);*/
            DEBUG_EVENT_TYPE type;
            int processId;
            int threadId;
            int contextUsed;
            int extraInformationUsed;
            HRESULT hr = Raw4.GetStoredEventInformation(out type, out processId, out threadId, context, contextSize, out contextUsed, extraInformation, extraInformationSize, out extraInformationUsed);

            if (hr == HRESULT.S_OK)
                result = new GetStoredEventInformationResult(type, processId, threadId, contextUsed, extraInformationUsed);
            else
                result = default(GetStoredEventInformationResult);

            return hr;
        }

        #endregion
        #region GetManagedStatus

        /// <summary>
        /// Provides feedback on the engine's use of the runtime debugging APIs provided by the common language runtime (CLR).
        /// </summary>
        /// <param name="whichString">[in] A value that controls which string to use.</param>
        /// <returns>The values that were emitted from the COM method.</returns>
        public GetManagedStatusResult GetManagedStatus(DEBUG_MANSTR whichString)
        {
            GetManagedStatusResult result;
            TryGetManagedStatus(whichString, out result).ThrowDbgEngNotOK();

            return result;
        }

        /// <summary>
        /// Provides feedback on the engine's use of the runtime debugging APIs provided by the common language runtime (CLR).
        /// </summary>
        /// <param name="whichString">[in] A value that controls which string to use.</param>
        /// <param name="result">The values that were emitted from the COM method.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        public HRESULT TryGetManagedStatus(DEBUG_MANSTR whichString, out GetManagedStatusResult result)
        {
            /*HRESULT GetManagedStatus(
            [Out] out DEBUG_MANAGED Flags,
            [In] DEBUG_MANSTR WhichString,
            [SRI.Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U1, SizeParamIndex = 3)] byte[] String,
            [In] int StringSize,
            [Out] out int StringNeeded);*/
            DEBUG_MANAGED flags;
            byte[] @string;
            int stringSize = 0;
            int stringNeeded;
            HRESULT hr = Raw4.GetManagedStatus(out flags, whichString, null, stringSize, out stringNeeded);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER && hr != HRESULT.S_OK)
                goto fail;

            stringSize = stringNeeded;
            @string = new byte[stringSize];
            hr = Raw4.GetManagedStatus(out flags, whichString, @string, stringSize, out stringNeeded);

            if (hr == HRESULT.S_OK)
            {
                result = new GetManagedStatusResult(flags, CreateString(@string, stringNeeded));

                return hr;
            }

            fail:
            result = default(GetManagedStatusResult);

            return hr;
        }

        #endregion
        #region GetManagedStatusWide

        /// <summary>
        /// Provides feedback as a Unicode character string on the engine's use of the runtime debugging APIs provided by the common language runtime (CLR).
        /// </summary>
        /// <param name="whichString">[in] A value that controls which string to use.</param>
        /// <returns>The values that were emitted from the COM method.</returns>
        public GetManagedStatusWideResult GetManagedStatusWide(DEBUG_MANSTR whichString)
        {
            GetManagedStatusWideResult result;
            TryGetManagedStatusWide(whichString, out result).ThrowDbgEngNotOK();

            return result;
        }

        /// <summary>
        /// Provides feedback as a Unicode character string on the engine's use of the runtime debugging APIs provided by the common language runtime (CLR).
        /// </summary>
        /// <param name="whichString">[in] A value that controls which string to use.</param>
        /// <param name="result">The values that were emitted from the COM method.</param>
        /// <returns>This method may also return error values. See Return Values for more details. Managed debugging support relies on debugging functionality provided by the CLR.</returns>
        public HRESULT TryGetManagedStatusWide(DEBUG_MANSTR whichString, out GetManagedStatusWideResult result)
        {
            /*HRESULT GetManagedStatusWide(
            [Out] out DEBUG_MANAGED Flags,
            [In] DEBUG_MANSTR WhichString,
            [SRI.Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U2, SizeParamIndex = 3)] char[] String,
            [In] int StringSize,
            [Out] out int StringNeeded);*/
            DEBUG_MANAGED flags;
            char[] @string;
            int stringSize = 0;
            int stringNeeded;
            HRESULT hr = Raw4.GetManagedStatusWide(out flags, whichString, null, stringSize, out stringNeeded);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER && hr != HRESULT.S_OK)
                goto fail;

            stringSize = stringNeeded;
            @string = new char[stringSize];
            hr = Raw4.GetManagedStatusWide(out flags, whichString, @string, stringSize, out stringNeeded);

            if (hr == HRESULT.S_OK)
            {
                result = new GetManagedStatusWideResult(flags, CreateString(@string, stringNeeded));

                return hr;
            }

            fail:
            result = default(GetManagedStatusWideResult);

            return hr;
        }

        #endregion
        #region ResetManagedStatus

        /// <summary>
        /// Clears and reinitializes the engine's managed code debugging support of the runtime debugging APIs provided by the common language runtime (CLR).
        /// </summary>
        /// <param name="flags">[in] Flags for the debugging API.</param>
        public void ResetManagedStatus(DEBUG_MANRESET flags)
        {
            TryResetManagedStatus(flags).ThrowDbgEngNotOK();
        }

        /// <summary>
        /// Clears and reinitializes the engine's managed code debugging support of the runtime debugging APIs provided by the common language runtime (CLR).
        /// </summary>
        /// <param name="flags">[in] Flags for the debugging API.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        public HRESULT TryResetManagedStatus(DEBUG_MANRESET flags)
        {
            /*HRESULT ResetManagedStatus(
            [In] DEBUG_MANRESET Flags);*/
            return Raw4.ResetManagedStatus(flags);
        }

        #endregion
        #endregion
        #region IDebugControl5

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public IDebugControl5 Raw5 => (IDebugControl5) Raw;

        #region GetStackTraceEx

        /// <summary>
        /// The GetStackTraceEx method returns the frames at the top of the specified call stack. The GetStackTraceEx method provides inline frame support.<para/>
        /// For more information about working with inline functions, see Debugging Optimized Code and Inline Functions.
        /// </summary>
        /// <param name="frameOffset">[in] Specifies the location of the stack frame at the top of the stack. If FrameOffset is set to zero, the current frame pointer is used instead.</param>
        /// <param name="stackOffset">[in] Specifies the location of the current stack. If StackOffset is set to zero, the current stack pointer is used instead.</param>
        /// <param name="instructionOffset">[in] Specifies the location of the instruction of interest for the function that is represented by the stack frame at the top of the stack.<para/>
        /// If InstructionOffset is set to zero, the current instruction is used instead.</param>
        /// <param name="framesSize">[in] Specifies the number of items in the Frames array.</param>
        /// <returns>[out] Receives the stack frames. The number of elements this array holds is FrameSize.</returns>
        public DEBUG_STACK_FRAME_EX[] GetStackTraceEx(long frameOffset, long stackOffset, long instructionOffset, int framesSize)
        {
            DEBUG_STACK_FRAME_EX[] frames;
            TryGetStackTraceEx(frameOffset, stackOffset, instructionOffset, framesSize, out frames).ThrowDbgEngNotOK();

            return frames;
        }

        /// <summary>
        /// The GetStackTraceEx method returns the frames at the top of the specified call stack. The GetStackTraceEx method provides inline frame support.<para/>
        /// For more information about working with inline functions, see Debugging Optimized Code and Inline Functions.
        /// </summary>
        /// <param name="frameOffset">[in] Specifies the location of the stack frame at the top of the stack. If FrameOffset is set to zero, the current frame pointer is used instead.</param>
        /// <param name="stackOffset">[in] Specifies the location of the current stack. If StackOffset is set to zero, the current stack pointer is used instead.</param>
        /// <param name="instructionOffset">[in] Specifies the location of the instruction of interest for the function that is represented by the stack frame at the top of the stack.<para/>
        /// If InstructionOffset is set to zero, the current instruction is used instead.</param>
        /// <param name="frames">[out] Receives the stack frames. The number of elements this array holds is FrameSize.</param>
        /// <param name="framesSize">[in] Specifies the number of items in the Frames array.</param>
        /// <returns>This method may also return other error values. See Return Values for more details.</returns>
        public HRESULT TryGetStackTraceEx(long frameOffset, long stackOffset, long instructionOffset, int framesSize, out DEBUG_STACK_FRAME_EX[] frames)
        {
            /*HRESULT GetStackTraceEx(
            [In] long FrameOffset,
            [In] long StackOffset,
            [In] long InstructionOffset,
            [SRI.Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 4)] DEBUG_STACK_FRAME_EX[] Frames,
            [In] int FramesSize,
            [Out] out int FramesFilled);*/
            frames = new DEBUG_STACK_FRAME_EX[framesSize];
            int framesFilled;
            HRESULT hr = Raw5.GetStackTraceEx(frameOffset, stackOffset, instructionOffset, frames, framesSize, out framesFilled);

            if (framesSize != framesFilled)
                Array.Resize(ref frames, framesFilled);

            return hr;
        }

        #endregion
        #region OutputStackTraceEx

        /// <summary>
        /// The OutputStackTraceEx method outputs either the supplied stack frame or the current stack frames. The OutputStackTraceEx method provides inline frame support.<para/>
        /// For more information about working with inline functions, see Debugging Optimized Code and Inline Functions.
        /// </summary>
        /// <param name="outputControl">[in] Specifies where to send the output. For possible values, see DEBUG_OUTCTL_XXX.</param>
        /// <param name="frames">[in, optional] Specifies the array of stack frames to output. The number of elements in this array is FramesSize.<para/>
        /// If Frames is NULL, the current stack frames are used.</param>
        /// <param name="framesSize">[in] Specifies the number of frames to output.</param>
        /// <param name="flags">[in] Specifies bit flags that determine what information to output for each frame. Flags can be any combination of values from the following table.</param>
        /// <remarks>
        /// The array of stack frames can be obtained using <see cref="GetStackTraceEx"/>.
        /// </remarks>
        public void OutputStackTraceEx(int outputControl, DEBUG_STACK_FRAME_EX[] frames, int framesSize, DEBUG_STACK flags)
        {
            TryOutputStackTraceEx(outputControl, frames, framesSize, flags).ThrowDbgEngNotOK();
        }

        /// <summary>
        /// The OutputStackTraceEx method outputs either the supplied stack frame or the current stack frames. The OutputStackTraceEx method provides inline frame support.<para/>
        /// For more information about working with inline functions, see Debugging Optimized Code and Inline Functions.
        /// </summary>
        /// <param name="outputControl">[in] Specifies where to send the output. For possible values, see DEBUG_OUTCTL_XXX.</param>
        /// <param name="frames">[in, optional] Specifies the array of stack frames to output. The number of elements in this array is FramesSize.<para/>
        /// If Frames is NULL, the current stack frames are used.</param>
        /// <param name="framesSize">[in] Specifies the number of frames to output.</param>
        /// <param name="flags">[in] Specifies bit flags that determine what information to output for each frame. Flags can be any combination of values from the following table.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// The array of stack frames can be obtained using <see cref="GetStackTraceEx"/>.
        /// </remarks>
        public HRESULT TryOutputStackTraceEx(int outputControl, DEBUG_STACK_FRAME_EX[] frames, int framesSize, DEBUG_STACK flags)
        {
            /*HRESULT OutputStackTraceEx(
            [In] int OutputControl,
            [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] DEBUG_STACK_FRAME_EX[] Frames,
            [In] int FramesSize,
            [In] DEBUG_STACK Flags);*/
            return Raw5.OutputStackTraceEx(outputControl, frames, framesSize, flags);
        }

        #endregion
        #region GetContextStackTraceEx

        /// <summary>
        /// The GetContextStackTraceEx method returns the frames at the top of the call stack, starting with an arbitrary register context and returning the reconstructed register context for each stack frame.<para/>
        /// The GetContextStackTraceEx method provides inline frame support. For more information about working with inline functions, see Debugging Optimized Code and Inline Functions.
        /// </summary>
        /// <param name="startContext">[in, optional] Specifies the register context for the top of the stack.</param>
        /// <param name="startContextSize">[in] Specifies the size, in bytes, of the StartContext register context.</param>
        /// <param name="framesSize">[in] Specifies the number of items in the array Frames.</param>
        /// <param name="frameContexts">[out, optional] Receives the reconstructed register context for each frame in the stack. The entries in this array correspond to the entries in the Frames array.<para/>
        /// The type of the thread context is the CONTEXT structure for the target's effective processor. If FrameContexts is NULL, this information is not returned.</param>
        /// <param name="frameContextsSize">[in] Specifies the size, in bytes, of the memory pointed to by FrameContexts. The number of stack frames returned equals the number of contexts returned, and FrameContextsSize must equal FramesSize times FrameContextsEntrySize.</param>
        /// <param name="frameContextsEntrySize">[in] Specifies the size, in bytes, of each frame context in FrameContexts.</param>
        /// <returns>The values that were emitted from the COM method.</returns>
        /// <remarks>
        /// The stack trace returned to Frames and FrameContexts can be printed using <see cref="OutputContextStackTraceEx"/>.
        /// It is common for stack unwinds to restore only a subset of the registers. For example, stack unwinds will not always
        /// restore the volatile register state because the volatile registers are scratch registers and code does not need
        /// to preserve them. Registers that are not restored on unwind are left as the last value restored, so care should
        /// be taken when using the register state that might not be restored by an unwind.
        /// </remarks>
        public GetContextStackTraceExResult GetContextStackTraceEx(IntPtr startContext, int startContextSize, int framesSize, IntPtr frameContexts, int frameContextsSize, int frameContextsEntrySize)
        {
            GetContextStackTraceExResult result;
            TryGetContextStackTraceEx(startContext, startContextSize, framesSize, frameContexts, frameContextsSize, frameContextsEntrySize, out result).ThrowDbgEngNotOK();

            return result;
        }

        /// <summary>
        /// The GetContextStackTraceEx method returns the frames at the top of the call stack, starting with an arbitrary register context and returning the reconstructed register context for each stack frame.<para/>
        /// The GetContextStackTraceEx method provides inline frame support. For more information about working with inline functions, see Debugging Optimized Code and Inline Functions.
        /// </summary>
        /// <param name="startContext">[in, optional] Specifies the register context for the top of the stack.</param>
        /// <param name="startContextSize">[in] Specifies the size, in bytes, of the StartContext register context.</param>
        /// <param name="framesSize">[in] Specifies the number of items in the array Frames.</param>
        /// <param name="frameContexts">[out, optional] Receives the reconstructed register context for each frame in the stack. The entries in this array correspond to the entries in the Frames array.<para/>
        /// The type of the thread context is the CONTEXT structure for the target's effective processor. If FrameContexts is NULL, this information is not returned.</param>
        /// <param name="frameContextsSize">[in] Specifies the size, in bytes, of the memory pointed to by FrameContexts. The number of stack frames returned equals the number of contexts returned, and FrameContextsSize must equal FramesSize times FrameContextsEntrySize.</param>
        /// <param name="frameContextsEntrySize">[in] Specifies the size, in bytes, of each frame context in FrameContexts.</param>
        /// <param name="result">The values that were emitted from the COM method.</param>
        /// <returns>This method can also return error values. For more information, see Return Values.</returns>
        /// <remarks>
        /// The stack trace returned to Frames and FrameContexts can be printed using <see cref="OutputContextStackTraceEx"/>.
        /// It is common for stack unwinds to restore only a subset of the registers. For example, stack unwinds will not always
        /// restore the volatile register state because the volatile registers are scratch registers and code does not need
        /// to preserve them. Registers that are not restored on unwind are left as the last value restored, so care should
        /// be taken when using the register state that might not be restored by an unwind.
        /// </remarks>
        public HRESULT TryGetContextStackTraceEx(IntPtr startContext, int startContextSize, int framesSize, IntPtr frameContexts, int frameContextsSize, int frameContextsEntrySize, out GetContextStackTraceExResult result)
        {
            /*HRESULT GetContextStackTraceEx(
            [In] IntPtr StartContext,
            [In] int StartContextSize,
            [SRI.Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 3)] DEBUG_STACK_FRAME_EX[] Frames,
            [In] int FramesSize,
            [In] IntPtr FrameContexts,
            [In] int FrameContextsSize,
            [In] int FrameContextsEntrySize,
            [Out] out int FramesFilled);*/
            DEBUG_STACK_FRAME_EX[] frames = new DEBUG_STACK_FRAME_EX[framesSize];
            int framesFilled;
            HRESULT hr = Raw5.GetContextStackTraceEx(startContext, startContextSize, frames, framesSize, frameContexts, frameContextsSize, frameContextsEntrySize, out framesFilled);

            if (hr == HRESULT.S_OK)
                result = new GetContextStackTraceExResult(frames, framesFilled);
            else
                result = default(GetContextStackTraceExResult);

            return hr;
        }

        #endregion
        #region OutputContextStackTraceEx

        /// <summary>
        /// The OutputContextStackTraceEx method prints the call stack specified by an array of stack frames and corresponding register contexts.<para/>
        /// The OutputContextStackTraceEx method provides inline frame support. For more information about working with inline functions, see Debugging Optimized Code and Inline Functions.
        /// </summary>
        /// <param name="outputControl">[in] Specifies where to send the output. For possible values, see DEBUG_OUTCTL_XXX.</param>
        /// <param name="frames">[in] Specifies the array of stack frames to output. The number of elements in this array is FramesSize. If Frames is NULL, the current stack frame is used.</param>
        /// <param name="framesSize">[in] Specifies the number of frames to output.</param>
        /// <param name="frameContexts">[in] Specifies the register context for each frame in the stack. The entries in this array correspond to the entries in the Frames array.<para/>
        /// The type of the thread context is the CONTEXT structure for the target's effective processor.</param>
        /// <param name="frameContextsSize">[in] Specifies the size, in bytes, of the memory pointed to by FrameContexts. The number of stack frames must equal the number of contexts, and FrameContextsSize must equal FramesSize multiplied by FrameContextsEntrySize.</param>
        /// <param name="frameContextsEntrySize">[in] Specifies the size, in bytes, of each frame context in FrameContexts.</param>
        /// <param name="flags">[in] Specifies bit flags that determine what information to output for each frame. Flags can be any combination of values from the following table.</param>
        public void OutputContextStackTraceEx(int outputControl, DEBUG_STACK_FRAME_EX[] frames, int framesSize, IntPtr frameContexts, int frameContextsSize, int frameContextsEntrySize, DEBUG_STACK flags)
        {
            TryOutputContextStackTraceEx(outputControl, frames, framesSize, frameContexts, frameContextsSize, frameContextsEntrySize, flags).ThrowDbgEngNotOK();
        }

        /// <summary>
        /// The OutputContextStackTraceEx method prints the call stack specified by an array of stack frames and corresponding register contexts.<para/>
        /// The OutputContextStackTraceEx method provides inline frame support. For more information about working with inline functions, see Debugging Optimized Code and Inline Functions.
        /// </summary>
        /// <param name="outputControl">[in] Specifies where to send the output. For possible values, see DEBUG_OUTCTL_XXX.</param>
        /// <param name="frames">[in] Specifies the array of stack frames to output. The number of elements in this array is FramesSize. If Frames is NULL, the current stack frame is used.</param>
        /// <param name="framesSize">[in] Specifies the number of frames to output.</param>
        /// <param name="frameContexts">[in] Specifies the register context for each frame in the stack. The entries in this array correspond to the entries in the Frames array.<para/>
        /// The type of the thread context is the CONTEXT structure for the target's effective processor.</param>
        /// <param name="frameContextsSize">[in] Specifies the size, in bytes, of the memory pointed to by FrameContexts. The number of stack frames must equal the number of contexts, and FrameContextsSize must equal FramesSize multiplied by FrameContextsEntrySize.</param>
        /// <param name="frameContextsEntrySize">[in] Specifies the size, in bytes, of each frame context in FrameContexts.</param>
        /// <param name="flags">[in] Specifies bit flags that determine what information to output for each frame. Flags can be any combination of values from the following table.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        public HRESULT TryOutputContextStackTraceEx(int outputControl, DEBUG_STACK_FRAME_EX[] frames, int framesSize, IntPtr frameContexts, int frameContextsSize, int frameContextsEntrySize, DEBUG_STACK flags)
        {
            /*HRESULT OutputContextStackTraceEx(
            [In] int OutputControl,
            [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] DEBUG_STACK_FRAME_EX[] Frames,
            [In] int FramesSize,
            [In] IntPtr FrameContexts,
            [In] int FrameContextsSize,
            [In] int FrameContextsEntrySize,
            [In] DEBUG_STACK Flags);*/
            return Raw5.OutputContextStackTraceEx(outputControl, frames, framesSize, frameContexts, frameContextsSize, frameContextsEntrySize, flags);
        }

        #endregion
        #region GetBreakpointByGuid

        /// <summary>
        /// The GetBreakpointByGuid method returns the breakpoint with the specified breakpoint GUID.
        /// </summary>
        /// <param name="guid">[in] Specifies the breakpoint GUID of the breakpoint to return.</param>
        /// <returns>[out] Receives the breakpoint.</returns>
        public DebugBreakpoint GetBreakpointByGuid(Guid guid)
        {
            DebugBreakpoint bpResult;
            TryGetBreakpointByGuid(guid, out bpResult).ThrowDbgEngNotOK();

            return bpResult;
        }

        /// <summary>
        /// The GetBreakpointByGuid method returns the breakpoint with the specified breakpoint GUID.
        /// </summary>
        /// <param name="guid">[in] Specifies the breakpoint GUID of the breakpoint to return.</param>
        /// <param name="bpResult">[out] Receives the breakpoint.</param>
        /// <returns>This method can also return other error values. See Return Values for more details.</returns>
        public HRESULT TryGetBreakpointByGuid(Guid guid, out DebugBreakpoint bpResult)
        {
            /*HRESULT GetBreakpointByGuid(
            [In, MarshalAs(UnmanagedType.LPStruct)] Guid Guid,
            [Out, MarshalAs(UnmanagedType.Interface), ComAliasName("IDebugBreakpoint3")] out IDebugBreakpoint3 Bp);*/
            IDebugBreakpoint3 bp;
            HRESULT hr = Raw5.GetBreakpointByGuid(guid, out bp);

            if (hr == HRESULT.S_OK)
                bpResult = bp == null ? null : new DebugBreakpoint(bp);
            else
                bpResult = default(DebugBreakpoint);

            return hr;
        }

        #endregion
        #endregion
        #region IDebugControl6

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public IDebugControl6 Raw6 => (IDebugControl6) Raw;

        #region ExecutionStatusEx

        /// <summary>
        /// The GetExecutionStatusEx method returns information about the execution status of the debugger engine.
        /// </summary>
        public DEBUG_STATUS ExecutionStatusEx
        {
            get
            {
                DEBUG_STATUS status;
                TryGetExecutionStatusEx(out status).ThrowDbgEngNotOK();

                return status;
            }
        }

        /// <summary>
        /// The GetExecutionStatusEx method returns information about the execution status of the debugger engine.
        /// </summary>
        /// <param name="status">[out] Receives the extended execution status. This will be set to values described in DEBUG_STATUS_XXX.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// For more information, see Target Information.
        /// </remarks>
        public HRESULT TryGetExecutionStatusEx(out DEBUG_STATUS status)
        {
            /*HRESULT GetExecutionStatusEx(
            [Out] out DEBUG_STATUS Status);*/
            return Raw6.GetExecutionStatusEx(out status);
        }

        #endregion
        #region SynchronizationStatus

        /// <summary>
        /// The GetSynchronizationStatus method returns information about the synchronization status of the debugger engine.
        /// </summary>
        public GetSynchronizationStatusResult SynchronizationStatus
        {
            get
            {
                GetSynchronizationStatusResult result;
                TryGetSynchronizationStatus(out result).ThrowDbgEngNotOK();

                return result;
            }
        }

        /// <summary>
        /// The GetSynchronizationStatus method returns information about the synchronization status of the debugger engine.
        /// </summary>
        /// <param name="result">The values that were emitted from the COM method.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// When the client object connects to a session, the most recent output from the session is sent to the client. If
        /// the session is currently waiting on input, the client object is given the opportunity to provide input. Thus, the
        /// client object synchronizes with the session's input and output.
        /// </remarks>
        public HRESULT TryGetSynchronizationStatus(out GetSynchronizationStatusResult result)
        {
            /*HRESULT GetSynchronizationStatus(
            [Out] out int SendsAttempted,
            [Out] out int SecondsSinceLastResponse);*/
            int sendsAttempted;
            int secondsSinceLastResponse;
            HRESULT hr = Raw6.GetSynchronizationStatus(out sendsAttempted, out secondsSinceLastResponse);

            if (hr == HRESULT.S_OK)
                result = new GetSynchronizationStatusResult(sendsAttempted, secondsSinceLastResponse);
            else
                result = default(GetSynchronizationStatusResult);

            return hr;
        }

        #endregion
        #endregion
        #region IDebugControl7

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public IDebugControl7 Raw7 => (IDebugControl7) Raw;

        #region GetDebuggeeType2

        /// <summary>
        /// The GetDebuggeeType2 method describes the nature of the current target.
        /// </summary>
        /// <param name="flags">[in] Takes a single flag, DEBUG_EXEC_FLAGS_NONBLOCK, that indicates whether the function GetDebuggeeType2 should own the engine critical section object (g_EngineLock) before finding the debuggee type.<para/>
        /// If the Flag is present, then the function will try to own the critical section. If that fails, it will continue without blocking the caller thread.<para/>
        /// If the flag is not passed in, then the function will wait for the engine critical section to become available before continuing.</param>
        /// <returns>The values that were emitted from the COM method.</returns>
        public GetDebuggeeType2Result GetDebuggeeType2(DEBUG_EXEC_FLAGS flags)
        {
            GetDebuggeeType2Result result;
            TryGetDebuggeeType2(flags, out result).ThrowDbgEngNotOK();

            return result;
        }

        /// <summary>
        /// The GetDebuggeeType2 method describes the nature of the current target.
        /// </summary>
        /// <param name="flags">[in] Takes a single flag, DEBUG_EXEC_FLAGS_NONBLOCK, that indicates whether the function GetDebuggeeType2 should own the engine critical section object (g_EngineLock) before finding the debuggee type.<para/>
        /// If the Flag is present, then the function will try to own the critical section. If that fails, it will continue without blocking the caller thread.<para/>
        /// If the flag is not passed in, then the function will wait for the engine critical section to become available before continuing.</param>
        /// <param name="result">The values that were emitted from the COM method.</param>
        /// <returns>This method does not return a value.</returns>
        public HRESULT TryGetDebuggeeType2(DEBUG_EXEC_FLAGS flags, out GetDebuggeeType2Result result)
        {
            /*HRESULT GetDebuggeeType2(
            [In] DEBUG_EXEC_FLAGS Flags,
            [Out] out DEBUG_CLASS Class,
            [Out] out DEBUG_CLASS_QUALIFIER Qualifier);*/
            DEBUG_CLASS @class;
            DEBUG_CLASS_QUALIFIER qualifier;
            HRESULT hr = Raw7.GetDebuggeeType2(flags, out @class, out qualifier);

            if (hr == HRESULT.S_OK)
                result = new GetDebuggeeType2Result(@class, qualifier);
            else
                result = default(GetDebuggeeType2Result);

            return hr;
        }

        #endregion
        #endregion
    }
}
