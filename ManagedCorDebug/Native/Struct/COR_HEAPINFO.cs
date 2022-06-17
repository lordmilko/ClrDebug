using System.Diagnostics;
using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    /// <summary>
    /// Provides general information about the garbage collection heap, including whether it is enumerable.
    /// </summary>
    /// <remarks>
    /// An instance of the <see cref="COR_HEAPINFO"/> structure is returned by calling the <see cref="ICorDebugProcess5.GetGCHeapInformation"/>
    /// method. Before enumerating objects on the garbage collection heap, you must always check the areGCStructuresValid
    /// field to ensure that the heap is in an enumerable state. For more information, see the <see cref="ICorDebugProcess5.GetGCHeapInformation"/>
    /// method.
    /// </remarks>
    [DebuggerDisplay("areGCStructuresValid = {areGCStructuresValid}, pointerSize = {pointerSize}, numHeaps = {numHeaps}, concurrent = {concurrent}, gcType = {gcType.ToString(),nq}")]
    [StructLayout(LayoutKind.Sequential, Pack = 4)]
    public struct COR_HEAPINFO
    {
        /// <summary>
        /// true if garbage collection structures are valid and the heap can be enumerated; otherwise, false.
        /// </summary>
        public int areGCStructuresValid;

        /// <summary>
        /// The size, in bytes, of pointers on the target architecture.
        /// </summary>
        public int pointerSize;

        /// <summary>
        /// The number of logical garbage collection heaps in the process.
        /// </summary>
        public int numHeaps;

        /// <summary>
        /// TRUE if concurrent (background) garbage collection is enabled; otherwise, FALSE.
        /// </summary>
        public int concurrent;

        /// <summary>
        /// A member of the <see cref="CorDebugGCType"/> enumeration that indicates whether the garbage collector is running on a workstation or a server.
        /// </summary>
        public CorDebugGCType gcType;
    }
}
