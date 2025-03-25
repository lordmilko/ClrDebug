namespace ClrDebug.TTD
{
    public struct ThreadId
    {
        //Name unknown
        public static readonly ThreadId Active = 0;

        public int Value;

        public static implicit operator ThreadId(int value) => new ThreadId { Value = value };

        public override string ToString() => Value.ToString();
    }
}
