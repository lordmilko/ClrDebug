﻿using System.Diagnostics;

namespace ClrDebug.DbgEng
{
    /// <summary>
    /// Encapsulates the results of the <see cref="DebugControl.GetLastEventInformation"/> method.
    /// </summary>
    [DebuggerDisplay("Type = {Type.ToString(),nq}, ProcessId = {ProcessId}, ThreadId = {ThreadId}, Description = {Description}, DescriptionUsed = {DescriptionUsed}")]
    public struct GetLastEventInformationResult
    {
        /// <summary>
        /// Receives the type of the last event generated by the target. For a list of possible types, see DEBUG_EVENT_XXX.
        /// </summary>
        public DEBUG_EVENT_TYPE Type { get; }

        /// <summary>
        /// Receives the process ID of the process in which the event occurred. If this information is not available, DEBUG_ANY_ID will be returned instead.
        /// </summary>
        public uint ProcessId { get; }

        /// <summary>
        /// Receives the thread index (not the thread ID) of the thread in which the last event occurred. If this information is not available, DEBUG_ANY_ID will be returned instead.
        /// </summary>
        public uint ThreadId { get; }

        /// <summary>
        /// Receives the description of the event. If Description is NULL, this information is not returned.
        /// </summary>
        public string Description { get; }

        /// <summary>
        /// Receives the size in characters of the description of the event. This size includes the space for the '\0' terminating character.<para/>
        /// If DescriptionUsed is NULL, this information is not returned.
        /// </summary>
        public uint DescriptionUsed { get; }

        public GetLastEventInformationResult(DEBUG_EVENT_TYPE type, uint processId, uint threadId, string description, uint descriptionUsed)
        {
            Type = type;
            ProcessId = processId;
            ThreadId = threadId;
            Description = description;
            DescriptionUsed = descriptionUsed;
        }
    }
}
