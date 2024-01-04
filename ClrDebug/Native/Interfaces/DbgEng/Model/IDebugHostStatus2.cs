using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("4A168D3F-04D0-49C4-8F9A-7B5B3108C6C6")]
    [ComImport]
    public interface IDebugHostStatus2 : IDebugHostStatus
    {
        /// <summary>
        /// The PollUserInterrupt method is used to inquire whether the user of the debug host has requested an interruption of the current operation.<para/>
        /// A property accessor in the data model may, for instance, call into arbitrary code (e.g.: a JavaScript method). That code may take an arbitrary amount of time.<para/>
        /// In order to keep the debug host responsive, any such code which may take an arbitrary amount of time should check for an interrupt request via calling this method.<para/>
        /// If the interruptRequested value comes back as true, the caller should immediately abort and return a result of E_ABORT.<para/>
        /// It is important that any caller of data model APIs which receives an error of E_ABORT propagate that error outward and not swallow just it.<para/>
        /// Certain hosts (in particular, Debugging Tools for Windows) may opt to fail inquiries which occur while an interrupt is pending.<para/>
        /// In such circumstances, many method calls to <see cref="IDebugHost"/>* interfaces will return E_ABORT until control has returned to the debug host.
        /// </summary>
        /// <param name="interruptRequested">An indication of whether or not a user interrupt is pending is returned. If the returned value is true, the caller should immediately stop what it is doing and propagate the E_ABORT error code outward.</param>
        /// <returns>This method returns HRESULT which indicates success or failure.</returns>
        [PreserveSig]
        new HRESULT PollUserInterrupt(
            [Out, MarshalAs(UnmanagedType.U1)] out bool interruptRequested);
        
        [PreserveSig]
        HRESULT SetUserInterrupt();
        
        [PreserveSig]
        HRESULT ClearUserInterrupt();
    }
}
