using System.Diagnostics;

namespace ManagedCorDebug
{
    /// <summary>
    /// Encapsulates the results of the <see cref="MetaDataImport.GetEventProps"/> method.
    /// </summary>
    [DebuggerDisplay("pClass = {pClass}, szEvent = {szEvent}, pdwEventFlags = {pdwEventFlags}, ptkEventType = {ptkEventType}, pmdAddOn = {pmdAddOn}, pmdRemoveOn = {pmdRemoveOn}, pmdFire = {pmdFire}, rmdOtherMethod = {rmdOtherMethod}")]
    public struct GetEventPropsResult
    {
        /// <summary>
        /// A pointer to the TypeDef token representing the class that declares the event.
        /// </summary>
        public mdTypeDef pClass { get; }

        /// <summary>
        /// The name of the event referenced by ev.
        /// </summary>
        public string szEvent { get; }

        /// <summary>
        /// A pointer to the event flags of the event.
        /// </summary>
        public int pdwEventFlags { get; }

        /// <summary>
        /// A pointer to a TypeRef or TypeDef metadata token representing the System.Delegate type of the event.
        /// </summary>
        public mdToken ptkEventType { get; }

        /// <summary>
        /// A pointer to the metadata token representing the method that adds handlers for the event.
        /// </summary>
        public mdMethodDef pmdAddOn { get; }

        /// <summary>
        /// A pointer to the metadata token representing the method that removes handlers for the event.
        /// </summary>
        public mdMethodDef pmdRemoveOn { get; }

        /// <summary>
        /// A pointer to the metadata token representing the method that raises the event.
        /// </summary>
        public mdMethodDef pmdFire { get; }

        /// <summary>
        /// An array of token pointers to other methods associated with the event.
        /// </summary>
        public mdMethodDef[] rmdOtherMethod { get; }

        public GetEventPropsResult(mdTypeDef pClass, string szEvent, int pdwEventFlags, mdToken ptkEventType, mdMethodDef pmdAddOn, mdMethodDef pmdRemoveOn, mdMethodDef pmdFire, mdMethodDef[] rmdOtherMethod)
        {
            this.pClass = pClass;
            this.szEvent = szEvent;
            this.pdwEventFlags = pdwEventFlags;
            this.ptkEventType = ptkEventType;
            this.pmdAddOn = pmdAddOn;
            this.pmdRemoveOn = pmdRemoveOn;
            this.pmdFire = pmdFire;
            this.rmdOtherMethod = rmdOtherMethod;
        }
    }
}