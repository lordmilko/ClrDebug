using System.Runtime.InteropServices;

namespace ClrDebug.PDB
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public unsafe struct TYPTYPE
    {
        public ushort len; //The length of the data that follows this field. The total size of the TYPTYPE is sizeof(ushort) + len
        public LEAF_ENUM_e leaf;
        public fixed byte data[1];

        public override string ToString()
        {
            return leaf.ToString();
        }
    }
}
