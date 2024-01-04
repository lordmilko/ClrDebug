using System.Diagnostics;

namespace ClrDebug.DbgEng
{
    /// <summary>
    /// Encapsulates the results of the <see cref="SvcSymbolCompilationUnit.Language"/> property.
    /// </summary>
    [DebuggerDisplay("language = {language.ToString(),nq}, version = {version}")]
    public struct GetLanguageResult
    {
        public SvcSourceLanguage language { get; }

        public int version { get; }

        public GetLanguageResult(SvcSourceLanguage language, int version)
        {
            this.language = language;
            this.version = version;
        }
    }
}
