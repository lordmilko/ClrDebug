using System;
using System.Diagnostics;

namespace ClrDebug
{
    /// <summary>
    /// Encapsulates the results of the <see cref="RecordInfo.GetFieldNoCopy"/> method.
    /// </summary>
    [DebuggerDisplay("pvarField = {pvarField}, ppvDataCArray = {ppvDataCArray.ToString(),nq}")]
    public struct GetFieldNoCopyResult
    {
        public object pvarField { get; }

        public IntPtr ppvDataCArray { get; }

        public GetFieldNoCopyResult(object pvarField, IntPtr ppvDataCArray)
        {
            this.pvarField = pvarField;
            this.ppvDataCArray = ppvDataCArray;
        }
    }
}
