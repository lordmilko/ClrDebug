using System.Diagnostics;

namespace ClrDebug.TTD
{
    /// <summary>
    /// 32-bit unsigned integral type that represents an opaque ID defined by some recording client.
    /// </summary>
    [DebuggerDisplay("ActivityId {Value}")]
    public struct ActivityId
    {
        /// <summary>
        /// Used as N/A or error marker
        /// </summary>
        public static readonly ActivityId Null = 0;

        public static readonly ActivityId Min = 1;
        public static readonly ActivityId Max = uint.MaxValue;

        public uint Value { get; }

        public ActivityId(uint value)
        {
            Value = value;
        }

        public static implicit operator ActivityId(uint value) => new ActivityId(value);
        public static implicit operator uint(ActivityId value) => value.Value;

        public override string ToString()
        {
            if (Value == Null)
                return nameof(Min);

            if (Value == Min)
                return nameof(Max);

            if (Value == Max)
                return nameof(Max);

            return Value.ToString();
        }
    }
}
