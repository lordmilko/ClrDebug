using System.Diagnostics;

namespace ClrDebug.DbgEng
{
    /// <summary>
    /// Encapsulates the results of the <see cref="DebugHostModule.PrimaryCompilerInformation"/> property.
    /// </summary>
    [DebuggerDisplay("pCompilerId = {pCompilerId.ToString(),nq}, pPrimaryCompilerString = {pPrimaryCompilerString}")]
    public struct GetPrimaryCompilerInformationResult
    {
        public KnownCompiler pCompilerId { get; }

        public string pPrimaryCompilerString { get; }

        public GetPrimaryCompilerInformationResult(KnownCompiler pCompilerId, string pPrimaryCompilerString)
        {
            this.pCompilerId = pCompilerId;
            this.pPrimaryCompilerString = pPrimaryCompilerString;
        }
    }
}
