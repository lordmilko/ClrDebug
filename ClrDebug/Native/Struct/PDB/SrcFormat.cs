using System;

namespace ClrDebug.PDB
{
    /* A PDB source file is either in SrcFormat format, or raw text format. If the count of bytes
     * is less than the size of SrcFormat, it's definitely raw text. Otherwise, you can potentially use heuristics
     * to try and confirm whether the blob you're looking at looks like a SrcFormat record. pdbdump looks for well known
     * algorithm IDs, however this is not a good idea: if a record doesn't have a checksum, the algorithmId will be null.
     * While languageVendor is only ever known to be Microsoft, I recommend looking at the documentType, in case any other vendors
     * ever pop up in the future */
    public struct SrcFormat
    {
        public Guid language;
        public Guid languageVendor;
        public Guid documentType;
        public Guid algorithmId;
        public int checkSumSize;
        public int sourceSize;
        // followed by 'checkSumSize' bytes of checksum
        // followed by 'sourceSize' source bytes
    };
}
