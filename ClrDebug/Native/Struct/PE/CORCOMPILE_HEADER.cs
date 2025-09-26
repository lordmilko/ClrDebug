using System;

namespace ClrDebug
{
    // This structure is pointed to by the code:IMAGE_COR20_HEADER (see file:corcompile.h#ManagedHeader)
    // See the file:../../doc/BookOfTheRuntime/NGEN/NGENDesign.doc for more
    public struct CORCOMPILE_HEADER
    {
        // For backward compatibility reasons, VersionInfo field must be at offset 40, ManifestMetaData
        // must be at 88, PEKind must be at 112/116 bytes, Machine must be at 120/124 bytes, and
        // size of CORCOMPILE_HEADER must be 164/168 bytes.  Be careful when you modify this struct.
        // See code:PEDecoder::GetMetaDataHelper.
        public uint Signature;
        public ushort MajorVersion;
        public ushort MinorVersion;

        public IMAGE_DATA_DIRECTORY HelperTable;    // Table of function pointers to JIT helpers indexed by helper number
        public IMAGE_DATA_DIRECTORY ImportSections; // points to array of code:CORCOMPILE_IMPORT_SECTION
        public IMAGE_DATA_DIRECTORY Dummy0;
        public IMAGE_DATA_DIRECTORY StubsData;      // contains the value to register with the stub manager for the delegate stubs & AMD64 tail call stubs
        public IMAGE_DATA_DIRECTORY VersionInfo;    // points to a code:CORCOMPILE_VERSION_INFO
        public IMAGE_DATA_DIRECTORY Dependencies;   // points to an array of code:CORCOMPILE_DEPENDENCY
        public IMAGE_DATA_DIRECTORY DebugMap;       // points to an array of code:CORCOMPILE_DEBUG_RID_ENTRY hashed by method RID
        public IMAGE_DATA_DIRECTORY ModuleImage;    // points to the freeze dried  Module structure
        public IMAGE_DATA_DIRECTORY CodeManagerTable;  // points to a code:CORCOMPILE_CODE_MANAGER_ENTRY
        public IMAGE_DATA_DIRECTORY ProfileDataList;// points to the list of code:CORCOMPILE_METHOD_PROFILE_LIST
        public IMAGE_DATA_DIRECTORY ManifestMetaData; // points to the native manifest metadata
        public IMAGE_DATA_DIRECTORY VirtualSectionsTable;// List of CORCOMPILE_VIRTUAL_SECTION_INFO. Contains a list of Section
                                                         // ranges for debugging purposes. There is one entry in this table per
                                                         // ZapVirtualSection in the NGEN image.  This data is used to fire ETW
                                                         // events that describe the various VirtualSection in the NGEN image. These
                                                         // events are used for diagnostics and performance purposes. Some of the
                                                         // questions these events help answer are like : how effective is IBC
                                                         // training data. They can also be used to have better nidump support for
                                                         // decoding virtual section information ( start - end ranges for each
                                                         // virtual section )

        public IntPtr ImageBase;      // Actual image base address (ASLR fakes the image base in PE header while applying relocations in kernel)
        public CorCompileHeaderFlags Flags;          // Flags, see CorCompileHeaderFlags above

        public CorPEKind PEKind;         // CorPEKind of the original IL image

        public COMIMAGE_FLAGS COR20Flags;     // Cached value of code:IMAGE_COR20_HEADER.Flags from original IL image
        public short Machine;        // Cached value of _IMAGE_FILE_HEADER.Machine from original IL image
        public short Characteristics;// Cached value of _IMAGE_FILE_HEADER.Characteristics from original IL image

        public IMAGE_DATA_DIRECTORY EEInfoTable;    // points to a code:CORCOMPILE_EE_INFO_TABLE

        // For backward compatibility (see above)
        public IMAGE_DATA_DIRECTORY Dummy1;
        public IMAGE_DATA_DIRECTORY Dummy2;
        public IMAGE_DATA_DIRECTORY Dummy3;
        public IMAGE_DATA_DIRECTORY Dummy4;
    };
}
