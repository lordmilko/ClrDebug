using System.Runtime.InteropServices;
using System.Text;

namespace ManagedCorDebug
{
    /// <summary>
    /// Represents the debug symbol information for an instance field.
    /// </summary>
    /// <remarks>
    /// The <see cref="ICorDebugInstanceFieldSymbol"/> interface is used to retrieve the debug symbol information for an instance field.
    /// </remarks>
    public class CorDebugInstanceFieldSymbol : ComObject<ICorDebugInstanceFieldSymbol>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CorDebugInstanceFieldSymbol"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
        public CorDebugInstanceFieldSymbol(ICorDebugInstanceFieldSymbol raw) : base(raw)
        {
        }

        #region ICorDebugInstanceFieldSymbol
        #region Size

        /// <summary>
        /// Gets the size in bytes of the instance field.
        /// </summary>
        public int Size
        {
            get
            {
                HRESULT hr;
                int pcbSize;

                if ((hr = TryGetSize(out pcbSize)) != HRESULT.S_OK)
                    Marshal.ThrowExceptionForHR((int) hr);

                return pcbSize;
            }
        }

        /// <summary>
        /// Gets the size in bytes of the instance field.
        /// </summary>
        /// <param name="pcbSize">[out] A pointer to length of the field.</param>
        public HRESULT TryGetSize(out int pcbSize)
        {
            /*HRESULT GetSize(out int pcbSize);*/
            return Raw.GetSize(out pcbSize);
        }

        #endregion
        #region Offset

        /// <summary>
        /// Gets the offset in bytes of this instance field in its parent class.
        /// </summary>
        public int Offset
        {
            get
            {
                HRESULT hr;
                int pcbOffset;

                if ((hr = TryGetOffset(out pcbOffset)) != HRESULT.S_OK)
                    Marshal.ThrowExceptionForHR((int) hr);

                return pcbOffset;
            }
        }

        /// <summary>
        /// Gets the offset in bytes of this instance field in its parent class.
        /// </summary>
        /// <param name="pcbOffset">A pointer to the number of bytes that this instance field is offset in its parent class.</param>
        public HRESULT TryGetOffset(out int pcbOffset)
        {
            /*HRESULT GetOffset(out int pcbOffset);*/
            return Raw.GetOffset(out pcbOffset);
        }

        #endregion
        #region GetName

        /// <summary>
        /// Gets the name of the instance field.
        /// </summary>
        /// <returns>[out] A character array that stores the returned name.</returns>
        public string GetName()
        {
            HRESULT hr;
            string szNameResult;

            if ((hr = TryGetName(out szNameResult)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return szNameResult;
        }

        /// <summary>
        /// Gets the name of the instance field.
        /// </summary>
        /// <param name="szNameResult">[out] A character array that stores the returned name.</param>
        public HRESULT TryGetName(out string szNameResult)
        {
            /*HRESULT GetName([In] int cchName, out int pcchName, [Out] StringBuilder szName);*/
            int cchName = 0;
            int pcchName;
            StringBuilder szName = null;
            HRESULT hr = Raw.GetName(cchName, out pcchName, szName);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER)
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
        #endregion
    }
}