using System.Runtime.InteropServices;

namespace ClrDebug.PDB
{
    /// <summary>
    /// information decribing each segment in a module
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public unsafe struct OMFSegMap
    {
        /// <summary>
        /// total number of segment descriptors
        /// </summary>
        public ushort cSeg;

        /// <summary>
        /// number of logical segment descriptors
        /// </summary>
        public ushort cSegLog;

        /// <summary>
        /// array of segment descriptors<para/>
        /// This value is an array of <see cref="OMFSegMapDesc"/>
        /// </summary>
        public fixed byte rgDesc[1]; //OMFSegMapDesc
    }
}
