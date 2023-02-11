namespace ClrDebug
{
    public enum STGC
    {
        /// <summary>
        /// You can specify this condition with STGC_CONSOLIDATE, or some combination of the other three flags in this list of elements. Use this value to increase the readability of code.
        /// </summary>
        STGC_DEFAULT = 0,

        /// <summary>
        /// The commit operation can overwrite existing data to reduce overall space requirements.
        /// This value is not recommended for typical usage because it is not as robust as the default value.<para/>
        /// In this case, it is possible for the commit operation to fail after the old data is overwritten, but before the new data is completely committed.
        /// Then, neither the old version nor the new version of the storage object will be intact.
        /// </summary>
        STGC_OVERWRITE = 1,

        /// <summary>
        /// Prevents multiple users of a storage object from overwriting each other's changes.
        /// The commit operation occurs only if there have been no changes to the saved storage object because the user most recently opened it.
        /// Thus, the saved version of the storage object is the same version that the user has been editing.<para/>
        /// If other users have changed the storage object, the commit operation fails and returns the STG_E_NOTCURRENT value.
        /// To override this behavior, call the IStorage::Commit or IStream::Commit method again using the STGC_DEFAULT value.
        /// </summary>
        STGC_ONLYIFCURRENT = 2,

        /// <summary>
        /// Commits the changes to a write-behind disk cache, but does not save the cache to the disk.
        /// In a write-behind disk cache, the operation that writes to disk actually writes to a disk cache, thus increasing performance.<para/>
        /// The cache is eventually written to the disk, but usually not until after the write operation has already returned.
        /// The performance increase comes at the expense of an increased risk of losing data if a problem occurs before the cache is saved and the data in the cache is lost.
        /// </summary>
        STGC_DANGEROUSLYCOMMITMERELYTODISKCACHE = 4,

        /// <summary>
        /// Windows 2000 and Windows XP: Indicates that a storage should be consolidated after it is committed, resulting in a smaller file on disk.
        /// This flag is valid only on the outermost storage object that has been opened in transacted mode. It is not valid for streams.
        /// The STGC_CONSOLIDATE flag can be combined with any other STGC flags.
        /// </summary>
        STGC_CONSOLIDATE = 8
    }
}
