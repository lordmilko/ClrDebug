using System;

namespace ClrDebug.PDB
{
#pragma warning disable CS0649
    internal struct PDB1Vtbl
    {
        public IntPtr QueryInterfaceVersion;
        public IntPtr QueryImplementationVersion;
        public IntPtr QueryLastError;
        public IntPtr QueryPDBName;
        public IntPtr QuerySignature;
        public IntPtr QueryAge;
        public IntPtr CreateDBI;
        public IntPtr OpenDBI;
        public IntPtr OpenTpi;
        public IntPtr OpenIpi;
        public IntPtr Commit;
        public IntPtr Close;
        public IntPtr OpenStream;
        public IntPtr GetEnumStreamNameMap;
        public IntPtr GetRawBytes;
        public IntPtr QueryPdbImplementationVersion;
        public IntPtr OpenDBIEx;
        public IntPtr CopyTo;
        public IntPtr OpenSrc;
        public IntPtr QueryLastErrorExW;
        public IntPtr QueryPDBNameExW;
        public IntPtr QuerySignature2;
        public IntPtr CopyToW;
        public IntPtr fIsSZPDB;
        public IntPtr OpenStreamW;
        public IntPtr CopyToW2;
        public IntPtr OpenStreamEx;
        public IntPtr RegisterPDBMapping;
        public IntPtr EnablePrefetching;
        public IntPtr FLazy;
        public IntPtr FMinimal;
        public IntPtr ResetGUID;
        public IntPtr FReleaseGlobalSymbolBuffer;
        public IntPtr UpdateSignature;
        public IntPtr FRepro;
        public IntPtr FPortablePDB;
    }
#pragma warning restore CS0649
}
