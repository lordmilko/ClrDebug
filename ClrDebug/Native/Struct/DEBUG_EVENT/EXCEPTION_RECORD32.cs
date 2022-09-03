using System.Diagnostics;

namespace ClrDebug
{
    [DebuggerDisplay("ExceptionCode = {ExceptionCode.ToString(),nq}, ExceptionFlags = {ExceptionFlags.ToString(),nq}, ExceptionRecord = {ExceptionRecord}, ExceptionAddress = {ExceptionAddress}, NumberParameters = {NumberParameters}, ExceptionInformation = {ExceptionInformation}")]
    public unsafe struct EXCEPTION_RECORD32
    {
        public NTSTATUS ExceptionCode;
        public ExceptionFlags ExceptionFlags;
        public int ExceptionRecord;
        public int ExceptionAddress;
        public int NumberParameters;
        public fixed int ExceptionInformation[15];
    }
}
