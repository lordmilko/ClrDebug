using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("FF4713F1-74DD-4CBC-830C-7F13D7E31AA3")]
    [ComImport]
    public interface ISvcModuleWithTimestampAndChecksum : ISvcModule
    {
        /// <summary>
        /// Gets the unique key of the process to which this thread belongs. This is the same key returned from the containing ISvcProcess's GetKey method.<para/>
        /// This method may return S_FALSE and a process key of zero for modules which do not logically belong to any process (e.g.: they are kernel modules / drivers that are mapped into every process).
        /// </summary>
        [PreserveSig]
        new HRESULT GetContainingProcessKey(
            [Out] out long containingProcessKey);

        /// <summary>
        /// Gets the unique "per-process" module key. The interpretation of this key is dependent upon the service which provides this interface.<para/>
        /// This may be the base address of the module.
        /// </summary>
        [PreserveSig]
        new HRESULT GetKey(
            [Out] out long moduleKey);

        /// <summary>
        /// Gets the base address of the module.
        /// </summary>
        [PreserveSig]
        new HRESULT GetBaseAddress(
            [Out] out long moduleBaseAddress);

        /// <summary>
        /// Gets the size of the module.
        /// </summary>
        [PreserveSig]
        new HRESULT GetSize(
            [Out] out long moduleSize);

        /// <summary>
        /// Gets the name of the module.
        /// </summary>
        [PreserveSig]
        new HRESULT GetName(
            [Out, MarshalAs(UnmanagedType.BStr)] out string moduleName);

        /// <summary>
        /// Gets the load path of the module.
        /// </summary>
        [PreserveSig]
        new HRESULT GetPath(
            [Out, MarshalAs(UnmanagedType.BStr)] out string modulePath);

        /// <summary>
        /// Gets the time date stamp of the module.
        /// </summary>
        [PreserveSig]
        HRESULT GetTimeDateStamp(
            [Out] out int moduleTimeDateStamp);

        /// <summary>
        /// Gets the check sum of the module.
        /// </summary>
        [PreserveSig]
        HRESULT GetCheckSum(
            [Out] out int moduleCheckSum);
    }
}
