using System;

namespace ClrDebug
{
    /// <summary>
    /// Encapsulates the results of the <see cref="DbgShim.CreateProcessForLaunch"/> method.
    /// </summary>
    public struct CreateProcessForLaunchResult
    {
        public int ProcessId { get; }

        public IntPtr ResumeHandle { get; }

        public CreateProcessForLaunchResult(int pProcessId, IntPtr pResumeHandle)
        {
            ProcessId = pProcessId;
            ResumeHandle = pResumeHandle;
        }
    }
}
