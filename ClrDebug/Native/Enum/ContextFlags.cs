using System;
using static ClrDebug.ContextKind;

namespace ClrDebug
{
    internal class ContextKind
    {
        public const int CONTEXT_CONTROL = 1;
        public const int CONTEXT_INTEGER = 2;
        public const int CONTEXT_SEGMENTS = 4;
        public const int CONTEXT_FLOATING_POINT = 8;
        public const int CONTEXT_DEBUG_REGISTERS = 10;
        public const int CONTEXT_EXTENDED_REGISTERS = 20;

        //Note: XSTATE is not defined as part of CONTEXT_FULL or CONTEXT_ALL
        public const int CONTEXT_XSTATE = 40;

        public const int ARM_CONTEXT_CONTROL = 1;
        public const int ARM_CONTEXT_INTEGER = 2;
        public const int ARM_CONTEXT_FLOATING_POINT = 4;
        public const int ARM_CONTEXT_DEBUG_REGISTERS = 8;
    }

    [Flags]
    public enum ContextFlags : uint
    {
        None = 0,
        X86Context = 0x10000,

        /// <summary>
        /// Specifies SegSs, Esp, SegCs, Eip, Ebp and EFlags.
        /// </summary>
        X86ContextControl              = X86Context | CONTEXT_CONTROL,

        /// <summary>
        /// Specifies Eax, Ecx, Edx, Ebx, Esi and Edi.
        /// </summary>
        X86ContextInteger = X86Context | CONTEXT_INTEGER,

        /// <summary>
        /// Specifies SegDs, SegEs, SegFs and SegGs.
        /// </summary>
        X86ContextSegments             = X86Context | CONTEXT_SEGMENTS,

        /// <summary>
        /// Specifies FloatSave.
        /// </summary>
        X86ContextFloatingPoint        = X86Context | CONTEXT_FLOATING_POINT,

        /// <summary>
        /// Specifies Dr0-Dr7.
        /// </summary>
        X86ContextDebugRegisters       = X86Context | CONTEXT_DEBUG_REGISTERS,

        X86ContextExtendedRegisters    = X86Context | CONTEXT_EXTENDED_REGISTERS,
        X86ContextXState               = X86Context | CONTEXT_XSTATE,
        X86ContextFull                 = X86Context | X86ContextControl        | X86ContextInteger           | X86ContextSegments,
        X86ContextAll                  = X86Context | X86ContextControl        | X86ContextInteger           | X86ContextSegments | X86ContextFloatingPoint |
                                                      X86ContextDebugRegisters | X86ContextExtendedRegisters,

        AMD64Context                   = 0x100000,

        /// <summary>
        /// Specifies SegSs, Rsp, SegCs, Rip and EFlags.
        /// </summary>
        AMD64ContextControl            = AMD64Context | CONTEXT_CONTROL,

        /// <summary>
        /// Specifies Rax, Rcx, Rdx, Rbx, Rbp, Rsi, Rdi and R8-R15.
        /// </summary>
        AMD64ContextInteger            = AMD64Context | CONTEXT_INTEGER,

        /// <summary>
        /// Specifies SegDs, SegEs, SegFs and SegGs.
        /// </summary>
        AMD64ContextSegments           = AMD64Context | CONTEXT_SEGMENTS,

        /// <summary>
        /// Specifies Xmm0-Xmm15.
        /// </summary>
        AMD64ContextFloatingPoint      = AMD64Context | CONTEXT_FLOATING_POINT,

        /// <summary>
        /// Specifies Dr0-Dr3 and Dr6-Dr7.
        /// </summary>
        AMD64ContextDebugRegisters     = AMD64Context | CONTEXT_DEBUG_REGISTERS,

        AMD64ContextXState             = AMD64Context | CONTEXT_XSTATE,
        AMD64ContextFull               = AMD64Context | AMD64ContextControl       | AMD64ContextInteger        | AMD64ContextFloatingPoint,
        AMD64ContextAll                = AMD64Context | AMD64ContextControl       | AMD64ContextInteger        | AMD64ContextSegments |
                                                        AMD64ContextFloatingPoint | AMD64ContextDebugRegisters,

        IA64Context                    = 0x80000,
        IA64ContextControl             = IA64Context | 0x1,
        IA64ContextLowerFloatingPoint  = IA64Context | 0x2,
        IA64ContextHigherFloatingPoint = IA64Context | 0x4,
        IA64ContextInteger             = IA64Context | 0x8,
        IA64ContextDebug               = IA64Context | 0x10,
        IA64ContextIA32Control         = IA64Context | 0x20,
        IA64ContextFloatingPoint       = IA64Context | IA64ContextLowerFloatingPoint | IA64ContextHigherFloatingPoint,
        IA64ContextFull                = IA64Context | IA64ContextControl            | IA64ContextFloatingPoint | IA64ContextInteger | IA64ContextIA32Control,
        IA64ContextAll                 = IA64Context | IA64ContextControl            | IA64ContextFloatingPoint | IA64ContextInteger |
                                                       IA64ContextDebug              | IA64ContextIA32Control,

        ARMContext                     = 0x00200000,
        ARMContextControl              = ARMContext | ARM_CONTEXT_CONTROL,
        ARMContextInteger              = ARMContext | ARM_CONTEXT_INTEGER,
        ARMContextFloatingPoint        = ARMContext | ARM_CONTEXT_FLOATING_POINT,
        ARMContextDebugRegisters       = ARMContext | ARM_CONTEXT_DEBUG_REGISTERS,

        ARMContextFull                 = ARMContext | ARMContextControl | ARMContextInteger | ARMContextFloatingPoint,
        ARMContextAll                  = ARMContext | ARMContextControl | ARMContextInteger | ARMContextFloatingPoint | ARMContextDebugRegisters,

        ARM64Context                   = 0x00400000,
        ARM64ContextControl            = ARM64Context | ARM_CONTEXT_CONTROL,
        ARM64ContextInteger            = ARM64Context | ARM_CONTEXT_INTEGER,
        ARM64ContextFloatingPoint      = ARM64Context | ARM_CONTEXT_FLOATING_POINT,
        ARM64ContextDebugRegisters     = ARM64Context | ARM_CONTEXT_DEBUG_REGISTERS,

        ARM64ContextFull               = ARM64Context | ARM64ContextControl | ARM64ContextInteger | ARM64ContextFloatingPoint,
        ARM64ContextAll                = ARM64Context | ARM64ContextControl | ARM64ContextInteger | ARM64ContextFloatingPoint | ARM64ContextDebugRegisters
    }
}
