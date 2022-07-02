using System;

namespace ClrDebug
{
    /// <summary>
    /// Represents the arguments that were passed to the <see cref="ICLRDataEnumMemoryRegionsCallback2.UpdateMemoryRegion"/> method.
    /// </summary>
    public class UpdateMemoryRegionCLRDataEnumMemoryRegionsCallbackEventArgs : CLRDataEnumMemoryRegionsCallbackEventArgs
    {
        /// <summary>
        /// Gets the type of callback event that occurred.
        /// </summary>
        public override CLRDataEnumMemoryRegionsCallbackKind Kind => CLRDataEnumMemoryRegionsCallbackKind.UpdateMemoryRegion;

        public CLRDATA_ADDRESS Address { get; }

        public int BufferSize { get; }

        public IntPtr Buffer { get; }

        public UpdateMemoryRegionCLRDataEnumMemoryRegionsCallbackEventArgs(CLRDATA_ADDRESS address, int bufferSize, IntPtr buffer)
        {
            Address = address;
            BufferSize = bufferSize;
            Buffer = buffer;
        }
    }
}