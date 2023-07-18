# NetCore

This sample demonstrates the principles of creating an `ICorDebug` instance for debugging a .NET Core application.

Unlike the .NET Framework, where you can simply probe `mscoree.dll` to `CLRCreateInstance` an `ICLRMetaHost` (which in turn will give you an `ICLRRuntimeInfo` and then an `ICorDebug`) there is no global library with .NET Core that you can query to get a handle on something. The recommended solution for developing .NET Core debuggers is to utilize the `dbgshim` library (e.g. `dbgshim.dll` on Windows). This creates a bit of a catch-22 however: you don't know where the required .NET Core libraries are, but you need to find `dbgshim` in order to do anything.

An important point to note is that unlike the DBI/DAC, the version of `dbgshim` you use doesn't really matter; many comments in the CLR source code stress the importance of keeping the `dbgshim` API mechanisms backwards compatible. As such, the recommended solution from Microsoft generally tends to be *simply ship `dbgshim` with your application!* This is easier said than done however

* dnSpy and Visual Studio both ship `dbgshim.dll` with themselves, and only work on Windows
* Using the `dotnet` tool to list SDKs could work (assuming its globally installed) but this is pretty hacky
* Furthermore, the version of `dbgshim` that ships with .NET is *very different* from the version that `dotnet/diagnostics` now releases. e.g. in `dotnet/diagnostics`, `InvokeStartupCallback` will call `CreateDebuggingInterfaceFromVersion` (v2 API). The debugger version encoded in the `szDebuggeeVersion` won't save you, since this doesn't actually appear to do anything
* Microsoft previously announced on GitHub they had plans to put `dbgshim` on NuGet; months or years later we now finally have [this](https://www.nuget.org/packages/Microsoft.Diagnostics.DbgShim)
* While the NuGet package may install every single `dbgshim` library into your project, they aren't exactly *referenced*, rather it seems you're supposed to `NativeLibrary.Load` the right library for the current platform by manually finding the library in the `runtimes` output folder of your project?
* Also not helping is that this `runtimes` folder isn't always created, and doesn't seem to work with older .NET Core versions. They may appear when you *publish* for a specific runtime identifier, but that isn't very helpful during development
* Obviously you could just grab the DLL from somewhere and include it as a resource, but do you really want to do that?

For the purposes of this sample, we simply try and grab `dbgshim.dll` from a runtime we're guessing is installed under `C:\Program Files\dotnet\shared\Microsoft.NETCore.App`. This is not a very robust solution - you should probably just ship `dbgshim` with your application

## DbgShim APIs

ClrDebug defines a type `DbgShim` that helpfully encapsulates all known `dbgshim` APIs, and handles the dirty work for you of calling `GetProcAddress` and then `Marshal.GetDelegateForFunctionPointer` for each function for you. As the `NativeLibrary` type is not available in .NET Standard 2.0, this wrapper type only supports Windows, however it is possible to extend it to be used on other platforms as well. When looking at the [DbgShim APIs](https://docs.microsoft.com/en-us/dotnet/framework/unmanaged-api/debugging/dotnet-debugging) you'll notice that there are a number of similarly named `CreateDebuggingInterfaceFromVersion*` and `RegisterForRuntimeStartup*` functions. The differences between each of these functions are tabulated below.

There are two common patterns for calling DbgShim's APIs: *Manual* and *Automatic*

In the *Manual* pattern, the sequence of events is usually as follows

1. Create the process (using `::CreateProcess`, `CreateProcessForLaunch` or any other mechanism)
2. Call `GetStartupNotificationEvent` to get the global event to wait on
3. `::WaitForSingleObject` on the event that was returned from `GetStartupNotificationEvent`
4. Get the path to the CLR that was loaded into the process via `EnumerateCLRs`
5. Get the version string for the process via `CreateVersionStringFromModule`
6. Create the `ICorDebug` via `CreateDebuggingInterfaceFromVersionEx`
7. Initialize your `ICorDebug` via calls to `Initialize`, `SetManagedHandler` and finally `DebugActiveProcess`

In the *Automatic* pattern, the flow is much simpler:
1. Create the process (using `::CreateProcess`, `CreateProcessForLaunch` or any other mechanism)
2. Call `RegisterForRuntimeStartup` with a `PSTARTUP_CALLBACK` that will store the `ICorDebug` event when it is retrieved
3. Wait on an event that will be set at the end of the `PSTARTUP_CALLBACK` above
4. Initialize the `ICorDebug` that was retrieved via calls to `Initialize`, `SetManagedHandler` and finally `DebugActiveProcess`

The following illustrates what `RegisterForRuntimeStartup` does internally and how it compares to the *Manual* pattern

Automatic:
```
RegisterForRuntimeStartup()
    RuntimeStartupHelper::Register()
      GetStartupNotificationEvent() - as we normally would
      New thread with proc StartupHelperThread()
      
StartupHelperThread
    InvokeStartupCallback() - assume the runtime is already loaded
        InternalGetRuntime()
        GetRuntime() - enumerate all modules in the target process to try and find a runtime module
    WaitForSingleObject() - if we failed to find the runtime module, wait on startup event returned from GetStartupNotificationEvent()
    InvokeStartupCallback()
        InternalGetRuntime() - we should find the runtime module this time
        CreateCoreDbg() - looks up several exports on mscordbi and calls the first one it finds
```
Manual:
```
EnumerateCLRs
    GetRuntime() - this is the same thing InvokeStartupCallback calls above. As of writing EnumerateCLRs is hardcoded to return at most one CLR
    
CreateDebuggingInterfaceFromVersion3 - locates the dbi, calls ICLRDebuggingLibraryProvider3 if needed
    CreateCoreDbg()
```

Generally speaking, you should use the manual pattern if
* You want to start the process suspended and resume it when you're ready
* You want to allow timing out waiting on the event returned from `GetStartupNotificationEvent` (`StartupHelperThread` will wait infinitely for the event to be signalled)

### CreateDebuggingInterfaceFromVersion

| Function                              | iDebuggerVersion | szDebuggeeVersion | szApplicationGroupId | pLibraryProvider |
| ------------------------------------- | ---------------- | ----------------- | -------------------- | ---------------- |
| CreateDebuggingInterfaceFromVersion   |                  | TRUE              |                      |                  |
| CreateDebuggingInterfaceFromVersionEx | TRUE             | TRUE              |                      |                  |
| CreateDebuggingInterfaceFromVersion2  | TRUE             | TRUE              | TRUE                 |                  |
| CreateDebuggingInterfaceFromVersion3  | TRUE             | TRUE              | TRUE                 | TRUE             |

Internally, these functions call each other as follows

* `CreateDebuggingInterfaceFromVersion()` -> `CreateDebuggingInterfaceFromVersion3(CorDebugVersion_2_0)`
* `CreateDebuggingInterfaceFromVersionEx()` -> `CreateDebuggingInterfaceFromVersion3()`
* `CreateDebuggingInterfaceFromVersion2()` -> `CreateDebuggingInterfaceFromVersion3()`

Based on this information, we can make the following conclusions

| Function                              | Description |
| ------------------------------------- | --------------------------------------------------------- |
| CreateDebuggingInterfaceFromVersion   | Do not use, as this causes the debugger to be version 2.0 |
| CreateDebuggingInterfaceFromVersionEx | Recommended API for most scenarios                        |
| CreateDebuggingInterfaceFromVersion2  | Use if you're sandboxing on Mac OS, although from my analysis `szApplicationGroupId` doesn't do anything |
| CreateDebuggingInterfaceFromVersion3  | Use if you need to specify a custom library provider      |

### RegisterForRuntimeStartup

| Function                    | lpApplicationGroupId | pLibraryProvider |
| --------------------------- | -------------------- | ---------------- |
| RegisterForRuntimeStartup   |                      |                  |
| RegisterForRuntimeStartupEx | TRUE                 |                  |
| RegisterForRuntimeStartup3  | TRUE                 | TRUE             |

Internally, these functions call each other as follows

* `RegisterForRuntimeStartup()` -> `RegisterForRuntimeStartup3()`
* `RegisterForRuntimeStartupEx()` -> `RegisterForRuntimeStartup3()`

Based on this information, we can make the following conclusions

| Function                    | Description
| --------------------------- | -------------------------------------------------------------------------------------------------------- |
| RegisterForRuntimeStartup   | Recommended API for most scenarios                                                                       |
| RegisterForRuntimeStartupEx | Use if you're sandboxing on Mac OS, although from my analysis `szApplicationGroupId` doesn't do anything |
| RegisterForRuntimeStartup3  | Use if you need to specify a custom library provider                                                     |

## Gotchas

* Attempting to define the `pCordb` parameter of the `RegisterForRuntimeStartup*` `PSTARTUP_CALLBACK` delegate as either an `object` or `ICorDebug` will cause the CLR to throw an exception - regardless of whether you stated the parameter should be marshaled as an `IUnknown` or `Interface`. This occurs due to `coreclr!CtxEntry::Init` calling `GetCurrentObjCtx()` which in turn calls `CoGetObjectContext()` - a call which is expected to always succeed. Evidently, something about the `StartupHelperThread` is not quite right, as the call to `CoGetObjectContext()` fails, causing the CLR to throw an exception which `InvokeStartupCallback` will catch, resulting in `StartupHelperThread` attempting to call your callback *again* - this time with no `pCordb` and with a `HRESULT` of `E_FAIL`. To workaround this issue, rather than declaring `pCordb` as an `IntPtr` (which is what the unit tests in `dotnet/diagnostics` do) we declare a custom marshaler and do `Marshal.GetObjectForIUnknown` in there. For whatever reason, this succeeds without issue
* If the target process starts before `GetStartupNotificationEvent` is called (either directly or via `RegisterForRuntimeStartup`), there won't be a startup event for the target CLR to set, which in turn will cause `WaitForSingleObject` to either hang or fail (depending on your timeout). In the *Manual* scenario, this can be resolved by starting the process suspended and resuming after `GetStartupNotificationEvent` has been called. While this race may be unlikely in normal scenarios, it's a lot more likely when you're stepping around in the code, let the process start before the event was created and then you're left wondering why your process has hung. In the *Automatic* scenario, `RegisterForRuntimeStartup` technically is prone to this race condition; to protect you from yourself when stepping through the code, we can still start the process suspended and resume just before `RegisterForRuntimeStartup` is called. Because `GetStartupNotificationEvent` still hasn't been called yet though, it's very important you be careful how you step. Any delay you create between calling `ResumeProcess` and `RegisterForRuntimeStartup` could hang your program
* Normally you must call `GC.KeepAlive` on any callback delegate passed to managed code to prevent that delegate being garbage collected while it is still in use. ClrDebug's `DbgShim` type automatically caches the last `PSTARTUP_CALLBACK` passed to each `RegisterForRuntimeStartup*` method. As such, attempting
to call `RegisterForRuntimeStartup*` methods multiple times without keeping the `PSTARTUP_CALLBACK` alive yourself could lead to crashes if the `PSTARTUP_CALLBACK` is invoked after having been garbage collected! Under normal circumstances, you would only ever call `RegisterForRuntimeStartup*` one time so this would not be an issue
* The `PSTARTUP_CALLBACK` delegate type is very troublesome, in both .NET Core and NativeAOT. If parameter `pCordb` is an `IntPtr`, you have to marshal it to `ICorDebug` yourself (which is annoying). In .NET Core, if `pCordb` is `ICorDebug`, the built-in marshaller will crash when attempting to create an RCW; you have to define an `ICustomMarshaler` to handle the marshalling instead. In NativeAOT, declaring `pCordb` as `ICorDebug` will causes even bigger issues: on Windows, you won't be able to marshal the parameter without a globally registered `ComWrappers` instance, and cross-platform you're completely out of luck. There does not currently seem to be anyway of defining "custom delegate marshalling" code. As such, we have no choice but to define `pCordb` as `IntPtr`. We make things more user friendly by defining `RegisterForRuntimeStartup*` extension methods that instead take a `RuntimeStartupCallback`. Our extension methods then handle the nitty gritty of marshalling the `IntPtr` -> `ICorDebug` in an appropriate way and then encapsulating the `ICorDebug` in a `CorDebug` wrapper to pass to your callback method. The `RegisterForRuntimeStartup*` method chosen by the compiler can be inferred based on the type of value your `pCordb` callback parameter is assigned to.
* In order to use `Marshal.GetDelegateForFunctionPointer` in NativeAOT, you must define an [rd.xml](https://github.com/dotnet/runtime/blob/main/src/coreclr/nativeaot/docs/rd-xml-format.md) file which is [intentionally undocumented](https://github.com/dotnet/runtime/issues/72989#issuecomment-1212614350) (you're presumably expected to exclusively use unmanaged function pointers, which aren't as user friendly). The `ClrDebug.rd.xml` file at the root of this repo contains definitions for all delegates known to ClrDebug
* When performing NativeAOT, if you wish to place your `rd.xml` files relative to the root of your solution, [you can't use $(SolutionDir)](https://stackoverflow.com/questions/635346/prebuild-event-in-visual-studio-replacing-solutiondir-with-undefined) to refer to them, as `$(SolutionDir)` isn't always defined
* You currently can't debug NativeAOT applications using F5 debugging in Visual Studio. Even if you point your `launchSettings.json` to the natively generated EXE and enable native debugging, Visual Studio still seems to think it needs to use the CoreCLR debugger to attach to the target process. This is not an issue in the *Profiler* sample, as Visual Studio evidently does see that PowerShell is an unmanaged process (PowerShell launches the CLR from unmanaged code) and so utilizes the native debugger