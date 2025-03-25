using System.Diagnostics;

namespace ClrDebug
{
    /// <summary>
    /// Encapsulates the results of the <see cref="SymUnmanagedCompilerInfoReader.GetCompilerInfo"/> method.
    /// </summary>
    [DebuggerDisplay("minor = {minor}, build = {build}, revision = {revision}, name = {name}")]
    public struct GetCompilerInfoResult
    {
        public int minor { get; }

        public int build { get; }

        public int revision { get; }

        public string name { get; }

        public GetCompilerInfoResult(int minor, int build, int revision, string name)
        {
            this.minor = minor;
            this.build = build;
            this.revision = revision;
            this.name = name;
        }
    }
}
