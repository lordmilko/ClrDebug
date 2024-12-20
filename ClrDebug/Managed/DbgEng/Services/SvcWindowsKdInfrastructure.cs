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

        /// <summary>
        /// Retrieves a pointer to the read debugger data block in memory. The valid size of the block is returned as well.<para/>
        /// This pointer is guaranteed to be valid until the virtual memory service in the service stack changes. In this case, any cached copy of this pointer must be flushed and reread.
        /// </summary>
        public GetKdDebuggerDataBlockResult KdDebuggerDataBlock
        {
            get
            {
                GetKdDebuggerDataBlockResult result;
                TryGetKdDebuggerDataBlock(out result).ThrowDbgEngNotOK();

                return result;
            }
        }

        /// <summary>
        /// Retrieves a pointer to the read debugger data block in memory. The valid size of the block is returned as well.<para/>
        /// This pointer is guaranteed to be valid until the virtual memory service in the service stack changes. In this case, any cached copy of this pointer must be flushed and reread.
        /// </summary>
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

        /// <summary>
        /// Finds the KD version block and returns its address. If the version block is not located within the address space of the debug source, this may fail.<para/>
        /// In such cases, GetKdVersionBlock may be called.
        /// </summary>
        public long FindKdVersionBlock()
        {
            long kdVersionBlockAddress;
            TryFindKdVersionBlock(out kdVersionBlockAddress).ThrowDbgEngNotOK();

            return kdVersionBlockAddress;
        }

        /// <summary>
        /// Finds the KD version block and returns its address. If the version block is not located within the address space of the debug source, this may fail.<para/>
        /// In such cases, GetKdVersionBlock may be called.
        /// </summary>
        public HRESULT TryFindKdVersionBlock(out long kdVersionBlockAddress)
        {
            /*HRESULT FindKdVersionBlock(
            [Out] out long kdVersionBlockAddress);*/
            return Raw.FindKdVersionBlock(out kdVersionBlockAddress);
        }

        #endregion
        #region FindKdDebuggerDataBlock

        /// <summary>
        /// Finds the KD debugger data block and returns its address. If the debugger data block is not located within the address space of the debug source, this may fail.<para/>
        /// In such cases, GetKdDebuggerDataBlock may be called.
        /// </summary>
        public long FindKdDebuggerDataBlock()
        {
            long kdDebuggerDataBlockAddress;
            TryFindKdDebuggerDataBlock(out kdDebuggerDataBlockAddress).ThrowDbgEngNotOK();

            return kdDebuggerDataBlockAddress;
        }

        /// <summary>
        /// Finds the KD debugger data block and returns its address. If the debugger data block is not located within the address space of the debug source, this may fail.<para/>
        /// In such cases, GetKdDebuggerDataBlock may be called.
        /// </summary>
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
