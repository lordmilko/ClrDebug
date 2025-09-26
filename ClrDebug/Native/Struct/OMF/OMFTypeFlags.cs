using System.Runtime.InteropServices;
using ClrDebug.PDB;

namespace ClrDebug.OMF
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct OMFTypeFlags
    {
        public CV_SIGNATURE sig;
        public byte unused1;
        public byte unused2;
        public byte unused3;

        public override string ToString()
        {
            return sig.ToString();
        }
    }
}
