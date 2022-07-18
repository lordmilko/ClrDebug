using System;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace ClrDebug.DbgEng
{
    /// <summary>
    /// Provides facilities for executing <see cref="DEBUG_REQUEST.EXT_TYPED_DATA_ANSI"/> requests.
    /// </summary>
    internal unsafe struct ExtIoctl
    {
        /// <summary>
        /// The <see cref="DebugAdvanced"/> that should be used for performing the request.
        /// </summary>
        public DebugAdvanced Advanced;

        #region Buffer

        /// <summary>
        /// The size of the buffer that will be passed to the request.
        /// The buffer will be large enough to include the <see cref="EXT_TYPED_DATA"/>,
        /// as well as optional <see cref="InputString"/> and <see cref="OutputString"/>.
        /// </summary>
        public int BufferSize;

        /// <summary>
        /// The buffer that should be passed to the request.
        /// </summary>
        public IntPtr Buffer;

        /// <summary>
        /// The buffer that should be passed to the request, casted as a pointer to an <see cref="EXT_TYPED_DATA"/> structure.
        /// </summary>
        public EXT_TYPED_DATA* Payload => (EXT_TYPED_DATA*)Buffer;

        /// <summary>
        /// Gets the current offset of the data that is trailing the <see cref="Payload"/>.
        /// </summary>
        public IntPtr ExtraData;

        #endregion

        /// <summary>
        /// The operation that should be performed in the request.
        /// </summary>
        public EXT_TDOP Operation;

        /// <summary>
        /// Flags that specify the type of memory to use in the request.
        /// </summary>
        public EXT_TDF Flags;

        #region Parameters
        #region TypedData

        /// <summary>
        /// [in] The typed data that specifies the context in which the request should be performed.
        /// </summary>
        public DEBUG_TYPED_DATA InputTypedData;

        /// <summary>
        /// [out] The typed data that was returned from the request.
        /// </summary>
        public DEBUG_TYPED_DATA OutputTypedData;

        #endregion
        #region String

        /// <summary>
        /// [in] A string that should be passed in the request. This string is placed
        /// after the end of the <see cref="EXT_TYPED_DATA"/> structure.
        /// </summary>
        public string InputString;

        /// <summary>
        /// [out] A string that receives an output string that is emitted from the request.<para/>
        /// The string will be extracted from the buffer and then assigned to <see cref="OutputString"/>.
        /// </summary>
        public string OutputString;

        /// <summary>
        /// [in] The length of the desired <see cref="OutputString"/>, including any null terminator. If this value is 0,
        /// an <see cref="OutputString"/> will not be returned.
        /// </summary>
        public int OutputStringLength;

        #endregion
        #region Number

        /// <summary>
        /// [in] A 64-bit number that should be passed in the request.
        /// </summary>
        public ulong InputNumber64;

        /// <summary>
        /// [out] A 32-bit number that may be returned from the response.
        /// </summary>
        public uint OutputNumber32;

        #endregion
        #endregion

        public void Execute() => TryExecute().ThrowDbgEngNotOk();

        public HRESULT TryExecute()
        {
            InitBufferSize();

            try
            {
                //Initialize

                InitBuffer();

                Payload->Operation = Operation;
                Payload->Flags = Flags;

                TrySetInputString();

                Payload->In64 = InputNumber64;

                TrySetOutputString();

                //Even if InputTypedData isn't set, it will all be 0's
                Payload->InData = InputTypedData;

                //Execute
                var hr = Advanced.Request().TryExtTypedDataAnsi(Buffer, BufferSize);

                if (hr != HRESULT.S_OK)
                    return hr;

                //Finalize
                OutputTypedData = Payload->OutData;
                OutputNumber32 = Payload->Out32;
                TryGetOutputString();

                return hr;
            }
            finally
            {
                FreeBuffer();
            }
        }

        private void InitBufferSize()
        {
            BufferSize = Marshal.SizeOf<EXT_TYPED_DATA>(); //472

            if (InputString != null)
                BufferSize += (InputString.Length + 1); //+1 to include a null terminator

            if (OutputStringLength > 0)
                BufferSize += OutputStringLength;
        }

        private void InitBuffer()
        {
            Buffer = Marshal.AllocHGlobal(BufferSize);

            NativeMethods.RtlZeroMemory(Buffer, BufferSize);

            ExtraData = (IntPtr)(Payload + 1);
        }

        private void TrySetInputString()
        {
            if (InputString != null)
            {
                Payload->InStrIndex = (uint)((ulong)ExtraData - (ulong)Payload);

                var bytes = Encoding.ASCII.GetBytes(InputString);

                Marshal.Copy(bytes, 0, ExtraData, bytes.Length);

                //We didn't copy in a null terminator, however since we already zeroed the memory we already have one, hence add 1 to the length to
                //skip over that terminator
                ExtraData += bytes.Length + 1;
            }
        }

        private void TrySetOutputString()
        {
            if (OutputStringLength > 0)
            {
                Payload->StrBufferIndex = (uint)((ulong)ExtraData - (ulong)Payload);
                Payload->StrBufferChars = (uint) OutputStringLength;
                ExtraData += OutputStringLength; //Null terminator is included in OutputStringLength
            }
        }

        private void TryGetOutputString()
        {
            if (OutputStringLength > 0)
            {
                var dest = new byte[OutputStringLength];
                var source = Buffer + (int)Payload->StrBufferIndex;
                Marshal.Copy(source, dest, 0, OutputStringLength);

                OutputString = Encoding.ASCII.GetString(dest.TakeWhile(v => v != '\0').ToArray());
            }
        }

        private void FreeBuffer()
        {
            if (Buffer != IntPtr.Zero)
                Marshal.FreeHGlobal(Buffer);
        }
    }
}
