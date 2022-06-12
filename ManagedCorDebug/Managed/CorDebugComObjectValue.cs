using System;
using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    /// <summary>
    /// Provides methods to retrieve information associated with a runtime callable wrapper (RCW).
    /// </summary>
    /// <remarks>
    /// To check whether an instance of an "ICorDebugValue" interface represents an RCW, a debugger calls QueryInterface
    /// on "ICorDebugValue" with IID_ICorDebugComObjectValue.
    /// </remarks>
    public class CorDebugComObjectValue : ComObject<ICorDebugComObjectValue>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CorDebugComObjectValue"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
        public CorDebugComObjectValue(ICorDebugComObjectValue raw) : base(raw)
        {
        }

        #region ICorDebugComObjectValue
        #region GetCachedInterfaceTypes

        /// <summary>
        /// Provides an enumerator for the interface types that the current object has been cast to or used as.
        /// </summary>
        /// <param name="bIInspectableOnly">[in] A value that indicates whether the method returns only Windows Runtime interfaces (IInspectable interfaces) or all COM interfaces cached by the runtime callable wrapper (RCW).</param>
        /// <returns>[out] A pointer to the address of an <see cref="ICorDebugTypeEnum"/> enumerator that provides access to <see cref="ICorDebugType"/> objects that represent cached interface types filtered according to bIInspectableOnly.</returns>
        public CorDebugTypeEnum GetCachedInterfaceTypes(int bIInspectableOnly)
        {
            HRESULT hr;
            CorDebugTypeEnum ppInterfacesEnumResult;

            if ((hr = TryGetCachedInterfaceTypes(bIInspectableOnly, out ppInterfacesEnumResult)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return ppInterfacesEnumResult;
        }

        /// <summary>
        /// Provides an enumerator for the interface types that the current object has been cast to or used as.
        /// </summary>
        /// <param name="bIInspectableOnly">[in] A value that indicates whether the method returns only Windows Runtime interfaces (IInspectable interfaces) or all COM interfaces cached by the runtime callable wrapper (RCW).</param>
        /// <param name="ppInterfacesEnumResult">[out] A pointer to the address of an <see cref="ICorDebugTypeEnum"/> enumerator that provides access to <see cref="ICorDebugType"/> objects that represent cached interface types filtered according to bIInspectableOnly.</param>
        public HRESULT TryGetCachedInterfaceTypes(int bIInspectableOnly, out CorDebugTypeEnum ppInterfacesEnumResult)
        {
            /*HRESULT GetCachedInterfaceTypes([In] int bIInspectableOnly,
            [MarshalAs(UnmanagedType.Interface)] out ICorDebugTypeEnum ppInterfacesEnum);*/
            ICorDebugTypeEnum ppInterfacesEnum;
            HRESULT hr = Raw.GetCachedInterfaceTypes(bIInspectableOnly, out ppInterfacesEnum);

            if (hr == HRESULT.S_OK)
                ppInterfacesEnumResult = new CorDebugTypeEnum(ppInterfacesEnum);
            else
                ppInterfacesEnumResult = default(CorDebugTypeEnum);

            return hr;
        }

        #endregion
        #region GetCachedInterfacePointers

        /// <summary>
        /// Gets the raw interface pointers cached on the current runtime callable wrapper (RCW).
        /// </summary>
        /// <param name="bIInspectableOnly">[in] A value that indicates whether the method will return only Windows Runtime interfaces (IInspectable interfaces) or all COM interfaces that are cached by the runtime callable wrapper (RCW).</param>
        /// <param name="celt">[in] The number of objects whose addresses are to be retrieved.</param>
        /// <returns>The values that were emitted from the COM method.</returns>
        public GetCachedInterfacePointersResult GetCachedInterfacePointers(int bIInspectableOnly, int celt)
        {
            HRESULT hr;
            GetCachedInterfacePointersResult result;

            if ((hr = TryGetCachedInterfacePointers(bIInspectableOnly, celt, out result)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return result;
        }

        /// <summary>
        /// Gets the raw interface pointers cached on the current runtime callable wrapper (RCW).
        /// </summary>
        /// <param name="bIInspectableOnly">[in] A value that indicates whether the method will return only Windows Runtime interfaces (IInspectable interfaces) or all COM interfaces that are cached by the runtime callable wrapper (RCW).</param>
        /// <param name="celt">[in] The number of objects whose addresses are to be retrieved.</param>
        /// <param name="result">The values that were emitted from the COM method.</param>
        public HRESULT TryGetCachedInterfacePointers(int bIInspectableOnly, int celt, out GetCachedInterfacePointersResult result)
        {
            /*HRESULT GetCachedInterfacePointers(
            [In] int bIInspectableOnly,
            [In] int celt,
            out int pceltFetched,
            out CORDB_ADDRESS[] ptrs);*/
            int pceltFetched;
            CORDB_ADDRESS[] ptrs;
            HRESULT hr = Raw.GetCachedInterfacePointers(bIInspectableOnly, celt, out pceltFetched, out ptrs);

            if (hr == HRESULT.S_OK)
                result = new GetCachedInterfacePointersResult(pceltFetched, ptrs);
            else
                result = default(GetCachedInterfacePointersResult);

            return hr;
        }

        #endregion
        #endregion
    }
}