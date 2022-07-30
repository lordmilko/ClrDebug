using System;
using System.Runtime.InteropServices;
using ClrDebug.DbgEng;
using SymStore;

namespace ClrDebug.Tests.DbgEng
{
    class Debugger
    {
        internal DebugClient Client { get; set; }
        internal DEBUG_STATUS ExecutionStatus { get; set; }

        private SymbolClient symbolClient = new SymbolClient();

        public void Run()
        {
            //Create our IDebugClient wrappers
            var client = CreateDebugClient();
            Client = client;

            //Initialize callbacks
            Client.OutputCallbacks = new OutputCallbacks();
            Client.EventCallbacks = new EventCallbacks(this);

            //Configure settings
            Client.Control.EngineOptions = DEBUG_ENGOPT.INITIAL_BREAK | DEBUG_ENGOPT.FINAL_BREAK;
            Client.Symbols.SymbolOptions = SYMOPT.CASE_INSENSITIVE | SYMOPT.UNDNAME | SYMOPT.NO_CPP |
                                           SYMOPT.OMAP_FIND_NEAREST | SYMOPT.DEFERRED_LOADS;

            //DbgEng won't start debugging a process until you attach to it. You must specify DEBUG_ONLY_THIS_PROCESS or DEBUG_PROCESS else
            //the debugger won't be able to attach to it - even when using CreateProcessAndAttach()
            Client.CreateProcessAndAttach(0, "notepad", DEBUG_CREATE_PROCESS.CREATE_NEW_CONSOLE | DEBUG_CREATE_PROCESS.DEBUG_ONLY_THIS_PROCESS, 0, DEBUG_ATTACH.DEFAULT);

            Client.Control.WaitForEvent(DEBUG_WAIT.DEFAULT, -1);

            var handle = Client.SystemObjects.CurrentProcessHandle;

            //The test host automatically loads DbgHelp from system32; so even if we were using the Debugging Tools for Windows' DbgEng, we wouldn't be able to also
            //use its DbgHelp + symsrv for resolving symbols. As such, in both scenarios we must tell DbgHelp where to find our symbols; this whole operation is predicated on the symbols
            //we need for our tests already having been cached previously. DbgEng sets search path after WaitForEvent() has been called to initialize the process; as such
            //right here is the the exact time to override the path
            NativeMethods.SymSetSearchPath(new IntPtr(handle), symbolClient.CacheStore.CacheDirectory);
        }

        public void EnsurePDB(string modulePath)
        {
            symbolClient.GetPdb(modulePath);
        }

        private static DebugClient CreateDebugClient()
        {
            //The test host loads system32's DbgHelp itself so there's no point in us trying to use the Debugging Tools for Windows' DbgEng
            var dbgEng = NativeMethods.LoadLibrary("dbgeng.dll");
            var debugCreatePtr = NativeMethods.GetProcAddress(dbgEng, "DebugCreate");
            var debugCreate = Marshal.GetDelegateForFunctionPointer<DebugCreateDelegate>(debugCreatePtr);

            //var proxy = new DbgEngProxy();

            IntPtr debugClientPtr;
            debugCreate(DebugClient.IID_IDebugClient, out debugClientPtr).ThrowOnNotOK();
            var debugClient = new DebugClient(debugClientPtr);

            return debugClient;
        }
    }
}
