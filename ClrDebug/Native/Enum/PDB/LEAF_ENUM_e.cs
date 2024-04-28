namespace ClrDebug.PDB
{
    public enum LEAF_ENUM_e : ushort
    {
        // leaf indices starting records but referenced from symbol records

        /// <summary>
        /// Type: <see cref="lfModifier_16t"/>
        /// </summary>
        LF_MODIFIER_16t     = 0x0001,

        LF_POINTER_16t      = 0x0002,

        /// <summary>
        /// Type: <see cref="lfArray_16t"/>
        /// </summary>
        LF_ARRAY_16t        = 0x0003,

        /// <summary>
        /// Type: <see cref="lfClass_16t"/>
        /// </summary>
        LF_CLASS_16t        = 0x0004,

        LF_STRUCTURE_16t    = 0x0005,

        /// <summary>
        /// Type: <see cref="lfUnion_16t"/>
        /// </summary>
        LF_UNION_16t        = 0x0006,

        /// <summary>
        /// Type: <see cref="lfEnum_16t"/>
        /// </summary>
        LF_ENUM_16t         = 0x0007,

        /// <summary>
        /// Type: <see cref="lfProc_16t"/>
        /// </summary>
        LF_PROCEDURE_16t    = 0x0008,

        /// <summary>
        /// Type: <see cref="lfMFunc_16t"/>
        /// </summary>
        LF_MFUNCTION_16t    = 0x0009,

        /// <summary>
        /// Type: <see cref="lfVTShape"/>
        /// </summary>
        LF_VTSHAPE          = 0x000a,

        /// <summary>
        /// Type: <see cref="lfCobol0_16t"/>
        /// </summary>
        LF_COBOL0_16t       = 0x000b,

        /// <summary>
        /// Type: <see cref="lfCobol1"/>
        /// </summary>
        LF_COBOL1           = 0x000c,

        /// <summary>
        /// Type: <see cref="lfBArray_16t"/>
        /// </summary>
        LF_BARRAY_16t       = 0x000d,

        /// <summary>
        /// Type: <see cref="lfLabel"/>
        /// </summary>
        LF_LABEL            = 0x000e,

        LF_NULL             = 0x000f,
        LF_NOTTRAN          = 0x0010,

        /// <summary>
        /// Type: <see cref="lfDimArray_16t"/>
        /// </summary>
        LF_DIMARRAY_16t     = 0x0011,

        /// <summary>
        /// Type: <see cref="lfVFTPath_16t"/>
        /// </summary>
        LF_VFTPATH_16t      = 0x0012,

        /// <summary>
        /// not referenced from symbol<para/>
        /// Type: <see cref="lfPreComp_16t"/>
        /// </summary>
        LF_PRECOMP_16t      = 0x0013,

        /// <summary>
        /// not referenced from symbol<para/>
        /// Type: <see cref="lfEndPreComp"/>
        /// </summary>
        LF_ENDPRECOMP       = 0x0014,

        /// <summary>
        /// oem definable type string<para/>
        /// Type: <see cref="lfOEM_16t"/>
        /// </summary>
        LF_OEM_16t          = 0x0015,

        /// <summary>
        /// not referenced from symbol
        /// </summary>
        LF_TYPESERVER_ST    = 0x0016,

        // leaf indices starting records but referenced only from type records

        /// <summary>
        /// Type: <see cref="lfSkip_16t"/>
        /// </summary>
        LF_SKIP_16t         = 0x0200,

        /// <summary>
        /// Type: <see cref="lfArgList_16t"/>
        /// </summary>
        LF_ARGLIST_16t      = 0x0201,

        /// <summary>
        /// Type: <see cref="lfDefArg_16t"/>
        /// </summary>
        LF_DEFARG_16t       = 0x0202,

        /// <summary>
        /// Type: <see cref="lfList"/>
        /// </summary>
        LF_LIST             = 0x0203,

        /// <summary>
        /// Type: <see cref="lfFieldList_16t"/>
        /// </summary>
        LF_FIELDLIST_16t    = 0x0204,

        /// <summary>
        /// Type: <see cref="lfDerived_16t"/>
        /// </summary>
        LF_DERIVED_16t      = 0x0205,

        /// <summary>
        /// Type: <see cref="lfBitfield_16t"/>
        /// </summary>
        LF_BITFIELD_16t     = 0x0206,

        LF_METHODLIST_16t   = 0x0207,

        /// <summary>
        /// Type: <see cref="lfDimCon_16t"/>
        /// </summary>
        LF_DIMCONU_16t      = 0x0208,

        /// <summary>
        /// Type: <see cref="lfDimCon_16t"/>
        /// </summary>
        LF_DIMCONLU_16t     = 0x0209,

        /// <summary>
        /// Type: <see cref="lfDimVar_16t"/>
        /// </summary>
        LF_DIMVARU_16t      = 0x020a,

        /// <summary>
        /// Type: <see cref="lfDimVar_16t"/>
        /// </summary>
        LF_DIMVARLU_16t     = 0x020b,

        /// <summary>
        /// Type: <see cref="lfRefSym"/>
        /// </summary>
        LF_REFSYM           = 0x020c,

        /// <summary>
        /// Type: <see cref="lfBClass_16t"/>
        /// </summary>
        LF_BCLASS_16t       = 0x0400,

        /// <summary>
        /// Type: <see cref="lfVBClass_16t"/>
        /// </summary>
        LF_VBCLASS_16t      = 0x0401,

        LF_IVBCLASS_16t     = 0x0402,
        LF_ENUMERATE_ST     = 0x0403,

        /// <summary>
        /// Type: <see cref="lfFriendFcn_16t"/>
        /// </summary>
        LF_FRIENDFCN_16t    = 0x0404,

        /// <summary>
        /// Type: <see cref="lfIndex_16t"/>
        /// </summary>
        LF_INDEX_16t        = 0x0405,

        /// <summary>
        /// Type: <see cref="lfMember_16t"/>
        /// </summary>
        LF_MEMBER_16t       = 0x0406,

        /// <summary>
        /// Type: <see cref="lfSTMember_16t"/>
        /// </summary>
        LF_STMEMBER_16t     = 0x0407,

        /// <summary>
        /// Type: <see cref="lfMethod_16t"/>
        /// </summary>
        LF_METHOD_16t       = 0x0408,

        /// <summary>
        /// Type: <see cref="lfNestType_16t"/>
        /// </summary>
        LF_NESTTYPE_16t     = 0x0409,

        /// <summary>
        /// Type: <see cref="lfVFuncTab_16t"/>
        /// </summary>
        LF_VFUNCTAB_16t     = 0x040a,

        /// <summary>
        /// Type: <see cref="lfFriendCls_16t"/>
        /// </summary>
        LF_FRIENDCLS_16t    = 0x040b,

        /// <summary>
        /// Type: <see cref="lfOneMethod_16t"/>
        /// </summary>
        LF_ONEMETHOD_16t    = 0x040c,

        /// <summary>
        /// Type: <see cref="lfVFuncOff_16t"/>
        /// </summary>
        LF_VFUNCOFF_16t     = 0x040d,

// 32-bit type index versions of leaves, all have the 0x1000 bit set
//
        LF_TI16_MAX         = 0x1000,

        /// <summary>
        /// Type: <see cref="lfModifier"/>
        /// </summary>
        LF_MODIFIER         = 0x1001,

        /// <summary>
        /// Type: <see cref="lfPointer"/>
        /// </summary>
        LF_POINTER          = 0x1002,

        LF_ARRAY_ST         = 0x1003,
        LF_CLASS_ST         = 0x1004,
        LF_STRUCTURE_ST     = 0x1005,
        LF_UNION_ST         = 0x1006,
        LF_ENUM_ST          = 0x1007,

        /// <summary>
        /// Type: <see cref="lfProc"/>
        /// </summary>
        LF_PROCEDURE        = 0x1008,

        /// <summary>
        /// Type: <see cref="lfMFunc"/>
        /// </summary>
        LF_MFUNCTION        = 0x1009,

        /// <summary>
        /// Type: <see cref="lfCobol0"/>
        /// </summary>
        LF_COBOL0           = 0x100a,

        /// <summary>
        /// Type: <see cref="lfBArray"/>
        /// </summary>
        LF_BARRAY           = 0x100b,
        LF_DIMARRAY_ST      = 0x100c,

        /// <summary>
        /// Type: <see cref="lfVFTPath"/>
        /// </summary>
        LF_VFTPATH          = 0x100d,

        /// <summary>
        /// not referenced from symbol
        /// </summary>
        LF_PRECOMP_ST       = 0x100e,

        /// <summary>
        /// oem definable type string<para/>
        /// Type: <see cref="lfOEM"/>
        /// </summary>
        LF_OEM              = 0x100f,

        /// <summary>
        /// alias (typedef) type
        /// </summary>
        LF_ALIAS_ST         = 0x1010,

        /// <summary>
        /// oem definable type string<para/>
        /// Type: <see cref="lfOEM2"/>
        /// </summary>
        LF_OEM2             = 0x1011,

        // leaf indices starting records but referenced only from type records

        /// <summary>
        /// Type: <see cref="lfSkip"/>
        /// </summary>
        LF_SKIP             = 0x1200,

        /// <summary>
        /// Type: <see cref="lfArgList"/>
        /// </summary>
        LF_ARGLIST          = 0x1201,
        LF_DEFARG_ST        = 0x1202,

        /// <summary>
        /// Type: <see cref="lfFieldList"/>
        /// </summary>
        LF_FIELDLIST        = 0x1203,

        /// <summary>
        /// Type: <see cref="lfDerived"/>
        /// </summary>
        LF_DERIVED          = 0x1204,

        /// <summary>
        /// Type: <see cref="lfBitfield"/>
        /// </summary>
        LF_BITFIELD         = 0x1205,
        LF_METHODLIST       = 0x1206,

        /// <summary>
        /// Type: <see cref="lfDimCon"/>
        /// </summary>
        LF_DIMCONU          = 0x1207,

        /// <summary>
        /// Type: <see cref="lfDimCon"/>
        /// </summary>
        LF_DIMCONLU         = 0x1208,

        /// <summary>
        /// Type: <see cref="lfDimVar"/>
        /// </summary>
        LF_DIMVARU          = 0x1209,

        /// <summary>
        /// Type: <see cref="lfDimVar"/>
        /// </summary>
        LF_DIMVARLU         = 0x120a,

        /// <summary>
        /// Type: <see cref="lfBClass"/>
        /// </summary>
        LF_BCLASS           = 0x1400,

        /// <summary>
        /// Type: <see cref="lfVBClass"/>
        /// </summary>
        LF_VBCLASS          = 0x1401,
        LF_IVBCLASS         = 0x1402,
        LF_FRIENDFCN_ST     = 0x1403,

        /// <summary>
        /// Type: <see cref="lfIndex"/>
        /// </summary>
        LF_INDEX            = 0x1404,
        LF_MEMBER_ST        = 0x1405,
        LF_STMEMBER_ST      = 0x1406,
        LF_METHOD_ST        = 0x1407,
        LF_NESTTYPE_ST      = 0x1408,

        /// <summary>
        /// Type: <see cref="lfVFuncTab"/>
        /// </summary>
        LF_VFUNCTAB         = 0x1409,

        /// <summary>
        /// Type: <see cref="lfFriendCls"/>
        /// </summary>
        LF_FRIENDCLS        = 0x140a,
        LF_ONEMETHOD_ST     = 0x140b,

        /// <summary>
        /// Type: <see cref="lfVFuncOff"/>
        /// </summary>
        LF_VFUNCOFF         = 0x140c,
        LF_NESTTYPEEX_ST    = 0x140d,
        LF_MEMBERMODIFY_ST  = 0x140e,
        LF_MANAGED_ST       = 0x140f,

        // Types w/ SZ names

        LF_ST_MAX           = 0x1500,

        /// <summary>
        /// not referenced from symbol<para/>
        /// Type: <see cref="lfTypeServer"/>
        /// </summary>
        LF_TYPESERVER       = 0x1501,

        /// <summary>
        /// Type: <see cref="lfEnumerate"/>
        /// </summary>
        LF_ENUMERATE        = 0x1502,

        /// <summary>
        /// Type: <see cref="lfArray"/>
        /// </summary>
        LF_ARRAY            = 0x1503,

        /// <summary>
        /// Type: <see cref="lfClass"/>
        /// </summary>
        LF_CLASS            = 0x1504,
        LF_STRUCTURE        = 0x1505,

        /// <summary>
        /// Type: <see cref="lfUnion"/>
        /// </summary>
        LF_UNION            = 0x1506,

        /// <summary>
        /// Type: <see cref="lfEnum"/>
        /// </summary>
        LF_ENUM             = 0x1507,

        /// <summary>
        /// Type: <see cref="lfDimArray"/>
        /// </summary>
        LF_DIMARRAY         = 0x1508,

        /// <summary>
        /// not referenced from symbol<para/>
        /// Type: <see cref="lfPreComp"/>
        /// </summary>
        LF_PRECOMP          = 0x1509,

        /// <summary>
        /// alias (typedef) type<para/>
        /// Type: <see cref="lfAlias"/>
        /// </summary>
        LF_ALIAS            = 0x150a,

        /// <summary>
        /// Type: <see cref="lfDefArg"/>
        /// </summary>
        LF_DEFARG           = 0x150b,

        /// <summary>
        /// Type: <see cref="lfFriendFcn"/>
        /// </summary>
        LF_FRIENDFCN        = 0x150c,

        /// <summary>
        /// Type: <see cref="lfMember"/>
        /// </summary>
        LF_MEMBER           = 0x150d,

        /// <summary>
        /// Type: <see cref="lfSTMember"/>
        /// </summary>
        LF_STMEMBER         = 0x150e,

        /// <summary>
        /// Type: <see cref="lfMethod"/>
        /// </summary>
        LF_METHOD           = 0x150f,

        /// <summary>
        /// Type: <see cref="lfNestType"/>
        /// </summary>
        LF_NESTTYPE         = 0x1510,

        /// <summary>
        /// Type: <see cref="lfOneMethod"/>
        /// </summary>
        LF_ONEMETHOD        = 0x1511,

        /// <summary>
        /// Type: <see cref="lfNestTypeEx"/>
        /// </summary>
        LF_NESTTYPEEX       = 0x1512,

        /// <summary>
        /// Type: <see cref="lfMemberModify"/>
        /// </summary>
        LF_MEMBERMODIFY     = 0x1513,

        /// <summary>
        /// Type: <see cref="lfManaged"/>
        /// </summary>
        LF_MANAGED          = 0x1514,

        /// <summary>
        /// Type: <see cref="lfTypeServer2"/>
        /// </summary>
        LF_TYPESERVER2      = 0x1515,

        /// <summary>
        /// same as LF_ARRAY, but with stride between adjacent elements<para/>
        /// Type: <see cref="lfStridedArray"/>
        /// </summary>
        LF_STRIDED_ARRAY    = 0x1516,

        /// <summary>
        /// Type: <see cref="lfHLSL"/>
        /// </summary>
        LF_HLSL             = 0x1517,

        /// <summary>
        /// Type: <see cref="lfModifierEx"/>
        /// </summary>
        LF_MODIFIER_EX      = 0x1518,

        /// <summary>
        /// Type: <see cref="lfClass"/>
        /// </summary>
        LF_INTERFACE        = 0x1519,

        /// <summary>
        /// Type: <see cref="lfBClass"/>
        /// </summary>
        LF_BINTERFACE       = 0x151a,

        /// <summary>
        /// Type: <see cref="lfVector"/>
        /// </summary>
        LF_VECTOR           = 0x151b,

        /// <summary>
        /// Type: <see cref="lfMatrix"/>
        /// </summary>
        LF_MATRIX           = 0x151c,

        /// <summary>
        /// a virtual function table<para/>
        /// Type: <see cref="lfVftable"/>
        /// </summary>
        LF_VFTABLE          = 0x151d,

        LF_ENDOFLEAFRECORD  = LF_VFTABLE,

        /// <summary>
        /// one greater than the last type record
        /// </summary>
        LF_TYPE_LAST,

        LF_TYPE_MAX         = LF_TYPE_LAST - 1,

        /// <summary>
        /// global func ID<para/>
        /// Type: <see cref="lfFuncId"/>
        /// </summary>
        LF_FUNC_ID          = 0x1601,

        /// <summary>
        /// member func ID<para/>
        /// Type: <see cref="lfMFuncId"/>
        /// </summary>
        LF_MFUNC_ID         = 0x1602,

        /// <summary>
        /// build info: tool, version, command line, src/pdb file<para/>
        /// Type: <see cref="lfBuildInfo"/>
        /// </summary>
        LF_BUILDINFO        = 0x1603,

        /// <summary>
        /// similar to LF_ARGLIST, for list of sub strings<para/>
        /// Type: <see cref="lfArgList"/>
        /// </summary>
        LF_SUBSTR_LIST      = 0x1604,

        /// <summary>
        /// string ID<para/>
        /// Type: <see cref="lfStringId"/>
        /// </summary>
        LF_STRING_ID        = 0x1605,

        /// <summary>
        /// source and line on where an UDT is defined<para/>
        /// Type: <see cref="lfUdtSrcLine"/>
        /// </summary>
        LF_UDT_SRC_LINE     = 0x1606,

        // only generated by compiler

        /// <summary>
        /// module, source and line on where an UDT is defined<para/>
        /// Type: <see cref="lfUdtModSrcLine"/>
        /// </summary>
        LF_UDT_MOD_SRC_LINE = 0x1607,

        // only generated by linker

        /// <summary>
        /// one greater than the last ID record
        /// </summary>
        LF_ID_LAST,

        LF_ID_MAX           = LF_ID_LAST - 1,

        LF_NUMERIC          = 0x8000,

        /// <summary>
        /// Type: <see cref="lfChar"/>
        /// </summary>
        LF_CHAR             = 0x8000,

        /// <summary>
        /// Type: <see cref="lfShort"/>
        /// </summary>
        LF_SHORT            = 0x8001,

        /// <summary>
        /// Type: <see cref="lfUShort"/>
        /// </summary>
        LF_USHORT = 0x8002,

        /// <summary>
        /// Type: <see cref="lfLong"/>
        /// </summary>
        LF_LONG             = 0x8003,

        /// <summary>
        /// Type: <see cref="lfULong"/>
        /// </summary>
        LF_ULONG            = 0x8004,

        /// <summary>
        /// Type: <see cref="lfReal32"/>
        /// </summary>
        LF_REAL32           = 0x8005,

        /// <summary>
        /// Type: <see cref="lfReal64"/>
        /// </summary>
        LF_REAL64           = 0x8006,

        /// <summary>
        /// Type: <see cref="lfReal80"/>
        /// </summary>
        LF_REAL80           = 0x8007,

        /// <summary>
        /// Type: <see cref="lfReal128"/>
        /// </summary>
        LF_REAL128          = 0x8008,
        LF_QUADWORD         = 0x8009,
        LF_UQUADWORD        = 0x800a,

        /// <summary>
        /// Type: <see cref="lfReal48"/>
        /// </summary>
        LF_REAL48           = 0x800b,

        /// <summary>
        /// Type: <see cref="lfCmplx32"/>
        /// </summary>
        LF_COMPLEX32        = 0x800c,

        /// <summary>
        /// Type: <see cref="lfCmplx64"/>
        /// </summary>
        LF_COMPLEX64        = 0x800d,

        /// <summary>
        /// Type: <see cref="lfCmplx80"/>
        /// </summary>
        LF_COMPLEX80        = 0x800e,

        /// <summary>
        /// Type: <see cref="lfCmplx128"/>
        /// </summary>
        LF_COMPLEX128       = 0x800f,

        /// <summary>
        /// Type: <see cref="lfVarString"/>
        /// </summary>
        LF_VARSTRING        = 0x8010,

        LF_OCTWORD          = 0x8017,
        LF_UOCTWORD         = 0x8018,

        LF_DECIMAL          = 0x8019,
        LF_DATE             = 0x801a,
        LF_UTF8STRING       = 0x801b,

        /// <summary>
        /// Type: <see cref="lfReal16"/>
        /// </summary>
        LF_REAL16           = 0x801c,
    
        LF_PAD0             = 0xf0,
        LF_PAD1             = 0xf1,
        LF_PAD2             = 0xf2,
        LF_PAD3             = 0xf3,
        LF_PAD4             = 0xf4,
        LF_PAD5             = 0xf5,
        LF_PAD6             = 0xf6,
        LF_PAD7             = 0xf7,
        LF_PAD8             = 0xf8,
        LF_PAD9             = 0xf9,
        LF_PAD10            = 0xfa,
        LF_PAD11            = 0xfb,
        LF_PAD12            = 0xfc,
        LF_PAD13            = 0xfd,
        LF_PAD14            = 0xfe,
        LF_PAD15            = 0xff
    }
}
