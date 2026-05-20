namespace ClrDebug.TTD
{
    /* Based on dbgeng!ProcArchToImageMachine
     *
     * 0: I386
     * 1: R400 | (mysterious value that can be 4 & 1) << 9) | R400
     * 2: ALPHA
     * 3: (mysterious value that can be 4 & 3) == 2 -> unknown machine 0x1F2, else UNKNOWN
     * 4: SH4
     * 5: 0
     *
     * 6: IA64
     * 7: ALPHA64
     * 9: AMD64
     * 12: ARM64
     *
     */

    //in DbgEng x64 rax is xor'd out and then it does +4, and this is bor'd with 0x1C0 if this value is 5.
    //So I would guess that maybe DbgEng x86 doesn't do the +4, making 5 = 0x1C0 or 0x1C4 (ARM or ARMNT)

    //Name is made up
    public enum TtdProcessorKind : ushort
    {
        //Names are made up
        I386 = 0,
        R4000 = 1,
        ALPHA = 2,

        //3 has complex logic

        SH4 = 4,

        //5 seems to map to UNKNOWN

        IA64 = 6,
        ALPHA64 = 7,
        AMD64 = 9,
        ARM64 = 12
    }
}
