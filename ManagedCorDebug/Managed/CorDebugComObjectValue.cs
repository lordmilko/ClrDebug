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
        public CorDebugTypeEnum GetCachedInterfaceTypes(bool bIInspectableOnly)
        {
            CorDebugTypeEnum ppInterfacesEnumResult;
            TryGetCachedInterfaceTypes(bIInspectableOnly, out ppInterfacesEnumResult).ThrowOnNotOK();

            return ppInterfacesEnumResult;
        }

        /// <summary>
        /// Provides an enumerator for the interface types that the current object has been cast to or used as.
        /// </summary>
        /// <param name="bIInspectableOnly">[in] A value that indicates whether the method returns only Windows Runtime interfaces (IInspectable interfaces) or all COM interfaces cached by the runtime callable wrapper (RCW).</param>
        /// <param name="ppInterfacesEnumResult">[out] A pointer to the address of an <see cref="ICorDebugTypeEnum"/> enumerator that provides access to <see cref="ICorDebugType"/> objects that represent cached interface types filtered according to bIInspectableOnly.</param>
        public HRESULT TryGetCachedInterfaceTypes(bool bIInspectableOnly, out CorDebugTypeEnum ppInterfacesEnumResult)
        {
            /*HRESULT GetCachedInterfaceTypes([In] bool bIInspectableOnly,
            [Out, MarshalAs(UnmanagedType.Interface)] out ICorDebugTypeEnum ppInterfacesEnum);*/
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
        /// <returns>A pointer to the starting address of an array of <see cref="CORDB_ADDRESS"/> values that contain the addresses of cached interface objects.</returns>
        public CORDB_ADDRESS[] GetCachedInterfacePointers(bool bIInspectableOnly)
        {
            CORDB_ADDRESS[] ptrs;
            TryGetCachedInterfacePointers(bIInspectableOnly, out ptrs).ThrowOnNotOK();

            return ptrs;
        }

        /// <summary>
        /// Gets the raw interface pointers cached on the current runtime callable wrapper (RCW).
        /// </summary>
        /// <param name="bIInspectableOnly">[in] A value that indicates whether the method will return only Windows Runtime interfaces (IInspectable interfaces) or all COM interfaces that are cached by the runtime callable wrapper (RCW).</param>
        /// <param name="ptrs">A pointer to the starting address of an array of <see cref="CORDB_ADDRESS"/> values that contain the addresses of cached interface objects.</param>
        public HRESULT TryGetCachedInterfacePointers(bool bIInspectableOnly, out CORDB_ADDRESS[] ptrs)
        {
            /*HRESULT GetCachedInterfacePointers(
            [In] bool bIInspectableOnly,
            [In] int celt,
            [Out] out int pceltFetched,
            [Out, MarshalAs(UnmanagedType.LPArray)] CORDB_ADDRESS[] ptrs);*/
            int celt = 0;
            int pceltFetched;
            ptrs = null;
            HRESULT hr = Raw.GetCachedInterfacePointers(bIInspectableOnly, celt, out pceltFetched, ptrs);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER && hr != HRESULT.S_OK)
                goto fail;

            celt = pceltFetched;
            ptrs = new CORDB_ADDRESS[celt];
            hr = Raw.GetCachedInterfacePointers(bIInspectableOnly, celt, out pceltFetched, ptrs);
            fail:
            return hr;
        }

        #endregion
        #endregion
    }
}