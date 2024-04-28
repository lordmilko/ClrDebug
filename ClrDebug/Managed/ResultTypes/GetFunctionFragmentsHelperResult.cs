using System.Diagnostics;

namespace ClrDebug.DIA
{
    /// <summary>
    /// Encapsulates the results of the <see cref="DiaSession.GetFunctionFragmentsHelper"/> method.
    /// </summary>
    [DebuggerDisplay("_d = {_d}, _e = {_e}, _f = {_f}")]
    public struct GetFunctionFragmentsHelperResult
    {
        public long _d { get; }

        public long _e { get; }

        public long _f { get; }

        public GetFunctionFragmentsHelperResult(long _d, long _e, long _f)
        {
            this._d = _d;
            this._e = _e;
            this._f = _f;
        }
    }
}
