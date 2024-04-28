using System.Diagnostics;

namespace ClrDebug.DIA
{
    /// <summary>
    /// Encapsulates the results of the <see cref="DiaSession.PdbMappingsForMiniPDB"/> property.
    /// </summary>
    [DebuggerDisplay("_a = {_a}, _b = {_b}, _c = {_c}")]
    public unsafe struct GetPdbMappingsForMiniPDBResult
    {
        public long _a { get; }

        public ushort* _b { get; }

        public ushort* _c { get; }

        public GetPdbMappingsForMiniPDBResult(long _a, ushort* _b, ushort* _c)
        {
            this._a = _a;
            this._b = _b;
            this._c = _c;
        }
    }
}
