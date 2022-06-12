namespace ManagedCorDebug
{
    /// <summary>
    /// Encapsulates the results of the <see cref="MetaDataImport.GetInterfaceImplProps"/> method.
    /// </summary>
    public struct GetInterfaceImplPropsResult
    {
        /// <summary>
        /// [out] The metadata token representing the class that implements the method.
        /// </summary>
        public mdTypeDef pClass { get; }

        /// <summary>
        /// [out] The metadata token representing the interface that defines the implemented method.
        /// </summary>
        public mdToken ptkIface { get; }

        public GetInterfaceImplPropsResult(mdTypeDef pClass, mdToken ptkIface)
        {
            this.pClass = pClass;
            this.ptkIface = ptkIface;
        }
    }
}