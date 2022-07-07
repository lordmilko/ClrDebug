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
        HRESULT GetAssemblyOptions(
            [Out] out DEBUG_ASMOPT Options);

        [PreserveSig]
        HRESULT AddAssemblyOptions(
            [In] DEBUG_ASMOPT Options);

        [PreserveSig]
        HRESULT RemoveAssemblyOptions(
            [In] DEBUG_ASMOPT Options);

        [PreserveSig]
        HRESULT SetAssemblyOptions(
            [In] DEBUG_ASMOPT Options);

        [PreserveSig]
        HRESULT GetExpressionSyntax(
            [Out] out DEBUG_EXPR Flags);

        [PreserveSig]
        HRESULT SetExpressionSyntax(
            [In] DEBUG_EXPR Flags);

        [PreserveSig]
        HRESULT SetExpressionSyntaxByName(
            [In, MarshalAs(UnmanagedType.LPStr)] string AbbrevName);

        [PreserveSig]
        HRESULT GetNumberExpressionSyntaxes(
            [Out] out uint Number);

        [PreserveSig]
        HRESULT GetExpressionSyntaxNames(
            [In] uint Index,
            [Out, MarshalAs(UnmanagedType.LPStr)] StringBuilder FullNameBuffer,
            [In] int FullNameBufferSize,
            [Out] out uint FullNameSize,
            [Out, MarshalAs(UnmanagedType.LPStr)] StringBuilder AbbrevNameBuffer,
            [In] int AbbrevNameBufferSize,
            [Out] out uint AbbrevNameSize);

        [PreserveSig]
        HRESULT GetNumberEvents(
            [Out] out uint Events);

        [PreserveSig]
        HRESULT GetEventIndexDescription(
            [In] uint Index,
            [In] DEBUG_EINDEX Which,
            [Out, MarshalAs(UnmanagedType.LPStr)] StringBuilder Buffer,
            [In] int BufferSize,
            [Out] out uint DescSize);

        [PreserveSig]
        HRESULT GetCurrentEventIndex(
            [Out] out uint Index);

        [PreserveSig]
        HRESULT SetNextEventIndex(
            [In] DEBUG_EINDEX Relation,
            [In] uint Value,
            [Out] out uint NextIndex);

        #endregion
    }
}
