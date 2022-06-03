using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;

namespace ManagedCorDebug
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("FAA8637B-3BBE-4671-8E26-3B59875B922A")]
    [ComImport]
    public interface ICorDebugMergedAssemblyRecord
    {
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT GetSimpleName([In] uint cchName, out uint pcchName, [Out] StringBuilder szName);

        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT GetVersion(out ushort pMajor, out ushort pMinor, out ushort pBuild, out ushort pRevision);

        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT GetCulture([In] uint cchCulture, out uint pcchCulture, [Out] StringBuilder szCulture);

        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT GetPublicKey(
            [In] uint cbPublicKey,
            out uint pcbPublicKey,
            [MarshalAs(UnmanagedType.LPArray), Out]
            byte[] pbPublicKey);

        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT GetPublicKeyToken(
            [In] uint cbPublicKeyToken,
            out uint pcbPublicKeyToken,
            [MarshalAs(UnmanagedType.LPArray), Out]
            byte[] pbPublicKeyToken);

        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT GetIndex(out uint pIndex);
    }
}