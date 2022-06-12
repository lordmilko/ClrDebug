using System;

namespace ManagedCorDebug
{
    public struct EnumEventsResult
    {
        public IntPtr PhEnum { get; }

        public mdEvent[] REvents { get; }

        public int PcEvents { get; }

        public EnumEventsResult(IntPtr phEnum, mdEvent[] rEvents, int pcEvents)
        {
            PhEnum = phEnum;
            REvents = rEvents;
            PcEvents = pcEvents;
        }
    }
}