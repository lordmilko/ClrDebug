using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.InteropServices;
using static ClrDebug.Extensions;

namespace ClrDebug.TTD
{
    public unsafe class ThreadView
    {
        public IntPtr Raw { get; }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private ThreadViewVtbl* vtbl;

        #region GetThreadInfo

        //TTD::Replay::ExecutionState::GetThreadInfo(void)

        [EditorBrowsable(EditorBrowsableState.Never)]
        public delegate ThreadInfo* GetThreadInfoDelegate(
            [In] IntPtr @this);

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private GetThreadInfoDelegate getThreadInfo;

        public ThreadInfo ThreadInfo
        {
            get
            {
                InitDelegate(ref getThreadInfo, vtbl->GetThreadInfo);

                return *getThreadInfo(Raw);
            }
        }

        #endregion
        #region GetTebAddress

        //TTD::Replay::ExecutionState::GetTebAddress(void)

        [EditorBrowsable(EditorBrowsableState.Never)]
        public delegate GuestAddress GetTebAddressDelegate(
            [In] IntPtr @this);

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private GetTebAddressDelegate getTebAddress;

        public GuestAddress TebAddress
        {
            get
            {
                InitDelegate(ref getTebAddress, vtbl->GetTebAddress);

                return getTebAddress(Raw);
            }
        }

        #endregion
        #region GetPosition

        //TTD::Replay::ExecutionState::GetPosition(void)

        [EditorBrowsable(EditorBrowsableState.Never)]
        public delegate Position* GetPositionDelegate(
            [In] IntPtr @this);

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private GetPositionDelegate getPosition;

        public Position Position
        {
            get
            {
                InitDelegate(ref getPosition, vtbl->GetPosition);

                return *getPosition(Raw);
            }
        }

        #endregion
        #region GetPreviousPosition

        //TTD::Replay::ExecutionState::GetPreviousPosition(void)

        [EditorBrowsable(EditorBrowsableState.Never)]
        public delegate IntPtr GetPreviousPositionDelegate( //Can't use pointers here as this will mess up our ability to inspect detoured values when the value is null
            [In] IntPtr @this,
            [In] IntPtr position);

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private GetPreviousPositionDelegate getPreviousPosition;

        public Position? PreviousPosition //The position value is allocated by the caller, so we can't return a pointer to it
        {
            get
            {
                InitDelegate(ref getPreviousPosition, vtbl->GetPreviousPosition);

                //The symbols say it takes no arguments, but the disassembly shows its moving something into r8,
                //and it crashes if we don't have this extra parameter
                Position position;
                var result = getPreviousPosition(Raw, (IntPtr) (&position));

                if (result == default)
                    return null;

                return Marshal.PtrToStructure<Position>(result);
            }
        }

        #endregion
        #region GetProgramCounter

        //TTD::Replay::ExecutionState::GetProgramCounter(void)

        [EditorBrowsable(EditorBrowsableState.Never)]
        public delegate GuestAddress GetProgramCounterDelegate(
            [In] IntPtr @this);

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private GetProgramCounterDelegate getProgramCounter;

        public GuestAddress ProgramCounter
        {
            get
            {
                InitDelegate(ref getProgramCounter, vtbl->GetProgramCounter);

                return getProgramCounter(Raw);
            }
        }

        #endregion
        #region GetStackPointer

        //TTD::Replay::ExecutionState::GetStackPointer(void)

        [EditorBrowsable(EditorBrowsableState.Never)]
        public delegate GuestAddress GetStackPointerDelegate(
            [In] IntPtr @this);

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private GetStackPointerDelegate getStackPointer;

        public GuestAddress StackPointer
        {
            get
            {
                InitDelegate(ref getStackPointer, vtbl->GetStackPointer);

                return getStackPointer(Raw);
            }
        }

        #endregion
        #region GetFramePointer

        //TTD::Replay::ExecutionState::GetFramePointer(void)

        [EditorBrowsable(EditorBrowsableState.Never)]
        public delegate GuestAddress GetFramePointerDelegate(
            [In] IntPtr @this);

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private GetFramePointerDelegate getFramePointer;

        public GuestAddress FramePointer
        {
            get
            {
                InitDelegate(ref getFramePointer, vtbl->GetFramePointer);

                return getFramePointer(Raw);
            }
        }

        #endregion
        #region GetBasicReturnValue

        //TTD::Replay::ExecutionState::GetBasicReturnValue(void)

        [EditorBrowsable(EditorBrowsableState.Never)]
        public delegate long GetBasicReturnValueDelegate(
            [In] IntPtr @this);

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private GetBasicReturnValueDelegate getBasicReturnValue;

        public long BasicReturnValue
        {
            get
            {
                InitDelegate(ref getBasicReturnValue, vtbl->GetBasicReturnValue);

                return getBasicReturnValue(Raw);
            }
        }

        #endregion
        #region GetCrossPlatformContext

        //TTD::Replay::ExecutionState::GetCrossPlatformContext(void)

        [EditorBrowsable(EditorBrowsableState.Never)]
        public delegate IntPtr GetCrossPlatformContextDelegate(
            [In] IntPtr @this,
            [In] IntPtr buffer);

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private GetCrossPlatformContextDelegate getCrossPlatformContext;

        public IntPtr GetCrossPlatformContext(IntPtr buffer)
        {
            InitDelegate(ref getCrossPlatformContext, vtbl->GetCrossPlatformContext);

            return getCrossPlatformContext(Raw, buffer);
        }

        #endregion
        #region GetAvxExtendedContext

        //TTD::Replay::ExecutionState::GetAvxExtendedContext(void)

        [EditorBrowsable(EditorBrowsableState.Never)]
        public delegate IntPtr GetAvxExtendedContextDelegate(
            [In] IntPtr @this,
            [In] IntPtr buffer);

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private GetAvxExtendedContextDelegate getAvxExtendedContext;

        public IntPtr GetAvxExtendedContext(IntPtr buffer)
        {
            InitDelegate(ref getAvxExtendedContext, vtbl->GetAvxExtendedContext);

            return getAvxExtendedContext(Raw, buffer);
        }

        #endregion
        #region QueryMemoryRange

        //TTD::Replay::ExecutionState::QueryMemoryRange(Nirvana::GuestAddress)

        [EditorBrowsable(EditorBrowsableState.Never)]
        public delegate MemoryRange* QueryMemoryRangeDelegate(
            [In] IntPtr @this,
            [In] GuestAddress address);

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private QueryMemoryRangeDelegate queryMemoryRange;

        public MemoryRange* QueryMemoryRange(GuestAddress address)
        {
            InitDelegate(ref queryMemoryRange, vtbl->QueryMemoryRange);

            return queryMemoryRange(Raw, address);
        }

        #endregion
        #region QueryMemoryBuffer

        //TTD::Replay::ExecutionState::QueryMemoryBuffer(Nirvana::GuestAddress,TTD::TBufferView<0>)

        [EditorBrowsable(EditorBrowsableState.Never)]
        public delegate MemoryBuffer* QueryMemoryBufferDelegate(
            [In] IntPtr @this,
            [In] IntPtr resultBuffer,
            [In] GuestAddress address,
            [In] IntPtr bufferView);

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private QueryMemoryBufferDelegate queryMemoryBuffer;

        public void QueryMemoryBuffer(
            GuestAddress address,
            IntPtr buffer,
            long bytesRequested,
            out long bytesRead)
        {
            InitDelegate(ref queryMemoryBuffer, vtbl->QueryMemoryBuffer);

            TBufferView bufferView = new TBufferView
            {
                buffer = buffer,
                size = bytesRequested
            };

            //MemoryBuffer's data apparently points to the buffer we created. We're going to free that, and it's bad practice to "surprise" the caller with
            //memory to be free'd. As such, we implement a pattern similar to other ReadVirtual methods
            MemoryBuffer resultBuffer;
            var result = *queryMemoryBuffer(Raw, (IntPtr) (&resultBuffer), address, (IntPtr) (&bufferView));

            bytesRead = result.size;
        }

        #endregion
        #region QueryMemoryBufferWithRanges

        //TTD::Replay::ExecutionState::QueryMemoryBufferWithRanges(Nirvana::GuestAddress,TTD::TBufferView<0>,unsigned __int64,TTD::Replay::MemoryRange *)

        [EditorBrowsable(EditorBrowsableState.Never)]
        public delegate MemoryBufferWithRanges* QueryMemoryBufferWithRangesDelegate(
            [In] IntPtr @this,
            [In] GuestAddress address);

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private QueryMemoryBufferWithRangesDelegate queryMemoryBufferWithRanges;

        public MemoryBufferWithRanges* QueryMemoryBufferWithRanges(GuestAddress address)
        {
            InitDelegate(ref queryMemoryBufferWithRanges, vtbl->QueryMemoryBufferWithRanges);

            return queryMemoryBufferWithRanges(Raw, address);
        }

        #endregion

        public ThreadView(IntPtr raw)
        {
            if (raw == IntPtr.Zero)
                throw new ArgumentNullException(nameof(raw));

            Raw = raw;
            vtbl = *(ThreadViewVtbl**) raw;
        }
    }
}
