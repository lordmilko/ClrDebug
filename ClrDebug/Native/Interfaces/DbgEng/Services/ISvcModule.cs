using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("360DE704-D055-483A-8E3B-BD67D2DA0133")]
    [ComImport]
    public interface ISvcModule
    {
        /// <summary>
        /// Gets the unique key of the process to which this thread belongs. This is the same key returned from the containing ISvcProcess's GetKey method.<para/>
        /// This method may return S_FALSE and a process key of zero for modules which do not logically belong to any process (e.g.: they are kernel modules / drivers that are mapped into every process).
        /// </summary>
        [PreserveSig]
        HRESULT GetContainingProcessKey(
            [Out] out long containingProcessKey);

        /// <summary>
        /// Gets the unique "per-process" module key. The interpretation of this key is dependent upon the service which provides this interface.<para/>
        /// This may be the base address of the module.
        /// </summary>
        [PreserveSig]
        HRESULT GetKey(
            [Out] out long moduleKey);

        /// <summary>
        /// Gets the base address of the module.
        /// </summary>
        [PreserveSig]
        HRESULT GetBaseAddress(
            [Out] out long moduleBaseAddress);

        /// <summary>
        /// Gets the size of the module.
        /// </summary>
        [PreserveSig]
        HRESULT GetSize(
            [Out] out long moduleSize);

        /// <summary>
        /// Gets the name of the module.
        /// </summary>
        [PreserveSig]
        HRESULT GetName(
            [Out, MarshalAs(UnmanagedType.BStr)] out string moduleName);

        /// <summary>
        /// Gets the load path of the module.
        /// </summary>
        [PreserveSig]
        HRESULT GetPath(
            [Out, MarshalAs(UnmanagedType.BStr)] out string modulePath);
    }
}
