namespace ClrDebug
{
    /// <summary>
    /// Provides a method to enumerate regions of memory that are specified by callers.
    /// </summary>
    public class CLRDataEnumMemoryRegions : ComObject<ICLRDataEnumMemoryRegions>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CLRDataEnumMemoryRegions"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
        public CLRDataEnumMemoryRegions(ICLRDataEnumMemoryRegions raw) : base(raw)
        {
        }

        #region ICLRDataEnumMemoryRegions
        #region EnumMemoryRegions

        /// <summary>
        /// Enumerates specified areas of memory.
        /// </summary>
        /// <param name="callback">[in] A pointer to an <see cref="ICLRDataEnumMemoryRegionsCallback"/> instance that is called by this method for each memory region being enumerated to notify the debugger of the result.<para/>
        /// The enumeration of memory regions continues even if the callback indicates a failure.</param>
        /// <param name="miniDumpFlags">[in] Not used.</param>
        /// <param name="clrFlags">[in] A value of the <see cref="CLRDataEnumMemoryFlags"/> enumeration that specifies the regions of memory to be enumerated.</param>
        /// <remarks>
        /// This method uses the specified <see cref="ICLRDataEnumMemoryRegionsCallback"/> instance to notify the caller of
        /// results.
        /// </remarks>
        public void EnumMemoryRegions(ICLRDataEnumMemoryRegionsCallback callback, int miniDumpFlags, CLRDataEnumMemoryFlags clrFlags)
        {
            TryEnumMemoryRegions(callback, miniDumpFlags, clrFlags).ThrowOnNotOK();
        }

        /// <summary>
        /// Enumerates specified areas of memory.
        /// </summary>
        /// <param name="callback">[in] A pointer to an <see cref="ICLRDataEnumMemoryRegionsCallback"/> instance that is called by this method for each memory region being enumerated to notify the debugger of the result.<para/>
        /// The enumeration of memory regions continues even if the callback indicates a failure.</param>
        /// <param name="miniDumpFlags">[in] Not used.</param>
        /// <param name="clrFlags">[in] A value of the <see cref="CLRDataEnumMemoryFlags"/> enumeration that specifies the regions of memory to be enumerated.</param>
        /// <remarks>
        /// This method uses the specified <see cref="ICLRDataEnumMemoryRegionsCallback"/> instance to notify the caller of
        /// results.
        /// </remarks>
        public HRESULT TryEnumMemoryRegions(ICLRDataEnumMemoryRegionsCallback callback, int miniDumpFlags, CLRDataEnumMemoryFlags clrFlags)
        {
            /*HRESULT EnumMemoryRegions(
            [MarshalAs(UnmanagedType.Interface), In] ICLRDataEnumMemoryRegionsCallback callback,
            [In] int miniDumpFlags,
            [In] CLRDataEnumMemoryFlags clrFlags);*/
            return Raw.EnumMemoryRegions(callback, miniDumpFlags, clrFlags);
        }

        #endregion
        #endregion
    }
}
