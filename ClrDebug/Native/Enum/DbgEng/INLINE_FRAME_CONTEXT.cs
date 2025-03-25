using System.Diagnostics;
using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    /// <summary>
    /// Describes inline frame context.
    /// </summary>
    [DebuggerDisplay("FrameId = {FrameId}, FrameType = {FrameType}, FrameSignature = {FrameSignature}")]
    [StructLayout(LayoutKind.Sequential)]
    public struct INLINE_FRAME_CONTEXT
    {
        //This structure must not be explicit, as the CLR will get confused when marshalling STACKFRAME_EX if any of the
        //fields within it are explicit, causing memory values to be placed into the wrong fields.

        /// <summary>
        /// A context value.
        /// </summary>
        public int ContextValue;

        public byte FrameId => (byte) (ContextValue & 0xFF);

        public STACK_FRAME_TYPE FrameType => (STACK_FRAME_TYPE) ((ContextValue >> 8) & 0xFF);

        //On the first call to SymInitialize, DbgHelp does GetSystemTimeAsFileTime and stores the dwLowDateTime in a global variable.
        //When parsing inline frame contexts, DbgHelp will compare this value against its global variable to confirm that this context
        //did indeed come from DbgHelp and wasn't just synthesized by the user
        public short FrameSignature => (short) (ContextValue >> 16);
    }
}
