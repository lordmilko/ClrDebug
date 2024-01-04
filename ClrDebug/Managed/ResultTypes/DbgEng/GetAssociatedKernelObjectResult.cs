using System.Diagnostics;

namespace ClrDebug.DbgEng
{
    /// <summary>
    /// Encapsulates the results of the <see cref="SvcOSKernelObject.AssociatedKernelObject"/> property.
    /// </summary>
    [DebuggerDisplay("kernelObjectAddress = {kernelObjectAddress}, kernelAddressContext = {kernelAddressContext?.ToString(),nq}, kernelModule = {kernelModule?.ToString(),nq}, kernelObjectType = {kernelObjectType?.ToString(),nq}")]
    public struct GetAssociatedKernelObjectResult
    {
        public long kernelObjectAddress { get; }

        public SvcAddressContext kernelAddressContext { get; }

        public SvcModule kernelModule { get; }

        public SvcSymbol kernelObjectType { get; }

        public GetAssociatedKernelObjectResult(long kernelObjectAddress, SvcAddressContext kernelAddressContext, SvcModule kernelModule, SvcSymbol kernelObjectType)
        {
            this.kernelObjectAddress = kernelObjectAddress;
            this.kernelAddressContext = kernelAddressContext;
            this.kernelModule = kernelModule;
            this.kernelObjectType = kernelObjectType;
        }
    }
}
