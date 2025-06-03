namespace ClrDebug.PDB
{
    public enum DBGTYPE
    {
        /// <summary>
        /// Data type: <see cref="FPO_DATA"/>
        /// </summary>
        dbgtypeFPO,

        /// <summary>
        /// deprecated<para/>
        /// Data type: IMAGE_FUNCTION_ENTRY
        /// </summary>
        dbgtypeException, //Not sure if it's IMAGE_FUNCTION_ENTRY / IMAGE_FUNCTION_ENTRY64? DbgFunc1 just said IMAGE_FUNCTION_ENTRY though

        /// <summary>
        /// Data type: <see cref="XFIXUP_DATA"/>
        /// </summary>
        dbgtypeFixup,

        /// <summary>
        /// Data type: <see cref="OMAP_DATA"/>.
        /// </summary>
        dbgtypeOmapToSrc,

        /// <summary>
        /// Data type: <see cref="OMAP_DATA"/>
        /// </summary>
        dbgtypeOmapFromSrc,

        /// <summary>
        /// Data type: <see cref="IMAGE_SECTION_HEADER"/>
        /// </summary>
        dbgtypeSectionHdr,

        /// <summary>
        /// Data type: int
        /// </summary>
        dbgtypeTokenRidMap,

        /// <summary>
        /// Data type: <see cref="DbgRvaVaBlob"/>
        /// </summary>
        dbgtypeXdata,

        /// <summary>
        /// Data type: <see cref="DbgRvaVaBlob"/>
        /// </summary>
        dbgtypePdata,

        /// <summary>
        /// Data type: <see cref="FRAMEDATA"/>
        /// </summary>
        dbgtypeNewFPO,

        /// <summary>
        /// Data type: <see cref="IMAGE_SECTION_HEADER"/>
        /// </summary>
        dbgtypeSectionHdrOrig,

        dbgtypeMax          // must be last!
    }
}
