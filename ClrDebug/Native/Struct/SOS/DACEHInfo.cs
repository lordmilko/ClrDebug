using System.Diagnostics;
using System.Runtime.InteropServices;

namespace ClrDebug
{
    [DebuggerDisplay("clauseType = {clauseType.ToString(),nq}, tryStartOffset = {tryStartOffset.ToString(),nq}, tryEndOffset = {tryEndOffset.ToString(),nq}, handlerStartOffset = {handlerStartOffset.ToString(),nq}, handlerEndOffset = {handlerEndOffset.ToString(),nq}, isDuplicateClause = {isDuplicateClause}, filterOffset = {filterOffset.ToString(),nq}, isCatchAllHandler = {isCatchAllHandler}, moduleAddr = {moduleAddr.ToString(),nq}, mtCatch = {mtCatch.ToString(),nq}, tokCatch = {tokCatch.ToString(),nq}")]
    [StructLayout(LayoutKind.Sequential)]
    public partial struct DACEHInfo
    {
        public EHClauseType clauseType;
        public CLRDATA_ADDRESS tryStartOffset;
        public CLRDATA_ADDRESS tryEndOffset;
        public CLRDATA_ADDRESS handlerStartOffset;
        public CLRDATA_ADDRESS handlerEndOffset;
        public bool isDuplicateClause;
        public CLRDATA_ADDRESS filterOffset;
        public bool isCatchAllHandler;
        public CLRDATA_ADDRESS moduleAddr;
        public CLRDATA_ADDRESS mtCatch;
        public mdToken tokCatch;
    }
}
