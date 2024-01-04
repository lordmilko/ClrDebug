using System.Diagnostics;

namespace ClrDebug.DbgEng
{
    /// <summary>
    /// Encapsulates the results of the <see cref="ClrDacAndSosProvider.IsClrImage"/> method.
    /// </summary>
    [DebuggerDisplay("pIsClrImage = {pIsClrImage}, pbCanProvideClrDac = {pbCanProvideClrDac}, pbCanProvideClrSos = {pbCanProvideClrSos}")]
    public struct IsClrImageResult
    {
        public bool pIsClrImage { get; }

        public bool pbCanProvideClrDac { get; }

        public bool pbCanProvideClrSos { get; }

        public IsClrImageResult(bool pIsClrImage, bool pbCanProvideClrDac, bool pbCanProvideClrSos)
        {
            this.pIsClrImage = pIsClrImage;
            this.pbCanProvideClrDac = pbCanProvideClrDac;
            this.pbCanProvideClrSos = pbCanProvideClrSos;
        }
    }
}
