using System.Diagnostics;

namespace ClrDebug
{
    /// <summary>
    /// Encapsulates the results of the <see cref="XCLRDataProcess.FollowStub2"/> method.
    /// </summary>
    [DebuggerDisplay("outAddr = {outAddr.ToString(),nq}, outBuffer = {outBuffer.ToString(),nq}, outFlags = {outFlags.ToString(),nq}")]
    public struct FollowStub2Result
    {
        public CLRDATA_ADDRESS outAddr { get; }

        public CLRDATA_FOLLOW_STUB_BUFFER outBuffer { get; }

        public CLRDataFollowStubOutFlag outFlags { get; }

        public FollowStub2Result(CLRDATA_ADDRESS outAddr, CLRDATA_FOLLOW_STUB_BUFFER outBuffer, CLRDataFollowStubOutFlag outFlags)
        {
            this.outAddr = outAddr;
            this.outBuffer = outBuffer;
            this.outFlags = outFlags;
        }
    }
}
