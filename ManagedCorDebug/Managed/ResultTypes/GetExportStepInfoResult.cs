namespace ManagedCorDebug
{
    public struct GetExportStepInfoResult
    {
        public CorDebugCodeInvokeKind PInvokeKind { get; }

        public CorDebugCodeInvokePurpose PInvokePurpose { get; }

        public GetExportStepInfoResult(CorDebugCodeInvokeKind pInvokeKind, CorDebugCodeInvokePurpose pInvokePurpose)
        {
            PInvokeKind = pInvokeKind;
            PInvokePurpose = pInvokePurpose;
        }
    }
}