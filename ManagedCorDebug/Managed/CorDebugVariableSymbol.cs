using System;
using System.Runtime.InteropServices;
using System.Text;

namespace ManagedCorDebug
{
    public class CorDebugVariableSymbol : ComObject<ICorDebugVariableSymbol>
    {
        public CorDebugVariableSymbol(ICorDebugVariableSymbol raw) : base(raw)
        {
        }

        #region ICorDebugVariableSymbol
        #region GetSize

        public uint Size
        {
            get
            {
                HRESULT hr;
                uint pcbValue;

                if ((hr = TryGetSize(out pcbValue)) != HRESULT.S_OK)
                    Marshal.ThrowExceptionForHR((int) hr);

                return pcbValue;
            }
        }

        public HRESULT TryGetSize(out uint pcbValue)
        {
            /*HRESULT GetSize(out uint pcbValue);*/
            return Raw.GetSize(out pcbValue);
        }

        #endregion
        #region GetSlotIndex

        public uint SlotIndex
        {
            get
            {
                HRESULT hr;
                uint pSlotIndex;

                if ((hr = TryGetSlotIndex(out pSlotIndex)) != HRESULT.S_OK)
                    Marshal.ThrowExceptionForHR((int) hr);

                return pSlotIndex;
            }
        }

        public HRESULT TryGetSlotIndex(out uint pSlotIndex)
        {
            /*HRESULT GetSlotIndex(out uint pSlotIndex);*/
            return Raw.GetSlotIndex(out pSlotIndex);
        }

        #endregion
        #region GetName

        public string GetName()
        {
            HRESULT hr;
            string szNameResult;

            if ((hr = TryGetName(out szNameResult)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return szNameResult;
        }

        public HRESULT TryGetName(out string szNameResult)
        {
            /*HRESULT GetName([In] uint cchName, out uint pcchName, [Out] StringBuilder szName);*/
            uint cchName = 0;
            uint pcchName;
            StringBuilder szName = null;
            HRESULT hr = Raw.GetName(cchName, out pcchName, szName);

            if (hr != HRESULT.S_FALSE)
                goto fail;

            cchName = pcchName;
            szName = new StringBuilder((int) pcchName);
            hr = Raw.GetName(cchName, out pcchName, szName);

            if (hr == HRESULT.S_OK)
            {
                szNameResult = szName.ToString();

                return hr;
            }

            fail:
            szNameResult = default(string);

            return hr;
        }

        #endregion
        #region GetValue

        public GetValueResult GetValue(uint offset, uint cbContext, IntPtr context, uint cbValue)
        {
            HRESULT hr;
            GetValueResult result;

            if ((hr = TryGetValue(offset, cbContext, context, cbValue, out result)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return result;
        }

        public HRESULT TryGetValue(uint offset, uint cbContext, IntPtr context, uint cbValue, out GetValueResult result)
        {
            /*HRESULT GetValue(
            [In] uint offset,
            [In] uint cbContext,
            [In] IntPtr context,
            [In] uint cbValue,
            out uint pcbValue,
            [MarshalAs(UnmanagedType.LPArray), Out] byte[] pValue);*/
            uint pcbValue;
            byte[] pValue = null;
            HRESULT hr = Raw.GetValue(offset, cbContext, context, cbValue, out pcbValue, pValue);

            if (hr == HRESULT.S_OK)
                result = new GetValueResult(pcbValue, pValue);
            else
                result = default(GetValueResult);

            return hr;
        }

        #endregion
        #region SetValue

        public void SetValue(uint offset, uint threadID, uint cbContext, IntPtr context, uint cbValue, IntPtr pValue)
        {
            HRESULT hr;

            if ((hr = TrySetValue(offset, threadID, cbContext, context, cbValue, pValue)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        public HRESULT TrySetValue(uint offset, uint threadID, uint cbContext, IntPtr context, uint cbValue, IntPtr pValue)
        {
            /*HRESULT SetValue(
            [In] uint offset,
            [In] uint threadID,
            [In] uint cbContext,
            [In] IntPtr context,
            [In] uint cbValue,
            [In] IntPtr pValue);*/
            return Raw.SetValue(offset, threadID, cbContext, context, cbValue, pValue);
        }

        #endregion
        #endregion
    }
}