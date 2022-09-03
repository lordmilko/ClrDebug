using System.Diagnostics;

namespace ClrDebug.TypeLib
{
    [DebuggerDisplay("cElements = {cElements}, lLbound = {lLbound}")]
    public struct SAFEARRAYBOUND
    {
        public int cElements;
        public int lLbound;
    }
}
