using System;

namespace PEReader.PE
{
    /// <summary>
    /// Represents the VS_FF_* enumeration which specifies file flags of a VS_FIXEDFILEINFO.
    /// </summary>
    [Flags]
    public enum FileInfoFlags : uint
    {
        Debug = 0x00000001,
        PreRelease = 0x00000002,
        Patched = 0x00000004,
        PrivateBuild = 0x00000008,
        InfoInferred = 0x00000010,
        SpecialBuild = 0x00000020,
    }
}