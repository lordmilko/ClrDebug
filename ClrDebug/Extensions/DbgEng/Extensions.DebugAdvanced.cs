using System;
using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    public static partial class DbgEngExtensions
    {
        public static DebugAdvancedRequests Request(this DebugAdvanced advanced) => new DebugAdvancedRequests(advanced);

        #region Request [in]

        public static void Request<T>(this DebugAdvanced advanced, DEBUG_REQUEST request, T value) where T : struct =>
            advanced.TryRequest(request, value).ThrowDbgEngNotOK();

        public static HRESULT TryRequest<T>(this DebugAdvanced advanced, DEBUG_REQUEST request, T value) where T : struct
        {
            var size = Marshal.SizeOf<T>();
            var buffer = Marshal.AllocHGlobal(size);

            try
            {
                Marshal.StructureToPtr(value, buffer, false);

                return advanced.TryRequest(
                    request,
                    buffer,
                    size,
                    IntPtr.Zero,
                    0,
                    out _
                );
            }
            finally
            {
                Marshal.FreeHGlobal(buffer);
            }
        }

        #endregion
        #region Request [out]

        public static T Request<T>(this DebugAdvanced advanced, DEBUG_REQUEST request) where T : struct
        {
            advanced.TryRequest<T>(request, out var result).ThrowDbgEngNotOK();
            return result;
        }
        
        public static HRESULT TryRequest<T>(this DebugAdvanced advanced, DEBUG_REQUEST request, out T result) where T : struct
        {
            var size = Marshal.SizeOf<T>();
            var buffer = Marshal.AllocHGlobal(size);

            try
            {
                var hr = advanced.TryRequest(
                    request,
                    IntPtr.Zero,
                    0,
                    buffer,
                    size,
                    out _
                );

                if (hr == HRESULT.S_OK)
                    result = Marshal.PtrToStructure<T>(buffer);
                else
                    result = default(T);

                return hr;
            }
            finally
            {
                Marshal.FreeHGlobal(buffer);
            }
        }

        #endregion
        #region Request (Other)

        internal static HRESULT RequestHRESULT(this DebugAdvanced advanced, DEBUG_REQUEST request) =>
            advanced.TryRequest(request, IntPtr.Zero, 0, IntPtr.Zero, 0, out var outSize).ThrowDbgEngFailed();

        internal static string RequestString(this DebugAdvanced advanced, DEBUG_REQUEST request, bool unicode)
        {
            advanced.TryRequest(request, IntPtr.Zero, 0, IntPtr.Zero, 0, out var length).ThrowDbgEngFailed();

            var buffer = Marshal.AllocHGlobal(length);

            try
            {
                advanced.TryRequest(request, IntPtr.Zero, 0, buffer, length, out _).ThrowDbgEngNotOK();

                if (unicode)
                    return Marshal.PtrToStringUni(buffer);
                else
                    return Marshal.PtrToStringAnsi(buffer);
            }
            finally
            {
                Marshal.FreeHGlobal(buffer);
            }
        }

        #endregion
        #region DebugAdvancedRequests

        public class DebugAdvancedRequests
        {
            private DebugAdvanced advanced;

            internal DebugAdvancedRequests(DebugAdvanced advanced)
            {
                this.advanced = advanced;
            }

            #region NotImplemented

            private void AddCachedSymbolInfo()
            {
                throw new NotImplementedException();
            }

            private void CloseToken()
            {
                throw new NotImplementedException();
            }

            private void CurrentOutputCallbacksAreDmlAware()
            {
                throw new NotImplementedException();
            }

            private void DuplicateToken()
            {
                throw new NotImplementedException();
            }

            #endregion
            #region ExtTypedDataAnsi

            public void ExtTypedDataAnsi(IntPtr buffer, int bufferSize) =>
                TryExtTypedDataAnsi(buffer, bufferSize).ThrowDbgEngNotOK();

            public HRESULT TryExtTypedDataAnsi(IntPtr buffer, int bufferSize) =>
                advanced.TryRequest(DEBUG_REQUEST.EXT_TYPED_DATA_ANSI, buffer, bufferSize, buffer, bufferSize, out var outSize);

            #endregion

            public DebugAdvancedExtTypedDataAnsiRequests ExtTypedDataAnsi() =>
                new DebugAdvancedExtTypedDataAnsiRequests(advanced);

            public void GetAdditionalCreateOptions() =>
                advanced.Request<DEBUG_CREATE_PROCESS_OPTIONS>(DEBUG_REQUEST.GET_ADDITIONAL_CREATE_OPTIONS);

            #region NotImplemented

            private void GetCachedSymbolInfo()
            {
                throw new NotImplementedException();
            }

            #endregion

            public void GetCapturedEventCodeOffset() =>
                advanced.Request<long>(DEBUG_REQUEST.GET_CAPTURED_EVENT_CODE_OFFSET);

            //Only works with kernel dumps; DbgEng sets the type to "2" for user mode dumps,
            //but Request() wants the type to be "1"
            public void GetDumpHeader<T>() where T : struct =>
                advanced.Request<T>(DEBUG_REQUEST.GET_DUMP_HEADER);

            public string GetExtensionSearchPathWide() =>
                advanced.RequestString(DEBUG_REQUEST.GET_EXTENSION_SEARCH_PATH_WIDE, true);

            #region NotImplemented

            private void GetOffsetUnwindInformation()
            {
                throw new NotImplementedException();
            }

            private void GetTextCompletionsAnsi()
            {
                throw new NotImplementedException();
            }

            private void GetTextCompletionsWide()
            {
                throw new NotImplementedException();
            }

            #endregion

            public Version GetWin32MajorMinorVersions()
            {
                var value = advanced.Request<long>(DEBUG_REQUEST.GET_WIN32_MAJOR_MINOR_VERSIONS);

                //While the major version was located first in memory, little endianness swaps
                //their positions around, so high is minor and low is major
                var high = (int)(value >> 32);
                var low = (int)(value & 0xFFFFFFFF); //Get the lower 32-bits (each F is 4 bits: 1111)

                return new Version(low, high);
            }

            #region NotImplemented

            private void LiveUserNonInvasive()
            {
                throw new NotImplementedException();
            }

            private void Midori()
            {
                throw new NotImplementedException();
            }

            private void MiscInformation()
            {
                throw new NotImplementedException();
            }

            private void OpenProcessToken()
            {
                throw new NotImplementedException();
            }

            private void OpenThreadToken()
            {
                throw new NotImplementedException();
            }

            private void ProcessDescriptors()
            {
                throw new NotImplementedException();
            }

            private void QueryInfoToken()
            {
                throw new NotImplementedException();
            }

            private void RemoveCachedSymbolInfo()
            {
                throw new NotImplementedException();
            }

            private void ReadCapturedEventCodeStream()
            {
                throw new NotImplementedException();
            }

            private void ReadUserMinidumpStream(ref DEBUG_READ_USER_MINIDUMP_STREAM stream)
            {
                //This request wants an existing DEBUG_READ_USER_MINIDUMP_STREAM to be passed
                //by ref

                throw new NotImplementedException();
            }

            private void ResumeThread()
            {
                throw new NotImplementedException();
            }

            #endregion

            public void SetAdditionalCreateOptions(DEBUG_CREATE_PROCESS_OPTIONS options) =>
                advanced.Request(DEBUG_REQUEST.SET_ADDITIONAL_CREATE_OPTIONS, options);

            #region NotImplemented

            private void SetDumpHeader()
            {
                throw new NotImplementedException();
            }

            private void SetLocalImplicitCommandLine(string commandLine)
            {
                throw new NotImplementedException();
            }

            #endregion

            //Check the source path for a source server.
            public bool SourcePathHasSourceServer() =>
                advanced.RequestHRESULT(DEBUG_REQUEST.SOURCE_PATH_HAS_SOURCE_SERVER) == HRESULT.S_OK;

            public bool TargetCanDetach() =>
                advanced.RequestHRESULT(DEBUG_REQUEST.TARGET_CAN_DETACH) == HRESULT.S_OK;

            //Return the thread context for the stored event in a user-mode minidump file.
            public T TargetExceptionContext<T>() where T : struct =>
                advanced.Request<T>(DEBUG_REQUEST.TARGET_EXCEPTION_CONTEXT);

            public void TargetExceptionRecord() =>
                advanced.Request<EXCEPTION_RECORD64>(DEBUG_REQUEST.TARGET_EXCEPTION_RECORD);

            public void TargetExceptionThread() =>
                advanced.Request<int>(DEBUG_REQUEST.TARGET_EXCEPTION_THREAD);

            #region NotImplemented

            private void WowModule()
            {
                throw new NotImplementedException();
            }

            private void WowProcess()
            {
                throw new NotImplementedException();
            }

            #endregion
        }

        #endregion
        #region DebugAdvancedExtTypedDataAnsiRequests

        public class DebugAdvancedExtTypedDataAnsiRequests
        {
            private DebugAdvanced advanced;

            internal DebugAdvancedExtTypedDataAnsiRequests(DebugAdvanced advanced)
            {
                this.advanced = advanced;
            }

            #region Copy

            public DEBUG_TYPED_DATA Copy(DEBUG_TYPED_DATA original)
            {
                TryCopy(original, out var copy).ThrowDbgEngNotOK();
                return copy;
            }

            public HRESULT TryCopy(DEBUG_TYPED_DATA original, out DEBUG_TYPED_DATA copy)
            {
                var ioctl = new ExtIoctl
                {
                    Operation = EXT_TDOP.EXT_TDOP_COPY,
                    InputTypedData = original
                };

                var hr = ioctl.TryExecute();

                if (hr == HRESULT.S_OK)
                    copy = ioctl.OutputTypedData;
                else
                    copy = default(DEBUG_TYPED_DATA);

                return hr;
            }

            #endregion
            #region Evaluate

            //Similar to SET_FROM_EXPR except you can optionally specify an input typed data
            public DEBUG_TYPED_DATA Evaluate(string expr, DEBUG_TYPED_DATA typedData = default(DEBUG_TYPED_DATA), EXT_TDF flags = 0)
            {
                TryEvaluate(expr, typedData, flags, out var result).ThrowDbgEngNotOK();
                return result;
            }

            public HRESULT TryEvaluate(string expr, out DEBUG_TYPED_DATA result) =>
                TryEvaluate(expr, default(DEBUG_TYPED_DATA), 0, out result);

            public HRESULT TryEvaluate(string expr, DEBUG_TYPED_DATA typedData, out DEBUG_TYPED_DATA result) =>
                TryEvaluate(expr, typedData, 0, out result);

            public HRESULT TryEvaluate(
                string expr,
                DEBUG_TYPED_DATA typedData,
                EXT_TDF flags,
                out DEBUG_TYPED_DATA result)
            {
                if (expr == null)
                    throw new ArgumentNullException(nameof(expr));

                var ioctl = new ExtIoctl
                {
                    Advanced = advanced,
                    Operation = EXT_TDOP.EXT_TDOP_EVALUATE,
                    InputString = expr,
                    InputTypedData = typedData,
                    Flags = flags
                };

                var hr = ioctl.TryExecute();

                if (hr == HRESULT.S_OK)
                    result = ioctl.OutputTypedData;
                else
                    result = default(DEBUG_TYPED_DATA);

                return hr;
            }

            #endregion
            #region GetArrayElement

            public DEBUG_TYPED_DATA GetArrayElement(DEBUG_TYPED_DATA input, int index)
            {
                TryGetArrayElement(input, index, out var result).ThrowDbgEngNotOK();
                return result;
            }

            public HRESULT TryGetArrayElement(DEBUG_TYPED_DATA input, int index, out DEBUG_TYPED_DATA element)
            {
                var ioctl = new ExtIoctl
                {
                    Advanced = advanced,
                    Operation = EXT_TDOP.EXT_TDOP_GET_ARRAY_ELEMENT,
                    InputTypedData = input,
                    InputNumber64 = (long)index
                };

                var hr = ioctl.TryExecute();

                if (hr == HRESULT.S_OK)
                    element = ioctl.OutputTypedData;
                else
                    element = default(DEBUG_TYPED_DATA);

                return hr;
            }

            #endregion
            #region GetDereference

            public DEBUG_TYPED_DATA GetDereference(DEBUG_TYPED_DATA type)
            {
                TryGetDereference(type, out var output).ThrowDbgEngNotOK();
                return output;
            }

            public HRESULT TryGetDereference(DEBUG_TYPED_DATA type, out DEBUG_TYPED_DATA result)
            {
                var ioctl = new ExtIoctl
                {
                    Advanced = advanced,
                    Operation = EXT_TDOP.EXT_TDOP_GET_DEREFERENCE,
                    InputTypedData = type
                };

                var hr = ioctl.TryExecute();

                if (hr == HRESULT.S_OK)
                    result = ioctl.OutputTypedData;
                else
                    result = default(DEBUG_TYPED_DATA);

                return hr;
            }

            #endregion
            #region GetField

            public DEBUG_TYPED_DATA GetField(DEBUG_TYPED_DATA type, string name)
            {
                TryGetField(type, name, out var field).ThrowDbgEngNotOK();
                return field;
            }

            public HRESULT TryGetField(DEBUG_TYPED_DATA type, string name, out DEBUG_TYPED_DATA field)
            {
                if (name == null)
                    throw new ArgumentNullException(nameof(name));

                var ioctl = new ExtIoctl
                {
                    Advanced = advanced,
                    Operation = EXT_TDOP.EXT_TDOP_GET_FIELD,
                    InputString = name,
                    InputTypedData = type
                };

                var hr = ioctl.TryExecute();

                if (hr == HRESULT.S_OK)
                    field = ioctl.OutputTypedData;
                else
                    field = default(DEBUG_TYPED_DATA);

                return hr;
            }

            #endregion
            #region GetFieldOffset

            public int GetFieldOffset(DEBUG_TYPED_DATA type, string name)
            {
                TryGetFieldOffset(type, name, out var offset).ThrowDbgEngNotOK();
                return offset;
            }

            public HRESULT TryGetFieldOffset(DEBUG_TYPED_DATA type, string name, out int offset)
            {
                if (name == null)
                    throw new ArgumentNullException(nameof(name));

                var ioctl = new ExtIoctl
                {
                    Advanced = advanced,
                    Operation = EXT_TDOP.EXT_TDOP_GET_FIELD_OFFSET,
                    InputTypedData = type,
                    InputString = name
                };

                var hr = ioctl.TryExecute();

                if (hr == HRESULT.S_OK)
                    offset = ioctl.OutputNumber32;
                else
                    offset = 0;

                return hr;
            }

            #endregion
            #region GetPointerTo

            public DEBUG_TYPED_DATA GetPointerTo(DEBUG_TYPED_DATA type)
            {
                TryGetPointerTo(type, out var ptr).ThrowDbgEngNotOK();
                return ptr;
            }

            public HRESULT TryGetPointerTo(DEBUG_TYPED_DATA type, out DEBUG_TYPED_DATA ptr)
            {
                var ioctl = new ExtIoctl
                {
                    Advanced = advanced,
                    Operation = EXT_TDOP.EXT_TDOP_GET_POINTER_TO,
                    InputTypedData = type
                };

                var hr = ioctl.TryExecute();

                if (hr == HRESULT.S_OK)
                    ptr = ioctl.OutputTypedData;
                else
                    ptr = default(DEBUG_TYPED_DATA);

                return hr;
            }

            #endregion
            #region GetTypeName

            public string GetTypeName(DEBUG_TYPED_DATA type)
            {
                TryGetTypeName(type, out var name).ThrowDbgEngNotOK();
                return name;
            }

            public HRESULT TryGetTypeName(DEBUG_TYPED_DATA type, out string name)
            {
                var ioctl = new ExtIoctl
                {
                    Advanced = advanced,
                    Operation = EXT_TDOP.EXT_TDOP_GET_TYPE_NAME,
                    OutputStringLength = 256, //The Visual C++ debugger has a maximum symbol length of 256
                    InputTypedData = type
                };

                var hr = ioctl.TryExecute();

                if (hr == HRESULT.S_OK)
                    name = ioctl.OutputString;
                else
                    name = null;

                return hr;
            }

            #endregion
            #region GetTypeSize

            public int GetTypeSize(DEBUG_TYPED_DATA type)
            {
                TryGetTypeSize(type, out var size).ThrowDbgEngNotOK();
                return size;
            }

            public HRESULT TryGetTypeSize(DEBUG_TYPED_DATA type, out int size)
            {
                var ioctl = new ExtIoctl
                {
                    Advanced = advanced,
                    Operation = EXT_TDOP.EXT_TDOP_GET_TYPE_SIZE,
                    InputTypedData = type
                };

                var hr = ioctl.TryExecute();

                if (hr == HRESULT.S_OK)
                    size = ioctl.OutputNumber32;
                else
                    size = 0;

                return hr;
            }

            #endregion
            #region HasField

            public bool HasField(DEBUG_TYPED_DATA type, string name)
            {
                if (name == null)
                    throw new ArgumentNullException(nameof(name));

                var ioctl = new ExtIoctl
                {
                    Advanced = advanced,
                    Operation = EXT_TDOP.EXT_TDOP_HAS_FIELD,
                    InputString = name,
                    InputTypedData = type
                };

                var hr = ioctl.TryExecute();

                return hr == HRESULT.S_OK;
            }

            #endregion
            #region OutputFullValue

            public void OutputFullValue(DEBUG_TYPED_DATA type)
            {
                TryOutputFullValue(type).ThrowDbgEngNotOK();
            }

            public HRESULT TryOutputFullValue(DEBUG_TYPED_DATA type)
            {
                var ioctl = new ExtIoctl
                {
                    Advanced = advanced,
                    Operation = EXT_TDOP.EXT_TDOP_OUTPUT_FULL_VALUE,
                    InputTypedData = type
                };

                return ioctl.TryExecute();
            }

            #endregion
            #region OutputSimpleValue

            public void OutputSimpleValue(DEBUG_TYPED_DATA type)
            {
                TryOutputSimpleValue(type).ThrowDbgEngNotOK();
            }

            public HRESULT TryOutputSimpleValue(DEBUG_TYPED_DATA type)
            {
                var ioctl = new ExtIoctl
                {
                    Advanced = advanced,
                    Operation = EXT_TDOP.EXT_TDOP_OUTPUT_SIMPLE_VALUE,
                    InputTypedData = type
                };

                return ioctl.TryExecute();
            }

            #endregion
            #region OutputTypeDefinition

            public void OutputTypeDefinition(DEBUG_TYPED_DATA type)
            {
                TryOutputTypeDefinition(type).ThrowDbgEngNotOK();
            }

            public HRESULT TryOutputTypeDefinition(DEBUG_TYPED_DATA type)
            {
                var ioctl = new ExtIoctl
                {
                    Advanced = advanced,
                    Operation = EXT_TDOP.EXT_TDOP_OUTPUT_TYPE_DEFINITION,
                    InputTypedData = type
                };

                return ioctl.TryExecute();
            }

            #endregion
            #region OutputTypeName

            public void OutputTypeName(DEBUG_TYPED_DATA type)
            {
                TryOutputTypeName(type).ThrowDbgEngNotOK();
            }

            public HRESULT TryOutputTypeName(DEBUG_TYPED_DATA type)
            {
                var ioctl = new ExtIoctl
                {
                    Advanced = advanced,
                    Operation = EXT_TDOP.EXT_TDOP_OUTPUT_TYPE_NAME,
                    InputTypedData = type
                };

                return ioctl.TryExecute();
            }

            #endregion
            #region Release

            public void Release(DEBUG_TYPED_DATA type)
            {
                TryRelease(type).ThrowDbgEngNotOK();
            }

            public HRESULT TryRelease(DEBUG_TYPED_DATA type)
            {
                var ioctl = new ExtIoctl
                {
                    Operation = EXT_TDOP.EXT_TDOP_RELEASE,
                    InputTypedData = type
                };

                return ioctl.TryExecute();
            }

            #endregion
            #region SetFromExpr

            public DEBUG_TYPED_DATA SetFromExpr(string expr, EXT_TDF flags = 0)
            {
                TrySetFromExpr(expr, flags, out var result).ThrowDbgEngNotOK();
                return result;
            }

            public HRESULT TrySetFromExpr(string expr, out DEBUG_TYPED_DATA result) =>
                TrySetFromExpr(expr, 0, out result);

            public HRESULT TrySetFromExpr(
                string expr,
                EXT_TDF flags,
                out DEBUG_TYPED_DATA result)
            {
                if (expr == null)
                    throw new ArgumentNullException(nameof(expr));

                var ioctl = new ExtIoctl
                {
                    Advanced = advanced,
                    Operation = EXT_TDOP.EXT_TDOP_SET_FROM_EXPR,
                    InputString = expr,
                    Flags = flags
                };

                var hr = ioctl.TryExecute();

                if (hr == HRESULT.S_OK)
                    result = ioctl.OutputTypedData;
                else
                    result = default(DEBUG_TYPED_DATA);

                return hr;
            }

            #endregion
            #region SetFromTypeIdAndU64

            public DEBUG_TYPED_DATA SetFromTypeIdAndU64(long modBase, long offset, int typeId, EXT_TDF flags = 0)
            {
                TrySetFromTypeIdAndU64(modBase, offset, typeId, flags, out var result).ThrowDbgEngNotOK();
                return result;
            }

            public HRESULT TrySetFromTypeIdAndU64(
                long modBase,
                long offset,
                int typeId,
                out DEBUG_TYPED_DATA result) =>
                TrySetFromTypeIdAndU64(modBase, offset, typeId, 0, out result);

            public HRESULT TrySetFromTypeIdAndU64(
                long modBase,
                long offset,
                int typeId,
                EXT_TDF flags,
                out DEBUG_TYPED_DATA result)
            {
                var typedData = new DEBUG_TYPED_DATA
                {
                    ModBase = modBase,
                    Offset = offset,
                    TypeId = typeId
                };

                return TrySetFromTypeIdAndU64(typedData, flags, out result);
            }

            public DEBUG_TYPED_DATA SetFromTypeIdAndU64(DEBUG_TYPED_DATA typedData, EXT_TDF flags = 0)
            {
                TrySetFromTypeIdAndU64(typedData, flags, out var result).ThrowDbgEngNotOK();
                return result;
            }

            public HRESULT TrySetFromTypeIdAndU64(DEBUG_TYPED_DATA typedData, out DEBUG_TYPED_DATA result) =>
                TrySetFromTypeIdAndU64(typedData, 0, out result);

            public HRESULT TrySetFromTypeIdAndU64(DEBUG_TYPED_DATA typedData, EXT_TDF flags, out DEBUG_TYPED_DATA result)
            {
                var ioctl = new ExtIoctl
                {
                    Advanced = advanced,
                    Operation = EXT_TDOP.EXT_TDOP_SET_FROM_TYPE_ID_AND_U64,
                    InputTypedData = typedData,
                    Flags = flags
                };

                var hr = ioctl.TryExecute();

                if (hr == HRESULT.S_OK)
                    result = ioctl.OutputTypedData;
                else
                    result = default(DEBUG_TYPED_DATA);

                return hr;
            }

            #endregion
            #region SetFromU64Expr

            public DEBUG_TYPED_DATA SetFromU64Expr(
                string expr,
                DEBUG_TYPED_DATA typedData = default(DEBUG_TYPED_DATA),
                long offset = 0,
                EXT_TDF flags = 0)
            {
                TrySetFromU64Expr(expr, typedData, offset, flags, out var result).ThrowDbgEngNotOK();
                return result;
            }

            public HRESULT TrySetFromU64Expr(string expr, out DEBUG_TYPED_DATA result) =>
                TrySetFromU64Expr(expr, default(DEBUG_TYPED_DATA), 0, out result);

            public HRESULT TrySetFromU64Expr(
                string expr,
                DEBUG_TYPED_DATA typedData,
                out DEBUG_TYPED_DATA result) =>
                TrySetFromU64Expr(expr, typedData, 0, 0, out result);

            public HRESULT TrySetFromU64Expr(
                string expr,
                DEBUG_TYPED_DATA typedData,
                long offset,
                out DEBUG_TYPED_DATA result) =>
                TrySetFromU64Expr(expr, typedData, offset, 0, out result);

            //This uses the address from DEBUG_TYPED_DATA, while Evaluate uses the "value" apprently
            public HRESULT TrySetFromU64Expr(
                string expr,
                DEBUG_TYPED_DATA typedData,
                long offset,
                EXT_TDF flags,
                out DEBUG_TYPED_DATA result
                )
            {
                if (expr == null)
                    throw new ArgumentNullException(nameof(expr));

                typedData.Offset = offset;

                var ioctl = new ExtIoctl
                {
                    Advanced = advanced,
                    Operation = EXT_TDOP.EXT_TDOP_SET_FROM_U64_EXPR,
                    InputString = expr,
                    InputTypedData = typedData,
                    Flags = flags
                };

                var hr = ioctl.TryExecute();

                if (hr == HRESULT.S_OK)
                    result = ioctl.OutputTypedData;
                else
                    result = default(DEBUG_TYPED_DATA);

                return hr;
            }

            #endregion
            #region SetPtrFromTypeIdAndU64

            public DEBUG_TYPED_DATA SetPtrFromTypeIdAndU64(long modBase, long offset, int typeId, EXT_TDF flags = 0)
            {
                TrySetPtrFromTypeIdAndU64(modBase, offset, typeId, flags, out var result).ThrowDbgEngNotOK();
                return result;
            }

            public HRESULT TrySetPtrFromTypeIdAndU64(
                long modBase,
                long offset,
                int typeId,
                out DEBUG_TYPED_DATA result) =>
                TrySetPtrFromTypeIdAndU64(modBase, offset, typeId, 0, out result);

            public HRESULT TrySetPtrFromTypeIdAndU64(
                long modBase,
                long offset,
                int typeId,
                EXT_TDF flags,
                out DEBUG_TYPED_DATA result)
            {
                var typedData = new DEBUG_TYPED_DATA
                {
                    ModBase = modBase,
                    Offset = offset,
                    TypeId = typeId
                };

                return TrySetPtrFromTypeIdAndU64(typedData, flags, out result);
            }

            public DEBUG_TYPED_DATA SetPtrFromTypeIdAndU64(DEBUG_TYPED_DATA typedData, EXT_TDF flags = 0)
            {
                TrySetPtrFromTypeIdAndU64(typedData, flags, out var result).ThrowDbgEngNotOK();
                return result;
            }

            public HRESULT TrySetPtrFromTypeIdAndU64(
                DEBUG_TYPED_DATA typedData,
                out DEBUG_TYPED_DATA result) =>
                TrySetPtrFromTypeIdAndU64(typedData, 0, out result);

            public HRESULT TrySetPtrFromTypeIdAndU64(
                DEBUG_TYPED_DATA typedData,
                EXT_TDF flags,
                out DEBUG_TYPED_DATA result)
            {
                var ioctl = new ExtIoctl
                {
                    Advanced = advanced,
                    Operation = EXT_TDOP.EXT_TDOP_SET_PTR_FROM_TYPE_ID_AND_U64,
                    InputTypedData = typedData,
                    Flags = flags,
                };

                var hr = ioctl.TryExecute();

                if (hr == HRESULT.S_OK)
                    result = ioctl.OutputTypedData;
                else
                    result = default(DEBUG_TYPED_DATA);

                return hr;
            }

            #endregion
        }

        #endregion
    }
}
