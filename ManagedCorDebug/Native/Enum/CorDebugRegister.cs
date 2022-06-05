namespace ManagedCorDebug
{
    /// <summary>
    /// Specifies the registers associated with a given processor architecture.
    /// </summary>
    /// <remarks>
    /// There are 128 general-purpose data registers and 128 floating-point data registers on the IA-64 processor, but
    /// only values REGISTER_IA64_R0 and REGISTER_IA64_F0 are provided. The other values can be determined as follows:
    /// For example, if you need to specify the #83 data register on the IA-64 processor, use REGISTER_IA64_R0 + 83.
    /// </remarks>
    public enum CorDebugRegister
    {
        /// <summary>
        /// The instruction pointer register on the AMD64 processor.
        /// </summary>
        REGISTER_AMD64_RIP = 0,
        REGISTER_ARM64_PC = 0,

        /// <summary>
        /// The program counter register (R15) on the ARM processor.
        /// </summary>
        REGISTER_ARM_PC = 0,

        /// <summary>
        /// An instruction pointer register on any processor.
        /// </summary>
        REGISTER_INSTRUCTION_POINTER = 0,

        /// <summary>
        /// The instruction pointer register on the x86 processor.
        /// </summary>
        REGISTER_X86_EIP = 0,

        /// <summary>
        /// The stack pointer register on the AMD64 processor.
        /// </summary>
        REGISTER_AMD64_RSP = 1,
        REGISTER_ARM64_SP = 1,

        /// <summary>
        /// The stack pointer register (R13) on the ARM processor.
        /// </summary>
        REGISTER_ARM_SP = 1,

        /// <summary>
        /// A stack pointer register on any processor.
        /// </summary>
        REGISTER_STACK_POINTER = 1,

        /// <summary>
        /// The stack pointer register on the x86 processor.
        /// </summary>
        REGISTER_X86_ESP = 1,

        /// <summary>
        /// The base pointer register on the AMD64 processor.
        /// </summary>
        REGISTER_AMD64_RBP = 2,
        REGISTER_ARM64_FP = 2,

        /// <summary>
        /// Data register R0 on the ARM processor.
        /// </summary>
        REGISTER_ARM_R0 = 2,

        /// <summary>
        /// A frame pointer register on any processor.
        /// </summary>
        REGISTER_FRAME_POINTER = 2,

        /// <summary>
        /// The stack pointer register on the IA-64 processor.
        /// </summary>
        REGISTER_IA64_BSP = 2,

        /// <summary>
        /// The base pointer register on the x86 processor.
        /// </summary>
        REGISTER_X86_EBP = 2,

        /// <summary>
        /// The A data register on the AMD64 processor.
        /// </summary>
        REGISTER_AMD64_RAX = 3,
        REGISTER_ARM64_X0 = 3,

        /// <summary>
        /// Data register R1 on the ARM processor.
        /// </summary>
        REGISTER_ARM_R1 = 3,

        /// <summary>
        /// The #0 data register on the IA-64 processor.
        /// </summary>
        REGISTER_IA64_R0 = 3,

        /// <summary>
        /// The A data register on the x86 processor.
        /// </summary>
        REGISTER_X86_EAX = 3,

        /// <summary>
        /// The C data register on the AMD64 processor.
        /// </summary>
        REGISTER_AMD64_RCX = 4,
        REGISTER_ARM64_X1 = 4,

        /// <summary>
        /// Data register R2 on the ARM processor.
        /// </summary>
        REGISTER_ARM_R2 = 4,

        /// <summary>
        /// The C data register on the x86 processor.
        /// </summary>
        REGISTER_X86_ECX = 4,

        /// <summary>
        /// The D data register on the AMD64 processor.
        /// </summary>
        REGISTER_AMD64_RDX = 5,
        REGISTER_ARM64_X2 = 5,

        /// <summary>
        /// Data register R3 on the ARM processor.
        /// </summary>
        REGISTER_ARM_R3 = 5,

        /// <summary>
        /// The D data register on the x86 processor.
        /// </summary>
        REGISTER_X86_EDX = 5,

        /// <summary>
        /// The B data register on the AMD64 processor.
        /// </summary>
        REGISTER_AMD64_RBX = 6,
        REGISTER_ARM64_X3 = 6,

        /// <summary>
        /// Register R4 on the ARM processor.
        /// </summary>
        REGISTER_ARM_R4 = 6,

        /// <summary>
        /// The B data register on the x86 processor.
        /// </summary>
        REGISTER_X86_EBX = 6,

        /// <summary>
        /// The source index register on the AMD64 processor.
        /// </summary>
        REGISTER_AMD64_RSI = 7,
        REGISTER_ARM64_X4 = 7,

        /// <summary>
        /// Register R5 on the ARM processor.
        /// </summary>
        REGISTER_ARM_R5 = 7,

        /// <summary>
        /// The source index register on the x86 processor.
        /// </summary>
        REGISTER_X86_ESI = 7,

        /// <summary>
        /// The destination index register on the AMD64 processor.
        /// </summary>
        REGISTER_AMD64_RDI = 8,
        REGISTER_ARM64_X5 = 8,

        /// <summary>
        /// Register R6 on the ARM processor.
        /// </summary>
        REGISTER_ARM_R6 = 8,

        /// <summary>
        /// The destination index register on the x86 processor.
        /// </summary>
        REGISTER_X86_EDI = 8,

        /// <summary>
        /// The #8 data register on the AMD64 processor.
        /// </summary>
        REGISTER_AMD64_R8 = 9,
        REGISTER_ARM64_X6 = 9,

        /// <summary>
        /// Register R7 (the THUMB frame pointer) on the ARM processor.
        /// </summary>
        REGISTER_ARM_R7 = 9,

        /// <summary>
        /// The stack register 0 on the x86 floating-point (FP) processor.
        /// </summary>
        REGISTER_X86_FPSTACK_0 = 9,

        /// <summary>
        /// The #9 data register on the AMD64 processor.
        /// </summary>
        REGISTER_AMD64_R9 = 10, // 0x0000000A
        REGISTER_ARM64_X7 = 10, // 0x0000000A

        /// <summary>
        /// Register R8 on the ARM processor.
        /// </summary>
        REGISTER_ARM_R8 = 10, // 0x0000000A

        /// <summary>
        /// The #1 stack register on the x86 FP processor.
        /// </summary>
        REGISTER_X86_FPSTACK_1 = 10, // 0x0000000A

        /// <summary>
        /// The #10 data register on the AMD64 processor.
        /// </summary>
        REGISTER_AMD64_R10 = 11, // 0x0000000B
        REGISTER_ARM64_X8 = 11, // 0x0000000B

        /// <summary>
        /// Register R9 on the ARM processor.
        /// </summary>
        REGISTER_ARM_R9 = 11, // 0x0000000B

        /// <summary>
        /// The #2 stack register on the x86 FP processor.
        /// </summary>
        REGISTER_X86_FPSTACK_2 = 11, // 0x0000000B

        /// <summary>
        /// The #11 data register on the AMD64 processor.
        /// </summary>
        REGISTER_AMD64_R11 = 12, // 0x0000000C
        REGISTER_ARM64_X9 = 12, // 0x0000000C

        /// <summary>
        /// Register R10 on the ARM processor.
        /// </summary>
        REGISTER_ARM_R10 = 12, // 0x0000000C

        /// <summary>
        /// The #3 stack register on the x86 FP processor.
        /// </summary>
        REGISTER_X86_FPSTACK_3 = 12, // 0x0000000C

        /// <summary>
        /// The #12 data register on the AMD64 processor.
        /// </summary>
        REGISTER_AMD64_R12 = 13, // 0x0000000D
        REGISTER_ARM64_X10 = 13, // 0x0000000D

        /// <summary>
        /// The frame pointer on the ARM processor.
        /// </summary>
        REGISTER_ARM_R11 = 13, // 0x0000000D

        /// <summary>
        /// The #4 stack register on the x86 FP processor.
        /// </summary>
        REGISTER_X86_FPSTACK_4 = 13, // 0x0000000D

        /// <summary>
        /// The #13 data register on the AMD64 processor.
        /// </summary>
        REGISTER_AMD64_R13 = 14, // 0x0000000E
        REGISTER_ARM64_X11 = 14, // 0x0000000E

        /// <summary>
        /// Register R12 on the ARM processor.
        /// </summary>
        REGISTER_ARM_R12 = 14, // 0x0000000E

        /// <summary>
        /// The #5 stack register on the x86 FP processor.
        /// </summary>
        REGISTER_X86_FPSTACK_5 = 14, // 0x0000000E

        /// <summary>
        /// The #14 data register on the AMD64 processor.
        /// </summary>
        REGISTER_AMD64_R14 = 15, // 0x0000000F
        REGISTER_ARM64_X12 = 15, // 0x0000000F

        /// <summary>
        /// The link register (R14) on the ARM processor.
        /// </summary>
        REGISTER_ARM_LR = 15, // 0x0000000F

        /// <summary>
        /// The #6 stack register on the x86 FP processor.
        /// </summary>
        REGISTER_X86_FPSTACK_6 = 15, // 0x0000000F

        /// <summary>
        /// The #15 data register on the AMD64 processor.
        /// </summary>
        REGISTER_AMD64_R15 = 16, // 0x00000010
        REGISTER_ARM64_X13 = 16, // 0x00000010

        /// <summary>
        /// The #7 stack register on the x86 FP processor.
        /// </summary>
        REGISTER_X86_FPSTACK_7 = 16, // 0x00000010

        /// <summary>
        /// The #0 multimedia register on the AMD64 processor.
        /// </summary>
        REGISTER_AMD64_XMM0 = 17, // 0x00000011
        REGISTER_ARM64_X14 = 17, // 0x00000011

        /// <summary>
        /// The #1 multimedia register on the AMD64 processor.
        /// </summary>
        REGISTER_AMD64_XMM1 = 18, // 0x00000012
        REGISTER_ARM64_X15 = 18, // 0x00000012

        /// <summary>
        /// The #2 multimedia register on the AMD64 processor.
        /// </summary>
        REGISTER_AMD64_XMM2 = 19, // 0x00000013
        REGISTER_ARM64_X16 = 19, // 0x00000013

        /// <summary>
        /// The #3 multimedia register on the AMD64 processor.
        /// </summary>
        REGISTER_AMD64_XMM3 = 20, // 0x00000014
        REGISTER_ARM64_X17 = 20, // 0x00000014

        /// <summary>
        /// The #4 multimedia register on the AMD64 processor.
        /// </summary>
        REGISTER_AMD64_XMM4 = 21, // 0x00000015
        REGISTER_ARM64_X18 = 21, // 0x00000015

        /// <summary>
        /// The #5 multimedia register on the AMD64 processor.
        /// </summary>
        REGISTER_AMD64_XMM5 = 22, // 0x00000016
        REGISTER_ARM64_X19 = 22, // 0x00000016

        /// <summary>
        /// The #6 multimedia register on the AMD64 processor.
        /// </summary>
        REGISTER_AMD64_XMM6 = 23, // 0x00000017
        REGISTER_ARM64_X20 = 23, // 0x00000017

        /// <summary>
        /// The #7 multimedia register on the AMD64 processor.
        /// </summary>
        REGISTER_AMD64_XMM7 = 24, // 0x00000018
        REGISTER_ARM64_X21 = 24, // 0x00000018

        /// <summary>
        /// The #8 multimedia register on the AMD64 processor.
        /// </summary>
        REGISTER_AMD64_XMM8 = 25, // 0x00000019
        REGISTER_ARM64_X22 = 25, // 0x00000019

        /// <summary>
        /// The #9 multimedia register on the AMD64 processor.
        /// </summary>
        REGISTER_AMD64_XMM9 = 26, // 0x0000001A
        REGISTER_ARM64_X23 = 26, // 0x0000001A

        /// <summary>
        /// The #10 multimedia register on the AMD64 processor.
        /// </summary>
        REGISTER_AMD64_XMM10 = 27, // 0x0000001B
        REGISTER_ARM64_X24 = 27, // 0x0000001B

        /// <summary>
        /// The #11 multimedia register on the AMD64 processor.
        /// </summary>
        REGISTER_AMD64_XMM11 = 28, // 0x0000001C
        REGISTER_ARM64_X25 = 28, // 0x0000001C

        /// <summary>
        /// The #12 multimedia register on the AMD64 processor.
        /// </summary>
        REGISTER_AMD64_XMM12 = 29, // 0x0000001D
        REGISTER_ARM64_X26 = 29, // 0x0000001D

        /// <summary>
        /// The #13 multimedia register on the AMD64 processor.
        /// </summary>
        REGISTER_AMD64_XMM13 = 30, // 0x0000001E
        REGISTER_ARM64_X27 = 30, // 0x0000001E

        /// <summary>
        /// The #14 multimedia register on the AMD64 processor.
        /// </summary>
        REGISTER_AMD64_XMM14 = 31, // 0x0000001F
        REGISTER_ARM64_X28 = 31, // 0x0000001F

        /// <summary>
        /// The #15 multimedia register on the AMD64 processor.
        /// </summary>
        REGISTER_AMD64_XMM15 = 32, // 0x00000020
        REGISTER_ARM64_LR = 32, // 0x00000020

        /// <summary>
        /// The #0 FP data register on the IA-64 processor.
        /// </summary>
        REGISTER_IA64_F0 = 131 // 0x00000083
    }
}