namespace ClrDebug.DbgEng
{
    public enum SSRVACTION
    {
        /// <summary>
        /// Provide debug trace information. The data parameter is a text string.
        /// </summary>
        SSRVACTION_TRACE = 1,

        /// <summary>
        /// Cancel the file copy. The data parameter is a ULONG64 value. If this value is zero, continue the operation. Otherwise, cancel the operation.
        /// </summary>
        SSRVACTION_QUERYCANCEL = 2,

        /// <summary>
        /// Provide debug trace information. The data parameter is a pointer to an IMAGEHLP_CBA_EVENT structure.
        /// </summary>
        SSRVACTION_EVENT = 3,

        /// <summary>
        /// Provide debug trace information. The data parameter is a pointer to an IMAGEHLP_CBA_EVENTW structure.
        /// </summary>
        SSRVACTION_EVENTW = 4,

        /// <summary>
        /// The data parameter is the size of the file to be provided by the system.
        /// </summary>
        SSRVACTION_SIZE = 5,

        SSRVACTION_HTTPSTATUS = 6,
        SSRVACTION_XMLOUTPUT = 7,
        SSRVACTION_CHECKSUMSTATUS = 8
    }
}
