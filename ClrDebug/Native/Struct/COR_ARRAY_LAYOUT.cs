﻿using System.Diagnostics;
using System.Runtime.InteropServices;

namespace ClrDebug
{
    /// <summary>
    /// Provides information about the layout of an array object in memory.
    /// </summary>
    /// <remarks>
    /// The rankSize field specifies the size of a rank in a multi-dimensional array. It is accurate for single-dimensional
    /// arrays as well. The value of numRanks is 1 for a single-dimensional array and N for a multi-dimensional array of
    /// N dimensions.
    /// </remarks>
    [DebuggerDisplay("componentID = {componentID.ToString(),nq}, componentType = {componentType.ToString(),nq}, firstElementOffset = {firstElementOffset}, elementSize = {elementSize}, countOffset = {countOffset}, rankSize = {rankSize}, numRanks = {numRanks}, rankOffset = {rankOffset}")]
    [StructLayout(LayoutKind.Sequential, Pack = 8)]
    public struct COR_ARRAY_LAYOUT
    {
        /// <summary>
        /// The identifier of the type of objects that the array contains.
        /// </summary>
        public COR_TYPEID componentID;

        /// <summary>
        /// A <see cref="CorElementType"/> enumeration value that indicates whether the component is a garbage collection reference, a value class, or a primitive.
        /// </summary>
        public CorElementType componentType;

        /// <summary>
        /// The offset to the first element in the array.
        /// </summary>
        public int firstElementOffset;

        /// <summary>
        /// The size of each element.
        /// </summary>
        public int elementSize;

        /// <summary>
        /// The offset to the number of elements in the array.
        /// </summary>
        public int countOffset;

        /// <summary>
        /// The size of the rank, in bytes.
        /// </summary>
        public int rankSize;

        /// <summary>
        /// The number of ranks in the array.
        /// </summary>
        public int numRanks;

        /// <summary>
        /// The offset at which the ranks start.
        /// </summary>
        public int rankOffset;
    }
}
