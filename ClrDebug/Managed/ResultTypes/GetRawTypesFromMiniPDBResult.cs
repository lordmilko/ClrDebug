using System;
using System.Diagnostics;

namespace ClrDebug.DIA
{
    /// <summary>
    /// Encapsulates the results of the <see cref="DiaSession.GetRawTypesFromMiniPDB"/> method.
    /// </summary>
    [DebuggerDisplay("_b = {_b}, _c = {_c.ToString(),nq}")]
    public struct GetRawTypesFromMiniPDBResult
    {
        public long _b { get; }

        public IntPtr _c { get; }

        public GetRawTypesFromMiniPDBResult(long _b, IntPtr _c)
        {
            this._b = _b;
            this._c = _c;
        }
    }
}
