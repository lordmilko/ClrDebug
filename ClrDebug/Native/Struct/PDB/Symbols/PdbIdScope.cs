using System.Diagnostics;

namespace ClrDebug.PDB
{
    /// <summary>
    /// Compilation Unit object file path include library name
    /// Or compile time PDB full path
    /// </summary>
    [DebuggerDisplay("{offObjectFilePath}")]
    public struct PdbIdScope
    {
        //This is an offset into /names
        public CV_off32_t offObjectFilePath;
    }
}
