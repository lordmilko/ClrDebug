using ClrDebug.DIA;

namespace ClrDebug.PDB
{
    //Name is from clrmd (which strips _t on all its names), so is assumed to be correct.
    //dumpsym7.cpp declates an anonymous struct "filedata" whose members have slightly different names
    public struct CV_FileCheckSum_t
    {
        public int name; // Index of name in name table.
        public byte len; // Hash length
        public byte type; //CV_SourceChksum_t
    }
}
