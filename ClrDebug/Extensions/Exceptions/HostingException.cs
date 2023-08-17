using System;

namespace ClrDebug
{
    /// <summary>
    /// The exception that is thrown when a hosting component returns an unsuccessful <see cref="HostStatusCode"/>.
    /// </summary>
    public class HostingException : Exception
    {
        public HostStatusCode Status { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="HostingException"/> class.
        /// </summary>
        /// <param name="status">The <see cref="HostStatusCode"/> that is the cause of the exception.</param>
        public HostingException(HostStatusCode status) : base($"Status {status} has been returned from a call to a hosting component.")
        {
            Status = status;
        }
    }
}
