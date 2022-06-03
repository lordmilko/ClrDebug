using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    [Guid("0A29FF9E-7F9C-4437-8B11-F424491E3931")]
    [TypeLibType(TypeLibTypeFlags.FCanCreate)]
    [ClassInterface(ClassInterfaceType.None)]
    [ComImport]
    public class CorSymBinder_SxSClass : ISymUnmanagedBinder, CorSymBinder_SxS
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