using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [ComConversionLoss]
    [ComImport]
    [Guid("9FD93CCF-3280-4391-B3A9-96E1CDE77C8D")]
    public interface ICLRStrongName
    {
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT GetHashFromAssemblyFile(
            [MarshalAs(UnmanagedType.LPStr), In] string pszFilePath,
            [In] [Out] ref uint piHashAlg,
            out byte pbHash,
            [In] uint cchHash,
            out uint pchHash);

        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT GetHashFromAssemblyFileW(
            [MarshalAs(UnmanagedType.LPWStr), In] string pwzFilePath,
            [In] [Out] ref uint piHashAlg,
            out byte pbHash,
            [In] uint cchHash,
            out uint pchHash);

        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT GetHashFromBlob(
            [In] ref byte pbBlob,
            [In] uint cchBlob,
            [In] [Out] ref uint piHashAlg,
            out byte pbHash,
            [In] uint cchHash,
            out uint pchHash);

        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT GetHashFromFile(
            [MarshalAs(UnmanagedType.LPStr), In] string pszFilePath,
            [In] [Out] ref uint piHashAlg,
            out byte pbHash,
            [In] uint cchHash,
            out uint pchHash);

        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT GetHashFromFileW(
            [MarshalAs(UnmanagedType.LPWStr), In] string pwzFilePath,
            [In] [Out] ref uint piHashAlg,
            out byte pbHash,
            [In] uint cchHash,
            out uint pchHash);

        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT GetHashFromHandle(
            [In] IntPtr hFile,
            [In] [Out] ref uint piHashAlg,
            out byte pbHash,
            [In] uint cchHash,
            out uint pchHash);

        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT StrongNameCompareAssemblies([MarshalAs(UnmanagedType.LPWStr), In] string pwzAssembly1,
            [MarshalAs(UnmanagedType.LPWStr), In] string pwzAssembly2);

        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT StrongNameFreeBuffer([In] ref byte pbMemory);

        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT StrongNameGetBlob([MarshalAs(UnmanagedType.LPWStr), In] string pwzFilePath, [In] [Out] ref byte pbBlob,
            [In] [Out] ref uint pcbBlob);

        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT StrongNameGetBlobFromImage(
            [In] ref byte pbBase,
            [In] uint dwLength,
            out byte pbBlob,
            [In] [Out] ref uint pcbBlob);

        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT StrongNameGetPublicKey(
            [MarshalAs(UnmanagedType.LPWStr), In] string pwzKeyContainer,
            [In] ref byte pbKeyBlob,
            [In] uint cbKeyBlob,
            [Out] IntPtr ppbPublicKeyBlob,
            out uint pcbPublicKeyBlob);

        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT StrongNameHashSize([In] uint ulHashAlg);

        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT StrongNameKeyDelete([MarshalAs(UnmanagedType.LPWStr), In] string pwzKeyContainer);

        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT StrongNameKeyGen(
            [MarshalAs(UnmanagedType.LPWStr), In] string pwzKeyContainer,
            [In] uint dwFlags,
            [Out] IntPtr ppbKeyBlob,
            out uint pcbKeyBlob);

        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT StrongNameKeyGenEx(
            [MarshalAs(UnmanagedType.LPWStr), In] string pwzKeyContainer,
            [In] uint dwFlags,
            [In] uint dwKeySize,
            [Out] IntPtr ppbKeyBlob,
            out uint pcbKeyBlob);

        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT StrongNameKeyInstall([MarshalAs(UnmanagedType.LPWStr), In] string pwzKeyContainer,
            [In] ref byte pbKeyBlob, [In] uint cbKeyBlob);

        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT StrongNameSignatureGeneration(
            [MarshalAs(UnmanagedType.LPWStr), In] string pwzFilePath,
            [MarshalAs(UnmanagedType.LPWStr), In] string pwzKeyContainer,
            [In] ref byte pbKeyBlob,
            [In] uint cbKeyBlob,
            [Out] IntPtr ppbSignatureBlob,
            out uint pcbSignatureBlob);

        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT StrongNameSignatureGenerationEx(
            [MarshalAs(UnmanagedType.LPWStr), In] string wszFilePath,
            [MarshalAs(UnmanagedType.LPWStr), In] string wszKeyContainer,
            [In] ref byte pbKeyBlob,
            [In] uint cbKeyBlob,
            [Out] IntPtr ppbSignatureBlob,
            out uint pcbSignatureBlob,
            [In] uint dwFlags);

        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT StrongNameSignatureSize([In] ref byte pbPublicKeyBlob, [In] uint cbPublicKeyBlob, [In] ref uint pcbSize);

        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT StrongNameSignatureVerification([MarshalAs(UnmanagedType.LPWStr), In] string pwzFilePath,
            [In] uint dwInFlags);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        sbyte StrongNameSignatureVerificationEx([MarshalAs(UnmanagedType.LPWStr), In] string pwzFilePath,
            [In] sbyte fForceVerification);

        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT StrongNameSignatureVerificationFromImage([In] ref byte pbBase, [In] uint dwLength, [In] uint dwInFlags);

        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT StrongNameTokenFromAssembly(
            [MarshalAs(UnmanagedType.LPWStr), In] string pwzFilePath,
            [Out] IntPtr ppbStrongNameToken,
            out uint pcbStrongNameToken);

        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT StrongNameTokenFromAssemblyEx(
            [MarshalAs(UnmanagedType.LPWStr), In] string pwzFilePath,
            [Out] IntPtr ppbStrongNameToken,
            out uint pcbStrongNameToken,
            [Out] IntPtr ppbPublicKeyBlob,
            out uint pcbPublicKeyBlob);

        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT StrongNameTokenFromPublicKey(
            [In] ref byte pbPublicKeyBlob,
            [In] uint cbPublicKeyBlob,
            [Out] IntPtr ppbStrongNameToken,
            out uint pcbStrongNameToken);
    }
}