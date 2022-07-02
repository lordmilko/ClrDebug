using System.Diagnostics;

namespace ClrDebug
{
    /// <summary>
    /// Encapsulates the results of the <see cref="SymUnmanagedReader.GetDocumentVersion"/> method.
    /// </summary>
    [DebuggerDisplay("version = {version}, pbCurrent = {pbCurrent}")]
    public struct GetDocumentVersionResult
    {
        /// <summary>
        /// A pointer to a variable that receives the version of the specified document.
        /// </summary>
        public int version { get; }

        /// <summary>
        /// A pointer to a variable that receives true if this is the latest version of the document, or false if it isn't the latest version.
        /// </summary>
        public bool pbCurrent { get; }

        public GetDocumentVersionResult(int version, bool pbCurrent)
        {
            this.version = version;
            this.pbCurrent = pbCurrent;
        }
    }
}