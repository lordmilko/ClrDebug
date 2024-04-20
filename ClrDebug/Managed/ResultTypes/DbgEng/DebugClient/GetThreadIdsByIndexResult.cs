using System.Diagnostics;

namespace ClrDebug.DbgEng
{
    /// <summary>
    /// Encapsulates the results of the <see cref="DebugSystemObjects.GetThreadIdsByIndex"/> method.
    /// </summary>
    [DebuggerDisplay("Ids = {Ids}, SysIds = {SysIds}")]
    public struct GetThreadIdsByIndexResult
    {
        /// <summary>
        /// Receives the engine thread IDs. If Ids is NULL, this information is not returned; otherwise, Ids is treated as an array of Count ULONG values.
        /// </summary>
        public int[] Ids { get; }

        /// <summary>
        /// Receives the system thread IDs. If SysIds is NULL, this information is not returned; otherwise, SysIds is treated as an array of Count ULONG values.
        /// </summary>
        public int[] SysIds { get; }

        public GetThreadIdsByIndexResult(int[] ids, int[] sysIds)
        {
            Ids = ids;
            SysIds = sysIds;
        }
    }
}
