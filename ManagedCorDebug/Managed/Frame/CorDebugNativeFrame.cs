using System;
using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    public class CorDebugNativeFrame : CorDebugFrame
    {
        public CorDebugNativeFrame(ICorDebugNativeFrame raw) : base(raw)
        {
        }

        #region ICorDebugNativeFrame

        public new ICorDebugNativeFrame Raw => (ICorDebugNativeFrame) base.Raw;

        #region GetIP

        public uint IP
        {
            get
            {
                HRESULT hr;
                uint pnOffset;

                if ((hr = TryGetIP(out pnOffset)) != HRESULT.S_OK)
                    Marshal.ThrowExceptionForHR((int) hr);

                return pnOffset;
            }
            set
            {
                HRESULT hr;

                if ((hr = TrySetIP(value)) != HRESULT.S_OK)
                    Marshal.ThrowExceptionForHR((int) hr);
            }
        }

        public HRESULT TryGetIP(out uint pnOffset)
        {
            /*HRESULT GetIP(out uint pnOffset);*/
            return Raw.GetIP(out pnOffset);
        }

        public HRESULT TrySetIP(uint nOffset)
        {
            /*HRESULT SetIP([In] uint nOffset);*/
            return Raw.SetIP(nOffset);
        }

        #endregion
        #region GetRegisterSet

        public CorDebugRegisterSet RegisterSet
        {
            get
            {
                HRESULT hr;
                CorDebugRegisterSet ppRegistersResult;

                if ((hr = TryGetRegisterSet(out ppRegistersResult)) != HRESULT.S_OK)
                    Marshal.ThrowExceptionForHR((int) hr);

                return ppRegistersResult;
            }
        }

        public HRESULT TryGetRegisterSet(out CorDebugRegisterSet ppRegistersResult)
        {
            /*HRESULT GetRegisterSet([MarshalAs(UnmanagedType.Interface)] out ICorDebugRegisterSet ppRegisters);*/
            ICorDebugRegisterSet ppRegisters;
            HRESULT hr = Raw.GetRegisterSet(out ppRegisters);

            if (hr == HRESULT.S_OK)
                ppRegistersResult = new CorDebugRegisterSet(ppRegisters);
            else
                ppRegistersResult = default(CorDebugRegisterSet);

            return hr;
        }

        #endregion
        #region GetLocalRegisterValue

        public CorDebugValue GetLocalRegisterValue(CorDebugRegister reg, uint cbSigBlob, IntPtr pvSigBlob)
        {
            HRESULT hr;
            CorDebugValue ppValueResult;

            if ((hr = TryGetLocalRegisterValue(reg, cbSigBlob, pvSigBlob, out ppValueResult)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return ppValueResult;
        }

        public HRESULT TryGetLocalRegisterValue(CorDebugRegister reg, uint cbSigBlob, IntPtr pvSigBlob, out CorDebugValue ppValueResult)
        {
            /*HRESULT GetLocalRegisterValue(
            [In] CorDebugRegister reg,
            [In] uint cbSigBlob,
            [In] IntPtr pvSigBlob,
            [MarshalAs(UnmanagedType.Interface)] out ICorDebugValue ppValue);*/
            ICorDebugValue ppValue;
            HRESULT hr = Raw.GetLocalRegisterValue(reg, cbSigBlob, pvSigBlob, out ppValue);

            if (hr == HRESULT.S_OK)
                ppValueResult = CorDebugValue.New(ppValue);
            else
                ppValueResult = default(CorDebugValue);

            return hr;
        }

        #endregion
        #region GetLocalDoubleRegisterValue

        public CorDebugValue GetLocalDoubleRegisterValue(CorDebugRegister highWordReg, CorDebugRegister lowWordReg, uint cbSigBlob, IntPtr pvSigBlob)
        {
            HRESULT hr;
            CorDebugValue ppValueResult;

            if ((hr = TryGetLocalDoubleRegisterValue(highWordReg, lowWordReg, cbSigBlob, pvSigBlob, out ppValueResult)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return ppValueResult;
        }

        public HRESULT TryGetLocalDoubleRegisterValue(CorDebugRegister highWordReg, CorDebugRegister lowWordReg, uint cbSigBlob, IntPtr pvSigBlob, out CorDebugValue ppValueResult)
        {
            /*HRESULT GetLocalDoubleRegisterValue(
            [In] CorDebugRegister highWordReg,
            [In] CorDebugRegister lowWordReg,
            [In] uint cbSigBlob,
            [In] IntPtr pvSigBlob,
            [MarshalAs(UnmanagedType.Interface)] out ICorDebugValue ppValue);*/
            ICorDebugValue ppValue;
            HRESULT hr = Raw.GetLocalDoubleRegisterValue(highWordReg, lowWordReg, cbSigBlob, pvSigBlob, out ppValue);

            if (hr == HRESULT.S_OK)
                ppValueResult = CorDebugValue.New(ppValue);
            else
                ppValueResult = default(CorDebugValue);

            return hr;
        }

        #endregion
        #region GetLocalMemoryValue

        public CorDebugValue GetLocalMemoryValue(CORDB_ADDRESS address, uint cbSigBlob, IntPtr pvSigBlob)
        {
            HRESULT hr;
            CorDebugValue ppValueResult;

            if ((hr = TryGetLocalMemoryValue(address, cbSigBlob, pvSigBlob, out ppValueResult)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return ppValueResult;
        }

        public HRESULT TryGetLocalMemoryValue(CORDB_ADDRESS address, uint cbSigBlob, IntPtr pvSigBlob, out CorDebugValue ppValueResult)
        {
            /*HRESULT GetLocalMemoryValue(
            [In] CORDB_ADDRESS address,
            [In] uint cbSigBlob,
            [In] IntPtr pvSigBlob,
            [MarshalAs(UnmanagedType.Interface)] out ICorDebugValue ppValue);*/
            ICorDebugValue ppValue;
            HRESULT hr = Raw.GetLocalMemoryValue(address, cbSigBlob, pvSigBlob, out ppValue);

            if (hr == HRESULT.S_OK)
                ppValueResult = CorDebugValue.New(ppValue);
            else
                ppValueResult = default(CorDebugValue);

            return hr;
        }

        #endregion
        #region GetLocalRegisterMemoryValue

        public CorDebugValue GetLocalRegisterMemoryValue(CorDebugRegister highWordReg, CORDB_ADDRESS lowWordAddress, uint cbSigBlob, IntPtr pvSigBlob)
        {
            HRESULT hr;
            CorDebugValue ppValueResult;

            if ((hr = TryGetLocalRegisterMemoryValue(highWordReg, lowWordAddress, cbSigBlob, pvSigBlob, out ppValueResult)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return ppValueResult;
        }

        public HRESULT TryGetLocalRegisterMemoryValue(CorDebugRegister highWordReg, CORDB_ADDRESS lowWordAddress, uint cbSigBlob, IntPtr pvSigBlob, out CorDebugValue ppValueResult)
        {
            /*HRESULT GetLocalRegisterMemoryValue(
            [In] CorDebugRegister highWordReg,
            [In] CORDB_ADDRESS lowWordAddress,
            [In] uint cbSigBlob,
            [In] IntPtr pvSigBlob,
            [MarshalAs(UnmanagedType.Interface)] out ICorDebugValue ppValue);*/
            ICorDebugValue ppValue;
            HRESULT hr = Raw.GetLocalRegisterMemoryValue(highWordReg, lowWordAddress, cbSigBlob, pvSigBlob, out ppValue);

            if (hr == HRESULT.S_OK)
                ppValueResult = CorDebugValue.New(ppValue);
            else
                ppValueResult = default(CorDebugValue);

            return hr;
        }

        #endregion
        #region GetLocalMemoryRegisterValue

        public CorDebugValue GetLocalMemoryRegisterValue(CORDB_ADDRESS highWordAddress, CorDebugRegister lowWordRegister, uint cbSigBlob, IntPtr pvSigBlob)
        {
            HRESULT hr;
            CorDebugValue ppValueResult;

            if ((hr = TryGetLocalMemoryRegisterValue(highWordAddress, lowWordRegister, cbSigBlob, pvSigBlob, out ppValueResult)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return ppValueResult;
        }

        public HRESULT TryGetLocalMemoryRegisterValue(CORDB_ADDRESS highWordAddress, CorDebugRegister lowWordRegister, uint cbSigBlob, IntPtr pvSigBlob, out CorDebugValue ppValueResult)
        {
            /*HRESULT GetLocalMemoryRegisterValue(
            [In] CORDB_ADDRESS highWordAddress,
            [In] CorDebugRegister lowWordRegister,
            [In] uint cbSigBlob,
            [In] IntPtr pvSigBlob,
            [MarshalAs(UnmanagedType.Interface)] out ICorDebugValue ppValue);*/
            ICorDebugValue ppValue;
            HRESULT hr = Raw.GetLocalMemoryRegisterValue(highWordAddress, lowWordRegister, cbSigBlob, pvSigBlob, out ppValue);

            if (hr == HRESULT.S_OK)
                ppValueResult = CorDebugValue.New(ppValue);
            else
                ppValueResult = default(CorDebugValue);

            return hr;
        }

        #endregion
        #region CanSetIP

        public void CanSetIP(uint nOffset)
        {
            HRESULT hr;

            if ((hr = TryCanSetIP(nOffset)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        public HRESULT TryCanSetIP(uint nOffset)
        {
            /*HRESULT CanSetIP([In] uint nOffset);*/
            return Raw.CanSetIP(nOffset);
        }

        #endregion
        #endregion
        #region ICorDebugNativeFrame2

        public ICorDebugNativeFrame2 Raw2 => (ICorDebugNativeFrame2) Raw;

        #region IsChild

        public int IsChild
        {
            get
            {
                HRESULT hr;
                int pIsChild;

                if ((hr = TryIsChild(out pIsChild)) != HRESULT.S_OK)
                    Marshal.ThrowExceptionForHR((int) hr);

                return pIsChild;
            }
        }

        public HRESULT TryIsChild(out int pIsChild)
        {
            /*HRESULT IsChild(out int pIsChild);*/
            return Raw2.IsChild(out pIsChild);
        }

        #endregion
        #region GetStackParameterSize

        public uint StackParameterSize
        {
            get
            {
                HRESULT hr;
                uint pSize;

                if ((hr = TryGetStackParameterSize(out pSize)) != HRESULT.S_OK)
                    Marshal.ThrowExceptionForHR((int) hr);

                return pSize;
            }
        }

        public HRESULT TryGetStackParameterSize(out uint pSize)
        {
            /*HRESULT GetStackParameterSize(out uint pSize);*/
            return Raw2.GetStackParameterSize(out pSize);
        }

        #endregion
        #region IsMatchingParentFrame

        public int IsMatchingParentFrame(ICorDebugNativeFrame2 pPotentialParentFrame)
        {
            HRESULT hr;
            int pIsParent;

            if ((hr = TryIsMatchingParentFrame(pPotentialParentFrame, out pIsParent)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return pIsParent;
        }

        public HRESULT TryIsMatchingParentFrame(ICorDebugNativeFrame2 pPotentialParentFrame, out int pIsParent)
        {
            /*HRESULT IsMatchingParentFrame([MarshalAs(UnmanagedType.Interface), In]
            ICorDebugNativeFrame2 pPotentialParentFrame, out int pIsParent);*/
            return Raw2.IsMatchingParentFrame(pPotentialParentFrame, out pIsParent);
        }

        #endregion
        #endregion
    }
}