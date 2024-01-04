using System;
using System.Diagnostics;

namespace ClrDebug.DbgEng
{
    /// <summary>
    /// Encapsulates the results of the <see cref="SvcModuleIndexProvider.GetModuleIndexKey"/> method.
    /// </summary>
    [DebuggerDisplay("pModuleIndex = {pModuleIndex}, pModuleIndexKind = {pModuleIndexKind.ToString(),nq}")]
    public struct GetModuleIndexKeyResult
    {
        public string pModuleIndex { get; }

        public Guid pModuleIndexKind { get; }

        public GetModuleIndexKeyResult(string pModuleIndex, Guid pModuleIndexKind)
        {
            this.pModuleIndex = pModuleIndex;
            this.pModuleIndexKind = pModuleIndexKind;
        }
    }
}
