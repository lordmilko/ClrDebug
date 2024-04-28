namespace ClrDebug.PDB
{
    /// <summary>
    /// Special Types
    /// </summary>
    public enum TYPE_ENUM_e
    {
        /// <summary>
        /// uncharacterized type (no type)
        /// </summary>
        T_NOTYPE        = 0x0000,

        /// <summary>
        /// absolute symbol
        /// </summary>
        T_ABS           = 0x0001,

        /// <summary>
        /// segment type
        /// </summary>
        T_SEGMENT       = 0x0002,

        /// <summary>
        /// void
        /// </summary>
        T_VOID          = 0x0003,

        /// <summary>
        /// OLE/COM HRESULT
        /// </summary>
        T_HRESULT       = 0x0008,

        /// <summary>
        /// OLE/COM HRESULT __ptr32 *
        /// </summary>
        T_32PHRESULT    = 0x0408,

        /// <summary>
        /// OLE/COM HRESULT __ptr64 *
        /// </summary>
        T_64PHRESULT    = 0x0608,

        /// <summary>
        /// near pointer to void
        /// </summary>
        T_PVOID         = 0x0103,

        /// <summary>
        /// far pointer to void
        /// </summary>
        T_PFVOID        = 0x0203,

        /// <summary>
        /// huge pointer to void
        /// </summary>
        T_PHVOID        = 0x0303,

        /// <summary>
        /// 32 bit pointer to void
        /// </summary>
        T_32PVOID       = 0x0403,

        /// <summary>
        /// 16:32 pointer to void
        /// </summary>
        T_32PFVOID      = 0x0503,

        /// <summary>
        /// 64 bit pointer to void
        /// </summary>
        T_64PVOID       = 0x0603,

        /// <summary>
        /// BASIC 8 byte currency value
        /// </summary>
        T_CURRENCY      = 0x0004,

        /// <summary>
        /// Near BASIC string
        /// </summary>
        T_NBASICSTR     = 0x0005,

        /// <summary>
        /// Far BASIC string
        /// </summary>
        T_FBASICSTR     = 0x0006,

        /// <summary>
        /// type not translated by cvpack
        /// </summary>
        T_NOTTRANS      = 0x0007,

        /// <summary>
        /// bit
        /// </summary>
        T_BIT           = 0x0060,

        /// <summary>
        /// Pascal CHAR
        /// </summary>
        T_PASCHAR       = 0x0061,

        /// <summary>
        /// 32-bit BOOL where true is 0xffffffff
        /// </summary>
        T_BOOL32FF      = 0x0062,

//      Character types

        /// <summary>
        /// 8 bit signed
        /// </summary>
        T_CHAR          = 0x0010,

        /// <summary>
        /// 16 bit pointer to 8 bit signed
        /// </summary>
        T_PCHAR         = 0x0110,

        /// <summary>
        /// 16:16 far pointer to 8 bit signed
        /// </summary>
        T_PFCHAR        = 0x0210,

        /// <summary>
        /// 16:16 huge pointer to 8 bit signed
        /// </summary>
        T_PHCHAR        = 0x0310,

        /// <summary>
        /// 32 bit pointer to 8 bit signed
        /// </summary>
        T_32PCHAR       = 0x0410,

        /// <summary>
        /// 16:32 pointer to 8 bit signed
        /// </summary>
        T_32PFCHAR      = 0x0510,

        /// <summary>
        /// 64 bit pointer to 8 bit signed
        /// </summary>
        T_64PCHAR       = 0x0610,

        /// <summary>
        /// 8 bit unsigned
        /// </summary>
        T_UCHAR         = 0x0020,

        /// <summary>
        /// 16 bit pointer to 8 bit unsigned
        /// </summary>
        T_PUCHAR        = 0x0120,

        /// <summary>
        /// 16:16 far pointer to 8 bit unsigned
        /// </summary>
        T_PFUCHAR       = 0x0220,

        /// <summary>
        /// 16:16 huge pointer to 8 bit unsigned
        /// </summary>
        T_PHUCHAR       = 0x0320,

        /// <summary>
        /// 32 bit pointer to 8 bit unsigned
        /// </summary>
        T_32PUCHAR      = 0x0420,

        /// <summary>
        /// 16:32 pointer to 8 bit unsigned
        /// </summary>
        T_32PFUCHAR     = 0x0520,

        /// <summary>
        /// 64 bit pointer to 8 bit unsigned
        /// </summary>
        T_64PUCHAR      = 0x0620,

//      really a character types

        /// <summary>
        /// really a char
        /// </summary>
        T_RCHAR         = 0x0070,

        /// <summary>
        /// 16 bit pointer to a real char
        /// </summary>
        T_PRCHAR        = 0x0170,

        /// <summary>
        /// 16:16 far pointer to a real char
        /// </summary>
        T_PFRCHAR       = 0x0270,

        /// <summary>
        /// 16:16 huge pointer to a real char
        /// </summary>
        T_PHRCHAR       = 0x0370,

        /// <summary>
        /// 32 bit pointer to a real char
        /// </summary>
        T_32PRCHAR      = 0x0470,

        /// <summary>
        /// 16:32 pointer to a real char
        /// </summary>
        T_32PFRCHAR     = 0x0570,

        /// <summary>
        /// 64 bit pointer to a real char
        /// </summary>
        T_64PRCHAR      = 0x0670,

//      really a wide character types

        /// <summary>
        /// wide char
        /// </summary>
        T_WCHAR         = 0x0071,

        /// <summary>
        /// 16 bit pointer to a wide char
        /// </summary>
        T_PWCHAR        = 0x0171,

        /// <summary>
        /// 16:16 far pointer to a wide char
        /// </summary>
        T_PFWCHAR       = 0x0271,

        /// <summary>
        /// 16:16 huge pointer to a wide char
        /// </summary>
        T_PHWCHAR       = 0x0371,

        /// <summary>
        /// 32 bit pointer to a wide char
        /// </summary>
        T_32PWCHAR      = 0x0471,

        /// <summary>
        /// 16:32 pointer to a wide char
        /// </summary>
        T_32PFWCHAR     = 0x0571,

        /// <summary>
        /// 64 bit pointer to a wide char
        /// </summary>
        T_64PWCHAR      = 0x0671,

//      really a 16-bit unicode char

        /// <summary>
        /// 16-bit unicode char
        /// </summary>
        T_CHAR16         = 0x007a,

        /// <summary>
        /// 16 bit pointer to a 16-bit unicode char
        /// </summary>
        T_PCHAR16        = 0x017a,

        /// <summary>
        /// 16:16 far pointer to a 16-bit unicode char
        /// </summary>
        T_PFCHAR16       = 0x027a,

        /// <summary>
        /// 16:16 huge pointer to a 16-bit unicode char
        /// </summary>
        T_PHCHAR16       = 0x037a,

        /// <summary>
        /// 32 bit pointer to a 16-bit unicode char
        /// </summary>
        T_32PCHAR16      = 0x047a,

        /// <summary>
        /// 16:32 pointer to a 16-bit unicode char
        /// </summary>
        T_32PFCHAR16     = 0x057a,

        /// <summary>
        /// 64 bit pointer to a 16-bit unicode char
        /// </summary>
        T_64PCHAR16      = 0x067a,

//      really a 32-bit unicode char

        /// <summary>
        /// 32-bit unicode char
        /// </summary>
        T_CHAR32         = 0x007b,

        /// <summary>
        /// 16 bit pointer to a 32-bit unicode char
        /// </summary>
        T_PCHAR32        = 0x017b,

        /// <summary>
        /// 16:16 far pointer to a 32-bit unicode char
        /// </summary>
        T_PFCHAR32       = 0x027b,

        /// <summary>
        /// 16:16 huge pointer to a 32-bit unicode char
        /// </summary>
        T_PHCHAR32       = 0x037b,

        /// <summary>
        /// 32 bit pointer to a 32-bit unicode char
        /// </summary>
        T_32PCHAR32      = 0x047b,

        /// <summary>
        /// 16:32 pointer to a 32-bit unicode char
        /// </summary>
        T_32PFCHAR32     = 0x057b,

        /// <summary>
        /// 64 bit pointer to a 32-bit unicode char
        /// </summary>
        T_64PCHAR32      = 0x067b,

//      8 bit int types

        /// <summary>
        /// 8 bit signed int
        /// </summary>
        T_INT1          = 0x0068,

        /// <summary>
        /// 16 bit pointer to 8 bit signed int
        /// </summary>
        T_PINT1         = 0x0168,

        /// <summary>
        /// 16:16 far pointer to 8 bit signed int
        /// </summary>
        T_PFINT1        = 0x0268,

        /// <summary>
        /// 16:16 huge pointer to 8 bit signed int
        /// </summary>
        T_PHINT1        = 0x0368,

        /// <summary>
        /// 32 bit pointer to 8 bit signed int
        /// </summary>
        T_32PINT1       = 0x0468,

        /// <summary>
        /// 16:32 pointer to 8 bit signed int
        /// </summary>
        T_32PFINT1      = 0x0568,

        /// <summary>
        /// 64 bit pointer to 8 bit signed int
        /// </summary>
        T_64PINT1       = 0x0668,

        /// <summary>
        /// 8 bit unsigned int
        /// </summary>
        T_UINT1         = 0x0069,

        /// <summary>
        /// 16 bit pointer to 8 bit unsigned int
        /// </summary>
        T_PUINT1        = 0x0169,

        /// <summary>
        /// 16:16 far pointer to 8 bit unsigned int
        /// </summary>
        T_PFUINT1       = 0x0269,

        /// <summary>
        /// 16:16 huge pointer to 8 bit unsigned int
        /// </summary>
        T_PHUINT1       = 0x0369,

        /// <summary>
        /// 32 bit pointer to 8 bit unsigned int
        /// </summary>
        T_32PUINT1      = 0x0469,

        /// <summary>
        /// 16:32 pointer to 8 bit unsigned int
        /// </summary>
        T_32PFUINT1     = 0x0569,

        /// <summary>
        /// 64 bit pointer to 8 bit unsigned int
        /// </summary>
        T_64PUINT1      = 0x0669,

//      16 bit short types

        /// <summary>
        /// 16 bit signed
        /// </summary>
        T_SHORT         = 0x0011,

        /// <summary>
        /// 16 bit pointer to 16 bit signed
        /// </summary>
        T_PSHORT        = 0x0111,

        /// <summary>
        /// 16:16 far pointer to 16 bit signed
        /// </summary>
        T_PFSHORT       = 0x0211,

        /// <summary>
        /// 16:16 huge pointer to 16 bit signed
        /// </summary>
        T_PHSHORT       = 0x0311,

        /// <summary>
        /// 32 bit pointer to 16 bit signed
        /// </summary>
        T_32PSHORT      = 0x0411,

        /// <summary>
        /// 16:32 pointer to 16 bit signed
        /// </summary>
        T_32PFSHORT     = 0x0511,

        /// <summary>
        /// 64 bit pointer to 16 bit signed
        /// </summary>
        T_64PSHORT      = 0x0611,

        /// <summary>
        /// 16 bit unsigned
        /// </summary>
        T_USHORT        = 0x0021,

        /// <summary>
        /// 16 bit pointer to 16 bit unsigned
        /// </summary>
        T_PUSHORT       = 0x0121,

        /// <summary>
        /// 16:16 far pointer to 16 bit unsigned
        /// </summary>
        T_PFUSHORT      = 0x0221,

        /// <summary>
        /// 16:16 huge pointer to 16 bit unsigned
        /// </summary>
        T_PHUSHORT      = 0x0321,

        /// <summary>
        /// 32 bit pointer to 16 bit unsigned
        /// </summary>
        T_32PUSHORT     = 0x0421,

        /// <summary>
        /// 16:32 pointer to 16 bit unsigned
        /// </summary>
        T_32PFUSHORT    = 0x0521,

        /// <summary>
        /// 64 bit pointer to 16 bit unsigned
        /// </summary>
        T_64PUSHORT     = 0x0621,

//      16 bit int types

        /// <summary>
        /// 16 bit signed int
        /// </summary>
        T_INT2          = 0x0072,

        /// <summary>
        /// 16 bit pointer to 16 bit signed int
        /// </summary>
        T_PINT2         = 0x0172,

        /// <summary>
        /// 16:16 far pointer to 16 bit signed int
        /// </summary>
        T_PFINT2        = 0x0272,

        /// <summary>
        /// 16:16 huge pointer to 16 bit signed int
        /// </summary>
        T_PHINT2        = 0x0372,

        /// <summary>
        /// 32 bit pointer to 16 bit signed int
        /// </summary>
        T_32PINT2       = 0x0472,

        /// <summary>
        /// 16:32 pointer to 16 bit signed int
        /// </summary>
        T_32PFINT2      = 0x0572,

        /// <summary>
        /// 64 bit pointer to 16 bit signed int
        /// </summary>
        T_64PINT2       = 0x0672,

        /// <summary>
        /// 16 bit unsigned int
        /// </summary>
        T_UINT2         = 0x0073,

        /// <summary>
        /// 16 bit pointer to 16 bit unsigned int
        /// </summary>
        T_PUINT2        = 0x0173,

        /// <summary>
        /// 16:16 far pointer to 16 bit unsigned int
        /// </summary>
        T_PFUINT2       = 0x0273,

        /// <summary>
        /// 16:16 huge pointer to 16 bit unsigned int
        /// </summary>
        T_PHUINT2       = 0x0373,

        /// <summary>
        /// 32 bit pointer to 16 bit unsigned int
        /// </summary>
        T_32PUINT2      = 0x0473,

        /// <summary>
        /// 16:32 pointer to 16 bit unsigned int
        /// </summary>
        T_32PFUINT2     = 0x0573,

        /// <summary>
        /// 64 bit pointer to 16 bit unsigned int
        /// </summary>
        T_64PUINT2      = 0x0673,

//      32 bit long types

        /// <summary>
        /// 32 bit signed
        /// </summary>
        T_LONG          = 0x0012,

        /// <summary>
        /// 32 bit unsigned
        /// </summary>
        T_ULONG         = 0x0022,

        /// <summary>
        /// 16 bit pointer to 32 bit signed
        /// </summary>
        T_PLONG         = 0x0112,

        /// <summary>
        /// 16 bit pointer to 32 bit unsigned
        /// </summary>
        T_PULONG        = 0x0122,

        /// <summary>
        /// 16:16 far pointer to 32 bit signed
        /// </summary>
        T_PFLONG        = 0x0212,

        /// <summary>
        /// 16:16 far pointer to 32 bit unsigned
        /// </summary>
        T_PFULONG       = 0x0222,

        /// <summary>
        /// 16:16 huge pointer to 32 bit signed
        /// </summary>
        T_PHLONG        = 0x0312,

        /// <summary>
        /// 16:16 huge pointer to 32 bit unsigned
        /// </summary>
        T_PHULONG       = 0x0322,

        /// <summary>
        /// 32 bit pointer to 32 bit signed
        /// </summary>
        T_32PLONG       = 0x0412,

        /// <summary>
        /// 32 bit pointer to 32 bit unsigned
        /// </summary>
        T_32PULONG      = 0x0422,

        /// <summary>
        /// 16:32 pointer to 32 bit signed
        /// </summary>
        T_32PFLONG      = 0x0512,

        /// <summary>
        /// 16:32 pointer to 32 bit unsigned
        /// </summary>
        T_32PFULONG     = 0x0522,

        /// <summary>
        /// 64 bit pointer to 32 bit signed
        /// </summary>
        T_64PLONG       = 0x0612,

        /// <summary>
        /// 64 bit pointer to 32 bit unsigned
        /// </summary>
        T_64PULONG      = 0x0622,

//      32 bit int types

        /// <summary>
        /// 32 bit signed int
        /// </summary>
        T_INT4          = 0x0074,

        /// <summary>
        /// 16 bit pointer to 32 bit signed int
        /// </summary>
        T_PINT4         = 0x0174,

        /// <summary>
        /// 16:16 far pointer to 32 bit signed int
        /// </summary>
        T_PFINT4        = 0x0274,

        /// <summary>
        /// 16:16 huge pointer to 32 bit signed int
        /// </summary>
        T_PHINT4        = 0x0374,

        /// <summary>
        /// 32 bit pointer to 32 bit signed int
        /// </summary>
        T_32PINT4       = 0x0474,

        /// <summary>
        /// 16:32 pointer to 32 bit signed int
        /// </summary>
        T_32PFINT4      = 0x0574,

        /// <summary>
        /// 64 bit pointer to 32 bit signed int
        /// </summary>
        T_64PINT4       = 0x0674,

        /// <summary>
        /// 32 bit unsigned int
        /// </summary>
        T_UINT4         = 0x0075,

        /// <summary>
        /// 16 bit pointer to 32 bit unsigned int
        /// </summary>
        T_PUINT4        = 0x0175,

        /// <summary>
        /// 16:16 far pointer to 32 bit unsigned int
        /// </summary>
        T_PFUINT4       = 0x0275,

        /// <summary>
        /// 16:16 huge pointer to 32 bit unsigned int
        /// </summary>
        T_PHUINT4       = 0x0375,

        /// <summary>
        /// 32 bit pointer to 32 bit unsigned int
        /// </summary>
        T_32PUINT4      = 0x0475,

        /// <summary>
        /// 16:32 pointer to 32 bit unsigned int
        /// </summary>
        T_32PFUINT4     = 0x0575,

        /// <summary>
        /// 64 bit pointer to 32 bit unsigned int
        /// </summary>
        T_64PUINT4      = 0x0675,

//      64 bit quad types

        /// <summary>
        /// 64 bit signed
        /// </summary>
        T_QUAD          = 0x0013,

        /// <summary>
        /// 16 bit pointer to 64 bit signed
        /// </summary>
        T_PQUAD         = 0x0113,

        /// <summary>
        /// 16:16 far pointer to 64 bit signed
        /// </summary>
        T_PFQUAD        = 0x0213,

        /// <summary>
        /// 16:16 huge pointer to 64 bit signed
        /// </summary>
        T_PHQUAD        = 0x0313,

        /// <summary>
        /// 32 bit pointer to 64 bit signed
        /// </summary>
        T_32PQUAD       = 0x0413,

        /// <summary>
        /// 16:32 pointer to 64 bit signed
        /// </summary>
        T_32PFQUAD      = 0x0513,

        /// <summary>
        /// 64 bit pointer to 64 bit signed
        /// </summary>
        T_64PQUAD       = 0x0613,

        /// <summary>
        /// 64 bit unsigned
        /// </summary>
        T_UQUAD         = 0x0023,

        /// <summary>
        /// 16 bit pointer to 64 bit unsigned
        /// </summary>
        T_PUQUAD        = 0x0123,

        /// <summary>
        /// 16:16 far pointer to 64 bit unsigned
        /// </summary>
        T_PFUQUAD       = 0x0223,

        /// <summary>
        /// 16:16 huge pointer to 64 bit unsigned
        /// </summary>
        T_PHUQUAD       = 0x0323,

        /// <summary>
        /// 32 bit pointer to 64 bit unsigned
        /// </summary>
        T_32PUQUAD      = 0x0423,

        /// <summary>
        /// 16:32 pointer to 64 bit unsigned
        /// </summary>
        T_32PFUQUAD     = 0x0523,

        /// <summary>
        /// 64 bit pointer to 64 bit unsigned
        /// </summary>
        T_64PUQUAD      = 0x0623,

//      64 bit int types

        /// <summary>
        /// 64 bit signed int
        /// </summary>
        T_INT8          = 0x0076,

        /// <summary>
        /// 16 bit pointer to 64 bit signed int
        /// </summary>
        T_PINT8         = 0x0176,

        /// <summary>
        /// 16:16 far pointer to 64 bit signed int
        /// </summary>
        T_PFINT8        = 0x0276,

        /// <summary>
        /// 16:16 huge pointer to 64 bit signed int
        /// </summary>
        T_PHINT8        = 0x0376,

        /// <summary>
        /// 32 bit pointer to 64 bit signed int
        /// </summary>
        T_32PINT8       = 0x0476,

        /// <summary>
        /// 16:32 pointer to 64 bit signed int
        /// </summary>
        T_32PFINT8      = 0x0576,

        /// <summary>
        /// 64 bit pointer to 64 bit signed int
        /// </summary>
        T_64PINT8       = 0x0676,

        /// <summary>
        /// 64 bit unsigned int
        /// </summary>
        T_UINT8         = 0x0077,

        /// <summary>
        /// 16 bit pointer to 64 bit unsigned int
        /// </summary>
        T_PUINT8        = 0x0177,

        /// <summary>
        /// 16:16 far pointer to 64 bit unsigned int
        /// </summary>
        T_PFUINT8       = 0x0277,

        /// <summary>
        /// 16:16 huge pointer to 64 bit unsigned int
        /// </summary>
        T_PHUINT8       = 0x0377,

        /// <summary>
        /// 32 bit pointer to 64 bit unsigned int
        /// </summary>
        T_32PUINT8      = 0x0477,

        /// <summary>
        /// 16:32 pointer to 64 bit unsigned int
        /// </summary>
        T_32PFUINT8     = 0x0577,

        /// <summary>
        /// 64 bit pointer to 64 bit unsigned int
        /// </summary>
        T_64PUINT8      = 0x0677,

//      128 bit octet types

        /// <summary>
        /// 128 bit signed
        /// </summary>
        T_OCT           = 0x0014,

        /// <summary>
        /// 16 bit pointer to 128 bit signed
        /// </summary>
        T_POCT          = 0x0114,

        /// <summary>
        /// 16:16 far pointer to 128 bit signed
        /// </summary>
        T_PFOCT         = 0x0214,

        /// <summary>
        /// 16:16 huge pointer to 128 bit signed
        /// </summary>
        T_PHOCT         = 0x0314,

        /// <summary>
        /// 32 bit pointer to 128 bit signed
        /// </summary>
        T_32POCT        = 0x0414,

        /// <summary>
        /// 16:32 pointer to 128 bit signed
        /// </summary>
        T_32PFOCT       = 0x0514,

        /// <summary>
        /// 64 bit pointer to 128 bit signed
        /// </summary>
        T_64POCT        = 0x0614,

        /// <summary>
        /// 128 bit unsigned
        /// </summary>
        T_UOCT          = 0x0024,

        /// <summary>
        /// 16 bit pointer to 128 bit unsigned
        /// </summary>
        T_PUOCT         = 0x0124,

        /// <summary>
        /// 16:16 far pointer to 128 bit unsigned
        /// </summary>
        T_PFUOCT        = 0x0224,

        /// <summary>
        /// 16:16 huge pointer to 128 bit unsigned
        /// </summary>
        T_PHUOCT        = 0x0324,

        /// <summary>
        /// 32 bit pointer to 128 bit unsigned
        /// </summary>
        T_32PUOCT       = 0x0424,

        /// <summary>
        /// 16:32 pointer to 128 bit unsigned
        /// </summary>
        T_32PFUOCT      = 0x0524,

        /// <summary>
        /// 64 bit pointer to 128 bit unsigned
        /// </summary>
        T_64PUOCT       = 0x0624,

//      128 bit int types

        /// <summary>
        /// 128 bit signed int
        /// </summary>
        T_INT16         = 0x0078,

        /// <summary>
        /// 16 bit pointer to 128 bit signed int
        /// </summary>
        T_PINT16        = 0x0178,

        /// <summary>
        /// 16:16 far pointer to 128 bit signed int
        /// </summary>
        T_PFINT16       = 0x0278,

        /// <summary>
        /// 16:16 huge pointer to 128 bit signed int
        /// </summary>
        T_PHINT16       = 0x0378,

        /// <summary>
        /// 32 bit pointer to 128 bit signed int
        /// </summary>
        T_32PINT16      = 0x0478,

        /// <summary>
        /// 16:32 pointer to 128 bit signed int
        /// </summary>
        T_32PFINT16     = 0x0578,

        /// <summary>
        /// 64 bit pointer to 128 bit signed int
        /// </summary>
        T_64PINT16      = 0x0678,

        /// <summary>
        /// 128 bit unsigned int
        /// </summary>
        T_UINT16        = 0x0079,

        /// <summary>
        /// 16 bit pointer to 128 bit unsigned int
        /// </summary>
        T_PUINT16       = 0x0179,

        /// <summary>
        /// 16:16 far pointer to 128 bit unsigned int
        /// </summary>
        T_PFUINT16      = 0x0279,

        /// <summary>
        /// 16:16 huge pointer to 128 bit unsigned int
        /// </summary>
        T_PHUINT16      = 0x0379,

        /// <summary>
        /// 32 bit pointer to 128 bit unsigned int
        /// </summary>
        T_32PUINT16     = 0x0479,

        /// <summary>
        /// 16:32 pointer to 128 bit unsigned int
        /// </summary>
        T_32PFUINT16    = 0x0579,

        /// <summary>
        /// 64 bit pointer to 128 bit unsigned int
        /// </summary>
        T_64PUINT16     = 0x0679,

//      16 bit real types

        /// <summary>
        /// 16 bit real
        /// </summary>
        T_REAL16        = 0x0046,

        /// <summary>
        /// 16 bit pointer to 16 bit real
        /// </summary>
        T_PREAL16       = 0x0146,

        /// <summary>
        /// 16:16 far pointer to 16 bit real
        /// </summary>
        T_PFREAL16      = 0x0246,

        /// <summary>
        /// 16:16 huge pointer to 16 bit real
        /// </summary>
        T_PHREAL16      = 0x0346,

        /// <summary>
        /// 32 bit pointer to 16 bit real
        /// </summary>
        T_32PREAL16     = 0x0446,

        /// <summary>
        /// 16:32 pointer to 16 bit real
        /// </summary>
        T_32PFREAL16    = 0x0546,

        /// <summary>
        /// 64 bit pointer to 16 bit real
        /// </summary>
        T_64PREAL16     = 0x0646,

//      32 bit real types

        /// <summary>
        /// 32 bit real
        /// </summary>
        T_REAL32        = 0x0040,

        /// <summary>
        /// 16 bit pointer to 32 bit real
        /// </summary>
        T_PREAL32       = 0x0140,

        /// <summary>
        /// 16:16 far pointer to 32 bit real
        /// </summary>
        T_PFREAL32      = 0x0240,

        /// <summary>
        /// 16:16 huge pointer to 32 bit real
        /// </summary>
        T_PHREAL32      = 0x0340,

        /// <summary>
        /// 32 bit pointer to 32 bit real
        /// </summary>
        T_32PREAL32     = 0x0440,

        /// <summary>
        /// 16:32 pointer to 32 bit real
        /// </summary>
        T_32PFREAL32    = 0x0540,

        /// <summary>
        /// 64 bit pointer to 32 bit real
        /// </summary>
        T_64PREAL32     = 0x0640,

//      32 bit partial-precision real types

        /// <summary>
        /// 32 bit PP real
        /// </summary>
        T_REAL32PP      = 0x0045,

        /// <summary>
        /// 16 bit pointer to 32 bit PP real
        /// </summary>
        T_PREAL32PP     = 0x0145,

        /// <summary>
        /// 16:16 far pointer to 32 bit PP real
        /// </summary>
        T_PFREAL32PP    = 0x0245,

        /// <summary>
        /// 16:16 huge pointer to 32 bit PP real
        /// </summary>
        T_PHREAL32PP    = 0x0345,

        /// <summary>
        /// 32 bit pointer to 32 bit PP real
        /// </summary>
        T_32PREAL32PP   = 0x0445,

        /// <summary>
        /// 16:32 pointer to 32 bit PP real
        /// </summary>
        T_32PFREAL32PP  = 0x0545,

        /// <summary>
        /// 64 bit pointer to 32 bit PP real
        /// </summary>
        T_64PREAL32PP   = 0x0645,

//      48 bit real types

        /// <summary>
        /// 48 bit real
        /// </summary>
        T_REAL48        = 0x0044,

        /// <summary>
        /// 16 bit pointer to 48 bit real
        /// </summary>
        T_PREAL48       = 0x0144,

        /// <summary>
        /// 16:16 far pointer to 48 bit real
        /// </summary>
        T_PFREAL48      = 0x0244,

        /// <summary>
        /// 16:16 huge pointer to 48 bit real
        /// </summary>
        T_PHREAL48      = 0x0344,

        /// <summary>
        /// 32 bit pointer to 48 bit real
        /// </summary>
        T_32PREAL48     = 0x0444,

        /// <summary>
        /// 16:32 pointer to 48 bit real
        /// </summary>
        T_32PFREAL48    = 0x0544,

        /// <summary>
        /// 64 bit pointer to 48 bit real
        /// </summary>
        T_64PREAL48     = 0x0644,

//      64 bit real types

        /// <summary>
        /// 64 bit real
        /// </summary>
        T_REAL64        = 0x0041,

        /// <summary>
        /// 16 bit pointer to 64 bit real
        /// </summary>
        T_PREAL64       = 0x0141,

        /// <summary>
        /// 16:16 far pointer to 64 bit real
        /// </summary>
        T_PFREAL64      = 0x0241,

        /// <summary>
        /// 16:16 huge pointer to 64 bit real
        /// </summary>
        T_PHREAL64      = 0x0341,

        /// <summary>
        /// 32 bit pointer to 64 bit real
        /// </summary>
        T_32PREAL64     = 0x0441,

        /// <summary>
        /// 16:32 pointer to 64 bit real
        /// </summary>
        T_32PFREAL64    = 0x0541,

        /// <summary>
        /// 64 bit pointer to 64 bit real
        /// </summary>
        T_64PREAL64     = 0x0641,

//      80 bit real types

        /// <summary>
        /// 80 bit real
        /// </summary>
        T_REAL80        = 0x0042,

        /// <summary>
        /// 16 bit pointer to 80 bit real
        /// </summary>
        T_PREAL80       = 0x0142,

        /// <summary>
        /// 16:16 far pointer to 80 bit real
        /// </summary>
        T_PFREAL80      = 0x0242,

        /// <summary>
        /// 16:16 huge pointer to 80 bit real
        /// </summary>
        T_PHREAL80      = 0x0342,

        /// <summary>
        /// 32 bit pointer to 80 bit real
        /// </summary>
        T_32PREAL80     = 0x0442,

        /// <summary>
        /// 16:32 pointer to 80 bit real
        /// </summary>
        T_32PFREAL80    = 0x0542,

        /// <summary>
        /// 64 bit pointer to 80 bit real
        /// </summary>
        T_64PREAL80     = 0x0642,

//      128 bit real types

        /// <summary>
        /// 128 bit real
        /// </summary>
        T_REAL128       = 0x0043,

        /// <summary>
        /// 16 bit pointer to 128 bit real
        /// </summary>
        T_PREAL128      = 0x0143,

        /// <summary>
        /// 16:16 far pointer to 128 bit real
        /// </summary>
        T_PFREAL128     = 0x0243,

        /// <summary>
        /// 16:16 huge pointer to 128 bit real
        /// </summary>
        T_PHREAL128     = 0x0343,

        /// <summary>
        /// 32 bit pointer to 128 bit real
        /// </summary>
        T_32PREAL128    = 0x0443,

        /// <summary>
        /// 16:32 pointer to 128 bit real
        /// </summary>
        T_32PFREAL128   = 0x0543,

        /// <summary>
        /// 64 bit pointer to 128 bit real
        /// </summary>
        T_64PREAL128    = 0x0643,

//      32 bit complex types

        /// <summary>
        /// 32 bit complex
        /// </summary>
        T_CPLX32        = 0x0050,

        /// <summary>
        /// 16 bit pointer to 32 bit complex
        /// </summary>
        T_PCPLX32       = 0x0150,

        /// <summary>
        /// 16:16 far pointer to 32 bit complex
        /// </summary>
        T_PFCPLX32      = 0x0250,

        /// <summary>
        /// 16:16 huge pointer to 32 bit complex
        /// </summary>
        T_PHCPLX32      = 0x0350,

        /// <summary>
        /// 32 bit pointer to 32 bit complex
        /// </summary>
        T_32PCPLX32     = 0x0450,

        /// <summary>
        /// 16:32 pointer to 32 bit complex
        /// </summary>
        T_32PFCPLX32    = 0x0550,

        /// <summary>
        /// 64 bit pointer to 32 bit complex
        /// </summary>
        T_64PCPLX32     = 0x0650,

//      64 bit complex types

        /// <summary>
        /// 64 bit complex
        /// </summary>
        T_CPLX64        = 0x0051,

        /// <summary>
        /// 16 bit pointer to 64 bit complex
        /// </summary>
        T_PCPLX64       = 0x0151,

        /// <summary>
        /// 16:16 far pointer to 64 bit complex
        /// </summary>
        T_PFCPLX64      = 0x0251,

        /// <summary>
        /// 16:16 huge pointer to 64 bit complex
        /// </summary>
        T_PHCPLX64      = 0x0351,

        /// <summary>
        /// 32 bit pointer to 64 bit complex
        /// </summary>
        T_32PCPLX64     = 0x0451,

        /// <summary>
        /// 16:32 pointer to 64 bit complex
        /// </summary>
        T_32PFCPLX64    = 0x0551,

        /// <summary>
        /// 64 bit pointer to 64 bit complex
        /// </summary>
        T_64PCPLX64     = 0x0651,

//      80 bit complex types

        /// <summary>
        /// 80 bit complex
        /// </summary>
        T_CPLX80        = 0x0052,

        /// <summary>
        /// 16 bit pointer to 80 bit complex
        /// </summary>
        T_PCPLX80       = 0x0152,

        /// <summary>
        /// 16:16 far pointer to 80 bit complex
        /// </summary>
        T_PFCPLX80      = 0x0252,

        /// <summary>
        /// 16:16 huge pointer to 80 bit complex
        /// </summary>
        T_PHCPLX80      = 0x0352,

        /// <summary>
        /// 32 bit pointer to 80 bit complex
        /// </summary>
        T_32PCPLX80     = 0x0452,

        /// <summary>
        /// 16:32 pointer to 80 bit complex
        /// </summary>
        T_32PFCPLX80    = 0x0552,

        /// <summary>
        /// 64 bit pointer to 80 bit complex
        /// </summary>
        T_64PCPLX80     = 0x0652,

//      128 bit complex types

        /// <summary>
        /// 128 bit complex
        /// </summary>
        T_CPLX128       = 0x0053,

        /// <summary>
        /// 16 bit pointer to 128 bit complex
        /// </summary>
        T_PCPLX128      = 0x0153,

        /// <summary>
        /// 16:16 far pointer to 128 bit complex
        /// </summary>
        T_PFCPLX128     = 0x0253,

        /// <summary>
        /// 16:16 huge pointer to 128 bit real
        /// </summary>
        T_PHCPLX128     = 0x0353,

        /// <summary>
        /// 32 bit pointer to 128 bit complex
        /// </summary>
        T_32PCPLX128    = 0x0453,

        /// <summary>
        /// 16:32 pointer to 128 bit complex
        /// </summary>
        T_32PFCPLX128   = 0x0553,

        /// <summary>
        /// 64 bit pointer to 128 bit complex
        /// </summary>
        T_64PCPLX128    = 0x0653,

//      boolean types

        /// <summary>
        /// 8 bit boolean
        /// </summary>
        T_BOOL08        = 0x0030,

        /// <summary>
        /// 16 bit pointer to  8 bit boolean
        /// </summary>
        T_PBOOL08       = 0x0130,

        /// <summary>
        /// 16:16 far pointer to  8 bit boolean
        /// </summary>
        T_PFBOOL08      = 0x0230,

        /// <summary>
        /// 16:16 huge pointer to  8 bit boolean
        /// </summary>
        T_PHBOOL08      = 0x0330,

        /// <summary>
        /// 32 bit pointer to 8 bit boolean
        /// </summary>
        T_32PBOOL08     = 0x0430,

        /// <summary>
        /// 16:32 pointer to 8 bit boolean
        /// </summary>
        T_32PFBOOL08    = 0x0530,

        /// <summary>
        /// 64 bit pointer to 8 bit boolean
        /// </summary>
        T_64PBOOL08     = 0x0630,

        /// <summary>
        /// 16 bit boolean
        /// </summary>
        T_BOOL16        = 0x0031,

        /// <summary>
        /// 16 bit pointer to 16 bit boolean
        /// </summary>
        T_PBOOL16       = 0x0131,

        /// <summary>
        /// 16:16 far pointer to 16 bit boolean
        /// </summary>
        T_PFBOOL16      = 0x0231,

        /// <summary>
        /// 16:16 huge pointer to 16 bit boolean
        /// </summary>
        T_PHBOOL16      = 0x0331,

        /// <summary>
        /// 32 bit pointer to 18 bit boolean
        /// </summary>
        T_32PBOOL16     = 0x0431,

        /// <summary>
        /// 16:32 pointer to 16 bit boolean
        /// </summary>
        T_32PFBOOL16    = 0x0531,

        /// <summary>
        /// 64 bit pointer to 18 bit boolean
        /// </summary>
        T_64PBOOL16     = 0x0631,

        /// <summary>
        /// 32 bit boolean
        /// </summary>
        T_BOOL32        = 0x0032,

        /// <summary>
        /// 16 bit pointer to 32 bit boolean
        /// </summary>
        T_PBOOL32       = 0x0132,

        /// <summary>
        /// 16:16 far pointer to 32 bit boolean
        /// </summary>
        T_PFBOOL32      = 0x0232,

        /// <summary>
        /// 16:16 huge pointer to 32 bit boolean
        /// </summary>
        T_PHBOOL32      = 0x0332,

        /// <summary>
        /// 32 bit pointer to 32 bit boolean
        /// </summary>
        T_32PBOOL32     = 0x0432,

        /// <summary>
        /// 16:32 pointer to 32 bit boolean
        /// </summary>
        T_32PFBOOL32    = 0x0532,

        /// <summary>
        /// 64 bit pointer to 32 bit boolean
        /// </summary>
        T_64PBOOL32     = 0x0632,

        /// <summary>
        /// 64 bit boolean
        /// </summary>
        T_BOOL64        = 0x0033,

        /// <summary>
        /// 16 bit pointer to 64 bit boolean
        /// </summary>
        T_PBOOL64       = 0x0133,

        /// <summary>
        /// 16:16 far pointer to 64 bit boolean
        /// </summary>
        T_PFBOOL64      = 0x0233,

        /// <summary>
        /// 16:16 huge pointer to 64 bit boolean
        /// </summary>
        T_PHBOOL64      = 0x0333,

        /// <summary>
        /// 32 bit pointer to 64 bit boolean
        /// </summary>
        T_32PBOOL64     = 0x0433,

        /// <summary>
        /// 16:32 pointer to 64 bit boolean
        /// </summary>
        T_32PFBOOL64    = 0x0533,

        /// <summary>
        /// 64 bit pointer to 64 bit boolean
        /// </summary>
        T_64PBOOL64     = 0x0633,

//      ???

        /// <summary>
        /// CV Internal type for created near pointers
        /// </summary>
        T_NCVPTR        = 0x01f0,

        /// <summary>
        /// CV Internal type for created far pointers
        /// </summary>
        T_FCVPTR        = 0x02f0,

        /// <summary>
        /// CV Internal type for created huge pointers
        /// </summary>
        T_HCVPTR        = 0x03f0,

        /// <summary>
        /// CV Internal type for created near 32-bit pointers
        /// </summary>
        T_32NCVPTR      = 0x04f0,

        /// <summary>
        /// CV Internal type for created far 32-bit pointers
        /// </summary>
        T_32FCVPTR      = 0x05f0,

        /// <summary>
        /// CV Internal type for created near 64-bit pointers
        /// </summary>
        T_64NCVPTR      = 0x06f0
    }
}
