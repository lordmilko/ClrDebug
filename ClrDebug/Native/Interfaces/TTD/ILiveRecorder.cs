using System;
using System.Runtime.InteropServices;
using SRI = System.Runtime.InteropServices;
#if GENERATED_MARSHALLING
using System.Runtime.InteropServices.Marshalling;
#endif

namespace ClrDebug.TTD
{
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    [return: MarshalAs(UnmanagedType.Interface)]
    public delegate ILiveRecorder TTDMakeLiveRecorderDelegate(
        [In, MarshalAs(UnmanagedType.LPStruct)] Guid clientGuid,
        [In] IntPtr pUserData,
        [In] IntPtr userDataSizeInBytes,
        [In, MarshalAs(UnmanagedType.LPStruct)] Guid recorderGuid);

    [Guid("1173F92A-535A-4D75-A1A5-6040B589E6F5")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
#if !GENERATED_MARSHALLING
    [ComImport]
#else
    [GeneratedComInterface]
#endif
    public partial interface ILiveRecorder
    {
        // Returns false if Close() has been called.
        [PreserveSig]
        [return: MarshalAs(UnmanagedType.Bool)]
        bool IsOpen();

        // End this client's interaction with the recorder, and optionally store a final user data.
        // Possible use for this data is to precord a summary of the recording peformed.
        // Note that a recording can be ended asynchronously before releasing the client,
        // so there's no guarantee that this data will make it into the file.
        [PreserveSig]
        void Close(
            IntPtr pUserData,
            IntPtr userDataSizeInBytes); //Max size: MaxUserDataSizeInBytes

        // Retrieves the path to the file containing the recording.
        // Returns the length of the string written to pFileName.
        [PreserveSig]
        IntPtr GetFileName(
            [SRI.Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U2, SizeParamIndex = 1)] char[] pFileName,
            [In] IntPtr fileNameSize);

        // Insert in the file the current contents of memory between the two given addresses.
        // pBeginAddress is inclusive and pEndAddress is not, similar to C++ iterators.
        // If 'synchronous' is false, the function may return before the operation is complete.
        [PreserveSig]
        void DumpSnapshot(
            IntPtr pBeginAddress,
            IntPtr pEndAddress,
            [MarshalAs(UnmanagedType.Bool)] bool synchronous);

        // Insert in the file the current contents of memory of the given loaded module.
        // If 'writableOnly' is true, only writable memory will be recorded (usually the module's global data segment).
        // This operation is always synchronous, and will be complete when the function returns.
        [PreserveSig]
        void DumpModuleData(
            IntPtr module,
            [MarshalAs(UnmanagedType.Bool)] bool writableOnly);

        // Dump a snapshot of all the process heaps into the trace file.
        // This operation is always synchronous, and will be complete when the function returns.
        [PreserveSig]
        void DumpHeaps();

        // Adds an event in the trace file with some associated user data.
        // Note that the user data is technically optional if no data is given,
        // but without it there's no way to distinguish this event from any other,
        // except by its position in the recording timeline.
        // The replay engine exposes all events, and associates them to the client,
        // which is identifiable via the client GUID.
        // Possible uses for custom events:
        //  - Marking points of interest in the timeline.
        //  - Signaling actions taken by the client.
        //  - Recording some meaningful piece of metadata.
        [PreserveSig]
        void AddCustomEvent(
            CustomEventType eventType,
            CustomEventFlags eventFlags,
            IntPtr pUserData,
            IntPtr userDataSizeInBytes); //Max size: MaxUserDataSizeInBytes

        // Start recording a new island in the calling thread with the given Activity ID.
        // A throttle may be specified as a maximum count of instructions to record,
        // with InstructionCount::Max meaning no throttle.
        // If the current thread was recording already,
        // then recording will be stopped as if StopRecordingCurrentThread had been called,
        // and then started anew using the new activity ID and throttle.
        // The provided user data, if any, will be associated with the new island.
        // This operation is always synchronous, and the current thread will already be recording when the function returns.
        [PreserveSig]
        void StartRecordingCurrentThread(
            ActivityId activityId,
            InstructionCount maxInstructionsToRecord,
            IntPtr pUserData,
            IntPtr userDataSizeInBytes); //Max size: MaxUserDataSizeInBytes

        // Utility inlined overload without user data, because this should be fairly common.
        /*inline
        void StartRecordingCurrentThread(ActivityId activity, InstructionCount maxInstructionsToRecord) noexcept
        {
            return StartRecordingCurrentThread(activity, maxInstructionsToRecord, nullptr, 0);
        }*/

        // Stop recording instructions on the calling thread, ending the current island if any.
        // Returns the number of instructions that were recorded into the island.
        // If the calling thread wasn't recording because it had reached its throttle or because it was paused,
        // then the result will be the count of instructions recorded until the pause or throttle.
        // If the calling thread wasn't recording because recording never was started,
        // or because recording was already explicitly stopped via this function,
        // then the result will be InstructionCount::Zero.
        InstructionCount StopRecordingCurrentThread();

        // Query the current instruction counts relevant to the throttle.
        // If the calling thread is actively recording an island, then upon return
        // the counts returned will already be stale by some indeterminate amount.
        // Returns all InstructionCount::Zero if not within an island.
        void GetThrottleState(out ThrottleState throttleState);

        // Convenience overload to get the throttle state as a return value.
        /*inline
        ThrottleState GetThrottleState() const noexcept
        {
            ThrottleState result;
            GetThrottleState(result);
            return result;
        }*/

        // Reset the throttle as if we had called Stop and then Start again with this new throttle.
        // It returns the number of instructions that were recorded before the throttle was reset.
        // If called outside of an island, this does nothing and returns InstructionCount::Zero.
        [PreserveSig]
        InstructionCount ResetThrottle(InstructionCount maxInstructionsToRecord);

        // Raw APIs to stop and then restart the recording.
        // Useful when we want to avoid recording client code.

        // TryPauseRecording() returns true only if the thread was being actively recorded.
        // This result should be checked when calling ResumeRecording() after the client code finishes.
        // ResumeRecording() shouldn't be called if TryPauseRecording() returned false.
        [PreserveSig]
        [return: MarshalAs(UnmanagedType.Bool)]
        bool TryPauseRecording();

        // Resume recording on for the current thread if it had already been started, but recording was paused.
        // Returns true if the current thread is being recorded upon return.
        // This result is not reliable, as recording may be stopped at any time via throttling,
        // but it may be used for logging purposes.
        [PreserveSig]
        [return: MarshalAs(UnmanagedType.Bool)]
        bool ResumeRecording();

        // Check the record engine's state for the current thread.
        // If this is called while the current thread is being recorded,
        // the result might be already stale upon returning to the caller (might get throttled on the way out).
        // Even if the current thread is not being recorded, the potential existence of a global throttle
        // might switch the state from Recording or Paused to Throttled at any time, without notice.
        // Please exercise caution and use defensive programming techniques when using this function.
        [PreserveSig]
        ThreadRecordingState GetState();

        // Templates added for convenience, they all adapt to interface functions defined above:

        /*template < typename UserData >
        inline
        void Close(_In_ UserData const& userData) noexcept
        {
            return Close(&userData, sizeof(userData));
        }

        template < typename UserData >
        inline
        void AddCustomEvent(
                 CustomEventType  const type,
                 CustomEventFlags const flags,
            _In_ UserData        const& userData
        ) noexcept
        {
            return AddCustomEvent(type, flags, &userData, sizeof(userData));
        }

        template < typename UserData >
        inline
        void StartRecordingCurrentThread(
                 ActivityId       const activity,
                 InstructionCount const maxInstructionsToRecord,
            _In_ UserData        const& userData
        ) noexcept
        {
            return StartRecordingCurrentThread(activity, maxInstructionsToRecord, &userData, sizeof(userData));
        }

        // RAII helper to reliably pause emulation over a piece of code, and resume recording afterwards.
        // Note: If a client throws an exception while paused,
        // this class will automatically resume recording in the middle of the stack unwinding,
        // when the unwinder goes past the function that used it.
        // This is perfectly safe, but it might look disconcerting on replay.
        class ScopedPauseRecording
        {
        public:
            // Note: we want the emulated portion of the pause/resume sequence to be as lean as possible.
            // __forceinline expresses this intent: we'd rather not emulate the call into the constructor,
            // or the return from the destructor, when not inlined.
            __forceinline ScopedPauseRecording(_Inout_ ILiveRecorder* const pLiveRecorder) noexcept : m_pLiveRecorder(pLiveRecorder->TryPauseRecording() ? pLiveRecorder : nullptr) {}
            __forceinline ~ScopedPauseRecording() noexcept { if (m_pLiveRecorder != nullptr) { m_pLiveRecorder->ResumeRecording(); } }

            // true if the current thread was originally recording (if the destructor will resume recording).
            bool WasRecording() const noexcept { return m_pLiveRecorder != nullptr; }

            // No copying or moving. Just pure RAII.
            ScopedPauseRecording           (ScopedPauseRecording const&) = delete;
            ScopedPauseRecording           (ScopedPauseRecording&&)      = delete;
            ScopedPauseRecording& operator=(ScopedPauseRecording const&) = delete;
            ScopedPauseRecording& operator=(ScopedPauseRecording&&)      = delete;

        private:
            ILiveRecorder* m_pLiveRecorder; // Set to nullptr if recording was off, so we won't resume.
        };*/
    }
}
