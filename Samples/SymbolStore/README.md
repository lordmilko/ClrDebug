# SymbolStore

This sample implements a simple Symbol Store for locating and downloading Windows PDBs.

When writing a debugger, an important task is being able to resolve the symbols of unmanaged modules. This is typically done using DbgHelp.
Unfortunately however, DbgHelp relies on symsrv.dll to be able to download symbols properly, which is only included
in with the DbgHelp that is part of the Debugging Tools for Windows.

This sample is largely based on [Microsoft.SymbolStore](https://github.com/dotnet/symstore) - an unsupported Microsoft project that can be used by pointing to the dotnet-tools NuGet feed.
This sample includes all of the code specific to resolving symbols for Windows PDBs from Cache and HTTP symbol stores.

This sample utilizes the [PEReader](https://github.com/lordmilko/ManagedCorDebug/tree/master/Samples/PEReader) sample for analyzing PE Metadata, and eliminates the need to pull in all of System.Reflection.Metadata (and all of its dependencies) for the purposes of utilizing its inferior PE reader.

For an example of how to use this sample for retrieving symbols from the _NT_SYMBOL_PATH,
and how DbgHelp can locate symbols in the absence of symsrv.dll, please see the [NativeSymbols](https://github.com/lordmilko/ManagedCorDebug/tree/master/Samples/NativeSymbols) sample.