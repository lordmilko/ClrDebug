using System.Diagnostics;
using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    /// <summary>
    /// A struct containing information about a particular debug event.
    /// </summary>
    [DebuggerDisplay("DebugEvent = {DebugEvent.ToString(),nq}, EventPosition = {EventPosition.ToString(),nq}, EventSpanEnd = {EventSpanEnd.ToString(),nq}")]
    [StructLayout(LayoutKind.Sequential)]
    public struct ScriptDebugEventInformation
    {
        public ScriptDebugEvent DebugEvent;

        /// <summary>
        /// The line/column of script at which the debug event occurred (0 values : cannot determine)
        /// </summary>
        public ScriptDebugPosition EventPosition;

        /// <summary>
        /// The ending line/column of script at which the debug event occurred (0 values : cannot determine)
        /// </summary>
        public ScriptDebugPosition EventSpanEnd;

        public Union u;

        [StructLayout(LayoutKind.Explicit)]
        public struct Union
        {
            [FieldOffset(0)]
            public ExceptionInformation ExceptionInformation;

            [FieldOffset(0)]
            public BreakpointInformation BreakpointInformation;
        }

        [DebuggerDisplay("IsUncaught = {IsUncaught}")]
        public struct ExceptionInformation
        {
            //Not sure how we'd go trying to union a bool that needs special marshalling, so we'll just use byte
            public byte IsUncaught; //bool
        }

        [DebuggerDisplay("BreakpointId = {BreakpointId}")]
        public struct BreakpointInformation
        {
            public long BreakpointId;
        }
    }
}
