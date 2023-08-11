#if !GENERATED_MARSHALLING

using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace ClrDebug.CoClass
{
    [Guid("AA544D41-28CB-11D3-BD22-0000F80849BD")]
    [ClassInterface(ClassInterfaceType.None)]
    [ComImport]
    public partial class CorSymBinder_deprecatedClass : ISymUnmanagedBinder, CorSymBinder_deprecated
    {
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        public virtual extern HRESULT GetReaderForFile(
            [MarshalAs(UnmanagedType.Interface), In] IMetaDataImport importer,
            [In, MarshalAs(UnmanagedType.LPWStr)] string fileName,
            [In, MarshalAs(UnmanagedType.LPWStr)] string searchPath,
            [Out, MarshalAs(UnmanagedType.Interface)] out ISymUnmanagedReader pRetVal);

        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        public virtual extern HRESULT GetReaderFromStream(
            [MarshalAs(UnmanagedType.Interface), In] IMetaDataImport importer,
            [MarshalAs(UnmanagedType.Interface), In] IStream pstream,
            [Out, MarshalAs(UnmanagedType.Interface)] out ISymUnmanagedReader pRetVal);
    }
}

#endif
