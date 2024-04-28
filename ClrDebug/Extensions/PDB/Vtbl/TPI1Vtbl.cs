using System;

namespace ClrDebug.PDB
{
#pragma warning disable CS0649
    internal struct TPI1Vtbl
    {
        public IntPtr QueryInterfaceVersion;
        public IntPtr QueryImplementationVersion;
        public IntPtr QueryTi16ForCVRecord;
        public IntPtr QueryCVRecordForTi16;
        public IntPtr QueryPbCVRecordForTi16;
        public IntPtr QueryTi16Min;
        public IntPtr QueryTi16Mac;
        public IntPtr QueryCb;
        public IntPtr Close;
        public IntPtr Commit;
        public IntPtr QueryTi16ForUDT;
        public IntPtr SupportQueryTiForUDT;
        public IntPtr fIs16bitTypePool;
        public IntPtr QueryTiForUDT;
        public IntPtr QueryTiForCVRecord;
        public IntPtr QueryCVRecordForTi;
        public IntPtr QueryPbCVRecordForTi;
        public IntPtr QueryTiMin;
        public IntPtr QueryTiMac;
        public IntPtr AreTypesEqual;
        public IntPtr IsTypeServed;
        public IntPtr QueryTiForUDTW;
        public IntPtr QueryModSrcLineForUDTDefn;
        public IntPtr QueryTIsForCVRecords;
    }
#pragma warning restore CS0649
}
