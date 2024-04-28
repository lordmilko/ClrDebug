namespace ClrDebug.PDB
{
    public enum CEXM_MODEL_e
    {
        /// <summary>
        /// not executable
        /// </summary>
        CEXM_MDL_table = 0x00,

        /// <summary>
        /// Compiler generated jump table
        /// </summary>
        CEXM_MDL_jumptable = 0x01,

        /// <summary>
        /// Data padding for alignment
        /// </summary>
        CEXM_MDL_datapad = 0x02,

        /// <summary>
        /// native (actually not-pcode)
        /// </summary>
        CEXM_MDL_native = 0x20,

        /// <summary>
        /// cobol
        /// </summary>
        CEXM_MDL_cobol = 0x21,

        /// <summary>
        /// Code padding for alignment
        /// </summary>
        CEXM_MDL_codepad = 0x22,

        /// <summary>
        /// code
        /// </summary>
        CEXM_MDL_code = 0x23,

        /// <summary>
        /// sql
        /// </summary>
        CEXM_MDL_sql = 0x30,

        /// <summary>
        /// pcode
        /// </summary>
        CEXM_MDL_pcode = 0x40,

        /// <summary>
        /// macintosh 32 bit pcode
        /// </summary>
        CEXM_MDL_pcode32Mac = 0x41,

        /// <summary>
        /// macintosh 32 bit pcode native entry point
        /// </summary>
        CEXM_MDL_pcode32MacNep = 0x42,

        CEXM_MDL_javaInt = 0x50,
        CEXM_MDL_unknown = 0xff
    }
}
