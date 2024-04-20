using System;

namespace ClrDebug
{
    //https://en.wikipedia.org/wiki/FLAGS_register

    /// <summary>
    /// Describes flags found in the EFLAGS member of <see cref="X86_CONTEXT"/> and <see cref="AMD64_CONTEXT"/>.
    /// </summary>
    [Flags]
    public enum X86_CONTEXT_FLAGS : uint
    {
        /// <summary>
        /// Carry flag
        /// =1 CY (Carry)
        /// =0 NC (NoCarry)
        /// </summary>
        CF = 0x1,

        /// <summary>
        /// Reserved. Always 1 in EFLAGS.
        /// </summary>
        Reserved1 = 0x2,

        /// <summary>
        /// Parity flag
        /// =1 PE (Parity Even)
        /// =0 PO (Parity Odd)
        /// </summary>
        PF = 0x4,

        /// <summary>
        /// Auxiliary Carry flag
        /// =1 AC (Auxiliary Carry)
        /// =0 NA (No Auxiliary Carry)
        /// </summary>
        AF = 0x10,

        /// <summary>
        /// Zero flag
        /// =1 ZR (Zero)
        /// =0 NZ (Not Zero)
        /// </summary>
        ZF = 0x40,

        /// <summary>
        /// Sign flag
        /// =1 NG (Negative)
        /// =0 PL (Positive)
        /// </summary>
        SF = 0x80,

        /// <summary>
        /// Trap flag
        /// </summary>
        TF = 0x100,

        /// <summary>
        /// Interrupt enable flag
        /// =1 EI (Enable Interrupt)
        /// =0 DI (Disable Interrupt)
        /// </summary>
        IF = 0x200,

        /// <summary>
        /// Direction flag
        /// =1 DN (Down)
        /// =0 UP (Up)
        /// </summary>
        DF = 0x400,

        /// <summary>
        /// Overflow flag
        /// =1 OV (Overflow)
        /// =0 NV (Not Overflow)
        /// </summary>
        OF = 0x800,

        /// <summary>
        /// I/O privilege level
        /// </summary>
        IOPL = 0x3000,

        /// <summary>
        /// Nested task flag
        /// </summary>
        NT = 0x4000,

        /// <summary>
        /// Mode flag
        /// </summary>
        MD = 0x8000,

        /// <summary>
        /// Resume flag
        /// </summary>
        RF = 0x00010000,

        /// <summary>
        /// Virtual 8086 mode flag
        /// </summary>
        VM = 0x00020000,

        /// <summary>
        /// Alignment Check (486+, ring 3)<para/>
        /// SMAP Access Check (Broadwell+, ring 0-2)
        /// </summary>
        AC = 0x00040000,

        /// <summary>
        /// Virtual interrupt pending
        /// </summary>
        VIF = 0x00080000,

        /// <summary>
        /// Virtual interrupt pending
        /// </summary>
        VIP = 0x00100000,

        /// <summary>
        /// Able to use CPUID instruction
        /// </summary>
        ID = 0x00200000,

        /// <summary>
        /// Alternate Instruction Set enabled
        /// </summary>
        AI = 0x80000000
    }
}
