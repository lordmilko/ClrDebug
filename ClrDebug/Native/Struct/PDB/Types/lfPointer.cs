using System.Runtime.InteropServices;
using static ClrDebug.Extensions;

namespace ClrDebug.PDB
{
    /// <summary>
    /// type record for LF_POINTER
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 2)]
    public struct lfPointer //20 bytes when aligned, 16 when unaligned
    {
        public lfPointerBody u;
        public BaseInfo pbase;

        [StructLayout(LayoutKind.Sequential, Pack = 2)]
        public struct lfPointerBody
        {
            /// <summary>
            /// LF_POINTER
            /// </summary>
            public LEAF_ENUM_e leaf;

            /// <summary>
            /// type index of the underlying type
            /// </summary>
            public CV_typ_t utype;

            public lfPointerAttr attr;
        }

        [StructLayout(LayoutKind.Sequential, Pack = 2)]
        public struct lfPointerAttr
        {
            /// <summary>
            /// ordinal specifying pointer type (CV_ptrtype_e)
            /// </summary>
            public CV_ptrtype_e ptrtype
            {
                get => (CV_ptrtype_e) GetBits(data, 0, 5); //0-4
                set => SetBits(ref data, 0, 5, (int) value);
            }

            /// <summary>
            /// ordinal specifying pointer mode (CV_ptrmode_e)
            /// </summary>
            public CV_ptrmode_e ptrmode
            {
                get => (CV_ptrmode_e) GetBits(data, 5, 3); //5-7
                set => SetBits(ref data, 5, 3, (int) value);
            }

            /// <summary>
            /// true if 0:32 pointer
            /// </summary>
            public bool isflat32
            {
                get => GetBitFlag(data, 8);
                set => SetBitFlag(ref data, 8, value);
            }

            /// <summary>
            /// TRUE if volatile pointer
            /// </summary>
            public bool isvolatile
            {
                get => GetBitFlag(data, 9);
                set => SetBitFlag(ref data, 9, value);
            }

            /// <summary>
            /// TRUE if const pointer
            /// </summary>
            public bool isconst
            {
                get => GetBitFlag(data, 10);
                set => SetBitFlag(ref data, 10, value);
            }

            /// <summary>
            /// TRUE if unaligned pointer
            /// </summary>
            public bool isunaligned
            {
                get => GetBitFlag(data, 11);
                set => SetBitFlag(ref data, 11, value);
            }

            /// <summary>
            /// TRUE if restricted pointer (allow agressive opts)
            /// </summary>
            public bool isrestrict
            {
                get => GetBitFlag(data, 12);
                set => SetBitFlag(ref data, 12, value);
            }

            /// <summary>
            /// size of pointer (in bytes)
            /// </summary>
            public int size
            {
                get => GetBits(data, 13, 6); //13-18
                set => SetBits(ref data, 13, 6, value);
            }

            /// <summary>
            /// TRUE if it is a MoCOM pointer (^ or %)
            /// </summary>
            public bool ismocom
            {
                get => GetBitFlag(data, 19);
                set => SetBitFlag(ref data, 19, value);
            }

            /// <summary>
            /// TRUE if it is this pointer of member function with &amp; ref-qualifier
            /// </summary>
            public bool islref
            {
                get => GetBitFlag(data, 20);
                set => SetBitFlag(ref data, 20, value);
            }

            /// <summary>
            /// TRUE if it is this pointer of member function with &amp;&amp; ref-qualifier
            /// </summary>
            public bool isrref
            {
                get => GetBitFlag(data, 21);
                set => SetBitFlag(ref data, 21, value);
            }

            /// <summary>
            /// pad out to 32-bits for following cv_typ_t's
            /// </summary>
            public int unused
            {
                get => GetBits(data, 22, 10); //22-31
                set => SetBits(ref data, 22, 10, value);
            }

            public int data;
        }

        [StructLayout(LayoutKind.Explicit)]
        public unsafe struct BaseInfo
        {
            [FieldOffset(0)]
            public PointerMemberInfo pm;

            /// <summary>
            /// base segment if PTR_BASE_SEG
            /// </summary>
            [FieldOffset(0)]
            public short bseg;

            /// <summary>
            /// copy of base symbol record (including length)
            /// </summary>
            [FieldOffset(0)]
            public fixed byte Sym[1];

            [FieldOffset(0)]
            public BaseTypeInfo btype;
        }

        [StructLayout(LayoutKind.Sequential, Pack = 2)]
        public struct PointerMemberInfo
        {
            /// <summary>
            /// index of containing class for pointer to member
            /// </summary>
            public CV_typ_t pmclass;

            /// <summary>
            /// enumeration specifying pm format (CV_pmtype_e)
            /// </summary>
            public CV_pmtype_e pmenum;
        }

        [StructLayout(LayoutKind.Sequential, Pack = 2)]
        public unsafe struct BaseTypeInfo
        {
            /// <summary>
            /// type index if CV_PTR_BASE_TYPE
            /// </summary>
            public CV_typ_t index;

            /// <summary>
            /// name of base type
            /// </summary>
            public fixed byte name[1];
        }
    }
}
