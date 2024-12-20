namespace ClrDebug.DbgEng
{
    /// <summary>
    /// Defines the source language of a CU or other symbol.
    /// </summary>
    public enum SvcSourceLanguage : uint
    {
        SvcSourceLanguageUnknown = 0,
        SvcSourceLanguageC,
        SvcSourceLanguageCPlusPlus,
        SvcSourceLanguageAssembly,
        SvcSourceLanguageRust
    }
}
