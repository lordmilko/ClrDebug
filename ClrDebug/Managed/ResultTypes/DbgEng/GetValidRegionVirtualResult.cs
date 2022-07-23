using System.Diagnostics;

namespace ClrDebug.DbgEng
{
    /// <summary>
    /// Encapsulates the results of the <see cref="DebugDataSpaces.GetValidRegionVirtual"/> method.
    /// </summary>
    [DebuggerDisplay("ValidBase = {ValidBase}, ValidSize = {ValidSize}")]
    public struct GetValidRegionVirtualResult
    {
        /// <summary>
        /// Receives the address of the beginning of the found valid memory.
        /// </summary>
        public long ValidBase { get; }

        /// <summary>
        /// Receives the size, in bytes, of the valid memory.
        /// </summary>
        public int ValidSize { get; }

        public GetValidRegionVirtualResult(long validBase, int validSize)
        {
            ValidBase = validBase;
            ValidSize = validSize;
        }
    }
}
