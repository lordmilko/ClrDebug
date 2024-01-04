using System;
using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    /// <summary>
    /// If a client wants to take over the storage of keys and values for an object, it can implement this concept interface.<para/>
    /// The object is a dynamic provider of keys and wishes to take over all key queries from the core data model. This interface is typically used as a bridge to dynamic languages such as JavaScript.
    /// </summary>
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("95A7F7DD-602E-483F-9D06-A15C0EE13174")]
    [ComImport]
    public interface IDynamicConceptProviderConcept
    {
        /// <summary>
        /// The GetConcept method on a dynamic concept provider is effectively an override of the GetConcept method on <see cref="IModelObject"/>.<para/>
        /// The dynamic concept provider must return an interface for the queried concept if it exists as well as any metadata associated with that concept.<para/>
        /// If the concept does not exist on the provider, that must be indicated via a false value being returned in the hasConcept argument and a successful return.<para/>
        /// Failure of this method is a failure to fetch the concept and will explicitly halt the search for the concept. Returning false for hasConcept and a successful code will continue the search for the concept through the parent model tree.
        /// </summary>
        /// <param name="contextObject">The instance object (this pointer) for which to get a concept.</param>
        /// <param name="conceptId">The GUID which identifies the concept being acquired. This GUID uniquely identifies both the concept and the core interface of the concept.<para/>
        /// It is the interface id (IID) of the primary interface for a defined concept.</param>
        /// <param name="conceptInterface">The core interface to the concept as defined by the conceptId argument is returned here.</param>
        /// <param name="conceptMetadata">Any metadata which is associated with the concept can optionally be returned here.</param>
        /// <param name="hasConcept">An indication of whether the dynamic provider has the concept is returned here. If the provider does not have the concept, the value false should be returned here and the method should succeed.</param>
        /// <returns>This method returns HRESULT which indicates success or failure.</returns>
        [PreserveSig]
        HRESULT GetConcept(
            [In, MarshalAs(UnmanagedType.Interface)] IModelObject contextObject,
            [In, MarshalAs(UnmanagedType.LPStruct)] Guid conceptId,
            [Out, MarshalAs(UnmanagedType.Interface)] out object conceptInterface,
            [Out, MarshalAs(UnmanagedType.Interface)] out IKeyStore conceptMetadata,
            [Out, MarshalAs(UnmanagedType.U1)] out bool hasConcept);

        /// <summary>
        /// The SetConcept method on a dynamic concept provider is effectively an override of the SetConcept method on <see cref="IModelObject"/>.<para/>
        /// The dynamic provider will assign the concept. This may make the object iterable, indexable, string convertible, etc...<para/>
        /// Note that a provider which does not allow the creation of concepts on it should return E_NOPTIMPL here.
        /// </summary>
        /// <param name="contextObject">The instance object (this pointer) on which a concept is being created.</param>
        /// <param name="conceptId">The GUID which identifies the concept being assigned. This GUID uniquely identifies both the concept and the core interface of the concept.<para/>
        /// It is the interface id (IID) of the primary interface for a defined concept.</param>
        /// <param name="conceptInterface">The core interface to the concept as defined by the conceptId argument.</param>
        /// <param name="conceptMetadata">Optional metadata to be associated with the concept.</param>
        /// <returns>This method returns HRESULT which indicates success or failure.</returns>
        [PreserveSig]
        HRESULT SetConcept(
            [In, MarshalAs(UnmanagedType.Interface)] IModelObject contextObject,
            [In, MarshalAs(UnmanagedType.LPStruct)] Guid conceptId,
            [In, MarshalAs(UnmanagedType.Interface)] object conceptInterface,
            [In, MarshalAs(UnmanagedType.Interface)] IKeyStore conceptMetadata);

        /// <summary>
        /// The NotifyParent call on a dynamic concept provider is used by the core data model to inform the dynamic provider of the single parent model which is created to allow for bridging the "multiple parent models" paradigm of the data model to more dynamic languages.<para/>
        /// Any manipulation of that single parent model will cause further notifications to the dynamic provider. Note that this callback is made immediately upon assignment of the dynamic concept provider concept.
        /// </summary>
        /// <param name="parentModel">The single parent model created by the data model to help bridge the multiple parent paradigm of the data model to more dynamic languages.<para/>
        /// The dynamic provider should save this argument as it will only be notified of this once upon assignment of the dynamic concept provider concept.</param>
        /// <returns>This method returns HRESULT which indicates success or failure.</returns>
        [PreserveSig]
        HRESULT NotifyParent(
            [In, MarshalAs(UnmanagedType.Interface)] IModelObject parentModel);

        /// <summary>
        /// The NotifyParent method on a dynamic concept provider is a callback made by the core data model when a static manipulation of the object's single parent model is made.<para/>
        /// For any given parent model added, this method will be called a first time when said parent model is added and a second time if/when said parent model is removed.
        /// </summary>
        /// <param name="parentModel">The parent model being added or removed from the single parent model of the dynamic concept provider object.</param>
        /// <returns>This method returns HRESULT which indicates success or failure.</returns>
        [PreserveSig]
        HRESULT NotifyParentChange(
            [In, MarshalAs(UnmanagedType.Interface)] IModelObject parentModel);

        /// <summary>
        /// The NotifyDestruct method on a dynamic concept provider is a callback made by the core data model at the start of destruction of the object which is a dynamic concept provider.<para/>
        /// It provides additional clean up opportunities to clients which require it.
        /// </summary>
        /// <returns>This method returns HRESULT which indicates success or failure.</returns>
        [PreserveSig]
        HRESULT NotifyDestruct();
    }
}
