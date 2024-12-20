using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("36994180-227B-4C58-A394-5484B761DDB0")]
    [ComImport]
    public interface IComponentVirtualMemoryFromFileInitializer
    {
        /// <summary>
        /// Initializes the DEBUG_COMPONENTSVC_VIRTUALMEMORY_FROM_FILE component.
        /// </summary>
        [PreserveSig]
        HRESULT Initialize(
            [In] long mappingBaseAddress);
    }
}
