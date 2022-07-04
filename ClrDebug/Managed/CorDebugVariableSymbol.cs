using System;
using System.Text;

namespace ClrDebug
{
    /// <summary>
    /// Retrieves the debug symbol information for a variable.
    /// </summary>
    public class CorDebugVariableSymbol : ComObject<ICorDebugVariableSymbol>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CorDebugVariableSymbol"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
        public CorDebugVariableSymbol(ICorDebugVariableSymbol raw) : base(raw)
        {
        }

        #region ICorDebugVariableSymbol
        #region Name

        /// <summary>
        /// Gets the name of a variable.
        /// </summary>
        public string Name
        {
            get
            {
                string szNameResult;
                TryGetName(out szNameResult).ThrowOnNotOK();

                return szNameResult;
            }
        }

        /// <summary>
        /// Gets the name of a variable.
        /// </summary>
        /// <param name="szNameResult">A pointer to a character array that contains the variable name.</param>
        public HRESULT TryGetName(out string szNameResult)
        {
            /*HRESULT GetName([In] int cchName, [Out] out int pcchName, [Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder szName);*/
            int cchName = 0;
            int pcchName;
            StringBuilder szName = null;
            HRESULT hr = Raw.GetName(cchName, out pcchName, szName);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER && hr != HRESULT.S_OK)
                goto fail;

            cchName = pcchName;
            szName = new StringBuilder(pcchName);
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
        #region Size

        /// <summary>
        /// Gets the size of a variable in bytes.
        /// </summary>
        public int Size
        {
            get
            {
                int pcbValue;
                TryGetSize(out pcbValue).ThrowOnNotOK();

                return pcbValue;
            }
        }

        /// <summary>
        /// Gets the size of a variable in bytes.
        /// </summary>
        /// <param name="pcbValue">A pointer to a 32-bit unsigned integer containing the size of the variable.</param>
        public HRESULT TryGetSize(out int pcbValue)
        {
            /*HRESULT GetSize([Out] out int pcbValue);*/
            return Raw.GetSize(out pcbValue);
        }

        #endregion
        #region SlotIndex

        /// <summary>
        /// Gets the managed slot index of a local variable.
        /// </summary>
        public int SlotIndex
        {
            get
            {
                int pSlotIndex;
                TryGetSlotIndex(out pSlotIndex).ThrowOnNotOK();

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
        public HRESULT TryGetSlotIndex(out int pSlotIndex)
        {
            /*HRESULT GetSlotIndex([Out] out int pSlotIndex);*/
            return Raw.GetSlotIndex(out pSlotIndex);
        }

        #endregion
        #region GetValue

        /// <summary>
        /// Gets the value of a variable as a byte array.
        /// </summary>
        /// <param name="offset">[in] The starting offset in the variable from which to read the value. This parameter is used when reading member fields in an object.</param>
        /// <param name="cbContext">[in] The size in bytes of the context argument.</param>
        /// <param name="context">[in] The thread context used to read the value.</param>
        /// <returns>[out] A byte array that contains the value of the variable.</returns>
        public byte[] GetValue(int offset, int cbContext, IntPtr context)
        {
            byte[] pValue;
            TryGetValue(offset, cbContext, context, out pValue).ThrowOnNotOK();

            return pValue;
        }

        /// <summary>
        /// Gets the value of a variable as a byte array.
        /// </summary>
        /// <param name="offset">[in] The starting offset in the variable from which to read the value. This parameter is used when reading member fields in an object.</param>
        /// <param name="cbContext">[in] The size in bytes of the context argument.</param>
        /// <param name="context">[in] The thread context used to read the value.</param>
        /// <param name="pValue">[out] A byte array that contains the value of the variable.</param>
        public HRESULT TryGetValue(int offset, int cbContext, IntPtr context, out byte[] pValue)
        {
            /*HRESULT GetValue(
            [In] int offset,
            [In] int cbContext,
            [In] IntPtr context,
            [In] int cbValue,
            [Out] out int pcbValue,
            [MarshalAs(UnmanagedType.LPArray), Out] byte[] pValue);*/
            int cbValue = 0;
            int pcbValue;
            pValue = null;
            HRESULT hr = Raw.GetValue(offset, cbContext, context, cbValue, out pcbValue, pValue);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER && hr != HRESULT.S_OK)
                goto fail;

            cbValue = pcbValue;
            pValue = new byte[cbValue];
            hr = Raw.GetValue(offset, cbContext, context, cbValue, out pcbValue, pValue);
            fail:
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
        public void SetValue(int offset, int threadID, int cbContext, IntPtr context, int cbValue, IntPtr pValue)
        {
            TrySetValue(offset, threadID, cbContext, context, cbValue, pValue).ThrowOnNotOK();
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
        public HRESULT TrySetValue(int offset, int threadID, int cbContext, IntPtr context, int cbValue, IntPtr pValue)
        {
            /*HRESULT SetValue(
            [In] int offset,
            [In] int threadID,
            [In] int cbContext,
            [In] IntPtr context,
            [In] int cbValue,
            [In] IntPtr pValue);*/
            return Raw.SetValue(offset, threadID, cbContext, context, cbValue, pValue);
        }

        #endregion
        #endregion
    }
}
