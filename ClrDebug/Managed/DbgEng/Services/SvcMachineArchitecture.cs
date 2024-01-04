using System;

namespace ClrDebug.DbgEng
{
    public class SvcMachineArchitecture : ComObject<ISvcMachineArchitecture>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SvcMachineArchitecture"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
        public SvcMachineArchitecture(ISvcMachineArchitecture raw) : base(raw)
        {
        }

        #region ISvcMachineArchitecture
        #region Architecture

        public int Architecture
        {
            get
            {
                /*int GetArchitecture();*/
                return Raw.GetArchitecture();
            }
        }

        #endregion
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
        #region Bitness

        public long Bitness
        {
            get
            {
                /*long GetBitness();*/
                return Raw.GetBitness();
            }
        }

        #endregion
        #region PageSize

        public long PageSize
        {
            get
            {
                /*long GetPageSize();*/
                return Raw.GetPageSize();
            }
        }

        #endregion
        #region PageShift

        public long PageShift
        {
            get
            {
                /*long GetPageShift();*/
                return Raw.GetPageShift();
            }
        }

        #endregion
        #region EnumerateRegisters

        public SvcRegisterEnumerator EnumerateRegisters(SvcContextFlags flags)
        {
            SvcRegisterEnumerator registerEnumeratorResult;
            TryEnumerateRegisters(flags, out registerEnumeratorResult).ThrowDbgEngNotOK();

            return registerEnumeratorResult;
        }

        public HRESULT TryEnumerateRegisters(SvcContextFlags flags, out SvcRegisterEnumerator registerEnumeratorResult)
        {
            /*HRESULT EnumerateRegisters(
            [In] SvcContextFlags flags,
            [Out, MarshalAs(UnmanagedType.Interface)] out ISvcRegisterEnumerator registerEnumerator);*/
            ISvcRegisterEnumerator registerEnumerator;
            HRESULT hr = Raw.EnumerateRegisters(flags, out registerEnumerator);

            if (hr == HRESULT.S_OK)
                registerEnumeratorResult = registerEnumerator == null ? null : new SvcRegisterEnumerator(registerEnumerator);
            else
                registerEnumeratorResult = default(SvcRegisterEnumerator);

            return hr;
        }

        #endregion
        #region GetRegisterInformation

        public SvcRegisterInformation GetRegisterInformation(int registerId)
        {
            SvcRegisterInformation registerInformationResult;
            TryGetRegisterInformation(registerId, out registerInformationResult).ThrowDbgEngNotOK();

            return registerInformationResult;
        }

        public HRESULT TryGetRegisterInformation(int registerId, out SvcRegisterInformation registerInformationResult)
        {
            /*HRESULT GetRegisterInformation(
            [In] int registerId,
            [Out, MarshalAs(UnmanagedType.Interface)] out ISvcRegisterInformation registerInformation);*/
            ISvcRegisterInformation registerInformation;
            HRESULT hr = Raw.GetRegisterInformation(registerId, out registerInformation);

            if (hr == HRESULT.S_OK)
                registerInformationResult = registerInformation == null ? null : new SvcRegisterInformation(registerInformation);
            else
                registerInformationResult = default(SvcRegisterInformation);

            return hr;
        }

        #endregion
        #region GetIdForAbstractRegister

        public int GetIdForAbstractRegister(SvcAbstractRegister abstractId)
        {
            int canonicalId;
            TryGetIdForAbstractRegister(abstractId, out canonicalId).ThrowDbgEngNotOK();

            return canonicalId;
        }

        public HRESULT TryGetIdForAbstractRegister(SvcAbstractRegister abstractId, out int canonicalId)
        {
            /*HRESULT GetIdForAbstractRegister(
            [In] SvcAbstractRegister abstractId,
            [Out] out int canonicalId);*/
            return Raw.GetIdForAbstractRegister(abstractId, out canonicalId);
        }

        #endregion
        #region CreateRegisterContext

        public SvcRegisterContext CreateRegisterContext()
        {
            SvcRegisterContext ppArchRegisterContextResult;
            TryCreateRegisterContext(out ppArchRegisterContextResult).ThrowDbgEngNotOK();

            return ppArchRegisterContextResult;
        }

        public HRESULT TryCreateRegisterContext(out SvcRegisterContext ppArchRegisterContextResult)
        {
            /*HRESULT CreateRegisterContext(
            [Out, MarshalAs(UnmanagedType.Interface)] out ISvcRegisterContext ppArchRegisterContext);*/
            ISvcRegisterContext ppArchRegisterContext;
            HRESULT hr = Raw.CreateRegisterContext(out ppArchRegisterContext);

            if (hr == HRESULT.S_OK)
                ppArchRegisterContextResult = ppArchRegisterContext == null ? null : new SvcRegisterContext(ppArchRegisterContext);
            else
                ppArchRegisterContextResult = default(SvcRegisterContext);

            return hr;
        }

        #endregion
        #region GetDirectoryBase

        public long GetDirectoryBase(DirectoryBaseKind dirKind, ISvcRegisterContext pSpecialContext)
        {
            /*long GetDirectoryBase(
            [In] DirectoryBaseKind dirKind,
            [In, MarshalAs(UnmanagedType.Interface)] ISvcRegisterContext pSpecialContext);*/
            return Raw.GetDirectoryBase(dirKind, pSpecialContext);
        }

        #endregion
        #region GetPagingLevels

        public void GetPagingLevels(ISvcRegisterContext pSpecialContext)
        {
            TryGetPagingLevels(pSpecialContext).ThrowDbgEngNotOK();
        }

        public HRESULT TryGetPagingLevels(ISvcRegisterContext pSpecialContext)
        {
            /*int GetPagingLevels(
            [In, MarshalAs(UnmanagedType.Interface)] ISvcRegisterContext pSpecialContext);*/
            return (HRESULT) Raw.GetPagingLevels(pSpecialContext);
        }

        #endregion
        #endregion
    }
}
