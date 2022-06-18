using System.Diagnostics;

namespace ManagedCorDebug
{
    /// <summary>
    /// Encapsulates the results of the <see cref="MetaDataImport.EnumMethodsWithName"/> method.
    /// </summary>
    [DebuggerDisplay("szName = {szName}, rMethods = {rMethods}")]
    public struct EnumMethodsWithNameResult
    {
        /// <summary>
        /// The name that limits the scope of the enumeration.
        /// </summary>
        public string szName { get; }

        /// <summary>
        /// The array used to store the MethodDef tokens.
        /// </summary>
        public mdMethodDef[] rMethods { get; }

        public EnumMethodsWithNameResult(string szName, mdMethodDef[] rMethods)
        {
            this.szName = szName;
            this.rMethods = rMethods;
        }
    }
}