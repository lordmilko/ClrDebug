# Normal

Write-Host "Generating normal..."

$normalArgs = @{
    Path = "$PSScriptRoot\ClrDebug"
    NumberAsValueOnSimpleInvocation = $true
    Namespace = "ClrDebug"
    Partial = "cordebug","CLRMetaHost","CLRMetaHostPolicy","CLRDebugging","metadatadispenserex"
    FancyExceptions = $true
    Skip = "*CorDebugManagedCallbackEventArgs","ClassFactory"
    ManualArray = "isosdacinterface.getappdomainlist","ICorDebugCode.GetCode","ITypeInfo.GetNames","ITypeLib.FindName"
    MaxPathArray = "ixclrdata*.getfilename"
    MaxLongPathArray = "ISymNGenWriter*.QueryPDBNameExW"
    SkipFolder = "DbgEng"
    NotAbstract = "ICorDebugReferenceValue","IMetaDataDispenser"

    # Indicates that the string is not null terminated and that we should convert to a string by specifying the specific number of characters to read
    NonNullString = "IMetaDataImport.GetUserString"

    ComPrefix = "IStream","ITypeLib"
    MirrorNamespace = $true
    BaseCallbackTypes = "ICorProfilerCallback*"

    CharArrayHandler = "ClrDebug.Extensions.CreateString"
}

New-ComWrapper @normalArgs

Write-Host "Generating DbgEng..."

# DbgEng

$dbgEngArgs = @{
    Path = "$PSScriptRoot\ClrDebug"
    NumberAsValueOnSimpleInvocation = $true
    Namespace = "ClrDebug.DbgEng"
    Partial = "DebugClient"
    FancyExceptions = $true
    Skip = "*Callback*"
    IncludeFolders = "dbgeng"
    VTable = $true
    DefaultFolder = "DbgEng"
    FancyExceptionHandler = "ThrowDbgEngNotOK"
    CDecl = "IDebugControl*.Output","IDebugControl*.OutputWide","IDebugControl*.ControlledOutput*","IDebugControl*.OutputPrompt*"
    FailedOnlyFancyExceptionHandler = "ThrowDbgEngFailed"
    ManualArray = "idebugcontrol.getstacktrace","idebugcontrol5.getstacktraceex"

    CharArrayHandler = "ClrDebug.Extensions.CreateString"
}

New-ComWrapper @dbgEngArgs