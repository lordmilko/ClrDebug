using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    /// <summary>
    /// Any object which represents a data model which is registered under a name or is registered for a particular type signature must implement this concept and add it to the data model object via <see cref="IModelObject"/>::SetConcept.<para/>
    /// Clients which create data models implement this interface. It is most frequently consumed by the data model manager itself.
    /// </summary>
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("FCB98D1D-1114-4FBF-B24C-EFFCB5DEF0D3")]
    [ComImport]
    public interface IDataModelConcept
    {
        /// <summary>
        /// A data model can be registered as the canonical visualizer or as an extension for a given native type through the data model manager's RegisterModelForTypeSignature or RegisterExtensionForTypeSignature methods.<para/>
        /// When a model is registered via either of these methods, the data model is automatically attached as a parent model to any native object whose type matches the signature passed in the registration.<para/>
        /// At the point where that attachment is automatically made, the InitializeObject method is called on the data model.<para/>
        /// It is passed the instance object, the type signature which caused the attachment, and an enumerator which produces the type instances (in linear order) which matched any wildcards in the type signature.<para/>
        /// The data model implementation may use this method call to initialize any caches it requires.
        /// </summary>
        /// <param name="modelObject">The instance object which is being initialized.</param>
        /// <param name="matchingTypeSignature">The type signature against which the native type of modelObject matched that caused the attachment of the data model.</param>
        /// <param name="wildcardMatches">If the matching type signature includes wildcards, this argument will contain an enumerator which will enumerate how each wildcard matched.<para/>
        /// Typically, each <see cref="IDebugHostSymbol"/> enumerated here is an <see cref="IDebugHostType"/>. That is, not, however a requirement.<para/>
        /// Non-type template arguments (amongst other things) can match wildcards and may produce symbols such as <see cref="IDebugHostConstant"/>.</param>
        /// <returns>This method returns HRESULT that indicates success or failure. Failing this method will prevent object construction of the instance.</returns>
        /// <remarks>
        /// Note that a given data model implementation cannot assume that the InitializeObject call will be made for every
        /// object to which the data model is attached. As the data model is a completely dynamic system, it is entirely possible
        /// for a caller to directly acquire a model (via, for example, the GetParentModel method on <see cref="IModelObject"/>)
        /// and attach it manually. In such a circumstance, the InitializeObject call will not have been made and the implementation
        /// must be prepared to do such. The calling of this method is an optimization to allow expensive implementations to
        /// prefill and preinitialize requisite caches. Implementation Example Note that a client will never call this interface.
        /// </remarks>
        [PreserveSig]
        HRESULT InitializeObject(
            [In, MarshalAs(UnmanagedType.Interface)] IModelObject modelObject,
            [In, MarshalAs(UnmanagedType.Interface)] IDebugHostTypeSignature matchingTypeSignature,
            [In, MarshalAs(UnmanagedType.Interface)] IDebugHostSymbolEnumerator wildcardMatches);

        /// <summary>
        /// If a given data model is registered under a default name via the RegisterNamedModel method, the registered data model's <see cref="IDataModelConcept"/> interface must return that name from this method.<para/>
        /// Note that it is perfectly legitimate for a model to be registered under multiple names (the default or best one should be returned here).<para/>
        /// A model may be completely unnamed (so long as it is not registered under a name). In such circumstances, the GetName method should return E_NOTIMPL.
        /// </summary>
        /// <param name="modelName">The model name should be returned in this argument as a string allocated via the SysAllocString method.</param>
        /// <returns>This method returns HRESULT which indicates success or failure. A model which is unnamed should return E_NOTIMPL.</returns>
        [PreserveSig]
        HRESULT GetName(
            [Out, MarshalAs(UnmanagedType.BStr)] out string modelName);
    }
}
