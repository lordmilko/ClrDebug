# DbgEngTypedData

## Overview

This sample demonstrates how to interact with typed data using DbgEng

If you've ever written an EngExtCpp WinDbg extension, you may know about a collection of very cool classes you can use in your scripts:

| Class              | Description                                                                                                                                                        |
| ------------------ | ------------------------------------------------------------------------------------------------------------------------------------------------------------------ |
| ExtRemoteData      | Provides facilities for reading simple data types from a process' memory                                                                                           |
| ExtRemoteTyped     | Treats a memory address like a fully formed "type", with fields you can query and interact with                                                                    |
| ExtRemoteList      | Represents an abstract single or doubly linked list                                                                                                                |
| ExtRemoteTypedList | Represents a single or doubly linked list of `LIST_ENTRY` or `SINGLE_LIST_ENTRY` entries, capable of spitting out the true type of object pointed to by each entry |

These APIs are *very cool*, and make it easy to query internal datastructures (like the PEB) with minimal effort. Internally, these APIs are built on top of what I would call the *Ext Typed Data* API -
an API that is made available via the `DEBUG_REQUEST_EXT_TYPED_DATA_ANSI` `IDebugAdvanced::Request`. While ClrDebug does provide extension methods for performing all `EXT_TDOP` operations (see the methods under `DebugClient.Advanced.Request().ExtTypedDataAnsi()`), the *Ext Typed Data* API is really just an abstraction over the *true underlying* typed data APIs that DbgEng offers. EngExtCpp's implementations leave much to be desired (they don't exactly spell out how reading a `LIST_ENTRY` works, and they provide no mechanism of enumerating all available fields of a type).

This sample demonstrates how the `IDebugSymbols` interface can be used for retrieving and interacting with typed data. Two demonstrations are given

* The first sample, titled *Manual*, demonstrates how you can laboriously retrieve each little bit of data you need in order to traverse a type hierarchy in order to achieve a complex goal: dumping the list of loaded processes from a PEB
* The second sample - *Custom* - shows how the principles demonstrated in *Manual* can be used to create an object hierarchy for dynamically exploring infinitely complex objects.

This sample provides examples of how to use features from the following APIs

* `IDebugSymbols`
* `WINDBG_EXTENSION_APIS`
* `SymGetTypeInfo`

## Implementation

### Type ID

When DbgEng calls a DbgHelp function like `SymGetTypeFromName`, the `TypeIndex` member of the returned `SYMBOL_INFO` will store a number that uniquely identifies the specified type within the given module. This `TypeIndex` - referred to as a *Type Id* by DbgEng APIs - then acts as the key for all further interactions you may wish to do with that type.

In DbgEng, the most obvious way to retrieve a *Type Id* is to use the `IDebugSymbols::GetTypeId` method. When calling `GetTypeId`, you can either specify a fully qualified symbol name and no module base

```c#
var typeId = client.Symbols.GetTypeId(0, "ntdll!_PEB");
```

or a module base and relative symbol name

```c#
var ntdll = client.Symbols.GetModuleByModuleName("ntdll", 0);
var typeId = client.Symbols.GetTypeId(ntdll.Base, "_PEB");
```

Ultimately, in order to use most typed data APIs effectively you're going to need both the module base and *Type Id* of the type you're trying to interact with. Fortunately, DbgEng provides us a helper method that allows us to grab both of these values all in one go

```c#
var result = client.Symbols.GetSymbolTypeId("ntdll!_PEB");

var ntdll = result.Module;
var typeId = result.TypeId;
```

### Type Hierarchy

Given a *Type Id*, it is possible to query DbgHelp for the kind of type this represents using the [SymGetTypeInfo](https://docs.microsoft.com/en-us/windows/win32/api/dbghelp/nf-dbghelp-symgettypeinfo) function. The following lists some of the most interesting type infos you can retrieve from a given *Type Id*

| Info            | Description                                                                                                                                                        |
| --------------- | ------------------------------------------------------------------------------------------------------------------------------------------------------------------ |
| TI_GET_SYMTAG   | The type of symbol this type represents. e.g. is it a `UDT` (User Defined Type; i.e. a struct), `Data` (a struct field) or `BaseType` (primitive type e.g. `uint`) |
| TI_GET_TYPEID   | Gets the *base type* or perhaps more precisely the *base symbol* of the current type                                                                               |
| TI_GET_BASETYPE | Gets the specific primitive type of a type with tag `BaseType`                                                                                                   |

Types appear to be defined in symbols using a series of *layers*. When you retrieve a field from a `UDT`, `TI_GET_SYMTAG` will reveal your *Type Id* to be a value tagged `Data` (indicating it is a field). By calling `SymGetTypeInfo` with `TI_GET_TYPEID` on your `Data` *Type Id* it is possible to reveal get the *true* type beneath. This could potentially be a `PointerType`, in which case there may be further types beneath you can query. In this way, it is possible to know precisely what the underlying type of a value is. If you have the *Type Id* of a `_PEB_LDR_DATA*`, you are able to unwrap it to get the original `_PEB_LDR_DATA` type.

Separate to these *Type Id* layers is the concept of *base types*, which perhaps should be really called *basic types*. These represent the fundamental primitive types that
can exist in a program (items like `BOOLEAN`, `USHORT`, `ULONG`, etc). When you have a *Type Id* of tag `BaseType`, you can `SymGetTypeInfo` for `TI_GET_BASETYPE`. The type of value returned by `TI_GET_BASETYPE` is extremely poorly documented, but it returns a `BasicType` value which can be found in `cvconst.h` in the DIA SDK that ships with Visual Studio (remember that DbgHelp uses DIA internally)

### Enumerating Fields

A major limitation of EngExtCpp's `ExtTypedData` is that it does provide a mechanism for enumerating all fields that may exist on a given type. Clearly it is possible for WinDbg to know this information, as you can see all the members of a struct displayed when you use the `dt` command.

`dt` calls `SymbolTypeDumpEx` which in turn calls `SymbolTypeDumpNew` which calls the pivotal `TypeInfoFound` and then calls `DumpType`-> `DumpTypeAndReturnInfo` to dump the type. `DebugClient::GetFieldOffset` similarly calls straight into `DumpType` to get its data.

The secret to enumerating type fields is to somehow hook into `DumpTypeAndReturnInfo`. But how do we do that? The secret lies in the `Ioctl` function `WINDBG_EXTENSION_APIS`. By specifying request type `IG_DUMP_SYMBOL_INFO` we're able to call into `SymbolTypeDump` which calls into `SymbolTypeDumpNew` and caches its results. `IG_DUMP_SYMBOL_INFO` is one of the more complex Ioctls you can perform using DbgEng, although it pales in comparison to `DEBUG_REQUEST_EXT_TYPED_DATA_ANSI`.

Normally, to invoke the `IG_DUMP_SYMBOL_INFO` request in managed code, you would need to

1. Declare a `WINDBG_EXTENSION_APIS` variable
2. Set the `WINDBG_EXTENSION_APIS` variable's size
3. Populate `WINDBG_EXTENSION_APIS` from either `IDebugControl::GetWindbgExtensionApis32` or `IDebugControl::GetWindbgExtensionApis64`
4. Create a delegate for the `lpIoctlRoutine`
5. Construct a `SYM_DUMP_PARAM`, filling in every single field as required
6. Marshal any strings/callback functions you may want to pass
7. Execute the Ioctl
8. Cleanup any unmanaged resources you allocated

each time you want to dump some symbol info. Don't make any mistakes!

To simplify this process, `WINDBG_EXTENSION_APIS` is given the same special treatment that DbgEng's interfaces are given

* There is an extension method `DebugControl.GetWindbgExtensionApis()` that creates a `WinDbgExtensionAPI` type around a `WINDBG_EXTENSION_APIS` via `GetWindbgExtensionApis32` if you're in a 32-bit process or `GetWindbgExtensionApis64` if you're in a 64-bit process. I don't know when/when not to use the 32/64-bit `GetWindbgExtensionApis*` functions, but this seems reasonable to me
* `WinDbgExtensionAPI` provides thin wrapper functions around the function pointers of the `WINDBG_EXTENSION_APIS` type that automatically create and cache the required delegates for you
* The `WinDbgExtensionAPI.Ioctl()` extension method then provides built-in implementations of core Ioctl commands you may want to run, including `DumpSymbolInfo`. Every parameter on `DumpSymbolInfo` is listed as optional; just fill in the ones you need.

### Linked Lists

When attempting to list all modules loaded in a PEB, you would typically do the following

1. Get a `_PEB`
2. Get the `PEB_LDR_DATA Ldr` field of the `_PEB`
3. Get the `LIST_ENTRY InLoadOrderModuleList` of the `PEB_LDR_DATA Ldr` field

Windows typically implements (doubly) linked lists using the `LIST_ENTRY` structure. The way `LIST_ENTRY` works can be quite confusing to get one's head around, however understanding `LIST_ENTRY` is essential for querying internal data structures such as the PEB.

A `LIST_ENTRY` is a data structure defined as follows

```c++
struct LIST_ENTRY
{
    LIST_ENTRY* Flink;
    LIST_ENTRY* Blink;
}
```

`Flink` points to the next `LIST_ENTRY` in the list, and `Blink` points to the previous entry in the list. Given we have a `LIST_ENTRY InLoadOrderModuleList`, where is the data?

The key to think to understand here is that entire premise of the `LIST_ENTRY` type is a lie, and that the rules that normally apply to `LIST_ENTRY` objects does not apply to the *head* `InLoadOrderModuleList` object. First of all, you should really think of this member like this

    LIST_HEAD InLoadOrderModuleList
    
The `Flink` of our `InLoadOrderModuleList` then points to a data structure like so

```
                               LDR_DATA_TABLE_ENTRY
                               --------------------
                               LIST_ENTRY InLoadOrderLinks
InLoadOrderModuleList.Flink -> LIST_ENTRY InMemoryOrderLinks
                               LIST_ENTRY InInitializationOrderLinks
                               IntPtr DllBase
                               ...
```

The `LIST_ENTRY* Flink` of the `InLoadOrderModuleList` in fact points to the address of the `InMemoryOrderLinks` member of a `LDR_DATA_TABLE_ENTRY` structure. As such, in order to retrieve a typed `LDR_DATA_TABLE_ENTRY` object we need to perform a fixup: we need to rewind from the `InLoadOrderModuleList.Flink` several bytes to the start of the structure. This can be done either using the `IDebugSymbols::GetFieldOffset` method or from the fields dumped via the `IG_DUMP_SYMBOL_INFO` `WINDBG_EXTENSION_APIS` ioctl described above.

The list chain is then continually traversed by accessing the `Flink` member of the current item

```
                               LDR_DATA_TABLE_ENTRY                     LDR_DATA_TABLE_ENTRY
                               --------------------                     --------------------
                               LIST_ENTRY InLoadOrderLinks              LIST_ENTRY InLoadOrderLinks
InLoadOrderModuleList.Flink -> LIST_ENTRY InMemoryOrderLinks.Flink   -> LIST_ENTRY InMemoryOrderLinks
                               LIST_ENTRY InInitializationOrderLinks    LIST_ENTRY InInitializationOrderLinks
                               IntPtr DllBase                           IntPtr DllBase
                               ...                                      ...
```

If you think about how a doubly linked list would work, you'd have `Next` and `Previous` members, followed by a bunch of other members that would follow it. Conceptually, this is exactly what a `LIST_ENTRY` is - the `LIST_ENTRY` would be your `Next` and `Previous`, and then you'd have a bunch of secret members dangling off the end. The complexity here lies in the fact that your `Next` and `Previous` may actually be in the middle of the structure...meaning you've got items dangling off the end as well as off the front!

The end of a `LIST_ENTRY` chain is reached upon reaching the original `InLoadOrderModuleList` again
* If you have the address of `InLoadOrderModuleList`, you can say that the list is over when `nextEntry.Flink == ptrInLoadOrderModuleList`
* If you don't have the address of `InLoadOrderModuleList`, then you can say that the list is over when `nextEntry.Flink.Flink == InLoadOrderModuleList.Flink`. Observe that `nextEntry.Flink` could be the original `InLoadOrderModuleList`, so we have to check *its* `Flink` against the `Flink` of `InLoadOrderModuleList`

In this sample, the *Custom* sample demonstates dealing with the former case, while the *Manual* sample demonstrates the latter.

If `InLoadOrderModuleList.Flink` points to itself, that means the list is empty. This is a very important check to do.

## Gotchas

* The DbgEng documentation explicitly states that you should refrain from calling DbgHelp directly, and instead rely on DbgEng to make any APIs that rely on DbgHelp. While this sounds nice in principle, there is a lot of important information we need to retrieve from `SymGetTypeInfo`, and DbgEng simply provides no way for us to access this information. Fortunately, DbgEng exposes the process handle it uses to call `SymInitialize` to us, so you can easily call `IDebugSystemObjects::GetCurrentProcessHandle()` after the very first call to `IDebugControl::WaitForEvent()` which finalizes the engine's initialization
* `TI_GET_TYPEID` gets the *base type* of a symbol, while `TI_GET_BASETYPE` gets the *basic type*
* Struct members are of type `Data`. Be sure to unwrap them using `SymGetTypeInfo` to get their actual types
* By default, DbgEng's symbol dumper will want to print everything you dumped to the screen. Specify `DBG_DUMP.NO_PRINT` to suppress this
* When enumerating `LIST_ENTRY` items, be sure not to treat the list head as a legitimate list item. Every `LIST_ENTRY*` in a chain is a pointer to a `LIST_ENTRY` field in some struct EXCEPT in the case of the list head. In the list head's case, it is literally a `LIST_ENTRY` and nothing more. If you made a list of all the LIST_ENTRY items in your chain and one of them is in a totally different memory region, you messed up and included the list head in your results