namespace ClrDebug.PDB
{
    public enum DBGTYPE
    {
        dbgtypeFPO,

        /// <summary>
        /// deprecated
        /// </summary>
        dbgtypeException,

        dbgtypeFixup,
        dbgtypeOmapToSrc,
        dbgtypeOmapFromSrc,
        dbgtypeSectionHdr,
        dbgtypeTokenRidMap,
        dbgtypeXdata,
        dbgtypePdata,
        dbgtypeNewFPO,
        dbgtypeSectionHdrOrig,
        dbgtypeMax          // must be last!
    }
}
