using System;
using System.Runtime.InteropServices;

namespace ClrDebug.PDB
{
    //mspdb140.dll seems quite similar to mspdbcore.dll, but it does not have all of the same exports (e.g. MSF related exports
    //only exist on mspdbcore.dll and not mspdb140.dll)

    #region Delegates

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate int PfnPDBQueryCallback(IntPtr pvClient, POVC povc);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate IntPtr MSFOpenWDelegate(
        [In, MarshalAs(UnmanagedType.LPWStr)] string wszFilename,
        [In, MarshalAs(UnmanagedType.Bool)] bool fWrite,
        [Out] out MSF_EC pec);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate IntPtr MSFOpenExWDelegate(
        [In, MarshalAs(UnmanagedType.LPWStr)] string wszFilename,
        [In, MarshalAs(UnmanagedType.Bool)] bool fWrite,
        [Out] out MSF_EC pec,
        [In] int cbPage);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate bool PDBOpen2WDelegate(
        [In, MarshalAs(UnmanagedType.LPWStr)] string wszPDB,
        [In, MarshalAs(UnmanagedType.LPWStr)] string szMode,
        [Out] out EC pec,
        [Out] IntPtr wszError,
        [In] IntPtr cchErrMax,
        [Out] out IntPtr pppdb);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate bool PDBOpenEx2WDelegate(
        [In, MarshalAs(UnmanagedType.LPWStr)] string wszPDB,
        [In, MarshalAs(UnmanagedType.LPWStr)] string szMode,
        [In] int cbPage,
        [Out] out EC pec,
        [Out] IntPtr wszError,
        [In] IntPtr cchErrMax,
        [Out] out IntPtr pppdb);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate bool PDBOpenNgenPdbDelegate(
        [In, MarshalAs(UnmanagedType.LPWStr)] string wszNgenImage,
        [In, MarshalAs(UnmanagedType.LPWStr)] string wszPdbPath,
        [Out] out EC pec,
        [Out] IntPtr wszError,
        [In] IntPtr cchErrMax,
        [Out] out IntPtr pppdb);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate bool PDBOpenValidate4Delegate(
        [In, MarshalAs(UnmanagedType.LPWStr)] string wszPDB,
        [In, MarshalAs(UnmanagedType.LPWStr)] string szMode,
        [In, MarshalAs(UnmanagedType.LPStruct)] Guid pcsig70,
        [In] int sig,
        [In] int age,
        [Out] out EC pec,
        [Out] IntPtr wszError,
        [In] IntPtr cchErrMax,
        [Out] out IntPtr pppdb);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate bool PDBOpenValidate5Delegate(
        [In, MarshalAs(UnmanagedType.LPWStr)] string wszExecutable,
        [In, MarshalAs(UnmanagedType.LPWStr)] string wszSearchPath,
        [In] IntPtr pvClient,
        [In, MarshalAs(UnmanagedType.FunctionPtr)] PfnPDBQueryCallback pfnQueryCallback,
        [Out] out EC pec,
        [Out] IntPtr wszError,
        [In] IntPtr cchErrMax,
        [Out] out IntPtr pppdb);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate bool NameMapOpenDelegate(
        [In] IntPtr ppdb,
        [In, MarshalAs(UnmanagedType.Bool)] bool fWrite,
        [Out] out IntPtr ppnm);

    #endregion

    /// <summary>
    /// Provides facilities for interacting with mspdbcore.dll, which ships with Visual Studio.<para/>
    /// This type only contains methods for interacting with C exports that are not otherwise defined as instance
    /// methods on PDB1-associated objects.<para/>
    /// Note: mspdbcore.dll may have other dependent DLLs that need to be loaded from the same directory as it. Consider using
    /// kernel32!SetDllDirectory or other techniques to ensure that all dependencies are properly loaded
    /// </summary>
    public class MsPdbCore
    {
        private DelegateProvider delegateProvider;

        public MsPdbCore(IntPtr hModule)
        {
            if (hModule == IntPtr.Zero)
                throw new ArgumentNullException(nameof(hModule));

            delegateProvider = new DelegateProvider(hModule);
        }

        #region MSFOpenW

        public MSF MSFOpenW(string wszFilename, bool fWrite)
        {
            var ec = TryMSFOpenW(wszFilename, fWrite, out var msf);

            if (ec != MSF_EC.MSF_EC_OK)
                throw new NotImplementedException();

            return msf;
        }

        public MSF_EC TryMSFOpenW(string wszFilename, bool fWrite, out MSF msf)
        {
            var @delegate = delegateProvider.MSFOpenW;

            var pMSF = @delegate(wszFilename, fWrite, out var ec);

            if (pMSF != IntPtr.Zero)
            {
                msf = new MSF(pMSF);
                return ec;
            }

            msf = default;
            return ec;
        }

        #endregion
        #region MSFOpenExW

        #endregion

        #region PDBOpen2W

        public PDB1 PDBOpen2W(string wszPDB, string szMode)
        {
            var ec = TryPDBOpen2W(wszPDB, szMode, out _, out var pdb);

            if (ec != EC.EC_OK)
                throw new NotImplementedException();

            return pdb;
        }

        public EC TryPDBOpen2W(string wszPDB, string szMode, out string wszError, out PDB1 ppPDB)
        {
            //todo: handle error message properly
            var @delegate = delegateProvider.PDBOpen2W;

            @delegate(wszPDB, szMode, out var pec, default, default, out var pppdb);

            if (pec != EC.EC_OK)
                throw new NotImplementedException(); //todo: how to get error message?

            wszError = default;
            ppPDB = new PDB1(pppdb);
            return EC.EC_OK;
        }

        #endregion
        #region PDBOpenEx2W
        #endregion
        #region PDBOpenNgenPdb
        #endregion

        //PDBOpenValidate4
        //PDBOpenValidate5
        //PDBOpenValidate6
        //PDBOpenValidate7

        #region NameMapOpen

        public NameMap NameMapOpen(IntPtr ppdb, bool fWrite)
        {
            if (!TryNameMapOpen(ppdb, fWrite, out var ppNM))
                throw new NotImplementedException();

            return ppNM;
        }

        public bool TryNameMapOpen(IntPtr ppdb, bool fWrite, out NameMap ppNM)
        {
            var @delegate = delegateProvider.NameMapOpen;

            if (@delegate(ppdb, fWrite, out var ppnm))
            {
                ppNM = new NameMap(ppnm);
                return true;
            }

            ppNM = default;
            return false;
        }

        #endregion
    }
}
