using System.Diagnostics;

namespace ClrDebug.DbgEng
{
    /// <summary>
    /// Encapsulates the results of the <see cref="SvcSymbolSetSourceFileChecksums.GetLegacySourceFileChecksumInformation"/> method.
    /// </summary>
    [DebuggerDisplay("pChecksumKind = {pChecksumKind.ToString(),nq}, pChecksumSize = {pChecksumSize}")]
    public struct GetLegacySourceFileChecksumInformationResult
    {
        public SvcChecksumKind pChecksumKind { get; }

        public int pChecksumSize { get; }

        public GetLegacySourceFileChecksumInformationResult(SvcChecksumKind pChecksumKind, int pChecksumSize)
        {
            this.pChecksumKind = pChecksumKind;
            this.pChecksumSize = pChecksumSize;
        }
    }
}
