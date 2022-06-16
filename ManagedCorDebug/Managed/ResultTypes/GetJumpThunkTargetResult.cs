using System.Diagnostics;

namespace ManagedCorDebug
{
    /// <summary>
    /// Encapsulates the results of the <see cref="SOSDacInterface.GetJumpThunkTarget"/> method.
    /// </summary>
    [DebuggerDisplay("targetIP = {targetIP}, targetMD = {targetMD}")]
    public struct GetJumpThunkTargetResult
    {
        public CLRDATA_ADDRESS targetIP { get; }

        public CLRDATA_ADDRESS targetMD { get; }

        public GetJumpThunkTargetResult(CLRDATA_ADDRESS targetIP, CLRDATA_ADDRESS targetMD)
        {
            this.targetIP = targetIP;
            this.targetMD = targetMD;
        }
    }
}