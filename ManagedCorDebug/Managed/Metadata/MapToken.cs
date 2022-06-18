using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    /// <summary>
    /// Provides mapping capabilities between assemblies.
    /// </summary>
    public class MapToken : ComObject<IMapToken>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MapToken"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
        public MapToken(IMapToken raw) : base(raw)
        {
        }

        #region IMapToken
        #region Map

        /// <summary>
        /// Maps a relationship between the assemblies using metadata signatures.
        /// </summary>
        /// <param name="tkImp">[in] The metadata token that represents the imported code object.</param>
        /// <param name="tkEmit">[in] The metadata token that represents the emitted code object.</param>
        /// <remarks>
        /// When the token re-map occurs during a merge, the original token is scoped in the imported (source) metadata scope
        /// and the new token is scoped in the emitted (target) metadata scope.
        /// </remarks>
        public void Map(mdToken tkImp, mdToken tkEmit)
        {
            HRESULT hr;

            if ((hr = TryMap(tkImp, tkEmit)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        /// <summary>
        /// Maps a relationship between the assemblies using metadata signatures.
        /// </summary>
        /// <param name="tkImp">[in] The metadata token that represents the imported code object.</param>
        /// <param name="tkEmit">[in] The metadata token that represents the emitted code object.</param>
        /// <remarks>
        /// When the token re-map occurs during a merge, the original token is scoped in the imported (source) metadata scope
        /// and the new token is scoped in the emitted (target) metadata scope.
        /// </remarks>
        public HRESULT TryMap(mdToken tkImp, mdToken tkEmit)
        {
            /*HRESULT Map([In] mdToken tkImp, [In] mdToken tkEmit);*/
            return Raw.Map(tkImp, tkEmit);
        }

        #endregion
        #endregion
    }
}