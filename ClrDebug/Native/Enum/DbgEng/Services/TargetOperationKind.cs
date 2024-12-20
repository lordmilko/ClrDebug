namespace ClrDebug.DbgEng
{
    /// <summary>
    /// Defines a kind of operation.
    /// </summary>
    public enum TargetOperationKind : uint
    {
        /// <summary>
        /// OperationStep: This represents a step operation.
        /// </summary>
        OperationStep,

        /// <summary>
        /// OperationRun: This represents a run operation.
        /// </summary>
        OperationRun,

        /// <summary>
        /// OperationHalt: This represents a halt operation.
        /// </summary>
        OperationHalt
    }
}
