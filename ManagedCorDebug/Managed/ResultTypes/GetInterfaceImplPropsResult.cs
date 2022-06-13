using System.Diagnostics;

namespace ManagedCorDebug
{
    /// <summary>
    /// Encapsulates the results of the <see cref="MetaDataImport.GetInterfaceImplProps"/> method.
    /// </summary>
    [DebuggerDisplay("pClass = {pClass}, ptkIface = {ptkIface}")]
    public struct GetInterfaceImplPropsResult
    {
        /// <summary>
        /// The metadata token representing the class that implements the method.
        /// </summary>
        public mdTypeDef pClass { get; }

        /// <summary>
        /// The metadata token representing the interface that defines the implemented method.
        /// </summary>
        public mdToken ptkIface { get; }

        public GetInterfaceImplPropsResult(mdTypeDef pClass, mdToken ptkIface)
        {
            this.pClass = pClass;
            this.ptkIface = ptkIface;
        }
    }
}