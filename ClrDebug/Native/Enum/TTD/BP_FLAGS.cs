using System;

namespace ClrDebug.TTD
{
    //TTDReplay (Undocumented)
    //Not clear what the basis for the enum name/fields are

    [Flags]
    public enum BP_FLAGS : byte
    {
        READ = 1,
        WRITE = 2,
        EXEC = 4
    }
}
