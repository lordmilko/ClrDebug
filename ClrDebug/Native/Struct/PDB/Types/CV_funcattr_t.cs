﻿using System.Diagnostics;
using static ClrDebug.Extensions;

namespace ClrDebug.PDB
{
    /// <summary>
    /// function flags
    /// </summary>
    [DebuggerDisplay("cxxreturnudt = {cxxreturnudt}, ctor = {ctor}, ctorvbase = {ctorvbase}, unused = {unused}, flags = {flags}")]
    public struct CV_funcattr_t
    {
        /// <summary>
        /// true if C++ style ReturnUDT
        /// </summary>
        public bool cxxreturnudt
        {
            get => GetBitFlag(flags, 0);
            set => SetBitFlag(ref flags, 0, value);
        }

        /// <summary>
        /// true if func is an instance constructor
        /// </summary>
        public bool ctor
        {
            get => GetBitFlag(flags, 1);
            set => SetBitFlag(ref flags, 1, value);
        }

        /// <summary>
        /// true if func is an instance constructor of a class with virtual bases
        /// </summary>
        public bool ctorvbase
        {
            get => GetBitFlag(flags, 2);
            set => SetBitFlag(ref flags, 2, value);
        }

        /// <summary>
        /// unused
        /// </summary>
        public byte unused
        {
            get => GetBits(flags, 3, 5); //3-7
            set => SetBits(ref flags, 3, 5, value);
        }

        public byte flags;
    }
}
