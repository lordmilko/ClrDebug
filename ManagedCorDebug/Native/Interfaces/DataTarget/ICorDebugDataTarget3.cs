using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    /// <summary>
    /// Logically extends the <see cref="ICorDebugDataTarget"/> interface to provide information about loaded modules.
    /// </summary>
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("D05E60C3-848C-4E7D-894E-623320FF6AFA")]
    [ComImport]
    public interface ICorDebugDataTarget3
    {
        /// <summary>
        /// Gets a list of the modules that have been loaded so far.
        /// </summary>
        /// <param name="cRequestedModules">[in] The number of modules for which information is requested.</param>
        /// <param name="pcFetchedModules">[out] A pointer to the number of modules about which information was returned.</param>
        /// <param name="pLoadedModules">[out] A pointer to an array of <see cref="ICorDebugLoadedModule"/> objects that provide information about loaded modules.</param>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT GetLoadedModules(
            [In] int cRequestedModules,
            [Out] out int pcFetchedModules,
            [Out, MarshalAs(UnmanagedType.LPArray)] ICorDebugLoadedModule[] pLoadedModules);
    }
}