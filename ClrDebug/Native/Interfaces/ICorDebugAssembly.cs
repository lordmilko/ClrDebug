﻿using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using SRI = System.Runtime.InteropServices;
#if GENERATED_MARSHALLING
using System.Runtime.InteropServices.Marshalling;
#endif

namespace ClrDebug
{
    /// <summary>
    /// Represents an assembly.
    /// </summary>
    [Guid("DF59507C-D47A-459E-BCE2-6427EAC8FD06")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
#if !GENERATED_MARSHALLING
    [ComImport]
#else
    [GeneratedComInterface]
#endif
    public partial interface ICorDebugAssembly
    {
        /// <summary>
        /// Gets an interface pointer to the process in which this <see cref="ICorDebugAssembly"/> instance is running.
        /// </summary>
        /// <param name="ppProcess">[out] A pointer to an <see cref="ICorDebugProcess"/> interface that represents the process.</param>
        [PreserveSig]
        HRESULT GetProcess(
            [Out, MarshalAs(UnmanagedType.Interface)] out ICorDebugProcess ppProcess);

        /// <summary>
        /// Gets an interface pointer to the application domain that contains this <see cref="ICorDebugAssembly"/> instance.
        /// </summary>
        /// <param name="ppAppDomain">[out] A pointer to the address of an <see cref="ICorDebugAppDomain"/> interface that represents the application domain.</param>
        /// <remarks>
        /// If this assembly is the system assembly, GetAppDomain returns null.
        /// </remarks>
        [PreserveSig]
        HRESULT GetAppDomain(
            [Out, MarshalAs(UnmanagedType.Interface)] out ICorDebugAppDomain ppAppDomain);

        /// <summary>
        /// Gets an enumerator for the modules contained in the <see cref="ICorDebugAssembly"/>.
        /// </summary>
        /// <param name="ppModules">[out] A pointer to the address of the <see cref="ICorDebugModuleEnum"/> interface that is the enumerator.</param>
        [PreserveSig]
        HRESULT EnumerateModules(
            [Out, MarshalAs(UnmanagedType.Interface)] out ICorDebugModuleEnum ppModules);

        /// <summary>
        /// This method is not implemented in the current version of the .NET Framework.
        /// </summary>
        [PreserveSig]
        HRESULT GetCodeBase(
            [In] int cchName,
            [Out] out int pcchName,
            [SRI.Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U2, SizeParamIndex = 0)] char[] szName);

        /// <summary>
        /// Gets the name of the assembly that this <see cref="ICorDebugAssembly"/> instance represents.
        /// </summary>
        /// <param name="cchName">[in] The size of the szName array.</param>
        /// <param name="pcchName">[out] A pointer to an integer that specifies the actual length of the name.</param>
        /// <param name="szName">[out] An array that stores the name.</param>
        /// <remarks>
        /// The GetName method returns the full path and file name of the assembly.
        /// </remarks>
        [PreserveSig]
        HRESULT GetName(
            [In] int cchName,
            [Out] out int pcchName,
            [SRI.Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U2, SizeParamIndex = 0)] char[] szName);
    }
}
