using System.Diagnostics;

namespace ClrDebug.TypeLib
{
    /// <summary>
    /// Encapsulates the results of the <see cref="ComTypeLib.GetDocumentation"/> method.
    /// </summary>
    [DebuggerDisplay("strName = {strName}, strDocString = {strDocString}, dwHelpContext = {dwHelpContext}, strHelpFile = {strHelpFile}")]
    public struct GetDocumentationResult
    {
        /// <summary>
        /// When this method returns, contains a string that represents the name of the specified item. This parameter is passed uninitialized.
        /// </summary>
        public string strName { get; }

        /// <summary>
        /// When this method returns, contains a string that represents the documentation string for the specified item. This parameter is passed uninitialized.
        /// </summary>
        public string strDocString { get; }

        /// <summary>
        /// When this method returns, contains the Help context identifier associated with the specified item. This parameter is passed uninitialized.
        /// </summary>
        public int dwHelpContext { get; }

        /// <summary>
        /// When this method returns, contains a string that represents the fully qualified name of the Help file. This parameter is passed uninitialized.
        /// </summary>
        public string strHelpFile { get; }

        public GetDocumentationResult(string strName, string strDocString, int dwHelpContext, string strHelpFile)
        {
            this.strName = strName;
            this.strDocString = strDocString;
            this.dwHelpContext = dwHelpContext;
            this.strHelpFile = strHelpFile;
        }
    }
}
