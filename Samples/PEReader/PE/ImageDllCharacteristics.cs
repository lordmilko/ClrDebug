using System;

namespace PEReader.PE
{
    /// <summary>
    /// Represents the IMAGE_DLLCHARACTERISTICS_HIGH_* enumeration which specifies the DLL characteristics of an IMAGE_OPTIONAL_HEADER.
    /// </summary>
    [Flags]
    public enum ImageDllCharacteristics : ushort
    {
        ProcessInit = 1,
        ProcessTerm = 2,
        ThreadInit = 4,
        ThreadTerm = 8,
        HighEntropyVirtualAddressSpace = 32,
        DynamicBase = 64,
        NxCompatible = 256,
        NoIsolation = 512,
        NoSeh = 1024,
        NoBind = 2048,
        AppContainer = 4096,
        WdmDriver = 8192,
        TerminalServerAware = 32768,
    }
}