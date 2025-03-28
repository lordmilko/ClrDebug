﻿/********************************************************************************
 * This code was generated by a tool.                                           *
 * Please do not modify this file directly - modify DelegateProvider.tt instead *
 ********************************************************************************/
using System;
using System.Runtime.InteropServices;
using static ClrDebug.Extensions;

namespace ClrDebug
{
    internal partial struct DelegateHolder
    {
        private IntPtr proc;

        internal DelegateHolder(IntPtr proc)
        {
            this.proc = proc;
        }
    }

    internal struct DelegateProvider
    {
        private IntPtr hModule;

        internal DelegateProvider(IntPtr hModule)
        {
            this.hModule = hModule;
        }

        public CLRCreateInstanceDelegate CLRCreateInstance
        {
            get
            {
                var export = GetExport(hModule, nameof(CLRCreateInstance));

#if GENERATED_MARSHALLING
                return new DelegateHolder(export).CLRCreateInstance;
#else
                return Marshal.GetDelegateForFunctionPointer<CLRCreateInstanceDelegate>(export);
#endif
            }
        }

        public CloseCLREnumerationDelegate CloseCLREnumeration
        {
            get
            {
                var export = GetExport(hModule, nameof(CloseCLREnumeration));

#if GENERATED_MARSHALLING
                return new DelegateHolder(export).CloseCLREnumeration;
#else
                return Marshal.GetDelegateForFunctionPointer<CloseCLREnumerationDelegate>(export);
#endif
            }
        }

        public CloseResumeHandleDelegate CloseResumeHandle
        {
            get
            {
                var export = GetExport(hModule, nameof(CloseResumeHandle));

#if GENERATED_MARSHALLING
                return new DelegateHolder(export).CloseResumeHandle;
#else
                return Marshal.GetDelegateForFunctionPointer<CloseResumeHandleDelegate>(export);
#endif
            }
        }

        public CreateVersionStringFromModuleDelegate CreateVersionStringFromModule
        {
            get
            {
                var export = GetExport(hModule, nameof(CreateVersionStringFromModule));

#if GENERATED_MARSHALLING
                return new DelegateHolder(export).CreateVersionStringFromModule;
#else
                return Marshal.GetDelegateForFunctionPointer<CreateVersionStringFromModuleDelegate>(export);
#endif
            }
        }

        public CreateDebuggingInterfaceFromVersionDelegate CreateDebuggingInterfaceFromVersion
        {
            get
            {
                var export = GetExport(hModule, nameof(CreateDebuggingInterfaceFromVersion));

#if GENERATED_MARSHALLING
                return new DelegateHolder(export).CreateDebuggingInterfaceFromVersion;
#else
                return Marshal.GetDelegateForFunctionPointer<CreateDebuggingInterfaceFromVersionDelegate>(export);
#endif
            }
        }

        public CreateDebuggingInterfaceFromVersionExDelegate CreateDebuggingInterfaceFromVersionEx
        {
            get
            {
                var export = GetExport(hModule, nameof(CreateDebuggingInterfaceFromVersionEx));

#if GENERATED_MARSHALLING
                return new DelegateHolder(export).CreateDebuggingInterfaceFromVersionEx;
#else
                return Marshal.GetDelegateForFunctionPointer<CreateDebuggingInterfaceFromVersionExDelegate>(export);
#endif
            }
        }

        public CreateDebuggingInterfaceFromVersion2Delegate CreateDebuggingInterfaceFromVersion2
        {
            get
            {
                var export = GetExport(hModule, nameof(CreateDebuggingInterfaceFromVersion2));

#if GENERATED_MARSHALLING
                return new DelegateHolder(export).CreateDebuggingInterfaceFromVersion2;
#else
                return Marshal.GetDelegateForFunctionPointer<CreateDebuggingInterfaceFromVersion2Delegate>(export);
#endif
            }
        }

        public CreateDebuggingInterfaceFromVersion3Delegate CreateDebuggingInterfaceFromVersion3
        {
            get
            {
                var export = GetExport(hModule, nameof(CreateDebuggingInterfaceFromVersion3));

#if GENERATED_MARSHALLING
                return new DelegateHolder(export).CreateDebuggingInterfaceFromVersion3;
#else
                return Marshal.GetDelegateForFunctionPointer<CreateDebuggingInterfaceFromVersion3Delegate>(export);
#endif
            }
        }

        public CreateProcessForLaunchDelegate CreateProcessForLaunch
        {
            get
            {
                var export = GetExport(hModule, nameof(CreateProcessForLaunch));

#if GENERATED_MARSHALLING
                return new DelegateHolder(export).CreateProcessForLaunch;
#else
                return Marshal.GetDelegateForFunctionPointer<CreateProcessForLaunchDelegate>(export);
#endif
            }
        }

        public EnumerateCLRsDelegate EnumerateCLRs
        {
            get
            {
                var export = GetExport(hModule, nameof(EnumerateCLRs));

#if GENERATED_MARSHALLING
                return new DelegateHolder(export).EnumerateCLRs;
#else
                return Marshal.GetDelegateForFunctionPointer<EnumerateCLRsDelegate>(export);
#endif
            }
        }

        public GetStartupNotificationEventDelegate GetStartupNotificationEvent
        {
            get
            {
                var export = GetExport(hModule, nameof(GetStartupNotificationEvent));

#if GENERATED_MARSHALLING
                return new DelegateHolder(export).GetStartupNotificationEvent;
#else
                return Marshal.GetDelegateForFunctionPointer<GetStartupNotificationEventDelegate>(export);
#endif
            }
        }

        public PSTARTUP_CALLBACK PSTARTUP_CALLBACK
        {
            get
            {
                var export = GetExport(hModule, nameof(PSTARTUP_CALLBACK));

#if GENERATED_MARSHALLING
                return new DelegateHolder(export).PSTARTUP_CALLBACK;
#else
                return Marshal.GetDelegateForFunctionPointer<PSTARTUP_CALLBACK>(export);
#endif
            }
        }

        public RegisterForRuntimeStartupDelegate RegisterForRuntimeStartup
        {
            get
            {
                var export = GetExport(hModule, nameof(RegisterForRuntimeStartup));

#if GENERATED_MARSHALLING
                return new DelegateHolder(export).RegisterForRuntimeStartup;
#else
                return Marshal.GetDelegateForFunctionPointer<RegisterForRuntimeStartupDelegate>(export);
#endif
            }
        }

        public RegisterForRuntimeStartupExDelegate RegisterForRuntimeStartupEx
        {
            get
            {
                var export = GetExport(hModule, nameof(RegisterForRuntimeStartupEx));

#if GENERATED_MARSHALLING
                return new DelegateHolder(export).RegisterForRuntimeStartupEx;
#else
                return Marshal.GetDelegateForFunctionPointer<RegisterForRuntimeStartupExDelegate>(export);
#endif
            }
        }

        public RegisterForRuntimeStartup3Delegate RegisterForRuntimeStartup3
        {
            get
            {
                var export = GetExport(hModule, nameof(RegisterForRuntimeStartup3));

#if GENERATED_MARSHALLING
                return new DelegateHolder(export).RegisterForRuntimeStartup3;
#else
                return Marshal.GetDelegateForFunctionPointer<RegisterForRuntimeStartup3Delegate>(export);
#endif
            }
        }

        public ResumeProcessDelegate ResumeProcess
        {
            get
            {
                var export = GetExport(hModule, nameof(ResumeProcess));

#if GENERATED_MARSHALLING
                return new DelegateHolder(export).ResumeProcess;
#else
                return Marshal.GetDelegateForFunctionPointer<ResumeProcessDelegate>(export);
#endif
            }
        }

        public UnregisterForRuntimeStartupDelegate UnregisterForRuntimeStartup
        {
            get
            {
                var export = GetExport(hModule, nameof(UnregisterForRuntimeStartup));

#if GENERATED_MARSHALLING
                return new DelegateHolder(export).UnregisterForRuntimeStartup;
#else
                return Marshal.GetDelegateForFunctionPointer<UnregisterForRuntimeStartupDelegate>(export);
#endif
            }
        }

        public CLRDataCreateInstanceDelegate CLRDataCreateInstance
        {
            get
            {
                var export = GetExport(hModule, nameof(CLRDataCreateInstance));

#if GENERATED_MARSHALLING
                return new DelegateHolder(export).CLRDataCreateInstance;
#else
                return Marshal.GetDelegateForFunctionPointer<CLRDataCreateInstanceDelegate>(export);
#endif
            }
        }

        public MetaDataGetDispenserDelegate MetaDataGetDispenser
        {
            get
            {
                var export = GetExport(hModule, nameof(MetaDataGetDispenser));

#if GENERATED_MARSHALLING
                return new DelegateHolder(export).MetaDataGetDispenser;
#else
                return Marshal.GetDelegateForFunctionPointer<MetaDataGetDispenserDelegate>(export);
#endif
            }
        }

        public DllGetClassObjectDelegate DllGetClassObject
        {
            get
            {
                var export = GetExport(hModule, nameof(DllGetClassObject));

#if GENERATED_MARSHALLING
                return new DelegateHolder(export).DllGetClassObject;
#else
                return Marshal.GetDelegateForFunctionPointer<DllGetClassObjectDelegate>(export);
#endif
            }
        }

        public get_hostfxr_path_fn get_hostfxr_path
        {
            get
            {
                var export = GetExport(hModule, nameof(get_hostfxr_path));

#if GENERATED_MARSHALLING
                return new DelegateHolder(export).get_hostfxr_path;
#else
                return Marshal.GetDelegateForFunctionPointer<get_hostfxr_path_fn>(export);
#endif
            }
        }

        public hostfxr_close_fn hostfxr_close
        {
            get
            {
                var export = GetExport(hModule, nameof(hostfxr_close));

#if GENERATED_MARSHALLING
                return new DelegateHolder(export).hostfxr_close;
#else
                return Marshal.GetDelegateForFunctionPointer<hostfxr_close_fn>(export);
#endif
            }
        }

        public hostfxr_get_available_sdks_fn hostfxr_get_available_sdks
        {
            get
            {
                var export = GetExport(hModule, nameof(hostfxr_get_available_sdks));

#if GENERATED_MARSHALLING
                return new DelegateHolder(export).hostfxr_get_available_sdks;
#else
                return Marshal.GetDelegateForFunctionPointer<hostfxr_get_available_sdks_fn>(export);
#endif
            }
        }

        public hostfxr_get_dotnet_environment_info_fn hostfxr_get_dotnet_environment_info
        {
            get
            {
                var export = GetExport(hModule, nameof(hostfxr_get_dotnet_environment_info));

#if GENERATED_MARSHALLING
                return new DelegateHolder(export).hostfxr_get_dotnet_environment_info;
#else
                return Marshal.GetDelegateForFunctionPointer<hostfxr_get_dotnet_environment_info_fn>(export);
#endif
            }
        }

        public hostfxr_get_native_search_directories_fn hostfxr_get_native_search_directories
        {
            get
            {
                var export = GetExport(hModule, nameof(hostfxr_get_native_search_directories));

#if GENERATED_MARSHALLING
                return new DelegateHolder(export).hostfxr_get_native_search_directories;
#else
                return Marshal.GetDelegateForFunctionPointer<hostfxr_get_native_search_directories_fn>(export);
#endif
            }
        }

        public hostfxr_get_runtime_delegate_fn hostfxr_get_runtime_delegate
        {
            get
            {
                var export = GetExport(hModule, nameof(hostfxr_get_runtime_delegate));

#if GENERATED_MARSHALLING
                return new DelegateHolder(export).hostfxr_get_runtime_delegate;
#else
                return Marshal.GetDelegateForFunctionPointer<hostfxr_get_runtime_delegate_fn>(export);
#endif
            }
        }

        public hostfxr_get_runtime_properties_fn hostfxr_get_runtime_properties
        {
            get
            {
                var export = GetExport(hModule, nameof(hostfxr_get_runtime_properties));

#if GENERATED_MARSHALLING
                return new DelegateHolder(export).hostfxr_get_runtime_properties;
#else
                return Marshal.GetDelegateForFunctionPointer<hostfxr_get_runtime_properties_fn>(export);
#endif
            }
        }

        public hostfxr_get_runtime_property_value_fn hostfxr_get_runtime_property_value
        {
            get
            {
                var export = GetExport(hModule, nameof(hostfxr_get_runtime_property_value));

#if GENERATED_MARSHALLING
                return new DelegateHolder(export).hostfxr_get_runtime_property_value;
#else
                return Marshal.GetDelegateForFunctionPointer<hostfxr_get_runtime_property_value_fn>(export);
#endif
            }
        }

        public hostfxr_initialize_for_dotnet_command_line_fn hostfxr_initialize_for_dotnet_command_line
        {
            get
            {
                var export = GetExport(hModule, nameof(hostfxr_initialize_for_dotnet_command_line));

#if GENERATED_MARSHALLING
                return new DelegateHolder(export).hostfxr_initialize_for_dotnet_command_line;
#else
                return Marshal.GetDelegateForFunctionPointer<hostfxr_initialize_for_dotnet_command_line_fn>(export);
#endif
            }
        }

        public hostfxr_initialize_for_runtime_config_fn hostfxr_initialize_for_runtime_config
        {
            get
            {
                var export = GetExport(hModule, nameof(hostfxr_initialize_for_runtime_config));

#if GENERATED_MARSHALLING
                return new DelegateHolder(export).hostfxr_initialize_for_runtime_config;
#else
                return Marshal.GetDelegateForFunctionPointer<hostfxr_initialize_for_runtime_config_fn>(export);
#endif
            }
        }

        public hostfxr_main_fn hostfxr_main
        {
            get
            {
                var export = GetExport(hModule, nameof(hostfxr_main));

#if GENERATED_MARSHALLING
                return new DelegateHolder(export).hostfxr_main;
#else
                return Marshal.GetDelegateForFunctionPointer<hostfxr_main_fn>(export);
#endif
            }
        }

        public hostfxr_main_bundle_startupinfo_fn hostfxr_main_bundle_startupinfo
        {
            get
            {
                var export = GetExport(hModule, nameof(hostfxr_main_bundle_startupinfo));

#if GENERATED_MARSHALLING
                return new DelegateHolder(export).hostfxr_main_bundle_startupinfo;
#else
                return Marshal.GetDelegateForFunctionPointer<hostfxr_main_bundle_startupinfo_fn>(export);
#endif
            }
        }

        public hostfxr_main_startupinfo_fn hostfxr_main_startupinfo
        {
            get
            {
                var export = GetExport(hModule, nameof(hostfxr_main_startupinfo));

#if GENERATED_MARSHALLING
                return new DelegateHolder(export).hostfxr_main_startupinfo;
#else
                return Marshal.GetDelegateForFunctionPointer<hostfxr_main_startupinfo_fn>(export);
#endif
            }
        }

        public hostfxr_resolve_sdk_fn hostfxr_resolve_sdk
        {
            get
            {
                var export = GetExport(hModule, nameof(hostfxr_resolve_sdk));

#if GENERATED_MARSHALLING
                return new DelegateHolder(export).hostfxr_resolve_sdk;
#else
                return Marshal.GetDelegateForFunctionPointer<hostfxr_resolve_sdk_fn>(export);
#endif
            }
        }

        public hostfxr_resolve_sdk2_fn hostfxr_resolve_sdk2
        {
            get
            {
                var export = GetExport(hModule, nameof(hostfxr_resolve_sdk2));

#if GENERATED_MARSHALLING
                return new DelegateHolder(export).hostfxr_resolve_sdk2;
#else
                return Marshal.GetDelegateForFunctionPointer<hostfxr_resolve_sdk2_fn>(export);
#endif
            }
        }

        public hostfxr_run_app_fn hostfxr_run_app
        {
            get
            {
                var export = GetExport(hModule, nameof(hostfxr_run_app));

#if GENERATED_MARSHALLING
                return new DelegateHolder(export).hostfxr_run_app;
#else
                return Marshal.GetDelegateForFunctionPointer<hostfxr_run_app_fn>(export);
#endif
            }
        }

        public hostfxr_set_error_writer_fn hostfxr_set_error_writer
        {
            get
            {
                var export = GetExport(hModule, nameof(hostfxr_set_error_writer));

#if GENERATED_MARSHALLING
                return new DelegateHolder(export).hostfxr_set_error_writer;
#else
                return Marshal.GetDelegateForFunctionPointer<hostfxr_set_error_writer_fn>(export);
#endif
            }
        }

        public hostfxr_set_runtime_property_value_fn hostfxr_set_runtime_property_value
        {
            get
            {
                var export = GetExport(hModule, nameof(hostfxr_set_runtime_property_value));

#if GENERATED_MARSHALLING
                return new DelegateHolder(export).hostfxr_set_runtime_property_value;
#else
                return Marshal.GetDelegateForFunctionPointer<hostfxr_set_runtime_property_value_fn>(export);
#endif
            }
        }

        public coreclr_create_delegate_fn coreclr_create_delegate
        {
            get
            {
                var export = GetExport(hModule, nameof(coreclr_create_delegate));

#if GENERATED_MARSHALLING
                return new DelegateHolder(export).coreclr_create_delegate;
#else
                return Marshal.GetDelegateForFunctionPointer<coreclr_create_delegate_fn>(export);
#endif
            }
        }

        public coreclr_execute_assembly_fn coreclr_execute_assembly
        {
            get
            {
                var export = GetExport(hModule, nameof(coreclr_execute_assembly));

#if GENERATED_MARSHALLING
                return new DelegateHolder(export).coreclr_execute_assembly;
#else
                return Marshal.GetDelegateForFunctionPointer<coreclr_execute_assembly_fn>(export);
#endif
            }
        }

        public coreclr_initialize_fn coreclr_initialize
        {
            get
            {
                var export = GetExport(hModule, nameof(coreclr_initialize));

#if GENERATED_MARSHALLING
                return new DelegateHolder(export).coreclr_initialize;
#else
                return Marshal.GetDelegateForFunctionPointer<coreclr_initialize_fn>(export);
#endif
            }
        }

        public coreclr_set_error_writer_fn coreclr_set_error_writer
        {
            get
            {
                var export = GetExport(hModule, nameof(coreclr_set_error_writer));

#if GENERATED_MARSHALLING
                return new DelegateHolder(export).coreclr_set_error_writer;
#else
                return Marshal.GetDelegateForFunctionPointer<coreclr_set_error_writer_fn>(export);
#endif
            }
        }

        public coreclr_shutdown_fn coreclr_shutdown
        {
            get
            {
                var export = GetExport(hModule, nameof(coreclr_shutdown));

#if GENERATED_MARSHALLING
                return new DelegateHolder(export).coreclr_shutdown;
#else
                return Marshal.GetDelegateForFunctionPointer<coreclr_shutdown_fn>(export);
#endif
            }
        }

        public coreclr_shutdown_2_fn coreclr_shutdown_2
        {
            get
            {
                var export = GetExport(hModule, nameof(coreclr_shutdown_2));

#if GENERATED_MARSHALLING
                return new DelegateHolder(export).coreclr_shutdown_2;
#else
                return Marshal.GetDelegateForFunctionPointer<coreclr_shutdown_2_fn>(export);
#endif
            }
        }

        public GetCLRRuntimeHostDelegate GetCLRRuntimeHost
        {
            get
            {
                var export = GetExport(hModule, nameof(GetCLRRuntimeHost));

#if GENERATED_MARSHALLING
                return new DelegateHolder(export).GetCLRRuntimeHost;
#else
                return Marshal.GetDelegateForFunctionPointer<GetCLRRuntimeHostDelegate>(export);
#endif
            }
        }
    }
}
