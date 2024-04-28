using System;

namespace ClrDebug.PDB
{
#pragma warning disable CS0649
    internal struct DBI1Vtbl
    {
        public IntPtr QueryImplementationVersion;
        public IntPtr QueryInterfaceVersion;
        public IntPtr OpenMod;
        public IntPtr DeleteMod;
        public IntPtr QueryNextMod;
        public IntPtr OpenGlobals;
        public IntPtr OpenPublics;
        public IntPtr AddSec;
        public IntPtr QueryModFromAddr;
        public IntPtr QuerySecMap;
        public IntPtr QueryFileInfo;
        public IntPtr DumpMods;
        public IntPtr DumpSecContribs;
        public IntPtr DumpSecMap;
        public IntPtr Close;
        public IntPtr AddThunkMap;
        public IntPtr AddPublic;
        public IntPtr getEnumContrib;
        public IntPtr QueryTypeServer;
        public IntPtr QueryItsmForTi;
        public IntPtr QueryNextItsm;
        public IntPtr QueryLazyTypes;
        public IntPtr SetLazyTypes;
        public IntPtr FindTypeServers;
        public IntPtr DumpTypeServers;
        public IntPtr OpenDbg;
        public IntPtr QueryDbgTypes;
        public IntPtr QueryAddrForSec;
        public IntPtr QueryAddrForSecEx;
        public IntPtr QuerySupportsEC;
        public IntPtr QueryPdb;
        public IntPtr AddLinkInfo;
        public IntPtr QueryLinkInfo;
        public IntPtr QueryAge;
        public IntPtr QueryHeader;
        public IntPtr FlushTypeServers;
        public IntPtr QueryTypeServerByPdb;
        public IntPtr OpenModW;
        public IntPtr DeleteModW;
        public IntPtr AddPublicW;
        public IntPtr QueryTypeServerByPdbW;
        public IntPtr AddLinkInfoW;
        public IntPtr AddPublic2;
        public IntPtr QueryMachineType;
        public IntPtr SetMachineType;
        public IntPtr RemoveDataForRva;
        public IntPtr FStripped;
        public IntPtr QueryModFromAddr2;
        public IntPtr QueryNoOfMods;
        public IntPtr QueryMods;
        public IntPtr QueryImodFromAddr;
        public IntPtr OpenModFromImod;
        public IntPtr QueryHeader2;
        public IntPtr FAddSourceMappingItem;
        public IntPtr FSetPfnNotePdbUsed;
        public IntPtr FCTypes;
        public IntPtr QueryFileInfo2;
        public IntPtr FSetPfnQueryCallback;
        public IntPtr FSetPfnNoteTypeMismatch;
        public IntPtr FSetPfnTmdTypeFilter;
        public IntPtr FSetPfnDumpTMCache;
        public IntPtr RemovePublic;
        public IntPtr getEnumContrib2;
        public IntPtr QueryModFromAddrEx;
        public IntPtr QueryImodFromAddrEx;
        public IntPtr UpdateGlobalDataAddr;
        public IntPtr _Missing;
        public IntPtr ClearSegmentMap;
        public IntPtr DumpTMCache;
        public IntPtr QueryDbgHeader;
    }
#pragma warning restore CS0649
}
