using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Text;
using static ClrDebug.Extensions;

namespace ClrDebug.PDB
{
    [DebuggerDisplay("reclen = {reclen}, rectyp = {rectyp.ToString(),nq}, rev = {rev}, pad = {pad}, flags = {flags}, rgsz = {rgsz}")]
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public unsafe struct ENVBLOCKSYM
    {
        /// <summary>
        /// Record length
        /// </summary>
        public ushort reclen;

        /// <summary>
        /// S_ENVBLOCK
        /// </summary>
        public SYM_ENUM_e rectyp;

        #region BitField

        /// <summary>
        /// reserved
        /// </summary>
        public bool rev
        {
            get => GetBitFlag(flags, 0);
            set => SetBitFlag(ref flags, 0, value);
        }

        /// <summary>
        /// reserved, must be 0
        /// </summary>
        public byte pad
        {
            get => GetBits(flags, 1, 7); //1-7
            set => SetBits(ref flags, 1, 7, value);
        }

        public byte flags;

        #endregion

        /// <summary>
        /// Sequence of zero-terminated strings
        /// </summary>
        public fixed byte rgsz[1];

        public string[] Strings
        {
            get
            {
                //From dumpsym7.cpp!C7Envblock, we can see that the array will end in a \0

                var results = new List<string>();

                fixed (byte* local = rgsz)
                {
                    var ptr = local;

                    while (true)
                    {
                        if (*ptr == 0)
                            break;

                        var str = CreateString(ptr, true);

                        results.Add(str);

                        ptr += Encoding.UTF8.GetByteCount(str) + 1; //Skip the \0 as well
                    }
                }

                return results.ToArray();
            }
        }

        public override string ToString()
        {
            var builder = new StringBuilder();

            var strs = Strings;

            for (var i = 0; i < strs.Length; i += 2)
            {
                builder.Append(strs[i]).Append(" = ");

                if (i < strs.Length - 1)
                    builder.Append(strs[i + 1]);
                else
                    builder.Append("null");

                if (i < strs.Length - 2)
                    builder.Append(", ");
            }

            return builder.ToString();
        }
    }
}
