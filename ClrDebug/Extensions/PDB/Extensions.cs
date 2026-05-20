using System.Runtime.CompilerServices;
using ClrDebug.DIA;
using static ClrDebug.IMAGE_FILE_MACHINE;
using static ClrDebug.DIA.CV_CPU_TYPE_e;
using static ClrDebug.PDB.CV_prmode_e;
using static ClrDebug.PDB.CV_type_e;
using static ClrDebug.PDB.TYPE_ENUM_e;

namespace ClrDebug.PDB
{
    public partial struct CV_ItemId
    {
        public bool IsCrossScopeId => (Value & 0x80000000) == 0x80000000;
    }

    public static partial class PdbExtensions
    {
        public const int CV_MMASK = 0x700;       // mode mask
        public const int CV_TMASK = 0x0f0;       // type mask

        // can we use the reserved bit ??
        public const int CV_SMASK = 0x00f;       // subtype mask

        public const int CV_MSHIFT = 8;           // primitive mode right shift count
        public const int CV_TSHIFT = 4;           // primitive type right shift count
        public const int CV_SSHIFT = 0;           // primitive subtype right shift count

        // macros to extract primitive mode, type and size

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static CV_prmode_e CV_MODE(this TYPE_ENUM_e typ) => (CV_prmode_e) (((int) typ & CV_MMASK) >> CV_MSHIFT);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static CV_type_e CV_TYPE(this TYPE_ENUM_e typ)  =>  (CV_type_e) (((int) typ & CV_TMASK) >> CV_TSHIFT);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int CV_SUBT(this TYPE_ENUM_e typ)  =>  ((((int) typ) & CV_SMASK) >> CV_SSHIFT); //depending on the CV_TYPE, will be one of CV_special_e / CV_special2_e / CV_integral_e / CV_real_e / CV_int_e

        // macros to insert new primitive mode, type and size

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static CV_prmode_e CV_NEWMODE(this int typ, int nm) => (CV_prmode_e) ((typ & ~CV_MMASK) | (nm << CV_MSHIFT));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static CV_type_e CV_NEWTYPE(this int typ, int nt) => (CV_type_e) ((typ & ~CV_TMASK) | (nt << CV_TSHIFT));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int CV_NEWSUBT(this int typ, int ns) => ((typ & ~CV_SMASK) | (ns << CV_SSHIFT));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool CV_TYP_IS_DIRECT(this TYPE_ENUM_e typ) => (CV_MODE(typ) == CV_TM_DIRECT);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool CV_TYP_IS_PTR(this TYPE_ENUM_e typ) => (CV_MODE(typ) != CV_TM_DIRECT);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool CV_TYP_IS_NPTR(this TYPE_ENUM_e typ) => (CV_MODE(typ) == CV_TM_NPTR);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool CV_TYP_IS_FPTR(this TYPE_ENUM_e typ) => (CV_MODE(typ) == CV_TM_FPTR);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool CV_TYP_IS_HPTR(this TYPE_ENUM_e typ) => (CV_MODE(typ) == CV_TM_HPTR);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool CV_TYP_IS_NPTR32(this TYPE_ENUM_e typ) => (CV_MODE(typ) == CV_TM_NPTR32);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool CV_TYP_IS_FPTR32(this TYPE_ENUM_e typ) => (CV_MODE(typ) == CV_TM_FPTR32);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool CV_TYP_IS_SIGNED(this TYPE_ENUM_e typ)  => ((CV_TYPE(typ) == CV_SIGNED && CV_TYP_IS_DIRECT(typ)) ||
                                                                       typ is T_INT1 or T_INT2 or T_INT4 or T_INT8 or T_INT16 or T_RCHAR);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool CV_TYP_IS_UNSIGNED(this TYPE_ENUM_e typ) => (((CV_TYPE(typ) == CV_UNSIGNED) && CV_TYP_IS_DIRECT(typ)) ||
                                                                        typ is T_UINT1 or T_UINT2 or T_UINT4 or T_UINT8 or T_UINT16);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool CV_TYP_IS_REAL(this TYPE_ENUM_e typ) => ((CV_TYPE(typ) == CV_REAL) && CV_TYP_IS_DIRECT(typ));

        public const int CV_FIRST_NONPRIM = 0x1000;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool CV_IS_PRIMITIVE(this CV_typ_t typ) => (((int) typ) < CV_FIRST_NONPRIM);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool CV_TYP_IS_COMPLEX(this TYPE_ENUM_e typ) => ((CV_TYPE(typ) == CV_COMPLEX) && CV_TYP_IS_DIRECT(typ));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool CV_IS_INTERNAL_PTR(this TYPE_ENUM_e typ) => (CV_IS_PRIMITIVE((int) typ) &&
                                                                        CV_TYPE(typ) == CV_CVRESERVED &&
                                                                        CV_TYP_IS_PTR(typ));

        private static readonly CV_HREG_e[] rgFramePointerRegX86 =
        {
            CV_HREG_e.CV_REG_NONE,
            CV_HREG_e.CV_ALLREG_VFRAME,
            CV_HREG_e.CV_REG_EBP,
            CV_HREG_e.CV_REG_EBX
        };

        private static readonly CV_HREG_e[] rgFramePointerRegX64 =
        {
            CV_HREG_e.CV_REG_NONE,
            CV_HREG_e.CV_AMD64_RSP,
            CV_HREG_e.CV_AMD64_RBP,
            CV_HREG_e.CV_AMD64_R13
        };

        private static readonly CV_HREG_e[] rgFramePointerRegArm =
        {
            CV_HREG_e.CV_REG_NONE,
            CV_HREG_e.CV_ARM_SP,
            CV_HREG_e.CV_ARM_R7,
            CV_HREG_e.CV_REG_NONE
        };

        //msdia140!COptDbgLocalTrav::getScopeSymbolInfo shows how various IMAGE_FILE_MACHINE types are translated
        //to CV_CPU_TYPE_e

        public static CV_HREG_e ExpandEncodedBasePointerReg(IMAGE_FILE_MACHINE machineType, int encodedFrameReg)
        {
            var cpuType = machineType switch
            {
                IMAGE_FILE_MACHINE_I386 => CV_CFL_PENTIUMIII,
                IMAGE_FILE_MACHINE_AMD64 => CV_CFL_AMD64,
                IMAGE_FILE_MACHINE_ARM64 => CV_CFL_ARM64,
                IMAGE_FILE_MACHINE_ARM64X => CV_CFL_ARM64X,
                IMAGE_FILE_MACHINE_ARMNT => CV_CFL_ARMNT,
                (IMAGE_FILE_MACHINE) 0x3A64 => CV_CFL_HYBRID_X86_ARM64
            };

            return ExpandEncodedBasePointerReg(cpuType, encodedFrameReg);
        }

        public static CV_HREG_e ExpandEncodedBasePointerReg(CV_CPU_TYPE_e machineType, int encodedFrameReg)
        {
            if (encodedFrameReg >= 4)
                return CV_HREG_e.CV_REG_NONE;

            switch (machineType)
            {
                case CV_CPU_TYPE_e.CV_CFL_8080 :
                case CV_CPU_TYPE_e.CV_CFL_8086 :
                case CV_CPU_TYPE_e.CV_CFL_80286 :
                case CV_CPU_TYPE_e.CV_CFL_80386 :
                case CV_CPU_TYPE_e.CV_CFL_80486 :
                case CV_CPU_TYPE_e.CV_CFL_PENTIUM :
                case CV_CPU_TYPE_e.CV_CFL_PENTIUMII :
                case CV_CPU_TYPE_e.CV_CFL_PENTIUMIII :
                    return rgFramePointerRegX86[encodedFrameReg];
                case CV_CPU_TYPE_e.CV_CFL_AMD64 :
                    return rgFramePointerRegX64[encodedFrameReg];
                case CV_CPU_TYPE_e.CV_CFL_ARMNT :
                    return rgFramePointerRegArm[encodedFrameReg];
                default:
                    return CV_HREG_e.CV_REG_NONE;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe int CVUncompressData(ref byte* pData)    // [IN,OUT] compressed data 
        {
            int res = -1;

            if ((*pData & 0x80) == 0x00)
            {
                // 0??? ????

                res = (int) (*pData++);
            }
            else if ((*pData & 0xC0) == 0x80)
            {
                // 10?? ????

                res = (int) ((*pData++ & 0x3f) << 8);
                res |= *pData++;
            }
            else if ((*pData & 0xE0) == 0xC0)
            {
                // 110? ???? 

                res = (*pData++ & 0x1f) << 24;
                res |= *pData++ << 16;
                res |= *pData++ << 8;
                res |= *pData++;
            }

            return res;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int DecodeSignedInt32(int input)
        {
            int rotatedInput;

            if ((input & 1) != 0)
            {
                rotatedInput = -(int) (input >> 1);
            }
            else
            {
                rotatedInput = input >> 1;
            }

            return rotatedInput;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int BinaryAnnotationInstructionOperandCount(BinaryAnnotationOpcode op) =>
            (op == BinaryAnnotationOpcode.BA_OP_ChangeCodeLengthAndCodeOffset) ? 2 : 1;
    }
}
