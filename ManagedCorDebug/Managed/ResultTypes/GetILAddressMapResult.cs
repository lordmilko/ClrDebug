using System.Diagnostics;

namespace ManagedCorDebug
{
    /// <summary>
    /// Encapsulates the results of the <see cref="XCLRDataMethodInstance.GetILAddressMap"/> method.
    /// </summary>
    [DebuggerDisplay("mapNeeded = {mapNeeded}, maps = {maps}")]
    public struct GetILAddressMapResult
    {
        public int mapNeeded { get; }

        public CLRDATA_IL_ADDRESS_MAP[] maps { get; }

        public GetILAddressMapResult(int mapNeeded, CLRDATA_IL_ADDRESS_MAP[] maps)
        {
            this.mapNeeded = mapNeeded;
            this.maps = maps;
        }
    }
}