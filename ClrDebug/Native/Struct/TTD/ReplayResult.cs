namespace ClrDebug.TTD
{
    //TTDReplay (Undocumented)
    //x64 layout; x86 not yet known


    public struct ReplayResult
    {
        //There's sometimes garbage after the EventType, which means it must be a single byte
        //not sure if we should call this "stopreason"? but ttd dbgmodel sometimes shows the result of a calls() method as eventtype 0, and this value can sometimes be a value of 0
        public EventType EventType; //EventType? ttd.calls() shows an event type, but most importantly thers talk of an "event type" in ttdtargetinfo::waitforevent

        //If EventType is a single byte, then there must be some type of padding
        public byte _unknown1;
        public byte _unknown2;
        public byte _unknown3;

        public long _stepsTaken1;
        public long _stepsTaken2;

        //possibly related to watchpoint data breakpoints?
        public long _MaybeWatchpointAddressHit; //ip at breakpoint?
        public long _MaybeWatchpointSizeHit; //watchpointdata.size hit? may not match the size listed in the watchpointdata?
        public long _MaybeWatchpointByteHit; //which byte was hit? 1 based?
    }
}
