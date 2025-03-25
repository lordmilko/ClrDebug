using System.Diagnostics;

namespace ClrDebug.TTD
{
    //TTDReplay (Undocumented)
    //x64 layout; x86 not yet known

    /// <summary>
    /// Represents an occurrence where a module was loaded.
    /// </summary>
    [DebuggerDisplay("Module = {Module->ToString()}, FirstSequence = {FirstSequence.ToString(\"X\")}, LastSequence = {LastSequence.ToString(\"X\")}")]
    public unsafe struct ModuleInstance
    {
        public Module* Module;

        //Based on observing that these numbers correspond with the sequences listed by dx @$curprocess.TTD.Events

        /// <summary>
        /// The first <see cref="Position.Sequence"/> where the module was loaded.
        /// </summary>
        public long FirstSequence;

        /// <summary>
        /// The last <see cref="Position.Sequence"/> where the module was loaded.
        /// </summary>
        public long LastSequence;

        public override string ToString()
        {
            if (Module != default)
                return Module->ToString();

            return base.ToString();
        }
    }
}
