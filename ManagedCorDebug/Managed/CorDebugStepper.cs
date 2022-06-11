using System;
using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    public class CorDebugStepper : ComObject<ICorDebugStepper>
    {
        public CorDebugStepper(ICorDebugStepper raw) : base(raw)
        {
        }

        #region ICorDebugStepper
        #region IsActive

        public int IsActive
        {
            get
            {
                HRESULT hr;
                int pbActive;

                if ((hr = TryIsActive(out pbActive)) != HRESULT.S_OK)
                    Marshal.ThrowExceptionForHR((int) hr);

                return pbActive;
            }
        }

        public HRESULT TryIsActive(out int pbActive)
        {
            /*HRESULT IsActive(out int pbActive);*/
            return Raw.IsActive(out pbActive);
        }

        #endregion
        #region Deactivate

        public void Deactivate()
        {
            HRESULT hr;

            if ((hr = TryDeactivate()) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        public HRESULT TryDeactivate()
        {
            /*HRESULT Deactivate();*/
            return Raw.Deactivate();
        }

        #endregion
        #region SetInterceptMask

        public void SetInterceptMask(CorDebugIntercept mask)
        {
            HRESULT hr;

            if ((hr = TrySetInterceptMask(mask)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        public HRESULT TrySetInterceptMask(CorDebugIntercept mask)
        {
            /*HRESULT SetInterceptMask([In] CorDebugIntercept mask);*/
            return Raw.SetInterceptMask(mask);
        }

        #endregion
        #region SetUnmappedStopMask

        public void SetUnmappedStopMask(CorDebugUnmappedStop mask)
        {
            HRESULT hr;

            if ((hr = TrySetUnmappedStopMask(mask)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        public HRESULT TrySetUnmappedStopMask(CorDebugUnmappedStop mask)
        {
            /*HRESULT SetUnmappedStopMask([In] CorDebugUnmappedStop mask);*/
            return Raw.SetUnmappedStopMask(mask);
        }

        #endregion
        #region Step

        public void Step(int bStepIn)
        {
            HRESULT hr;

            if ((hr = TryStep(bStepIn)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        public HRESULT TryStep(int bStepIn)
        {
            /*HRESULT Step([In] int bStepIn);*/
            return Raw.Step(bStepIn);
        }

        #endregion
        #region StepRange

        public void StepRange(int bStepIn, COR_DEBUG_STEP_RANGE ranges, uint cRangeCount)
        {
            HRESULT hr;

            if ((hr = TryStepRange(bStepIn, ranges, cRangeCount)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        public HRESULT TryStepRange(int bStepIn, COR_DEBUG_STEP_RANGE ranges, uint cRangeCount)
        {
            /*HRESULT StepRange([In] int bStepIn, [In] ref COR_DEBUG_STEP_RANGE ranges, [In] uint cRangeCount);*/
            return Raw.StepRange(bStepIn, ref ranges, cRangeCount);
        }

        #endregion
        #region StepOut

        public void StepOut()
        {
            HRESULT hr;

            if ((hr = TryStepOut()) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        public HRESULT TryStepOut()
        {
            /*HRESULT StepOut();*/
            return Raw.StepOut();
        }

        #endregion
        #region SetRangeIL

        public void SetRangeIL(int bIL)
        {
            HRESULT hr;

            if ((hr = TrySetRangeIL(bIL)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        public HRESULT TrySetRangeIL(int bIL)
        {
            /*HRESULT SetRangeIL([In] int bIL);*/
            return Raw.SetRangeIL(bIL);
        }

        #endregion
        #endregion
        #region ICorDebugStepper2

        public ICorDebugStepper2 Raw2 => (ICorDebugStepper2) Raw;

        #region SetJMC

        public void SetJMC(int fIsJMCStepper)
        {
            HRESULT hr;

            if ((hr = TrySetJMC(fIsJMCStepper)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        public HRESULT TrySetJMC(int fIsJMCStepper)
        {
            /*HRESULT SetJMC([In] int fIsJMCStepper);*/
            return Raw2.SetJMC(fIsJMCStepper);
        }

        #endregion
        #endregion
    }
}