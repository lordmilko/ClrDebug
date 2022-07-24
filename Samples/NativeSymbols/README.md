# NativeSymbols

![NativeSymbols](https://raw.githubusercontent.com/lordmilko/ClrDebug/master/assets/NativeSymbols.png)

The *NativeSymbols* sample provides a simple REPL for resolving symbols from unmanaged assemblies. *NativeSymbols* accepts expressions in the form

    <fileName>[!<expression>]

where `<fileName>` is one of

* an absolute path to a file (`C:\Windows\notepad.exe`)
* a file in system32 without extension (`kernel32`)
* a file in system32 with extension (`kernel32.dll`)
* `this` (which is resolved to the path of `NativeSymbols.exe`)

and `<expression>` is a symbol or wildcard expression that should be resolved from the file.

Note that unlike a real debugger, this sample does not support specifying wildcard characters in the `<fileName>` component of the symbol to resolve. This is because the way this sample works is it loads arbitrary files on disk to then retrieve their symbols; in a real debugger, the scope of available modules would be limited to those that have already been loaded into the process, thereby allowing wildcard module searches to be performed.

By default, only function/method symbols will be displayed. To display all all symbols in the DLL, specify `-a`. To specify just user defined types (UDTs), specify `-t`

    ntdll!*peb* -t

In addition, while this sample is principally designed around demonstrating how unmanaged symbols can be resolved from a symbol store, DbgHelp is also capable of resolving symbols from managed PDBs,
although those symbols likely wouldn't mean much once the managed methods have been JITted.

## Implementation

In order to locate symbol PDBs using DbgHelp, symsrv.dll must be present in the same directory as DbgHelp.dll. While DbgHelp does come with Windows, symsrv.dll is only present in the *Debugging Tools for Windows*, effectively creating a huge dependency on this arbitrary piece of software being installed (and *locatable*) on your application's user's computers. While there are other workarounds available (such as shipping DbgHelp and symsrv.dll with your application), this sample tackles this problem by implementing a rudimentary symbol client on top of the [SymbolStore](https://github.com/lordmilko/ClrDebug/tree/master/Samples/PEReader) sample.

If the `_NT_SYMBOL_PATH` environment variable is defined on your computer, the symbol client deconstructs this and forms a *symbol store chain* that will be used to locate your PDBs. Otherwise, a default symbol store chain will be created from `http://msdl.microsoft.com/download/symbols` with `%temp%\symbols` acting as your local cache. DbgHelp is then initialized, and is told to look in our symbol cache folder in the absence of symsrv.dll being available.

When attempting to resolve a for a module that hasn't been seen before, the module will first be passed to our symbol client to pre-populate our local symbol cache with that modules' symbols if they aren't there already. After we know any available symbols have been resolved, we then register the module with DbgHelp. Having already downloaded the modules symbols, DbgHelp is successfully able to locate and consume them despite the fact symsrv.dll is unavailable.

If no symbols could be found for a given module in the symbol store chain, DbgHelp will still try and find symbols for module using some basic heuristics. If a module was locally built and its PE metadata points to a PDB on your system, DbgHelp will successfully locate this PDB and you'll be able to resolve symbols.

Despite what you may think, DbgHelp's `SymEnumSymbols` function does not in fact enumerate all symbols; rather, it appears to only enumerate symbols of type `Function` or `PublicSymbol` (which pretty much seems to be functions too). To *actually* enumerate all symbols, one must use the `SymSearch` function instead. Typically you would instruct `SymSearch` to display top level (global) symbols only, however for the purposes of this sample we display nested symbols as well (such as UDT fields, denoted as type `Data`).

## Gotchas

* [Microsoft.SymbolStore](https://github.com/dotnet/symstore) (which our *SymbolStore* sample is based on) combines base HTTP URLs with the relative path to your PDB via the `Uri.TryCreate` method; a side effect of this is that part of the base URL will be truncated if it does not end in a trailing slash. For consistency with *Microsoft.SymbolStore* (in case you decide to use that instead), our *SymbolStore* sample retains this dodgy URI creation behavior, which *NativeSymbols* demonstrates how to work around
* `SymEnumTypes` does not allow specifying a mask; as such, it's better to use `SymEnumTypesByName` instead
* Not all symbols can be used with all symbol functions. You can't `SymFromAddr` a UDT for example