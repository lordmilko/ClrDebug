namespace ClrDebug.DbgEng
{
    /// <summary>
    /// Defines the current status of an operation.
    /// </summary>
    public enum TargetOperationStatus : uint
    {
        /// <summary>
        /// OperationCompleted: the requested operation has completed.
        /// </summary>
        OperationCompleted,

        /// <summary>
        /// OperationCanceled: the requested operation has been canceled.
        /// </summary>
        OperationCanceled,

        /// <summary>
        /// OperationPending: the requested operation is still pending.
        /// </summary>
        OperationPending,

        /// <summary>
        /// OperationError: the requested operation cannot be completed due to an error.
        /// </summary>
        OperationError
    }
}
