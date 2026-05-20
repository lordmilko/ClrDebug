namespace ClrDebug.TTD
{
    //TTDReplay (Undocumented)

    public enum ReplayFlags
    {
        //ttdext sets this to 5 when it goes to do a !tt register br change.
        //It seems to use memory watchpoints for this.
        //EventMask is set to 1 by DbgEng normally, and is also set to 1
        //while tracing the memory watchpoint
    }
}
