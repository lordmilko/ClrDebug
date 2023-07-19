using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
#if GENERATED_MARSHALLING
using System.Runtime.InteropServices.Marshalling;
#endif

namespace ClrDebug.CoClass
{
    [Guid("0A29FF9E-7F9C-4437-8B11-F424491E3931")]
    [ClassInterface(ClassInterfaceType.None)]
#if !GENERATED_MARSHALLING
    [ComImport]
#else
    [GeneratedComClass]
#endif
    public partial class CorSymBinder_SxSClass : ISymUnmanagedBinder, CorSymBinder_SxS
    {
        [PreserveSig]
        public virtual extern HRESULT GetReaderForFile(
            [MarshalAs(UnmanagedType.Interface), In] IMetaDataImport importer,
            [In, MarshalAs(UnmanagedType.LPWStr)] string fileName,
            [In, MarshalAs(UnmanagedType.LPWStr)] string searchPath,
            [Out, MarshalAs(UnmanagedType.Interface)] out ISymUnmanagedReader pRetVal);

        [PreserveSig]
        public virtual extern HRESULT GetReaderFromStream(
            [MarshalAs(UnmanagedType.Interface), In] IMetaDataImport importer,
            [MarshalAs(UnmanagedType.Interface), In] IStream pstream,
            [Out, MarshalAs(UnmanagedType.Interface)] out ISymUnmanagedReader pRetVal);
    }
}
