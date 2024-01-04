namespace ClrDebug.DbgEng
{
    public class SvcSymbolType : ComObject<ISvcSymbolType>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SvcSymbolType"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
        public SvcSymbolType(ISvcSymbolType raw) : base(raw)
        {
        }

        #region ISvcSymbolType
        #region TypeKind

        public SvcSymbolTypeKind TypeKind
        {
            get
            {
                SvcSymbolTypeKind kind;
                TryGetTypeKind(out kind).ThrowDbgEngNotOK();

                return kind;
            }
        }

        public HRESULT TryGetTypeKind(out SvcSymbolTypeKind kind)
        {
            /*HRESULT GetTypeKind(
            [Out] out SvcSymbolTypeKind kind);*/
            return Raw.GetTypeKind(out kind);
        }

        #endregion
        #region Size

        public long Size
        {
            get
            {
                long size;
                TryGetSize(out size).ThrowDbgEngNotOK();

                return size;
            }
        }

        public HRESULT TryGetSize(out long size)
        {
            /*HRESULT GetSize(
            [Out] out long size);*/
            return Raw.GetSize(out size);
        }

        #endregion
        #region BaseType

        public SvcSymbol BaseType
        {
            get
            {
                SvcSymbol baseTypeResult;
                TryGetBaseType(out baseTypeResult).ThrowDbgEngNotOK();

                return baseTypeResult;
            }
        }

        public HRESULT TryGetBaseType(out SvcSymbol baseTypeResult)
        {
            /*HRESULT GetBaseType(
            [Out, MarshalAs(UnmanagedType.Interface)] out ISvcSymbol baseType);*/
            ISvcSymbol baseType;
            HRESULT hr = Raw.GetBaseType(out baseType);

            if (hr == HRESULT.S_OK)
                baseTypeResult = baseType == null ? null : new SvcSymbol(baseType);
            else
                baseTypeResult = default(SvcSymbol);

            return hr;
        }

        #endregion
        #region UnmodifiedType

        public SvcSymbol UnmodifiedType
        {
            get
            {
                SvcSymbol unmodifiedTypeResult;
                TryGetUnmodifiedType(out unmodifiedTypeResult).ThrowDbgEngNotOK();

                return unmodifiedTypeResult;
            }
        }

        public HRESULT TryGetUnmodifiedType(out SvcSymbol unmodifiedTypeResult)
        {
            /*HRESULT GetUnmodifiedType(
            [Out, MarshalAs(UnmanagedType.Interface)] out ISvcSymbol unmodifiedType);*/
            ISvcSymbol unmodifiedType;
            HRESULT hr = Raw.GetUnmodifiedType(out unmodifiedType);

            if (hr == HRESULT.S_OK)
                unmodifiedTypeResult = unmodifiedType == null ? null : new SvcSymbol(unmodifiedType);
            else
                unmodifiedTypeResult = default(SvcSymbol);

            return hr;
        }

        #endregion
        #region IntrinsicType

        public SvcSymbolType_GetIntrinsicTypeResult IntrinsicType
        {
            get
            {
                SvcSymbolType_GetIntrinsicTypeResult result;
                TryGetIntrinsicType(out result).ThrowDbgEngNotOK();

                return result;
            }
        }

        public HRESULT TryGetIntrinsicType(out SvcSymbolType_GetIntrinsicTypeResult result)
        {
            /*HRESULT GetIntrinsicType(
            [Out] out SvcSymbolIntrinsicKind kind,
            [Out] out int packingSize);*/
            SvcSymbolIntrinsicKind kind;
            int packingSize;
            HRESULT hr = Raw.GetIntrinsicType(out kind, out packingSize);

            if (hr == HRESULT.S_OK)
                result = new SvcSymbolType_GetIntrinsicTypeResult(kind, packingSize);
            else
                result = default(SvcSymbolType_GetIntrinsicTypeResult);

            return hr;
        }

        #endregion
        #region PointerKind

        public SvcSymbolPointerKind PointerKind
        {
            get
            {
                SvcSymbolPointerKind kind;
                TryGetPointerKind(out kind).ThrowDbgEngNotOK();

                return kind;
            }
        }

        public HRESULT TryGetPointerKind(out SvcSymbolPointerKind kind)
        {
            /*HRESULT GetPointerKind(
            [Out] out SvcSymbolPointerKind kind);*/
            return Raw.GetPointerKind(out kind);
        }

        #endregion
        #region MemberType

        public SvcSymbolType MemberType
        {
            get
            {
                SvcSymbolType memberTypeResult;
                TryGetMemberType(out memberTypeResult).ThrowDbgEngNotOK();

                return memberTypeResult;
            }
        }

        public HRESULT TryGetMemberType(out SvcSymbolType memberTypeResult)
        {
            /*HRESULT GetMemberType(
            [Out, MarshalAs(UnmanagedType.Interface)] out ISvcSymbolType memberType);*/
            ISvcSymbolType memberType;
            HRESULT hr = Raw.GetMemberType(out memberType);

            if (hr == HRESULT.S_OK)
                memberTypeResult = memberType == null ? null : new SvcSymbolType(memberType);
            else
                memberTypeResult = default(SvcSymbolType);

            return hr;
        }

        #endregion
        #region ArrayDimensionality

        public long ArrayDimensionality
        {
            get
            {
                long arrayDimensionality;
                TryGetArrayDimensionality(out arrayDimensionality).ThrowDbgEngNotOK();

                return arrayDimensionality;
            }
        }

        public HRESULT TryGetArrayDimensionality(out long arrayDimensionality)
        {
            /*HRESULT GetArrayDimensionality(
            [Out] out long arrayDimensionality);*/
            return Raw.GetArrayDimensionality(out arrayDimensionality);
        }

        #endregion
        #region ArrayHeaderSize

        public long ArrayHeaderSize
        {
            get
            {
                long arrayHeaderSize;
                TryGetArrayHeaderSize(out arrayHeaderSize).ThrowDbgEngNotOK();

                return arrayHeaderSize;
            }
        }

        public HRESULT TryGetArrayHeaderSize(out long arrayHeaderSize)
        {
            /*HRESULT GetArrayHeaderSize(
            [Out] out long arrayHeaderSize);*/
            return Raw.GetArrayHeaderSize(out arrayHeaderSize);
        }

        #endregion
        #region FunctionReturnType

        public SvcSymbol FunctionReturnType
        {
            get
            {
                SvcSymbol returnTypeResult;
                TryGetFunctionReturnType(out returnTypeResult).ThrowDbgEngNotOK();

                return returnTypeResult;
            }
        }

        public HRESULT TryGetFunctionReturnType(out SvcSymbol returnTypeResult)
        {
            /*HRESULT GetFunctionReturnType(
            [Out, MarshalAs(UnmanagedType.Interface)] out ISvcSymbol returnType);*/
            ISvcSymbol returnType;
            HRESULT hr = Raw.GetFunctionReturnType(out returnType);

            if (hr == HRESULT.S_OK)
                returnTypeResult = returnType == null ? null : new SvcSymbol(returnType);
            else
                returnTypeResult = default(SvcSymbol);

            return hr;
        }

        #endregion
        #region FunctionParameterTypeCount

        public long FunctionParameterTypeCount
        {
            get
            {
                long count;
                TryGetFunctionParameterTypeCount(out count).ThrowDbgEngNotOK();

                return count;
            }
        }

        public HRESULT TryGetFunctionParameterTypeCount(out long count)
        {
            /*HRESULT GetFunctionParameterTypeCount(
            [Out] out long count);*/
            return Raw.GetFunctionParameterTypeCount(out count);
        }

        #endregion
        #region GetArrayDimensions

        public SvcSymbolArrayDimension[] GetArrayDimensions(long dimensions)
        {
            SvcSymbolArrayDimension[] pDimensions;
            TryGetArrayDimensions(dimensions, out pDimensions).ThrowDbgEngNotOK();

            return pDimensions;
        }

        public HRESULT TryGetArrayDimensions(long dimensions, out SvcSymbolArrayDimension[] pDimensions)
        {
            /*HRESULT GetArrayDimensions(
            [In] long dimensions,
            [SRI.Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] SvcSymbolArrayDimension[] pDimensions);*/
            pDimensions = new SvcSymbolArrayDimension[(int) dimensions];
            HRESULT hr = Raw.GetArrayDimensions(dimensions, pDimensions);

            return hr;
        }

        #endregion
        #region GetFunctionParameterTypeAt

        public SvcSymbol GetFunctionParameterTypeAt(long i)
        {
            SvcSymbol parameterTypeResult;
            TryGetFunctionParameterTypeAt(i, out parameterTypeResult).ThrowDbgEngNotOK();

            return parameterTypeResult;
        }

        public HRESULT TryGetFunctionParameterTypeAt(long i, out SvcSymbol parameterTypeResult)
        {
            /*HRESULT GetFunctionParameterTypeAt(
            [In] long i,
            [Out, MarshalAs(UnmanagedType.Interface)] out ISvcSymbol parameterType);*/
            ISvcSymbol parameterType;
            HRESULT hr = Raw.GetFunctionParameterTypeAt(i, out parameterType);

            if (hr == HRESULT.S_OK)
                parameterTypeResult = parameterType == null ? null : new SvcSymbol(parameterType);
            else
                parameterTypeResult = default(SvcSymbol);

            return hr;
        }

        #endregion
        #endregion
    }
}
