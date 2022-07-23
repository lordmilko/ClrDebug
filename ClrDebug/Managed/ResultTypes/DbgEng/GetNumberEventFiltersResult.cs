using System.Diagnostics;

namespace ClrDebug.DbgEng
{
    /// <summary>
    /// Encapsulates the results of the <see cref="DebugControl.NumberEventFilters"/> property.
    /// </summary>
    [DebuggerDisplay("SpecificEvents = {SpecificEvents}, SpecificExceptions = {SpecificExceptions}, ArbitraryExceptions = {ArbitraryExceptions}")]
    public struct GetNumberEventFiltersResult
    {
        /// <summary>
        /// Receives the number of events that can be controlled using the specific event filters. These events are enumerated using some of the DEBUG_FILTER_XXX constants.
        /// </summary>
        public int SpecificEvents { get; }

        /// <summary>
        /// Receives the number of exceptions that can be controlled using the specific exception filters. The first specific exception filter is the default exception filter.<para/>
        /// The exceptions controlled by the other specific exception filters will always have their own filter and will not inherit their behavior from the default specific exception filter.<para/>
        /// These exception filters are identified by their exception code. See Specific Exceptions for a list of the specific exception filters.
        /// </summary>
        public int SpecificExceptions { get; }

        /// <summary>
        /// Receives the number of arbitrary exception filters currently used by the engine. These exception filters are identified by their exception code.
        /// </summary>
        public int ArbitraryExceptions { get; }

        public GetNumberEventFiltersResult(int specificEvents, int specificExceptions, int arbitraryExceptions)
        {
            SpecificEvents = specificEvents;
            SpecificExceptions = specificExceptions;
            ArbitraryExceptions = arbitraryExceptions;
        }
    }
}
