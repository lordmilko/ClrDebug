using System.Diagnostics;
using System.Runtime.InteropServices;

namespace ClrDebug.PDB
{
    /// <summary>
    /// Symbol for describing indirect calls when they are using
    /// a function pointer cast on some other type or temporary.<para/>
    /// Typical content will be an LF_POINTER to an LF_PROCEDURE
    /// type record that should mimic an actual variable with the
    /// function pointer type in question.<para/>
    ///
    /// Since the compiler can sometimes tail-merge a function call
    /// through a function pointer, there may be more than one
    /// S_CALLSITEINFO record at an address.  This is similar to what
    /// you could do in your own code by:
    ///
    /// <c>
    ///  if (expr)
    ///      pfn = &amp;function1;
    ///  else
    ///      pfn = &amp;function2;
    ///
    ///  (*pfn)(arg list);
    /// </c>
    /// </summary>
    [DebuggerDisplay("reclen = {reclen}, rectyp = {rectyp.ToString(),nq}, off = {off.ToString(),nq}, sect = {sect}, __reserved_0 = {__reserved_0}, typind = {typind.ToString(),nq}")]
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct CALLSITEINFO
    {
        /// <summary>
        /// Record length
        /// </summary>
        public ushort reclen;

        /// <summary>
        /// S_CALLSITEINFO
        /// </summary>
        public SYM_ENUM_e rectyp;

        /// <summary>
        /// offset of call site
        /// </summary>
        public CV_off32_t off;

        /// <summary>
        /// section index of call site
        /// </summary>
        public short sect;

        /// <summary>
        /// alignment padding field, must be zero
        /// </summary>
        public short __reserved_0;

        /// <summary>
        /// type index describing function signature
        /// </summary>
        public CV_typ_t typind;
    }
}
