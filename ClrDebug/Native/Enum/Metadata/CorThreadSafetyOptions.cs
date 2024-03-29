﻿namespace ClrDebug
{
    /// <summary>
    /// Specifies flags to select options for thread safety.<para/>
    /// Used with <see cref="MetaDataDispenserOption.MetaDataThreadSafetyOptions"/>.
    /// </summary>
    public enum CorThreadSafetyOptions
    {
        /// <summary>
        /// Default value. Same as MDThreadSafetyOff.
        /// </summary>
        MDThreadSafetyDefault = 0x00000000,

        /// <summary>
        /// Indicates that a reader/writer lock cannot be set.
        /// </summary>
        MDThreadSafetyOff = 0x00000000,

        /// <summary>
        /// Indicates that a reader/writer lock can be set.
        /// </summary>
        MDThreadSafetyOn = 0x00000001,
    }
}
