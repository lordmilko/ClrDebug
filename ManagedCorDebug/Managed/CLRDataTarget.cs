using System;
using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    public class CLRDataTarget : ComObject<ICLRDataTarget>
    {
        public CLRDataTarget(ICLRDataTarget raw) : base(raw)
        {
        }

        #region ICLRDataTarget
        #region GetMachineType

        public uint MachineType
        {
            get
            {
                HRESULT hr;
                uint machineType;

                if ((hr = TryGetMachineType(out machineType)) != HRESULT.S_OK)
                    Marshal.ThrowExceptionForHR((int) hr);

                return machineType;
            }
        }

        public HRESULT TryGetMachineType(out uint machineType)
        {
            /*HRESULT GetMachineType(out uint machineType);*/
            return Raw.GetMachineType(out machineType);
        }

        #endregion
        #region GetPointerSize

        public uint PointerSize
        {
            get
            {
                HRESULT hr;
                uint pointerSize;

                if ((hr = TryGetPointerSize(out pointerSize)) != HRESULT.S_OK)
                    Marshal.ThrowExceptionForHR((int) hr);

                return pointerSize;
            }
        }

        public HRESULT TryGetPointerSize(out uint pointerSize)
        {
            /*HRESULT GetPointerSize(out uint pointerSize);*/
            return Raw.GetPointerSize(out pointerSize);
        }

        #endregion
        #region GetCurrentThreadID

        public uint CurrentThreadID
        {
            get
            {
                HRESULT hr;
                uint threadID;

                if ((hr = TryGetCurrentThreadID(out threadID)) != HRESULT.S_OK)
                    Marshal.ThrowExceptionForHR((int) hr);

                return threadID;
            }
        }

        public HRESULT TryGetCurrentThreadID(out uint threadID)
        {
            /*HRESULT GetCurrentThreadID(out uint threadID);*/
            return Raw.GetCurrentThreadID(out threadID);
        }

        #endregion
        #region GetImageBase

        public ulong GetImageBase(string imagePath)
        {
            HRESULT hr;
            ulong baseAddress;

            if ((hr = TryGetImageBase(imagePath, out baseAddress)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return baseAddress;
        }

        public HRESULT TryGetImageBase(string imagePath, out ulong baseAddress)
        {
            /*HRESULT GetImageBase([MarshalAs(UnmanagedType.LPWStr), In] string imagePath, out ulong baseAddress);*/
            return Raw.GetImageBase(imagePath, out baseAddress);
        }

        #endregion
        #region ReadVirtual

        public ReadVirtualResult ReadVirtual(ulong address, uint bytesRequested)
        {
            HRESULT hr;
            ReadVirtualResult result;

            if ((hr = TryReadVirtual(address, bytesRequested, out result)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return result;
        }

        public HRESULT TryReadVirtual(ulong address, uint bytesRequested, out ReadVirtualResult result)
        {
            /*HRESULT ReadVirtual([In] ulong address, out byte buffer, [In] uint bytesRequested, out uint bytesRead);*/
            byte buffer;
            uint bytesRead;
            HRESULT hr = Raw.ReadVirtual(address, out buffer, bytesRequested, out bytesRead);

            if (hr == HRESULT.S_OK)
                result = new ReadVirtualResult(buffer, bytesRead);
            else
                result = default(ReadVirtualResult);

            return hr;
        }

        #endregion
        #region WriteVirtual

        public uint WriteVirtual(ulong address, IntPtr buffer, uint bytesRequested)
        {
            HRESULT hr;
            uint bytesWritten;

            if ((hr = TryWriteVirtual(address, buffer, bytesRequested, out bytesWritten)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return bytesWritten;
        }

        public HRESULT TryWriteVirtual(ulong address, IntPtr buffer, uint bytesRequested, out uint bytesWritten)
        {
            /*HRESULT WriteVirtual([In] ulong address, [In] IntPtr buffer, [In] uint bytesRequested, out uint bytesWritten);*/
            return Raw.WriteVirtual(address, buffer, bytesRequested, out bytesWritten);
        }

        #endregion
        #region GetTLSValue

        public ulong GetTLSValue(uint threadID, uint index)
        {
            HRESULT hr;
            ulong value;

            if ((hr = TryGetTLSValue(threadID, index, out value)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return value;
        }

        public HRESULT TryGetTLSValue(uint threadID, uint index, out ulong value)
        {
            /*HRESULT GetTLSValue([In] uint threadID, [In] uint index, out ulong value);*/
            return Raw.GetTLSValue(threadID, index, out value);
        }

        #endregion
        #region SetTLSValue

        public void SetTLSValue(uint threadID, uint index, ulong value)
        {
            HRESULT hr;

            if ((hr = TrySetTLSValue(threadID, index, value)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        public HRESULT TrySetTLSValue(uint threadID, uint index, ulong value)
        {
            /*HRESULT SetTLSValue([In] uint threadID, [In] uint index, [In] ulong value);*/
            return Raw.SetTLSValue(threadID, index, value);
        }

        #endregion
        #region GetThreadContext

        public byte GetThreadContext(uint threadID, uint contextFlags, uint contextSize)
        {
            HRESULT hr;
            byte context;

            if ((hr = TryGetThreadContext(threadID, contextFlags, contextSize, out context)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return context;
        }

        public HRESULT TryGetThreadContext(uint threadID, uint contextFlags, uint contextSize, out byte context)
        {
            /*HRESULT GetThreadContext([In] uint threadID, [In] uint contextFlags, [In] uint contextSize, out byte context);*/
            return Raw.GetThreadContext(threadID, contextFlags, contextSize, out context);
        }

        #endregion
        #region SetThreadContext

        public void SetThreadContext(uint threadID, uint contextSize, IntPtr context)
        {
            HRESULT hr;

            if ((hr = TrySetThreadContext(threadID, contextSize, context)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        public HRESULT TrySetThreadContext(uint threadID, uint contextSize, IntPtr context)
        {
            /*HRESULT SetThreadContext([In] uint threadID, [In] uint contextSize, [In] IntPtr context);*/
            return Raw.SetThreadContext(threadID, contextSize, context);
        }

        #endregion
        #region Request

        public byte Request(uint reqCode, uint inBufferSize, IntPtr inBuffer, uint outBufferSize)
        {
            HRESULT hr;
            byte outBuffer;

            if ((hr = TryRequest(reqCode, inBufferSize, inBuffer, outBufferSize, out outBuffer)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return outBuffer;
        }

        public HRESULT TryRequest(uint reqCode, uint inBufferSize, IntPtr inBuffer, uint outBufferSize, out byte outBuffer)
        {
            /*HRESULT Request(
            [In] uint reqCode,
            [In] uint inBufferSize,
            [In] IntPtr inBuffer,
            [In] uint outBufferSize,
            out byte outBuffer);*/
            return Raw.Request(reqCode, inBufferSize, inBuffer, outBufferSize, out outBuffer);
        }

        #endregion
        #endregion
        #region ICLRDataTarget2

        public ICLRDataTarget2 Raw2 => (ICLRDataTarget2) Raw;

        #region AllocVirtual

        public ulong AllocVirtual(ulong addr, uint size, uint typeFlags, uint protectFlags)
        {
            HRESULT hr;
            ulong virt;

            if ((hr = TryAllocVirtual(addr, size, typeFlags, protectFlags, out virt)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return virt;
        }

        public HRESULT TryAllocVirtual(ulong addr, uint size, uint typeFlags, uint protectFlags, out ulong virt)
        {
            /*HRESULT AllocVirtual([In] ulong addr, [In] uint size, [In] uint typeFlags, [In] uint protectFlags, out ulong virt);*/
            return Raw2.AllocVirtual(addr, size, typeFlags, protectFlags, out virt);
        }

        #endregion
        #region FreeVirtual

        public void FreeVirtual(ulong addr, uint size, uint typeFlags)
        {
            HRESULT hr;

            if ((hr = TryFreeVirtual(addr, size, typeFlags)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        public HRESULT TryFreeVirtual(ulong addr, uint size, uint typeFlags)
        {
            /*HRESULT FreeVirtual([In] ulong addr, [In] uint size, [In] uint typeFlags);*/
            return Raw2.FreeVirtual(addr, size, typeFlags);
        }

        #endregion
        #endregion
        #region ICLRDataTarget3

        public ICLRDataTarget3 Raw3 => (ICLRDataTarget3) Raw;

        #region GetExceptionThreadID

        public uint ExceptionThreadID
        {
            get
            {
                HRESULT hr;
                uint threadID;

                if ((hr = TryGetExceptionThreadID(out threadID)) != HRESULT.S_OK)
                    Marshal.ThrowExceptionForHR((int) hr);

                return threadID;
            }
        }

        public HRESULT TryGetExceptionThreadID(out uint threadID)
        {
            /*HRESULT GetExceptionThreadID(out uint threadID);*/
            return Raw3.GetExceptionThreadID(out threadID);
        }

        #endregion
        #region GetExceptionRecord

        public GetExceptionRecordResult GetExceptionRecord(uint bufferSize)
        {
            HRESULT hr;
            GetExceptionRecordResult result;

            if ((hr = TryGetExceptionRecord(bufferSize, out result)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return result;
        }

        public HRESULT TryGetExceptionRecord(uint bufferSize, out GetExceptionRecordResult result)
        {
            /*HRESULT GetExceptionRecord([In] uint bufferSize, out uint bufferUsed, out byte buffer);*/
            uint bufferUsed;
            byte buffer;
            HRESULT hr = Raw3.GetExceptionRecord(bufferSize, out bufferUsed, out buffer);

            if (hr == HRESULT.S_OK)
                result = new GetExceptionRecordResult(bufferUsed, buffer);
            else
                result = default(GetExceptionRecordResult);

            return hr;
        }

        #endregion
        #region GetExceptionContextRecord

        public GetExceptionContextRecordResult GetExceptionContextRecord(uint bufferSize)
        {
            HRESULT hr;
            GetExceptionContextRecordResult result;

            if ((hr = TryGetExceptionContextRecord(bufferSize, out result)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return result;
        }

        public HRESULT TryGetExceptionContextRecord(uint bufferSize, out GetExceptionContextRecordResult result)
        {
            /*HRESULT GetExceptionContextRecord([In] uint bufferSize, out uint bufferUsed, out byte buffer);*/
            uint bufferUsed;
            byte buffer;
            HRESULT hr = Raw3.GetExceptionContextRecord(bufferSize, out bufferUsed, out buffer);

            if (hr == HRESULT.S_OK)
                result = new GetExceptionContextRecordResult(bufferUsed, buffer);
            else
                result = default(GetExceptionContextRecordResult);

            return hr;
        }

        #endregion
        #endregion
    }
}