namespace ClrDebug.TTD
{
    //TTDReplay (Undocumented)
    //Enum field names based on DbgEng Data Model @$curprocess.TTD.DefaultMemoryPolicy

    public enum QueryMemoryPolicy
    {
        Default = 0,
        ThreadLocal = 1,
        GloballyConservative = 2,
        GloballyAggressive = 3,
        InFragmentAggressive = 4
    }
}
