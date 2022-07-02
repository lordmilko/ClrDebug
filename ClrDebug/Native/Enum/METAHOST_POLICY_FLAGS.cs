using System;

namespace ClrDebug
{
    /// <summary>
    /// Provides binding policies that are common to most runtime hosts. This enumeration is used by the <see cref="ICLRMetaHostPolicy.GetRequestedRuntime"/> method.
    /// </summary>
    [Flags]
    public enum METAHOST_POLICY_FLAGS
    {
        /// <summary>
        /// Defines the high-compatibility policy, which does not consider any common language runtime (CLR) that is loaded into the current process.<para/>
        /// Instead, it considers only the installed CLRs and the preferences of the component, as derived from the assembly file itself, the declared built-against version, or the configuration file.
        /// </summary>
        HIGHCOMPAT = 0,

        /// <summary>
        /// Applies upgrade policy to the version bind result when an exact match is not found, based on the contents of HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\.NETFramework\Policy\Upgrades.<para/>
        /// This has the same effect as RUNTIME_INFO_FLAGS.RUNTIME_INFO_UPGRADE_VERSION.
        /// </summary>
        APPLY_UPGRADE_POLICY = 8,

        /// <summary>
        /// Binding results are returned as if the image provided to the call were launched in a new process. Currently, GetRequestedRuntime ignores the set of loadable runtimes and binds against the set of installed runtimes.<para/>
        /// This flag allows a host to determine which runtime an EXE will bind to when it is launched.
        /// </summary>
        EMULATE_EXE_LAUNCH = 16, // 0x00000010

        /// <summary>
        /// An error dialog box is displayed if GetRequestedRuntime is unable to find a runtime that is compatible with the input parameters.<para/>
        /// Beginning with the .NET Framework 4.5, this error dialog box can take the form of a Windows feature dialog box that asks whether the user would like to enable the appropriate feature.
        /// </summary>
        SHOW_ERROR_DIALOG = 32, // 0x00000020

        /// <summary>
        /// GetRequestedRuntime uses the process image (and any corresponding configuration file) as additional input to the binding process.<para/>
        /// By default, GetRequestedRuntime does not fall back to the process image path (typically, the EXE that was used to launch the process) when determining the runtime to bind to.
        /// </summary>
        USE_PROCESS_IMAGE_PATH = 64, // 0x00000040

        /// <summary>
        /// GetRequestedRuntime must check whether the appropriate SKU is installed when no information is available in the configuration file.<para/>
        /// This allows applications that do not have configuration files to fail gracefully on smaller SKUs than the default installation of the .NET Framework.<para/>
        /// By default, GetRequestedRuntime does not check whether the appropriate SKU is installed unless the SKU attribute is specified in the configuration file &lt;supportedRuntime /&gt; element.
        /// </summary>
        ENSURE_SKU_SUPPORTED = 128, // 0x00000080

        /// <summary>
        /// GetRequestedRuntime should ignore SEM_FAILCRITICALERRORS (which is set by calling the SetErrorMode function), and show the error dialog box.<para/>
        /// By default, SEM_FAILCRITICALERRORS suppresses the error dialog box. It may have been inherited from another process, and the silent error may be undesirable in your scenario.
        /// </summary>
        IGNORE_ERROR_MODE = 4096 // 0x00001000
    }
}