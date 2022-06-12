using System;
using System.Runtime.InteropServices;
using System.Text;

namespace ManagedCorDebug
{
    /// <summary>
    /// Retrieves the debug symbol information for a variable.
    /// </summary>
    public class CorDebugVariableSymbol : ComObject<ICorDebugVariableSymbol>
    {
        public CorDebugVariableSymbol(ICorDebugVariableSymbol raw) : base(raw)
        {
        }

        #region ICorDebugVariableSymbol
        #region GetSize

        /// <summary>
        /// Gets the size of a variable in bytes.
        /// </summary>
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

        /// <summary>
        /// Gets the size of a variable in bytes.
        /// </summary>
        /// <param name="pcbValue">A pointer to a 32-bit unsigned integer containing the size of the variable.</param>
        public HRESULT TryGetSize(out uint pcbValue)
        {
            /*HRESULT GetSize(out uint pcbValue);*/
            return Raw.GetSize(out pcbValue);
        }

        #endregion
        #region GetSlotIndex

        /// <summary>
        /// Gets the managed slot index of a local variable.
        /// </summary>
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

        /// <summary>
        /// Gets the managed slot index of a local variable.
        /// </summary>
        /// <param name="pSlotIndex">[out] A pointer to the local variable's slot index.</param>
        /// <returns>S_OK if successful. E_FAIL if the variable is a function argument.</returns>
        /// <remarks>
        /// The managed slot index of a local variable can be used to retrieve the variable's metadata information
        /// </remarks>
        public HRESULT TryGetSlotIndex(out uint pSlotIndex)
        {
            /*HRESULT GetSlotIndex(out uint pSlotIndex);*/
            return Raw.GetSlotIndex(out pSlotIndex);
        }

        #endregion
        #region GetName

        /// <summary>
        /// Gets the name of a variable.
        /// </summary>
        /// <returns>A pointer to a character array that contains the variable name.</returns>
        public string GetName()
        {
            HRESULT hr;
            string szNameResult;

            if ((hr = TryGetName(out szNameResult)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return szNameResult;
        }

        /// <summary>
        /// Gets the name of a variable.
        /// </summary>
        /// <param name="szNameResult">A pointer to a character array that contains the variable name.</param>
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

        /// <summary>
        /// Gets the value of a variable as a byte array.
        /// </summary>
        /// <param name="offset">[in] The starting offset in the variable from which to read the value. This parameter is used when reading member fields in an object.</param>
        /// <param name="cbContext">[in] The size in bytes of the context argument.</param>
        /// <param name="context">[in] The thread context used to read the value.</param>
        /// <param name="cbValue">[in] The size in bytes of the pValue buffer.</param>
        /// <returns>The values that were emitted from the COM method.</returns>
        public GetValueResult GetValue(uint offset, uint cbContext, IntPtr context, uint cbValue)
        {
            HRESULT hr;
            GetValueResult result;

            if ((hr = TryGetValue(offset, cbContext, context, cbValue, out result)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return result;
        }

        /// <summary>
        /// Gets the value of a variable as a byte array.
        /// </summary>
        /// <param name="offset">[in] The starting offset in the variable from which to read the value. This parameter is used when reading member fields in an object.</param>
        /// <param name="cbContext">[in] The size in bytes of the context argument.</param>
        /// <param name="context">[in] The thread context used to read the value.</param>
        /// <param name="cbValue">[in] The size in bytes of the pValue buffer.</param>
        /// <param name="result">The values that were emitted from the COM method.</param>
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

        /// <summary>
        /// Assigns the value of a byte array to a variable.
        /// </summary>
        /// <param name="offset">[in] The starting offset in the variable at which to set the value. This parameter is used when writing to member fields in an object.</param>
        /// <param name="threadID">[in] The thread identifier of the thread whose context must be updated to reflect the new value.</param>
        /// <param name="cbContext">[in] The size in bytes of the thread context.</param>
        /// <param name="context">[in] The thread context used to write the value.</param>
        /// <param name="cbValue">[in] The size in bytes of the pValue buffer.</param>
        /// <param name="pValue">[in] The buffer that contains the value to set.</param>
        public void SetValue(uint offset, uint threadID, uint cbContext, IntPtr context, uint cbValue, IntPtr pValue)
        {
            HRESULT hr;

            if ((hr = TrySetValue(offset, threadID, cbContext, context, cbValue, pValue)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        /// <summary>
        /// Assigns the value of a byte array to a variable.
        /// </summary>
        /// <param name="offset">[in] The starting offset in the variable at which to set the value. This parameter is used when writing to member fields in an object.</param>
        /// <param name="threadID">[in] The thread identifier of the thread whose context must be updated to reflect the new value.</param>
        /// <param name="cbContext">[in] The size in bytes of the thread context.</param>
        /// <param name="context">[in] The thread context used to write the value.</param>
        /// <param name="cbValue">[in] The size in bytes of the pValue buffer.</param>
        /// <param name="pValue">[in] The buffer that contains the value to set.</param>
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