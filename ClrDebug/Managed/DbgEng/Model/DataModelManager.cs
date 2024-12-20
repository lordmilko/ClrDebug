﻿using System;
using System.Diagnostics;

namespace ClrDebug.DbgEng
{
    /// <summary>
    /// The core interface for the data model manager. This is the interface by which new objects are created, intrinsic values are boxed and unboxed, and models are registered for types.<para/>
    /// This interface is never directly implemented by a client.
    /// </summary>
    public class DataModelManager : ComObject<IDataModelManager>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DataModelManager"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
        public DataModelManager(IDataModelManager raw) : base(raw)
        {
        }

        #region IDataModelManager
        #region RootNamespace

        /// <summary>
        /// The GetRootNamespace method returns the data model's root namespace. This is an object which the data model manages and into which the debug host places certain objects.<para/>
        /// It is expected that at least the following hierarchy is exposed by every host:
        /// </summary>
        public ModelObject RootNamespace
        {
            get
            {
                ModelObject rootNamespaceResult;
                TryGetRootNamespace(out rootNamespaceResult).ThrowDbgEngNotOK();

                return rootNamespaceResult;
            }
        }

        /// <summary>
        /// The GetRootNamespace method returns the data model's root namespace. This is an object which the data model manages and into which the debug host places certain objects.<para/>
        /// It is expected that at least the following hierarchy is exposed by every host:
        /// </summary>
        /// <param name="rootNamespaceResult">The root namespace of the data model is returned here.</param>
        /// <returns>This method returns HRESULT that indicates success or failure.</returns>
        public HRESULT TryGetRootNamespace(out ModelObject rootNamespaceResult)
        {
            /*HRESULT GetRootNamespace(
            [Out, MarshalAs(UnmanagedType.Interface)] out IModelObject rootNamespace);*/
            IModelObject rootNamespace;
            HRESULT hr = Raw.GetRootNamespace(out rootNamespace);

            if (hr == HRESULT.S_OK)
                rootNamespaceResult = rootNamespace == null ? null : new ModelObject(rootNamespace);
            else
                rootNamespaceResult = default(ModelObject);

            return hr;
        }

        #endregion
        #region Close

        /// <summary>
        /// The Close method is called on the data model manager by an application (e.g.: debugger) hosting the data model in order to start the shutdown process of the data model manager.<para/>
        /// A host of the data model which does not the Close method prior to releasing its final reference on the data model manager may cause undefined behavior including, but not limited to, significant leaks of the management infrastructure for the data model.
        /// </summary>
        public void Close()
        {
            TryClose().ThrowDbgEngNotOK();
        }

        /// <summary>
        /// The Close method is called on the data model manager by an application (e.g.: debugger) hosting the data model in order to start the shutdown process of the data model manager.<para/>
        /// A host of the data model which does not the Close method prior to releasing its final reference on the data model manager may cause undefined behavior including, but not limited to, significant leaks of the management infrastructure for the data model.
        /// </summary>
        /// <returns>This method returns HRESULT.</returns>
        public HRESULT TryClose()
        {
            /*HRESULT Close();*/
            return Raw.Close();
        }

        #endregion
        #region CreateNoValue

        /// <summary>
        /// The CreateNoValue method creates a "no value" object, boxes it into an <see cref="IModelObject"/>, and returns it.<para/>
        /// The returned model object has a kind of ObjectNoValue. A "no value" object has several semantic meanings:
        /// </summary>
        /// <returns>The newly created/boxed "no value" object will be returned here.</returns>
        public ModelObject CreateNoValue()
        {
            ModelObject objectResult;
            TryCreateNoValue(out objectResult).ThrowDbgEngNotOK();

            return objectResult;
        }

        /// <summary>
        /// The CreateNoValue method creates a "no value" object, boxes it into an <see cref="IModelObject"/>, and returns it.<para/>
        /// The returned model object has a kind of ObjectNoValue. A "no value" object has several semantic meanings:
        /// </summary>
        /// <param name="objectResult">The newly created/boxed "no value" object will be returned here.</param>
        /// <returns>This method returns HRESULT that indicates success or failure.</returns>
        public HRESULT TryCreateNoValue(out ModelObject objectResult)
        {
            /*HRESULT CreateNoValue(
            [Out, MarshalAs(UnmanagedType.Interface)] out IModelObject @object);*/
            IModelObject @object;
            HRESULT hr = Raw.CreateNoValue(out @object);

            if (hr == HRESULT.S_OK)
                objectResult = @object == null ? null : new ModelObject(@object);
            else
                objectResult = default(ModelObject);

            return hr;
        }

        #endregion
        #region CreateErrorObject

        /// <summary>
        /// The CreateErrorObject method creates an "error object". The data model does not have the notion of exceptions and exception flow.<para/>
        /// Failure comes out of a property/method in two ways:
        /// </summary>
        /// <param name="hrError">The error code for which the extended error information is being created. If a given function is the entity creating an error object for a failure, this code must match the failing HRESULT returned by the function.</param>
        /// <param name="pwszMessage">An optional message giving a deeper indication of what failed and why. This message will be the display string conversion of the created error object.</param>
        /// <returns>The newly constructed/boxed error object will be returned here.</returns>
        public ModelObject CreateErrorObject(HRESULT hrError, string pwszMessage)
        {
            ModelObject objectResult;
            TryCreateErrorObject(hrError, pwszMessage, out objectResult).ThrowDbgEngNotOK();

            return objectResult;
        }

        /// <summary>
        /// The CreateErrorObject method creates an "error object". The data model does not have the notion of exceptions and exception flow.<para/>
        /// Failure comes out of a property/method in two ways:
        /// </summary>
        /// <param name="hrError">The error code for which the extended error information is being created. If a given function is the entity creating an error object for a failure, this code must match the failing HRESULT returned by the function.</param>
        /// <param name="pwszMessage">An optional message giving a deeper indication of what failed and why. This message will be the display string conversion of the created error object.</param>
        /// <param name="objectResult">The newly constructed/boxed error object will be returned here.</param>
        /// <returns>This method returns HRESULT.</returns>
        public HRESULT TryCreateErrorObject(HRESULT hrError, string pwszMessage, out ModelObject objectResult)
        {
            /*HRESULT CreateErrorObject(
            [In] HRESULT hrError,
            [In, MarshalAs(UnmanagedType.LPWStr)] string pwszMessage,
            [Out, MarshalAs(UnmanagedType.Interface)] out IModelObject @object);*/
            IModelObject @object;
            HRESULT hr = Raw.CreateErrorObject(hrError, pwszMessage, out @object);

            if (hr == HRESULT.S_OK)
                objectResult = @object == null ? null : new ModelObject(@object);
            else
                objectResult = default(ModelObject);

            return hr;
        }

        #endregion
        #region CreateTypedObject

        /// <summary>
        /// The CreateTypedObject method is the method which allows a client to create a representation of a native/language object in the address space of a debug target.<para/>
        /// If the type of the newly created object (as indicated by the objectType argument) happens to match one or more type signatures registered with the data model manager as either canonical visualizers or extensions, those matching data models will automatically be attached to the created instance object before it is returned to the caller.
        /// </summary>
        /// <param name="context">The debug host context in which this object is located. If no explicit context is given, the context of the newly created object will inherit from the context of the objectType argument.<para/>
        /// A caller can pass the special marker value USE_CURRENT_HOST_CONTEXT to indicate that the object should receive the context which is current in the debugger's user interface.</param>
        /// <param name="objectLocation">The location of the object in the address space of the debug target. If the location is a virtual address, the location can be constructed by the client using a 64-bit offset into the address space; otherwise - the location must be retrieved from another debug host interface.</param>
        /// <param name="objectType">The type of the object being constructed. The context of the type will propagate to the newly created object if no explicit context is passed in the context argument.</param>
        /// <returns>The newly created object will be returned here.</returns>
        public ModelObject CreateTypedObject(IDebugHostContext context, Location objectLocation, IDebugHostType objectType)
        {
            ModelObject objectResult;
            TryCreateTypedObject(context, objectLocation, objectType, out objectResult).ThrowDbgEngNotOK();

            return objectResult;
        }

        /// <summary>
        /// The CreateTypedObject method is the method which allows a client to create a representation of a native/language object in the address space of a debug target.<para/>
        /// If the type of the newly created object (as indicated by the objectType argument) happens to match one or more type signatures registered with the data model manager as either canonical visualizers or extensions, those matching data models will automatically be attached to the created instance object before it is returned to the caller.
        /// </summary>
        /// <param name="context">The debug host context in which this object is located. If no explicit context is given, the context of the newly created object will inherit from the context of the objectType argument.<para/>
        /// A caller can pass the special marker value USE_CURRENT_HOST_CONTEXT to indicate that the object should receive the context which is current in the debugger's user interface.</param>
        /// <param name="objectLocation">The location of the object in the address space of the debug target. If the location is a virtual address, the location can be constructed by the client using a 64-bit offset into the address space; otherwise - the location must be retrieved from another debug host interface.</param>
        /// <param name="objectType">The type of the object being constructed. The context of the type will propagate to the newly created object if no explicit context is passed in the context argument.</param>
        /// <param name="objectResult">The newly created object will be returned here.</param>
        /// <returns>This method returns HRESULT that indicates success or failure.</returns>
        public HRESULT TryCreateTypedObject(IDebugHostContext context, Location objectLocation, IDebugHostType objectType, out ModelObject objectResult)
        {
            /*HRESULT CreateTypedObject(
            [In, MarshalAs(UnmanagedType.Interface)] IDebugHostContext context,
            [In] Location objectLocation,
            [In, MarshalAs(UnmanagedType.Interface)] IDebugHostType objectType,
            [Out, MarshalAs(UnmanagedType.Interface)] out IModelObject @object);*/
            IModelObject @object;
            HRESULT hr = Raw.CreateTypedObject(context, objectLocation, objectType, out @object);

            if (hr == HRESULT.S_OK)
                objectResult = @object == null ? null : new ModelObject(@object);
            else
                objectResult = default(ModelObject);

            return hr;
        }

        #endregion
        #region CreateTypedObjectReference

        /// <summary>
        /// The CreateTypedObjectReference method is semantically similar to the CreateTypedObject method excepting that it creates a reference to the underlying native/language construct.<para/>
        /// The created reference is an object which has a kind of ObjectTargetObjectReference. It is not a native reference as the underlying language might support (e.g.: a C++ &amp; or &amp;&amp;).<para/>
        /// It is entirely possible to have a ObjectTargetObjectReference to a C++ reference. An object of kind ObjectTargetObjectReference can be converted to the underlying value through use of the Dereference method on <see cref="IModelObject"/>.<para/>
        /// The reference can also be passed to the underlying host's expression evaluator in order to assign back to the value in a language appropriate way.
        /// </summary>
        /// <param name="context">The debug host context in which this object is located. If no explicit context is given, the context of the newly created object will inherit from the context of the objectType argument.<para/>
        /// A caller can pass the special marker value USE_CURRENT_HOST_CONTEXT to indicate that the object should receive the context which is current in the debugger's user interface.</param>
        /// <param name="objectLocation">The location of the object in the address space of the debug target. If the location is a virtual address, the location can be constructed by the client using a 64-bit offset into the address space; otherwise - the location must be retrieved from another debug host interface.</param>
        /// <param name="objectType">The type of the object being constructed. The context of the type will propagate to the newly created object if no explicit context is passed in the context argument.</param>
        /// <returns>The newly created object reference will be returned here.</returns>
        public ModelObject CreateTypedObjectReference(IDebugHostContext context, Location objectLocation, IDebugHostType objectType)
        {
            ModelObject objectResult;
            TryCreateTypedObjectReference(context, objectLocation, objectType, out objectResult).ThrowDbgEngNotOK();

            return objectResult;
        }

        /// <summary>
        /// The CreateTypedObjectReference method is semantically similar to the CreateTypedObject method excepting that it creates a reference to the underlying native/language construct.<para/>
        /// The created reference is an object which has a kind of ObjectTargetObjectReference. It is not a native reference as the underlying language might support (e.g.: a C++ &amp; or &amp;&amp;).<para/>
        /// It is entirely possible to have a ObjectTargetObjectReference to a C++ reference. An object of kind ObjectTargetObjectReference can be converted to the underlying value through use of the Dereference method on <see cref="IModelObject"/>.<para/>
        /// The reference can also be passed to the underlying host's expression evaluator in order to assign back to the value in a language appropriate way.
        /// </summary>
        /// <param name="context">The debug host context in which this object is located. If no explicit context is given, the context of the newly created object will inherit from the context of the objectType argument.<para/>
        /// A caller can pass the special marker value USE_CURRENT_HOST_CONTEXT to indicate that the object should receive the context which is current in the debugger's user interface.</param>
        /// <param name="objectLocation">The location of the object in the address space of the debug target. If the location is a virtual address, the location can be constructed by the client using a 64-bit offset into the address space; otherwise - the location must be retrieved from another debug host interface.</param>
        /// <param name="objectType">The type of the object being constructed. The context of the type will propagate to the newly created object if no explicit context is passed in the context argument.</param>
        /// <param name="objectResult">The newly created object reference will be returned here.</param>
        /// <returns>This method returns HRESULT that indicates success or failure.</returns>
        public HRESULT TryCreateTypedObjectReference(IDebugHostContext context, Location objectLocation, IDebugHostType objectType, out ModelObject objectResult)
        {
            /*HRESULT CreateTypedObjectReference(
            [In, MarshalAs(UnmanagedType.Interface)] IDebugHostContext context,
            [In] Location objectLocation,
            [In, MarshalAs(UnmanagedType.Interface)] IDebugHostType objectType,
            [Out, MarshalAs(UnmanagedType.Interface)] out IModelObject @object);*/
            IModelObject @object;
            HRESULT hr = Raw.CreateTypedObjectReference(context, objectLocation, objectType, out @object);

            if (hr == HRESULT.S_OK)
                objectResult = @object == null ? null : new ModelObject(@object);
            else
                objectResult = default(ModelObject);

            return hr;
        }

        #endregion
        #region CreateSyntheticObject

        /// <summary>
        /// The CreateSyntheticObject method creates an empty data model object -- a dictionary of key/value/metadata tuples and concepts.<para/>
        /// At the time of creation, there are no keys nor concepts on the object. It is a clean slate for the caller to utilize.
        /// </summary>
        /// <param name="context">The debug host context which will be associated with the newly created synthetic object. Not every object requires a context.<para/>
        /// If the object refers to things such as processes, threads, or memory in the address space of the host, it may need one (unless it encapsulates other objects which contain such).</param>
        /// <returns>The newly created object will be returned here.</returns>
        public ModelObject CreateSyntheticObject(IDebugHostContext context)
        {
            ModelObject objectResult;
            TryCreateSyntheticObject(context, out objectResult).ThrowDbgEngNotOK();

            return objectResult;
        }

        /// <summary>
        /// The CreateSyntheticObject method creates an empty data model object -- a dictionary of key/value/metadata tuples and concepts.<para/>
        /// At the time of creation, there are no keys nor concepts on the object. It is a clean slate for the caller to utilize.
        /// </summary>
        /// <param name="context">The debug host context which will be associated with the newly created synthetic object. Not every object requires a context.<para/>
        /// If the object refers to things such as processes, threads, or memory in the address space of the host, it may need one (unless it encapsulates other objects which contain such).</param>
        /// <param name="objectResult">The newly created object will be returned here.</param>
        /// <returns>This method returns HRESULT that indicates success or failure.</returns>
        public HRESULT TryCreateSyntheticObject(IDebugHostContext context, out ModelObject objectResult)
        {
            /*HRESULT CreateSyntheticObject(
            [In, MarshalAs(UnmanagedType.Interface)] IDebugHostContext context,
            [Out, MarshalAs(UnmanagedType.Interface)] out IModelObject @object);*/
            IModelObject @object;
            HRESULT hr = Raw.CreateSyntheticObject(context, out @object);

            if (hr == HRESULT.S_OK)
                objectResult = @object == null ? null : new ModelObject(@object);
            else
                objectResult = default(ModelObject);

            return hr;
        }

        #endregion
        #region CreateDataModelObject

        /// <summary>
        /// The CreateDataModelObject method is a simple helper wrapper to create objects which are data models -- that is objects which are going to be attached as parent models to other objects.<para/>
        /// All such objects must support the data model concept via <see cref="IDataModelConcept"/>. This method creates a new blank synthetic object with no explicit context and adds the inpassed <see cref="IDataModelConcept"/> as the newly created object's implementation of the data model concept.<para/>
        /// This can similarly be accomplished with calls to CreateSyntheticObject and SetConcept.
        /// </summary>
        /// <param name="dataModel">The implementation of <see cref="IDataModelConcept"/> which will be automatically added to the newly created object as its implementation of the data model concept.</param>
        /// <returns>The newly created synthetic object (with the data model concept set) will be returned here.</returns>
        public ModelObject CreateDataModelObject(IDataModelConcept dataModel)
        {
            ModelObject objectResult;
            TryCreateDataModelObject(dataModel, out objectResult).ThrowDbgEngNotOK();

            return objectResult;
        }

        /// <summary>
        /// The CreateDataModelObject method is a simple helper wrapper to create objects which are data models -- that is objects which are going to be attached as parent models to other objects.<para/>
        /// All such objects must support the data model concept via <see cref="IDataModelConcept"/>. This method creates a new blank synthetic object with no explicit context and adds the inpassed <see cref="IDataModelConcept"/> as the newly created object's implementation of the data model concept.<para/>
        /// This can similarly be accomplished with calls to CreateSyntheticObject and SetConcept.
        /// </summary>
        /// <param name="dataModel">The implementation of <see cref="IDataModelConcept"/> which will be automatically added to the newly created object as its implementation of the data model concept.</param>
        /// <param name="objectResult">The newly created synthetic object (with the data model concept set) will be returned here.</param>
        /// <returns>This method returns HRESULT.</returns>
        public HRESULT TryCreateDataModelObject(IDataModelConcept dataModel, out ModelObject objectResult)
        {
            /*HRESULT CreateDataModelObject(
            [In, MarshalAs(UnmanagedType.Interface)] IDataModelConcept dataModel,
            [Out, MarshalAs(UnmanagedType.Interface)] out IModelObject @object);*/
            IModelObject @object;
            HRESULT hr = Raw.CreateDataModelObject(dataModel, out @object);

            if (hr == HRESULT.S_OK)
                objectResult = @object == null ? null : new ModelObject(@object);
            else
                objectResult = default(ModelObject);

            return hr;
        }

        #endregion
        #region CreateIntrinsicObject

        /// <summary>
        /// The CreateIntrinsicObject method is the method which boxes intrinsic values into <see cref="IModelObject"/>. The caller places the value in a COM VARIANT and calls this method.<para/>
        /// The data model manager returns an <see cref="IModelObject"/> representing the object. Note that this method is also used to box fundamental IUnknown based types: property accessors, methods, contexts, etc...<para/>
        /// In such cases, the objectKind method indicates what kind of IUnknown based construct the object represents and the punkVal field of the passed variant is the IUnknown derived type.<para/>
        /// The type must be statically castable to the appropriate model interface (e.g.: <see cref="IModelPropertyAccessor"/>, <see cref="IModelMethod"/>, <see cref="IDebugHostContext"/>, etc...) in process.<para/>
        /// The VARIANT types that are supported by this method are VT_UI1, VT_I1, VT_UI2, VT_I2, VT_UI4, VT_I4, VT_UI8, VT_I8, VT_R4, VT_R8, VT_BOOL, VT_BSTR, and VT_UNKNOWN (for a specialized set of IUnknown derived types as indicated by the enumeration ModelObjectKind.
        /// </summary>
        /// <param name="objectKind">Indicates the kind of object which is being boxed. For normal intrinsics which differ by the variant type, ObjectIntrinsic is passed here.<para/>
        /// For others which are effectively IUnknown derived interfaces, the object type is one of the values in the ModelObjectKind enumeration and the interface in the VARIANT must match.</param>
        /// <param name="intrinsicData">A VARIANT containing the value which is going to be boxed inside an <see cref="IModelObject"/> container.</param>
        /// <returns>The newly boxed value (as an <see cref="IModelObject"/>) will be returned here.</returns>
        public ModelObject CreateIntrinsicObject(ModelObjectKind objectKind, IntPtr intrinsicData)
        {
            ModelObject objectResult;
            TryCreateIntrinsicObject(objectKind, intrinsicData, out objectResult).ThrowDbgEngNotOK();

            return objectResult;
        }

        /// <summary>
        /// The CreateIntrinsicObject method is the method which boxes intrinsic values into <see cref="IModelObject"/>. The caller places the value in a COM VARIANT and calls this method.<para/>
        /// The data model manager returns an <see cref="IModelObject"/> representing the object. Note that this method is also used to box fundamental IUnknown based types: property accessors, methods, contexts, etc...<para/>
        /// In such cases, the objectKind method indicates what kind of IUnknown based construct the object represents and the punkVal field of the passed variant is the IUnknown derived type.<para/>
        /// The type must be statically castable to the appropriate model interface (e.g.: <see cref="IModelPropertyAccessor"/>, <see cref="IModelMethod"/>, <see cref="IDebugHostContext"/>, etc...) in process.<para/>
        /// The VARIANT types that are supported by this method are VT_UI1, VT_I1, VT_UI2, VT_I2, VT_UI4, VT_I4, VT_UI8, VT_I8, VT_R4, VT_R8, VT_BOOL, VT_BSTR, and VT_UNKNOWN (for a specialized set of IUnknown derived types as indicated by the enumeration ModelObjectKind.
        /// </summary>
        /// <param name="objectKind">Indicates the kind of object which is being boxed. For normal intrinsics which differ by the variant type, ObjectIntrinsic is passed here.<para/>
        /// For others which are effectively IUnknown derived interfaces, the object type is one of the values in the ModelObjectKind enumeration and the interface in the VARIANT must match.</param>
        /// <param name="intrinsicData">A VARIANT containing the value which is going to be boxed inside an <see cref="IModelObject"/> container.</param>
        /// <param name="objectResult">The newly boxed value (as an <see cref="IModelObject"/>) will be returned here.</param>
        /// <returns>This method returns HRESULT that indicates success or failure.</returns>
        public HRESULT TryCreateIntrinsicObject(ModelObjectKind objectKind, IntPtr intrinsicData, out ModelObject objectResult)
        {
            /*HRESULT CreateIntrinsicObject(
            [In] ModelObjectKind objectKind,
            [In, MarshalAs(UnmanagedType.Struct)] object intrinsicData,
            [Out, MarshalAs(UnmanagedType.Interface)] out IModelObject @object);*/
            IModelObject @object;
            HRESULT hr = Raw.CreateIntrinsicObject(objectKind, intrinsicData, out @object);

            if (hr == HRESULT.S_OK)
                objectResult = @object == null ? null : new ModelObject(@object);
            else
                objectResult = default(ModelObject);

            return hr;
        }

        #endregion
        #region CreateTypedIntrinsicObject

        /// <summary>
        /// The CreateTypedintrinsicObject method is similar to the CreateIntrinsicObject method excepting that it allows a native/language type to be associated with the data and carried along with the boxed value.<para/>
        /// This allows the data model to represent constructs such as native enumeration types (which are simply VT_UI* or VT_I* values).<para/>
        /// Pointer types are also created with this method. A native pointer in the data model is a zero extended 64-bit quantity representing an offset into the virtual address space of the debug target.<para/>
        /// It is boxed inside a VT_UI8 and is created with this method and a type which indicates a native/language pointer.
        /// </summary>
        /// <param name="intrinsicData">A VARIANT containing the value which is going to be boxd inside an <see cref="IModelObject"/> container. Note that this method does not support VT_UNKNOWN constructs.<para/>
        /// Anything passed to this method must be expressable as ObjectIntrinsic.</param>
        /// <param name="type">The native/language type of the value.</param>
        /// <returns>The newly boxed value (as an <see cref="IModelObject"/>) will be returned here.</returns>
        public ModelObject CreateTypedIntrinsicObject(IntPtr intrinsicData, IDebugHostType type)
        {
            ModelObject objectResult;
            TryCreateTypedIntrinsicObject(intrinsicData, type, out objectResult).ThrowDbgEngNotOK();

            return objectResult;
        }

        /// <summary>
        /// The CreateTypedintrinsicObject method is similar to the CreateIntrinsicObject method excepting that it allows a native/language type to be associated with the data and carried along with the boxed value.<para/>
        /// This allows the data model to represent constructs such as native enumeration types (which are simply VT_UI* or VT_I* values).<para/>
        /// Pointer types are also created with this method. A native pointer in the data model is a zero extended 64-bit quantity representing an offset into the virtual address space of the debug target.<para/>
        /// It is boxed inside a VT_UI8 and is created with this method and a type which indicates a native/language pointer.
        /// </summary>
        /// <param name="intrinsicData">A VARIANT containing the value which is going to be boxd inside an <see cref="IModelObject"/> container. Note that this method does not support VT_UNKNOWN constructs.<para/>
        /// Anything passed to this method must be expressable as ObjectIntrinsic.</param>
        /// <param name="type">The native/language type of the value.</param>
        /// <param name="objectResult">The newly boxed value (as an <see cref="IModelObject"/>) will be returned here.</param>
        /// <returns>This method returns HRESULT that indicates success or failure.</returns>
        public HRESULT TryCreateTypedIntrinsicObject(IntPtr intrinsicData, IDebugHostType type, out ModelObject objectResult)
        {
            /*HRESULT CreateTypedIntrinsicObject(
            [In, MarshalAs(UnmanagedType.Struct)] object intrinsicData,
            [In, MarshalAs(UnmanagedType.Interface)] IDebugHostType type,
            [Out, MarshalAs(UnmanagedType.Interface)] out IModelObject @object);*/
            IModelObject @object;
            HRESULT hr = Raw.CreateTypedIntrinsicObject(intrinsicData, type, out @object);

            if (hr == HRESULT.S_OK)
                objectResult = @object == null ? null : new ModelObject(@object);
            else
                objectResult = default(ModelObject);

            return hr;
        }

        #endregion
        #region GetModelForTypeSignature

        /// <summary>
        /// The GetModelForTypeSignature method returns the data model that was registered against a particular type signature via a prior call to the RegisterModelForTypeSignature method.<para/>
        /// The data model returned from this method is considered the canonical visualizer for any type which matches the passed type signature.<para/>
        /// As a canonical visualizer, that data model takes over the display of the type. Display engines will, by default, hide native/language constructs of the object in favor of the view of the object presented by the data model.
        /// </summary>
        /// <param name="typeSignature">A type signature for which dataModel will be registered as the canonical visualizer. Any object created with a native/language type which matches the signature (and for which there is no better matching type signature) will automatically have the returned data model attached as a parent.</param>
        /// <returns>The data model which is registered as the canonical visualizer for all type instances which match the given type signature (and for which there is no better matching type signature.</returns>
        public ModelObject GetModelForTypeSignature(IDebugHostTypeSignature typeSignature)
        {
            ModelObject dataModelResult;
            TryGetModelForTypeSignature(typeSignature, out dataModelResult).ThrowDbgEngNotOK();

            return dataModelResult;
        }

        /// <summary>
        /// The GetModelForTypeSignature method returns the data model that was registered against a particular type signature via a prior call to the RegisterModelForTypeSignature method.<para/>
        /// The data model returned from this method is considered the canonical visualizer for any type which matches the passed type signature.<para/>
        /// As a canonical visualizer, that data model takes over the display of the type. Display engines will, by default, hide native/language constructs of the object in favor of the view of the object presented by the data model.
        /// </summary>
        /// <param name="typeSignature">A type signature for which dataModel will be registered as the canonical visualizer. Any object created with a native/language type which matches the signature (and for which there is no better matching type signature) will automatically have the returned data model attached as a parent.</param>
        /// <param name="dataModelResult">The data model which is registered as the canonical visualizer for all type instances which match the given type signature (and for which there is no better matching type signature.</param>
        /// <returns>This method returns HRESULT that indicates success or failure.</returns>
        public HRESULT TryGetModelForTypeSignature(IDebugHostTypeSignature typeSignature, out ModelObject dataModelResult)
        {
            /*HRESULT GetModelForTypeSignature(
            [In, MarshalAs(UnmanagedType.Interface)] IDebugHostTypeSignature typeSignature,
            [Out, MarshalAs(UnmanagedType.Interface)] out IModelObject dataModel);*/
            IModelObject dataModel;
            HRESULT hr = Raw.GetModelForTypeSignature(typeSignature, out dataModel);

            if (hr == HRESULT.S_OK)
                dataModelResult = dataModel == null ? null : new ModelObject(dataModel);
            else
                dataModelResult = default(ModelObject);

            return hr;
        }

        #endregion
        #region GetModelForType

        /// <summary>
        /// The GetModelForType method returns the data model which is the canonical visualizer for a given type instance. In effect, this method finds the best matching type signature which was registered with a prior call to the RegisterModelForTypeSignature method and returns the associated data model.
        /// </summary>
        /// <param name="type">The concrete type instance for which to find the best matching canonical visualizer registered via a prior call to the RegisterModelForTypeSignature method.</param>
        /// <returns>The values that were emitted from the COM method.</returns>
        public GetModelForTypeResult GetModelForType(IDebugHostType type)
        {
            GetModelForTypeResult result;
            TryGetModelForType(type, out result).ThrowDbgEngNotOK();

            return result;
        }

        /// <summary>
        /// The GetModelForType method returns the data model which is the canonical visualizer for a given type instance. In effect, this method finds the best matching type signature which was registered with a prior call to the RegisterModelForTypeSignature method and returns the associated data model.
        /// </summary>
        /// <param name="type">The concrete type instance for which to find the best matching canonical visualizer registered via a prior call to the RegisterModelForTypeSignature method.</param>
        /// <param name="result">The values that were emitted from the COM method.</param>
        /// <returns>This method returns HRESULT that indicates success or failure.</returns>
        public HRESULT TryGetModelForType(IDebugHostType type, out GetModelForTypeResult result)
        {
            /*HRESULT GetModelForType(
            [In, MarshalAs(UnmanagedType.Interface)] IDebugHostType type,
            [Out, MarshalAs(UnmanagedType.Interface)] out IModelObject dataModel,
            [Out, MarshalAs(UnmanagedType.Interface)] out IDebugHostTypeSignature typeSignature,
            [Out, MarshalAs(UnmanagedType.Interface)] out IDebugHostSymbolEnumerator wildcardMatches);*/
            IModelObject dataModel;
            IDebugHostTypeSignature typeSignature;
            IDebugHostSymbolEnumerator wildcardMatches;
            HRESULT hr = Raw.GetModelForType(type, out dataModel, out typeSignature, out wildcardMatches);

            if (hr == HRESULT.S_OK)
                result = new GetModelForTypeResult(dataModel == null ? null : new ModelObject(dataModel), typeSignature == null ? null : new DebugHostTypeSignature(typeSignature), DebugHostSymbolEnumerator.New(wildcardMatches));
            else
                result = default(GetModelForTypeResult);

            return hr;
        }

        #endregion
        #region RegisterModelForTypeSignature

        /// <summary>
        /// The RegisterModelForTypeSignature method is the primary method that a caller utilizes to register a canonical visualizer for a given type (or set of types).<para/>
        /// A canonical visualizer is a data model which, in effect, takes over the display of a given type (or set of types).<para/>
        /// Instead of the native/language view of the type being displayed in any debugger user interface, the view of the type as presented by the registered data model is displayed (along with a means of getting back to the native/language view for a user who desires it).The type signature which is passed to this method may match multiple concrete types.<para/>
        /// If there are multiple matches for a given type instance, only the best match will be returned. One type signature is considered a better match than another if it more specifically refers to a given concrete type.<para/>
        /// As examples: If the three type signatures above (A, B, and C) are registered and checked against a concrete type: Alltype signatures match this type instance.<para/>
        /// The second is a better match than the first because int (the first template argument of B) is a better match than a wildcard (the first template argument of A).<para/>
        /// Likewise, the third is a better match than the second (it is a total match with no wildcards). The RegisterModelForTypeSignature method will not allow duplicate type signatures to be registered.<para/>
        /// Only one data model can be registered as the canonical visualizer for a given type signature. An attempt to register the same type signature twice will fail.<para/>
        /// Likewise, the RegisterModelForTypeSignature method will not allow type signatures which can ambiguously match any type instance to be registered.<para/>
        /// As an example: The two type signatures above (D and E) cannot both be registered. For some types, it is clear which signature applies and is best.<para/>
        /// For instance, Only matches the first of these (D) since float and int do not match. However, it is completely ambiguous when considering the following: Either of these signatures is equally good (both have one concrete and one wildcard match).<para/>
        /// These type signatures are ambiguous. Hence, a call to register the second of them will fail for this reason.
        /// </summary>
        /// <param name="typeSignature">The type signature being registered. Any native/language object of a concrete type which best matches this type signature will have the data model given by the dataModel argument automatically attached.</param>
        /// <param name="dataModel">The data model which is to become the canonical visualizer for types matching the given type signature.</param>
        public void RegisterModelForTypeSignature(IDebugHostTypeSignature typeSignature, IModelObject dataModel)
        {
            TryRegisterModelForTypeSignature(typeSignature, dataModel).ThrowDbgEngNotOK();
        }

        /// <summary>
        /// The RegisterModelForTypeSignature method is the primary method that a caller utilizes to register a canonical visualizer for a given type (or set of types).<para/>
        /// A canonical visualizer is a data model which, in effect, takes over the display of a given type (or set of types).<para/>
        /// Instead of the native/language view of the type being displayed in any debugger user interface, the view of the type as presented by the registered data model is displayed (along with a means of getting back to the native/language view for a user who desires it).The type signature which is passed to this method may match multiple concrete types.<para/>
        /// If there are multiple matches for a given type instance, only the best match will be returned. One type signature is considered a better match than another if it more specifically refers to a given concrete type.<para/>
        /// As examples: If the three type signatures above (A, B, and C) are registered and checked against a concrete type: Alltype signatures match this type instance.<para/>
        /// The second is a better match than the first because int (the first template argument of B) is a better match than a wildcard (the first template argument of A).<para/>
        /// Likewise, the third is a better match than the second (it is a total match with no wildcards). The RegisterModelForTypeSignature method will not allow duplicate type signatures to be registered.<para/>
        /// Only one data model can be registered as the canonical visualizer for a given type signature. An attempt to register the same type signature twice will fail.<para/>
        /// Likewise, the RegisterModelForTypeSignature method will not allow type signatures which can ambiguously match any type instance to be registered.<para/>
        /// As an example: The two type signatures above (D and E) cannot both be registered. For some types, it is clear which signature applies and is best.<para/>
        /// For instance, Only matches the first of these (D) since float and int do not match. However, it is completely ambiguous when considering the following: Either of these signatures is equally good (both have one concrete and one wildcard match).<para/>
        /// These type signatures are ambiguous. Hence, a call to register the second of them will fail for this reason.
        /// </summary>
        /// <param name="typeSignature">The type signature being registered. Any native/language object of a concrete type which best matches this type signature will have the data model given by the dataModel argument automatically attached.</param>
        /// <param name="dataModel">The data model which is to become the canonical visualizer for types matching the given type signature.</param>
        /// <returns>This method returns HRESULT that indicates success or failure. This method will fail to register identical or ambiguous type signatures.</returns>
        public HRESULT TryRegisterModelForTypeSignature(IDebugHostTypeSignature typeSignature, IModelObject dataModel)
        {
            /*HRESULT RegisterModelForTypeSignature(
            [In, MarshalAs(UnmanagedType.Interface)] IDebugHostTypeSignature typeSignature,
            [In, MarshalAs(UnmanagedType.Interface)] IModelObject dataModel);*/
            return Raw.RegisterModelForTypeSignature(typeSignature, dataModel);
        }

        #endregion
        #region UnregisterModelForTypeSignature

        /// <summary>
        /// The UnregisterModelForTypeSignature method undoes a prior call to the RegisterModelForTypeSignature method. This method can either remove a given data model as the canonical visualizer for types matching a particular type signature or it can remove a given data model as the canonical visualizer for every type signature under which that data model is registered.
        /// </summary>
        /// <param name="dataModel">The data model to be unregistered as the canonical visualizer for one or more type signatures. If the typeSignature argument is nullptr, this data model will be unregistered from all type signatures it was registered against; otherwise, it will only be unregistered against the particular type signature indicated.</param>
        /// <param name="typeSignature">The type signature against which the data model given by the dataModel argument will be unregistered. This argument is optional and hence, nullptr can be passed.<para/>
        /// If nullptr is passed, the data model given by the dataModel argument will be unregistered from all type signatures it was registered against.</param>
        public void UnregisterModelForTypeSignature(IModelObject dataModel, IDebugHostTypeSignature typeSignature)
        {
            TryUnregisterModelForTypeSignature(dataModel, typeSignature).ThrowDbgEngNotOK();
        }

        /// <summary>
        /// The UnregisterModelForTypeSignature method undoes a prior call to the RegisterModelForTypeSignature method. This method can either remove a given data model as the canonical visualizer for types matching a particular type signature or it can remove a given data model as the canonical visualizer for every type signature under which that data model is registered.
        /// </summary>
        /// <param name="dataModel">The data model to be unregistered as the canonical visualizer for one or more type signatures. If the typeSignature argument is nullptr, this data model will be unregistered from all type signatures it was registered against; otherwise, it will only be unregistered against the particular type signature indicated.</param>
        /// <param name="typeSignature">The type signature against which the data model given by the dataModel argument will be unregistered. This argument is optional and hence, nullptr can be passed.<para/>
        /// If nullptr is passed, the data model given by the dataModel argument will be unregistered from all type signatures it was registered against.</param>
        /// <returns>This method returns HRESULT that indicates success or failure.</returns>
        public HRESULT TryUnregisterModelForTypeSignature(IModelObject dataModel, IDebugHostTypeSignature typeSignature)
        {
            /*HRESULT UnregisterModelForTypeSignature(
            [In, MarshalAs(UnmanagedType.Interface)] IModelObject dataModel,
            [In, MarshalAs(UnmanagedType.Interface)] IDebugHostTypeSignature typeSignature);*/
            return Raw.UnregisterModelForTypeSignature(dataModel, typeSignature);
        }

        #endregion
        #region RegisterExtensionForTypeSignature

        /// <summary>
        /// The RegisterExtensionForTypeSignature method is similar to the RegisterModelForTypeSignature method with one key difference.<para/>
        /// The data model which is passed to this method is not the canonical visualizer for any type and it will not take over the display of the native/language view of that type.<para/>
        /// The data model which is passed to this method will automatically be added as a parent to any concrete type which matches the supplied type signature.<para/>
        /// Unlike the RegisterModelForTypeSignature method, there is no limit on identical or ambiguous type signatures being registered as extensions to a given type (or set of types).<para/>
        /// Every extension whose type signature matches a given concrete type instance will cause the data model registered via this method to automatically be attached to newly created objects as parent models.<para/>
        /// This, in effect, allows an arbitrary number of clients to extend a type (or set of types) with new fields or functionality.
        /// </summary>
        /// <param name="typeSignature">The type signature against which the supplied data model will be registered as an extension. Every native/language object whose concrete type matches this signature will have the given data model attached as a parent model automatically.</param>
        /// <param name="dataModel">The data model which will automatically be added as a parent model to every native/language object with a concrete type which matches the supplied type signature.</param>
        public void RegisterExtensionForTypeSignature(IDebugHostTypeSignature typeSignature, IModelObject dataModel)
        {
            TryRegisterExtensionForTypeSignature(typeSignature, dataModel).ThrowDbgEngNotOK();
        }

        /// <summary>
        /// The RegisterExtensionForTypeSignature method is similar to the RegisterModelForTypeSignature method with one key difference.<para/>
        /// The data model which is passed to this method is not the canonical visualizer for any type and it will not take over the display of the native/language view of that type.<para/>
        /// The data model which is passed to this method will automatically be added as a parent to any concrete type which matches the supplied type signature.<para/>
        /// Unlike the RegisterModelForTypeSignature method, there is no limit on identical or ambiguous type signatures being registered as extensions to a given type (or set of types).<para/>
        /// Every extension whose type signature matches a given concrete type instance will cause the data model registered via this method to automatically be attached to newly created objects as parent models.<para/>
        /// This, in effect, allows an arbitrary number of clients to extend a type (or set of types) with new fields or functionality.
        /// </summary>
        /// <param name="typeSignature">The type signature against which the supplied data model will be registered as an extension. Every native/language object whose concrete type matches this signature will have the given data model attached as a parent model automatically.</param>
        /// <param name="dataModel">The data model which will automatically be added as a parent model to every native/language object with a concrete type which matches the supplied type signature.</param>
        /// <returns>This method returns HRESULT that indicates success or failure.</returns>
        public HRESULT TryRegisterExtensionForTypeSignature(IDebugHostTypeSignature typeSignature, IModelObject dataModel)
        {
            /*HRESULT RegisterExtensionForTypeSignature(
            [In, MarshalAs(UnmanagedType.Interface)] IDebugHostTypeSignature typeSignature,
            [In, MarshalAs(UnmanagedType.Interface)] IModelObject dataModel);*/
            return Raw.RegisterExtensionForTypeSignature(typeSignature, dataModel);
        }

        #endregion
        #region UnregisterExtensionForTypeSignature

        /// <summary>
        /// The UnregisterExtensionForTypeSignature method undoes a prior call to RegisterExtensionForTypeSignature. It unregisters a particular data model as an extension for either a particular type signature or as an extension for all type signatures against which the data model was registered.
        /// </summary>
        /// <param name="dataModel">The data model to unregister as an extension from one or more type signatures. If a specific type signature is passed in the typeSignature argument, this data model will be unregistered as an extension from that particular type signature.<para/>
        /// Newly created native/language objects with concrete types which match the signature will no longer have this data model automatically attached.<para/>
        /// If typeSignature is passed as nullptr, this data model will be unregistered from every type signature that it was registered against.</param>
        /// <param name="typeSignature">The type signature from which dataModel should be unregistered as an extension. If this argument is nullptr, the data model given by the dataModel argument will be unregistered as an extension from every type signature it was registered against.</param>
        public void UnregisterExtensionForTypeSignature(IModelObject dataModel, IDebugHostTypeSignature typeSignature)
        {
            TryUnregisterExtensionForTypeSignature(dataModel, typeSignature).ThrowDbgEngNotOK();
        }

        /// <summary>
        /// The UnregisterExtensionForTypeSignature method undoes a prior call to RegisterExtensionForTypeSignature. It unregisters a particular data model as an extension for either a particular type signature or as an extension for all type signatures against which the data model was registered.
        /// </summary>
        /// <param name="dataModel">The data model to unregister as an extension from one or more type signatures. If a specific type signature is passed in the typeSignature argument, this data model will be unregistered as an extension from that particular type signature.<para/>
        /// Newly created native/language objects with concrete types which match the signature will no longer have this data model automatically attached.<para/>
        /// If typeSignature is passed as nullptr, this data model will be unregistered from every type signature that it was registered against.</param>
        /// <param name="typeSignature">The type signature from which dataModel should be unregistered as an extension. If this argument is nullptr, the data model given by the dataModel argument will be unregistered as an extension from every type signature it was registered against.</param>
        /// <returns>This method returns HRESULT that indicates success or failure.</returns>
        public HRESULT TryUnregisterExtensionForTypeSignature(IModelObject dataModel, IDebugHostTypeSignature typeSignature)
        {
            /*HRESULT UnregisterExtensionForTypeSignature(
            [In, MarshalAs(UnmanagedType.Interface)] IModelObject dataModel,
            [In, MarshalAs(UnmanagedType.Interface)] IDebugHostTypeSignature typeSignature);*/
            return Raw.UnregisterExtensionForTypeSignature(dataModel, typeSignature);
        }

        #endregion
        #region CreateMetadataStore

        /// <summary>
        /// The CreateMetadataStore method creates a key store -- a simplified container of key/value/metadata tuples -- which is used to hold metadata that can be associated with properties and a variety of other values.<para/>
        /// A metadata store may have a single parent (which in turn can have a single parent). If a given metadata key is not located in a given store, its parents are checked.<para/>
        /// Most metadata stores do not have parents. It does, however, provide a way of sharing common metadata easily.
        /// </summary>
        /// <param name="parentStore">The parent store for the newly created metadata store. This may be null if there is no parent.</param>
        /// <returns>The newly created metadata store will be returned here.</returns>
        public KeyStore CreateMetadataStore(IKeyStore parentStore)
        {
            KeyStore metadataStoreResult;
            TryCreateMetadataStore(parentStore, out metadataStoreResult).ThrowDbgEngNotOK();

            return metadataStoreResult;
        }

        /// <summary>
        /// The CreateMetadataStore method creates a key store -- a simplified container of key/value/metadata tuples -- which is used to hold metadata that can be associated with properties and a variety of other values.<para/>
        /// A metadata store may have a single parent (which in turn can have a single parent). If a given metadata key is not located in a given store, its parents are checked.<para/>
        /// Most metadata stores do not have parents. It does, however, provide a way of sharing common metadata easily.
        /// </summary>
        /// <param name="parentStore">The parent store for the newly created metadata store. This may be null if there is no parent.</param>
        /// <param name="metadataStoreResult">The newly created metadata store will be returned here.</param>
        /// <returns>This method returns HRESULT that indicates success or failure.</returns>
        public HRESULT TryCreateMetadataStore(IKeyStore parentStore, out KeyStore metadataStoreResult)
        {
            /*HRESULT CreateMetadataStore(
            [In, MarshalAs(UnmanagedType.Interface)] IKeyStore parentStore,
            [Out, MarshalAs(UnmanagedType.Interface)] out IKeyStore metadataStore);*/
            IKeyStore metadataStore;
            HRESULT hr = Raw.CreateMetadataStore(parentStore, out metadataStore);

            if (hr == HRESULT.S_OK)
                metadataStoreResult = metadataStore == null ? null : new KeyStore(metadataStore);
            else
                metadataStoreResult = default(KeyStore);

            return hr;
        }

        #endregion
        #region RegisterNamedModel

        /// <summary>
        /// The RegisterNamedModel method registers a given data model under a well known name so that it can be found by clients wishing to extend it.<para/>
        /// This is the primary purpose of the API -- to publish a data model as something which can be extended by retrieving the model registered under this well known name and adding a parent model to it.While the string passed in the modelName argument can be anything (it is just a name), there is a convention that it look like a dot separated namespace of the following form: An example of such a name is Debugger.Models.Process.<para/>
        /// This is the name under which the debugger's notion of a process is registered. A client which extends process and itself is extensible might register its extensibility point as Debugger.Models.Process.NamedExtensionPoint where NamedExtensionPoint refers to the semantics being added to process.<para/>
        /// Note that if a given data model is registered under a name, the implementation of <see cref="IDataModelConcept"/> for that data model must have a GetName method which returns the name registered via calling this RegisterNamedModel method.
        /// </summary>
        /// <param name="modelName">The root namespace of the data model is returned here.</param>
        /// <param name="modeObject">The data model being registered.</param>
        public void RegisterNamedModel(string modelName, IModelObject modeObject)
        {
            TryRegisterNamedModel(modelName, modeObject).ThrowDbgEngNotOK();
        }

        /// <summary>
        /// The RegisterNamedModel method registers a given data model under a well known name so that it can be found by clients wishing to extend it.<para/>
        /// This is the primary purpose of the API -- to publish a data model as something which can be extended by retrieving the model registered under this well known name and adding a parent model to it.While the string passed in the modelName argument can be anything (it is just a name), there is a convention that it look like a dot separated namespace of the following form: An example of such a name is Debugger.Models.Process.<para/>
        /// This is the name under which the debugger's notion of a process is registered. A client which extends process and itself is extensible might register its extensibility point as Debugger.Models.Process.NamedExtensionPoint where NamedExtensionPoint refers to the semantics being added to process.<para/>
        /// Note that if a given data model is registered under a name, the implementation of <see cref="IDataModelConcept"/> for that data model must have a GetName method which returns the name registered via calling this RegisterNamedModel method.
        /// </summary>
        /// <param name="modelName">The root namespace of the data model is returned here.</param>
        /// <param name="modeObject">The data model being registered.</param>
        /// <returns>This method returns HRESULT that indicates success or failure.</returns>
        public HRESULT TryRegisterNamedModel(string modelName, IModelObject modeObject)
        {
            /*HRESULT RegisterNamedModel(
            [In, MarshalAs(UnmanagedType.LPWStr)] string modelName,
            [In, MarshalAs(UnmanagedType.Interface)] IModelObject modeObject);*/
            return Raw.RegisterNamedModel(modelName, modeObject);
        }

        #endregion
        #region UnregisterNamedModel

        /// <summary>
        /// The UnregisterNamedModel method undoes a prior call to RegisterNamedModel. It removes the association between a data model and a name under which it can be looked up.
        /// </summary>
        /// <param name="modelName">The name which will be unregistered. Any data model registered under this name will no longer be registered.</param>
        public void UnregisterNamedModel(string modelName)
        {
            TryUnregisterNamedModel(modelName).ThrowDbgEngNotOK();
        }

        /// <summary>
        /// The UnregisterNamedModel method undoes a prior call to RegisterNamedModel. It removes the association between a data model and a name under which it can be looked up.
        /// </summary>
        /// <param name="modelName">The name which will be unregistered. Any data model registered under this name will no longer be registered.</param>
        /// <returns>This method returns HRESULT that indicates success or failure.</returns>
        public HRESULT TryUnregisterNamedModel(string modelName)
        {
            /*HRESULT UnregisterNamedModel(
            [In, MarshalAs(UnmanagedType.LPWStr)] string modelName);*/
            return Raw.UnregisterNamedModel(modelName);
        }

        #endregion
        #region AcquireNamedModel

        /// <summary>
        /// This looks up a well known model name and returns the data model registered by that name. Note that if there is no model registeredby the supplied name, a stub will be created and returned to the caller.<para/>
        /// Anything added to the stub will be added to the real object at the time a registration is made.
        /// </summary>
        /// <param name="modelName">The name for which to look up a registered data model.</param>
        /// <returns>The data model which was registered under the name given by the modelName argument will be returned here. If no such data model is registered, a stub object will be created, temporarily registered under the name given by the modelName argument and returned here.<para/>
        /// If such occurred, when the real object is registered via a call to the RegisterNamedModel method, the changes which were made to the stub object are, in effect, moved to the real data model.</returns>
        /// <remarks>
        /// A caller who wishes to extend a data model which is registered under a given name calls the AcquireNamedModel method
        /// in order to retrieve the object for the data model they wish to extend. This method will return whatever data model
        /// was registered via a prior call to the RegisterNamedModel method. As the primary purpose of the AcquireNamedModel
        /// method is to extend the model, this method has a special behavior if no model has been registered under the given
        /// name yet. If no model has been registered under the given name yet, a stub object is created, temporarily registered
        /// under the given name, and returned to the caller. When the real data model is registered via a call to the RegisterNamedModel
        /// method, any changes which were made to the stub object are, in effect, made to the real model. This removes many
        /// load order dependency issues from components which extend each other. Sample Code
        /// </remarks>
        public ModelObject AcquireNamedModel(string modelName)
        {
            ModelObject modelObjectResult;
            TryAcquireNamedModel(modelName, out modelObjectResult).ThrowDbgEngNotOK();

            return modelObjectResult;
        }

        /// <summary>
        /// This looks up a well known model name and returns the data model registered by that name. Note that if there is no model registeredby the supplied name, a stub will be created and returned to the caller.<para/>
        /// Anything added to the stub will be added to the real object at the time a registration is made.
        /// </summary>
        /// <param name="modelName">The name for which to look up a registered data model.</param>
        /// <param name="modelObjectResult">The data model which was registered under the name given by the modelName argument will be returned here. If no such data model is registered, a stub object will be created, temporarily registered under the name given by the modelName argument and returned here.<para/>
        /// If such occurred, when the real object is registered via a call to the RegisterNamedModel method, the changes which were made to the stub object are, in effect, moved to the real data model.</param>
        /// <returns>This method returns HRESULT.</returns>
        /// <remarks>
        /// A caller who wishes to extend a data model which is registered under a given name calls the AcquireNamedModel method
        /// in order to retrieve the object for the data model they wish to extend. This method will return whatever data model
        /// was registered via a prior call to the RegisterNamedModel method. As the primary purpose of the AcquireNamedModel
        /// method is to extend the model, this method has a special behavior if no model has been registered under the given
        /// name yet. If no model has been registered under the given name yet, a stub object is created, temporarily registered
        /// under the given name, and returned to the caller. When the real data model is registered via a call to the RegisterNamedModel
        /// method, any changes which were made to the stub object are, in effect, made to the real model. This removes many
        /// load order dependency issues from components which extend each other. Sample Code
        /// </remarks>
        public HRESULT TryAcquireNamedModel(string modelName, out ModelObject modelObjectResult)
        {
            /*HRESULT AcquireNamedModel(
            [In, MarshalAs(UnmanagedType.LPWStr)] string modelName,
            [Out, MarshalAs(UnmanagedType.Interface)] out IModelObject modelObject);*/
            IModelObject modelObject;
            HRESULT hr = Raw.AcquireNamedModel(modelName, out modelObject);

            if (hr == HRESULT.S_OK)
                modelObjectResult = modelObject == null ? null : new ModelObject(modelObject);
            else
                modelObjectResult = default(ModelObject);

            return hr;
        }

        #endregion
        #endregion
        #region IDataModelManager2

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public IDataModelManager2 Raw2 => (IDataModelManager2) Raw;

        #region AcquireSubNamespace

        /// <summary>
        /// The AcquireSubNamespace method helps in the construction of something which might more traditionally look like a language namespace than a new object in a dynamic language.<para/>
        /// If, for instance, a caller wishes to categorize properties on a process object to make the process object more organized and the properties easier to discover, one method of doing this would be to create a sub-object for each category on the process object and placing those properties inside that object.<para/>
        /// The problem with this notion is that the sub-object has its own context and the properties there are passed the sub-object as an instance pointer instead of the process object itself.<para/>
        /// The AcquireSubNamespace method helps to create a shared ownership "sub-object" where the instance pointer passed to properties of the sub-object is the parent object.<para/>
        /// As an example, consider a process object to which we want to add a Heaps property representing the process heap (and all other custom heaps within the process).<para/>
        /// It might initially appear as follows: Since the process object may have many other fields and there may be many things associated with Memory in the process, a better paradigm might be: If the Memory object above is simply a normal property which returns a new object, when a caller asks for someProcess.Memory.Heaps, the property accessor for the Heaps property will be passed a context object (this pointer) of the newly created Memory object with no easy way to get back to other attributes of the process.<para/>
        /// If the Memory object is instead created with the AcquireSubNamespace method, the paradigm looks as above excepting that the property accessor for anything on the Memory object will instead be the process object itself.<para/>
        /// This allows the Heaps property implementation to easily get back to other attributes of the process. This style of object is a sub-namespace instead of a sub-object.<para/>
        /// It is important to note that there is nothing which the AcquireSubNamespace method does which cannot be accomplished with other methods.<para/>
        /// In effect, this is a helper method which does the following: Once a sub-namespace is created, its ownership is considered shared amongst all potential callers of the AcquireSubNamespace method with the same set of arguments.<para/>
        /// As a shared ownership semantic, it is improper to unregister a sub-namespace arbitrarily.
        /// </summary>
        /// <param name="modelName">The name of the data model which is being extended with a sub-namespace.</param>
        /// <param name="subNamespaceModelName">The name of the data model which represents the sub-namespace itself. The newly created sub-namespace is a data model which will be registered under this name.</param>
        /// <param name="accessName">A property of this name will be added to the data model registered under the name given by the modelName argument in order to access the sub-namespace.</param>
        /// <param name="metadata">Optional metadata to be associated with the key given by accessName in the event that this call is the one which creates the shared sub-namespace.</param>
        /// <returns>The data model representing the sub-namespace will be returned here. This data model may have been created by a prior call to the AcquireSubNamespace method or by the current call.<para/>
        /// The ownership is considered shared amongst all callers.</returns>
        public ModelObject AcquireSubNamespace(string modelName, string subNamespaceModelName, string accessName, IKeyStore metadata)
        {
            ModelObject namespaceModelObjectResult;
            TryAcquireSubNamespace(modelName, subNamespaceModelName, accessName, metadata, out namespaceModelObjectResult).ThrowDbgEngNotOK();

            return namespaceModelObjectResult;
        }

        /// <summary>
        /// The AcquireSubNamespace method helps in the construction of something which might more traditionally look like a language namespace than a new object in a dynamic language.<para/>
        /// If, for instance, a caller wishes to categorize properties on a process object to make the process object more organized and the properties easier to discover, one method of doing this would be to create a sub-object for each category on the process object and placing those properties inside that object.<para/>
        /// The problem with this notion is that the sub-object has its own context and the properties there are passed the sub-object as an instance pointer instead of the process object itself.<para/>
        /// The AcquireSubNamespace method helps to create a shared ownership "sub-object" where the instance pointer passed to properties of the sub-object is the parent object.<para/>
        /// As an example, consider a process object to which we want to add a Heaps property representing the process heap (and all other custom heaps within the process).<para/>
        /// It might initially appear as follows: Since the process object may have many other fields and there may be many things associated with Memory in the process, a better paradigm might be: If the Memory object above is simply a normal property which returns a new object, when a caller asks for someProcess.Memory.Heaps, the property accessor for the Heaps property will be passed a context object (this pointer) of the newly created Memory object with no easy way to get back to other attributes of the process.<para/>
        /// If the Memory object is instead created with the AcquireSubNamespace method, the paradigm looks as above excepting that the property accessor for anything on the Memory object will instead be the process object itself.<para/>
        /// This allows the Heaps property implementation to easily get back to other attributes of the process. This style of object is a sub-namespace instead of a sub-object.<para/>
        /// It is important to note that there is nothing which the AcquireSubNamespace method does which cannot be accomplished with other methods.<para/>
        /// In effect, this is a helper method which does the following: Once a sub-namespace is created, its ownership is considered shared amongst all potential callers of the AcquireSubNamespace method with the same set of arguments.<para/>
        /// As a shared ownership semantic, it is improper to unregister a sub-namespace arbitrarily.
        /// </summary>
        /// <param name="modelName">The name of the data model which is being extended with a sub-namespace.</param>
        /// <param name="subNamespaceModelName">The name of the data model which represents the sub-namespace itself. The newly created sub-namespace is a data model which will be registered under this name.</param>
        /// <param name="accessName">A property of this name will be added to the data model registered under the name given by the modelName argument in order to access the sub-namespace.</param>
        /// <param name="metadata">Optional metadata to be associated with the key given by accessName in the event that this call is the one which creates the shared sub-namespace.</param>
        /// <param name="namespaceModelObjectResult">The data model representing the sub-namespace will be returned here. This data model may have been created by a prior call to the AcquireSubNamespace method or by the current call.<para/>
        /// The ownership is considered shared amongst all callers.</param>
        /// <returns>This method returns HRESULT.</returns>
        public HRESULT TryAcquireSubNamespace(string modelName, string subNamespaceModelName, string accessName, IKeyStore metadata, out ModelObject namespaceModelObjectResult)
        {
            /*HRESULT AcquireSubNamespace(
            [In, MarshalAs(UnmanagedType.LPWStr)] string modelName,
            [In, MarshalAs(UnmanagedType.LPWStr)] string subNamespaceModelName,
            [In, MarshalAs(UnmanagedType.LPWStr)] string accessName,
            [In, MarshalAs(UnmanagedType.Interface)] IKeyStore metadata,
            [Out, MarshalAs(UnmanagedType.Interface)] out IModelObject namespaceModelObject);*/
            IModelObject namespaceModelObject;
            HRESULT hr = Raw2.AcquireSubNamespace(modelName, subNamespaceModelName, accessName, metadata, out namespaceModelObject);

            if (hr == HRESULT.S_OK)
                namespaceModelObjectResult = namespaceModelObject == null ? null : new ModelObject(namespaceModelObject);
            else
                namespaceModelObjectResult = default(ModelObject);

            return hr;
        }

        #endregion
        #region CreateTypedIntrinsicObjectEx

        /// <summary>
        /// The CreateTypedIntrinsicObjectEx method is semantically similar to the CreateTypedIntrinsicObject method. The only difference between the two is that this method allows the caller to specify the context in which the intrinsic data is valid.<para/>
        /// If no context is passed, the data is considered valid in whatever context is inherited from the type argument (how CreateTypedIntrinsicObject behaves).<para/>
        /// This allows for the creation of typed pointer values in the debug target which require more specific context than can be inherited from the type.
        /// </summary>
        /// <param name="context">The context which should be associated with the newly created object. If this is not specified, the context of the object will inherit from the context of the type argument.<para/>
        /// The special value USE_CURRENT_HOST_CONTEXT can also be passed indicating that the context should be the current UI context of the debugger.</param>
        /// <param name="intrinsicData">A VARIANT containing the value which is going to be boxd inside an <see cref="IModelObject"/> container. Note that this method does not support VT_UNKNOWN constructs.<para/>
        /// Anything passed to this method must be expressable as ObjectIntrinsic</param>
        /// <param name="type">The native/language type of the value.</param>
        /// <returns>The newly boxed value (as an <see cref="IModelObject"/>) will be returned here.</returns>
        public ModelObject CreateTypedIntrinsicObjectEx(IDebugHostContext context, IntPtr intrinsicData, IDebugHostType type)
        {
            ModelObject objectResult;
            TryCreateTypedIntrinsicObjectEx(context, intrinsicData, type, out objectResult).ThrowDbgEngNotOK();

            return objectResult;
        }

        /// <summary>
        /// The CreateTypedIntrinsicObjectEx method is semantically similar to the CreateTypedIntrinsicObject method. The only difference between the two is that this method allows the caller to specify the context in which the intrinsic data is valid.<para/>
        /// If no context is passed, the data is considered valid in whatever context is inherited from the type argument (how CreateTypedIntrinsicObject behaves).<para/>
        /// This allows for the creation of typed pointer values in the debug target which require more specific context than can be inherited from the type.
        /// </summary>
        /// <param name="context">The context which should be associated with the newly created object. If this is not specified, the context of the object will inherit from the context of the type argument.<para/>
        /// The special value USE_CURRENT_HOST_CONTEXT can also be passed indicating that the context should be the current UI context of the debugger.</param>
        /// <param name="intrinsicData">A VARIANT containing the value which is going to be boxd inside an <see cref="IModelObject"/> container. Note that this method does not support VT_UNKNOWN constructs.<para/>
        /// Anything passed to this method must be expressable as ObjectIntrinsic</param>
        /// <param name="type">The native/language type of the value.</param>
        /// <param name="objectResult">The newly boxed value (as an <see cref="IModelObject"/>) will be returned here.</param>
        /// <returns>This method returns HRESULT which indicates success or failure.</returns>
        public HRESULT TryCreateTypedIntrinsicObjectEx(IDebugHostContext context, IntPtr intrinsicData, IDebugHostType type, out ModelObject objectResult)
        {
            /*HRESULT CreateTypedIntrinsicObjectEx(
            [In, MarshalAs(UnmanagedType.Interface)] IDebugHostContext context,
            [In, MarshalAs(UnmanagedType.Struct)] object intrinsicData,
            [In, MarshalAs(UnmanagedType.Interface)] IDebugHostType type,
            [Out, MarshalAs(UnmanagedType.Interface)] out IModelObject @object);*/
            IModelObject @object;
            HRESULT hr = Raw2.CreateTypedIntrinsicObjectEx(context, intrinsicData, type, out @object);

            if (hr == HRESULT.S_OK)
                objectResult = @object == null ? null : new ModelObject(@object);
            else
                objectResult = default(ModelObject);

            return hr;
        }

        #endregion
        #endregion
        #region IDataModelManager3

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public IDataModelManager3 Raw3 => (IDataModelManager3) Raw;

        #region AcquireFilteredSubNamespace

        public AcquireFilteredSubNamespaceResult AcquireFilteredSubNamespace(string modelName, string subNamespaceModelName, string accessName, IKeyStore metadata, IModelMethod filter)
        {
            AcquireFilteredSubNamespaceResult result;
            TryAcquireFilteredSubNamespace(modelName, subNamespaceModelName, accessName, metadata, filter, out result).ThrowDbgEngNotOK();

            return result;
        }

        public HRESULT TryAcquireFilteredSubNamespace(string modelName, string subNamespaceModelName, string accessName, IKeyStore metadata, IModelMethod filter, out AcquireFilteredSubNamespaceResult result)
        {
            /*HRESULT AcquireFilteredSubNamespace(
            [In, MarshalAs(UnmanagedType.LPWStr)] string modelName,
            [In, MarshalAs(UnmanagedType.LPWStr)] string subNamespaceModelName,
            [In, MarshalAs(UnmanagedType.LPWStr)] string accessName,
            [In, MarshalAs(UnmanagedType.Interface)] IKeyStore metadata,
            [In, MarshalAs(UnmanagedType.Interface)] IModelMethod filter,
            [Out, MarshalAs(UnmanagedType.Interface)] out IModelObject namespaceModelObject,
            [Out, MarshalAs(UnmanagedType.Interface)] out IFilteredNamespacePropertyToken token);*/
            IModelObject namespaceModelObject;
            IFilteredNamespacePropertyToken token;
            HRESULT hr = Raw3.AcquireFilteredSubNamespace(modelName, subNamespaceModelName, accessName, metadata, filter, out namespaceModelObject, out token);

            if (hr == HRESULT.S_OK)
                result = new AcquireFilteredSubNamespaceResult(namespaceModelObject == null ? null : new ModelObject(namespaceModelObject), token == null ? null : new FilteredNamespacePropertyToken(token));
            else
                result = default(AcquireFilteredSubNamespaceResult);

            return hr;
        }

        #endregion
        #region EnumerateNamedModels

        public NamedModelsEnumerator EnumerateNamedModels()
        {
            NamedModelsEnumerator ppEnumeratorResult;
            TryEnumerateNamedModels(out ppEnumeratorResult).ThrowDbgEngNotOK();

            return ppEnumeratorResult;
        }

        public HRESULT TryEnumerateNamedModels(out NamedModelsEnumerator ppEnumeratorResult)
        {
            /*HRESULT EnumerateNamedModels(
            [Out, MarshalAs(UnmanagedType.Interface)] out INamedModelsEnumerator ppEnumerator);*/
            INamedModelsEnumerator ppEnumerator;
            HRESULT hr = Raw3.EnumerateNamedModels(out ppEnumerator);

            if (hr == HRESULT.S_OK)
                ppEnumeratorResult = ppEnumerator == null ? null : new NamedModelsEnumerator(ppEnumerator);
            else
                ppEnumeratorResult = default(NamedModelsEnumerator);

            return hr;
        }

        #endregion
        #endregion
        #region IDataModelManager4

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public IDataModelManager4 Raw4 => (IDataModelManager4) Raw;

        #region CreateSyntheticObjectFromKeyStore

        public ModelObject CreateSyntheticObjectFromKeyStore(IDebugHostContext context, IKeyStore parentStore)
        {
            ModelObject objectResult;
            TryCreateSyntheticObjectFromKeyStore(context, parentStore, out objectResult).ThrowDbgEngNotOK();

            return objectResult;
        }

        public HRESULT TryCreateSyntheticObjectFromKeyStore(IDebugHostContext context, IKeyStore parentStore, out ModelObject objectResult)
        {
            /*HRESULT CreateSyntheticObjectFromKeyStore(
            [In, MarshalAs(UnmanagedType.Interface)] IDebugHostContext context,
            [In, MarshalAs(UnmanagedType.Interface)] IKeyStore parentStore,
            [Out, MarshalAs(UnmanagedType.Interface)] out IModelObject @object);*/
            IModelObject @object;
            HRESULT hr = Raw4.CreateSyntheticObjectFromKeyStore(context, parentStore, out @object);

            if (hr == HRESULT.S_OK)
                objectResult = @object == null ? null : new ModelObject(@object);
            else
                objectResult = default(ModelObject);

            return hr;
        }

        #endregion
        #endregion
    }
}
