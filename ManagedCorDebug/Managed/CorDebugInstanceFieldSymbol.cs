using System;
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
        public CorDebugInstanceFieldSymbol(ICorDebugInstanceFieldSymbol raw) : base(raw)
        {
        }

        #region ICorDebugInstanceFieldSymbol
        #region GetSize

        /// <summary>
        /// Gets the size in bytes of the instance field.
        /// </summary>
        public uint Size
        {
            get
            {
                HRESULT hr;
                uint pcbSize;

                if ((hr = TryGetSize(out pcbSize)) != HRESULT.S_OK)
                    Marshal.ThrowExceptionForHR((int) hr);

                return pcbSize;
            }
        }

        /// <summary>
        /// Gets the size in bytes of the instance field.
        /// </summary>
        /// <param name="pcbSize">[out] A pointer to length of the field.</param>
        public HRESULT TryGetSize(out uint pcbSize)
        {
            /*HRESULT GetSize(out uint pcbSize);*/
            return Raw.GetSize(out pcbSize);
        }

        #endregion
        #region GetOffset

        /// <summary>
        /// Gets the offset in bytes of this instance field in its parent class.
        /// </summary>
        public uint Offset
        {
            get
            {
                HRESULT hr;
                uint pcbOffset;

                if ((hr = TryGetOffset(out pcbOffset)) != HRESULT.S_OK)
                    Marshal.ThrowExceptionForHR((int) hr);

                return pcbOffset;
            }
        }

        /// <summary>
        /// Gets the offset in bytes of this instance field in its parent class.
        /// </summary>
        /// <param name="pcbOffset">A pointer to the number of bytes that this instance field is offset in its parent class.</param>
        public HRESULT TryGetOffset(out uint pcbOffset)
        {
            /*HRESULT GetOffset(out uint pcbOffset);*/
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
        #endregion
    }
}