using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;

namespace ManagedCorDebug
{
    /// <summary>
    /// Provides methods to map type libraries to their metadata signatures, and to convert from one to the other.
    /// </summary>
    [Guid("D9DEBD79-2992-11d3-8BC1-0000F8083A57")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [ComImport]
    public interface IMetaDataConverter
    {
        /// <summary>
        /// Gets a pointer to an <see cref="IMetaDataImport"/> instance that represents the metadata signature of the type library referenced by the specified ITypeInfo instance.
        /// </summary>
        /// <param name="pITI">[in] A pointer to an ITypeInfo object that refers to the type library.</param>
        /// <param name="ppMDI">[out] A pointer to a location that receives the address of the IMetaDataImport instance that represents the metadata signature.</param>
        [PreserveSig]
        HRESULT GetMetaDataFromTypeInfo(
            [In, MarshalAs(UnmanagedType.Interface)] ITypeInfo pITI,
            [Out, MarshalAs(UnmanagedType.Interface)] out IMetaDataImport ppMDI);

        /// <summary>
        /// Gets an interface pointer to an <see cref="IMetaDataImport"/> instance that represents the metadata signature of the type library represented by the specified ITypeLib instance.
        /// </summary>
        /// <param name="pITL">[in] Pointer to an ITypeLib object that represents the type library.</param>
        /// <param name="ppMDI">[out] Pointer to a location that receives the address of the IMetaDataImport instance that represents the metadata signature.</param>
        [PreserveSig]
        HRESULT GetMetaDataFromTypeLib(
            [In, MarshalAs(UnmanagedType.Interface)] ITypeLib pITL,
            [Out, MarshalAs(UnmanagedType.Interface)] out IMetaDataImport ppMDI);

        /// <summary>
        /// Gets a pointer to an ITypeLib instance that represents the type library that has the specified library and module names.
        /// </summary>
        /// <param name="strModule">[in] The name of the type library's module.</param>
        /// <param name="strTlbName">[in] The name of the type library.</param>
        /// <param name="ppITL">[out] A pointer to a location that receives the address of the ITypeLib instance that represents the type library.</param>
        [PreserveSig]
        HRESULT GetTypeLibFromMetaData(
            [In, MarshalAs(UnmanagedType.BStr)] string strModule,
            [In, MarshalAs(UnmanagedType.BStr)] string strTlbName,
            [Out, MarshalAs(UnmanagedType.Interface)] out ITypeLib ppITL);
    }
}