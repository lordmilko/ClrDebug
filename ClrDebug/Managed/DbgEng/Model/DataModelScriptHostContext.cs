namespace ClrDebug.DbgEng
{
    /// <summary>
    /// Implemented by the underlying host debugger, represents information about where the debug host is bridging the script.
    /// </summary>
    public class DataModelScriptHostContext : ComObject<IDataModelScriptHostContext>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DataModelScriptHostContext"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
        public DataModelScriptHostContext(IDataModelScriptHostContext raw) : base(raw)
        {
        }

        #region IDataModelScriptHostContext
        #region NamespaceObject

        /// <summary>
        /// The GetNamespaceObject method returns an object into which the script provider can place any bridges between the data model and the script.<para/>
        /// It is here, for instance, that the script provider might place data model method objects (<see cref="IModelMethod"/> interfaces boxed into <see cref="IModelObject"/>) whose implementation calls into correspondingly named functions in the script.
        /// </summary>
        public ModelObject NamespaceObject
        {
            get
            {
                ModelObject namespaceObjectResult;
                TryGetNamespaceObject(out namespaceObjectResult).ThrowDbgEngNotOK();

                return namespaceObjectResult;
            }
        }

        /// <summary>
        /// The GetNamespaceObject method returns an object into which the script provider can place any bridges between the data model and the script.<para/>
        /// It is here, for instance, that the script provider might place data model method objects (<see cref="IModelMethod"/> interfaces boxed into <see cref="IModelObject"/>) whose implementation calls into correspondingly named functions in the script.
        /// </summary>
        /// <param name="namespaceObjectResult">A data model object which can be used as the representation of the namespace of the script.</param>
        /// <returns>This method returns HRESULT which indicates success or failure.</returns>
        public HRESULT TryGetNamespaceObject(out ModelObject namespaceObjectResult)
        {
            /*HRESULT GetNamespaceObject(
            [Out, MarshalAs(UnmanagedType.Interface)] out IModelObject namespaceObject);*/
            IModelObject namespaceObject;
            HRESULT hr = Raw.GetNamespaceObject(out namespaceObject);

            if (hr == HRESULT.S_OK)
                namespaceObjectResult = namespaceObject == null ? null : new ModelObject(namespaceObject);
            else
                namespaceObjectResult = default(ModelObject);

            return hr;
        }

        #endregion
        #region NotifyScriptChange

        /// <summary>
        /// It is required that a script provider notify the debug host upon certain operations occurring with a method call to the NotifyScriptChange method on the associated context.<para/>
        /// Such operations are defined as members of the ScriptChangeKind enumeration which is defined as follows:
        /// </summary>
        /// <param name="script">The script for which the notification is occurring.</param>
        /// <param name="changeKind">The nature of the notification.</param>
        public void NotifyScriptChange(IDataModelScript script, ScriptChangeKind changeKind)
        {
            TryNotifyScriptChange(script, changeKind).ThrowDbgEngNotOK();
        }

        /// <summary>
        /// It is required that a script provider notify the debug host upon certain operations occurring with a method call to the NotifyScriptChange method on the associated context.<para/>
        /// Such operations are defined as members of the ScriptChangeKind enumeration which is defined as follows:
        /// </summary>
        /// <param name="script">The script for which the notification is occurring.</param>
        /// <param name="changeKind">The nature of the notification.</param>
        /// <returns>This method returns HRESULT which indicates success or failure.</returns>
        public HRESULT TryNotifyScriptChange(IDataModelScript script, ScriptChangeKind changeKind)
        {
            /*HRESULT NotifyScriptChange(
            [In, MarshalAs(UnmanagedType.Interface)] IDataModelScript script,
            [In] ScriptChangeKind changeKind);*/
            return Raw.NotifyScriptChange(script, changeKind);
        }

        #endregion
        #endregion
    }
}
