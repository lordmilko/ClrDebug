namespace ClrDebug.TTD
{
    //TTD::Replay::StepCount
    public struct StepCount
    {
        public static readonly StepCount Max = 0xFFFFFFFFFFFFFFFE;

        public ulong Value;

        public static implicit operator StepCount(int value) => new StepCount {Value = (ulong) value};
        public static implicit operator StepCount(ulong value) => new StepCount {Value = value};
        public static implicit operator StepCount(long value) => new StepCount {Value = (ulong) value};

        public override string ToString()
        {
            if (Value == Max.Value)
                return nameof(Max);

            return Value.ToString();
        }
    }
}
