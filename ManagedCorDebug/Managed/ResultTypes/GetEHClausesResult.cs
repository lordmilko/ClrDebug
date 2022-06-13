using System.Diagnostics;

namespace ManagedCorDebug
{
    /// <summary>
    /// Encapsulates the results of the <see cref="CorDebugILCode.GetEHClauses"/> method.
    /// </summary>
    [DebuggerDisplay("pcClauses = {pcClauses}, clauses = {clauses}")]
    public struct GetEHClausesResult
    {
        /// <summary>
        /// The number of clauses about which information is written to the clauses array.
        /// </summary>
        public int pcClauses { get; }

        /// <summary>
        /// An array of <see cref="CorDebugEHClause"/> objects that contain information on exception handling clauses defined for this IL.
        /// </summary>
        public CorDebugEHClause[] clauses { get; }

        public GetEHClausesResult(int pcClauses, CorDebugEHClause[] clauses)
        {
            this.pcClauses = pcClauses;
            this.clauses = clauses;
        }
    }
}