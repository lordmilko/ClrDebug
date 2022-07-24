using System;
using System.Diagnostics;

namespace ClrDebug.DbgEng
{
    /// <summary>
    /// Encapsulates the results of the <see cref="WinDbgExtensionAPI.GetSymbol"/> method.
    /// </summary>
    [DebuggerDisplay("Buffer = {Buffer}, Displacement = {Displacement}")]
    public struct GetSymbolResult
    {
        public string Buffer;

        public IntPtr Displacement;

        public GetSymbolResult(string pchBuffer, IntPtr pDisplacement)
        {
            Buffer = pchBuffer;
            Displacement = pDisplacement;
        }
    }
}