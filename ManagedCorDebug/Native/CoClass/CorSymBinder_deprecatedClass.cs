using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    [Guid("AA544D41-28CB-11D3-BD22-0000F80849BD")]
    [TypeLibType(TypeLibTypeFlags.FCanCreate)]
    [ClassInterface(ClassInterfaceType.None)]
    [ComImport]
    public class CorSymBinder_deprecatedClass : ISymUnmanagedBinder, CorSymBinder_deprecated
    {
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        [return: MarshalAs(UnmanagedType.Interface)]
        public virtual extern ISymUnmanagedReader GetReaderForFile(
            [MarshalAs(UnmanagedType.IUnknown), In]
            object importer,
            [In] ref ushort filename,
            [In] ref ushort searchPath);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        [return: MarshalAs(UnmanagedType.Interface)]
        public virtual extern ISymUnmanagedReader GetReaderFromStream(
            [MarshalAs(UnmanagedType.IUnknown), In]
            object importer,
            [MarshalAs(UnmanagedType.Interface), In]
            IStream pstream);
    }
}