﻿using System;
using System.Diagnostics;

namespace ClrDebug
{
    /// <summary>
    /// Encapsulates the results of the <see cref="SymUnmanagedSourceServerModule.SourceServerData"/> property.
    /// </summary>
    [DebuggerDisplay("pDataByteCount = {pDataByteCount}, ppData = {ppData.ToString(),nq}")]
    public struct SymUnmanagedSourceServerModule_GetSourceServerDataResult
    {
        /// <summary>
        /// A pointer to a ULONG32 that receives the size, in bytes, of the source server data.
        /// </summary>
        public int pDataByteCount { get; }

        /// <summary>
        /// A pointer to the returned pDataByteCount value.
        /// </summary>
        public IntPtr ppData { get; }

        public SymUnmanagedSourceServerModule_GetSourceServerDataResult(int pDataByteCount, IntPtr ppData)
        {
            this.pDataByteCount = pDataByteCount;
            this.ppData = ppData;
        }
    }
}
