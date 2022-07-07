using System;
using System.Runtime.InteropServices;
using System.Text;

namespace ClrDebug.DbgEng
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("94e60ce9-9b41-4b19-9fc0-6d9eb35272b3")]
    [ComImport]
    public interface IDebugControl4 : IDebugControl3
    {
        #region IDebugControl

        [PreserveSig]
        new HRESULT GetInterrupt();

        [PreserveSig]
        new HRESULT SetInterrupt(
            [In] DEBUG_INTERRUPT Flags);

        [PreserveSig]
        new HRESULT GetInterruptTimeout(
            [Out] out uint Seconds);

        [PreserveSig]
        new HRESULT SetInterruptTimeout(
            [In] uint Seconds);

        [PreserveSig]
        new HRESULT GetLogFile(
            [Out, MarshalAs(UnmanagedType.LPStr)] StringBuilder Buffer,
            [In] int BufferSize,
            [Out] out uint FileSize,
            [Out, MarshalAs(UnmanagedType.Bool)] out bool Append);

        [PreserveSig]
        new HRESULT OpenLogFile(
            [In, MarshalAs(UnmanagedType.LPStr)] string File,
            [In, MarshalAs(UnmanagedType.Bool)] bool Append);

        [PreserveSig]
        new HRESULT CloseLogFile();

        [PreserveSig]
        new HRESULT GetLogMask(
            [Out] out DEBUG_OUTPUT Mask);

        [PreserveSig]
        new HRESULT SetLogMask(
            [In] DEBUG_OUTPUT Mask);

        [PreserveSig]
        new HRESULT Input(
            [Out, MarshalAs(UnmanagedType.LPStr)] StringBuilder Buffer,
            [In] int BufferSize,
            [Out] out uint InputSize);

        [PreserveSig]
        new HRESULT ReturnInput(
            [In, MarshalAs(UnmanagedType.LPStr)] string Buffer);

        [PreserveSig]
        new HRESULT Output(
            [In] DEBUG_OUTPUT Mask,
            [In, MarshalAs(UnmanagedType.LPStr)] string Format);

        [PreserveSig]
        [Obsolete("This method cannot be safely called from managed code")]
        new HRESULT OutputVaList(
            [In] DEBUG_OUTPUT Mask,
            [In, MarshalAs(UnmanagedType.LPStr)] string Format,
            [In] IntPtr va_list_Args);

        [PreserveSig]
        new HRESULT ControlledOutput(
            [In] DEBUG_OUTCTL OutputControl,
            [In] DEBUG_OUTPUT Mask,
            [In, MarshalAs(UnmanagedType.LPStr)] string Format);

        [PreserveSig]
        [Obsolete("This method cannot be safely called from managed code")]
        new HRESULT ControlledOutputVaList(
            [In] DEBUG_OUTCTL OutputControl,
            [In] DEBUG_OUTPUT Mask,
            [In, MarshalAs(UnmanagedType.LPStr)] string Format,
            [In] IntPtr va_list_Args);

        [PreserveSig]
        new HRESULT OutputPrompt(
            [In] DEBUG_OUTCTL OutputControl,
            [In, MarshalAs(UnmanagedType.LPStr)] string Format);

        [PreserveSig]
        [Obsolete("This method cannot be safely called from managed code")]
        new HRESULT OutputPromptVaList(
            [In] DEBUG_OUTCTL OutputControl,
            [In, MarshalAs(UnmanagedType.LPStr)] string Format,
            [In] IntPtr va_list_Args);

        [PreserveSig]
        new HRESULT GetPromptText(
            [Out, MarshalAs(UnmanagedType.LPStr)] StringBuilder Buffer,
            [In] int BufferSize,
            [Out] out uint TextSize);

        [PreserveSig]
        new HRESULT OutputCurrentState(
            [In] DEBUG_OUTCTL OutputControl,
            [In] DEBUG_CURRENT Flags);

        [PreserveSig]
        new HRESULT OutputVersionInformation(
            [In] DEBUG_OUTCTL OutputControl);

        [PreserveSig]
        new HRESULT GetNotifyEventHandle(
            [Out] out ulong Handle);

        [PreserveSig]
        new HRESULT SetNotifyEventHandle(
            [In] ulong Handle);

        [PreserveSig]
        new HRESULT Assemble(
            [In] ulong Offset,
            [In, MarshalAs(UnmanagedType.LPStr)] string Instr,
            [Out] out ulong EndOffset);

        [PreserveSig]
        new HRESULT Disassemble(
            [In] ulong Offset,
            [In] DEBUG_DISASM Flags,
            [Out, MarshalAs(UnmanagedType.LPStr)] StringBuilder Buffer,
            [In] int BufferSize,
            [Out] out uint DisassemblySize,
            [Out] out ulong EndOffset);

        [PreserveSig]
        new HRESULT GetDisassembleEffectiveOffset(
            [Out] out ulong Offset);

        [PreserveSig]
        new HRESULT OutputDisassembly(
            [In] DEBUG_OUTCTL OutputControl,
            [In] ulong Offset,
            [In] DEBUG_DISASM Flags,
            [Out] out ulong EndOffset);

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

        [PreserveSig]
        new HRESULT GetNearInstruction(
            [In] ulong Offset,
            [In] int Delta,
            [Out] out ulong NearOffset);

        [PreserveSig]
        new HRESULT GetStackTrace(
            [In] ulong FrameOffset,
            [In] ulong StackOffset,
            [In] ulong InstructionOffset,
            [Out, MarshalAs(UnmanagedType.LPArray)] DEBUG_STACK_FRAME[] Frames,
            [In] int FrameSize,
            [Out] out uint FramesFilled);

        [PreserveSig]
        new HRESULT GetReturnOffset(
            [Out] out ulong Offset);

        [PreserveSig]
        new HRESULT OutputStackTrace(
            [In] DEBUG_OUTCTL OutputControl,
            [In, MarshalAs(UnmanagedType.LPArray)] DEBUG_STACK_FRAME[] Frames,
            [In] int FramesSize,
            [In] DEBUG_STACK Flags);

        [PreserveSig]
        new HRESULT GetDebuggeeType(
            [Out] out DEBUG_CLASS Class,
            [Out] out DEBUG_CLASS_QUALIFIER Qualifier);

        [PreserveSig]
        new HRESULT GetActualProcessorType(
            [Out] out IMAGE_FILE_MACHINE Type);

        [PreserveSig]
        new HRESULT GetExecutingProcessorType(
            [Out] out IMAGE_FILE_MACHINE Type);

        [PreserveSig]
        new HRESULT GetNumberPossibleExecutingProcessorTypes(
            [Out] out uint Number);

        [PreserveSig]
        new HRESULT GetPossibleExecutingProcessorTypes(
            [In] uint Start,
            [In] uint Count,
            [Out, MarshalAs(UnmanagedType.LPArray)] IMAGE_FILE_MACHINE[] Types);

        [PreserveSig]
        new HRESULT GetNumberProcessors(
            [Out] out uint Number);

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

        [PreserveSig]
        new HRESULT GetPageSize(
            [Out] out uint Size);

        [PreserveSig]
        new HRESULT IsPointer64Bit();

        [PreserveSig]
        new HRESULT ReadBugCheckData(
            [Out] out uint Code,
            [Out] out ulong Arg1,
            [Out] out ulong Arg2,
            [Out] out ulong Arg3,
            [Out] out ulong Arg4);

        [PreserveSig]
        new HRESULT GetNumberSupportedProcessorTypes(
            [Out] out uint Number);

        [PreserveSig]
        new HRESULT GetSupportedProcessorTypes(
            [In] uint Start,
            [In] uint Count,
            [Out, MarshalAs(UnmanagedType.LPArray)] IMAGE_FILE_MACHINE[] Types);

        [PreserveSig]
        new HRESULT GetProcessorTypeNames(
            [In] IMAGE_FILE_MACHINE Type,
            [Out, MarshalAs(UnmanagedType.LPStr)] StringBuilder FullNameBuffer,
            [In] int FullNameBufferSize,
            [Out] out uint FullNameSize,
            [Out, MarshalAs(UnmanagedType.LPStr)] StringBuilder AbbrevNameBuffer,
            [In] int AbbrevNameBufferSize,
            [Out] out uint AbbrevNameSize);

        [PreserveSig]
        new HRESULT GetEffectiveProcessorType(
            [Out] out IMAGE_FILE_MACHINE Type);

        [PreserveSig]
        new HRESULT SetEffectiveProcessorType(
            [In] IMAGE_FILE_MACHINE Type);

        [PreserveSig]
        new HRESULT GetExecutionStatus(
            [Out] out DEBUG_STATUS Status);

        [PreserveSig]
        new HRESULT SetExecutionStatus(
            [In] DEBUG_STATUS Status);

        [PreserveSig]
        new HRESULT GetCodeLevel(
            [Out] out DEBUG_LEVEL Level);

        [PreserveSig]
        new HRESULT SetCodeLevel(
            [In] DEBUG_LEVEL Level);

        [PreserveSig]
        new HRESULT GetEngineOptions(
            [Out] out DEBUG_ENGOPT Options);

        [PreserveSig]
        new HRESULT AddEngineOptions(
            [In] DEBUG_ENGOPT Options);

        [PreserveSig]
        new HRESULT RemoveEngineOptions(
            [In] DEBUG_ENGOPT Options);

        [PreserveSig]
        new HRESULT SetEngineOptions(
            [In] DEBUG_ENGOPT Options);

        [PreserveSig]
        new HRESULT GetSystemErrorControl(
            [Out] out ERROR_LEVEL OutputLevel,
            [Out] out ERROR_LEVEL BreakLevel);

        [PreserveSig]
        new HRESULT SetSystemErrorControl(
            [In] ERROR_LEVEL OutputLevel,
            [In] ERROR_LEVEL BreakLevel);

        [PreserveSig]
        new HRESULT GetTextMacro(
            [In] uint Slot,
            [Out, MarshalAs(UnmanagedType.LPStr)] StringBuilder Buffer,
            [In] int BufferSize,
            [Out] out uint MacroSize);

        [PreserveSig]
        new HRESULT SetTextMacro(
            [In] uint Slot,
            [In, MarshalAs(UnmanagedType.LPStr)] string Macro);

        [PreserveSig]
        new HRESULT GetRadix(
            [Out] out uint Radix);

        [PreserveSig]
        new HRESULT SetRadix(
            [In] uint Radix);

        [PreserveSig]
        new HRESULT Evaluate(
            [In, MarshalAs(UnmanagedType.LPStr)] string Expression,
            [In] DEBUG_VALUE_TYPE DesiredType,
            [Out] out DEBUG_VALUE Value,
            [Out] out uint RemainderIndex);

        [PreserveSig]
        new HRESULT CoerceValue(
            [In] DEBUG_VALUE In,
            [In] DEBUG_VALUE_TYPE OutType,
            [Out] out DEBUG_VALUE Out);

        [PreserveSig]
        new HRESULT CoerceValues(
            [In] uint Count,
            [In, MarshalAs(UnmanagedType.LPArray)] DEBUG_VALUE[] In,
            [In, MarshalAs(UnmanagedType.LPArray)] DEBUG_VALUE_TYPE[] OutType,
            [Out, MarshalAs(UnmanagedType.LPArray)] DEBUG_VALUE[] Out);

        [PreserveSig]
        new HRESULT Execute(
            [In] DEBUG_OUTCTL OutputControl,
            [In, MarshalAs(UnmanagedType.LPStr)] string Command,
            [In] DEBUG_EXECUTE Flags);

        [PreserveSig]
        new HRESULT ExecuteCommandFile(
            [In] DEBUG_OUTCTL OutputControl,
            [In, MarshalAs(UnmanagedType.LPStr)] string CommandFile,
            [In] DEBUG_EXECUTE Flags);

        [PreserveSig]
        new HRESULT GetNumberBreakpoints(
            [Out] out uint Number);

        [PreserveSig]
        new HRESULT GetBreakpointByIndex(
            [In] uint Index,
            [Out, MarshalAs(UnmanagedType.Interface)]
            out IDebugBreakpoint bp);

        [PreserveSig]
        new HRESULT GetBreakpointById(
            [In] uint Id,
            [Out, MarshalAs(UnmanagedType.Interface)]
            out IDebugBreakpoint bp);

        [PreserveSig]
        new HRESULT GetBreakpointParameters(
            [In] uint Count,
            [In, MarshalAs(UnmanagedType.LPArray)] uint[] Ids,
            [In] uint Start,
            [Out, MarshalAs(UnmanagedType.LPArray)] DEBUG_BREAKPOINT_PARAMETERS[] Params);

        [PreserveSig]
        new HRESULT AddBreakpoint(
            [In] DEBUG_BREAKPOINT_TYPE Type,
            [In] uint DesiredId,
            [Out, MarshalAs(UnmanagedType.Interface)]
            out IDebugBreakpoint Bp);

        [PreserveSig]
        new HRESULT RemoveBreakpoint(
            [In, MarshalAs(UnmanagedType.Interface)]
            IDebugBreakpoint Bp);

        [PreserveSig]
        new HRESULT AddExtension(
            [In, MarshalAs(UnmanagedType.LPStr)] string Path,
            [In] uint Flags,
            [Out] out ulong Handle);

        [PreserveSig]
        new HRESULT RemoveExtension(
            [In] ulong Handle);

        [PreserveSig]
        new HRESULT GetExtensionByPath(
            [In, MarshalAs(UnmanagedType.LPStr)] string Path,
            [Out] out ulong Handle);

        [PreserveSig]
        new HRESULT CallExtension(
            [In] ulong Handle,
            [In, MarshalAs(UnmanagedType.LPStr)] string Function,
            [In, MarshalAs(UnmanagedType.LPStr)] string Arguments);

        [PreserveSig]
        new HRESULT GetExtensionFunction(
            [In] ulong Handle,
            [In, MarshalAs(UnmanagedType.LPStr)] string FuncName,
            [Out] out IntPtr Function);

        [PreserveSig]
        new HRESULT GetWindbgExtensionApis32(
            [In, Out] ref WINDBG_EXTENSION_APIS Api); //Must initialize nSize, hence ref

        [PreserveSig]
        new HRESULT GetWindbgExtensionApis64(
            [In, Out] ref WINDBG_EXTENSION_APIS Api); //Must initialize nSize, hence ref

        [PreserveSig]
        new HRESULT GetNumberEventFilters(
            [Out] out uint SpecificEvents,
            [Out] out uint SpecificExceptions,
            [Out] out uint ArbitraryExceptions);

        [PreserveSig]
        new HRESULT GetEventFilterText(
            [In] uint Index,
            [Out, MarshalAs(UnmanagedType.LPStr)] StringBuilder Buffer,
            [In] int BufferSize,
            [Out] out uint TextSize);

        [PreserveSig]
        new HRESULT GetEventFilterCommand(
            [In] uint Index,
            [Out, MarshalAs(UnmanagedType.LPStr)] StringBuilder Buffer,
            [In] int BufferSize,
            [Out] out uint CommandSize);

        [PreserveSig]
        new HRESULT SetEventFilterCommand(
            [In] uint Index,
            [In, MarshalAs(UnmanagedType.LPStr)] string Command);

        [PreserveSig]
        new HRESULT GetSpecificFilterParameters(
            [In] uint Start,
            [In] uint Count,
            [Out, MarshalAs(UnmanagedType.LPArray)] DEBUG_SPECIFIC_FILTER_PARAMETERS[] Params);

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

        [PreserveSig]
        new HRESULT GetExceptionFilterParameters(
            [In] uint Count,
            [In, MarshalAs(UnmanagedType.LPArray)]
            uint[] Codes,
            [In] uint Start,
            [Out, MarshalAs(UnmanagedType.LPArray)] DEBUG_EXCEPTION_FILTER_PARAMETERS[] Params);

        [PreserveSig]
        new HRESULT SetExceptionFilterParameters(
            [In] uint Count,
            [In, MarshalAs(UnmanagedType.LPArray)] DEBUG_EXCEPTION_FILTER_PARAMETERS[] Params);

        [PreserveSig]
        new HRESULT GetExceptionFilterSecondCommand(
            [In] uint Index,
            [Out, MarshalAs(UnmanagedType.LPStr)] StringBuilder Buffer,
            [In] int BufferSize,
            [Out] out uint CommandSize);

        [PreserveSig]
        new HRESULT SetExceptionFilterSecondCommand(
            [In] uint Index,
            [In, MarshalAs(UnmanagedType.LPStr)] string Command);

        [PreserveSig]
        new HRESULT WaitForEvent(
            [In] DEBUG_WAIT Flags,
            [In] int Timeout);

        [PreserveSig]
        new HRESULT GetLastEventInformation(
            [Out] out DEBUG_EVENT Type,
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

        [PreserveSig]
        new HRESULT GetCurrentTimeDate(
            [Out] out uint TimeDate);

        [PreserveSig]
        new HRESULT GetCurrentSystemUpTime(
            [Out] out uint UpTime);

        [PreserveSig]
        new HRESULT GetDumpFormatFlags(
            [Out] out DEBUG_FORMAT FormatFlags);

        [PreserveSig]
        new HRESULT GetNumberTextReplacements(
            [Out] out uint NumRepl);

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

        [PreserveSig]
        new HRESULT SetTextReplacement(
            [In, MarshalAs(UnmanagedType.LPStr)] string SrcText,
            [In, MarshalAs(UnmanagedType.LPStr)] string DstText);

        [PreserveSig]
        new HRESULT RemoveTextReplacements();

        [PreserveSig]
        new HRESULT OutputTextReplacements(
            [In] DEBUG_OUTCTL OutputControl,
            [In] DEBUG_OUT_TEXT_REPL Flags);

        #endregion
        #region IDebugControl3

        [PreserveSig]
        new HRESULT GetAssemblyOptions(
            [Out] out DEBUG_ASMOPT Options);

        [PreserveSig]
        new HRESULT AddAssemblyOptions(
            [In] DEBUG_ASMOPT Options);

        [PreserveSig]
        new HRESULT RemoveAssemblyOptions(
            [In] DEBUG_ASMOPT Options);

        [PreserveSig]
        new HRESULT SetAssemblyOptions(
            [In] DEBUG_ASMOPT Options);

        [PreserveSig]
        new HRESULT GetExpressionSyntax(
            [Out] out DEBUG_EXPR Flags);

        [PreserveSig]
        new HRESULT SetExpressionSyntax(
            [In] DEBUG_EXPR Flags);

        [PreserveSig]
        new HRESULT SetExpressionSyntaxByName(
            [In, MarshalAs(UnmanagedType.LPStr)] string AbbrevName);

        [PreserveSig]
        new HRESULT GetNumberExpressionSyntaxes(
            [Out] out uint Number);

        [PreserveSig]
        new HRESULT GetExpressionSyntaxNames(
            [In] uint Index,
            [Out, MarshalAs(UnmanagedType.LPStr)] StringBuilder FullNameBuffer,
            [In] int FullNameBufferSize,
            [Out] out uint FullNameSize,
            [Out, MarshalAs(UnmanagedType.LPStr)] StringBuilder AbbrevNameBuffer,
            [In] int AbbrevNameBufferSize,
            [Out] out uint AbbrevNameSize);

        [PreserveSig]
        new HRESULT GetNumberEvents(
            [Out] out uint Events);

        [PreserveSig]
        new HRESULT GetEventIndexDescription(
            [In] uint Index,
            [In] DEBUG_EINDEX Which,
            [Out, MarshalAs(UnmanagedType.LPStr)] StringBuilder Buffer,
            [In] int BufferSize,
            [Out] out uint DescSize);

        [PreserveSig]
        new HRESULT GetCurrentEventIndex(
            [Out] out uint Index);

        [PreserveSig]
        new HRESULT SetNextEventIndex(
            [In] DEBUG_EINDEX Relation,
            [In] uint Value,
            [Out] out uint NextIndex);

        #endregion
        #region IDebugControl4

        [PreserveSig]
        HRESULT GetLogFileWide(
            [Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder Buffer,
            [In] int BufferSize,
            [Out] out uint FileSize,
            [Out, MarshalAs(UnmanagedType.Bool)] out bool Append);

        [PreserveSig]
        HRESULT OpenLogFileWide(
            [In, MarshalAs(UnmanagedType.LPWStr)] string File,
            [In, MarshalAs(UnmanagedType.Bool)] bool Append);

        [PreserveSig]
        HRESULT InputWide(
            [Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder Buffer,
            [In] int BufferSize,
            [Out] out uint InputSize);

        [PreserveSig]
        HRESULT ReturnInputWide(
            [In, MarshalAs(UnmanagedType.LPWStr)] string Buffer);

        [PreserveSig]
        HRESULT OutputWide(
            [In] DEBUG_OUTPUT Mask,
            [In, MarshalAs(UnmanagedType.LPWStr)] string Format);

        [PreserveSig]
        [Obsolete("This method cannot be safely called from managed code")]
        HRESULT OutputVaListWide(
            [In] DEBUG_OUTPUT Mask,
            [In, MarshalAs(UnmanagedType.LPWStr)] string Format,
            [In] IntPtr va_list_Args);

        [PreserveSig]
        HRESULT ControlledOutputWide(
            [In] DEBUG_OUTCTL OutputControl,
            [In] DEBUG_OUTPUT Mask,
            [In, MarshalAs(UnmanagedType.LPWStr)] string Format);

        [PreserveSig]
        [Obsolete("This method cannot be safely called from managed code")]
        HRESULT ControlledOutputVaListWide(
            [In] DEBUG_OUTCTL OutputControl,
            [In] DEBUG_OUTPUT Mask,
            [In, MarshalAs(UnmanagedType.LPWStr)] string Format,
            [In] IntPtr va_list_Args);

        [PreserveSig]
        HRESULT OutputPromptWide(
            [In] DEBUG_OUTCTL OutputControl,
            [In, MarshalAs(UnmanagedType.LPWStr)] string Format);

        [PreserveSig]
        [Obsolete("This method cannot be safely called from managed code")]
        HRESULT OutputPromptVaListWide(
            [In] DEBUG_OUTCTL OutputControl,
            [In, MarshalAs(UnmanagedType.LPWStr)] string Format,
            [In] IntPtr va_list_Args);

        [PreserveSig]
        HRESULT GetPromptTextWide(
            [Out, MarshalAs(UnmanagedType.LPWStr)]
            StringBuilder Buffer,
            [In] int BufferSize,
            [Out] out uint TextSize);

        [PreserveSig]
        HRESULT AssembleWide(
            [In] ulong Offset,
            [In, MarshalAs(UnmanagedType.LPWStr)] string Instr,
            [Out] out ulong EndOffset);

        [PreserveSig]
        HRESULT DisassembleWide(
            [In] ulong Offset,
            [In] DEBUG_DISASM Flags,
            [Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder Buffer,
            [In] int BufferSize,
            [Out] out uint DisassemblySize,
            [Out] out ulong EndOffset);

        [PreserveSig]
        HRESULT GetProcessorTypeNamesWide(
            [In] IMAGE_FILE_MACHINE Type,
            [Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder FullNameBuffer,
            [In] int FullNameBufferSize,
            [Out] out uint FullNameSize,
            [Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder AbbrevNameBuffer,
            [In] int AbbrevNameBufferSize,
            [Out] out uint AbbrevNameSize);

        [PreserveSig]
        HRESULT GetTextMacroWide(
            [In] uint Slot,
            [Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder Buffer,
            [In] int BufferSize,
            [Out] out uint MacroSize);

        [PreserveSig]
        HRESULT SetTextMacroWide(
            [In] uint Slot,
            [In, MarshalAs(UnmanagedType.LPWStr)] string Macro);

        [PreserveSig]
        HRESULT EvaluateWide(
            [In, MarshalAs(UnmanagedType.LPWStr)] string Expression,
            [In] DEBUG_VALUE_TYPE DesiredType,
            [Out] out DEBUG_VALUE Value,
            [Out] out uint RemainderIndex);

        [PreserveSig]
        HRESULT ExecuteWide(
            [In] DEBUG_OUTCTL OutputControl,
            [In, MarshalAs(UnmanagedType.LPWStr)] string Command,
            [In] DEBUG_EXECUTE Flags);

        [PreserveSig]
        HRESULT ExecuteCommandFileWide(
            [In] DEBUG_OUTCTL OutputControl,
            [In, MarshalAs(UnmanagedType.LPWStr)] string CommandFile,
            [In] DEBUG_EXECUTE Flags);

        [PreserveSig]
        HRESULT GetBreakpointByIndex2(
            [In] uint Index,
            [Out, MarshalAs(UnmanagedType.Interface)] out IDebugBreakpoint2 bp);

        [PreserveSig]
        HRESULT GetBreakpointById2(
            [In] uint Id,
            [Out, MarshalAs(UnmanagedType.Interface)] out IDebugBreakpoint2 bp);

        [PreserveSig]
        HRESULT AddBreakpoint2(
            [In] DEBUG_BREAKPOINT_TYPE Type,
            [In] uint DesiredId,
            [Out, MarshalAs(UnmanagedType.Interface)] out IDebugBreakpoint2 Bp);

        [PreserveSig]
        HRESULT RemoveBreakpoint2(
            [In, MarshalAs(UnmanagedType.Interface)] IDebugBreakpoint2 Bp);

        [PreserveSig]
        HRESULT AddExtensionWide(
            [In, MarshalAs(UnmanagedType.LPWStr)] string Path,
            [In] uint Flags,
            [Out] out ulong Handle);

        [PreserveSig]
        HRESULT GetExtensionByPathWide(
            [In, MarshalAs(UnmanagedType.LPWStr)] string Path,
            [Out] out ulong Handle);

        [PreserveSig]
        HRESULT CallExtensionWide(
            [In] ulong Handle,
            [In, MarshalAs(UnmanagedType.LPWStr)] string Function,
            [In, MarshalAs(UnmanagedType.LPWStr)] string Arguments);

        [PreserveSig]
        HRESULT GetExtensionFunctionWide(
            [In] ulong Handle,
            [In, MarshalAs(UnmanagedType.LPWStr)] string FuncName,
            [Out] out IntPtr Function);

        [PreserveSig]
        HRESULT GetEventFilterTextWide(
            [In] uint Index,
            [Out, MarshalAs(UnmanagedType.LPWStr)]
            StringBuilder Buffer,
            [In] int BufferSize,
            [Out] out uint TextSize);

        [PreserveSig]
        HRESULT GetEventFilterCommandWide(
            [In] uint Index,
            [Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder Buffer,
            [In] int BufferSize,
            [Out] out uint CommandSize);

        [PreserveSig]
        HRESULT SetEventFilterCommandWide(
            [In] uint Index,
            [In, MarshalAs(UnmanagedType.LPWStr)] string Command);

        [PreserveSig]
        HRESULT GetSpecificEventFilterArgumentWide(
            [In] uint Index,
            [Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder Buffer,
            [In] int BufferSize,
            [Out] out uint ArgumentSize);

        [PreserveSig]
        HRESULT SetSpecificEventFilterArgumentWide(
            [In] uint Index,
            [In, MarshalAs(UnmanagedType.LPWStr)] string Argument);

        [PreserveSig]
        HRESULT GetExceptionFilterSecondCommandWide(
            [In] uint Index,
            [Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder Buffer,
            [In] int BufferSize,
            [Out] out uint CommandSize);

        [PreserveSig]
        HRESULT SetExceptionFilterSecondCommandWide(
            [In] uint Index,
            [In, MarshalAs(UnmanagedType.LPWStr)] string Command);

        [PreserveSig]
        HRESULT GetLastEventInformationWide(
            [Out] out DEBUG_EVENT Type,
            [Out] out uint ProcessId,
            [Out] out uint ThreadId,
            [In] IntPtr ExtraInformation,
            [In] int ExtraInformationSize,
            [Out] out uint ExtraInformationUsed,
            [Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder Description,
            [In] int DescriptionSize,
            [Out] out uint DescriptionUsed);

        [PreserveSig]
        HRESULT GetTextReplacementWide(
            [In, MarshalAs(UnmanagedType.LPWStr)] string SrcText,
            [In] uint Index,
            [Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder SrcBuffer,
            [In] int SrcBufferSize,
            [Out] out uint SrcSize,
            [Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder DstBuffer,
            [In] int DstBufferSize,
            [Out] out uint DstSize);

        [PreserveSig]
        HRESULT SetTextReplacementWide(
            [In, MarshalAs(UnmanagedType.LPWStr)] string SrcText,
            [In, MarshalAs(UnmanagedType.LPWStr)] string DstText);

        [PreserveSig]
        HRESULT SetExpressionSyntaxByNameWide(
            [In, MarshalAs(UnmanagedType.LPWStr)] string AbbrevName);

        [PreserveSig]
        HRESULT GetExpressionSyntaxNamesWide(
            [In] uint Index,
            [Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder FullNameBuffer,
            [In] int FullNameBufferSize,
            [Out] out uint FullNameSize,
            [Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder AbbrevNameBuffer,
            [In] int AbbrevNameBufferSize,
            [Out] out uint AbbrevNameSize);

        [PreserveSig]
        HRESULT GetEventIndexDescriptionWide(
            [In] uint Index,
            [In] DEBUG_EINDEX Which,
            [Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder Buffer,
            [In] int BufferSize,
            [Out] out uint DescSize);

        [PreserveSig]
        HRESULT GetLogFile2(
            [Out, MarshalAs(UnmanagedType.LPStr)] StringBuilder Buffer,
            [In] int BufferSize,
            [Out] out uint FileSize,
            [Out] out DEBUG_LOG Flags);

        [PreserveSig]
        HRESULT OpenLogFile2(
            [In, MarshalAs(UnmanagedType.LPStr)] string File,
            [Out] out DEBUG_LOG Flags);

        [PreserveSig]
        HRESULT GetLogFile2Wide(
            [Out, MarshalAs(UnmanagedType.LPWStr)]
            StringBuilder Buffer,
            [In] int BufferSize,
            [Out] out uint FileSize,
            [Out] out DEBUG_LOG Flags);

        [PreserveSig]
        HRESULT OpenLogFile2Wide(
            [In, MarshalAs(UnmanagedType.LPWStr)] string File,
            [Out] out DEBUG_LOG Flags);

        [PreserveSig]
        HRESULT GetSystemVersionValues(
            [Out] out uint PlatformId,
            [Out] out uint Win32Major,
            [Out] out uint Win32Minor,
            [Out] out uint KdMajor,
            [Out] out uint KdMinor);

        [PreserveSig]
        HRESULT GetSystemVersionString(
            [In] DEBUG_SYSVERSTR Which,
            [Out, MarshalAs(UnmanagedType.LPStr)] StringBuilder Buffer,
            [In] int BufferSize,
            [Out] out uint StringSize);

        [PreserveSig]
        HRESULT GetSystemVersionStringWide(
            [In] DEBUG_SYSVERSTR Which,
            [Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder Buffer,
            [In] int BufferSize,
            [Out] out uint StringSize);

        [PreserveSig]
        HRESULT GetContextStackTrace(
            [In] IntPtr StartContext,
            [In] uint StartContextSize,
            [Out, MarshalAs(UnmanagedType.LPArray)] DEBUG_STACK_FRAME[] Frames,
            [In] int FrameSize,
            [In] IntPtr FrameContexts,
            [In] uint FrameContextsSize,
            [In] uint FrameContextsEntrySize,
            [Out] out uint FramesFilled);

        [PreserveSig]
        HRESULT OutputContextStackTrace(
            [In] DEBUG_OUTCTL OutputControl,
            [In, MarshalAs(UnmanagedType.LPArray)] DEBUG_STACK_FRAME[] Frames,
            [In] int FramesSize,
            [In] IntPtr FrameContexts,
            [In] uint FrameContextsSize,
            [In] uint FrameContextsEntrySize,
            [In] DEBUG_STACK Flags);

        [PreserveSig]
        HRESULT GetStoredEventInformation(
            [Out] out DEBUG_EVENT Type,
            [Out] out uint ProcessId,
            [Out] out uint ThreadId,
            [In] IntPtr Context,
            [In] uint ContextSize,
            [Out] out uint ContextUsed,
            [In] IntPtr ExtraInformation,
            [In] uint ExtraInformationSize,
            [Out] out uint ExtraInformationUsed);

        [PreserveSig]
        HRESULT GetManagedStatus(
            [Out] out DEBUG_MANAGED Flags,
            [In] DEBUG_MANSTR WhichString,
            [Out, MarshalAs(UnmanagedType.LPStr)] StringBuilder String,
            [In] int StringSize,
            [Out] out uint StringNeeded);

        [PreserveSig]
        HRESULT GetManagedStatusWide(
            [Out] out DEBUG_MANAGED Flags,
            [In] DEBUG_MANSTR WhichString,
            [Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder String,
            [In] int StringSize,
            [Out] out uint StringNeeded);

        [PreserveSig]
        HRESULT ResetManagedStatus(
            [In] DEBUG_MANRESET Flags);

        #endregion
    }
}
