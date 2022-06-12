using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;

namespace ManagedCorDebug
{
    /// <summary>
    /// Provides information about a loaded module.
    /// </summary>
    /// <remarks>
    /// The <see cref="ICorDebugLoadedModule"/> interface is implemented by a debugger and is used by the CLR debugging interfaces to
    /// get information about the loaded module from the debugger.
    /// </remarks>
    [Guid("817F343A-6630-4578-96C5-D11BC0EC5EE2")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [ComImport]
    public interface ICorDebugLoadedModule
    {
        /// <summary>
        /// Gets the base address of the loaded module.
        /// </summary>
        /// <param name="pAddress">[out] A pointer to the base address of the loaded module.</param>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT GetBaseAddress(out CORDB_ADDRESS pAddress);

        /// <summary>
        /// Gets the name of the loaded module.
        /// </summary>
        /// <param name="cchName">[in] The number of characters in the szName buffer.</param>
        /// <param name="pcchName">[out] A pointer to the number of characters actually written to the szName buffer.</param>
        /// <param name="szName">[out] An array of characters that contain the name of the loaded module.</param>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT GetName([In] int cchName, out int pcchName, [Out] StringBuilder szName);

        /// <summary>
        /// Gets the size in bytes of the loaded module.
        /// </summary>
        /// <param name="pcBytes">[out] A pointer to the number of bytes in the loaded module.</param>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT GetSize(out int pcBytes);
    }
}