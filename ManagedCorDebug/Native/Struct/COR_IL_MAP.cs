using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    /// <summary>
    /// Specifies changes in the relative offset of a function.
    /// </summary>
    /// <remarks>
    /// The format of the map is as follows: The debugger will assume that oldOffset refers to an MSIL offset within the
    /// original, unmodified MSIL code. The newOffset parameter refers to the corresponding MSIL offset within the new,
    /// instrumented code. For stepping to work properly, the following requirements should be met: The map does not interpolate
    /// missing entries. The following example shows a map and its results. Map: Results:
    /// </remarks>
    [StructLayout(LayoutKind.Sequential, Pack = 4)]
    public struct COR_IL_MAP
    {
        /// <summary>
        /// The old Microsoft intermediate language (MSIL) offset relative to the beginning of the function.
        /// </summary>
        public int oldOffset;

        /// <summary>
        /// The new MSIL offset relative to the beginning of the function.
        /// </summary>
        public int newOffset;

        /// <summary>
        /// true if the mapping is known to be accurate; otherwise, false.
        /// </summary>
        public int fAccurate;
    }
}