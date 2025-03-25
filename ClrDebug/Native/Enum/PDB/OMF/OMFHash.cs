namespace ClrDebug.PDB
{
    public enum OMFHash
    {
        /// <summary>
        /// no hashing
        /// </summary>
        OMFHASH_NONE,

        /// <summary>
        /// upper case sum of chars in 16 bit table
        /// </summary>
        OMFHASH_SUMUC16,

        /// <summary>
        /// upper case sum of chars in 32 bit table
        /// </summary>
        OMFHASH_SUMUC32,

        /// <summary>
        /// sorted by increasing address in 16 bit table
        /// </summary>
        OMFHASH_ADDR16,

        /// <summary>
        /// sorted by increasing address in 32 bit table
        /// </summary>
        OMFHASH_ADDR32
    }
}
