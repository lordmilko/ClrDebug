using System;

namespace ManagedCorDebug
{
    /// <summary>
    /// Contains values that describe run-time features of an assembly.
    /// </summary>
    /// <remarks>
    /// The values between 0x0010 and 0x0070, inclusive, are used to describe side-by-side compatibility features of the
    /// referenced assembly. If none of these values are set, the assembly is assumed to be side-by-side compatible.
    /// </remarks>
    [Flags]
    public enum AssemblyFlags
    {
        /// <summary>
        /// Specifies that exported type definitions are implicit within the files that comprise the assembly. In the .NET Framework versions 1.0 and 1.1, this value is always assumed to be set.
        /// </summary>
        afImplicitExportedTypes = 0x0001,

        /// <summary>
        /// Specifies that resource definitions are implicit within the files that comprise the assembly. In the .NET Framework 1.0 and 1.1, this value is always assumed to be set.
        /// </summary>
        afImplicitResources = 0x0002,

        /// <summary>
        /// Specifies that the assembly cannot execute with other versions if they are running in the same application domain.
        /// </summary>
        afNonSideBySideAppDomain = 0x0010,

        /// <summary>
        /// Specifies that the assembly cannot execute with other versions if they are running in the same process.
        /// </summary>
        afNonSideBySideProcess = 0x0020,

        /// <summary>
        /// Specifies that the assembly cannot execute with other versions if they are running on the same computer.
        /// </summary>
        afNonSideBySideMachine = 0x0030
    }
}