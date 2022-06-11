namespace ManagedCorDebug
{
    public struct GetInterfaceImplPropsResult
    {
        public mdTypeDef PClass { get; }

        public mdToken PtkIface { get; }

        public GetInterfaceImplPropsResult(mdTypeDef pClass, mdToken ptkIface)
        {
            PClass = pClass;
            PtkIface = ptkIface;
        }
    }
}