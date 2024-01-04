using System;

namespace ClrDebug.DbgEng
{
    public class SvcWindowsKdInfrastructure : ComObject<ISvcWindowsKdInfrastructure>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SvcWindowsKdInfrastructure"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
        public SvcWindowsKdInfrastructure(ISvcWindowsKdInfrastructure raw) : base(raw)
        {
        }

        #region ISvcWindowsKdInfrastructure
        #region KdDebuggerDataBlock

        public GetKdDebuggerDataBlockResult KdDebuggerDataBlock
        {
            get
            {
                GetKdDebuggerDataBlockResult result;
                TryGetKdDebuggerDataBlock(out result).ThrowDbgEngNotOK();

                return result;
            }
        }

        public HRESULT TryGetKdDebuggerDataBlock(out GetKdDebuggerDataBlockResult result)
        {
            /*HRESULT GetKdDebuggerDataBlock(
            [Out] out IntPtr kdDebuggerDataBlock,
            [Out] out long dataBlockSize);*/
            IntPtr kdDebuggerDataBlock;
            long dataBlockSize;
            HRESULT hr = Raw.GetKdDebuggerDataBlock(out kdDebuggerDataBlock, out dataBlockSize);

            if (hr == HRESULT.S_OK)
                result = new GetKdDebuggerDataBlockResult(kdDebuggerDataBlock, dataBlockSize);
            else
                result = default(GetKdDebuggerDataBlockResult);

            return hr;
        }

        #endregion
        #region FindKdVersionBlock

        public long FindKdVersionBlock()
        {
            long kdVersionBlockAddress;
            TryFindKdVersionBlock(out kdVersionBlockAddress).ThrowDbgEngNotOK();

            return kdVersionBlockAddress;
        }

        public HRESULT TryFindKdVersionBlock(out long kdVersionBlockAddress)
        {
            /*HRESULT FindKdVersionBlock(
            [Out] out long kdVersionBlockAddress);*/
            return Raw.FindKdVersionBlock(out kdVersionBlockAddress);
        }

        #endregion
        #region FindKdDebuggerDataBlock

        public long FindKdDebuggerDataBlock()
        {
            long kdDebuggerDataBlockAddress;
            TryFindKdDebuggerDataBlock(out kdDebuggerDataBlockAddress).ThrowDbgEngNotOK();

            return kdDebuggerDataBlockAddress;
        }

        public HRESULT TryFindKdDebuggerDataBlock(out long kdDebuggerDataBlockAddress)
        {
            /*HRESULT FindKdDebuggerDataBlock(
            [Out] out long kdDebuggerDataBlockAddress);*/
            return Raw.FindKdDebuggerDataBlock(out kdDebuggerDataBlockAddress);
        }

        #endregion
        #endregion
    }
}
