using System;

namespace ClrDebug
{
    /// <summary>
    /// Specifies flags to select options for the metadata linker.<para/>
    /// Used with <see cref="MetaDataDispenserOption.MetaDataLinkerOptions"/>.
    /// </summary>
    [Flags]
    public enum CorLinkerOptions
    {
        /// <summary>
        /// The private types and global functions are not preserved.
        /// </summary>
        MDAssembly = 0x00000000,

        /// <summary>
        /// The private types and global functions are preserved.
        /// </summary>
        MDNetModule = 0x00000001,
    }
}
