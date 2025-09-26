using System.Diagnostics;

namespace ClrDebug.PDB
{
    [DebuggerDisplay("LocalId = 0x{LocalId.ToString(\"X\"),nq}, IsCrossScopeId = {IsCrossScopeId(crossScopeId)}")]
    public readonly struct CrossScopeId
    {
        public const int LocalIdBitWidth = 20;
        public const int IdScopeBitWidth = 11;
        public const uint StartCrossScopeId = unchecked((1u << (LocalIdBitWidth + IdScopeBitWidth)));
        public const uint LocalIdMask = (1 << LocalIdBitWidth) - 1;
        public const uint ScopeIdMask = StartCrossScopeId - (1 << LocalIdBitWidth);

        // Compilation unit at most reference 1M constructed type.
        public const uint MaxLocalId = (1 << LocalIdBitWidth) - 1;

        // Compilation unit at most reference to another 2K compilation units.
        public const uint MaxScopeId = (1 << IdScopeBitWidth) - 1;

        public static bool IsCrossScopeId(uint i) => (StartCrossScopeId & i) != 0;

        public static CrossScopeId Decode(uint i) => new CrossScopeId(i);

        private readonly uint crossScopeId;

        public uint LocalId => crossScopeId & LocalIdMask;

        public CrossScopeId(ushort aIdScopeId, uint aLocalId)
        {
            crossScopeId = (uint) (StartCrossScopeId
                           | (aIdScopeId << LocalIdBitWidth)
                           | aLocalId);
        }

        public static implicit operator uint(CrossScopeId value) => value.crossScopeId;
        public static implicit operator CrossScopeId(CV_ItemId value) => new CrossScopeId(value.Value);

        private CrossScopeId(uint i)
        {
            crossScopeId = i;
        }
    }
}
