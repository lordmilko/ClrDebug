namespace ClrDebug.DbgEng
{
    public class SvcAddressContextHardware : ComObject<ISvcAddressContextHardware>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SvcAddressContextHardware"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
        public SvcAddressContextHardware(ISvcAddressContextHardware raw) : base(raw)
        {
        }

        #region ISvcAddressContextHardware
        #region PagingLevels

        /// <summary>
        /// Gets the number of paging levels mode that the hardware is utilizing.
        /// </summary>
        public int PagingLevels
        {
            get
            {
                int pagingLevels;
                TryGetPagingLevels(out pagingLevels).ThrowDbgEngNotOK();

                return pagingLevels;
            }
        }

        /// <summary>
        /// Gets the number of paging levels mode that the hardware is utilizing.
        /// </summary>
        public HRESULT TryGetPagingLevels(out int pagingLevels)
        {
            /*HRESULT GetPagingLevels(
            [Out] out int pagingLevels);*/
            return Raw.GetPagingLevels(out pagingLevels);
        }

        #endregion
        #region GetDirectoryBase

        /// <summary>
        /// Gets the directory base for this address context (represented as hardware -- e.g.: a processor) e.g.: For a AMD64 processor, this interface would return the CR3 value.
        /// </summary>
        public long GetDirectoryBase(DirectoryBaseKind dirKind)
        {
            long directoryBase;
            TryGetDirectoryBase(dirKind, out directoryBase).ThrowDbgEngNotOK();

            return directoryBase;
        }

        /// <summary>
        /// Gets the directory base for this address context (represented as hardware -- e.g.: a processor) e.g.: For a AMD64 processor, this interface would return the CR3 value.
        /// </summary>
        public HRESULT TryGetDirectoryBase(DirectoryBaseKind dirKind, out long directoryBase)
        {
            /*HRESULT GetDirectoryBase(
            [In] DirectoryBaseKind dirKind,
            [Out] out long directoryBase);*/
            return Raw.GetDirectoryBase(dirKind, out directoryBase);
        }

        #endregion
        #endregion
    }
}
