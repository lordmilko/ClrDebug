﻿using System;
using System.Diagnostics;

namespace ClrDebug
{
    /// <summary>
    /// Encapsulates the results of the <see cref="CorProfilerInfo.GetDynamicFunctionInfo"/> method.
    /// </summary>
    [DebuggerDisplay("moduleId = {moduleId.ToString(),nq}, ppvSig = {ppvSig.ToString(),nq}, pbSig = {pbSig}, wszName = {wszName}")]
    public struct GetDynamicFunctionInfoResult
    {
        /// <summary>
        /// A pointer to the module in which the function's parent class is defined.
        /// </summary>
        public ModuleID moduleId { get; }

        /// <summary>
        /// A pointer to the signature for the function.
        /// </summary>
        public IntPtr ppvSig { get; }

        /// <summary>
        /// A pointer to the count of bytes for the function signature.
        /// </summary>
        public int pbSig { get; }

        /// <summary>
        /// An array of WCHAR which is the name of the function, if one exists.
        /// </summary>
        public string wszName { get; }

        public GetDynamicFunctionInfoResult(ModuleID moduleId, IntPtr ppvSig, int pbSig, string wszName)
        {
            this.moduleId = moduleId;
            this.ppvSig = ppvSig;
            this.pbSig = pbSig;
            this.wszName = wszName;
        }
    }
}
