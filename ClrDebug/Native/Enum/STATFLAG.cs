namespace ClrDebug
{
    public enum STATFLAG
    {
        /// <summary>
        /// Requests that the statistics include the pwcsName member of the STATSTG structure.
        /// </summary>
        STATFLAG_DEFAULT = 0,

        /// <summary>
        /// Requests that the statistics not include the pwcsName member of the STATSTG structure. If the name is omitted, there is no need for the ILockBytes::Stat, IStorage::Stat, and
        /// IStream::Stat methods methods to allocate and free memory for the string value of the name, therefore the method reduces time and resources used in an allocation and free operation.
        /// </summary>
        STATFLAG_NONAME = 1,

        /// <summary>
        /// Not implemented.
        /// </summary>
        STATFLAG_NOOPEN = 2
    }
}