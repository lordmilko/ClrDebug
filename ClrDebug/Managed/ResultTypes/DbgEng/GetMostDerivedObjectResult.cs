using System.Diagnostics;

namespace ClrDebug.DbgEng
{
    /// <summary>
    /// Encapsulates the results of the <see cref="DebugHostSymbols.GetMostDerivedObject"/> method.
    /// </summary>
    [DebuggerDisplay("derivedLocation = {derivedLocation.ToString(),nq}, derivedType = {derivedType?.ToString(),nq}")]
    public struct GetMostDerivedObjectResult
    {
        /// <summary>
        /// The location of the runtime typed object within the address space given by either the pContext argument or the objectType argument.<para/>
        /// This may or may not be the same as the location given by the location argument.
        /// </summary>
        public Location derivedLocation { get; }

        /// <summary>
        /// The runtime type of the object will be returned here. This may or may not be the same as the type passed in the objectType argument.
        /// </summary>
        public DebugHostType derivedType { get; }

        public GetMostDerivedObjectResult(Location derivedLocation, DebugHostType derivedType)
        {
            this.derivedLocation = derivedLocation;
            this.derivedType = derivedType;
        }
    }
}
