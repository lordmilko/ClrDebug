using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    /// <summary>
    /// Provides mapping capabilities between assemblies.
    /// </summary>
    [Guid("06A3EA8B-0225-11d1-BF72-00C04FC31E12")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [ComImport]
    public interface IMapToken
    {
        /// <summary>
        /// Maps a relationship between the assemblies using metadata signatures.
        /// </summary>
        /// <param name="tkImp">[in] The metadata token that represents the imported code object.</param>
        /// <param name="tkEmit">[in] The metadata token that represents the emitted code object.</param>
        /// <remarks>
        /// When the token re-map occurs during a merge, the original token is scoped in the imported (source) metadata scope
        /// and the new token is scoped in the emitted (target) metadata scope.
        /// </remarks>
        [PreserveSig]
        HRESULT Map([In] mdToken tkImp, [In] mdToken tkEmit);
    }
}
