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
        /// Receives the engine thread IDs. If Ids is NULL, this information is not returned; otherwise, Ids is treated as an array of Count ULONG valuess.
        /// </summary>
        public uint[] Ids { get; }

        /// <summary>
        /// Receives the system thread IDs. If SysIds is NULL, this information is not returned; otherwise, SysIds is treated as an array of Count ULONG values.
        /// </summary>
        public uint[] SysIds { get; }

        public GetThreadIdsByIndexResult(uint[] ids, uint[] sysIds)
        {
            Ids = ids;
            SysIds = sysIds;
        }
    }
}
