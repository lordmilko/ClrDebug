using System.Diagnostics;
using System.Runtime.InteropServices;

namespace ClrDebug.PDB
{
    /* There are three kinds of Def Range symbols
     * - 16 byte
     * - 20 byte
     * - HLSL
     *
     * the following table lists each Def Range symbol and how it gets processed by dumpsym7.cpp in microsoft-pdb
     *
     * | SYM_ENUM_e                             | Struct                                | Size | dumpsym7.cpp
     * |----------------------------------------|---------------------------------------|------|--------------
     * | S_DEFRANGE                             | DEFRANGESYM                           | 16   | C7DefRange
     * | S_DEFRANGE_FRAMEPOINTER_REL            | DEFRANGESYMFRAMEPOINTERREL            | 16   | C7DefRange
     * | S_DEFRANGE_FRAMEPOINTER_REL_FULL_SCOPE | DEFRANGESYMFRAMEPOINTERREL_FULL_SCOPE | 8    | C7DefRange (but bails out early)
     * | S_DEFRANGE_HLSL                        | DEFRANGESYMHLSL                       | 20   | C7DefRangeHLSL
     * | S_DEFRANGE_REGISTER                    | DEFRANGESYMREGISTER                   | 16   | C7DefRange
     * | S_DEFRANGE_REGISTER_REL                | DEFRANGESYMREGISTERREL                | 20   | C7DefRange2
     * | S_DEFRANGE_SUBFIELD                    | DEFRANGESYMSUBFIELD                   | 20   | C7DefRange2
     * | S_DEFRANGE_SUBFIELD_REGISTER           | DEFRANGESYMSUBFIELDREGISTER           | 20   | C7DefRange2
     */

    /// <summary>
    /// A live range of sub field of variable
    /// </summary>
    [DebuggerDisplay("reclen = {reclen}, rectyp = {rectyp.ToString(),nq}, program = {program.ToString(),nq}, range = {range.ToString(),nq}, gaps = {gaps}")]
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public unsafe struct DEFRANGESYM
    {
        //#define CV_DEFRANGESYM_GAPS_COUNT(x) \
        //    (((x)->reclen + sizeof((x)->reclen) - sizeof(DEFRANGESYM)) / sizeof(CV_LVAR_ADDR_GAP))

        public static int CV_DEFRANGESYM_GAPS_COUNT(SYMTYPE* symType) =>
            (symType->reclen + sizeof(ushort) - sizeof(DEFRANGESYM)) / sizeof(CV_LVAR_ADDR_GAP);

        /// <summary>
        /// Record length
        /// </summary>
        public ushort reclen;

        /// <summary>
        /// S_DEFRANGE
        /// </summary>
        public SYM_ENUM_e rectyp;

        /// <summary>
        /// DIA program to evaluate the value of the symbol
        /// </summary>
        public CV_uoff32_t program;

        /// <summary>
        /// Range of addresses where this program is valid
        /// </summary>
        public CV_LVAR_ADDR_RANGE range;

        /// <summary>
        /// The value is not available in following gaps.<para/>
        /// Read this value using <see cref="DEFRANGESYM.CV_DEFRANGESYM_GAPS_COUNT"/>
        /// </summary>
        public fixed byte gaps[1]; //CV_LVAR_ADDR_GAP[]
    }
}
