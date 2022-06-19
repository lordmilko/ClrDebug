using System;

namespace ManagedCorDebug
{
    /// <summary>
    /// Provides flag values used for registration when installing a module or composite image.
    /// </summary>
    [Flags]
    public enum CorRegFlags
    {
        /// <summary>
        /// Specifies that files should not be copied into the destination.
        /// </summary>
        regNoCopy = 0x00000001,         // Don't copy files into destination

        /// <summary>
        /// Specifies that the module or composite is a configuration.
        /// </summary>
        regConfig = 0x00000002,         // Is a configuration

        /// <summary>
        /// Specifies that the module or composite has class references.
        /// </summary>
        regHasRefs = 0x00000004         // Has class references 
    }
}