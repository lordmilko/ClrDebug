using System.Diagnostics;

namespace ClrDebug.DbgEng
{
    /// <summary>
    /// Encapsulates the results of the <see cref="SvcSymbolVariantInfo.IsDiscriminated"/> property.
    /// </summary>
    [DebuggerDisplay("pIsDiscriminated = {pIsDiscriminated}, ppDiscriminator = {ppDiscriminator?.ToString(),nq}")]
    public struct IsDiscriminatedResult
    {
        public bool pIsDiscriminated { get; }

        public SvcSymbol ppDiscriminator { get; }

        public IsDiscriminatedResult(bool pIsDiscriminated, SvcSymbol ppDiscriminator)
        {
            this.pIsDiscriminated = pIsDiscriminated;
            this.ppDiscriminator = ppDiscriminator;
        }
    }
}
