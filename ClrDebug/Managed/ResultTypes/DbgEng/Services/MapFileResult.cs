using System;
using System.Diagnostics;

namespace ClrDebug.DbgEng
{
    /// <summary>
    /// Encapsulates the results of the <see cref="SvcDebugSourceFileMapping.MapFile"/> method.
    /// </summary>
    [DebuggerDisplay("mapAddress = {mapAddress.ToString(),nq}, mapSize = {mapSize}")]
    public struct MapFileResult
    {
        public IntPtr mapAddress { get; }

        public long mapSize { get; }

        public MapFileResult(IntPtr mapAddress, long mapSize)
        {
            this.mapAddress = mapAddress;
            this.mapSize = mapSize;
        }
    }
}
