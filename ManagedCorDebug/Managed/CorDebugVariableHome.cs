using System;
using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    public class CorDebugVariableHome : ComObject<ICorDebugVariableHome>
    {
        public CorDebugVariableHome(ICorDebugVariableHome raw) : base(raw)
        {
        }

        #region ICorDebugVariableHome
        #region GetCode

        public CorDebugCode Code
        {
            get
            {
                HRESULT hr;
                CorDebugCode ppCodeResult;

                if ((hr = TryGetCode(out ppCodeResult)) != HRESULT.S_OK)
                    Marshal.ThrowExceptionForHR((int) hr);

                return ppCodeResult;
            }
        }

        public HRESULT TryGetCode(out CorDebugCode ppCodeResult)
        {
            /*HRESULT GetCode([MarshalAs(UnmanagedType.Interface)] out ICorDebugCode ppCode);*/
            ICorDebugCode ppCode;
            HRESULT hr = Raw.GetCode(out ppCode);

            if (hr == HRESULT.S_OK)
                ppCodeResult = new CorDebugCode(ppCode);
            else
                ppCodeResult = default(CorDebugCode);

            return hr;
        }

        #endregion
        #region GetSlotIndex

        public uint SlotIndex
        {
            get
            {
                HRESULT hr;
                uint pSlotIndex;

                if ((hr = TryGetSlotIndex(out pSlotIndex)) != HRESULT.S_OK)
                    Marshal.ThrowExceptionForHR((int) hr);

                return pSlotIndex;
            }
        }

        public HRESULT TryGetSlotIndex(out uint pSlotIndex)
        {
            /*HRESULT GetSlotIndex(out uint pSlotIndex);*/
            return Raw.GetSlotIndex(out pSlotIndex);
        }

        #endregion
        #region GetArgumentIndex

        public uint ArgumentIndex
        {
            get
            {
                HRESULT hr;
                uint pArgumentIndex;

                if ((hr = TryGetArgumentIndex(out pArgumentIndex)) != HRESULT.S_OK)
                    Marshal.ThrowExceptionForHR((int) hr);

                return pArgumentIndex;
            }
        }

        public HRESULT TryGetArgumentIndex(out uint pArgumentIndex)
        {
            /*HRESULT GetArgumentIndex(out uint pArgumentIndex);*/
            return Raw.GetArgumentIndex(out pArgumentIndex);
        }

        #endregion
        #region GetLiveRange

        public GetLiveRangeResult LiveRange
        {
            get
            {
                HRESULT hr;
                GetLiveRangeResult result;

                if ((hr = TryGetLiveRange(out result)) != HRESULT.S_OK)
                    Marshal.ThrowExceptionForHR((int) hr);

                return result;
            }
        }

        public HRESULT TryGetLiveRange(out GetLiveRangeResult result)
        {
            /*HRESULT GetLiveRange(out uint pStartOffset, out uint pEndOffset);*/
            uint pStartOffset;
            uint pEndOffset;
            HRESULT hr = Raw.GetLiveRange(out pStartOffset, out pEndOffset);

            if (hr == HRESULT.S_OK)
                result = new GetLiveRangeResult(pStartOffset, pEndOffset);
            else
                result = default(GetLiveRangeResult);

            return hr;
        }

        #endregion
        #region GetLocationType

        public VariableLocationType LocationType
        {
            get
            {
                HRESULT hr;
                VariableLocationType pLocationType;

                if ((hr = TryGetLocationType(out pLocationType)) != HRESULT.S_OK)
                    Marshal.ThrowExceptionForHR((int) hr);

                return pLocationType;
            }
        }

        public HRESULT TryGetLocationType(out VariableLocationType pLocationType)
        {
            /*HRESULT GetLocationType(out VariableLocationType pLocationType);*/
            return Raw.GetLocationType(out pLocationType);
        }

        #endregion
        #region GetRegister

        public CorDebugRegister Register
        {
            get
            {
                HRESULT hr;
                CorDebugRegister pRegister;

                if ((hr = TryGetRegister(out pRegister)) != HRESULT.S_OK)
                    Marshal.ThrowExceptionForHR((int) hr);

                return pRegister;
            }
        }

        public HRESULT TryGetRegister(out CorDebugRegister pRegister)
        {
            /*HRESULT GetRegister(out CorDebugRegister pRegister);*/
            return Raw.GetRegister(out pRegister);
        }

        #endregion
        #region GetOffset

        public int Offset
        {
            get
            {
                HRESULT hr;
                int pOffset;

                if ((hr = TryGetOffset(out pOffset)) != HRESULT.S_OK)
                    Marshal.ThrowExceptionForHR((int) hr);

                return pOffset;
            }
        }

        public HRESULT TryGetOffset(out int pOffset)
        {
            /*HRESULT GetOffset(out int pOffset);*/
            return Raw.GetOffset(out pOffset);
        }

        #endregion
        #endregion
    }
}