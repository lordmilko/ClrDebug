using System.Diagnostics;

namespace ClrDebug.DIA
{
    /// <summary>
    /// Encapsulates the results of the <see cref="DiaSession.FindSectionAddressByCrc"/> method.
    /// </summary>
    [DebuggerDisplay("_f = {_f}, _g = {_g}, _h = {_h}")]
    public struct FindSectionAddressByCrcResult
    {
        public long _f { get; }

        public long _g { get; }

        public long _h { get; }

        public FindSectionAddressByCrcResult(long _f, long _g, long _h)
        {
            this._f = _f;
            this._g = _g;
            this._h = _h;
        }
    }
}
