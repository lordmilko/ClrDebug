using System;
using System.Diagnostics;

namespace ManagedCorDebug
{
    /// <summary>
    /// Encapsulates the results of the <see cref="MetaDataImport.EnumEvents"/> method.
    /// </summary>
    [DebuggerDisplay("phEnum = {phEnum}, rEvents = {rEvents}, pcEvents = {pcEvents}")]
    public struct EnumEventsResult
    {
        /// <summary>
        /// A pointer to the enumerator.
        /// </summary>
        public IntPtr phEnum { get; }

        /// <summary>
        /// The array of returned events.
        /// </summary>
        public mdEvent[] rEvents { get; }

        /// <summary>
        /// The actual number of events returned in rEvents.
        /// </summary>
        public int pcEvents { get; }

        public EnumEventsResult(IntPtr phEnum, mdEvent[] rEvents, int pcEvents)
        {
            this.phEnum = phEnum;
            this.rEvents = rEvents;
            this.pcEvents = pcEvents;
        }
    }
}