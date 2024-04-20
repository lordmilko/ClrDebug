using System.Diagnostics;

namespace ClrDebug
{
    [DebuggerDisplay("Signature = {Signature}, MajorVersion = {MajorVersion}, MinorVersion = {MinorVersion}, CoreHeader = {CoreHeader.ToString(),nq}")]
    public struct READYTORUN_HEADER
    {
        public const int READYTORUN_SIGNATURE = 0x00525452; //'RTR'
        public int Signature; // READYTORUN_SIGNATURE
        public short MajorVersion; // READYTORUN_VERSION_XXX
        public short MinorVersion;
        public READYTORUN_CORE_HEADER CoreHeader;
    }
}
