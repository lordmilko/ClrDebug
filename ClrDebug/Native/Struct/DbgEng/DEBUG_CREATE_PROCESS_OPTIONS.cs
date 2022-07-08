using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    /// <summary>
    /// The DEBUG_CREATE_PROCESS_OPTIONS structure specifies the process creation options to use when creating a new process.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct DEBUG_CREATE_PROCESS_OPTIONS
    {
        /// <summary>
        /// The flags to use when creating the process. In addition to the flags described in the "Process Creation Flags" topic in the Platform SDK documentation, the debugger engine uses the following flags when creating a process.<para/>
        /// When creating and attaching to a process through the debugger engine, set one of the Platform SDK's process creation flags: DEBUG_PROCESS or DEBUG_ONLY_THIS_PROCESS.
        /// </summary>
        public DEBUG_CREATE_PROCESS CreateFlags;

        /// <summary>
        /// The engine specific flags used when creating the process. EngCreateFlags is a combination of the following bit-flags:
        /// </summary>
        public DEBUG_ECREATE_PROCESS EngCreateFlags;

        /// <summary>
        /// The Application Verifier flags. Only used if DEBUG_ECREATE_PROCESS_USE_VERIFIER_FLAGS is set in the EngCreateFlags field.<para/>
        /// For possible values, see the Application Verifier documentation.
        /// </summary>
        public uint VerifierFlags;

        /// <summary>
        /// Set to zero.
        /// </summary>
        public uint Reserved;
    }
}