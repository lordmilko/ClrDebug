# PEReader

This sample provides a simple PE Reader. There are many like it, but this one is mine.

This code is largely based off of [System.Reflection.Metadata](https://github.com/dotnet/runtime/tree/main/src/libraries/System.Reflection.Metadata)

`System.Reflection.Metadata` has a good overall design for a PE Reader, however it suffers from a couple of issues:

* It assumes your input `Stream` has a known `Length`. If you're trying to read an image out of a processes memory, you have no idea what the length is - that's what you're reading the PE image for to try and figure out!
* Does not follow PE file structure naming conventions. The PE file format is complicated enough without having to cross reference the fields you're trying to read with what your PE reader decided to name them
* Does not fully implement the PE file specification. Where is `IMAGE_EXPORT_DIRECTORY`, how about resources?
* Not user friendly enough. Why do I have to call `ReadCodeViewDebugDirectoryData` and pass arguments to read a codeview. Why is this simply not a standard property?

Further complicating things is the confusing nature of various PE data structure names. `IMAGE_DATA_DIRECTORY`/`IMAGE_DEBUG_DIRECTORY`/`IMAGE_DEBUG_DIRECTORY_ENTRY` and `IMAGE_RESOURCE_DIRECTORY`/`IMAGE_RESOURCE_DIRECTORY_ENTRY`/`IMAGE_RESOURCE_DATA_ENTRY`
are all types you can easily conflate the meaning of if you haven't spent hours writing your own PE reader. This sample includes extensive XmlDoc comments on key structures to make clear what each structure does, where it comes from,
and how it relates and differs to other similarly named structures.

This sample is almost completely independent of *ClrDebug*, with the exception of the `IMAGE_FILE_MACHINE` type which is used
from the main *ClrDebug* assembly rather than being redeclared.

## Resources

Included in this sample is a demonstration of how to parse the resource directory of an image - arguably one of the most complex sections to parse. Unlike other sections which are often laid out
sequentially in memory, the resource directory consists of a tree hierarchy of "files", "folders" and other miscellaneous components that must be read from all over the place.

Conceptually speaking, resources are implemented as follows

```c#
class IMAGE_RESOURCE_DIRECTORY
{
    IMAGE_RESOURCE_DIRECTORY_ENTRY[] Entries;
}

class IMAGE_RESOURCE_DIRECTORY_ENTRY
{
    Either<IMAGE_RESOURCE_DIRECTORY_STRING, int> NameOrId;

    Either<IMAGE_RESOURCE_DATA_DIRECTORY, IMAGE_RESOURCE_DIRECTORY> DataOrDirectory;    
}
```

* There is a `IMAGE_RESOURCE_DIRECTORY` at the root, which points to an `IMAGE_RESOURCE_DIRECTORY_ENTRY`
* This `IMAGE_RESOURCE_DIRECTORY_ENTRY`
    * may be named (in which case its name can be found in an `IMAGE_RESOURCE_DIRECTORY_STRING`) or have an ID, and
    * may point to yet another `IMAGE_RESOURCE_DIRECTORY`, or an actual `IMAGE_RESOURCE_DATA_DIRECTORY` containing the size and location of some data
    
In reality, each structure contains a pointer to the additional structures that comprise it, and its up to you to reconstruct it properly.

In order to maintain the "purity" of the underlying data structures being read from the image, this sample achieves this by creating an additional layer on top of the data structures we're reading

So instead of the above, we have something like

```c#
class ImageResourceDirectoryInfo
{
    IMAGE_RESOURCE_DIRECTORY Directory;
    
    ImageResourceDirectoryEntryInfo Entries[];
}

class ImageResourceDirectoryEntryInfo
{
    IMAGE_RESOURCE_DIRECTORY_ENTRY Entry;
    
    IMAGE_RESOURCE_DIRECTORY_STRING Name; //If null, Id should be retrieved from Entry.Id

    Either<IMAGE_RESOURCE_DATA_DIRECTORY, IMAGE_RESOURCE_DIRECTORY> DataOrDirectory;    
}
```

The tradeoff of this approach is the hierarchy is now more complex to dig into.

For more information on the structure of the resources directory, please see the following articles

* https://docs.microsoft.com/en-us/previous-versions/ms809762(v=msdn.10)#pe-file-resources
* https://docs.microsoft.com/en-us/archive/msdn-magazine/2002/march/inside-windows-an-in-depth-look-into-the-win32-portable-executable-file-format-part-2