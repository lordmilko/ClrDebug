using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    /// <summary>
    /// Context information for a stack unwind. Such an interface must always be passed to all components involved in a stack unwind.
    /// </summary>
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("B44285F2-5FAC-4BA9-8A1F-DD264EF1F1D3")]
    [ComImport]
    public interface ISvcStackUnwindContext
    {
        /// <summary>
        /// Gets the process that the stack unwind is occuring for. This method may legally return null/S_FALSE in cases where there is no associated process for the stack walk.
        /// </summary>
        [PreserveSig]
        HRESULT GetProcess(
            [Out, MarshalAs(UnmanagedType.Interface)] out ISvcProcess process);

        /// <summary>
        /// Gets the thread that the stack unwind is occurring for. This method may legally return null/S_FALSE in cases where there is no associated thread for the stack walk.
        /// </summary>
        [PreserveSig]
        HRESULT GetThread(
            [Out, MarshalAs(UnmanagedType.Interface)] out ISvcThread thread);

        /// <summary>
        /// Sets a piece of context data for a component involved in the stack walk which can be fetched later with GetContextData.
        /// </summary>
        [PreserveSig]
        HRESULT SetContextData(
            [In, MarshalAs(UnmanagedType.Interface)] object component,
            [In, MarshalAs(UnmanagedType.Interface)] object contextData);

        /// <summary>
        /// Gets a piece of context data for a component involved in the stack walk. Such data must have been set earlier via a call to SetContextData.
        /// </summary>
        [PreserveSig]
        HRESULT GetContextData(
            [In, MarshalAs(UnmanagedType.Interface)] object component,
            [Out, MarshalAs(UnmanagedType.Interface)] out object contextData);
    }
}
