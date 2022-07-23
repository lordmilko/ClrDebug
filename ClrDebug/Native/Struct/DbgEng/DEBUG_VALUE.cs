using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    /// <summary>
    /// The DEBUG_VALUE structure holds register and expression values.
    /// </summary>
    /// <remarks>
    /// The Type field specifies the value type that is being held by the structure. This also specifies which field in
    /// the structure is valid. The possible values of the Type field, and the corresponding field specified as valid in
    /// the structure, include the following.
    /// </remarks>
    [StructLayout(LayoutKind.Explicit)]
    public unsafe struct DEBUG_VALUE
    {
        [FieldOffset(0)]
        public byte I8;
        [FieldOffset(0)]
        public ushort I16;
        [FieldOffset(0)]
        public int I32;
        [FieldOffset(0)]
        public long I64;
        [FieldOffset(8)]
        public int Nat;
        [FieldOffset(0)]
        public float F32;
        [FieldOffset(0)]
        public double F64;
        [FieldOffset(0)]
        public fixed byte F80Bytes[10];
        [FieldOffset(0)]
        public fixed byte F82Bytes[11];
        [FieldOffset(0)]
        public fixed byte F128Bytes[16];
        [FieldOffset(0)]
        public fixed byte VI8[16];
        [FieldOffset(0)]
        public fixed ushort VI16[8];
        [FieldOffset(0)]
        public fixed int VI32[4];
        [FieldOffset(0)]
        public fixed long VI64[2];
        [FieldOffset(0)]
        public fixed float VF32[4];
        [FieldOffset(0)]
        public fixed double VF64[2];
        [FieldOffset(0)]
        public I64PARTS32 I64Parts32;
        [FieldOffset(0)]
        public F128PARTS64 F128Parts64;
        [FieldOffset(0)]
        public fixed byte RawBytes[24];

        /// <summary>
        /// See Remarks.
        /// </summary>
        [FieldOffset(24)]
        public int TailOfRawBytes;

        /// <summary>
        /// See Remarks.
        /// </summary>
        [FieldOffset(28)]
        public DEBUG_VALUE_TYPE Type;
    }
}