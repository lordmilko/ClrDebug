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

        public class DebugAdvancedRequests
        {
            private DebugAdvanced advanced;

            internal DebugAdvancedRequests(DebugAdvanced advanced)
            {
                this.advanced = advanced;
            }

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

            private void GetCachedSymbolInfo()
            {
                throw new NotImplementedException();
            }

            public void GetCapturedEventCodeOffset() =>
                advanced.Request<ulong>(DEBUG_REQUEST.GET_CAPTURED_EVENT_CODE_OFFSET);

            //Only works with kernel dumps; DbgEng sets the type to "2" for user mode dumps,
            //but Request() wants the type to be "1"
            public void GetDumpHeader<T>() where T : struct =>
                advanced.Request<T>(DEBUG_REQUEST.GET_DUMP_HEADER);

            public string GetExtensionSearchPathWide() =>
                advanced.RequestString(DEBUG_REQUEST.GET_EXTENSION_SEARCH_PATH_WIDE, true);

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

            public Version GetWin32MajorMinorVersions()
            {
                var value = advanced.Request<ulong>(DEBUG_REQUEST.GET_WIN32_MAJOR_MINOR_VERSIONS);

                //While the major version was located first in memory, little endianness swaps
                //their positions around, so high is minor and low is major
                var high = (int)(value >> 32);
                var low = (int)(value & 0xFFFFFFFF); //Get the lower 32-bits (each F is 4 bits: 1111)

                return new Version(low, high);
            }

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

            public void SetAdditionalCreateOptions(DEBUG_CREATE_PROCESS_OPTIONS options) =>
                advanced.Request(DEBUG_REQUEST.SET_ADDITIONAL_CREATE_OPTIONS, options);

            private void SetDumpHeader()
            {
                throw new NotImplementedException();
            }

            private void SetLocalImplicitCommandLine(string commandLine)
            {
                throw new NotImplementedException();
            }

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

            private void WowModule()
            {
                throw new NotImplementedException();
            }

            private void WowProcess()
            {
                throw new NotImplementedException();
            }
        }

        public class DebugAdvancedExtTypedDataAnsiRequests
        {
            private DebugAdvanced advanced;

            internal DebugAdvancedExtTypedDataAnsiRequests(DebugAdvanced advanced)
            {
                this.advanced = advanced;
            }

            public DEBUG_TYPED_DATA Copy(DEBUG_TYPED_DATA typedData)
            {
                var ioctl = new ExtIoctl
                {
                    Operation = EXT_TDOP.EXT_TDOP_COPY,
                    InputTypedData = typedData
                };

                ioctl.Execute();

                return ioctl.OutputTypedData;
            }

            //Similar to SET_FROM_EXPR except you can optionally specify an input typed data
            public DEBUG_TYPED_DATA Evaluate(string expr, DEBUG_TYPED_DATA typedData = default(DEBUG_TYPED_DATA), EXT_TDF flags = 0)
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

                ioctl.Execute();

                return ioctl.OutputTypedData;
            }

            public DEBUG_TYPED_DATA GetArrayElement(DEBUG_TYPED_DATA typedData, int index)
            {
                var ioctl = new ExtIoctl
                {
                    Advanced = advanced,
                    Operation = EXT_TDOP.EXT_TDOP_GET_ARRAY_ELEMENT,
                    InputTypedData = typedData,
                    InputNumber64 = (ulong) index
                };

                ioctl.Execute();

                return ioctl.OutputTypedData;
            }

            public DEBUG_TYPED_DATA GetDereference(DEBUG_TYPED_DATA typedData)
            {
                var ioctl = new ExtIoctl
                {
                    Advanced = advanced,
                    Operation = EXT_TDOP.EXT_TDOP_GET_DEREFERENCE,
                    InputTypedData = typedData
                };

                ioctl.Execute();

                return ioctl.OutputTypedData;
            }

            public DEBUG_TYPED_DATA GetField(DEBUG_TYPED_DATA typedData, string name)
            {
                if (name == null)
                    throw new ArgumentNullException(nameof(name));

                var ioctl = new ExtIoctl
                {
                    Advanced = advanced,
                    Operation = EXT_TDOP.EXT_TDOP_GET_FIELD,
                    InputString = name,
                    InputTypedData = typedData
                };

                ioctl.Execute();

                return ioctl.OutputTypedData;
            }

            public uint GetFieldOffset(DEBUG_TYPED_DATA typedData, string name)
            {
                if (name == null)
                    throw new ArgumentNullException(nameof(name));

                var ioctl = new ExtIoctl
                {
                    Advanced = advanced,
                    Operation = EXT_TDOP.EXT_TDOP_GET_FIELD_OFFSET,
                    InputTypedData = typedData,
                    InputString = name
                };

                ioctl.Execute();

                return ioctl.OutputNumber32;
            }

            public DEBUG_TYPED_DATA GetPointerTo(DEBUG_TYPED_DATA typedData)
            {
                var ioctl = new ExtIoctl
                {
                    Advanced = advanced,
                    Operation = EXT_TDOP.EXT_TDOP_GET_POINTER_TO,
                    InputTypedData = typedData
                };

                ioctl.Execute();

                return ioctl.OutputTypedData;
            }

            public string GetTypeName(DEBUG_TYPED_DATA typedData)
            {
                var ioctl = new ExtIoctl
                {
                    Advanced = advanced,
                    Operation = EXT_TDOP.EXT_TDOP_GET_TYPE_NAME,
                    OutputStringLength = 256, //The Visual C++ debugger has a maximum symbol length of 256
                    InputTypedData = typedData
                };

                ioctl.Execute();

                return ioctl.OutputString;
            }

            public uint GetTypeSize(DEBUG_TYPED_DATA typedData)
            {
                var ioctl = new ExtIoctl
                {
                    Advanced = advanced,
                    Operation = EXT_TDOP.EXT_TDOP_GET_TYPE_SIZE,
                    InputTypedData = typedData
                };

                ioctl.Execute();

                return ioctl.OutputNumber32;
            }

            public bool HasField(DEBUG_TYPED_DATA typedData, string name)
            {
                if (name == null)
                    throw new ArgumentNullException(nameof(name));

                var ioctl = new ExtIoctl
                {
                    Advanced = advanced,
                    Operation = EXT_TDOP.EXT_TDOP_HAS_FIELD,
                    InputString = name,
                    InputTypedData = typedData
                };

                var hr = ioctl.TryExecute();

                return hr == HRESULT.S_OK;
            }

            public void OutputFullValue(DEBUG_TYPED_DATA typedData)
            {
                var ioctl = new ExtIoctl
                {
                    Advanced = advanced,
                    Operation = EXT_TDOP.EXT_TDOP_OUTPUT_FULL_VALUE,
                    InputTypedData = typedData
                };

                ioctl.Execute();
            }

            public void OutputSimpleValue(DEBUG_TYPED_DATA typedData)
            {
                var ioctl = new ExtIoctl
                {
                    Advanced = advanced,
                    Operation = EXT_TDOP.EXT_TDOP_OUTPUT_SIMPLE_VALUE,
                    InputTypedData = typedData
                };

                ioctl.Execute();
            }

            public void OutputTypeDefinition(DEBUG_TYPED_DATA typedData)
            {
                var ioctl = new ExtIoctl
                {
                    Advanced = advanced,
                    Operation = EXT_TDOP.EXT_TDOP_OUTPUT_TYPE_DEFINITION,
                    InputTypedData = typedData
                };

                ioctl.Execute();
            }

            public void OutputTypeName(DEBUG_TYPED_DATA typedData)
            {
                var ioctl = new ExtIoctl
                {
                    Advanced = advanced,
                    Operation = EXT_TDOP.EXT_TDOP_OUTPUT_TYPE_NAME,
                    InputTypedData = typedData
                };

                ioctl.Execute();
            }

            public void Release(DEBUG_TYPED_DATA typedData)
            {
                var ioctl = new ExtIoctl
                {
                    Operation = EXT_TDOP.EXT_TDOP_RELEASE,
                    InputTypedData = typedData
                };

                ioctl.Execute();
            }

            public DEBUG_TYPED_DATA SetFromExpr(string expr, EXT_TDF flags = 0)
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

                ioctl.Execute();

                return ioctl.OutputTypedData;
            }

            #region SetFromTypeIdAndU64

            public DEBUG_TYPED_DATA SetFromTypeIdAndU64(ulong modBase, ulong offset, uint typeId, EXT_TDF flags = 0)
            {
                var typedData = new DEBUG_TYPED_DATA
                {
                    ModBase = modBase,
                    Offset = offset,
                    TypeId = typeId
                };

                return SetFromTypeIdAndU64(typedData, flags);
            }

            public DEBUG_TYPED_DATA SetFromTypeIdAndU64(DEBUG_TYPED_DATA typedData, EXT_TDF flags = 0)
            {
                var ioctl = new ExtIoctl
                {
                    Advanced = advanced,
                    Operation = EXT_TDOP.EXT_TDOP_SET_FROM_TYPE_ID_AND_U64,
                    InputTypedData = typedData,
                    Flags = flags
                };

                ioctl.Execute();

                return ioctl.OutputTypedData;
            }

            #endregion
            #region SetFromU64Expr

            //This uses the address from DEBUG_TYPED_DATA, while Evaluate uses the "value" apprently
            public DEBUG_TYPED_DATA SetFromU64Expr(string expr, DEBUG_TYPED_DATA typedData = default(DEBUG_TYPED_DATA), EXT_TDF flags = 0)
            {
                if (expr == null)
                    throw new ArgumentNullException(nameof(expr));

                var ioctl = new ExtIoctl
                {
                    Advanced = advanced,
                    Operation = EXT_TDOP.EXT_TDOP_SET_FROM_U64_EXPR,
                    InputString = expr,
                    InputTypedData = typedData,
                    Flags = flags
                };

                ioctl.Execute();

                return ioctl.OutputTypedData;
            }

            #endregion
            #region SetPtrFromTypeIdAndU64

            public DEBUG_TYPED_DATA SetPtrFromTypeIdAndU64(ulong modBase, ulong offset, uint typeId, EXT_TDF flags = 0)
            {
                var typedData = new DEBUG_TYPED_DATA
                {
                    ModBase = modBase,
                    Offset = offset,
                    TypeId = typeId
                };

                return SetPtrFromTypeIdAndU64(typedData, flags);
            }

            public DEBUG_TYPED_DATA SetPtrFromTypeIdAndU64(DEBUG_TYPED_DATA typedData, EXT_TDF flags = 0)
            {
                var ioctl = new ExtIoctl
                {
                    Advanced = advanced,
                    Operation = EXT_TDOP.EXT_TDOP_SET_PTR_FROM_TYPE_ID_AND_U64,
                    InputTypedData = typedData,
                    Flags = flags,
                };

                ioctl.Execute();

                return ioctl.OutputTypedData;
            }

            #endregion
        }
    }
}
