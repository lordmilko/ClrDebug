namespace ClrDebug.DbgEng
{
    public class SvcStackProviderPartialPhysicalFrame : ComObject<ISvcStackProviderPartialPhysicalFrame>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SvcStackProviderPartialPhysicalFrame"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
        public SvcStackProviderPartialPhysicalFrame(ISvcStackProviderPartialPhysicalFrame raw) : base(raw)
        {
        }

        #region ISvcStackProviderPartialPhysicalFrame
        #region InstructionPointer

        /// <summary>
        /// Gets the instruction pointer for this partial physical frame. This is the *MINIMUM MUST* implement for a partial physical frame.<para/>
        /// All other Get* methods within ISvcStackProviderPartialPhysicalFrame may legally return E_NOT_SET.
        /// </summary>
        public long InstructionPointer
        {
            get
            {
                long instructionPointer;
                TryGetInstructionPointer(out instructionPointer).ThrowDbgEngNotOK();

                return instructionPointer;
            }
        }

        /// <summary>
        /// Gets the instruction pointer for this partial physical frame. This is the *MINIMUM MUST* implement for a partial physical frame.<para/>
        /// All other Get* methods within ISvcStackProviderPartialPhysicalFrame may legally return E_NOT_SET.
        /// </summary>
        public HRESULT TryGetInstructionPointer(out long instructionPointer)
        {
            /*HRESULT GetInstructionPointer(
            [Out] out long instructionPointer);*/
            return Raw.GetInstructionPointer(out instructionPointer);
        }

        #endregion
        #region StackPointer

        /// <summary>
        /// Gets the stack pointer for this partial physical frame. This may return E_NOT_SET indicating that there is no available stack pointer value for this partial frame.<para/>
        /// All users of a partial physical frame must be able to deal with such.
        /// </summary>
        public long StackPointer
        {
            get
            {
                long stackPointer;
                TryGetStackPointer(out stackPointer).ThrowDbgEngNotOK();

                return stackPointer;
            }
        }

        /// <summary>
        /// Gets the stack pointer for this partial physical frame. This may return E_NOT_SET indicating that there is no available stack pointer value for this partial frame.<para/>
        /// All users of a partial physical frame must be able to deal with such.
        /// </summary>
        public HRESULT TryGetStackPointer(out long stackPointer)
        {
            /*HRESULT GetStackPointer(
            [Out] out long stackPointer);*/
            return Raw.GetStackPointer(out stackPointer);
        }

        #endregion
        #region FramePointer

        /// <summary>
        /// Gets the frame pointer for this partial physical frame. This may return E_NOT_SET indicating that there is no available frame pointer value for this partial frame.<para/>
        /// All users of a partial physical frame must be able to deal with such.
        /// </summary>
        public long FramePointer
        {
            get
            {
                long framePointer;
                TryGetFramePointer(out framePointer).ThrowDbgEngNotOK();

                return framePointer;
            }
        }

        /// <summary>
        /// Gets the frame pointer for this partial physical frame. This may return E_NOT_SET indicating that there is no available frame pointer value for this partial frame.<para/>
        /// All users of a partial physical frame must be able to deal with such.
        /// </summary>
        public HRESULT TryGetFramePointer(out long framePointer)
        {
            /*HRESULT GetFramePointer(
            [Out] out long framePointer);*/
            return Raw.GetFramePointer(out framePointer);
        }

        #endregion
        #endregion
    }
}
