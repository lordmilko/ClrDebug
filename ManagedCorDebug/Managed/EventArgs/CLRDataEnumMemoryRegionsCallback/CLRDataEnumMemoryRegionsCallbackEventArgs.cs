using System;

namespace ManagedCorDebug
{
    /// <summary>
    /// Represents an event that occurred from one of the methods in the <see cref="ICLRDataEnumMemoryRegionsCallback"/> interface or its derivatives.
    /// </summary>
    public abstract class CLRDataEnumMemoryRegionsCallbackEventArgs : EventArgs
    {
        /// <summary>
        /// Gets the type of callback event that occurred.
        /// </summary>
        public abstract CLRDataEnumMemoryRegionsCallbackKind Kind { get; }
    }
}