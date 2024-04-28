using System.Diagnostics;
using System.Runtime.InteropServices;
using static ClrDebug.Extensions;

namespace ClrDebug.PDB
{
    /// <summary>
    /// local variable flags
    /// </summary>
    [DebuggerDisplay("fIsParam = {fIsParam}, fAddrTaken = {fAddrTaken}, fCompGenx = {fCompGenx}, fIsAggregate = {fIsAggregate}, fIsAggregated = {fIsAggregated}, fIsAliased = {fIsAliased}, fIsAlias = {fIsAlias}, fIsRetValue = {fIsRetValue}, fIsOptimizedOut = {fIsOptimizedOut}, fIsEnregGlob = {fIsEnregGlob}, fIsEnregStat = {fIsEnregStat}, unused = {unused}, flags = {flags}")]
    [StructLayout(LayoutKind.Sequential, Pack = 2)]
    public struct CV_LVARFLAGS
    {
        /// <summary>
        /// variable is a parameter
        /// </summary>
        public bool fIsParam
        {
            get => GetBitFlag(flags, 0);
            set => SetBitFlag(ref flags, 0, value);
        }

        /// <summary>
        /// address is taken
        /// </summary>
        public bool fAddrTaken
        {
            get => GetBitFlag(flags, 1);
            set => SetBitFlag(ref flags, 1, value);
        }

        /// <summary>
        /// variable is compiler generated
        /// </summary>
        public bool fCompGenx
        {
            get => GetBitFlag(flags, 2);
            set => SetBitFlag(ref flags, 2, value);
        }

        /// <summary>
        /// the symbol is splitted in temporaries,
        /// </summary>
        public bool fIsAggregate
        {
            get => GetBitFlag(flags, 3);
            set => SetBitFlag(ref flags, 3, value);
        }

        // which are treated by compiler as
        // independent entities
        /// <summary>
        /// Counterpart of fIsAggregate - tells
        /// </summary>
        public bool fIsAggregated
        {
            get => GetBitFlag(flags, 4);
            set => SetBitFlag(ref flags, 4, value);
        }

        // that it is a part of a fIsAggregate symbol
        /// <summary>
        /// variable has multiple simultaneous lifetimes
        /// </summary>
        public bool fIsAliased
        {
            get => GetBitFlag(flags, 5);
            set => SetBitFlag(ref flags, 5, value);
        }

        /// <summary>
        /// represents one of the multiple simultaneous lifetimes
        /// </summary>
        public bool fIsAlias
        {
            get => GetBitFlag(flags, 6);
            set => SetBitFlag(ref flags, 6, value);
        }

        /// <summary>
        /// represents a function return value
        /// </summary>
        public bool fIsRetValue
        {
            get => GetBitFlag(flags, 7);
            set => SetBitFlag(ref flags, 7, value);
        }

        /// <summary>
        /// variable has no lifetimes
        /// </summary>
        public bool fIsOptimizedOut
        {
            get => GetBitFlag(flags, 8);
            set => SetBitFlag(ref flags, 8, value);
        }

        /// <summary>
        /// variable is an enregistered global
        /// </summary>
        public bool fIsEnregGlob
        {
            get => GetBitFlag(flags, 9);
            set => SetBitFlag(ref flags, 9, value);
        }

        /// <summary>
        /// variable is an enregistered static
        /// </summary>
        public bool fIsEnregStat
        {
            get => GetBitFlag(flags, 10);
            set => SetBitFlag(ref flags, 10, value);
        }

        /// <summary>
        /// must be zero
        /// </summary>
        public short unused
        {
            get => GetBits(flags, 11, 5); //11-15
            set => SetBits(ref flags, 11, 5, value);
        }

        public short flags;
    }
}
