using System.Diagnostics;

namespace ClrDebug.DbgEng
{
    /// <summary>
    /// Encapsulates the results of the <see cref="DebugControl.GetDebuggeeType2"/> method.
    /// </summary>
    [DebuggerDisplay("Class = {Class.ToString(),nq}, Qualifier = {Qualifier.ToString(),nq}")]
    public struct GetDebuggeeType2Result
    {
        /// <summary>
        /// Receives the class of the current target. It will be set to one of the values in the following table.
        /// </summary>
        public DEBUG_CLASS Class { get; }

        /// <summary>
        /// Provides more details about the type of the target. Its interpretation depends on the value of Class. When class is DEBUG_CLASS_UNINITIALIZED, Qualifier returns zero.<para/>
        /// The following values are applicable for kernel-mode targets. The following values are applicable for user-mode targets.
        /// </summary>
        public DEBUG_CLASS_QUALIFIER Qualifier { get; }

        public GetDebuggeeType2Result(DEBUG_CLASS @class, DEBUG_CLASS_QUALIFIER qualifier)
        {
            Class = @class;
            Qualifier = qualifier;
        }
    }
}
