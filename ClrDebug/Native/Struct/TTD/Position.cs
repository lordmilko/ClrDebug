using System;

namespace ClrDebug.TTD
{
    public readonly struct Position : IComparable<Position>
    {
        //All three of these have symbols in TTDReplay.dll
        public static readonly Position Min = new Position(0, 0);
        public static readonly Position Max = new Position(0xFFFFFFFFFFFFFFFE, 0xFFFFFFFFFFFFFFFE);
        public static readonly Position Invalid = new Position(0xFFFFFFFFFFFFFFFF, 0);

        public ulong Sequence { get; }
        public ulong Steps { get; }

        public Position(ulong sequence, ulong steps)
        {
            Sequence = sequence;
            Steps = steps;
        }

        public static implicit operator Position(ulong sequence) => new Position(sequence, 0);

        public static implicit operator Position(string value)
        {
            if (value == null)
                throw new ArgumentNullException(nameof(value));

            var split = value.Split(':');

            if (split.Length != 2)
                throw new ArgumentException($"Cannot convert value '{value}' to a position");

            return new Position(
                Convert.ToUInt64(split[0], 16),
                Convert.ToUInt64(split[1], 16)
            );
        }

        public override bool Equals(object obj)
        {
            if (obj is not Position p)
                return false;

            return Sequence == p.Sequence && Steps == p.Steps;
        }

        public override int GetHashCode()
        {
            var hashCode = Sequence.GetHashCode();
            hashCode = (hashCode ^ 397) ^ Steps.GetHashCode();
            return hashCode;
        }

        public override string ToString()
        {
            if (this == Min)
                return nameof(Min);

            if (this == Max)
                return nameof(Max);

            if (this == Invalid)
                return nameof(Invalid);

            return $"{Sequence:X}:{Steps:X}";
        }

        public static bool operator ==(Position left, Position right) =>
            left.Sequence == right.Sequence && left.Steps == right.Steps;

        public static bool operator !=(Position left, Position right) =>
            left.Sequence != right.Sequence || left.Steps != right.Steps;

        public int CompareTo(Position other)
        {
            var sequenceComparison = Sequence.CompareTo(other.Sequence);

            if (sequenceComparison != 0)
                return sequenceComparison;

            return Steps.CompareTo(other.Steps);
        }
    }
}
