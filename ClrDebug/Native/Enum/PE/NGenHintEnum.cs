namespace ClrDebug
{
    public enum NGenHintEnum
    {
        NGenDefault = 0x0000, // No preference specified

        NGenEager = 0x0001, // NGen at install time
        NGenLazy = 0x0002, // NGen after install time
        NGenNever = 0x0003  // Assembly should not be ngened
    }
}