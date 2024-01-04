﻿using System.Diagnostics;

namespace ClrDebug.DbgEng
{
    /// <summary>
    /// Encapsulates the results of the <see cref="DebugHostEvaluator.EvaluateExpression"/> method.
    /// </summary>
    [DebuggerDisplay("result = {result?.ToString(),nq}, metadata = {metadata?.ToString(),nq}")]
    public struct EvaluateExpressionResult
    {
        /// <summary>
        /// The resulting value of the expression evaluation will be returned here.
        /// </summary>
        public ModelObject result { get; }

        /// <summary>
        /// Any metadata associated with the expression or result is returned here.
        /// </summary>
        public KeyStore metadata { get; }

        public EvaluateExpressionResult(ModelObject result, KeyStore metadata)
        {
            this.result = result;
            this.metadata = metadata;
        }
    }
}
