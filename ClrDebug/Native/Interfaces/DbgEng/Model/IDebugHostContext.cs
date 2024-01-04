using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    /// <summary>
    /// Represents a context of the debugger answers questions about (what session, process, thread).
    /// </summary>
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("A68C70D8-5EC0-46E5-B775-3134A48EA2E3")]
    [ComImport]
    public interface IDebugHostContext
    {
        /// <summary>
        /// Returns whether two <see cref="IDebugHostContext"/> objects are equal by value. Note that there is no requirement for a debug host to have interface pointer equality for two contexts which are equivalent.<para/>
        /// The actual contexts can be compared through this method.
        /// </summary>
        /// <param name="pContext">The host context to compare against.</param>
        /// <param name="pIsEqual">An indication of whether the values of the two objects are equal.</param>
        /// <returns>This method returns HRESULT.</returns>
        [PreserveSig]
        HRESULT IsEqualTo(
            [In, MarshalAs(UnmanagedType.Interface)] IDebugHostContext pContext,
            [Out, MarshalAs(UnmanagedType.U1)] out bool pIsEqual);
    }
}
