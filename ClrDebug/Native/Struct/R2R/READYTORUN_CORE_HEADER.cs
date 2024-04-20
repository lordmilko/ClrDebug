using System.Diagnostics;

namespace ClrDebug
{
    [DebuggerDisplay("Flags = {Flags.ToString(),nq}, NumberOfSections = {NumberOfSections}")]
    public struct READYTORUN_CORE_HEADER
    {
        public ReadyToRunFlag Flags; // READYTORUN_FLAG_XXX
        public int NumberOfSections;

        // Array of sections follows. The array entries are sorted by Type
        // READYTORUN_SECTION   Sections[];
    }
}
