using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("D492514F-7CFE-4876-96AC-7FAB627895AB")]
    [ComImport]
    public interface ISvcEventArgumentsModuleDiscovery
    {
        /// <summary>
        /// Gets the module which is (dis)appearing. For a module arrival event, the returned module must already be in the enumerator as of the firing of this event and must be fully valid.<para/>
        /// For a module disappearance event, the interfaces on the returned module *MUST* continue to operate as if the module were loaded until the event notification has completed.<para/>
        /// This means fetching the name, base address, size, etc... must function during the event notification. After the event notification is complete, the module may be considered detached/orphaned for anyone continuing to hold the ISvcModule interface.
        /// </summary>
        [PreserveSig]
        HRESULT GetModule(
            [Out, MarshalAs(UnmanagedType.Interface)] out ISvcModule module);
    }
}
