namespace ClrDebug.PDB
{
    public enum CV_BuildInfo_e
    {
        CV_BuildInfo_CurrentDirectory = 0,

        /// <summary>
        /// Cl.exe
        /// </summary>
        CV_BuildInfo_BuildTool = 1,

        /// <summary>
        /// foo.cpp
        /// </summary>
        CV_BuildInfo_SourceFile = 2,

        /// <summary>
        /// foo.pdb
        /// </summary>
        CV_BuildInfo_ProgramDatabaseFile = 3,

        /// <summary>
        /// -I etc
        /// </summary>
        CV_BuildInfo_CommandArguments = 4,

        CV_BUILDINFO_KNOWN
    }
}
