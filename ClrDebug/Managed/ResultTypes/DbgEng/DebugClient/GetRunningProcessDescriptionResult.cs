using System.Diagnostics;

namespace ClrDebug.DbgEng
{
    /// <summary>
    /// Encapsulates the results of the <see cref="DebugClient.GetRunningProcessDescription"/> method.
    /// </summary>
    [DebuggerDisplay("ExeName = {ExeName}, Description = {Description}")]
    public struct GetRunningProcessDescriptionResult
    {
        /// <summary>
        /// Receives the name of the executable file used to start the process. If ExeName is NULL, this information is not returned.
        /// </summary>
        public string ExeName { get; }

        /// <summary>
        /// Receives extra information about the process, including service names, MTS package names, and the command line.<para/>
        /// If Description is NULL, this information is not returned.
        /// </summary>
        public string Description { get; }

        public GetRunningProcessDescriptionResult(string exeName, string description)
        {
            ExeName = exeName;
            Description = description;
        }
    }
}
