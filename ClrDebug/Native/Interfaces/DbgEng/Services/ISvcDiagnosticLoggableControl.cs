using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("432BEA74-794D-46FB-AC50-EBECA9AA865C")]
    [ComImport]
    public interface ISvcDiagnosticLoggableControl
    {
        [PreserveSig]
        DiagnosticLogLevel GetLoggingLevel();
        
        [PreserveSig]
        void SetLoggingLevel(
            [In] DiagnosticLogLevel level);
    }
}
