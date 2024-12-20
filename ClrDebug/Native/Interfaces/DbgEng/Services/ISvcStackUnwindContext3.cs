using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    /// <summary>
    /// Context information for a stakc unwind. Such interface must always be passed to all component involved in a stack unwind.
    /// </summary>
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("E5CFCBEE-E83D-451F-A26B-D687C72159DD")]
    [ComImport]
    public interface ISvcStackUnwindContext3 : ISvcStackUnwindContext2
    {
        /// <summary>
        /// Gets the execution unit that the stack unwind is occuring for. This method may legally return null/S_FALSE in cases where there is no associated execution unit for the stack walk.
        /// </summary>
        [PreserveSig]
        new HRESULT GetExecutionUnit(
            [Out, MarshalAs(UnmanagedType.Interface)] out ISvcExecutionUnit execUnit);

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
        /// Gets the address context for reading the stack and appropriate data. If the unwind context has a particular process context, this is the process context.<para/>
        /// If it does not, this is the context of the execution unit (assuming that such represents a processor or other unit that has an associated address context).
        /// </summary>
        [PreserveSig]
        HRESULT GetAddressContext(
            [Out, MarshalAs(UnmanagedType.Interface)] out ISvcAddressContext addressContext);
    }
}
