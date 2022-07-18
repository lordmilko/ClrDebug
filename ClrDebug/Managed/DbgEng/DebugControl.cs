using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Text;
using ClrDebug.DbgEng.Vtbl;

namespace ClrDebug.DbgEng
{
    public unsafe class DebugControl : RuntimeCallableWrapper
    {
        public static readonly Guid IID_IDebugControl = new Guid("5182e668-105e-416e-ad92-24ef800424ba");

        #region Vtbl

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private new IDebugControlVtbl* Vtbl => (IDebugControlVtbl*) base.Vtbl;

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private IDebugControl2Vtbl* Vtbl2 => (IDebugControl2Vtbl*) base.Vtbl;

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private IDebugControl3Vtbl* Vtbl3 => (IDebugControl3Vtbl*) base.Vtbl;

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private IDebugControl4Vtbl* Vtbl4 => (IDebugControl4Vtbl*) base.Vtbl;

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private IDebugControl5Vtbl* Vtbl5 => (IDebugControl5Vtbl*) base.Vtbl;

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private IDebugControl6Vtbl* Vtbl6 => (IDebugControl6Vtbl*) base.Vtbl;

        #endregion
        
        public DebugControl(IntPtr raw) : base(raw, IID_IDebugControl)
        {
        }

        public DebugControl(IDebugControl raw) : base(raw)
        {
        }

        #region IDebugControl
        #region InterruptTimeout

        /// <summary>
        /// The GetInterruptTimeout method returns the number of seconds that the engine will wait when requesting a break into the debugger.
        /// </summary>
        public uint InterruptTimeout
        {
            get
            {
                uint seconds;
                TryGetInterruptTimeout(out seconds).ThrowDbgEngNotOk();

                return seconds;
            }
            set
            {
                TrySetInterruptTimeout(value).ThrowDbgEngNotOk();
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
        public HRESULT TryGetInterruptTimeout(out uint seconds)
        {
            InitDelegate(ref getInterruptTimeout, Vtbl->GetInterruptTimeout);

            /*HRESULT GetInterruptTimeout(
            [Out] out uint Seconds);*/
            return getInterruptTimeout(Raw, out seconds);
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
        public HRESULT TrySetInterruptTimeout(uint seconds)
        {
            InitDelegate(ref setInterruptTimeout, Vtbl->SetInterruptTimeout);

            /*HRESULT SetInterruptTimeout(
            [In] uint Seconds);*/
            return setInterruptTimeout(Raw, seconds);
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
                TryGetLogFile(out result).ThrowDbgEngNotOk();

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
            InitDelegate(ref getLogFile, Vtbl->GetLogFile);
            /*HRESULT GetLogFile(
            [Out, MarshalAs(UnmanagedType.LPStr)] StringBuilder Buffer,
            [In] int BufferSize,
            [Out] out uint FileSize,
            [Out, MarshalAs(UnmanagedType.Bool)] out bool Append);*/
            StringBuilder buffer;
            int bufferSize = 0;
            uint fileSize;
            bool append;
            HRESULT hr = getLogFile(Raw, null, bufferSize, out fileSize, out append);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER && hr != HRESULT.S_OK)
                goto fail;

            bufferSize = (int) fileSize;
            buffer = new StringBuilder(bufferSize);
            hr = getLogFile(Raw, buffer, bufferSize, out fileSize, out append);

            if (hr == HRESULT.S_OK)
            {
                result = new GetLogFileResult(buffer.ToString(), append);

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
                TryGetLogMask(out mask).ThrowDbgEngNotOk();

                return mask;
            }
            set
            {
                TrySetLogMask(value).ThrowDbgEngNotOk();
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
            InitDelegate(ref getLogMask, Vtbl->GetLogMask);

            /*HRESULT GetLogMask(
            [Out] out DEBUG_OUTPUT Mask);*/
            return getLogMask(Raw, out mask);
        }

        /// <summary>
        /// The SetLogMask method sets the output mask for the currently open log file.
        /// </summary>
        /// <param name="mask">[in] Specifies the new output mask for the log file. See DEBUG_OUTPUT_XXX for details about this value.</param>
        /// <returns>This method can also return error values. See Return Values for more details.</returns>
        public HRESULT TrySetLogMask(DEBUG_OUTPUT mask)
        {
            InitDelegate(ref setLogMask, Vtbl->SetLogMask);

            /*HRESULT SetLogMask(
            [In] DEBUG_OUTPUT Mask);*/
            return setLogMask(Raw, mask);
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
                TryGetPromptText(out bufferResult).ThrowDbgEngNotOk();

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
            InitDelegate(ref getPromptText, Vtbl->GetPromptText);
            /*HRESULT GetPromptText(
            [Out, MarshalAs(UnmanagedType.LPStr)] StringBuilder Buffer,
            [In] int BufferSize,
            [Out] out uint TextSize);*/
            StringBuilder buffer;
            int bufferSize = 0;
            uint textSize;
            HRESULT hr = getPromptText(Raw, null, bufferSize, out textSize);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER && hr != HRESULT.S_OK)
                goto fail;

            bufferSize = (int) textSize;
            buffer = new StringBuilder(bufferSize);
            hr = getPromptText(Raw, buffer, bufferSize, out textSize);

            if (hr == HRESULT.S_OK)
            {
                bufferResult = buffer.ToString();

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
        public ulong NotifyEventHandle
        {
            get
            {
                ulong handle;
                TryGetNotifyEventHandle(out handle).ThrowDbgEngNotOk();

                return handle;
            }
            set
            {
                TrySetNotifyEventHandle(value).ThrowDbgEngNotOk();
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
        public HRESULT TryGetNotifyEventHandle(out ulong handle)
        {
            InitDelegate(ref getNotifyEventHandle, Vtbl->GetNotifyEventHandle);

            /*HRESULT GetNotifyEventHandle(
            [Out] out ulong Handle);*/
            return getNotifyEventHandle(Raw, out handle);
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
        public HRESULT TrySetNotifyEventHandle(ulong handle)
        {
            InitDelegate(ref setNotifyEventHandle, Vtbl->SetNotifyEventHandle);

            /*HRESULT SetNotifyEventHandle(
            [In] ulong Handle);*/
            return setNotifyEventHandle(Raw, handle);
        }

        #endregion
        #region DisassembleEffectiveOffset

        /// <summary>
        /// The GetDisassembleEffectiveOffset method returns the address of the last instruction disassembled using <see cref="Disassemble"/>.
        /// </summary>
        public ulong DisassembleEffectiveOffset
        {
            get
            {
                ulong offset;
                TryGetDisassembleEffectiveOffset(out offset).ThrowDbgEngNotOk();

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
        public HRESULT TryGetDisassembleEffectiveOffset(out ulong offset)
        {
            InitDelegate(ref getDisassembleEffectiveOffset, Vtbl->GetDisassembleEffectiveOffset);

            /*HRESULT GetDisassembleEffectiveOffset(
            [Out] out ulong Offset);*/
            return getDisassembleEffectiveOffset(Raw, out offset);
        }

        #endregion
        #region ReturnOffset

        /// <summary>
        /// The GetReturnOffset method returns the return address for the current function.
        /// </summary>
        public ulong ReturnOffset
        {
            get
            {
                ulong offset;
                TryGetReturnOffset(out offset).ThrowDbgEngNotOk();

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
        public HRESULT TryGetReturnOffset(out ulong offset)
        {
            InitDelegate(ref getReturnOffset, Vtbl->GetReturnOffset);

            /*HRESULT GetReturnOffset(
            [Out] out ulong Offset);*/
            return getReturnOffset(Raw, out offset);
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
                TryGetDebuggeeType(out result).ThrowDbgEngNotOk();

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
            InitDelegate(ref getDebuggeeType, Vtbl->GetDebuggeeType);
            /*HRESULT GetDebuggeeType(
            [Out] out DEBUG_CLASS Class,
            [Out] out DEBUG_CLASS_QUALIFIER Qualifier);*/
            DEBUG_CLASS @class;
            DEBUG_CLASS_QUALIFIER qualifier;
            HRESULT hr = getDebuggeeType(Raw, out @class, out qualifier);

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
                TryGetActualProcessorType(out type).ThrowDbgEngNotOk();

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
            InitDelegate(ref getActualProcessorType, Vtbl->GetActualProcessorType);

            /*HRESULT GetActualProcessorType(
            [Out] out IMAGE_FILE_MACHINE Type);*/
            return getActualProcessorType(Raw, out type);
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
                TryGetExecutingProcessorType(out type).ThrowDbgEngNotOk();

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
            InitDelegate(ref getExecutingProcessorType, Vtbl->GetExecutingProcessorType);

            /*HRESULT GetExecutingProcessorType(
            [Out] out IMAGE_FILE_MACHINE Type);*/
            return getExecutingProcessorType(Raw, out type);
        }

        #endregion
        #region NumberPossibleExecutingProcessorTypes

        /// <summary>
        /// The GetNumberPossibleExecutingProcessorTypes method returns the number of processor types that are supported by the computer running the current target.
        /// </summary>
        public uint NumberPossibleExecutingProcessorTypes
        {
            get
            {
                uint number;
                TryGetNumberPossibleExecutingProcessorTypes(out number).ThrowDbgEngNotOk();

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
        public HRESULT TryGetNumberPossibleExecutingProcessorTypes(out uint number)
        {
            InitDelegate(ref getNumberPossibleExecutingProcessorTypes, Vtbl->GetNumberPossibleExecutingProcessorTypes);

            /*HRESULT GetNumberPossibleExecutingProcessorTypes(
            [Out] out uint Number);*/
            return getNumberPossibleExecutingProcessorTypes(Raw, out number);
        }

        #endregion
        #region NumberProcessors

        /// <summary>
        /// The GetNumberProcessors method returns the number of processors on the computer running the current target.
        /// </summary>
        public uint NumberProcessors
        {
            get
            {
                uint number;
                TryGetNumberProcessors(out number).ThrowDbgEngNotOk();

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
        public HRESULT TryGetNumberProcessors(out uint number)
        {
            InitDelegate(ref getNumberProcessors, Vtbl->GetNumberProcessors);

            /*HRESULT GetNumberProcessors(
            [Out] out uint Number);*/
            return getNumberProcessors(Raw, out number);
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
                TryGetSystemVersion(out result).ThrowDbgEngNotOk();

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
            InitDelegate(ref getSystemVersion, Vtbl->GetSystemVersion);
            /*HRESULT GetSystemVersion(
            [Out] out uint PlatformId,
            [Out] out uint Major,
            [Out] out uint Minor,
            [Out, MarshalAs(UnmanagedType.LPStr)] StringBuilder ServicePackString,
            [In] int ServicePackStringSize,
            [Out] out uint ServicePackStringUsed,
            [Out] out uint ServicePackNumber,
            [Out, MarshalAs(UnmanagedType.LPStr)] StringBuilder BuildString,
            [In] int BuildStringSize,
            [Out] out uint BuildStringUsed);*/
            uint platformId;
            uint major;
            uint minor;
            StringBuilder servicePackString;
            int servicePackStringSize = 0;
            uint servicePackStringUsed;
            uint servicePackNumber;
            StringBuilder buildString;
            int buildStringSize = 0;
            uint buildStringUsed;
            HRESULT hr = getSystemVersion(Raw, out platformId, out major, out minor, null, servicePackStringSize, out servicePackStringUsed, out servicePackNumber, null, buildStringSize, out buildStringUsed);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER && hr != HRESULT.S_OK)
                goto fail;

            servicePackStringSize = (int) servicePackStringUsed;
            servicePackString = new StringBuilder(servicePackStringSize);
            buildStringSize = (int) buildStringUsed;
            buildString = new StringBuilder(buildStringSize);
            hr = getSystemVersion(Raw, out platformId, out major, out minor, servicePackString, servicePackStringSize, out servicePackStringUsed, out servicePackNumber, buildString, buildStringSize, out buildStringUsed);

            if (hr == HRESULT.S_OK)
            {
                result = new GetSystemVersionResult(platformId, major, minor, servicePackString.ToString(), servicePackNumber, buildString.ToString());

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
        public uint PageSize
        {
            get
            {
                uint size;
                TryGetPageSize(out size).ThrowDbgEngNotOk();

                return size;
            }
        }

        /// <summary>
        /// The GetPageSize method returns the page size for the effective processor mode.
        /// </summary>
        /// <param name="size">[out] Receives the page size.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        public HRESULT TryGetPageSize(out uint size)
        {
            InitDelegate(ref getPageSize, Vtbl->GetPageSize);

            /*HRESULT GetPageSize(
            [Out] out uint Size);*/
            return getPageSize(Raw, out size);
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
                hr.ThrowDbgEngNotOk();

                return hr == HRESULT.S_OK;
            }
        }

        /// <summary>
        /// The IsPointer64Bit method determines if the effective processor uses 64-bit pointers.
        /// </summary>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        public HRESULT TryIsPointer64Bit()
        {
            InitDelegate(ref isPointer64Bit, Vtbl->IsPointer64Bit);

            /*HRESULT IsPointer64Bit();*/
            return isPointer64Bit(Raw);
        }

        #endregion
        #region NumberSupportedProcessorTypes

        /// <summary>
        /// The GetNumberSupportedProcessorTypes method returns the number of processor types supported by the engine.
        /// </summary>
        public uint NumberSupportedProcessorTypes
        {
            get
            {
                uint number;
                TryGetNumberSupportedProcessorTypes(out number).ThrowDbgEngNotOk();

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
        public HRESULT TryGetNumberSupportedProcessorTypes(out uint number)
        {
            InitDelegate(ref getNumberSupportedProcessorTypes, Vtbl->GetNumberSupportedProcessorTypes);

            /*HRESULT GetNumberSupportedProcessorTypes(
            [Out] out uint Number);*/
            return getNumberSupportedProcessorTypes(Raw, out number);
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
                TryGetEffectiveProcessorType(out type).ThrowDbgEngNotOk();

                return type;
            }
            set
            {
                TrySetEffectiveProcessorType(value).ThrowDbgEngNotOk();
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
            InitDelegate(ref getEffectiveProcessorType, Vtbl->GetEffectiveProcessorType);

            /*HRESULT GetEffectiveProcessorType(
            [Out] out IMAGE_FILE_MACHINE Type);*/
            return getEffectiveProcessorType(Raw, out type);
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
            InitDelegate(ref setEffectiveProcessorType, Vtbl->SetEffectiveProcessorType);

            /*HRESULT SetEffectiveProcessorType(
            [In] IMAGE_FILE_MACHINE Type);*/
            return setEffectiveProcessorType(Raw, type);
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
                TryGetExecutionStatus(out status).ThrowDbgEngNotOk();

                return status;
            }
            set
            {
                TrySetExecutionStatus(value).ThrowDbgEngNotOk();
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
            InitDelegate(ref getExecutionStatus, Vtbl->GetExecutionStatus);

            /*HRESULT GetExecutionStatus(
            [Out] out DEBUG_STATUS Status);*/
            return getExecutionStatus(Raw, out status);
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
            InitDelegate(ref setExecutionStatus, Vtbl->SetExecutionStatus);

            /*HRESULT SetExecutionStatus(
            [In] DEBUG_STATUS Status);*/
            return setExecutionStatus(Raw, status);
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
                TryGetCodeLevel(out level).ThrowDbgEngNotOk();

                return level;
            }
            set
            {
                TrySetCodeLevel(value).ThrowDbgEngNotOk();
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
            InitDelegate(ref getCodeLevel, Vtbl->GetCodeLevel);

            /*HRESULT GetCodeLevel(
            [Out] out DEBUG_LEVEL Level);*/
            return getCodeLevel(Raw, out level);
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
            InitDelegate(ref setCodeLevel, Vtbl->SetCodeLevel);

            /*HRESULT SetCodeLevel(
            [In] DEBUG_LEVEL Level);*/
            return setCodeLevel(Raw, level);
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
                TryGetEngineOptions(out options).ThrowDbgEngNotOk();

                return options;
            }
            set
            {
                TrySetEngineOptions(value).ThrowDbgEngNotOk();
            }
        }

        /// <summary>
        /// The GetEngineOptions method returns the engine's options.
        /// </summary>
        /// <param name="options">[out] Receives a bit-set that contains the engine's options. For a description of the engine options, see DEBUG_ENGOPT_XXX.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        public HRESULT TryGetEngineOptions(out DEBUG_ENGOPT options)
        {
            InitDelegate(ref getEngineOptions, Vtbl->GetEngineOptions);

            /*HRESULT GetEngineOptions(
            [Out] out DEBUG_ENGOPT Options);*/
            return getEngineOptions(Raw, out options);
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
            InitDelegate(ref setEngineOptions, Vtbl->SetEngineOptions);

            /*HRESULT SetEngineOptions(
            [In] DEBUG_ENGOPT Options);*/
            return setEngineOptions(Raw, options);
        }

        #endregion
        #region Radix

        /// <summary>
        /// The GetRadix method returns the default radix (number base) used by the debugger engine when it evaluates and displays MASM expressions, and when it displays symbol information.
        /// </summary>
        public uint Radix
        {
            get
            {
                uint radix;
                TryGetRadix(out radix).ThrowDbgEngNotOk();

                return radix;
            }
            set
            {
                TrySetRadix(value).ThrowDbgEngNotOk();
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
        public HRESULT TryGetRadix(out uint radix)
        {
            InitDelegate(ref getRadix, Vtbl->GetRadix);

            /*HRESULT GetRadix(
            [Out] out uint Radix);*/
            return getRadix(Raw, out radix);
        }

        /// <summary>
        /// The SetRadix method sets the default radix (number base) used by the debugger engine when it evaluates and displays MASM expressions, and when it displays symbol information.
        /// </summary>
        /// <param name="radix">[in] Specifies the new default radix. The following table contains the possible values for the radix.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// When the radix is changed, the engine notifies the event callbacks by passing the DEBUG_CES_RADIX flag to the <see 
        ///cref="IDebugEventCallbacks.ChangeEngineState"/> callback method. For more information about the default radix,
        /// see Using Input and Output.
        /// </remarks>
        public HRESULT TrySetRadix(uint radix)
        {
            InitDelegate(ref setRadix, Vtbl->SetRadix);

            /*HRESULT SetRadix(
            [In] uint Radix);*/
            return setRadix(Raw, radix);
        }

        #endregion
        #region NumberBreakpoints

        /// <summary>
        /// The GetNumberBreakpoints method returns the number of breakpoints for the current process.
        /// </summary>
        public uint NumberBreakpoints
        {
            get
            {
                uint number;
                TryGetNumberBreakpoints(out number).ThrowDbgEngNotOk();

                return number;
            }
        }

        /// <summary>
        /// The GetNumberBreakpoints method returns the number of breakpoints for the current process.
        /// </summary>
        /// <param name="number">[out] Receives the number of breakpoints.</param>
        /// <returns>This method can also return error values. See Return Values for more details.</returns>
        public HRESULT TryGetNumberBreakpoints(out uint number)
        {
            InitDelegate(ref getNumberBreakpoints, Vtbl->GetNumberBreakpoints);

            /*HRESULT GetNumberBreakpoints(
            [Out] out uint Number);*/
            return getNumberBreakpoints(Raw, out number);
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
                TryGetNumberEventFilters(out result).ThrowDbgEngNotOk();

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
            InitDelegate(ref getNumberEventFilters, Vtbl->GetNumberEventFilters);
            /*HRESULT GetNumberEventFilters(
            [Out] out uint SpecificEvents,
            [Out] out uint SpecificExceptions,
            [Out] out uint ArbitraryExceptions);*/
            uint specificEvents;
            uint specificExceptions;
            uint arbitraryExceptions;
            HRESULT hr = getNumberEventFilters(Raw, out specificEvents, out specificExceptions, out arbitraryExceptions);

            if (hr == HRESULT.S_OK)
                result = new GetNumberEventFiltersResult(specificEvents, specificExceptions, arbitraryExceptions);
            else
                result = default(GetNumberEventFiltersResult);

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
            TryGetInterrupt().ThrowDbgEngNotOk();
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
            InitDelegate(ref getInterrupt, Vtbl->GetInterrupt);

            /*HRESULT GetInterrupt();*/
            return getInterrupt(Raw);
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
            TrySetInterrupt(flags).ThrowDbgEngNotOk();
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
            InitDelegate(ref setInterrupt, Vtbl->SetInterrupt);

            /*HRESULT SetInterrupt(
            [In] DEBUG_INTERRUPT Flags);*/
            return setInterrupt(Raw, flags);
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
            TryOpenLogFile(file, append).ThrowDbgEngNotOk();
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
            InitDelegate(ref openLogFile, Vtbl->OpenLogFile);

            /*HRESULT OpenLogFile(
            [In, MarshalAs(UnmanagedType.LPStr)] string File,
            [In, MarshalAs(UnmanagedType.Bool)] bool Append);*/
            return openLogFile(Raw, file, append);
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
            TryCloseLogFile().ThrowDbgEngNotOk();
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
            InitDelegate(ref closeLogFile, Vtbl->CloseLogFile);

            /*HRESULT CloseLogFile();*/
            return closeLogFile(Raw);
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
            TryInput(out bufferResult).ThrowDbgEngNotOk();

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
            InitDelegate(ref input, Vtbl->Input);
            /*HRESULT Input(
            [Out, MarshalAs(UnmanagedType.LPStr)] StringBuilder Buffer,
            [In] int BufferSize,
            [Out] out uint InputSize);*/
            StringBuilder buffer;
            int bufferSize = 0;
            uint inputSize;
            HRESULT hr = input(Raw, null, bufferSize, out inputSize);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER && hr != HRESULT.S_OK)
                goto fail;

            bufferSize = (int) inputSize;
            buffer = new StringBuilder(bufferSize);
            hr = input(Raw, buffer, bufferSize, out inputSize);

            if (hr == HRESULT.S_OK)
            {
                bufferResult = buffer.ToString();

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
            TryReturnInput(buffer).ThrowDbgEngNotOk();
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
            InitDelegate(ref returnInput, Vtbl->ReturnInput);

            /*HRESULT ReturnInput(
            [In, MarshalAs(UnmanagedType.LPStr)] string Buffer);*/
            return returnInput(Raw, buffer);
        }

        #endregion
        #region Output

        /// <summary>
        /// The Output method formats a string and send the result to output callbacks that have been registered with the engine's clients.
        /// </summary>
        /// <remarks>
        /// When generating very large output strings, it is possible to reach the limits of the debugger engine or of the
        /// operating system. For example, some versions of the debugger engine have a 16K character limit for a single output.
        /// If you find that very large output is getting truncated, you might need to split your output into multiple requests.
        /// </remarks>
        public void Output(DEBUG_OUTPUT mask, string format)
        {
            TryOutput(mask, format).ThrowDbgEngNotOk();
        }

        /// <summary>
        /// The Output method formats a string and send the result to output callbacks that have been registered with the engine's clients.
        /// </summary>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// When generating very large output strings, it is possible to reach the limits of the debugger engine or of the
        /// operating system. For example, some versions of the debugger engine have a 16K character limit for a single output.
        /// If you find that very large output is getting truncated, you might need to split your output into multiple requests.
        /// </remarks>
        public HRESULT TryOutput(DEBUG_OUTPUT mask, string format)
        {
            InitDelegate(ref output, Vtbl->Output);

            /*HRESULT Output(
            [In] DEBUG_OUTPUT Mask,
            [In, MarshalAs(UnmanagedType.LPStr)] string Format);*/
            return output(Raw, mask, format);
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
            TryOutputVaList(mask, format, va_list_Args).ThrowDbgEngNotOk();
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
            InitDelegate(ref outputVaList, Vtbl->OutputVaList);

            /*HRESULT OutputVaList(
            [In] DEBUG_OUTPUT Mask,
            [In, MarshalAs(UnmanagedType.LPStr)] string Format,
            [In] IntPtr va_list_Args);*/
            return outputVaList(Raw, mask, format, va_list_Args);
        }

        #endregion
        #region ControlledOutput

        /// <summary>
        /// The ControlledOutput method formats a string and sends the result to output callbacks that were registered with some of the engine's clients.
        /// </summary>
        /// <remarks>
        /// When generating very large output strings, it is possible to reach the limits of the debugger engine or of the
        /// operating system. For example, some versions of the debugger engine have a 16K character limit for a single output.
        /// If you find that very large output is getting truncated, you might need to split your output into multiple requests.
        /// </remarks>
        public void ControlledOutput(DEBUG_OUTCTL outputControl, DEBUG_OUTPUT mask, string format)
        {
            TryControlledOutput(outputControl, mask, format).ThrowDbgEngNotOk();
        }

        /// <summary>
        /// The ControlledOutput method formats a string and sends the result to output callbacks that were registered with some of the engine's clients.
        /// </summary>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// When generating very large output strings, it is possible to reach the limits of the debugger engine or of the
        /// operating system. For example, some versions of the debugger engine have a 16K character limit for a single output.
        /// If you find that very large output is getting truncated, you might need to split your output into multiple requests.
        /// </remarks>
        public HRESULT TryControlledOutput(DEBUG_OUTCTL outputControl, DEBUG_OUTPUT mask, string format)
        {
            InitDelegate(ref controlledOutput, Vtbl->ControlledOutput);

            /*HRESULT ControlledOutput(
            [In] DEBUG_OUTCTL OutputControl,
            [In] DEBUG_OUTPUT Mask,
            [In, MarshalAs(UnmanagedType.LPStr)] string Format);*/
            return controlledOutput(Raw, outputControl, mask, format);
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
            TryControlledOutputVaList(outputControl, mask, format, va_list_Args).ThrowDbgEngNotOk();
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
            InitDelegate(ref controlledOutputVaList, Vtbl->ControlledOutputVaList);

            /*HRESULT ControlledOutputVaList(
            [In] DEBUG_OUTCTL OutputControl,
            [In] DEBUG_OUTPUT Mask,
            [In, MarshalAs(UnmanagedType.LPStr)] string Format,
            [In] IntPtr va_list_Args);*/
            return controlledOutputVaList(Raw, outputControl, mask, format, va_list_Args);
        }

        #endregion
        #region OutputPrompt

        /// <summary>
        /// The OutputPrompt method formats and sends a user prompt to the output callback objects.
        /// </summary>
        /// <remarks>
        /// OutputPrompt and OutputPromptWide can be used to prompt the user for input. The standard prompt will be sent to
        /// the output callbacks before the formatted text described by Format. The contents of the standard prompt is returned
        /// by the method <see cref="PromptText"/>. The prompt text is sent to the output callbacks with the DEBUG_OUTPUT_PROMPT
        /// output mask set. For more information about prompting the user, see Using Input and Output.
        /// </remarks>
        public void OutputPrompt(DEBUG_OUTCTL outputControl, string format)
        {
            TryOutputPrompt(outputControl, format).ThrowDbgEngNotOk();
        }

        /// <summary>
        /// The OutputPrompt method formats and sends a user prompt to the output callback objects.
        /// </summary>
        /// <returns>This method can also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// OutputPrompt and OutputPromptWide can be used to prompt the user for input. The standard prompt will be sent to
        /// the output callbacks before the formatted text described by Format. The contents of the standard prompt is returned
        /// by the method <see cref="PromptText"/>. The prompt text is sent to the output callbacks with the DEBUG_OUTPUT_PROMPT
        /// output mask set. For more information about prompting the user, see Using Input and Output.
        /// </remarks>
        public HRESULT TryOutputPrompt(DEBUG_OUTCTL outputControl, string format)
        {
            InitDelegate(ref outputPrompt, Vtbl->OutputPrompt);

            /*HRESULT OutputPrompt(
            [In] DEBUG_OUTCTL OutputControl,
            [In, MarshalAs(UnmanagedType.LPStr)] string Format);*/
            return outputPrompt(Raw, outputControl, format);
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
            TryOutputPromptVaList(outputControl, format, va_list_Args).ThrowDbgEngNotOk();
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
            InitDelegate(ref outputPromptVaList, Vtbl->OutputPromptVaList);

            /*HRESULT OutputPromptVaList(
            [In] DEBUG_OUTCTL OutputControl,
            [In, MarshalAs(UnmanagedType.LPStr)] string Format,
            [In] IntPtr va_list_Args);*/
            return outputPromptVaList(Raw, outputControl, format, va_list_Args);
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
            TryOutputCurrentState(outputControl, flags).ThrowDbgEngNotOk();
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
            InitDelegate(ref outputCurrentState, Vtbl->OutputCurrentState);

            /*HRESULT OutputCurrentState(
            [In] DEBUG_OUTCTL OutputControl,
            [In] DEBUG_CURRENT Flags);*/
            return outputCurrentState(Raw, outputControl, flags);
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
            TryOutputVersionInformation(outputControl).ThrowDbgEngNotOk();
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
            InitDelegate(ref outputVersionInformation, Vtbl->OutputVersionInformation);

            /*HRESULT OutputVersionInformation(
            [In] DEBUG_OUTCTL OutputControl);*/
            return outputVersionInformation(Raw, outputControl);
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
        public ulong Assemble(ulong offset, string instr)
        {
            ulong endOffset;
            TryAssemble(offset, instr, out endOffset).ThrowDbgEngNotOk();

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
        public HRESULT TryAssemble(ulong offset, string instr, out ulong endOffset)
        {
            InitDelegate(ref assemble, Vtbl->Assemble);

            /*HRESULT Assemble(
            [In] ulong Offset,
            [In, MarshalAs(UnmanagedType.LPStr)] string Instr,
            [Out] out ulong EndOffset);*/
            return assemble(Raw, offset, instr, out endOffset);
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
        public DisassembleResult Disassemble(ulong offset, DEBUG_DISASM flags)
        {
            DisassembleResult result;
            TryDisassemble(offset, flags, out result).ThrowDbgEngNotOk();

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
        public HRESULT TryDisassemble(ulong offset, DEBUG_DISASM flags, out DisassembleResult result)
        {
            InitDelegate(ref disassemble, Vtbl->Disassemble);
            /*HRESULT Disassemble(
            [In] ulong Offset,
            [In] DEBUG_DISASM Flags,
            [Out, MarshalAs(UnmanagedType.LPStr)] StringBuilder Buffer,
            [In] int BufferSize,
            [Out] out uint DisassemblySize,
            [Out] out ulong EndOffset);*/
            StringBuilder buffer;
            int bufferSize = 0;
            uint disassemblySize;
            ulong endOffset;
            HRESULT hr = disassemble(Raw, offset, flags, null, bufferSize, out disassemblySize, out endOffset);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER && hr != HRESULT.S_OK)
                goto fail;

            bufferSize = (int) disassemblySize;
            buffer = new StringBuilder(bufferSize);
            hr = disassemble(Raw, offset, flags, buffer, bufferSize, out disassemblySize, out endOffset);

            if (hr == HRESULT.S_OK)
            {
                result = new DisassembleResult(buffer.ToString(), endOffset);

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
        public ulong OutputDisassembly(DEBUG_OUTCTL outputControl, ulong offset, DEBUG_DISASM flags)
        {
            ulong endOffset;
            TryOutputDisassembly(outputControl, offset, flags, out endOffset).ThrowDbgEngNotOk();

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
        public HRESULT TryOutputDisassembly(DEBUG_OUTCTL outputControl, ulong offset, DEBUG_DISASM flags, out ulong endOffset)
        {
            InitDelegate(ref outputDisassembly, Vtbl->OutputDisassembly);

            /*HRESULT OutputDisassembly(
            [In] DEBUG_OUTCTL OutputControl,
            [In] ulong Offset,
            [In] DEBUG_DISASM Flags,
            [Out] out ulong EndOffset);*/
            return outputDisassembly(Raw, outputControl, offset, flags, out endOffset);
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
        public OutputDisassemblyLinesResult OutputDisassemblyLines(DEBUG_OUTCTL outputControl, uint previousLines, uint totalLines, ulong offset, DEBUG_DISASM flags)
        {
            OutputDisassemblyLinesResult result;
            TryOutputDisassemblyLines(outputControl, previousLines, totalLines, offset, flags, out result).ThrowDbgEngNotOk();

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
        public HRESULT TryOutputDisassemblyLines(DEBUG_OUTCTL outputControl, uint previousLines, uint totalLines, ulong offset, DEBUG_DISASM flags, out OutputDisassemblyLinesResult result)
        {
            InitDelegate(ref outputDisassemblyLines, Vtbl->OutputDisassemblyLines);
            /*HRESULT OutputDisassemblyLines(
            [In] DEBUG_OUTCTL OutputControl,
            [In] uint PreviousLines,
            [In] uint TotalLines,
            [In] ulong Offset,
            [In] DEBUG_DISASM Flags,
            [Out] out uint OffsetLine,
            [Out] out ulong StartOffset,
            [Out] out ulong EndOffset,
            [Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] ulong[] LineOffsets);*/
            uint offsetLine;
            ulong startOffset;
            ulong endOffset;
            ulong[] lineOffsets = new ulong[(int) totalLines];
            HRESULT hr = outputDisassemblyLines(Raw, outputControl, previousLines, totalLines, offset, flags, out offsetLine, out startOffset, out endOffset, lineOffsets);

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
        public ulong GetNearInstruction(ulong offset, int delta)
        {
            ulong nearOffset;
            TryGetNearInstruction(offset, delta, out nearOffset).ThrowDbgEngNotOk();

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
        public HRESULT TryGetNearInstruction(ulong offset, int delta, out ulong nearOffset)
        {
            InitDelegate(ref getNearInstruction, Vtbl->GetNearInstruction);

            /*HRESULT GetNearInstruction(
            [In] ulong Offset,
            [In] int Delta,
            [Out] out ulong NearOffset);*/
            return getNearInstruction(Raw, offset, delta, out nearOffset);
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
        /// <returns>[out] Receives the stack frames. The number of elements this array holds is FrameSize.</returns>
        /// <remarks>
        /// The stack trace returned to Frames can be printed using <see cref="OutputStackTrace"/>.
        /// </remarks>
        public DEBUG_STACK_FRAME[] GetStackTrace(ulong frameOffset, ulong stackOffset, ulong instructionOffset)
        {
            DEBUG_STACK_FRAME[] frames;
            TryGetStackTrace(frameOffset, stackOffset, instructionOffset, out frames).ThrowDbgEngNotOk();

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
        /// <returns>This method may also return other error values. See Return Values for more details.</returns>
        /// <remarks>
        /// The stack trace returned to Frames can be printed using <see cref="OutputStackTrace"/>.
        /// </remarks>
        public HRESULT TryGetStackTrace(ulong frameOffset, ulong stackOffset, ulong instructionOffset, out DEBUG_STACK_FRAME[] frames)
        {
            InitDelegate(ref getStackTrace, Vtbl->GetStackTrace);
            /*HRESULT GetStackTrace(
            [In] ulong FrameOffset,
            [In] ulong StackOffset,
            [In] ulong InstructionOffset,
            [Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 4)] DEBUG_STACK_FRAME[] Frames,
            [In] int FrameSize,
            [Out] out uint FramesFilled);*/
            frames = null;
            int frameSize = 0;
            uint framesFilled;
            HRESULT hr = getStackTrace(Raw, frameOffset, stackOffset, instructionOffset, null, frameSize, out framesFilled);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER && hr != HRESULT.S_OK)
                goto fail;

            frameSize = (int) framesFilled;
            frames = new DEBUG_STACK_FRAME[frameSize];
            hr = getStackTrace(Raw, frameOffset, stackOffset, instructionOffset, frames, frameSize, out framesFilled);
            fail:
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
            TryOutputStackTrace(outputControl, frames, framesSize, flags).ThrowDbgEngNotOk();
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
            InitDelegate(ref outputStackTrace, Vtbl->OutputStackTrace);

            /*HRESULT OutputStackTrace(
            [In] DEBUG_OUTCTL OutputControl,
            [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] DEBUG_STACK_FRAME[] Frames,
            [In] int FramesSize,
            [In] DEBUG_STACK Flags);*/
            return outputStackTrace(Raw, outputControl, frames, framesSize, flags);
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
        public IMAGE_FILE_MACHINE[] GetPossibleExecutingProcessorTypes(uint start, uint count)
        {
            IMAGE_FILE_MACHINE[] types;
            TryGetPossibleExecutingProcessorTypes(start, count, out types).ThrowDbgEngNotOk();

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
        public HRESULT TryGetPossibleExecutingProcessorTypes(uint start, uint count, out IMAGE_FILE_MACHINE[] types)
        {
            InitDelegate(ref getPossibleExecutingProcessorTypes, Vtbl->GetPossibleExecutingProcessorTypes);
            /*HRESULT GetPossibleExecutingProcessorTypes(
            [In] uint Start,
            [In] uint Count,
            [Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)]
            IMAGE_FILE_MACHINE[] Types);*/
            types = new IMAGE_FILE_MACHINE[(int) count];
            HRESULT hr = getPossibleExecutingProcessorTypes(Raw, start, count, types);

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
            TryReadBugCheckData(out result).ThrowDbgEngNotOk();

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
            InitDelegate(ref readBugCheckData, Vtbl->ReadBugCheckData);
            /*HRESULT ReadBugCheckData(
            [Out] out uint Code,
            [Out] out ulong Arg1,
            [Out] out ulong Arg2,
            [Out] out ulong Arg3,
            [Out] out ulong Arg4);*/
            uint code;
            ulong arg1;
            ulong arg2;
            ulong arg3;
            ulong arg4;
            HRESULT hr = readBugCheckData(Raw, out code, out arg1, out arg2, out arg3, out arg4);

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
        public IMAGE_FILE_MACHINE[] GetSupportedProcessorTypes(uint start, uint count)
        {
            IMAGE_FILE_MACHINE[] types;
            TryGetSupportedProcessorTypes(start, count, out types).ThrowDbgEngNotOk();

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
        public HRESULT TryGetSupportedProcessorTypes(uint start, uint count, out IMAGE_FILE_MACHINE[] types)
        {
            InitDelegate(ref getSupportedProcessorTypes, Vtbl->GetSupportedProcessorTypes);
            /*HRESULT GetSupportedProcessorTypes(
            [In] uint Start,
            [In] uint Count,
            [Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)]
            IMAGE_FILE_MACHINE[] Types);*/
            types = new IMAGE_FILE_MACHINE[(int) count];
            HRESULT hr = getSupportedProcessorTypes(Raw, start, count, types);

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
            TryGetProcessorTypeNames(type, out result).ThrowDbgEngNotOk();

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
            InitDelegate(ref getProcessorTypeNames, Vtbl->GetProcessorTypeNames);
            /*HRESULT GetProcessorTypeNames(
            [In] IMAGE_FILE_MACHINE Type,
            [Out, MarshalAs(UnmanagedType.LPStr)] StringBuilder FullNameBuffer,
            [In] int FullNameBufferSize,
            [Out] out uint FullNameSize,
            [Out, MarshalAs(UnmanagedType.LPStr)] StringBuilder AbbrevNameBuffer,
            [In] int AbbrevNameBufferSize,
            [Out] out uint AbbrevNameSize);*/
            StringBuilder fullNameBuffer;
            int fullNameBufferSize = 0;
            uint fullNameSize;
            StringBuilder abbrevNameBuffer;
            int abbrevNameBufferSize = 0;
            uint abbrevNameSize;
            HRESULT hr = getProcessorTypeNames(Raw, type, null, fullNameBufferSize, out fullNameSize, null, abbrevNameBufferSize, out abbrevNameSize);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER && hr != HRESULT.S_OK)
                goto fail;

            fullNameBufferSize = (int) fullNameSize;
            fullNameBuffer = new StringBuilder(fullNameBufferSize);
            abbrevNameBufferSize = (int) abbrevNameSize;
            abbrevNameBuffer = new StringBuilder(abbrevNameBufferSize);
            hr = getProcessorTypeNames(Raw, type, fullNameBuffer, fullNameBufferSize, out fullNameSize, abbrevNameBuffer, abbrevNameBufferSize, out abbrevNameSize);

            if (hr == HRESULT.S_OK)
            {
                result = new GetProcessorTypeNamesResult(fullNameBuffer.ToString(), abbrevNameBuffer.ToString());

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
            TryAddEngineOptions(options).ThrowDbgEngNotOk();
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
            InitDelegate(ref addEngineOptions, Vtbl->AddEngineOptions);

            /*HRESULT AddEngineOptions(
            [In] DEBUG_ENGOPT Options);*/
            return addEngineOptions(Raw, options);
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
            TryRemoveEngineOptions(options).ThrowDbgEngNotOk();
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
            InitDelegate(ref removeEngineOptions, Vtbl->RemoveEngineOptions);

            /*HRESULT RemoveEngineOptions(
            [In] DEBUG_ENGOPT Options);*/
            return removeEngineOptions(Raw, options);
        }

        #endregion
        #region GetSystemErrorControl

        /// <summary>
        /// The GetSystemErrorControl method returns the control values for handling system errors.
        /// </summary>
        /// <returns>The values that were emitted from the COM method.</returns>
        /// <remarks>
        /// The level of a system error can take one of the following three values, listed from lowest to highest: SLE_ERROR,
        /// SLE_MINORERROR, and SLE_WARNING. These values are defined in Winuser.h. When a system error occurs, the engine
        /// calls the <see cref="IDebugEventCallbacks.SystemError"/> method of the event callbacks. If the level is less than
        /// or equal to BreakLevel, the error will break into the debugger. If the level is greater than BreakLevel, the engine
        /// will proceed with execution in the target as indicated by the IDebugEventCallbacks::SystemError method calls. For
        /// more information about how the engine proceeds after an event, see Monitoring Events.
        /// </remarks>
        public GetSystemErrorControlResult GetSystemErrorControl()
        {
            GetSystemErrorControlResult result;
            TryGetSystemErrorControl(out result).ThrowDbgEngNotOk();

            return result;
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
            InitDelegate(ref getSystemErrorControl, Vtbl->GetSystemErrorControl);
            /*HRESULT GetSystemErrorControl(
            [Out] out ERROR_LEVEL OutputLevel,
            [Out] out ERROR_LEVEL BreakLevel);*/
            ERROR_LEVEL outputLevel;
            ERROR_LEVEL breakLevel;
            HRESULT hr = getSystemErrorControl(Raw, out outputLevel, out breakLevel);

            if (hr == HRESULT.S_OK)
                result = new GetSystemErrorControlResult(outputLevel, breakLevel);
            else
                result = default(GetSystemErrorControlResult);

            return hr;
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
            TrySetSystemErrorControl(outputLevel, breakLevel).ThrowDbgEngNotOk();
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
            InitDelegate(ref setSystemErrorControl, Vtbl->SetSystemErrorControl);

            /*HRESULT SetSystemErrorControl(
            [In] ERROR_LEVEL OutputLevel,
            [In] ERROR_LEVEL BreakLevel);*/
            return setSystemErrorControl(Raw, outputLevel, breakLevel);
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
        public string GetTextMacro(uint slot)
        {
            string bufferResult;
            TryGetTextMacro(slot, out bufferResult).ThrowDbgEngNotOk();

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
        public HRESULT TryGetTextMacro(uint slot, out string bufferResult)
        {
            InitDelegate(ref getTextMacro, Vtbl->GetTextMacro);
            /*HRESULT GetTextMacro(
            [In] uint Slot,
            [Out, MarshalAs(UnmanagedType.LPStr)] StringBuilder Buffer,
            [In] int BufferSize,
            [Out] out uint MacroSize);*/
            StringBuilder buffer;
            int bufferSize = 0;
            uint macroSize;
            HRESULT hr = getTextMacro(Raw, slot, null, bufferSize, out macroSize);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER && hr != HRESULT.S_OK)
                goto fail;

            bufferSize = (int) macroSize;
            buffer = new StringBuilder(bufferSize);
            hr = getTextMacro(Raw, slot, buffer, bufferSize, out macroSize);

            if (hr == HRESULT.S_OK)
            {
                bufferResult = buffer.ToString();

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
        public void SetTextMacro(uint slot, string macro)
        {
            TrySetTextMacro(slot, macro).ThrowDbgEngNotOk();
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
        public HRESULT TrySetTextMacro(uint slot, string macro)
        {
            InitDelegate(ref setTextMacro, Vtbl->SetTextMacro);

            /*HRESULT SetTextMacro(
            [In] uint Slot,
            [In, MarshalAs(UnmanagedType.LPStr)] string Macro);*/
            return setTextMacro(Raw, slot, macro);
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
            TryEvaluate(expression, desiredType, out result).ThrowDbgEngNotOk();

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
            InitDelegate(ref evaluate, Vtbl->Evaluate);
            /*HRESULT Evaluate(
            [In, MarshalAs(UnmanagedType.LPStr)] string Expression,
            [In] DEBUG_VALUE_TYPE DesiredType,
            [Out] out DEBUG_VALUE Value,
            [Out] out uint RemainderIndex);*/
            DEBUG_VALUE value;
            uint remainderIndex;
            HRESULT hr = evaluate(Raw, expression, desiredType, out value, out remainderIndex);

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
            TryCoerceValue(@in, outType, out @out).ThrowDbgEngNotOk();

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
            InitDelegate(ref coerceValue, Vtbl->CoerceValue);

            /*HRESULT CoerceValue(
            [In] DEBUG_VALUE In,
            [In] DEBUG_VALUE_TYPE OutType,
            [Out] out DEBUG_VALUE Out);*/
            return coerceValue(Raw, @in, outType, out @out);
        }

        #endregion
        #region CoerceValues

        /// <summary>
        /// The CoerceValues method converts an array of values into an array of values of different types.
        /// </summary>
        /// <param name="count">[in] Specifies the number of values to convert.</param>
        /// <param name="in">[in] Specifies the array of values to convert. The number of elements that this array holds is Count.</param>
        /// <param name="outType">[out] Specifies the array to be populated by the converted values. The types of these values are specified by OutType.<para/>
        /// The number of elements that this array holds is Count.</param>
        /// <returns>[in] Specifies the array of desired types for the converted values. For possible values, see <see cref="DEBUG_VALUE"/>.<para/>
        /// The number of elements that this array holds is Count.</returns>
        /// <remarks>
        /// This method converts an array of values of one type into values of another type. Some of these conversions can
        /// result in loss of precision.
        /// </remarks>
        public DEBUG_VALUE[] CoerceValues(uint count, DEBUG_VALUE[] @in, DEBUG_VALUE_TYPE[] outType)
        {
            DEBUG_VALUE[] @out;
            TryCoerceValues(count, @in, outType, out @out).ThrowDbgEngNotOk();

            return @out;
        }

        /// <summary>
        /// The CoerceValues method converts an array of values into an array of values of different types.
        /// </summary>
        /// <param name="count">[in] Specifies the number of values to convert.</param>
        /// <param name="in">[in] Specifies the array of values to convert. The number of elements that this array holds is Count.</param>
        /// <param name="outType">[out] Specifies the array to be populated by the converted values. The types of these values are specified by OutType.<para/>
        /// The number of elements that this array holds is Count.</param>
        /// <param name="out">[in] Specifies the array of desired types for the converted values. For possible values, see <see cref="DEBUG_VALUE"/>.<para/>
        /// The number of elements that this array holds is Count.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// This method converts an array of values of one type into values of another type. Some of these conversions can
        /// result in loss of precision.
        /// </remarks>
        public HRESULT TryCoerceValues(uint count, DEBUG_VALUE[] @in, DEBUG_VALUE_TYPE[] outType, out DEBUG_VALUE[] @out)
        {
            InitDelegate(ref coerceValues, Vtbl->CoerceValues);
            /*HRESULT CoerceValues(
            [In] uint Count,
            [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] DEBUG_VALUE[] In,
            [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] DEBUG_VALUE_TYPE[] OutType,
            [Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] DEBUG_VALUE[] Out);*/
            @out = new DEBUG_VALUE[(int) count];
            HRESULT hr = coerceValues(Raw, count, @in, outType, @out);

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
            TryExecute(outputControl, command, flags).ThrowDbgEngNotOk();
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
            InitDelegate(ref execute, Vtbl->Execute);

            /*HRESULT Execute(
            [In] DEBUG_OUTCTL OutputControl,
            [In, MarshalAs(UnmanagedType.LPStr)] string Command,
            [In] DEBUG_EXECUTE Flags);*/
            return execute(Raw, outputControl, command, flags);
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
            TryExecuteCommandFile(outputControl, commandFile, flags).ThrowDbgEngNotOk();
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
            InitDelegate(ref executeCommandFile, Vtbl->ExecuteCommandFile);

            /*HRESULT ExecuteCommandFile(
            [In] DEBUG_OUTCTL OutputControl,
            [In, MarshalAs(UnmanagedType.LPStr)] string CommandFile,
            [In] DEBUG_EXECUTE Flags);*/
            return executeCommandFile(Raw, outputControl, commandFile, flags);
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
        public DebugBreakpoint GetBreakpointByIndex(uint index)
        {
            DebugBreakpoint bpResult;
            TryGetBreakpointByIndex(index, out bpResult).ThrowDbgEngNotOk();

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
        public HRESULT TryGetBreakpointByIndex(uint index, out DebugBreakpoint bpResult)
        {
            InitDelegate(ref getBreakpointByIndex, Vtbl->GetBreakpointByIndex);
            /*HRESULT GetBreakpointByIndex(
            [In] uint Index,
            [Out, ComAliasName("IDebugBreakpoint")] out IntPtr bp);*/
            IntPtr bp;
            HRESULT hr = getBreakpointByIndex(Raw, index, out bp);

            if (hr == HRESULT.S_OK)
                bpResult = new DebugBreakpoint(bp);
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
        public DebugBreakpoint GetBreakpointById(uint id)
        {
            DebugBreakpoint bpResult;
            TryGetBreakpointById(id, out bpResult).ThrowDbgEngNotOk();

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
        public HRESULT TryGetBreakpointById(uint id, out DebugBreakpoint bpResult)
        {
            InitDelegate(ref getBreakpointById, Vtbl->GetBreakpointById);
            /*HRESULT GetBreakpointById(
            [In] uint Id,
            [Out, ComAliasName("IDebugBreakpoint")] out IntPtr bp);*/
            IntPtr bp;
            HRESULT hr = getBreakpointById(Raw, id, out bp);

            if (hr == HRESULT.S_OK)
                bpResult = new DebugBreakpoint(bp);
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
        public DEBUG_BREAKPOINT_PARAMETERS[] GetBreakpointParameters(uint count, uint[] ids, uint start)
        {
            DEBUG_BREAKPOINT_PARAMETERS[] @params;
            TryGetBreakpointParameters(count, ids, start, out @params).ThrowDbgEngNotOk();

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
        public HRESULT TryGetBreakpointParameters(uint count, uint[] ids, uint start, out DEBUG_BREAKPOINT_PARAMETERS[] @params)
        {
            InitDelegate(ref getBreakpointParameters, Vtbl->GetBreakpointParameters);
            /*HRESULT GetBreakpointParameters(
            [In] uint Count,
            [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] uint[] Ids,
            [In] uint Start,
            [Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] DEBUG_BREAKPOINT_PARAMETERS[] Params);*/
            @params = new DEBUG_BREAKPOINT_PARAMETERS[(int) count];
            HRESULT hr = getBreakpointParameters(Raw, count, ids, start, @params);

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
        /// The client is saved as the adder of the new breakpoint. See <see cref="DebugBreakpoint.GetAdder"/>.
        /// </remarks>
        public DebugBreakpoint AddBreakpoint(DEBUG_BREAKPOINT_TYPE type, uint desiredId)
        {
            DebugBreakpoint bpResult;
            TryAddBreakpoint(type, desiredId, out bpResult).ThrowDbgEngNotOk();

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
        /// The client is saved as the adder of the new breakpoint. See <see cref="DebugBreakpoint.GetAdder"/>.
        /// </remarks>
        public HRESULT TryAddBreakpoint(DEBUG_BREAKPOINT_TYPE type, uint desiredId, out DebugBreakpoint bpResult)
        {
            InitDelegate(ref addBreakpoint, Vtbl->AddBreakpoint);
            /*HRESULT AddBreakpoint(
            [In] DEBUG_BREAKPOINT_TYPE Type,
            [In] uint DesiredId,
            [Out, ComAliasName("IDebugBreakpoint")] out IntPtr Bp);*/
            IntPtr bp;
            HRESULT hr = addBreakpoint(Raw, type, desiredId, out bp);

            if (hr == HRESULT.S_OK)
                bpResult = new DebugBreakpoint(bp);
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
        public void RemoveBreakpoint(IntPtr bp)
        {
            TryRemoveBreakpoint(bp).ThrowDbgEngNotOk();
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
        public HRESULT TryRemoveBreakpoint(IntPtr bp)
        {
            InitDelegate(ref removeBreakpoint, Vtbl->RemoveBreakpoint);

            /*HRESULT RemoveBreakpoint(
            [In, ComAliasName("IDebugBreakpoint")] IntPtr Bp);*/
            return removeBreakpoint(Raw, bp);
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
        public ulong AddExtension(string path, uint flags)
        {
            ulong handle;
            TryAddExtension(path, flags, out handle).ThrowDbgEngNotOk();

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
        public HRESULT TryAddExtension(string path, uint flags, out ulong handle)
        {
            InitDelegate(ref addExtension, Vtbl->AddExtension);

            /*HRESULT AddExtension(
            [In, MarshalAs(UnmanagedType.LPStr)] string Path,
            [In] uint Flags,
            [Out] out ulong Handle);*/
            return addExtension(Raw, path, flags, out handle);
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
        public void RemoveExtension(ulong handle)
        {
            TryRemoveExtension(handle).ThrowDbgEngNotOk();
        }

        /// <summary>
        /// The RemoveExtension method unloads an extension library.
        /// </summary>
        /// <param name="handle">[in] Specifies the handle of the extension library to unload. This is the handle returned by <see cref="AddExtension"/>.</param>
        /// <returns>This method can also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// For more information on using extension libraries, see Calling Extensions and Extension Functions.
        /// </remarks>
        public HRESULT TryRemoveExtension(ulong handle)
        {
            InitDelegate(ref removeExtension, Vtbl->RemoveExtension);

            /*HRESULT RemoveExtension(
            [In] ulong Handle);*/
            return removeExtension(Raw, handle);
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
        public ulong GetExtensionByPath(string path)
        {
            ulong handle;
            TryGetExtensionByPath(path, out handle).ThrowDbgEngNotOk();

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
        public HRESULT TryGetExtensionByPath(string path, out ulong handle)
        {
            InitDelegate(ref getExtensionByPath, Vtbl->GetExtensionByPath);

            /*HRESULT GetExtensionByPath(
            [In, MarshalAs(UnmanagedType.LPStr)] string Path,
            [Out] out ulong Handle);*/
            return getExtensionByPath(Raw, path, out handle);
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
        public void CallExtension(ulong handle, string function, string arguments)
        {
            TryCallExtension(handle, function, arguments).ThrowDbgEngNotOk();
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
        public HRESULT TryCallExtension(ulong handle, string function, string arguments)
        {
            InitDelegate(ref callExtension, Vtbl->CallExtension);

            /*HRESULT CallExtension(
            [In] ulong Handle,
            [In, MarshalAs(UnmanagedType.LPStr)] string Function,
            [In, MarshalAs(UnmanagedType.LPStr)] string Arguments);*/
            return callExtension(Raw, handle, function, arguments);
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
        public IntPtr GetExtensionFunction(ulong handle, string funcName)
        {
            IntPtr function;
            TryGetExtensionFunction(handle, funcName, out function).ThrowDbgEngNotOk();

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
        public HRESULT TryGetExtensionFunction(ulong handle, string funcName, out IntPtr function)
        {
            InitDelegate(ref getExtensionFunction, Vtbl->GetExtensionFunction);

            /*HRESULT GetExtensionFunction(
            [In] ulong Handle,
            [In, MarshalAs(UnmanagedType.LPStr)] string FuncName,
            [Out] out IntPtr Function);*/
            return getExtensionFunction(Raw, handle, funcName, out function);
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
            TryGetWindbgExtensionApis32(ref api).ThrowDbgEngNotOk();
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
            InitDelegate(ref getWindbgExtensionApis32, Vtbl->GetWindbgExtensionApis32);

            /*HRESULT GetWindbgExtensionApis32(
            [In, Out] ref WINDBG_EXTENSION_APIS Api);*/
            return getWindbgExtensionApis32(Raw, ref api);
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
            TryGetWindbgExtensionApis64(ref api).ThrowDbgEngNotOk();
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
            InitDelegate(ref getWindbgExtensionApis64, Vtbl->GetWindbgExtensionApis64);

            /*HRESULT GetWindbgExtensionApis64(
            [In, Out] ref WINDBG_EXTENSION_APIS Api);*/
            return getWindbgExtensionApis64(Raw, ref api);
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
        public string GetEventFilterText(uint index)
        {
            string bufferResult;
            TryGetEventFilterText(index, out bufferResult).ThrowDbgEngNotOk();

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
        public HRESULT TryGetEventFilterText(uint index, out string bufferResult)
        {
            InitDelegate(ref getEventFilterText, Vtbl->GetEventFilterText);
            /*HRESULT GetEventFilterText(
            [In] uint Index,
            [Out, MarshalAs(UnmanagedType.LPStr)] StringBuilder Buffer,
            [In] int BufferSize,
            [Out] out uint TextSize);*/
            StringBuilder buffer;
            int bufferSize = 0;
            uint textSize;
            HRESULT hr = getEventFilterText(Raw, index, null, bufferSize, out textSize);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER && hr != HRESULT.S_OK)
                goto fail;

            bufferSize = (int) textSize;
            buffer = new StringBuilder(bufferSize);
            hr = getEventFilterText(Raw, index, buffer, bufferSize, out textSize);

            if (hr == HRESULT.S_OK)
            {
                bufferResult = buffer.ToString();

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
        public string GetEventFilterCommand(uint index)
        {
            string bufferResult;
            TryGetEventFilterCommand(index, out bufferResult).ThrowDbgEngNotOk();

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
        public HRESULT TryGetEventFilterCommand(uint index, out string bufferResult)
        {
            InitDelegate(ref getEventFilterCommand, Vtbl->GetEventFilterCommand);
            /*HRESULT GetEventFilterCommand(
            [In] uint Index,
            [Out, MarshalAs(UnmanagedType.LPStr)] StringBuilder Buffer,
            [In] int BufferSize,
            [Out] out uint CommandSize);*/
            StringBuilder buffer;
            int bufferSize = 0;
            uint commandSize;
            HRESULT hr = getEventFilterCommand(Raw, index, null, bufferSize, out commandSize);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER && hr != HRESULT.S_OK)
                goto fail;

            bufferSize = (int) commandSize;
            buffer = new StringBuilder(bufferSize);
            hr = getEventFilterCommand(Raw, index, buffer, bufferSize, out commandSize);

            if (hr == HRESULT.S_OK)
            {
                bufferResult = buffer.ToString();

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
        public void SetEventFilterCommand(uint index, string command)
        {
            TrySetEventFilterCommand(index, command).ThrowDbgEngNotOk();
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
        public HRESULT TrySetEventFilterCommand(uint index, string command)
        {
            InitDelegate(ref setEventFilterCommand, Vtbl->SetEventFilterCommand);

            /*HRESULT SetEventFilterCommand(
            [In] uint Index,
            [In, MarshalAs(UnmanagedType.LPStr)] string Command);*/
            return setEventFilterCommand(Raw, index, command);
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
        public DEBUG_SPECIFIC_FILTER_PARAMETERS[] GetSpecificFilterParameters(uint start, uint count)
        {
            DEBUG_SPECIFIC_FILTER_PARAMETERS[] @params;
            TryGetSpecificFilterParameters(start, count, out @params).ThrowDbgEngNotOk();

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
        public HRESULT TryGetSpecificFilterParameters(uint start, uint count, out DEBUG_SPECIFIC_FILTER_PARAMETERS[] @params)
        {
            InitDelegate(ref getSpecificFilterParameters, Vtbl->GetSpecificFilterParameters);
            /*HRESULT GetSpecificFilterParameters(
            [In] uint Start,
            [In] uint Count,
            [Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] DEBUG_SPECIFIC_FILTER_PARAMETERS[] Params);*/
            @params = new DEBUG_SPECIFIC_FILTER_PARAMETERS[(int) count];
            HRESULT hr = getSpecificFilterParameters(Raw, start, count, @params);

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
        public void SetSpecificFilterParameters(uint start, uint count, DEBUG_SPECIFIC_FILTER_PARAMETERS[] @params)
        {
            TrySetSpecificFilterParameters(start, count, @params).ThrowDbgEngNotOk();
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
        public HRESULT TrySetSpecificFilterParameters(uint start, uint count, DEBUG_SPECIFIC_FILTER_PARAMETERS[] @params)
        {
            InitDelegate(ref setSpecificFilterParameters, Vtbl->SetSpecificFilterParameters);

            /*HRESULT SetSpecificFilterParameters(
            [In] uint Start,
            [In] uint Count,
            [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] DEBUG_SPECIFIC_FILTER_PARAMETERS[] Params);*/
            return setSpecificFilterParameters(Raw, start, count, @params);
        }

        #endregion
        #region GetSpecificEventFilterArgument

        public string GetSpecificEventFilterArgument(uint index)
        {
            string bufferResult;
            TryGetSpecificEventFilterArgument(index, out bufferResult).ThrowDbgEngNotOk();

            return bufferResult;
        }

        public HRESULT TryGetSpecificEventFilterArgument(uint index, out string bufferResult)
        {
            InitDelegate(ref getSpecificEventFilterArgument, Vtbl->GetSpecificEventFilterArgument);
            /*HRESULT GetSpecificEventFilterArgument(
            [In] uint Index,
            [Out, MarshalAs(UnmanagedType.LPStr)] StringBuilder Buffer,
            [In] int BufferSize,
            [Out] out uint ArgumentSize);*/
            StringBuilder buffer;
            int bufferSize = 0;
            uint argumentSize;
            HRESULT hr = getSpecificEventFilterArgument(Raw, index, null, bufferSize, out argumentSize);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER && hr != HRESULT.S_OK)
                goto fail;

            bufferSize = (int) argumentSize;
            buffer = new StringBuilder(bufferSize);
            hr = getSpecificEventFilterArgument(Raw, index, buffer, bufferSize, out argumentSize);

            if (hr == HRESULT.S_OK)
            {
                bufferResult = buffer.ToString();

                return hr;
            }

            fail:
            bufferResult = default(string);

            return hr;
        }

        #endregion
        #region SetSpecificEventFilterArgument

        public void SetSpecificEventFilterArgument(uint index, string argument)
        {
            TrySetSpecificEventFilterArgument(index, argument).ThrowDbgEngNotOk();
        }

        public HRESULT TrySetSpecificEventFilterArgument(uint index, string argument)
        {
            InitDelegate(ref setSpecificEventFilterArgument, Vtbl->SetSpecificEventFilterArgument);

            /*HRESULT SetSpecificEventFilterArgument(
            [In] uint Index,
            [In, MarshalAs(UnmanagedType.LPStr)] string Argument);*/
            return setSpecificEventFilterArgument(Raw, index, argument);
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
        public DEBUG_EXCEPTION_FILTER_PARAMETERS[] GetExceptionFilterParameters(uint count, uint[] codes, uint start)
        {
            DEBUG_EXCEPTION_FILTER_PARAMETERS[] @params;
            TryGetExceptionFilterParameters(count, codes, start, out @params).ThrowDbgEngNotOk();

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
        public HRESULT TryGetExceptionFilterParameters(uint count, uint[] codes, uint start, out DEBUG_EXCEPTION_FILTER_PARAMETERS[] @params)
        {
            InitDelegate(ref getExceptionFilterParameters, Vtbl->GetExceptionFilterParameters);
            /*HRESULT GetExceptionFilterParameters(
            [In] uint Count,
            [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] uint[] Codes,
            [In] uint Start,
            [Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] DEBUG_EXCEPTION_FILTER_PARAMETERS[] Params);*/
            @params = new DEBUG_EXCEPTION_FILTER_PARAMETERS[(int) count];
            HRESULT hr = getExceptionFilterParameters(Raw, count, codes, start, @params);

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
        public void SetExceptionFilterParameters(uint count, DEBUG_EXCEPTION_FILTER_PARAMETERS[] @params)
        {
            TrySetExceptionFilterParameters(count, @params).ThrowDbgEngNotOk();
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
        public HRESULT TrySetExceptionFilterParameters(uint count, DEBUG_EXCEPTION_FILTER_PARAMETERS[] @params)
        {
            InitDelegate(ref setExceptionFilterParameters, Vtbl->SetExceptionFilterParameters);

            /*HRESULT SetExceptionFilterParameters(
            [In] uint Count,
            [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] DEBUG_EXCEPTION_FILTER_PARAMETERS[] Params);*/
            return setExceptionFilterParameters(Raw, count, @params);
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
        public string GetExceptionFilterSecondCommand(uint index)
        {
            string bufferResult;
            TryGetExceptionFilterSecondCommand(index, out bufferResult).ThrowDbgEngNotOk();

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
        public HRESULT TryGetExceptionFilterSecondCommand(uint index, out string bufferResult)
        {
            InitDelegate(ref getExceptionFilterSecondCommand, Vtbl->GetExceptionFilterSecondCommand);
            /*HRESULT GetExceptionFilterSecondCommand(
            [In] uint Index,
            [Out, MarshalAs(UnmanagedType.LPStr)] StringBuilder Buffer,
            [In] int BufferSize,
            [Out] out uint CommandSize);*/
            StringBuilder buffer;
            int bufferSize = 0;
            uint commandSize;
            HRESULT hr = getExceptionFilterSecondCommand(Raw, index, null, bufferSize, out commandSize);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER && hr != HRESULT.S_OK)
                goto fail;

            bufferSize = (int) commandSize;
            buffer = new StringBuilder(bufferSize);
            hr = getExceptionFilterSecondCommand(Raw, index, buffer, bufferSize, out commandSize);

            if (hr == HRESULT.S_OK)
            {
                bufferResult = buffer.ToString();

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
        public void SetExceptionFilterSecondCommand(uint index, string command)
        {
            TrySetExceptionFilterSecondCommand(index, command).ThrowDbgEngNotOk();
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
        public HRESULT TrySetExceptionFilterSecondCommand(uint index, string command)
        {
            InitDelegate(ref setExceptionFilterSecondCommand, Vtbl->SetExceptionFilterSecondCommand);

            /*HRESULT SetExceptionFilterSecondCommand(
            [In] uint Index,
            [In, MarshalAs(UnmanagedType.LPStr)] string Command);*/
            return setExceptionFilterSecondCommand(Raw, index, command);
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
            TryWaitForEvent(flags, timeout).ThrowDbgEngNotOk();
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
            InitDelegate(ref waitForEvent, Vtbl->WaitForEvent);

            /*HRESULT WaitForEvent(
            [In] DEBUG_WAIT Flags,
            [In] int Timeout);*/
            return waitForEvent(Raw, flags, timeout);
        }

        #endregion
        #region GetLastEventInformation

        /// <summary>
        /// The GetLastEventInformation method returns information about the last event that occurred in a target.
        /// </summary>
        /// <param name="extraInformation">[out, optional] Receives extra information about the event. The contents of this extra information depends on the type of the event.<para/>
        /// If ExtraInformation is NULL, this information is not returned.</param>
        /// <param name="descriptionSize">[in] Specifies the size, in characters, of the buffer that Description specifies. This size includes the space for the '\0' terminating character.</param>
        /// <returns>The values that were emitted from the COM method.</returns>
        /// <remarks>
        /// For thread and process creation events, the thread index and process ID returned to ThreadId and ProcessId are
        /// for the newly created thread or process. For more information about the last event, see the topic Event Information.
        /// </remarks>
        public GetLastEventInformationResult GetLastEventInformation(IntPtr extraInformation, int descriptionSize)
        {
            GetLastEventInformationResult result;
            TryGetLastEventInformation(extraInformation, descriptionSize, out result).ThrowDbgEngNotOk();

            return result;
        }

        /// <summary>
        /// The GetLastEventInformation method returns information about the last event that occurred in a target.
        /// </summary>
        /// <param name="extraInformation">[out, optional] Receives extra information about the event. The contents of this extra information depends on the type of the event.<para/>
        /// If ExtraInformation is NULL, this information is not returned.</param>
        /// <param name="descriptionSize">[in] Specifies the size, in characters, of the buffer that Description specifies. This size includes the space for the '\0' terminating character.</param>
        /// <param name="result">The values that were emitted from the COM method.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// For thread and process creation events, the thread index and process ID returned to ThreadId and ProcessId are
        /// for the newly created thread or process. For more information about the last event, see the topic Event Information.
        /// </remarks>
        public HRESULT TryGetLastEventInformation(IntPtr extraInformation, int descriptionSize, out GetLastEventInformationResult result)
        {
            InitDelegate(ref getLastEventInformation, Vtbl->GetLastEventInformation);
            /*HRESULT GetLastEventInformation(
            [Out] out DEBUG_EVENT_TYPE Type,
            [Out] out uint ProcessId,
            [Out] out uint ThreadId,
            [In] IntPtr ExtraInformation,
            [In] uint ExtraInformationSize,
            [Out] out uint ExtraInformationUsed,
            [Out, MarshalAs(UnmanagedType.LPStr)] StringBuilder Description,
            [In] int DescriptionSize,
            [Out] out uint DescriptionUsed);*/
            DEBUG_EVENT_TYPE type;
            uint processId;
            uint threadId;
            uint extraInformationSize = 0;
            uint extraInformationUsed;
            StringBuilder description;
            uint descriptionUsed;
            HRESULT hr = getLastEventInformation(Raw, out type, out processId, out threadId, extraInformation, extraInformationSize, out extraInformationUsed, null, descriptionSize, out descriptionUsed);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER && hr != HRESULT.S_OK)
                goto fail;

            extraInformationSize = extraInformationUsed;
            description = new StringBuilder((int) extraInformationSize);
            hr = getLastEventInformation(Raw, out type, out processId, out threadId, extraInformation, extraInformationSize, out extraInformationUsed, description, descriptionSize, out descriptionUsed);

            if (hr == HRESULT.S_OK)
            {
                result = new GetLastEventInformationResult(type, processId, threadId, description.ToString(), descriptionUsed);

                return hr;
            }

            fail:
            result = default(GetLastEventInformationResult);

            return hr;
        }

        #endregion
        #endregion
        #region IDebugControl2
        #region CurrentTimeDate

        /// <summary>
        /// The GetCurrentTimeDate method returns the time of the current target.
        /// </summary>
        public uint CurrentTimeDate
        {
            get
            {
                uint timeDate;
                TryGetCurrentTimeDate(out timeDate).ThrowDbgEngNotOk();

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
        public HRESULT TryGetCurrentTimeDate(out uint timeDate)
        {
            InitDelegate(ref getCurrentTimeDate, Vtbl2->GetCurrentTimeDate);

            /*HRESULT GetCurrentTimeDate(
            [Out] out uint TimeDate);*/
            return getCurrentTimeDate(Raw, out timeDate);
        }

        #endregion
        #region CurrentSystemUpTime

        /// <summary>
        /// The GetCurrentSystemUpTime method returns the number of seconds the current target's computer has been running since it was last started.
        /// </summary>
        public uint CurrentSystemUpTime
        {
            get
            {
                uint upTime;
                TryGetCurrentSystemUpTime(out upTime).ThrowDbgEngNotOk();

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
        public HRESULT TryGetCurrentSystemUpTime(out uint upTime)
        {
            InitDelegate(ref getCurrentSystemUpTime, Vtbl2->GetCurrentSystemUpTime);

            /*HRESULT GetCurrentSystemUpTime(
            [Out] out uint UpTime);*/
            return getCurrentSystemUpTime(Raw, out upTime);
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
                TryGetDumpFormatFlags(out formatFlags).ThrowDbgEngNotOk();

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
            InitDelegate(ref getDumpFormatFlags, Vtbl2->GetDumpFormatFlags);

            /*HRESULT GetDumpFormatFlags(
            [Out] out DEBUG_FORMAT FormatFlags);*/
            return getDumpFormatFlags(Raw, out formatFlags);
        }

        #endregion
        #region NumberTextReplacements

        /// <summary>
        /// The GetNumberTextReplacements method returns the number of currently defined user-named and automatic aliases.
        /// </summary>
        public uint NumberTextReplacements
        {
            get
            {
                uint numRepl;
                TryGetNumberTextReplacements(out numRepl).ThrowDbgEngNotOk();

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
        public HRESULT TryGetNumberTextReplacements(out uint numRepl)
        {
            InitDelegate(ref getNumberTextReplacements, Vtbl2->GetNumberTextReplacements);

            /*HRESULT GetNumberTextReplacements(
            [Out] out uint NumRepl);*/
            return getNumberTextReplacements(Raw, out numRepl);
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
        public GetTextReplacementResult GetTextReplacement(string srcText, uint index)
        {
            GetTextReplacementResult result;
            TryGetTextReplacement(srcText, index, out result).ThrowDbgEngNotOk();

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
        public HRESULT TryGetTextReplacement(string srcText, uint index, out GetTextReplacementResult result)
        {
            InitDelegate(ref getTextReplacement, Vtbl2->GetTextReplacement);
            /*HRESULT GetTextReplacement(
            [In, MarshalAs(UnmanagedType.LPStr)] string SrcText,
            [In] uint Index,
            [Out, MarshalAs(UnmanagedType.LPStr)] StringBuilder SrcBuffer,
            [In] int SrcBufferSize,
            [Out] out uint SrcSize,
            [Out, MarshalAs(UnmanagedType.LPStr)] StringBuilder DstBuffer,
            [In] int DstBufferSize,
            [Out] out uint DstSize);*/
            StringBuilder srcBuffer;
            int srcBufferSize = 0;
            uint srcSize;
            StringBuilder dstBuffer;
            int dstBufferSize = 0;
            uint dstSize;
            HRESULT hr = getTextReplacement(Raw, srcText, index, null, srcBufferSize, out srcSize, null, dstBufferSize, out dstSize);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER && hr != HRESULT.S_OK)
                goto fail;

            srcBufferSize = (int) srcSize;
            srcBuffer = new StringBuilder(srcBufferSize);
            dstBufferSize = (int) dstSize;
            dstBuffer = new StringBuilder(dstBufferSize);
            hr = getTextReplacement(Raw, srcText, index, srcBuffer, srcBufferSize, out srcSize, dstBuffer, dstBufferSize, out dstSize);

            if (hr == HRESULT.S_OK)
            {
                result = new GetTextReplacementResult(srcBuffer.ToString(), dstBuffer.ToString());

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
            TrySetTextReplacement(srcText, dstText).ThrowDbgEngNotOk();
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
            InitDelegate(ref setTextReplacement, Vtbl2->SetTextReplacement);

            /*HRESULT SetTextReplacement(
            [In, MarshalAs(UnmanagedType.LPStr)] string SrcText,
            [In, MarshalAs(UnmanagedType.LPStr)] string DstText);*/
            return setTextReplacement(Raw, srcText, dstText);
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
            TryRemoveTextReplacements().ThrowDbgEngNotOk();
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
            InitDelegate(ref removeTextReplacements, Vtbl2->RemoveTextReplacements);

            /*HRESULT RemoveTextReplacements();*/
            return removeTextReplacements(Raw);
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
            TryOutputTextReplacements(outputControl, flags).ThrowDbgEngNotOk();
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
            InitDelegate(ref outputTextReplacements, Vtbl2->OutputTextReplacements);

            /*HRESULT OutputTextReplacements(
            [In] DEBUG_OUTCTL OutputControl,
            [In] DEBUG_OUT_TEXT_REPL Flags);*/
            return outputTextReplacements(Raw, outputControl, flags);
        }

        #endregion
        #endregion
        #region IDebugControl3
        #region AssemblyOptions

        /// <summary>
        /// The GetAssemblyOptions method returns the assembly and disassembly options that affect how the debugger engine assembles and disassembles processor instructions for the target.
        /// </summary>
        public DEBUG_ASMOPT AssemblyOptions
        {
            get
            {
                DEBUG_ASMOPT options;
                TryGetAssemblyOptions(out options).ThrowDbgEngNotOk();

                return options;
            }
            set
            {
                TrySetAssemblyOptions(value).ThrowDbgEngNotOk();
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
            InitDelegate(ref getAssemblyOptions, Vtbl3->GetAssemblyOptions);

            /*HRESULT GetAssemblyOptions(
            [Out] out DEBUG_ASMOPT Options);*/
            return getAssemblyOptions(Raw, out options);
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
            InitDelegate(ref setAssemblyOptions, Vtbl3->SetAssemblyOptions);

            /*HRESULT SetAssemblyOptions(
            [In] DEBUG_ASMOPT Options);*/
            return setAssemblyOptions(Raw, options);
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
                TryGetExpressionSyntax(out flags).ThrowDbgEngNotOk();

                return flags;
            }
            set
            {
                TrySetExpressionSyntax(value).ThrowDbgEngNotOk();
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
            InitDelegate(ref getExpressionSyntax, Vtbl3->GetExpressionSyntax);

            /*HRESULT GetExpressionSyntax(
            [Out] out DEBUG_EXPR Flags);*/
            return getExpressionSyntax(Raw, out flags);
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
            InitDelegate(ref setExpressionSyntax, Vtbl3->SetExpressionSyntax);

            /*HRESULT SetExpressionSyntax(
            [In] DEBUG_EXPR Flags);*/
            return setExpressionSyntax(Raw, flags);
        }

        #endregion
        #region NumberExpressionSyntaxes

        /// <summary>
        /// The GetNumberExpressionSyntaxes method returns the number of expression syntaxes that are supported by the engine.
        /// </summary>
        public uint NumberExpressionSyntaxes
        {
            get
            {
                uint number;
                TryGetNumberExpressionSyntaxes(out number).ThrowDbgEngNotOk();

                return number;
            }
        }

        /// <summary>
        /// The GetNumberExpressionSyntaxes method returns the number of expression syntaxes that are supported by the engine.
        /// </summary>
        /// <param name="number">[out] Receives the number of expression syntaxes.</param>
        /// <returns>This method can also return error values. See Return Values for more details.</returns>
        public HRESULT TryGetNumberExpressionSyntaxes(out uint number)
        {
            InitDelegate(ref getNumberExpressionSyntaxes, Vtbl3->GetNumberExpressionSyntaxes);

            /*HRESULT GetNumberExpressionSyntaxes(
            [Out] out uint Number);*/
            return getNumberExpressionSyntaxes(Raw, out number);
        }

        #endregion
        #region NumberEvents

        /// <summary>
        /// The GetNumberEvents method returns the number of events for the current target, if the number of events is fixed.
        /// </summary>
        public uint NumberEvents
        {
            get
            {
                uint events;
                TryGetNumberEvents(out events).ThrowDbgEngNotOk();

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
        public HRESULT TryGetNumberEvents(out uint events)
        {
            InitDelegate(ref getNumberEvents, Vtbl3->GetNumberEvents);

            /*HRESULT GetNumberEvents(
            [Out] out uint Events);*/
            return getNumberEvents(Raw, out events);
        }

        #endregion
        #region CurrentEventIndex

        /// <summary>
        /// The GetCurrentEventIndex method returns the index of the current event within the current list of events for the current target, if such a list exists.
        /// </summary>
        public uint CurrentEventIndex
        {
            get
            {
                uint index;
                TryGetCurrentEventIndex(out index).ThrowDbgEngNotOk();

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
        public HRESULT TryGetCurrentEventIndex(out uint index)
        {
            InitDelegate(ref getCurrentEventIndex, Vtbl3->GetCurrentEventIndex);

            /*HRESULT GetCurrentEventIndex(
            [Out] out uint Index);*/
            return getCurrentEventIndex(Raw, out index);
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
            TryAddAssemblyOptions(options).ThrowDbgEngNotOk();
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
            InitDelegate(ref addAssemblyOptions, Vtbl3->AddAssemblyOptions);

            /*HRESULT AddAssemblyOptions(
            [In] DEBUG_ASMOPT Options);*/
            return addAssemblyOptions(Raw, options);
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
            TryRemoveAssemblyOptions(options).ThrowDbgEngNotOk();
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
            InitDelegate(ref removeAssemblyOptions, Vtbl3->RemoveAssemblyOptions);

            /*HRESULT RemoveAssemblyOptions(
            [In] DEBUG_ASMOPT Options);*/
            return removeAssemblyOptions(Raw, options);
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
            TrySetExpressionSyntaxByName(abbrevName).ThrowDbgEngNotOk();
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
            InitDelegate(ref setExpressionSyntaxByName, Vtbl3->SetExpressionSyntaxByName);

            /*HRESULT SetExpressionSyntaxByName(
            [In, MarshalAs(UnmanagedType.LPStr)] string AbbrevName);*/
            return setExpressionSyntaxByName(Raw, abbrevName);
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
        public GetExpressionSyntaxNamesResult GetExpressionSyntaxNames(uint index)
        {
            GetExpressionSyntaxNamesResult result;
            TryGetExpressionSyntaxNames(index, out result).ThrowDbgEngNotOk();

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
        public HRESULT TryGetExpressionSyntaxNames(uint index, out GetExpressionSyntaxNamesResult result)
        {
            InitDelegate(ref getExpressionSyntaxNames, Vtbl3->GetExpressionSyntaxNames);
            /*HRESULT GetExpressionSyntaxNames(
            [In] uint Index,
            [Out, MarshalAs(UnmanagedType.LPStr)] StringBuilder FullNameBuffer,
            [In] int FullNameBufferSize,
            [Out] out uint FullNameSize,
            [Out, MarshalAs(UnmanagedType.LPStr)] StringBuilder AbbrevNameBuffer,
            [In] int AbbrevNameBufferSize,
            [Out] out uint AbbrevNameSize);*/
            StringBuilder fullNameBuffer;
            int fullNameBufferSize = 0;
            uint fullNameSize;
            StringBuilder abbrevNameBuffer;
            int abbrevNameBufferSize = 0;
            uint abbrevNameSize;
            HRESULT hr = getExpressionSyntaxNames(Raw, index, null, fullNameBufferSize, out fullNameSize, null, abbrevNameBufferSize, out abbrevNameSize);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER && hr != HRESULT.S_OK)
                goto fail;

            fullNameBufferSize = (int) fullNameSize;
            fullNameBuffer = new StringBuilder(fullNameBufferSize);
            abbrevNameBufferSize = (int) abbrevNameSize;
            abbrevNameBuffer = new StringBuilder(abbrevNameBufferSize);
            hr = getExpressionSyntaxNames(Raw, index, fullNameBuffer, fullNameBufferSize, out fullNameSize, abbrevNameBuffer, abbrevNameBufferSize, out abbrevNameSize);

            if (hr == HRESULT.S_OK)
            {
                result = new GetExpressionSyntaxNamesResult(fullNameBuffer.ToString(), abbrevNameBuffer.ToString());

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
        public string GetEventIndexDescription(uint index, DEBUG_EINDEX which)
        {
            string bufferResult;
            TryGetEventIndexDescription(index, which, out bufferResult).ThrowDbgEngNotOk();

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
        public HRESULT TryGetEventIndexDescription(uint index, DEBUG_EINDEX which, out string bufferResult)
        {
            InitDelegate(ref getEventIndexDescription, Vtbl3->GetEventIndexDescription);
            /*HRESULT GetEventIndexDescription(
            [In] uint Index,
            [In] DEBUG_EINDEX Which,
            [Out, MarshalAs(UnmanagedType.LPStr)] StringBuilder Buffer,
            [In] int BufferSize,
            [Out] out uint DescSize);*/
            StringBuilder buffer;
            int bufferSize = 0;
            uint descSize;
            HRESULT hr = getEventIndexDescription(Raw, index, which, null, bufferSize, out descSize);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER && hr != HRESULT.S_OK)
                goto fail;

            bufferSize = (int) descSize;
            buffer = new StringBuilder(bufferSize);
            hr = getEventIndexDescription(Raw, index, which, buffer, bufferSize, out descSize);

            if (hr == HRESULT.S_OK)
            {
                bufferResult = buffer.ToString();

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
        public uint SetNextEventIndex(DEBUG_EINDEX relation, uint value)
        {
            uint nextIndex;
            TrySetNextEventIndex(relation, value, out nextIndex).ThrowDbgEngNotOk();

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
        public HRESULT TrySetNextEventIndex(DEBUG_EINDEX relation, uint value, out uint nextIndex)
        {
            InitDelegate(ref setNextEventIndex, Vtbl3->SetNextEventIndex);

            /*HRESULT SetNextEventIndex(
            [In] DEBUG_EINDEX Relation,
            [In] uint Value,
            [Out] out uint NextIndex);*/
            return setNextEventIndex(Raw, relation, value, out nextIndex);
        }

        #endregion
        #endregion
        #region IDebugControl4
        #region LogFileWide

        /// <summary>
        /// The GetLogFileWide method returns the name of the currently open log file.
        /// </summary>
        public GetLogFileWideResult LogFileWide
        {
            get
            {
                GetLogFileWideResult result;
                TryGetLogFileWide(out result).ThrowDbgEngNotOk();

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
            InitDelegate(ref getLogFileWide, Vtbl4->GetLogFileWide);
            /*HRESULT GetLogFileWide(
            [Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder Buffer,
            [In] int BufferSize,
            [Out] out uint FileSize,
            [Out, MarshalAs(UnmanagedType.Bool)] out bool Append);*/
            StringBuilder buffer;
            int bufferSize = 0;
            uint fileSize;
            bool append;
            HRESULT hr = getLogFileWide(Raw, null, bufferSize, out fileSize, out append);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER && hr != HRESULT.S_OK)
                goto fail;

            bufferSize = (int) fileSize;
            buffer = new StringBuilder(bufferSize);
            hr = getLogFileWide(Raw, buffer, bufferSize, out fileSize, out append);

            if (hr == HRESULT.S_OK)
            {
                result = new GetLogFileWideResult(buffer.ToString(), append);

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
                TryGetPromptTextWide(out bufferResult).ThrowDbgEngNotOk();

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
            InitDelegate(ref getPromptTextWide, Vtbl4->GetPromptTextWide);
            /*HRESULT GetPromptTextWide(
            [Out, MarshalAs(UnmanagedType.LPWStr)]
            StringBuilder Buffer,
            [In] int BufferSize,
            [Out] out uint TextSize);*/
            StringBuilder buffer;
            int bufferSize = 0;
            uint textSize;
            HRESULT hr = getPromptTextWide(Raw, null, bufferSize, out textSize);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER && hr != HRESULT.S_OK)
                goto fail;

            bufferSize = (int) textSize;
            buffer = new StringBuilder(bufferSize);
            hr = getPromptTextWide(Raw, buffer, bufferSize, out textSize);

            if (hr == HRESULT.S_OK)
            {
                bufferResult = buffer.ToString();

                return hr;
            }

            fail:
            bufferResult = default(string);

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
                TryGetLogFile2(out result).ThrowDbgEngNotOk();

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
            InitDelegate(ref getLogFile2, Vtbl4->GetLogFile2);
            /*HRESULT GetLogFile2(
            [Out, MarshalAs(UnmanagedType.LPStr)] StringBuilder Buffer,
            [In] int BufferSize,
            [Out] out uint FileSize,
            [Out] out DEBUG_LOG Flags);*/
            StringBuilder buffer;
            int bufferSize = 0;
            uint fileSize;
            DEBUG_LOG flags;
            HRESULT hr = getLogFile2(Raw, null, bufferSize, out fileSize, out flags);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER && hr != HRESULT.S_OK)
                goto fail;

            bufferSize = (int) fileSize;
            buffer = new StringBuilder(bufferSize);
            hr = getLogFile2(Raw, buffer, bufferSize, out fileSize, out flags);

            if (hr == HRESULT.S_OK)
            {
                result = new GetLogFile2Result(buffer.ToString(), flags);

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
                TryGetLogFile2Wide(out result).ThrowDbgEngNotOk();

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
            InitDelegate(ref getLogFile2Wide, Vtbl4->GetLogFile2Wide);
            /*HRESULT GetLogFile2Wide(
            [Out, MarshalAs(UnmanagedType.LPWStr)]
            StringBuilder Buffer,
            [In] int BufferSize,
            [Out] out uint FileSize,
            [Out] out DEBUG_LOG Flags);*/
            StringBuilder buffer;
            int bufferSize = 0;
            uint fileSize;
            DEBUG_LOG flags;
            HRESULT hr = getLogFile2Wide(Raw, null, bufferSize, out fileSize, out flags);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER && hr != HRESULT.S_OK)
                goto fail;

            bufferSize = (int) fileSize;
            buffer = new StringBuilder(bufferSize);
            hr = getLogFile2Wide(Raw, buffer, bufferSize, out fileSize, out flags);

            if (hr == HRESULT.S_OK)
            {
                result = new GetLogFile2WideResult(buffer.ToString(), flags);

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
                TryGetSystemVersionValues(out result).ThrowDbgEngNotOk();

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
            InitDelegate(ref getSystemVersionValues, Vtbl4->GetSystemVersionValues);
            /*HRESULT GetSystemVersionValues(
            [Out] out uint PlatformId,
            [Out] out uint Win32Major,
            [Out] out uint Win32Minor,
            [Out] out uint KdMajor,
            [Out] out uint KdMinor);*/
            uint platformId;
            uint win32Major;
            uint win32Minor;
            uint kdMajor;
            uint kdMinor;
            HRESULT hr = getSystemVersionValues(Raw, out platformId, out win32Major, out win32Minor, out kdMajor, out kdMinor);

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
            TryOpenLogFileWide(file, append).ThrowDbgEngNotOk();
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
            InitDelegate(ref openLogFileWide, Vtbl4->OpenLogFileWide);

            /*HRESULT OpenLogFileWide(
            [In, MarshalAs(UnmanagedType.LPWStr)] string File,
            [In, MarshalAs(UnmanagedType.Bool)] bool Append);*/
            return openLogFileWide(Raw, file, append);
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
            TryInputWide(out bufferResult).ThrowDbgEngNotOk();

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
            InitDelegate(ref inputWide, Vtbl4->InputWide);
            /*HRESULT InputWide(
            [Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder Buffer,
            [In] int BufferSize,
            [Out] out uint InputSize);*/
            StringBuilder buffer;
            int bufferSize = 0;
            uint inputSize;
            HRESULT hr = inputWide(Raw, null, bufferSize, out inputSize);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER && hr != HRESULT.S_OK)
                goto fail;

            bufferSize = (int) inputSize;
            buffer = new StringBuilder(bufferSize);
            hr = inputWide(Raw, buffer, bufferSize, out inputSize);

            if (hr == HRESULT.S_OK)
            {
                bufferResult = buffer.ToString();

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
            TryReturnInputWide(buffer).ThrowDbgEngNotOk();
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
            InitDelegate(ref returnInputWide, Vtbl4->ReturnInputWide);

            /*HRESULT ReturnInputWide(
            [In, MarshalAs(UnmanagedType.LPWStr)] string Buffer);*/
            return returnInputWide(Raw, buffer);
        }

        #endregion
        #region OutputWide

        /// <summary>
        /// The OutputWide method formats a string and send the result to output callbacks that have been registered with the engine's clients.
        /// </summary>
        /// <remarks>
        /// When generating very large output strings, it is possible to reach the limits of the debugger engine or of the
        /// operating system. For example, some versions of the debugger engine have a 16K character limit for a single output.
        /// If you find that very large output is getting truncated, you might need to split your output into multiple requests.
        /// </remarks>
        public void OutputWide(DEBUG_OUTPUT mask, string format)
        {
            TryOutputWide(mask, format).ThrowDbgEngNotOk();
        }

        /// <summary>
        /// The OutputWide method formats a string and send the result to output callbacks that have been registered with the engine's clients.
        /// </summary>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// When generating very large output strings, it is possible to reach the limits of the debugger engine or of the
        /// operating system. For example, some versions of the debugger engine have a 16K character limit for a single output.
        /// If you find that very large output is getting truncated, you might need to split your output into multiple requests.
        /// </remarks>
        public HRESULT TryOutputWide(DEBUG_OUTPUT mask, string format)
        {
            InitDelegate(ref outputWide, Vtbl4->OutputWide);

            /*HRESULT OutputWide(
            [In] DEBUG_OUTPUT Mask,
            [In, MarshalAs(UnmanagedType.LPWStr)] string Format);*/
            return outputWide(Raw, mask, format);
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
            TryOutputVaListWide(mask, format, va_list_Args).ThrowDbgEngNotOk();
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
            InitDelegate(ref outputVaListWide, Vtbl4->OutputVaListWide);

            /*HRESULT OutputVaListWide(
            [In] DEBUG_OUTPUT Mask,
            [In, MarshalAs(UnmanagedType.LPWStr)] string Format,
            [In] IntPtr va_list_Args);*/
            return outputVaListWide(Raw, mask, format, va_list_Args);
        }

        #endregion
        #region ControlledOutputWide

        /// <summary>
        /// The ControlledOutputWide method formats a string and sends the result to output callbacks that were registered with some of the engine's clients.
        /// </summary>
        /// <remarks>
        /// When generating very large output strings, it is possible to reach the limits of the debugger engine or of the
        /// operating system. For example, some versions of the debugger engine have a 16K character limit for a single output.
        /// If you find that very large output is getting truncated, you might need to split your output into multiple requests.
        /// </remarks>
        public void ControlledOutputWide(DEBUG_OUTCTL outputControl, DEBUG_OUTPUT mask, string format)
        {
            TryControlledOutputWide(outputControl, mask, format).ThrowDbgEngNotOk();
        }

        /// <summary>
        /// The ControlledOutputWide method formats a string and sends the result to output callbacks that were registered with some of the engine's clients.
        /// </summary>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// When generating very large output strings, it is possible to reach the limits of the debugger engine or of the
        /// operating system. For example, some versions of the debugger engine have a 16K character limit for a single output.
        /// If you find that very large output is getting truncated, you might need to split your output into multiple requests.
        /// </remarks>
        public HRESULT TryControlledOutputWide(DEBUG_OUTCTL outputControl, DEBUG_OUTPUT mask, string format)
        {
            InitDelegate(ref controlledOutputWide, Vtbl4->ControlledOutputWide);

            /*HRESULT ControlledOutputWide(
            [In] DEBUG_OUTCTL OutputControl,
            [In] DEBUG_OUTPUT Mask,
            [In, MarshalAs(UnmanagedType.LPWStr)] string Format);*/
            return controlledOutputWide(Raw, outputControl, mask, format);
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
            TryControlledOutputVaListWide(outputControl, mask, format, va_list_Args).ThrowDbgEngNotOk();
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
            InitDelegate(ref controlledOutputVaListWide, Vtbl4->ControlledOutputVaListWide);

            /*HRESULT ControlledOutputVaListWide(
            [In] DEBUG_OUTCTL OutputControl,
            [In] DEBUG_OUTPUT Mask,
            [In, MarshalAs(UnmanagedType.LPWStr)] string Format,
            [In] IntPtr va_list_Args);*/
            return controlledOutputVaListWide(Raw, outputControl, mask, format, va_list_Args);
        }

        #endregion
        #region OutputPromptWide

        /// <summary>
        /// The OutputPromptWide method formats and sends a user prompt to the output callback objects.
        /// </summary>
        /// <remarks>
        /// OutputPrompt and OutputPromptWide can be used to prompt the user for input. The standard prompt will be sent to
        /// the output callbacks before the formatted text described by Format. The contents of the standard prompt is returned
        /// by the method <see cref="PromptText"/>. The prompt text is sent to the output callbacks with the
        /// DEBUG_OUTPUT_PROMPT output mask set. For more information about prompting the user, see Using Input and Output.
        /// </remarks>
        public void OutputPromptWide(DEBUG_OUTCTL outputControl, string format)
        {
            TryOutputPromptWide(outputControl, format).ThrowDbgEngNotOk();
        }

        /// <summary>
        /// The OutputPromptWide method formats and sends a user prompt to the output callback objects.
        /// </summary>
        /// <returns>This method can also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// OutputPrompt and OutputPromptWide can be used to prompt the user for input. The standard prompt will be sent to
        /// the output callbacks before the formatted text described by Format. The contents of the standard prompt is returned
        /// by the method <see cref="PromptText"/>. The prompt text is sent to the output callbacks with the
        /// DEBUG_OUTPUT_PROMPT output mask set. For more information about prompting the user, see Using Input and Output.
        /// </remarks>
        public HRESULT TryOutputPromptWide(DEBUG_OUTCTL outputControl, string format)
        {
            InitDelegate(ref outputPromptWide, Vtbl4->OutputPromptWide);

            /*HRESULT OutputPromptWide(
            [In] DEBUG_OUTCTL OutputControl,
            [In, MarshalAs(UnmanagedType.LPWStr)] string Format);*/
            return outputPromptWide(Raw, outputControl, format);
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
            TryOutputPromptVaListWide(outputControl, format, va_list_Args).ThrowDbgEngNotOk();
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
            InitDelegate(ref outputPromptVaListWide, Vtbl4->OutputPromptVaListWide);

            /*HRESULT OutputPromptVaListWide(
            [In] DEBUG_OUTCTL OutputControl,
            [In, MarshalAs(UnmanagedType.LPWStr)] string Format,
            [In] IntPtr va_list_Args);*/
            return outputPromptVaListWide(Raw, outputControl, format, va_list_Args);
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
        public ulong AssembleWide(ulong offset, string instr)
        {
            ulong endOffset;
            TryAssembleWide(offset, instr, out endOffset).ThrowDbgEngNotOk();

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
        public HRESULT TryAssembleWide(ulong offset, string instr, out ulong endOffset)
        {
            InitDelegate(ref assembleWide, Vtbl4->AssembleWide);

            /*HRESULT AssembleWide(
            [In] ulong Offset,
            [In, MarshalAs(UnmanagedType.LPWStr)] string Instr,
            [Out] out ulong EndOffset);*/
            return assembleWide(Raw, offset, instr, out endOffset);
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
        public DisassembleWideResult DisassembleWide(ulong offset, DEBUG_DISASM flags)
        {
            DisassembleWideResult result;
            TryDisassembleWide(offset, flags, out result).ThrowDbgEngNotOk();

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
        public HRESULT TryDisassembleWide(ulong offset, DEBUG_DISASM flags, out DisassembleWideResult result)
        {
            InitDelegate(ref disassembleWide, Vtbl4->DisassembleWide);
            /*HRESULT DisassembleWide(
            [In] ulong Offset,
            [In] DEBUG_DISASM Flags,
            [Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder Buffer,
            [In] int BufferSize,
            [Out] out uint DisassemblySize,
            [Out] out ulong EndOffset);*/
            StringBuilder buffer;
            int bufferSize = 0;
            uint disassemblySize;
            ulong endOffset;
            HRESULT hr = disassembleWide(Raw, offset, flags, null, bufferSize, out disassemblySize, out endOffset);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER && hr != HRESULT.S_OK)
                goto fail;

            bufferSize = (int) disassemblySize;
            buffer = new StringBuilder(bufferSize);
            hr = disassembleWide(Raw, offset, flags, buffer, bufferSize, out disassemblySize, out endOffset);

            if (hr == HRESULT.S_OK)
            {
                result = new DisassembleWideResult(buffer.ToString(), endOffset);

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
            TryGetProcessorTypeNamesWide(type, out result).ThrowDbgEngNotOk();

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
            InitDelegate(ref getProcessorTypeNamesWide, Vtbl4->GetProcessorTypeNamesWide);
            /*HRESULT GetProcessorTypeNamesWide(
            [In] IMAGE_FILE_MACHINE Type,
            [Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder FullNameBuffer,
            [In] int FullNameBufferSize,
            [Out] out uint FullNameSize,
            [Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder AbbrevNameBuffer,
            [In] int AbbrevNameBufferSize,
            [Out] out uint AbbrevNameSize);*/
            StringBuilder fullNameBuffer;
            int fullNameBufferSize = 0;
            uint fullNameSize;
            StringBuilder abbrevNameBuffer;
            int abbrevNameBufferSize = 0;
            uint abbrevNameSize;
            HRESULT hr = getProcessorTypeNamesWide(Raw, type, null, fullNameBufferSize, out fullNameSize, null, abbrevNameBufferSize, out abbrevNameSize);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER && hr != HRESULT.S_OK)
                goto fail;

            fullNameBufferSize = (int) fullNameSize;
            fullNameBuffer = new StringBuilder(fullNameBufferSize);
            abbrevNameBufferSize = (int) abbrevNameSize;
            abbrevNameBuffer = new StringBuilder(abbrevNameBufferSize);
            hr = getProcessorTypeNamesWide(Raw, type, fullNameBuffer, fullNameBufferSize, out fullNameSize, abbrevNameBuffer, abbrevNameBufferSize, out abbrevNameSize);

            if (hr == HRESULT.S_OK)
            {
                result = new GetProcessorTypeNamesWideResult(fullNameBuffer.ToString(), abbrevNameBuffer.ToString());

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
        public string GetTextMacroWide(uint slot)
        {
            string bufferResult;
            TryGetTextMacroWide(slot, out bufferResult).ThrowDbgEngNotOk();

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
        public HRESULT TryGetTextMacroWide(uint slot, out string bufferResult)
        {
            InitDelegate(ref getTextMacroWide, Vtbl4->GetTextMacroWide);
            /*HRESULT GetTextMacroWide(
            [In] uint Slot,
            [Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder Buffer,
            [In] int BufferSize,
            [Out] out uint MacroSize);*/
            StringBuilder buffer;
            int bufferSize = 0;
            uint macroSize;
            HRESULT hr = getTextMacroWide(Raw, slot, null, bufferSize, out macroSize);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER && hr != HRESULT.S_OK)
                goto fail;

            bufferSize = (int) macroSize;
            buffer = new StringBuilder(bufferSize);
            hr = getTextMacroWide(Raw, slot, buffer, bufferSize, out macroSize);

            if (hr == HRESULT.S_OK)
            {
                bufferResult = buffer.ToString();

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
        public void SetTextMacroWide(uint slot, string macro)
        {
            TrySetTextMacroWide(slot, macro).ThrowDbgEngNotOk();
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
        public HRESULT TrySetTextMacroWide(uint slot, string macro)
        {
            InitDelegate(ref setTextMacroWide, Vtbl4->SetTextMacroWide);

            /*HRESULT SetTextMacroWide(
            [In] uint Slot,
            [In, MarshalAs(UnmanagedType.LPWStr)] string Macro);*/
            return setTextMacroWide(Raw, slot, macro);
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
            TryEvaluateWide(expression, desiredType, out result).ThrowDbgEngNotOk();

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
            InitDelegate(ref evaluateWide, Vtbl4->EvaluateWide);
            /*HRESULT EvaluateWide(
            [In, MarshalAs(UnmanagedType.LPWStr)] string Expression,
            [In] DEBUG_VALUE_TYPE DesiredType,
            [Out] out DEBUG_VALUE Value,
            [Out] out uint RemainderIndex);*/
            DEBUG_VALUE value;
            uint remainderIndex;
            HRESULT hr = evaluateWide(Raw, expression, desiredType, out value, out remainderIndex);

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
            TryExecuteWide(outputControl, command, flags).ThrowDbgEngNotOk();
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
            InitDelegate(ref executeWide, Vtbl4->ExecuteWide);

            /*HRESULT ExecuteWide(
            [In] DEBUG_OUTCTL OutputControl,
            [In, MarshalAs(UnmanagedType.LPWStr)] string Command,
            [In] DEBUG_EXECUTE Flags);*/
            return executeWide(Raw, outputControl, command, flags);
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
            TryExecuteCommandFileWide(outputControl, commandFile, flags).ThrowDbgEngNotOk();
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
            InitDelegate(ref executeCommandFileWide, Vtbl4->ExecuteCommandFileWide);

            /*HRESULT ExecuteCommandFileWide(
            [In] DEBUG_OUTCTL OutputControl,
            [In, MarshalAs(UnmanagedType.LPWStr)] string CommandFile,
            [In] DEBUG_EXECUTE Flags);*/
            return executeCommandFileWide(Raw, outputControl, commandFile, flags);
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
        public DebugBreakpoint GetBreakpointByIndex2(uint index)
        {
            DebugBreakpoint bpResult;
            TryGetBreakpointByIndex2(index, out bpResult).ThrowDbgEngNotOk();

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
        public HRESULT TryGetBreakpointByIndex2(uint index, out DebugBreakpoint bpResult)
        {
            InitDelegate(ref getBreakpointByIndex2, Vtbl4->GetBreakpointByIndex2);
            /*HRESULT GetBreakpointByIndex2(
            [In] uint Index,
            [Out, ComAliasName("IDebugBreakpoint2")] out IntPtr bp);*/
            IntPtr bp;
            HRESULT hr = getBreakpointByIndex2(Raw, index, out bp);

            if (hr == HRESULT.S_OK)
                bpResult = new DebugBreakpoint(bp);
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
        public DebugBreakpoint GetBreakpointById2(uint id)
        {
            DebugBreakpoint bpResult;
            TryGetBreakpointById2(id, out bpResult).ThrowDbgEngNotOk();

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
        public HRESULT TryGetBreakpointById2(uint id, out DebugBreakpoint bpResult)
        {
            InitDelegate(ref getBreakpointById2, Vtbl4->GetBreakpointById2);
            /*HRESULT GetBreakpointById2(
            [In] uint Id,
            [Out, ComAliasName("IDebugBreakpoint2")] out IntPtr bp);*/
            IntPtr bp;
            HRESULT hr = getBreakpointById2(Raw, id, out bp);

            if (hr == HRESULT.S_OK)
                bpResult = new DebugBreakpoint(bp);
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
        /// The client is saved as the adder of the new breakpoint. See <see cref="DebugBreakpoint.GetAdder"/>.
        /// </remarks>
        public DebugBreakpoint AddBreakpoint2(DEBUG_BREAKPOINT_TYPE type, uint desiredId)
        {
            DebugBreakpoint bpResult;
            TryAddBreakpoint2(type, desiredId, out bpResult).ThrowDbgEngNotOk();

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
        /// The client is saved as the adder of the new breakpoint. See <see cref="DebugBreakpoint.GetAdder"/>.
        /// </remarks>
        public HRESULT TryAddBreakpoint2(DEBUG_BREAKPOINT_TYPE type, uint desiredId, out DebugBreakpoint bpResult)
        {
            InitDelegate(ref addBreakpoint2, Vtbl4->AddBreakpoint2);
            /*HRESULT AddBreakpoint2(
            [In] DEBUG_BREAKPOINT_TYPE Type,
            [In] uint DesiredId,
            [Out, ComAliasName("IDebugBreakpoint2")] out IntPtr Bp);*/
            IntPtr bp;
            HRESULT hr = addBreakpoint2(Raw, type, desiredId, out bp);

            if (hr == HRESULT.S_OK)
                bpResult = new DebugBreakpoint(bp);
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
        public void RemoveBreakpoint2(IntPtr bp)
        {
            TryRemoveBreakpoint2(bp).ThrowDbgEngNotOk();
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
        public HRESULT TryRemoveBreakpoint2(IntPtr bp)
        {
            InitDelegate(ref removeBreakpoint2, Vtbl4->RemoveBreakpoint2);

            /*HRESULT RemoveBreakpoint2(
            [In, ComAliasName("IDebugBreakpoint2")] IntPtr Bp);*/
            return removeBreakpoint2(Raw, bp);
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
        public ulong AddExtensionWide(string path, uint flags)
        {
            ulong handle;
            TryAddExtensionWide(path, flags, out handle).ThrowDbgEngNotOk();

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
        public HRESULT TryAddExtensionWide(string path, uint flags, out ulong handle)
        {
            InitDelegate(ref addExtensionWide, Vtbl4->AddExtensionWide);

            /*HRESULT AddExtensionWide(
            [In, MarshalAs(UnmanagedType.LPWStr)] string Path,
            [In] uint Flags,
            [Out] out ulong Handle);*/
            return addExtensionWide(Raw, path, flags, out handle);
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
        public ulong GetExtensionByPathWide(string path)
        {
            ulong handle;
            TryGetExtensionByPathWide(path, out handle).ThrowDbgEngNotOk();

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
        public HRESULT TryGetExtensionByPathWide(string path, out ulong handle)
        {
            InitDelegate(ref getExtensionByPathWide, Vtbl4->GetExtensionByPathWide);

            /*HRESULT GetExtensionByPathWide(
            [In, MarshalAs(UnmanagedType.LPWStr)] string Path,
            [Out] out ulong Handle);*/
            return getExtensionByPathWide(Raw, path, out handle);
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
        public void CallExtensionWide(ulong handle, string function, string arguments)
        {
            TryCallExtensionWide(handle, function, arguments).ThrowDbgEngNotOk();
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
        public HRESULT TryCallExtensionWide(ulong handle, string function, string arguments)
        {
            InitDelegate(ref callExtensionWide, Vtbl4->CallExtensionWide);

            /*HRESULT CallExtensionWide(
            [In] ulong Handle,
            [In, MarshalAs(UnmanagedType.LPWStr)] string Function,
            [In, MarshalAs(UnmanagedType.LPWStr)] string Arguments);*/
            return callExtensionWide(Raw, handle, function, arguments);
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
        public IntPtr GetExtensionFunctionWide(ulong handle, string funcName)
        {
            IntPtr function;
            TryGetExtensionFunctionWide(handle, funcName, out function).ThrowDbgEngNotOk();

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
        public HRESULT TryGetExtensionFunctionWide(ulong handle, string funcName, out IntPtr function)
        {
            InitDelegate(ref getExtensionFunctionWide, Vtbl4->GetExtensionFunctionWide);

            /*HRESULT GetExtensionFunctionWide(
            [In] ulong Handle,
            [In, MarshalAs(UnmanagedType.LPWStr)] string FuncName,
            [Out] out IntPtr Function);*/
            return getExtensionFunctionWide(Raw, handle, funcName, out function);
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
        public string GetEventFilterTextWide(uint index)
        {
            string bufferResult;
            TryGetEventFilterTextWide(index, out bufferResult).ThrowDbgEngNotOk();

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
        public HRESULT TryGetEventFilterTextWide(uint index, out string bufferResult)
        {
            InitDelegate(ref getEventFilterTextWide, Vtbl4->GetEventFilterTextWide);
            /*HRESULT GetEventFilterTextWide(
            [In] uint Index,
            [Out, MarshalAs(UnmanagedType.LPWStr)]
            StringBuilder Buffer,
            [In] int BufferSize,
            [Out] out uint TextSize);*/
            StringBuilder buffer;
            int bufferSize = 0;
            uint textSize;
            HRESULT hr = getEventFilterTextWide(Raw, index, null, bufferSize, out textSize);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER && hr != HRESULT.S_OK)
                goto fail;

            bufferSize = (int) textSize;
            buffer = new StringBuilder(bufferSize);
            hr = getEventFilterTextWide(Raw, index, buffer, bufferSize, out textSize);

            if (hr == HRESULT.S_OK)
            {
                bufferResult = buffer.ToString();

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
        public string GetEventFilterCommandWide(uint index)
        {
            string bufferResult;
            TryGetEventFilterCommandWide(index, out bufferResult).ThrowDbgEngNotOk();

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
        public HRESULT TryGetEventFilterCommandWide(uint index, out string bufferResult)
        {
            InitDelegate(ref getEventFilterCommandWide, Vtbl4->GetEventFilterCommandWide);
            /*HRESULT GetEventFilterCommandWide(
            [In] uint Index,
            [Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder Buffer,
            [In] int BufferSize,
            [Out] out uint CommandSize);*/
            StringBuilder buffer;
            int bufferSize = 0;
            uint commandSize;
            HRESULT hr = getEventFilterCommandWide(Raw, index, null, bufferSize, out commandSize);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER && hr != HRESULT.S_OK)
                goto fail;

            bufferSize = (int) commandSize;
            buffer = new StringBuilder(bufferSize);
            hr = getEventFilterCommandWide(Raw, index, buffer, bufferSize, out commandSize);

            if (hr == HRESULT.S_OK)
            {
                bufferResult = buffer.ToString();

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
        public void SetEventFilterCommandWide(uint index, string command)
        {
            TrySetEventFilterCommandWide(index, command).ThrowDbgEngNotOk();
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
        public HRESULT TrySetEventFilterCommandWide(uint index, string command)
        {
            InitDelegate(ref setEventFilterCommandWide, Vtbl4->SetEventFilterCommandWide);

            /*HRESULT SetEventFilterCommandWide(
            [In] uint Index,
            [In, MarshalAs(UnmanagedType.LPWStr)] string Command);*/
            return setEventFilterCommandWide(Raw, index, command);
        }

        #endregion
        #region GetSpecificEventFilterArgumentWide

        public string GetSpecificEventFilterArgumentWide(uint index)
        {
            string bufferResult;
            TryGetSpecificEventFilterArgumentWide(index, out bufferResult).ThrowDbgEngNotOk();

            return bufferResult;
        }

        public HRESULT TryGetSpecificEventFilterArgumentWide(uint index, out string bufferResult)
        {
            InitDelegate(ref getSpecificEventFilterArgumentWide, Vtbl4->GetSpecificEventFilterArgumentWide);
            /*HRESULT GetSpecificEventFilterArgumentWide(
            [In] uint Index,
            [Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder Buffer,
            [In] int BufferSize,
            [Out] out uint ArgumentSize);*/
            StringBuilder buffer;
            int bufferSize = 0;
            uint argumentSize;
            HRESULT hr = getSpecificEventFilterArgumentWide(Raw, index, null, bufferSize, out argumentSize);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER && hr != HRESULT.S_OK)
                goto fail;

            bufferSize = (int) argumentSize;
            buffer = new StringBuilder(bufferSize);
            hr = getSpecificEventFilterArgumentWide(Raw, index, buffer, bufferSize, out argumentSize);

            if (hr == HRESULT.S_OK)
            {
                bufferResult = buffer.ToString();

                return hr;
            }

            fail:
            bufferResult = default(string);

            return hr;
        }

        #endregion
        #region SetSpecificEventFilterArgumentWide

        public void SetSpecificEventFilterArgumentWide(uint index, string argument)
        {
            TrySetSpecificEventFilterArgumentWide(index, argument).ThrowDbgEngNotOk();
        }

        public HRESULT TrySetSpecificEventFilterArgumentWide(uint index, string argument)
        {
            InitDelegate(ref setSpecificEventFilterArgumentWide, Vtbl4->SetSpecificEventFilterArgumentWide);

            /*HRESULT SetSpecificEventFilterArgumentWide(
            [In] uint Index,
            [In, MarshalAs(UnmanagedType.LPWStr)] string Argument);*/
            return setSpecificEventFilterArgumentWide(Raw, index, argument);
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
        public string GetExceptionFilterSecondCommandWide(uint index)
        {
            string bufferResult;
            TryGetExceptionFilterSecondCommandWide(index, out bufferResult).ThrowDbgEngNotOk();

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
        public HRESULT TryGetExceptionFilterSecondCommandWide(uint index, out string bufferResult)
        {
            InitDelegate(ref getExceptionFilterSecondCommandWide, Vtbl4->GetExceptionFilterSecondCommandWide);
            /*HRESULT GetExceptionFilterSecondCommandWide(
            [In] uint Index,
            [Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder Buffer,
            [In] int BufferSize,
            [Out] out uint CommandSize);*/
            StringBuilder buffer;
            int bufferSize = 0;
            uint commandSize;
            HRESULT hr = getExceptionFilterSecondCommandWide(Raw, index, null, bufferSize, out commandSize);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER && hr != HRESULT.S_OK)
                goto fail;

            bufferSize = (int) commandSize;
            buffer = new StringBuilder(bufferSize);
            hr = getExceptionFilterSecondCommandWide(Raw, index, buffer, bufferSize, out commandSize);

            if (hr == HRESULT.S_OK)
            {
                bufferResult = buffer.ToString();

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
        public void SetExceptionFilterSecondCommandWide(uint index, string command)
        {
            TrySetExceptionFilterSecondCommandWide(index, command).ThrowDbgEngNotOk();
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
        public HRESULT TrySetExceptionFilterSecondCommandWide(uint index, string command)
        {
            InitDelegate(ref setExceptionFilterSecondCommandWide, Vtbl4->SetExceptionFilterSecondCommandWide);

            /*HRESULT SetExceptionFilterSecondCommandWide(
            [In] uint Index,
            [In, MarshalAs(UnmanagedType.LPWStr)] string Command);*/
            return setExceptionFilterSecondCommandWide(Raw, index, command);
        }

        #endregion
        #region GetLastEventInformationWide

        /// <summary>
        /// The GetLastEventInformationWide method returns information about the last event that occurred in a target.
        /// </summary>
        /// <param name="extraInformation">[out, optional] Receives extra information about the event. The contents of this extra information depends on the type of the event as indicated by the returned Type parameter.<para/>
        /// For example, if Type is breakpoint, ExtraInformation contains a DEBUG_LAST_EVENT_INFO_BREAKPOINT; if Type is Exception, ExtraInformation contains a DEBUG_LAST_EVENT_INFO_EXCEPTION.<para/>
        /// Refer to DEBUG_EVENT_XXX for the complete list of event types and the dbgeng.h header file for the structure definitions for each event type.<para/>
        /// If ExtraInformation is NULL, this information is not returned.</param>
        /// <param name="descriptionSize">[in] Specifies the size, in characters, of the buffer that Description specifies. This size includes the space for the '\0' terminating character.</param>
        /// <returns>The values that were emitted from the COM method.</returns>
        /// <remarks>
        /// For thread and process creation events, the thread ID and process ID returned to ThreadId and ProcessId are for
        /// the newly created thread or process. For more information about the last event, see the topic Event Information.
        /// </remarks>
        public GetLastEventInformationWideResult GetLastEventInformationWide(IntPtr extraInformation, int descriptionSize)
        {
            GetLastEventInformationWideResult result;
            TryGetLastEventInformationWide(extraInformation, descriptionSize, out result).ThrowDbgEngNotOk();

            return result;
        }

        /// <summary>
        /// The GetLastEventInformationWide method returns information about the last event that occurred in a target.
        /// </summary>
        /// <param name="extraInformation">[out, optional] Receives extra information about the event. The contents of this extra information depends on the type of the event as indicated by the returned Type parameter.<para/>
        /// For example, if Type is breakpoint, ExtraInformation contains a DEBUG_LAST_EVENT_INFO_BREAKPOINT; if Type is Exception, ExtraInformation contains a DEBUG_LAST_EVENT_INFO_EXCEPTION.<para/>
        /// Refer to DEBUG_EVENT_XXX for the complete list of event types and the dbgeng.h header file for the structure definitions for each event type.<para/>
        /// If ExtraInformation is NULL, this information is not returned.</param>
        /// <param name="descriptionSize">[in] Specifies the size, in characters, of the buffer that Description specifies. This size includes the space for the '\0' terminating character.</param>
        /// <param name="result">The values that were emitted from the COM method.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// For thread and process creation events, the thread ID and process ID returned to ThreadId and ProcessId are for
        /// the newly created thread or process. For more information about the last event, see the topic Event Information.
        /// </remarks>
        public HRESULT TryGetLastEventInformationWide(IntPtr extraInformation, int descriptionSize, out GetLastEventInformationWideResult result)
        {
            InitDelegate(ref getLastEventInformationWide, Vtbl4->GetLastEventInformationWide);
            /*HRESULT GetLastEventInformationWide(
            [Out] out DEBUG_EVENT_TYPE Type,
            [Out] out uint ProcessId,
            [Out] out uint ThreadId,
            [In] IntPtr ExtraInformation,
            [In] int ExtraInformationSize,
            [Out] out uint ExtraInformationUsed,
            [Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder Description,
            [In] int DescriptionSize,
            [Out] out uint DescriptionUsed);*/
            DEBUG_EVENT_TYPE type;
            uint processId;
            uint threadId;
            int extraInformationSize = 0;
            uint extraInformationUsed;
            StringBuilder description;
            uint descriptionUsed;
            HRESULT hr = getLastEventInformationWide(Raw, out type, out processId, out threadId, extraInformation, extraInformationSize, out extraInformationUsed, null, descriptionSize, out descriptionUsed);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER && hr != HRESULT.S_OK)
                goto fail;

            extraInformationSize = (int) extraInformationUsed;
            description = new StringBuilder(extraInformationSize);
            hr = getLastEventInformationWide(Raw, out type, out processId, out threadId, extraInformation, extraInformationSize, out extraInformationUsed, description, descriptionSize, out descriptionUsed);

            if (hr == HRESULT.S_OK)
            {
                result = new GetLastEventInformationWideResult(type, processId, threadId, description.ToString(), descriptionUsed);

                return hr;
            }

            fail:
            result = default(GetLastEventInformationWideResult);

            return hr;
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
        public GetTextReplacementWideResult GetTextReplacementWide(string srcText, uint index)
        {
            GetTextReplacementWideResult result;
            TryGetTextReplacementWide(srcText, index, out result).ThrowDbgEngNotOk();

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
        public HRESULT TryGetTextReplacementWide(string srcText, uint index, out GetTextReplacementWideResult result)
        {
            InitDelegate(ref getTextReplacementWide, Vtbl4->GetTextReplacementWide);
            /*HRESULT GetTextReplacementWide(
            [In, MarshalAs(UnmanagedType.LPWStr)] string SrcText,
            [In] uint Index,
            [Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder SrcBuffer,
            [In] int SrcBufferSize,
            [Out] out uint SrcSize,
            [Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder DstBuffer,
            [In] int DstBufferSize,
            [Out] out uint DstSize);*/
            StringBuilder srcBuffer;
            int srcBufferSize = 0;
            uint srcSize;
            StringBuilder dstBuffer;
            int dstBufferSize = 0;
            uint dstSize;
            HRESULT hr = getTextReplacementWide(Raw, srcText, index, null, srcBufferSize, out srcSize, null, dstBufferSize, out dstSize);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER && hr != HRESULT.S_OK)
                goto fail;

            srcBufferSize = (int) srcSize;
            srcBuffer = new StringBuilder(srcBufferSize);
            dstBufferSize = (int) dstSize;
            dstBuffer = new StringBuilder(dstBufferSize);
            hr = getTextReplacementWide(Raw, srcText, index, srcBuffer, srcBufferSize, out srcSize, dstBuffer, dstBufferSize, out dstSize);

            if (hr == HRESULT.S_OK)
            {
                result = new GetTextReplacementWideResult(srcBuffer.ToString(), dstBuffer.ToString());

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
            TrySetTextReplacementWide(srcText, dstText).ThrowDbgEngNotOk();
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
            InitDelegate(ref setTextReplacementWide, Vtbl4->SetTextReplacementWide);

            /*HRESULT SetTextReplacementWide(
            [In, MarshalAs(UnmanagedType.LPWStr)] string SrcText,
            [In, MarshalAs(UnmanagedType.LPWStr)] string DstText);*/
            return setTextReplacementWide(Raw, srcText, dstText);
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
            TrySetExpressionSyntaxByNameWide(abbrevName).ThrowDbgEngNotOk();
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
            InitDelegate(ref setExpressionSyntaxByNameWide, Vtbl4->SetExpressionSyntaxByNameWide);

            /*HRESULT SetExpressionSyntaxByNameWide(
            [In, MarshalAs(UnmanagedType.LPWStr)] string AbbrevName);*/
            return setExpressionSyntaxByNameWide(Raw, abbrevName);
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
        public GetExpressionSyntaxNamesWideResult GetExpressionSyntaxNamesWide(uint index)
        {
            GetExpressionSyntaxNamesWideResult result;
            TryGetExpressionSyntaxNamesWide(index, out result).ThrowDbgEngNotOk();

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
        public HRESULT TryGetExpressionSyntaxNamesWide(uint index, out GetExpressionSyntaxNamesWideResult result)
        {
            InitDelegate(ref getExpressionSyntaxNamesWide, Vtbl4->GetExpressionSyntaxNamesWide);
            /*HRESULT GetExpressionSyntaxNamesWide(
            [In] uint Index,
            [Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder FullNameBuffer,
            [In] int FullNameBufferSize,
            [Out] out uint FullNameSize,
            [Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder AbbrevNameBuffer,
            [In] int AbbrevNameBufferSize,
            [Out] out uint AbbrevNameSize);*/
            StringBuilder fullNameBuffer;
            int fullNameBufferSize = 0;
            uint fullNameSize;
            StringBuilder abbrevNameBuffer;
            int abbrevNameBufferSize = 0;
            uint abbrevNameSize;
            HRESULT hr = getExpressionSyntaxNamesWide(Raw, index, null, fullNameBufferSize, out fullNameSize, null, abbrevNameBufferSize, out abbrevNameSize);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER && hr != HRESULT.S_OK)
                goto fail;

            fullNameBufferSize = (int) fullNameSize;
            fullNameBuffer = new StringBuilder(fullNameBufferSize);
            abbrevNameBufferSize = (int) abbrevNameSize;
            abbrevNameBuffer = new StringBuilder(abbrevNameBufferSize);
            hr = getExpressionSyntaxNamesWide(Raw, index, fullNameBuffer, fullNameBufferSize, out fullNameSize, abbrevNameBuffer, abbrevNameBufferSize, out abbrevNameSize);

            if (hr == HRESULT.S_OK)
            {
                result = new GetExpressionSyntaxNamesWideResult(fullNameBuffer.ToString(), abbrevNameBuffer.ToString());

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
        public string GetEventIndexDescriptionWide(uint index, DEBUG_EINDEX which)
        {
            string bufferResult;
            TryGetEventIndexDescriptionWide(index, which, out bufferResult).ThrowDbgEngNotOk();

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
        public HRESULT TryGetEventIndexDescriptionWide(uint index, DEBUG_EINDEX which, out string bufferResult)
        {
            InitDelegate(ref getEventIndexDescriptionWide, Vtbl4->GetEventIndexDescriptionWide);
            /*HRESULT GetEventIndexDescriptionWide(
            [In] uint Index,
            [In] DEBUG_EINDEX Which,
            [Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder Buffer,
            [In] int BufferSize,
            [Out] out uint DescSize);*/
            StringBuilder buffer;
            int bufferSize = 0;
            uint descSize;
            HRESULT hr = getEventIndexDescriptionWide(Raw, index, which, null, bufferSize, out descSize);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER && hr != HRESULT.S_OK)
                goto fail;

            bufferSize = (int) descSize;
            buffer = new StringBuilder(bufferSize);
            hr = getEventIndexDescriptionWide(Raw, index, which, buffer, bufferSize, out descSize);

            if (hr == HRESULT.S_OK)
            {
                bufferResult = buffer.ToString();

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
            TryOpenLogFile2(file, out flags).ThrowDbgEngNotOk();

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
            InitDelegate(ref openLogFile2, Vtbl4->OpenLogFile2);

            /*HRESULT OpenLogFile2(
            [In, MarshalAs(UnmanagedType.LPStr)] string File,
            [Out] out DEBUG_LOG Flags);*/
            return openLogFile2(Raw, file, out flags);
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
            TryOpenLogFile2Wide(file, out flags).ThrowDbgEngNotOk();

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
            InitDelegate(ref openLogFile2Wide, Vtbl4->OpenLogFile2Wide);

            /*HRESULT OpenLogFile2Wide(
            [In, MarshalAs(UnmanagedType.LPWStr)] string File,
            [Out] out DEBUG_LOG Flags);*/
            return openLogFile2Wide(Raw, file, out flags);
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
            TryGetSystemVersionString(which, out bufferResult).ThrowDbgEngNotOk();

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
            InitDelegate(ref getSystemVersionString, Vtbl4->GetSystemVersionString);
            /*HRESULT GetSystemVersionString(
            [In] DEBUG_SYSVERSTR Which,
            [Out, MarshalAs(UnmanagedType.LPStr)] StringBuilder Buffer,
            [In] int BufferSize,
            [Out] out uint StringSize);*/
            StringBuilder buffer;
            int bufferSize = 0;
            uint stringSize;
            HRESULT hr = getSystemVersionString(Raw, which, null, bufferSize, out stringSize);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER && hr != HRESULT.S_OK)
                goto fail;

            bufferSize = (int) stringSize;
            buffer = new StringBuilder(bufferSize);
            hr = getSystemVersionString(Raw, which, buffer, bufferSize, out stringSize);

            if (hr == HRESULT.S_OK)
            {
                bufferResult = buffer.ToString();

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
            TryGetSystemVersionStringWide(which, out bufferResult).ThrowDbgEngNotOk();

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
            InitDelegate(ref getSystemVersionStringWide, Vtbl4->GetSystemVersionStringWide);
            /*HRESULT GetSystemVersionStringWide(
            [In] DEBUG_SYSVERSTR Which,
            [Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder Buffer,
            [In] int BufferSize,
            [Out] out uint StringSize);*/
            StringBuilder buffer;
            int bufferSize = 0;
            uint stringSize;
            HRESULT hr = getSystemVersionStringWide(Raw, which, null, bufferSize, out stringSize);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER && hr != HRESULT.S_OK)
                goto fail;

            bufferSize = (int) stringSize;
            buffer = new StringBuilder(bufferSize);
            hr = getSystemVersionStringWide(Raw, which, buffer, bufferSize, out stringSize);

            if (hr == HRESULT.S_OK)
            {
                bufferResult = buffer.ToString();

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
        public GetContextStackTraceResult GetContextStackTrace(IntPtr startContext, uint startContextSize, int frameSize, IntPtr frameContexts, uint frameContextsSize, uint frameContextsEntrySize)
        {
            GetContextStackTraceResult result;
            TryGetContextStackTrace(startContext, startContextSize, frameSize, frameContexts, frameContextsSize, frameContextsEntrySize, out result).ThrowDbgEngNotOk();

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
        public HRESULT TryGetContextStackTrace(IntPtr startContext, uint startContextSize, int frameSize, IntPtr frameContexts, uint frameContextsSize, uint frameContextsEntrySize, out GetContextStackTraceResult result)
        {
            InitDelegate(ref getContextStackTrace, Vtbl4->GetContextStackTrace);
            /*HRESULT GetContextStackTrace(
            [In] IntPtr StartContext,
            [In] uint StartContextSize,
            [Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 3)] DEBUG_STACK_FRAME[] Frames,
            [In] int FrameSize,
            [In] IntPtr FrameContexts,
            [In] uint FrameContextsSize,
            [In] uint FrameContextsEntrySize,
            [Out] out uint FramesFilled);*/
            DEBUG_STACK_FRAME[] frames = new DEBUG_STACK_FRAME[frameSize];
            uint framesFilled;
            HRESULT hr = getContextStackTrace(Raw, startContext, startContextSize, frames, frameSize, frameContexts, frameContextsSize, frameContextsEntrySize, out framesFilled);

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
        public void OutputContextStackTrace(DEBUG_OUTCTL outputControl, DEBUG_STACK_FRAME[] frames, int framesSize, IntPtr frameContexts, uint frameContextsSize, uint frameContextsEntrySize, DEBUG_STACK flags)
        {
            TryOutputContextStackTrace(outputControl, frames, framesSize, frameContexts, frameContextsSize, frameContextsEntrySize, flags).ThrowDbgEngNotOk();
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
        public HRESULT TryOutputContextStackTrace(DEBUG_OUTCTL outputControl, DEBUG_STACK_FRAME[] frames, int framesSize, IntPtr frameContexts, uint frameContextsSize, uint frameContextsEntrySize, DEBUG_STACK flags)
        {
            InitDelegate(ref outputContextStackTrace, Vtbl4->OutputContextStackTrace);

            /*HRESULT OutputContextStackTrace(
            [In] DEBUG_OUTCTL OutputControl,
            [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] DEBUG_STACK_FRAME[] Frames,
            [In] int FramesSize,
            [In] IntPtr FrameContexts,
            [In] uint FrameContextsSize,
            [In] uint FrameContextsEntrySize,
            [In] DEBUG_STACK Flags);*/
            return outputContextStackTrace(Raw, outputControl, frames, framesSize, frameContexts, frameContextsSize, frameContextsEntrySize, flags);
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
        public GetStoredEventInformationResult GetStoredEventInformation(IntPtr context, uint contextSize, IntPtr extraInformation, uint extraInformationSize)
        {
            GetStoredEventInformationResult result;
            TryGetStoredEventInformation(context, contextSize, extraInformation, extraInformationSize, out result).ThrowDbgEngNotOk();

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
        public HRESULT TryGetStoredEventInformation(IntPtr context, uint contextSize, IntPtr extraInformation, uint extraInformationSize, out GetStoredEventInformationResult result)
        {
            InitDelegate(ref getStoredEventInformation, Vtbl4->GetStoredEventInformation);
            /*HRESULT GetStoredEventInformation(
            [Out] out DEBUG_EVENT_TYPE Type,
            [Out] out uint ProcessId,
            [Out] out uint ThreadId,
            [In] IntPtr Context,
            [In] uint ContextSize,
            [Out] out uint ContextUsed,
            [In] IntPtr ExtraInformation,
            [In] uint ExtraInformationSize,
            [Out] out uint ExtraInformationUsed);*/
            DEBUG_EVENT_TYPE type;
            uint processId;
            uint threadId;
            uint contextUsed;
            uint extraInformationUsed;
            HRESULT hr = getStoredEventInformation(Raw, out type, out processId, out threadId, context, contextSize, out contextUsed, extraInformation, extraInformationSize, out extraInformationUsed);

            if (hr == HRESULT.S_OK)
                result = new GetStoredEventInformationResult(type, processId, threadId, contextUsed, extraInformationUsed);
            else
                result = default(GetStoredEventInformationResult);

            return hr;
        }

        #endregion
        #region GetManagedStatus

        /// <summary>
        /// Provides feedback on the engine'suse of the runtime debugging APIs provided by the common language runtime (CLR).
        /// </summary>
        /// <param name="whichString">[in] A value that controls which string to use.</param>
        /// <returns>The values that were emitted from the COM method.</returns>
        public GetManagedStatusResult GetManagedStatus(DEBUG_MANSTR whichString)
        {
            GetManagedStatusResult result;
            TryGetManagedStatus(whichString, out result).ThrowDbgEngNotOk();

            return result;
        }

        /// <summary>
        /// Provides feedback on the engine'suse of the runtime debugging APIs provided by the common language runtime (CLR).
        /// </summary>
        /// <param name="whichString">[in] A value that controls which string to use.</param>
        /// <param name="result">The values that were emitted from the COM method.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        public HRESULT TryGetManagedStatus(DEBUG_MANSTR whichString, out GetManagedStatusResult result)
        {
            InitDelegate(ref getManagedStatus, Vtbl4->GetManagedStatus);
            /*HRESULT GetManagedStatus(
            [Out] out DEBUG_MANAGED Flags,
            [In] DEBUG_MANSTR WhichString,
            [Out, MarshalAs(UnmanagedType.LPStr)] StringBuilder String,
            [In] int StringSize,
            [Out] out uint StringNeeded);*/
            DEBUG_MANAGED flags;
            StringBuilder @string;
            int stringSize = 0;
            uint stringNeeded;
            HRESULT hr = getManagedStatus(Raw, out flags, whichString, null, stringSize, out stringNeeded);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER && hr != HRESULT.S_OK)
                goto fail;

            stringSize = (int) stringNeeded;
            @string = new StringBuilder(stringSize);
            hr = getManagedStatus(Raw, out flags, whichString, @string, stringSize, out stringNeeded);

            if (hr == HRESULT.S_OK)
            {
                result = new GetManagedStatusResult(flags, @string.ToString());

                return hr;
            }

            fail:
            result = default(GetManagedStatusResult);

            return hr;
        }

        #endregion
        #region GetManagedStatusWide

        /// <summary>
        /// Provides feedback as a Unicode character string on the engine'suse of the runtime debugging APIs provided by the common language runtime (CLR).
        /// </summary>
        /// <param name="whichString">[in] A value that controls which string to use.</param>
        /// <returns>The values that were emitted from the COM method.</returns>
        public GetManagedStatusWideResult GetManagedStatusWide(DEBUG_MANSTR whichString)
        {
            GetManagedStatusWideResult result;
            TryGetManagedStatusWide(whichString, out result).ThrowDbgEngNotOk();

            return result;
        }

        /// <summary>
        /// Provides feedback as a Unicode character string on the engine'suse of the runtime debugging APIs provided by the common language runtime (CLR).
        /// </summary>
        /// <param name="whichString">[in] A value that controls which string to use.</param>
        /// <param name="result">The values that were emitted from the COM method.</param>
        /// <returns>This method may also return error values. See Return Values for more details. Managed debugging support relies on debugging functionality provided by the CLR.</returns>
        public HRESULT TryGetManagedStatusWide(DEBUG_MANSTR whichString, out GetManagedStatusWideResult result)
        {
            InitDelegate(ref getManagedStatusWide, Vtbl4->GetManagedStatusWide);
            /*HRESULT GetManagedStatusWide(
            [Out] out DEBUG_MANAGED Flags,
            [In] DEBUG_MANSTR WhichString,
            [Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder String,
            [In] int StringSize,
            [Out] out uint StringNeeded);*/
            DEBUG_MANAGED flags;
            StringBuilder @string;
            int stringSize = 0;
            uint stringNeeded;
            HRESULT hr = getManagedStatusWide(Raw, out flags, whichString, null, stringSize, out stringNeeded);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER && hr != HRESULT.S_OK)
                goto fail;

            stringSize = (int) stringNeeded;
            @string = new StringBuilder(stringSize);
            hr = getManagedStatusWide(Raw, out flags, whichString, @string, stringSize, out stringNeeded);

            if (hr == HRESULT.S_OK)
            {
                result = new GetManagedStatusWideResult(flags, @string.ToString());

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
            TryResetManagedStatus(flags).ThrowDbgEngNotOk();
        }

        /// <summary>
        /// Clears and reinitializes the engine's managed code debugging support of the runtime debugging APIs provided by the common language runtime (CLR).
        /// </summary>
        /// <param name="flags">[in] Flags for the debugging API.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        public HRESULT TryResetManagedStatus(DEBUG_MANRESET flags)
        {
            InitDelegate(ref resetManagedStatus, Vtbl4->ResetManagedStatus);

            /*HRESULT ResetManagedStatus(
            [In] DEBUG_MANRESET Flags);*/
            return resetManagedStatus(Raw, flags);
        }

        #endregion
        #endregion
        #region IDebugControl5
        #region GetStackTraceEx

        /// <summary>
        /// The GetStackTraceEx method returns the frames at the top of the specified call stack. The GetStackTraceEx method provides inline frame support.<para/>
        /// For more information about working with inline functions, see Debugging Optimized Code and Inline Functions.
        /// </summary>
        /// <param name="frameOffset">[in] Specifies the location of the stack frame at the top of the stack. If FrameOffset is set to zero, the current frame pointer is used instead.</param>
        /// <param name="stackOffset">[in] Specifies the location of the current stack. If StackOffset is set to zero, the current stack pointer is used instead.</param>
        /// <param name="instructionOffset">[in] Specifies the location of the instruction of interest for the function that is represented by the stack frame at the top of the stack.<para/>
        /// If InstructionOffset is set to zero, the current instruction is used instead.</param>
        /// <returns>[out] Receives the stack frames. The number of elements this array holds is FrameSize.</returns>
        public DEBUG_STACK_FRAME_EX[] GetStackTraceEx(ulong frameOffset, ulong stackOffset, ulong instructionOffset)
        {
            DEBUG_STACK_FRAME_EX[] frames;
            TryGetStackTraceEx(frameOffset, stackOffset, instructionOffset, out frames).ThrowDbgEngNotOk();

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
        /// <returns>This method may also return other error values. See Return Values for more details.</returns>
        public HRESULT TryGetStackTraceEx(ulong frameOffset, ulong stackOffset, ulong instructionOffset, out DEBUG_STACK_FRAME_EX[] frames)
        {
            InitDelegate(ref getStackTraceEx, Vtbl5->GetStackTraceEx);
            /*HRESULT GetStackTraceEx(
            [In] ulong FrameOffset,
            [In] ulong StackOffset,
            [In] ulong InstructionOffset,
            [Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 4)] DEBUG_STACK_FRAME_EX[] Frames,
            [In] int FramesSize,
            [Out] out uint FramesFilled);*/
            frames = null;
            int framesSize = 0;
            uint framesFilled;
            HRESULT hr = getStackTraceEx(Raw, frameOffset, stackOffset, instructionOffset, null, framesSize, out framesFilled);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER && hr != HRESULT.S_OK)
                goto fail;

            framesSize = (int) framesFilled;
            frames = new DEBUG_STACK_FRAME_EX[framesSize];
            hr = getStackTraceEx(Raw, frameOffset, stackOffset, instructionOffset, frames, framesSize, out framesFilled);
            fail:
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
        public void OutputStackTraceEx(uint outputControl, DEBUG_STACK_FRAME_EX[] frames, int framesSize, DEBUG_STACK flags)
        {
            TryOutputStackTraceEx(outputControl, frames, framesSize, flags).ThrowDbgEngNotOk();
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
        public HRESULT TryOutputStackTraceEx(uint outputControl, DEBUG_STACK_FRAME_EX[] frames, int framesSize, DEBUG_STACK flags)
        {
            InitDelegate(ref outputStackTraceEx, Vtbl5->OutputStackTraceEx);

            /*HRESULT OutputStackTraceEx(
            [In] uint OutputControl,
            [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] DEBUG_STACK_FRAME_EX[] Frames,
            [In] int FramesSize,
            [In] DEBUG_STACK Flags);*/
            return outputStackTraceEx(Raw, outputControl, frames, framesSize, flags);
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
        public GetContextStackTraceExResult GetContextStackTraceEx(IntPtr startContext, uint startContextSize, int framesSize, IntPtr frameContexts, uint frameContextsSize, uint frameContextsEntrySize)
        {
            GetContextStackTraceExResult result;
            TryGetContextStackTraceEx(startContext, startContextSize, framesSize, frameContexts, frameContextsSize, frameContextsEntrySize, out result).ThrowDbgEngNotOk();

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
        public HRESULT TryGetContextStackTraceEx(IntPtr startContext, uint startContextSize, int framesSize, IntPtr frameContexts, uint frameContextsSize, uint frameContextsEntrySize, out GetContextStackTraceExResult result)
        {
            InitDelegate(ref getContextStackTraceEx, Vtbl5->GetContextStackTraceEx);
            /*HRESULT GetContextStackTraceEx(
            [In] IntPtr StartContext,
            [In] uint StartContextSize,
            [Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 3)] DEBUG_STACK_FRAME_EX[] Frames,
            [In] int FramesSize,
            [In] IntPtr FrameContexts,
            [In] uint FrameContextsSize,
            [In] uint FrameContextsEntrySize,
            [Out] out uint FramesFilled);*/
            DEBUG_STACK_FRAME_EX[] frames = new DEBUG_STACK_FRAME_EX[framesSize];
            uint framesFilled;
            HRESULT hr = getContextStackTraceEx(Raw, startContext, startContextSize, frames, framesSize, frameContexts, frameContextsSize, frameContextsEntrySize, out framesFilled);

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
        public void OutputContextStackTraceEx(uint outputControl, DEBUG_STACK_FRAME_EX[] frames, int framesSize, IntPtr frameContexts, uint frameContextsSize, uint frameContextsEntrySize, DEBUG_STACK flags)
        {
            TryOutputContextStackTraceEx(outputControl, frames, framesSize, frameContexts, frameContextsSize, frameContextsEntrySize, flags).ThrowDbgEngNotOk();
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
        public HRESULT TryOutputContextStackTraceEx(uint outputControl, DEBUG_STACK_FRAME_EX[] frames, int framesSize, IntPtr frameContexts, uint frameContextsSize, uint frameContextsEntrySize, DEBUG_STACK flags)
        {
            InitDelegate(ref outputContextStackTraceEx, Vtbl5->OutputContextStackTraceEx);

            /*HRESULT OutputContextStackTraceEx(
            [In] uint OutputControl,
            [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] DEBUG_STACK_FRAME_EX[] Frames,
            [In] int FramesSize,
            [In] IntPtr FrameContexts,
            [In] uint FrameContextsSize,
            [In] uint FrameContextsEntrySize,
            [In] DEBUG_STACK Flags);*/
            return outputContextStackTraceEx(Raw, outputControl, frames, framesSize, frameContexts, frameContextsSize, frameContextsEntrySize, flags);
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
            TryGetBreakpointByGuid(guid, out bpResult).ThrowDbgEngNotOk();

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
            InitDelegate(ref getBreakpointByGuid, Vtbl5->GetBreakpointByGuid);
            /*HRESULT GetBreakpointByGuid(
            [In, MarshalAs(UnmanagedType.LPStruct)] Guid Guid,
            [Out, ComAliasName("IDebugBreakpoint3")] out IntPtr Bp);*/
            IntPtr bp;
            HRESULT hr = getBreakpointByGuid(Raw, guid, out bp);

            if (hr == HRESULT.S_OK)
                bpResult = new DebugBreakpoint(bp);
            else
                bpResult = default(DebugBreakpoint);

            return hr;
        }

        #endregion
        #endregion
        #region IDebugControl6
        #region ExecutionStatusEx

        /// <summary>
        /// The GetExecutionStatusEx method returns information about the execution status of the debugger engine.
        /// </summary>
        public DEBUG_STATUS ExecutionStatusEx
        {
            get
            {
                DEBUG_STATUS status;
                TryGetExecutionStatusEx(out status).ThrowDbgEngNotOk();

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
            InitDelegate(ref getExecutionStatusEx, Vtbl6->GetExecutionStatusEx);

            /*HRESULT GetExecutionStatusEx([Out] out DEBUG_STATUS Status);*/
            return getExecutionStatusEx(Raw, out status);
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
                TryGetSynchronizationStatus(out result).ThrowDbgEngNotOk();

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
            InitDelegate(ref getSynchronizationStatus, Vtbl6->GetSynchronizationStatus);
            /*HRESULT GetSynchronizationStatus(
            [Out] out uint SendsAttempted,
            [Out] out uint SecondsSinceLastResponse);*/
            uint sendsAttempted;
            uint secondsSinceLastResponse;
            HRESULT hr = getSynchronizationStatus(Raw, out sendsAttempted, out secondsSinceLastResponse);

            if (hr == HRESULT.S_OK)
                result = new GetSynchronizationStatusResult(sendsAttempted, secondsSinceLastResponse);
            else
                result = default(GetSynchronizationStatusResult);

            return hr;
        }

        #endregion
        #endregion
        #region Cached Delegates
        #region IDebugControl

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private GetInterruptTimeoutDelegate getInterruptTimeout;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private SetInterruptTimeoutDelegate setInterruptTimeout;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private GetLogFileDelegate getLogFile;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private GetLogMaskDelegate getLogMask;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private SetLogMaskDelegate setLogMask;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private GetPromptTextDelegate getPromptText;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private GetNotifyEventHandleDelegate getNotifyEventHandle;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private SetNotifyEventHandleDelegate setNotifyEventHandle;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private GetDisassembleEffectiveOffsetDelegate getDisassembleEffectiveOffset;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private GetReturnOffsetDelegate getReturnOffset;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private GetDebuggeeTypeDelegate getDebuggeeType;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private GetActualProcessorTypeDelegate getActualProcessorType;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private GetExecutingProcessorTypeDelegate getExecutingProcessorType;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private GetNumberPossibleExecutingProcessorTypesDelegate getNumberPossibleExecutingProcessorTypes;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private GetNumberProcessorsDelegate getNumberProcessors;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private GetSystemVersionDelegate getSystemVersion;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private GetPageSizeDelegate getPageSize;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private IsPointer64BitDelegate isPointer64Bit;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private GetNumberSupportedProcessorTypesDelegate getNumberSupportedProcessorTypes;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private GetEffectiveProcessorTypeDelegate getEffectiveProcessorType;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private SetEffectiveProcessorTypeDelegate setEffectiveProcessorType;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private GetExecutionStatusDelegate getExecutionStatus;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private SetExecutionStatusDelegate setExecutionStatus;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private GetCodeLevelDelegate getCodeLevel;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private SetCodeLevelDelegate setCodeLevel;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private GetEngineOptionsDelegate getEngineOptions;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private SetEngineOptionsDelegate setEngineOptions;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private GetRadixDelegate getRadix;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private SetRadixDelegate setRadix;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private GetNumberBreakpointsDelegate getNumberBreakpoints;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private GetNumberEventFiltersDelegate getNumberEventFilters;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private GetInterruptDelegate getInterrupt;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private SetInterruptDelegate setInterrupt;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private OpenLogFileDelegate openLogFile;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private CloseLogFileDelegate closeLogFile;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private InputDelegate input;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private ReturnInputDelegate returnInput;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private OutputDelegate output;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private OutputVaListDelegate outputVaList;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private ControlledOutputDelegate controlledOutput;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private ControlledOutputVaListDelegate controlledOutputVaList;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private OutputPromptDelegate outputPrompt;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private OutputPromptVaListDelegate outputPromptVaList;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private OutputCurrentStateDelegate outputCurrentState;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private OutputVersionInformationDelegate outputVersionInformation;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private AssembleDelegate assemble;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private DisassembleDelegate disassemble;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private OutputDisassemblyDelegate outputDisassembly;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private OutputDisassemblyLinesDelegate outputDisassemblyLines;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private GetNearInstructionDelegate getNearInstruction;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private GetStackTraceDelegate getStackTrace;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private OutputStackTraceDelegate outputStackTrace;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private GetPossibleExecutingProcessorTypesDelegate getPossibleExecutingProcessorTypes;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private ReadBugCheckDataDelegate readBugCheckData;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private GetSupportedProcessorTypesDelegate getSupportedProcessorTypes;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private GetProcessorTypeNamesDelegate getProcessorTypeNames;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private AddEngineOptionsDelegate addEngineOptions;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private RemoveEngineOptionsDelegate removeEngineOptions;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private GetSystemErrorControlDelegate getSystemErrorControl;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private SetSystemErrorControlDelegate setSystemErrorControl;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private GetTextMacroDelegate getTextMacro;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private SetTextMacroDelegate setTextMacro;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private EvaluateDelegate evaluate;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private CoerceValueDelegate coerceValue;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private CoerceValuesDelegate coerceValues;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private ExecuteDelegate execute;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private ExecuteCommandFileDelegate executeCommandFile;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private GetBreakpointByIndexDelegate getBreakpointByIndex;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private GetBreakpointByIdDelegate getBreakpointById;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private GetBreakpointParametersDelegate getBreakpointParameters;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private AddBreakpointDelegate addBreakpoint;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private RemoveBreakpointDelegate removeBreakpoint;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private AddExtensionDelegate addExtension;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private RemoveExtensionDelegate removeExtension;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private GetExtensionByPathDelegate getExtensionByPath;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private CallExtensionDelegate callExtension;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private GetExtensionFunctionDelegate getExtensionFunction;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private GetWindbgExtensionApis32Delegate getWindbgExtensionApis32;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private GetWindbgExtensionApis64Delegate getWindbgExtensionApis64;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private GetEventFilterTextDelegate getEventFilterText;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private GetEventFilterCommandDelegate getEventFilterCommand;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private SetEventFilterCommandDelegate setEventFilterCommand;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private GetSpecificFilterParametersDelegate getSpecificFilterParameters;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private SetSpecificFilterParametersDelegate setSpecificFilterParameters;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private GetSpecificEventFilterArgumentDelegate getSpecificEventFilterArgument;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private SetSpecificEventFilterArgumentDelegate setSpecificEventFilterArgument;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private GetExceptionFilterParametersDelegate getExceptionFilterParameters;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private SetExceptionFilterParametersDelegate setExceptionFilterParameters;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private GetExceptionFilterSecondCommandDelegate getExceptionFilterSecondCommand;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private SetExceptionFilterSecondCommandDelegate setExceptionFilterSecondCommand;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private WaitForEventDelegate waitForEvent;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private GetLastEventInformationDelegate getLastEventInformation;

        #endregion
        #region IDebugControl2

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private GetCurrentTimeDateDelegate getCurrentTimeDate;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private GetCurrentSystemUpTimeDelegate getCurrentSystemUpTime;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private GetDumpFormatFlagsDelegate getDumpFormatFlags;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private GetNumberTextReplacementsDelegate getNumberTextReplacements;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private GetTextReplacementDelegate getTextReplacement;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private SetTextReplacementDelegate setTextReplacement;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private RemoveTextReplacementsDelegate removeTextReplacements;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private OutputTextReplacementsDelegate outputTextReplacements;

        #endregion
        #region IDebugControl3

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private GetAssemblyOptionsDelegate getAssemblyOptions;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private SetAssemblyOptionsDelegate setAssemblyOptions;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private GetExpressionSyntaxDelegate getExpressionSyntax;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private SetExpressionSyntaxDelegate setExpressionSyntax;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private GetNumberExpressionSyntaxesDelegate getNumberExpressionSyntaxes;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private GetNumberEventsDelegate getNumberEvents;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private GetCurrentEventIndexDelegate getCurrentEventIndex;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private AddAssemblyOptionsDelegate addAssemblyOptions;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private RemoveAssemblyOptionsDelegate removeAssemblyOptions;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private SetExpressionSyntaxByNameDelegate setExpressionSyntaxByName;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private GetExpressionSyntaxNamesDelegate getExpressionSyntaxNames;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private GetEventIndexDescriptionDelegate getEventIndexDescription;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private SetNextEventIndexDelegate setNextEventIndex;

        #endregion
        #region IDebugControl4

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private GetLogFileWideDelegate getLogFileWide;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private GetPromptTextWideDelegate getPromptTextWide;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private GetLogFile2Delegate getLogFile2;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private GetLogFile2WideDelegate getLogFile2Wide;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private GetSystemVersionValuesDelegate getSystemVersionValues;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private OpenLogFileWideDelegate openLogFileWide;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private InputWideDelegate inputWide;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private ReturnInputWideDelegate returnInputWide;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private OutputWideDelegate outputWide;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private OutputVaListWideDelegate outputVaListWide;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private ControlledOutputWideDelegate controlledOutputWide;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private ControlledOutputVaListWideDelegate controlledOutputVaListWide;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private OutputPromptWideDelegate outputPromptWide;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private OutputPromptVaListWideDelegate outputPromptVaListWide;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private AssembleWideDelegate assembleWide;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private DisassembleWideDelegate disassembleWide;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private GetProcessorTypeNamesWideDelegate getProcessorTypeNamesWide;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private GetTextMacroWideDelegate getTextMacroWide;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private SetTextMacroWideDelegate setTextMacroWide;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private EvaluateWideDelegate evaluateWide;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private ExecuteWideDelegate executeWide;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private ExecuteCommandFileWideDelegate executeCommandFileWide;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private GetBreakpointByIndex2Delegate getBreakpointByIndex2;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private GetBreakpointById2Delegate getBreakpointById2;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private AddBreakpoint2Delegate addBreakpoint2;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private RemoveBreakpoint2Delegate removeBreakpoint2;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private AddExtensionWideDelegate addExtensionWide;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private GetExtensionByPathWideDelegate getExtensionByPathWide;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private CallExtensionWideDelegate callExtensionWide;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private GetExtensionFunctionWideDelegate getExtensionFunctionWide;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private GetEventFilterTextWideDelegate getEventFilterTextWide;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private GetEventFilterCommandWideDelegate getEventFilterCommandWide;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private SetEventFilterCommandWideDelegate setEventFilterCommandWide;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private GetSpecificEventFilterArgumentWideDelegate getSpecificEventFilterArgumentWide;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private SetSpecificEventFilterArgumentWideDelegate setSpecificEventFilterArgumentWide;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private GetExceptionFilterSecondCommandWideDelegate getExceptionFilterSecondCommandWide;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private SetExceptionFilterSecondCommandWideDelegate setExceptionFilterSecondCommandWide;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private GetLastEventInformationWideDelegate getLastEventInformationWide;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private GetTextReplacementWideDelegate getTextReplacementWide;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private SetTextReplacementWideDelegate setTextReplacementWide;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private SetExpressionSyntaxByNameWideDelegate setExpressionSyntaxByNameWide;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private GetExpressionSyntaxNamesWideDelegate getExpressionSyntaxNamesWide;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private GetEventIndexDescriptionWideDelegate getEventIndexDescriptionWide;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private OpenLogFile2Delegate openLogFile2;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private OpenLogFile2WideDelegate openLogFile2Wide;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private GetSystemVersionStringDelegate getSystemVersionString;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private GetSystemVersionStringWideDelegate getSystemVersionStringWide;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private GetContextStackTraceDelegate getContextStackTrace;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private OutputContextStackTraceDelegate outputContextStackTrace;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private GetStoredEventInformationDelegate getStoredEventInformation;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private GetManagedStatusDelegate getManagedStatus;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private GetManagedStatusWideDelegate getManagedStatusWide;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private ResetManagedStatusDelegate resetManagedStatus;

        #endregion
        #region IDebugControl5

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private GetStackTraceExDelegate getStackTraceEx;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private OutputStackTraceExDelegate outputStackTraceEx;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private GetContextStackTraceExDelegate getContextStackTraceEx;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private OutputContextStackTraceExDelegate outputContextStackTraceEx;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private GetBreakpointByGuidDelegate getBreakpointByGuid;

        #endregion
        #region IDebugControl6

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private GetExecutionStatusExDelegate getExecutionStatusEx;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private GetSynchronizationStatusDelegate getSynchronizationStatus;

        #endregion
        #endregion
        #region Delegates
        #region IDebugControl

        private delegate HRESULT GetInterruptTimeoutDelegate(IntPtr self, [Out] out uint Seconds);
        private delegate HRESULT SetInterruptTimeoutDelegate(IntPtr self, [In] uint Seconds);
        private delegate HRESULT GetLogFileDelegate(IntPtr self, [Out, MarshalAs(UnmanagedType.LPStr)] StringBuilder Buffer, [In] int BufferSize, [Out] out uint FileSize, [Out, MarshalAs(UnmanagedType.Bool)] out bool Append);
        private delegate HRESULT GetLogMaskDelegate(IntPtr self, [Out] out DEBUG_OUTPUT Mask);
        private delegate HRESULT SetLogMaskDelegate(IntPtr self, [In] DEBUG_OUTPUT Mask);
        private delegate HRESULT GetPromptTextDelegate(IntPtr self, [Out, MarshalAs(UnmanagedType.LPStr)] StringBuilder Buffer, [In] int BufferSize, [Out] out uint TextSize);
        private delegate HRESULT GetNotifyEventHandleDelegate(IntPtr self, [Out] out ulong Handle);
        private delegate HRESULT SetNotifyEventHandleDelegate(IntPtr self, [In] ulong Handle);
        private delegate HRESULT GetDisassembleEffectiveOffsetDelegate(IntPtr self, [Out] out ulong Offset);
        private delegate HRESULT GetReturnOffsetDelegate(IntPtr self, [Out] out ulong Offset);
        private delegate HRESULT GetDebuggeeTypeDelegate(IntPtr self, [Out] out DEBUG_CLASS Class, [Out] out DEBUG_CLASS_QUALIFIER Qualifier);
        private delegate HRESULT GetActualProcessorTypeDelegate(IntPtr self, [Out] out IMAGE_FILE_MACHINE Type);
        private delegate HRESULT GetExecutingProcessorTypeDelegate(IntPtr self, [Out] out IMAGE_FILE_MACHINE Type);
        private delegate HRESULT GetNumberPossibleExecutingProcessorTypesDelegate(IntPtr self, [Out] out uint Number);
        private delegate HRESULT GetNumberProcessorsDelegate(IntPtr self, [Out] out uint Number);
        private delegate HRESULT GetSystemVersionDelegate(IntPtr self, [Out] out uint PlatformId, [Out] out uint Major, [Out] out uint Minor, [Out, MarshalAs(UnmanagedType.LPStr)] StringBuilder ServicePackString, [In] int ServicePackStringSize, [Out] out uint ServicePackStringUsed, [Out] out uint ServicePackNumber, [Out, MarshalAs(UnmanagedType.LPStr)] StringBuilder BuildString, [In] int BuildStringSize, [Out] out uint BuildStringUsed);
        private delegate HRESULT GetPageSizeDelegate(IntPtr self, [Out] out uint Size);
        private delegate HRESULT IsPointer64BitDelegate(IntPtr self);
        private delegate HRESULT GetNumberSupportedProcessorTypesDelegate(IntPtr self, [Out] out uint Number);
        private delegate HRESULT GetEffectiveProcessorTypeDelegate(IntPtr self, [Out] out IMAGE_FILE_MACHINE Type);
        private delegate HRESULT SetEffectiveProcessorTypeDelegate(IntPtr self, [In] IMAGE_FILE_MACHINE Type);
        private delegate HRESULT GetExecutionStatusDelegate(IntPtr self, [Out] out DEBUG_STATUS Status);
        private delegate HRESULT SetExecutionStatusDelegate(IntPtr self, [In] DEBUG_STATUS Status);
        private delegate HRESULT GetCodeLevelDelegate(IntPtr self, [Out] out DEBUG_LEVEL Level);
        private delegate HRESULT SetCodeLevelDelegate(IntPtr self, [In] DEBUG_LEVEL Level);
        private delegate HRESULT GetEngineOptionsDelegate(IntPtr self, [Out] out DEBUG_ENGOPT Options);
        private delegate HRESULT SetEngineOptionsDelegate(IntPtr self, [In] DEBUG_ENGOPT Options);
        private delegate HRESULT GetRadixDelegate(IntPtr self, [Out] out uint Radix);
        private delegate HRESULT SetRadixDelegate(IntPtr self, [In] uint Radix);
        private delegate HRESULT GetNumberBreakpointsDelegate(IntPtr self, [Out] out uint Number);
        private delegate HRESULT GetNumberEventFiltersDelegate(IntPtr self, [Out] out uint SpecificEvents, [Out] out uint SpecificExceptions, [Out] out uint ArbitraryExceptions);
        private delegate HRESULT GetInterruptDelegate(IntPtr self);
        private delegate HRESULT SetInterruptDelegate(IntPtr self, [In] DEBUG_INTERRUPT Flags);
        private delegate HRESULT OpenLogFileDelegate(IntPtr self, [In, MarshalAs(UnmanagedType.LPStr)] string File, [In, MarshalAs(UnmanagedType.Bool)] bool Append);
        private delegate HRESULT CloseLogFileDelegate(IntPtr self);
        private delegate HRESULT InputDelegate(IntPtr self, [Out, MarshalAs(UnmanagedType.LPStr)] StringBuilder Buffer, [In] int BufferSize, [Out] out uint InputSize);
        private delegate HRESULT ReturnInputDelegate(IntPtr self, [In, MarshalAs(UnmanagedType.LPStr)] string Buffer);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate HRESULT OutputDelegate(IntPtr self, [In] DEBUG_OUTPUT Mask, [In, MarshalAs(UnmanagedType.LPStr)] string Format);
        private delegate HRESULT OutputVaListDelegate(IntPtr self, [In] DEBUG_OUTPUT Mask, [In, MarshalAs(UnmanagedType.LPStr)] string Format, [In] IntPtr va_list_Args);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate HRESULT ControlledOutputDelegate(IntPtr self, [In] DEBUG_OUTCTL OutputControl, [In] DEBUG_OUTPUT Mask, [In, MarshalAs(UnmanagedType.LPStr)] string Format);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate HRESULT ControlledOutputVaListDelegate(IntPtr self, [In] DEBUG_OUTCTL OutputControl, [In] DEBUG_OUTPUT Mask, [In, MarshalAs(UnmanagedType.LPStr)] string Format, [In] IntPtr va_list_Args);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate HRESULT OutputPromptDelegate(IntPtr self, [In] DEBUG_OUTCTL OutputControl, [In, MarshalAs(UnmanagedType.LPStr)] string Format);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate HRESULT OutputPromptVaListDelegate(IntPtr self, [In] DEBUG_OUTCTL OutputControl, [In, MarshalAs(UnmanagedType.LPStr)] string Format, [In] IntPtr va_list_Args);
        private delegate HRESULT OutputCurrentStateDelegate(IntPtr self, [In] DEBUG_OUTCTL OutputControl, [In] DEBUG_CURRENT Flags);
        private delegate HRESULT OutputVersionInformationDelegate(IntPtr self, [In] DEBUG_OUTCTL OutputControl);
        private delegate HRESULT AssembleDelegate(IntPtr self, [In] ulong Offset, [In, MarshalAs(UnmanagedType.LPStr)] string Instr, [Out] out ulong EndOffset);
        private delegate HRESULT DisassembleDelegate(IntPtr self, [In] ulong Offset, [In] DEBUG_DISASM Flags, [Out, MarshalAs(UnmanagedType.LPStr)] StringBuilder Buffer, [In] int BufferSize, [Out] out uint DisassemblySize, [Out] out ulong EndOffset);
        private delegate HRESULT OutputDisassemblyDelegate(IntPtr self, [In] DEBUG_OUTCTL OutputControl, [In] ulong Offset, [In] DEBUG_DISASM Flags, [Out] out ulong EndOffset);
        private delegate HRESULT OutputDisassemblyLinesDelegate(IntPtr self, [In] DEBUG_OUTCTL OutputControl, [In] uint PreviousLines, [In] uint TotalLines, [In] ulong Offset, [In] DEBUG_DISASM Flags, [Out] out uint OffsetLine, [Out] out ulong StartOffset, [Out] out ulong EndOffset, [Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] ulong[] LineOffsets);
        private delegate HRESULT GetNearInstructionDelegate(IntPtr self, [In] ulong Offset, [In] int Delta, [Out] out ulong NearOffset);
        private delegate HRESULT GetStackTraceDelegate(IntPtr self, [In] ulong FrameOffset, [In] ulong StackOffset, [In] ulong InstructionOffset, [Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 4)] DEBUG_STACK_FRAME[] Frames, [In] int FrameSize, [Out] out uint FramesFilled);
        private delegate HRESULT OutputStackTraceDelegate(IntPtr self, [In] DEBUG_OUTCTL OutputControl, [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] DEBUG_STACK_FRAME[] Frames, [In] int FramesSize, [In] DEBUG_STACK Flags);
        private delegate HRESULT GetPossibleExecutingProcessorTypesDelegate(IntPtr self, [In] uint Start, [In] uint Count, [Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] IMAGE_FILE_MACHINE[] Types);
        private delegate HRESULT ReadBugCheckDataDelegate(IntPtr self, [Out] out uint Code, [Out] out ulong Arg1, [Out] out ulong Arg2, [Out] out ulong Arg3, [Out] out ulong Arg4);
        private delegate HRESULT GetSupportedProcessorTypesDelegate(IntPtr self, [In] uint Start, [In] uint Count, [Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] IMAGE_FILE_MACHINE[] Types);
        private delegate HRESULT GetProcessorTypeNamesDelegate(IntPtr self, [In] IMAGE_FILE_MACHINE Type, [Out, MarshalAs(UnmanagedType.LPStr)] StringBuilder FullNameBuffer, [In] int FullNameBufferSize, [Out] out uint FullNameSize, [Out, MarshalAs(UnmanagedType.LPStr)] StringBuilder AbbrevNameBuffer, [In] int AbbrevNameBufferSize, [Out] out uint AbbrevNameSize);
        private delegate HRESULT AddEngineOptionsDelegate(IntPtr self, [In] DEBUG_ENGOPT Options);
        private delegate HRESULT RemoveEngineOptionsDelegate(IntPtr self, [In] DEBUG_ENGOPT Options);
        private delegate HRESULT GetSystemErrorControlDelegate(IntPtr self, [Out] out ERROR_LEVEL OutputLevel, [Out] out ERROR_LEVEL BreakLevel);
        private delegate HRESULT SetSystemErrorControlDelegate(IntPtr self, [In] ERROR_LEVEL OutputLevel, [In] ERROR_LEVEL BreakLevel);
        private delegate HRESULT GetTextMacroDelegate(IntPtr self, [In] uint Slot, [Out, MarshalAs(UnmanagedType.LPStr)] StringBuilder Buffer, [In] int BufferSize, [Out] out uint MacroSize);
        private delegate HRESULT SetTextMacroDelegate(IntPtr self, [In] uint Slot, [In, MarshalAs(UnmanagedType.LPStr)] string Macro);
        private delegate HRESULT EvaluateDelegate(IntPtr self, [In, MarshalAs(UnmanagedType.LPStr)] string Expression, [In] DEBUG_VALUE_TYPE DesiredType, [Out] out DEBUG_VALUE Value, [Out] out uint RemainderIndex);
        private delegate HRESULT CoerceValueDelegate(IntPtr self, [In] DEBUG_VALUE In, [In] DEBUG_VALUE_TYPE OutType, [Out] out DEBUG_VALUE Out);
        private delegate HRESULT CoerceValuesDelegate(IntPtr self, [In] uint Count, [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] DEBUG_VALUE[] In, [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] DEBUG_VALUE_TYPE[] OutType, [Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] DEBUG_VALUE[] Out);
        private delegate HRESULT ExecuteDelegate(IntPtr self, [In] DEBUG_OUTCTL OutputControl, [In, MarshalAs(UnmanagedType.LPStr)] string Command, [In] DEBUG_EXECUTE Flags);
        private delegate HRESULT ExecuteCommandFileDelegate(IntPtr self, [In] DEBUG_OUTCTL OutputControl, [In, MarshalAs(UnmanagedType.LPStr)] string CommandFile, [In] DEBUG_EXECUTE Flags);
        private delegate HRESULT GetBreakpointByIndexDelegate(IntPtr self, [In] uint Index, [Out, ComAliasName("IDebugBreakpoint")] out IntPtr bp);
        private delegate HRESULT GetBreakpointByIdDelegate(IntPtr self, [In] uint Id, [Out, ComAliasName("IDebugBreakpoint")] out IntPtr bp);
        private delegate HRESULT GetBreakpointParametersDelegate(IntPtr self, [In] uint Count, [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] uint[] Ids, [In] uint Start, [Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] DEBUG_BREAKPOINT_PARAMETERS[] Params);
        private delegate HRESULT AddBreakpointDelegate(IntPtr self, [In] DEBUG_BREAKPOINT_TYPE Type, [In] uint DesiredId, [Out, ComAliasName("IDebugBreakpoint")] out IntPtr Bp);
        private delegate HRESULT RemoveBreakpointDelegate(IntPtr self, [In, ComAliasName("IDebugBreakpoint")] IntPtr Bp);
        private delegate HRESULT AddExtensionDelegate(IntPtr self, [In, MarshalAs(UnmanagedType.LPStr)] string Path, [In] uint Flags, [Out] out ulong Handle);
        private delegate HRESULT RemoveExtensionDelegate(IntPtr self, [In] ulong Handle);
        private delegate HRESULT GetExtensionByPathDelegate(IntPtr self, [In, MarshalAs(UnmanagedType.LPStr)] string Path, [Out] out ulong Handle);
        private delegate HRESULT CallExtensionDelegate(IntPtr self, [In] ulong Handle, [In, MarshalAs(UnmanagedType.LPStr)] string Function, [In, MarshalAs(UnmanagedType.LPStr)] string Arguments);
        private delegate HRESULT GetExtensionFunctionDelegate(IntPtr self, [In] ulong Handle, [In, MarshalAs(UnmanagedType.LPStr)] string FuncName, [Out] out IntPtr Function);
        private delegate HRESULT GetWindbgExtensionApis32Delegate(IntPtr self, [In, Out] ref WINDBG_EXTENSION_APIS Api);
        private delegate HRESULT GetWindbgExtensionApis64Delegate(IntPtr self, [In, Out] ref WINDBG_EXTENSION_APIS Api);
        private delegate HRESULT GetEventFilterTextDelegate(IntPtr self, [In] uint Index, [Out, MarshalAs(UnmanagedType.LPStr)] StringBuilder Buffer, [In] int BufferSize, [Out] out uint TextSize);
        private delegate HRESULT GetEventFilterCommandDelegate(IntPtr self, [In] uint Index, [Out, MarshalAs(UnmanagedType.LPStr)] StringBuilder Buffer, [In] int BufferSize, [Out] out uint CommandSize);
        private delegate HRESULT SetEventFilterCommandDelegate(IntPtr self, [In] uint Index, [In, MarshalAs(UnmanagedType.LPStr)] string Command);
        private delegate HRESULT GetSpecificFilterParametersDelegate(IntPtr self, [In] uint Start, [In] uint Count, [Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] DEBUG_SPECIFIC_FILTER_PARAMETERS[] Params);
        private delegate HRESULT SetSpecificFilterParametersDelegate(IntPtr self, [In] uint Start, [In] uint Count, [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] DEBUG_SPECIFIC_FILTER_PARAMETERS[] Params);
        private delegate HRESULT GetSpecificEventFilterArgumentDelegate(IntPtr self, [In] uint Index, [Out, MarshalAs(UnmanagedType.LPStr)] StringBuilder Buffer, [In] int BufferSize, [Out] out uint ArgumentSize);
        private delegate HRESULT SetSpecificEventFilterArgumentDelegate(IntPtr self, [In] uint Index, [In, MarshalAs(UnmanagedType.LPStr)] string Argument);
        private delegate HRESULT GetExceptionFilterParametersDelegate(IntPtr self, [In] uint Count, [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] uint[] Codes, [In] uint Start, [Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] DEBUG_EXCEPTION_FILTER_PARAMETERS[] Params);
        private delegate HRESULT SetExceptionFilterParametersDelegate(IntPtr self, [In] uint Count, [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] DEBUG_EXCEPTION_FILTER_PARAMETERS[] Params);
        private delegate HRESULT GetExceptionFilterSecondCommandDelegate(IntPtr self, [In] uint Index, [Out, MarshalAs(UnmanagedType.LPStr)] StringBuilder Buffer, [In] int BufferSize, [Out] out uint CommandSize);
        private delegate HRESULT SetExceptionFilterSecondCommandDelegate(IntPtr self, [In] uint Index, [In, MarshalAs(UnmanagedType.LPStr)] string Command);
        private delegate HRESULT WaitForEventDelegate(IntPtr self, [In] DEBUG_WAIT Flags, [In] int Timeout);
        private delegate HRESULT GetLastEventInformationDelegate(IntPtr self, [Out] out DEBUG_EVENT_TYPE Type, [Out] out uint ProcessId, [Out] out uint ThreadId, [In] IntPtr ExtraInformation, [In] uint ExtraInformationSize, [Out] out uint ExtraInformationUsed, [Out, MarshalAs(UnmanagedType.LPStr)] StringBuilder Description, [In] int DescriptionSize, [Out] out uint DescriptionUsed);

        #endregion
        #region IDebugControl2

        private delegate HRESULT GetCurrentTimeDateDelegate(IntPtr self, [Out] out uint TimeDate);
        private delegate HRESULT GetCurrentSystemUpTimeDelegate(IntPtr self, [Out] out uint UpTime);
        private delegate HRESULT GetDumpFormatFlagsDelegate(IntPtr self, [Out] out DEBUG_FORMAT FormatFlags);
        private delegate HRESULT GetNumberTextReplacementsDelegate(IntPtr self, [Out] out uint NumRepl);
        private delegate HRESULT GetTextReplacementDelegate(IntPtr self, [In, MarshalAs(UnmanagedType.LPStr)] string SrcText, [In] uint Index, [Out, MarshalAs(UnmanagedType.LPStr)] StringBuilder SrcBuffer, [In] int SrcBufferSize, [Out] out uint SrcSize, [Out, MarshalAs(UnmanagedType.LPStr)] StringBuilder DstBuffer, [In] int DstBufferSize, [Out] out uint DstSize);
        private delegate HRESULT SetTextReplacementDelegate(IntPtr self, [In, MarshalAs(UnmanagedType.LPStr)] string SrcText, [In, MarshalAs(UnmanagedType.LPStr)] string DstText);
        private delegate HRESULT RemoveTextReplacementsDelegate(IntPtr self);
        private delegate HRESULT OutputTextReplacementsDelegate(IntPtr self, [In] DEBUG_OUTCTL OutputControl, [In] DEBUG_OUT_TEXT_REPL Flags);

        #endregion
        #region IDebugControl3

        private delegate HRESULT GetAssemblyOptionsDelegate(IntPtr self, [Out] out DEBUG_ASMOPT Options);
        private delegate HRESULT SetAssemblyOptionsDelegate(IntPtr self, [In] DEBUG_ASMOPT Options);
        private delegate HRESULT GetExpressionSyntaxDelegate(IntPtr self, [Out] out DEBUG_EXPR Flags);
        private delegate HRESULT SetExpressionSyntaxDelegate(IntPtr self, [In] DEBUG_EXPR Flags);
        private delegate HRESULT GetNumberExpressionSyntaxesDelegate(IntPtr self, [Out] out uint Number);
        private delegate HRESULT GetNumberEventsDelegate(IntPtr self, [Out] out uint Events);
        private delegate HRESULT GetCurrentEventIndexDelegate(IntPtr self, [Out] out uint Index);
        private delegate HRESULT AddAssemblyOptionsDelegate(IntPtr self, [In] DEBUG_ASMOPT Options);
        private delegate HRESULT RemoveAssemblyOptionsDelegate(IntPtr self, [In] DEBUG_ASMOPT Options);
        private delegate HRESULT SetExpressionSyntaxByNameDelegate(IntPtr self, [In, MarshalAs(UnmanagedType.LPStr)] string AbbrevName);
        private delegate HRESULT GetExpressionSyntaxNamesDelegate(IntPtr self, [In] uint Index, [Out, MarshalAs(UnmanagedType.LPStr)] StringBuilder FullNameBuffer, [In] int FullNameBufferSize, [Out] out uint FullNameSize, [Out, MarshalAs(UnmanagedType.LPStr)] StringBuilder AbbrevNameBuffer, [In] int AbbrevNameBufferSize, [Out] out uint AbbrevNameSize);
        private delegate HRESULT GetEventIndexDescriptionDelegate(IntPtr self, [In] uint Index, [In] DEBUG_EINDEX Which, [Out, MarshalAs(UnmanagedType.LPStr)] StringBuilder Buffer, [In] int BufferSize, [Out] out uint DescSize);
        private delegate HRESULT SetNextEventIndexDelegate(IntPtr self, [In] DEBUG_EINDEX Relation, [In] uint Value, [Out] out uint NextIndex);

        #endregion
        #region IDebugControl4

        private delegate HRESULT GetLogFileWideDelegate(IntPtr self, [Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder Buffer, [In] int BufferSize, [Out] out uint FileSize, [Out, MarshalAs(UnmanagedType.Bool)] out bool Append);
        private delegate HRESULT GetPromptTextWideDelegate(IntPtr self, [Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder Buffer, [In] int BufferSize, [Out] out uint TextSize);
        private delegate HRESULT GetLogFile2Delegate(IntPtr self, [Out, MarshalAs(UnmanagedType.LPStr)] StringBuilder Buffer, [In] int BufferSize, [Out] out uint FileSize, [Out] out DEBUG_LOG Flags);
        private delegate HRESULT GetLogFile2WideDelegate(IntPtr self, [Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder Buffer, [In] int BufferSize, [Out] out uint FileSize, [Out] out DEBUG_LOG Flags);
        private delegate HRESULT GetSystemVersionValuesDelegate(IntPtr self, [Out] out uint PlatformId, [Out] out uint Win32Major, [Out] out uint Win32Minor, [Out] out uint KdMajor, [Out] out uint KdMinor);
        private delegate HRESULT OpenLogFileWideDelegate(IntPtr self, [In, MarshalAs(UnmanagedType.LPWStr)] string File, [In, MarshalAs(UnmanagedType.Bool)] bool Append);
        private delegate HRESULT InputWideDelegate(IntPtr self, [Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder Buffer, [In] int BufferSize, [Out] out uint InputSize);
        private delegate HRESULT ReturnInputWideDelegate(IntPtr self, [In, MarshalAs(UnmanagedType.LPWStr)] string Buffer);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate HRESULT OutputWideDelegate(IntPtr self, [In] DEBUG_OUTPUT Mask, [In, MarshalAs(UnmanagedType.LPWStr)] string Format);
        private delegate HRESULT OutputVaListWideDelegate(IntPtr self, [In] DEBUG_OUTPUT Mask, [In, MarshalAs(UnmanagedType.LPWStr)] string Format, [In] IntPtr va_list_Args);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate HRESULT ControlledOutputWideDelegate(IntPtr self, [In] DEBUG_OUTCTL OutputControl, [In] DEBUG_OUTPUT Mask, [In, MarshalAs(UnmanagedType.LPWStr)] string Format);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate HRESULT ControlledOutputVaListWideDelegate(IntPtr self, [In] DEBUG_OUTCTL OutputControl, [In] DEBUG_OUTPUT Mask, [In, MarshalAs(UnmanagedType.LPWStr)] string Format, [In] IntPtr va_list_Args);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate HRESULT OutputPromptWideDelegate(IntPtr self, [In] DEBUG_OUTCTL OutputControl, [In, MarshalAs(UnmanagedType.LPWStr)] string Format);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate HRESULT OutputPromptVaListWideDelegate(IntPtr self, [In] DEBUG_OUTCTL OutputControl, [In, MarshalAs(UnmanagedType.LPWStr)] string Format, [In] IntPtr va_list_Args);
        private delegate HRESULT AssembleWideDelegate(IntPtr self, [In] ulong Offset, [In, MarshalAs(UnmanagedType.LPWStr)] string Instr, [Out] out ulong EndOffset);
        private delegate HRESULT DisassembleWideDelegate(IntPtr self, [In] ulong Offset, [In] DEBUG_DISASM Flags, [Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder Buffer, [In] int BufferSize, [Out] out uint DisassemblySize, [Out] out ulong EndOffset);
        private delegate HRESULT GetProcessorTypeNamesWideDelegate(IntPtr self, [In] IMAGE_FILE_MACHINE Type, [Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder FullNameBuffer, [In] int FullNameBufferSize, [Out] out uint FullNameSize, [Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder AbbrevNameBuffer, [In] int AbbrevNameBufferSize, [Out] out uint AbbrevNameSize);
        private delegate HRESULT GetTextMacroWideDelegate(IntPtr self, [In] uint Slot, [Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder Buffer, [In] int BufferSize, [Out] out uint MacroSize);
        private delegate HRESULT SetTextMacroWideDelegate(IntPtr self, [In] uint Slot, [In, MarshalAs(UnmanagedType.LPWStr)] string Macro);
        private delegate HRESULT EvaluateWideDelegate(IntPtr self, [In, MarshalAs(UnmanagedType.LPWStr)] string Expression, [In] DEBUG_VALUE_TYPE DesiredType, [Out] out DEBUG_VALUE Value, [Out] out uint RemainderIndex);
        private delegate HRESULT ExecuteWideDelegate(IntPtr self, [In] DEBUG_OUTCTL OutputControl, [In, MarshalAs(UnmanagedType.LPWStr)] string Command, [In] DEBUG_EXECUTE Flags);
        private delegate HRESULT ExecuteCommandFileWideDelegate(IntPtr self, [In] DEBUG_OUTCTL OutputControl, [In, MarshalAs(UnmanagedType.LPWStr)] string CommandFile, [In] DEBUG_EXECUTE Flags);
        private delegate HRESULT GetBreakpointByIndex2Delegate(IntPtr self, [In] uint Index, [Out, ComAliasName("IDebugBreakpoint2")] out IntPtr bp);
        private delegate HRESULT GetBreakpointById2Delegate(IntPtr self, [In] uint Id, [Out, ComAliasName("IDebugBreakpoint2")] out IntPtr bp);
        private delegate HRESULT AddBreakpoint2Delegate(IntPtr self, [In] DEBUG_BREAKPOINT_TYPE Type, [In] uint DesiredId, [Out, ComAliasName("IDebugBreakpoint2")] out IntPtr Bp);
        private delegate HRESULT RemoveBreakpoint2Delegate(IntPtr self, [In, ComAliasName("IDebugBreakpoint2")] IntPtr Bp);
        private delegate HRESULT AddExtensionWideDelegate(IntPtr self, [In, MarshalAs(UnmanagedType.LPWStr)] string Path, [In] uint Flags, [Out] out ulong Handle);
        private delegate HRESULT GetExtensionByPathWideDelegate(IntPtr self, [In, MarshalAs(UnmanagedType.LPWStr)] string Path, [Out] out ulong Handle);
        private delegate HRESULT CallExtensionWideDelegate(IntPtr self, [In] ulong Handle, [In, MarshalAs(UnmanagedType.LPWStr)] string Function, [In, MarshalAs(UnmanagedType.LPWStr)] string Arguments);
        private delegate HRESULT GetExtensionFunctionWideDelegate(IntPtr self, [In] ulong Handle, [In, MarshalAs(UnmanagedType.LPWStr)] string FuncName, [Out] out IntPtr Function);
        private delegate HRESULT GetEventFilterTextWideDelegate(IntPtr self, [In] uint Index, [Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder Buffer, [In] int BufferSize, [Out] out uint TextSize);
        private delegate HRESULT GetEventFilterCommandWideDelegate(IntPtr self, [In] uint Index, [Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder Buffer, [In] int BufferSize, [Out] out uint CommandSize);
        private delegate HRESULT SetEventFilterCommandWideDelegate(IntPtr self, [In] uint Index, [In, MarshalAs(UnmanagedType.LPWStr)] string Command);
        private delegate HRESULT GetSpecificEventFilterArgumentWideDelegate(IntPtr self, [In] uint Index, [Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder Buffer, [In] int BufferSize, [Out] out uint ArgumentSize);
        private delegate HRESULT SetSpecificEventFilterArgumentWideDelegate(IntPtr self, [In] uint Index, [In, MarshalAs(UnmanagedType.LPWStr)] string Argument);
        private delegate HRESULT GetExceptionFilterSecondCommandWideDelegate(IntPtr self, [In] uint Index, [Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder Buffer, [In] int BufferSize, [Out] out uint CommandSize);
        private delegate HRESULT SetExceptionFilterSecondCommandWideDelegate(IntPtr self, [In] uint Index, [In, MarshalAs(UnmanagedType.LPWStr)] string Command);
        private delegate HRESULT GetLastEventInformationWideDelegate(IntPtr self, [Out] out DEBUG_EVENT_TYPE Type, [Out] out uint ProcessId, [Out] out uint ThreadId, [In] IntPtr ExtraInformation, [In] int ExtraInformationSize, [Out] out uint ExtraInformationUsed, [Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder Description, [In] int DescriptionSize, [Out] out uint DescriptionUsed);
        private delegate HRESULT GetTextReplacementWideDelegate(IntPtr self, [In, MarshalAs(UnmanagedType.LPWStr)] string SrcText, [In] uint Index, [Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder SrcBuffer, [In] int SrcBufferSize, [Out] out uint SrcSize, [Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder DstBuffer, [In] int DstBufferSize, [Out] out uint DstSize);
        private delegate HRESULT SetTextReplacementWideDelegate(IntPtr self, [In, MarshalAs(UnmanagedType.LPWStr)] string SrcText, [In, MarshalAs(UnmanagedType.LPWStr)] string DstText);
        private delegate HRESULT SetExpressionSyntaxByNameWideDelegate(IntPtr self, [In, MarshalAs(UnmanagedType.LPWStr)] string AbbrevName);
        private delegate HRESULT GetExpressionSyntaxNamesWideDelegate(IntPtr self, [In] uint Index, [Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder FullNameBuffer, [In] int FullNameBufferSize, [Out] out uint FullNameSize, [Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder AbbrevNameBuffer, [In] int AbbrevNameBufferSize, [Out] out uint AbbrevNameSize);
        private delegate HRESULT GetEventIndexDescriptionWideDelegate(IntPtr self, [In] uint Index, [In] DEBUG_EINDEX Which, [Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder Buffer, [In] int BufferSize, [Out] out uint DescSize);
        private delegate HRESULT OpenLogFile2Delegate(IntPtr self, [In, MarshalAs(UnmanagedType.LPStr)] string File, [Out] out DEBUG_LOG Flags);
        private delegate HRESULT OpenLogFile2WideDelegate(IntPtr self, [In, MarshalAs(UnmanagedType.LPWStr)] string File, [Out] out DEBUG_LOG Flags);
        private delegate HRESULT GetSystemVersionStringDelegate(IntPtr self, [In] DEBUG_SYSVERSTR Which, [Out, MarshalAs(UnmanagedType.LPStr)] StringBuilder Buffer, [In] int BufferSize, [Out] out uint StringSize);
        private delegate HRESULT GetSystemVersionStringWideDelegate(IntPtr self, [In] DEBUG_SYSVERSTR Which, [Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder Buffer, [In] int BufferSize, [Out] out uint StringSize);
        private delegate HRESULT GetContextStackTraceDelegate(IntPtr self, [In] IntPtr StartContext, [In] uint StartContextSize, [Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 3)] DEBUG_STACK_FRAME[] Frames, [In] int FrameSize, [In] IntPtr FrameContexts, [In] uint FrameContextsSize, [In] uint FrameContextsEntrySize, [Out] out uint FramesFilled);
        private delegate HRESULT OutputContextStackTraceDelegate(IntPtr self, [In] DEBUG_OUTCTL OutputControl, [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] DEBUG_STACK_FRAME[] Frames, [In] int FramesSize, [In] IntPtr FrameContexts, [In] uint FrameContextsSize, [In] uint FrameContextsEntrySize, [In] DEBUG_STACK Flags);
        private delegate HRESULT GetStoredEventInformationDelegate(IntPtr self, [Out] out DEBUG_EVENT_TYPE Type, [Out] out uint ProcessId, [Out] out uint ThreadId, [In] IntPtr Context, [In] uint ContextSize, [Out] out uint ContextUsed, [In] IntPtr ExtraInformation, [In] uint ExtraInformationSize, [Out] out uint ExtraInformationUsed);
        private delegate HRESULT GetManagedStatusDelegate(IntPtr self, [Out] out DEBUG_MANAGED Flags, [In] DEBUG_MANSTR WhichString, [Out, MarshalAs(UnmanagedType.LPStr)] StringBuilder String, [In] int StringSize, [Out] out uint StringNeeded);
        private delegate HRESULT GetManagedStatusWideDelegate(IntPtr self, [Out] out DEBUG_MANAGED Flags, [In] DEBUG_MANSTR WhichString, [Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder String, [In] int StringSize, [Out] out uint StringNeeded);
        private delegate HRESULT ResetManagedStatusDelegate(IntPtr self, [In] DEBUG_MANRESET Flags);

        #endregion
        #region IDebugControl5

        private delegate HRESULT GetStackTraceExDelegate(IntPtr self, [In] ulong FrameOffset, [In] ulong StackOffset, [In] ulong InstructionOffset, [Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 4)] DEBUG_STACK_FRAME_EX[] Frames, [In] int FramesSize, [Out] out uint FramesFilled);
        private delegate HRESULT OutputStackTraceExDelegate(IntPtr self, [In] uint OutputControl, [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] DEBUG_STACK_FRAME_EX[] Frames, [In] int FramesSize, [In] DEBUG_STACK Flags);
        private delegate HRESULT GetContextStackTraceExDelegate(IntPtr self, [In] IntPtr StartContext, [In] uint StartContextSize, [Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 3)] DEBUG_STACK_FRAME_EX[] Frames, [In] int FramesSize, [In] IntPtr FrameContexts, [In] uint FrameContextsSize, [In] uint FrameContextsEntrySize, [Out] out uint FramesFilled);
        private delegate HRESULT OutputContextStackTraceExDelegate(IntPtr self, [In] uint OutputControl, [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] DEBUG_STACK_FRAME_EX[] Frames, [In] int FramesSize, [In] IntPtr FrameContexts, [In] uint FrameContextsSize, [In] uint FrameContextsEntrySize, [In] DEBUG_STACK Flags);
        private delegate HRESULT GetBreakpointByGuidDelegate(IntPtr self, [In, MarshalAs(UnmanagedType.LPStruct)] Guid Guid, [Out, ComAliasName("IDebugBreakpoint3")] out IntPtr Bp);

        #endregion
        #region IDebugControl6

        private delegate HRESULT GetExecutionStatusExDelegate(IntPtr self, [Out] out DEBUG_STATUS Status);
        private delegate HRESULT GetSynchronizationStatusDelegate(IntPtr self, [Out] out uint SendsAttempted, [Out] out uint SecondsSinceLastResponse);

        #endregion
        #endregion
    }
}
