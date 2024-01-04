using System;
using System.Runtime.InteropServices;
using ClrDebug.TypeLib;

namespace ClrDebug.DbgEng
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("D61E19F4-AB3D-4344-9F7B-0993F3D58745")]
    [ComImport]
    public interface IModelObject2 : IModelObject
    {
        /// <summary>
        /// The GetContext method returns the host context that is associated with the object. This represents which target, process, thread, etc...<para/>
        /// the object came from.
        /// </summary>
        /// <param name="context">The host context of the object will be returned in this argument.</param>
        /// <returns>This method returns HRESULT that indicates success or failure.</returns>
        [PreserveSig]
        new HRESULT GetContext(
            [Out, MarshalAs(UnmanagedType.Interface)] out IDebugHostContext context);

        /// <summary>
        /// The GetKind method returns what kind of object is boxed inside the <see cref="IModelObject"/>. Such kind is defined by the ModelObjectKind enumeration.
        /// </summary>
        /// <param name="kind">The kind of object as indicated above will be returned in this argument.</param>
        /// <returns>This method returns HRESULT that indicates success or failure. This method should not typically fail.</returns>
        [PreserveSig]
        new HRESULT GetKind(
            [Out] out ModelObjectKind kind);

        /// <summary>
        /// The GetIntrinsicValue method returns the thing which is boxed inside an <see cref="IModelObject"/>. This method may only legally be called on <see cref="IModelObject"/> interfaces which represent a boxed intrinsic or a particular interface which is boxed.<para/>
        /// It cannot be called on native objects, no value objects, synthetic objects, and reference objects.
        /// </summary>
        /// <param name="intrinsicData">The value boxed inside the <see cref="IModelObject"/> is returned here. The pointer must point to a VARIANT structure which does not contain a freeable value.<para/>
        /// It is the responsibility of the caller to clear this VARIANT with VariantClear when finished with it.</param>
        /// <returns>This method returns HRESULT that indicates success or failure.</returns>
        [PreserveSig]
        new HRESULT GetIntrinsicValue(
            [Out, MarshalAs(UnmanagedType.Struct)] out object intrinsicData);

        /// <summary>
        /// The GetIntrinsicValueAs method behaves much as the GetIntrinsicValue method excepting that it converts the value to the specified variant type.<para/>
        /// If the conversion cannot be performed, the method returns an error.
        /// </summary>
        /// <param name="vt">The type of value to convert to is passed here as a VARTYPE. Legal values are VT_I1 through VT_I8, VT_U1 through VT_U8, VT_R4 through VT_R8, and VT_BOOL.<para/>
        /// String conversions cannot be performed through this method.</param>
        /// <param name="intrinsicData">The value boxed inside the <see cref="IModelObject"/> converted to the type described by the vt argument is returned here.<para/>
        /// The pointer must point to a VARIANT structure which does not contain a freeable value. It is the responsibility of the caller to clear this VARIANT with VariantClear when finished with it.</param>
        /// <returns>This method returns HRESULT that indicates success or failure.</returns>
        [PreserveSig]
        new HRESULT GetIntrinsicValueAs(
            [In] VARENUM vt,
            [Out, MarshalAs(UnmanagedType.Struct)] out object intrinsicData);

        /// <summary>
        /// The GetKeyValue method is the first method a client will turn to in order to get the value of (and the metadata associated with) a given key by name.<para/>
        /// If the key is a property accessor -- that is it's value as an <see cref="IModelObject"/> which is a boxed <see cref="IModelPropertyAccessor"/>, the GetKeyValue method will automatically call the property accessor's GetValue method in order to retrieve the actual value.
        /// </summary>
        /// <param name="key">The name of the key to get a value for.</param>
        /// <param name="object">The value of the key will be returned in this argument. In some error cases, extended error information may be passed out in this argument even though the method returns a failing HRESULT.</param>
        /// <param name="metadata">The metadata store associated with this key will be optionally returned in this argument.</param>
        /// <returns>This method returns HRESULT that indicates success or failure. The return values E_BOUNDS (or E_NOT_SET in some cases) indicates the key could not be found.</returns>
        [PreserveSig]
        new HRESULT GetKeyValue(
            [In, MarshalAs(UnmanagedType.LPWStr)] string key,
            [Out, MarshalAs(UnmanagedType.Interface)] out IModelObject @object,
            [Out, MarshalAs(UnmanagedType.Interface)] out IKeyStore metadata);

        /// <summary>
        /// The SetKeyValue method is the first method a client will turn to in order to set the value of a key. This method cannot be used to create a new key on an object.<para/>
        /// It will only set the value of an existing key. Note that many keys are read-only (e.g.: they are implemented by a property accessor which returns E_NOT_IMPL from it's SetValue method).<para/>
        /// This method will fail when called on a read only key.
        /// </summary>
        /// <param name="key">The name of the key to set a value for.</param>
        /// <param name="object">The value of the key will be set to the object contained in this argument.</param>
        /// <returns>This method returns HRESULT that indicates success or failure.</returns>
        [PreserveSig]
        new HRESULT SetKeyValue(
            [In, MarshalAs(UnmanagedType.LPWStr)] string key,
            [In, MarshalAs(UnmanagedType.Interface)] IModelObject @object);

        /// <summary>
        /// The EnumerateKeyValues method is the first method a client will turn to in order to enumerate all of the keys on an object (this includes all keys implemented anywhere in the tree of parent models).<para/>
        /// It is important to note that EnumerateKeyValues will enumerate any keys defined by duplicate names in the object tree; however -- methods like GetKeyValue and SetKeyValue will only manipulate the first instance of a key with the given name as discovered by the depth-first-traversal.
        /// </summary>
        /// <param name="enumerator">An enumerator for all keys on the object (and all of its parent models) and their values and metadata is returned in this argument as an <see cref="IKeyEnumerator"/>.</param>
        /// <returns>This method returns HRESULT that indicates success or failure.</returns>
        [PreserveSig]
        new HRESULT EnumerateKeyValues(
            [Out, MarshalAs(UnmanagedType.Interface)] out IKeyEnumerator enumerator);

        /// <summary>
        /// The GetRawValue method finds a native construct within the given object. Such a construct may be a field, a base class, a field in a base class, a member function, etc.
        /// </summary>
        /// <param name="kind">Indicates the kind of native symbol to fetch (e.g.: a base class or a data member)</param>
        /// <param name="name">The name of the native construct to fetch.</param>
        /// <param name="searchFlags">An optional set of flags specifying the behavior of the search for the native construct.</param>
        /// <param name="object">An <see cref="IModelObject"/> representing the fetched native construct will be returned here. Note that in some circumstances, extended error information may be returned in this argument even if the HRESULT indicates failure.</param>
        /// <returns>This method returns HRESULT that indicates success or failure.</returns>
        /// <remarks>
        /// The searchFlags argument is a set of bit flags specified by the RawSearchFlags enumeration. This enumeration presently
        /// defines the following values: RawSearchNone - No special semantics to the search. Do the default search action
        /// for the target language being debugged. RawSearchNoBases - Indicates that the search should not recurse to base
        /// children (e.g.: base classes). Only names/types which are in the object itself should be returned. Code Sample
        /// </remarks>
        [PreserveSig]
        new HRESULT GetRawValue(
            [In] SymbolKind kind,
            [In, MarshalAs(UnmanagedType.LPWStr)] string name,
            [In] int searchFlags,
            [Out, MarshalAs(UnmanagedType.Interface)] out IModelObject @object);

        /// <summary>
        /// The EnumerateRawValues method enumerates all native children (e.g.: fields, base classes, etc...) of the given object.
        /// </summary>
        /// <param name="kind">Indicates the kind of native symbol to fetch (e.g.: a base class or a data member)</param>
        /// <param name="searchFlags">An optional set of flags specifying the behavior of the search for the native construct.</param>
        /// <param name="enumerator">An enumerator which will enumerate every native child of the kind specified by the kind argument as an <see cref="IRawEnumerator"/> interface.</param>
        /// <returns>This method returns HRESULT that indicates success or failure.</returns>
        [PreserveSig]
        new HRESULT EnumerateRawValues(
            [In] SymbolKind kind,
            [In] int searchFlags,
            [Out, MarshalAs(UnmanagedType.Interface)] out IRawEnumerator enumerator);

        /// <summary>
        /// The Dereference method dereferences an object. This method can be used to dereference a data model based reference (ObjectTargetObjectReference, ObjectKeyReference) or a native language reference (a pointer or a language reference).<para/>
        /// It is important to note that this method removes a single level of reference semantics on the object. It is entirely possible to, for instance, have a data model reference to a language reference.<para/>
        /// In such a case, calling the Dereference method the first time would remove the data model reference and leave the language reference.<para/>
        /// Calling Dereference on that resulting object would subsequently remove the language reference and return the native value under that reference.
        /// </summary>
        /// <param name="object">The result of dereferencing the object will be returned here.</param>
        /// <returns>This method returns HRESULT that indicates success or failure.</returns>
        [PreserveSig]
        new HRESULT Dereference(
            [Out, MarshalAs(UnmanagedType.Interface)] out IModelObject @object);

        /// <summary>
        /// The TryCastToRuntimeType method will ask the debug host to perform an analysis and determine the actual runtime type (e.g.: most derived class) of the given object.<para/>
        /// The exact analysis utilized is specific to the debug host and may include RTTI (C++ run time type information), examination of the V-Table(virtual function table) structure of the object, or any other means that the host can use to reliably determine dynamic/runtime type from the static type.<para/>
        /// Failure to convert to a runtime type does not mean that this method call will fail. In such cases, the method will return the given object (the this pointer) in the output argument.
        /// </summary>
        /// <param name="runtimeTypedObject">The conversion of the given object to an instance of its dynamic/runtime type will be returned in this argument.<para/>
        /// If analysis fails to find a change in static type, the given object (this pointer) maybe returned (with an additional reference) in this output.</param>
        /// <returns>This method returns HRESULT that indicates success or failure. Note that an analysis which cannot find a derived type is not a failure as defined here.</returns>
        [PreserveSig]
        new HRESULT TryCastToRuntimeType(
            [Out, MarshalAs(UnmanagedType.Interface)] out IModelObject runtimeTypedObject);

        /// <summary>
        /// The GetConcept method will search for a concept on the object (or its parent model chain) and return an interface pointer to the concept interface.<para/>
        /// The behavior and methods on a concept interface are specific to each concept. It is important to note, however, that many of the concept interfaces require the caller to explicitly pass the context object (or what one might traditionally call the this pointer).<para/>
        /// It is important to ensure that the correct context object is passed to every concept interface.
        /// </summary>
        /// <param name="conceptId">The unique identifier of the concept being queried. This is also the IID of the core interface of the concept.</param>
        /// <param name="conceptInterface">The interface defined by conceptId will be returned in this argument.</param>
        /// <param name="conceptMetadata">The metadata store associated with this concept will be optionally returned in this argument</param>
        /// <returns>This method returns HRESULT that indicates success or failure.</returns>
        [PreserveSig]
        new HRESULT GetConcept(
            [In, MarshalAs(UnmanagedType.LPStruct)] Guid conceptId,
            [Out, MarshalAs(UnmanagedType.Interface)] out object conceptInterface,
            [Out, MarshalAs(UnmanagedType.Interface)] out IKeyStore conceptMetadata);

        /// <summary>
        /// The GetLocation method will return the location of the native object. While such a location is typically a virtual address within the address space of the debug target, it is not necessarily so.<para/>
        /// The location returned by this method is an abstract location that may be a virtual address, may indicate placement within a register or sub-register, or may indicate some other arbitrary address space as defined by the debug host.<para/>
        /// If the HostDefined field of the resulting Location object is 0, it indicates that the location is actually a virtual address.<para/>
        /// Such virtual address may be retrieved by examining the Offset field of the resulting location. Any non-zero value of the HostDefined field indicates an alternate address space where the Offset field is the offset within that address space.<para/>
        /// The exact meaning of non-zero HostDefined values here are private to the debug host. If the <see cref="IModelObject"/> on which this method is called is not a native construct with a location in some abstract address space of the debug target, this method will return E_FAIL.
        /// </summary>
        /// <param name="location">The abstract location of the native object represented by the this pointer will be returned here.</param>
        /// <returns>This method returns HRESULT that indicates success or failure.</returns>
        /// <remarks>
        /// In this sample, the <see cref="Location"/> defines the location for an object.
        /// </remarks>
        [PreserveSig]
        new HRESULT GetLocation(
            [Out] out Location location);

        /// <summary>
        /// The GetTypeInfo method will return the native type of the given object. If the object does not have native type information associated with it (e.g.: it is an intrinsic, etc...), the call will still succeed but will return null.
        /// </summary>
        /// <param name="type">The native type of the object represented by the this pointer will be returned here as an <see cref="IDebugHostType"/> interface.</param>
        /// <returns>This method returns HRESULT that indicates success or failure.</returns>
        /// <remarks>
        /// In this sample the <see cref="IDebugHostType"/> is used.
        /// </remarks>
        [PreserveSig]
        new HRESULT GetTypeInfo(
            [Out, MarshalAs(UnmanagedType.Interface)] out IDebugHostType type);

        /// <summary>
        /// The GetTargetInfo method is effectively a combination of the GetLocation and GetTypeInfo methods returning both the abstract location as well as native type of the given object.
        /// </summary>
        /// <param name="location">The abstract location of the native object represented by the this pointer will be returned here.</param>
        /// <param name="type">The native type of the object represented by the this pointer will be returned here as an <see cref="IDebugHostType"/> interface.</param>
        /// <returns>This method returns HRESULT that indicates success or failure.</returns>
        [PreserveSig]
        new HRESULT GetTargetInfo(
            [Out] out Location location,
            [Out, MarshalAs(UnmanagedType.Interface)] out IDebugHostType type);

        /// <summary>
        /// The GetNumberOfParentModels method returns the number of parent models which are attached to the given object instance.<para/>
        /// Parent models are searched for properties depth-first in the linear ordering of the parent model chain.
        /// </summary>
        /// <param name="numModels">The number of parent models of the given object is returned here.</param>
        /// <returns>This method returns HRESULT that indicates success or failure.</returns>
        [PreserveSig]
        new HRESULT GetNumberOfParentModels(
            [Out] out long numModels);

        /// <summary>
        /// The GetParentModel method returns the i-th parent model in the parent model chain of the given object. Parent models are searched for a property or concept in the linear order they are added or enumerated.<para/>
        /// The parent model with index i of zero is searched (hierarchically) before the parent model with index i + 1.
        /// </summary>
        /// <param name="i">A linear zero based index indicating which parent model in the chain to retrieve.</param>
        /// <param name="model">An <see cref="IModelObject"/> representing the i-th parent model will be returned here.</param>
        /// <param name="contextObject">If the parent model has an associated context adjustor, the adjusted context will be returned here. See the documentation for AddParentModel for more information about this value.</param>
        /// <returns>This method returns HRESULT that indicates success or failure.</returns>
        [PreserveSig]
        new HRESULT GetParentModel(
            [In] long i,
            [Out, MarshalAs(UnmanagedType.Interface)] out IModelObject model,
            [Out, MarshalAs(UnmanagedType.Interface)] out IModelObject contextObject);

        /// <summary>
        /// The AddParentModel method adds a new parent model to the given object. Such a model may be added at the end of the search chain (the override argument is specified as false) or at the front of the search chain (the override argument is specified as true).<para/>
        /// In addition, each parent model may optionally adjust the context (the semantic this pointer) for any property or concept on the given parent (or anyone in its parent hierarchy).<para/>
        /// Context adjustment is seldom used but allows for some powerful concepts like object embedding, constructing namespaces, etc...<para/>
        /// When a parent model has a context adjustment, the core data model will perform this adjustment automatically on behalf of the caller.<para/>
        /// In effect, for an object instance with a parent model parent having a context adjustor to newContext, a call of will end up changing the context/this pointer from instance to newContext before calling someKey's GetValue method since the access to someKey passed through the context adjustor.<para/>
        /// Any <see cref="IModelObject"/> which is added as a parent model to another object must individually support the <see cref="IDataModelConcept"/> concept.<para/>
        /// Failure to implement this concept may result in the AddParentModel method call failing.
        /// </summary>
        /// <param name="model">An <see cref="IModelObject"/> which will be added to the parent model chain of the given object. This <see cref="IModelObject"/> must individually support the <see cref="IDataModelConcept"/> concept.</param>
        /// <param name="contextObject">If the data model has a context adjustment associated with it, the adjusted context (or a property accessor which returns the adjusted context) may be passed here.</param>
        /// <param name="override">An indication of whether the parent model specified by the model argument is placed at the front or the end of the linear chain of parent models.<para/>
        /// A value of false (normally supplied) indicates the end of the chain. A value of true indicates the front of the chain.</param>
        /// <returns>This method returns HRESULT that indicates success or failure.</returns>
        /// <remarks>
        /// ** Code Sample**
        /// </remarks>
        [PreserveSig]
        new HRESULT AddParentModel(
            [In, MarshalAs(UnmanagedType.Interface)] IModelObject model,
            [In, MarshalAs(UnmanagedType.Interface)] IModelObject contextObject,
            [In, MarshalAs(UnmanagedType.U1)] bool @override);

        /// <summary>
        /// The RemoveParentModel will remove a specified parent model from the parent search chain of the given object.
        /// </summary>
        /// <param name="model">The parent model to remove from this object.</param>
        /// <returns>This method returns HRESULT that indicates success or failure.</returns>
        [PreserveSig]
        new HRESULT RemoveParentModel(
            [In, MarshalAs(UnmanagedType.Interface)] IModelObject model);

        /// <summary>
        /// The GetKey method will get the value of (and the metadata associated with) a given key by name. Most clients should utilize the GetKeyValue method instead.<para/>
        /// If the key is a property accessor, calling this method will return the property accessor (an <see cref="IModelPropertyAccessor"/> interface) boxed into an <see cref="IModelObject"/>.<para/>
        /// Unlike, GetKeyValue, this method will not automatically resolve the underlying value of the key by calling the GetValue method.<para/>
        /// That responsibility is the caller's.
        /// </summary>
        /// <param name="key">The name of the key to get a value for.</param>
        /// <param name="object">The value of the key will be returned in this argument. In some error cases, extended error information may be passed out in this argument even though the method returns a failing HRESULT.</param>
        /// <param name="metadata">The metadata store associated with this key will be optionally returned in this argument.</param>
        /// <returns>This method returns HRESULT that indicates success or failure. The return values E_BOUNDS (or E_NOT_SET in some cases) indicates the key could not be found.</returns>
        [PreserveSig]
        new HRESULT GetKey(
            [In, MarshalAs(UnmanagedType.LPWStr)] string key,
            [Out, MarshalAs(UnmanagedType.Interface)] out IModelObject @object,
            [Out, MarshalAs(UnmanagedType.Interface)] out IKeyStore metadata);

        /// <summary>
        /// If the object or one of its parent models has a key named according to the argument 'key', this will return a reference to that key (and optionally the present metadata associated with that key).
        /// </summary>
        /// <param name="key">The name of the key to get a value for.</param>
        /// <param name="objectReference">The object reference.</param>
        /// <param name="metadata">The metadata store associated with this key will be optionally returned in this argument.</param>
        /// <returns>This method returns HRESULT that indicates success or failure.</returns>
        [PreserveSig]
        new HRESULT GetKeyReference(
            [In, MarshalAs(UnmanagedType.LPWStr)] string key,
            [Out, MarshalAs(UnmanagedType.Interface)] out IModelObject objectReference,
            [Out, MarshalAs(UnmanagedType.Interface)] out IKeyStore metadata);

        /// <summary>
        /// The SetKey method is the method a client will turn to in order to create a key on an object (and potentially associate metadata with the created key).<para/>
        /// If a given object already has a key with the given name, one of two behaviors will occur. If the key is on the instance given by this, the value of that key will be replaced as if the original key did not exist.<para/>
        /// If, on the other hand, the key is in the chain of parent data models of the instance given by this, a new key with the given name will be created on the instance given by this.<para/>
        /// This would, in effect, cause the object to have two keys of the same name (similar to a derived class shadowing a member of the same name as a base class).
        /// </summary>
        /// <param name="key">The name of the key to set a value for.</param>
        /// <param name="object">The value of the key will be set to the object contained in this argument.</param>
        /// <param name="metadata">Optional metadata to be associated with the newly set key.</param>
        /// <returns>This method returns HRESULT that indicates success or failure.</returns>
        [PreserveSig]
        new HRESULT SetKey(
            [In, MarshalAs(UnmanagedType.LPWStr)] string key,
            [In, MarshalAs(UnmanagedType.Interface)] IModelObject @object,
            [In, MarshalAs(UnmanagedType.Interface)] IKeyStore metadata);

        /// <summary>
        /// The ClearKeys method removes all keys and their associated values and metadata from the instance of the object specified by this.<para/>
        /// This method has no effect on parent models attached to the particular object instance.
        /// </summary>
        /// <returns>This method returns HRESULT that indicates success or failure.</returns>
        [PreserveSig]
        new HRESULT ClearKeys();

        /// <summary>
        /// Enumerates the keys within the dynamic key provider. The returned enumerator must behave as per an EnumerateKeys(...) call on <see cref="IModelObject"/> and not as EnumerateKeyValues or any of the other enumeration variants.<para/>
        /// Note that from the perspective of a single dynamic key provider, it is illegal to enumerate multiple keys of the same name that are physically distinct keys.
        /// </summary>
        /// <param name="enumerator">An enumerator for all keys on the object (and all of its parent models) and their values and metadata is returned in this argument as an <see cref="IKeyEnumerator"/>.</param>
        /// <returns>This method returns HRESULT that indicates success or failure.</returns>
        /// <remarks>
        /// The EnumerateKeys method behaves similar to the EnumerateKeyValues method excepting that it does not automatically
        /// resolve property accessors on the object. This means that if the value of a key is a property accessor, the EnumerateKeys
        /// method will return the property accessor (an IModelPropertyAccessorInterface) boxed into an <see cref="IModelObject"/>
        /// rather than automatically calling the GetValue method. This is similar to the difference between GetKey and GetKeyValue.
        /// </remarks>
        [PreserveSig]
        new HRESULT EnumerateKeys(
            [Out, MarshalAs(UnmanagedType.Interface)] out IKeyEnumerator enumerator);

        /// <summary>
        /// The EnumerateKeyReferences method behaves similar to the EnumerateKeyValues method excepting that it returns references to the keys it enumerates (given by an <see cref="IModelKeyReference"/> interface boxed into an <see cref="IModelObject"/>) instead of the value of the key.<para/>
        /// Such references can be used to get or set the underlying value of the keys.
        /// </summary>
        /// <param name="enumerator">An enumerator for references to all keys on the object (and all of its parent models) and metadata is returned in this argument as an <see cref="IKeyEnumerator"/>.</param>
        /// <returns>This method returns HRESULT that indicates success or failure.</returns>
        [PreserveSig]
        new HRESULT EnumerateKeyReferences(
            [Out, MarshalAs(UnmanagedType.Interface)] out IKeyEnumerator enumerator);

        /// <summary>
        /// The SetConcept method will place a specified concept on the object instance specified by the this pointer. If a parent model attached to the object instance specified by this also supports the concept, the implementation in the instance will override that in the parent model.<para/>
        /// For the set of concepts (interfaces) that are supported by the data model, see Debugger Data Model C. For information on the <see cref="IKeyStore"/> interface, see <see cref="IKeyStore"/>.
        /// </summary>
        /// <param name="conceptId">The unique identifier of the concept being assigned. This is also the IID of the core interface of the concept.</param>
        /// <param name="conceptInterface">The concept interface being assigned (defined by conceptId).</param>
        /// <param name="conceptMetadata">Optional metadata to be associated with this concept.</param>
        /// <returns>This method returns HRESULT that indicates success or failure.</returns>
        [PreserveSig]
        new HRESULT SetConcept(
            [In, MarshalAs(UnmanagedType.LPStruct)] Guid conceptId,
            [In, MarshalAs(UnmanagedType.Interface)] object conceptInterface,
            [In, MarshalAs(UnmanagedType.Interface)] IKeyStore conceptMetadata);

        /// <summary>
        /// The ClearConcepts method will remove all concepts from the instance of the object specified by this.
        /// </summary>
        /// <returns>This method returns HRESULT that indicates success or failure.</returns>
        [PreserveSig]
        new HRESULT ClearConcepts();

        /// <summary>
        /// The GetRawReference method finds a native construct within the given object and returns a reference to it. Such a construct may be a field, a base class, a field in a base class, a member function, etc...<para/>
        /// It is important to distinguish the reference returned here (an object of the type ObjectTargetObjectReference) from a language reference (e.g.: a C++ &amp; or &amp;&amp; style reference).
        /// </summary>
        /// <param name="kind">Indicates the kind of native symbol to fetch (e.g.: a base class or a data member)</param>
        /// <param name="name">The name of the native construct to fetch.</param>
        /// <param name="searchFlags">An optional set of flags specifying the behavior of the search for the native construct.</param>
        /// <param name="object">An <see cref="IModelObject"/> representing the fetched native construct will be returned here. Note that in some circumstances, extended error information may be returned in this argument even if the HRESULT indicates failure.</param>
        /// <returns>This method returns HRESULT that indicates success or failure. The return values E_BOUNDS (or E_NOT_SET in some cases) indicates the field could not be found.</returns>
        [PreserveSig]
        new HRESULT GetRawReference(
            [In] SymbolKind kind,
            [In, MarshalAs(UnmanagedType.LPWStr)] string name,
            [In] int searchFlags,
            [Out, MarshalAs(UnmanagedType.Interface)] out IModelObject @object);

        /// <summary>
        /// The EnumerateRawReferences method enumerates references to all native children (e.g.: fields, base classes, etc...) of the given object.
        /// </summary>
        /// <param name="kind">Indicates the kind of native symbol to fetch (e.g.: a base class or a data member).</param>
        /// <param name="searchFlags">An optional set of flags specifying the behavior of the search for the native construct.</param>
        /// <param name="enumerator">An enumerator which will enumerate a reference (an object that is a ObjectTargetObjectReference style object) to every native child of the kind specified by the kind argument as an <see cref="IRawEnumerator"/> interface.</param>
        /// <returns>This method returns HRESULT that indicates success or failure.</returns>
        [PreserveSig]
        new HRESULT EnumerateRawReferences(
            [In] SymbolKind kind,
            [In] int searchFlags,
            [Out, MarshalAs(UnmanagedType.Interface)] out IRawEnumerator enumerator);

        /// <summary>
        /// The SetContextForDataModel method is used by the implementation of a data model to place implementation data on instance objects.<para/>
        /// Conceptually, each <see cref="IModelObject"/> (call this the instance for simplicity) contains a hash table of state.<para/>
        /// The hash table is indexed by another <see cref="IModelObject"/> (call this the data model for simplicity) which is in the parent model hierarchy of the instance.<para/>
        /// The value contained in this hash is a set of reference counted state information represented by an IUnknown instance.<para/>
        /// Once the data model sets this state on the instance it can store arbitrary implementation data which can be retrieved during things like property getters.<para/>
        /// It is often the case that extensions (or other data model components) want to represent some synthetic construct as what one might consider a type.<para/>
        /// The debugger's exposing of process objects is one such example. Frequently, an implementation will map the notion of a type definition to a data model.<para/>
        /// The data model will contain property getters for the things which are exposed on the object (e.g.: process name, process id, thread count, threads, etc...).<para/>
        /// When it is time to create an instance of this data model, a blank synthetic object is created and the data model (or what we might consider the type definition) is attached as a parent model.<para/>
        /// In some cases, enough information to uniquely identify the object and implement all of the data model's' property getters might be able to be directly placed on the instance object.<para/>
        /// In our process example, the process id might be stored as a key named Id on the instance. When a getter on the data model is called, say for the process name, for example, the implementation can simply call the GetKeyValue method to fetch the process Id.<para/>
        /// The implementation necessary to return the name can then do so from the PID. In other cases, the state required to implement the type is more complex, contains other native constructs, or for other reasons cannot be set as an instance key.<para/>
        /// In such cases, the data model will construct an IUnknown derived class, place the implementation data within this class, and call the SetContextForDataModel method on the instance in order to associate its implementation data with the instance object.<para/>
        /// When the instance destructs, the reference count on the state class will be released and it will be freed as required
        /// </summary>
        /// <param name="dataModelObject">The <see cref="IModelObject"/> representing the data model for which state is being stored on an instance object.<para/>
        /// This is, in effect, a hash key to the associated state object.</param>
        /// <param name="context">The state being associated with the instance. The exact meaning of this (and any other interfaces, etc... it supports) is up to the data model making the call to set this state.<para/>
        /// The only requirement is that such state is COM reference counted.</param>
        /// <returns>This method returns HRESULT that indicates success or failure.</returns>
        [PreserveSig]
        new HRESULT SetContextForDataModel(
            [In, MarshalAs(UnmanagedType.Interface)] IModelObject dataModelObject,
            [In, MarshalAs(UnmanagedType.Interface)] object context);

        /// <summary>
        /// The GetContextForDataModel method is used to retrieve context information which was set up with a prior call to SetContextForDataModel.<para/>
        /// This retrieves state information which was set on an instance object by a data model further up in the instance object's parent model hierarchy.<para/>
        /// For more details about this context/state and its meaning, see the documentation for <see cref="SetContextForDataModel"/>.
        /// </summary>
        /// <param name="dataModelObject">The <see cref="IModelObject"/> representing the data model for which state is being retrieved from an instance object.<para/>
        /// This is, in effect, a hash key to the associated state object.</param>
        /// <param name="context">The state which was associated with the instance is returned here. The exact meaning of this (and any other interfaces, etc...<para/>
        /// it supports) is up to the data model that made the call to set the state.</param>
        /// <returns>This method returns HRESULT that indicates success or failure.</returns>
        [PreserveSig]
        new HRESULT GetContextForDataModel(
            [In, MarshalAs(UnmanagedType.Interface)] IModelObject dataModelObject,
            [Out, MarshalAs(UnmanagedType.Interface)] out object context);

        /// <summary>
        /// The Compare method compares two model objects and returns an indication of how those objects relate. One of three states is returned: Note that only intrinsic values can be compared using this method.<para/>
        /// Calling with any other object type will result in failure.
        /// </summary>
        /// <param name="other">The object to compare this object to. The instance object is on the left side of the comparison and the object supplied by this argument is on the right.</param>
        /// <param name="ppResult">The result of the comparison is returned here. If less than zero, this &lt; other; if equal to zero, this == other; if greater than zero, this &gt; other.</param>
        /// <returns>This method returns HRESULT that indicates success or failure.</returns>
        [PreserveSig]
        new HRESULT Compare(
            [In, MarshalAs(UnmanagedType.Interface)] IModelObject other,
            [Out, MarshalAs(UnmanagedType.Interface)] out IModelObject ppResult);

        /// <summary>
        /// The IsEqualTo method compares a host context to another host context. If the two contexts are equivalent, an indication of this is returned.<para/>
        /// Note that this comparison is not interface equivalence. This compares the underlying opaque contents of the context itself.<para/>
        /// It is also important to note that this method checks for equivalence and not that one of the contexts is a subset or superset of the other.
        /// </summary>
        /// <param name="other">The host context to compare against.</param>
        /// <param name="equal">An indication of whether the two contexts are equivalent is passed back here.</param>
        /// <returns>This method returns HRESULT that indicates success or failure.</returns>
        [PreserveSig]
        new HRESULT IsEqualTo(
            [In, MarshalAs(UnmanagedType.Interface)] IModelObject other,
            [Out, MarshalAs(UnmanagedType.U1)] out bool equal);
        
        [PreserveSig]
        HRESULT EnumerateOwnKeyValues(
            [Out, MarshalAs(UnmanagedType.Interface)] out IKeyEnumerator ppEnumerator);
        
        [PreserveSig]
        HRESULT EnumerateOwnKeys(
            [Out, MarshalAs(UnmanagedType.Interface)] out IKeyEnumerator ppEnumerator);
        
        [PreserveSig]
        HRESULT EnumerateOwnKeyReferences(
            [Out, MarshalAs(UnmanagedType.Interface)] out IKeyEnumerator ppEnumerator);
    }
}
