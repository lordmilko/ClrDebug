using System.ComponentModel;
using System.Runtime.CompilerServices;
using static ClrDebug.CorTypeAttr;
using static ClrDebug.CorMethodAttr;
using static ClrDebug.CorFieldAttr;
using static ClrDebug.CorParamAttr;
using static ClrDebug.CorPropertyAttr;
using static ClrDebug.CorEventAttr;
using static ClrDebug.CorMethodSemanticsAttr;
using static ClrDebug.CorDeclSecurity;
using static ClrDebug.CorMethodImpl;
using static ClrDebug.CorPinvokeMap;
using static ClrDebug.CorAssemblyFlags;
using static ClrDebug.CorManifestResourceFlags;
using static ClrDebug.CorFileFlags;
using static ClrDebug.Extensions;

namespace ClrDebug
{
    //#define (.+?)\(x\) +\(+x\)(.+)\)
    //public static bool $1(this CorTypeAttr attr) => (attr$2;

    [EditorBrowsable(EditorBrowsableState.Never)]
    public static class EnumExtensions
    {
        #region CorTypeAttr

        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool IsTdNotPublic(this CorTypeAttr attr) => (attr & tdVisibilityMask) == tdNotPublic;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool IsTdPublic(this CorTypeAttr attr) => (attr & tdVisibilityMask) == tdPublic;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool IsTdNestedPublic(this CorTypeAttr attr) => (attr & tdVisibilityMask) == tdNestedPublic;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool IsTdNestedPrivate(this CorTypeAttr attr) => (attr & tdVisibilityMask) == tdNestedPrivate;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool IsTdNestedFamily(this CorTypeAttr attr) => (attr & tdVisibilityMask) == tdNestedFamily;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool IsTdNestedAssembly(this CorTypeAttr attr) => (attr & tdVisibilityMask) == tdNestedAssembly;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool IsTdNestedFamANDAssem(this CorTypeAttr attr) => (attr & tdVisibilityMask) == tdNestedFamANDAssem;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool IsTdNestedFamORAssem(this CorTypeAttr attr) => (attr & tdVisibilityMask) == tdNestedFamORAssem;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool IsTdNested(this CorTypeAttr attr) => (attr & tdVisibilityMask) >= tdNestedPublic;

        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool IsTdAutoLayout(this CorTypeAttr attr) => (attr & tdLayoutMask) == tdAutoLayout;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool IsTdSequentialLayout(this CorTypeAttr attr) => (attr & tdLayoutMask) == tdSequentialLayout;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool IsTdExplicitLayout(this CorTypeAttr attr) => (attr & tdLayoutMask) == tdExplicitLayout;

        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool IsTdClass(this CorTypeAttr attr) => (attr & tdClassSemanticsMask) == tdClass;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool IsTdInterface(this CorTypeAttr attr) => (attr & tdClassSemanticsMask) == tdInterface;

        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool IsTdAbstract(this CorTypeAttr attr) => (attr & tdAbstract) != 0;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool IsTdSealed(this CorTypeAttr attr) => (attr & tdSealed) != 0;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool IsTdSpecialName(this CorTypeAttr attr) => (attr & tdSpecialName) != 0;

        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool IsTdImport(this CorTypeAttr attr) => (attr & tdImport) != 0;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool IsTdSerializable(this CorTypeAttr attr) => (attr & tdSerializable) != 0;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool IsTdWindowsRuntime(this CorTypeAttr attr) => (attr & tdWindowsRuntime) != 0;

        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool IsTdAnsiClass(this CorTypeAttr attr) => (attr & tdStringFormatMask) == tdAnsiClass;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool IsTdUnicodeClass(this CorTypeAttr attr) => (attr & tdStringFormatMask) == tdUnicodeClass;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool IsTdAutoClass(this CorTypeAttr attr) => (attr & tdStringFormatMask) == tdAutoClass;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool IsTdCustomFormatClass(this CorTypeAttr attr) => (attr & tdStringFormatMask) == tdCustomFormatClass;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool IsTdBeforeFieldInit(this CorTypeAttr attr) => (attr & tdBeforeFieldInit) != 0;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool IsTdForwarder(this CorTypeAttr attr) => (attr & tdForwarder) != 0;

        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool IsTdRTSpecialName(this CorTypeAttr attr) => (attr & tdRTSpecialName) != 0;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool IsTdHasSecurity(this CorTypeAttr attr) => (attr & tdHasSecurity) != 0;

        #endregion
        #region CorMethodAttr

        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool IsMdPrivateScope(this CorMethodAttr attr) => (attr & mdMemberAccessMask) == mdPrivateScope;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool IsMdPrivate(this CorMethodAttr attr) => (attr & mdMemberAccessMask) == mdPrivate;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool IsMdFamANDAssem(this CorMethodAttr attr) => (attr & mdMemberAccessMask) == mdFamANDAssem;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool IsMdAssem(this CorMethodAttr attr) => (attr & mdMemberAccessMask) == mdAssem;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool IsMdFamily(this CorMethodAttr attr) => (attr & mdMemberAccessMask) == mdFamily;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool IsMdFamORAssem(this CorMethodAttr attr) => (attr & mdMemberAccessMask) == mdFamORAssem;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool IsMdPublic(this CorMethodAttr attr) => (attr & mdMemberAccessMask) == mdPublic;

        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool IsMdStatic(this CorMethodAttr attr) => (attr & mdStatic) != 0;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool IsMdFinal(this CorMethodAttr attr) => (attr & mdFinal) != 0;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool IsMdVirtual(this CorMethodAttr attr) => (attr & mdVirtual) != 0;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool IsMdHideBySig(this CorMethodAttr attr) => (attr & mdHideBySig) != 0;

        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool IsMdReuseSlot(this CorMethodAttr attr) => (attr & mdVtableLayoutMask) == mdReuseSlot;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool IsMdNewSlot(this CorMethodAttr attr) => (attr & mdVtableLayoutMask) == mdNewSlot;

        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool IsMdCheckAccessOnOverride(this CorMethodAttr attr) => (attr & mdCheckAccessOnOverride) != 0;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool IsMdAbstract(this CorMethodAttr attr) => (attr & mdAbstract) != 0;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool IsMdSpecialName(this CorMethodAttr attr) => (attr & mdSpecialName) != 0;

        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool IsMdPinvokeImpl(this CorMethodAttr attr) => (attr & mdPinvokeImpl) != 0;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool IsMdUnmanagedExport(this CorMethodAttr attr) => (attr & mdUnmanagedExport) != 0;

        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool IsMdRTSpecialName(this CorMethodAttr attr) => (attr & mdRTSpecialName) != 0;

        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool IsMdInstanceInitializer(this CorMethodAttr attr, string str) => (attr & mdRTSpecialName) != 0 && str == COR_CTOR_METHOD_NAME;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool IsMdClassConstructor(this CorMethodAttr attr, string str) => (attr & mdRTSpecialName) != 0 && str == COR_CCTOR_METHOD_NAME;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool IsMdHasSecurity(this CorMethodAttr attr) => (attr & mdHasSecurity) != 0;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool IsMdRequireSecObject(this CorMethodAttr attr) => (attr & mdRequireSecObject) != 0;

        #endregion
        #region CorFieldAttr

        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool IsFdPrivateScope(this CorFieldAttr attr) => (attr & fdFieldAccessMask) == fdPrivateScope;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool IsFdPrivate(this CorFieldAttr attr) => (attr & fdFieldAccessMask) == fdPrivate;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool IsFdFamANDAssem(this CorFieldAttr attr) => (attr & fdFieldAccessMask) == fdFamANDAssem;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool IsFdAssembly(this CorFieldAttr attr) => (attr & fdFieldAccessMask) == fdAssembly;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool IsFdFamily(this CorFieldAttr attr) => (attr & fdFieldAccessMask) == fdFamily;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool IsFdFamORAssem(this CorFieldAttr attr) => (attr & fdFieldAccessMask) == fdFamORAssem;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool IsFdPublic(this CorFieldAttr attr) => (attr & fdFieldAccessMask) == fdPublic;

        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool IsFdStatic(this CorFieldAttr attr) => (attr & fdStatic) != 0;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool IsFdInitOnly(this CorFieldAttr attr) => (attr & fdInitOnly) != 0;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool IsFdLiteral(this CorFieldAttr attr) => (attr & fdLiteral) != 0;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool IsFdNotSerialized(this CorFieldAttr attr) => (attr & fdNotSerialized) != 0;

        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool IsFdPinvokeImpl(this CorFieldAttr attr) => (attr & fdPinvokeImpl) != 0;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool IsFdSpecialName(this CorFieldAttr attr) => (attr & fdSpecialName) != 0;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool IsFdHasFieldRVA(this CorFieldAttr attr) => (attr & fdHasFieldRVA) != 0;

        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool IsFdRTSpecialName(this CorFieldAttr attr) => (attr & fdRTSpecialName) != 0;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool IsFdHasFieldMarshal(this CorFieldAttr attr) => (attr & fdHasFieldMarshal) != 0;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool IsFdHasDefault(this CorFieldAttr attr) => (attr & fdHasDefault) != 0;

        #endregion
        #region CorParamAttr

        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool IsPdIn(this CorParamAttr attr) => (attr & pdIn) != 0;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool IsPdOut(this CorParamAttr attr) => (attr & pdOut) != 0;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool IsPdOptional(this CorParamAttr attr) => (attr & pdOptional) != 0;

        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool IsPdHasDefault(this CorParamAttr attr) => (attr & pdHasDefault) != 0;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool IsPdHasFieldMarshal(this CorParamAttr attr) => (attr & pdHasFieldMarshal) != 0;

        #endregion
        #region CorPropertyAttr

        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool IsPrSpecialName(this CorPropertyAttr attr) => (attr & prSpecialName) != 0;

        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool IsPrRTSpecialName(this CorPropertyAttr attr) => (attr & prRTSpecialName) != 0;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool IsPrHasDefault(this CorPropertyAttr attr) => (attr & prHasDefault) != 0;

        #endregion
        #region CorEventAttr

        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool IsEvSpecialName(this CorEventAttr attr) => (attr & evSpecialName) != 0;

        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool IsEvRTSpecialName(this CorEventAttr attr) => (attr & evRTSpecialName) != 0;

        #endregion
        #region CorMethodSemanticsAttr

        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool IsMsSetter(this CorMethodSemanticsAttr attr) => (attr & msSetter) != 0;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool IsMsGetter(this CorMethodSemanticsAttr attr) => (attr & msGetter) != 0;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool IsMsOther(this CorMethodSemanticsAttr attr) => (attr & msOther) != 0;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool IsMsAddOn(this CorMethodSemanticsAttr attr) => (attr & msAddOn) != 0;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool IsMsRemoveOn(this CorMethodSemanticsAttr attr) => (attr & msRemoveOn) != 0;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool IsMsFire(this CorMethodSemanticsAttr attr) => (attr & msFire) != 0;

        #endregion
        #region CorDeclSecurity

        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool IsDclActionNil(this CorDeclSecurity attr) => (attr & dclActionMask) == dclActionNil;

        // Is this a demand that can trigger a stackwalk?
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool IsDclActionAnyStackModifier(this CorDeclSecurity attr) =>
            (attr & dclActionMask) == dclAssert || (attr & dclActionMask) == dclDeny  || (attr & dclActionMask) == dclPermitOnly;

        // Is this an assembly level attribute (i.e. not applicable on Type/Member)?
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool IsAssemblyDclAction(this CorDeclSecurity attr) =>
            (attr >= dclRequestMinimum) && attr <= dclRequestRefuse;

        // Is this an NGen only attribute?
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool IsNGenOnlyDclAction(this CorDeclSecurity attr) =>
            attr == dclPrejitGrant || attr == dclPrejitDenied;

        #endregion
        #region CorMethodImpl

        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool IsMiIL(this CorMethodImpl attr) => (attr & miCodeTypeMask) == miIL;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool IsMiNative(this CorMethodImpl attr) => (attr & miCodeTypeMask) == miNative;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool IsMiOPTIL(this CorMethodImpl attr) => (attr & miCodeTypeMask) == miOPTIL;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool IsMiRuntime(this CorMethodImpl attr) => (attr & miCodeTypeMask) == miRuntime;

        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool IsMiUnmanaged(this CorMethodImpl attr) => (attr & miManagedMask) == miUnmanaged;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool IsMiManaged(this CorMethodImpl attr) => (attr & miManagedMask) == miManaged;

        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool IsMiForwardRef(this CorMethodImpl attr) => (attr & miForwardRef) != 0;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool IsMiPreserveSig(this CorMethodImpl attr) => (attr & miPreserveSig) != 0;

        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool IsMiInternalCall(this CorMethodImpl attr) => (attr & miInternalCall) != 0;

        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool IsMiSynchronized(this CorMethodImpl attr) => (attr & miSynchronized) != 0;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool IsMiNoInlining(this CorMethodImpl attr) => (attr & miNoInlining) != 0;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool IsMiAggressiveInlining(this CorMethodImpl attr) => (attr & miAggressiveInlining) != 0;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool IsMiNoOptimization(this CorMethodImpl attr) => (attr & miNoOptimization) != 0;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool IsMiAggressiveOptimization(this CorMethodImpl attr) => (attr & (miAggressiveOptimization | miNoOptimization)) == miAggressiveOptimization;


        #endregion
        #region CorPinvokeMap

        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool IsPmNoMangle(this CorPinvokeMap attr) => (attr & pmNoMangle) != 0;

        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool IsPmCharSetNotSpec(this CorPinvokeMap attr) => (attr & pmCharSetMask) == pmCharSetNotSpec;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool IsPmCharSetAnsi(this CorPinvokeMap attr) => (attr & pmCharSetMask) == pmCharSetAnsi;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool IsPmCharSetUnicode(this CorPinvokeMap attr) => (attr & pmCharSetMask) == pmCharSetUnicode;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool IsPmCharSetAuto(this CorPinvokeMap attr) => (attr & pmCharSetMask) == pmCharSetAuto;

        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool IsPmSupportsLastError(this CorPinvokeMap attr) => (attr & pmSupportsLastError) != 0;

        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool IsPmCallConvWinapi(this CorPinvokeMap attr) => (attr & pmCallConvMask) == pmCallConvWinapi;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool IsPmCallConvCdecl(this CorPinvokeMap attr) => (attr & pmCallConvMask) == pmCallConvCdecl;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool IsPmCallConvStdcall(this CorPinvokeMap attr) => (attr & pmCallConvMask) == pmCallConvStdcall;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool IsPmCallConvThiscall(this CorPinvokeMap attr) => (attr & pmCallConvMask) == pmCallConvThiscall;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool IsPmCallConvFastcall(this CorPinvokeMap attr) => (attr & pmCallConvMask) == pmCallConvFastcall;

        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool IsPmBestFitEnabled(this CorPinvokeMap attr) => (attr & pmBestFitMask) == pmBestFitEnabled;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool IsPmBestFitDisabled(this CorPinvokeMap attr) => (attr & pmBestFitMask) == pmBestFitDisabled;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool IsPmBestFitUseAssem(this CorPinvokeMap attr) => (attr & pmBestFitMask) == pmBestFitUseAssem;

        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool IsPmThrowOnUnmappableCharEnabled(this CorPinvokeMap attr) => (attr & pmThrowOnUnmappableCharMask) == pmThrowOnUnmappableCharEnabled;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool IsPmThrowOnUnmappableCharDisabled(this CorPinvokeMap attr) => (attr & pmThrowOnUnmappableCharMask) == pmThrowOnUnmappableCharDisabled;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool IsPmThrowOnUnmappableCharUseAssem(this CorPinvokeMap attr) => (attr & pmThrowOnUnmappableCharMask) == pmThrowOnUnmappableCharUseAssem;


        #endregion
        #region CorAssemblyFlags

        // Macros for accessing the members of CorAssemblyFlags.
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool IsAfRetargetable(this CorAssemblyFlags attr) => (attr & afRetargetable) != 0;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool IsAfContentType_Default(this CorAssemblyFlags attr) => (attr & afContentType_Mask) == afContentType_Default;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool IsAfContentType_WindowsRuntime(this CorAssemblyFlags attr) => (attr & afContentType_Mask) == afContentType_WindowsRuntime;

        // Macros for accessing the Processor Architecture flags of CorAssemblyFlags.
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool IsAfPA_MSIL(this CorAssemblyFlags attr) => (attr & afPA_Mask) == afPA_MSIL;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool IsAfPA_x86(this CorAssemblyFlags attr) => (attr & afPA_Mask) == afPA_x86;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool IsAfPA_IA64(this CorAssemblyFlags attr) => (attr & afPA_Mask) == afPA_IA64;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool IsAfPA_AMD64(this CorAssemblyFlags attr) => (attr & afPA_Mask) == afPA_AMD64;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool IsAfPA_ARM(this CorAssemblyFlags attr) => (attr & afPA_Mask) == afPA_ARM;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool IsAfPA_ARM64(this CorAssemblyFlags attr) => (attr & afPA_Mask) == afPA_ARM64;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool IsAfPA_NoPlatform(this CorAssemblyFlags attr) => (attr & afPA_FullMask) == afPA_NoPlatform;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool IsAfPA_Specified(this CorAssemblyFlags attr) => (attr & afPA_Specified) != 0;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool PAIndex(this CorAssemblyFlags attr) => ((int) (attr & afPA_Mask) >> (int) afPA_Shift) != 0;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool PAFlag(this CorAssemblyFlags attr) => ((((int) attr) << (int) afPA_Shift) & (int) afPA_Mask) != 0;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static CorAssemblyFlags PrepareForSaving(this CorAssemblyFlags attr) => (attr & ((attr & afPA_Specified) != 0 ? ~afPA_Specified : ~afPA_FullMask));

        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool IsAfEnableJITcompileTracking(this CorAssemblyFlags attr) => (attr & afEnableJITcompileTracking) != 0;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool IsAfDisableJITcompileOptimizer(this CorAssemblyFlags attr) => (attr & afDisableJITcompileOptimizer) != 0;

        // Macros for accessing the public key flags of CorAssemblyFlags.
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool IsAfPublicKey(this CorAssemblyFlags attr) => (attr & afPublicKey) != 0;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool IsAfPublicKeyToken(this CorAssemblyFlags attr) => (attr & afPublicKey) == 0;

        #endregion
        #region CorManifestResourceFlags

        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool IsMrPublic(this CorManifestResourceFlags attr) => (attr & mrVisibilityMask) == mrPublic;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool IsMrPrivate(this CorManifestResourceFlags attr) => (attr & mrVisibilityMask) == mrPrivate;

        #endregion
        #region CorFileFlags

        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool IsFfContainsMetaData(this CorFileFlags attr) => (attr & ffContainsNoMetaData) == 0;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool IsFfContainsNoMetaData(this CorFileFlags attr) => (attr & ffContainsNoMetaData) != 0;

        #endregion
    }
}
