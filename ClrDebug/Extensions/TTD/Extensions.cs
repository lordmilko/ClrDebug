using System;
using System.Runtime.InteropServices;

namespace ClrDebug.TTD
{
    public delegate bool InitiateReplayEngineHandshakeDelegate(
        [In, MarshalAs(UnmanagedType.LPStr)] string Seed,
        [Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U1, SizeConst = 48)] byte[] Source);

    //Can return several error codes on failure such as 1 and 3. Error 1 relates to an invalid encoded handshake
    public delegate int CreateReplayEngineWithHandshakeDelegate(
        [In, MarshalAs(UnmanagedType.LPStr)] string EncodedHandshake,
        [Out] out IntPtr pReplayEngine,
        [In, MarshalAs(UnmanagedType.LPStruct)] Guid guid);

    public static partial class TtdExtensions
    {
        public static readonly Guid IID_IReplayEngine = new Guid("4D3420A5-37EF-4114-AE91-63D0378C84A9");
        public static readonly Guid IID_IReplayEngine_v1 = new Guid("1224C752-5361-4512-8473-95C08CD3EE1B");
        public static readonly Guid IID_IReplayEngine_v2 = new Guid("5D6C0347-C107-44C0-811C-BE6764D2856A");
        public static readonly Guid IID_IReplayEngine_v3 = new Guid("D6B41256-9C0B-4183-9BD7-88CBEED3F2F2");
        public static readonly Guid IID_IReplayEngine_v4 = new Guid("34BEE39E-87C1-417E-A8DF-D0B0354CFA9D");

        public static readonly Guid IID_ICursor = new Guid("B1D2E6AB-9052-4B72-999E-A88BA868F899");
        public static readonly Guid IID_ICursor_v1 = new Guid("70245F71-539E-4ACF-8528-806CD874B198");
        public static readonly Guid IID_ICursor_v2 = new Guid("37196CF1-B27F-43EC-A063-4913B65C6035");

        public static Cursor NewCursor(this ReplayEngine replayEngine) =>
            replayEngine.NewCursor(IID_ICursor);

        public static void StartRecordingCurrentThread(this LiveRecorder liveRecorder, uint activityId = 1) =>
            liveRecorder.StartRecordingCurrentThread(activityId, InstructionCount.Invalid, IntPtr.Zero, IntPtr.Zero);

        public static void Close(this LiveRecorder liveRecorder) =>
            liveRecorder.Close(IntPtr.Zero, IntPtr.Zero);

        #region Cursor

        public static void SeekPosition(this Cursor cursor, int percent)
        {
            var replayEngine = new ReplayEngine(cursor.UnsafeGetReplayEngine(IID_IReplayEngine));

            var min = replayEngine.FirstPosition;
            var max = replayEngine.LastPosition;

            var range = max.Sequence - min.Sequence;

            var result = (ulong) Math.Floor(((double) range) * percent / 100) + min.Sequence;

            cursor.SetPosition(result);
        }

        public static T QueryMemoryBuffer<T>(this Cursor cursor, GuestAddress address, QueryMemoryPolicy queryMemoryPolicy)
        {
            if (!TryQueryMemoryBuffer<T>(cursor, address, queryMemoryPolicy, out var result))
                throw new InvalidOperationException($"Failed to query address {address}");

            return result;
        }

        public static bool TryQueryMemoryBuffer<T>(this Cursor cursor, GuestAddress address, QueryMemoryPolicy queryMemoryPolicy, out T result)
        {
            var size = Marshal.SizeOf<T>();
            var buffer = Marshal.AllocHGlobal(size);

            try
            {
                cursor.QueryMemoryBuffer(address, buffer, size, out var bytesRead, queryMemoryPolicy);

                if (bytesRead != size)
                {
                    result = default;
                    return false;
                }

                result = Marshal.PtrToStructure<T>(buffer);
                return true;
            }
            finally
            {
                Marshal.FreeHGlobal(buffer);
            }
        }

        public static byte[] QueryMemoryBuffer(this Cursor cursor, GuestAddress address, long bytesRequested, QueryMemoryPolicy queryMemoryPolicy)
        {
            byte[] result;

            if (!TryQueryMemoryBuffer(cursor, address, bytesRequested, queryMemoryPolicy, out result))
                throw new InvalidOperationException($"Failed to query address {address}");

            return result;
        }

        public static bool TryQueryMemoryBuffer(this Cursor cursor, GuestAddress address, long bytesRequested, QueryMemoryPolicy queryMemoryPolicy, out byte[] result)
        {
            var buffer = Marshal.AllocHGlobal((int) bytesRequested);

            try
            {
                cursor.QueryMemoryBuffer(address, buffer, bytesRequested, out var bytesRead, queryMemoryPolicy);

                if (bytesRead == 0)
                {
                    result = default;
                    return false;
                }

                result = new byte[bytesRead];
                Marshal.Copy(buffer, result, 0, (int) bytesRead);

                return true;
            }
            finally
            {
                Marshal.FreeHGlobal(buffer);
            }
        }

        #endregion

        public static T QueryMemoryBuffer<T>(this ThreadView threadView, GuestAddress address)
        {
            if (!TryQueryMemoryBuffer<T>(threadView, address, out var result))
                throw new InvalidOperationException($"Failed to query address {address}");

            return result;
        }

        public static bool TryQueryMemoryBuffer<T>(this ThreadView threadView, GuestAddress address, out T result)
        {
            var size = Marshal.SizeOf<T>();
            var buffer = Marshal.AllocHGlobal(size);

            try
            {
                threadView.QueryMemoryBuffer(address, buffer, size, out var bytesRead);

                if (bytesRead != size)
                {
                    result = default;
                    return false;
                }

                result = Marshal.PtrToStructure<T>(buffer);
                return true;
            }
            finally
            {
                Marshal.FreeHGlobal(buffer);
            }
        }

        public static byte[] QueryMemoryBuffer(this ThreadView threadView, GuestAddress address, long bytesRequested)
        {
            byte[] result;

            if (!TryQueryMemoryBuffer(threadView, address, bytesRequested, out result))
                throw new InvalidOperationException($"Failed to query address {address}");

            return result;
        }

        public static bool TryQueryMemoryBuffer(this ThreadView threadView, GuestAddress address, long bytesRequested, out byte[] result)
        {
            var buffer = Marshal.AllocHGlobal((int) bytesRequested);

            try
            {
                threadView.QueryMemoryBuffer(address, buffer, bytesRequested, out var bytesRead);

                if (bytesRead == 0)
                {
                    result = default;
                    return false;
                }

                result = new byte[bytesRead];
                Marshal.Copy(buffer, result, 0, (int) bytesRead);

                return true;
            }
            finally
            {
                Marshal.FreeHGlobal(buffer);
            }
        }
    }
}
