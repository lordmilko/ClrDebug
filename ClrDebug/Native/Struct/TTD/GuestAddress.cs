namespace ClrDebug.TTD
{
    public struct GuestAddress
    {
        public long Value;

        public override string ToString() => "0x" + Value.ToString("X");

        public static implicit operator GuestAddress(long value) => new GuestAddress { Value = value };

        public static implicit operator long(GuestAddress value) => value.Value;
    }
}