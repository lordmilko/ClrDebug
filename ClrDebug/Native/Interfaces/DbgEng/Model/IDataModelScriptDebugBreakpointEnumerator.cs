using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    /// <summary>
    /// An enumerator of breakpoints within the script. The script provider implements this to enumerate all of the breakpoints which currently exist within the script (whether enabled or not).
    /// </summary>
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("39484A75-B4F3-4799-86DA-691AFA57B299")]
    [ComImport]
    public interface IDataModelScriptDebugBreakpointEnumerator
    {
        /// <summary>
        /// The Reset method resets the position of the enumerator to where it was just after the enumerator was created -- that is, before the first enumerated breakpoint.
        /// </summary>
        /// <returns>This method returns HRESULT that indicates success or failure.</returns>
        [PreserveSig]
        HRESULT Reset();

        /// <summary>
        /// The GetNext method moves the enumerator forward to the next breakpoint to be enumerated and returns the <see cref="IDataModelScriptDebugBreakpoint"/> interface for that breakpoint.<para/>
        /// If the enumerator has reached the end of the enumeration, it returns E_BOUNDS. Once the E_BOUNDS error has been produced, subsequent calls to the GetNext method will continue to produce E_BOUNDS unless an intervening call to the Reset method has been made.
        /// </summary>
        /// <param name="breakpoint">The next enumerated breakpoint is returned here.</param>
        /// <returns>This method returns HRESULT that indicates success or failure.</returns>
        [PreserveSig]
        HRESULT GetNext(
            [Out, MarshalAs(UnmanagedType.Interface)] out IDataModelScriptDebugBreakpoint breakpoint);
    }
}
