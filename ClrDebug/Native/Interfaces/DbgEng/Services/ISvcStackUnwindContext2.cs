using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    /// <summary>
    /// Context information for a stack unwind. Such an interface must always be passed to all components involved in a stack unwind.
    /// </summary>
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("2D742534-FC20-4472-A5DD-3A66BFED5832")]
    [ComImport]
    public interface ISvcStackUnwindContext2 : ISvcStackUnwindContext
    {
        /// <summary>
        /// Gets the process that the stack unwind is occuring for. This method may legally return null/S_FALSE in cases where there is no associated process for the stack walk.
        /// </summary>
        [PreserveSig]
        new HRESULT GetProcess(
            [Out, MarshalAs(UnmanagedType.Interface)] out ISvcProcess process);

        /// <summary>
        /// Gets the thread that the stack unwind is occurring for. This method may legally return null/S_FALSE in cases where there is no associated thread for the stack walk.
        /// </summary>
        [PreserveSig]
        new HRESULT GetThread(
            [Out, MarshalAs(UnmanagedType.Interface)] out ISvcThread thread);

        /// <summary>
        /// Sets a piece of context data for a component involved in the stack walk which can be fetched later with GetContextData.
        /// </summary>
        [PreserveSig]
        new HRESULT SetContextData(
            [In, MarshalAs(UnmanagedType.Interface)] object component,
            [In, MarshalAs(UnmanagedType.Interface)] object contextData);

        /// <summary>
        /// Gets a piece of context data for a component involved in the stack walk. Such data must have been set earlier via a call to SetContextData.
        /// </summary>
        [PreserveSig]
        new HRESULT GetContextData(
            [In, MarshalAs(UnmanagedType.Interface)] object component,
            [Out, MarshalAs(UnmanagedType.Interface)] out object contextData);

        /// <summary>
        /// Gets the execution unit that the stack unwind is occuring for. This method may legally return null/S_FALSE in cases where there is no associated execution unit for the stack walk.
        /// </summary>
        [PreserveSig]
        HRESULT GetExecutionUnit(
            [Out, MarshalAs(UnmanagedType.Interface)] out ISvcExecutionUnit execUnit);
    }
}
