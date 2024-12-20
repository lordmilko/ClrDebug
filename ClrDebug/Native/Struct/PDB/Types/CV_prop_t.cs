using System.Diagnostics;
using System.Runtime.InteropServices;
using static ClrDebug.Extensions;

namespace ClrDebug.PDB
{
    /// <summary>
    /// bit field structure describing class/struct/union/enum properties
    /// </summary>
    [DebuggerDisplay("data = {data}, packed = {packed}, ctor = {ctor}, ovlops = {ovlops}, isnested = {isnested}, cnested = {cnested}, opassign = {opassign}, opcast = {opcast}, fwdref = {fwdref}, scoped = {scoped}, hasuniquename = {hasuniquename}, @sealed = {@sealed}, intrinsic = {intrinsic}")]
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct CV_prop_t
    {
        private short data;

        /// <summary>
        /// true if structure is packed
        /// </summary>
        public bool packed
        {
            get => GetBitFlag(data, 0);
            set => SetBitFlag(ref data, 0, value);
        }

        /// <summary>
        /// true if constructors or destructors present
        /// </summary>
        public bool ctor
        {
            get => GetBitFlag(data, 1);
            set => SetBitFlag(ref data, 1, value);
        }

        /// <summary>
        /// true if overloaded operators present
        /// </summary>
        public bool ovlops
        {
            get => GetBitFlag(data, 2);
            set => SetBitFlag(ref data, 2, value);
        }

        /// <summary>
        /// true if this is a nested class
        /// </summary>
        public bool isnested
        {
            get => GetBitFlag(data, 3);
            set => SetBitFlag(ref data, 3, value);
        }

        /// <summary>
        /// true if this class contains nested types
        /// </summary>
        public bool cnested
        {
            get => GetBitFlag(data, 4);
            set => SetBitFlag(ref data, 4, value);
        }

        /// <summary>
        /// true if overloaded assignment (=)
        /// </summary>
        public bool opassign
        {
            get => GetBitFlag(data, 5);
            set => SetBitFlag(ref data, 5, value);
        }

        /// <summary>
        /// true if casting methods
        /// </summary>
        public bool opcast
        {
            get => GetBitFlag(data, 6);
            set => SetBitFlag(ref data, 6, value);
        }

        /// <summary>
        /// true if forward reference (incomplete defn)
        /// </summary>
        public bool fwdref
        {
            get => GetBitFlag(data, 7);
            set => SetBitFlag(ref data, 7, value);
        }

        /// <summary>
        /// scoped definition
        /// </summary>
        public bool scoped
        {
            get => GetBitFlag(data, 8);
            set => SetBitFlag(ref data, 8, value);
        }

        /// <summary>
        /// true if there is a decorated name following the regular name
        /// </summary>
        public bool hasuniquename
        {
            get => GetBitFlag(data, 9);
            set => SetBitFlag(ref data, 9, value);
        }

        /// <summary>
        /// true if class cannot be used as a base class
        /// </summary>
        public bool @sealed
        {
            get => GetBitFlag(data, 10);
            set => SetBitFlag(ref data, 10, value);
        }

        /// <summary>
        /// CV_HFA_e
        /// </summary>
        public CV_HFA_e hfa
        {
            get => (CV_HFA_e) GetBits(data, 11, 2); //11-12
            set => SetBits(ref data, 11, 2, (short) value);
        }

        /// <summary>
        /// true if class is an intrinsic type (e.g. __m128d)
        /// </summary>
        public bool intrinsic
        {
            get => GetBitFlag(data, 13);
            set => SetBitFlag(ref data, 13, value);
        }

        /// <summary>
        /// CV_MOCOM_UDT_e
        /// </summary>
        public CV_MOCOM_UDT_e mocom
        {
            get => (CV_MOCOM_UDT_e) GetBits(data, 14, 2); //14-15
            set => SetBits(ref data, 14, 2, (short) value);
        }

        public static implicit operator CV_prop_t(short value) => new CV_prop_t { data = value };
        public static implicit operator short(CV_prop_t value) => value.data;
    }
}
