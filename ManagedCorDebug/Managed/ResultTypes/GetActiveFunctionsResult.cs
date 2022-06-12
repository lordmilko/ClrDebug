using System.Diagnostics;

namespace ManagedCorDebug
{
    /// <summary>
    /// Encapsulates the results of the <see cref="CorDebugThread.GetActiveFunctions"/> method.
    /// </summary>
    [DebuggerDisplay("pcFunctions = {pcFunctions}, pFunctions = {pFunctions}")]
    public struct GetActiveFunctionsResult
    {
        /// <summary>
        /// [out] A pointer to the number of objects returned in the pFunctions array. The number of objects returned will be equal to the number of managed frames on the stack.
        /// </summary>
        public int pcFunctions { get; }

        /// <summary>
        /// [in, out] An array of <see cref="COR_ACTIVE_FUNCTION"/> objects, each of which contains information about the active functions in this thread's frames.<para/>
        /// The first element will be used for the leaf frame, and so on back to the root of the stack.
        /// </summary>
        public COR_ACTIVE_FUNCTION[] pFunctions { get; }

        public GetActiveFunctionsResult(int pcFunctions, COR_ACTIVE_FUNCTION[] pFunctions)
        {
            this.pcFunctions = pcFunctions;
            this.pFunctions = pFunctions;
        }
    }
}