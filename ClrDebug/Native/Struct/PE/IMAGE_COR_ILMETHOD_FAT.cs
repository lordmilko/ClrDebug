using System.Diagnostics;

namespace ClrDebug
{
    [DebuggerDisplay("FlagsAndSize = {FlagsAndSize}, MaxStack = {MaxStack}, CodeSize = {CodeSize}, LocalVarSigTok = {LocalVarSigTok.ToString(),nq}, Flags = {Flags.ToString(),nq}, Size = {Size}")]
    public struct IMAGE_COR_ILMETHOD_FAT
    {
        //Flags: 12 bits. Size: 4 bits.
        //Flags is a CorILMethodFlags value
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public short FlagsAndSize;

        /// <summary>
        /// Maximum number of items (I4, I, I8, obj ...), on the operand stack
        /// </summary>
        public short MaxStack; //16 bits

        /// <summary>
        /// Size of the code.
        /// </summary>
        public int CodeSize;

        /// <summary>
        /// Token that indicates the signature of the local vars (0 means none).
        /// </summary>
        public mdSignature LocalVarSigTok;

        public CorILMethodFlags Flags => (CorILMethodFlags)(FlagsAndSize >> 8); //While it says that flags is 12 bytes, it seems like due to little endianness one of those bytes lands after the size when flipped around

        /// <summary>
        /// Size in DWords of this structure (currently 3).
        /// </summary>
        public byte Size => (byte)((FlagsAndSize >> 4) & 0x00f);
    }
}
