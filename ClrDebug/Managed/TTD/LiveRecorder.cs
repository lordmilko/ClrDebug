using System;
using static ClrDebug.Extensions;

namespace ClrDebug.TTD
{
    public class LiveRecorder : ComObject<ILiveRecorder>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LiveRecorder"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
        public LiveRecorder(ILiveRecorder raw) : base(raw)
        {
        }

        #region ILiveRecorder
        #region IsOpen

        public bool IsOpen
        {
            get
            {
                /*bool IsOpen();*/
                return Raw.IsOpen();
            }
        }

        #endregion
        #region ThrottleState

        public ThrottleState ThrottleState
        {
            get
            {
                /*void GetThrottleState(out ThrottleState throttleState);*/
                ThrottleState throttleState;
                Raw.GetThrottleState(out throttleState);

                return throttleState;
            }
        }

        #endregion
        #region State

        public ThreadRecordingState State
        {
            get
            {
                /*ThreadRecordingState GetState();*/
                return Raw.GetState();
            }
        }

        #endregion
        #region Close

        public void Close(IntPtr pUserData, IntPtr userDataSizeInBytes)
        {
            /*void Close(
            IntPtr pUserData,
            IntPtr userDataSizeInBytes);*/
            Raw.Close(pUserData, userDataSizeInBytes);
        }

        #endregion
        #region GetFileName

        public GetFileNameResult GetFileName(IntPtr fileNameSize)
        {
            /*IntPtr GetFileName(
            [Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U2, SizeParamIndex = 1)] char[] pFileName,
            [In] IntPtr fileNameSize);*/
            char[] pFileName = new char[(int) fileNameSize];
            IntPtr val = Raw.GetFileName(pFileName, fileNameSize);

            return new GetFileNameResult(CreateString(pFileName), val);
        }

        #endregion
        #region DumpSnapshot

        public void DumpSnapshot(IntPtr pBeginAddress, IntPtr pEndAddress, bool synchronous)
        {
            /*void DumpSnapshot(
            IntPtr pBeginAddress,
            IntPtr pEndAddress,
            bool synchronous);*/
            Raw.DumpSnapshot(pBeginAddress, pEndAddress, synchronous);
        }

        #endregion
        #region DumpModuleData

        public void DumpModuleData(IntPtr module, bool writableOnly)
        {
            /*void DumpModuleData(IntPtr module, bool writableOnly);*/
            Raw.DumpModuleData(module, writableOnly);
        }

        #endregion
        #region DumpHeaps

        public void DumpHeaps()
        {
            /*void DumpHeaps();*/
            Raw.DumpHeaps();
        }

        #endregion
        #region AddCustomEvent

        public void AddCustomEvent(CustomEventType eventType, CustomEventFlags eventFlags, IntPtr pUserData, IntPtr userDataSizeInBytes)
        {
            /*void AddCustomEvent(
            CustomEventType eventType,
            CustomEventFlags eventFlags,
            IntPtr pUserData,
            IntPtr userDataSizeInBytes);*/
            Raw.AddCustomEvent(eventType, eventFlags, pUserData, userDataSizeInBytes);
        }

        #endregion
        #region StartRecordingCurrentThread

        public void StartRecordingCurrentThread(ActivityId activityId, InstructionCount maxInstructionsToRecord, IntPtr pUserData, IntPtr userDataSizeInBytes)
        {
            /*void StartRecordingCurrentThread(
            ActivityId activityId,
            InstructionCount maxInstructionsToRecord,
            IntPtr pUserData,
            IntPtr userDataSizeInBytes);*/
            Raw.StartRecordingCurrentThread(activityId, maxInstructionsToRecord, pUserData, userDataSizeInBytes);
        }

        #endregion
        #region StopRecordingCurrentThread

        public InstructionCount StopRecordingCurrentThread()
        {
            /*InstructionCount StopRecordingCurrentThread();*/
            return Raw.StopRecordingCurrentThread();
        }

        #endregion
        #region ResetThrottle

        public InstructionCount ResetThrottle(InstructionCount maxInstructionsToRecord)
        {
            /*InstructionCount ResetThrottle(InstructionCount maxInstructionsToRecord);*/
            return Raw.ResetThrottle(maxInstructionsToRecord);
        }

        #endregion
        #region TryPauseRecording

        public bool TryPauseRecording()
        {
            /*bool TryPauseRecording();*/
            return Raw.TryPauseRecording();
        }

        #endregion
        #region ResumeRecording

        public bool ResumeRecording()
        {
            /*bool ResumeRecording();*/
            return Raw.ResumeRecording();
        }

        #endregion
        #endregion
    }
}
