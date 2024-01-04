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

        public long InstructionPointer
        {
            get
            {
                long instructionPointer;
                TryGetInstructionPointer(out instructionPointer).ThrowDbgEngNotOK();

                return instructionPointer;
            }
        }

        public HRESULT TryGetInstructionPointer(out long instructionPointer)
        {
            /*HRESULT GetInstructionPointer(
            [Out] out long instructionPointer);*/
            return Raw.GetInstructionPointer(out instructionPointer);
        }

        #endregion
        #region StackPointer

        public long StackPointer
        {
            get
            {
                long stackPointer;
                TryGetStackPointer(out stackPointer).ThrowDbgEngNotOK();

                return stackPointer;
            }
        }

        public HRESULT TryGetStackPointer(out long stackPointer)
        {
            /*HRESULT GetStackPointer(
            [Out] out long stackPointer);*/
            return Raw.GetStackPointer(out stackPointer);
        }

        #endregion
        #region FramePointer

        public long FramePointer
        {
            get
            {
                long framePointer;
                TryGetFramePointer(out framePointer).ThrowDbgEngNotOK();

                return framePointer;
            }
        }

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
