using System;

namespace ClrDebug.DbgEng
{
    public static partial class DbgEngExtensions
    {
        //List of "well known" module index kinds (returned by ISvcModuleIndexProvider::GetModuleIndexKey)

        public static readonly Guid DEBUG_MODULEINDEXKEY_GUID = new Guid("DF45233D-4B67-40F7-8708-4ED91D7AE875");
        public static readonly Guid DEBUG_MODULEINDEXKEY_GNU_BUILDID = new Guid("192E4E9B-C62F-47F6-B77E-96D9399945D4");
        public static readonly Guid DEBUG_MODULEINDEXKEY_TIMESTAMP_IMAGESIZE = new Guid("03339721-75E7-4A09-8B28-FCC73A8D1ABF");

        #region Capability Definitions

        /// <summary>
        /// Supported on a step controller service, this defines certain capabilities of how the step controller can move the target. enum ServiceCapsMotionKind defines the various items in this set.
        /// </summary>
        public static readonly Guid DEBUG_SERVICECAPS_MOTION = new Guid("D7984BEF-AD2F-4188-A047-C21653428038");

        /// <summary>
        /// Supported on any service, this defines whether and in what form multiple threads may access the service. Note that a service which supports this capability has responsibility to determine transitivity on its dependencies.
        /// A service cannot, for instance, declare itself free threaded and then make unguarded calls to a dependent service which is *NOT* free threaded. enum ServiceCapsThreadingKind defines the various items in this set.
        /// </summary>
        public static readonly Guid DEBUG_SERVICECAPS_THREADING = new Guid("D209C291-7B45-473D-8249-D0DDBFDBF870");

        /// <summary>
        /// The unique identifier which describes the AMD64 (x86-64) architecture. This corresponds directly to IMAGE_FILE_MACHINE_AMD64. This is also DEBUG_COMPONENTAGGREGATE_MACHINEARCH_AMD64.
        /// </summary>
        public static readonly Guid DEBUG_ARCHDEF_AMD64 = new Guid("4BC151FE-5096-47E3-8B1E-2093F20BB979");

        /// <summary>
        /// The unique identifier which describes the X86/I386 (x86-32) architecture. This corresponds directly to IMAGE_FILE_MACHINE_I386. This is also DEBUG_COMPONENTAGGREGATE_MACHINEARCH_X86.
        /// </summary>
        public static readonly Guid DEBUG_ARCHDEF_X86 = new Guid("EDFD8AD0-1369-431D-B574-33E72CF1B12E");

        /// <summary>
        /// The unique identifier which describes the ARM64 architecture. This corresponds directly to IMAGE_FILE_MACHINE_ARM64. This is also DEBUG_COMPONENTAGGREGATE_MACHINEARCH_ARM64.
        /// </summary>
        public static readonly Guid DEBUG_ARCHDEF_ARM64 = new Guid("71DCF2FF-BBD0-4300-A37A-3B04F4F9713B");

        /// <summary>
        /// The unique identifier which describes the ARM32 architecture. This correponds to IMAGE_FILE_MACHINE_ARM / IMAGE_FILE_MACHINE_ARMNT. This is also DEBUG_COMPONENTAGGREGATE_MACHINEARCH_ARM32.
        /// </summary>
        public static readonly Guid DEBUG_ARCHDEF_ARM32 = new Guid("1C48E7A8-CD38-477E-8661-5718A315810D");

        /// <summary>
        /// Corresponds to SvcOSPlatWindows. This represents the Windows platform.
        /// </summary>
        public static readonly Guid DEBUG_PLATDEF_WINDOWS = new Guid("72911516-8FD9-4CF9-82E9-F316FDCA7474");

        /// <summary>
        /// Corresponds to SvcOSPlatLinux. This represents the Linux platform.
        /// </summary>
        public static readonly Guid DEBUG_PLATDEF_LINUX = new Guid("0EF7E0F9-DB8E-4D84-BBEA-16274A4B14DE");

        /// <summary>
        /// Corresponds to SvcOSPlatUNIX. This represents an unidentified UNIX variant (which may be Linux, etc...)
        /// </summary>
        public static readonly Guid DEBUG_PLATDEF_UNIX = new Guid("DC2EEEFF-D1F4-41F1-A829-687DFD6DC44A");

        /// <summary>
        /// Corresponds to SvcOSPlatMacOS. This represents the MacOS platform.
        /// </summary>
        public static readonly Guid DEBUG_PLATDEF_MACOS = new Guid("4CCE3765-278A-4AAB-A825-28C8E54699CA");

        /// <summary>
        /// Corresponds to SvcOSPlatiOS. This represents the iOS platform.
        /// </summary>
        public static readonly Guid DEBUG_PLATDEF_IOS = new Guid("812B2757-9303-4008-A333-67534130F421");

        /// <summary>
        /// Corresponds to SvcOSPlatChromeOS. This represents the Chrome OS or Chronium OS platforms.
        /// </summary>
        public static readonly Guid DEBUG_PLATDEF_CHROMEOS = new Guid("56F7C7EA-AB44-4DF0-BEE8-8554C0A58893");

        /// <summary>
        /// Corresponds to SvcOSPlatAndroid. This represents the Android platform.
        /// </summary>
        public static readonly Guid DEBUG_PLATDEF_ANDROID = new Guid("70C591E9-9156-41D0-8637-8BEBA93D539C");

        #endregion
        #region Core Components

        /// <summary>
        /// A cache layer which sits above a service which implements ISvcMemoryAccess and provides caching functionality for the underlying memory. This component can be used as a cache on any ISvcMemoryAccess based service.
        /// It will mirror the "services" provided by its target layer.
        /// </summary>
        public static readonly Guid DEBUG_COMPONENT_MEMORY_CACHE = new Guid("DAD78CB5-98DE-4445-9571-9362077EE170");

        /// <summary>
        /// Q: Need this... Or higher granulatity...? DEBUG_COMPONENT_VIRTUAL_TO_PHYSICAL_TRANSLATOR A layer which translates virtual to physical addresses for a given machine.
        /// </summary>
        public static readonly Guid DEBUG_COMPONENT_VIRTUAL_TO_PHYSICAL_TRANSLATOR = new Guid("B6EF76C8-2D21-45CB-AD11-20507000E78C");

        #endregion
        #region Aggregate Components

        //These are aggregations of individual components which provide multiple services designed to operate
        //at a specific layer of the target composition stack.  Instead of building a "target" out of many individual
        //service components, an aggregate component can be constructed to provide this set of services.

        /// <summary>
        /// A component which provides the architecture specific definitions of the AMD64 architecture.<para/>
        /// Components Aggregated:
        ///     DEBUG_COMPONENTSVC_MACHINEARCH_AMD64_PAGETABLEREADER
        ///     DEBUG_COMPONENTSVC_MACHINEARCH_AMD64_ARCHINFO
        /// </summary>
        public static readonly Guid DEBUG_COMPONENTAGGREGATE_MACHINEARCH_AMD64 = new Guid("4BC151FE-5096-47E3-8B1E-2093F20BB979");

        /// <summary>
        /// A component which provides the architecture specific definitions of the X86 architecture. Components Aggregated DEBUG_COMPONENTSVC_MACHINEARCH_X86_PAGETABLEREADER DEBUG_COMPONENTSVC_MACHINEARCH_X86_ARCHINFO
        /// </summary>
        public static readonly Guid DEBUG_COMPONENTAGGREGATE_MACHINEARCH_X86 = new Guid("EDFD8AD0-1369-431D-B574-33E72CF1B12E");

        /// <summary>
        /// A component which provides the architecture specific definitions of the ARM64 architecture.<para/>
        /// Components Aggregated:
        ///     DEBUG_COMPONENTSVC_MACHINEARCH_ARM64_PAGETABLEREADER
        ///     DEBUG_COMPONENTSVC_MACHINEARCH_ARM64_ARCHINFO
        /// </summary>
        public static readonly Guid DEBUG_COMPONENTAGGREGATE_MACHINEARCH_ARM64 = new Guid("71DCF2FF-BBD0-4300-A37A-3B04F4F9713B");

        /// <summary>
        /// A component which provides the architecture specific definitions of the ARM architecture.<para/>
        /// Components Aggregated:
        ///     DEBUG_COMPONENTSVC_MACHINEARCH_ARM32_PAGETABLEREADER
        ///     DEBUG_COMPONENTSVC_MACHINEARCH_ARM32_ARCHINFO
        /// </summary>
        public static readonly Guid DEBUG_COMPONENTAGGREGATE_MACHINEARCH_ARM32 = new Guid("1C48E7A8-CD38-477E-8661-5718A315810D");

        /// <summary>
        /// A base layer which understands the semantics of a 32-bit kernel full dump on top of a file service.
        /// </summary>
        public static readonly Guid DEBUG_COMPONENTAGGREGATE_BASE_KERNELFULLDUMP32 = new Guid("88D793FA-5DF5-43CC-A837-53C2144BF071");

        /// <summary>
        /// A base layer which understands the semantics of a 64-bit kernel full dump on top of a file service.
        /// </summary>
        public static readonly Guid DEBUG_COMPONENTAGGREGATE_BASE_KERNELFULLDUMP64 = new Guid("E804FF5D-DC9A-45FF-845F-DEF1C40F788A");

        /// <summary>
        /// A layer which understands the semantics of the Windows kernel and provides requisite services on top of it.
        /// </summary>
        public static readonly Guid DEBUG_COMPONENTAGGREGATE_OS_KERNEL_WINDOWS = new Guid("30444EE1-97F6-4698-BFF3-6707BEFC0849");

        /// <summary>
        /// A layer which understands how to find a recognized OS kernel from a set of base machine services. Components Aggregated
        /// Services Provided:
        /// </summary>
        public static readonly Guid DEBUG_COMPONENTAGGREGATE_OS_KERNEL_LOCATOR = new Guid("049643ED-1E60-476F-A927-DCF4EC210575");

        #endregion
        #region Architecture (Individual) Components

        /// <summary>
        /// A component which provides an address translation service (virtual to physical) via direct reading of AMD64 page tables<para/>
        /// Services Provided: DEBUG_SERVICE_VIRTUAL_TO_PHYSICAL_TRANSLATION<para/>
        /// Services Depended On: (Required) DEBUG_SERVICE_PHYSICAL_MEMORY (Required) DEBUG_SERVICE_ARCHINFO (Optional) DEBUG_SERVICE_PAGEFILE_READER
        /// </summary>
        public static readonly Guid DEBUG_COMPONENTSVC_MACHINEARCH_AMD64_PAGETABLEREADER = new Guid("3EA63BF1-E7CD-4BC2-B25E-D16EC4BDDA4B");

        /// <summary>
        /// A component which provides architecture information services for AMD64<para/>
        /// Services Provided: DEBUG_SERVICE_ARCHINFO<para/>
        /// Services Depended On: None
        /// </summary>
        public static readonly Guid DEBUG_COMPONENTSVC_MACHINEARCH_AMD64_ARCHINFO = new Guid("9C37ED47-AF09-4977-9440-56F341419B03");

        /// <summary>
        /// A component which provides an address translation service (virtual to physical) via direct reading of X86 page tables<para/>
        /// Services Provided: DEBUG_SERVICE_VIRTUAL_TO_PHYSICAL_TRANSLATION<para/>
        /// Services Depended On: (Required) DEBUG_SERVICE_PHYSICAL_MEMORY (Required) DEBUG_SERVICE_ARCHINFO (Optional) DEBUG_SERVICE_PAGEFILE_READER
        /// </summary>
        public static readonly Guid DEBUG_COMPONENTSVC_MACHINEARCH_X86_PAGETABLEREADER = new Guid("1F5CF754-B0BA-4341-8D85-0F1F66284CF5");

        /// <summary>
        /// A component which provides architecture information services for X86<para/>
        /// Services Provided: DEBUG_SERVICE_ARCHINFO<para/>
        /// Services Depended On: None
        /// </summary>
        public static readonly Guid DEBUG_COMPONENTSVC_MACHINEARCH_X86_ARCHINFO = new Guid("FD409ED7-B3AA-4A3C-B400-BA1D4947FB47");

        /// <summary>
        /// A component which provides an address translation service (virtual to physical) via direct reading of ARM64 page tables<para/>
        /// Services Provided: DEBUG_SERVICE_VIRTUAL_TO_PHYSICAL_TRANSLATION<para/>
        /// Services Depended On: (Required) DEBUG_SERVICE_PHYSICAL_MEMORY (Required) DEBUG_SERVICE_ARCHINFO (Optional) DEBUG_SERVICE_PAGEFILE_READER
        /// </summary>
        public static readonly Guid DEBUG_COMPONENTSVC_MACHINEARCH_ARM64_PAGETABLEREADER = new Guid("1F347758-D804-4628-98F5-17B533542BBF");

        /// <summary>
        /// A component which provides architecture information services for ARM64<para/>
        /// Services Provided: DEBUG_SERVICE_ARCHINFO<para/>
        /// Services Depended On: None
        /// </summary>
        public static readonly Guid DEBUG_COMPONENTSVC_MACHINEARCH_ARM64_ARCHINFO = new Guid("F492EC3E-38F3-4875-B366-5E1424F7AD52");

        /// <summary>
        /// A component which provides an address translation service (virtual to physical) via direct reading of ARM32 page tables<para/>
        /// Services Provided: DEBUG_SERVICE_VIRTUAL_TO_PHYSICAL_TRANSLATION<para/>
        /// Services Depended On: (Required) DEBUG_SERVICE_PHYSICAL_MEMORY (Required) DEBUG_SERVICE_ARCHINFO (Optional) DEBUG_SERVICE_PAGEFILE_READER
        /// </summary>
        public static readonly Guid DEBUG_COMPONENTSVC_MACHINEARCH_ARM32_PAGETABLEREADER = new Guid("1742F2C1-2EEC-469B-9D70-ECAB6462AE16");

        /// <summary>
        /// A component which provides architecture information services for ARM32<para/>
        /// Services Provided: DEBUG_SERVICE_ARCHINFO<para/>
        /// Services Depended On: None
        /// </summary>
        public static readonly Guid DEBUG_COMPONENTSVC_MACHINEARCH_ARM32_ARCHINFO = new Guid("49F1D274-750E-4B63-B722-A86E54F27D86");

        #endregion
        #region Individual Service Components

        //These are individual services typically found aggregated in a larger component that provide individual pieces
        // of functionality in the target composition stack.

        /// <summary>
        /// A component which provides a file debug source service on top of a file.<para/>
        /// Initializer Interface: IComponentFileSourceInitializer<para/>
        /// Services Provided: DEBUG_PRIVATE_SERVICE_DEBUGSOURCE (ISvcDebugSourceFile)<para/>
        /// Services Depended On: None
        /// </summary>
        public static readonly Guid DEBUG_COMPONENTSVC_FILESOURCE = new Guid("5CE00BC6-2170-4F0D-B39E-0930C388D8B3");

        /// <summary>
        /// A component which provides a view source debug service to another service manager.<para/>
        /// Initializer Interface: IComponentViewSourceInitializer<para/>
        /// Services Provided: DEBUG_PRIVATE_SERVICE_DEBUGSOURCE (ISvcDebugSourceView)<para/>
        /// Services Depended On: None
        /// </summary>
        public static readonly Guid DEBUG_COMPONENTSVC_VIEWSOURCE = new Guid("CA1FA8A8-53A4-4CCA-B4A8-266815E3E818");

        /// <summary>
        /// A component which stacks on top of a file source (DEBUG_PRIVATE_SERVICE_DEBUGSOURCE / ISvcDebugSourceFile) which does *NOT* support ISvcDebugSourceFileMapping and provides an implementation of "memory mapping" the stream.
        /// This memory mapping is done via a **FULL AND IMMEDIATE** read of the entire stream into memory.<para/>
        /// Initializer Interface: IComponentPseudoStreamMapperInitializer<para/>
        /// Services Provided: DEBUG_PRIVATE_SERVICE_DEBUGSOURCE (ISvcDebugSourceFile)<para/>
        /// Services Depended On: None
        /// </summary>
        public static readonly Guid DEBUG_COMPONENTSVC_PSEUDOSTREAMFULLMAPPER = new Guid("E96275D9-5FA1-4DC9-A292-53E54DCFF28B");

        /// <summary>
        /// A component which stacks on top of a file source (DEBUG_PRIVATE_SERVICE_DEBUGSOURCE / ISvcDebugSourceFile) which does *NOT* support ISvcDebugSourceFileMapping and provides an implementation of "memory mapping" the stream.
        /// This memory mapping is done via a reserved VA space in which faults trigger a demand read of a chunk of the stream. Using this component may lead to asynchronous SEH exceptions flowing out of memory accesses to the mapping if, for any reason,
        /// the calls to read the stream fail.<para/>
        /// Initializer Interface: IComponentPseudoStreamMapperInitializer<para/>
        /// Services Provided: DEBUG_PRIVATE_SERVICE_DEBUGSOURCE (ISvcDebugSourceFile)<para/>
        /// Services Depended On: None
        /// </summary>
        public static readonly Guid DEBUG_COMPONENTSVC_PSEUDOSTREAMDEMANDMAPPER = new Guid("06DE4D77-78E3-4E8B-916B-09A13FA91902");

        /// <summary>
        /// A component which provides a virtual memory service abstracted over a data file<para/>
        /// Services Provided: DEBUG_SERVICE_VIRTUAL_MEMORY
        /// </summary>
        public static readonly Guid DEBUG_COMPONENTSVC_VIRTUALMEMORY_FROM_FILE = new Guid("011810C7-63CE-4934-A5EA-18AF7C872DDA");

        /// <summary>
        /// A component which provides a physical memory service for a kernel 32-bit full dump (on top of a file service)<para/>
        /// Services Provided: DEBUG_SERVICE_PHYSICAL_MEMORY<para/>
        /// Services Depended On: DEBUG_PRIVATE_SERVICE_DEBUGSOURCE (a file based debug source implementing ISvcDebugSourceFile and pointing at a 32-bit full kernel dump file)
        /// </summary>
        public static readonly Guid DEBUG_COMPONENTSVC_KERNELFULLDUMP32_PHYSICALMEMORY = new Guid("6728DFF0-D56D-454E-B9DA-77BA3E9C1E43");

        /// <summary>
        /// A component which provides machine level services (config, machine debug) for a ekrnel 32-bit full dump (on top a file service and virtual memory services.
        ///<para/>
        /// Services Provided: DEBUG_SERVICE_MACHINE<para/>
        /// Services Depended On: DEBUG_PRIVATE_SERVICE_DEBUGSOURCE (a file based debug source implementing ISvcDebugSourceFile and pointing at a 32-bit full kernel dump file)
        /// </summary>
        public static readonly Guid DEBUG_COMPONENTSVC_KERNELFULLDUMP32_MACHINE = new Guid("3011A1DD-932B-4BB9-A6A6-811154A62815");

        /// <summary>
        /// A component which provides a physical memory service for a kernel 64-bit full dump (on top a file service)<para/>
        /// Services Provided: DEBUG_SERVICE_PHYSICAL_MEMORY<para/>
        /// Services Depended On: DEBUG_PRIVATE_SERVICE_DEBUGSOURCE (a file based debug source implementing ISvcDebugSourceFile and pointing at a 64-bit full kernel dump file)
        /// </summary>
        public static readonly Guid DEBUG_COMPONENTSVC_KERNELFULLDUMP64_PHYSICALMEMORY = new Guid("8F57F3EB-1F84-4434-BA8D-77E6EB7A4EF1");

        /// <summary>
        /// A component which provides machine level services (config, machine debug) for a ekrnel 64-bit full dump (on top a file service and virtual memory services.
        ///<para/>
        /// Services Provided: DEBUG_SERVICE_MACHINE<para/>
        /// Services Depended On: DEBUG_PRIVATE_SERVICE_DEBUGSOURCE (a file based debug source implementing ISvcDebugSourceFile and pointing at a 64-bit full kernel dump file)
        /// </summary>
        public static readonly Guid DEBUG_COMPONENTSVC_KERNELFULLDUMP64_MACHINE = new Guid("41056A8F-A108-49D9-977B-A876E2615D64");

        /// <summary>
        /// A component which provides a virtual memory service for a stack that has a page table reader (VtoP) service and an underlying physical memory service.
        /// This component handles virtual memory requests by interpreting the page tables and issuing physical memory requests. Note that if a page table reader is in the service stack, any virtual addresses which are paged out will forward to the page table reader.<para/>
        /// Services Provided: DEBUG_SERVICE_VIRTUAL_MEMORY<para/>
        /// Services Depended On: (Required) DEBUG_SERVICE_PHYSICAL_MEMORY (Required) DEBUG_SERVICE_VIRTUAL_TO_PHYSICAL_TRANSLATION (Optional) DEBUG_SERVICE_PAGEFILE_READER
        /// </summary>
        public static readonly Guid DEBUG_COMPONENTSVC_VIRTUALMEMORY_TO_PHYSICALMEMORY = new Guid("2BB80CD4-BB10-46EA-98E3-33C576D2E205");

        /// <summary>
        /// A "component" which provides an implementation of ISvcStackUnwindContext for a stack unwind. This component is *NOT* a service which can be placed into the service manager;
        /// rather -- it is the context for a stack unwind which can be passed amongst multiple service components.<para/>
        /// Services Provided: **NONE**<para/>
        /// Services Depended On: **NONE**
        /// </summary>
        public static readonly Guid DEBUG_COMPONENTSVC_STACKUNWIND_CONTEXT = new Guid("10C3F8E7-38CF-40E9-B906-D85229E872D1");

        /// <summary>
        /// A component which understands PE images and can parse them.<para/>
        /// Services Provided: DEBUG_SERVICE_IMAGE_PARSE_PROVIDER<para/>
        /// Dependent Services: (soft) DEBUG_SERVICE_VIRTUAL_MEMORY (soft) DEBUG_SERVICE_PROCESS_ENUMERATOR
        /// </summary>
        public static readonly Guid DEBUG_COMPONENTSVC_PEIMAGE_IMAGEPARSEPROVIDER = new Guid("BE0E2781-4FF3-4C5C-B041-8EA029ED65E3");

        /// <summary>
        /// A component which understands how to find the original image on disk for a PE image in the target address space. Such PE will be found either in the client's search path or on the symbol server.
        /// The identity is verified by the image size, timestamp, and checksum in the PE image headers. Note that the pages containing the image headers must be readable via a virtual memory service.<para/>
        /// Services Provided: DEBUG_SERVICE_IMAGE_PROVIDER<para/>
        /// Dependent Services: DEBUG_SERVICE_VIRTUAL_MEMORY
        /// </summary>
        public static readonly Guid DEBUG_COMPONENTSVC_PEIMAGE_IMAGEPROVIDER = new Guid("4ACED62F-CEF1-4F74-A1A1-994D61959A80");

        /// <summary>
        /// A component which understands how to find the indexing keys for PE images. These indexing keys (the time/date stamp and the size of the image) are read from the PE headers in the virtual address space of the target.<para/>
        /// Services Provided: DEBUG_SERVICE_MODULE_INDEX_PROVIDER<para/>
        /// Dependent Services: DEBUG_SERVICE_VIRTUAL_MEMORY DEBUG_SERVICE_PROCESS_ENUMERATOR
        /// </summary>
        public static readonly Guid DEBUG_COMPONENTSVC_PEIMAGE_MODULEINDEXPROVIDER = new Guid("A32E9F81-74B4-4CEC-9843-62ADE5889B01");

        /// <summary>
        /// A component which stacks atop another virtual memory service and overlays pages of image files (executables, DLLs, ELF shared objects, etc...) from disk images into the virtual address space.
        /// If pages are not available in the underlying virtual memory service (e.g.: the core file, dump file, etc...) and the original image can be located by an image provider service, the disk image will be used to provide those pages.
        /// If the full requirements of this service are not met, it will operate as a pass through to the underlying virtual memory service. In order for this service to provide image pages, there must be - An image provider which can locate
        /// images from a search path or service (e.g.: symbol server) - An image parse provider which understands how to parse the image format and can translate between the on-disk file view and the in-memory loader view of the image format.<para/>
        /// Initializer Interface: IComponentImageBackedVirtualMemoryInitializer<para/>
        /// Services Provided: DEBUG_SERVICE_VIRTUAL_MEMORY<para/>
        /// Dependent Services: (soft) DEBUG_SERVICE_IMAGE_PROVIDER (soft) DEBUG_SERVICE_MODULE_ENUMERATOR (soft) DEBUG_SERVICE_IMAGE_PARSE_PROVIDER
        /// </summary>
        public static readonly Guid DEBUG_COMPONENTSVC_IMAGEBACKED_VIRTUALMEMORY = new Guid("1E3DB962-FF60-4B28-99FC-0F9D121F1A21");

        /// <summary>
        /// A default implementation of a stack provider which utilizes an underlying stack unwinder service to provider higher level abstract frames. This implementation will, by default, return one physical frame per frame returned from the unwinder.
        /// It can optionally also place inline stack frames above each physical frame for each inline method. Note that such requires access to the symbol provider and symbols which provide inlining information as a symbol set. Note that PDBs are presently not
        /// accessible via a symbol set.<para/>
        /// Initializer Interface<para/> IComponentStackUnwinderStackProviderInitializer<para/>
        /// Services Provided: DEBUG_SERVICE_STACK_PROVIDER<para/>
        /// Dependent Services: (hard) DEBUG_SERVICE_STACK_UNWINDER (hard) DEBUG_SERVICE_ARCHINFO (soft) DEBUG_SERVICE_MODULE_ENUMERATOR (soft) DEBUG_SERVICE_SYMBOL_PROVIDER
        /// </summary>
        public static readonly Guid DEBUG_COMPONENTSVC_STACKUNWINDER_STACKPROVIDER = new Guid("29B6F990-DFD4-4D75-A20C-5E85B630939B");

        /// <summary>
        /// A component which provides an image provider that is simply a redirect to the file source. Such component can be used if the target is simply an open image.<para/>
        /// Services Provided: DEBUG_SERVICE_IMAGE_PROVIDER
        /// </summary>
        public static readonly Guid DEBUG_COMPONENTSVC_IMAGEPROVIDER_FROM_FILE = new Guid("016315AA-3972-421F-8AFD-DB3DC0E4DD72");

        #endregion
        #region Aggregating Components

        /// <summary>
        /// A component which aggregates multiple other module enumerator services to make a single module enumerator service. This component is registered as the standard aggregator for DEBUG_SERVICE_MODULE_ENUMERATOR.<para/>
        /// Services Provided: DEBUG_SERVICE_MODULE_ENUMERATOR Services Dependended On None (depends on what is aggregated)
        /// </summary>
        public static readonly Guid DEBUG_COMPONENTSVC_AGGREGATING_MODULE_ENUMERATOR = new Guid("CB00740B-CD89-40BD-A860-D648C24205F2");

        /// <summary>
        /// A component which aggregates multiple other module index provider services to make a single module index provider service. This component is registered as the standard aggregator for DEBUG_SERVICE_MODULE_INDEX_PROVIDER.<para/>
        /// Services Provided: DEBUG_SERVICE_MODULE_INDEX_PROVIDER Services Dependended On None (depends on what is aggregated)
        /// </summary>
        public static readonly Guid DEBUG_COMPONENTSVC_AGGREGATING_MODULE_INDEX_PROVIDER = new Guid("37ADF532-778E-49D7-85DF-507A60E5A469");

        /// <summary>
        /// A component which aggregates multiple stack unwinders to comprise a single stack unwind capability. The unwinders which are placed in the aggregate must be placed in **PRIORITY** order.
        /// The first unwinder in the container is considered primary. Each unwinder in the container has an opportunity to ask for a transition away from another unwinder on a frame-by-frame basis by implementing the ISvcStackFrameUnwinderTransition interface.
        /// This component is registered as the standard aggregator for DEBUG_SERVICE_STACK_UNWINDER.<para/>
        /// Services Provided: DEBUG_SERVICE_STACK_UNWINDER<para/>
        /// Services Depended On: None (depends on what is aggregated)
        /// </summary>
        public static readonly Guid DEBUG_COMPONENTSVC_AGGREGATING_STACK_UNWINDER = new Guid("1B391664-8128-42B4-A26A-0265B7CC177F");

        /// <summary>
        /// A component which aggregates multiple symbol providers to comprise a single symbol provider capability. Each symbol provider in the aggregate will be asked in turn to provide symbols for a given component until one succeeds.
        /// This component is registered as the standard aggregator for DEBUG_SERVICE_SYMBOL_PROVIDER.<para/>
        /// Services Provided: DEBUG_SERVICE_SYMBOL_PROVIDER<para/>
        /// Services Depended On: None (depends on what is aggregated)
        /// </summary>
        public static readonly Guid DEBUG_COMPONENTSVC_AGGREGATING_SYMBOL_PROVIDER = new Guid("380A71A1-669F-4612-B80F-677865DBE3AF");

        /// <summary>
        /// A component which aggregates multiple image parse providers to comprise a single image parse provider capability. Each image parse provider in the aggregate will be asked in turn to parse an image until it succeeds.
        /// This component is registered as the standard aggregator for DEBUG_SERVICE_IMAGE_PARSE_PROVIDER.<para/>
        /// Services Provided: DEBUG_SERVICE_IMAGE_PARSE_PROVIDER<para/>
        /// Services Depended On: None (depends on what is aggregated)
        /// </summary>
        public static readonly Guid DEBUG_COMPONENTSVC_AGGREGATING_IMAGE_PARSE_PROVIDER = new Guid("577ABB35-723C-4515-B59A-24CDED6468A7");

        /// <summary>
        /// A component which aggregates multiple image providers to comprise a single image provider capability. Each image provider in the aggregate will be asked in turn to provide an image for a given module until one succeeds.
        /// This component is registered as the standard aggregator for DEBUG_SERVICE_IMAGE_PROVIDER.<para/>
        /// Services Provided: DEBUG_SERVICE_IMAGE_PROVIDER<para/>
        /// Services Depended On: None (depends on what is aggregated)
        /// </summary>
        public static readonly Guid DEBUG_COMPONENTSVC_AGGREGATING_IMAGE_PROVIDER = new Guid("B945EEF5-85D7-4D51-AD75-8CD33EF04678");

        /// <summary>
        /// A component which aggregates multiple name demanglers to comprise a single name demangler. Each name demangler in the aggregate will be asked in turn to attempt to demangle a given mangled name until one succeeds.
        /// This component is registered as the standard aggregator for DEBUG_SERVICE_NAME_DEMANGLER.<para/>
        /// Services Provided: DEBUG_SERVICE_NAME_DEMANGLER<para/>
        /// Services Depended On: None (depends on what is aggregated)
        /// </summary>
        public static readonly Guid DEBUG_COMPONENTSVC_AGGREGATING_NAME_DEMANGLER = new Guid("762317E6-8DD3-4112-9FF6-0971A5BFD227");

        #endregion
        #region Forwarder Components

        /// <summary>
        /// A component which forwards a physical memory request from one service manager to another. This allows for the creation of a 'view' of another target.<para/>
        /// Services Provided: DEBUG_SERVICE_PHYSICAL_MEMORY<para/>
        /// Services Depended On: DEBUG_PRIVATE_SERVICE_DEBUGSOURCE (a view debug source implementing ISvcDebugSourceView)
        /// </summary>
        public static readonly Guid DEBUG_COMPONENTSVC_FORWARD_PHYSICALMEMORY = new Guid("0A9E8183-AF09-4F1C-A42D-D8DBA02AB27D");

        #endregion
        #region Stack Components

        /// <summary>
        /// Defines a higher level mechanism for getting at an abstract stack and its frames. The default stack provider is a thin shim over a physical stack unwinder. Other stack providers can present "logical call stacks" which have no relationship to a
        /// set of physical frames in memory unwound by traditional means.<para/>
        /// Provides <see cref="ISvcStackProvider"/>
        /// </summary>
        public static readonly Guid DEBUG_SERVICE_STACK_PROVIDER = new Guid("62D97173-A8DD-44F7-8487-AC9EE6262EF4");

        /// <summary>
        /// Defines the standard mecahnism for unwinding stack frames.
        /// </summary>
        public static readonly Guid DEBUG_SERVICE_STACK_UNWINDER = new Guid("B84A9083-8F92-4783-B6E1-187B53FFDABA");

        #endregion
        #region Core "Public" Services

        /// <summary>
        /// Defines the standard mechanism for getting an abstraction over architecture specific details of a debug target (e.g.: hardware page sizes, etc...). This service does not provide any configuration details (e.g.: number of CPUs) or hardware
        /// debug capabilities. Every composition stack MUST have this service.<para/>
        /// Provides <see cref="ISvcMachineArchitecture"/>
        /// </summary>
        public static readonly Guid DEBUG_SERVICE_ARCHINFO = new Guid("1AAAE599-C167-42B5-B46F-D8B614DA622A");

        /// <summary>
        /// Defines access to the disassembler. This service must provide ISvcBasicDisassembly and may provide other stacked disassembly interfaces to indicate progressively more capability.<para/>
        /// Provides <see cref="ISvcBasicDisassembly"/>
        /// </summary>
        public static readonly Guid DEBUG_SERVICE_DISASSEMBLER = new Guid("03EBFBBC-8C0E-423B-97AF-91EF24045933");

        /// <summary>
        /// Defines the standard mechanism for getting an abstraction over a machine configuration, possible hardware debugging, and the details which govern it.<para/>
        /// Provides <see cref="ISvcMachineConfiguration"/>, <see cref="ISvcMachineConfiguration2"/>, <see cref="ISvcMachineDebug"/>
        /// </summary>
        public static readonly Guid DEBUG_SERVICE_MACHINE = new Guid("8514F5BC-5827-4794-BF0F-619C8FD2E84E");

        /// <summary>
        /// Defines the standard mechanism for accessing the virtual memory associated with a given process / address space. This service is always available on a given debug target. The implementation of this service may defer to a cache, may translate
        /// to physical addresses, or may issue remote read requests. It is entirely up to the service.
        ///
        /// NOTE: If you query for this service, you are always reading memory of a process or address space. This means
        /// that (on Windows), reading a user mode address passing a particular process will always perform that read to the best of the ability of the debugger regardless of
        /// the break state of the CPU. This may involve doing a virtual->physical<para/>
        /// Provides <see cref="ISvcMemoryAccess"/>, <see cref="ISvcMemoryInformation"/>
        /// </summary>
        public static readonly Guid DEBUG_SERVICE_VIRTUAL_MEMORY = new Guid("0E1096D0-9E8D-46FE-94A5-FCD06B38FF21");

        /// <summary>
        /// Defines the standard mechanism for accessing the physical memory associated with a given target. This service is only available on targets which speak in terms of physical memory. A kernel debugger connection, a full kernel dump, and an EXDI
        /// connection are all examples of this.<para/>
        /// Provides <see cref="ISvcMemoryAccess"/>, <see cref="ISvcMemoryInformation"/>
        /// </summary>
        public static readonly Guid DEBUG_SERVICE_PHYSICAL_MEMORY = new Guid("0516BF7F-2644-4EA4-A151-B55AE016B213");

        /// <summary>
        /// Defines the standard mechanism for translating virtual addresses within a particular process or address space to physical addresses (if possible). This service is only available on targets which speak in terms of physical memory and have
        /// services available to interpret the page tables.<para/>
        /// Provides <see cref="ISvcMemoryTranslation"/>
        /// </summary>
        public static readonly Guid DEBUG_SERVICE_VIRTUAL_TO_PHYSICAL_TRANSLATION = new Guid("1B3DC04F-3027-4377-B440-7FA1146BDCFF");

        /// <summary>
        /// Defines the standard mechanism for reading data which has been paged out. The data read may come from an in-memory compressed store or may come from the actual page file (if available to the target). This service is only available on targets
        /// which understand the paging hardware of the target (e.g.: kernel sessions).<para/>
        /// Provides <see cref="ISvcPageFileReader"/>
        /// </summary>
        public static readonly Guid DEBUG_SERVICE_PAGEFILE_READER = new Guid("32C258DC-14EE-487E-9499-96FDDB3D3369");

        /// <summary>
        /// Defines the standard mechanism for enumerating processes which are actively "connected" (e.g.: being debugged). DEBUG_SERVICE_PROCESS_CONNECTOR is the service which represents the ability to connect to or start processes (as might be represented
        /// by a dbgsrv or gdbserver --multi instance)<para/>
        /// Provides <see cref="ISvcProcessEnumerator"/>
        /// </summary>
        public static readonly Guid DEBUG_SERVICE_PROCESS_ENUMERATOR = new Guid("A3371693-C1EB-4ACD-A459-891AD2354F7E");

        /// <summary>
        /// Defines the standard mechanism for finding processes which are potential debug targets. If a container has a process connector, it is assumed to be a "process server" with the capability of creating new processes, attaching to existing ones, and
        /// debugging multiple processes simultaneously.<para/>
        /// Provides <see cref="ISvcProcessConnector"/>
        /// </summary>
        public static readonly Guid DEBUG_SERVICE_PROCESS_CONNECTOR = new Guid("9922FEF0-69EA-4AB0-8331-92361374CCCE");

        /// <summary>
        /// Defines the standard mechanism for enumerating threads.<para/>
        /// Provides <see cref="ISvcThreadEnumerator"/>
        /// </summary>
        public static readonly Guid DEBUG_SERVICE_THREAD_ENUMERATOR = new Guid("BFC2F315-AB73-4876-BCED-1D6CD5D3A8C3");

        /// <summary>
        /// Defines the standard mechanism for enumerating modules.<para/>
        /// Provides <see cref="ISvcModuleEnumerator"/>
        /// </summary>
        public static readonly Guid DEBUG_SERVICE_MODULE_ENUMERATOR = new Guid("DA9DCFAE-3CB4-48A8-A5EA-6B63ABCB5CE7");

        /// <summary>
        /// Defines the standard mechanism for providing an index key for a given module.<para/>
        /// Provides <see cref="ISvcModuleIndexProvider"/>
        /// </summary>
        public static readonly Guid DEBUG_SERVICE_MODULE_INDEX_PROVIDER = new Guid("3BB7A2F9-EC02-458F-AB46-1B0C66FCDDB8");

        /// <summary>
        /// Defines the standard mechanism for providing access to thread-local storage.<para/>
        /// Provides <see cref="ISvcThreadLocalStorageProvider"/>
        /// </summary>
        public static readonly Guid DEBUG_SERVICE_THREAD_LOCAL_STORAGE_PROVIDER = new Guid("4EFB2597-D280-4DDA-820B-14A07ED2D2D2");

        /// <summary>
        /// Defines the standard mechanism for communicating with kernel infrastructure that is specific to the operating system of the machine.<para/>
        /// Provides <see cref="ISvcOSKernelInfrastructure"/>, <see cref="ISvcOSKernelTypes"/>
        /// </summary>
        public static readonly Guid DEBUG_SERVICE_OS_KERNELINFRASTRUCTURE = new Guid("BCBAC4B1-ED84-4326-B062-21FB57556F4F");

        /// <summary>
        /// Defines the standard mechanism for locating the kernel.<para/>
        /// Provides <see cref="ISvcOSKernelLocator"/>
        /// </summary>
        public static readonly Guid DEBUG_SERVICE_OS_KERNELLOCATOR = new Guid("037AC304-09CF-472A-B2FD-C0E69C881B75");

        /// <summary>
        /// Defines the standard mechanism for locating symbols for the given composition stack.<para/>
        /// Provides <see cref="ISvcSymbolProvider"/>
        /// </summary>
        public static readonly Guid DEBUG_SERVICE_SYMBOL_PROVIDER = new Guid("088C65CF-5950-4C41-9F2E-82FF1F93EFB3");

        /// <summary>
        /// Defines the standard mechanism for locating image files from information read from a target.<para/>
        /// Provides <see cref="ISvcImageProvider"/>
        /// </summary>
        public static readonly Guid DEBUG_SERVICE_IMAGE_PROVIDER = new Guid("F656EC69-9E28-41BA-BC6A-CAF8A5CEC8ED");

        /// <summary>
        /// Defines the standard mechanism for parsing various formats of image files in a target.<para/>
        /// Provides <see cref="ISvcImageParseProvider"/>
        /// </summary>
        public static readonly Guid DEBUG_SERVICE_IMAGE_PARSE_PROVIDER = new Guid("7B88E717-F162-4CFE-B643-54C1122D0670");

        /// <summary>
        /// Defines the standard mechanism for trying to demangle mangled symbolic names (e.g.: C++ mangled names).<para/>
        /// Provides <see cref="ISvcNameDemangler"/>
        /// </summary>
        public static readonly Guid DEBUG_SERVICE_NAME_DEMANGLER = new Guid("C1E4D3BF-9F45-4F0C-B08D-1B993C438629");

        /// <summary>
        /// Defines the standard mechanism for fetching context from execution units (software threads or physical cores) where that context might need to be translated. Such translation may occur due to the debugger providing a view on the actual target
        /// (e.g.: emulator versus emulate, WoW versus native, enclave versus host) The ::GetContext method on a given execution unit will *ALWAYS* return the *ACTUAL* context of the thread/core. It is expected that a client will fetch context through
        /// this service. If not present in the service container, the underlying native context can be fetched directly from an execution unit.<para/>
        /// Provides <see cref="ISvcContextTranslation"/>
        /// </summary>
        public static readonly Guid DEBUG_SERVICE_EXECUTION_CONTEXT_TRANSLATION = new Guid("AE987DC0-7D24-4C33-A5A6-312D96192C8E");

        /// <summary>
        /// Defines a mechanism for fetching information about active exception like events (e.g.: exceptions, Linux signals, etc...) A post-mortem target can indicate information about the reason for the snapshot (dump, etc...) via this mechanism.<para/>
        /// Provides <see cref="ISvcActiveExceptions"/>
        /// </summary>
        public static readonly Guid DEBUG_SERVICE_ACTIVE_EXCEPTIONS = new Guid("39B29A74-4608-4A1D-8102-D68F7391E8B5");

        /// <summary>
        /// Defines a standard service for formatting exceptional events (e.g.: Win32 exceptions, Linux signals, etc...) from a target.<para/>
        /// Provides <see cref="ISvcExceptionFormatter"/>
        /// </summary>
        public static readonly Guid DEBUG_SERVICE_EXCEPTION_FORMATTER = new Guid("46BD1681-384A-4FAA-B588-E5244E8BA65E");

        /// <summary>
        /// Defines a standardized way to get information about the underlying OS platform that a given target is/was executing upon. This service is *OPTIONAL* and is not required in any target.<para/>
        /// Provides <see cref="ISvcOSPlatformInformation"/>, <see cref="ISvcOSPlatformInformation2"/>
        /// </summary>
        public static readonly Guid DEBUG_SERVICE_OS_INFORMATION = new Guid("43AFEC1D-7529-40E0-8BF3-F27469F40FEF");

        /// <summary>
        /// Defines the standardized way of controlling motion of a live target. A service container which contains DEBUG_SERVICE_STEP_CONTROLLER is considered to be a "live target" This service is *OPTIONAL*. It is only required for targets which wish
        /// to present other than a static view.<para/>
        /// Provides <see cref="ISvcStepController"/>
        /// </summary>
        public static readonly Guid DEBUG_SERVICE_STEP_CONTROLLER = new Guid("D9FB31D3-5A02-49B5-8201-9F4365B70B2D");

        /// <summary>
        /// Defines the standardized way of controlling breakpoints within a live target. This service is *OPTIONAL*. It *SHOULD* be present for targets which wish to present other than a static view; however, some targets may only provide run/stop/step
        /// and may not support breakpoints at all.<para/>
        /// Provides <see cref="ISvcBreakpointController"/>
        /// </summary>
        public static readonly Guid DEBUG_SERVICE_BREAKPOINT_CONTROLLER = new Guid("BDD79E78-891B-4857-A511-3D67C3B274B0");

        #endregion
        #region Operating System Specific Services

        /// <summary>
        /// Defines a set of services specific to the kernel of Windows.
        /// </summary>
        public static readonly Guid DEBUG_SERVICE_WINDOWS_KERNELINFRASTRUCTURE = new Guid("355ED9B0-8AF4-4B91-8AD0-C71AF8ADF5EC");

        /// <summary>
        /// Defines a means of translating from one exception record to another (e.g.: native to WoW, emulator to emulate, etc...)<para/>
        /// Provides <see cref="ISvcWindowsExceptionTranslation"/>
        /// </summary>
        public static readonly Guid DEBUG_SERVICE_WINDOWS_EXECUTION_EXCEPTION_TRANSLATION = new Guid("EB09BB33-9834-408A-B026-9B51EB901D1A");

        #endregion
        #region Core "Private" Services

        /// <summary>
        /// Defines a means by which other components in the service stack can send diagnostic warning or error messages.
        /// </summary>
        public static readonly Guid DEBUG_PRIVATE_SERVICE_DIAGNOSTIC_SINK = new Guid("455C5AF5-B697-48DB-86FF-15E51920A136");

        /// <summary>
        /// Defines the mechanism for communication with the underlying "target" or "debug source". This may be an abstraction over a file, set of files, or set of streams (for a dump). It may be an abstraction over a kernel transport connection.
        /// It may be an abstraction for a connection to a process server. A few of the core services which sit low in the target composition stack (e.g.: reading and writing memory, getting thread context) are tightly bound to a particular debug source
        /// but present an abstract service. The debug source service is the very bottom of the target composition stack and provides a concrete interface. No components outside the stack should EVER access the debug source service. It should only be accessed
        /// by components within the service stack.
        /// </summary>
        public static readonly Guid DEBUG_PRIVATE_SERVICE_DEBUGSOURCE = new Guid("4268D211-058A-4AFC-B5CD-68F1E210D03D");

        /// <summary>
        /// Defines the standard mechanism for providing an CLR DAC and SOS for a given (CLR) module.<para/>
        /// Provides <see cref="IClrDacAndSosProvider"/>
        /// </summary>
        public static readonly Guid DEBUG_SERVICE_CLR_DAC_AND_SOS_PROVIDER = new Guid("8BBE9989-E330-4BDB-A774-35AD3547D583");

        /// <summary>
        /// Defines the standard mechanism for providing download URL (or a list of URLs) for a source code file.<para/>
        /// Provides <see cref="ISourceCodeDownloadUrlLinkProvider"/>
        /// </summary>
        public static readonly Guid DEBUG_SERVICE_SOURCE_CODE_FILE_DOWNLOAD_URL_LINK_PROVIDER = new Guid("89C3AA95-385D-4C1C-95BB-EF294E5BFD76");

        #endregion
        #region Secondary Services

        /// <summary>
        /// Defines a mechanism for accessing the virtual memory associated with a given process or address space with a guarantee that the reads and writes are not serviced via a cache. This service is always available on a given debug target.<para/>
        /// Provides <see cref="ISvcMemoryAccess"/>, <see cref="ISvcMemoryInformation"/>
        /// </summary>
        public static readonly Guid DEBUG_SERVICE_VIRTUAL_MEMORY_UNCACHED = new Guid("C8ADD00A-A5C0-4CA2-8BD2-3D502443926C");

        /// <summary>
        /// Defines a mechanism for accessing the physical memory associated with a given target with a guarantee that the reads and writes are not serviced via a cache. This service is available on any target which supports DEBUG_SERVICE_PHYSICAL_MEMORY.<para/>
        /// Provides <see cref="ISvcMemoryAccess"/>, <see cref="ISvcMemoryInformation"/>
        /// </summary>
        public static readonly Guid DEBUG_SERVICE_PHYSICAL_MEMORY_UNCACHED = new Guid("F98B6C17-09F1-45EC-B5A0-3B94682EBD8D");

        /// <summary>
        /// Denotes a service stack which accesses virtual memory via direct translation to physical memory addresses and physical reads. This service is only available on some debug targets. In particular, kernel targets which have access to the underlying
        /// physical memory of the machine support this<para/>
        /// Provides <see cref="ISvcMemoryAccess"/>, <see cref="ISvcMemoryInformation"/>
        /// </summary>
        public static readonly Guid DEBUG_SERVICE_VIRTUAL_MEMORY_TRANSLATED = new Guid("C8ADD00A-A5C0-4CA2-8BD2-3D502443926C");

        #endregion
        #region Utility Services

        /// <summary>
        /// A standard telemetry service to send diagnostic information.<para/>
        /// Provides <see cref="ISvcTelemetry"/>
        /// </summary>
        public static readonly Guid DEBUG_SERVICE_TELEMETRY = new Guid("91D9084F-A8AC-4D4F-88E1-5E65E8A64C60");

        /// <summary>
        /// A standard logging service to send diagnostic information. The diagnostic logging service has special semantics placed upon it. Any implementation of the diagnostic logging service must be prepared to receive *Log* calls on
        /// ISvcDiagnosticLogging **BEFORE** the service container is started and services are fully initialized. The service manager itself will begin to write diagnostics to this service immediately after it is placed in the service container.<para/>
        /// Provides <see cref="ISvcDiagnosticLoggableControl"/>
        /// </summary>
        public static readonly Guid DEBUG_SERVICE_DIAGNOSTIC_LOGGING = new Guid("507C628C-DDC3-4829-91AF-01E1BF541B7B");

        #endregion
        #region Conditional Services

        /// <summary>
        /// A service which is able to translate between canonical register IDs and a domain specific register numbering. This service is *NEVER* canonical. It is always conditional on two conditions Primary  : The DEBUG_ARCHDEF_* GUID for the architecture
        /// of the context Secondary: The GUID which defines the domain specific context<para/>
        /// Provides <see cref="ISvcRegisterTranslation"/>, <see cref="ISvcDwarfRegisterTranslation"/>
        /// </summary>
        public static readonly Guid DEBUG_SERVICE_REGISTERTRANSLATION = new Guid("95C5E296-C8CA-4BA2-A52A-FEF3C913AF8C");

        /// <summary>
        /// A service which is able to translate between the canonical context (ISvcRegisterContext) and a domain specific context (e.g.: the context record stored after a PRSTATUS record in a Linux ELF core dump) This service is *NEVER* canonical.
        /// It is always conditional on two conditions
        ///
        /// Primary  : The DEBUG_ARCHDEF_* GUID for the architecture of the context
        /// Secondary: The GUID which defines the domain specific context<para/>
        /// 
        /// Provides <see cref="ISvcRegisterContextTranslation"/>
        /// </summary>
        public static readonly Guid DEBUG_SERVICE_REGISTERCONTEXTTRANSLATION = new Guid("7319EEDD-828F-4995-8994-ED694805E84C");

        /// <summary>
        /// A service which is able to restore pre-trap state from the point of a trap handler (e.g.: a signal frame) This service is *NEVER* Canonical. It is always conditional on two conditions Primary  : The DEBUG_ARCHDEF_* GUID for the architecture
        /// of the context Secondary: The DEBUG_PLATFDEF_* GUID for the platform of the context<para/>
        /// Provides <see cref="ISvcTrapContextRestoration"/>
        /// </summary>
        public static readonly Guid DEBUG_SERVICE_TRAPCONTEXTRESTORATION = new Guid("1AE71270-299C-417F-9608-E15912C229FB");

        #endregion
        #region Debug Source APIs

        /// <summary>
        /// Describes the register numbering domain for CodeView identifiers.
        /// </summary>
        public static readonly Guid DEBUG_REGISTERDOMAIN_CODEVIEW = new Guid("5C9CE1FF-CAE7-459C-A0F8-00A34B146133");

        /// <summary>
        /// Describes the register numbering domain for DWARF identifiers.
        /// </summary>
        public static readonly Guid DEBUG_REGISTERDOMAIN_DWARF = new Guid("530B23F0-0E37-458F-A4C7-93B0254A9F8E");

        /// <summary>
        /// Describes the register context domain for the Windows platform. In specific, this refers to the use of architecture specific CONTEXT structures to store a register context.
        /// </summary>
        public static readonly Guid DEBUG_REGISTERCONTEXTDOMAIN_WINDOWSPLATFORM = new Guid("A50BD040-289D-492A-9C9A-FB14B3A32325");

        /// <summary>
        /// Describes the register context domain for the Linux platform. In specific, this refers to the use of architecture specific PRSTATUS structures to store a register context in places such as core dumps and KDUMPs.
        /// </summary>
        public static readonly Guid DEBUG_REGISTERCONTEXTDOMAIN_LINUXPRSTATUS = new Guid("C8BAF6C4-B964-45DD-9D81-45FD50DB9279");

        /// <summary>
        /// Describes the register context domain for signal records on the Linux platform. In specific, this refers to the use of architecture specific ucontext structures that store a register context on the stack when a signal handler is invoked.
        /// </summary>
        public static readonly Guid DEBUG_REGISTERCONTEXTDOMAIN_LINUXSIGNALCONTEXT = new Guid("3F330F59-3A39-46EE-9D06-67FA5FA84065");

        /// <summary>
        /// Describes the register context domain for the *thread_state*_t commands stored in LC_THREAD load commands within Mac OS core dumps.
        /// </summary>
        public static readonly Guid DEBUG_REGISTERCONTEXTDOMAIN_MACTHREADSTATE = new Guid("9B602ACF-4AA6-4FB7-B0F2-2DE8DEACD650");

        #endregion
        #region Symbol Services

        /// <summary>
        /// A set of capabilities that defines the general capabilities of a symbol set. The identifiers within this set are given by the SvcSymbolSetGeneralCaps enumeration.
        /// </summary>
        public static readonly Guid DEBUG_SYMBOLSETCAPS_GENERAL = new Guid("591037BC-1C2C-4A0E-87EA-59F53581E787");

        #endregion
        #region Image Services

        /// <summary>
        /// Identifies the package name associated with the image.
        /// </summary>
        public static readonly Guid DEBUG_VERSIONIDENTIFIER_PACKAGENAME = new Guid("F779EDF9-2F05-4E9D-A3DE-479BD2FCA1AC");

        /// <summary>
        /// Identifies the copyright information associated with the image.
        /// </summary>
        public static readonly Guid DEBUG_VERSIONIDENTIFIER_COPYRIGHT = new Guid("00C9CB55-2134-455C-BD7A-A106A9F71884");

        /// <summary>
        /// Identifies the distribution/product associated with the image.
        /// </summary>
        public static readonly Guid DEBUG_VERSIONIDENTIFIER_DISTRIBUTION = new Guid("3A51BE14-3AD5-481F-871D-6F37CFFEEBA3");

        /// <summary>
        /// Identifies the repository associated with the image.
        /// </summary>
        public static readonly Guid DEBUG_VERSIONIDENTIFIER_REPOSITORY = new Guid("2B32B734-ABC0-413F-973A-C2F114C8B40B");

        /// <summary>
        /// Identifies the branch associated with the image.
        /// </summary>
        public static readonly Guid DEBUG_VERSIONIDENTIFIER_BRANCH = new Guid("A1C282C0-54D8-4AA7-BB18-3B83744DA9F7");

        /// <summary>
        /// Identifies description information associated with the image.
        /// </summary>
        public static readonly Guid DEBUG_VERSIONIDENTIFIER_DESCRIPTION = new Guid("218F0E9D-8B59-436A-AEEB-DF31B1A1A924");

        /// <summary>
        /// Identifies a commit hash associated with the image.
        /// </summary>
        public static readonly Guid DEBUG_VERSIONIDENTIFIER_COMMIT_HASH = new Guid("365C64DE-26C5-469D-8698-0E41A7492AEB");

        /// <summary>
        /// A GUID which can be passed to ISvcImageDataLocationParser::LocateDataBlob in order to find the address of the runtime linker debugger rendezvous (r_debug) structure POINTER within an ELF executable on Linux (this is the effective address
        /// of the r_debug pointer within the DT_DEBUG dynamic entry)
        /// </summary>
        public static readonly Guid DEBUG_SVCDATABLOB_RUNTIME_LINKER_DEBUGGER_RENDEZVOUS = new Guid("9A42D659-3D92-4A5A-A166-A06DB9F02E6F");

        /// <summary>
        /// A GUID which can be passed to ISvcImageDataLocationParser::LocateDataBlob in order to find the address of the entry point within an executable.
        /// </summary>
        public static readonly Guid DEBUG_SVCDATABLOB_ENTRY_ADDRESS = new Guid("16E51259-6DBB-4C47-8D28-8AA7BB5F93D2");

        #endregion
        #region Events

        /// <summary>
        /// An event which is fired when the service manager container is initialized.<para/>
        /// Event Argument: [Reserved] Currently, always nullptr
        /// </summary>
        public static readonly Guid DEBUG_SVCEVENT_SERVICEMANAGERINITIALIZED = new Guid("966E5F1F-C1DD-45B0-8C39-112EFF58D996");

        /// <summary>
        /// An event which is fired when the service manager container is uninitialized (immediately before any uninitialization actions)<para/>
        /// Event Argument: [Reserved] Currently, always nullptr
        /// </summary>
        public static readonly Guid DEBUG_SVCEVENT_SERVICEMANAGERUNINITIALIZING = new Guid("189FFEA7-FE84-4E66-A41F-2F31839D7C4B");

        /// <summary>
        /// An event which is fired when, for any reason, context information (e.g.: registers, etc...) needs to be invalidated. Any service which caches context information must flush its cache upon receipt of this event.<para/>
        /// Event Argument: [Reserved] Currently, always nullptr
        /// </summary>
        public static readonly Guid DEBUG_SVCEVENT_CONTEXTINVALIDATE = new Guid("F89FEFFD-EF5D-4F04-AB62-943E0402B2EC");

        /// <summary>
        /// An event which is fired when the search paths for images or symbols is changed.<para/>
        /// Event Argument: [Reserved] Currently, always nullptr
        /// </summary>
        public static readonly Guid DEBUG_SVCEVENT_SEARCHPATHSCHANGED = new Guid("53E3027B-535E-4E21-972E-F76FE605A1B0");

        /// <summary>
        /// Symbols have been successfully loaded for a given module.<para/>
        /// Event Argument: ISvcEventArgumentsSymbolLoad
        /// </summary>
        public static readonly Guid DEBUG_SVCEVENT_SYMBOLLOAD = new Guid("6A8ABDFC-9607-4AB7-B3D2-75AFFA1A2B02");

        /// <summary>
        /// Fired immediately before symbols are unloaded for a given module. This allows any components which are caching information outside the context of a symbol set to flush caches as appropriate. Such event may be fired immediately before loading
        /// symbols again in the context of a reload of symbols (e.g.: after changing symbol search paths, etc...)<para/>
        /// Event Argument: ISvcEventArgumentsSymbolUnload
        /// </summary>
        public static readonly Guid DEBUG_SVCEVENT_SYMBOLUNLOAD = new Guid("507FD081-9C6A-45E0-9762-51D0F62914F3");

        /// <summary>
        /// A new module has arrived or been detected. This may indicate that a module was "loaded", that a JIT module was allocated, or that some other mechanism detected a previously unknown module. This event may *ONLY* be fired by the module enumeration
        /// service which is responsible for the initial presentation of the module. At the time the event is fired (as seen by any listener), the module enumeration service must already present the given module.<para/>
        /// Event Argument: ISvcEventArgumentsModuleDiscovery
        /// </summary>
        public static readonly Guid DEBUG_SVCEVENT_MODULEARRIVAL = new Guid("08DA6258-3D12-45C7-BCF9-BC88E6E5049A");

        /// <summary>
        /// A module which was previously discovered is no longer present. This may indicate that a module was "unloaded", that a JIT module was deallocated, or that some other mechanism decided that the module is no longer relevant to the target system.
        /// This event may *ONLY* be fired by the module enumeration service which was responsible for the initial presentation of the module. At the time the event is fired (as seen by any listener), the module enumeration service must already have removed the given module.<para/>
        /// Event Argument: ISvcEventArgumentsModuleDiscovery
        /// </summary>
        public static readonly Guid DEBUG_SVCEVENT_MODULEDISAPPEARANCE = new Guid("A849133A-56E6-4878-9A0F-71152554EA02");

        /// <summary>
        /// If there is a provider which demand provides source mappings akin to a symbol server, it should fire this event if the source mappings for a particular module change in order that any listener can update necessary caches.<para/>
        /// Event Argument: ISvcEventArgumentsSourceMappingsChanged
        /// </summary>
        public static readonly Guid DEBUG_SVCEVENT_SOURCEMAPPINGS_CHANGED = new Guid("B476344D-7EB1-4EB7-AD4C-AA19A83059C1");

        /// <summary>
        /// An event which is fired when the execution state of the debugger changes (the target breaks in, the target resumes, etc...<para/>
        /// Event Argument: ISvcEventArgumentExecutionStateChange
        /// </summary>
        public static readonly Guid DEBUG_SVCEVENT_EXECUTIONSTATECHANGE = new Guid("466C9324-F601-4CAC-9EAA-8A1E89A0C21E");

        /// <summary>
        /// An event which is fired when something changes that makes any cached symbols from a given symbol set no longer valid. Any caller which caches individual symbols from a symbol set should listen to this change and flush their caches upon receipt.<para/>
        /// Event Argument: ISvcEventArgumentsSymbolCacheInvalidate
        /// </summary>
        public static readonly Guid DEBUG_SVCEVENT_SYMBOLCACHEINVALIDATE = new Guid("3B740272-22A7-40D4-A1E6-12E1BCFD232C");

        /// <summary>
        /// An event which is fired when a new process is targeted by a target. This may be the result of attaching or creating a process *OR* it may be the result of a child process being created while the parent is selected to debug all children.<para/>
        /// Event Argument: ISvcEventArgumentsProcessDiscovery
        /// </summary>
        public static readonly Guid DEBUG_SVCEVENT_PROCESSARRIVAL = new Guid("C1AAFD0B-044B-4E2A-A4B0-4B2BF900EDFA");

        /// <summary>
        /// An event which is fired when a process which is targeted exits.<para/>
        /// Event Argument: ISvcEventArgumentsProcessDiscovery
        /// </summary>
        public static readonly Guid DEBUG_SVCEVENT_PROCESSEXIT = new Guid("FC9AA8EF-BA7A-4823-9D2F-9F5B3DE9693C");

        /// <summary>
        /// An event which is fired when a process does a Unix style exec (effectively replacing the process with a new one).<para/>
        /// Event Argument: ISvcEventArgumentsProcessDiscovery
        /// </summary>
        public static readonly Guid DEBUG_SVCEVENT_PROCESSEXEC = new Guid("BBD69DE9-331D-48BC-8C2A-D8A8C3CD2E87");

        /// <summary>
        /// An event which is fired when a new thread is created by a target.<para/>
        /// Event Argument: ISvcEventArgumentsThreadDiscovery
        /// </summary>
        public static readonly Guid DEBUG_SVCEVENT_THREADARRIVAL = new Guid("4DC31DD9-43A0-4C12-ADAF-E5DDB68E00C7");

        /// <summary>
        /// An event which is fired when an existing thread exits.<para/>
        /// Event Argument: ISvcEventArgumentsThreadDiscovery
        /// </summary>
        public static readonly Guid DEBUG_SVCEVENT_THREADEXIT = new Guid("89DD0121-CCEF-4D60-9E2F-53CC8D638608");

        #endregion
        #region Private Services

        /// <summary>
        /// An internal only component which bridges between legacy portions of the debugger and target composition
        /// portions of the debugger. This should only be necessary until more components can be refactored.<para/>
        /// Provides <see cref="ISvcLegacyClrDiscovery"/>, <see cref="ISvcLegacyClrInformation"/>
        /// </summary>
        public static readonly Guid DEBUG_PRIVATE_SERVICE_LEGACYBRIDGE = new Guid("FFFEAF0D-DA4A-485e-8C64-27C99659B628");

        #endregion
        #region Private Events

        /// <summary>
        /// An event which is fired when the legacy CLR discovery service determines that something about its ability to find the CLR has changed.
        /// </summary>
        public static readonly Guid DEBUG_PRIVATE_SVCEVENT_CLRINFORMATIONCHANGED = new Guid("2C51799C-F1E9-4d49-A883-6BB768FA41B3");

        #endregion
    }
}
