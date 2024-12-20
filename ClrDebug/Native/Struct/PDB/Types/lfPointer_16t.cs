using System.Runtime.InteropServices;
using static ClrDebug.Extensions;

namespace ClrDebug.PDB
{
    /// <summary>
    /// type record for LF_POINTER_16t
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct lfPointer_16t //10 bytes
    {
        public lfPointerBody_16t u;
        public BaseInfo pbase;

        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct lfPointerBody_16t
        {
            /// <summary>
            /// LF_POINTER_16t
            /// </summary>
            public LEAF_ENUM_e leaf;

            public lfPointerAttr_16t attr;

            /// <summary>
            /// type index of the underlying type
            /// </summary>
            public CV_typ16_t utype;
        }

        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct lfPointerAttr_16t
        {
            /// <summary>
            /// ordinal specifying pointer type (CV_ptrtype_e)
            /// </summary>
            public CV_ptrtype_e ptrtype
            {
                get => (CV_ptrtype_e) GetBits(data, 0, 5); //0-4
                set => SetBits(ref data, 0, 5, (short) value);
            }

            /// <summary>
            /// ordinal specifying pointer mode (CV_ptrmode_e)
            /// </summary>
            public CV_ptrmode_e ptrmode
            {
                get => (CV_ptrmode_e) GetBits(data, 5, 3); //5-7
                set => SetBits(ref data, 5, 3, (short) value);
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

            public short unused
            {
                get => GetBits(data, 12, 4); //12-15
                set => SetBits(ref data, 12, 4, value);
            }

            public short data;
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

        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct PointerMemberInfo
        {
            /// <summary>
            /// index of containing class for pointer to member
            /// </summary>
            public CV_typ16_t pmclass;

            /// <summary>
            /// enumeration specifying pm format (CV_pmtype_e)
            /// </summary>
            public CV_pmtype_e pmenum;
        }

        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public unsafe struct BaseTypeInfo
        {
            /// <summary>
            /// type index if CV_PTR_BASE_TYPE
            /// </summary>
            public CV_typ16_t index;

            /// <summary>
            /// name of base type
            /// </summary>
            public fixed byte name[1];
        }
    }
}
