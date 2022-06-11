namespace ManagedCorDebug
{
    public struct GetEHClausesResult
    {
        public uint PcClauses { get; }

        public CorDebugEHClause[] Clauses { get; }

        public GetEHClausesResult(uint pcClauses, CorDebugEHClause[] clauses)
        {
            PcClauses = pcClauses;
            Clauses = clauses;
        }
    }
}