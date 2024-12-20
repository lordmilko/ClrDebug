using System;

namespace ClrDebug.DbgEng
{
    public class SvcDebugSourceFileMapping : ComObject<ISvcDebugSourceFileMapping>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SvcDebugSourceFileMapping"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
        public SvcDebugSourceFileMapping(ISvcDebugSourceFileMapping raw) : base(raw)
        {
        }

        #region ISvcDebugSourceFileMapping
        #region Handle

        /// <summary>
        /// Gets the original handle associated with this file mapping.
        /// </summary>
        public IntPtr Handle
        {
            get
            {
                IntPtr pHandle;
                TryGetHandle(out pHandle).ThrowDbgEngNotOK();

                return pHandle;
            }
        }

        /// <summary>
        /// Gets the original handle associated with this file mapping.
        /// </summary>
        public HRESULT TryGetHandle(out IntPtr pHandle)
        {
            /*HRESULT GetHandle(
            [Out] out IntPtr pHandle);*/
            return Raw.GetHandle(out pHandle);
        }

        #endregion
        #region MapFile

        /// <summary>
        /// Returns a complete memory mapping of the file. Note that this entire interface can only be used in process and is in no way required of a source file implementation.
        /// </summary>
        public MapFileResult MapFile()
        {
            MapFileResult result;
            TryMapFile(out result).ThrowDbgEngNotOK();

            return result;
        }

        /// <summary>
        /// Returns a complete memory mapping of the file. Note that this entire interface can only be used in process and is in no way required of a source file implementation.
        /// </summary>
        public HRESULT TryMapFile(out MapFileResult result)
        {
            /*HRESULT MapFile(
            [Out] out IntPtr mapAddress,
            [Out] out long mapSize);*/
            IntPtr mapAddress;
            long mapSize;
            HRESULT hr = Raw.MapFile(out mapAddress, out mapSize);

            if (hr == HRESULT.S_OK)
                result = new MapFileResult(mapAddress, mapSize);
            else
                result = default(MapFileResult);

            return hr;
        }

        #endregion
        #endregion
    }
}
