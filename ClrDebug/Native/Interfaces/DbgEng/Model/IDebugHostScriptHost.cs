using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    /// <summary>
    /// An interface which the underlying debugger host must implement in order to manage data model scripts. The interface which indicates the capability of the debug host to take part in the scripting environment.<para/>
    /// This interface allows for the creation of contexts which inform scripting engines of where to place objects.
    /// </summary>
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("B70334A4-B92C-4570-93A1-D3EB686649A0")]
    [ComImport]
    public interface IDebugHostScriptHost
    {
        /// <summary>
        /// The CreateContext method is called by a script provider to create a new context in which to place the contents of the script.<para/>
        /// Such context is represented by the <see cref="IDataModelScriptHostContext"/>.
        /// </summary>
        /// <param name="script">The script for which to create a new context.</param>
        /// <param name="scriptContext">The newly created script host context is returned here.</param>
        /// <returns>This method returns HRESULT which indicates success or failure.</returns>
        [PreserveSig]
        HRESULT CreateContext(
            [In, MarshalAs(UnmanagedType.Interface)] IDataModelScript script,
            [Out, MarshalAs(UnmanagedType.Interface)] out IDataModelScriptHostContext scriptContext);
    }
}
