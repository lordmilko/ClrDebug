using System;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;

namespace ManagedCorDebug
{
    /// <summary>
    /// Provides information about a merged assembly.
    /// </summary>
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("FAA8637B-3BBE-4671-8E26-3B59875B922A")]
    [ComImport]
    public interface ICorDebugMergedAssemblyRecord
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
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT GetSimpleName([In] int cchName, out int pcchName, [Out] StringBuilder szName);

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
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT GetVersion(out ushort pMajor, out ushort pMinor, out ushort pBuild, out ushort pRevision);

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
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT GetCulture([In] int cchCulture, out int pcchCulture, [Out] StringBuilder szCulture);

        /// <summary>
        /// Gets the assembly's public key.
        /// </summary>
        /// <param name="cbPublicKey">[in] The maximum number of bytes in the pbPublicKey array.</param>
        /// <param name="pcbPublicKey">[out] A pointer to the actual number of bytes written to the pbPublicKey array.</param>
        /// <param name="pbPublicKey">[out] A pointer to a byte array that contains the assembly's public key.</param>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT GetPublicKey(
            [In] int cbPublicKey,
            out int pcbPublicKey,
            [MarshalAs(UnmanagedType.LPArray), Out]
            byte[] pbPublicKey);

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
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT GetPublicKeyToken(
            [In] int cbPublicKeyToken,
            out int pcbPublicKeyToken,
            [MarshalAs(UnmanagedType.LPArray), Out] byte[] pbPublicKeyToken);

        /// <summary>
        /// Gets the assembly's prefix index.
        /// </summary>
        /// <param name="pIndex">[out] A pointer to the prefix index.</param>
        /// <remarks>
        /// The prefix index is used to prevent name collisions in the merged metadata type names.
        /// </remarks>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT GetIndex(out int pIndex);
    }
}