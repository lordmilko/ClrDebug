using System.Diagnostics;

namespace ClrDebug.DbgEng
{
    /// <summary>
    /// Encapsulates the results of the <see cref="SvcSymbolMultipleLocations.GetLocations"/> method.
    /// </summary>
    [DebuggerDisplay("pLocation = {pLocation}, pSize = {pSize}")]
    public struct GetLocationsResult
    {
        public SvcSymbolLocation[] pLocation { get; }

        public long pSize { get; }

        public GetLocationsResult(SvcSymbolLocation[] pLocation, long pSize)
        {
            this.pLocation = pLocation;
            this.pSize = pSize;
        }
    }
}
