using System.Diagnostics;
using System.Runtime.InteropServices;

namespace ClrDebug.PDB
{
    /// <summary>
    /// derived class list leaf
    /// </summary>
    [DebuggerDisplay("leaf = {leaf.ToString(),nq}, count = {count}, drvdcls = {drvdcls}")]
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public unsafe struct lfDerived_16t
    {
        /// <summary>
        /// LF_DERIVED_16t
        /// </summary>
        public LEAF_ENUM_e leaf;

        /// <summary>
        /// number of arguments
        /// </summary>
        public short count;

        /// <summary>
        /// type indices of derived classes
        /// </summary>
        public fixed short drvdcls[1]; //CV_typ16_t
    }
}
