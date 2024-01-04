using System.Diagnostics;

namespace ClrDebug.DbgEng
{
    /// <summary>
    /// Encapsulates the results of the <see cref="SvcSymbolSetSourceFileChecksums.GetLegacySourceFileChecksum"/> method.
    /// </summary>
    [DebuggerDisplay("pChecksumKind = {pChecksumKind.ToString(),nq}, pChecksum = {pChecksum}")]
    public struct GetLegacySourceFileChecksumResult
    {
        public SvcChecksumKind pChecksumKind { get; }

        public byte[] pChecksum { get; }

        public GetLegacySourceFileChecksumResult(SvcChecksumKind pChecksumKind, byte[] pChecksum)
        {
            this.pChecksumKind = pChecksumKind;
            this.pChecksum = pChecksum;
        }
    }
}
