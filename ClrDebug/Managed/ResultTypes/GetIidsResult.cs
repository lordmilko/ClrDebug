using System;
using System.Diagnostics;

namespace ClrDebug
{
    /// <summary>
    /// Encapsulates the results of the <see cref="Inspectable.Iids"/> property.
    /// </summary>
    [DebuggerDisplay("iidCount = {iidCount}, iids = {iids.ToString(),nq}")]
    public struct GetIidsResult
    {
        public int iidCount { get; }

        public IntPtr iids { get; }

        public GetIidsResult(int iidCount, IntPtr iids)
        {
            this.iidCount = iidCount;
            this.iids = iids;
        }
    }
}
