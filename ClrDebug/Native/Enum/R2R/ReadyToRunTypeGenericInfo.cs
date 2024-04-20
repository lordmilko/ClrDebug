namespace ClrDebug
{
    public enum ReadyToRunTypeGenericInfo : byte
    {
        GenericCountMask = 0x3,
        HasConstraints = 0x4,
        HasVariance = 0x8,
    }
}
