using System;
using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    public class CorDebugCode : ComObject<ICorDebugCode>
    {
        public CorDebugCode(ICorDebugCode raw) : base(raw)
        {
        }

        #region ICorDebugCode
        #region IsIL

        public int IsIL
        {
            get
            {
                HRESULT hr;
                int pbIL;

                if ((hr = TryIsIL(out pbIL)) != HRESULT.S_OK)
                    Marshal.ThrowExceptionForHR((int) hr);

                return pbIL;
            }
        }

        public HRESULT TryIsIL(out int pbIL)
        {
            /*HRESULT IsIL(out int pbIL);*/
            return Raw.IsIL(out pbIL);
        }

        #endregion
        #region GetFunction

        public CorDebugFunction Function
        {
            get
            {
                HRESULT hr;
                CorDebugFunction ppFunctionResult;

                if ((hr = TryGetFunction(out ppFunctionResult)) != HRESULT.S_OK)
                    Marshal.ThrowExceptionForHR((int) hr);

                return ppFunctionResult;
            }
        }

        public HRESULT TryGetFunction(out CorDebugFunction ppFunctionResult)
        {
            /*HRESULT GetFunction([MarshalAs(UnmanagedType.Interface)] out ICorDebugFunction ppFunction);*/
            ICorDebugFunction ppFunction;
            HRESULT hr = Raw.GetFunction(out ppFunction);

            if (hr == HRESULT.S_OK)
                ppFunctionResult = new CorDebugFunction(ppFunction);
            else
                ppFunctionResult = default(CorDebugFunction);

            return hr;
        }

        #endregion
        #region GetAddress

        public ulong Address
        {
            get
            {
                HRESULT hr;
                ulong pStart;

                if ((hr = TryGetAddress(out pStart)) != HRESULT.S_OK)
                    Marshal.ThrowExceptionForHR((int) hr);

                return pStart;
            }
        }

        public HRESULT TryGetAddress(out ulong pStart)
        {
            /*HRESULT GetAddress(out ulong pStart);*/
            return Raw.GetAddress(out pStart);
        }

        #endregion
        #region GetSize

        public uint Size
        {
            get
            {
                HRESULT hr;
                uint pcBytes;

                if ((hr = TryGetSize(out pcBytes)) != HRESULT.S_OK)
                    Marshal.ThrowExceptionForHR((int) hr);

                return pcBytes;
            }
        }

        public HRESULT TryGetSize(out uint pcBytes)
        {
            /*HRESULT GetSize(out uint pcBytes);*/
            return Raw.GetSize(out pcBytes);
        }

        #endregion
        #region GetVersionNumber

        public uint VersionNumber
        {
            get
            {
                HRESULT hr;
                uint nVersion;

                if ((hr = TryGetVersionNumber(out nVersion)) != HRESULT.S_OK)
                    Marshal.ThrowExceptionForHR((int) hr);

                return nVersion;
            }
        }

        public HRESULT TryGetVersionNumber(out uint nVersion)
        {
            /*HRESULT GetVersionNumber(out uint nVersion);*/
            return Raw.GetVersionNumber(out nVersion);
        }

        #endregion
        #region CreateBreakpoint

        public CorDebugFunctionBreakpoint CreateBreakpoint(uint offset)
        {
            HRESULT hr;
            CorDebugFunctionBreakpoint ppBreakpointResult;

            if ((hr = TryCreateBreakpoint(offset, out ppBreakpointResult)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return ppBreakpointResult;
        }

        public HRESULT TryCreateBreakpoint(uint offset, out CorDebugFunctionBreakpoint ppBreakpointResult)
        {
            /*HRESULT CreateBreakpoint([In] uint offset,
            [MarshalAs(UnmanagedType.Interface)] out ICorDebugFunctionBreakpoint ppBreakpoint);*/
            ICorDebugFunctionBreakpoint ppBreakpoint;
            HRESULT hr = Raw.CreateBreakpoint(offset, out ppBreakpoint);

            if (hr == HRESULT.S_OK)
                ppBreakpointResult = new CorDebugFunctionBreakpoint(ppBreakpoint);
            else
                ppBreakpointResult = default(CorDebugFunctionBreakpoint);

            return hr;
        }

        #endregion
        #region GetCode

        public GetCodeResult GetCode(uint startOffset, uint endOffset, uint cBufferAlloc)
        {
            HRESULT hr;
            GetCodeResult result;

            if ((hr = TryGetCode(startOffset, endOffset, cBufferAlloc, out result)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return result;
        }

        public HRESULT TryGetCode(uint startOffset, uint endOffset, uint cBufferAlloc, out GetCodeResult result)
        {
            /*HRESULT GetCode(
            [In] uint startOffset,
            [In] uint endOffset,
            [In] uint cBufferAlloc,
            [MarshalAs(UnmanagedType.LPArray), Out] byte[] buffer,
            out uint pcBufferSize);*/
            byte[] buffer = null;
            uint pcBufferSize;
            HRESULT hr = Raw.GetCode(startOffset, endOffset, cBufferAlloc, buffer, out pcBufferSize);

            if (hr == HRESULT.S_OK)
                result = new GetCodeResult(buffer, pcBufferSize);
            else
                result = default(GetCodeResult);

            return hr;
        }

        #endregion
        #region GetILToNativeMapping

        public GetILToNativeMappingResult GetILToNativeMapping(uint cMap)
        {
            HRESULT hr;
            GetILToNativeMappingResult result;

            if ((hr = TryGetILToNativeMapping(cMap, out result)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return result;
        }

        public HRESULT TryGetILToNativeMapping(uint cMap, out GetILToNativeMappingResult result)
        {
            /*HRESULT GetILToNativeMapping([In] uint cMap, out uint pcMap, [MarshalAs(UnmanagedType.LPArray), Out]
            COR_DEBUG_IL_TO_NATIVE_MAP[] map);*/
            uint pcMap;
            COR_DEBUG_IL_TO_NATIVE_MAP[] map = null;
            HRESULT hr = Raw.GetILToNativeMapping(cMap, out pcMap, map);

            if (hr == HRESULT.S_OK)
                result = new GetILToNativeMappingResult(pcMap, map);
            else
                result = default(GetILToNativeMappingResult);

            return hr;
        }

        #endregion
        #region GetEnCRemapSequencePoints

        public GetEnCRemapSequencePointsResult GetEnCRemapSequencePoints(uint cMap)
        {
            HRESULT hr;
            GetEnCRemapSequencePointsResult result;

            if ((hr = TryGetEnCRemapSequencePoints(cMap, out result)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return result;
        }

        public HRESULT TryGetEnCRemapSequencePoints(uint cMap, out GetEnCRemapSequencePointsResult result)
        {
            /*HRESULT GetEnCRemapSequencePoints(
            [In] uint cMap,
            out uint pcMap,
            [MarshalAs(UnmanagedType.LPArray), Out] uint[] offsets);*/
            uint pcMap;
            uint[] offsets = null;
            HRESULT hr = Raw.GetEnCRemapSequencePoints(cMap, out pcMap, offsets);

            if (hr == HRESULT.S_OK)
                result = new GetEnCRemapSequencePointsResult(pcMap, offsets);
            else
                result = default(GetEnCRemapSequencePointsResult);

            return hr;
        }

        #endregion
        #endregion
        #region ICorDebugCode2

        public ICorDebugCode2 Raw2 => (ICorDebugCode2) Raw;

        #region GetCompilerFlags

        public CorDebugJITCompilerFlags CompilerFlags
        {
            get
            {
                HRESULT hr;
                CorDebugJITCompilerFlags pdwFlags;

                if ((hr = TryGetCompilerFlags(out pdwFlags)) != HRESULT.S_OK)
                    Marshal.ThrowExceptionForHR((int) hr);

                return pdwFlags;
            }
        }

        public HRESULT TryGetCompilerFlags(out CorDebugJITCompilerFlags pdwFlags)
        {
            /*HRESULT GetCompilerFlags(out CorDebugJITCompilerFlags pdwFlags);*/
            return Raw2.GetCompilerFlags(out pdwFlags);
        }

        #endregion
        #region GetCodeChunks

        public GetCodeChunksResult GetCodeChunks(uint cbufSize)
        {
            HRESULT hr;
            GetCodeChunksResult result;

            if ((hr = TryGetCodeChunks(cbufSize, out result)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return result;
        }

        public HRESULT TryGetCodeChunks(uint cbufSize, out GetCodeChunksResult result)
        {
            /*HRESULT GetCodeChunks([In] uint cbufSize, out uint pcnumChunks, [MarshalAs(UnmanagedType.LPArray), Out] CodeChunkInfo[] chunks);*/
            uint pcnumChunks;
            CodeChunkInfo[] chunks = null;
            HRESULT hr = Raw2.GetCodeChunks(cbufSize, out pcnumChunks, chunks);

            if (hr == HRESULT.S_OK)
                result = new GetCodeChunksResult(pcnumChunks, chunks);
            else
                result = default(GetCodeChunksResult);

            return hr;
        }

        #endregion
        #endregion
        #region ICorDebugCode3

        public ICorDebugCode3 Raw3 => (ICorDebugCode3) Raw;

        #region GetReturnValueLiveOffset

        public GetReturnValueLiveOffsetResult GetReturnValueLiveOffset(uint ilOffset, uint bufferSize)
        {
            HRESULT hr;
            GetReturnValueLiveOffsetResult result;

            if ((hr = TryGetReturnValueLiveOffset(ilOffset, bufferSize, out result)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return result;
        }

        public HRESULT TryGetReturnValueLiveOffset(uint ilOffset, uint bufferSize, out GetReturnValueLiveOffsetResult result)
        {
            /*HRESULT GetReturnValueLiveOffset(
            [In] uint ilOffset,
            [In] uint bufferSize,
            out uint pFetched,
            [Out] uint pOffsets);*/
            uint pFetched;
            uint pOffsets = default(uint);
            HRESULT hr = Raw3.GetReturnValueLiveOffset(ilOffset, bufferSize, out pFetched, pOffsets);

            if (hr == HRESULT.S_OK)
                result = new GetReturnValueLiveOffsetResult(pFetched, pOffsets);
            else
                result = default(GetReturnValueLiveOffsetResult);

            return hr;
        }

        #endregion
        #endregion
        #region ICorDebugCode4

        public ICorDebugCode4 Raw4 => (ICorDebugCode4) Raw;

        #region EnumerateVariableHomes

        public CorDebugVariableHomeEnum EnumerateVariableHomes()
        {
            HRESULT hr;
            CorDebugVariableHomeEnum ppEnumResult;

            if ((hr = TryEnumerateVariableHomes(out ppEnumResult)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return ppEnumResult;
        }

        public HRESULT TryEnumerateVariableHomes(out CorDebugVariableHomeEnum ppEnumResult)
        {
            /*HRESULT EnumerateVariableHomes([MarshalAs(UnmanagedType.Interface)] out ICorDebugVariableHomeEnum ppEnum);*/
            ICorDebugVariableHomeEnum ppEnum;
            HRESULT hr = Raw4.EnumerateVariableHomes(out ppEnum);

            if (hr == HRESULT.S_OK)
                ppEnumResult = new CorDebugVariableHomeEnum(ppEnum);
            else
                ppEnumResult = default(CorDebugVariableHomeEnum);

            return hr;
        }

        #endregion
        #endregion
    }
}