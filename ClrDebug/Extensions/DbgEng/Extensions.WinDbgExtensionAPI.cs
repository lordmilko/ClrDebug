using System;
using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    public partial class DbgEngExtensions
    {
        #region Ioctl

        //Executes an Ioctl that merely returns a value
        public static bool Ioctl<T>(this WinDbgExtensionAPI api, IG IoctlType, out T data) where T : struct
        {
            var size = Marshal.SizeOf<T>();
            var buffer = Marshal.AllocHGlobal(size);

            try
            {
                var result = api.Ioctl(IoctlType, buffer, size) == 1;

                if (result)
                    data = Marshal.PtrToStructure<T>(buffer);
                else
                    data = default(T);

                return result;
            }
            finally
            {
                Marshal.FreeHGlobal(buffer);
            }
        }

        //Executes an Ioctl that requires a value to be passed without any member of that value being modified that the caller would need to access afterwards
        public static int Ioctl<T>(this WinDbgExtensionAPI api, IG IoctlType, T data) where T : struct
        {
            var size = Marshal.SizeOf<T>();
            var buffer = Marshal.AllocHGlobal(size);

            try
            {
                Marshal.StructureToPtr(data, buffer, false);
                
                return api.Ioctl(IoctlType, buffer, size);
            }
            finally
            {
                Marshal.DestroyStructure<T>(buffer);
                Marshal.FreeHGlobal(buffer);
            }
        }

        public static WinDbgExtensionAPIIoctls Ioctl(this WinDbgExtensionAPI api) => new WinDbgExtensionAPIIoctls(api);

        #endregion

        public class WinDbgExtensionAPIIoctls
        {
            private WinDbgExtensionAPI api;

            public WinDbgExtensionAPIIoctls(WinDbgExtensionAPI api)
            {
                this.api = api;
            }

            #region NotImplemented

            private void DisassembleBuffer()
            {
                throw new NotImplementedException();
            }

            #endregion
            #region DumpSymbolInfo

            public unsafe IoctlDumpError TryGetFieldOffset(string type, string field, out int offset)
            {
                IntPtr fieldInfo = IntPtr.Zero;
                IntPtr fieldName = Marshal.StringToHGlobalAnsi(field);

                try
                {
                    fieldInfo = CreateFieldInfo(
                        name: fieldName,
                        options: DBG_DUMP_FIELD.FULL_NAME | DBG_DUMP_FIELD.RETURN_ADDRESS
                    );

                    var result = TryDumpSymbolInfo(
                        name: type,
                        options: DBG_DUMP.NO_PRINT,
                        nFields: 1,
                        fields: fieldInfo
                    );

                    if (result == 0)
                        offset = ((FIELD_INFO*) fieldInfo)->FieldOffset;
                    else
                        offset = 0;

                    return result;
                }
                finally
                {
                    if (fieldInfo != IntPtr.Zero)
                        Marshal.FreeHGlobal(fieldInfo);

                    Marshal.FreeHGlobal(fieldName);
                }
            }

            public unsafe IoctlDumpError TryDumpSymbolInfo(
                string name = null,
                DBG_DUMP options = 0,
                long addr = 0,
                IntPtr listLink = default(IntPtr),
                IntPtr bufferOrContext = default(IntPtr),
                PSYM_DUMP_FIELD_CALLBACK callbackRoutine = null,
                int nFields = 0,
                IntPtr fields = default(IntPtr))
            {
                IntPtr namePtr = IntPtr.Zero;

                var symDumpParamSize = Marshal.SizeOf<SYM_DUMP_PARAM>();
                var symDumpParamBuffer = Marshal.AllocHGlobal(symDumpParamSize);

                try
                {
                    var symDumpParam = (SYM_DUMP_PARAM*)symDumpParamBuffer;
                    NativeMethods.RtlZeroMemory(symDumpParamBuffer, symDumpParamSize);

                    symDumpParam->size = symDumpParamSize;
                    symDumpParam->Options = options;
                    symDumpParam->addr = addr;
                    symDumpParam->listLink = listLink;
                    symDumpParam->BufferOrContext = bufferOrContext;
                    symDumpParam->nFields = nFields;
                    symDumpParam->Fields = fields;

                    if (callbackRoutine != null)
                        symDumpParam->CallbackRoutine = Marshal.GetFunctionPointerForDelegate(callbackRoutine);

                    if (name != null)
                    {
                        namePtr = Marshal.StringToHGlobalAnsi(name);
                        symDumpParam->sName = namePtr;
                    }

                    return (IoctlDumpError) api.Ioctl(IG.DUMP_SYMBOL_INFO, symDumpParamBuffer, symDumpParamSize);
                }
                finally
                {
                    if (namePtr != IntPtr.Zero)
                        Marshal.FreeHGlobal(namePtr);

                    Marshal.AllocHGlobal(symDumpParamSize);
                }
            }

            private unsafe IntPtr CreateFieldInfo(
                IntPtr name = default(IntPtr),
                IntPtr printName = default(IntPtr),
                int size = 0,
                DBG_DUMP_FIELD options = 0,
                long address = 0,
                PSYM_DUMP_FIELD_CALLBACK fieldCallback = null,
                IntPtr buffer = default(IntPtr))
            {
                var fieldInfoSize = Marshal.SizeOf<FIELD_INFO>();
                var fieldInfoBuffer = Marshal.AllocHGlobal(fieldInfoSize);

                try
                {
                    var fieldInfo = (FIELD_INFO*) fieldInfoBuffer;
                    NativeMethods.RtlZeroMemory(fieldInfoBuffer, fieldInfoSize);

                    fieldInfo->fName = name;
                    fieldInfo->printName = printName;
                    fieldInfo->size = size;
                    fieldInfo->fOptions = options;
                    fieldInfo->address = address;

                    if (fieldCallback != null && buffer != IntPtr.Zero)
                        throw new ArgumentException($"Cannot specify both '{nameof(fieldCallback)}' and '{nameof(buffer)}'");

                    if (fieldCallback != null)
                        fieldInfo->fieldCallbackOrBuffer = Marshal.GetFunctionPointerForDelegate(fieldCallback);

                    if (buffer != IntPtr.Zero)
                        fieldInfo->fieldCallbackOrBuffer = buffer;

                    return fieldInfoBuffer;
                }
                catch
                {
                    Marshal.FreeHGlobal(fieldInfoBuffer);

                    throw;
                }
            }

            #endregion
            #region NotImplemented

            private void FindFile()
            {
                throw new NotImplementedException();
            }

            private void GetAnyModuleInRange()
            {
                throw new NotImplementedException();
            }

            private void GetBusData()
            {
                throw new NotImplementedException();
            }

            private void GetCacheSize()
            {
                throw new NotImplementedException();
            }

            #endregion
            #region GetClrDataInterface

            public XCLRDataProcess GetClrDataInterface()
            {
                if (TryGetClrDataInterface(out var process))
                    return process;

                throw new InvalidOperationException("Failed to retrieve CLR interface; current target is either not a managed process or the CLR is not loaded yet.");
            }

            public unsafe bool TryGetClrDataInterface(out XCLRDataProcess process)
            {
                var size = Marshal.SizeOf<WDBGEXTS_CLR_DATA_INTERFACE>();

                var buffer = (WDBGEXTS_CLR_DATA_INTERFACE*) Marshal.AllocHGlobal(size);
                var guid = GCHandle.Alloc(typeof(IXCLRDataProcess).GUID, GCHandleType.Pinned);

                try
                {
                    buffer->Iid = guid.AddrOfPinnedObject();

                    if (api.Ioctl(IG.GET_CLR_DATA_INTERFACE, new IntPtr(buffer), size) == 1)
                    {
                        var iface = Marshal.GetObjectForIUnknown(buffer->Iface);
                        process = new XCLRDataProcess((IXCLRDataProcess)iface);
                        return true;
                    }
                    else
                    {
                        process = null;
                        return false;
                    }
                }
                finally
                {
                    Marshal.FreeHGlobal(new IntPtr(buffer));
                    guid.Free();
                }
            }

            #endregion
            #region NotImplemented

            private void GetContextEx()
            {
                throw new NotImplementedException();
            }

            private void GetCurrentProcess()
            {
                throw new NotImplementedException();
            }

            private void GetCurrentProcessHandle()
            {
                throw new NotImplementedException();
            }

            private void GetCurrentThread()
            {
                throw new NotImplementedException();
            }

            private void GetDebuggerData()
            {
                throw new NotImplementedException();
            }

            private void GetExceptionRecord()
            {
                throw new NotImplementedException();
            }

            private void GetExpressionEx()
            {
                throw new NotImplementedException();
            }

            private void GetInputLine()
            {
                throw new NotImplementedException();
            }

            private void GetKernelVersion()
            {
                throw new NotImplementedException();
            }

            private void GetPebAddress()
            {
                throw new NotImplementedException();
            }

            private void GetSetSympath()
            {
                throw new NotImplementedException();
            }

            private void GetTebAddress()
            {
                throw new NotImplementedException();
            }

            private void GetThreadOsInfo()
            {
                throw new NotImplementedException();
            }

            #endregion

            public int GetTypeSize(string Type)
            {
                var str = Marshal.StringToHGlobalAnsi(Type);

                try
                {
                    var sdp = new SYM_DUMP_PARAM
                    {
                        size = Marshal.SizeOf<SYM_DUMP_PARAM>(),
                        sName = str,
                        Options = DBG_DUMP.NO_PRINT | DBG_DUMP.GET_SIZE_ONLY
                    };

                    return api.Ioctl(IG.GET_TYPE_SIZE, sdp);
                }
                finally
                {
                    Marshal.FreeHGlobal(str);
                }
            }

            public bool IsPtr64()
            {
                if (api.Ioctl(IG.IS_PTR64, out bool result))
                    return result;

                return false;
            }

            #region NotImplemented

            private void KdContext()
            {
                throw new NotImplementedException();
            }

            private void KstackHelp()
            {
                throw new NotImplementedException();
            }

            private void LowmemCheck()
            {
                throw new NotImplementedException();
            }

            private void MatchPatternA()
            {
                throw new NotImplementedException();
            }

            private void ObsoletePlaceholder36()
            {
                throw new NotImplementedException();
            }

            private void PhysicalToVirtual()
            {
                throw new NotImplementedException();
            }

            private void PointerSearchPhysical()
            {
                throw new NotImplementedException();
            }

            private void QueryTargetInterface()
            {
                throw new NotImplementedException();
            }

            private void ReadControlSpace()
            {
                throw new NotImplementedException();
            }

            private void ReadIoSpace()
            {
                throw new NotImplementedException();
            }

            private void ReadIoSpaceEx()
            {
                throw new NotImplementedException();
            }

            private void ReadMsr()
            {
                throw new NotImplementedException();
            }

            private void ReadPhysical()
            {
                throw new NotImplementedException();
            }

            private void ReadPhysicalWithFlags()
            {
                throw new NotImplementedException();
            }

            private void ReloadSymbols()
            {
                throw new NotImplementedException();
            }

            private void SearchMemory()
            {
                throw new NotImplementedException();
            }

            private void SetBusData()
            {
                throw new NotImplementedException();
            }

            private void SetThread()
            {
                throw new NotImplementedException();
            }

            private void TranslateVirtualToPhysical()
            {
                throw new NotImplementedException();
            }

            private void TypedData()
            {
                throw new NotImplementedException();
            }

            private void TypedDataObsolete()
            {
                throw new NotImplementedException();
            }

            private void VirtualToPhysical()
            {
                throw new NotImplementedException();
            }

            private void WriteControlSpace()
            {
                throw new NotImplementedException();
            }

            private void WriteIoSpace()
            {
                throw new NotImplementedException();
            }

            private void WriteIoSpaceEx()
            {
                throw new NotImplementedException();
            }

            private void WriteMsr()
            {
                throw new NotImplementedException();
            }

            private void WritePhysical()
            {
                throw new NotImplementedException();
            }

            private void WritePhysicalWithFlags()
            {
                throw new NotImplementedException();
            }

            #endregion
        }
    }
}
