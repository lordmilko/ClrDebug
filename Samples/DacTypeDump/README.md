# DacTypeDump

This sample demonstrates how assembly, module, type and member information can be extracted from a running process and dumped using the raw DAC interfaces

This sample provides examples of how to use the following APIs

* `CLRDataCreateInstance`
* `IXCLRDataProcess`
* `IXCLRDataModule`
* `ISOSDacInterface`
* `IMetaDataImport`
* `ICLRDataTarget`

## Overview

DAC interfaces can be retrieved from the `CLRDataCreateInstance` function export from your runtime's DAC library (mscordacwks, mscordaccore, etc). IXCLRDataProcess
is perhaps the "default" interface one retrieves from this function (and what you would get using an `Ioctl` for `IG_GET_CLR_DATA_INTERFACE` using DbgEng).
In reality, `CLRDataCreateInstance` simply creates a `ClrDataAccess` object; as such, it is valid to query any interface type from `CLRDataCreateInstance` that is supported by this type,
which critically includes `ISOSDacInterface` - the core interface of interacting with the DAC. Note that when `ICorDebug` creates the DAC object that it uses internally, it creates an `DacDbiInterfaceImpl`
which derives from `ClrDataAccess` (and implements the `IDacDbiInterface` interface). *That* interface is provided via `DacDbiInterfaceInstance` function which you can retrieve via `GetProcAddress`. Methods on `IDacDbiInterface` take `VMPTR` types,
which aren't exposed externally.

In order to retrieve interfaces via `CLRDataCreateInstance`, you must first define an `ICLRDataTarget` capable of reading memory from the target process. When reading process memory via `ReadProcessMemory` on Windows,
it is very important to constrain reads to being within memory page boundaries. DbgEng/mscordbi `ReadVirtual`/`ReadMemory` methods in `ICorDebug` interfaces know to do this internally, however when it comes to interfaces like `ICLRDataTarget` and
`ICorDebugDataTarget`, *you* are the one in charge of defining the read implementation, so it is your responsibility to take care of this.

From `ISOSDacInterface` we can retrieve the memory addresses of all AppDomains, from which we can retrieve the memory addresses of all assemblies and all [modules](https://stackoverflow.com/questions/645728/what-is-a-module-in-net).
Given the memory address of a module, `ISOSDacInterface` can give us a `IXCLRDataModule` (internally represented as a `ClrDataModule`). Simply looking at the members of a `IXCLRDataModule` it would appear you've hit a deadend. How do we introspect
into the actual types that have been defined within this module? The secret lies with `QueryInterface`. While `ClrDataModule` does not *implement* `IMetaDataImport`, if you `QueryInterface` for it `ClrDataModule` will retrieve the `IMetaDataImport`
that corresponds to this module and return it to you.

From here, it's simply a matter of instructing `ISOSDacInterface` to traverse the list of MethodTable addresses that are contained within the module, getting the `mdTypeDef` of each one, and then using the `IMetaDataImport` we retrieved earlier for deconstructing things further.

## Gotchas

* `ISOSDacInterface.GetAppDomainList` won't tell you the number of available AppDomains if you don't know; it's up to you to figure this out for yourself, which you can do by calling `ISOSDacInterface.GetAppDomainStoreData`
* When using `ReadProcessMemory`, be sure to constrain reads to within page boundaries. On Windows x86 and x64, pages are 4096 bytes
* To get an `IMetaDataImport` out of an `IXCLRDataModule`, simply `QueryInterface` for it
* Evidently not all MethodTables that are listed by `ISOSDacInterface.TraverseModuleMap` are actually valid. You can confirm this by generating a memory dump, then doing `!DumpModule -MT <moduleAddress>` using SOS. Investigation
shows that the address of the parent method table ISOSDacInterface.GetMethodTableData retrieves sometimes points to a bogus memory address.
* `ISOSDacInterface.GetAssemblyName` may sometimes return `E_FAIL`. Given the random nature of these failures, it's possible this is a race condition caused by the fact the process isn't stopped and running under a debugger
* According to SOS, the lower 2 bits of a method table can be used by GC to indicate that we are currently in mark phase.
As such when attempting to perform operations against method tables, it is important to clear these bits by simply doing `mt & ~3`