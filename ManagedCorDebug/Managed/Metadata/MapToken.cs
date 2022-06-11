using System;
using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    public class MapToken : ComObject<IMapToken>
    {
        public MapToken(IMapToken raw) : base(raw)
        {
        }

        #region IMapToken
        #region Map

        public void Map(mdToken tkImp, mdToken tkEmit)
        {
            HRESULT hr;

            if ((hr = TryMap(tkImp, tkEmit)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        public HRESULT TryMap(mdToken tkImp, mdToken tkEmit)
        {
            /*HRESULT Map(mdToken tkImp, mdToken tkEmit);*/
            return Raw.Map(tkImp, tkEmit);
        }

        #endregion
        #endregion
    }
}