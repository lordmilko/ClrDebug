namespace ClrDebug.PDB
{
    public enum EC
    {
        /// <summary>
        /// no problem
        /// </summary>
        EC_OK,

        /// <summary>
        /// invalid parameter or call order
        /// </summary>
        EC_USAGE,

        /// <summary>
        /// out of heap
        /// </summary>
        EC_OUT_OF_MEMORY,

        /// <summary>
        /// "pdb name", can't write file, out of disk, etc.
        /// </summary>
        EC_FILE_SYSTEM,

        /// <summary>
        /// "pdb name", PDB file not found
        /// </summary>
        EC_NOT_FOUND,

        /// <summary>
        /// "pdb name", PDB::OpenValidate() and its clients only
        /// </summary>
        EC_INVALID_SIG,

        /// <summary>
        /// "pdb name", PDB::OpenValidate() and its clients only
        /// </summary>
        EC_INVALID_AGE,

        /// <summary>
        /// "obj name", Mod::AddTypes() only
        /// </summary>
        EC_PRECOMP_REQUIRED,

        /// <summary>
        /// "pdb name", TPI::QueryTiForCVRecord() only
        /// </summary>
        EC_OUT_OF_TI,

        /// <summary>
        /// -
        /// </summary>
        EC_NOT_IMPLEMENTED,

        /// <summary>
        /// "pdb name", PDB::Open* only (obsolete)
        /// </summary>
        EC_V1_PDB,

        /// <summary>
        /// pdb can't be opened because it has newer versions of stuff
        /// </summary>
        EC_UNKNOWN_FORMAT = EC_V1_PDB,

        /// <summary>
        /// accessing pdb with obsolete format
        /// </summary>
        EC_FORMAT,

        EC_LIMIT,

        /// <summary>
        /// cv info corrupt, recompile mod
        /// </summary>
        EC_CORRUPT,

        /// <summary>
        /// no 16-bit type interface present
        /// </summary>
        EC_TI16,

        /// <summary>
        /// "pdb name", PDB file read-only
        /// </summary>
        EC_ACCESS_DENIED,

        /// <summary>
        /// trying to edit types in read-only mode
        /// </summary>
        EC_ILLEGAL_TYPE_EDIT,

        /// <summary>
        /// not recogized as a valid executable
        /// </summary>
        EC_INVALID_EXECUTABLE,

        /// <summary>
        /// A required .DBG file was not found
        /// </summary>
        EC_DBG_NOT_FOUND,

        /// <summary>
        /// No recognized debug info found
        /// </summary>
        EC_NO_DEBUG_INFO,

        /// <summary>
        /// Invalid timestamp on Openvalidate of exe
        /// </summary>
        EC_INVALID_EXE_TIMESTAMP,

        /// <summary>
        /// A corrupted type record was found in a PDB
        /// </summary>
        EC_CORRUPT_TYPEPOOL,

        /// <summary>
        /// returned by OpenValidateX
        /// </summary>
        EC_DEBUG_INFO_NOT_IN_PDB,

        /// <summary>
        /// Error occured during RPC
        /// </summary>
        EC_RPC,

        /// <summary>
        /// Unknown error
        /// </summary>
        EC_UNKNOWN,

        /// <summary>
        /// bad cache location specified with symsrv
        /// </summary>
        EC_BAD_CACHE_PATH,

        /// <summary>
        /// symsrv cache is full
        /// </summary>
        EC_CACHE_FULL,

        /// <summary>
        /// Addtype is called more then once per mod
        /// </summary>
        EC_TOO_MANY_MOD_ADDTYPE,

        EC_MAX
    }
}
