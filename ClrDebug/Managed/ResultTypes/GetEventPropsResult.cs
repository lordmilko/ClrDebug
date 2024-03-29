﻿using System.Diagnostics;

namespace ClrDebug
{
    /// <summary>
    /// Encapsulates the results of the <see cref="MetaDataImport.GetEventProps"/> method.
    /// </summary>
    [DebuggerDisplay("pClass = {pClass.ToString(),nq}, szEvent = {szEvent}, pdwEventFlags = {pdwEventFlags.ToString(),nq}, ptkEventType = {ptkEventType.ToString(),nq}, pmdAddOn = {pmdAddOn.ToString(),nq}, pmdRemoveOn = {pmdRemoveOn.ToString(),nq}, pmdFire = {pmdFire.ToString(),nq}, rmdOtherMethod = {rmdOtherMethod}")]
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
        public CorEventAttr pdwEventFlags { get; }

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

        public GetEventPropsResult(mdTypeDef pClass, string szEvent, CorEventAttr pdwEventFlags, mdToken ptkEventType, mdMethodDef pmdAddOn, mdMethodDef pmdRemoveOn, mdMethodDef pmdFire, mdMethodDef[] rmdOtherMethod)
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
