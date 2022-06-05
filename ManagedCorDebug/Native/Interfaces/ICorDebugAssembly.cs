using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;

namespace ManagedCorDebug
{
    /// <summary>
    /// Represents an assembly.
    /// </summary>
    [Guid("DF59507C-D47A-459E-BCE2-6427EAC8FD06")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [ComImport]
    public interface ICorDebugAssembly
    {
        /// <summary>
        /// Gets an interface pointer to the process in which this ICorDebugAssembly instance is running.
        /// </summary>
        /// <param name="ppProcess">[out] A pointer to an ICorDebugProcess interface that represents the process.</param>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT GetProcess([MarshalAs(UnmanagedType.Interface)] out ICorDebugProcess ppProcess);

        /// <summary>
        /// Gets an interface pointer to the application domain that contains this ICorDebugAssembly instance.
        /// </summary>
        /// <param name="ppAppDomain">[out] A pointer to the address of an ICorDebugAppDomain interface that represents the application domain.</param>
        /// <remarks>
        /// If this assembly is the system assembly, GetAppDomain returns null.
        /// </remarks>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT GetAppDomain([MarshalAs(UnmanagedType.Interface)] out ICorDebugAppDomain ppAppDomain);

        /// <summary>
        /// Gets an enumerator for the modules contained in the ICorDebugAssembly.
        /// </summary>
        /// <param name="ppModules">[out] A pointer to the address of the ICorDebugModuleEnum interface that is the enumerator.</param>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT EnumerateModules([MarshalAs(UnmanagedType.Interface)] out ICorDebugModuleEnum ppModules);

        /// <summary>
        /// This method is not implemented in the current version of the .NET Framework.
        /// </summary>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT GetCodeBase([In] uint cchName, out uint pcchName, [Out] StringBuilder szName);

        /// <summary>
        /// Gets the name of the assembly that this ICorDebugAssembly instance represents.
        /// </summary>
        /// <param name="cchName">[in] The size of the szName array.</param>
        /// <param name="pcchName">[out] A pointer to an integer that specifies the actual length of the name.</param>
        /// <param name="szName">[out] An array that stores the name.</param>
        /// <remarks>
        /// The GetName method returns the full path and file name of the assembly.
        /// </remarks>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT GetName([In] uint cchName, out uint pcchName, [Out] StringBuilder szName);
    }
}