using System.Diagnostics;

namespace ClrDebug.DbgEng
{
    /// <summary>
    /// Encapsulates the results of the <see cref="SvcMemoryTranslation.TranslateAddress"/> method.
    /// </summary>
    [DebuggerDisplay("translatedOffset = {translatedOffset}, translatedContiguousByteCount = {translatedContiguousByteCount}, translationEntry = {translationEntry}")]
    public struct TranslateAddressResult
    {
        public long translatedOffset { get; }

        public long translatedContiguousByteCount { get; }

        public long translationEntry { get; }

        public TranslateAddressResult(long translatedOffset, long translatedContiguousByteCount, long translationEntry)
        {
            this.translatedOffset = translatedOffset;
            this.translatedContiguousByteCount = translatedContiguousByteCount;
            this.translationEntry = translationEntry;
        }
    }
}
