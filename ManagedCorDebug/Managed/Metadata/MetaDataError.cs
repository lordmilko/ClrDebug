using System;
using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    public class MetaDataError : ComObject<IMetaDataError>
    {
        public MetaDataError(IMetaDataError raw) : base(raw)
        {
        }

        #region IMetaDataError
        #region OnError

        public void OnError(HRESULT hrError, mdToken token)
        {
            HRESULT hr;

            if ((hr = TryOnError(hrError, token)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        public HRESULT TryOnError(HRESULT hrError, mdToken token)
        {
            /*HRESULT OnError(HRESULT hrError, mdToken token);*/
            return Raw.OnError(hrError, token);
        }

        #endregion
        #endregion
    }
}