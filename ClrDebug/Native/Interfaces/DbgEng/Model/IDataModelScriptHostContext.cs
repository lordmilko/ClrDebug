using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    /// <summary>
    /// Implemented by the underlying host debugger, represents information about where the debug host is bridging the script.
    /// </summary>
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("014D366A-1F23-4981-9219-B2DB8B402054")]
    [ComImport]
    public interface IDataModelScriptHostContext
    {
        /// <summary>
        /// It is required that a script provider notify the debug host upon certain operations occurring with a method call to the NotifyScriptChange method on the associated context.<para/>
        /// Such operations are defined as members of the ScriptChangeKind enumeration which is defined as follows:
        /// </summary>
        /// <param name="script">The script for which the notification is occurring.</param>
        /// <param name="changeKind">The nature of the notification.</param>
        /// <returns>This method returns HRESULT which indicates success or failure.</returns>
        [PreserveSig]
        HRESULT NotifyScriptChange(
            [In, MarshalAs(UnmanagedType.Interface)] IDataModelScript script,
            [In] ScriptChangeKind changeKind);

        /// <summary>
        /// The GetNamespaceObject method returns an object into which the script provider can place any bridges between the data model and the script.<para/>
        /// It is here, for instance, that the script provider might place data model method objects (<see cref="IModelMethod"/> interfaces boxed into <see cref="IModelObject"/>) whose implementation calls into correspondingly named functions in the script.
        /// </summary>
        /// <param name="namespaceObject">A data model object which can be used as the representation of the namespace of the script.</param>
        /// <returns>This method returns HRESULT which indicates success or failure.</returns>
        [PreserveSig]
        HRESULT GetNamespaceObject(
            [Out, MarshalAs(UnmanagedType.Interface)] out IModelObject namespaceObject);
    }
}
