namespace ClrDebug.DbgEng
{
    public enum ServiceCapsThreadingKind : uint
    {
        /// <summary>
        /// ServiceCapsThreadingModel Indicates what the threading model of the service is. This data is an enum value of the type ServiceCapsThreadingModelKind expressed as four bytes of data.<para/>
        /// The default for this capability is 'ServiceCapsThreadingModelNone'.
        /// </summary>
        ServiceCapsThreadingModel = 0
    }
}
