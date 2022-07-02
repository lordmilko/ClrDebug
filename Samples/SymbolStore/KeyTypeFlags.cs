using System;

namespace SymStore
{
    /// <summary>
    /// Type of keys to generate
    /// </summary>
    [Flags]
    public enum KeyTypeFlags
    {
        /// <summary>
        /// No keys.
        /// </summary>
        None = 0x00,

        /// <summary>
        /// Generate the key of the binary or file itself.
        /// </summary>
        IdentityKey = 0x01,

        /// <summary>
        /// Generate the symbol key of the binary (if one).
        /// </summary>
        SymbolKey = 0x02,

        /// <summary>
        /// Generate the keys for the DAC/SOS modules for a coreclr module.
        /// </summary>
        ClrKeys = 0x04,

        /// <summary>
        /// Return only the DAC (including any cross-OS DACs) and DBI module 
        /// keys. Does not include any SOS binaries.
        /// </summary>
        DacDbiKeys = 0x20,

        /// <summary>
        /// Include the runtime modules (coreclr.dll, clrjit.dll, clrgc.dll, 
        /// libcoreclr.so, libclrjit.so, libcoreclr.dylib, etc.)
        /// </summary>
        RuntimeKeys = 0x40
    }
}