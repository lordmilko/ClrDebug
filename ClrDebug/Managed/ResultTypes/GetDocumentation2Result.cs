using System.Diagnostics;

namespace ClrDebug.TypeLib
{
    /// <summary>
    /// Encapsulates the results of the <see cref="ComTypeLib.GetDocumentation2"/> method.
    /// </summary>
    [DebuggerDisplay("pbstrHelpString = {pbstrHelpString}, pdwHelpStringContext = {pdwHelpStringContext}, pbstrHelpStringDll = {pbstrHelpStringDll}")]
    public struct GetDocumentation2Result
    {
        /// <summary>
        /// When this method returns, contains a BSTR that specifies the name of the specified item. If the caller does not need the item name, pbstrHelpString can be <see langword="null"/>. This parameter is passed uninitialized.
        /// </summary>
        public string pbstrHelpString { get; }

        /// <summary>
        /// When this method returns, contains the Help localization context. If the caller does not need the Help context, pdwHelpStringContext can be <see langword="null"/>. This parameter is passed uninitialized.
        /// </summary>
        public int pdwHelpStringContext { get; }

        /// <summary>
        /// When this method returns, contains a BSTR that specifies the fully qualified name of the file containing the DLL used for Help file. If the caller does not need the file name, pbstrHelpStringDll can be <see langword="null"/>. This parameter is passed uninitialized.
        /// </summary>
        public string pbstrHelpStringDll { get; }

        public GetDocumentation2Result(string pbstrHelpString, int pdwHelpStringContext, string pbstrHelpStringDll)
        {
            this.pbstrHelpString = pbstrHelpString;
            this.pdwHelpStringContext = pdwHelpStringContext;
            this.pbstrHelpStringDll = pbstrHelpStringDll;
        }
    }
}
