using System.Diagnostics;

namespace ClrDebug.DbgEng
{
    /// <summary>
    /// Encapsulates the results of the <see cref="DebugHostSymbol.CompilerInformation"/> property.
    /// </summary>
    [DebuggerDisplay("pCompilerId = {pCompilerId.ToString(),nq}, pCompilerString = {pCompilerString}")]
    public struct GetCompilerInformationResult
    {
        public KnownCompiler pCompilerId { get; }

        public string pCompilerString { get; }

        public GetCompilerInformationResult(KnownCompiler pCompilerId, string pCompilerString)
        {
            this.pCompilerId = pCompilerId;
            this.pCompilerString = pCompilerString;
        }
    }
}
