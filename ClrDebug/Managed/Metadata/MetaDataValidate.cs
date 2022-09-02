namespace ClrDebug
{
    /// <summary>
    /// Provides methods to validate metadata signatures.
    /// </summary>
    public class MetaDataValidate : ComObject<IMetaDataValidate>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MetaDataValidate"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
        public MetaDataValidate(IMetaDataValidate raw) : base(raw)
        {
        }

        #region IMetaDataValidate
        #region ValidatorInit

        /// <summary>
        /// Sets a flag that specifies the type of the module in the current metadata scope, and registers the specified callback method for validation errors.
        /// </summary>
        /// <param name="dwModuleType">[in] A value of the <see cref="CorValidatorModuleType"/> enumeration that specifies the type of the module in the current metadata scope.</param>
        /// <param name="pUnk">[in] A pointer to an IUnknown instance that serves as a function callback for validation errors.</param>
        public void ValidatorInit(int dwModuleType, object pUnk)
        {
            TryValidatorInit(dwModuleType, pUnk).ThrowOnNotOK();
        }

        /// <summary>
        /// Sets a flag that specifies the type of the module in the current metadata scope, and registers the specified callback method for validation errors.
        /// </summary>
        /// <param name="dwModuleType">[in] A value of the <see cref="CorValidatorModuleType"/> enumeration that specifies the type of the module in the current metadata scope.</param>
        /// <param name="pUnk">[in] A pointer to an IUnknown instance that serves as a function callback for validation errors.</param>
        public HRESULT TryValidatorInit(int dwModuleType, object pUnk)
        {
            /*HRESULT ValidatorInit(
            [In] int dwModuleType,
            [In, MarshalAs(UnmanagedType.Interface)] object pUnk);*/
            return Raw.ValidatorInit(dwModuleType, pUnk);
        }

        #endregion
        #region ValidateMetaData

        /// <summary>
        /// Validates the metadata signatures of the objects in the current metadata scope.
        /// </summary>
        public void ValidateMetaData()
        {
            TryValidateMetaData().ThrowOnNotOK();
        }

        /// <summary>
        /// Validates the metadata signatures of the objects in the current metadata scope.
        /// </summary>
        public HRESULT TryValidateMetaData()
        {
            /*HRESULT ValidateMetaData();*/
            return Raw.ValidateMetaData();
        }

        #endregion
        #endregion
    }
}
