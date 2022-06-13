using System.Diagnostics;

namespace ManagedCorDebug
{
    /// <summary>
    /// Encapsulates the results of the <see cref="CorDebugProcess.GetTypeFields"/> method.
    /// </summary>
    [DebuggerDisplay("fields = {fields}, pceltNeeded = {pceltNeeded}")]
    public struct GetTypeFieldsResult
    {
        /// <summary>
        /// An array of <see cref="COR_FIELD"/> objects that provide information about the fields that belong to the type.
        /// </summary>
        public COR_FIELD fields { get; }

        /// <summary>
        /// A pointer to the number of <see cref="COR_FIELD"/> objects included in fields.
        /// </summary>
        public int pceltNeeded { get; }

        public GetTypeFieldsResult(COR_FIELD fields, int pceltNeeded)
        {
            this.fields = fields;
            this.pceltNeeded = pceltNeeded;
        }
    }
}