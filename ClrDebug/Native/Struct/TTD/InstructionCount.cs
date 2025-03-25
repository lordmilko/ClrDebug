namespace ClrDebug.TTD
{
    //From LiveRecorder

    /// <summary>
    /// Represents a number of instructions, encapsulated as a stronger-typed enum.<para/>
    /// Counting instructions is a core activity of TTD that is used at all levels of recording and replay.
    /// </summary>
    public struct InstructionCount
    {
        public static readonly InstructionCount Zero = 0;
        public static readonly InstructionCount Min = 0;
        public static readonly InstructionCount Max = ulong.MaxValue - 1;

        /// <summary>
        /// Used as N/A or error marker
        /// </summary>
        public static readonly InstructionCount Invalid = ulong.MaxValue;

        public ulong Value { get; }

        public InstructionCount(ulong value)
        {
            Value = value;
        }

        public static implicit operator InstructionCount(ulong value) => new InstructionCount(value);
        public static implicit operator ulong(InstructionCount value) => value.Value;

        public override string ToString()
        {
            if (Value == Min)
                return nameof(Min);

            if (Value == Max)
                return nameof(Max);

            if (Value == Invalid)
                return nameof(Invalid);

            return Value.ToString();
        }
    }
}
