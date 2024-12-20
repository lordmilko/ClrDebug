namespace ClrDebug.DbgEng
{
    /// <summary>
    /// Defines a level of diagnostic output to a log sink.
    /// </summary>
    public enum DiagnosticLogLevel : uint
    {
        DiagnosticLevelVerboseInfo = 0,
        DiagnosticLevelInfo,
        DiagnosticLevelWarning,
        DiagnosticLevelError
    }
}
