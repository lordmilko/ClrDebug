# DbgEngConsole

The *DbgEngConsole* sample demonstrates the principles of implementing a simple console based DbgEng debugger.

When launching a process using the DbgEng API, there a specific series of steps that must be taken in order to actually be able to debug your process.

This sample assumes you have the Debugging Tools for Windows installed to `C:\Program Files (x86)\Windows Kits\10\Debuggers`

## Initializing A Debug Target

Processes can be launched using either `IDebugClient::CreateProcess`, `IDebugClient::CreateProcessAndAttach`, or via some other mechanism outside of DbgEng. However you create the process, the first thing to keep in mind is that you *must* specify `DEBUG_PROCESS` or `DEBUG_ONLY_THIS_PROCESS` in your process creation flags, no matter which method you choose. You might think that because you're calling `CreateProcessAndAttach` that DbgEng will automatically connect to your process so you won't have to worry. Wrong.

Once you've created your process, you then have to tell DbgEng to *attach* to it. When you use the `CreateProcessAndAttach` method this is automatically taken care of for you. Otherwise, you will need to call `IDebugClient::AttachProcess` directly. If you created your process with `IDebugClient::CreateProcess`, you've now got an issue - you need to get the process ID out of DbgEng, but as far as I can see that DbgEng won't provide that information to you until after it's properly attached.

Once you've signalled that you'd like to attach to your process, you must then `IDebugControl::WaitForEvent`. This will return immediately, at which point you'll now be able to query various bits of information about the process (including its `CurrentProcessSystemId` via `IDebugSystemObjects`).

## Gotchas

* You won't be able to load symbols using DbgEng if you use the version in system32, as DbgHelp won't be able to load symsrv.dll for locating symbols. Your options here are either to hook `dbghelp!SymSetSearchPath` (which will at least
let you use symbols you already have) or to use `SetDllDirectory` to tell .NET the path to your Debugging Tools for Windows installation that it should try first for locating any DLLs
* Even if DbgEng creates a process, it won't actually do anything with it until you then *attach* to it. As far as I can see, there is no way to get the process ID of a process DbgEng created if you didn't also *attach* to it
* Once you've attached to a process, it won't actually be available to the debug session until you've performed a single `IDebugClient::WaitForEvent`
* When trying to find IDs of things using DbgEng, it can be very confusing trying to figure out what a *user ID* and a *system ID* is. The *user ID* of a resource refers to the internal index number that DbgEng has assigned it - e.g. process 0, thread 0, etc. The *system ID* of a resource refers to the *actual* ID that Windows has assigned it.
* You need to monitor the `ChangeEngineState` event callback for a change in execution status (triggered by a command you ran) to update your UI to indicate that the debugger is now running again