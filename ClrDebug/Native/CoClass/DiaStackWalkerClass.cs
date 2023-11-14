using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using ClrDebug.DIA;

namespace ClrDebug.CoClass
{
    [Guid("CE4A85DB-5768-475B-A4E1-C0BCA2112A6B")]
    [ClassInterface(ClassInterfaceType.None)]
    [ComImport]
    public class DiaStackWalkerClass : IDiaStackWalker, DiaStackWalker
    {
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        public virtual extern HRESULT getEnumFrames(
            [MarshalAs(UnmanagedType.Interface), In] IDiaStackWalkHelper pHelper,
            [MarshalAs(UnmanagedType.Interface)] out IDiaEnumStackFrames ppenum);

        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        public virtual extern HRESULT getEnumFrames2(
            [In] CV_CPU_TYPE_e cpuid,
            [MarshalAs(UnmanagedType.Interface), In] IDiaStackWalkHelper pHelper,
            [MarshalAs(UnmanagedType.Interface)] out IDiaEnumStackFrames ppenum);
    }
}
