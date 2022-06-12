namespace ManagedCorDebug
{
    /// <summary>
    /// Encapsulates the results of the <see cref="SymUnmanagedReader.GetDocumentVersion"/> method.
    /// </summary>
    public struct GetDocumentVersionResult
    {
        /// <summary>
        /// [out] A pointer to a variable that receives the version of the specified document.
        /// </summary>
        public int version { get; }

        /// <summary>
        /// [out] A pointer to a variable that receives true if this is the latest version of the document, or false if it isn't the latest version.
        /// </summary>
        public int pbCurrent { get; }

        public GetDocumentVersionResult(int version, int pbCurrent)
        {
            this.version = version;
            this.pbCurrent = pbCurrent;
        }
    }
}