using System;

namespace ClrDebug
{
    [Flags]
    public enum ReadyToRunImportSectionFlags : short
    {
        None     = 0x0000,
        Eager    = 0x0001, // Section at module load time.
        PCode    = 0x0004, // Section contains pointers to code
    }
}
