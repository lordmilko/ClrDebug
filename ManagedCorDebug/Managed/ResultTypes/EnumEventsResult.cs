using System;

namespace ManagedCorDebug
{
    /// <summary>
    /// Encapsulates the results of the <see cref="MetaDataImport.EnumEvents"/> method.
    /// </summary>
    public struct EnumEventsResult
    {
        /// <summary>
        /// [in, out] A pointer to the enumerator.
        /// </summary>
        public IntPtr phEnum { get; }

        /// <summary>
        /// [out] The array of returned events.
        /// </summary>
        public mdEvent[] rEvents { get; }

        /// <summary>
        /// [out] The actual number of events returned in rEvents.
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