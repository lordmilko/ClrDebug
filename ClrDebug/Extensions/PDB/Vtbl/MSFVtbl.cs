using System;

namespace ClrDebug.PDB
{
#pragma warning disable CS0649
    internal struct MSFVtbl
    {
        //There's some new methods on here in the vtbl that aren't in microsoft-pdb, so I'm not too sure
        //how much to trust the current layout. My guess is that the vtbl of MSF is ignored and this is the vtbl of MSF_HB
        //which includes extra overloads of various members (microsoft-pdb has two ReadStream overloads on MSF_HB for example)

        public IntPtr QueryInterfaceVersion;
        public IntPtr QueryImplementationVersion;
        public IntPtr GetCbPage;
        public IntPtr GetCbStream;
        public IntPtr GetFreeSn;
        public IntPtr ReadStream1;
        public IntPtr ReadStream2;
        public IntPtr ReadStream3;
        public IntPtr ReadStream4;
        public IntPtr WriteStream;
        public IntPtr ReplaceStream;
        public IntPtr AppendStream1;
        public IntPtr AppendStream2;
        public IntPtr TruncateStream;
        public IntPtr DeleteStream;
        public IntPtr Commit;
        public IntPtr Close;
        //public IntPtr GetRawBytes;
        //public IntPtr SnMax;
        //public IntPtr FRelease1;
        //public IntPtr FRelease2;
        //public IntPtr FIsBigMsf;
        //public IntPtr FSetCompression;
        //public IntPtr FGetCompression;
        //public IntPtr NonTransactionalEraseStream;
        //public IntPtr MapStreamToMemory;
        //public IntPtr ReadDataFromMappedFile;
        //public IntPtr SupportsMemoryMapping;
        //public IntPtr DisableMemoryMapping;
        //public IntPtr GetVersionDescription;
        //public IntPtr SnMaxUsed;
    }
#pragma warning restore CS0649
}
