using System;

namespace ClrDebug
{
    /// <summary>
    /// Contains values used to influence behavior during the generation of metadata.<para/>
    /// Used with <see cref="MetaDataDispenserOption.MetaDataSetENC"/>.
    /// </summary>
    [Flags]
    public enum CorSetENC
    {
        /// <summary>
        /// Obsolete.
        /// </summary>
        MDSetENCOn = 0x00000001,   // Deprecated name.

        /// <summary>
        /// Obsolete.
        /// </summary>
        MDSetENCOff = 0x00000002,   // Deprecated name.

        /// <summary>
        /// Indicates that whereas metadata can be updated, tokens cannot be moved.
        /// </summary>
        MDUpdateENC = 0x00000001,   // ENC mode.  Tokens don't move; can be updated.

        /// <summary>
        /// Indicates that tokens can be moved during updates.
        /// </summary>
        MDUpdateFull = 0x00000002,   // "Normal" update mode.

        /// <summary>
        /// Indicates that updates can consist only of additions. Tokens cannot be moved.
        /// </summary>
        MDUpdateExtension = 0x00000003,   // Extension mode.  Tokens don't move, adds only.

        /// <summary>
        /// Indicates that compilation is incremental.
        /// </summary>
        MDUpdateIncremental = 0x00000004,   // Incremental compilation

        /// <summary>
        /// Indicates that only changed metadata should be saved.
        /// </summary>
        MDUpdateDelta = 0x00000005,   // If ENC on, save only deltas.

        /// <summary>
        /// Includes MDUpdateENC, MDUpdateFull and MDUpdateIncremental.
        /// </summary>
        MDUpdateMask = 0x00000007,


    }
}
