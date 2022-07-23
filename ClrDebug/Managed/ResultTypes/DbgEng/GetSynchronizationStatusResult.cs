using System.Diagnostics;

namespace ClrDebug.DbgEng
{
    /// <summary>
    /// Encapsulates the results of the <see cref="DebugControl.SynchronizationStatus"/> property.
    /// </summary>
    [DebuggerDisplay("SendsAttempted = {SendsAttempted}, SecondsSinceLastResponse = {SecondsSinceLastResponse}")]
    public struct GetSynchronizationStatusResult
    {
        /// <summary>
        /// The number of packet sends that have been attempted by the current debugger-engine kernel transport mechanism.<para/>
        /// This number will be incremented if engine did not receive a packet "ACK" for the last packet sent by the engine to the target.
        /// </summary>
        public int SendsAttempted { get; }

        /// <summary>
        /// The number of seconds since the last response.
        /// </summary>
        public int SecondsSinceLastResponse { get; }

        public GetSynchronizationStatusResult(int sendsAttempted, int secondsSinceLastResponse)
        {
            SendsAttempted = sendsAttempted;
            SecondsSinceLastResponse = secondsSinceLastResponse;
        }
    }
}
