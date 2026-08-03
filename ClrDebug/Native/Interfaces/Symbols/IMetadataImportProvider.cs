using System.Runtime.InteropServices;
#if GENERATED_MARSHALLING
using System.Runtime.InteropServices.Marshalling;
#endif

namespace ClrDebug
{
    //This type is referenced from ISymUnmanagedBinder4, but as of writing
    //Microsoft.DiaSymReader.Native.amd64.dll still uses at most ISymUnmanagedBinder3

    [Guid("EDF3A293-A10D-4F4A-A609-38D5EDE35F89")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
#if !GENERATED_MARSHALLING
    [ComImport]
#else
    [GeneratedComInterface]
#endif
    public partial interface IMetadataImportProvider
    {
        /// <summary>
        /// Gets an instance of IMetadataImport.
        /// </summary>
        /// <remarks>
        /// The implementer is responsible for managing the lifetime of the resulting object.
        /// </remarks>
        [return: MarshalAs(UnmanagedType.Interface)] //I'm not sure if this should be PreserveSig or not. I'm guessing the actual native implementation returns a HRESULT and emits the IMetaDataImport as an out parameter
        IMetaDataImport GetMetadataImport();
    }
}
