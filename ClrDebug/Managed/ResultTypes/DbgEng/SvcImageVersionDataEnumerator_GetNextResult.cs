using System;
using System.Diagnostics;

namespace ClrDebug.DbgEng
{
    /// <summary>
    /// Encapsulates the results of the <see cref="SvcImageVersionDataEnumerator.Next"/> property.
    /// </summary>
    [DebuggerDisplay("pVersionDataIdentifierGuid = {pVersionDataIdentifierGuid.ToString(),nq}, pVersionDataIdentifierString = {pVersionDataIdentifierString}, pVersionDataString = {pVersionDataString}, pVersionDataDescription = {pVersionDataDescription}, pVersionKind = {pVersionKind.ToString(),nq}")]
    public struct SvcImageVersionDataEnumerator_GetNextResult
    {
        public Guid pVersionDataIdentifierGuid { get; }

        public string pVersionDataIdentifierString { get; }

        public string pVersionDataString { get; }

        public string pVersionDataDescription { get; }

        public VersionKind pVersionKind { get; }

        public SvcImageVersionDataEnumerator_GetNextResult(Guid pVersionDataIdentifierGuid, string pVersionDataIdentifierString, string pVersionDataString, string pVersionDataDescription, VersionKind pVersionKind)
        {
            this.pVersionDataIdentifierGuid = pVersionDataIdentifierGuid;
            this.pVersionDataIdentifierString = pVersionDataIdentifierString;
            this.pVersionDataString = pVersionDataString;
            this.pVersionDataDescription = pVersionDataDescription;
            this.pVersionKind = pVersionKind;
        }
    }
}
