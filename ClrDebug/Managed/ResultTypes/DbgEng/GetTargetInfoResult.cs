using System.Diagnostics;

namespace ClrDebug.DbgEng
{
    /// <summary>
    /// Encapsulates the results of the <see cref="ModelObject.TargetInfo"/> property.
    /// </summary>
    [DebuggerDisplay("location = {location.ToString(),nq}, type = {type?.ToString(),nq}")]
    public struct GetTargetInfoResult
    {
        /// <summary>
        /// The abstract location of the native object represented by the this pointer will be returned here.
        /// </summary>
        public Location location { get; }

        /// <summary>
        /// The native type of the object represented by the this pointer will be returned here as an <see cref="IDebugHostType"/> interface.
        /// </summary>
        public DebugHostType type { get; }

        public GetTargetInfoResult(Location location, DebugHostType type)
        {
            this.location = location;
            this.type = type;
        }
    }
}
