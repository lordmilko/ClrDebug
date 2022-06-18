using System;
using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    /// <summary>
    /// Provides a method that gets information about the mapping of metadata from an on-disk file into memory.
    /// </summary>
    [Guid("7998EA64-7F95-48B8-86FC-17CAF48BF5CB")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [ComImport]
    public interface IMetaDataInfo
    {
        /// <summary>
        /// Gets the memory region of the mapped file, and the type of mapping.
        /// </summary>
        /// <param name="ppvData">[out] A pointer to the start of the mapped file.</param>
        /// <param name="pcbData">[out] The size of the mapped region. If pdwMappingType is fmFlat, this is the size of the file.</param>
        /// <param name="pdwMappingType">[out] A <see cref="CorFileMapping"/> value that indicates the type of mapping. The current implementation of the common language runtime (CLR) always returns fmFlat.<para/>
        /// Other values are reserved for future use. However, you should always verify the returned value, because other values may be enabled in future versions or service releases.</param>
        /// <returns>
        /// | HRESULT            | Description                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                      |
        /// | ------------------ | ------------------------------------------------------------------------------------------------------------------------- |
        /// | S_OK               | All outputs are filled.                                                                                                   |
        /// | E_INVALIDARG       | NULL was passed as an argument value.                                                                                     |
        /// | COR_E_NOTSUPPORTED | The CLR implementation cannot provide information about the memory region. This can happen for the following reasons:     |
        /// |                    | -   The metadata scope was opened with the ofWrite or ofCopyMemory flag.                                                  |
        /// |                    | -   The metadata scope was opened without the ofReadOnly flag.                                                            |
        /// |                    | -   The <see cref="IMetaDataDispenser.OpenScopeOnMemory"/> method was used to open only the metadata portion of the file. |
        /// |                    | -   The file is not a portable executable (PE) file.                                                                      |
        /// |                    | Note:  These conditions depend on the CLR implementation, and are likely to be weakened in future versions of the CLR.    |
        /// </returns>
        /// <remarks>
        /// The memory that ppvData points to is valid only as long as the underlying metadata scope is open. In order for
        /// this method to work, when you map the metadata of an on-disk file into memory by calling the <see cref="IMetaDataDispenser.OpenScope"/>
        /// method, you must specify the ofReadOnly flag and you must not specify the ofWrite or ofCopyMemory flag. The choice
        /// of file mapping type for each scope is specific to a given implementation of the CLR. It cannot be set by the user.
        /// The current implementation of the CLR always returns fmFlat in pdwMappingType, but this can change in future versions
        /// of the CLR or in future service releases of a given version. You should always check the returned value in pdwMappingType,
        /// because different types will have different layouts and offsets. Passing NULL for any of the three parameters is
        /// not supported. The method returns E_INVALIDARG, and none of the outputs are filled. Ignoring the mapping type or
        /// the size of the region can result in abnormal program termination.
        /// </remarks>
        [PreserveSig]
        HRESULT GetFileMapping(
            [Out] out IntPtr ppvData,
            [Out] out long pcbData,
            [Out] out CorFileMapping pdwMappingType);
    }
}