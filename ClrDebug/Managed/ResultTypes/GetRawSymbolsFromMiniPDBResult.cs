using System;
using System.Diagnostics;

namespace ClrDebug.DIA
{
    /// <summary>
    /// Encapsulates the results of the <see cref="DiaSession.GetRawSymbolsFromMiniPDB"/> method.
    /// </summary>
    [DebuggerDisplay("_c = {_c}, _d = {_d.ToString(),nq}")]
    public struct GetRawSymbolsFromMiniPDBResult
    {
        public long _c { get; }

        public IntPtr _d { get; }

        public GetRawSymbolsFromMiniPDBResult(long _c, IntPtr _d)
        {
            this._c = _c;
            this._d = _d;
        }
    }
}
