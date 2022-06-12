using System;
using System.Reflection;
using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    /// <summary>
    /// A subclass of <see cref="ICorDebugHeapValue"/> that represents a single-dimensional or multi-dimensional array.
    /// </summary>
    /// <remarks>
    /// <see cref="ICorDebugArrayValue"/> supports both single-dimensional and multi-dimensional arrays.
    /// </remarks>
    public class CorDebugArrayValue : CorDebugHeapValue
    {
        public CorDebugArrayValue(ICorDebugArrayValue raw) : base(raw)
        {
        }

        #region ICorDebugArrayValue

        public new ICorDebugArrayValue Raw => (ICorDebugArrayValue) base.Raw;

        #region GetElementType

        /// <summary>
        /// Gets a value that indicates the simple type of the elements in the array.
        /// </summary>
        public CorElementType ElementType
        {
            get
            {
                HRESULT hr;
                CorElementType pType;

                if ((hr = TryGetElementType(out pType)) != HRESULT.S_OK)
                    Marshal.ThrowExceptionForHR((int) hr);

                return pType;
            }
        }

        /// <summary>
        /// Gets a value that indicates the simple type of the elements in the array.
        /// </summary>
        /// <param name="pType">[out] A pointer to a value of the <see cref="CorElementType"/> enumeration that indicates the type.</param>
        public HRESULT TryGetElementType(out CorElementType pType)
        {
            /*HRESULT GetElementType(out CorElementType pType);*/
            return Raw.GetElementType(out pType);
        }

        #endregion
        #region GetRank

        /// <summary>
        /// Gets the number of dimensions in the array.
        /// </summary>
        public int Rank
        {
            get
            {
                HRESULT hr;
                int pnRank;

                if ((hr = TryGetRank(out pnRank)) != HRESULT.S_OK)
                    Marshal.ThrowExceptionForHR((int) hr);

                return pnRank;
            }
        }

        /// <summary>
        /// Gets the number of dimensions in the array.
        /// </summary>
        /// <param name="pnRank">[out] A pointer to the number of dimensions in this <see cref="ICorDebugArrayValue"/> object.</param>
        public HRESULT TryGetRank(out int pnRank)
        {
            /*HRESULT GetRank(out int pnRank);*/
            return Raw.GetRank(out pnRank);
        }

        #endregion
        #region GetCount

        /// <summary>
        /// Gets the total number of elements in the array.
        /// </summary>
        public int Count
        {
            get
            {
                HRESULT hr;
                int pnCount;

                if ((hr = TryGetCount(out pnCount)) != HRESULT.S_OK)
                    Marshal.ThrowExceptionForHR((int) hr);

                return pnCount;
            }
        }

        /// <summary>
        /// Gets the total number of elements in the array.
        /// </summary>
        /// <param name="pnCount">[out] A pointer to the total number of elements in the array.</param>
        public HRESULT TryGetCount(out int pnCount)
        {
            /*HRESULT GetCount(out int pnCount);*/
            return Raw.GetCount(out pnCount);
        }

        #endregion
        #region GetDimensions

        /// <summary>
        /// Gets the number of elements in each dimension of this array.
        /// </summary>
        /// <param name="cdim">[in] The number of dimensions of this <see cref="ICorDebugArrayValue"/> object. This value is also the size of the dims array because its size is equal to the number of dimensions of the <see cref="ICorDebugArrayValue"/> object.</param>
        /// <returns>[out] An array of integers, each of which specifies the number of elements in a dimension in this <see cref="ICorDebugArrayValue"/> object.</returns>
        public int[] GetDimensions(int cdim)
        {
            HRESULT hr;
            int[] dimsResult;

            if ((hr = TryGetDimensions(cdim, out dimsResult)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return dimsResult;
        }

        /// <summary>
        /// Gets the number of elements in each dimension of this array.
        /// </summary>
        /// <param name="cdim">[in] The number of dimensions of this <see cref="ICorDebugArrayValue"/> object. This value is also the size of the dims array because its size is equal to the number of dimensions of the <see cref="ICorDebugArrayValue"/> object.</param>
        /// <param name="dimsResult">[out] An array of integers, each of which specifies the number of elements in a dimension in this <see cref="ICorDebugArrayValue"/> object.</param>
        public HRESULT TryGetDimensions(int cdim, out int[] dimsResult)
        {
            /*HRESULT GetDimensions([In] int cdim, [MarshalAs(UnmanagedType.LPArray), Out] int[] dims);*/
            int[] dims = null;
            HRESULT hr = Raw.GetDimensions(cdim, dims);

            if (hr == HRESULT.S_OK)
                dimsResult = dims;
            else
                dimsResult = default(int[]);

            return hr;
        }

        #endregion
        #region HasBaseIndicies

        /// <summary>
        /// Gets a value that indicates whether any dimensions of this array have a base index of non-zero.
        /// </summary>
        /// <returns>[out] A pointer to a Boolean value that is true if one or more dimensions of this <see cref="ICorDebugArrayValue"/> object have a base index of non-zero; otherwise, the Boolean value is false.</returns>
        public int HasBaseIndicies()
        {
            HRESULT hr;
            int pbHasBaseIndicies;

            if ((hr = TryHasBaseIndicies(out pbHasBaseIndicies)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return pbHasBaseIndicies;
        }

        /// <summary>
        /// Gets a value that indicates whether any dimensions of this array have a base index of non-zero.
        /// </summary>
        /// <param name="pbHasBaseIndicies">[out] A pointer to a Boolean value that is true if one or more dimensions of this <see cref="ICorDebugArrayValue"/> object have a base index of non-zero; otherwise, the Boolean value is false.</param>
        public HRESULT TryHasBaseIndicies(out int pbHasBaseIndicies)
        {
            /*HRESULT HasBaseIndicies(out int pbHasBaseIndicies);*/
            return Raw.HasBaseIndicies(out pbHasBaseIndicies);
        }

        #endregion
        #region GetBaseIndicies

        /// <summary>
        /// Gets the base index of each dimension in the array.
        /// </summary>
        /// <param name="cdim">[in] The number of dimensions of this <see cref="ICorDebugArrayValue"/> object. This value is also the size of the indicies array because its size is equal to the number of dimensions of the <see cref="ICorDebugArrayValue"/> object.</param>
        /// <returns>[out] An array of integers, each of which is the base index (that is, the starting index) of a dimension of this <see cref="ICorDebugArrayValue"/> object.</returns>
        public int[] GetBaseIndicies(int cdim)
        {
            HRESULT hr;
            int[] indiciesResult;

            if ((hr = TryGetBaseIndicies(cdim, out indiciesResult)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return indiciesResult;
        }

        /// <summary>
        /// Gets the base index of each dimension in the array.
        /// </summary>
        /// <param name="cdim">[in] The number of dimensions of this <see cref="ICorDebugArrayValue"/> object. This value is also the size of the indicies array because its size is equal to the number of dimensions of the <see cref="ICorDebugArrayValue"/> object.</param>
        /// <param name="indiciesResult">[out] An array of integers, each of which is the base index (that is, the starting index) of a dimension of this <see cref="ICorDebugArrayValue"/> object.</param>
        public HRESULT TryGetBaseIndicies(int cdim, out int[] indiciesResult)
        {
            /*HRESULT GetBaseIndicies([In] int cdim, [MarshalAs(UnmanagedType.LPArray), Out] int[] indicies);*/
            int[] indicies = null;
            HRESULT hr = Raw.GetBaseIndicies(cdim, indicies);

            if (hr == HRESULT.S_OK)
                indiciesResult = indicies;
            else
                indiciesResult = default(int[]);

            return hr;
        }

        #endregion
        #region GetElement

        /// <summary>
        /// Gets the value of the given array element.
        /// </summary>
        /// <param name="cdim">[in] The number of dimensions of this <see cref="ICorDebugArrayValue"/> object. This value is also the size of the indices array because its size is equal to the number of dimensions of the <see cref="ICorDebugArrayValue"/> object.</param>
        /// <param name="indices">[in] An array of index values, each of which specifies a position within a dimension of the <see cref="ICorDebugArrayValue"/> object.<para/>
        /// This value must not be null.</param>
        /// <returns>[out] A pointer to the address of an <see cref="ICorDebugValue"/> object that represents the value of the specified element.</returns>
        public CorDebugValue GetElement(int cdim, int indices)
        {
            HRESULT hr;
            CorDebugValue ppValueResult;

            if ((hr = TryGetElement(cdim, indices, out ppValueResult)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return ppValueResult;
        }

        /// <summary>
        /// Gets the value of the given array element.
        /// </summary>
        /// <param name="cdim">[in] The number of dimensions of this <see cref="ICorDebugArrayValue"/> object. This value is also the size of the indices array because its size is equal to the number of dimensions of the <see cref="ICorDebugArrayValue"/> object.</param>
        /// <param name="indices">[in] An array of index values, each of which specifies a position within a dimension of the <see cref="ICorDebugArrayValue"/> object.<para/>
        /// This value must not be null.</param>
        /// <param name="ppValueResult">[out] A pointer to the address of an <see cref="ICorDebugValue"/> object that represents the value of the specified element.</param>
        public HRESULT TryGetElement(int cdim, int indices, out CorDebugValue ppValueResult)
        {
            /*HRESULT GetElement(
            [In] int cdim,
            [MarshalAs(UnmanagedType.LPArray), In] int indices,
            [MarshalAs(UnmanagedType.Interface)] out ICorDebugValue ppValue);*/
            ICorDebugValue ppValue;
            HRESULT hr = Raw.GetElement(cdim, indices, out ppValue);

            if (hr == HRESULT.S_OK)
                ppValueResult = CorDebugValue.New(ppValue);
            else
                ppValueResult = default(CorDebugValue);

            return hr;
        }

        #endregion
        #region GetElementAtPosition

        /// <summary>
        /// Gets the element at the given position, treating the array as a zero-based, single-dimensional array.
        /// </summary>
        /// <param name="nPosition">[in] The position of the element to be retrieved.</param>
        /// <returns>[out] A pointer to the address of an <see cref="ICorDebugValue"/> object that represents the value of the element.</returns>
        /// <remarks>
        /// The layout of a multi-dimension array follows the C++ style of array layout.
        /// </remarks>
        public CorDebugValue GetElementAtPosition(int nPosition)
        {
            HRESULT hr;
            CorDebugValue ppValueResult;

            if ((hr = TryGetElementAtPosition(nPosition, out ppValueResult)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return ppValueResult;
        }

        /// <summary>
        /// Gets the element at the given position, treating the array as a zero-based, single-dimensional array.
        /// </summary>
        /// <param name="nPosition">[in] The position of the element to be retrieved.</param>
        /// <param name="ppValueResult">[out] A pointer to the address of an <see cref="ICorDebugValue"/> object that represents the value of the element.</param>
        /// <remarks>
        /// The layout of a multi-dimension array follows the C++ style of array layout.
        /// </remarks>
        public HRESULT TryGetElementAtPosition(int nPosition, out CorDebugValue ppValueResult)
        {
            /*HRESULT GetElementAtPosition([In] int nPosition, [MarshalAs(UnmanagedType.Interface)] out ICorDebugValue ppValue);*/
            ICorDebugValue ppValue;
            HRESULT hr = Raw.GetElementAtPosition(nPosition, out ppValue);

            if (hr == HRESULT.S_OK)
                ppValueResult = CorDebugValue.New(ppValue);
            else
                ppValueResult = default(CorDebugValue);

            return hr;
        }

        #endregion
        #endregion
    }
}