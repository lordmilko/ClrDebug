using System.Diagnostics;

namespace ClrDebug.DbgEng
{
    public class DebugHostFunctionLocalDetails : ComObject<IDebugHostFunctionLocalDetails>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DebugHostFunctionLocalDetails"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
        public DebugHostFunctionLocalDetails(IDebugHostFunctionLocalDetails raw) : base(raw)
        {
        }

        #region IDebugHostFunctionLocalDetails
        #region Name

        public string Name
        {
            get
            {
                string name;
                TryGetName(out name).ThrowDbgEngNotOK();

                return name;
            }
        }

        public HRESULT TryGetName(out string name)
        {
            /*HRESULT GetName(
            [Out, MarshalAs(UnmanagedType.BStr)] out string name);*/
            return Raw.GetName(out name);
        }

        #endregion
        #region Type

        public DebugHostType Type
        {
            get
            {
                DebugHostType localTypeResult;
                TryGetType(out localTypeResult).ThrowDbgEngNotOK();

                return localTypeResult;
            }
        }

        public HRESULT TryGetType(out DebugHostType localTypeResult)
        {
            /*HRESULT GetType(
            [Out, MarshalAs(UnmanagedType.Interface)] out IDebugHostType localType);*/
            IDebugHostType localType;
            HRESULT hr = Raw.GetType(out localType);

            if (hr == HRESULT.S_OK)
                localTypeResult = localType == null ? null : new DebugHostType(localType);
            else
                localTypeResult = default(DebugHostType);

            return hr;
        }

        #endregion
        #region LocalKind

        public LocalKind LocalKind
        {
            get
            {
                LocalKind kind;
                TryGetLocalKind(out kind).ThrowDbgEngNotOK();

                return kind;
            }
        }

        public HRESULT TryGetLocalKind(out LocalKind kind)
        {
            /*HRESULT GetLocalKind(
            [Out] out LocalKind kind);*/
            return Raw.GetLocalKind(out kind);
        }

        #endregion
        #region ArgumentPosition

        public long ArgumentPosition
        {
            get
            {
                long argPosition;
                TryGetArgumentPosition(out argPosition).ThrowDbgEngNotOK();

                return argPosition;
            }
        }

        public HRESULT TryGetArgumentPosition(out long argPosition)
        {
            /*HRESULT GetArgumentPosition(
            [Out] out long argPosition);*/
            return Raw.GetArgumentPosition(out argPosition);
        }

        #endregion
        #region EnumerateStorage

        public DebugHostFunctionLocalStorageEnumerator EnumerateStorage()
        {
            DebugHostFunctionLocalStorageEnumerator storageEnumResult;
            TryEnumerateStorage(out storageEnumResult).ThrowDbgEngNotOK();

            return storageEnumResult;
        }

        public HRESULT TryEnumerateStorage(out DebugHostFunctionLocalStorageEnumerator storageEnumResult)
        {
            /*HRESULT EnumerateStorage(
            [Out, MarshalAs(UnmanagedType.Interface)] out IDebugHostFunctionLocalStorageEnumerator storageEnum);*/
            IDebugHostFunctionLocalStorageEnumerator storageEnum;
            HRESULT hr = Raw.EnumerateStorage(out storageEnum);

            if (hr == HRESULT.S_OK)
                storageEnumResult = storageEnum == null ? null : new DebugHostFunctionLocalStorageEnumerator(storageEnum);
            else
                storageEnumResult = default(DebugHostFunctionLocalStorageEnumerator);

            return hr;
        }

        #endregion
        #endregion
        #region IDebugHostFunctionLocalDetails2

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public IDebugHostFunctionLocalDetails2 Raw2 => (IDebugHostFunctionLocalDetails2) Raw;

        #region IsInlineScope

        public bool IsInlineScope
        {
            get
            {
                /*bool IsInlineScope();*/
                return Raw2.IsInlineScope();
            }
        }

        #endregion
        #region InlinedFunction

        public DebugHostSymbol InlinedFunction
        {
            get
            {
                DebugHostSymbol inlineFunctionResult;
                TryGetInlinedFunction(out inlineFunctionResult).ThrowDbgEngNotOK();

                return inlineFunctionResult;
            }
        }

        public HRESULT TryGetInlinedFunction(out DebugHostSymbol inlineFunctionResult)
        {
            /*HRESULT GetInlinedFunction(
            [Out, MarshalAs(UnmanagedType.Interface)] out IDebugHostSymbol inlineFunction);*/
            IDebugHostSymbol inlineFunction;
            HRESULT hr = Raw2.GetInlinedFunction(out inlineFunction);

            if (hr == HRESULT.S_OK)
                inlineFunctionResult = DebugHostSymbol.New(inlineFunction);
            else
                inlineFunctionResult = default(DebugHostSymbol);

            return hr;
        }

        #endregion
        #endregion

        /// <summary>
        /// Returns a string that represents the current object.
        /// </summary>
        /// <returns>A string that represents the current object.</returns>
        public override string ToString()
        {
            return Name;
        }
    }
}
