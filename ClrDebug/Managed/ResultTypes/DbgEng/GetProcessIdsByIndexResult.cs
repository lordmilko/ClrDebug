﻿using System.Diagnostics;

namespace ClrDebug.DbgEng
{
    /// <summary>
    /// Encapsulates the results of the <see cref="DebugSystemObjects.GetProcessIdsByIndex"/> method.
    /// </summary>
    [DebuggerDisplay("Ids = {Ids}, SysIds = {SysIds}")]
    public struct GetProcessIdsByIndexResult
    {
        /// <summary>
        /// Receives the engine process IDs. If Ids is NULL, this information is not returned; otherwise, Ids is treated as an array of Count ULONG values.
        /// </summary>
        public uint[] Ids { get; }

        /// <summary>
        /// Receives the system process IDs. If SysIds is NULL, this information is not returned; otherwise, SysIds is treated as an array of Count ULONG values.
        /// </summary>
        public uint[] SysIds { get; }

        public GetProcessIdsByIndexResult(uint[] ids, uint[] sysIds)
        {
            Ids = ids;
            SysIds = sysIds;
        }
    }
}
