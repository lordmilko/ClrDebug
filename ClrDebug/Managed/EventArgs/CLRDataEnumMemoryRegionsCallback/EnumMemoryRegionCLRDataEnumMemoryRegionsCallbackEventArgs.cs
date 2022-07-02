namespace ClrDebug
{
    /// <summary>
    /// Represents the arguments that were passed to the <see cref="ICLRDataEnumMemoryRegionsCallback.EnumMemoryRegion"/> method.
    /// </summary>
    public class EnumMemoryRegionCLRDataEnumMemoryRegionsCallbackEventArgs : CLRDataEnumMemoryRegionsCallbackEventArgs
    {
        /// <summary>
        /// Gets the type of callback event that occurred.
        /// </summary>
        public override CLRDataEnumMemoryRegionsCallbackKind Kind => CLRDataEnumMemoryRegionsCallbackKind.EnumMemoryRegion;

        /// <summary>
        /// The starting address of the memory region that was to be enumerated.
        /// </summary>
        public CLRDATA_ADDRESS Address { get; }

        /// <summary>
        /// The size, in bytes, of the memory region.
        /// </summary>
        public int Size { get; }

        /// <summary>
        /// Called by <see cref="ICLRDataEnumMemoryRegions.EnumMemoryRegions"/> to report to the debugger the result of an attempt to enumerate a specified region of memory.
        /// </summary>
        /// <param name="address">The starting address of the memory region that was to be enumerated.</param>
        /// <param name="size">The size, in bytes, of the memory region.</param>
        public EnumMemoryRegionCLRDataEnumMemoryRegionsCallbackEventArgs(CLRDATA_ADDRESS address, int size)
        {
            Address = address;
            Size = size;
        }
    }
}