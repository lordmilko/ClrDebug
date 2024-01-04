using System.Diagnostics;

namespace ClrDebug.DbgEng
{
    /// <summary>
    /// Encapsulates the results of the <see cref="SvcEventArgumentsSymbolCacheInvalidate.SymbolsInformation"/> property.
    /// </summary>
    [DebuggerDisplay("module = {module?.ToString(),nq}, symbolSet = {symbolSet?.ToString(),nq}")]
    public struct GetSymbolsInformationResult
    {
        public SvcModule module { get; }

        public SvcSymbolSet symbolSet { get; }

        public GetSymbolsInformationResult(SvcModule module, SvcSymbolSet symbolSet)
        {
            this.module = module;
            this.symbolSet = symbolSet;
        }
    }
}
