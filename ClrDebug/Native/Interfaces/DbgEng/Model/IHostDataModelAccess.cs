using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    /// <summary>
    /// When DebugExtensionInitialize is called, it creates a debug client and gets access to the data model. Such access is provided by a bridge interface between the legacy IDebug* interfaces of Debugging Tools for Windows and the data model.<para/>
    /// This bridge interface is IHostDataModelAccess.
    /// </summary>
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("F2BCE54E-4835-4F8A-836E-7981E29904D1")]
    [ComImport]
    public interface IHostDataModelAccess
    {
        /// <summary>
        /// The GetDataModel method is the method on the bridge interface which provides access to both sides of the data model: • The debug host (the lower edge of the debugger) is expressed by the returned <see cref="IDebugHost"/> interface • The data model's main component -- the data model manager is expressed by the returned <see cref="IDataModelManager"/> interface
        /// </summary>
        /// <param name="manager">An interface to the data model manager is returned here.</param>
        /// <param name="host">The core interface of the debug host is returned here.</param>
        /// <returns>This method returns HRESULT that indicates success or failure.</returns>
        [PreserveSig]
        HRESULT GetDataModel(
            [Out, MarshalAs(UnmanagedType.Interface)] out IDataModelManager manager,
            [Out, MarshalAs(UnmanagedType.Interface)] out IDebugHost host);
    }
}
