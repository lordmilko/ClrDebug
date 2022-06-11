using System;
using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    public class MetaDataFilter : ComObject<IMetaDataFilter>
    {
        public MetaDataFilter(IMetaDataFilter raw) : base(raw)
        {
        }

        #region IMetaDataFilter
        #region UnmarkAll

        public void UnmarkAll()
        {
            HRESULT hr;

            if ((hr = TryUnmarkAll()) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        public HRESULT TryUnmarkAll()
        {
            /*HRESULT UnmarkAll();*/
            return Raw.UnmarkAll();
        }

        #endregion
        #region MarkToken

        public void MarkToken(mdToken tk)
        {
            HRESULT hr;

            if ((hr = TryMarkToken(tk)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        public HRESULT TryMarkToken(mdToken tk)
        {
            /*HRESULT MarkToken(mdToken tk);*/
            return Raw.MarkToken(tk);
        }

        #endregion
        #region IsTokenMarked

        public int IsTokenMarked(mdToken tk)
        {
            HRESULT hr;
            int pIsMarked;

            if ((hr = TryIsTokenMarked(tk, out pIsMarked)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return pIsMarked;
        }

        public HRESULT TryIsTokenMarked(mdToken tk, out int pIsMarked)
        {
            /*HRESULT IsTokenMarked([In] mdToken tk, [Out] out int pIsMarked);*/
            return Raw.IsTokenMarked(tk, out pIsMarked);
        }

        #endregion
        #endregion
    }
}