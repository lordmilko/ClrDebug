﻿using System;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using SRI = System.Runtime.InteropServices;
#if GENERATED_MARSHALLING
using System.Runtime.InteropServices.Marshalling;
#endif

namespace ClrDebug
{
    /// <summary>
    /// Provides information about a merged assembly.
    /// </summary>
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("FAA8637B-3BBE-4671-8E26-3B59875B922A")]
#if !GENERATED_MARSHALLING
    [ComImport]
#else
    [GeneratedComInterface]
#endif
    public partial interface ICorDebugMergedAssemblyRecord
    {
        /// <summary>
        /// Gets the simple name of the assembly.
        /// </summary>
        /// <param name="cchName">[in] The number of characters in the szName buffer.</param>
        /// <param name="pcchName">[out] A pointer to the number of characters actually written to the szName buffer.</param>
        /// <param name="szName">A pointer to a character array.</param>
        /// <remarks>
        /// This method retrieves the simple name of an assembly (such as "System.Collections"), without a file extension,
        /// version, culture, or public key token. It corresponds to the <see cref="AssemblyName.Name"/> property in managed
        /// code.
        /// </remarks>
        [PreserveSig]
        HRESULT GetSimpleName(
            [In] int cchName,
            [Out] out int pcchName,
            [SRI.Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U2, SizeParamIndex = 0)] char[] szName);

        /// <summary>
        /// Gets the assembly's version information.
        /// </summary>
        /// <param name="pMajor">[out] A pointer to the major version number.</param>
        /// <param name="pMinor">[out] A pointer to the minor version number.</param>
        /// <param name="pBuild">[out] A pointer to the build number.</param>
        /// <param name="pRevision">[out] A pointer to the revision number.</param>
        /// <remarks>
        /// For information on assembly version numbers, see the <see cref="Version"/> class topic.
        /// </remarks>
        [PreserveSig]
        HRESULT GetVersion(
            [Out] out ushort pMajor,
            [Out] out ushort pMinor,
            [Out] out ushort pBuild,
            [Out] out ushort pRevision);

        /// <summary>
        /// Gets the culture name string of the assembly.
        /// </summary>
        /// <param name="cchCulture">[in] The number of characters in the szCulture buffer.</param>
        /// <param name="pcchCulture">[out] The number of characters actually written to the szCulture buffer.</param>
        /// <param name="szCulture">[out] A character array that contains the culture name.</param>
        /// <remarks>
        /// The culture name is a unique string that identifies a culture, such as "en-US" (for the English (United States)
        /// culture), or "neutral" (for a neutral culture).
        /// </remarks>
        [PreserveSig]
        HRESULT GetCulture(
            [In] int cchCulture,
            [Out] out int pcchCulture,
            [SRI.Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U2, SizeParamIndex = 0)] char[] szCulture);

        /// <summary>
        /// Gets the assembly's public key.
        /// </summary>
        /// <param name="cbPublicKey">[in] The maximum number of bytes in the pbPublicKey array.</param>
        /// <param name="pcbPublicKey">[out] A pointer to the actual number of bytes written to the pbPublicKey array.</param>
        /// <param name="pbPublicKey">[out] A pointer to a byte array that contains the assembly's public key.</param>
        [PreserveSig]
        HRESULT GetPublicKey(
            [In] int cbPublicKey,
            [Out] out int pcbPublicKey,
            [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0), SRI.Out] byte[] pbPublicKey);

        /// <summary>
        /// Gets the assembly's public key token.
        /// </summary>
        /// <param name="cbPublicKeyToken">[in] The maximum number of bytes in the pbPublicKeyToken array.</param>
        /// <param name="pcbPublicKeyToken">[out] A pointer to the actual number of bytes written to the pbPublicKeyToken array.</param>
        /// <param name="pbPublicKeyToken">[out] A pointer to a byte array that contains the assembly's public key token.</param>
        /// <remarks>
        /// An assembly's public key token is the last eight bytes of a SHA1 hash of its public key.
        /// </remarks>
        [PreserveSig]
        HRESULT GetPublicKeyToken(
            [In] int cbPublicKeyToken,
            [Out] out int pcbPublicKeyToken,
            [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0), SRI.Out] byte[] pbPublicKeyToken);

        /// <summary>
        /// Gets the assembly's prefix index.
        /// </summary>
        /// <param name="pIndex">[out] A pointer to the prefix index.</param>
        /// <remarks>
        /// The prefix index is used to prevent name collisions in the merged metadata type names.
        /// </remarks>
        [PreserveSig]
        HRESULT GetIndex(
            [Out] out int pIndex);
    }
}
