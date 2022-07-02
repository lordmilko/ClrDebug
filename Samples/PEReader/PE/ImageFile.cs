using System;

namespace PEReader.PE
{
    /// <summary>
    /// Represents the IMAGE_FILE_* enumeration which specifies characteristics of an IMAGE_FILE_HEADER.
    /// </summary>
    [Flags]
    public enum ImageFile : ushort
    {
        RelocsStripped = 1,
        ExecutableImage = 2,
        LineNumsStripped = 4,
        LocalSymsStripped = 8,
        AggressiveWSTrim = 16,
        LargeAddressAware = 32,
        BytesReversedLo = 128,
        Bit32Machine = 256,
        DebugStripped = 512,
        RemovableRunFromSwap = 1024,
        NetRunFromSwap = 2048,
        System = 4096,
        Dll = 8192,
        UpSystemOnly = 16384,
        BytesReversedHi = 32768,
    }
}