using System.Diagnostics;

namespace ClrDebug.DbgEng
{
    /// <summary>
    /// Encapsulates the results of the <see cref="DebugHostFunctionLocalStorage.ExtendedRegisterAddressInfo"/> property.
    /// </summary>
    [DebuggerDisplay("registerId = {registerId}, offset = {offset}, isIndirectAccess = {isIndirectAccess}, indirectOffset = {indirectOffset}")]
    public struct GetExtendedRegisterAddressInfoResult
    {
        public int registerId { get; }

        public long offset { get; }

        public bool isIndirectAccess { get; }

        public int indirectOffset { get; }

        public GetExtendedRegisterAddressInfoResult(int registerId, long offset, bool isIndirectAccess, int indirectOffset)
        {
            this.registerId = registerId;
            this.offset = offset;
            this.isIndirectAccess = isIndirectAccess;
            this.indirectOffset = indirectOffset;
        }
    }
}
