using System.Diagnostics;

namespace ClrDebug.DbgEng
{
    /// <summary>
    /// Encapsulates the results of the <see cref="DebugHostFunctionIntrospection.FindSourceLocationByRVA"/> method.
    /// </summary>
    [DebuggerDisplay("sourceFile = {sourceFile}, sourceLine = {sourceLine}")]
    public struct FindSourceLocationByRVAResult
    {
        public string sourceFile { get; }

        public long sourceLine { get; }

        public FindSourceLocationByRVAResult(string sourceFile, long sourceLine)
        {
            this.sourceFile = sourceFile;
            this.sourceLine = sourceLine;
        }
    }
}
