using System.Diagnostics;

namespace ClrDebug.DIA
{
    /// <summary>
    /// Encapsulates the results of the <see cref="DiaSession.GetLinkInfo"/> method.
    /// </summary>
    [DebuggerDisplay("_b = {_b}, _c = {_c}, _d = {_d}, _e = {_e}, _f = {_f}")]
    public struct GetLinkInfoResult
    {
        public long _b { get; }

        public long _c { get; }

        public long _d { get; }

        public long _e { get; }

        public long _f { get; }

        public GetLinkInfoResult(long _b, long _c, long _d, long _e, long _f)
        {
            this._b = _b;
            this._c = _c;
            this._d = _d;
            this._e = _e;
            this._f = _f;
        }
    }
}
