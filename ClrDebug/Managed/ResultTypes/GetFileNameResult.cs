using System;
using System.Diagnostics;

namespace ClrDebug.TTD
{
    /// <summary>
    /// Encapsulates the results of the <see cref="LiveRecorder.GetFileName"/> method.
    /// </summary>
    [DebuggerDisplay("pFileName = {pFileName}, val = {val.ToString(),nq}")]
    public struct GetFileNameResult
    {
        public string pFileName { get; }

        public IntPtr val { get; }

        public GetFileNameResult(string pFileName, IntPtr val)
        {
            this.pFileName = pFileName;
            this.val = val;
        }
    }
}
