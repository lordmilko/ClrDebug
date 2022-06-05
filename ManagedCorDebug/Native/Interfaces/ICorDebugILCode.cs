using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    /// <summary>
    /// [Supported in the .NET Framework 4.5.2 and later versions]<para/>
    /// Represents a segment of intermediate language (IL) code.
    /// </summary>
    [Guid("598D46C2-C877-42A7-89D2-3D0C7F1C1264")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [ComImport]
    public interface ICorDebugILCode
    {
        /// <summary>
        /// [Supported in the .NET Framework 4.5.2 and later versions]<para/>
        /// Returns a pointer to a list of exception handling (EH) clauses that are defined for this intermediate language (IL).
        /// </summary>
        /// <param name="cClauses">[in] The storage capacity of the clauses array. See the Remarks section for more information.</param>
        /// <param name="pcClauses">[out] The number of clauses about which information is written to the clauses array.</param>
        /// <param name="clauses">[out] An array of <see cref="CorDebugEHClause"/> objects that contain information on exception handling clauses defined for this IL.</param>
        /// <remarks>
        /// If cClauses is 0 and pcClauses is non-null, pcClauses is set to the number of available exception handling clauses.
        /// If cClauses is non-zero, it represents the storage capacity of the clauses array. When the method returns, clauses
        /// contains a maximum of cClauses items, and pcClauses is set to the number of clauses actually written to the clauses
        /// array.
        /// </remarks>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT GetEHClauses([In] uint cClauses, out uint pcClauses, [MarshalAs(UnmanagedType.LPArray), Out]
            CorDebugEHClause[] clauses);
    }
}