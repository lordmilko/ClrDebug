using System.Diagnostics;

namespace ManagedCorDebug
{
    /// <summary>
    /// Encapsulates the results of the <see cref="MetaDataAssemblyImport.GetExportedTypeProps"/> method.
    /// </summary>
    [DebuggerDisplay("szName = {szName}, ptkImplementation = {ptkImplementation}, ptkTypeDef = {ptkTypeDef.ToString(),nq}, pdwExportedTypeFlags = {pdwExportedTypeFlags.ToString(),nq}")]
    public struct GetExportedTypePropsResult
    {
        /// <summary>
        /// The name of the exported type.
        /// </summary>
        public string szName { get; }

        /// <summary>
        /// An <see cref="mdFile"/>, <see cref="mdAssemblyRef"/>, or <see cref="mdExportedType"/> metadata token that contains or allows access to the properties of the exported type.
        /// </summary>
        public int ptkImplementation { get; }

        /// <summary>
        /// A pointer to an <see cref="mdTypeDef"/> token that represents a type in the file.
        /// </summary>
        public mdTypeDef ptkTypeDef { get; }

        /// <summary>
        /// A pointer to the flags that describe the metadata applied to the exported type. The flags value can be one or more <see cref="CorTypeAttr"/> values.
        /// </summary>
        public CorTypeAttr pdwExportedTypeFlags { get; }

        public GetExportedTypePropsResult(string szName, int ptkImplementation, mdTypeDef ptkTypeDef, CorTypeAttr pdwExportedTypeFlags)
        {
            this.szName = szName;
            this.ptkImplementation = ptkImplementation;
            this.ptkTypeDef = ptkTypeDef;
            this.pdwExportedTypeFlags = pdwExportedTypeFlags;
        }
    }
}