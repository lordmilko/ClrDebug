using System;
using System.Diagnostics;

namespace ClrDebug
{
    /// <summary>
    /// Contains values that describe the metadata applied to an assembly compilation.
    /// </summary>
    [Flags]
    public enum CorAssemblyFlags
    {
        /// <summary>
        /// Indicates that the assembly reference holds the full, unhashed public key.
        /// </summary>
        afPublicKey = 0x0001,

        /// <summary>
        /// Indicates that the processor architecture is unspecified.
        /// </summary>
        afPA_None = 0x0000,

        /// <summary>
        /// Indicates that the processor architecture is neutral (PE32).
        /// </summary>
        afPA_MSIL = 0x0010,

        /// <summary>
        /// Indicates that the processor architecture is x86 (PE32).
        /// </summary>
        afPA_x86 = 0x0020,

        /// <summary>
        /// Indicates that the processor architecture is Itanium (PE32+).
        /// </summary>
        afPA_IA64 = 0x0030,

        /// <summary>
        /// Indicates that the processor architecture is AMD X64 (PE32+).
        /// </summary>
        afPA_AMD64 = 0x0040,

        /// <summary>
        /// Indicates that the processor architecture is ARM (PE32).
        /// </summary>
        afPA_ARM = 0x0050,

        /// <summary>
        /// Indicates that the processor architecture is AMD X64 (PE32+).
        /// </summary>
        afPA_ARM64 = 0x0060,

        /// <summary>
        /// Indicates that the assembly is a reference assembly; that is, it applies to any architecture but cannot run on any
        /// architecture. Thus, the flag is the same as <see cref="afPA_Mask"/>.
        /// </summary>
        afPA_NoPlatform = 0x0070,

        /// <summary>
        /// Indicates that the processor architecture flags should be propagated to the AssemblyRef record.
        /// </summary>
        afPA_Specified = 0x0080,

        /// <summary>
        /// A mask that describes the processor architecture.
        /// </summary>
        afPA_Mask = 0x0070,

        /// <summary>
        /// Specifies that the processor architecture description is included.
        /// </summary>
        afPA_FullMask = 0x00F0,

        /// <summary>
        /// Indicates a shift count in the processor architecture flags to and from the index.
        /// </summary>
        afPA_Shift = 0x0004,

        /// <summary>
        /// Indicates the corresponding value from the <see cref="DebuggableAttribute.DebuggingModes"/> of the <see cref="DebuggableAttribute"/>.
        /// </summary>
        afEnableJITcompileTracking = 0x8000,

        /// <summary>
        /// Indicates the corresponding value from the <see cref="DebuggableAttribute.DebuggingModes"/> of the <see cref="DebuggableAttribute"/>.
        /// </summary>
        afDisableJITcompileOptimizer = 0x4000,

        afDebuggableAttributeMask = 0xc000,

        /// <summary>
        /// Indicates that the assembly can be retargeted at run time to an assembly from a different publisher.
        /// </summary>
        afRetargetable = 0x0100,

        /// <summary>
        /// Indicates the default content type.
        /// </summary>
        afContentType_Default = 0x0000,

        /// <summary>
        /// Indicates the Windows Runtime content type.
        /// </summary>
        afContentType_WindowsRuntime = 0x0200,

        /// <summary>
        /// A mask that describes the content type.
        /// </summary>
        afContentType_Mask = 0x0E00
    }
}
