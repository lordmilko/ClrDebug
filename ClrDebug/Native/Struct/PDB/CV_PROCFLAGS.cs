using System.Diagnostics;
using System.Runtime.InteropServices;
using static ClrDebug.Extensions;

namespace ClrDebug.PDB
{
    /// <summary>
    /// enum describing function return method
    /// </summary>
    [DebuggerDisplay("CV_PFLAG_NOFPO = {CV_PFLAG_NOFPO}, CV_PFLAG_INT = {CV_PFLAG_INT}, CV_PFLAG_FAR = {CV_PFLAG_FAR}, CV_PFLAG_NEVER = {CV_PFLAG_NEVER}, CV_PFLAG_NOTREACHED = {CV_PFLAG_NOTREACHED}, CV_PFLAG_CUST_CALL = {CV_PFLAG_CUST_CALL}, CV_PFLAG_NOINLINE = {CV_PFLAG_NOINLINE}, CV_PFLAG_OPTDBGINFO = {CV_PFLAG_OPTDBGINFO}, bAll = {bAll}")]
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct CV_PROCFLAGS
    {
        /// <summary>
        /// frame pointer present
        /// </summary>
        public bool CV_PFLAG_NOFPO
        {
            get => GetBitFlag(bAll, 0);
            set => SetBitFlag(ref bAll, 0, value);
        }

        /// <summary>
        /// interrupt return
        /// </summary>
        public bool CV_PFLAG_INT
        {
            get => GetBitFlag(bAll, 1);
            set => SetBitFlag(ref bAll, 1, value);
        }

        /// <summary>
        /// far return
        /// </summary>
        public bool CV_PFLAG_FAR
        {
            get => GetBitFlag(bAll, 2);
            set => SetBitFlag(ref bAll, 2, value);
        }

        /// <summary>
        /// function does not return
        /// </summary>
        public bool CV_PFLAG_NEVER
        {
            get => GetBitFlag(bAll, 3);
            set => SetBitFlag(ref bAll, 3, value);
        }

        /// <summary>
        /// label isn't fallen into
        /// </summary>
        public bool CV_PFLAG_NOTREACHED
        {
            get => GetBitFlag(bAll, 4);
            set => SetBitFlag(ref bAll, 4, value);
        }

        /// <summary>
        /// custom calling convention
        /// </summary>
        public bool CV_PFLAG_CUST_CALL
        {
            get => GetBitFlag(bAll, 5);
            set => SetBitFlag(ref bAll, 5, value);
        }

        /// <summary>
        /// function marked as noinline
        /// </summary>
        public bool CV_PFLAG_NOINLINE
        {
            get => GetBitFlag(bAll, 6);
            set => SetBitFlag(ref bAll, 6, value);
        }

        /// <summary>
        /// function has debug information for optimized code
        /// </summary>
        public bool CV_PFLAG_OPTDBGINFO
        {
            get => GetBitFlag(bAll, 7);
            set => SetBitFlag(ref bAll, 7, value);
        }

        private byte bAll;

        public static implicit operator CV_PROCFLAGS(byte value) => new CV_PROCFLAGS { bAll = value };
        public static implicit operator byte(CV_PROCFLAGS value) => value.bAll;
    }
}
