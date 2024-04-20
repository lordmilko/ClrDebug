# ClrDebug

[![Appveyor status](https://ci.appveyor.com/api/projects/status/exeyd1rc7147vbki?svg=true)](https://ci.appveyor.com/project/lordmilko/clrdebug)
[![NuGet](https://img.shields.io/nuget/v/ClrDebug.svg)](https://www.nuget.org/packages/ClrDebug/)

ClrDebug provides a collection of easy to use, cross platform, managed wrappers around the .NET Unmanaged API.

Rather than mess around with building layers on top of ugly COM interfaces yourself, ClrDebug provides an automatically generated
set of wrappers around *every single method* of every single interface it knows about, giving you confidence that
no underlying functionality is being hidden from you from using these wrappers.

ClrDebug aims to be a complete wrapper around all of the essential APIs you may need when developing diagnostic applications, including:
* CorDebug (`ICorDebug*`)
* Metadata (`IMetaData*`)
* Profiling (`ICorProfiler*`)
* Diagnostics Symbol Store (`ISym*`)
* `IXCLR*`/`ISOS*`/DAC
* DbgEng (`IDebug*`)
* DIA
* and more

## Getting Started

### ICorDebug

Getting started with ClrDebug is easy! You can use `CLRCreateInstance` if you like, or use the parameterless `CorDebug`
constructor which simplifies these starting steps for you

```c#
//Get an ICLRMetaHost, an ICLRRuntimeInfo, an ICorDebug and then call ICorDebug.Initialize()
var corDebug = new CorDebug();

var callback = new CorDebugManagedCallback();

//You use event handlers for some, none, or all events
callback.OnAnyEvent += (s, e) =>
{
    Console.WriteLine(e.Kind);
    e.Continue();
};

corDebug.SetManagedHandler(callback);

//Use the CreateProcess() extension method that omits lpApplicationName and contains optional parameters
var process = corDebug.CreateProcess("powershell.exe", dwCreationFlags: CreateProcessFlags.CREATE_NEW_CONSOLE);

while (true)
    Thread.Sleep(1);
```

Nifty globals (including various CLSIDs, `CLRCreateInstance` and `CLRDataCreateInstance`) can be found under the `Extensions` class.

You can do things manually

```c#
using static ClrDebug.Extensions;

var clsid = CLSID_CLRMetaHost;
var riid = typeof(ICLRMetaHost).GUID;
object ppInterface;

var hr = CLRCreateInstance(
    ref clsid,
    ref riid,
    out ppInterface
);

var metaHost = new CLRMetaHost((ICLRMetaHost) ppInterface);
```

Or use some syntactic sugar

```c#
using static ClrDebug.Extensions;

var metaHost = CLRCreateInstance().CLRMetaHost;
```

`HRESULT` values can easily be turned into exceptions by calling the `ThrowOnFailed()` or `ThrowOnNotOK()` extension methods (depending on whether or not you want to treat `S_FALSE` as an exception).
A custom `COMException` type is used to properly store the `HRESULT` enum value in the exception, rather than simply showing a meaningless error code.

In more advanced scenarios, you'll probably want to implement a type derived from `CorDebugManagedCallback` that overrides the `HandleEvent` method. By default, `HandleEvent` will invoke the event-specific event handler (e.g. `OnLoadModule`) followed by the shared event handler (`OnAnyEvent`). If you have any work that needs to be done before/after these events are fired, you can do this in your custom `HandleEvent` override. Your custom `HandleEvent` override should then either call `base.HandleEvent` to get the default event handling, or dispatch all events manually, itself. You can use `RaiseOnAnyEvent` to invoke the `OnAnyEvent` handler from a derived class.

### SOS

SOS types, including `SOSDacInterface` and `XCLRDataProcess` can be retrieved via the `CLRDataCreateInstance` extension method

```c#
using static ClrDebug.Extensions;

//Implement a custom ICLRDataTarget that will be used to interact with the target process.
//See Samples/DacTypeDump/DataTarget.cs for a basic example.
dataTarget = new DataTarget();

var sosDacInterface = CLRDataCreateInstance(dataTarget).SOSDacInterface;
```

Once you have your `SOSDacInterface`, you can easily get a `XCLRDataProcess` out of it, using ClrDebug's helpful `As` extension methods, which handle the messy work of accessing the wrapper's `Raw` property, casting it to the target interface type and creating the required wrapper type around it.

```c#
//Short for new XCLRDataProcess((IXCLRDataProcess) sosDacInterface.Raw);
var clrDataProcess = sosDacInterface.As<XCLRDataProcess>()
```

### Metadata

CLR metadata files can easily be manipulated by creating a standalone `IMetaDataDispenserEx`. ClrDebug contains a helpful extension constructor that can create a metadata dispenser for you from the `MetaDataGetDispenser` function exported by the CLR.

```c#
var disp = new MetaDataDispenserEx();

//ClrDebug's OpenScope<T> extension method simplifies the messy work of requesting an IMetaDataImport
//and wrapping it up in a MetaDataImport wrapper type
var mdi = disp.OpenScope<MetaDataImport>("C:\\ClrDebug.dll", CorOpenFlags.ofReadOnly);

//Use ClrDebug's metadata token enumeration extension methods
foreach (var type in mdi.EnumTypeDefs())
{
    //All out parameters will be wrapped up in an automatically generated struct type
    var props = mdi.GetTypeDefProps(type);
    
    Console.WriteLine(props.szTypeDef);
}
```

Files opened by an `IMetaDataDispenserEx` may be locked until the interface using those files is released.

### DIA

Normally, manipulating PDBs using DIA is very messy and painful. In ClrDebug, it's easy!

There are two ways to use DIA: using the statically linked version inside DbgHelp, and via the standalone version, using DLLs such as `msdia140.dll`.

A huge gotcha when using DIA is that it supports two methods of allocating strings. While all DIA methods *claim* to work with `BSTR` strings, in reality DIA works with either *real* `BSTR` strings (allocated on the COM heap via `SysAllocString`) or *fake* `BSTR` strings (allocated on the "normal" heap). Once a root DIA interface has been retrieved, you cannot change the string allocation mode until the module containing DIA is unloaded. Prior to retrieving a DIA interface, you must inform ClrDebug which DIA string allocation mode will be used for the life of your process. More information on this is provided in the *DbgHelp* and *msdia140* sections below.

The following shows how to use DIA in non-NativeAOT scenarios. For NativeAOT, you will likely need to define compatible unmanaged function pointers to call `SymGetDiaSession`/`SymGetDiaSource`. ClrDebug's `DllGetClassObject` extension method *is* NativeAOT compatible.

#### DbgHelp

DbgHelp contains a few secret exports that can be used to grab a reference to its underlying DIA interfaces

```c#
[DllImport("dbghelp.dll", SetLastError = true)]
internal static extern bool SymGetDiaSource(
    [In] IntPtr hProcess,
    [In] long modBase,
    [Out, MarshalAs(UnmanagedType.Interface)] out IDiaDataSource dataSource);

[DllImport("dbghelp.dll", SetLastError = true)]
internal static extern bool SymGetDiaSession(
    [In] IntPtr hProcess,
    [In] long modBase,
    [Out, MarshalAs(UnmanagedType.Interface)] out IDiaSession session);
```

Once you've loaded a module in DbgHelp, you can then grab a reference to these interfaces. Since DbgHelp will automatically create an `IDiaSession` for you, there isn't much point in obtaining the underlying `IDiaDataSource`. Unfortunately, there is no way of creating `IDiaDataSource` objects yourself. You have to go through DbgHelp's awful non-typesafe functions.

DbgHelp exclusively uses fake `BSTR` strings with DIA. Prior to attempting to do anything with DIA, you must instruct ClrDebug to interpret all DIA strings as fake `BSTR` values. This can be done by setting the `ClrDebug.Extensions.DiaStringsUseComHeap` property to `false`

```c#
using static ClrDebug.Extensions;

DiaStringsUseComHeap = false;

if (SymGetDiaSession(hProcess, modBase, out var raw))
{
    var diaSession = new DiaSession(raw);
    
    var globalScope = diaSession.GlobalScope;
}
```

### msdia140

When using the standalone version of DIA, you can use `Microsoft.Diagnostics.Tracing.TraceEvent.SupportFiles` to grab an "official" distribution of DIA from Microsoft. We don't want any of the other files in this package, so we can potentially just add an MSBuild directive to copy `msdia140.dll` to our output directory. Ensuring these files also get copied across Project References in your solution can be tricky. One potential solution is to do the following:

```xml
<!-- I like to use "x64" instead of "amd64". Customize these as you like -->
<None Include="$(TraceEventSupportFilesBase)native\x86\msdia140.dll" CopyToOutputDirectory="PreserveNewest" Visible="False" Link="x86\%(FileName)%(Extension)" />
<None Include="$(TraceEventSupportFilesBase)native\amd64\msdia140.dll" CopyToOutputDirectory="PreserveNewest" Visible="False" Link="x64\%(FileName)%(Extension)" />
```

Unlike DbgHelp, which exclusively uses fake `BSTR` strings, `msdia140` supports using *either* real `BSTR` strings or fake `BSTR` strings. The string allocation method DIA uses is determined based on the CLSID that is passed to `DllGetClassObject`. `CLSID_DiaSource` specifies that real `BSTR` values should be used, while `CLSID_DiaSourceAlt` specifies that fake `BSTR` values should be used. There isn't really any difference between them, except for the fact that if you also want to create a `CLSID_DiaStackWalker`, you must use `CLSID_DiaSource`, but if you're *also* planning to use DbgHelp's version of DIA, you'll need to use `CLSID_DiaSourceAlt`

As working with `DllGetClassObject` / `IClassFactory` can be quite messy, ClrDebug provides some extension methods that make this a lot easier

```c#
using static ClrDebug.Extensions;

//You can either PInvoke LoadLibrary, or use NativeLibrary.Load (in .NET 5+)
var hModule = LoadLibrary("C:\\msdia140.dll");

//Decide whether you want to use real BSTR or fake BSTRs in your process
DiaStringsUseComHeap = false;

//Now retrieve an IClassFactory and create the IDiaDataSource
var classFactory = DllGetClassObject(hModule).ClassFactory(DiaStringsUseComHeap ? CLSID_DiaSource : CLSID_DiaSourceAlt);
var dataSource = new DiaDataSource(classFactory.CreateInstance<IDiaDataSource>());
```

Once you have a `DiaDataSource`, you'll likely want to call either `LoadDataForExe` or `LoadDataFromPdb`, followed by `OpenSession` to get going. See the DIA2Dump sample in `DIA SDK\Samples\DIA2Dump` under your Visual Studio installation for some examples of using DIA (you may need the the Desktop development with C++ workload installed to see this folder)

If you choose not to use ClrDebug's extension methods, watch out when using .NET 8! When a delegate emits an RCW, it specifically emits a "classic" `System.__ComObject` RCW. These RCWs are not compatible with source generated COM that is used in .NET 8/Native AOT. Thus, you must ensure that any delegates you use instead emit an `IntPtr`, and then use ClrDebug's `GetObjectForIUnknown` extension method to correctly create a source generated COM compatible RCW.

### DbgEng

Due to an oversight by Microsoft, the RPC proxy types that are created when using `DebugConnect` do not respond correctly to a `QueryInterface` for `IUnknown`. This completely violates the COM specification, and prevents the CLR from creating RCWs around these objects. To circumvent this, ClrDebug implements its own custom RCW/VTable definitions for use with DbgEng. A consequence of this is that ClrDebug's DbgEng wrappers are not (currently) compatible with NativeAOT.

To start using DbgEng, use either `DebugCreate` or `DebugConnect` to create a `DebugClient. It is recommended to use a modern version of DbgEng, rather than the version located in system32. The `Microsoft.Debugging.Platform.DbgEng` NuGet package can be used to include a redistributable version of DbgEng in your project. (consider including `Microsoft.Debugging.Platform.SymSrv` as well for proper symbol resolution)

```c#
var hModule = LoadLibrary("C:\\dbgeng.dll");
var pDebugCreate = GetProcAddress(hModule, "DebugCreate");

var debugCreate = Marshal.GetDelegateForFunctionPointer<DebugCreateDelegate>(pDebugCreate);

debugCreate(typeof(IDebugClient).GUID, out var pDebugClient).ThrowDbgEngNotOK();

var debugClient = new DebugClient(pDebugClient);
```

`DebugClient` contains extension properties that provide access to the various sub-interfaces that you would normally `QueryInterface` off of it.

```c#
debugClient.Control.Execute(DEBUG_OUTCTL.THIS_CLIENT, "k", DEBUG_EXECUTE.DEFAULT);
```

When you are done using your `DebugClient`, it is recommended to call `Dispose` on it prior to unloading `dbgeng.dll`. `DebugClient.Dispose` will automatically call `Dispose` on all sub-interface wrappers that you used during its lifetime. If you unload `dbgeng.dll` while there are still live DbgEng interface objects, your program will crash when these RCWs attempt to `Release` their remaining references on the finalizer thread. If, instead of using these extension properties, you use ClrDebug's `As<T>` extension methods, or manually create new wrapper objects from the `DebugClient.Raw` property directly, you may find yourself with stray un-released RCWs that may blow up your process when finalized after you've already unloaded `dbgeng.dll`. Ensuring RCW's have been properly disposed prior to unloading their DLL is a common .NET problem, and is not something specific to ClrDebug.

When working with `HRESULT` values returned from DbgEng COM methods, use the `ThrowDbgEngNotOK` and `ThrowDbgEngFailed` extension methods, rather than the usual `ThrowOnNotOK` and `ThrowOnFailed` extension methods. Certain `HRESULT` values have specific meanings within the context of DbgEng (e.g. `E_NOINTERFACE` doesn't have anything to do with "interfaces"), and ClrDebug will automatically wrap these `HRESULT` values up in a custom exception type that more properly explains what exactly is going on.

## Features

ClrDebug provides a variety of features to make developing diagnostic applications easier, which can be broken down into the following categories

### Types

* Wrapper types that implement methods for all primary/secondary interfaces for a given type (`ICorDebugProcess`, `ICorDebugProcess2`)
* Proper inheritance hierarchies; `CorDebugProcess` inherits from `CorDebugController`, which is where all of the `ICorDebugController` wrappers are implemented
* All interfaces contained in the CorDebug IDL files - not just the ones emitted to TLBs by default
* Type safe numeric values, such as `mdToken` variants, `CORDB_ADDRESS` and `CLRDATA_ADDRESS` used in all structures/method declarations where appropriate
    * Automatic implicit conversions between different token types, and correct conversions between `CORDB_ADDRESS` and `CLRDATA_ADDRESS`
* Event handler enabled callback wrappers
* Automatically generated event args, containing with XmlDoc documentation and lazily evaluated wrapper properties
* Full access to the underlying native COM APIs
* CoClasses for easy type instantiation where required

### Methods / Properties

* Wrappers around all the common COM patterns
    * Does some method emit an array? ClrDebug will call it twice - once to get the get the size of the buffer, and again to actually fill in the buffer
    * Does the method start with `Is*`, take no parameters and return a `HRESULT`? It'll be compared against `S_OK` to turn it into a `bool`
    * Is an interface an enumerator with the standard `Skip`/`Reset`/`Next` methods? It's now an `IEnumerable<T>`
* Two wrapper methods for every COM method: one that returns a `HRESULT` (`TryCreateProcess`) and one with exception handling (`CreateProcess`) that simply calls the `HRESULT` variant and validates the result
* Getters and/or setters where appropriate for easier debugging/exploration
* Intelligent object creation for abstract data types. If an object emits an `ICorDebugValue`, it will be wrapped via `CorDebugValue.New` which will figure out which derived wrapper we should use
* Result Structs that encapsulate output values when multiple values are emitted out of a COM method
* Correct marshalling of arrays and pointers
* `bool` used on all method parameters/struct members where it should be used
* CLS compliant types; all methods/structs use `int`/`long` on parameters/fields to avoid annoying explicit casting
* `Request` methods on `Dacp*` structs, mirroring the behavior of their unmanaged counterparts
* Extension methods around particularly complex operations, including
    * Querying for specific interfaces from a method
    * Reading/writing complex structures to virtual memory
    * Getting and properly initializing + setting thread context types
    * Launching processes
    * Enumerating the enumerators of `IMetaDataImport` and `IXCLR*` interfaces

### User Experience

* Full XmlDoc documentation on all enumerations, structs, COM interfaces and COM Wrapper types extracted from [docs.microsoft.com](https://docs.microsoft.com/en-us/dotnet/framework/unmanaged-api/debugging/debugging-interfaces),
with proper cross references to types, properties and methods contained within XmlDocs
* Debugger displays on all structs, making it much easier to debug without having to expand things
* User friendly exceptions. No more having to lookup what the error code in a given `COMException` means; the relevant `HRESULT` enum member will be clearly displayed
* `ToString` overrides on any wrapper that contains a `Name` property

## Troubleshooting

ClrDebug's wrapper definitions are automatically generated based on common COM method patterns, however in some cases, certain cases methods may require the use of non-standard patterns, or even trip over bugs in the CLR that need to be worked around.

In the event you find that one of ClrDebug's wrapper methods isn't behaving as expected, you can try and perform the following troubleshooting steps

* Does it work when you call the underlying COM method directly from the `Raw` property of the wrapper object? (e.g. methods that accept a buffer typically allow passing `null` to get the size of the buffer to then allocate...but you may find on a given method that that's not actually allowed!)
* Does ClrDebug's COM method definition match what is listed on MSDN?
* Does ClrDebug's wrapper method definition look like it's doing the wrong thing? e.g. not initializing a buffer variable correctly or ignoring an `out` parameter
* Does the CLR source code give any hint as to what the issue may be? mscordbi's source code can be found [here](https://github.com/dotnet/runtime/tree/main/src/coreclr/debug/di) and the SOS/XCLR DAC interfaces can be found [here](https://github.com/dotnet/runtime/blob/main/src/coreclr/debug/daccess/request.cpp)
* If you otherwise can't figure it out, feel free to open an [issue](https://github.com/lordmilko/ClrDebug/issues). The only circumstance in which you should ever have to resort to using the `Raw` COM interfaces is when a COM method actually *does* fill in some of its `out` parameters on failure (ClrDebug assumes that all `out` parameters should be `default` on failure). Otherwise, if you find yourself having to resort to using the raw COM methods, this probably indicates there's a bug in ClrDebug! Please open an issue so I get this fixed. Thanks

## Samples

Writing a debugger is hard. ClrDebug provides a set of [samples](https://github.com/lordmilko/ClrDebug/tree/master/Samples) for a variety of different tasks one might need to
perform when developing a debugger, be it mixed, managed or native. Unlike other samples (such as MDbg) which try and demonstrate everything at once, each ClrDebug sample
is short, self-contained, and tries to demonstrate a simple concept with ample documentation and references to why certain decisions have been made based on analysis of the CLR source code.