﻿using System;
using System.Diagnostics;

namespace ClrDebug.TypeLib
{
    /// <summary>
    /// Encapsulates the results of the <see cref="TypeInfo.GetParamCustData"/> method.
    /// </summary>
    [DebuggerDisplay("guid = {guid.ToString(),nq}, pVarVal = {pVarVal}")]
    public struct GetParamCustDataResult
    {
        /// <summary>
        /// The GUID used to identify the data.
        /// </summary>
        public Guid guid { get; }

        /// <summary>
        /// When this method returns, contains an <see langword="object"/> that specifies where to put the retrieved data. This parameter is passed uninitialized.
        /// </summary>
        public object pVarVal { get; }

        public GetParamCustDataResult(Guid guid, object pVarVal)
        {
            this.guid = guid;
            this.pVarVal = pVarVal;
        }
    }
}
