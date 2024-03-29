﻿using System.Diagnostics;

namespace ClrDebug
{
    /// <summary>
    /// Encapsulates the results of the <see cref="CorDebugProcess.GetExportStepInfo"/> method.
    /// </summary>
    [DebuggerDisplay("pInvokeKind = {pInvokeKind.ToString(),nq}, pInvokePurpose = {pInvokePurpose.ToString(),nq}")]
    public struct GetExportStepInfoResult
    {
        /// <summary>
        /// A pointer to a member of the <see cref="CorDebugCodeInvokeKind"/> enumeration that describes how the exported function will invoke managed code.
        /// </summary>
        public CorDebugCodeInvokeKind pInvokeKind { get; }

        /// <summary>
        /// A pointer to a member of the <see cref="CorDebugCodeInvokePurpose"/> enumeration that describes why the exported function will call managed code.
        /// </summary>
        public CorDebugCodeInvokePurpose pInvokePurpose { get; }

        public GetExportStepInfoResult(CorDebugCodeInvokeKind pInvokeKind, CorDebugCodeInvokePurpose pInvokePurpose)
        {
            this.pInvokeKind = pInvokeKind;
            this.pInvokePurpose = pInvokePurpose;
        }
    }
}
