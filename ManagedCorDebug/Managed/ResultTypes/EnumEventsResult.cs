using System;

namespace ManagedCorDebug
{
    public struct EnumEventsResult
    {
        public IntPtr PhEnum { get; }

        public mdEvent[] REvents { get; }

        public uint PcEvents { get; }

        public EnumEventsResult(IntPtr phEnum, mdEvent[] rEvents, uint pcEvents)
        {
            PhEnum = phEnum;
            REvents = rEvents;
            PcEvents = pcEvents;
        }
    }
}