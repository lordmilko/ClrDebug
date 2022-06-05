using System;
using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    /// <summary>
    /// Extends <see cref="IMetaDataTables"/> to include methods for working with metadata streams.
    /// </summary>
    [Guid("BADB5F70-58DA-43a9-A1C6-D74819F19B15")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [ComImport]
    public interface IMetaDataTables2
    {
        /// <summary>
        /// Gets the size and contents of the metadata stored in the specified section.
        /// </summary>
        /// <param name="ppvMd">[in, out] A pointer to a metadata section.</param>
        /// <param name="pcbMd">[out] The size of the metadata stream.</param>
        [PreserveSig]
        HRESULT GetMetaDataStorage(out IntPtr ppvMd, out uint pcbMd);

        /// <summary>
        /// Gets the name, size, and contents of the metadata stream at the specified index.
        /// </summary>
        /// <param name="ix">[in] The index of the requested metadata stream.</param>
        /// <param name="ppchName">[out] A pointer to the name of the stream.</param>
        /// <param name="ppv">[out] A pointer to the metadata stream.</param>
        /// <param name="pcb">[out] The size, in bytes, of ppv.</param>
        [PreserveSig]
        HRESULT GetMetaDataStreamInfo(uint ix, [MarshalAs(UnmanagedType.LPArray)] char[] ppchName, out IntPtr ppv, out uint pcb);
    }
}