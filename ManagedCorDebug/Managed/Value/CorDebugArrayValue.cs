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
        public uint Rank
        {
            get
            {
                HRESULT hr;
                uint pnRank;

                if ((hr = TryGetRank(out pnRank)) != HRESULT.S_OK)
                    Marshal.ThrowExceptionForHR((int) hr);

                return pnRank;
            }
        }

        /// <summary>
        /// Gets the number of dimensions in the array.
        /// </summary>
        /// <param name="pnRank">[out] A pointer to the number of dimensions in this <see cref="ICorDebugArrayValue"/> object.</param>
        public HRESULT TryGetRank(out uint pnRank)
        {
            /*HRESULT GetRank(out uint pnRank);*/
            return Raw.GetRank(out pnRank);
        }

        #endregion
        #region GetCount

        /// <summary>
        /// Gets the total number of elements in the array.
        /// </summary>
        public uint Count
        {
            get
            {
                HRESULT hr;
                uint pnCount;

                if ((hr = TryGetCount(out pnCount)) != HRESULT.S_OK)
                    Marshal.ThrowExceptionForHR((int) hr);

                return pnCount;
            }
        }

        /// <summary>
        /// Gets the total number of elements in the array.
        /// </summary>
        /// <param name="pnCount">[out] A pointer to the total number of elements in the array.</param>
        public HRESULT TryGetCount(out uint pnCount)
        {
            /*HRESULT GetCount(out uint pnCount);*/
            return Raw.GetCount(out pnCount);
        }

        #endregion
        #region GetDimensions

        /// <summary>
        /// Gets the number of elements in each dimension of this array.
        /// </summary>
        /// <param name="cdim">[in] The number of dimensions of this <see cref="ICorDebugArrayValue"/> object. This value is also the size of the dims array because its size is equal to the number of dimensions of the <see cref="ICorDebugArrayValue"/> object.</param>
        /// <returns>[out] An array of integers, each of which specifies the number of elements in a dimension in this <see cref="ICorDebugArrayValue"/> object.</returns>
        public uint[] GetDimensions(uint cdim)
        {
            HRESULT hr;
            uint[] dimsResult;

            if ((hr = TryGetDimensions(cdim, out dimsResult)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return dimsResult;
        }

        /// <summary>
        /// Gets the number of elements in each dimension of this array.
        /// </summary>
        /// <param name="cdim">[in] The number of dimensions of this <see cref="ICorDebugArrayValue"/> object. This value is also the size of the dims array because its size is equal to the number of dimensions of the <see cref="ICorDebugArrayValue"/> object.</param>
        /// <param name="dimsResult">[out] An array of integers, each of which specifies the number of elements in a dimension in this <see cref="ICorDebugArrayValue"/> object.</param>
        public HRESULT TryGetDimensions(uint cdim, out uint[] dimsResult)
        {
            /*HRESULT GetDimensions([In] uint cdim, [MarshalAs(UnmanagedType.LPArray), Out] uint[] dims);*/
            uint[] dims = null;
            HRESULT hr = Raw.GetDimensions(cdim, dims);

            if (hr == HRESULT.S_OK)
                dimsResult = dims;
            else
                dimsResult = default(uint[]);

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
        public uint[] GetBaseIndicies(uint cdim)
        {
            HRESULT hr;
            uint[] indiciesResult;

            if ((hr = TryGetBaseIndicies(cdim, out indiciesResult)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return indiciesResult;
        }

        /// <summary>
        /// Gets the base index of each dimension in the array.
        /// </summary>
        /// <param name="cdim">[in] The number of dimensions of this <see cref="ICorDebugArrayValue"/> object. This value is also the size of the indicies array because its size is equal to the number of dimensions of the <see cref="ICorDebugArrayValue"/> object.</param>
        /// <param name="indiciesResult">[out] An array of integers, each of which is the base index (that is, the starting index) of a dimension of this <see cref="ICorDebugArrayValue"/> object.</param>
        public HRESULT TryGetBaseIndicies(uint cdim, out uint[] indiciesResult)
        {
            /*HRESULT GetBaseIndicies([In] uint cdim, [MarshalAs(UnmanagedType.LPArray), Out] uint[] indicies);*/
            uint[] indicies = null;
            HRESULT hr = Raw.GetBaseIndicies(cdim, indicies);

            if (hr == HRESULT.S_OK)
                indiciesResult = indicies;
            else
                indiciesResult = default(uint[]);

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
        public CorDebugValue GetElement(uint cdim, uint indices)
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
        public HRESULT TryGetElement(uint cdim, uint indices, out CorDebugValue ppValueResult)
        {
            /*HRESULT GetElement(
            [In] uint cdim,
            [MarshalAs(UnmanagedType.LPArray), In] uint indices,
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
        public CorDebugValue GetElementAtPosition(uint nPosition)
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
        public HRESULT TryGetElementAtPosition(uint nPosition, out CorDebugValue ppValueResult)
        {
            /*HRESULT GetElementAtPosition([In] uint nPosition, [MarshalAs(UnmanagedType.Interface)] out ICorDebugValue ppValue);*/
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