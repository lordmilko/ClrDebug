﻿using System.Runtime.InteropServices;

namespace ClrDebug
{
    /// <summary>
    /// Provides methods to validate metadata signatures.
    /// </summary>
    [Guid("4709C9C6-81FF-11D3-9FC7-00C04F79A0A3")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [ComImport]
    public interface IMetaDataValidate
    {
        /// <summary>
        /// Sets a flag that specifies the type of the module in the current metadata scope, and registers the specified callback method for validation errors.
        /// </summary>
        /// <param name="dwModuleType">[in] A value of the <see cref="CorValidatorModuleType"/> enumeration that specifies the type of the module in the current metadata scope.</param>
        /// <param name="pUnk">[in] A pointer to an IUnknown instance that serves as a function callback for validation errors.</param>
        [PreserveSig]
        HRESULT ValidatorInit(
            [In] int dwModuleType,
            [In, MarshalAs(UnmanagedType.IUnknown)] object pUnk);

        /// <summary>
        /// Validates the metadata signatures of the objects in the current metadata scope.
        /// </summary>
        [PreserveSig]
        HRESULT ValidateMetaData();
    }
}
