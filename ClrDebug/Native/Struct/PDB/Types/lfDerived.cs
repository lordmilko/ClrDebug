using System.Diagnostics;
using System.Runtime.InteropServices;

namespace ClrDebug.PDB
{
    /// <summary>
    /// derived class list leaf
    /// </summary>
    [DebuggerDisplay("leaf = {leaf.ToString(),nq}, count = {count}, drvdcls = {drvdcls}")]
    [StructLayout(LayoutKind.Sequential, Pack = 2)]
    public unsafe struct lfDerived
    {
        /// <summary>
        /// LF_DERIVED
        /// </summary>
        public LEAF_ENUM_e leaf;

        /// <summary>
        /// number of arguments
        /// </summary>
        public int count;

        /// <summary>
        /// type indices of derived classes
        /// </summary>
        public fixed int drvdcls[1]; //CV_typ_t
    }
}
