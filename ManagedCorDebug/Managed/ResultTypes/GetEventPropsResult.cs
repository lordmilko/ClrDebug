namespace ManagedCorDebug
{
    /// <summary>
    /// Encapsulates the results of the <see cref="MetaDataImport.GetEventProps"/> method.
    /// </summary>
    public struct GetEventPropsResult
    {
        /// <summary>
        /// [out] A pointer to the TypeDef token representing the class that declares the event.
        /// </summary>
        public mdTypeDef pClass { get; }

        /// <summary>
        /// [out] The name of the event referenced by ev.
        /// </summary>
        public string szEvent { get; }

        /// <summary>
        /// [out] A pointer to the event flags of the event.
        /// </summary>
        public int pdwEventFlags { get; }

        /// <summary>
        /// [out] A pointer to a TypeRef or TypeDef metadata token representing the System.Delegate type of the event.
        /// </summary>
        public mdToken ptkEventType { get; }

        /// <summary>
        /// [out] A pointer to the metadata token representing the method that adds handlers for the event.
        /// </summary>
        public mdMethodDef pmdAddOn { get; }

        /// <summary>
        /// [out] A pointer to the metadata token representing the method that removes handlers for the event.
        /// </summary>
        public mdMethodDef pmdRemoveOn { get; }

        /// <summary>
        /// [out] A pointer to the metadata token representing the method that raises the event.
        /// </summary>
        public mdMethodDef pmdFire { get; }

        /// <summary>
        /// [out] An array of token pointers to other methods associated with the event.
        /// </summary>
        public mdMethodDef[] rmdOtherMethod { get; }

        /// <summary>
        /// [out] The number of tokens returned in rmdOtherMethod.
        /// </summary>
        public int pcOtherMethod { get; }

        public GetEventPropsResult(mdTypeDef pClass, string szEvent, int pdwEventFlags, mdToken ptkEventType, mdMethodDef pmdAddOn, mdMethodDef pmdRemoveOn, mdMethodDef pmdFire, mdMethodDef[] rmdOtherMethod, int pcOtherMethod)
        {
            this.pClass = pClass;
            this.szEvent = szEvent;
            this.pdwEventFlags = pdwEventFlags;
            this.ptkEventType = ptkEventType;
            this.pmdAddOn = pmdAddOn;
            this.pmdRemoveOn = pmdRemoveOn;
            this.pmdFire = pmdFire;
            this.rmdOtherMethod = rmdOtherMethod;
            this.pcOtherMethod = pcOtherMethod;
        }
    }
}