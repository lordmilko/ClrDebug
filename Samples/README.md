# Samples

This directory provides a variety of sample projects demonstrating how to do common or otherwise interesting debugging tasks, with extensive
references to the CLR source code to explain how and why things work a certain way. Not all samples may necessarily pertain to
ClrDebug specifically, however may still prove relevant depending on the type of application you're trying to develop (e.g. a mixed managed debugger)

| Sample        | Description                                                                                                     |
| ------------- | --------------------------------------------------------------------------------------------------------------- |
| DacTypeDump   | Demonstrates how type/member information can be read from a process via the DAC                                 |
| DbgEngConsole | Demonstrates the principles of processing input and running an engine loop in a DbgEng based debugger           |
| NativeSymbols | Simple REPL for resolving unmanaged symbols via DbgHelp and a custom symbol store                               |
| PEReader      | Demonstrates how to read a variety of important sections from an in memory or on disk PE file                   |
| SymbolStore   | Simple managed implementation of symsrv.dll for resolving unmanaged symbols from local and online symbol stores |