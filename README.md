# ClrDebug

[![Appveyor status](https://ci.appveyor.com/api/projects/status/exeyd1rc7147vbki?svg=true)](https://ci.appveyor.com/project/lordmilko/clrdebug)
[![NuGet](https://img.shields.io/nuget/v/ClrDebug.svg)](https://www.nuget.org/packages/ClrDebug/)

ClrDebug provides a collection of easy to use, managed wrappers around the .NET Unmanaged API.

Rather than mess around with building layers on top of ugly COM interfaces, ClrDebug provides an automatically generated
wrappers - via the awesome [ComWrapper](https://github.com/lordmilko/ComWrapper) library - around *every single method* of every single interface it knows about, giving you confidence that
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

## Samples

Writing a debugger is hard. ClrDebug provides a set of [samples](https://github.com/lordmilko/ClrDebug/tree/master/Samples) for a variety of different tasks one might need to
perform when developing a debugger, be it mixed, managed or native. Unlike other samples (such as MDbg) which try and demonstrate everything at once, each ClrDebug sample
is short, self-contained, and tries to demonstrate a simple concept with ample documentation and references to why certain decisions have been made based on analysis of the CLR source code.