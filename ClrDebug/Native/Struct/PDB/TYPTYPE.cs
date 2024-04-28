using System.Diagnostics;
using System.Runtime.InteropServices;

namespace ClrDebug.PDB
{
    [DebuggerDisplay("len = {len}, leaf = {leaf.ToString(),nq}, data = {data}")]
    [StructLayout(LayoutKind.Sequential, Pack = 2)]
    public unsafe struct TYPTYPE
    {
        public short len;
        public LEAF_ENUM_e leaf;
        public fixed byte data[1];

        public override string ToString()
        {
            return leaf.ToString();
        }
    }
}
