﻿using System.Diagnostics;

namespace ClrDebug
{
    /// <summary>
    /// Contains information that is used when installing a module or a composite image.
    /// </summary>
    [DebuggerDisplay("Major = {Major}, Minor = {Minor}, Sub = {Sub}, Build = {Build}")]
    public struct CVStruct
    {
        /// <summary>
        /// Major version build number.
        /// </summary>
        public short Major;

        /// <summary>
        /// Minor version build number.
        /// </summary>
        public short Minor;

        /// <summary>
        /// Sub-build number.
        /// </summary>
        public short Sub;

        /// <summary>
        /// Build number.
        /// </summary>
        public short Build;
    }
}
