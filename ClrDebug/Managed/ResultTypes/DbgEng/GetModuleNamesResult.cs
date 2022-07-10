using System.Diagnostics;

namespace ClrDebug.DbgEng
{
    /// <summary>
    /// Encapsulates the results of the <see cref="DebugSymbols.GetModuleNames"/> method.
    /// </summary>
    [DebuggerDisplay("ImageNameBuffer = {ImageNameBuffer}, ModuleNameBuffer = {ModuleNameBuffer}, LoadedImageNameBuffer = {LoadedImageNameBuffer}")]
    public struct GetModuleNamesResult
    {
        /// <summary>
        /// Receives the image name of the module. If ImageNameBuffer is NULL, this information is not returned.
        /// </summary>
        public string ImageNameBuffer { get; }

        /// <summary>
        /// Receives the module name of the module. If ModuleNameBuffer is NULL, this information is not returned.
        /// </summary>
        public string ModuleNameBuffer { get; }

        /// <summary>
        /// Receives the loaded image name of the module. If LoadedImageNameBuffer is NULL, this information is not returned.
        /// </summary>
        public string LoadedImageNameBuffer { get; }

        public GetModuleNamesResult(string imageNameBuffer, string moduleNameBuffer, string loadedImageNameBuffer)
        {
            ImageNameBuffer = imageNameBuffer;
            ModuleNameBuffer = moduleNameBuffer;
            LoadedImageNameBuffer = loadedImageNameBuffer;
        }
    }
}
