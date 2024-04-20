using System.Diagnostics;

namespace ClrDebug
{
    [DebuggerDisplay("Type = {Type.ToString(),nq}, Section = {Section.ToString(),nq}")]
    public struct READYTORUN_SECTION
    {
        public ReadyToRunSectionType Type; // READYTORUN_SECTION_XXX
        public IMAGE_DATA_DIRECTORY Section;
    }
}
