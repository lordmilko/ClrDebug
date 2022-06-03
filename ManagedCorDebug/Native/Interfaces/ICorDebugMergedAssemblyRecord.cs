using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("FAA8637B-3BBE-4671-8E26-3B59875B922A")]
    [ComImport]
    public interface ICorDebugMergedAssemblyRecord
    {
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void GetSimpleName([In] uint cchName, out uint pcchName, [MarshalAs(UnmanagedType.Interface), Out]
            ICorDebugMergedAssemblyRecord szName);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void GetVersion(out ushort pMajor, out ushort pMinor, out ushort pBuild, out ushort pRevision);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void GetCulture([In] uint cchCulture, out uint pcchCulture, [MarshalAs(UnmanagedType.Interface), Out]
            ICorDebugMergedAssemblyRecord szCulture);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void GetPublicKey(
            [In] uint cbPublicKey,
            out uint pcbPublicKey,
            [MarshalAs(UnmanagedType.Interface), Out]
            ICorDebugMergedAssemblyRecord pbPublicKey);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void GetPublicKeyToken(
            [In] uint cbPublicKeyToken,
            out uint pcbPublicKeyToken,
            [MarshalAs(UnmanagedType.Interface), Out]
            ICorDebugMergedAssemblyRecord pbPublicKeyToken);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void GetIndex(out uint pIndex);
    }
}