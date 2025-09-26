namespace ClrDebug.PDB
{
    public unsafe struct InlineeSourceLineEx
    {
        /// <summary>
        /// function id
        /// </summary>
        public CV_ItemId inlinee;

        /// <summary>
        /// offset into file table DEBUG_S_FILECHKSMS
        /// </summary>
        public CV_off32_t fileId;

        /// <summary>
        /// definition start line number
        /// </summary>
        public CV_off32_t sourceLineNum;

        public int countOfExtraFiles;
        public fixed int extraFileId[1]; //CV_off32_t
    }
}
