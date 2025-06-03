namespace ClrDebug.OMF
{
    /// <summary>
    /// Describes subsection types found in OMF style CodeView symbols.<para/>
    /// Identifiers in all uppercase are from NB00 -> NB02, identifiers in mixed case are NB05+.
    /// </summary>
    public enum SST : ushort
    {
        #region NB00 -> NB02

        /// <summary>
        /// NB00 -> NB02<para/>
        /// Basic info. about object module
        /// </summary>
        SSTMODULE = 0x101,

        /// <summary>
        /// NB00 -> NB02<para/>
        /// Public symbols
        /// </summary>
        SSTPUBLIC = 0x102,

        /// <summary>
        /// NB00 -> NB02<para/>
        /// Type information
        /// </summary>
        SSTTYPES = 0x103,

        /// <summary>
        /// NB00 -> NB02<para/>
        /// Symbol Data
        /// </summary>
        SSTSYMBOLS = 0x104,

        /// <summary>
        /// NB00 -> NB02<para/>
        /// Source line information
        /// </summary>
        SSTSRCLINES = 0x105,

        /// <summary>
        /// NB00 -> NB02<para/>
        /// Names of all library files used
        /// </summary>
        SSTLIBRARIES = 0x106,

        /// <summary>
        /// NB00 -> NB02<para/>
        /// Symbols for DLL fixups
        /// </summary>
        SSTIMPORTS = 0x107,

        /// <summary>
        /// NB00 -> NB02<para/>
        /// Compacted types section
        /// </summary>
        SSTCOMPACTED = 0x108,

        /// <summary>
        /// NB00 -> NB02<para/>
        /// Same as source lines, contains segment
        /// </summary>
        SSTSRCLNSEG = 0x109,

        #endregion
        #region NB05+

        /// <summary>
        /// NB05+<para/>
        /// This describes the basic information about an object module, including code segments, module name, and the number of segments for the modules that follow.<para/>
        /// Entry type: <see cref="OMFModule"/>.
        /// </summary>
        sstModule = 0x120,

        /// <summary>
        /// NB05+
        /// </summary>
        sstTypes = 0x121,

        /// <summary>
        /// NB05+
        /// </summary>
        sstPublic = 0x122, //Exact structure defined in MS_Symbol_Type_v1.0.pdf doesn't exist in cvexefmt.h

        /// <summary>
        /// NB05+<para/>
        /// publics as symbol (waiting for link)
        /// </summary>
        sstPublicSym = 0x123,

        /// <summary>
        /// NB05+
        /// </summary>
        sstSymbols = 0x124,

        /// <summary>
        /// NB05+
        /// </summary>
        sstAlignSym = 0x125,

        /// <summary>
        /// NB05+<para/>
        /// because link doesn't emit SrcModule
        /// </summary>
        sstSrcLnSeg = 0x126,

        /// <summary>
        /// NB05+<para/>
        /// Entry type: <see cref="OMFSourceModule"/>
        /// </summary>
        sstSrcModule = 0x127,

        /// <summary>
        /// NB05+
        /// </summary>
        sstLibraries = 0x128,

        /// <summary>
        /// NB05+
        /// </summary>
        sstGlobalSym = 0x129,

        /// <summary>
        /// NB05+
        /// </summary>
        sstGlobalPub = 0x12a,

        /// <summary>
        /// NB05+
        /// </summary>
        sstGlobalTypes = 0x12b,

        /// <summary>
        /// NB05+
        /// </summary>
        sstMPC = 0x12c,

        /// <summary>
        /// NB05+
        /// </summary>
        sstSegMap = 0x12d,

        /// <summary>
        /// NB05+
        /// </summary>
        sstSegName = 0x12e,

        /// <summary>
        /// NB05+<para/>
        /// precompiled types
        /// </summary>
        sstPreComp = 0x12f,

        /// <summary>
        /// NB05+<para/>
        /// map precompiled types in global types
        /// </summary>
        sstPreCompMap = 0x130,

        /// <summary>
        /// NB05+
        /// </summary>
        sstOffsetMap16 = 0x131,

        /// <summary>
        /// NB05+
        /// </summary>
        sstOffsetMap32 = 0x132,

        /// <summary>
        /// NB05+<para/>
        /// Index of file names
        /// </summary>
        sstFileIndex = 0x133,

        /// <summary>
        /// NB05+
        /// </summary>
        sstStaticSym = 0x134

        #endregion
    }
}
