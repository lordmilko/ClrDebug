namespace ManagedCorDebug
{
    public struct GetEHClausesResult
    {
        public int PcClauses { get; }

        public CorDebugEHClause[] Clauses { get; }

        public GetEHClausesResult(int pcClauses, CorDebugEHClause[] clauses)
        {
            PcClauses = pcClauses;
            Clauses = clauses;
        }
    }
}