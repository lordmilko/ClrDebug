namespace ManagedCorDebug
{
    /// <summary>
    /// Encapsulates the results of the <see cref="CorDebugProcess.GetExportStepInfo"/> method.
    /// </summary>
    public struct GetExportStepInfoResult
    {
        /// <summary>
        /// [out] A pointer to a member of the <see cref="CorDebugCodeInvokeKind"/> enumeration that describes how the exported function will invoke managed code.
        /// </summary>
        public CorDebugCodeInvokeKind pInvokeKind { get; }

        /// <summary>
        /// [out] A pointer to a member of the <see cref="CorDebugCodeInvokePurpose"/> enumeration that describes why the exported function will call managed code.
        /// </summary>
        public CorDebugCodeInvokePurpose pInvokePurpose { get; }

        public GetExportStepInfoResult(CorDebugCodeInvokeKind pInvokeKind, CorDebugCodeInvokePurpose pInvokePurpose)
        {
            this.pInvokeKind = pInvokeKind;
            this.pInvokePurpose = pInvokePurpose;
        }
    }
}