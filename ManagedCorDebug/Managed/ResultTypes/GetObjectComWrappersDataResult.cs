using System.Diagnostics;

namespace ManagedCorDebug
{
    /// <summary>
    /// Encapsulates the results of the <see cref="SOSDacInterface.GetObjectComWrappersData"/> method.
    /// </summary>
    [DebuggerDisplay("rcw = {rcw}, mowList = {mowList}")]
    public struct GetObjectComWrappersDataResult
    {
        public CLRDATA_ADDRESS rcw { get; }

        public CLRDATA_ADDRESS[] mowList { get; }

        public GetObjectComWrappersDataResult(CLRDATA_ADDRESS rcw, CLRDATA_ADDRESS[] mowList)
        {
            this.rcw = rcw;
            this.mowList = mowList;
        }
    }
}