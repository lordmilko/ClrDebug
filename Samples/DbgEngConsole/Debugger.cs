using System;
using System.Runtime.InteropServices;
using ClrDebug;
using ClrDebug.DbgEng;

namespace DbgEngConsole
{
    class Debugger
    {
        protected DebugClient Client { get; set; }
        internal DEBUG_STATUS ExecutionStatus { get; set; }
        private bool Exit { get; set; }

        public void Run()
        {
            Console.CancelKeyPress += Console_CancelKeyPress;

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

            OpenTarget();

            //Now run the main engine loop, waiting for events and then processing user input
            EngineLoop();
        }

        protected virtual void OpenTarget()
        {
            //In the DbgEngDumpReader sample we override this method to instead open a dump file

            //DbgEng won't start debugging a process until you attach to it. You must specify DEBUG_ONLY_THIS_PROCESS or DEBUG_PROCESS else
            //the debugger won't be able to attach to it - even when using CreateProcessAndAttach()
            Client.CreateProcessAndAttach(0, "notepad", DEBUG_CREATE_PROCESS.CREATE_NEW_CONSOLE | DEBUG_CREATE_PROCESS.DEBUG_ONLY_THIS_PROCESS, 0, DEBUG_ATTACH.DEFAULT);
        }

        private void Console_CancelKeyPress(object sender, ConsoleCancelEventArgs e)
        {
            //Don't terminate our process!
            e.Cancel = true;

            //Break into the process
            if (Client != null)
                Client.Control.SetInterrupt(DEBUG_INTERRUPT.ACTIVE);
        }

        private void EngineLoop()
        {
            while (!Exit)
            {
                Client.Control.WaitForEvent(DEBUG_WAIT.DEFAULT, -1);

                //An event was received! Output our current state and prompt for user input
                Client.Control.OutputCurrentState(DEBUG_OUTCTL.ALL_CLIENTS, DEBUG_CURRENT.DEFAULT);

                InputLoop();

                //If our event callback informed us our debuggee no longer exists, it's time to exit
                Exit = ExecutionStatus == DEBUG_STATUS.NO_DEBUGGEE;
            }
        }

        protected virtual void InputLoop()
        {
            //As long as we're still in break mode, keep prompting for input. The execution status will be updated from our event callback
            //if a command is executed that results in a change of states
            while (!Exit && ExecutionStatus == DEBUG_STATUS.BREAK)
            {
                ExecutionStatus = Client.Control.ExecutionStatus;

                Client.Control.OutputPrompt(DEBUG_OUTCTL.THIS_CLIENT | DEBUG_OUTCTL.NOT_LOGGED, " ");

                var command = Console.ReadLine();

                Client.Control.OutputPrompt(DEBUG_OUTCTL.ALL_OTHER_CLIENTS, $" {command}\n");

                Execute(command);
            }
        }

        protected virtual void Execute(string command)
        {
            //The DbgEngCommands sample will override this method to provide its own custom command execution engine, however most times you'll
            //simply want to forward all commands straight on to DbgEng

            //If the command fails, an error will be printed to the screen
            Client.Control.TryExecute(DEBUG_OUTCTL.ALL_CLIENTS, command, DEBUG_EXECUTE.NOT_LOGGED);
        }

        private static DebugClient CreateDebugClient()
        {
            //DbgEng will want to load DbgHelp, which later on will want to load symsrv.dll. To make sure everyone loads out of the right directory (and not system32),
            //we need to use SetDllDirectory. If we want to use Windows' provided DbgEng/DbgHelp DLLs, symsrv.dll will be unavailable, and we'll need to hook DbgEng to manually
            //tell it where our symbols are
            NativeMethods.SetDllDirectory("C:\\Program Files (x86)\\Windows Kits\\10\\Debuggers\\" + (IntPtr.Size == 8 ? "x64" :"x86"));
            
            var dbgEng = NativeMethods.LoadLibrary("dbgeng.dll");
            var debugCreatePtr = NativeMethods.GetProcAddress(dbgEng, "DebugCreate");
            var debugCreate = Marshal.GetDelegateForFunctionPointer<DebugCreateDelegate>(debugCreatePtr);

            IntPtr debugClientPtr;
            debugCreate(DebugClient.IID_IDebugClient, out debugClientPtr).ThrowOnNotOK();
            var debugClient = new DebugClient(debugClientPtr);

            return debugClient;
        }
    }
}
