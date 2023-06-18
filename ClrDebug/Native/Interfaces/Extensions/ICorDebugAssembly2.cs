using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace ClrDebug
{
    /// <summary>
    /// Represents an assembly. This interface is an extension of the <see cref="ICorDebugAssembly"/> interface.
    /// </summary>
    [Guid("426D1F9E-6DD4-44C8-AEC7-26CDBAF4E398")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [ComImport]
    public interface ICorDebugAssembly2
    {
        /// <summary>
        /// Gets a value that indicates whether the assembly has been granted full trust by the runtime security system.
        /// </summary>
        /// <param name="pbFullyTrusted">[out] true if the assembly has been granted full trust by the runtime security system; otherwise, false.</param>
        /// <remarks>
        /// This method returns an <see cref="HRESULT"/> of CORDBG_E_NOTREADY if the security policy for the assembly has not yet been resolved,
        /// that is, if no code in the assembly has been run yet.
        /// </remarks>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT IsFullyTrusted(
            [Out, MarshalAs(UnmanagedType.Bool)] out bool pbFullyTrusted);
    }
}
