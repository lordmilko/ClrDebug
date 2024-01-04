using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("E92274A2-47F4-4538-A196-B83DB25FE403")]
    [ComImport]
    public interface IDebugHostContext2 : IDebugHostContext
    {
        /// <summary>
        /// Returns whether two <see cref="IDebugHostContext"/> objects are equal by value. Note that there is no requirement for a debug host to have interface pointer equality for two contexts which are equivalent.<para/>
        /// The actual contexts can be compared through this method.
        /// </summary>
        /// <param name="pContext">The host context to compare against.</param>
        /// <param name="pIsEqual">An indication of whether the values of the two objects are equal.</param>
        /// <returns>This method returns HRESULT.</returns>
        [PreserveSig]
        new HRESULT IsEqualTo(
            [In, MarshalAs(UnmanagedType.Interface)] IDebugHostContext pContext,
            [Out, MarshalAs(UnmanagedType.U1)] out bool pIsEqual);
        
        [PreserveSig]
        HRESULT GetAddressSpaceRelation(
            [In, MarshalAs(UnmanagedType.Interface)] IDebugHostContext2 pContext,
            [Out] out AddressSpaceRelation pAddressSpaceRelation);
    }
}
