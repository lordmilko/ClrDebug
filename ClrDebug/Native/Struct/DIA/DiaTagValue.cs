using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Text;

namespace ClrDebug.DIA
{
    [DebuggerDisplay("{DebuggerDisplay,nq}")]
    [StructLayout(LayoutKind.Explicit, Pack = 1)]
    public struct DiaTagValue
    {
        private string DebuggerDisplay
        {
            get
            {
                var builder = new StringBuilder();

                switch (valueSizeBytes)
                {
                    case 1:
                        builder.Append($"data8 = {data8}, ");
                        break;

                    case 2:
                        builder.Append($"data16 = {data16}, ");
                        break;

                    case 4:
                        builder.Append($"data32 = {data32}, ");
                        break;

                    case 8:
                        builder.Append($"data64 = {data64}, ");
                        break;

                    case 16:
                        builder.Append($"data128_hi = {data128_hi}, data128_lo = {data128_lo}");
                        break;
                }

                builder.Append($"valueSizeBytes = {valueSizeBytes}");

                return builder.ToString();
            }
        }

        [FieldOffset(0)]
        public byte data8;

        [FieldOffset(0)]
        public ushort data16;

        [FieldOffset(0)]
        public int data32;

        [FieldOffset(0)]
        public ulong data64;

        [FieldOffset(0)]
        public ulong data128_hi;

        [FieldOffset(8)]
        public ulong data128_lo;

        [FieldOffset(16)]
        public byte valueSizeBytes;
    }
}
