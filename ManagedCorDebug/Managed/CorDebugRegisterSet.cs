using System;
using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    public class CorDebugRegisterSet : ComObject<ICorDebugRegisterSet>
    {
        public CorDebugRegisterSet(ICorDebugRegisterSet raw) : base(raw)
        {
        }

        #region ICorDebugRegisterSet
        #region GetRegistersAvailable

        public ulong RegistersAvailable
        {
            get
            {
                HRESULT hr;
                ulong pAvailable;

                if ((hr = TryGetRegistersAvailable(out pAvailable)) != HRESULT.S_OK)
                    Marshal.ThrowExceptionForHR((int) hr);

                return pAvailable;
            }
        }

        public HRESULT TryGetRegistersAvailable(out ulong pAvailable)
        {
            /*HRESULT GetRegistersAvailable(out ulong pAvailable);*/
            return Raw.GetRegistersAvailable(out pAvailable);
        }

        #endregion
        #region GetRegisters

        public CORDB_REGISTER[] GetRegisters(ulong mask, uint regCount)
        {
            HRESULT hr;
            CORDB_REGISTER[] regBufferResult;

            if ((hr = TryGetRegisters(mask, regCount, out regBufferResult)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return regBufferResult;
        }

        public HRESULT TryGetRegisters(ulong mask, uint regCount, out CORDB_REGISTER[] regBufferResult)
        {
            /*HRESULT GetRegisters([In] ulong mask, [In] uint regCount, [MarshalAs(UnmanagedType.LPArray), Out]
            CORDB_REGISTER[] regBuffer);*/
            CORDB_REGISTER[] regBuffer = null;
            HRESULT hr = Raw.GetRegisters(mask, regCount, regBuffer);

            if (hr == HRESULT.S_OK)
                regBufferResult = regBuffer;
            else
                regBufferResult = default(CORDB_REGISTER[]);

            return hr;
        }

        #endregion
        #region SetRegisters

        public void SetRegisters(ulong mask, uint regCount, IntPtr regBuffer)
        {
            HRESULT hr;

            if ((hr = TrySetRegisters(mask, regCount, regBuffer)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        public HRESULT TrySetRegisters(ulong mask, uint regCount, IntPtr regBuffer)
        {
            /*HRESULT SetRegisters([In] ulong mask, [In] uint regCount, [In] IntPtr regBuffer);*/
            return Raw.SetRegisters(mask, regCount, regBuffer);
        }

        #endregion
        #region GetThreadContext

        public byte[] GetThreadContext(uint contextSize)
        {
            HRESULT hr;
            byte[] contextResult;

            if ((hr = TryGetThreadContext(contextSize, out contextResult)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return contextResult;
        }

        public HRESULT TryGetThreadContext(uint contextSize, out byte[] contextResult)
        {
            /*HRESULT GetThreadContext([In] uint contextSize, [MarshalAs(UnmanagedType.LPArray), In, Out]
            byte[] context);*/
            byte[] context = null;
            HRESULT hr = Raw.GetThreadContext(contextSize, context);

            if (hr == HRESULT.S_OK)
                contextResult = context;
            else
                contextResult = default(byte[]);

            return hr;
        }

        #endregion
        #region SetThreadContext

        public void SetThreadContext(uint contextSize, byte[] context)
        {
            HRESULT hr;

            if ((hr = TrySetThreadContext(contextSize, context)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        public HRESULT TrySetThreadContext(uint contextSize, byte[] context)
        {
            /*HRESULT SetThreadContext([In] uint contextSize, [MarshalAs(UnmanagedType.Interface), In]
            byte[] context);*/
            return Raw.SetThreadContext(contextSize, context);
        }

        #endregion
        #endregion
        #region ICorDebugRegisterSet2

        public ICorDebugRegisterSet2 Raw2 => (ICorDebugRegisterSet2) Raw;

        #region GetRegistersAvailable

        public byte GetRegistersAvailable(uint numChunks)
        {
            HRESULT hr;
            byte availableRegChunks;

            if ((hr = TryGetRegistersAvailable(numChunks, out availableRegChunks)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return availableRegChunks;
        }

        public HRESULT TryGetRegistersAvailable(uint numChunks, out byte availableRegChunks)
        {
            /*HRESULT GetRegistersAvailable([In] uint numChunks, out byte availableRegChunks);*/
            return Raw2.GetRegistersAvailable(numChunks, out availableRegChunks);
        }

        #endregion
        #region GetRegisters

        public CORDB_REGISTER[] GetRegisters(uint maskCount, byte[] mask, uint regCount)
        {
            HRESULT hr;
            CORDB_REGISTER[] regBuffer;

            if ((hr = TryGetRegisters(maskCount, mask, regCount, out regBuffer)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return regBuffer;
        }

        public HRESULT TryGetRegisters(uint maskCount, byte[] mask, uint regCount, out CORDB_REGISTER[] regBuffer)
        {
            /*HRESULT GetRegisters([In] uint maskCount, [In] byte[] mask, [In] uint regCount, out CORDB_REGISTER[] regBuffer);*/
            return Raw2.GetRegisters(maskCount, mask, regCount, out regBuffer);
        }

        #endregion
        #region SetRegisters

        public void SetRegisters(uint maskCount, byte[] mask, uint regCount, ulong regBuffer)
        {
            HRESULT hr;

            if ((hr = TrySetRegisters(maskCount, mask, regCount, regBuffer)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        public HRESULT TrySetRegisters(uint maskCount, byte[] mask, uint regCount, ulong regBuffer)
        {
            /*HRESULT SetRegisters([In] uint maskCount, [In] byte[] mask, [In] uint regCount, [In] ref ulong regBuffer);*/
            return Raw2.SetRegisters(maskCount, mask, regCount, ref regBuffer);
        }

        #endregion
        #endregion
    }
}