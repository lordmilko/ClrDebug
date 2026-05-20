using System.Diagnostics;
using System.Runtime.InteropServices;

namespace ClrDebug.PDB
{
    /* There are three kinds of Def Range symbols
     * - 16 byte
     * - 20 byte
     * - HLSL
     *
     * the following table lists each Def Range symbol, how it gets processed by dumpsym7.cpp in microsoft-pdb
     * and whether the type supports gaps. Depending on the size of the symbol there are two different macros
     * that can be used to analyze the gaps:
     * - "Full": DEFRANGESYM.CV_DEFRANGESYM_GAPS_COUNT (16 byte types)
     * - "Sub": DEFRANGESYMSUBFIELD.CV_DEFRANGESYMSUBFIELD_GAPS_COUNT (20 byte types)
     * - "HLSL": DEFRANGESYMHLSL.<various> (as of writing not currently implemented)
     *
     * | SYM_ENUM_e                             | Struct                                | Kind | Gaps | Size | dumpsym7.cpp
     * |----------------------------------------|---------------------------------------|------|------|------|--------------
     * | S_DEFRANGE                             | DEFRANGESYM                           | Full | Yes  | 16   | C7DefRange
     * | S_DEFRANGE_FRAMEPOINTER_REL            | DEFRANGESYMFRAMEPOINTERREL            | Full | Yes  | 16   | C7DefRange
     * | S_DEFRANGE_FRAMEPOINTER_REL_FULL_SCOPE | DEFRANGESYMFRAMEPOINTERREL_FULL_SCOPE | N/A  | No   | 8    | C7DefRange (but bails out early)
     * | S_DEFRANGE_HLSL                        | DEFRANGESYMHLSL                       | HLSL | Yes  | 20   | C7DefRangeHLSL
     * | S_DEFRANGE_REGISTER                    | DEFRANGESYMREGISTER                   | Full | Yes  | 16   | C7DefRange
     * | S_DEFRANGE_REGISTER_REL                | DEFRANGESYMREGISTERREL                | Sub  | Yes  | 20   | C7DefRange2
     * | S_DEFRANGE_SUBFIELD                    | DEFRANGESYMSUBFIELD                   | Sub  | Yes  | 20   | C7DefRange2
     * | S_DEFRANGE_SUBFIELD_REGISTER           | DEFRANGESYMSUBFIELDREGISTER           | Sub  | Yes  | 20   | C7DefRange2
     * 
     * Additional types
     * S_DEFRANGE_DPC_PTR_TAG
     * S_DEFRANGE_REGISTER_REL_INDIR
     * S_DEFRANGE_CONSTVAL_ON_ENTRY
     * S_DEFRANGE_GLOBALSYM_ON_ENTRY
     * 
     * The following table lists the various fields found in in DefRange symbols, and which types have them
     * 
     * Type                                  | program | range | gaps | offFramePointer | HLSL Specific Fields | reg | attr | spilledUdtMember | off[set]Parent | baseReg | offBasePointer
     * --------------------------------------|---------|-------|------|-----------------|----------------------|-----|------|------------------|----------------|---------|---------------
     * DEFRANGESYM                           | Yes     | Yes   | Yes  |                 |                      |     |      |                  |                |         |
     * DEFRANGESYMFRAMEPOINTERREL            |         | Yes   | Yes  | Yes             |                      |     |      |                  |                |         |
     * DEFRANGESYMFRAMEPOINTERREL_FULL_SCOPE |         |       |      | Yes             |                      |     |      |                  |                |         |
     * DEFRANGESYMHLSL                       |         | Yes   | Yes  |                 | Yes                  |     |      | Yes              | Yes            |         |
     * DEFRANGESYMREGISTER                   |         | Yes   | Yes  |                 |                      | reg | Yes  |                  |                |         |
     * DEFRANGESYMREGISTERREL                |         | Yes   | Yes  |                 |                      |     |      | Yes              | Yes            | Yes     | Yes
     * DEFRANGESYMSUBFIELD                   | Yes     | Yes   | Yes  |                 |                      |     |      |                  | Yes            |         |
     * DEFRANGESYMSUBFIELDREGISTER           |         | Yes   | Yes  |                 |                      |     |      |                  | Yes            |         |
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
            (symType->reclen + sizeof(ushort) - 16) / sizeof(CV_LVAR_ADDR_GAP); //Can't do sizeof(DEFRANGESYM) because that will add 1 for the gaps[1]

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
