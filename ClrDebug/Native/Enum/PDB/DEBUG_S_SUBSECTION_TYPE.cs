namespace ClrDebug.PDB
{
    public enum DEBUG_S_SUBSECTION_TYPE : uint
    {
        DEBUG_S_IGNORE = 0x80000000,    // if this bit is set in a subsection type then ignore the subsection contents

        DEBUG_S_SYMBOLS = 0xf1,
        DEBUG_S_LINES,
        DEBUG_S_STRINGTABLE,
        DEBUG_S_FILECHKSMS,
        DEBUG_S_FRAMEDATA,
        DEBUG_S_INLINEELINES,
        DEBUG_S_CROSSSCOPEIMPORTS,
        DEBUG_S_CROSSSCOPEEXPORTS,

        DEBUG_S_IL_LINES,
        DEBUG_S_FUNC_MDTOKEN_MAP,
        DEBUG_S_TYPE_MDTOKEN_MAP,
        DEBUG_S_MERGED_ASSEMBLYINPUT,

        DEBUG_S_COFF_SYMBOL_RVA,
    }
}
