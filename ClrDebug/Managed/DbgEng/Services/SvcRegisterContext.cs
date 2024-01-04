using System;

namespace ClrDebug.DbgEng
{
    public class SvcRegisterContext : ComObject<ISvcRegisterContext>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SvcRegisterContext"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
        public SvcRegisterContext(ISvcRegisterContext raw) : base(raw)
        {
        }

        #region ISvcRegisterContext
        #region ArchitectureGuid

        public Guid ArchitectureGuid
        {
            get
            {
                Guid architecture;
                TryGetArchitectureGuid(out architecture).ThrowDbgEngNotOK();

                return architecture;
            }
        }

        public HRESULT TryGetArchitectureGuid(out Guid architecture)
        {
            /*HRESULT GetArchitectureGuid(
            [Out] out Guid architecture);*/
            return Raw.GetArchitectureGuid(out architecture);
        }

        #endregion
        #region GetRegisterValue

        public int GetRegisterValue(int registerId, IntPtr buffer, int bufferSize)
        {
            int registerSize;
            TryGetRegisterValue(registerId, buffer, bufferSize, out registerSize).ThrowDbgEngNotOK();

            return registerSize;
        }

        public HRESULT TryGetRegisterValue(int registerId, IntPtr buffer, int bufferSize, out int registerSize)
        {
            /*HRESULT GetRegisterValue(
            [In] int registerId,
            [Out] IntPtr buffer,
            [In] int bufferSize,
            [Out] out int registerSize);*/
            return Raw.GetRegisterValue(registerId, buffer, bufferSize, out registerSize);
        }

        #endregion
        #region GetRegisterValue64

        public long GetRegisterValue64(int registerId)
        {
            long pRegisterValue;
            TryGetRegisterValue64(registerId, out pRegisterValue).ThrowDbgEngNotOK();

            return pRegisterValue;
        }

        public HRESULT TryGetRegisterValue64(int registerId, out long pRegisterValue)
        {
            /*HRESULT GetRegisterValue64(
            [In] int registerId,
            [Out] out long pRegisterValue);*/
            return Raw.GetRegisterValue64(registerId, out pRegisterValue);
        }

        #endregion
        #region GetAbstractRegisterValue64

        public long GetAbstractRegisterValue64(SvcAbstractRegister abstractId)
        {
            long pRegisterValue;
            TryGetAbstractRegisterValue64(abstractId, out pRegisterValue).ThrowDbgEngNotOK();

            return pRegisterValue;
        }

        public HRESULT TryGetAbstractRegisterValue64(SvcAbstractRegister abstractId, out long pRegisterValue)
        {
            /*HRESULT GetAbstractRegisterValue64(
            [In] SvcAbstractRegister abstractId,
            [Out] out long pRegisterValue);*/
            return Raw.GetAbstractRegisterValue64(abstractId, out pRegisterValue);
        }

        #endregion
        #region SetRegisterValue

        public int SetRegisterValue(int registerId, IntPtr buffer, int bufferSize)
        {
            int registerSize;
            TrySetRegisterValue(registerId, buffer, bufferSize, out registerSize).ThrowDbgEngNotOK();

            return registerSize;
        }

        public HRESULT TrySetRegisterValue(int registerId, IntPtr buffer, int bufferSize, out int registerSize)
        {
            /*HRESULT SetRegisterValue(
            [In] int registerId,
            [In] IntPtr buffer,
            [In] int bufferSize,
            [Out] out int registerSize);*/
            return Raw.SetRegisterValue(registerId, buffer, bufferSize, out registerSize);
        }

        #endregion
        #region SetRegisterValue64

        public void SetRegisterValue64(int registerId, long registerValue)
        {
            TrySetRegisterValue64(registerId, registerValue).ThrowDbgEngNotOK();
        }

        public HRESULT TrySetRegisterValue64(int registerId, long registerValue)
        {
            /*HRESULT SetRegisterValue64(
            [In] int registerId,
            [In] long registerValue);*/
            return Raw.SetRegisterValue64(registerId, registerValue);
        }

        #endregion
        #region SetAbstractRegisterValue64

        public void SetAbstractRegisterValue64(SvcAbstractRegister abstractId, long registerValue)
        {
            TrySetAbstractRegisterValue64(abstractId, registerValue).ThrowDbgEngNotOK();
        }

        public HRESULT TrySetAbstractRegisterValue64(SvcAbstractRegister abstractId, long registerValue)
        {
            /*HRESULT SetAbstractRegisterValue64(
            [In] SvcAbstractRegister abstractId,
            [In] long registerValue);*/
            return Raw.SetAbstractRegisterValue64(abstractId, registerValue);
        }

        #endregion
        #region GetRegisterValues

        public int[] GetRegisterValues(int registerCount, RegisterInformationQuery[] pRegisters, int bufferSize, IntPtr buffer)
        {
            int[] registerSizes;
            TryGetRegisterValues(registerCount, pRegisters, bufferSize, buffer, out registerSizes).ThrowDbgEngNotOK();

            return registerSizes;
        }

        public HRESULT TryGetRegisterValues(int registerCount, RegisterInformationQuery[] pRegisters, int bufferSize, IntPtr buffer, out int[] registerSizes)
        {
            /*HRESULT GetRegisterValues(
            [In] int registerCount,
            [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] RegisterInformationQuery[] pRegisters,
            [In] int bufferSize,
            [Out] IntPtr buffer,
            [SRI.Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] int[] registerSizes);*/
            registerSizes = new int[registerCount];
            HRESULT hr = Raw.GetRegisterValues(registerCount, pRegisters, bufferSize, buffer, registerSizes);

            return hr;
        }

        #endregion
        #region SetRegisterValues

        public int[] SetRegisterValues(int registerCount, RegisterInformationQuery[] pRegisters, int bufferSize, IntPtr buffer)
        {
            int[] registerSizes;
            TrySetRegisterValues(registerCount, pRegisters, bufferSize, buffer, out registerSizes).ThrowDbgEngNotOK();

            return registerSizes;
        }

        public HRESULT TrySetRegisterValues(int registerCount, RegisterInformationQuery[] pRegisters, int bufferSize, IntPtr buffer, out int[] registerSizes)
        {
            /*HRESULT SetRegisterValues(
            [In] int registerCount,
            [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] RegisterInformationQuery[] pRegisters,
            [In] int bufferSize,
            [In] IntPtr buffer,
            [SRI.Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] int[] registerSizes);*/
            registerSizes = new int[registerCount];
            HRESULT hr = Raw.SetRegisterValues(registerCount, pRegisters, bufferSize, buffer, registerSizes);

            return hr;
        }

        #endregion
        #region SetToContext

        public void SetToContext(ISvcRegisterContext registerContext)
        {
            TrySetToContext(registerContext).ThrowDbgEngNotOK();
        }

        public HRESULT TrySetToContext(ISvcRegisterContext registerContext)
        {
            /*HRESULT SetToContext(
            [In, MarshalAs(UnmanagedType.Interface)] ISvcRegisterContext registerContext);*/
            return Raw.SetToContext(registerContext);
        }

        #endregion
        #region Duplicate

        public SvcRegisterContext Duplicate()
        {
            SvcRegisterContext duplicateContextResult;
            TryDuplicate(out duplicateContextResult).ThrowDbgEngNotOK();

            return duplicateContextResult;
        }

        public HRESULT TryDuplicate(out SvcRegisterContext duplicateContextResult)
        {
            /*HRESULT Duplicate(
            [Out, MarshalAs(UnmanagedType.Interface)] out ISvcRegisterContext duplicateContext);*/
            ISvcRegisterContext duplicateContext;
            HRESULT hr = Raw.Duplicate(out duplicateContext);

            if (hr == HRESULT.S_OK)
                duplicateContextResult = duplicateContext == null ? null : new SvcRegisterContext(duplicateContext);
            else
                duplicateContextResult = default(SvcRegisterContext);

            return hr;
        }

        #endregion
        #endregion
    }
}
