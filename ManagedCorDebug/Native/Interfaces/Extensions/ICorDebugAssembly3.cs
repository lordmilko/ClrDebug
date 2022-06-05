using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    /// <summary>
    /// Logically extends the ICorDebugAssembly interface to provide support for container assemblies and their contained assemblies.
    /// </summary>
    [Guid("76361AB2-8C86-4FE9-96F2-F73D8843570A")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [ComImport]
    public interface ICorDebugAssembly3
    {
        /// <summary>
        /// Returns the container assembly of this ICorDebugAssembly3 object.
        /// </summary>
        /// <param name="ppAssembly">A pointer to the address of an ICorDebugAssembly object that represents the container assembly, or null if the method call fails.</param>
        /// <returns>S_OK if the method call succeeds; otherwise, S_FALSE, and ppAssembly is null.</returns>
        /// <remarks>
        /// If this assembly has been merged with others inside a single container assembly, this method returns the container
        /// assembly. For more information and terminology, see the <see cref="ICorDebugProcess6.EnableVirtualModuleSplitting"/>
        /// topic.
        /// </remarks>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT GetContainerAssembly([MarshalAs(UnmanagedType.Interface)] ref ICorDebugAssembly ppAssembly);

        /// <summary>
        /// Gets an enumerator for the assemblies contained in this assembly.
        /// </summary>
        /// <param name="ppAssemblies">[out] A pointer to the address of an ICorDebugAssemblyEnum interface object that is the enumerator.</param>
        /// <returns>S_OK if this ICorDebugAssembly3 object is a container; otherwise, S_FALSE, and the enumeration is empty.</returns>
        /// <remarks>
        /// Symbols are needed to enumerate the contained assemblies. If they aren't present, the method returns S_FALSE, and
        /// no valid enumerator is provided.
        /// </remarks>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT EnumerateContainedAssemblies([MarshalAs(UnmanagedType.Interface)] ref ICorDebugAssemblyEnum ppAssemblies);
    }
}