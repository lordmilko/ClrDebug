using System;
using System.Diagnostics;

namespace ManagedCorDebug
{
    /// <summary>
    /// Encapsulates the results of the <see cref="MetaDataImport.EnumEvents"/> method.
    /// </summary>
    [DebuggerDisplay("phEnum = {phEnum}, rEvents = {rEvents}")]
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

        public EnumEventsResult(IntPtr phEnum, mdEvent[] rEvents)
        {
            this.phEnum = phEnum;
            this.rEvents = rEvents;
        }
    }
}