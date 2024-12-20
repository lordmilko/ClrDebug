namespace ClrDebug.PDB
{
    //Replace (.+?,) +// (.+)\r\n
    //with /// <summary>\r\n/// $2\r\n/// </summary>\r\n$1\r\n\r\n

    public enum SYM_ENUM_e : ushort
    {
        /// <summary>
        /// Compile flags symbol.<para/>
        /// Type: <see cref="CFLAGSYM"/>
        /// </summary>
        S_COMPILE = 0x0001,

        /// <summary>
        /// Register variable<para/>
        /// Type: <see cref="REGSYM_16t"/>
        /// </summary>
        S_REGISTER_16t = 0x0002,

        /// <summary>
        /// constant symbol.<para/>
        /// Type: <see cref="CONSTSYM_16t"/>
        /// </summary>
        S_CONSTANT_16t = 0x0003,

        /// <summary>
        /// User defined type.<para/>
        /// Type: <see cref="UDTSYM_16t"/>
        /// </summary>
        S_UDT_16t = 0x0004,

        /// <summary>
        /// Start Search.<para/>
        /// Type: <see cref="SEARCHSYM"/>
        /// </summary>
        S_SSEARCH = 0x0005,

        /// <summary>
        /// Block, procedure, "with" or thunk end
        /// </summary>
        S_END = 0x0006,

        /// <summary>
        /// Reserve symbol space in $$Symbols table.<para/>
        /// Type: <see cref="SYMTYPE"/>
        /// </summary>
        S_SKIP = 0x0007,

        /// <summary>
        /// Reserved symbol for CV internal use.<para/>
        /// Type: Unknown
        /// </summary>
        S_CVRESERVE = 0x0008,

        /// <summary>
        /// path to object file name.<para/>
        /// Type: <see cref="OBJNAMESYM"/>
        /// </summary>
        S_OBJNAME_ST = 0x0009,

        /// <summary>
        /// end of argument/return list
        /// </summary>
        S_ENDARG = 0x000a,

        /// <summary>
        /// special UDT for cobol that does not symbol pack.<para/>
        /// Type: <see cref="UDTSYM_16t"/>
        /// </summary>
        S_COBOLUDT_16t = 0x000b,

        /// <summary>
        /// multiple register variable.<para/>
        /// Type: <see cref="MANYREGSYM_16t"/>
        /// </summary>
        S_MANYREG_16t = 0x000c,

        /// <summary>
        /// return description symbol.<para/>
        /// Type: <see cref="RETURNSYM"/>
        /// </summary>
        S_RETURN = 0x000d,

        /// <summary>
        /// description of this pointer on entry.<para/>
        /// Type: <see cref="ENTRYTHISSYM"/>
        /// </summary>
        S_ENTRYTHIS = 0x000e,

        /// <summary>
        /// BP-relative.<para/>
        /// Type: <see cref="BPRELSYM16"/>
        /// </summary>
        S_BPREL16 = 0x0100,

        /// <summary>
        /// Module-local symbol.<para/>
        /// Type: <see cref="DATASYM16"/>
        /// </summary>
        S_LDATA16 = 0x0101,

        /// <summary>
        /// Global data symbol.<para/>
        /// Type: <see cref="DATASYM16"/>
        /// </summary>
        S_GDATA16 = 0x0102,

        /// <summary>
        /// a public symbol.<para/>
        /// Type: <see cref="DATASYM16"/>
        /// </summary>
        S_PUB16 = 0x0103,

        /// <summary>
        /// Local procedure start.<para/>
        /// Type: <see cref="PROCSYM16"/>
        /// </summary>
        S_LPROC16 = 0x0104,

        /// <summary>
        /// Global procedure start.<para/>
        /// Type: <see cref="PROCSYM16"/>
        /// </summary>
        S_GPROC16 = 0x0105,

        /// <summary>
        /// Thunk Start.<para/>
        /// Type: <see cref="THUNKSYM16"/>
        /// </summary>
        S_THUNK16 = 0x0106,

        /// <summary>
        /// block start.<para/>
        /// Type: <see cref="BLOCKSYM16"/>
        /// </summary>
        S_BLOCK16 = 0x0107,

        /// <summary>
        /// with start.<para/>
        /// Type: <see cref="BLOCKSYM16"/>
        /// </summary>
        S_WITH16 = 0x0108,

        /// <summary>
        /// code label.<para/>
        /// Type: <see cref="LABELSYM16"/>
        /// </summary>
        S_LABEL16 = 0x0109,

        /// <summary>
        /// change execution model.<para/>
        /// Type: <see cref="CEXMSYM16"/>
        /// </summary>
        S_CEXMODEL16 = 0x010a,

        /// <summary>
        /// address of virtual function table.<para/>
        /// Type: Unknown
        /// </summary>
        S_VFTABLE16 = 0x010b,

        /// <summary>
        /// register relative address.<para/>
        /// Type: <see cref="REGREL16"/>
        /// </summary>
        S_REGREL16 = 0x010c,

        /// <summary>
        /// BP-relative.<para/>
        /// Type: <see cref="BPRELSYM32_16t"/>
        /// </summary>
        S_BPREL32_16t = 0x0200,

        /// <summary>
        /// Module-local symbol.<para/>
        /// Type: <see cref="DATASYM32_16t"/>
        /// </summary>
        S_LDATA32_16t = 0x0201,

        /// <summary>
        /// Global data symbol.<para/>
        /// Type: <see cref="DATASYM32_16t"/>
        /// </summary>
        S_GDATA32_16t = 0x0202,

        /// <summary>
        /// a public symbol (CV internal reserved) (<see cref="DATASYM32_16t"/> (aliased as "PUBSYM32_16t"))
        /// </summary>
        S_PUB32_16t = 0x0203,

        /// <summary>
        /// Local procedure start.<para/>
        /// Type: <see cref="PROCSYM32_16t"/>
        /// </summary>
        S_LPROC32_16t = 0x0204,

        /// <summary>
        /// Global procedure start.<para/>
        /// Type: <see cref="PROCSYM32_16t"/>
        /// </summary>
        S_GPROC32_16t = 0x0205,

        /// <summary>
        /// Thunk Start.<para/>
        /// Type: <see cref="THUNKSYM32"/>
        /// </summary>
        S_THUNK32_ST = 0x0206,

        /// <summary>
        /// block start.<para/>
        /// Type: <see cref="BLOCKSYM32"/>
        /// </summary>
        S_BLOCK32_ST = 0x0207,

        /// <summary>
        /// with start.<para/>
        /// Type: <see cref="BLOCKSYM32"/>
        /// </summary>
        S_WITH32_ST = 0x0208,

        /// <summary>
        /// code label.<para/>
        /// Type: <see cref="LABELSYM32"/>
        /// </summary>
        S_LABEL32_ST = 0x0209,

        /// <summary>
        /// change execution model.<para/>
        /// Type: <see cref="CEXMSYM32"/>
        /// </summary>
        S_CEXMODEL32 = 0x020a,

        /// <summary>
        /// address of virtual function table.<para/>
        /// Type: Unknown
        /// </summary>
        S_VFTABLE32_16t = 0x020b,

        /// <summary>
        /// register relative address.<para/>
        /// Type: <see cref="REGREL32_16t"/>
        /// </summary>
        S_REGREL32_16t = 0x020c,

        /// <summary>
        /// local thread storage.<para/>
        /// Type: <see cref="DATASYM32_16t"/>
        /// </summary>
        S_LTHREAD32_16t = 0x020d,

        /// <summary>
        /// global thread storage.<para/>
        /// Type: <see cref="DATASYM32_16t"/>
        /// </summary>
        S_GTHREAD32_16t = 0x020e,

        /// <summary>
        /// static link for MIPS EH implementation.<para/>
        /// Type: <see cref="SLINK32"/>
        /// </summary>
        S_SLINK32 = 0x020f,

        /// <summary>
        /// Local procedure start.<para/>
        /// Type: <see cref="PROCSYMMIPS_16t"/>
        /// </summary>
        S_LPROCMIPS_16t = 0x0300,

        /// <summary>
        /// Global procedure start.<para/>
        /// Type: <see cref="PROCSYMMIPS_16t"/>
        /// </summary>
        S_GPROCMIPS_16t = 0x0301,

        // if these ref symbols have names following then the names are in ST format

        /// <summary>
        /// Reference to a procedure.<para/>
        /// Type: <see cref="REFSYM"/>
        /// </summary>
        S_PROCREF_ST = 0x0400,

        /// <summary>
        /// Reference to data.<para/>
        /// Type: <see cref="REFSYM"/>
        /// </summary>
        S_DATAREF_ST = 0x0401,

        /// <summary>
        /// Used for page alignment of symbols.<para/>
        /// Type: <see cref="ALIGNSYM"/>
        /// </summary>
        S_ALIGN = 0x0402,

        /// <summary>
        /// Local Reference to a procedure.<para/>
        /// Type: <see cref="REFSYM"/>
        /// </summary>
        S_LPROCREF_ST = 0x0403,

        /// <summary>
        /// OEM defined symbol.<para/>
        /// Type: <see cref="OEMSYMBOL"/>
        /// </summary>
        S_OEM = 0x0404,

        // sym records with 32-bit types embedded instead of 16-bit
        // all have 0x1000 bit set for easy identification
        // only do the 32-bit target versions since we don't really
        // care about 16-bit ones anymore.
        S_TI16_MAX = 0x1000,

        /// <summary>
        /// Register variable.<para/>
        /// Type: <see cref="REGSYM"/>
        /// </summary>
        S_REGISTER_ST = 0x1001,

        /// <summary>
        /// constant symbol.<para/>
        /// Type: <see cref="CONSTSYM"/>
        /// </summary>
        S_CONSTANT_ST = 0x1002,

        /// <summary>
        /// User defined type.<para/>
        /// Type: <see cref="UDTSYM"/>
        /// </summary>
        S_UDT_ST = 0x1003,

        /// <summary>
        /// special UDT for cobol that does not symbol pack.<para/>
        /// Type: <see cref="UDTSYM"/>
        /// </summary>
        S_COBOLUDT_ST = 0x1004,

        /// <summary>
        /// multiple register variable.<para/>
        /// Type: <see cref="MANYREGSYM"/>
        /// </summary>
        S_MANYREG_ST = 0x1005,

        /// <summary>
        /// BP-relative.<para/>
        /// Type: <see cref="BPRELSYM32"/>
        /// </summary>
        S_BPREL32_ST = 0x1006,

        /// <summary>
        /// Module-local symbol.<para/>
        /// Type: <see cref="DATASYM32"/>
        /// </summary>
        S_LDATA32_ST = 0x1007,

        /// <summary>
        /// Global data symbol.<para/>
        /// Type: <see cref="DATASYM32"/>
        /// </summary>
        S_GDATA32_ST = 0x1008,

        /// <summary>
        /// a public symbol (CV internal reserved).<para/>
        /// Type: <see cref="PUBSYM32"/>
        /// </summary>
        S_PUB32_ST = 0x1009,

        /// <summary>
        /// Local procedure start.<para/>
        /// Type: <see cref="PROCSYM32"/>
        /// </summary>
        S_LPROC32_ST = 0x100a,

        /// <summary>
        /// Global procedure start.<para/>
        /// Type: <see cref="PROCSYM32"/>
        /// </summary>
        S_GPROC32_ST = 0x100b,

        /// <summary>
        /// address of virtual function table.<para/>
        /// Type: Unknown
        /// </summary>
        S_VFTABLE32 = 0x100c,

        /// <summary>
        /// register relative address.<para/>
        /// Type: <see cref="REGREL32"/>
        /// </summary>
        S_REGREL32_ST = 0x100d,

        /// <summary>
        /// local thread storage.<para/>
        /// Type: <see cref="DATASYM32"/>
        /// </summary>
        S_LTHREAD32_ST = 0x100e,

        /// <summary>
        /// global thread storage.<para/>
        /// Type: <see cref="DATASYM32"/>
        /// </summary>
        S_GTHREAD32_ST = 0x100f,

        /// <summary>
        /// Local procedure start.<para/>
        /// Type: <see cref="PROCSYMMIPS"/>
        /// </summary>
        S_LPROCMIPS_ST = 0x1010,

        /// <summary>
        /// Global procedure start.<para/>
        /// Type: <see cref="PROCSYMMIPS"/>
        /// </summary>
        S_GPROCMIPS_ST = 0x1011,

        /// <summary>
        /// extra frame and proc information.<para/>
        /// Type: <see cref="FRAMEPROCSYM"/>
        /// </summary>
        S_FRAMEPROC = 0x1012,

        /// <summary>
        /// extended compile flags and info.<para/>
        /// Type: <see cref="COMPILESYM"/>
        /// </summary>
        S_COMPILE2_ST = 0x1013,

        // new symbols necessary for 16-bit enumerates of IA64 registers
        // and IA64 specific symbols

        /// <summary>
        /// multiple register variable.<para/>
        /// Type: <see cref="MANYREGSYM2"/>
        /// </summary>
        S_MANYREG2_ST = 0x1014,

        /// <summary>
        /// Local procedure start (IA64).<para/>
        /// Type: <see cref="PROCSYMIA64"/>
        /// </summary>
        S_LPROCIA64_ST = 0x1015,

        /// <summary>
        /// Global procedure start (IA64).<para/>
        /// Type: <see cref="PROCSYMIA64"/>
        /// </summary>
        S_GPROCIA64_ST = 0x1016,

        // Local symbols for IL

        /// <summary>
        /// local IL sym with field for local slot index.<para/>
        /// Type: <see cref="SLOTSYM32"/>
        /// </summary>
        S_LOCALSLOT_ST = 0x1017,

        /// <summary>
        /// local IL sym with field for parameter slot index.<para/>
        /// Type: <see cref="SLOTSYM32"/>
        /// </summary>
        S_PARAMSLOT_ST = 0x1018,

        /// <summary>
        /// Annotation string literals.<para/>
        /// Type: <see cref="ANNOTATIONSYM"/>
        /// </summary>
        S_ANNOTATION = 0x1019,

        // symbols to support managed code debugging

        /// <summary>
        /// Global proc.<para/>
        /// Type: <see cref="MANPROCSYM"/>
        /// </summary>
        S_GMANPROC_ST = 0x101a,

        /// <summary>
        /// Local proc.<para/>
        /// Type: <see cref="MANPROCSYM"/>
        /// </summary>
        S_LMANPROC_ST = 0x101b,

        /// <summary>
        /// reserved.<para/>
        /// Type: Unknown
        /// </summary>
        S_RESERVED1 = 0x101c,

        /// <summary>
        /// reserved.<para/>
        /// Type: Unknown
        /// </summary>
        S_RESERVED2 = 0x101d,

        /// <summary>
        /// reserved.<para/>
        /// Type: Unknown
        /// </summary>
        S_RESERVED3 = 0x101e,

        /// <summary>
        /// reserved.<para/>
        /// Type: Unknown
        /// </summary>
        S_RESERVED4 = 0x101f,

        S_LMANDATA_ST = 0x1020, //DATASYM32
        S_GMANDATA_ST = 0x1021, //DATASYM32
        S_MANFRAMEREL_ST = 0x1022, //FRAMERELSYM
        S_MANREGISTER_ST = 0x1023, //ATTRREGSYM
        S_MANSLOT_ST = 0x1024, //ATTRSLOTSYM
        S_MANMANYREG_ST = 0x1025,
        S_MANREGREL_ST = 0x1026, //ATTRREGREL
        S_MANMANYREG2_ST = 0x1027,

        /// <summary>
        /// Index for type referenced by name from metadata.<para/>
        /// Type: <see cref="MANTYPREF"/>
        /// </summary>
        S_MANTYPREF = 0x1028,

        /// <summary>
        /// Using namespace.<para/>
        /// Type: <see cref="UNAMESPACE"/>
        /// </summary>
        S_UNAMESPACE_ST = 0x1029,

        // Symbols w/ SZ name fields. All name fields contain utf8 encoded strings.

        /// <summary>
        /// starting point for SZ name symbols.
        /// </summary>
        S_ST_MAX = 0x1100,

        /// <summary>
        /// path to object file name.<para/>
        /// Type: <see cref="OBJNAMESYM"/>
        /// </summary>
        S_OBJNAME = 0x1101,

        /// <summary>
        /// Thunk Start.<para/>
        /// Type: <see cref="THUNKSYM32"/>
        /// </summary>
        S_THUNK32 = 0x1102,

        /// <summary>
        /// block start.<para/>
        /// Type: <see cref="BLOCKSYM32"/>
        /// </summary>
        S_BLOCK32 = 0x1103,

        /// <summary>
        /// with start.<para/>
        /// Type: <see cref="BLOCKSYM32"/>
        /// </summary>
        S_WITH32 = 0x1104,

        /// <summary>
        /// code label.<para/>
        /// Type: <see cref="LABELSYM32"/>
        /// </summary>
        S_LABEL32 = 0x1105,

        /// <summary>
        /// Register variable.<para/>
        /// Type: <see cref="REGSYM"/>
        /// </summary>
        S_REGISTER = 0x1106,

        /// <summary>
        /// constant symbol.<para/>
        /// Type: <see cref="CONSTSYM"/>
        /// </summary>
        S_CONSTANT = 0x1107,

        /// <summary>
        /// User defined type.<para/>
        /// Type: <see cref="UDTSYM"/>
        /// </summary>
        S_UDT = 0x1108,

        /// <summary>
        /// special UDT for cobol that does not symbol pack.<para/>
        /// Type: <see cref="UDTSYM"/>
        /// </summary>
        S_COBOLUDT = 0x1109,

        /// <summary>
        /// multiple register variable.<para/>
        /// Type: <see cref="MANYREGSYM"/>
        /// </summary>
        S_MANYREG = 0x110a,

        /// <summary>
        /// BP-relative.<para/>
        /// Type: <see cref="BPRELSYM32"/>
        /// </summary>
        S_BPREL32 = 0x110b,

        /// <summary>
        /// Module-local symbol.<para/>
        /// Type: <see cref="DATASYM32"/>
        /// </summary>
        S_LDATA32 = 0x110c,

        /// <summary>
        /// Global data symbol.<para/>
        /// Type: <see cref="DATASYM32"/>
        /// </summary>
        S_GDATA32 = 0x110d,

        /// <summary>
        /// a public symbol (CV internal reserved).<para/>
        /// Type: <see cref="PUBSYM32"/>
        /// </summary>
        S_PUB32 = 0x110e,

        /// <summary>
        /// Local procedure start.<para/>
        /// Type: <see cref="PROCSYM32"/>
        /// </summary>
        S_LPROC32 = 0x110f,

        /// <summary>
        /// Global procedure start.<para/>
        /// Type: <see cref="PROCSYM32"/>
        /// </summary>
        S_GPROC32 = 0x1110,

        /// <summary>
        /// register relative address.<para/>
        /// Type: <see cref="REGREL32"/>
        /// </summary>
        S_REGREL32 = 0x1111,

        /// <summary>
        /// local thread storage.<para/>
        /// Type: <see cref="DATASYM32"/>
        /// </summary>
        S_LTHREAD32 = 0x1112,

        /// <summary>
        /// global thread storage.<para/>
        /// Type: <see cref="DATASYM32"/>
        /// </summary>
        S_GTHREAD32 = 0x1113,

        /// <summary>
        /// Local procedure start.<para/>
        /// Type: <see cref="PROCSYMMIPS"/>
        /// </summary>
        S_LPROCMIPS = 0x1114,

        /// <summary>
        /// Global procedure start.<para/>
        /// Type: <see cref="PROCSYMMIPS"/>
        /// </summary>
        S_GPROCMIPS = 0x1115,

        /// <summary>
        /// extended compile flags and info.<para/>
        /// Type: <see cref="COMPILESYM"/>
        /// </summary>
        S_COMPILE2 = 0x1116,

        /// <summary>
        /// multiple register variable.<para/>
        /// Type: <see cref="MANYREGSYM2"/>
        /// </summary>
        S_MANYREG2 = 0x1117,

        /// <summary>
        /// Local procedure start (IA64).<para/>
        /// Type: <see cref="PROCSYMIA64"/>
        /// </summary>
        S_LPROCIA64 = 0x1118,

        /// <summary>
        /// Global procedure start (IA64).<para/>
        /// Type: <see cref="PROCSYMIA64"/>
        /// </summary>
        S_GPROCIA64 = 0x1119,

        /// <summary>
        /// local IL sym with field for local slot index.<para/>
        /// Type: <see cref="SLOTSYM32"/>
        /// </summary>
        S_LOCALSLOT = 0x111a,

        /// <summary>
        /// alias for LOCALSLOT.<para/>
        /// Type: <see cref="SLOTSYM32"/>
        /// </summary>
        S_SLOT = S_LOCALSLOT,

        /// <summary>
        /// local IL sym with field for parameter slot index.<para/>
        /// Type: <see cref="SLOTSYM32"/>
        /// </summary>
        S_PARAMSLOT = 0x111b,

        // symbols to support managed code debugging
        S_LMANDATA = 0x111c, //DATASYM32
        S_GMANDATA = 0x111d, //DATASYM32
        S_MANFRAMEREL = 0x111e, //FRAMERELSYM
        S_MANREGISTER = 0x111f, //ATTRREGSYM
        S_MANSLOT = 0x1120, //ATTRSLOTSYM
        S_MANMANYREG = 0x1121,
        S_MANREGREL = 0x1122, //ATTRREGREL
        S_MANMANYREG2 = 0x1123,

        /// <summary>
        /// Using namespace.<para/>
        /// Type: <see cref="UNAMESPACE"/>
        /// </summary>
        S_UNAMESPACE = 0x1124,

        // ref symbols with name fields

        /// <summary>
        /// Reference to a procedure.<para/>
        /// Type: <see cref="REFSYM2"/>
        /// </summary>
        S_PROCREF = 0x1125,

        /// <summary>
        /// Reference to data.<para/>
        /// Type: <see cref="REFSYM2"/>
        /// </summary>
        S_DATAREF = 0x1126,

        /// <summary>
        /// Local Reference to a procedure.<para/>
        /// Type: <see cref="REFSYM2"/>
        /// </summary>
        S_LPROCREF = 0x1127,

        /// <summary>
        /// Reference to an S_ANNOTATION symbol.<para/>
        /// Type: <see cref="REFSYM2"/>
        /// </summary>
        S_ANNOTATIONREF = 0x1128,

        /// <summary>
        /// Reference to one of the many MANPROCSYM's.<para/>
        /// Type: <see cref="REFSYM2"/>
        /// </summary>
        S_TOKENREF = 0x1129,

        // continuation of managed symbols
        /// <summary>
        /// Global proc.<para/>
        /// Type: <see cref="MANPROCSYM"/>
        /// </summary>
        S_GMANPROC = 0x112a,

        /// <summary>
        /// Local proc.<para/>
        /// Type: <see cref="MANPROCSYM"/>
        /// </summary>
        S_LMANPROC = 0x112b,

        // short, light-weight thunks
        /// <summary>
        /// trampoline thunks.<para/>
        /// Type: <see cref="TRAMPOLINESYM"/>
        /// </summary>
        S_TRAMPOLINE = 0x112c,

        /// <summary>
        /// constants with metadata type info.<para/>
        /// Type: <see cref="CONSTSYM"/>
        /// </summary>
        S_MANCONSTANT = 0x112d,

        // native attributed local/parms

        /// <summary>
        /// relative to virtual frame ptr.<para/>
        /// Type: <see cref="FRAMERELSYM"/> (also known as ATTRFRAMERELSYM)
        /// </summary>
        S_ATTR_FRAMEREL = 0x112e,

        /// <summary>
        /// stored in a register.<para/>
        /// Type: <see cref="ATTRREGSYM"/>
        /// </summary>
        S_ATTR_REGISTER = 0x112f,

        /// <summary>
        /// relative to register (alternate frame ptr).<para/>
        /// Type: <see cref="ATTRREGREL"/> (also known as ATTRREGRELSYM)
        /// </summary>
        S_ATTR_REGREL = 0x1130,

        /// <summary>
        /// stored in >1 register.<para/>
        /// Type: <see cref="ATTRMANYREGSYM2"/>
        /// </summary>
        S_ATTR_MANYREG = 0x1131,

        // Separated code (from the compiler) support
        S_SEPCODE = 0x1132, //SEPCODESYM

        /// <summary>
        /// defines a local symbol in optimized code.<para/>
        /// Type: Unknown
        /// </summary>
        S_LOCAL_2005 = 0x1133,

        /// <summary>
        /// defines a single range of addresses in which symbol can be evaluated.<para/>
        /// Type: Unknown
        /// </summary>
        S_DEFRANGE_2005 = 0x1134,

        /// <summary>
        /// defines ranges of addresses in which symbol can be evaluated.<para/>
        /// Type: Unknown
        /// </summary>
        S_DEFRANGE2_2005 = 0x1135,

        /// <summary>
        /// A COFF section in a PE executable.<para/>
        /// Type: <see cref="SECTIONSYM"/>
        /// </summary>
        S_SECTION = 0x1136,

        /// <summary>
        /// A COFF group.<para/>
        /// Type: <see cref="COFFGROUPSYM"/>
        /// </summary>
        S_COFFGROUP = 0x1137,

        /// <summary>
        /// A export.<para/>
        /// Type: <see cref="EXPORTSYM"/>
        /// </summary>
        S_EXPORT = 0x1138,

        /// <summary>
        /// Indirect call site information.<para/>
        /// Type: <see cref="CALLSITEINFO"/>
        /// </summary>
        S_CALLSITEINFO = 0x1139,

        /// <summary>
        /// Security cookie information.<para/>
        /// Type: <see cref="FRAMECOOKIE"/>
        /// </summary>
        S_FRAMECOOKIE = 0x113a,

        /// <summary>
        /// Discarded by LINK /OPT:REF (experimental, see richards).<para/>
        /// Type: <see cref="DISCARDEDSYM"/>
        /// </summary>
        S_DISCARDED = 0x113b,

        /// <summary>
        /// Replacement for S_COMPILE2.<para/>
        /// Type: <see cref="COMPILESYM3"/>
        /// </summary>
        S_COMPILE3 = 0x113c,

        /// <summary>
        /// Environment block split off from S_COMPILE2.<para/>
        /// Type: <see cref="ENVBLOCKSYM"/>
        /// </summary>
        S_ENVBLOCK = 0x113d,

        /// <summary>
        /// defines a local symbol in optimized code.<para/>
        /// Type: <see cref="LOCALSYM"/>
        /// </summary>
        S_LOCAL = 0x113e,

        /// <summary>
        /// defines a single range of addresses in which symbol can be evaluated.<para/>
        /// Type: <see cref="DEFRANGESYM"/>
        /// </summary>
        S_DEFRANGE = 0x113f,

        /// <summary>
        /// ranges for a subfield.<para/>
        /// Type: <see cref="DEFRANGESYMSUBFIELD"/>
        /// </summary>
        S_DEFRANGE_SUBFIELD = 0x1140,

        /// <summary>
        /// ranges for en-registered symbol.<para/>
        /// Type: <see cref="DEFRANGESYM"/>
        /// </summary>
        S_DEFRANGE_REGISTER = 0x1141,

        /// <summary>
        /// range for stack symbol.<para/>
        /// Type: <see cref="DEFRANGESYM"/>
        /// </summary>
        S_DEFRANGE_FRAMEPOINTER_REL = 0x1142,

        /// <summary>
        /// ranges for en-registered field of symbol.<para/>
        /// Type: <see cref="DEFRANGESYMSUBFIELD"/>
        /// </summary>
        S_DEFRANGE_SUBFIELD_REGISTER = 0x1143,

        /// <summary>
        /// range for stack symbol span valid full scope of function body, gap might apply.<para/>
        /// Type: <see cref="DEFRANGESYM"/>
        /// </summary>
        S_DEFRANGE_FRAMEPOINTER_REL_FULL_SCOPE = 0x1144,

        /// <summary>
        /// range for symbol address as register + offset.<para/>
        /// Type: <see cref="DEFRANGESYMSUBFIELD"/>
        /// </summary>
        S_DEFRANGE_REGISTER_REL = 0x1145,

        // S_PROC symbols that reference ID instead of type
        S_LPROC32_ID = 0x1146, //PROCSYM32
        S_GPROC32_ID = 0x1147, //PROCSYM32
        S_LPROCMIPS_ID = 0x1148, //PROCSYMMIPS
        S_GPROCMIPS_ID = 0x1149, //PROCSYMMIPS
        S_LPROCIA64_ID = 0x114a, //PROCSYMIA64
        S_GPROCIA64_ID = 0x114b, //PROCSYMIA64

        /// <summary>
        /// build information.<para/>
        /// Type: <see cref="BUILDINFOSYM"/>
        /// </summary>
        S_BUILDINFO = 0x114c,

        /// <summary>
        /// inlined function callsite.<para/>
        /// Type: <see cref="INLINESITESYM"/>
        /// </summary>
        S_INLINESITE = 0x114d,

        S_INLINESITE_END = 0x114e, //void
        S_PROC_ID_END = 0x114f, //void

        S_DEFRANGE_HLSL = 0x1150, //DEFRANGESYMHLSL
        S_GDATA_HLSL = 0x1151, //DATASYMHLSL
        S_LDATA_HLSL = 0x1152, //DATASYMHLSL

        S_FILESTATIC = 0x1153, //FILESTATICSYM

        /// <summary>
        /// DPC groupshared variable.<para/>
        /// Type: <see cref="LOCALDPCGROUPSHAREDSYM"/>
        /// </summary>
        S_LOCAL_DPC_GROUPSHARED = 0x1154,

        /// <summary>
        /// DPC local procedure start.<para/>
        /// Type: <see cref="PROCSYM32"/>
        /// </summary>
        S_LPROC32_DPC = 0x1155,

        S_LPROC32_DPC_ID = 0x1156, //PROCSYM32

        /// <summary>
        /// DPC pointer tag definition range.<para/>
        /// Type: <see cref="DEFRANGESYMHLSL"/>
        /// </summary>
        S_DEFRANGE_DPC_PTR_TAG = 0x1157,

        /// <summary>
        /// DPC pointer tag value to symbol record map.<para/>
        /// Type: <see cref="DPCSYMTAGMAP"/>
        /// </summary>
        S_DPC_SYM_TAG_MAP = 0x1158,

        S_ARMSWITCHTABLE = 0x1159, //ARMSWITCHTABLE
        S_CALLEES = 0x115a, //FUNCTIONLIST
        S_CALLERS = 0x115b, //FUNCTIONLIST
        S_POGODATA = 0x115c, //POGOINFO

        /// <summary>
        /// extended inline site information.<para/>
        /// Type: <see cref="INLINESITESYM2"/>
        /// </summary>
        S_INLINESITE2 = 0x115d,

        /// <summary>
        /// heap allocation site.<para/>
        /// Type: <see cref="HEAPALLOCSITE"/>
        /// </summary>
        S_HEAPALLOCSITE = 0x115e,

        /// <summary>
        /// only generated at link time.<para/>
        /// Type: <see cref="MODTYPEREF"/>
        /// </summary>
        S_MOD_TYPEREF = 0x115f,

        /// <summary>
        /// only generated at link time for mini PDB.<para/>
        /// Type: <see cref="REFMINIPDB"/>
        /// </summary>
        S_REF_MINIPDB = 0x1160,

        /// <summary>
        /// only generated at link time for mini PDB.<para/>
        /// Type: <see cref="PDBMAP"/>
        /// </summary>
        S_PDBMAP = 0x1161,

        S_GDATA_HLSL32 = 0x1162, //DATASYMHLSL32
        S_LDATA_HLSL32 = 0x1163, //DATASYMHLSL32

        S_GDATA_HLSL32_EX = 0x1164, //DATASYMHLSL32_EX
        S_LDATA_HLSL32_EX = 0x1165, //DATASYMHLSL32_EX

        //There are additional types that are not known that are used by DIA internally, including 0x1172-0x1175

        /// <summary>
        /// one greater than last
        /// </summary>
        S_RECTYPE_MAX,

        S_RECTYPE_LAST = S_RECTYPE_MAX - 1,
        S_RECTYPE_PAD = S_RECTYPE_MAX + 0x100 // Used *only* to verify symbol record types so that current PDB code can potentially read
                                              // future PDBs (assuming no format change, etc).
    }
}
