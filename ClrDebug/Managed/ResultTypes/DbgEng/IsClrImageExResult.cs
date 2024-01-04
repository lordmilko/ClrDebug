using System.Diagnostics;

namespace ClrDebug.DbgEng
{
    /// <summary>
    /// Encapsulates the results of the <see cref="ClrDacDbiAndSosProvider.IsClrImageEx"/> method.
    /// </summary>
    [DebuggerDisplay("pIsClrImage = {pIsClrImage}, pbCanProvideClrDac = {pbCanProvideClrDac}, pbCanProvideClrDbi = {pbCanProvideClrDbi}, pbCanProvideClrSos = {pbCanProvideClrSos}")]
    public struct IsClrImageExResult
    {
        public bool pIsClrImage { get; }

        public bool pbCanProvideClrDac { get; }

        public bool pbCanProvideClrDbi { get; }

        public bool pbCanProvideClrSos { get; }

        public IsClrImageExResult(bool pIsClrImage, bool pbCanProvideClrDac, bool pbCanProvideClrDbi, bool pbCanProvideClrSos)
        {
            this.pIsClrImage = pIsClrImage;
            this.pbCanProvideClrDac = pbCanProvideClrDac;
            this.pbCanProvideClrDbi = pbCanProvideClrDbi;
            this.pbCanProvideClrSos = pbCanProvideClrSos;
        }
    }
}
