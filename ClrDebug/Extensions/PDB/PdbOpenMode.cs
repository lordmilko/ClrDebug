namespace ClrDebug.PDB
{
    public static class PdbOpenMode
    {
        public const string pdbFSCompress         = "C";
        public const string pdbVC120              = "L";
        public const string pdbTypeAppend         = "a";
        public const string pdbGetRecordsOnly     = "c";
        public const string pdbFullBuild          = "f";
        public const string pdbGetTiOnly          = "i";
        public const string pdbNoTypeMergeLink    = "l";
        public const string pdbTypeMismatchesLink = "m";
        public const string pdbNewNameMap         = "n";
        public const string pdbMinimalLink        = "o";
        public const string pdbRead               = "r";
        public const string pdbWriteShared        = "s";
        public const string pdbCTypes             = "t";
        public const string pdbWrite              = "w";
        public const string pdbExclusive          = "x";
        public const string pdbRepro              = "z";
    }
}
