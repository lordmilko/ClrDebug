using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    [StructLayout(LayoutKind.Sequential)]
    public struct INLINE_FRAME_CONTEXT
    {
        //This structure must not be explicit, as the CLR will get confused when marshalling STACKFRAME_EX if any of the
        //fields within it are explicit, causing memory values to be placed into the wrong fields.

        public int ContextValue;

        public byte FrameId => (byte) (ContextValue & 0xFF);

        public STACK_FRAME_TYPE FrameType => (STACK_FRAME_TYPE) ((ContextValue >> 8) & 0xFF);

        public short FrameSignature => (short) (ContextValue >> 16);
    }
}
